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
            loadLanguage();
        }

        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "building_management":
                        label1.Text = a.Value;
                        break;
                    case "building_management_subtitle":
                        label22.Text = a.Value;
                        break;
                    case "building_section":
                        btn_quanlynha.Text = a.Value;
                        break;
                    case "add_building_btn":
                        btn_themnha.Text = a.Value;
                        break;
                    case "refresh_btn":
                        btnRefresh.Text = a.Value;
                        break;
                    case "manage_btn":
                        btnManage.Text = a.Value;
                        break;
                    case "btn_quaylai":
                        btnBack.Text = a.Value;
                        break;
                    case "add_key":
                        guna2Button5.Text = a.Value;
                        break;

                    case "search":
                        txtSearch.PlaceholderText = a.Value;
                        break;

                    case "building_key":
                        lblBuildingKey.Text = a.Value;
                        break;
                    case "building_address":
                        lblAddress.Text = a.Value;
                        break;
                    case "num_of_floors":
                        lblFloors.Text = a.Value;
                        break;
                    case "num_of_rooms":
                        lblNumRooms.Text = a.Value;
                        break;
                    case "btn_save":
                        btnSave.Text = a.Value;
                        break;
                    case "btn_cancel":
                        btnCancel.Text = a.Value;
                        break;

                    case "buildingtable_buildingid":
                        dgvBuildings.Columns["BuildingID"].HeaderText = a.Value;
                        break;
                    case "buildingtable_buildingkey":
                        dgvBuildings.Columns["Building_Key"].HeaderText = a.Value;
                        break;
                    case "buildingtable_username":
                        dgvBuildings.Columns["UserName"].HeaderText = a.Value;
                        break;
                    case "buildingtable_address":
                        dgvBuildings.Columns["Address"].HeaderText = a.Value;
                        break;
                    case "buildingtable_numoffloors":
                        dgvBuildings.Columns["NumOfFloors"].HeaderText = a.Value;
                        break;
                    case "buildingtable_numofrooms":
                        dgvBuildings.Columns["NumofRooms"].HeaderText = a.Value;
                        break;
                        //search: Tìm kiếm
                }
            }
        }
        private void LoadBuildingData()
        {
            try
            {
                dgvBuildings.DataSource = BuildingBLL.LoadBuilding(form1.taikhoan.Username);
                dgvBuildings.ScrollBars = ScrollBars.Both;
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
            this.Hide();
            form1.Show();
        }

        private void OnManageClick(object sender, EventArgs e)
        {
            if (selectedBuildingId != null)
            {
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

        private void dgvBuildings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void btn_csvc_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void Form_Building_Load(object sender, EventArgs e)
        {

            btn_quanlynha.Checked = true;


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(KeyBLL.add_Key(form1.taikhoan.Username, guna2TextBox3.Text));
            LoadBuildingData();
            guna2TextBox3.Text = "";
        }
    }
}
