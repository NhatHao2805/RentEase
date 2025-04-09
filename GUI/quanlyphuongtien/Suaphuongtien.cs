using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Quanlyphuongtien;

namespace GUI.QuanLyPhuongTien
{
    public partial class Suaphuongtien : Form
    {
        private string areaId;

        // Constructor mặc định
        public string buildingID_ = "";

        // Constructor nhận tham số areaId
        public Suaphuongtien(string areaId, string buildingID)
        {
            InitializeComponent();
            this.areaId = areaId;
            buildingID_ = buildingID;
        }

        private void Suaphuongtien_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có ID bãi đỗ xe
                if (string.IsNullOrEmpty(areaId))
                {
                    return;
                }

                // Lấy thông tin bãi đỗ xe
                DataTable allParkingAreas = ParkingAreaBLL.GetAllParkingAreas(buildingID_);
                DataRow[] rows = allParkingAreas.Select($"AREAID = '{areaId}'");

                if (rows.Length == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin bãi đỗ xe!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow currentData = rows[0];

                // Hiển thị ID bãi đỗ xe (chỉ đọc)
                guna2ComboBox1.Items.Add(areaId);
                guna2ComboBox1.SelectedIndex = 0;
                guna2ComboBox1.Enabled = false;

                // Tải danh sách tòa nhà
                DataTable buildings = ParkingAreaBLL.GetAllBuildings();


                // Tải danh sách địa chỉ
                string[] locations = {
                    "Tầng hầm B1",
                    "Tầng hầm B2",
                    "Khu vực sau tòa nhà",
                    "Khu vực trước tòa nhà",
                    "Khu vực bên hông"
                };

                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.AddRange(locations);

                // Tìm và chọn địa chỉ hiện tại
                string currentAddress = currentData["ADDRESS"].ToString();
                int addressIndex = Array.IndexOf(locations, currentAddress);
                if (addressIndex >= 0)
                {
                    guna2ComboBox2.SelectedIndex = addressIndex;
                }
                else
                {
                    // Nếu không tìm thấy, thêm địa chỉ hiện tại vào
                    guna2ComboBox2.Items.Add(currentAddress);
                    guna2ComboBox2.SelectedIndex = guna2ComboBox2.Items.Count - 1;
                }

                // Tải loại bãi đỗ xe
                guna2ComboBox4.Items.Clear();
                guna2ComboBox4.Items.Add("Xe máy");
                guna2ComboBox4.Items.Add("Ô tô");

                // Chọn loại hiện tại
                string currentType = currentData["TYPE"].ToString();
                if (currentType == "Xe máy")
                {
                    guna2ComboBox4.SelectedIndex = 0;
                }
                else if (currentType == "Ô tô")
                {
                    guna2ComboBox4.SelectedIndex = 1;
                }

                // Tải danh sách sức chứa
                guna2ComboBox5.Items.Clear();
                for (int i = 1; i <= 100; i++)
                {
                    guna2ComboBox5.Items.Add(i.ToString());
                }

                // Chọn sức chứa hiện tại
                int currentCapacity = Convert.ToInt32(currentData["CAPACITY"]);
                if (currentCapacity > 0 && currentCapacity <= 100)
                {
                    guna2ComboBox5.SelectedIndex = currentCapacity - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Xử lý sự kiện click nút Cập nhật
        private void buttonDangNhap1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các controls
                string currentAreaId = guna2ComboBox1.SelectedItem.ToString();

                string address = guna2ComboBox2.SelectedItem.ToString();
                string type = guna2ComboBox4.SelectedItem.ToString();
                int capacity = Convert.ToInt32(guna2ComboBox5.SelectedItem.ToString());

                // Gọi BLL để cập nhật
                if (ParkingAreaBLL.UpdateParkingArea(currentAreaId, buildingID_, address, type, capacity, out string message))
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

        // Các phương thức xử lý sự kiện đã có