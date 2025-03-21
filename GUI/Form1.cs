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
    public partial class Form1: Form
    {
        Account taikhoan = new Account();
        AccountBLL taikhoanBLL = new AccountBLL();
        quanlynha f2;
        bool check_picBox1 = true;

        private Point init_Location = new Point(290,0);
        private Point ter_Location = new Point(-300,0);
        public Form1()
        {
            InitializeComponent();
            setStartPositon();
        }

        private void setStartPositon()
        {
            pictureBox1.Location = init_Location;
        }
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan.taikhoan = textBoxTK_DN.Text;
            taikhoan.matkhau = textBoxMK_DN.Text;

            string check = taikhoanBLL.CheckLogic(taikhoan);

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

        private void buttonDangKy2_Click(object sender, EventArgs e)
        {
            if(textBoxMK_DK1.Text != textBoxMK_DK2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                return;
            }
            taikhoan.taikhoan = textBoxTK_DK.Text;
            taikhoan.matkhau = textBoxMK_DK1.Text;
            string check = taikhoanBLL.addAccountBLL(taikhoan);
            MessageBox.Show(check);
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

        private void buttonXemPass1_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxMK_DK1.PasswordChar = '\0';
        }

        private void buttonXemPass1_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxMK_DK1.PasswordChar = '*';

        }

        private void buttonXemPass2_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxMK_DK2.PasswordChar = '\0';

        }

        private void buttonXemPass2_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxMK_DK2.PasswordChar = '\0';

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check_picBox1)
            {
                if (pictureBox1.Location.X > ter_Location.X)
                {
                    pictureBox1.Location = new Point(pictureBox1.Left - 50, pictureBox1.Top);
                }
                else
                {
                    check_picBox1 = false;
                    timer1.Stop();
                }
            }
            else
            {
                if (pictureBox1.Location.X < init_Location.X)
                {
                    pictureBox1.Location = new Point(pictureBox1.Left + 50, pictureBox1.Top);
                }
                else
                {
                    check_picBox1 = true;
                    timer1.Stop();
                }
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer1.Start();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer1.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
