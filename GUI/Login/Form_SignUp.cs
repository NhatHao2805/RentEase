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
    public partial class Form_SignUp: Form
    {

        User taikhoan = new User();
        AccountBLL taikhoanBLL = new AccountBLL();
        private Form_Login lg;
        public Form_SignUp(Form_Login lg)
        {
            InitializeComponent();
            loadLanguage();//New NhatHao
            this.lg = lg;
            guna2DateTimePicker1.MaxDate = DateTime.Now;
        }

        private void loadLanguage()//New NhatHao
        {
            Console.WriteLine(Language.languages.Count);
            foreach (KeyValuePair<string, string> kvp in Language.languages)
            {
                //Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
                switch (kvp.Key)
                {
                    
                    case "Sign_Up_Title_Form":
                        label1.Text = kvp.Value;
                        buttonDangKy.Text = kvp.Value;
                        break;
                    case "User_info":
                        info_user.Text = kvp.Value;
                        break;
                    case "Fullname":
                        label2.Text = kvp.Value;
                        break;
                    case "Birthday":
                        label6.Text = kvp.Value;
                        break;
                    case "Email":
                        label3.Text = kvp.Value;
                        break;
                    case "Gender":
                        label7.Text = kvp.Value;
                        break;
                    case "Address":
                        label5.Text = kvp.Value;
                        break;
                    case "Numberphone":
                        label4.Text = kvp.Value;
                        break;
                    case "Username":
                        labelTK_DK.Text = kvp.Value;
                        break;
                    case "Password":
                        labelMK_DK1.Text = kvp.Value;
                        break;
                    case "Password2":
                        labelMK_DK2.Text = kvp.Value;
                        break;
                    case "Account_info":
                        info_account.Text = kvp.Value;
                        break;
                    
                }
            }
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
            textBoxMK_DK2.PasswordChar = '*';

        }


        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex pattern for email validation according to RFC 5322
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            try
            {
                // Check basic pattern
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
                    return false;

                // Additional checks
                var parts = email.Split('@');
                var localPart = parts[0];
                var domain = parts[1];

                // Check for invalid local-part conditions
                if (localPart.StartsWith(".") || localPart.EndsWith(".") || localPart.Contains(".."))
                    return false;

                // Check for invalid domain conditions
                if (domain.StartsWith("-") || domain.EndsWith("-") || domain.Contains(".."))
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            // Email validation
            if (!IsValidEmail(email_tb.Text))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng email.");
                return;
            }
            if (textBoxMK_DK1.Text != textBoxMK_DK2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                return;
            }

            taikhoan.Username = textBoxTK_DK.Text;
            taikhoan.Password = textBoxMK_DK1.Text;
            taikhoan.Gender = gt_cb.Text;
            taikhoan.Email  = email_tb.Text;
            taikhoan.Address = diachi_tb.Text;
            taikhoan.Birth = ns_datetimepicker.Value.ToString("dd-MM-yyyy");
            taikhoan.PhoneNumber = sdt_tb.Text;
            taikhoan.FullName = name_tb.Text;

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lg.Show();
            this.Close();
        }
    }
}
