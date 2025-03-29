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
                DataTable dt = RentalHistoryBLL.LoadRentalHistory(username);
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
            dgv_AssetsDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Tắt tự động điều chỉnh kích thước
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
                // Đặt tên cột tiếng Việt
                dgv_AssetsDetail.Columns["ROOMID"].HeaderText = "Mã Phòng";
                dgv_AssetsDetail.Columns["OLDTENANTID"].HeaderText = "Mã KH";
                dgv_AssetsDetail.Columns["ADDRESS"].HeaderText = "Địa chỉ";
                dgv_AssetsDetail.Columns["TYPE"].HeaderText = "Loại";
                dgv_AssetsDetail.Columns["CONVENIENT"].HeaderText = "Tiện ích";
                dgv_AssetsDetail.Columns["AREA"].HeaderText = "Diện tích";
                dgv_AssetsDetail.Columns["PRICE"].HeaderText = "Giá thuê";
                dgv_AssetsDetail.Columns["STATUS"].HeaderText = "Trạng thái";
                dgv_AssetsDetail.Columns["FIRSTNAME"].HeaderText = "Tên";
                dgv_AssetsDetail.Columns["LASTNAME"].HeaderText = "Họ";
                dgv_AssetsDetail.Columns["GENDER"].HeaderText = "Giới tính";
                dgv_AssetsDetail.Columns["PHONENUMBER"].HeaderText = "Điện thoại";
                dgv_AssetsDetail.Columns["STARTDATE"].HeaderText = "Bắt đầu";
                dgv_AssetsDetail.Columns["ENDDATE"].HeaderText = "Kết thúc";
                dgv_AssetsDetail.Columns["REASON_FOR_LEAVING"].HeaderText = "Lý do rời đi";

                // Đặt độ rộng cột
                dgv_AssetsDetail.Columns["ROOMID"].Width = 80;
                dgv_AssetsDetail.Columns["OLDTENANTID"].Width = 80;
                dgv_AssetsDetail.Columns["ADDRESS"].Width = 180;
                dgv_AssetsDetail.Columns["TYPE"].Width = 80;
                dgv_AssetsDetail.Columns["CONVENIENT"].Width = 150;
                dgv_AssetsDetail.Columns["AREA"].Width = 80;
                dgv_AssetsDetail.Columns["PRICE"].Width = 100;
                dgv_AssetsDetail.Columns["STATUS"].Width = 100;
                dgv_AssetsDetail.Columns["FIRSTNAME"].Width = 100;
                dgv_AssetsDetail.Columns["LASTNAME"].Width = 100;
                dgv_AssetsDetail.Columns["GENDER"].Width = 70;
                dgv_AssetsDetail.Columns["PHONENUMBER"].Width = 100;
                dgv_AssetsDetail.Columns["STARTDATE"].Width = 90;
                dgv_AssetsDetail.Columns["ENDDATE"].Width = 90;
                dgv_AssetsDetail.Columns["REASON_FOR_LEAVING"].Width = 150;

                // Định dạng dữ liệu
                dgv_AssetsDetail.Columns["STARTDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_AssetsDetail.Columns["ENDDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgv_AssetsDetail.Columns["PRICE"].DefaultCellStyle.Format = "N0";
                dgv_AssetsDetail.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_AssetsDetail.Columns["AREA"].DefaultCellStyle.Format = "N2";
                dgv_AssetsDetail.Columns["AREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Cho phép text wrap cho các cột dài
                dgv_AssetsDetail.Columns["CONVENIENT"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv_AssetsDetail.Columns["REASON_FOR_LEAVING"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv_AssetsDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            // Bật tính năng cuộn ngang nếu cần
            dgv_AssetsDetail.ScrollBars = ScrollBars.Both;
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
            // If the current DataGridView is dgv_QLP (Quản lý phòng)
            if (dgv_AssetsDetail.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_AssetsDetail, "Danh sách lịch sử thuê của căn nhà");
            }
            // If the current DataGridView is dgv_QLHD (Quản lý hợp đồng)
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}