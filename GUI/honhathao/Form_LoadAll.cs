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
    public partial class Form_LoadAll: Form
    {
        public Form_LoadAll()
        {
            InitializeComponent();
            loadInfo(null);
        }

        private void loadInfo(string name)
        {
            DataTable dt = BLL.honhathao.TenantHistoryBLL.TenantHistoryBLL_load_AllTenantHistory(name);
            dgv_LSTN.DataSource = dt;
            dgv_LSTN.Columns[0].HeaderText = "Mã Phòng";
            dgv_LSTN.Columns[1].HeaderText = "Mã Người Thuê";
            dgv_LSTN.Columns[2].HeaderText = "Họ";
            dgv_LSTN.Columns[3].HeaderText = "Tên";
            dgv_LSTN.Columns[4].HeaderText = "Đánh gia";
            dgv_LSTN.Columns[0].Width = 100;
            dgv_LSTN.Columns[1].Width = 100;
            dgv_LSTN.Columns[2].Width = 200;
            dgv_LSTN.Columns[3].Width = 100;
            dgv_LSTN.Columns[4].Width = 500;

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadInfo(guna2TextBox1.Text);
        }
    }
}
