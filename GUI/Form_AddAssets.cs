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
        AssetsBLL assetBLL = new AssetsBLL();
        QuanLyNha form;
        Assets asset = new Assets();

        public Form_AddAssets()
        {
            InitializeComponent();
        }

        private void Form_AddAssets_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            status_cb.Items.Add("Mới");
            status_cb.Items.Add("Đã qua sử dụng");
            status_cb.SelectedIndex = 0;

            roomID_cb.DataSource = assetBLL.GetRoomID();
            roomID_cb.DisplayMember = "ROOMID";
            roomID_cb.ValueMember = "ROOMID";
            roomID_cb.SelectedIndex = -1;

            price_tb.KeyPress += number_KeyPress;
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void selectAll_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string check = assetBLL.CheckLogic(asset);

            switch (check)
            {
                case "required_assetid":
                    MessageBox.Show("Bạn chưa nhập mã tài sản");
                    return;
                case "required_roomid":
                    MessageBox.Show("Bạn chưa nhập mã phòng");
                    return;
                case "required_assetname":
                    MessageBox.Show("Bạn chưa nhập tên tài sản");
                    return;
                case "required_price":
                    MessageBox.Show("Bạn chưa nhập giá");
                    return;
                case "Đã xảy ra lỗi khi thêm!":
                    MessageBox.Show("Đã xảy ra lỗi khi thêm!");
                    return;
                case "Tài sản đã tồn tại!":
                    MessageBox.Show("Phòng đã tồn tại!");
                    return;
                case "Thêm thành công!":
                    MessageBox.Show("Thêm thành công");
                    form = new QuanLyNha();
                    form.Show();
                    this.Hide();
                    return;
            }
        }

        private void roomID_chlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
