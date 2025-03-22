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
    public partial class Form_DangKy: Form
    {

        Account taikhoan = new Account();
        AccountBLL taikhoanBLL = new AccountBLL();
        public Form_DangKy()
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


        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            if (textBoxMK_DK1.Text != textBoxMK_DK2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                return;
            }

            taikhoan.taikhoan = textBoxTK_DK.Text;
            taikhoan.matkhau = textBoxMK_DK1.Text;
            taikhoan.gioitinh = gt_cb.Text;
            taikhoan.email  = email_tb.Text;
            taikhoan.diachi = diachi_tb.Text;
            taikhoan.ngaysinh = ns_datetimepicker.Value.ToString("dd-MM-yyyy");
            taikhoan.sdt = sdt_tb.Text;
            taikhoan.hovaten = name_tb.Text;

            string check = taikhoanBLL.AccountBLL_CheckSignUp(taikhoan);

            switch (check)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Thông tin tài khoản không hợp lệ!");
                    return;
                case "requeid_password":
                    MessageBox.Show("Mật khẩu không hợp lệ!");
                    return;
                case "requeid_username":
                    MessageBox.Show("Tên không hợp lệ!");
                    return;
                case "requeid_email":
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                case "requeid_gender":
                    MessageBox.Show("Vui lòng chọn giới tính");
                    return;
                case "requeid_phonenumber":
                    MessageBox.Show("Số điên thoại không hợp lệ!");
                    return;
                case "requeid_address":
                    MessageBox.Show("Vui lòng nhập địa chỉ!");
                    return;
            }

            textBoxTK_DK.Text = "";
            textBoxMK_DK1.Text = "";
            textBoxMK_DK2.Text = "";
            MessageBox.Show(check);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizedButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void gt_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
