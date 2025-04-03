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
using GUI.honhathao;
using BLL.honhathao;
using BLL;
using BLL.BLL_Service;
using BLL.Quanlyphuongtien;
using DTO;
using DTO.honhathao;
using GUI.GUI_Service;
using GUI.QuanLyPhuongTien;
using BLL.bll_service;
using DTO.dto_service;


namespace GUI
{
    public partial class quanlynha: Form
    {
        Form_Login form1;
        private int panel1_originalSize = 90;
        private int panel1_extendedSize = 90 + 170;
        private bool panel1_extendedEnabled = true;
        private Point tabQL = new Point(185, 10);
        private Size size_tabQL = new Size(1324, 969);

        private Point tabHD = new Point(0, -30);
        private Size size_tabHD = new Size(1324, 969);
        private Size size_component_quanlytaichinh = new Size(1010, 552);
        private Size size_component_quanlytaichinh_1 = new Size(10, 10);
        private Point location_component_quanlytaichinh = new Point(12, 86);
        private Point location_component_quanlytaichinh_1 = new Point(30,30);
        DataTable data = null;

        public quanlynha(Form_Login form1)
        {
            InitializeComponent();
            setStartPositon();
            this.form1 = form1;
            load_Building_By_User();
            loadInfo();
        }

        private void loadInfo()
        {
            load_QLP();
            load_Contract(0, null);
            load_Assets();
            loadTenant(null);
            loadTenantHistory();
            loadRegistration(null);
        }

