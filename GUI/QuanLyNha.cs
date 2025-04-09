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
using DTO.honhathao;
using GUI.QuanLyPhuongTien;
using DTO.dto_service;
using BLL.bll_service;
using DTO.DTO_Service;
using GUI.gui_service;
using System.Security.Policy;

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
            addTenantHistory();//New NhatHao
            loadTenantHistory(null);
            loadRegistration(null);
            loadBill(null);//New NhatHao

            loadInitLanguage(); //New NhatHao
            loadLanguage();//New NhatHao

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
            //data.Columns[0].ColumnName = "Mã khách hàng";
            //data.Columns[1].ColumnName = "Họ";
            //data.Columns[2].ColumnName = "Tên";
            //data.Columns[3].ColumnName = "Ngày sinh";
            //data.Columns[4].ColumnName = "Giới Tính";
            //data.Columns[5].ColumnName = "SĐT";
            //data.Columns[6].ColumnName = "Email";//comment lại
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
        private void loadTenantHistory(string name)
        {
            DataTable data = TenantHistoryBLL.TenantHistoryBLL_load_Tenant(listBuildingID.Text,name);
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

        private void load_Assets() 
        {
            if (listBuildingID.SelectedItem == null)
            {
                dgv_QLCSVC.DataSource = AssetBLL.LoadAssets(form1.taikhoan.Username, null);
            }
            else
            {
                dgv_QLCSVC.DataSource = AssetBLL.LoadAssets(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            }
            dgv_QLCSVC.Columns[0].Width = 90;
            dgv_QLCSVC.Columns[1].Width = 90;
            dgv_QLCSVC.Columns[2].Width = 150;
            dgv_QLCSVC.Columns[3].Width = 100;
            dgv_QLCSVC.Columns[4].Width = 150;
            dgv_QLCSVC.Columns[5].Width = 80;
            dgv_QLCSVC.ScrollBars = ScrollBars.Both;
        }

        private void load_QLP() 
        {
            if (listBuildingID.SelectedItem == null)
            {
                dgv_QLP.DataSource = RoomBLL.LoadRoom(form1.taikhoan.Username, null);
            }
            else
            {
                dgv_QLP.DataSource = RoomBLL.LoadRoom(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            }
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


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        //-----------------------------------------------------------------------
        //Code mới

        //Code sửa từ function đã có

        //Code xóa

        //-----------------------------------------------------------------------

        private void setStartPositon()
        {
            tabQuanLy.Location = tabQL;
            tabQuanLy.Size = size_tabQL;

            dklt4.Location = tabHD;
            dklt4.Size = size_tabHD;

            tabControl1.Location = tabHD;
            tabControl1.Size = size_tabHD;
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


       

        public GetAllServiceBLL getAllServiceBLL = new GetAllServiceBLL();
        private void btn_xemdichvu_Click(object sender, EventArgs e)
        {
            try
            {
                List<DichVuDTO> listDichVu = new List<DichVuDTO>();
                listDichVu = getAllServiceBLL.GetAllDichVu();

                SeeAllService seeForm = new SeeAllService(listDichVu);
                seeForm.ShowDialog(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy danh sách dịch vụ: " + ex.Message);
            }

        }

        private void guna2GradientButton12_Click(object sender, EventArgs e)
        {
            EmailBLL bll = new EmailBLL();

            string danhSachTo = bll.LayChuoiEmailNguoiNhan(listBuildingID.Text);
            string[] danhSachEmail = danhSachTo.Split(',');



            bool emailSentSuccessfully = true;  

            foreach (var emailRecipient in danhSachEmail)
            {
                string recipientEmail = emailRecipient.Trim();



                EmailDTO email = new EmailDTO
                {
                    From = "nhuthuyhk9@gmail.com",
                    Password = "gdjq astk ezog zdjz",
                    To = recipientEmail, // Gửi từng email cho mỗi người nhận
                    Subject = "Gửi từ phần mềm quản lí nhà Rentease",
                    Body = "Xin chào, hợp đồng của bạn sắp hết hạn. Đây là email tự động."
                };

                bool result = bll.GuiEmail(email);

                if (!result)
                {
                    emailSentSuccessfully = false;
                    break; 
                }
            }

            if (emailSentSuccessfully)
            {
                MessageBox.Show("Gửi email thành công!");
            }
            else
            {
                MessageBox.Show("Gửi email thất bại.");
            }
        }
        private void btn_vantay_Click(object sender, EventArgs e)
        {
            FingerprintManagementForm fingerprintForm = new FingerprintManagementForm(
                form1.taikhoan.Username,
                listBuildingID.SelectedItem.ToString()
            );
            fingerprintForm.ShowDialog();
        }

        

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            Form_W_E form_W_E = new Form_W_E(form1.taikhoan.Username, listBuildingID.Text);
            form_W_E.ShowDialog();
            string result = BillBLL.BillBLL_calculate_bill();
            loadBill(null);
        }

        public void btn_dichvu_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 4;



            var data = serviceUsageBLL.GetServiceUsage(filet_Service, listBuildingID.Text);

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
            }
            dgvServiceInfo.DataSource = data;

            //dgvServiceInfo.Columns["STT"].HeaderText = "STT";
            //dgvServiceInfo.Columns["RoomID"].HeaderText = "Mã phòng";
            //dgvServiceInfo.Columns["TenantName"].HeaderText = "Tên người thuê";
            //dgvServiceInfo.Columns["ServiceName"].HeaderText = "Tên dịch vụ";
            //dgvServiceInfo.Columns["ServicePrice"].HeaderText = "Giá dịch vụ";
            //dgvServiceInfo.Columns["StartedDay"].HeaderText = "Ngày bắt đầu";
            //dgvServiceInfo.Columns["EndDay"].HeaderText = "Ngày kết thúc";


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


        
        private void button11_Click(object sender, EventArgs e)
        {
            DataTable tmp = TenantHistoryBLL.TenantHistoryBLL_count_TenantHistory(listBuildingID.Text);
            Console.WriteLine(tmp.Rows.Count);
            if (tmp != null)
            {
                for (int i = 0; i < tmp.Rows.Count; i++)
                {
                    TenantHistoryBLL.TenantHistoryBLL_auto_AddTenantHistory(
                        tmp.Rows[i][0].ToString(),
                        tmp.Rows[i][2].ToString(),
                        tmp.Rows[i][1].ToString(),
                        tmp.Rows[i][4].ToString(),
                        tmp.Rows[i][5].ToString());
                }
            }
        }

        private void addTenantHistory()
        {
            DataTable tmp = TenantHistoryBLL.TenantHistoryBLL_count_TenantHistory(listBuildingID.Text);
            Console.WriteLine(tmp.Rows.Count);
            if (tmp != null)
            {
                for (int i = 0; i < tmp.Rows.Count; i++)
                {
                    TenantHistoryBLL.TenantHistoryBLL_auto_AddTenantHistory(
                        tmp.Rows[i][0].ToString(),
                        tmp.Rows[i][2].ToString(),
                        tmp.Rows[i][1].ToString(),
                        tmp.Rows[i][4].ToString(),
                        tmp.Rows[i][5].ToString());
                }
            }
        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            
            Form_TenantHistory f = new Form_TenantHistory(dgv_LSTN.Rows[dgv_LSTN.CurrentCell.RowIndex].Cells[0].Value.ToString());
            f.ShowDialog();
            loadTenantHistory(null);
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Form_LoadAll form_LoadAll = new Form_LoadAll();
            form_LoadAll.ShowDialog();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loadTenantHistory(guna2TextBox2.Text);
        }
        private void loadBill(string name)
        {
            DataTable data = BillBLL.BillBLL_load_Bill(form1.taikhoan.Username, name,listBuildingID.Text);
            dgv_thanhtoan.DataSource = data;
            dgv_thanhtoan.ScrollBars = ScrollBars.Both;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form_BillDetail form_BillDetail = new Form_BillDetail(dgv_thanhtoan.Rows[dgv_thanhtoan.CurrentCell.RowIndex].Cells[0].Value.ToString());
            form_BillDetail.ShowDialog();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void guna2GradientButton11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }
        

        private void button20_Click(object sender, EventArgs e)
        {
            string result = BillBLL.BillBLL_Del_Bill(
                dgv_thanhtoan.Rows[dgv_thanhtoan.CurrentCell.RowIndex].Cells[0].Value.ToString());
            MessageBox.Show(result);
            loadBill(null);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            Form_Payment form_Payment = new Form_Payment(listBuildingID.Text);
            form_Payment.ShowDialog();
            loadInfo();
        }

        
        private void listBuildingID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clearAllDataGridView();
            buildingKey.Text = data.Rows[listBuildingID.SelectedIndex][1].ToString();
            loadInfo();
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
        private void FilterAssets(string priceSort, string nameSort)
        {
            try
            {
                DataTable filteredData = AssetBLL.FilterAssets(form1.taikhoan.Username, priceSort, nameSort, listBuildingID.SelectedItem.ToString());

                dgv_QLCSVC.DataSource = null; 
                dgv_QLCSVC.DataSource = filteredData;

                dgv_QLCSVC.Columns["RoomID"].DisplayIndex = 0;
                dgv_QLCSVC.Columns["AssetID"].DisplayIndex = 1;
                dgv_QLCSVC.Columns["AssetName"].DisplayIndex = 2;
                dgv_QLCSVC.Columns["Price"].DisplayIndex = 3;
                dgv_QLCSVC.Columns["Status"].DisplayIndex = 4;
                dgv_QLCSVC.Columns["Use_Date"].DisplayIndex = 5;
                //load_Assets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            Form_AddAssets addAsset = new Form_AddAssets(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            if (addAsset.ShowDialog() == DialogResult.OK)
            {
                load_Assets();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (dgv_QLCSVC.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài sản cần sửa");
                return;
            }

            DataGridViewRow selectedRow = dgv_QLCSVC.SelectedRows[0];

            Assets selectedAsset = new Assets
            {
                RoomId = selectedRow.Cells["RoomID"].Value.ToString(),
                AssetId = selectedRow.Cells["AssetID"].Value.ToString(),
                AssetName = selectedRow.Cells["AssetName"].Value.ToString(),
                Price = selectedRow.Cells["Price"].Value?.ToString(),
                UseDate = selectedRow.Cells["Use_Date"].Value?.ToString(),
                Status = selectedRow.Cells["Status"].Value?.ToString()
            };
            Form_UpdateAssets updateAssets = new Form_UpdateAssets(form1.taikhoan.Username, selectedAsset, listBuildingID.SelectedItem.ToString());
            if (updateAssets.ShowDialog() == DialogResult.OK)
            {
                load_Assets();
            }
        }

        private void button21_Click(object sender, EventArgs e)
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

        private void button24_Click_1(object sender, EventArgs e)
        {
            Form_AssetsDetail assetsDetail = new Form_AssetsDetail(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            assetsDetail.Show();
        }

        private void button26_Click(object sender, EventArgs e)
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

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
            {
                checkBox22.Checked = false;
                checkBox19.Checked = false;
                FilterAssets("ASC", null);
            }
            else
            {
                FilterAssets(null, null);
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                checkBox23.Checked = false;
                checkBox19.Checked = false;
                FilterAssets("DESC", null);
            }
            else
            {
                FilterAssets(null, null);
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                checkBox23.Checked = false;
                checkBox22.Checked = false;
                FilterAssets(null, guna2TextBox1.Text.Trim());
            }
            else
            {
                FilterAssets(null, null);
            }
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

       


        private void FilterRoomByStatus()
        {
            try
            {
                // Tạo danh sách trạng thái được chọn
                List<string> selectedStatuses = new List<string>();

                if (DangO_chbox1.Checked) selectedStatuses.Add(DangO_chbox1.Text);
                if (DangTrong_chbox1.Checked) selectedStatuses.Add(DangTrong_chbox1.Text);
                if (DangKT_chbox1.Checked) selectedStatuses.Add(DangKT_chbox1.Text);
                if (DangCoc_chbox.Checked) selectedStatuses.Add(DangCoc_chbox.Text);
                if (SapHetHan_chbox.Checked) selectedStatuses.Add(SapHetHan_chbox.Text);
                if (DaQuaHan_chbox.Checked) selectedStatuses.Add(DaQuaHan_chbox.Text);
                if (DangNoTien_chbox.Checked) selectedStatuses.Add(DangNoTien_chbox.Text);

                // Chuyển danh sách thành chuỗi phân cách bằng dấu ;
                string statusFilter = string.Join("; ", selectedStatuses);


                // Lấy dữ liệu đã lọc
                DataTable filteredData = RoomBLL.FilterRoomByStatus(statusFilter, form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());

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
        private void DangO_chbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox1.Checked && DangTrong_chbox1.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang ở' vừa 'Đang trống'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangO_chbox1.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangTrong_chbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox1.Checked && DangO_chbox1.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang trống' vừa 'Đang ở'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangTrong_chbox1.Checked = false;
            }
            FilterRoomByStatus();
        }

        private void DangKT_chbox1_CheckedChanged(object sender, EventArgs e)
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
        private List<CheckBox> sortOptions = new List<CheckBox>();

        public string filet_Service = "Default";
       
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

        //Room
        private void button35_Click(object sender, EventArgs e)
        {
            Form_AddRoom addRoom = new Form_AddRoom(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            if (addRoom.ShowDialog() == DialogResult.OK)
            {
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
            Form_RentalHistory rentalHistory = new Form_RentalHistory(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
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




            dgv_thanhtoan.DataSource = dt;

            dgv_thanhtoan.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 120, 215); 
            dgv_thanhtoan.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_thanhtoan.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_thanhtoan.ColumnHeadersHeight = 40;

            if (dgv_thanhtoan.Columns.Count > 0)
            {
                dgv_thanhtoan.Columns[0].HeaderText = "Mã thanh toán";
                dgv_thanhtoan.Columns[1].HeaderText = "Mã hóa đơn";
                dgv_thanhtoan.Columns[2].HeaderText = "Phương thức";
                dgv_thanhtoan.Columns[3].HeaderText = "Số tiền";
                dgv_thanhtoan.Columns[4].HeaderText = "Thời gian";
                dgv_thanhtoan.Columns[3].DefaultCellStyle.Format = "N0";


            }

            dgv_thanhtoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_thanhtoan.Refresh();
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
        }
        private W_E_BLL figureBLL = new W_E_BLL();

        

        private void button56_Click(object sender, EventArgs e)
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
        //Thêm một comboBox để chọn ngôn ngữ
        private void loadInitLanguage()
        {
            string l = Language.GetCurrentLanguage();
            string[] listLanguage_string = Language.getListLanguage();
            listLanguage.Items.Add(l);
            foreach (string item in listLanguage_string)
            {
                if (item != l)
                {
                    listLanguage.Items.Add(item);
                }
            }
            listLanguage.SelectedItem = l;
        }
        private void loadLanguage()
        {

            string selectedLanguage = listLanguage.SelectedItem.ToString();
            Language.SetCurrentLanguage(selectedLanguage);
            foreach (KeyValuePair<string, string> kvp in Language.languages)
            {
                //Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
                switch (kvp.Key)
                {
                    case "Room_Management":
                        btn_phong.Text = kvp.Value;
                        break;
                    case "Contract_Management":
                        btn_hopdong.Text = kvp.Value;
                        break;
                    case "Payment_Management":
                        btn_taichinh.Text = kvp.Value;
                        break;
                    case "Service_Management":
                        btn_dichvu.Text = kvp.Value;
                        break;
                    case "Facility_Management":
                        btn_csvc.Text = kvp.Value;
                        break;
                    case "Parking_Management":
                        guna2Button1.Text = kvp.Value;
                        break;
                    case "room_list_management":
                        label14.Text = kvp.Value;
                        break;
                    case "text_room_list_management":
                        label7.Text = kvp.Value;
                        break;
                    case "edit":
                        button34.Text = kvp.Value;
                        button16.Text = kvp.Value;
                        button32.Text = kvp.Value;
                        button40.Text = kvp.Value;
                        button22.Text = kvp.Value;
                        guna2GradientButton5.Text = kvp.Value;
                        button53.Text = kvp.Value; 
                        break;

                    case "delete":
                        button11.Text = kvp.Value;
                        button31.Text = kvp.Value;
                        button15.Text = kvp.Value; 
                        button29.Text = kvp.Value;
                        guna2GradientButton6.Text = kvp.Value;
                        button52.Text = kvp.Value;
                        button21.Text = kvp.Value;
                        button20.Text = kvp.Value;
                        button39.Text = kvp.Value;
                        break;
                    case "view_rental_history":
                        button33.Text = kvp.Value;
                        break;
                    case "export_to_excel":
                        button36.Text = kvp.Value;
                        button26.Text = kvp.Value; 
                        button8.Text = kvp.Value;
                        guna2GradientButton7.Text = kvp.Value;
                        button9.Text = kvp.Value;
                        button41.Text = kvp.Value;
                        button17.Text = kvp.Value;
                        button37.Text = kvp.Value;
                        button50.Text = kvp.Value;
                        button57.Text = kvp.Value;
                        break;
                    case "occupied":
                        DangO_chbox1.Text = kvp.Value;
                        break;
                    case "vacant":
                        DangTrong_chbox1.Text = kvp.Value;
                        break;
                    case "reserved":
                        DangCoc_chbox.Text = kvp.Value;
                        break;
                    case "ending_soon":
                        DangKT_chbox1.Text = kvp.Value;
                        break;
                    case "contract_expiring_soon":
                        SapHetHan_chbox.Text = kvp.Value;
                        break;
                    case "contract_expired":
                        DaQuaHan_chbox.Text = kvp.Value;
                        break;
                    case "owing_money":
                        DangNoTien_chbox.Text = kvp.Value;
                        break;
                    case "building_add":
                        guna2Button3.Text = kvp.Value;
                        break;
                    case "building_change":
                        guna2Button2.Text = kvp.Value;
                        break;

                    case "taxpayer_information_management":
                        ttkt1.Text = kvp.Value;
                        ttkt2.Text = kvp.Value;
                        ttkt3.Text = kvp.Value;
                        ttkt4.Text = kvp.Value;
                        break;
                    case "contract_management":
                        hd1.Text = kvp.Value;
                        hd2.Text = kvp.Value;
                        hd3.Text = kvp.Value;
                        hd4.Text = kvp.Value;
                        break;
                    case "house_tax_history_management":
                        lstn1.Text = kvp.Value;
                        lstn2.Text = kvp.Value;
                        lstn3.Text = kvp.Value;
                        lstn4.Text = kvp.Value;
                        break;
                    case "residence_registration_management":
                        dklt1.Text = kvp.Value;
                        dklt2.Text = kvp.Value;
                        dklt3.Text = kvp.Value;
                        dklt4.Text = kvp.Value;
                        break;
                    case "all_contracts":
                        label8.Text = kvp.Value;
                        break;
                    case "created_contracts_list":
                        label6.Text = kvp.Value;
                        break;
                    case "contract_expiration_reminder":
                        guna2GradientButton12.Text = kvp.Value;
                        break;
                    case "within_term":
                        checkBox1.Text = kvp.Value;
                        break;
                    case "about_to_expire":
                        checkBox4.Text = kvp.Value;
                        break;
                    case "expired":
                        checkBox3.Text = kvp.Value;
                        break;
                    case "set_contract_template":
                        button42.Text = kvp.Value;
                        break;
                    case "search":
                        button_tk_contract.Text = kvp.Value;
                        guna2Button4.Text = kvp.Value;
                        timkiem_ttenant.Text = kvp.Value;
                        button_tk_dklt.Text = kvp.Value;
                        break;
                    case "rental_history_title":
                        label10.Text = kvp.Value;
                        break;
                    case "rental_history_description":
                        label9.Text = kvp.Value;
                        break;
                    case "view_all_tenants":
                        guna2GradientButton3.Text = kvp.Value;
                        break;
                    case "evaluation":
                        guna2GradientButton2.Text = kvp.Value;
                        break;
                    case "tenant_information_title":
                        label12.Text = kvp.Value;
                        break;
                    case "tenant_information_description":
                        label11.Text = kvp.Value;
                        break;
                    case "residence_registration_title":
                        label15.Text = kvp.Value;
                        break;
                    case "residence_registration_description":
                        label13.Text = kvp.Value;
                        break;

                    case "bill_information_title":
                        label17.Text = kvp.Value;
                        break;
                    case "bill_information_description":
                        label16.Text = kvp.Value;
                        break;
                    case "button_diennuoc":
                        guna2GradientButton1.Text = kvp.Value;
                        break;
                    case "button_xemchitiet":
                        button10.Text = kvp.Value;
                        button24.Text = kvp.Value;

                        break;
                    case "button_xemlstt":
                        button18.Text = kvp.Value;
                        break;
                    case "button_tbdenkhachthue":
                        button43.Text = kvp.Value;
                        break;
                    case "checkbox_dathu":
                        checkBox16.Text = kvp.Value;
                        break;
                    case "checkbox_chuathu":
                        checkBox15.Text = kvp.Value;
                        break;
                    case "checkbox_dangno":
                        checkBox13.Text = kvp.Value;
                        break;
                    case "checkbox_dahuy":
                        checkBox14.Text = kvp.Value;
                        break;
                    case "checkbox_loctheothang":
                        checkBox12.Text = kvp.Value;
                        break;

                    case "asset_information_title":
                        label19.Text = kvp.Value;
                        break;
                    case "asset_information_description":
                        label18.Text = kvp.Value;
                        break;
                    case "checkbox_tangdan":
                        checkBox22.Text = kvp.Value;
                        break;
                    case "checkbox_giamdan":
                        checkBox23.Text = kvp.Value;
                        break;
                    case "checkbox_theoten":
                        guna2HtmlLabel2.Text = kvp.Value;
                        guna2HtmlLabel3.Text = kvp.Value;
                        guna2HtmlLabel4.Text = kvp.Value;
                        guna2HtmlLabel1.Text = kvp.Value;
                        checkBox19.Text = kvp.Value;
                        break;
                    case "service_management_title":
                        label21.Text = kvp.Value;
                        break;
                    case "service_management_description":
                        label20.Text = kvp.Value;
                        break;
                    case "view_service":
                        btn_xemdichvu.Text = kvp.Value;
                        break;
                    case "filter_highlow":
                        checkBox_DV1.Text = kvp.Value;
                        break;
                    case "filter_lowhigh":
                        checkBox_DV2.Text = kvp.Value;
                        break;

                    case "filter_recent":
                        checkBox_DV3.Text = kvp.Value;
                        break;
                    case "filter_oldest":
                        checkBox_DV4.Text = kvp.Value;
                        break;
                    case "filter_az":
                        checkBox_DV5.Text = kvp.Value;
                        break;
                    case "filter_by_month":
                        checkBox9.Text = kvp.Value;
                        break;
                    case "action_editdelete":
                        button45.Text = kvp.Value;
                        break;
                    case "action_registCancel":
                        button49.Text = kvp.Value;
                        break;

                    case "parking_management_title":
                        label25.Text = kvp.Value;
                        label23.Text = kvp.Value;
                        break;
                    case "parking_list_title":
                        label22.Text = kvp.Value;
                        label24.Text = kvp.Value;

                        break;
                    case "parking_lot_label":
                        guna2GradientButton9.Text = kvp.Value;
                        guna2GradientButton11.Text = kvp.Value;
                        break;
                    case "vehicle_label":
                        guna2GradientButton8.Text = kvp.Value;
                        guna2GradientButton10.Text = kvp.Value;
                        break;

                    case "roomtable_room_id":
                        dgv_QLP.Columns["RoomID"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_building":
                        dgv_QLP.Columns["BuildingID"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_floor":
                        dgv_QLP.Columns["Floor"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_room_type":
                        dgv_QLP.Columns["Type"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_convenient":
                        dgv_QLP.Columns["Convenient"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_area":
                        dgv_QLP.Columns["Area"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_price":
                        dgv_QLP.Columns["Price"].HeaderText = kvp.Value;
                        break;
                    case "roomtable_status":
                        dgv_QLP.Columns["Status"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_contract_id":
                        dgv_QLHD.Columns["CONTRACTID"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_room_id":
                        dgv_QLHD.Columns["ROOMID"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_tenant_id":
                        dgv_QLHD.Columns["TENANTID"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_first_name":
                        dgv_QLHD.Columns["FIRSTNAME"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_last_name":
                        dgv_QLHD.Columns["LASTNAME"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_create_date":
                        dgv_QLHD.Columns["CREATEDATE"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_start_date":
                        dgv_QLHD.Columns["STARTDATE"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_end_date":
                        dgv_QLHD.Columns["ENDDATE"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_monthly_rent":
                        dgv_QLHD.Columns["MONTHLYRENT"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_payments":
                        dgv_QLHD.Columns["PAYMENTSCHEDULE"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_deposit":
                        dgv_QLHD.Columns["DEPOSIT"].HeaderText = kvp.Value;
                        break;
                    case "contracttable_notes":
                        dgv_QLHD.Columns["NOTES"].HeaderText = kvp.Value;
                        break;

                    case "lstntable_historyid":
                        dgv_LSTN.Columns["HISTORYID"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_contractid":
                        dgv_LSTN.Columns["CONTRACTID"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_tenantid":
                        dgv_LSTN.Columns["TENANTID"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_firstname":
                        dgv_LSTN.Columns["FIRSTNAME"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_lastname":
                        dgv_LSTN.Columns["LASTNAME"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_startdate":
                        dgv_LSTN.Columns["STARTDATE"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_enddate":
                        dgv_LSTN.Columns["ENDDATE"].HeaderText = kvp.Value;
                        break;
                    case "lstntable_note":
                        dgv_LSTN.Columns["NOTES"].HeaderText = kvp.Value;
                        break;

                    case "tenanttable_tenantid":
                        dgv_Tenant.Columns["TENANTID"].HeaderText = kvp.Value;
                        break;
                    case "tenanttable_firstname":
                        dgv_Tenant.Columns["FIRSTNAME"].HeaderText = kvp.Value;
                        break;
                    case "tenanttable_lastname":
                        dgv_Tenant.Columns["LASTNAME"].HeaderText = kvp.Value;
                        break;
                    case "tenanttable_birthday":
                        dgv_Tenant.Columns["BIRTHDAY"].HeaderText = kvp.Value;
                        break;
                    case "tenanttable_gender":
                        dgv_Tenant.Columns["GENDER"].HeaderText = kvp.Value;
                        break;
                    case "tenanttable_numberphone":
                        dgv_Tenant.Columns["PHONENUMBER"].HeaderText = kvp.Value;
                        break;
                    case "tenanttable_email":
                        dgv_Tenant.Columns["EMAIL"].HeaderText = kvp.Value;
                        break;

                    case "registrationtable_registrationid":
                        dgv_DKLT.Columns["REGISTRATIONID"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_roomid":
                        dgv_DKLT.Columns["ROOMID"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_tenantid":
                         dgv_DKLT.Columns["TENANTID"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_firstname":
                         dgv_DKLT.Columns["FIRSTNAME"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_lastname":
                         dgv_DKLT.Columns["LASTNAME"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_registrationdate":
                         dgv_DKLT.Columns["REGISTRATION_DATE"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_expirationdate":
                         dgv_DKLT.Columns["EXPIRATION_DATE"].HeaderText = kvp.Value;
                        break;
                    case "registrationtable_status":
                         dgv_DKLT.Columns["STATUS"].HeaderText = kvp.Value;
                        break;
                    case "billtable_billid":
                        dgv_thanhtoan.Columns["BILLID"].HeaderText = kvp.Value;
                        break;
                    case "billtable_tenantid":
                        dgv_thanhtoan.Columns["TENANTID"].HeaderText = kvp.Value;
                        break;
                    case "billtable_fisrtname":
                        dgv_thanhtoan.Columns["FIRSTNAME"].HeaderText = kvp.Value;
                        break;
                    case "billtable_lastname":
                        dgv_thanhtoan.Columns["LASTNAME"].HeaderText = kvp.Value;
                        break;
                    case "billtable_total":
                        dgv_thanhtoan.Columns["TOTAL"].HeaderText = kvp.Value;
                        break;
                    case "billtable_startdate":
                        dgv_thanhtoan.Columns["START_DATE"].HeaderText = kvp.Value;
                        break;
                    case "billtable_enddate":
                        dgv_thanhtoan.Columns["END_DATE"].HeaderText = kvp.Value;
                        break;
                    case "billtable_coalesce":
                        dgv_thanhtoan.Columns["TOTALS"].HeaderText = kvp.Value;
                        break;
                        //dgvServiceInfo.Columns["STT"].HeaderText = "STT";
                        //dgvServiceInfo.Columns["RoomID"].HeaderText = "Mã phòng";
                        //dgvServiceInfo.Columns["TenantName"].HeaderText = "Tên người thuê";
                        //dgvServiceInfo.Columns["ServiceName"].HeaderText = "Tên dịch vụ";
                        //dgvServiceInfo.Columns["ServicePrice"].HeaderText = "Giá dịch vụ";
                        //dgvServiceInfo.Columns["StartedDay"].HeaderText = "Ngày bắt đầu";
                        //dgvServiceInfo.Columns["EndDay"].HeaderText = "Ngày kết thúc";
                    case "servicetable_ordernumber":
                        //dgvServiceInfo.Columns["STT"].HeaderText = "STT";
                        break;
                    case "servicetable_roomid":
                        //dgvServiceInfo.Columns["RoomID"].HeaderText = kvp.Value;
                        break;
                    case "servicetable_tenantname":
                        //dgvServiceInfo.Columns[2].HeaderText = kvp.Value;
                        break;
                    case "servicetable_servicename":
                        //dgvServiceInfo.Columns[3].HeaderText = kvp.Value;
                        break;
                    case "servicetable_serviceprice":
                        //dgvServiceInfo.Columns[4].HeaderText = kvp.Value;
                        break;
                    case "servicetable_startdate":
                        //dgvServiceInfo.Columns[5].HeaderText = kvp.Value;
                        break;
                    case "servicetable_enddate":
                        //dgvServiceInfo.Columns[6].HeaderText = kvp.Value;
                        break;

                    case "assettable_assetid":
                        dgv_QLCSVC.Columns["ASSETID"].HeaderText = kvp.Value;
                        break;
                    case "assettable_roomid":
                        dgv_QLCSVC.Columns["ROOMID"].HeaderText = kvp.Value;
                        break;
                    case "assettable_assetname":
                        dgv_QLCSVC.Columns["ASSETNAME"].HeaderText = kvp.Value;
                        break;
                    case "assettable_price":
                        dgv_QLCSVC.Columns["PRICE"].HeaderText = kvp.Value;
                        break;
                    case "assettable_status":
                        dgv_QLCSVC.Columns["STATUS"].HeaderText = kvp.Value;
                        break;
                    case "assettable_usedate":
                        dgv_QLCSVC.Columns["USE_DATE"].HeaderText = kvp.Value;
                        break;
                }
            }
        }



        private void listLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadLanguage();
        }
    }
}
