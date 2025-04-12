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
    public partial class Form_AddParkingArea : Form
    {
        ParkingAreaBLL parkingAreaBLL = new ParkingAreaBLL();
        quanlynha form;
        ParkingArea area = new ParkingArea();
        private string _username;
        private string _buildingid;
        public Form_AddParkingArea(string username, string buildingid)
        {
            InitializeComponent();

            _username = username;
            _buildingid = buildingid;
        }

        private void add_btn_Click_1(object sender, EventArgs e)
        {
            area.BuildingId = _buildingid;
            area.Address = address_tb.Text;
            area.Type = type_cb.Text;
            area.Capacity = capacity_tb.Text;

            string check = ParkingAreaBLL.CheckLogic(area);

            switch (check)
            {
                case "required_address":
                    MessageBox.Show("Bạn chưa nhập địa chỉ");
                    return;
                case "required_type":
                    MessageBox.Show("Bạn chưa chọn loại bãi giữ xe");
                    return;
                case "required_capacity":
                    MessageBox.Show("Bạn chưa nhập sức chứa bãi giữ xe");
                    return;
                case "invalid_capacity_format":
                    MessageBox.Show("Sức chứa không hợp lệ");
                    capacity_tb.Text = string.Empty;
                    area.Capacity = null;
                    return;
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Add Successfully":
                    MessageBox.Show("Thêm bãi xe thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;

                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }

        private void Form_AddParkingArea_Load(object sender, EventArgs e)
        {
            type_cb.Items.Clear();
            type_cb.Items.Add("Xe ô tô");
            type_cb.Items.Add("Xe máy/Xe đạp");
            type_cb.Items.Add("Hỗn hợp");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
