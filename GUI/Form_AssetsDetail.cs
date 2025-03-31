using BLL;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_AssetsDetail : Form
    {
        private string username;

        public Form_AssetsDetail(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadAssetsDetailData();
            ConfigureDataGridView();
        }

        private void LoadAssetsDetailData()
        {
            try
            {
                DataTable dt = AssetBLL.LoadAssetDetail(username);
                dgv_AssetsDetail.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết tài sản: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Thiết lập cơ bản
            dgv_AssetsDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_AssetsDetail.AllowUserToAddRows = false;
            dgv_AssetsDetail.ReadOnly = true;
            dgv_AssetsDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_AssetsDetail.RowHeadersVisible = false;
            dgv_AssetsDetail.ScrollBars = ScrollBars.Both;
            dgv_AssetsDetail.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv_AssetsDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv_AssetsDetail.EnableHeadersVisualStyles = false;
            dgv_AssetsDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dgv_AssetsDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_AssetsDetail.ColumnHeadersHeight = 30;
            dgv_AssetsDetail.RowTemplate.Height = 25;

            // Thiết lập từng cột với độ rộng phù hợp
            if (dgv_AssetsDetail.Columns.Count > 0)
            {
                // Đặt tên cột tiếng Việt cho thông tin tài sản (kết quả đầu tiên từ stored procedure)
                if (dgv_AssetsDetail.Columns.Contains("ASSETID"))
                    dgv_AssetsDetail.Columns["ASSETID"].HeaderText = "Mã tài sản";
                if (dgv_AssetsDetail.Columns.Contains("ASSETNAME"))
                    dgv_AssetsDetail.Columns["ASSETNAME"].HeaderText = "Tên tài sản";
                if (dgv_AssetsDetail.Columns.Contains("PRICE"))
                    dgv_AssetsDetail.Columns["PRICE"].HeaderText = "Giá trị";
                if (dgv_AssetsDetail.Columns.Contains("ASSET_STATUS"))
                    dgv_AssetsDetail.Columns["ASSET_STATUS"].HeaderText = "Trạng thái tài sản";
                if (dgv_AssetsDetail.Columns.Contains("USE_DATE"))
                    dgv_AssetsDetail.Columns["USE_DATE"].HeaderText = "Ngày sử dụng";

                // Thông tin phòng (kết quả đầu tiên từ stored procedure)
                if (dgv_AssetsDetail.Columns.Contains("ROOMID"))
                    dgv_AssetsDetail.Columns["ROOMID"].HeaderText = "Mã phòng";
                if (dgv_AssetsDetail.Columns.Contains("ROOM_TYPE"))
                    dgv_AssetsDetail.Columns["ROOM_TYPE"].HeaderText = "Loại phòng";
                if (dgv_AssetsDetail.Columns.Contains("FLOOR"))
                    dgv_AssetsDetail.Columns["FLOOR"].HeaderText = "Tầng";
                if (dgv_AssetsDetail.Columns.Contains("BUILDINGID"))
                    dgv_AssetsDetail.Columns["BUILDINGID"].HeaderText = "Mã tòa nhà";
                if (dgv_AssetsDetail.Columns.Contains("BUILDING_ADDRESS"))
                    dgv_AssetsDetail.Columns["BUILDING_ADDRESS"].HeaderText = "Địa chỉ tòa nhà";

                // Lịch sử bảo trì (kết quả thứ hai từ stored procedure)
                if (dgv_AssetsDetail.Columns.Contains("MAINTENANCEID"))
                    dgv_AssetsDetail.Columns["MAINTENANCEID"].HeaderText = "Mã bảo trì";
                if (dgv_AssetsDetail.Columns.Contains("MAINTENANCE_DATE"))
                    dgv_AssetsDetail.Columns["MAINTENANCE_DATE"].HeaderText = "Ngày bảo trì";
                if (dgv_AssetsDetail.Columns.Contains("DESCRIPTION"))
                    dgv_AssetsDetail.Columns["DESCRIPTION"].HeaderText = "Mô tả";
                if (dgv_AssetsDetail.Columns.Contains("MAINTENANCE_STATUS"))
                    dgv_AssetsDetail.Columns["MAINTENANCE_STATUS"].HeaderText = "Trạng thái bảo trì";

                // Yêu cầu sửa chữa (kết quả thứ ba từ stored procedure)
                if (dgv_AssetsDetail.Columns.Contains("REQUESTID"))
                    dgv_AssetsDetail.Columns["REQUESTID"].HeaderText = "Mã yêu cầu";
                if (dgv_AssetsDetail.Columns.Contains("REQUEST_DATE"))
                    dgv_AssetsDetail.Columns["REQUEST_DATE"].HeaderText = "Ngày yêu cầu";
                if (dgv_AssetsDetail.Columns.Contains("DESCRIPTION"))
                    dgv_AssetsDetail.Columns["DESCRIPTION"].HeaderText = "Mô tả";
                if (dgv_AssetsDetail.Columns.Contains("REQUEST_STATUS"))
                    dgv_AssetsDetail.Columns["REQUEST_STATUS"].HeaderText = "Trạng thái yêu cầu";
                if (dgv_AssetsDetail.Columns.Contains("FIRSTNAME"))
                    dgv_AssetsDetail.Columns["FIRSTNAME"].HeaderText = "Tên khách";
                if (dgv_AssetsDetail.Columns.Contains("LASTNAME"))
                    dgv_AssetsDetail.Columns["LASTNAME"].HeaderText = "Họ khách";
                if (dgv_AssetsDetail.Columns.Contains("PHONENUMBER"))
                    dgv_AssetsDetail.Columns["PHONENUMBER"].HeaderText = "Số điện thoại";

                // Đặt độ rộng cột mặc định
                foreach (DataGridViewColumn column in dgv_AssetsDetail.Columns)
                {
                    column.Width = 120; // Độ rộng mặc định
                }

                // Đặt độ rộng cụ thể cho một số cột
                if (dgv_AssetsDetail.Columns.Contains("ASSETNAME"))
                    dgv_AssetsDetail.Columns["ASSETNAME"].Width = 150;
                if (dgv_AssetsDetail.Columns.Contains("DESCRIPTION"))
                    dgv_AssetsDetail.Columns["DESCRIPTION"].Width = 200;
                if (dgv_AssetsDetail.Columns.Contains("BUILDING_ADDRESS"))
                    dgv_AssetsDetail.Columns["BUILDING_ADDRESS"].Width = 200;
                if (dgv_AssetsDetail.Columns.Contains("FIRSTNAME") && dgv_AssetsDetail.Columns.Contains("LASTNAME"))
                {
                    dgv_AssetsDetail.Columns["FIRSTNAME"].Width = 100;
                    dgv_AssetsDetail.Columns["LASTNAME"].Width = 100;
                }

                // Định dạng dữ liệu
                string[] dateColumns = { "USE_DATE", "MAINTENANCE_DATE", "REQUEST_DATE" };
                foreach (var col in dateColumns)
                {
                    if (dgv_AssetsDetail.Columns.Contains(col))
                    {
                        dgv_AssetsDetail.Columns[col].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }

                if (dgv_AssetsDetail.Columns.Contains("PRICE"))
                {
                    dgv_AssetsDetail.Columns["PRICE"].DefaultCellStyle.Format = "N0";
                    dgv_AssetsDetail.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Cho phép text wrap cho các cột dài
                string[] wrapColumns = { "DESCRIPTION", "BUILDING_ADDRESS", "ASSETNAME" };
                foreach (var col in wrapColumns)
                {
                    if (dgv_AssetsDetail.Columns.Contains(col))
                    {
                        dgv_AssetsDetail.Columns[col].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    }
                }

                dgv_AssetsDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                // Code xuất Excel ở đây
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadAssetsDetailData();
        }

        private void ExcelExporter_btn_Click(object sender, EventArgs e)
        {
            if (dgv_AssetsDetail.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_AssetsDetail, "Danh sách thông tin chi tiết của tài sản");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}