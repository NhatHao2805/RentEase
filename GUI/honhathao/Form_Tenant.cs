using BLL.honhathao;
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

namespace GUI.honhathao
{
    public partial class Form_Tenant : Form
    {
        private DataGridViewRow data;
        private int control;
        private string username;
        private bool exit = false;
        public Form_Tenant(DataGridViewRow data,int control,string username)
        {
            InitializeComponent();
            this.data = data;
            this.control = control;
            this.username = username;
            loadinfo();
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
        private void loadinfo()
        {
            if(data != null)
            {
                hodem.Text = data.Cells[1].Value.ToString();
                ten.Text = data.Cells[2].Value.ToString();
                ngaysinh.Value = DateTime.Parse(data.Cells[3].Value.ToString());
                gioitinh.Text = data.Cells[4].Value.ToString();
                sdt.Text = data.Cells[5].Value.ToString();
                email.Text = data.Cells[6].Value.ToString();
            }
            else
            {
                
                hodem.Text = " ";
                ten.Text = " ";
                ngaysinh.Value = DateTime.Now;
                gioitinh.SelectedIndex = 0;
                sdt.Text = " ";
                email.Text = " ";
            }
        }

        private void luu_Click(object sender, EventArgs e)
        {
            switch (control)
            {
                case 0:
                    string result = TenantBLL.TenantBLL_add_Tenant(
                        username,
                        hodem.Text,
                        ten.Text,
                        ngaysinh.Value.ToString("yyyy-MM-dd"),
                        gioitinh.Text,
                        sdt.Text,
                        email.Text
                    );
                    if(result == "Thêm thành công")
                    {
                        MessageBox.Show(result, "Information", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result, "Error", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    string result1 = TenantBLL.TenantBLL_update_Tenant(
                        data.Cells[0].Value.ToString(),
                        hodem.Text,
                        ten.Text,
                        ngaysinh.Value.ToString("yyyy-MM-dd"),
                        gioitinh.Text,
                        sdt.Text,
                        email.Text
                    );
                    if (result1 == "Thêm thành công")
                    {
                        MessageBox.Show(result1, "Information", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result1, "Error", MessageBoxButtons.OK);
                    }
                    
                    break;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hodem_Leave(object sender, EventArgs e)
        {
            
            if (!exit)
            {
                var temp = TenantBLL.TenantBLL_hodem(hodem.Text);
                if (temp.Item1 == false)
                {
                    if (temp.Item2 != "Success")
                    {
                        MessageBox.Show(temp.Item2, "Error", MessageBoxButtons.OK);
                        //hodem.Focus();
                    }
                }
                if (string.IsNullOrEmpty(hodem.Text))
                {
                    hodem.Text = " ";
                }
            }
        }

        private void hodem_Enter(object sender, EventArgs e)
        {
            if(hodem.Text == " ")
                hodem.Text = "";
        }

        private void ten_Leave(object sender, EventArgs e)
        {
            
            if (!exit)
            {
                var temp = TenantBLL.TenantBLL_hoten(ten.Text);
                if (temp.Item1 == false)
                {
                    if (temp.Item2 != "Success")
                    {
                        MessageBox.Show(temp.Item2, "Error", MessageBoxButtons.OK);
                        //ten.Focus();
                    }
                }
                if (string.IsNullOrEmpty(ten.Text))
                {
                    ten.Text = " ";
                }
            }
        }

        private void ten_Enter(object sender, EventArgs e)
        {
            if(ten.Text == " ")
            ten.Text = "";
        }

        private void sdt_Leave(object sender, EventArgs e)
        {
           
            if (!exit)
            {
                var temp = TenantBLL.TenantBLL_sdt(sdt.Text);
                if (temp.Item1 == false)
                {
                    if (temp.Item2 != "Success")
                    {
                        MessageBox.Show(temp.Item2, "Error", MessageBoxButtons.OK);
                        //sdt.Focus();
                    }
                }
                if (string.IsNullOrEmpty(sdt.Text))
                {
                    sdt.Text = " ";
                }
            }
        }

        private void sdt_Enter(object sender, EventArgs e)
        {
            if(sdt.Text == " ")
            sdt.Text = "";
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (!exit)
            {
                var temp = TenantBLL.TenantBLL_email(email.Text);
                if (temp.Item1 == false)
                {
                    if (temp.Item2 != "Success")
                    {
                        MessageBox.Show(temp.Item2, "Error", MessageBoxButtons.OK);
                        //email.Focus();
                    }

                }
                if (string.IsNullOrEmpty(email.Text))
                {
                    email.Text = " ";
                }
            }
        }

        private void email_Enter(object sender, EventArgs e)
        {
            if(email.Text == " ")
            email.Text = "";
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            
            Console.WriteLine(exit);
            exit = true;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            Console.WriteLine(exit);
            exit = false;
        }
    }
}
