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
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Form_AddContract: Form
    {
        AccountBLL accountBLL;
        private string username;
        private int control;
        private string contractId;
        //private string row;
        private DataGridViewRow row;   
        public Form_AddContract(string username, int control, DataGridViewRow row)
        {
            this.username = username; 
            this.row = row;
            this.control = control;
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
                    accountBLL = new AccountBLL();
                    List<string> a = RoomBLL.RoomBLL_Load_RoomAddress(username);
                    foreach (string address in a)
                    {
                        DiaChiToaNha.Items.Add(address);
                    }
                    a = accountBLL.AccountBLL_Load_TenantName();
                    foreach (string name in a)
                    {
                        TenKhachHang.Items.Add(name);
                    }
                    break;
                case 1:
                    guna2DateTimePicker2.Enabled = false;


                    string info = ContractBLL.ContractBLL_alter_Contract(row.Cells["CONTRACTID"].Value.ToString());
                    Console.WriteLine(info);
                    string[] infos = info.Split('|');
                    contractId = infos[0];
                    DiaChiToaNha.Items.Add(infos[0]);
                    DiaChiToaNha.SelectedIndex = 0;

                    SoPhong.Items.Add(infos[1]);
                    SoPhong.SelectedIndex = 0;

                    TenKhachHang.Items.Add(infos[2]);
                    TenKhachHang.SelectedIndex = 0;

                    guna2DateTimePicker1.Value = DateTime.Parse(infos[3]);
                    guna2DateTimePicker2.Value = DateTime.Parse(infos[4]);
                    guna2DateTimePicker3.Value = DateTime.Parse(infos[5]);

                    LichThanhToan.Items.Clear();
                    LichThanhToan.Items.Add(infos[7]);
                    LichThanhToan.SelectedIndex = 0;

                    TienDatCoc.Text = infos[8];
                    GhiChu.Text = infos[9];

                    break;
            }
                
        }

        private void guna2ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SoPhong.Items.Clear();
            List<string> a = RoomBLL.RoomBLL_Load_RoomInBuilding(DiaChiToaNha.Text);
            foreach (string id in a)
            {
                SoPhong.Items.Add(id);
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
                    string result = ContractBLL.ContractBLL_add_Contract(
                    DiaChiToaNha.Text,
                    SoPhong.Text,
                    TenKhachHang.Text,
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
                    contractId,
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
