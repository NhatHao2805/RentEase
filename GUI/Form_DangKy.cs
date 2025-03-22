using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_DangKy : Form
    {
        public Form_DangKy()
        {
            InitializeComponent();
        }

        private void Form_DangKy_Load(object sender, EventArgs e)
        {
            
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            label1.Focus();
            username_tb.Text = "  Tên Tài Khoản";
            username_tb.ForeColor = Color.Silver;
            username_tb.Enter += new EventHandler(username_tb_Enter);
            username_tb.Leave += new EventHandler(username_tb_Leave);

            fullname_tb.Text = "  Tên Người Dùng";
            fullname_tb.ForeColor = Color.Silver;
            fullname_tb.Enter += new EventHandler(fullname_tb_Enter);
            fullname_tb.Leave += new EventHandler(fullname_tb_Leave);

            password_tb.Text = "  Mật Khẩu";
            password_tb.ForeColor = Color.Silver;
            password_tb.Enter += new EventHandler(password_tb_Enter);
            password_tb.Leave += new EventHandler(password_tb_Leave);

            repassword_tb.Text = "  Nhập lại Mật Khẩu";
            repassword_tb.ForeColor = Color.Silver;
            repassword_tb.Enter += new EventHandler(repassword_tb_Enter);
            repassword_tb.Leave += new EventHandler(repassword_tb_Leave);

            email_tb.Text = "  Email";
            email_tb.ForeColor = Color.Silver;
            email_tb.Enter += new EventHandler(email_tb_Enter);
            email_tb.Leave += new EventHandler(email_tb_Leave);

            numberphone_tb.Text = "  Số điện thoại";
            numberphone_tb.ForeColor = Color.Silver;
            numberphone_tb.Enter += new EventHandler(numberphone_tb_Enter);
            numberphone_tb.Leave += new EventHandler(numberphone_tb_Leave);

            address_tb.Text = "  Địa chỉ";
            address_tb.ForeColor = Color.Silver;
            address_tb.Enter += new EventHandler(address_tb_Enter);
            address_tb.Leave += new EventHandler(address_tb_Leave);

            gender_cb.Items.Add("Nam");
            gender_cb.Items.Add("Nữ");
            gender_cb.Items.Add("Khác..");
            gender_cb.SelectedIndex = 0;

            year_tb.Text = "  Năm";
            year_tb.ForeColor = Color.Silver;
            year_tb.Enter += new EventHandler(year_tb_Enter);
            year_tb.Leave += new EventHandler(year_tb_Leave);

            month_tb.Text = "  Tháng";
            month_tb.ForeColor = Color.Silver;
            month_tb.Enter += new EventHandler(month_tb_Enter);
            month_tb.Leave += new EventHandler(month_tb_Leave);

            day_tb.Text = "  Ngày";
            day_tb.ForeColor = Color.Silver;
            day_tb.Enter += new EventHandler(day_tb_Enter);
            day_tb.Leave += new EventHandler(day_tb_Leave);

            //for(int i = 1970; i <= DateTime.Now.Year; i++)
            //{
            //    year_cb.Items.Add(i.ToString());
            //}
            //year_cb.MaxDropDownItems = 3;

            //for (int i = 1; i <= 12; i++)
            //{
            //    month_cb.Items.Add(i.ToString());
            //}
            //month_cb.MaxDropDownItems = 3;

            //year_cb.SelectedIndexChanged += UpdateDays;
            //month_cb.SelectedIndexChanged += UpdateDays;

        }

        private void year_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(year_tb, "  Năm");
            //check_validity();

        }

        private void year_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(year_tb, "  Năm");
            //check_validity();

        }

        private void month_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(month_tb, "  Tháng");
            //check_validity();

        }

        private void month_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(month_tb, "  Tháng");
            //check_validity();

        }

        private void day_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(day_tb, "  Ngày");
            //check_validity();

        }

        private void day_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(day_tb, "  Ngày");
            //check_validity();
        }

        //private void UpdateDays(object sender, EventArgs e)
        //{
        //    day_cb.Items.Clear();
        //    if (year_cb.SelectedItem != null && month_cb.SelectedItem != null)
        //    {
        //        int year = int.Parse(year_cb.SelectedItem.ToString());
        //        int month = int.Parse(month_cb.SelectedItem.ToString());
        //        int daysInMonth = DateTime.DaysInMonth(year, month);
        //        for (int i = 1; i <= daysInMonth; i++)
        //        {
        //            day_cb.Items.Add(i.ToString());
        //        }
        //    }
        //    day_cb.MaxDropDownItems = 3;
        //}

        private void repassword_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(repassword_tb, "  Nhập lại Mật Khẩu");
        }

        private void repassword_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(repassword_tb, "  Nhập lại Mật Khẩu");
        }

        private void email_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(email_tb, "  Email");
        }

        private void email_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(email_tb, "  Email");
        }

        private void numberphone_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(numberphone_tb, "  Số điện thoại");
        }

        private void numberphone_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(numberphone_tb, "  Số điện thoại");
        }

        private void address_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(address_tb, "  Địa chỉ");
        }

        private void address_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(address_tb, "  Địa chỉ");
        }

        private void username_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(username_tb, "  Tên Tài Khoản");

        }

        private void username_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(username_tb, "  Tên Tài Khoản");
        }

        private void fullname_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(fullname_tb, "  Tên Người Dùng");
        }

        private void fullname_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(fullname_tb, "  Tên Người Dùng");
        }
        private void password_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(password_tb, "  Mật Khẩu");
        }

        private void password_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(password_tb, "  Mật Khẩu");
        }



        private void placeHolderText_1(TextBox tb,string text)
        {
            if (tb.Text == "")
            {
                tb.Text = text;
                tb.ForeColor = Color.Silver;
            }
        }

        private void placeHolderText_2(TextBox tb, string text)
        {
            if (tb.Text == text)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;

            }
        }

        private void birth_datepicker_ValueChanged(object sender, EventArgs e)
        {
            year_tb.Text = birth_datepicker.Value.Year.ToString();
            month_tb.Text = birth_datepicker.Value.Month.ToString();
            day_tb.Text = birth_datepicker.Value.Day.ToString();
            year_tb.ForeColor = Color.Black;
            month_tb.ForeColor = Color.Black;
            day_tb.ForeColor = Color.Black;
        }

        private void check_validity()
        {
            bool valid1 = int.TryParse(day_tb.Text, out int result1);
            bool valid2 = int.TryParse(month_tb.Text, out int result2);
            bool valid3 = int.TryParse(year_tb.Text, out int result3);
            if (day_tb.Text != "  Ngày" && month_tb.Text != "  Tháng" && year_tb.Text != "  Năm")
            {
                if (valid1 && valid2 && valid3)
                {
                    day_tb.ForeColor = Color.Black;
                    month_tb.ForeColor = Color.Black;
                    year_tb.ForeColor = Color.Black;
                    if(result2 < 1 || result2 > 12)
                    {
                        month_tb.ForeColor = Color.Red;
                        return;
                    }
                    int daysInMonth = DateTime.DaysInMonth(result3, result2);

                    if (result1 < 1 || result1 > daysInMonth)
                    {
                        day_tb.ForeColor= Color.Red;
                    }
                }   
                else
                {
                    if (!valid1) { 
                        day_tb.ForeColor = Color.Red;
                    }
                    if (!valid2) { 
                        month_tb.ForeColor = Color.Red;
                    }
                    if (!valid3) { 
                        year_tb.ForeColor = Color.Red; 
                    }
                    
                }
            }
        }

        private void month_tb_TextChanged(object sender, EventArgs e)
        {
            //check_validity();
            
        }

        private void day_tb_TextChanged(object sender, EventArgs e)
        {
            //check_validity();
        }

        private void settingSeePassword( TextBox tb, CheckBox chb, string s)
        {
            if (tb.Text != s)
            {
                if (chb.Checked)
                {
                    tb.PasswordChar = '\0';
                }
                else { tb.PasswordChar = '*'; }
            }
            else
            {
                tb.PasswordChar = '\0';
            }
        }

        private void seePassword_1_CheckedChanged(object sender, EventArgs e)
        {
            settingSeePassword(password_tb, seePassword_1, "  Mật Khẩu");
        }

        private void seePassword_2_CheckedChanged(object sender, EventArgs e)
        {
            settingSeePassword(repassword_tb, seePassword_2, "  Nhập lại Mật Khẩu");

        }

        private void password_tb_TextChanged(object sender, EventArgs e)
        {
            settingSeePassword(password_tb, seePassword_1, "  Mật Khẩu");

        }

        private void repassword_tb_TextChanged(object sender, EventArgs e)
        {
            settingSeePassword(repassword_tb, seePassword_2, "  Nhập lại Mật Khẩu");

        }
    }
}
