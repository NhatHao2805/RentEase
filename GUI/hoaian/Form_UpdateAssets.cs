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
    public partial class Form_UpdateAssets : Form
    {
        AssetBLL assetBLL = new AssetBLL();
        quanlynha form;
        Assets assets = new Assets();
        private string _username;
        private Assets infor;
        private string _buildingid;
        public Form_UpdateAssets(string username, Assets selectedAsset, string buildingid)
        {
            InitializeComponent();

            _username = username;
            infor = selectedAsset;
            _buildingid = buildingid;
        }

        private void Form_UpdateAssets_Load(object sender, EventArgs e)
        {
            roomid_cb.Items.Clear();
            roomid_cb.Items.Add(infor.RoomId);
            roomid_cb.SelectedValue = infor.RoomId;

            status_cb.Items.Clear();
            status_cb.Items.Add("Tốt");
            status_cb.Items.Add("Hư hỏng nhẹ");
            status_cb.Items.Add("Cần được sửa chữa/thay thế");
            status_cb.Items.Add("Đang sửa chữa");
            status_cb.Items.Add("Đang thay thế");

            // Hiển thị thông tin phòng lên các control
            roomid_cb.SelectedItem = infor.RoomId;
            assetId_tb.Text = infor.AssetId;
            assetName_tb.Text = infor.AssetName;
            price_tb.Text = infor.Price;
            DateTime result;
            if (DateTime.TryParse(infor.UseDate, out result))
            {
                useDate_dpk.Value = result;
            }
            status_cb.SelectedItem = infor.Status;


            // Disable các field không được phép sửa
            roomid_cb.Enabled = false;
            assetId_tb.Enabled = false;
            assetName_tb.Enabled = false;
            price_tb.Enabled = false;
            useDate_dpk.Enabled = false;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            assets.RoomId = infor.RoomId;
            assets.AssetId = assetId_tb.Text;
            assets.AssetName = assetName_tb.Text;
            assets.Price = price_tb.Text;
            assets.UseDate = useDate_dpk.Value.ToString("yyyy-MM-dd");
            assets.Status = status_cb.SelectedIndex.ToString();

            string check = AssetBLL.UpdateAsset(assets);

            switch (check)
            {
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
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Update Successfully":
                    MessageBox.Show("Sửa tài sản thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;

                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }

    }
}
