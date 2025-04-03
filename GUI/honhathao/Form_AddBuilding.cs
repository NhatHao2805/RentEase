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
    public partial class Form_AddBuilding: Form
    {
        private string key;
        private string username;
        public Form_AddBuilding(string key, string useranme)
        {
            this.key = key;
            this.username = useranme;
            InitializeComponent();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(address.Text))
            {
                MessageBox.Show("Please enter address");
                return;
            }
            BuildingBLL.BuildingBLL_add_building(key,username, address.Text);
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
