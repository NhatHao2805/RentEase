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
            Form_Add_W_E form = new Form_Add_W_E(dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[0].Value.ToString(),buildingid);
            form.ShowDialog();
            loadInfo();
        }

        private void loadInfo()
        {

            DataTable data = W_E_BLL.W_E_BLL_load_W_E(usern, buildingid);
            dgv_we.DataSource = data;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[2].Value.ToString());
            Console.WriteLine(dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[6].Value.ToString());
            Console.WriteLine(dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[7].Value.ToString());
            MessageBox.Show(W_E_BLL.W_E_BLL_Del_W_E(dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[2].Value.ToString(), dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[6].Value.ToString(), dgv_we.Rows[dgv_we.CurrentCell.RowIndex].Cells[7].Value.ToString()));
            loadInfo();
        }
    }
}
