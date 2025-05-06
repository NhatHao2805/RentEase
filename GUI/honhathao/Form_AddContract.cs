using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL;
using BLL.honhathao;
using Guna.UI2.WinForms;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Form_AddContract: Form
    {
        AccountBLL accountBLL;
        private string username;
        private int control;
        private string contractId;
        private int row;   
        private string buildingid;
        private DataGridView table;
        private DataGridView table_tenant;
        public Form_AddContract(string username, int control, int row,string buildingid,DataGridView table, DataGridView table_tenant)
        {
            this.username = username; 
            this.row = row;
            this.control = control;
            this.buildingid = buildingid;
            this.table = table;

            this.table_tenant = table_tenant;
            InitializeComponent(); 
            LoadInfo();
            loadLanguage();
            LichThanhToan.SelectedIndex = 0;

        }

        private void loadLanguage()
        {
            LichThanhToan.Items.Clear();
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "contract.add_title":
                        label23.Text = a.Value;
                        break;
                    case "contract.add_subtitle":

                        label22.Text = a.Value;
                        break;
                    case "contract.room_number":

                        guna2HtmlLabel14.Text = a.Value;
                        break;
                    case "contract.tenant_name":

                        guna2HtmlLabel16.Text = a.Value;
                        break;
                    case "contract.creation_date":

                        guna2HtmlLabel12.Text = a.Value;
                        break;
                    case "contract.start_date":

                        guna2HtmlLabel15.Text = a.Value;
                        break;
                    case "contract.end_date":

                        guna2HtmlLabel11.Text = a.Value;
                        break;
                    case "contract.monthly_rent":

                        guna2HtmlLabel2.Text = a.Value;
                        break;
                    case "contract.payment_schedule":
                        guna2HtmlLabel17.Text = a.Value;

                        break;
                    case "contract.deposit":

                        guna2HtmlLabel13.Text = a.Value;
                        break;
                    case "contract.notes":

                        guna2HtmlLabel18.Text = a.Value;
                        break;
                    case "btn_save":

                        saveButton.Text = a.Value;
                        break;
                    case "dauthang":

                        LichThanhToan.Items.Add(a.Value);
                        break;
                    case "cuoithang":

                        LichThanhToan.Items.Add(a.Value);
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

        private void LoadInfo()
        {
            
            guna2DateTimePicker1.Enabled = false;
            switch (control)
            {
                case 0:
                    for (int i = 0; i < table_tenant.Rows.Count; i++)
                    {                  
                        ListTenantID.Items.Add(table_tenant.Rows[i].Cells[0].Value.ToString() + ": " + table_tenant.Rows[i].Cells[1].Value.ToString()+ " " + table_tenant.Rows[i].Cells[2].Value.ToString());
                    }

                    guna2DateTimePicker1.Value = DateTime.Today;
                    guna2DateTimePicker2.Value = DateTime.Today;
                    guna2DateTimePicker3.Value = DateTime.Today;
                    SoPhong.Items.Clear();
                    List<string> a = RoomBLL.RoomBLL_Load_RoomAddress(buildingid);
                    foreach (string id in a)
                    {
                        SoPhong.Items.Add(id);
                    }

                    break;
                case 1:
                    guna2DateTimePicker2.Enabled = false;

                    SoPhong.Items.Clear();
                    SoPhong.Items.Add(table.Rows[row].Cells[1].Value.ToString());
                    SoPhong.SelectedIndex = 0;
                    SoPhong.Enabled = false;

                    ListTenantID.Items.Clear();
                    ListTenantID.Items.Add(table.Rows[row].Cells[2].Value.ToString() + ": " + table.Rows[row].Cells[3].Value.ToString() + " " + table.Rows[row].Cells[4].Value.ToString());
                    ListTenantID.SelectedIndex = 0;
                    ListTenantID.Enabled = false;

                    guna2DateTimePicker1.Value = DateTime.Parse(table.Rows[row].Cells[5].Value.ToString());
                    guna2DateTimePicker2.Value = DateTime.Parse(table.Rows[row].Cells[6].Value.ToString());
                    guna2DateTimePicker3.Value = DateTime.Parse(table.Rows[row].Cells[7].Value.ToString());

                    LichThanhToan.Items.Clear();
                    LichThanhToan.Items.Add(table.Rows[row].Cells[9].Value.ToString());
                    string[] ac = {Language.translate("dauthang"), Language.translate("cuoithang") };
                    foreach (string id in ac)
                    { 
                        if (!LichThanhToan.Items.Contains(id))
                        {
                            LichThanhToan.Items.Add(id);

                        }
                    }
                    TienDatCoc.Text = table.Rows[row].Cells[10].Value.ToString();
                    break;
            }
                
        }


        private void guna2ComboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            GiaThue.Text = RoomBLL.RoomBLL_TakePrice(SoPhong.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (control)
            {
                case 0:
                    if(ListTenantID.SelectedIndex > -1) {
                        if (guna2DateTimePicker2.Value > guna2DateTimePicker3.Value)
                        {
                            MessageBox.Show(Language.translate("invalid_"));
                            return;
                        }
                        if (!ContractBLL.Check_Contract(buildingid, table_tenant.Rows[ListTenantID.SelectedIndex].Cells[0].Value.ToString(), SoPhong.Text))
                        {
                            MessageBox.Show(Language.translate("invalid_"));

                            return;
                        }
                        string result = ContractBLL.ContractBLL_add_Contract(
                        buildingid,
                        SoPhong.Text,
                        table_tenant.Rows[ListTenantID.SelectedIndex].Cells[0].Value.ToString(),
                        guna2DateTimePicker1.Value.ToString("yyyy-MM-dd"),
                        guna2DateTimePicker2.Value.ToString("yyyy-MM-dd"),
                        guna2DateTimePicker3.Value.ToString("yyyy-MM-dd"),
                        Language.reverseTranslate(LichThanhToan.Text),
                        TienDatCoc.Text,
                        GhiChu.Text);
                        if (result == "Please fill all the fields")
                        {
                            MessageBox.Show(Language.translate("invalid_"));
                            return;
                        }
                        else if (result == "wrongDeposite")
                        {
                            MessageBox.Show(Language.translate("invalid_"));
                            return;
                        }
                        else
                        {
                            MessageBox.Show(Language.translate("success_"));
                        }

                        this.Close();
                    }
                    else {
                        MessageBox.Show(Language.translate("invalid_"));
                        return;
                    }


                        break;
                case 1:
                    if (guna2DateTimePicker2.Value > guna2DateTimePicker3.Value)
                    {
                        MessageBox.Show(Language.translate("invalid_"));
                        return;
                    }
                    string result1 = ContractBLL.ContractBLL_update_Contract(
                    table.Rows[row].Cells[0].Value.ToString(),
                    guna2DateTimePicker3.Value.ToString("yyyy-MM-dd"),
                    Language.reverseTranslate(LichThanhToan.Text),
                    TienDatCoc.Text,
                    GhiChu.Text);
                    if (result1 == "Please fill all the fields")
                    {
                        MessageBox.Show(Language.translate("invalid_"));
                        return;
                    }else if(result1 == "wrongDeposite")
                    {
                        MessageBox.Show(Language.translate("invalid_"));
                        return;
                    }
                    else
                    {
                        MessageBox.Show(Language.translate("success_"));
                    }
                    this.Close();
                    break;

            }
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TienDatCoc_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
