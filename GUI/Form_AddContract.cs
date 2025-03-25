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
using BLL;

namespace GUI
{
    public partial class Form_AddContract: Form
    {
        HouseBLL houseBLL;
        AccountBLL accountBLL;

        public Form_AddContract()
        {
            InitializeComponent();
            LoadInfo();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInfo()
        {
            houseBLL = new HouseBLL();
            accountBLL = new AccountBLL();
            List<string> a = houseBLL.HouseBLL_Load_HouseAddress();
            foreach (string address in a)
            {
                guna2ComboBox1.Items.Add(address);
            }
            a = accountBLL.AccountBLL_Load_TenantName();
            foreach (string name in a)
            {
                guna2ComboBox2.Items.Add(name);
            }
        }
        private void guna2ComboBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("hi");
            guna2TextBox1.Text = houseBLL.HouseBLL_TakePrice(guna2ComboBox1.Text);
        }

        private void Form_AddContract_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("value");
            guna2TextBox1.Text = houseBLL.HouseBLL_TakePrice(guna2ComboBox1.Text);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("index");
            guna2TextBox1.Text = houseBLL.HouseBLL_TakePrice(guna2ComboBox1.Text);
        }
    }
}
