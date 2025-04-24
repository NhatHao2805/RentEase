using BLL;
using BLL.honhathao;
using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.honhathao
{
    public partial class Form_Registration: Form
    {
        int row;
        string buildingid;
        int control;
        private DataGridView table;
        private DataGridView tenant;
        public Form_Registration(int row, string buildingid, int control,DataGridView table, DataGridView tenant)
        {
            //1, listBuildingID.Text, 0, dgv_DKLT, dgv_Tenant
            InitializeComponent();
            this.row = row;
            this.control = control;
            this.buildingid = buildingid;
            this.table = table;
            this.tenant = tenant;
            loadInfo();
        }

        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "registration.title":
                        label23.Text = a.Value;
                        break;
                    case "registration.subtitle":
                        label22.Text = a.Value;
                        break;
                    case "registration.customer_name":
                        guna2HtmlLabel10.Text = a.Value;
                        break;
                    case "registration.room_code":
                        guna2HtmlLabel9.Text = a.Value;
                        break;
                    case "registration.start_date":
                        guna2HtmlLabel8.Text = a.Value;
                        break;
                    case "registration.end_date":
                        guna2HtmlLabel6.Text = a.Value;
                        break;
                    case "registration.status":
                        guna2HtmlLabel7.Text = a.Value;
                        break;
                    case "registration.save_button":
                        luu.Text = a.Value;
                        break;


                }
            }
        }



        private void loadInfo()
        {
            TrangThai.Items.Clear();
            TrangThai.Items.Add(Language.translate("dangcho"));
            TrangThai.Items.Add(Language.translate("daduyet"));
            switch (control)
            {
                case 0:
                    for(int i = 0 ; i < tenant.Rows.Count ; i++)
                    {
                        TenKhachHang.Items.Add(tenant.Rows[i].Cells[0].Value.ToString() + ": " + tenant.Rows[i].Cells[1].Value.ToString() + " " + tenant.Rows[i].Cells[2].Value.ToString());                     
                    }
                    List<string> a = RoomBLL.RoomBLL_Load_RoomInBuilding_2(buildingid);
                    foreach (string id in a)
                    {
                        SoPhong.Items.Add(id);
                    }
                    //TenKhachHang.SelectedIndex = 0;
                    //SoPhong.SelectedIndex = 0;
                    //TrangThai.SelectedIndex = 0;
                    break;
                case 1:
                    TenKhachHang.Items.Clear();
                    TenKhachHang.Items.Add(table.Rows[row].Cells[2].Value.ToString() + ": " + table.Rows[row].Cells[3].Value.ToString() + " " + table.Rows[row].Cells[4].Value.ToString());
                    TenKhachHang.SelectedIndex = 0;

                    SoPhong.Items.Clear();
                    SoPhong.Items.Add(table.Rows[row].Cells[1].Value.ToString());
                    SoPhong.SelectedIndex = 0;


                    try
                    {
                        ngayDk.Value = DateTime.Parse(table.Rows[row].Cells[5].Value.ToString());
                        ngayHethan.Value = DateTime.Parse(table.Rows[row].Cells[6].Value.ToString());
                    }catch (Exception ex)
                    {
                        //MessageBox.Show("Lỗi");
                    }
                    string[] tmp = { Language.translate("dangcho"), Language.translate("daduyet") };
                    
                    TrangThai.Items.Clear();
                    TrangThai.Items.Add(table.Rows[row].Cells[7].Value.ToString());
                    foreach(string eace in tmp)
                    {
                        if (eace != table.Rows[row].Cells[7].Value.ToString())
                        {
                            TrangThai.Items.Add(eace);
                        }
                    }
                    TrangThai.SelectedIndex = 0;


                    break;
            }
            
            loadLanguage();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void luu_Click(object sender, EventArgs e)
        {
            switch (control)
            {
                case 0:
                    string result = RegistrationBLL.RegistrationBLL_add_Registration(
                        tenant.Rows[TenKhachHang.SelectedIndex].Cells[0].Value.ToString(),
                        SoPhong.Text,
                        ngayDk.Value.ToString("yyyy-MM-dd"),
                        ngayHethan.Value.ToString("yyyy-MM-dd"),
                        Language.reverseTranslate(TrangThai.Text),
                        buildingid);
                    
                    MessageBox.Show(result);
                    if(result == "Success")
                    {
                        this.Close();
                    }
                    break;
                case 1:
                    string result1 = RegistrationBLL.RegistratrionBLL_update_registration(
                        table.Rows[row].Cells[0].Value.ToString(),
                        Language.reverseTranslate(TrangThai.Text));
                    if (result1 == "Success")
                    {
                        MessageBox.Show("Cập nhật thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                   
                    }
                    break;
            }
        }

        private void TrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
