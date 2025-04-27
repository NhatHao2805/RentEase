using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace GUI
{
    public partial class Form_RentalHistory : Form
    {
        private string _username;
        private string _buildingid;


        public Form_RentalHistory(string username, string buildingid)
        {
            InitializeComponent();
            _username = username;
            _buildingid = buildingid;
            LoadRentalHistoryData();
            ConfigureDataGridView();
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "export_excel":
                        ExcelExporter_btn.Text = a.Value;
                        break;
                    case "btn_dong":
                        close_btn.Text = a.Value;
                        break;
                    case "rental_history.title":
                        label23.Text = a.Value;
                        break;
                    case "rental_history.description":
                        label22.Text = a.Value;
                        break;
                    case "rental_history.history_id":
                        dgv_RentalHistory.Columns[0].HeaderText = a.Value;
                        break;
                    case "rental_history.contract_id":
                        dgv_RentalHistory.Columns[1].HeaderText = a.Value;
                        break;
                    case "rental_history.room_id":
                        dgv_RentalHistory.Columns[2].HeaderText = a.Value;
                        break;
                    case "rental_history.customer_id":
                        dgv_RentalHistory.Columns[3].HeaderText = a.Value;
                        break;
                    case "rental_history.first_name":
                        dgv_RentalHistory.Columns[4].HeaderText = a.Value;
                        break;
                    case "rental_history.last_name":
                        dgv_RentalHistory.Columns[5].HeaderText = a.Value;
                        break;
                }
//                rental_history.history_id: Mã Lịch sử
//rental_history.contract_id: Mã Hợp đồng
//rental_history.room_id: Mã Phòng
//rental_history.customer_id: Mã KH
//rental_history.first_name: Tên
//rental_history.last_name: Họ


            }
        }
        private void LoadRentalHistoryData()
        {
            try
            {
                DataTable dt = RentalHistoryBLL.LoadRentalHistory(_username, _buildingid);
                dgv_RentalHistory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lịch sử thuê nhà: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Thiết lập cơ bản
            dgv_RentalHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_RentalHistory.AllowUserToAddRows = false;
            dgv_RentalHistory.ReadOnly = true;
            dgv_RentalHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_RentalHistory.RowHeadersVisible = false;
            dgv_RentalHistory.ScrollBars = ScrollBars.Both;
            dgv_RentalHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv_RentalHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv_RentalHistory.EnableHeadersVisualStyles = false;
            dgv_RentalHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dgv_RentalHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_RentalHistory.ColumnHeadersHeight = 30;
            dgv_RentalHistory.RowTemplate.Height = 25;

            // Thiết lập từng cột với độ rộng phù hợp
            if (dgv_RentalHistory.Columns.Count > 0)
            {
                // Đặt tên cột tiếng Việt
                dgv_RentalHistory.Columns["RENTAL_HISTORY_ID"].HeaderText = "Mã Lịch sử";
                dgv_RentalHistory.Columns["CONTRACTID"].HeaderText = "Mã Hợp đồng";
                dgv_RentalHistory.Columns["ROOMNAME"].HeaderText = "Mã Phòng";
                dgv_RentalHistory.Columns["TENANTID"].HeaderText = "Mã KH";
                dgv_RentalHistory.Columns["FIRSTNAME"].HeaderText = "Tên";
                dgv_RentalHistory.Columns["LASTNAME"].HeaderText = "Họ";
                dgv_RentalHistory.Columns["GENDER"].HeaderText = "Giới tính";
                dgv_RentalHistory.Columns["PHONENUMBER"].HeaderText = "Điện thoại";
                dgv_RentalHistory.Columns["TYPE"].HeaderText = "Loại phòng";
                dgv_RentalHistory.Columns["CONVENIENT"].HeaderText = "Tiện ích";
                dgv_RentalHistory.Columns["AREA"].HeaderText = "Diện tích (m²)";
                dgv_RentalHistory.Columns["PRICE"].HeaderText = "Giá thuê";
                dgv_RentalHistory.Columns["STATUS"].HeaderText = "Trạng thái";
                dgv_RentalHistory.Columns["STARTDATE"].HeaderText = "Bắt đầu";
                dgv_RentalHistory.Columns["ENDDATE"].HeaderText = "Kết thúc";
                dgv_RentalHistory.Columns["REASON_FOR_LEAVING"].HeaderText = "Lý do rời đi";
                dgv_RentalHistory.Columns["BUILDINGID"].HeaderText = "Mã Tòa nhà";
                dgv_RentalHistory.Columns["BUILDING_ADDRESS"].HeaderText = "Địa chỉ tòa nhà";

                // Đặt độ rộng cột
                dgv_RentalHistory.Columns["RENTAL_HISTORY_ID"].Width = 100;
                dgv_RentalHistory.Columns["CONTRACTID"].Width = 100;
                dgv_RentalHistory.Columns["ROOMNAME"].Width = 80;
                dgv_RentalHistory.Columns["TENANTID"].Width = 80;
                dgv_RentalHistory.Columns["FIRSTNAME"].Width = 100;
                dgv_RentalHistory.Columns["LASTNAME"].Width = 100;
                dgv_RentalHistory.Columns["GENDER"].Width = 70;
                dgv_RentalHistory.Columns["PHONENUMBER"].Width = 100;
                dgv_RentalHistory.Columns["TYPE"].Width = 100;
                dgv_RentalHistory.Columns["CONVENIENT"].Width = 150;
                dgv_RentalHistory.Columns["AREA"].Width = 90;
                dgv_RentalHistory.Columns["PRICE"].Width = 100;
                dgv_RentalHistory.Columns["STATUS"].Width = 100;
                dgv_RentalHistory.Columns["STARTDATE"].Width = 90;
                dgv_RentalHistory.Columns["ENDDATE"].Width = 90;
                dgv_RentalHistory.Columns["REASON_FOR_LEAVING"].Width = 150;
                dgv_RentalHistory.Columns["BUILDINGID"].Width = 100;
                dgv_RentalHistory.Columns["BUILDING_ADDRESS"].Width = 200;

                // Định dạng dữ liệu
                dgv_RentalHistory.Columns["STARTDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_RentalHistory.Columns["ENDDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgv_RentalHistory.Columns["PRICE"].DefaultCellStyle.Format = "N0";
                dgv_RentalHistory.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_RentalHistory.Columns["AREA"].DefaultCellStyle.Format = "N2";
                dgv_RentalHistory.Columns["AREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_RentalHistory.Columns["CONVENIENT"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv_RentalHistory.Columns["REASON_FOR_LEAVING"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv_RentalHistory.Columns["BUILDING_ADDRESS"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgv_RentalHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dgv_RentalHistory.ScrollBars = ScrollBars.Both;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExcelExporter_btn_Click(object sender, EventArgs e)
        {
            if (dgv_RentalHistory.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_RentalHistory, "Danh sách lịch sử thuê của căn nhà");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}