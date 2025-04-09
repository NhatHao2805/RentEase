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
        }


        private void add_btn_Click(object sender, EventArgs e)
        {
            room.BuildingId = _buildingid;
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
                case "Out range of number room of floor":
                    MessageBox.Show("Vượt quá số phòng của tầng");
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

            type_cb.Items.Add("Nhà trọ");
            type_cb.Items.Add("Chung cư 1 phòng ngủ");
            type_cb.Items.Add("Chung cư 2 phòng ngủ");

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}