using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class Form_AddAssets : Form
    {
        AssetBLL assetBLL = new AssetBLL();
        quanlynha form;
        Assets assets = new Assets();
        private string _username;
        private string _buildingid;
        public Form_AddAssets(string username, string buildingid)
        {
            InitializeComponent();

            _username = username;
            _buildingid = buildingid;
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "room_code":
                        guna2HtmlLabel5.Text = a.Value;
                        break;
                    case "asset_name":
                        guna2HtmlLabel4.Text = a.Value;
                        break;
                    case "asset_value":
                        guna2HtmlLabel3.Text = a.Value;
                        break;
                    case "usage_period":
                        guna2HtmlLabel6.Text = a.Value;
                        break;
                    case "status":
                        guna2HtmlLabel7.Text = a.Value;
                        break;
                    case "btn_save":
                        add_btn.Text = a.Value;
                        break;
                    case " asset.detail_title":
                        label23.Text = a.Value;
                        break;
                    case "asset.detail_description":
                        label22.Text = a.Value;
                        break;
                }
            }

        }


        private void add_btn_Click(object sender, EventArgs e)
        {
            assets.RoomId = roomid_cb.Text;
            assets.AssetName = name_tb.Text;
            assets.Price = price_tb.Text;
            assets.UseDate = useDate_dtp.Value.ToString("yyyy-MM-dd");
            assets.Status = status_cb.Text;

            string check = AssetBLL.CheckLogic(assets, _buildingid);

            switch (check)
            {
                case "required_roomid":
                    MessageBox.Show("Bạn chưa chọn phòng");
                    return;
                case "required_assetname":
                    MessageBox.Show("Bạn chưa nhập tên tài sản");
                    return;
                case "required_price":
                    MessageBox.Show("Bạn chưa nhập giá trị tài sản");
                    return;
                case "invalid_price_format":
                    MessageBox.Show("Giá trị tài sản không hợp lệ\nVí dụ: 2000000 hoặc 3.500000");
                    price_tb.Text = string.Empty;
                    assets.Price = null;
                    return;
                case "required_status":
                    MessageBox.Show("Bạn chưa chọn tình trạng tài sản");
                    return;
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Add Successfully":
                    MessageBox.Show("Thêm tài sản thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;

                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }

        private void Form_AddAssets_Load(object sender, EventArgs e)
        {

            roomid_cb.Items.Clear();

            foreach (DataRow row in AssetBLL.LoadRoomID(_buildingid).Rows)
            {
                roomid_cb.Items.Add(row["ROOMID"].ToString());
            }

            status_cb.Items.Clear();
            status_cb.Items.Add("Tốt");
            status_cb.Items.Add("Hư hỏng nhẹ");
            status_cb.Items.Add("Cần được sửa chữa/thay thế");
            status_cb.Items.Add("Đang sửa chữa");
            status_cb.Items.Add("Đang thay thế");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
