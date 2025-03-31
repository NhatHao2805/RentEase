// File: BLL/Quanlyphuongtien/ParkingAreaBLL.cs
using System;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using System.IO;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System.Xml;


namespace BLL.Quanlyphuongtien
{
    public class ParkingAreaBLL
    {
        static ParkingAreaBLL()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public static event EventHandler ParkingAreaChanged;
        public static DataTable GetAllParkingAreas()
        {
            return ParkingAreaAccess.GetAllParkingAreas();
        }
        // Thêm vào file BLL/Quanlyphuongtien/ParkingAreaBLL.cs
        public static DataTable GetAllBuildings()
        {
            return ParkingAreaAccess.GetAllBuildings();
        }

        public static DataTable GetParkingAddresses()
        {
            return ParkingAreaAccess.GetParkingAddresses();
        }

        public static string GenerateNewParkingAreaId()
        {
            return ParkingAreaAccess.GenerateNewParkingAreaId();
        }

        public static DataTable GetParkingTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
            dt.Rows.Add("Xe máy");
            dt.Rows.Add("Ô tô");
            return dt;
        }

        public static DataTable GetCapacityOptions()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Capacity", typeof(int));
            for (int i = 1; i <= 100; i++)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }

        private static void OnParkingAreaChanged()
        {
            ParkingAreaChanged?.Invoke(null, EventArgs.Empty);
        }

        public static bool AddParkingArea(string buildingId, string address, string type, int capacity)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(buildingId) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(type) || capacity <= 0)
            {
                return false;
            }

            bool result = ParkingAreaAccess.AddParkingArea(buildingId, address, type, capacity);

            // Nếu thêm thành công thì kích hoạt event
            if (result)
            {
                OnParkingAreaChanged();
            }

            return result;
        }
        public static bool UpdateParkingArea(string areaId, string buildingId, string address, string type, int capacity, out string message)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(areaId) || string.IsNullOrEmpty(buildingId) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(type) || capacity <= 0)
            {
                message = "Vui lòng nhập đầy đủ thông tin!";
                return false;
            }
            return ParkingAreaAccess.UpdateParkingArea(areaId, buildingId, address, type, capacity, out message);
        }
        public static string GenerateNewBuildingId()
        {
            return ParkingAreaAccess.GenerateNewBuildingId();
        }
        public static bool DeleteParkingArea(string areaId, out string message)
        {
            if (string.IsNullOrEmpty(areaId))
            {
                message = "Vui lòng chọn khu vực đỗ xe để xóa!";
                return false;
            }

            bool result = ParkingAreaAccess.DeleteParkingArea(areaId, out message);

            if (result)
            {
                OnParkingAreaChanged();
            }

            return result;
        }
        public static bool ExportParkingAreasToCsv(string filePath, out string message)
        {
            message = "";
            try
            {
                // Lấy dữ liệu từ DAL
                DataTable dt = ParkingAreaAccess.GetAllParkingAreas();
                if (dt == null || dt.Rows.Count == 0)
                {
                    message = "Không có dữ liệu để xuất!";
                    return false;
                }

                // Tạo StringBuilder để xây dựng nội dung CSV
                StringBuilder csvContent = new StringBuilder();

                // Tiêu đề tiếng Việt cố định
                string[] headers = new string[]
                {
                    "ID Bãi Đỗ Xe",
                    "ID Tòa Nhà",
                    "Địa Chỉ",
                    "Loại Bãi Đỗ Xe",
                    "Sức Chứa"
                };
                // Ghi tiêu đề trực tiếp không qua Select
                csvContent.AppendLine(string.Join(",", headers));

                // Ghi dữ liệu từ DataTable
                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = new string[]
                    {
                        row["AREAID"]?.ToString().Trim() ?? "",
                        row["BUILDINGID"]?.ToString().Trim() ?? "",
                        row["ADDRESS"]?.ToString().Trim() ?? "",
                        row["TYPE"]?.ToString().Trim() ?? "",
                        row["CAPACITY"]?.ToString().Trim() ?? ""
                    };
                    csvContent.AppendLine(string.Join(",", fields));
                }

                // Lưu file với UTF-8 BOM để hỗ trợ tiếng Việt trong Excel
                File.WriteAllText(filePath, "\ufeff" + csvContent.ToString(), Encoding.UTF8);

                message = "Xuất file CSV thành công!";
                return true;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi xuất file CSV: " + ex.Message;
                return false;
            }
        }
        public static DataTable GetParkingAreasByBuildingId(string buildingId)
        {
            return ParkingAreaAccess.GetParkingAreasByBuildingId(buildingId);
        }
        public static bool ExportParkingAreasToExcelWithChart(string filePath, out string message)
        {
            message = "";
            try
            {
                // Lấy dữ liệu từ DAL
                DataTable dt = ParkingAreaAccess.GetAllParkingAreas();
                if (dt == null || dt.Rows.Count == 0)
                {
                    message = "Không có dữ liệu để xuất!";
                    return false;
                }

                // Tạo package Excel mới
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Tạo worksheet mới
                    var worksheet = package.Workbook.Worksheets.Add("Bãi Đỗ Xe");

                    // Thêm tiêu đề
                    worksheet.Cells[1, 1].Value = "ID Bãi Đỗ Xe";
                    worksheet.Cells[1, 2].Value = "ID Tòa Nhà";
                    worksheet.Cells[1, 3].Value = "Địa Chỉ";
                    worksheet.Cells[1, 4].Value = "Loại Bãi Đỗ Xe";
                    worksheet.Cells[1, 5].Value = "Sức Chứa";

                    // Định dạng tiêu đề
                    using (var range = worksheet.Cells[1, 1, 1, 5])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Thêm dữ liệu
                    int row = 2;
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        worksheet.Cells[row, 1].Value = dataRow["AREAID"].ToString();
                        worksheet.Cells[row, 2].Value = dataRow["BUILDINGID"].ToString();
                        worksheet.Cells[row, 3].Value = dataRow["ADDRESS"].ToString();
                        worksheet.Cells[row, 4].Value = dataRow["TYPE"].ToString();
                        worksheet.Cells[row, 5].Value = Convert.ToInt32(dataRow["CAPACITY"]);
                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Tạo biểu đồ Pie of Pie
                    var pieChart = worksheet.Drawings.AddOfPieChart("Biểu đồ sức chứa", eOfPieChartType.PieOfPie) as ExcelOfPieChart;
                    pieChart.Title.Text = "Sức chứa theo bãi đỗ xe";
                    pieChart.SetPosition(1, 0, 6, 0);
                    pieChart.SetSize(800, 400);

                    // Thêm dữ liệu vào biểu đồ

                    var series = pieChart.Series.Add(worksheet.Cells[2, 5, row - 1, 5], worksheet.Cells[2, 1, row - 1, 1]) as ExcelPieChartSerie;
                    series.Header = "Sức chứa";

                    // Thiết lập nhãn dữ liệu
                    series.DataLabel.ShowCategory = true;
                    series.DataLabel.ShowPercent = true;
                    series.DataLabel.ShowLeaderLines = true;
                    series.DataLabel.Separator = "; ";
                    series.DataLabel.Position = eLabelPosition.BestFit;

                    // Thêm định dạng phần trăm bằng XML
                    var xdoc = pieChart.ChartXml;
                    var nsuri = xdoc.DocumentElement.NamespaceURI;
                    var nsm = new XmlNamespaceManager(xdoc.NameTable);
                    nsm.AddNamespace("c", nsuri);

                    // Tạo nút numFmt
                    var numFmtNode = xdoc.CreateElement("c:numFmt", nsuri);

                    var formatCodeAtt = xdoc.CreateAttribute("formatCode", nsuri);
                    formatCodeAtt.Value = "0.00%"; // Format phần trăm với 2 số thập phân
                    numFmtNode.Attributes.Append(formatCodeAtt);

                    var sourceLinkedAtt = xdoc.CreateAttribute("sourceLinked", nsuri);
                    sourceLinkedAtt.Value = "0";
                    numFmtNode.Attributes.Append(sourceLinkedAtt);

                    // Tìm nút dLbls để thêm nút numFmt
                    var dLblsNode = xdoc.SelectSingleNode("c:chartSpace/c:chart/c:plotArea/c:ofPieChart/c:ser/c:dLbls", nsm);
                    if (dLblsNode != null)
                    {
                        dLblsNode.AppendChild(numFmtNode);
                    }

                    // Thêm chú thích (Legend)
                    pieChart.Legend.Add();
                    pieChart.Legend.Position = eLegendPosition.Right;

                    // Lưu file
                    package.Save();
                }

                message = "Xuất file Excel và biểu đồ thành công!";
                return true;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi xuất file Excel: " + ex.Message;
                return false;
            }
        }
    }


}