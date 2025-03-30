using BLL;
using BLL.BLL_Service;
using BLL.Quanlyphuongtien;
using DTO;
using GUI.GUI_Service;
using Guna.UI2.WinForms;
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
            load_Assets();
        }

        private void load_Assets()
        {
            dgv_QLCSVC.DataSource = AssetBLL.AssetsBLL_load_Assets(form1.taikhoan.Username);
            dgv_QLCSVC.Columns[0].Width = 90;
            dgv_QLCSVC.Columns[1].Width = 90;
            dgv_QLCSVC.Columns[2].Width = 90;
            dgv_QLCSVC.Columns[3].Width = 150;
            dgv_QLCSVC.Columns[4].
                Width = 250;
            dgv_QLCSVC.Columns[5].Width = 80;
            dgv_QLCSVC.ScrollBars = ScrollBars.Both;
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
        //-------------------------------------------------------------------------------------
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


        public void setPosition_hoaDon_thuChi(Panel p1, Panel p2)
        {
            p1.Size = size_component_quanlytaichinh;
            p1.Location = location_component_quanlytaichinh;
            p2.Size = size_component_quanlytaichinh_1;
            p2.Location = location_component_quanlytaichinh_1;
        }



        private void btn_phong_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 0;
        }

        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 1;
        }
        private void btn_taichinh_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 2;


        }

        private void btn_csvc_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 3;


        }

        // Load DIch VU
        private List<CheckBox> sortOptions = new List<CheckBox>();

        public string filet_Service = "Default";
        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 4;
            
            var data = serviceUsageBLL.GetServiceUsage(filet_Service);

            if (data == null || data.Count == 0) // Nếu là List
            {
                MessageBox.Show("Không có dữ liệu!");
            }
            dgvServiceInfo.DataSource = data;

            //combo_DV1.Visible = false;
            //combo_DV2.Visible = false;

            // Thêm các checkbox vào danh sách
            sortOptions.Add(checkBox_DV1); // Giá cao-thấp
            sortOptions.Add(checkBox_DV2); // Giá thấp-cao
            sortOptions.Add(checkBox_DV3); // Ngày gần đây
            sortOptions.Add(checkBox_DV4); // Ngày xa nhất
            sortOptions.Add(checkBox_DV5); // Tên tăng dần



            // Đăng ký sự kiện cho tất cả checkbox
            foreach (var chk in sortOptions)
            {
                chk.CheckedChanged += CheckBox_CheckedChanged;
            }
           
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox current = (CheckBox)sender;
            // Chỉ xử lý khi checkbox được chọn
            if (current.Checked)
            {
                // Tạm ngừng sự kiện để tránh lặp vô hạn
                foreach (var chk in sortOptions)
                {
                    chk.CheckedChanged -= CheckBox_CheckedChanged;
                }

                // Bỏ chọn tất cả checkbox khác
                foreach (var chk in sortOptions)
                {
                    if (chk != current)
                    {
                        chk.Checked = false;
                    }
                }

                // Khôi phục sự kiện
                foreach (var chk in sortOptions)
                {
                    chk.CheckedChanged += CheckBox_CheckedChanged;
                }


                // Thay đổi filter dựa trên checkbox được chọn
                if (current.Name == "checkBox_DV1" || current.Text == "Giá cao-thấp")
                {
                    filet_Service = "GiaGiam";

                }
                else if (current.Name == "checkBox_DV2" || current.Text == "Giá thấp-cao")
                {
                    filet_Service = "GiaTang";
                }
                else if (current.Name == "checkBox_DV3" || current.Text == "Ngày gần đây")
                {
                    filet_Service = "NgayMoi";
                }
                else if (current.Name == "checkBox_DV4" || current.Text == "Ngày xa nhất")
                {
                    filet_Service = "NgayCu";
                }
                else if (current.Name == "checkBox_DV4" || current.Text == "Tên tăng dần")
                {
                    filet_Service = "TenTang";
                }
                var data = serviceUsageBLL.GetServiceUsage(filet_Service);

                if (data == null || data.Count == 0) // Nếu là List
                {
                    MessageBox.Show("Không có dữ liệu!");
                }
                dgvServiceInfo.DataSource = data;

            }
        }
      
        private void btn_caidat_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 5;
            LoadParkingAreaData();
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
        //-------------------------------------------------------------------------------------



        private void button38_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataRow = null;
            Form_AddContract f = new Form_AddContract(form1.taikhoan.Username, 0, dataRow);
            f.ShowDialog();
            loar_Contract();
        }

        private void button40_Click(object sender, EventArgs e)
        {

            try {
                int row = dgv_QLHD.CurrentCell.RowIndex;
                if (row >= 0)
                {
                    DataGridViewRow dataRow = dgv_QLHD.Rows[row];
                    Form_AddContract f = new Form_AddContract(form1.taikhoan.Username, 1, dataRow);
                    f.ShowDialog();
                    loar_Contract();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần sửa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button39_Click(object sender, EventArgs e)
        {


            try {
                int row = dgv_QLHD.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dgv_QLHD.Rows[row];
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận xóa", buttons);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(ContractBLL.ContractBLL_delete_Contract(selectedRow.Cells[0].Value.ToString()));
                }
                loar_Contract();
            }
             
            catch(Exception ex)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addRoom_btn_Click(object sender, EventArgs e)
        {
            Form_AddRoom addRoom = new Form_AddRoom(form1.taikhoan.Username);
            if (addRoom.ShowDialog() == DialogResult.OK)
            {
                // Nếu thêmthành công thì load lại dữ liệu
                load_QLP();
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
                    load_QLP(); // Load lại dữ liệu sau khi xóa thành công
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
                Type = selectedRow.Cells["Type"].Value?.ToString(),
                Floor = selectedRow.Cells["Floor"].Value?.ToString(),
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
                load_QLP();
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

        //Hoài An Chỉnh lại bên tên bên phần giao diện (lỗi do sai tên nút)
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
            // Đảm bảo thứ tự cột không thay đổi sau khi lọc
            dgv_QLP.Columns["RoomID"].DisplayIndex = 0;
            dgv_QLP.Columns["BuildingID"].DisplayIndex = 1;
            dgv_QLP.Columns["Floor"].DisplayIndex = 2;
            dgv_QLP.Columns["Type"].DisplayIndex = 3;
            dgv_QLP.Columns["Convenient"].DisplayIndex = 4;
            dgv_QLP.Columns["Area"].DisplayIndex = 5;
            dgv_QLP.Columns["Price"].DisplayIndex = 6;
            dgv_QLP.Columns["Status"].DisplayIndex = 7;

            // Thiết lập width
            dgv_QLP.Columns["RoomID"].Width = 90;
            dgv_QLP.Columns["BuildingID"].Width = 90;
            dgv_QLP.Columns["Floor"].Width = 150;
            dgv_QLP.Columns["Type"].Width = 150;
            dgv_QLP.Columns["Convenient"].Width = 250;
            dgv_QLP.Columns["Area"].Width = 80;
            dgv_QLP.Columns["Price"].Width = 80;
            dgv_QLP.Columns["Status"].Width = 150;

            dgv_QLP.ScrollBars = ScrollBars.Both;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Form_AddRoom addRoom = new Form_AddRoom(form1.taikhoan.Username);
            if (addRoom.ShowDialog() == DialogResult.OK)
            {
                // Nếu thêm thành công thì load lại dữ liệu
                load_QLP();
            }
        }

        private void button32_Click(object sender, EventArgs e)
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
                Type = selectedRow.Cells["Type"].Value?.ToString(),
                Floor = selectedRow.Cells["Floor"].Value?.ToString(),
                
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
                load_QLP();
            }
        }

        private void button29_Click(object sender, EventArgs e)
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
                    load_QLP(); // Load lại dữ liệu sau khi xóa thành công
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Form_RentalHistory rentalHistory = new Form_RentalHistory(form1.taikhoan.Username);
            rentalHistory.Show();
        }

        private void button36_Click(object sender, EventArgs e)
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






        //Huy và Thế An

        // QUAN lI dICH vU
        private UserService serviceUsageBLL = new UserService();
        //public void btn_dichvu_Click(object sender, EventArgs e)
        //{
        //    tabQuanLy.SelectedIndex = 4;
        //    tabQuanLy.SelectedIndex = 4;
        //    var data = serviceUsageBLL.GetServiceUsage();
        //    if (data == null || data.Count == 0) // Nếu là List
        //    {
        //        MessageBox.Show("Không có dữ liệu!");
        //    }
        //    dgvServiceInfo.DataSource = data;
        //}
        //Quản lý bãi đậu xe
        //private void btn_caidat_Click(object sender, EventArgs e)
        //{
        //    tabQuanLy.SelectedIndex = 5;
        //    LoadParkingAreaData();

        //}
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

        private void button49_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form AddService
            AddService addServiceForm = new AddService(this);

            // Hiển thị form đó
            addServiceForm.ShowDialog();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form AddService
            DeleteService delServiceForm = new DeleteService(this);

            // Hiển thị form đó
            delServiceForm.ShowDialog();
        }

        private void themDV_btn_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form AddService
            InsertService insertServiceForm = new InsertService();

            // Hiển thị form đó
            insertServiceForm.ShowDialog();
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            // Tạo một instance của form AddService
            AddService addServiceForm = new AddService(this);

            // Hiển thị form đó
            addServiceForm.ShowDialog();
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            // Tạo một instance của form AddService
            DeleteService delServiceForm = new DeleteService(this);

            // Hiển thị form đó
            delServiceForm.ShowDialog();
        }

        private void themDV_btn_Click_1(object sender, EventArgs e)
        {
            // Tạo một instance của form AddService
            InsertService insertServiceForm = new InsertService();

            // Hiển thị form đó
            insertServiceForm.ShowDialog();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.FileName = $"ThongKeDichVu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    if (BLL.BLL_Service.ServiceBLL.ExportServicesToExcelWithChart(sfd.FileName, out string message))
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

        private void checkBox_DV1_CheckedChanged(object sender, EventArgs e)
        {

          
        }

        private void checkBox_DV2_CheckedChanged(object sender, EventArgs e)
        {

           
        }

        private void checkBox_DV3_CheckedChanged(object sender, EventArgs e)
        {

          
        }

        private void checkBox_DV4_CheckedChanged(object sender, EventArgs e)
        {


           
         
        }

        private void checkBox_DV5_CheckedChanged(object sender, EventArgs e)
        {
    
         
            //checkBox_DV1.Checked = false;
            //checkBox_DV2.Checked = false;
            //checkBox_DV3.Checked = false;
            //checkBox_DV4.Checked = false;


            //combo_DV1.Visible = false;
            //combo_DV2.Visible = false;
        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            GUI.QuanLyPhuongTien.QuanLyPhuonTien quanLyPhuonTienForm = new GUI.QuanLyPhuongTien.QuanLyPhuonTien();
            quanLyPhuonTienForm.Owner = this;
            quanLyPhuonTienForm.ShowDialog();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (guna2DataGridView7.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bãi đỗ xe để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy areaId từ dòng được chọn
                string areaId = guna2DataGridView7.SelectedRows[0].Cells["AREAID"].Value.ToString();

                // Xác nhận sửa
                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn sửa thông tin bãi đỗ xe {areaId} không?",
                                                      "Xác nhận sửa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                {
                    return;
                }

                // Mở form sửa thông tin
                using (var suaForm = new GUI.QuanLyPhuongTien.Suaphuongtien(areaId))
                {
                    if (suaForm.ShowDialog() == DialogResult.OK)
                    {
                        // Nếu form đóng với DialogResult.OK, cập nhật lại dữ liệu
                        RefreshParkingAreaData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button52_Click_1(object sender, EventArgs e)
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

        private void button57_Click_1(object sender, EventArgs e)
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

        private void button41_Click(object sender, EventArgs e)
        {
            if (dgv_QLHD.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_QLHD, "Danh sách Hợp đồng");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
