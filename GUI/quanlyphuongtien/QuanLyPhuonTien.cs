using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Sử dụng namespace BLL trực tiếp thay vì BLL.Quanlyphuongtien
using BLL;
using BLL.Quanlyphuongtien;
using Guna.UI2.WinForms;

namespace GUI.QuanLyPhuongTien
{
    public partial class QuanLyPhuonTien : Form
    {
        public string buildingID_ = "";
        public QuanLyPhuonTien(string buildingID)
        {
            InitializeComponent();
            LoadData();
            buildingID_ = buildingID;
        }


        private void LoadData()
        {
            try
            {



                // Tải các thông tin vào ComboBox ID Bãi Đậu
                string newParkingId = ParkingAreaBLL.GenerateNewParkingAreaId();
                guna2ComboBox1.Items.Clear();
                guna2ComboBox1.Items.Add(newParkingId);
                guna2ComboBox1.SelectedIndex = 0;
                guna2ComboBox1.Enabled = false;

                // Load danh sách tòa nhà với ID tự động tăng
                DataTable buildingTable = ParkingAreaBLL.GetAllBuildings();
                string newBuildingId = ParkingAreaBLL.GenerateNewBuildingId();

                // Thêm ID mới vào DataTable
                DataRow newRow = buildingTable.NewRow();
                newRow["BUILDINGID"] = newBuildingId;
                buildingTable.Rows.InsertAt(newRow, 0);



                // Tải các thông tin vào ComboBox ID Bãi Đậu - cách đơn giản hơn
                string newId = ParkingAreaBLL.GenerateNewParkingAreaId();
                guna2ComboBox1.Items.Clear();
                guna2ComboBox1.Items.Add(newId);
                guna2ComboBox1.SelectedIndex = 0;
                guna2ComboBox1.Enabled = false; // Không cho phép thay đổi



                // Load danh sách địa chỉ
                string[] locations = {
        "Tầng hầm B1",
        "Tầng hầm B2",
        "Khu vực sau tòa nhà",
        "Khu vực trước tòa nhà",
        "Khu vực bên hông",

    };
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.AddRange(locations);
                guna2ComboBox2.SelectedIndex = 0;

                // Load danh sách loại bãi đậu xe
                guna2ComboBox4.DataSource = ParkingAreaBLL.GetParkingTypes();
                guna2ComboBox4.DisplayMember = "Type";
                guna2ComboBox4.ValueMember = "Type";
                // Load danh sách sức chứa
                guna2ComboBox5.DataSource = ParkingAreaBLL.GetCapacityOptions();
                guna2ComboBox5.DisplayMember = "Capacity";
                guna2ComboBox5.ValueMember = "Capacity";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có item nào được chọn không
         
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyPhuonTien_Load(object sender, EventArgs e)
        {

        }

        private void buttonDangNhap1_Click(object sender, EventArgs e)
        {
            try
            {

                string address = guna2ComboBox2.Text;
                string type = guna2ComboBox4.SelectedValue.ToString();
                int capacity = int.Parse(guna2ComboBox5.Text);

                if (ParkingAreaBLL.AddParkingArea(buildingID_, address, type, capacity))
                {
                    MessageBox.Show("Thêm bãi đậu xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nếu form cha (quanlynha) được thiết lập
                    if (this.Owner is quanlynha ownerForm)
                    {
                        // Gọi phương thức RefreshParkingAreaData để tải lại dữ liệu
                        ownerForm.RefreshParkingAreaData();
                    }

                    // Reset các control về giá trị mặc định
                    guna2ComboBox2.SelectedIndex = 0;
                    guna2ComboBox4.SelectedIndex = 0;
                    guna2ComboBox5.SelectedIndex = 0;
                    // Đóng form sau khi thêm thành công
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm bãi đậu xe thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}