using BLL;
using BLL.BLL_Service;
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
using DTO.dto_service;
using BLL.bll_service;
using DTO.DTO_Service;
using GUI.gui_service;
using System.Security.Policy;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using GUI.honhathao.languages;
using GUI.Custom;

namespace GUI
{
    public partial class quanlynha : Form
    {
        Form_Login form1;
        private int index;
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
        private Point location_component_quanlytaichinh_1 = new Point(30, 30);
        DataTable datakey = null;

        public quanlynha(Form_Login form1, int index)
        {
            InitializeComponent();

            //ẩn thanh Tab 
            tabQuanLy.SizeMode = TabSizeMode.Fixed;
            tabQuanLy.ItemSize = new Size(0, 1);
            tabQuanLy.Appearance = TabAppearance.FlatButtons;
            tabQuanLy.Region = new Region(new RectangleF(0, 1, tabQuanLy.Width, tabQuanLy.Height - 1));

            setStartPositon();
            this.form1 = form1;
            this.index = index;
            load_Building_By_User();
            loadInitLanguage();
            loadInfo();
            loadLanguage();

        }

        private void loadInfo()
        {
            load_QLP();
            load_PA();
            load_Contract(0, null);
            load_Assets();
            loadTenant(null);
            addTenantHistory();
            loadTenantHistory(null);
            loadRegistration(null);
            loadBill(null, "0");

            LoadDichVu();
            load_Vehicle();
            update_LSTN();
        }

