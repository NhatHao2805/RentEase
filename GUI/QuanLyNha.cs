using BLL;
using BLL.Quanlyphuongtien;
using DTO;
using GUI.QuanLyPhuongTien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;


namespace GUI
{
    public partial class quanlynha: Form
    {
        Form_Login form1;
        private int panel1_originalSize = 90;
        private int panel1_extendedSize = 90 + 170;
        private bool panel1_extendedEnabled = true;
        //Attribute's managementPanel
        private Point tabQL = new Point(185, 10);
        private Size size_tabQL = new Size(1324, 969);

        private Point tabHD = new Point(0, -30);
        private Size size_tabHD = new Size(1324, 969);
        //
        private Size size_component_quanlytaichinh = new Size(1010, 552);
        private Size size_component_quanlytaichinh_1 = new Size(10, 10);
        private Point location_component_quanlytaichinh = new Point(12, 86);
        private Point location_component_quanlytaichinh_1 = new Point(30,30);

        public quanlynha(Form_Login form1)
        {
            InitializeComponent();
            setStartPositon();
            this.form1 = form1;
            loadInfo();
        }

        private void loadInfo()
        {
            load_QLP();
            loar_Contract();
        }

        private void load_QLP()
        {
            dgv_QLP.DataSource = RoomBLL.RoomBLL_load_Room(form1.taikhoan.Username);
            dgv_QLP.Columns[0].Width = 90;
            dgv_QLP.Columns[1].Width = 90;
            dgv_QLP.Columns[2].Width = 150;
            dgv_QLP.Columns[3].Width = 250;
            dgv_QLP.Columns[4].Width = 80;
            dgv_QLP.Columns[5].Width = 80;
            dgv_QLP.Columns[6].Width = 80;
            dgv_QLP.Columns[7].Width = 250;
            dgv_QLP.ScrollBars = ScrollBars.Both;
        }

