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
    public partial class Form_W_E: Form
    {
        private string usern;
        private string buildingid;
        public Form_W_E(string usern,string buildingid)
        {
            this.usern = usern;
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

        private void button38_Click(object sender, EventArgs e)
        {
            Form_Add_W_E form = new Form_Add_W_E(buildingid);
            form.ShowDialog();
            dgv_we.DataSource = null;
            loadInfo();
        }

        private void loadInfo()
        {

            DataTable data = W_E_BLL.W_E_BLL_load_W_E(usern, buildingid);
            dgv_we.DataSource = data;
        }
    }
}