        private void clearAllDataGridView()
        {
            try
            {
                dgv_QLP.DataSource = null;
                dgv_QLHD.DataSource = null;
                dgv_QLCSVC.DataSource = null;
                dgv_Tenant.DataSource = null;
                dgv_LSTN.DataSource = null;
                dgv_DKLT.DataSource = null;
                load_Vehicle();
                load_PA();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadTenant(string name)
        {
            try
            {
                DataTable data = TenantBLL.TenantBLL_load_Tenant(listBuildingID.Text, name);
                if (dgv_Tenant.Rows.Count == 0)
                {
                    button31.Enabled = false;
                    button34.Enabled = false;
                    button37.Enabled = false;
                }
                else
                {
                    button31.Enabled = true;
                    button34.Enabled = true;
                    button37.Enabled = true;
                }
                data.Columns.RemoveAt(0);
                dgv_Tenant.DataSource = data;
                dgv_Tenant.Columns[0].Width = 90;
                dgv_Tenant.Columns[1].Width = 150;
                dgv_Tenant.Columns[2].Width = 100;
                dgv_Tenant.Columns[3].Width = 80;
                dgv_Tenant.Columns[4].Width = 100;
                dgv_Tenant.Columns[5].Width = 200;
                dgv_Tenant.Columns[6].Width = 300;
                dgv_Tenant.ScrollBars = ScrollBars.Both;

                translateValue(dgv_Tenant, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void loadTenantHistory(string name)
        {
            try
            {

                DataTable data = TenantHistoryBLL.TenantHistoryBLL_load_Tenant(listBuildingID.Text, name);
                dgv_LSTN.DataSource = data;
                if (dgv_LSTN.Rows.Count == 0)
                {
                    guna2GradientButton2.Enabled = false;
                    button9.Enabled = false;

                }
                else
                {
                    guna2GradientButton2.Enabled = true;
                    button9.Enabled = true;
                }

                dgv_LSTN.Columns[0].Width = 90;
                dgv_LSTN.Columns[1].Width = 150;
                dgv_LSTN.Columns[2].Width = 100;
                dgv_LSTN.Columns[3].Width = 80;
                dgv_LSTN.Columns[4].Width = 100;
                dgv_LSTN.Columns[5].Width = 200;
                dgv_LSTN.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        private void loadRegistration(string name)
        {
            try
            {

                DataTable data = RegistrationBLL.RegistrationBLL_load_registration(listBuildingID.Text, name);
                
                dgv_DKLT.DataSource = data;
                if (dgv_DKLT.Rows.Count == 0)
                {
                    button15.Enabled = false;
                    button16.Enabled = false;
                    button17.Enabled = false;

                }
                else
                {
                    button15.Enabled = true;
                    button16.Enabled = true;
                    button17.Enabled = true;
                }
                dgv_DKLT.Columns[0].Width = 90;
                dgv_DKLT.Columns[1].Width = 150;
                dgv_DKLT.Columns[2].Width = 100;
                dgv_DKLT.Columns[3].Width = 80;
                dgv_DKLT.Columns[4].Width = 100;
                dgv_DKLT.Columns[5].Width = 200;
                dgv_DKLT.ScrollBars = ScrollBars.Both;
                translateValue(dgv_DKLT, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_Contract(int control, string name)
        {
            try
            {
                dgv_QLHD.DataSource = ContractBLL.ContractBLL_load_Contract_filter(listBuildingID.Text, control, name);
                if (dgv_QLHD.Rows.Count == 0)
                {
                    button40.Enabled = false;
                    button41.Enabled = false;
                    button39.Enabled = false;
                    guna2GradientButton12.Enabled = false;

                }
                else
                {
                    button40.Enabled = true;
                    button41.Enabled = true;
                    button39.Enabled = true;
                    guna2GradientButton12.Enabled = true;
                    
                }

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
                dgv_QLHD.Columns[10].DefaultCellStyle.Format = "0";
                dgv_QLHD.ScrollBars = ScrollBars.Both;
                translateValue(dgv_QLHD, 9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void translateValue(DataGridView table, int column)
        {
            foreach (DataGridViewRow row in table.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[column].Value = Language.translate(row.Cells[column].Value.ToString());
                }
            }
        }
        private void load_Assets()
        {
            try
            {

                string priceSort = checkBox23.Checked ? "ASC" : null
                                 + (checkBox22.Checked ? "DESC" : null);
                string nameSort = checkBox19.Checked ? guna2TextBox1.Text : null;
                dgv_QLCSVC.DataSource = AssetBLL.FilterAssets(form1.taikhoan.Username, priceSort, nameSort, listBuildingID.Text);

                if (dgv_QLCSVC.Rows.Count == 0)
                {
                    button22.Enabled = false;
                    button21.Enabled = false;
                    button24.Enabled = false;
                    button26.Enabled = false;
                }
                else
                {
                    button22.Enabled = true;
                    button21.Enabled = true;
                    button24.Enabled = true;
                    button26.Enabled = true;
                }


                dgv_QLCSVC.Columns[0].Width = 90;
                dgv_QLCSVC.Columns[1].Width = 90;
                dgv_QLCSVC.Columns[2].Width = 150;
                dgv_QLCSVC.Columns[3].Width = 100;
                dgv_QLCSVC.Columns[4].Width = 120;
                dgv_QLCSVC.Columns[5].Width = 80;


                translateValue(dgv_QLCSVC, 4);
                dgv_QLCSVC.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_QLP()
        {
            try
            {
                string status = (DangO_chbox1.Checked ? Language.reverseTranslate(DangO_chbox1.Text) + "; " : "")
                              + (DangTrong_chbox1.Checked ? Language.reverseTranslate(DangTrong_chbox1.Text) + "; " : "")
                              + (DangKT_chbox1.Checked ? Language.reverseTranslate(DangKT_chbox1.Text) + "; " : "")
                              + (DangCoc_chbox.Checked ? Language.reverseTranslate(DangCoc_chbox.Text) + "; " : "")
                              + (DaQuaHan_chbox.Checked ? Language.reverseTranslate(DaQuaHan_chbox.Text) + "; " : "")
                              + (SapHetHan_chbox.Checked ? Language.reverseTranslate(SapHetHan_chbox.Text) + "; " : "")
                              + (DangNoTien_chbox.Checked ? Language.reverseTranslate(DangNoTien_chbox.Text) + "" : "");
                status = status.TrimEnd(';', ' ');


                dgv_QLP.DataSource = RoomBLL.FilterRoomByStatus(status, form1.taikhoan.Username, listBuildingID.Text);

                if (dgv_QLP.Rows.Count == 0)
                {
                    button32.Enabled = false;
                    button29.Enabled = false;
                    button33.Enabled = false;
                    button36.Enabled = false;
                }
                else
                {
                    button32.Enabled = true;
                    button29.Enabled = true;
                    button33.Enabled = true;
                    button36.Enabled = true;
                }

                dgv_QLP.Columns[0].Width = 90;
                dgv_QLP.Columns[1].Width = 90;
                dgv_QLP.Columns[2].Width = 150;
                dgv_QLP.Columns[3].Width = 70;
                dgv_QLP.Columns[4].Width = 200;
                dgv_QLP.Columns[5].Width = 120;
                dgv_QLP.Columns[6].Width = 150;
                dgv_QLP.Columns[7].Width = 250;
                dgv_QLP.ScrollBars = ScrollBars.Both;

                foreach (DataGridViewRow row in dgv_QLP.Rows)
                {
                    if (!row.IsNewRow)
                    {


                        string[] status1 = row.Cells[7].Value.ToString().Split(';');
                        for (int i = 0; i < status1.Length; i++)
                        {
                            status1[i] = Language.translate(status1[i].Trim());
                        }
                        row.Cells[7].Value = string.Join(";", status1);

                    }
                }
                translateValue(dgv_QLP, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_PA()
        {
            try
            {
                if (listBuildingID.SelectedItem == null)
                {
                    MessageBox.Show(Language.translate("asking"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string type = checkBox10.Checked ? "xeoto" :
                             (checkBox11.Checked ? "xemay/xedap" :
                             (checkBox18.Checked ? "honhop" : null));
                string status = checkBox17.Checked ? "empty" : (checkBox20.Checked ? "full" : null);

                guna2DataGridView7.DataSource = ParkingAreaBLL.FilterParkingArea(listBuildingID.Text, type, status);

                if (guna2DataGridView7.Rows.Count == 0)
                {
                    button53.Enabled = false;
                    button52.Enabled = false;
                    button57.Enabled = false;
                }
                else
                {
                    button53.Enabled = true;
                    button52.Enabled = true;
                    button57.Enabled = true;
                }

                guna2DataGridView7.Columns[0].Width = 90;
                guna2DataGridView7.Columns[1].Width = 90;
                guna2DataGridView7.Columns[2].Width = 150;
                guna2DataGridView7.Columns[3].Width = 100;
                guna2DataGridView7.Columns[4].Width = 100;
                guna2DataGridView7.Columns[5].Width = 90;
                guna2DataGridView7.Columns[6].Width = 120;
                guna2DataGridView7.ScrollBars = ScrollBars.Both;

                translateValue(guna2DataGridView7, 3);
                translateValue(guna2DataGridView7, 6);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_Vehicle()
        {
            try
            {
                string type = checkBox2.Checked ? "xeoto" :
                              checkBox5.Checked ? "xemay" :
                              (checkBox7.Checked ? "xedap" : null);

                guna2DataGridView1.DataSource = VehicleBLL.FilterVehicle(listBuildingID.Text, type);
                this.guna2DataGridView1.AllowUserToAddRows = false;

                if (guna2DataGridView1.Rows.Count == 0)
                {
                    guna2GradientButton5.Enabled = false;
                    guna2GradientButton6.Enabled = false;
                    guna2GradientButton7.Enabled = false;
                }
                else
                {
                    guna2GradientButton5.Enabled = true;
                    guna2GradientButton6.Enabled = true;
                    guna2GradientButton7.Enabled = true;
                }

                guna2DataGridView1.Columns[0].Width = 90;
                guna2DataGridView1.Columns[1].Width = 90;
                guna2DataGridView1.Columns[2].Width = 180;
                guna2DataGridView1.Columns[3].Width = 90;
                guna2DataGridView1.Columns[4].Width = 150;
                guna2DataGridView1.Columns[5].Width = 150;
                guna2DataGridView1.Columns[6].Width = 120;
                guna2DataGridView1.Columns[7].Width = 200;
                guna2DataGridView1.ScrollBars = ScrollBars.Both;

                translateValue(guna2DataGridView1, 6);
                translateValue(guna2DataGridView1, 9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDichVu()
        {
            try
            {
                var data = serviceUsageBLL.GetServiceUsage(filet_Service, listBuildingID.Text);

                if(dgv_QLHD.Rows.Count == 0)
                {
                    button49.Enabled = false;
                }
                dgvServiceInfo.DataSource = data;
                if (dgvServiceInfo.Rows.Count == 0)
                {
                    button45.Enabled = false;  
                    button50.Enabled = false;
                    //btn_xemdichvu.Enabled = false;

                }
                else
                {
                    button45.Enabled = true;
                    button49.Enabled = true;
                    button50.Enabled = true;
                    btn_xemdichvu.Enabled = true;

                }
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            //tabQuanLy.Size = size_tabQL;

            dklt444.Location = tabHD;
            //dklt4.Size = size_tabHD;

            tabControl1.Location = tabHD;
            //tabControl1.Size = size_tabHD;
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            form1.Close();
            Application.Exit();
        }




        public GetAllServiceBLL getAllServiceBLL = new GetAllServiceBLL();
        //Code sửa từ function đã có
        public void btn_dichvu_Click(object sender, EventArgs e)
        {
            checkBox9.Visible = false;
            guna2DateTimePicker2.Visible = false;
            dgvServiceInfo.Columns["ServicePrice"].DefaultCellStyle.Format = "N0";
            dgvServiceInfo.Columns["ServicePrice"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
            dgvServiceInfo.Columns["ServicePrice"].DefaultCellStyle.Format = "#,##0 VND";
            tabQuanLy.SelectedIndex = 4;
            LoadDichVu();
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

                if (string.IsNullOrEmpty(recipientEmail))
                    continue;

                // Tạo nội dung HTML email
                string htmlBody = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        body {{ 
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333333;
            margin: 0;
            padding: 0;
        }}
        .container {{
            max-width: 600px;
            margin: 0 auto;
        }}
        .header {{
            background-color: #4361EE;
            color: white;
            padding: 20px;
            text-align: center;
        }}
        .header h1 {{
            margin: 0;
            font-size: 24px;
            font-weight: normal;
        }}
        .content {{
            padding: 20px;
            background-color: #ffffff;
        }}
        .greeting {{
            font-size: 18px;
            color: #333;
            margin-bottom: 15px;
        }}
        .message {{
            color: #333;
            margin-bottom: 20px;
        }}
        .warning-box {{
            background-color: #fff7e6;
            border-left: 4px solid #ff9800;
            padding: 15px;
            margin: 15px 0;
        }}
        .action-button {{
            display: inline-block;
            background-color: #4361EE;
            color: white;
            text-decoration: none;
            padding: 10px 20px;
            border-radius: 4px;
            margin: 15px 0;
        }}
        .footer {{
            background-color: #f2f2f2;
            padding: 15px;
            text-align: center;
            font-size: 14px;
            color: #666;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1> Từ RentEase</h1>
        </div>
        <div class='content'>
            <div class='greeting'>Kính gửi Quý khách,</div>
            
            <div class='message'>
                Hệ thống RentEase xin  rằng hợp đồng thuê nhà của bạn sắp hết hạn trong vài ngày tới.
            </div>

            <div class='warning-box'>
                <strong>Lưu ý:</strong> Để đảm bảo quyền lợi sử dụng liên tục, bạn vui lòng liên hệ với chủ nhà để thực hiện gia hạn hợp đồng càng sớm càng tốt.
            </div>

            <p>Nếu bạn đã liên hệ với chủ nhà hoặc có kế hoạch chấm dứt hợp đồng, vui lòng bỏ qua  này.</p>
            
            <p>Xin chân thành cảm ơn bạn đã sử dụng dịch vụ của chúng tôi.</p>
        </div>
        <div class='footer'>
            <p>© 2023 RentEase - Phần mềm quản lý nhà cho thuê chuyên nghiệp</p>
            <p>Đây là email tự động, vui lòng không trả lời email này.</p>
        </div>
    </div>
</body>
</html>";

                EmailDTO email = new EmailDTO
                {
                    From = "nhuthuyhk9@gmail.com",
                    Password = "gdjq astk ezog zdjz",
                    To = recipientEmail,
                    Subject = ": Hợp đồng thuê nhà sắp hết hạn",
                    Body = htmlBody
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
                MessageBox.Show(Language.translate("success_"));
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"));
            }
        }
        private void btn_vantay_Click(object sender, EventArgs e)
        {
            FingerprintManagementForm fingerprintForm = new FingerprintManagementForm(
                form1.taikhoan.Username,
                listBuildingID.SelectedItem.ToString()
            );
            //fingerprintForm.ShowDialog();
            OverlayManager.ShowWithOverlay(this, fingerprintForm);
        }


        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            Form_W_E form_W_E = new Form_W_E(form1.taikhoan.Username, listBuildingID.Text);

            OverlayManager.ShowWithOverlay(this, form_W_E);

            string result = BillBLL.BillBLL_calculate_bill();
            loadBill(null,"0");
        }


        

        private void addTenantHistory()
        {
            DataTable tmp = TenantHistoryBLL.TenantHistoryBLL_count_TenantHistory(listBuildingID.Text);

            if (tmp != null)
            {
                for (int i = 0; i < tmp.Rows.Count; i++)
                {
                    TenantHistoryBLL.TenantHistoryBLL_auto_AddTenantHistory(
                        tmp.Rows[i][0].ToString(),
                        tmp.Rows[i][2].ToString(),
                        tmp.Rows[i][1].ToString(),
                        tmp.Rows[i][4].ToString(),
                        tmp.Rows[i][5].ToString(),
                        listBuildingID.Text);
                }
            }
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {

            BotChat b = new BotChat(form1.taikhoan.Username);
            //b.Show();
            OverlayManager.ShowWithOverlay(this, b);

        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            Form_TenantHistory f = new Form_TenantHistory(dgv_LSTN.Rows[dgv_LSTN.CurrentCell.RowIndex].Cells[0].Value.ToString());
            //f.ShowDialog();
            OverlayManager.ShowWithOverlay(this, f);

            loadTenantHistory(null);
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Form_LoadAll form_LoadAll = new Form_LoadAll();
            //form_LoadAll.ShowDialog();
            OverlayManager.ShowWithOverlay(this, form_LoadAll);

        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loadTenantHistory(guna2TextBox2.Text);
        }
        private void loadBill(string name,string control)
        {
            try
            {
                
                DataTable data = BillBLL.BillBLL_load_Bill(form1.taikhoan.Username, name, listBuildingID.Text, control);
                dgv_thanhtoan.DataSource = data;
                if (dgv_thanhtoan.Rows.Count == 0)
                {
                    button20.Enabled = false;
                    button10.Enabled = false;
                    button18.Enabled = false;
                    button8.Enabled = false;
                }
                else
                {
                    button20.Enabled = true;
                    button10.Enabled = true;
                    button18.Enabled = true;
                    button8.Enabled = true;
                }
                dgv_thanhtoan.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try {
                Form_BillDetail form_BillDetail = new Form_BillDetail(dgv_thanhtoan.Rows[dgv_thanhtoan.CurrentCell.RowIndex].Cells[0].Value.ToString());
                //form_BillDetail.ShowDialog();
                OverlayManager.ShowWithOverlay(this, form_BillDetail);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            try
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                string resultq = BillBLL.BillBLL_Del_Bill(
                dgv_thanhtoan.Rows[dgv_thanhtoan.CurrentCell.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(resultq);
                loadBill(null, "0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            Form_Payment form_Payment = new Form_Payment(listBuildingID.Text);
            //form_Payment.ShowDialog();
            OverlayManager.ShowWithOverlay(this, form_Payment);

        }


        private void listBuildingID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clearAllDataGridView();
            buildingKey.Text = datakey.Rows[listBuildingID.SelectedIndex][1].ToString();
            loadInfo();
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
            dklt444.SelectedIndex = 0;
        }
        private void hd2_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 0;

        }
        private void hd3_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 0;

        }
        private void hd4_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 0;

        }
        private void lstn1_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 1;

        }
        private void lstn2_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 1;

        }
        private void lstn3_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 1;

        }
        private void lstn4_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 1;

        }
        private void ttkt1_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 2;

        }
        private void ttkt2_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 2;

        }
        private void ttkt3_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 2;

        }
        private void ttkt4_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 2;

        }
        private void dklt1_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 3;

        }
        private void dklt2_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 3;

        }
        private void dklt3_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 3;

        }
        private void dklt4_Click(object sender, EventArgs e)
        {
            dklt444.SelectedIndex = 3;

        }
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(dgv_DKLT.SelectedRows[0].Cells[0].Value.ToString());
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    RegistrationBLL.RegistrationBLL_del_registration(dgv_DKLT.SelectedRows[0].Cells[0].Value.ToString());
                    MessageBox.Show("Xóa thành công");
                    loadInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    TenantBLL.TenantBLL_del_Tenant(dgv_Tenant.SelectedRows[0].Cells[0].Value.ToString());
                    MessageBox.Show("Xóa thành công");
                    //loadTenant(null);
                }
                loadInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
            {
                checkBox22.Checked = false;
                checkBox19.Checked = false;
            }
            load_Assets();
        }
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                checkBox23.Checked = false;
                checkBox19.Checked = false;
            }
            load_Assets();
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                checkBox23.Checked = false;
                checkBox22.Checked = false;
            }
            load_Assets();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.Rows.Count == 0) {
                MessageBox.Show(Language.translate("nonData") + " -> " + Language.translate("Room_Management"));
                return;
            }
            if (dgv_Tenant.Rows.Count == 0) {
                MessageBox.Show(Language.translate("nonData") + " -> " + Language.translate("tenant_information_title"));
                return;
            }
            if (dgv_QLHD.Rows.Count == 0)
            {
                MessageBox.Show(Language.translate("nonData") + " -> " + Language.translate("contract_management"));
                return;
            }
            Form_Registration f = new Form_Registration(1, listBuildingID.Text, 0, dgv_DKLT, dgv_Tenant);

            OverlayManager.ShowWithOverlay(this, f);

            loadInfo();
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

                    OverlayManager.ShowWithOverlay(this, f);

                    loadInfo();
                }
                else
                {
                    MessageBox.Show(Language.translate("asking"), "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
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
            Form_Tenant f = new Form_Tenant(data, 0, form1.taikhoan.Username,listBuildingID.Text);
            //f.ShowDialog();
            OverlayManager.ShowWithOverlay(this, f);
            loadInfo();
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            Form_AddAssets addAsset = new Form_AddAssets(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());

            OverlayManager.ShowWithOverlay(this, addAsset);

            if (addAsset.DialogResult == DialogResult.OK)
            {
                load_Assets();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (dgv_QLCSVC.SelectedRows.Count == 0)
            {
                MessageBox.Show(Language.translate("asking"));
                return;
            }

            DataGridViewRow selectedRow = dgv_QLCSVC.SelectedRows[0];

            Assets selectedAsset = new Assets
            {
                RoomId = selectedRow.Cells["ROOMNAME"].Value.ToString(),
                AssetId = selectedRow.Cells["AssetID"].Value.ToString(),
                AssetName = selectedRow.Cells["AssetName"].Value.ToString(),
                Price = selectedRow.Cells["Price"].Value?.ToString(),
                UseDate = selectedRow.Cells["Use_Date"].Value?.ToString(),
                Status = selectedRow.Cells["Status"].Value?.ToString()
            };
            Form_UpdateAssets updateAssets = new Form_UpdateAssets(form1.taikhoan.Username, selectedAsset, listBuildingID.Text);

            OverlayManager.ShowWithOverlay(this, updateAssets);
            if (updateAssets.DialogResult == DialogResult.OK)
            {
                load_Assets();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgv_QLCSVC.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dgv_QLCSVC.Rows[row];
                Console.WriteLine(selectedRow.Cells[0].Value.ToString());
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = AssetBLL.DeleteAssets(dgv_QLCSVC.SelectedRows[0].Cells["AssetID"].Value.ToString());

                    MessageBox.Show(message,
                                    success ? "" : "Lỗi",
                                    MessageBoxButtons.OK,
                                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (success)
                    {
                        loadInfo();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            Form_AssetsDetail assetsDetail = new Form_AssetsDetail(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            //assetsDetail.Show();
            OverlayManager.ShowWithOverlay(this, assetsDetail);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (dgv_QLCSVC.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_QLCSVC, "Danh sách tài sản");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgv_Tenant.CurrentCell.RowIndex;
                DataGridViewRow data = dgv_Tenant.Rows[row];
                Form_Tenant f = new Form_Tenant(data, 1, form1.taikhoan.Username, listBuildingID.Text);
                //f.ShowDialog();
                OverlayManager.ShowWithOverlay(this, f);

                loadInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Form_AddContract f = new Form_AddContract(form1.taikhoan.Username, 0, 1, listBuildingID.Text, dgv_QLHD, dgv_Tenant);
            //f.ShowDialog();
            OverlayManager.ShowWithOverlay(this, f);

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

                    OverlayManager.ShowWithOverlay(this, f);
                    //f.ShowDialog();
                    load_Contract(0, timkiem_contract.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
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
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(ContractBLL.ContractBLL_delete_Contract(selectedRow.Cells[0].Value.ToString()));
                }
                load_Contract(0, timkiem_contract.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        // New HoaiAn 14/4
        private void DangO_chbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox1.Checked)
            {
                DangTrong_chbox1.Checked = false;
            }
            load_QLP();
        }
        // New HoaiAn 14/4
        private void DangTrong_chbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox1.Checked)
            {
                DangO_chbox1.Checked = false;
            }
            load_QLP();
        }
        // New HoaiAn 14/4
        private void DangKT_chbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DangKT_chbox1.Checked)
            {
                DangCoc_chbox.Checked = false;
            }
            load_QLP();
        }
        // New HoaiAn 14/4
        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangCoc_chbox.Checked)
            {
                DangKT_chbox1.Checked = false;
            }
            load_QLP();
        }
        // New HoaiAn 14/4
        private void SapHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SapHetHan_chbox.Checked)
            {
                DaQuaHan_chbox.Checked = false;
            }
            load_QLP();
        }
        // New HoaiAn 14/4
        private void DaQuaHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DaQuaHan_chbox.Checked)
            {
                SapHetHan_chbox.Checked = false;
            }
            load_QLP();
        }

        private void DangNoTien_chbox_CheckedChanged(object sender, EventArgs e)
        {
            load_QLP();
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

        }

        private void button35_Click(object sender, EventArgs e)
        {
            Form_AddRoom addRoom = new Form_AddRoom(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());

            OverlayManager.ShowWithOverlay(this, addRoom);//hiệu ứng mờ

            if (addRoom.DialogResult == DialogResult.OK)
            {
                load_QLP();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.SelectedRows.Count == 0)
            {
                MessageBox.Show(Language.translate("asking"));
                return;
            }
            DataGridViewRow selectedRow = dgv_QLP.SelectedRows[0];

            Room selectedRoom = new Room
            {
                RoomId = selectedRow.Cells["RoomName"].Value.ToString(),
                BuildingId = selectedRow.Cells["BuildingID"].Value.ToString(),
                Type = selectedRow.Cells["Type"].Value?.ToString(),
                Floor = selectedRow.Cells["Floor"].Value?.ToString(),

                Convenient = selectedRow.Cells["Convenient"].Value?.ToString(),
                Area = selectedRow.Cells["Area"].Value?.ToString(),
                Price = selectedRow.Cells["Price"].Value?.ToString(),
                Status = selectedRow.Cells["Status"].Value?.ToString()
            };
            Form_UpdateRoom updateRoom = new Form_UpdateRoom(form1.taikhoan.Username, selectedRoom);

            OverlayManager.ShowWithOverlay(this, updateRoom);

            if (updateRoom.DialogResult == DialogResult.OK)
            {
                load_QLP();
            }
        }

        

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgv_QLP.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dgv_QLP.Rows[row];
                Console.WriteLine(selectedRow.Cells[0].Value.ToString());
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = RoomBLL.DeleteRoom(dgv_QLP.SelectedRows[0].Cells["ROOMNAME"].Value.ToString(), listBuildingID.Text);

                    MessageBox.Show(message,
                                  success ? "Thành công" : "Lỗi",
                                  MessageBoxButtons.OK,
                                  success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (success)
                    {
                        loadInfo();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


           
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Form_RentalHistory rentalHistory = new Form_RentalHistory(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());

            OverlayManager.ShowWithOverlay(this, rentalHistory);//thêm hiệu ứng mờ

            //rentalHistory.Show();
        }


        private void button36_Click(object sender, EventArgs e)
        {
            if (dgv_QLP.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_QLP, "Danh sách phòng");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private UserService serviceUsageBLL = new UserService();


        public void LoadParkingAreaDataWithFilter(DataTable filteredData)
        {
            try
            {
                guna2DataGridView7.DataSource = filteredData;
                if (guna2DataGridView7.Rows.Count == 0)
                {
                    button52.Enabled = false;
                    button53.Enabled = false;
                    button57.Enabled = false;

                }
                else
                {
                    button52.Enabled = true;
                    button53.Enabled = true;
                    button57.Enabled = true;
                }
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
            AddService addServiceForm = new AddService(listBuildingID.Text, this);
            OverlayManager.ShowWithOverlay(this, addServiceForm);
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            DeleteService delServiceForm = new DeleteService(this);
            OverlayManager.ShowWithOverlay(this, delServiceForm);
        }

        private void themDV_btn_Click_1(object sender, EventArgs e)
        {
            InsertService insertServiceForm = new InsertService();
            //insertServiceForm.ShowDialog();
            OverlayManager.ShowWithOverlay(this, insertServiceForm);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (dgvServiceInfo.Visible)
            {
                ExcelExporter.ExportToExcel(dgvServiceInfo, "Danh sách đăng ký dịch vụ");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void button41_Click(object sender, EventArgs e)
        {
            if (dgv_QLHD.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_QLHD, "Danh sách Hợp đồng");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
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
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string new_key = RandomKey.RandomString(10);
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
            if (result == DialogResult.Yes)
            {
                BuildingBLL.BuildingBLL_change_building_key(datakey.Rows[listBuildingID.SelectedIndex][0].ToString(), new_key);
                buildingKey.Text = new_key;
            }
            load_Building_By_User();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form_AddBuilding f = new Form_AddBuilding(RandomKey.RandomString(10), form1.taikhoan.Username);
            //f.ShowDialog();
            OverlayManager.ShowWithOverlay(this, f);
            load_Building_By_User();
        }
        private void button56_Click(object sender, EventArgs e)
        {
            Form_AddParkingArea addParkingArea = new Form_AddParkingArea(form1.taikhoan.Username, listBuildingID.SelectedItem.ToString());
            OverlayManager.ShowWithOverlay(this, addParkingArea);//thêm
            if (addParkingArea.DialogResult == DialogResult.OK)
            {
                load_PA();
            }
        }
        private void button53_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView7.SelectedRows.Count == 0)
            {
                MessageBox.Show(Language.translate("asking"));
                return;
            }
            DataGridViewRow selectedRow = guna2DataGridView7.SelectedRows[0];

            ParkingArea selectedArea = new ParkingArea
            {
                AreaId = selectedRow.Cells["AreaId"].Value?.ToString(),
                BuildingId = selectedRow.Cells["BuildingID"].Value?.ToString(),
                Address = selectedRow.Cells["Address"].Value?.ToString(),
                Type = selectedRow.Cells["Type"].Value?.ToString(),
                Capacity = selectedRow.Cells["Capacity"].Value?.ToString()
            };
            Form_UpdateParkingArea updateArea = new Form_UpdateParkingArea(form1.taikhoan.Username, selectedArea);
            OverlayManager.ShowWithOverlay(this, updateArea);//thêm
            if (updateArea.DialogResult == DialogResult.OK)
            {
                load_PA();
            }
        }
        private void button52_Click(object sender, EventArgs e)
        {
            try
            {
                int row = guna2DataGridView7.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = guna2DataGridView7.Rows[row];
                Console.WriteLine(selectedRow.Cells[0].Value.ToString());
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = ParkingAreaBLL.DeleteArea(guna2DataGridView7.SelectedRows[0].Cells["AreaId"].Value.ToString());

                    MessageBox.Show(message,
                                  success ? "Thành công" : "Lỗi",
                                  MessageBoxButtons.OK,
                                  success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (success)
                    {
                        load_PA();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button57_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView7.Visible)
            {
                ExcelExporter.ExportToExcel(guna2DataGridView7, "Danh sách bãi giữ xe");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // New HoaiAn 14/4
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox11.Checked = false;
                checkBox18.Checked = false;
            }
            load_PA();
        }
        // New HoaiAn 14/4
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                checkBox10.Checked = false;
                checkBox18.Checked = false;
            }
            load_PA();
        }
        // New HoaiAn 14/4
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                checkBox10.Checked = false;
                checkBox11.Checked = false;
            }
            load_PA();
        }
        // New HoaiAn 14/4
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                checkBox20.Checked = false;
            }
            load_PA();
        }
        // New HoaiAn 14/4
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
            {
                checkBox17.Checked = false;
            }
            load_PA();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabQuanLy.SelectedIndex = 5;
        }
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Form_AddVehicle addVehicle = new Form_AddVehicle(listBuildingID.SelectedItem.ToString());
            OverlayManager.ShowWithOverlay(this, addVehicle);
            if (addVehicle.DialogResult == DialogResult.OK)
            {
                load_Vehicle();
            }
        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(Language.translate("asking"));
                return;
            }
            DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

            Vehicle selectedVehicle = new Vehicle
            {
                VehicleID = selectedRow.Cells["VehicleID"].Value?.ToString(),
                TenantID = selectedRow.Cells["TenantID"].Value?.ToString(),
                VehicleUnitPriceID = selectedRow.Cells["VEHICLE_UNITPRICE_ID"].Value?.ToString(),
                Type = selectedRow.Cells["Type"].Value?.ToString(),
                LicensePlate = selectedRow.Cells["LicensePlate"].Value?.ToString()
            };
            Form_UpdateVehicle updateVehicle = new Form_UpdateVehicle(selectedVehicle, listBuildingID.SelectedItem.ToString());
            OverlayManager.ShowWithOverlay(this, updateVehicle);
            if (updateVehicle.DialogResult == DialogResult.OK)
            {
                load_Vehicle();
            }
        }
        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int row = guna2DataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[row];
                Console.WriteLine(selectedRow.Cells[0].Value.ToString());
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Language.translate("hoidelete"), "", buttons);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = VehicleBLL.DeleteVehicle(guna2DataGridView1.SelectedRows[0].Cells["VehicleId"].Value.ToString());

                    MessageBox.Show(message,
                                  success ? "Thành công" : "Lỗi",
                                  MessageBoxButtons.OK,
                                  success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (success)
                    {
                        load_Vehicle();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Language.translate("asking"), "",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Visible)
            {
                ExcelExporter.ExportToExcel(guna2DataGridView1, "Danh sách phương tiện");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // New HoaiAn 14/4
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox5.Checked = false;
                checkBox7.Checked = false;
            }
            load_Vehicle();
        }
        // New HoaiAn 14/4
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox2.Checked = false;
                checkBox7.Checked = false;
            }
            load_Vehicle();
        }
        // New HoaiAn 14/4
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox2.Checked = false;
                checkBox5.Checked = false;
            }
            load_Vehicle();
        }

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
            //load_Contract(0, null);
            //load_Contract(0, null);
            //load_QLP();
            //loadTenant(null);
            //loadRegistration(null);
            loadInfo();
            foreach (KeyValuePair<string, string> kvp in Language.languages)
            {
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
                    case "building_change":
                        guna2Button2.Text = kvp.Value;
                        break;
                    case "building_add":
                        guna2Button5.Text = kvp.Value;
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
                    case "LoadAll.placeholder":
                        guna2HtmlLabel5.Text = kvp.Value;
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
                        checkBox23.Text = kvp.Value;
                        break;
                    case "checkbox_giamdan":
                        checkBox22.Text = kvp.Value;
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
                    case "requestfb":
                        guna2GradientButton13.Text = kvp.Value;
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
                        dgv_QLP.Columns["RoomName"].HeaderText = kvp.Value;
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
                        dgv_QLHD.Columns["ROOMNAME"].HeaderText = kvp.Value;
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
                        dgv_DKLT.Columns["ROOMNAME"].HeaderText = kvp.Value;
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

                    case "servicetable_ordernumber":
                        dgvServiceInfo.Columns["STT"].HeaderText = kvp.Value;
                        break;
                    case "servicetable_roomid":
                        dgvServiceInfo.Columns["RoomID"].HeaderText = kvp.Value;
                        break;
                    case "servicetable_tenantname":
                        dgvServiceInfo.Columns["TenantName"].HeaderText = kvp.Value;
                        break;
                    case "servicetable_servicename":
                        dgvServiceInfo.Columns["ServiceName"].HeaderText = kvp.Value;
                        break;
                    case "servicetable_serviceprice":
                        dgvServiceInfo.Columns["ServicePrice"].HeaderText = kvp.Value;

                        break;
                    case "servicetable_startdate":
                        dgvServiceInfo.Columns["StartedDay"].HeaderText = kvp.Value;
                        break;
                    case "servicetable_enddate":
                        dgvServiceInfo.Columns["EndDay"].HeaderText = kvp.Value;
                        break;

                    case "assettable_assetid":
                        dgv_QLCSVC.Columns["ASSETID"].HeaderText = kvp.Value;
                        break;
                    case "assettable_roomid":
                        dgv_QLCSVC.Columns["ROOMNAME"].HeaderText = kvp.Value;
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

                    case "parking.table_header.parking_id":
                        guna2DataGridView7.Columns[0].HeaderText = kvp.Value;
                        break;
                    case "parking.table_header.building_id":
                        guna2DataGridView7.Columns[1].HeaderText = kvp.Value;
                        break;
                    case "parking.table_header.address":
                        guna2DataGridView7.Columns[2].HeaderText = kvp.Value;
                        break;
                    case "parking.table_header.type":
                        guna2DataGridView7.Columns[3].HeaderText = kvp.Value;
                        break;
                    case "parking.table_header.capacity":
                        guna2DataGridView7.Columns[4].HeaderText = kvp.Value;
                        break;
                    case "parking.table_header.current_vehicles":
                        guna2DataGridView7.Columns[5].HeaderText = kvp.Value;
                        break;
                    case "parking.table_header.status":
                        guna2DataGridView7.Columns[6].HeaderText = kvp.Value;
                        break;
                    case "parking.type.car":
                        checkBox10.Text = kvp.Value;
                        break;
                    case "parking.type.motor_bike":
                        checkBox11.Text = kvp.Value;
                        break;
                    case "parking.type.mixed":
                        checkBox18.Text = kvp.Value;
                        break;
                    case "parking.type.available":
                        checkBox17.Text = kvp.Value;
                        break;
                    case "parking.type.full":
                        checkBox20.Text = kvp.Value;
                        break;
                    case "vehicle.table_header.vehicle_id":
                        guna2DataGridView1.Columns[0].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.customer_id":
                        guna2DataGridView1.Columns[1].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.last_name":
                        guna2DataGridView1.Columns[2].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.first_name":
                        guna2DataGridView1.Columns[3].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.price_id":
                        guna2DataGridView1.Columns[4].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.price":
                        guna2DataGridView1.Columns[5].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.vehicle_type":
                        guna2DataGridView1.Columns[6].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.license_plate":
                        guna2DataGridView1.Columns[7].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.parking_slot_id":
                        guna2DataGridView1.Columns[8].HeaderText = kvp.Value;
                        break;
                    case "vehicle.table_header.status":
                        guna2DataGridView1.Columns[9].HeaderText = kvp.Value;
                        break;
                    case "vehicle.type.car":
                        checkBox2.Text = kvp.Value;
                        break;
                    case "vehicle.type.motor_bike":
                        checkBox5.Text = kvp.Value;
                        break;
                    case "vehicle.type.bicycle":
                        checkBox7.Text = kvp.Value;
                        break;
                    case "btn_vantay":
                        btn_vantay.Text = kvp.Value;
                        break;
                    case "label_lang":
                        guna2HtmlLabel2.Text = kvp.Value;
                        break;
                    case "troli":
                        guna2Button7.Text = kvp.Value;
                        break;
                }
            }
        }



        private void listLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadLanguage();
        }

        private void guna2CustomGradientPanel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_LSTN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {

        }

        private void tabQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quanlynha_Load(object sender, EventArgs e)
        {
            btn_phong.Checked = true;
        }

        private void quanlynha_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quanlynha_Shown(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        // Yeu Cau Phan Anh
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID tòa nhà hiện tại đang chọn
                string buildingID = listBuildingID.Text;

                if (string.IsNullOrEmpty(buildingID))
                {
                    MessageBox.Show(Language.translate("asking"),
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Khởi tạo form Quản lý phản ánh với buildingID
                FeedbackManagementForm feedbackForm = new FeedbackManagementForm(buildingID);

                // Hiển thị form dạng dialog
                //feedbackForm.ShowDialog();
                OverlayManager.ShowWithOverlay(this, feedbackForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Quản lý phản ánh: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
        //New NhatHao
        private void update_LSTN()
        {
            DataTable tmp = TenantHistoryBLL.TenantHistoryBLL_count_TenantHistory(listBuildingID.Text);
            
            if (tmp != null)
            {
                for (int i = 0; i < tmp.Rows.Count; i++)
                {
                    TenantHistoryBLL.TenantHistoryBLL_auto_AddTenantHistory(
                        tmp.Rows[i][0].ToString(),
                        tmp.Rows[i][2].ToString(),
                        tmp.Rows[i][1].ToString(),
                        tmp.Rows[i][4].ToString(),
                        tmp.Rows[i][5].ToString(),
                        listBuildingID.Text);
                }
            }
        }
        private void load_Building_By_User()
        {
            if (datakey != null)
            {
                datakey.Clear();
                listBuildingID.Items.Clear();
            }
            datakey = BuildingBLL.BuildingBLL_load_Building_By_User(form1.taikhoan.Username);
            datakey.Merge(KeyBLL.load_building_by_key(form1.taikhoan.Username));
            for (int i = 0; i < datakey.Rows.Count; i++)
            {
                listBuildingID.Items.Add(datakey.Rows[i][0].ToString());
            }

            if (listBuildingID.Items.Count == 0)
            {
                return;
            }
            else
            {
                listBuildingID.SelectedIndex = index;
                buildingKey.Text = datakey.Rows[0][1].ToString();

            }
            KeyBLL.reload_key();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(KeyBLL.add_Key(form1.taikhoan.Username, guna2TextBox3.Text));
            load_Building_By_User();
            guna2TextBox3.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dgv_DKLT.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_DKLT, "Danh sách đăng ký lưu trú");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dgv_LSTN.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_LSTN, "Danh sách lịch sử thuê nhà");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dgv_thanhtoan.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_thanhtoan, "Danh sách thanh toán");
            }
            else
            {
                MessageBox.Show(Language.translate("fail_"), "",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void checkBill()
        {
            string control = "0";
            if (checkBox13.Checked)
            {
                checkBox6.Checked = false;
                control = "2";
            }

            if (checkBox6.Checked)
            {
                checkBox13.Checked = false;
                control = "1";
            }
            loadBill(null, control);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            checkBill();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBill();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_QLHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Tenant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