        private void loar_Contract()
        {
            dgv_QLHD.DataSource = ContractBLL.ContractBLL_load_Contract(form1.taikhoan.Username);
            dgv_QLHD.Columns[0].Width = 90;
            dgv_QLHD.Columns[1].Width = 90;
            dgv_QLHD.Columns[2].Width = 150;
            dgv_QLHD.Columns[3].Width = 250;
            dgv_QLHD.Columns[4].Width = 80;
            dgv_QLHD.Columns[5].Width = 80;
            dgv_QLHD.Columns[6].Width = 80;
            dgv_QLHD.Columns[7].Width = 250;
            dgv_QLHD.ScrollBars = ScrollBars.Both;
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

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void setStartPositon()
        {
            tabQuanLy.Location = tabQL;
            tabQuanLy.Size = size_tabQL;

            tabHopDong.Location = tabHD;
            tabHopDong.Size = size_tabHD;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            form1.Close();
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

        public void setPosition_hoaDon_thuChi(Panel p1, Panel p2)
        {
            p1.Size = size_component_quanlytaichinh;
            p1.Location = location_component_quanlytaichinh;
            p2.Size = size_component_quanlytaichinh_1;
            p2.Location = location_component_quanlytaichinh_1;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_thuchi_Click(object sender, EventArgs e)
        {
          
        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void btn_phong_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 0;
        }

        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 1;
        }
        private void LoadData(String required)
        {
           
        }

        private void btn_taichinh_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 2;
            LoadSettingsData();


        }

        private void btn_csvc_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 3;


        }

        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 4;
        }
        //Quản lý bãi đậu xe
        private void btn_caidat_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 5;
            LoadParkingAreaData();

        }
        

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void quanlynha_Load(object sender, EventArgs e)
        {

        }


        private void button17_Click(object sender, EventArgs e)
        {
     
        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }
        private void Theemnoiluutru_Click(object sender, EventArgs e)
        {

        }

       


        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void hd1_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 0;
        }
        private void hd2_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 0;

        }
        private void hd3_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 0;

        }
        private void hd4_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 0;

        }
        private void lstn1_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 1;

        }
        private void lstn2_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 1;

        }
        private void lstn3_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 1;

        }
        private void lstn4_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 1;

        }
        private void ttkt1_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 2;

        }
        private void ttkt2_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 2;

        }
        private void ttkt3_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 2;

        }
        private void ttkt4_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 2;

        }
        private void dklt1_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 3;

        }
        private void dklt2_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 3;

        }
        private void dklt3_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 3;

        }
        private void dklt4_Click(object sender, EventArgs e)
        {
            tabHopDong.SelectedIndex = 3;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        //thêm chỗ bãi đậu xe
        private void button56_Click(object sender, EventArgs e)
        {
            GUI.QuanLyPhuongTien.QuanLyPhuonTien quanLyPhuonTienForm = new GUI.QuanLyPhuongTien.QuanLyPhuonTien();
            quanLyPhuonTienForm.Owner = this;
            quanLyPhuonTienForm.ShowDialog();
        
        }

        // Thêm phương thức public để load dữ liệu
        public void RefreshParkingAreaData()
        {
            LoadParkingAreaData();
        }
        private void guna2DataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadParkingAreaDataWithFilter(DataTable filteredData)
        {
            try
            {
                // Gán nguồn dữ liệu đã lọc cho DataGridView
                guna2DataGridView7.DataSource = filteredData;

                // Cố định thanh header
                guna2DataGridView7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                guna2DataGridView7.EnableHeadersVisualStyles = false;

                // Đặt chiều cao cho header
                guna2DataGridView7.ColumnHeadersHeight = 40;

                // Không cho phép người dùng sửa trực tiếp
                guna2DataGridView7.ReadOnly = true;
                guna2DataGridView7.AllowUserToAddRows = false;
                guna2DataGridView7.AllowUserToDeleteRows = false;
                guna2DataGridView7.AllowUserToOrderColumns = false;
                guna2DataGridView7.AllowUserToResizeRows = false;
                guna2DataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Định dạng hiển thị các cột
                if (guna2DataGridView7.Columns.Count > 0)
                {
                    // Đặt tiêu đề cho các cột
                    guna2DataGridView7.Columns["AREAID"].HeaderText = "ID Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["BUILDINGID"].HeaderText = "ID Tòa Nhà";
                    guna2DataGridView7.Columns["ADDRESS"].HeaderText = "Địa Chỉ";
                    guna2DataGridView7.Columns["TYPE"].HeaderText = "Loại Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["CAPACITY"].HeaderText = "Sức Chứa";

                    // Đặt độ rộng cho các cột
                    guna2DataGridView7.Columns["AREAID"].Width = 100;
                    guna2DataGridView7.Columns["BUILDINGID"].Width = 100;
                    guna2DataGridView7.Columns["ADDRESS"].Width = 200;
                    guna2DataGridView7.Columns["TYPE"].Width = 150;
                    guna2DataGridView7.Columns["CAPACITY"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //load dữ liệu thanh toán
        private void LoadSettingsData()
        {
            DataTable dt = BLL.PaymentBLL.GetAllPayments();

       


            guna2DataGridView2.DataSource = dt;

            // Thiết lập style cho header thông qua Guna Theme
            guna2DataGridView2.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 120, 215); // Màu xanh như trong ảnh
            guna2DataGridView2.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView2.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            guna2DataGridView2.ColumnHeadersHeight = 40;

            // Đặt tên hiển thị cho các cột
            if (guna2DataGridView2.Columns.Count > 0)
            {
                guna2DataGridView2.Columns[0].HeaderText = "Mã thanh toán";
                guna2DataGridView2.Columns[1].HeaderText = "Mã hóa đơn";
                guna2DataGridView2.Columns[2].HeaderText = "Phương thức";
                guna2DataGridView2.Columns[3].HeaderText = "Số tiền";
                guna2DataGridView2.Columns[4].HeaderText = "Thời gian";
                // Thêm những dòng này để định dạng hiển thị
                // Định dạng hiển thị số tiền với dấu phân cách hàng nghìn
                guna2DataGridView2.Columns[3].DefaultCellStyle.Format = "N0";
                

            }


          

            

            guna2DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Refresh bảng
            guna2DataGridView2.Refresh();
        }
        // Thêm phương thức LoadParkingAreaData
        private void LoadParkingAreaData()
        {
            try
            {
                // Gán nguồn dữ liệu cho DataGridView
                guna2DataGridView7.DataSource = ParkingAreaBLL.GetAllParkingAreas();

                // Cố định thanh header
                guna2DataGridView7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                guna2DataGridView7.EnableHeadersVisualStyles = false;

                // Đặt chiều cao cho header (tùy chọn)
                guna2DataGridView7.ColumnHeadersHeight = 40;


                // Không cho phép người dùng sửa trực tiếp
                guna2DataGridView7.ReadOnly = true;
                guna2DataGridView7.AllowUserToAddRows = false;
                guna2DataGridView7.AllowUserToDeleteRows = false;
                guna2DataGridView7.AllowUserToOrderColumns = false;
                guna2DataGridView7.AllowUserToResizeRows = false;
                guna2DataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Định dạng hiển thị các cột
                if (guna2DataGridView7.Columns.Count > 0)
                {
                    // Đặt tiêu đề cho các cột
                    guna2DataGridView7.Columns["AREAID"].HeaderText = "ID Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["BUILDINGID"].HeaderText = "ID Tòa Nhà";
                    guna2DataGridView7.Columns["ADDRESS"].HeaderText = "Địa Chỉ";
                    guna2DataGridView7.Columns["TYPE"].HeaderText = "Loại Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["CAPACITY"].HeaderText = "Sức Chứa";

                    // Đặt độ rộng cho các cột
                    guna2DataGridView7.Columns["AREAID"].Width = 100;
                    guna2DataGridView7.Columns["BUILDINGID"].Width = 100;
                    guna2DataGridView7.Columns["ADDRESS"].Width = 200;
                    guna2DataGridView7.Columns["TYPE"].Width = 150;
                    guna2DataGridView7.Columns["CAPACITY"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button53_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv_QLP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (guna2DataGridView7.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khu vực đỗ xe để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy areaId từ dòng được chọn
                string areaId = guna2DataGridView7.SelectedRows[0].Cells["AREAID"].Value.ToString();

                // Xác nhận xóa
                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khu vực đỗ xe {areaId} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                {
                    return;
                }

                // Gọi phương thức xóa từ BLL
                if (ParkingAreaBLL.DeleteParkingArea(areaId, out string message))
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); // Sử dụng message từ stored procedure
                    RefreshParkingAreaData(); // Làm mới dữ liệu
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hiển thị lý do thất bại từ stored procedure
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở hộp thoại lưu file
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv";
                    sfd.FileName = $"DanhSachBaiDoXe_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return; // Người dùng hủy thao tác
                    }

                    // Gọi BLL để xuất dữ liệu
                    if (ParkingAreaBLL.ExportParkingAreasToCsv(sfd.FileName, out string message))
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.FileName = $"ThongKeBaiDoXe_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    if (ParkingAreaBLL.ExportParkingAreasToExcelWithChart(sfd.FileName, out string message))
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
