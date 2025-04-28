using System.Globalization;
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
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "room_code":
                        guna2HtmlLabel9.Text = a.Value;
                        break;
                    case "asset_code":
                        guna2HtmlLabel11.Text = a.Value;
                        break;
                    case "asset_name":
                        guna2HtmlLabel5.Text = a.Value;
                        break;
                    case "asset_value":
                        guna2HtmlLabel4.Text = a.Value;
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
                    case "asset.update_title":
                        label23.Text = a.Value;
                        break;
                    case "asset.update_subtitle":
                        label22.Text = a.Value;
                        break;
//                        asset.update_title: Cập nhật tài sản
//asset.update_subtitle: Cập nhật tài sản của bạn
                }
            }

        }

        private void Form_UpdateAssets_Load(object sender, EventArgs e)
        {
            roomid_cb.Items.Clear();
            roomid_cb.Items.Add(infor.RoomId);
            roomid_cb.SelectedValue = infor.RoomId;

            status_cb.Items.Clear();
            status_cb.Items.Add(infor.Status);

            string[] status = { Language.translate("tot"), Language.translate("huhongnhe"), Language.translate("canduocsuachua/thaythe"), Language.translate("dangsuachua"), Language.translate("dangthaythe") };
            foreach (string s in status)
            {
                if (!status_cb.Items.Contains(s))
                {
                    status_cb.Items.Add(s);
                }
            }

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
            useDate_dpk.Enabled = false;
        }

        private void price_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(price_tb.Text))
                return;

            string value = price_tb.Text.Replace(",", "").Replace("VND", "").Trim();

            if (decimal.TryParse(value, out decimal number))
            {
                if (!price_tb.Text.EndsWith("VND"))
                {
                    price_tb.TextChanged -= price_tb_TextChanged;
                    price_tb.Text = string.Format("{0:N0} VND", number);
                    price_tb.SelectionStart = price_tb.Text.Length - 4;
                    price_tb.TextChanged += price_tb_TextChanged;
                }
            }
        }

        private void price_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            assets.RoomId = infor.RoomId;
            assets.AssetId = assetId_tb.Text;
            assets.AssetName = assetName_tb.Text;
            assets.Price = price_tb.Text;
            assets.UseDate = useDate_dpk.Value.ToString("yyyy-MM-dd");
            assets.Status = Language.reverseTranslate(status_cb.SelectedItem.ToString());

            string check = AssetBLL.UpdateAsset(assets, _buildingid);

            switch (check)
            {
                case "required_assetname":
                    MessageBox.Show("Bạn chưa nhập tên tài sản");
                    return;
                case "required_price":
                    MessageBox.Show("Bạn chưa nhập giá trị tài sản");
                    return;
                case "invalid_price_format":
                    MessageBox.Show("Giá trị tài sản không hợp lệ\nVui lòng nhập số");
                    price_tb.Text = string.Empty;
                    assets.Price = null;
                    return;
                case "price_out_of_range":
                    MessageBox.Show("Giá trị tài sản phải từ 1,000 VND đến 1,000,000,000 VND");
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
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
