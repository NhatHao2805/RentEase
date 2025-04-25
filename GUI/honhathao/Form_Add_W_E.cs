
using BLL;
using BLL.honhathao;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
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
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "utility_bill.title":
                        label23.Text = a.Value;
                        break;
                    case "utility_bill.subtitle":
                        label22.Text = a.Value;
                        break;
                    case "utility_bill.room_number":
                        guna2HtmlLabel14.Text = a.Value;
                        break;
                    case "utility_bill.tenant_name":
                        guna2HtmlLabel15.Text = a.Value;
                        break;
                    case "utility_bill.old_electric":
                        guna2HtmlLabel13.Text = a.Value;
                        break;
                    case "utility_bill.new_electric":
                        guna2HtmlLabel12.Text = a.Value;
                        break;
                    case "utility_bill.old_water":
                        guna2HtmlLabel9.Text = a.Value;
                        break;
                    case "utility_bill.new_water":
                        guna2HtmlLabel10.Text = a.Value;
                        break;
                    case "utility_bill.month":
                        guna2HtmlLabel11.Text = a.Value;
                        break;
                    case "utility_bill.add_button":
                        guna2Button1.Text = a.Value;
                        break;
                }
            }
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
                System.Data.DataTable data = TenantServiceBLL.TenantServiceBLL_load_registration_service_to_add(tenantID);
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
            loadLanguage();

        }

        private void SoPhong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            System.Data.DataTable data = TenantBLL.TenantBLL_load_Tenant_by_RoomID(SoPhong.Text);
            DataRow row = data.Rows[0];
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn column in data.Columns)
            {
                sb.Append($"{row[column]} ");
            }
            tenantID = row[0].ToString();
            guna2TextBox1.Text = sb.ToString();
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void o_e_Leave(object sender, EventArgs e)
        {
            if(o_e.Text.Length > 0 && n_e.Text.Length > 0)
            {
                if (int.TryParse(o_e.Text, out int oldElectric) && int.TryParse(n_e.Text, out int newElectric))
                {
                    if (oldElectric > newElectric)
                    {
                        MessageBox.Show("Số điện cũ không được lớn hơn số điện mới");
                        o_e.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Số điện không hợp lệ");
                    o_e.Text = "";
                }
            }
        }

        private void n_e_Leave(object sender, EventArgs e)
        {
            if (o_e.Text.Length > 0 && n_e.Text.Length > 0)
            {
                if (int.TryParse(o_e.Text, out int oldElectric) && int.TryParse(n_e.Text, out int newElectric))
                {
                    if (oldElectric > newElectric)
                    {
                        MessageBox.Show("Số điện cũ không được lớn hơn số điện mới");
                        n_e.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Số điện không hợp lệ");
                    n_e.Text = "";
                }
            }
        }

        private void o_w_Leave(object sender, EventArgs e)
        {
            if(o_w.Text.Length > 0 && n_w.Text.Length > 0)
            {
                if (int.TryParse(o_w.Text, out int oldWater) && int.TryParse(n_w.Text, out int newWater))
                {
                    if (oldWater > newWater)
                    {
                        MessageBox.Show("Số nước cũ không được lớn hơn số nước mới");
                        o_w.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Số nước không hợp lệ");
                    o_w.Text = "";
                }
            }
        }

        private void n_w_TextChanged(object sender, EventArgs e)
        {
            if (n_e.Text.Length > 0 && n_w.Text.Length > 0)
            {
                if (int.TryParse(o_w.Text, out int oldWater) && int.TryParse(n_w.Text, out int newWater))
                {
                    if (oldWater > newWater)
                    {
                        MessageBox.Show("Số nước cũ không được lớn hơn số nước mới");
                        n_w.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Số nước không hợp lệ");
                    n_w.Text = "";
                }
            }
        }

        private void SoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
