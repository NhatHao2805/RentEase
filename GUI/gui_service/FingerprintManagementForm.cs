// GUI.gui_service/FingerprintManagementForm.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.gui_service
{
    public partial class FingerprintManagementForm : Form
    {
        private FingerprintBLL fingerprintBLL;
        private string currentUsername;
        private string currentBuildingID;
        private string selectedImagePath = null;
        private Dictionary<int, string> areaIdMapping = new Dictionary<int, string>();

        public FingerprintManagementForm(string username, string buildingID)
        {
            InitializeComponent();
            fingerprintBLL = new FingerprintBLL();
            currentUsername = username;
            currentBuildingID = buildingID;

            // Trong constructor hoặc phương thức Load của form
            dgvFingerprints.SelectionChanged += dgvFingerprints_SelectionChanged;
            // Hoặc
            dgvFingerprints.CellClick += dgvFingerprints_CellClick;
        }

        private void FingerprintManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách người thuê để đăng ký vân tay
                LoadTenantCombobox();

                // Load danh sách khu vực truy cập
                LoadAccessAreas();

                // Load danh sách vân tay đã đăng ký
                LoadFingerprintList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFingerprintList()
        {
            try
            {
                DataTable fingerprints = fingerprintBLL.GetFingerprintsList(currentUsername);
                dgvFingerprints.DataSource = fingerprints;

                // Thiết lập hiển thị các cột
                if (fingerprints != null && fingerprints.Columns.Count > 0)
                {
                    dgvFingerprints.Columns["FINGERID"].HeaderText = "Mã vân tay";
                    dgvFingerprints.Columns["TENANTID"].HeaderText = "Mã người thuê";
                    dgvFingerprints.Columns["FIRSTNAME"].HeaderText = "Tên";
                    dgvFingerprints.Columns["LASTNAME"].HeaderText = "Họ";
                    dgvFingerprints.Columns["AREAPERMISSION"].HeaderText = "Quyền truy cập";
                    dgvFingerprints.Columns["ENROLLMENT_DATE"].HeaderText = "Ngày đăng ký";

                    // Ẩn một số cột
                    dgvFingerprints.Columns["USERNAME"].Visible = false;
                    if (fingerprints.Columns.Contains("IMAGE_NAME"))
                    {
                        dgvFingerprints.Columns["IMAGE_NAME"].HeaderText = "Tên ảnh";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vân tay: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // GUI.gui_service/FingerprintManagementForm.cs
        private void LoadTenantCombobox()
        {
            try
            {
                // Lấy danh sách người thuê liên quan đến tòa nhà đã chọn
                List<TenantDTO> tenants = fingerprintBLL.GetTenants(currentUsername, currentBuildingID);

                if (tenants != null && tenants.Count > 0)
                {
                    cboTenants.DataSource = tenants;
                    cboTenants.DisplayMember = "ToString";
                    cboTenants.ValueMember = "TenantID";
                }
                else
                {
                    cboTenants.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người thuê: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccessAreas()
        {
            try
            {
                // Lấy danh sách các khu vực có thể truy cập
                checkedListAreas.Items.Clear();
                areaIdMapping.Clear();

                List<AreaPermissionDTO> areas = fingerprintBLL.GetAvailableAreas(currentBuildingID);

                if (areas != null && areas.Count > 0)
                {
                    int index = 0;
                    foreach (var area in areas)
                    {
                        checkedListAreas.Items.Add($"{area.AreaName} - {area.Description}", false);
                        areaIdMapping.Add(index, area.AreaID);
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khu vực: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh vân tay";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        selectedImagePath = openFileDialog.FileName;

                        // Hiển thị ảnh đã chọn
                        if (File.Exists(selectedImagePath))
                        {
                            if (pictureBoxFingerprint.Image != null)
                            {
                                pictureBoxFingerprint.Image.Dispose();
                            }

                            pictureBoxFingerprint.Image = Image.FromFile(selectedImagePath);
                            pictureBoxFingerprint.SizeMode = PictureBoxSizeMode.StretchImage;
                            lblImageStatus.Text = "Đã chọn: " + Path.GetFileName(selectedImagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể hiển thị ảnh vân tay: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedImagePath = null;
                        lblImageStatus.Text = "Chưa chọn ảnh";
                    }
                }
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (cboTenants.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người thuê!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh vân tay!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy danh sách khu vực được chọn
                string selectedAreas = GetSelectedAreaIds();

                // Gọi BLL để đăng ký vân tay
                string result = fingerprintBLL.EnrollFingerprint(
                    currentUsername,
                    cboTenants.SelectedValue.ToString(),
                    selectedAreas,
                    selectedImagePath);

                // Hiển thị kết quả
                MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK,
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                // Nếu thành công, cập nhật lại danh sách và reset form
                if (result.Contains("thành công"))
                {
                    LoadFingerprintList();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký vân tay: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            // Xóa ảnh đã chọn
            if (pictureBoxFingerprint.Image != null)
            {
                pictureBoxFingerprint.Image.Dispose();
                pictureBoxFingerprint.Image = null;
            }

            selectedImagePath = null;
            lblImageStatus.Text = "Chưa chọn ảnh";

            // Xóa các lựa chọn trong danh sách khu vực
            for (int i = 0; i < checkedListAreas.Items.Count; i++)
            {
                checkedListAreas.SetItemChecked(i, false);
            }

            // Reset thông tin người thuê được chọn
            lblSelectedTenant.Text = "Chưa chọn dữ liệu";
        }

        private string GetSelectedAreaIds()
        {
            List<string> selectedAreas = new List<string>();

            for (int i = 0; i < checkedListAreas.Items.Count; i++)
            {
                if (checkedListAreas.GetItemChecked(i) && areaIdMapping.ContainsKey(i))
                {
                    selectedAreas.Add(areaIdMapping[i]);
                }
            }

            return string.Join(";", selectedAreas);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn vân tay cần xóa chưa
            if (dgvFingerprints.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vân tay cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Xác nhận xóa
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc muốn xóa vân tay đã chọn?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string fingerprintID = dgvFingerprints.SelectedRows[0].Cells["FINGERID"].Value.ToString();

                    // Gọi BLL để xóa vân tay
                    string result = fingerprintBLL.DeleteFingerprint(fingerprintID);

                    MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK,
                        result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    // Nếu thành công, cập nhật lại danh sách và reset form
                    if (result.Contains("thành công"))
                    {
                        LoadFingerprintList();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa vân tay: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn vân tay cần cập nhật quyền chưa
            if (dgvFingerprints.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vân tay cần cập nhật quyền!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string fingerprintID = dgvFingerprints.SelectedRows[0].Cells["FINGERID"].Value.ToString();
                string selectedAreas = GetSelectedAreaIds();

                // Gọi BLL để cập nhật quyền truy cập
                string result = fingerprintBLL.UpdateAccessPermission(fingerprintID, selectedAreas);

                MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK,
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                // Nếu thành công, cập nhật lại danh sách
                if (result.Contains("thành công"))
                {
                    LoadFingerprintList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật quyền truy cập: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn vân tay cần cập nhật ảnh chưa
            if (dgvFingerprints.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vân tay cần cập nhật ảnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh vân tay mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string fingerprintID = dgvFingerprints.SelectedRows[0].Cells["FINGERID"].Value.ToString();

                // Gọi BLL để cập nhật ảnh vân tay
                string result = fingerprintBLL.UpdateFingerprintImage(fingerprintID, selectedImagePath);

                MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK,
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                // Nếu thành công, cập nhật lại danh sách và reset form
                if (result.Contains("thành công"))
                {
                    LoadFingerprintList();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật ảnh vân tay: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFingerprints_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedFingerprintData();
            //if (dgvFingerprints.SelectedRows.Count > 0)
            //{
            //    try
            //    {
            //        // Lấy thông tin vân tay được chọn
            //        string fingerprintID = dgvFingerprints.SelectedRows[0].Cells["FINGERID"].Value.ToString();
            //        string tenantID = dgvFingerprints.SelectedRows[0].Cells["TENANTID"].Value.ToString();
            //        string firstName = dgvFingerprints.SelectedRows[0].Cells["FIRSTNAME"].Value.ToString();
            //        string lastName = dgvFingerprints.SelectedRows[0].Cells["LASTNAME"].Value.ToString();
            //        string areaPermissions = dgvFingerprints.SelectedRows[0].Cells["AREAPERMISSION"].Value?.ToString() ?? "";

            //        // Hiển thị thông tin người thuê
            //        lblSelectedTenant.Text = $"Đang chọn: {lastName} {firstName} (ID: {tenantID})";

            //        // Cập nhật các checkboxes dựa trên quyền truy cập
            //        UpdateAreaPermissionCheckboxes(areaPermissions);

            //        // Hiển thị ảnh vân tay
            //        UpdateFingerprintImage(fingerprintID);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi khi hiển thị thông tin vân tay: " + ex.Message,
            //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void UpdateAreaPermissionCheckboxes(string areaPermissions)
        {
            // Bỏ chọn tất cả
            for (int i = 0; i < checkedListAreas.Items.Count; i++)
            {
                checkedListAreas.SetItemChecked(i, false);
            }

            // Chọn các khu vực đã được phân quyền
            if (!string.IsNullOrEmpty(areaPermissions))
            {
                string[] permissions = areaPermissions.Split(';');

                for (int i = 0; i < checkedListAreas.Items.Count; i++)
                {
                    if (areaIdMapping.ContainsKey(i) && permissions.Contains(areaIdMapping[i]))
                    {
                        checkedListAreas.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void UpdateFingerprintImage(string fingerprintID)
        {
            try
            {
                // Làm sạch hình ảnh hiện tại
                if (pictureBoxFingerprint.Image != null)
                {
                    pictureBoxFingerprint.Image.Dispose();
                    pictureBoxFingerprint.Image = null;
                }

                // Lấy ảnh vân tay từ database
                Image fingerprintImage = fingerprintBLL.GetFingerprintImage(fingerprintID);

                if (fingerprintImage != null)
                {
                    pictureBoxFingerprint.Image = fingerprintImage;
                    pictureBoxFingerprint.SizeMode = PictureBoxSizeMode.StretchImage;

                    string imageName = "";
                    if (dgvFingerprints.SelectedRows[0].Cells["IMAGE_NAME"] != null &&
                        dgvFingerprints.SelectedRows[0].Cells["IMAGE_NAME"].Value != null)
                    {
                        imageName = dgvFingerprints.SelectedRows[0].Cells["IMAGE_NAME"].Value.ToString();
                    }

                    lblImageStatus.Text = string.IsNullOrEmpty(imageName) ? "Ảnh vân tay" : imageName;
                }
                else
                {
                    lblImageStatus.Text = "Không có ảnh vân tay";
                }

                // Xóa đường dẫn ảnh được chọn vì ta đang xem ảnh từ database
                selectedImagePath = null;
            }
            catch (Exception ex)
            {
                lblImageStatus.Text = "Lỗi hiển thị ảnh";
                Console.WriteLine("Lỗi khi hiển thị ảnh vân tay: " + ex.Message);
            }
        }

        private void btnTestFingerprint_Click(object sender, EventArgs e)
        {
            // Khai báo biến debug mode - có thể thêm checkbox trong giao diện để bật/tắt
            bool debugMode = false; // Đặt thành true nếu bạn muốn luôn xác thực thành công

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh vân tay để kiểm tra";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string testImagePath = openFileDialog.FileName;

                        if (File.Exists(testImagePath))
                        {
                            bool authenticated = false;
                            string fingerprintID = "";
                            string areaPermissions = "";

                            // Nếu đã chọn một vân tay trong danh sách, kiểm tra vân tay đó
                            if (dgvFingerprints.SelectedRows.Count > 0)
                            {
                                fingerprintID = dgvFingerprints.SelectedRows[0].Cells["FINGERID"].Value.ToString();
                                areaPermissions = dgvFingerprints.SelectedRows[0].Cells["AREAPERMISSION"].Value?.ToString() ?? "";

                                Console.WriteLine($"Testing fingerprint ID: {fingerprintID} with image: {Path.GetFileName(testImagePath)}");

                                // Chế độ debug - luôn trả về thành công
                                if (debugMode)
                                {
                                    authenticated = true;
                                    Console.WriteLine("DEBUG MODE: Authentication forced to succeed");
                                }
                                else
                                {
                                    // Gọi BLL để kiểm tra vân tay
                                
                                    authenticated = fingerprintBLL.VerifyFingerprintFromImage(fingerprintID, testImagePath);
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Vui lòng chọn một vân tay từ danh sách trước khi kiểm tra!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;

                                // Phần mô phỏng kiểm tra với tất cả vân tay giữ nguyên nếu bạn muốn giữ lại
                                // Random rnd = new Random();
                                // authenticated = rnd.Next(2) == 1; // 50% cơ hội thành công
                                // ...
                            }

                            if (authenticated)
                            {
                                // Phần hiển thị kết quả thành công giữ nguyên
                                List<string> areaNames = new List<string>();
                                if (!string.IsNullOrEmpty(areaPermissions))
                                {
                                    string[] permissions = areaPermissions.Split(';');

                                    foreach (string areaId in permissions)
                                    {
                                        int index = areaIdMapping.FirstOrDefault(x => x.Value == areaId).Key;
                                        if (index >= 0 && index < checkedListAreas.Items.Count)
                                        {
                                            areaNames.Add(checkedListAreas.Items[index].ToString().Split('-')[0].Trim());
                                        }
                                    }
                                }

                                string areaText = areaNames.Count > 0
                                    ? string.Join("\n- ", areaNames)
                                    : "Không có khu vực nào";

                                MessageBox.Show(
                                    $"Xác thực vân tay thành công!\n\nID vân tay: {fingerprintID}\n\nNgười dùng có quyền truy cập vào các khu vực:\n- {areaText}",
                                    "Kết quả xác thực",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Xác thực vân tay thất bại!\n\nKhông tìm thấy thông tin vân tay hoặc không có quyền truy cập.",
                                    "Kết quả xác thực",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in fingerprint verification UI: {ex.Message}");
                        Console.WriteLine(ex.StackTrace);

                        MessageBox.Show("Lỗi khi kiểm tra vân tay: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFingerprints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // Thêm sự kiện SelectionChanged cho dgvFingerprints

        // Hoặc có thể sử dụng sự kiện Click
        private void dgvFingerprints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedFingerprintData();
        }

        // Phương thức để load dữ liệu của vân tay đã chọn
        private void LoadSelectedFingerprintData()
        {
            try
            {
                if (dgvFingerprints.SelectedRows.Count > 0)
                {
                    // Lấy ID vân tay đã chọn
                    string fingerprintID = dgvFingerprints.SelectedRows[0].Cells["FINGERID"].Value.ToString();

                    // Hiển thị thông tin người thuê
                    string tenantID = dgvFingerprints.SelectedRows[0].Cells["TENANTID"].Value.ToString();

                    // Cập nhật selected tenant trong combobox
                    for (int i = 0; i < cboTenants.Items.Count; i++)
                    {
                        TenantDTO tenant = cboTenants.Items[i] as TenantDTO;
                        if (tenant != null && tenant.TenantID == tenantID)
                        {
                            cboTenants.SelectedIndex = i;
                            break;
                        }
                    }

                    // Hiển thị quyền truy cập 
                    string areaPermission = dgvFingerprints.SelectedRows[0].Cells["AREAPERMISSION"].Value?.ToString() ?? "";
                    LoadSelectedAreaPermissions(areaPermission);

                    // Load và hiển thị hình ảnh vân tay
                    DisplayFingerprintImage(fingerprintID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu vân tay đã chọn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức hiển thị ảnh vân tay
        private void DisplayFingerprintImage(string fingerprintID)
        {
            try
            {
                // Lấy ảnh vân tay từ BLL
                Image fingerprintImage = fingerprintBLL.GetFingerprintImage(fingerprintID);

                if (fingerprintImage != null)
                {
                    // Hiển thị ảnh trong PictureBox
                    pictureBoxFingerprint.Image = fingerprintImage;

                    // Cập nhật label thông tin ảnh
                    string imageName = dgvFingerprints.SelectedRows[0].Cells["IMAGENAME"].Value?.ToString() ?? "";
                    lblImageStatus.Text = "Đã chọn: " + imageName;

                    // Xóa đường dẫn ảnh được chọn vì ta đang xem ảnh từ database
                    selectedImagePath = null;
                }
                else
                {
                    // Nếu không tìm thấy ảnh
                    pictureBoxFingerprint.Image = null;
                    lblImageStatus.Text = "Không có ảnh vân tay";
                }
            }
            catch (Exception ex)
            {
                lblImageStatus.Text = "Lỗi hiển thị ảnh";
                Console.WriteLine("Lỗi khi hiển thị ảnh vân tay: " + ex.Message);
                pictureBoxFingerprint.Image = null;
            }
        }

        // Phương thức để check các checkbox quyền truy cập tương ứng
        private void LoadSelectedAreaPermissions(string areaPermission)
        {
            try
            {
                // Bỏ check tất cả các items
                for (int i = 0; i < checkedListAreas.Items.Count; i++)
                {
                    checkedListAreas.SetItemChecked(i, false);
                }

                // Không có quyền truy cập
                if (string.IsNullOrEmpty(areaPermission))
                    return;

                // Check các items tương ứng
                string[] permissions = areaPermission.Split(';');
                foreach (string areaId in permissions)
                {
                    // Tìm index trong checkedListAreas tương ứng với areaId
                    foreach (var pair in areaIdMapping)
                    {
                        if (pair.Value == areaId && pair.Key < checkedListAreas.Items.Count)
                        {
                            checkedListAreas.SetItemChecked(pair.Key, true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading area permissions: {ex.Message}");
            }
        }
    }
}