using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class Form_AssetsDetail : Form
    {
        private string _username;
        private string _buildingid;

        public Form_AssetsDetail(string username, string buildingid)
        {
            InitializeComponent();
            _username = username;
            _buildingid = buildingid;
            LoadAssetsDetailData();
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
                    case "asset.detail_title":
                        label23.Text = a.Value;
                        break;
                    case "asset.detail_description":
                        label22.Text = a.Value;
                        break;
                    case "assetdetail.assetid":
                        dgv_AssetsDetail.Columns["ASSETID"].HeaderText = a.Value;
                        break;
                    case "assetdetail.assetname":
                        dgv_AssetsDetail.Columns["ASSETNAME"].HeaderText = a.Value;
                        break;
                    case "assetdetail.price":
                        dgv_AssetsDetail.Columns["PRICE"].HeaderText = a.Value;
                        break;
                    case "assetdetail.asset_status":
                        dgv_AssetsDetail.Columns["ASSET_STATUS"].HeaderText = a.Value;
                        break;
                    case "assetdetail.use_date":
                        dgv_AssetsDetail.Columns["USE_DATE"].HeaderText = a.Value;
                        break;
                    case "assetdetail.roomid":
                        dgv_AssetsDetail.Columns["ROOMID"].HeaderText = a.Value;
                        break;
                    case "assetdetail.room_type":
                        dgv_AssetsDetail.Columns["ROOM_TYPE"].HeaderText = a.Value;
                        break;
                    case "assetdetail.floor":
                        dgv_AssetsDetail.Columns["FLOOR"].HeaderText = a.Value;
                        break;
                    case "assetdetail.buildingid":
                        dgv_AssetsDetail.Columns["BUILDINGID"].HeaderText = a.Value;
                        break;

                }


            }

            foreach (DataGridViewRow row in dgv_AssetsDetail.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["ASSET_STATUS"].Value = Language.translate(row.Cells["ASSET_STATUS"].Value.ToString());
                }
            }
        }

        private void LoadAssetsDetailData()
        {
            try
            {
                DataTable dt = AssetBLL.LoadAssetDetail(_username, _buildingid);
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
            // Thiết lập cơ bản (giữ nguyên)
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

            


            //// Thiết lập cột (CẬP NHẬT theo sp_AssetDetails mới)
            //if (dgv_AssetsDetail.Columns.Count > 0)
            //{
            //    // Đặt tên cột tiếng Việt
            //    dgv_AssetsDetail.Columns["ASSETID"].HeaderText = "Mã tài sản";
            //    dgv_AssetsDetail.Columns["ASSETNAME"].HeaderText = "Tên tài sản";
            //    dgv_AssetsDetail.Columns["PRICE"].HeaderText = "Giá trị (VND)";
            //    dgv_AssetsDetail.Columns["ASSET_STATUS"].HeaderText = "Trạng thái";
            //    dgv_AssetsDetail.Columns["USE_DATE"].HeaderText = "Ngày sử dụng";
            //    dgv_AssetsDetail.Columns["ROOMID"].HeaderText = "Mã phòng";
            //    dgv_AssetsDetail.Columns["ROOM_TYPE"].HeaderText = "Loại phòng";
            //    dgv_AssetsDetail.Columns["FLOOR"].HeaderText = "Tầng";
            //    dgv_AssetsDetail.Columns["BUILDINGID"].HeaderText = "Mã tòa nhà";

            //    // Đặt độ rộng cột (điều chỉnh lại)
            //    dgv_AssetsDetail.Columns["ASSETID"].Width = 90;
            //    dgv_AssetsDetail.Columns["ASSETNAME"].Width = 150;
            //    dgv_AssetsDetail.Columns["PRICE"].Width = 100;
            //    dgv_AssetsDetail.Columns["ASSET_STATUS"].Width = 100;
            //    dgv_AssetsDetail.Columns["USE_DATE"].Width = 90;
            //    dgv_AssetsDetail.Columns["ROOMID"].Width = 80;
            //    dgv_AssetsDetail.Columns["ROOM_TYPE"].Width = 90;
            //    dgv_AssetsDetail.Columns["FLOOR"].Width = 50;
            //    dgv_AssetsDetail.Columns["BUILDINGID"].Width = 90;

            //    // Định dạng dữ liệu (bổ sung)
            //    dgv_AssetsDetail.Columns["USE_DATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //    dgv_AssetsDetail.Columns["PRICE"].DefaultCellStyle.Format = "N0";
            //    dgv_AssetsDetail.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgv_AssetsDetail.Columns["FLOOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //    // Cho phép text wrap
            //    dgv_AssetsDetail.Columns["ASSETNAME"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //    // Tự động điều chỉnh chiều cao hàng
            //    dgv_AssetsDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //}
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExcelExporter_btn_Click(object sender, EventArgs e)
        {
            if (dgv_AssetsDetail.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_AssetsDetail, "Danh sách tài sản của chủ nhà");
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