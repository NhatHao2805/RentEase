using DAL.DAL_Service;
using DTO.DTO_Service;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL.BLL_Service
{
    public class ServiceBLL
    {
        private UpdatePriceDAL serviceDAL = new UpdatePriceDAL();
        static ServiceBLL()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public bool UpdateServicePrice(string serviceName, decimal newPrice)
        {
            return serviceDAL.UpdateServicePrice(serviceName, newPrice);
        }
        public static bool ExportServicesToExcelWithChart(string filePath, out string message)
        {
            message = "";
            try
            {
                // Lấy dữ liệu từ DAL
                var services = DichVuAccess.Load_DichVu();
                if (services == null || services.Count == 0)
                {
                    message = "Không có dữ liệu dịch vụ để xuất!";
                    return false;
                }

                // Tạo package Excel mới
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Tạo worksheet mới
                    var worksheet = package.Workbook.Worksheets.Add("Dịch Vụ");

                    // Thêm tiêu đề
                    worksheet.Cells[1, 1].Value = "ID Dịch Vụ";
                    worksheet.Cells[1, 2].Value = "Tên Dịch Vụ";
                    worksheet.Cells[1, 3].Value = "Giá Dịch Vụ";

                    // Định dạng tiêu đề
                    using (var range = worksheet.Cells[1, 1, 1, 3])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Thêm dữ liệu
                    int row = 2;
                    foreach (var service in services)
                    {
                        worksheet.Cells[row, 1].Value = service.ID;
                        worksheet.Cells[row, 2].Value = service.TenDichVu;
                        worksheet.Cells[row, 3].Value = service.GiaDichVu;
                        worksheet.Cells[row, 3].Style.Numberformat.Format = "#,##0";
                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Tạo biểu đồ tròn
                    var pieChart = worksheet.Drawings.AddPieChart("Biểu đồ dịch vụ", ePieChartType.Pie) as ExcelPieChart;
                    pieChart.Title.Text = "Phân bố giá dịch vụ";
                    pieChart.SetPosition(1, 0, 6, 0);
                    pieChart.SetSize(800, 400);

                    // Thêm dữ liệu vào biểu đồ
                    var series = pieChart.Series.Add(
                        worksheet.Cells[2, 3, row - 1, 3],
                        worksheet.Cells[2, 2, row - 1, 2]) as ExcelPieChartSerie;

                    // Thiết lập nhãn dữ liệu
                    series.DataLabel.ShowCategory = true;
                    series.DataLabel.ShowPercent = true;
                    series.DataLabel.ShowLeaderLines = true;
                    series.DataLabel.Separator = "; ";
                    series.DataLabel.Position = eLabelPosition.BestFit;

                    // Thêm định dạng phần trăm bằng XML (giữ lại số thập phân)
                    var xdoc = pieChart.ChartXml;
                    var nsuri = xdoc.DocumentElement.NamespaceURI;
                    var nsm = new XmlNamespaceManager(xdoc.NameTable);
                    nsm.AddNamespace("c", nsuri);

                    // Tạo nút numFmt để định dạng phần trăm với 2 chữ số thập phân
                    var numFmtNode = xdoc.CreateElement("c:numFmt", nsuri);

                    var formatCodeAtt = xdoc.CreateAttribute("formatCode", nsuri);
                    formatCodeAtt.Value = "0.00%"; // Format phần trăm với 2 số thập phân
                    numFmtNode.Attributes.Append(formatCodeAtt);

                    var sourceLinkedAtt = xdoc.CreateAttribute("sourceLinked", nsuri);
                    sourceLinkedAtt.Value = "0";
                    numFmtNode.Attributes.Append(sourceLinkedAtt);

                    // Tìm nút dLbls và thêm numFmt
                    var dLblsNode = xdoc.SelectSingleNode("c:chartSpace/c:chart/c:plotArea/c:pieChart/c:ser/c:dLbls", nsm);
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