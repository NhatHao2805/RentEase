using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.honhathao;
using Guna.UI2.WinForms;
using System.IO;
using System.Runtime.InteropServices;
using BLL;
using DTO;

namespace GUI.BuildingManagement
{
    public partial class Form_Building : Form
    {
        // Define color constants
        private static readonly Color PRIMARY_COLOR = Color.FromArgb(0, 200, 160);
        private static readonly Color SECONDARY_COLOR = Color.White;
        private static readonly Color BACKGROUND_COLOR = Color.FromArgb(240, 240, 240);
        private static readonly Color SELECTION_COLOR = Color.FromArgb(231, 229, 255);
        private static readonly Color SELECTION_TEXT_COLOR = Color.FromArgb(71, 69, 94);
        private static readonly Color HOVER_COLOR = Color.FromArgb(0, 180, 140);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private extern static System.IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private Form_Login form1;
        private quanlynha form2;
        private bool isGridInitialized = false;
        private string selectedBuildingId = null;
        private Building building = new Building();

        public Form_Building(Form_Login form1)
        {
            InitializeComponent();
            this.form1 = form1;
            
            LoadBuildingData();

            this.guna2Panel1.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0x112, 0xf012, 0);
                }
            };

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
        }

        private void LoadBuildingData()
        {
            try
            {
                dgvBuildings.DataSource = BuildingBLL.LoadBuilding(form1.taikhoan.Username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading building data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                ClearInputFields();
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadBuildingData();
                return;
            }

            try
            {
                var data = BuildingBLL.LoadBuilding(form1.taikhoan.Username);
                var filteredRows = data.AsEnumerable()
                    .Where(row =>
                        (row.Field<string>("BUILDINGID")?.ToLower().Contains(searchText) == true) ||
                        (row.Field<string>("BUILDING_KEY")?.ToLower().Contains(searchText) == true) ||
                        (row.Field<string>("USERNAME")?.ToLower().Contains(searchText) == true) ||
                        (row.Field<string>("ADDRESS")?.ToLower().Contains(searchText) == true) ||
                        row.Field<int>("NUMOFFLOORS").ToString().Contains(searchText) ||
                        row.Field<int>("NUMOFROOMS").ToString().Contains(searchText));

                if (!filteredRows.Any())
                {
                    DataTable emptyTable = data.Clone();
                    dgvBuildings.DataSource = emptyTable;
                }
                else
                {
                    dgvBuildings.DataSource = filteredRows.CopyToDataTable();
                }
            }
            catch (Exception)
            {
                var emptyTable = BuildingBLL.LoadBuilding(form1.taikhoan.Username).Clone();
                dgvBuildings.DataSource = emptyTable;
            }
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            LoadBuildingData();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            ClearInputFields();
            tabControl.SelectedIndex = 0;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (txtBuildingKey.Text.Length > 20)
            {
                MessageBox.Show("Building Key không được vượt quá 20 ký tự");
                return;
            }

            building.BuildingKey = txtBuildingKey.Text;
            building.Username = form1.taikhoan.Username;
            building.Address = txtAddress.Text;
            building.NumOfFloors = (int)numFloors.Value;
            building.NumOfRooms = (int)numRooms.Value;

            string check = BuildingBLL.addBuilding(building);

            switch (check)
            {
                case "required_buildingkey":
                    MessageBox.Show("Bạn chưa nhập key cho tòa nhà");
                    return;
                case "buildingkey_too_long":
                    MessageBox.Show("Building Key không được vượt quá 20 ký tự");
                    return;
                case "required_address":
                    MessageBox.Show("Bạn chưa nhập địa chỉ");
                    return;
                case "invalid_floors":
                    MessageBox.Show("Số tầng không hợp lệ");
                    return;
                case "invalid_rooms":
                    MessageBox.Show("Số phòng không hợp lệ");
                    return;
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Add Successfully":
                    MessageBox.Show("Thêm tòa nhà thành công!");
                    this.DialogResult = DialogResult.OK;
                    LoadBuildingData();
                    tabControl.SelectedIndex = 0;
                    return;
                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }

        private void OnBackClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back to login?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                form1.Show();
            }
        }

        private void OnManageClick(object sender, EventArgs e)
        {
            if (selectedBuildingId != null)
            {
                MessageBox.Show($"Opening management for building {selectedBuildingId}");
                form2 = new quanlynha(form1, dgvBuildings.SelectedRows[0].Index);
                form2.Show();
                this.Hide();
            }
        }

        private void OnBuildingSelectionChanged(object sender, EventArgs e)
        {
            if (dgvBuildings.SelectedRows.Count > 0)
            {
                selectedBuildingId = dgvBuildings.SelectedRows[0].Cells["BuildingID"].Value?.ToString();
                btnManage.Enabled = true;
            }
            else
            {
                selectedBuildingId = null;
                btnManage.Enabled = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearInputFields()
        {
            txtBuildingKey.Clear();
            txtAddress.Clear();
            numFloors.Value = numFloors.Minimum;
            numRooms.Value = numRooms.Minimum;
        }
    }
}
