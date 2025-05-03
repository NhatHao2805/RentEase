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
    public partial class Form_UpdateRoom : Form
    {
        RoomBLL roomBLL = new RoomBLL();
        quanlynha form;
        Room room = new Room();
        private string _username;
        private Room infor;
        public Form_UpdateRoom(string username, Room selectedRoom)
        {
            InitializeComponent();

            _username = username;
            infor = selectedRoom;
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "roomtable_building":
                        guna2HtmlLabel14.Text = a.Value;
                        break;
                    case "property_type":
                        guna2HtmlLabel13.Text = a.Value;
                        break;
                    case "classification":
                        guna2HtmlLabel12.Text = a.Value;
                        break;
                    case "amenities":
                        guna2HtmlLabel11.Text = a.Value;
                        break;
                    case "area":
                        guna2HtmlLabel9.Text = a.Value;
                        break;
                    case "rent_price":
                        guna2HtmlLabel7.Text = a.Value;
                        break;
                    case "status":
                        guna2HtmlLabel3.Text = a.Value;
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
                    //case "notification.reserved":
                    //    DangCoc_chbox.Text = a.Value;
                    //    break;
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
                        Update_btn.Text = a.Value;
                        break;
                }
            }
        }

        private void Form_UpdateRoom_Load(object sender, EventArgs e)
        {
            roomid_cb.Items.Clear();
            foreach (DataRow row in RoomBLL.LoadRoomIdByBuildingID(infor.BuildingId).Rows)
            {
                roomid_cb.Items.Add(row["ROOMNAME"].ToString());
            }

            floor_cb.Items.Clear();

            for(int i = 0; i <= RoomBLL.LoadFloorByBuildingID(infor.BuildingId); i++)
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
                if (!type_cb.Items.Contains(item))
                {
                    type_cb.Items.Add(item);
                }
            }

            // Hiển thị thông tin phòng lên các control
            roomid_cb.SelectedItem = infor.RoomId;
            type_cb.SelectedItem = infor.Type;
            floor_cb.SelectedItem = Convert.ToInt32(infor.Floor);
            area_tb.Text = infor.Area;
            price_tb.Text = infor.Price;
            convenient_tb.Text = infor.Convenient;

            // Xử lý trạng thái (status) - phân tích chuỗi trạng thái và check vào các checkbox tương ứng
            if (!string.IsNullOrEmpty(infor.Status))
            {
                string[] statuses = infor.Status.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string status in statuses)
                {
                    string trimmedStatus = status.Trim();
                    switch (Language.reverseTranslate(trimmedStatus))
                    {
                        case "saphethanhopdong":
                            SapHetHan_chbox.Checked = true;
                            break;
                        //case "dangcocgiucho":
                        //    DangCoc_chbox.Checked = true;
                        //    break;
                        case "daquahanhopdong":
                            DaHetHan_chbox.Checked = true;
                            break;
                        case "dangbaoketthuc":
                            DangKT_chbox.Checked = true;
                            break;
                        case "dangnotien":
                            DangNoTien_chbox.Checked = true;
                            break;
                        case "dangtrong":
                            DangTrong_chbox.Checked = true;
                            break;
                        case "dango":
                            DangO_chbox.Checked = true;
                            break;
                    }
                }
            }

            // Disable các field không được phép sửa
            roomid_cb.Enabled = false;
            floor_cb.Enabled = false;
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            room.RoomId = infor.RoomId;
            room.BuildingId = infor.BuildingId;
            room.Type = Language.reverseTranslate(type_cb.Text);
            room.Floor = floor_cb.Text;
            room.Convenient = convenient_tb.Text;
            room.Price = price_tb.Text;
            room.Area = area_tb.Text;

            string status = (DangO_chbox.Checked ? Language.reverseTranslate(DangO_chbox.Text) + "; " : "")
              + (DangTrong_chbox.Checked ? Language.reverseTranslate(DangTrong_chbox.Text) + "; " : "")
              + (DangKT_chbox.Checked ? Language.reverseTranslate(DangKT_chbox.Text) + "; " : "")
              //+ (DangCoc_chbox.Checked ? Language.reverseTranslate(DangCoc_chbox.Text) + "; " : "")
              + (DaHetHan_chbox.Checked ? Language.reverseTranslate(DaHetHan_chbox.Text) + "; " : "")
              + (SapHetHan_chbox.Checked ? Language.reverseTranslate(SapHetHan_chbox.Text) + "; " : "")
              + (DangNoTien_chbox.Checked ? Language.reverseTranslate(DangNoTien_chbox.Text) : "");
            room.Status = status.TrimEnd(';', ' ');

            string check = RoomBLL.UpdateRoom(room);

            switch (check)
            {
                case "required_area":
                    MessageBox.Show("Bạn chưa nhập diện tích");
                    return;
                case "invalid_area_format":
                    MessageBox.Show("Diện tích phòng không hợp lệ\nVí dụ: 20 hoặc 35.75");
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
                    MessageBox.Show("Giá phòng không hợp lệ\nVí dụ: 2000000 hoặc 3.500000");
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
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Update Successfully":
                    MessageBox.Show("Sửa phòng thành công!");
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
            //DangCoc_chbox.Checked = false;
            DaHetHan_chbox.Checked = false;
            SapHetHan_chbox.Checked = false;

            room.Status = "";
        }

        private void floor_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
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

        private void DangKT_chbox_CheckedChanged(object sender, EventArgs e)
        {
            //if (DangKT_chbox.Checked)
            //{
            //    DangCoc_chbox.Checked = false;
            //}
        }

//        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
//        {
//            if(DangCoc_chbox.Checked)
//{
//                DangKT_chbox.Checked = false;
//            }
//        }

        private void DaHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DaHetHan_chbox.Checked)
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
    }
}
