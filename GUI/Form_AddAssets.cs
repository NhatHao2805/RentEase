using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_AddAssets : Form
    {
        AssetBLL assetBLL = new AssetBLL();
        quanlynha form;
        Assets assets = new Assets();
        private string _username;
        public Form_AddAssets(string username)
        {
            InitializeComponent();

            _username = username;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            assets.RoomId = roomid_cb.Text;
            assets.AssetName = name_tb.Text;
            assets.Price = price_tb.Text;
            assets.UseDate = useDate_dtp.Value.ToString("yyyy-MM-dd");
            assets.Status = status_cb.Text;

            string check = AssetBLL.CheckLogic(assets);

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
            buildingid_cb.Items.Clear();

            foreach (DataRow row in AssetBLL.LoadBuildingID(_username).Rows)
            {
                buildingid_cb.Items.Add(row["BUILDINGID"].ToString());
            }

            status_cb.Items.Clear();
            status_cb.Items.Add("Tốt");
            status_cb.Items.Add("Hư hỏng nhẹ");
            status_cb.Items.Add("Cần được sửa chữa/thay thế");
            status_cb.Items.Add("Đang sửa chữa");
            status_cb.Items.Add("Đang thay thế");
        }

        private void buildingid_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomid_cb.Items.Clear();

            foreach (DataRow row in AssetBLL.LoadRoomID(buildingid_cb.SelectedItem.ToString()).Rows)
            {
                roomid_cb.Items.Add(row["ROOMID"].ToString());
            }
        }
    }
}
