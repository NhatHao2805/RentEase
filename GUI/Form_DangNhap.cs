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
        AccountBLL taikhoanBLL = new AccountBLL();
        QuanLyNha f2;
        User taikhoan = new User();
        bool check_picBox1 = true;

        private Point init_Location = new Point(290,0);
        private Point ter_Location = new Point(-300,0);
        public Form_DangNhap()
        {
            InitializeComponent();
            setStartPositon();
        }

        private void setStartPositon()
        {
           
        }
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan.username = textBoxTK_DN.Text;
            taikhoan.password = textBoxMK_DN.Text;

            string check = taikhoanBLL.CheckLogic(taikhoan);

            switch (check)
            {
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
            MessageBox.Show("Đăng nhập thành công");
            
            //f2 = new QuanLyNha(this);
            //f2.Show();
            //this.Hide();

        }

        private void buttonDangKy2_Click(object sender, EventArgs e)
        {
            //if(textBoxMK_DK1.Text != textBoxMK_DK2.Text)
            //{
            //    MessageBox.Show("Mật khẩu không trùng khớp!");
            //    return;
            //}
            //taikhoan.taikhoan = textBoxTK_DK.Text;
            //taikhoan.matkhau = textBoxMK_DK1.Text;
            //string check = taikhoanBLL.addAccountBLL(taikhoan);
            //MessageBox.Show(check);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //timer1.Start();

        }
    }
}
