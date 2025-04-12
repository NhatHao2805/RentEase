using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI.honhathao
{
    public partial class Form_LoadAll: Form
    {
        public Form_LoadAll()
        {
            InitializeComponent();
            loadInfo(null);
        }

        private void loadInfo(string name)
        {
            DataTable dt = BLL.honhathao.TenantHistoryBLL.TenantHistoryBLL_load_AllTenantHistory(name);
            dgv_LSTN.DataSource = dt;
            dgv_LSTN.Columns[0].Width = 100;
            dgv_LSTN.Columns[1].Width = 100;
            dgv_LSTN.Columns[2].Width = 200;
            dgv_LSTN.Columns[3].Width = 100;
            dgv_LSTN.Columns[4].Width = 500;

            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "LoadAll.room_number":
                        dgv_LSTN.Columns[0].HeaderText = a.Value;

                        break;
                    case "LoadAll.tenant":
                        dgv_LSTN.Columns[1].HeaderText = a.Value;

                        break;
                    case "LoadAll.last_name":
                        dgv_LSTN.Columns[2].HeaderText = a.Value;
                        break;
                    case "LoadAll.first_name":
                        dgv_LSTN.Columns[3].HeaderText = a.Value;
                        break;
                    case "LoadAll.rating":
                        dgv_LSTN.Columns[4].HeaderText = a.Value;
                        break;
                    case "LoadAll.detail_title":
                        label23.Text = a.Value;
                        break;
                    case "LoadAll.detail_subtitle":
                        label22.Text = a.Value;
                        break;
                    case "LoadAll.placeholder":
                        guna2HtmlLabel3.Text = a.Value;
                        break;
                    case "LoadAll.button":
                        guna2Button1.Text = a.Value;
                        break;
                }
            }
        }
//        LoadAll.detail_title: Xem chi tiết
        //LoadAll.detail_subtitle: Xem chi tiết thanh toán
        //LoadAll.placeholder: Tìm kiếm theo tên
        //LoadAll.button: Tìm kiếm
        //LoadAll.room_number: Số phòng
        //LoadAll.tenant: Người Thuê
        //LoadAll.last_name: Họ
        //LoadAll.first_name: Tên
        //LoadAll.rating: Đánh giá

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
            loadInfo(guna2TextBox1.Text);
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
