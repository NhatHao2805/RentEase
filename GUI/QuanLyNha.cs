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

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
