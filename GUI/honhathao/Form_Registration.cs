using BLL;
using BLL.honhathao;
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
    public partial class Form_Registration: Form
    {
        int row;
        string buildingid;
        int control;
        private DataGridView table;
        private DataGridView tenant;
        public Form_Registration(int row, string buildingid, int control,DataGridView table, DataGridView tenant)
        {
            InitializeComponent();
            this.row = row;
            this.control = control;
            this.buildingid = buildingid;
            this.table = table;
            this.tenant = tenant;
            loadInfo();
        }

        private void loadInfo()
        {
            switch(control)
            {
                case 0:
                    for(int i = 0 ; i < table.Rows.Count - 1; i++)
                    {
                        TenKhachHang.Items.Add(tenant.Rows[i].Cells[0].Value.ToString() + ": " + tenant.Rows[i].Cells[1].Value.ToString() + " " + tenant.Rows[i].Cells[2].Value.ToString());                     
                    }
                    List<string> a = RoomBLL.RoomBLL_Load_RoomInBuilding(buildingid);
                    foreach (string id in a)
                    {
                        SoPhong.Items.Add(id);
                    }
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
                    string[] tmp = { "Đang chờ", "Đã duyệt" };
                    
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
                        TrangThai.Text);
                    if (result == "Success")
                    {
                        MessageBox.Show("Thêm thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    break;
                case 1:
                    string result1 = RegistrationBLL.RegistratrionBLL_update_registration(
                        table.Rows[row].Cells[0].Value.ToString(),
                        TrangThai.Text);
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
    }
}
