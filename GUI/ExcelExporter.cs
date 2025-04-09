using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

public static class ExcelExporter
{
    public static void ExportToExcel(DataGridView dataGridView, string title)
    {
        try
        {
            // Kiểm tra xem Excel có cài đặt trên máy không
            bool hasExcel = IsExcelInstalled();

            if (hasExcel)
            {
                ExportWithExcelApp(dataGridView, title);
            }
            else
            {
                ExportToFileOnly(dataGridView, title);
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi",
            //              MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static bool IsExcelInstalled()
    {
        try
        {
            var excelApp = new Excel.Application();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void ExportWithExcelApp(DataGridView dataGridView, string title)
    {
        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;

        try
        {
            // Khởi tạo ứng dụng Excel
            excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Tạo workbook mới
            workbook = excelApp.Workbooks.Add(Type.Missing);
            worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Xuất dữ liệu
            ExportDataToWorksheet(dataGridView, title, worksheet);

            // Lưu file ra desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"{title}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            string filePath = Path.Combine(desktopPath, fileName);
            workbook.SaveAs(filePath);

            MessageBox.Show($"Xuất file Excel thành công! File đã được lưu tại:\n{filePath}", "Thành công",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            // Giải phóng tài nguyên
            if (workbook != null)
            {
                workbook.Close(false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            }
            if (excelApp != null)
            {
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }
    }

    private static void ExportToFileOnly(DataGridView dataGridView, string title)
    {
        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;

        try
        {
            // Khởi tạo ứng dụng Excel ẩn
            excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Tạo workbook mới
            workbook = excelApp.Workbooks.Add(Type.Missing);
            worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Xuất dữ liệu
            ExportDataToWorksheet(dataGridView, title, worksheet);

            // Lưu file ra desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"{title}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            string filePath = Path.Combine(desktopPath, fileName);
            workbook.SaveAs(filePath);

            MessageBox.Show($"Xuất file Excel thành công! File đã được lưu tại:\n{filePath}\n\n(Lưu ý: Máy bạn không có ứng dụng Excel nên file sẽ không được mở tự động)", "Thành công",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            // Giải phóng tài nguyên
            if (workbook != null)
            {
                workbook.Close(false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            }
            if (excelApp != null)
            {
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }
    }

    private static void ExportDataToWorksheet(DataGridView dataGridView, string title, Excel.Worksheet worksheet)
    {
        int columnCount = dataGridView.Columns.Count;

        // Đặt tiêu đề (gộp ô và căn giữa)
        Excel.Range titleRange = worksheet.Range["A1", GetExcelColumnName(columnCount) + "1"];
        titleRange.Merge();
        titleRange.Value = title;
        titleRange.Font.Bold = true;
        titleRange.Font.Size = 14;
        titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        // Đặt tiêu đề cột (hàng 2)
        for (int i = 0; i < columnCount; i++)
        {
            if (dataGridView.Columns[i].Visible)
            {
                worksheet.Cells[2, i + 1] = dataGridView.Columns[i].HeaderText;
            }
        }

        // Định dạng CHỈ các ô tiêu đề có chứa text
        for (int i = 1; i <= columnCount; i++)
        {
            if (worksheet.Cells[2, i].Value != null)
            {
                Excel.Range headerCell = worksheet.Cells[2, i];
                headerCell.Font.Bold = true;
                headerCell.Interior.Color = Color.LightGray.ToArgb();
                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
        }

        // Xuất dữ liệu (bắt đầu từ hàng 3)
        int rowIndex = 3;
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (!row.IsNewRow)
            {
                for (int colIndex = 0; colIndex < columnCount; colIndex++)
                {
                    if (dataGridView.Columns[colIndex].Visible)
                    {
                        var cellValue = row.Cells[colIndex].Value;
                        if (cellValue != null)
                        {
                            Excel.Range cell = worksheet.Cells[rowIndex, colIndex + 1];
                            cell.Value = cellValue.ToString();
                            cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                            // Định dạng số/ngày tháng phù hợp
                            if (row.Cells[colIndex].ValueType == typeof(decimal) ||
                                row.Cells[colIndex].ValueType == typeof(double) ||
                                row.Cells[colIndex].ValueType == typeof(int))
                            {
                                cell.NumberFormat = "#,##0";
                            }
                            else if (row.Cells[colIndex].ValueType == typeof(DateTime))
                            {
                                cell.NumberFormat = "dd/mm/yyyy hh:mm";
                            }
                        }
                    }
                }
                rowIndex++;
            }
        }

        // Tự động điều chỉnh độ rộng cột
        Excel.Range usedRange = worksheet.UsedRange;
        usedRange.Columns.AutoFit();

        // Cố định hàng tiêu đề
        worksheet.Application.ActiveWindow.SplitRow = 2;
        worksheet.Application.ActiveWindow.FreezePanes = true;
    }

    private static string GetExcelColumnName(int columnNumber)
    {
        string columnName = "";
        while (columnNumber > 0)
        {
            int modulo = (columnNumber - 1) % 26;
            columnName = Convert.ToChar('A' + modulo) + columnName;
            columnNumber = (columnNumber - modulo) / 26;
        }
        return columnName;
    }
}