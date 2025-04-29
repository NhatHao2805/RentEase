using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_AddRoom : Form
    {
        RoomBLL roomBLL = new RoomBLL();
        quanlynha form;
        Room room = new Room();
        private string _username;
        private string _buildingid;
        public Form_AddRoom(string username, string buildingid)
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
                    case "property_type":
                        guna2HtmlLabel11.Text = a.Value;
                        break;
                    case "classification":
                        guna2HtmlLabel9.Text = a.Value;
                        break;
                    case "amenities":
                        guna2HtmlLabel5.Text = a.Value;
                        break;
                    case "area":
                        guna2HtmlLabel3.Text = a.Value;
                        break;
                    case "rent_price":
                        guna2HtmlLabel7.Text = a.Value;
                        break;
                    case "status":
                        guna2HtmlLabel1.Text = a.Value;
                        break;
                    case "status_options.occupied":
                        DangO_chbox.Text = a.Value;
                        break;
                    case "status_options.vacant":
                        DangTrong_chbox.Text = a.Value;
                        break;
                    case "status_options.owing":
                        DangNoTien_chbox.Text = a.Value;
                        break;
                    case "notification.ending":
                        DangKT_chbox.Text = a.Value;
                        break;
                    case "notification.reserved":
                        DangCoc_chbox.Text = a.Value;
                        break;
                    case "contract.expired":
                        DaHetHan_chbox.Text = a.Value;
                        break;
                    case "contract.near_expiry":
                        SapHetHan_chbox.Text = a.Value;
                        break;

                    case "room.add_title":
                        label23.Text = a.Value;
                        break;
                    case "room.add_subtitle":
                        label22.Text = a.Value;
                        break;
                    case "btn_save":
                        add_btn.Text = a.Value;
                        break;
                }
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            room.BuildingId = _buildingid;
            room.Type = Language.reverseTranslate(type_cb.Text);
            room.Floor = floor_cb.Text;
            room.Convenient = convenient_tb.Text;
            room.Price = price_tb.Text;
            room.Area = area_tb.Text;

            string status = (DangO_chbox.Checked ? Language.reverseTranslate(DangO_chbox.Text) + "; " : "")
              + (DangTrong_chbox.Checked ? Language.reverseTranslate(DangTrong_chbox.Text) + "; " : "")
              + (DangKT_chbox.Checked ? Language.reverseTranslate(DangKT_chbox.Text) + "; " : "")
              + (DangCoc_chbox.Checked ? Language.reverseTranslate(DangCoc_chbox.Text) + "; " : "")
              + (DaHetHan_chbox.Checked ? Language.reverseTranslate(DaHetHan_chbox.Text) + "; " : "")
              + (SapHetHan_chbox.Checked ? Language.reverseTranslate(SapHetHan_chbox.Text) + "; " : "")
              + (DangNoTien_chbox.Checked ? Language.reverseTranslate(DangNoTien_chbox.Text) : "");
            room.Status = status.TrimEnd(';', ' ');

            string check = roomBLL.CheckLogic(room);

            switch (check)
            {
                case "required_buildingid":
                    MessageBox.Show("Bạn chưa chọn tòa nhà");
                    return;
                case "required_floor":
                    MessageBox.Show("Bạn chưa chọn tầng");
                    return;
                case "required_type":
                    MessageBox.Show("Bạn chưa phân loại nhà");
                    return;
                case "required_area":
                    MessageBox.Show("Bạn chưa nhập diện tích");
                    return;
                case "invalid_area_format":
                    MessageBox.Show("Diện tích phòng không hợp lệ");
                    area_tb.Text = string.Empty;
                    room.Area = null;
                    return;
                case "area_too_large":
                    MessageBox.Show("Diện tích không được vượt quá 1000m2");
                    area_tb.Text = string.Empty;
                    room.Area = null;
                    return;
                case "required_price":
                    MessageBox.Show("Bạn chưa nhập giá thuê");
                    return;
                case "invalid_price_format":
                    MessageBox.Show("Giá phòng không hợp lệ");
                    price_tb.Text = string.Empty;
                    room.Price = null;
                    return;
                case "price_too_large":
                    MessageBox.Show("Giá thuê không được vượt quá 1 tỷ đồng");
                    price_tb.Text = string.Empty;
                    room.Price = null;
                    return;
                case "required_status":
                    MessageBox.Show("Bạn chưa chọn trạng thái");
                    return;
                case "Out range of number room of floor":
                    MessageBox.Show("Vượt quá số phòng của tầng");
                    return;
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Add Successfully":
                    MessageBox.Show("Thêm phòng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;

                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }
        private void UndoCheckBox()
        {
            DangO_chbox.Checked = false;
            DangTrong_chbox.Checked = false;
            DangNoTien_chbox.Checked = false;
            DangKT_chbox.Checked = false;
            DangCoc_chbox.Checked = false;
            DaHetHan_chbox.Checked = false;
            SapHetHan_chbox.Checked = false;

            room.Status = "";
        }
        private void Form_AddRoom_Load(object sender, EventArgs e)
        {
            floor_cb.Items.Clear();

            for (int i = 0; i <= RoomBLL.LoadFloorByBuildingID(_buildingid); i++)
            {
                floor_cb.Items.Add(i);
            }
            string[] a = {Language.translate("phongdon"),
                Language.translate("phongdoi"),
                Language.translate("phongthuong"),
                Language.translate("phongcaocap"),
                Language.translate("studio"),
                Language.translate("phongnguyencan")};
            foreach (string item in a)
            {
                type_cb.Items.Add(item);
            }



        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangO_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox.Checked)
            {
                DangTrong_chbox.Checked = false;
            }
        }

        private void DangTrong_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox.Checked)
            {
                DangO_chbox.Checked = false;
            }
        }

        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangCoc_chbox.Checked)
            {
                DangKT_chbox.Checked = false;
            }
        }

        private void DangKT_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangKT_chbox.Checked)
            {
                DangCoc_chbox.Checked = false;
            }
        }

        private void DaHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if(DaHetHan_chbox.Checked)
            {
                SapHetHan_chbox.Checked = false;
            }
        }

        private void SapHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SapHetHan_chbox.Checked)
            {
                DaHetHan_chbox.Checked = false;
            }
        }

        private void floor_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void convenient_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}