        private void clearAllDataGridView()
        {
            dgv_QLP.DataSource = null;
            dgv_QLHD.DataSource = null;
            dgv_QLCSVC.DataSource = null;
            dgv_Tenant.DataSource = null;
            dgv_LSTN.DataSource = null;
            dgv_DKLT.DataSource = null;
        }
        private void loadTenant(string name)
        {
            DataTable data = TenantBLL.TenantBLL_load_Tenant(form1.taikhoan.Username, name);
            data.Columns.RemoveAt(0);
            data.Columns[0].ColumnName = "Mã khách hàng";
            data.Columns[1].ColumnName = "Họ";
            data.Columns[2].ColumnName = "Tên";
            data.Columns[3].ColumnName = "Ngày sinh";
            data.Columns[4].ColumnName = "Giới Tính";
            data.Columns[5].ColumnName = "SĐT";
            data.Columns[6].ColumnName = "Email";
            dgv_Tenant.DataSource = data;
            dgv_Tenant.Columns[0].Width = 90;
            dgv_Tenant.Columns[1].Width = 150;
            dgv_Tenant.Columns[2].Width = 100;
            dgv_Tenant.Columns[3].Width = 80;
            dgv_Tenant.Columns[4].Width = 100;
            dgv_Tenant.Columns[5].Width = 200;
            dgv_Tenant.Columns[6].Width = 300;
            dgv_Tenant.ScrollBars = ScrollBars.Both;
        }
        private void loadTenantHistory()
        {
            DataTable data = TenantHistoryBLL.TenantHistoryBLL_load_Tenant(listBuildingID.Text);
            dgv_LSTN.DataSource = data;
            dgv_LSTN.Columns[0].Width = 90;
            dgv_LSTN.Columns[1].Width = 150;
            dgv_LSTN.Columns[2].Width = 100;
            dgv_LSTN.Columns[3].Width = 80;
            dgv_LSTN.Columns[4].Width = 100;
            dgv_LSTN.Columns[5].Width = 200;
            dgv_LSTN.ScrollBars = ScrollBars.Both;
        }
        private void loadRegistration(string name)
        {
            DataTable data = RegistrationBLL.RegistrationBLL_load_registration(listBuildingID.Text, name);
            dgv_DKLT.DataSource = data;
            dgv_DKLT.Columns[0].Width = 90;
            dgv_DKLT.Columns[1].Width = 150;
            dgv_DKLT.Columns[2].Width = 100;
            dgv_DKLT.Columns[3].Width = 80;
            dgv_DKLT.Columns[4].Width = 100;
            dgv_DKLT.Columns[5].Width = 200;
            dgv_DKLT.ScrollBars = ScrollBars.Both;
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

        private void load_Contract(int control, string name)
        {
            dgv_QLHD.DataSource = ContractBLL.ContractBLL_load_Contract_filter(listBuildingID.Text, control, name);
            dgv_QLHD.Columns[0].Width = 70;
            dgv_QLHD.Columns[1].Width = 70;
            dgv_QLHD.Columns[2].Width = 90;
            dgv_QLHD.Columns[3].Width = 100;
            dgv_QLHD.Columns[4].Width = 100;
            dgv_QLHD.Columns[5].Width = 100;
            dgv_QLHD.Columns[6].Width = 100;
            dgv_QLHD.Columns[7].Width = 100;
            dgv_QLHD.Columns[8].Width = 100;
            dgv_QLHD.Columns[9].Width = 100;
            dgv_QLHD.Columns[10].Width = 100;
            dgv_QLHD.Columns[11].Width = 200;
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

            dklt4.Location = tabHD;
            dklt4.Size = size_tabHD;
        }

        private void load_Building_By_User()
        {
            if (data != null)
            {
                data.Clear();
                listBuildingID.Items.Clear();
            }
            data = BuildingBLL.BuildingBLL_load_Building_By_User(form1.taikhoan.Username);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                listBuildingID.Items.Add(data.Rows[i][0].ToString());
            }
            if (listBuildingID.Items.Count == 0)
            {
                return;
            }
            else
            {
                listBuildingID.SelectedIndex = 0;
                buildingKey.Text = data.Rows[0][1].ToString();
            }
           
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
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void hd1_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 0;
        }
        private void hd2_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 0;

        }
        private void hd3_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 0;

        }
        private void hd4_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 0;

        }
        private void lstn1_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 1;

        }
        private void lstn2_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 1;

        }
        private void lstn3_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 1;

        }
        private void lstn4_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 1;

        }
        private void ttkt1_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 2;

        }
        private void ttkt2_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 2;

        }
        private void ttkt3_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 2;

        }
        private void ttkt4_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 2;

        }
        private void dklt1_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 3;

        }
        private void dklt2_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 3;

        }
        private void dklt3_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 3;

        }
        private void dklt4_Click(object sender, EventArgs e)
        {
            dklt4.SelectedIndex = 3;

        }
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đăng ký lưu trú này không?", "Xác nhận xóa", buttons);
                if (result == DialogResult.Yes)
                {
                    RegistrationBLL.RegistrationBLL_del_registration(dgv_DKLT.SelectedRows[0].Cells[0].Value.ToString());
                    MessageBox.Show("Xóa thành công");
                    loadRegistration(null);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Vui lòng chọn đăng ký lưu trú cần xóa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", buttons);
                if (result == DialogResult.Yes)
                {
                    TenantBLL.TenantBLL_del_Tenant(dgv_Tenant.SelectedRows[0].Cells[0].Value.ToString());
                    MessageBox.Show("Xóa thành công");
                    loadTenant(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Form_Registration f = new Form_Registration(1, listBuildingID.Text, 0, dgv_DKLT, dgv_Tenant);
            f.ShowDialog();
            loadRegistration(null);
        }
        private void timkiem_ttenant_Click(object sender, EventArgs e)
        {
            loadTenant(timkiem_Tenant.Text);
        }
        private void button16_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgv_DKLT.CurrentCell != null && dgv_DKLT.CurrentCell.RowIndex >= 0)
                {
                    int row = dgv_DKLT.CurrentCell.RowIndex;
                    DataGridViewRow data = dgv_DKLT.Rows[row];
                    Form_Registration f = new Form_Registration(row, listBuildingID.Text, 1, dgv_DKLT, null);

                    f.ShowDialog();
                    loadRegistration(null);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng trước!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void check_Contract_filter()
        {
            if (!checkBox1.Checked && !checkBox4.Checked && !checkBox3.Checked)
            {
                load_Contract(0, timkiem_contract.Text);
            }
        }
        private void button_tk_contract_Click(object sender, EventArgs e)
        {
            int chec = 0;
            if (checkBox1.Checked)
            {
                chec = 3;
            }
            else if (checkBox4.Checked)
            {
                chec = 1;
            }
            else if (checkBox3.Checked)
            {
                chec = 2;
            }
            load_Contract(chec, timkiem_contract.Text);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox4.Checked = false;
                checkBox3.Checked = false;
                load_Contract(3, timkiem_contract.Text);
            }
            check_Contract_filter();
        }
        private void button_tk_dklt_Click(object sender, EventArgs e)
        {
            loadRegistration(timkiem_dklt.Text);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                load_Contract(1, timkiem_contract.Text);
            }
            check_Contract_filter();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                load_Contract(2, timkiem_contract.Text);
            }
            check_Contract_filter();
        }
        private void button30_Click(object sender, EventArgs e)
        {
            DataGridViewRow data = null;
            Form_Tenant f = new Form_Tenant(data, 0, form1.taikhoan.Username);
            f.ShowDialog();
            loadTenant(null);
        }
        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgv_Tenant.CurrentCell.RowIndex;
                DataGridViewRow data = dgv_Tenant.Rows[row];
                Form_Tenant f = new Form_Tenant(data, 1, form1.taikhoan.Username);
                f.ShowDialog();
                loadTenant(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Form_AddContract f = new Form_AddContract(form1.taikhoan.Username, 0, 1, listBuildingID.Text, dgv_QLHD, dgv_Tenant);
            f.ShowDialog();
            load_Contract(0, timkiem_contract.Text);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgv_QLHD.CurrentCell.RowIndex;
                if (row >= 0)
                {
                    Form_AddContract f = new Form_AddContract(form1.taikhoan.Username, 1, row, listBuildingID.Text, dgv_QLHD, dgv_Tenant);
                    f.ShowDialog();
                    load_Contract(0, timkiem_contract.Text);
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
            try
            {
                int row = dgv_QLHD.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dgv_QLHD.Rows[row];
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận xóa", buttons);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(ContractBLL.ContractBLL_delete_Contract(selectedRow.Cells[0].Value.ToString()));
                }
                load_Contract(0, timkiem_contract.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBuildingID_SelectionChangeCommitted(object sender, EventArgs e)
        {

            clearAllDataGridView();
            buildingKey.Text = data.Rows[listBuildingID.SelectedIndex][1].ToString();
            loadInfo();

        }

        private List<CheckBox> sortOptions = new List<CheckBox>();

        public string filet_Service = "Default";
        public void btn_dichvu_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 4;

            var data = serviceUsageBLL.GetServiceUsage(filet_Service, listBuildingID.Text);

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
            }
            dgvServiceInfo.DataSource = data;

            checkBox_DV1.Visible = true;
            checkBox_DV2.Visible = true;
            checkBox_DV3.Visible = true;
            checkBox_DV4.Visible = true;
            checkBox_DV5.Visible = true;

            sortOptions.Add(checkBox_DV1);
            sortOptions.Add(checkBox_DV2);
            sortOptions.Add(checkBox_DV3);
            sortOptions.Add(checkBox_DV4);
            sortOptions.Add(checkBox_DV5);

            foreach (var chk in sortOptions)
            {
                chk.CheckedChanged += CheckBox_CheckedChanged;
            }

        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox current = (CheckBox)sender;
            if (current.Checked)
            {
                foreach (var chk in sortOptions)
                {
                    chk.CheckedChanged -= CheckBox_CheckedChanged;
                }

                foreach (var chk in sortOptions)
                {
                    if (chk != current)
                    {
                        chk.Checked = false;
                    }
                }

                foreach (var chk in sortOptions)
                {
                    chk.CheckedChanged += CheckBox_CheckedChanged;
                }


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
                var data = serviceUsageBLL.GetServiceUsage(filet_Service, listBuildingID.Text);

                if (data == null || data.Count == 0) 
                {
                    MessageBox.Show("Không có dữ liệu!");
                }
                dgvServiceInfo.DataSource = data;

            }
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 5;
            LoadParkingAreaData(listBuildingID.Text);
        }


        private void addRoom_btn_Click(object sender, EventArgs e)
        {
            Form_AddRoom addRoom = new Form_AddRoom(form1.taikhoan.Username);
            if (addRoom.ShowDialog() == DialogResult.OK)
            {
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
                    load_QLP();
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

            Form_UpdateRoom updateRoom = new Form_UpdateRoom(form1.taikhoan.Username, selectedRoom);
            if (updateRoom.ShowDialog() == DialogResult.OK)
            {
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
        private void DangO_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox1.Checked && DangTrong_chbox1.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang ở' vừa 'Đang trống'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangO_chbox1.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangTrong_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox1.Checked && DangO_chbox1.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang trống' vừa 'Đang ở'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangTrong_chbox1.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangKT_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangKT_chbox1.Checked && DangCoc_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangKT_chbox1.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangCoc_chbox.Checked && (DangO_chbox1.Checked || DangKT_chbox1.Checked))
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
                List<string> selectedStatuses = new List<string>();

                if (DangO_chbox1.Checked) selectedStatuses.Add(DangO_chbox1.Text);
                if (DangTrong_chbox1.Checked) selectedStatuses.Add(DangTrong_chbox1.Text);
                if (DangKT_chbox1.Checked) selectedStatuses.Add(DangKT_chbox1.Text);
                if (DangCoc_chbox.Checked) selectedStatuses.Add(DangCoc_chbox.Text);
                if (SapHetHan_chbox.Checked) selectedStatuses.Add(SapHetHan_chbox.Text);
                if (DaQuaHan_chbox.Checked) selectedStatuses.Add(DaQuaHan_chbox.Text);
                if (DangNoTien_chbox.Checked) selectedStatuses.Add(DangNoTien_chbox.Text);
                string statusFilter = string.Join("; ", selectedStatuses);
                DataTable filteredData = RoomBLL.FilterRoomByStatus(statusFilter, form1.taikhoan.Username);

                dgv_QLP.DataSource = null; 
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
            dgv_QLP.Columns["RoomID"].DisplayIndex = 0;
            dgv_QLP.Columns["BuildingID"].DisplayIndex = 1;
            dgv_QLP.Columns["Floor"].DisplayIndex = 2;
            dgv_QLP.Columns["Type"].DisplayIndex = 3;
            dgv_QLP.Columns["Convenient"].DisplayIndex = 4;
            dgv_QLP.Columns["Area"].DisplayIndex = 5;
            dgv_QLP.Columns["Price"].DisplayIndex = 6;
            dgv_QLP.Columns["Status"].DisplayIndex = 7;
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

        private void button32_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa");
                return;
            }
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
            Form_UpdateRoom updateRoom = new Form_UpdateRoom(form1.taikhoan.Username, selectedRoom);
            if (updateRoom.ShowDialog() == DialogResult.OK)
            {
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
                    load_QLP(); 
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








        private UserService serviceUsageBLL = new UserService();

        public void RefreshParkingAreaData()
        {
            LoadParkingAreaData(listBuildingID.Text);
        }
        public void LoadParkingAreaDataWithFilter(DataTable filteredData)
        {
            try
            {
                guna2DataGridView7.DataSource = filteredData;

                guna2DataGridView7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                guna2DataGridView7.EnableHeadersVisualStyles = false;

                guna2DataGridView7.ColumnHeadersHeight = 40;

                guna2DataGridView7.ReadOnly = true;
                guna2DataGridView7.AllowUserToAddRows = false;
                guna2DataGridView7.AllowUserToDeleteRows = false;
                guna2DataGridView7.AllowUserToOrderColumns = false;
                guna2DataGridView7.AllowUserToResizeRows = false;
                guna2DataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (guna2DataGridView7.Columns.Count > 0)
                {
                    guna2DataGridView7.Columns["AREAID"].HeaderText = "ID Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["BUILDINGID"].HeaderText = "ID Tòa Nhà";
                    guna2DataGridView7.Columns["ADDRESS"].HeaderText = "Địa Chỉ";
                    guna2DataGridView7.Columns["TYPE"].HeaderText = "Loại Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["CAPACITY"].HeaderText = "Sức Chứa";

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
        private void LoadSettingsData()
        {
            DataTable dt = BLL.PaymentBLL.GetAllPayments();




            guna2DataGridView2.DataSource = dt;

            guna2DataGridView2.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 120, 215); 
            guna2DataGridView2.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView2.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            guna2DataGridView2.ColumnHeadersHeight = 40;

            if (guna2DataGridView2.Columns.Count > 0)
            {
                guna2DataGridView2.Columns[0].HeaderText = "Mã thanh toán";
                guna2DataGridView2.Columns[1].HeaderText = "Mã hóa đơn";
                guna2DataGridView2.Columns[2].HeaderText = "Phương thức";
                guna2DataGridView2.Columns[3].HeaderText = "Số tiền";
                guna2DataGridView2.Columns[4].HeaderText = "Thời gian";
                guna2DataGridView2.Columns[3].DefaultCellStyle.Format = "N0";


            }

            guna2DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView2.Refresh();
        }
        private void LoadParkingAreaData(string buildingID)
        {
            try
            {
                guna2DataGridView7.DataSource = ParkingAreaBLL.GetAllParkingAreas(buildingID);

                guna2DataGridView7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                guna2DataGridView7.EnableHeadersVisualStyles = false;

                guna2DataGridView7.ColumnHeadersHeight = 40;


                guna2DataGridView7.ReadOnly = true;
                guna2DataGridView7.AllowUserToAddRows = false;
                guna2DataGridView7.AllowUserToDeleteRows = false;
                guna2DataGridView7.AllowUserToOrderColumns = false;
                guna2DataGridView7.AllowUserToResizeRows = false;
                guna2DataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (guna2DataGridView7.Columns.Count > 0)
                {
                    guna2DataGridView7.Columns["AREAID"].HeaderText = "ID Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["BUILDINGID"].HeaderText = "ID Tòa Nhà";
                    guna2DataGridView7.Columns["ADDRESS"].HeaderText = "Địa Chỉ";
                    guna2DataGridView7.Columns["TYPE"].HeaderText = "Loại Bãi Đỗ Xe";
                    guna2DataGridView7.Columns["CAPACITY"].HeaderText = "Sức Chứa";

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
                if (guna2DataGridView7.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khu vực đỗ xe để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string areaId = guna2DataGridView7.SelectedRows[0].Cells["AREAID"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khu vực đỗ xe {areaId} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                {
                    return;
                }

                if (ParkingAreaBLL.DeleteParkingArea(areaId, out string message))
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshParkingAreaData();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv";
                    sfd.FileName = $"DanhSachBaiDoXe_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return; 
                    }

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

                    if (ParkingAreaBLL.ExportParkingAreasToExcelWithChart(sfd.FileName, out string message , listBuildingID.Text))
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
            AddService addServiceForm = new AddService(listBuildingID.Text);
            addServiceForm.ShowDialog();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            DeleteService delServiceForm = new DeleteService(this);
            delServiceForm.ShowDialog();
        }

        private void themDV_btn_Click(object sender, EventArgs e)
        {
            InsertService insertServiceForm = new InsertService();
            insertServiceForm.ShowDialog();
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            AddService addServiceForm = new AddService(listBuildingID.Text);
            addServiceForm.ShowDialog();
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            DeleteService delServiceForm = new DeleteService(this);
            delServiceForm.ShowDialog();
        }

        private void themDV_btn_Click_1(object sender, EventArgs e)
        {
            InsertService insertServiceForm = new InsertService();
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


        private void checkBox_DV5_CheckedChanged(object sender, EventArgs e)
        {


            checkBox_DV1.Checked = false;
            checkBox_DV2.Checked = false;
            checkBox_DV3.Checked = false;
            checkBox_DV4.Checked = false;


            //combo_DV1.Visible = false;
            //combo_DV2.Visible = false;
        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            GUI.QuanLyPhuongTien.QuanLyPhuonTien quanLyPhuonTienForm = new QuanLyPhuonTien(listBuildingID.Text);
            quanLyPhuonTienForm.Owner = this;
            quanLyPhuonTienForm.ShowDialog();
        }

        private void button53_Click(object sender, EventArgs e)
        {

            try
            {
                if (guna2DataGridView7.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bãi đỗ xe để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string areaId = guna2DataGridView7.SelectedRows[0].Cells["AREAID"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn sửa thông tin bãi đỗ xe {areaId} không?",
                                                      "Xác nhận sửa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                {
                    return;
                }

                using (var suaForm = new GUI.QuanLyPhuongTien.Suaphuongtien(areaId, listBuildingID.Text))
                {
                    if (suaForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshParkingAreaData();
                    }
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
                if (guna2DataGridView7.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khu vực đỗ xe để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string areaId = guna2DataGridView7.SelectedRows[0].Cells["AREAID"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khu vực đỗ xe {areaId} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                {
                    return;
                }

                if (ParkingAreaBLL.DeleteParkingArea(areaId, out string message))
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshParkingAreaData();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
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

                    if (ParkingAreaBLL.ExportParkingAreasToExcelWithChart(sfd.FileName, out string message, listBuildingID.Text))
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


        private void button37_Click(object sender, EventArgs e)
        {
            if (dgv_Tenant.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_Tenant, "Danh sách Khách Thuê");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string new_key = RandomKey.RandomString(10);
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thay đổi key không?", "Xác nhận thay đổi", buttons);
            if (result == DialogResult.Yes)
            {
                BuildingBLL.BuildingBLL_change_building_key(data.Rows[listBuildingID.SelectedIndex][0].ToString(), new_key);
                buildingKey.Text = new_key;
            }
            load_Building_By_User();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form_AddBuilding f = new Form_AddBuilding(RandomKey.RandomString(10) , form1.taikhoan.Username);
            f.ShowDialog();
            load_Building_By_User();
        }
        private ElectricWaterServiceBLL figureBLL = new ElectricWaterServiceBLL();
        private void button13_Click_1(object sender, EventArgs e)
        {
            dgvServiceInfo.DataSource = null;
            List<ElectricWaterServiceDTO> figures = figureBLL.GetAllElectricWaterData(listBuildingID.Text);
            dgvServiceInfo.DataSource = figures;
            checkBox_DV1.Visible = false;
            checkBox_DV2.Visible = false;
            checkBox_DV3.Visible = false;
            checkBox_DV4.Visible = false;
            checkBox_DV5.Visible = false;
        }
    }
}
