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
            //FilterRoomByStatus();
            loadInfo();
        }

        private void loadInfo()
        {  

            dgv_QLP.DataSource = RoomBLL.RoomBLL_load_Room(form1.taikhoan.Username);
            dgv_QLP.Columns[0].Width = 90;
            dgv_QLP.Columns[1].Width = 90;
            dgv_QLP.Columns[2].Width = 90;
            dgv_QLP.Columns[3].Width = 150;
            dgv_QLP.Columns[4].Width = 250;
            dgv_QLP.Columns[5].Width = 80;
            dgv_QLP.Columns[6].Width = 80;
            dgv_QLP.Columns[7].Width = 80;
            dgv_QLP.ScrollBars = ScrollBars.Both;


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

            dgv_QLCSVC.DataSource = AssetBLL.AssetsBLL_load_Assets(form1.taikhoan.Username);
            dgv_QLCSVC.Columns[0].Width = 90;
            dgv_QLCSVC.Columns[1].Width = 90;
            dgv_QLCSVC.Columns[2].Width = 90;
            dgv_QLCSVC.Columns[3].Width = 150;
            dgv_QLCSVC.Columns[4].Width = 250;
            dgv_QLCSVC.Columns[5].Width = 80;
            dgv_QLCSVC.ScrollBars = ScrollBars.Both;

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


        }

        private void btn_csvc_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 3;


        }

        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 4;
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 5;
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

        private void addRoom_btn_Click(object sender, EventArgs e)
        {
            Form_AddRoom addRoom = new Form_AddRoom(form1.taikhoan.Username);
            if (addRoom.ShowDialog() == DialogResult.OK)
            {
                // Nếu thêmthành công thì load lại dữ liệu
                loadInfo();
            }
        }

        private void DangO_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox.Checked && DangTrong_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang ở' vừa 'Đang trống'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangO_chbox.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangTrong_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox.Checked && DangO_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang trống' vừa 'Đang ở'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangTrong_chbox.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangKT_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangKT_chbox.Checked && DangCoc_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangKT_chbox.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangCoc_chbox.Checked && (DangO_chbox.Checked || DangKT_chbox.Checked))
            {
                MessageBox.Show("Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang ở' hoặc 'Đang báo kết thúc'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangCoc_chbox.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void SapHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SapHetHan_chbox.Checked && DaQuaHan_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồng'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SapHetHan_chbox.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DaQuaHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DaQuaHan_chbox.Checked && SapHetHan_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DaQuaHan_chbox.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangNoTien_chbox_CheckedChanged(object sender, EventArgs e)
        {
            FilterRoomByStatus();
        }
        private void FilterRoomByStatus()
        {
            try
            {
                // Tạo danh sách trạng thái được chọn
                List<string> selectedStatuses = new List<string>();

                if (DangO_chbox.Checked) selectedStatuses.Add(DangO_chbox.Text);
                if (DangTrong_chbox.Checked) selectedStatuses.Add(DangTrong_chbox.Text);
                if (DangKT_chbox.Checked) selectedStatuses.Add(DangKT_chbox.Text);
                if (DangCoc_chbox.Checked) selectedStatuses.Add(DangCoc_chbox.Text);
                if (SapHetHan_chbox.Checked) selectedStatuses.Add(SapHetHan_chbox.Text);
                if (DaQuaHan_chbox.Checked) selectedStatuses.Add(DaQuaHan_chbox.Text);
                if (DangNoTien_chbox.Checked) selectedStatuses.Add(DangNoTien_chbox.Text);

                // Chuyển danh sách thành chuỗi phân cách bằng dấu ;
                string statusFilter = string.Join("; ", selectedStatuses);


                // Lấy dữ liệu đã lọc
                DataTable filteredData = RoomBLL.FilterRoomByStatus(statusFilter, form1.taikhoan.Username);

                // Cập nhật DataGridView
                dgv_QLP.DataSource = null; // Xóa dữ liệu cũ trước
                dgv_QLP.DataSource = filteredData;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgv_QLP.Columns.Count > 0)
            {
                dgv_QLP.Columns["RoomID"].Width = 90;
                dgv_QLP.Columns["BuildingID"].Width = 90;
                dgv_QLP.Columns["Type"].Width = 150;
                dgv_QLP.Columns["Convenient"].Width = 250;
                dgv_QLP.Columns["Area"].Width = 80;
                dgv_QLP.Columns["Price"].Width = 100;
                dgv_QLP.Columns["Status"].Width = 150;
                dgv_QLP.ScrollBars = ScrollBars.Both;
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string roomId = dgv_QLP.SelectedRows[0].Cells["RoomID"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa phòng {roomId}?",
                              "Xác nhận xóa",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var (success, message) = RoomBLL.DeleteRoom(roomId);

                MessageBox.Show(message,
                              success ? "Thành công" : "Lỗi",
                              MessageBoxButtons.OK,
                              success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                {
                    loadInfo(); // Load lại dữ liệu sau khi xóa thành công
                }
            }
        }

        private void RentalHistory_btn_Click(object sender, EventArgs e)
        {
            Form_RentalHistory rentalHistory = new Form_RentalHistory(form1.taikhoan.Username);
            rentalHistory.Show();
        }

        private void ExcelExporterQLP_btn_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_QLP, "Danh sách phòng");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateRoom_btn_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = dgv_QLP.SelectedRows[0];

            Room selectedRoom = new Room
            {
                RoomId = selectedRow.Cells["RoomID"].Value.ToString(),
                BuildingId = selectedRow.Cells["BuildingID"].Value.ToString(),
                Floor = selectedRow.Cells["Floor"].Value?.ToString(),
                Type = selectedRow.Cells["Type"].Value?.ToString(),
                Convenient = selectedRow.Cells["Convenient"].Value?.ToString(),
                Area = selectedRow.Cells["Area"].Value?.ToString(),
                Price = selectedRow.Cells["Price"].Value?.ToString(),
                Status = selectedRow.Cells["Status"].Value?.ToString()
            };

            // Mở form sửa với dữ liệu đã chọn
            Form_UpdateRoom updateRoom = new Form_UpdateRoom(form1.taikhoan.Username, selectedRoom);
            if (updateRoom.ShowDialog() == DialogResult.OK)
            {
                // Nếu cập nhật thành công thì load lại dữ liệu
                loadInfo();
            }
        }

        private void addAsset_btn_Click(object sender, EventArgs e)
        {
            Form_AddAssets addAssets = new Form_AddAssets();
            this.Hide();
        }

        private void updateAssets_btn_Click(object sender, EventArgs e)
        {
            Form_UpdateAssets updateAssets = new Form_UpdateAssets();
            this.Hide();
        }

        private void deleteAssets_btn_Click(object sender, EventArgs e)
        {
            string assetid = dgv_QLCSVC.SelectedRows[0].Cells["AssetID"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa tài sản {assetid}?",
                                "Xác nhận xóa",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var (success, message) = AssetBLL.DeleteAssets(assetid);

                MessageBox.Show(message,
                                success ? "Thông báo" : "Lỗi",
                                MessageBoxButtons.OK,
                                success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                {
                    loadInfo();
                }
            }
        }

        private void assetsDetail_btn_Click(object sender, EventArgs e)
        {
            Form_AssetsDetail assetsDetail = new Form_AssetsDetail(form1.taikhoan.Username);
            this.Hide();
        }

        private void paymentHistoryAssets_btn_Click(object sender, EventArgs e)
        {
            Form_PaymentHistory paymentHistory = new Form_PaymentHistory();
            this.Hide();  
        }

        private void excelExportAssets_btn_Click(object sender, EventArgs e)
        {
            if (dgv_QLCSVC.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_QLCSVC, "Danh sách tài sản");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
