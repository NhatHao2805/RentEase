using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class QuanLyNha: Form
    {
        Form_DangNhap form1;
        private int panel1_originalSize = 90;
        private int panel1_extendedSize = 90 + 170;
        private bool panel1_extendedEnabled = true;
        //Attribute's managementPanel
        private Size size_quanly = new Size(1040, 696);
        private Point location_quanly = new Point(200, 37);
        private Size size_quanly_1 = new Size(10,10);
        private Point location_quanly_1 = new Point(200, 10);
        private List<Panel> list_panel_quanly;
        //
        private Size size_component_quanlytaichinh = new Size(1010, 552);
        private Size size_component_quanlytaichinh_1 = new Size(10, 10);
        private Point location_component_quanlytaichinh = new Point(12, 86);
        private Point location_component_quanlytaichinh_1 = new Point(30,30);

        public QuanLyNha()
        {
            InitializeComponent();
            this.DangO_chbox.CheckedChanged += new System.EventHandler(this.DangO_chbox_CheckedChanged);
            this.DangTrong_chbox.CheckedChanged += new System.EventHandler(this.DangTrong_chbox_CheckedChanged);
            this.DangKetThuc_chbox.CheckedChanged += new System.EventHandler(this.DangKetThuc_chbox_CheckedChanged);
            this.DangCoc_chbox.CheckedChanged += new System.EventHandler(this.DangCoc_chbox_CheckedChanged);
            this.SapHetHan_chbox.CheckedChanged += new System.EventHandler(this.SapHetHan_chbox_CheckedChanged);
            this.QuaHan_chbox.CheckedChanged += new System.EventHandler(this.QuaHan_chbox_CheckedChanged);
            this.DangNoTien_chbox.CheckedChanged += new System.EventHandler(this.DangNoTien_chbox_CheckedChanged);
            loadVariable();
            setStartPositon();
            
            //this.form1 = form1;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void setStartPositon()
        {
            setPosition_hoaDon_thuChi(panel_qltc_hoadon, panel_qltc_thuchi);
            changePanel(panel_quanlyphong);
            changePanel(panel_quanlycsvc);
        }

        private void loadVariable()
        {   
            list_panel_quanly = new List<Panel>();
            list_panel_quanly.Add(panel_quanlyphong);
            list_panel_quanly.Add(panel_quanlyhopdong);
            list_panel_quanly.Add(panel_quanlytaichinh);
            list_panel_quanly.Add(panel_quanlycsvc);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //form1.Close();
            Application.Exit();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1_extendedEnabled)
            {
                if (panel1.Height >= panel1_extendedSize)
                {
                    panel1_extendedEnabled = false;
                    panel1_timer.Stop();
                }
                else
                {
                    panel1.Height += 5;

                }
            }
            else
            {
                if (panel1.Height <= panel1_originalSize)
                {
                    panel1_extendedEnabled = true;
                    panel1_timer.Stop();
                }
                else
                {
                    panel1.Height -= 5;
                }
            }
        }



        private void extendBtnPanel1_MouseDown(object sender, MouseEventArgs e)
        {

            panel1_timer.Start();
        }


        private void changePanel(Panel panel)
        {
            if (!(panel.Size.Equals(size_quanly)))
            {
                foreach(Panel i in list_panel_quanly)
                {
                    if (!(i.Equals(panel)))
                    {
                        i.Size = size_quanly_1;
                        i.Location = location_quanly_1;
                    }
                }
                panel.Size = size_quanly;
                panel.Location = location_quanly;
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void extendBtnPanel1_Click(object sender, EventArgs e)
        {
            if(extendBtnPanel1.Text == "Xem Thêm")
            {
                extendBtnPanel1.Text = "Ẩn bớt";
            }
            else
            {
                extendBtnPanel1.Text = "Xem Thêm";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }


        public void setPosition_hoaDon_thuChi(Panel p1, Panel p2)
        {
            p1.Size = size_component_quanlytaichinh;
            p1.Location = location_component_quanlytaichinh;
            p2.Size = size_component_quanlytaichinh_1;
            p2.Location = location_component_quanlytaichinh_1;
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            setPosition_hoaDon_thuChi(panel_qltc_hoadon,panel_qltc_thuchi);
        }

        private void btn_thuchi_Click(object sender, EventArgs e)
        {
            setPosition_hoaDon_thuChi(panel_qltc_thuchi, panel_qltc_hoadon);
        }

        private void btn_phong_Click(object sender, EventArgs e)
        {
            changePanel(panel_quanlyphong);
        }

        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            changePanel(panel_quanlyhopdong);

        }

        private void btn_taichinh_Click(object sender, EventArgs e)
        {
            changePanel(panel_quanlytaichinh);

        }

        private void btn_csvc_Click(object sender, EventArgs e)
        {
            changePanel(panel_quanlycsvc);

        }

        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            //changePanel(panel_quanlydichvu);

        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            //changePanel(panel_quanlyphong);
        }

        private void QuanLyNha_Load(object sender, EventArgs e)
        {
            LoadRoom();
            LoadAsset();
            FilterRoom();
            CustomizeDataGridView(dtgridview_LoadRoom);
            CustomizeDataGridView(assetsList_dtgridview);
        }

        public RoomBLL room = new RoomBLL();
        private void LoadRoom()
        {
            
            DataTable dt = new DataTable();
            dt = room.LoadRoom();
            dtgridview_LoadRoom.AutoGenerateColumns = true;
            dtgridview_LoadRoom.DataSource = dt;
            dtgridview_LoadRoom.ReadOnly = true;
            dtgridview_LoadRoom.Columns["ROOMID"].HeaderText = "Mã phòng";
            dtgridview_LoadRoom.Columns["BUILDINGID"].HeaderText = "Mã tòa nhà";
            dtgridview_LoadRoom.Columns["TYPE"].HeaderText = "Phân loại";
            dtgridview_LoadRoom.Columns["CONVENIENT"].HeaderText = "Tiện ích";
            dtgridview_LoadRoom.Columns["PRICE"].HeaderText = "Giá";
            dtgridview_LoadRoom.Columns["AREA"].HeaderText = "Diện tích";
            dtgridview_LoadRoom.Columns["STATUS"].HeaderText = "Tình trạng";
            dtgridview_LoadRoom.Columns["LAST_MAINTENANCE_DATE"].HeaderText = "Ngày bảo trì gần nhất";
            
        }

        public void CustomizeDataGridView(DataGridView dtgridview)
        {
            // Căn chỉnh giao diện chung
            dtgridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgridview.RowHeadersVisible = false;
            dtgridview.AllowUserToAddRows = false;
            dtgridview.AllowUserToDeleteRows = false;
            dtgridview.ReadOnly = true;

            // Thiết lập style cho header
            dtgridview.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dtgridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgridview.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dtgridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgridview.EnableHeadersVisualStyles = false;


            // Thiết lập style cho các dòng
            dtgridview.AlternatingRowsDefaultCellStyle.BackColor = Color.DimGray;
            dtgridview.DefaultCellStyle.Font = new Font("Arial", 9);
            dtgridview.DefaultCellStyle.ForeColor = Color.Black;
            dtgridview.DefaultCellStyle.BackColor = Color.White;
            dtgridview.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtgridview.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Thiết lập style khi chọn dòng
            dtgridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgridview.MultiSelect = false;

            // Thiết lập màu nền và đường viền
            dtgridview.GridColor = Color.Gray;
            dtgridview.BackgroundColor = Color.White;

            // Tùy chỉnh font và kích thước
            dtgridview.Font = new Font("Arial", 10);
            dtgridview.RowTemplate.Height = 30;
        }

        private void addRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddRoom addRoom = new Form_AddRoom();
            addRoom.Show();
        }

        private void FilterRoom()
        {
            string status = "";
            foreach (Control control in chbox_datagridview_grbox.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    status += checkBox.Text + "; ";
                }
            }

            // Loại bỏ dấu "; " cuối cùng
            status = status.TrimEnd(';', ' ');

            // Nếu không có CheckBox nào được chọn, hiển thị tất cả dữ liệu
            if (string.IsNullOrEmpty(status))
            {
                LoadRoom();
                return;
            }

            // Lọc dữ liệu và hiển thị
            DataTable filteredData = room.FilterRoomByStatus(status);
            dtgridview_LoadRoom.DataSource = filteredData;
        }


        private void DangO_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox.Checked && DangTrong_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang ở' vừa 'Đang trống'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangO_chbox.Checked = false;
            }
            FilterRoom();
        }

        private void DangTrong_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox.Checked && DangO_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang trống' vừa 'Đang ở'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangTrong_chbox.Checked = false;
            }
            FilterRoom();
        }

        private void DangKetThuc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangKetThuc_chbox.Checked && DangCoc_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangKetThuc_chbox.Checked = false;
            }
            FilterRoom();
        }

        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangCoc_chbox.Checked && (DangO_chbox.Checked || DangKetThuc_chbox.Checked))
            {
                MessageBox.Show("Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang ở' hoặc 'Đang báo kết thúc'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangCoc_chbox.Checked = false;
            }
            FilterRoom();
        }

        private void SapHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SapHetHan_chbox.Checked && QuaHan_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồng'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SapHetHan_chbox.Checked = false;
            }
            FilterRoom();
        }

        private void QuaHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (QuaHan_chbox.Checked && SapHetHan_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QuaHan_chbox.Checked = false;
            }
            FilterRoom();
        }

        private void DangNoTien_chbox_CheckedChanged(object sender, EventArgs e)
        {
            FilterRoom();
        }


        //QuanLyCSVC
        public AssetsBLL asset = new AssetsBLL();
        private void LoadAsset()
        {

            DataTable dt = new DataTable();
            dt = asset.LoadAsset();
            assetsList_dtgridview.AutoGenerateColumns = true;
            assetsList_dtgridview.DataSource = dt;
            assetsList_dtgridview.ReadOnly = true;
            assetsList_dtgridview.Columns["ASSETID"].HeaderText = "Mã tài sản";
            assetsList_dtgridview.Columns["ROOMID"].HeaderText = "Mã phòng";
            assetsList_dtgridview.Columns["ASSETNAME"].HeaderText = "Tên tài sản";
            assetsList_dtgridview.Columns["PRICE"].HeaderText = "Giá";
            assetsList_dtgridview.Columns["STATUS"].HeaderText = "Tình trạng";
            assetsList_dtgridview.Columns["USE_DATE"].HeaderText = "Ngày đưa vào sử dụng";

        }

        private void FilterAssets()
        {
            //string status = "";
            //foreach (Control control in chbox_datagridview_grbox.Controls)
            //{
            //    if (control is CheckBox checkBox && checkBox.Checked)
            //    {
            //        status += checkBox.Text + "; ";
            //    }
            //}

            //// Loại bỏ dấu "; " cuối cùng
            //status = status.TrimEnd(';', ' ');

            //// Nếu không có CheckBox nào được chọn, hiển thị tất cả dữ liệu
            //if (string.IsNullOrEmpty(status))
            //{
            //    LoadRoom();
            //    return;
            //}

            // Lọc dữ liệu và hiển thị
            //DataTable filteredData = asset.FilterRoomByStatus(status);
            DataTable filteredData = asset.LoadAsset();
            assetsList_dtgridview.DataSource = filteredData;
        }

        private void manageAssets_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ManageAsset manageAsset = new Form_ManageAsset();
            manageAsset.Show();
        }

        private void repairRequest_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_RepairRequest repairRequest = new Form_RepairRequest(this);
            repairRequest.Show();
        }

        private void maintenance_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Maintenance maintenance = new Form_Maintenance(this);
            maintenance.Show();
        }

        private void addAssets_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddAssets addAsset = new Form_AddAssets();
            addAsset.Show();
        }

        private void sortPriceAscend_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sortPriceDescend_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void searchByName_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void assetName_tb_TextChanged(object sender, EventArgs e)
        {

        }

        //RepairRequesst
    }
}
