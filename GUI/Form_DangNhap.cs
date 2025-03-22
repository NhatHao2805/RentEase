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
namespace GUI
{
    public partial class Form_DangNhap: Form
    {
        Account taikhoan = new Account();
        AccountBLL taikhoanBLL = new AccountBLL();
        quanlynha f2;
        public Form_DangNhap()
        {
            InitializeComponent();
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
            taikhoan.taikhoan = textBoxTK_DN.Text;
            taikhoan.matkhau = textBoxMK_DN.Text;

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
            f2 = new quanlynha(this);
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
            Form_DangKy dk = new Form_DangKy();
            dk.Show();
        }
    }
    
}
