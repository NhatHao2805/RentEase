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
    public partial class quanlynha: Form
    {
        Form1 form1;
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

        public quanlynha(Form1 form1)
        {
            InitializeComponent();
            loadVariable();
            setStartPositon();
            this.form1 = form1;
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

        }
        private void Form2_Load(object sender, EventArgs e)
        {

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

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void btn_phong_Click(object sender, EventArgs e)
        {
            changePanel(panel_quanlyphong);
        }


        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            changePanel(panel_quanlyhopdong);
            LoadData("All");
        }
        private void LoadData(String required)
        {
            List<ContractDTO> contractList = contractBLL.GetContractList(required);
            dataGridView2.DataSource = contractList;
        }
     
        private void button19_Click(object sender, EventArgs e)
        {
     
            ThongtinkhachthueBLL tenantBLL = new ThongtinkhachthueBLL();
            List<ThongtinkhachthueDTO> tenants = tenantBLL.GetAllTenants();

        
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Khách Thuê", typeof(string));
            dt.Columns.Add("Tên", typeof(string));
            dt.Columns.Add("Họ", typeof(string));
            dt.Columns.Add("Ngày Sinh", typeof(string));
            dt.Columns.Add("Giới Tính", typeof(string));
            dt.Columns.Add("Số Điện Thoại", typeof(string));
            dt.Columns.Add("Email", typeof(string));

 
            foreach (ThongtinkhachthueDTO tenant in tenants)
            {
                dt.Rows.Add(
                    tenant.TenantID,
                    tenant.FirstName,
                    tenant.LastName,
                    tenant.Birthday.ToShortDateString(),
                    tenant.Gender,
                    tenant.PhoneNumber,
                    tenant.Email
                );
            }

            // 5. Gán DataTable cho DataGridView2
            dataGridView2.DataSource = dt;

            // 6. Tự động điều chỉnh độ rộng cột
            dataGridView2.AutoResizeColumns();
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

        // Them Hop Dong
        private void button16_Click(object sender, EventArgs e)
        {
            using (ContractForm contractForm = new ContractForm())
            {
                if (contractForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Contract has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // DataGridView Click
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private ContractBLL contractBLL = new ContractBLL();

        // Filter đã hết hạn

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                // Nếu checkbox được tick → Hiển thị dữ liệu A
                LoadData("Inactive");
            }
            else
            {
                // Nếu checkbox bỏ tick → Hiển thị lại toàn bộ dữ liệu
                LoadData("All");
            }
            
        }
        // sap het hạn hop dong
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                // Nếu checkbox được tick → Hiển thị dữ liệu A
                LoadData("Expire Soon");
            }
            else
            {
                // Nếu checkbox bỏ tick → Hiển thị lại toàn bộ dữ liệu
                LoadData("All");
            }
        }
        // con hieu luc
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Nếu checkbox được tick → Hiển thị dữ liệu A
                LoadData("Active");
            }
            else
            {
                // Nếu checkbox bỏ tick → Hiển thị lại toàn bộ dữ liệu
                LoadData("All");
            }
        }

        // Dang bao ket thuc
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // Nếu checkbox được tick → Hiển thị dữ liệu A
                LoadData("Ending");
            }
            else
            {
                // Nếu checkbox bỏ tick → Hiển thị lại toàn bộ dữ liệu
                LoadData("All");
            }
        }

        private void quanlynha_Load(object sender, EventArgs e)
        {

        }
    }
}
