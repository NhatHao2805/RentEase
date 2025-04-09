
using BLL;
using BLL.honhathao;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        private string tenantID = null;
        private string buildingid;
        public Form_Add_W_E(string buildingid)
        {
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
            
            
            if(tenantID != null)
            {
                W_E_BLL.Add_W_E(buildingid, o_w.Text, n_w.Text, o_e.Text, n_e.Text, month.Text);
                string billid = BillBLL.BillBLL_load_BillID();
                DataTable data = TenantServiceBLL.TenantServiceBLL_load_registration_service_to_add(tenantID);
                foreach (DataRow dataRow in data.Rows)
                {
                    TenantServiceBLL.TenantServiceBLL_add_all_registration_Ser_into_billdetail(
                       billid, dataRow[0].ToString(), dataRow[1].ToString());
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn phòng");
            }
            
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

        private void SoPhong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable data = TenantBLL.TenantBLL_load_Tenant_by_RoomID(SoPhong.Text);
            DataRow row = data.Rows[0];
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn column in data.Columns)
            {
                sb.Append($"{row[column]} ");
            }
            tenantID = row[0].ToString();
            guna2TextBox1.Text = sb.ToString();
        }
    }
}
