using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
                    for (int i = 0; i < table_tenant.Rows.Count - 1; i++)
                    {                  
                        ListTenantID.Items.Add(table_tenant.Rows[i].Cells[0].Value.ToString() + ": " + table_tenant.Rows[i].Cells[1].Value.ToString()+ " " + table_tenant.Rows[i].Cells[2].Value.ToString());
                    }

                    guna2DateTimePicker1.Value = DateTime.Today;
                    guna2DateTimePicker2.Value = DateTime.Today;
                    guna2DateTimePicker3.Value = DateTime.Today;
                    SoPhong.Items.Clear();
                    List<string> a = RoomBLL.RoomBLL_Load_RoomInBuilding(buildingid);
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
                    LichThanhToan.SelectedIndex = 0;
                    LichThanhToan.Enabled = false;

                    TienDatCoc.Text = table.Rows[row].Cells[10].Value.ToString();
                    GhiChu.Text = table.Rows[row].Cells[11].Value.ToString();

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
                // buildingid,  RoomId,  Tenantid,  CreateDate,  StartDate,  EndDate,  PaymenSchedule,  Deposite,  Note
                case 0:
                    string result = ContractBLL.ContractBLL_add_Contract(
                    buildingid,
                    SoPhong.Text,
                    table_tenant.Rows[ListTenantID.SelectedIndex].Cells[0].Value.ToString(),
                    guna2DateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    guna2DateTimePicker2.Value.ToString("yyyy-MM-dd"),
                    guna2DateTimePicker3.Value.ToString("yyyy-MM-dd"),
                    LichThanhToan.Text,
                    TienDatCoc.Text,
                    GhiChu.Text);
                    if(result == "Please fill all the fields")
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                        return;
                    }
                    else { 
                            MessageBox.Show(result);
                    }
                    this.Close();
                    break;
                case 1:
                    string result1 = ContractBLL.ContractBLL_update_Contract(
                    table.Rows[row].Cells[0].Value.ToString(),
                    guna2DateTimePicker3.Value.ToString("yyyy-MM-dd"),
                    LichThanhToan.Text,
                    TienDatCoc.Text,
                    GhiChu.Text);
                    if (result1 == "Please fill all the fields")
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                        return;
                    }
                    else
                    {
                        MessageBox.Show(result1);
                    }
                    this.Close();
                    break;

            }
        }
    }
}
