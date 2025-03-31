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
        }

        private void Form_UpdateRoom_Load(object sender, EventArgs e)
        {
            roomid_cb.Items.Clear();
            foreach (DataRow row in RoomBLL.LoadRoomIdByBuildingID(infor.BuildingId).Rows)
            {
                roomid_cb.Items.Add(row["ROOMID"].ToString());
            }

            buildingid_cb.Items.Clear();
            foreach (DataRow row in RoomBLL.LoadBuildingID(_username).Rows)
            {
                buildingid_cb.Items.Add(row["BUILDINGID"].ToString());
            }

            floor_cb.Items.Clear();

            for(int i = 0; i <= RoomBLL.LoadFloorByBuildingID(infor.BuildingId); i++)
            {
                floor_cb.Items.Add(i);
            }

            // Load loại phòng
            type_cb.Items.Add("Nhà trọ");
            type_cb.Items.Add("Chung cư 1 phòng ngủ");
            type_cb.Items.Add("Chung cư 2 phòng ngủ");

            // Hiển thị thông tin phòng lên các control
            roomid_cb.SelectedItem = infor.RoomId;
            buildingid_cb.SelectedItem = infor.BuildingId;
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

                    switch (trimmedStatus)
                    {
                        case "Sắp hết hạn hợp đồng":
                            SapHetHan_chbox.Checked = true;
                            break;
                        case "Đang cọc giữ chỗ":
                            DangCoc_chbox.Checked = true;
                            break;
                        case "Đã hết hạn hợp đồng":
                            DaHetHan_chbox.Checked = true;
                            break;
                        case "Đang báo kết thúc":
                            DangKT_chbox.Checked = true;
                            break;
                        case "Đang nợ tiền":
                            DangNoTien_chbox.Checked = true;
                            break;
                        case "Đang trống":
                            DangTrong_chbox.Checked = true;
                            break;
                        case "Đang ở":
                            DangO_chbox.Checked = true;
                            break;
                    }
                }
            }

            // Disable các field không được phép sửa
            roomid_cb.Enabled = false;
            buildingid_cb.Enabled = false;
            floor_cb.Enabled = false;
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            room.RoomId = infor.RoomId;
            room.BuildingId = buildingid_cb.Text;
            room.Type = type_cb.Text;
            room.Floor = floor_cb.Text;
            room.Convenient = convenient_tb.Text;
            room.Price = price_tb.Text;
            room.Area = area_tb.Text;

            string status = "";
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    status += checkBox.Text + "; ";
                }
            }
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
                case "required_price":
                    MessageBox.Show("Bạn chưa nhập giá thuê");
                    return;
                case "invalid_price_format":
                    MessageBox.Show("Giá phòng không hợp lệ\nVí dụ: 2000000 hoặc 3.500000");
                    price_tb.Text = string.Empty;
                    room.Price = null;
                    return;
                case "Không thể vừa 'Đang ở' vừa 'Đang trống'.":
                    MessageBox.Show("Không thể vừa 'Đang ở' vừa 'Đang trống'.");
                    UndoCheckBox();
                    return;
                case "Không thể vừa 'Đang trống' vừa 'Đang ở'.":
                    MessageBox.Show("Không thể vừa 'Đang trống' vừa 'Đang ở'.");
                    UndoCheckBox();
                    return;
                case "Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang báo kết thúc'.":
                    MessageBox.Show("Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang báo kết thúc'.");
                    UndoCheckBox();
                    return;
                case "Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.":
                    MessageBox.Show("Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.");
                    UndoCheckBox();
                    return;
                case "Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.":
                    MessageBox.Show("Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.");
                    UndoCheckBox();
                    return;
                case "Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồng'.":
                    MessageBox.Show("Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồngg'.");
                    UndoCheckBox();
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
            DangCoc_chbox.Checked = false;
            DaHetHan_chbox.Checked = false;
            SapHetHan_chbox.Checked = false;

            room.Status = "";
        }

        private void DangO_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DangTrong_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DangNoTien_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DangKT_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DaHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SapHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
