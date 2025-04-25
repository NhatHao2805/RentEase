using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Runtime.InteropServices;
using GUI;
using GUI.BuildingManagement;
using GUI.Custom;
namespace GUI
{
    public partial class Form_Login: Form
    {
        public User taikhoan = new User();
        AccountBLL taikhoanBLL = new AccountBLL();
        Form_Building f2;
        public Form_Login()
        {
            InitializeComponent();
            loadInfo();//New NhatHao
        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private extern static IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan.Username = textBoxTK_DN.Text;
            taikhoan.Password = textBoxMK_DN.Text;

            string check = taikhoanBLL.AccountBLL_CheckLogin(taikhoan);

            switch (check) {
                case "requeid_taikhoan":
                    MessageBox.Show("Bạn chưa nhập tài khoản!");
                    return;
                case "requeid_password":

                    MessageBox.Show("Bạn chưa nhập mật khẩu!");
                    return;
                case "Tài khoản hoặc mật khẩu không chính xác!":
                    MessageBox.Show(check);

                    return;
            }
            //Chưa hoàn chỉnh
            f2 = new Form_Building(this);
            f2.Show();
            this.Hide();

        }

        //Xử lí các nút xem password
        private void buttonXemPass_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxMK_DN.PasswordChar = '\0';
        }

        private void buttonXemPass_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxMK_DN.PasswordChar = '*';

        }
        private void exitButton_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void minimizedButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dk_lb_Click(object sender, EventArgs e)
        {
            Form_SignUp dk = new Form_SignUp();
            dk.Show();
        }
        private void loadInfo()//New Nhathao
        {
            string l = Language.GetCurrentLanguage();
            string[] listLanguage = Language.getListLanguage();
            guna2ComboBox1.Items.Add(l);
            foreach (string item in listLanguage)
            {
                if (item != l)
                {
                    guna2ComboBox1.Items.Add(item);
                }
            }
            guna2ComboBox1.SelectedItem = l;
            loadLanguage();
        }

        private void loadLanguage()//New NhatHao
        {
            string selectedLanguage = guna2ComboBox1.SelectedItem.ToString();
            Language.SetCurrentLanguage(selectedLanguage);

            foreach (KeyValuePair<string, string> kvp in Language.languages)
            {
                switch (kvp.Key)
                {
                    case "Title":
                        label1.Text = kvp.Value;
                        break;
                    case "Username":
                        labelTK_DN.Text = kvp.Value;
                        break;
                    case "Password":
                        labelMK_DN.Text = kvp.Value;
                        break;
                    case "Sign_in":
                        buttonDangNhap1.Text = kvp.Value;
                        break;
                    case "Sign_up":
                        dk_lb.Text = kvp.Value;
                        break;

                }
            }
        }
        //New NhatHao
        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadLanguage();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void hienMk_Popup(object sender, PopupEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        //New HoaiAn
        private void dmk_lb_Click(object sender, EventArgs e)
        {
            Form_ForgotPassword forgotPasswordForm = new Form_ForgotPassword();
            //forgotPasswordForm.ShowDialog();
            OverlayManager.ShowWithOverlay(this, forgotPasswordForm);
        }
    }
    
}
