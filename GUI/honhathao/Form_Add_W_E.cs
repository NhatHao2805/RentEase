
using BLL;
using BLL.honhathao;
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

namespace GUI.honhathao
{
    public partial class Form_Add_W_E: Form
    {
        private string tenantID;
        private string buildingid;
        public Form_Add_W_E(string tenantid,string buildingid)
        {
            this.tenantID = tenantid;
            this.buildingid = buildingid;

            InitializeComponent();
            loadInfo();
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
            W_E_BLL.Add_W_E(buildingid, o_w.Text, n_w.Text, o_e.Text, n_e.Text, month.Text);
            this.Close();
        }
        private void loadInfo()
        {
            Console.WriteLine(tenantID);
            List<string> a = RoomBLL.RoomBLL_Load_RoomInBuilding_2(buildingid);
            foreach (string id in a)
            {
                SoPhong.Items.Add(id);
            }
        }

        private void guna2GradientPanel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
