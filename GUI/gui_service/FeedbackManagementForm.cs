using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.bll_service;
using DTO;
using DTO.dto_service;
// Thêm các reference sau vào đầu file
using Excel = Microsoft.Office.Interop.Excel;
// Thêm vào đầu file
namespace GUI
{
    public partial class FeedbackManagementForm : Form
    {
        private List<FeedbackDTO> feedbackList;
        // Thêm thuộc tính lưu ID tòa nhà
        private string currentBuildingID;
        // Sửa constructor để nhận tham số buildingID
        public FeedbackManagementForm(string buildingID)
        {
            InitializeComponent();
            SetupDataGridView();
            InitializeAdditionalControls();
            this.currentBuildingID = buildingID;
            btnResetFilter.Click += new EventHandler(btnResetFilter_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
        }

        private void SetupDataGridView()
        {
            // Xóa tất cả cột hiện có
            dgvFeedbacks.Columns.Clear();

            // Thêm các cột mới
            dgvFeedbacks.Columns.Add("ID", "ID");
            dgvFeedbacks.Columns.Add("TenantName", "Tên khách hàng");
            dgvFeedbacks.Columns.Add("RoomName", "Phòng");
            dgvFeedbacks.Columns.Add("Email", "Email");
            dgvFeedbacks.Columns.Add("Content", "Nội dung");
            dgvFeedbacks.Columns.Add("DateSend", "Ngày gửi");
            dgvFeedbacks.Columns.Add("Status", "Trạng thái");

            // Cấu hình các cột
            dgvFeedbacks.Columns["ID"].Visible = false;
            dgvFeedbacks.Columns["Content"].Width = 300;
            dgvFeedbacks.Columns["Email"].Width = 150;
            dgvFeedbacks.Columns["TenantName"].Width = 150;
            dgvFeedbacks.Columns["RoomName"].Width = 100;
            dgvFeedbacks.Columns["DateSend"].Width = 120;
            dgvFeedbacks.Columns["Status"].Width = 100;

            // Cấu hình thêm cho DataGridView
            dgvFeedbacks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFeedbacks.AllowUserToAddRows = false;
            dgvFeedbacks.AllowUserToDeleteRows = false;
            dgvFeedbacks.ReadOnly = true;
            dgvFeedbacks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedbacks.MultiSelect = false;
        }

        private void FeedbackManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra buildingID có giá trị hợp lệ không
                if (string.IsNullOrEmpty(currentBuildingID))
                {
                    MessageBox.Show("Không xác định được tòa nhà đang quản lý!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Khởi tạo combobox status
                cboStatus.Items.Add(Language.translate("all_text"));
                cboStatus.Items.Add(Language.translate("dangcho"));
                cboStatus.Items.Add(Language.translate("dagiaiquyet"));
                cboStatus.SelectedIndex = 0;

                // Khởi tạo datepicker
                dtpFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpToDate.Value = DateTime.Now;

                // Khởi tạo các control bổ sung (nếu có)
                InitializeAdditionalControls();

                // QUAN TRỌNG: Chỉ load dữ liệu từ DATABASE, không đồng bộ
                LoadFeedbackDataFromDatabase();
                loadLanguage();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "page_title":
                        label23.Text = a.Value;
                        break;
                    case "page_subtitle":
                        label22.Text = a.Value;
                        break;
                    case "search_section":
                        label2.Text = a.Value;
                        break;
                    case "date_filter_start":
                        label4.Text = a.Value;
                        break;
                    case "date_filter_end":
                        label5.Text = a.Value;
                        break;
                    case "table_header_customer":
                        dgvFeedbacks.Columns[1].HeaderText = a.Value;
                        break;
                    case "table_header_email":
                        dgvFeedbacks.Columns[2].HeaderText = a.Value;
                        break;
                    case "table_header_content":
                        dgvFeedbacks.Columns[3].HeaderText = a.Value;
                        break;
                    case "table_header_date":
                        dgvFeedbacks.Columns[4].HeaderText = a.Value;
                        break;
                    case "table_header_status":
                        label3.Text = a.Value;
                        dgvFeedbacks.Columns[5].HeaderText = a.Value;
                        break;
                    case "doubleclick":
                        label6.Text = a.Value;
                        break;
                    case "export_excel":
                        btnExport.Text = a.Value;
                        break;
                    case "action_filter":
                        btnFilter.Text = a.Value;
                        break;
                    case "action_refresh":
                        btnResetFilter.Text = a.Value;
                        break;
                    case "action_import":
                        btnSync.Text = a.Value;
                        break;
                }
            }
        }
        //        page_title: Quản lý phản ánh khách hàng   export_excel
        //page_subtitle: Mọi phản ánh của khách hàng đều ở đây
        //search_section: Tìm kiếm
        //date_filter_start: Từ ngày
        //date_filter_end: Đến ngày
        //table_header_customer: Tên khách hàng
        //table_header_email: Email
        //table_header_content: Nội dung
        //table_header_date: Ngày gửi
        //table_header_status: Trạng thái
        //action_show_all: Tất cả
        //action_filter: Lọc
        //action_refresh: Làm mới
        //action_import: Dòng bệ dữ liệu từ Google Form
        private void LoadFeedbackDataFromDatabase()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // QUAN TRỌNG: Lấy dữ liệu trực tiếp từ DATABASE, không đồng bộ với Google Sheet
                feedbackList = FeedbackBLL.GetFeedbacksByBuildingID(currentBuildingID);

                if (feedbackList == null)
                {
                    feedbackList = new List<FeedbackDTO>();
                    MessageBox.Show("Không thể tải dữ liệu phản ánh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Hiển thị danh sách lên grid
                BindDataToGrid(feedbackList);

                // Cập nhật label số lượng nếu có
                if (lblTotalCount != null)
                {
                    lblTotalCount.Text = $"Tổng số: {feedbackList.Count} phản ánh";
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFeedbackData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Console.WriteLine("Bắt đầu tải dữ liệu feedback...");

                // Lưu trữ danh sách hiện tại (nếu có) để giữ lại trạng thái đã xử lý
                List<FeedbackDTO> currentFeedbacks = feedbackList ?? new List<FeedbackDTO>();
                Dictionary<string, FeedbackDTO> currentFeedbacksDict = new Dictionary<string, FeedbackDTO>();

                foreach (var feedback in currentFeedbacks)
                {
                    if (!string.IsNullOrEmpty(feedback.FeedbackID))
                    {
                        currentFeedbacksDict[feedback.FeedbackID] = feedback;
                    }
                }

                // Tải danh sách mới từ cơ sở dữ liệu
                List<FeedbackDTO> newFeedbackList = FeedbackBLL.GetFeedbacksByBuildingID(currentBuildingID);

                if (newFeedbackList == null)
                {
                    newFeedbackList = new List<FeedbackDTO>();
                    MessageBox.Show("Không thể tải dữ liệu phản ánh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Console.WriteLine($"Đã tải được {newFeedbackList.Count} feedback từ database");

                // Danh sách kết quả cuối cùng
                List<FeedbackDTO> mergedList = new List<FeedbackDTO>();

                // Duyệt qua danh sách mới để kết hợp với trạng thái đã lưu
                foreach (var newFeedback in newFeedbackList)
                {
                    if (currentFeedbacksDict.ContainsKey(newFeedback.FeedbackID))
                    {
                        // Phản ánh đã tồn tại, giữ nguyên trạng thái nếu đã xử lý
                        FeedbackDTO existingFeedback = currentFeedbacksDict[newFeedback.FeedbackID];
                        if (existingFeedback.Status == "RESOLVED")
                        {
                            newFeedback.Status = "RESOLVED";
                        }
                    }

                    // Thêm vào danh sách kết quả
                    mergedList.Add(newFeedback);
                }

                // Cập nhật danh sách phản ánh
                feedbackList = mergedList;

                // Hiển thị danh sách lên grid
                BindDataToGrid(feedbackList);

                Console.WriteLine($"Đã hiển thị {feedbackList.Count} feedback lên DataGridView");

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Lỗi: {ex.Message}\nStack trace: {ex.StackTrace}");
            }
        }


        private void ApplyFilters()
        {
            // Lọc theo các điều kiện
            var filteredList = feedbackList;

            // Lọc theo trạng thái
            if (cboStatus.SelectedIndex > 0)
            {
                string status = cboStatus.SelectedItem.ToString();
                filteredList = filteredList.Where(f => f.Status == status).ToList();
            }

            // Lọc theo khoảng thời gian
            filteredList = filteredList.Where(f =>
                f.DateSend >= dtpFromDate.Value.Date &&
                f.DateSend <= dtpToDate.Value.Date.AddDays(1).AddSeconds(-1)).ToList();

            // Lọc theo nội dung tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string searchText = txtSearch.Text.ToLower();
                filteredList = filteredList.Where(f =>
                    f.Content.ToLower().Contains(searchText) ||
                    f.Email.ToLower().Contains(searchText)).ToList();
            }

            // Hiển thị kết quả lên DataGridView
            BindDataToGrid(filteredList);
        }

        // Sửa hàm BindDataToGrid để hiển thị thêm email
        private void BindDataToGrid(List<FeedbackDTO> feedbacks)
        {
            try
            {
                // Xóa dữ liệu cũ
                dgvFeedbacks.Rows.Clear();

                // Thêm dữ liệu mới
                foreach (var feedback in feedbacks)
                {
                    try
                    {
                        int rowIndex = dgvFeedbacks.Rows.Add();
                        var row = dgvFeedbacks.Rows[rowIndex];

                        // Lưu FeedbackID vào Tag của row để sử dụng sau này
                        row.Tag = feedback.FeedbackID;

                        // Gán giá trị cho các cell
                        row.Cells["TenantName"].Value = feedback.TenantName ?? "Không xác định";
                        row.Cells["RoomName"].Value = feedback.RoomName ?? "Không xác định";
                        row.Cells["Email"].Value = feedback.Email;
                        row.Cells["Content"].Value = feedback.Content;
                        row.Cells["DateSend"].Value = feedback.DateSend.ToString("dd/MM/yyyy HH:mm");
                        row.Cells["Status"].Value = feedback.Status == "RESOLVED" ? "Đã xử lý" : "Chưa xử lý";

                        // Tô màu cho trạng thái
                        if (feedback.Status == "RESOLVED")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi thêm dòng cho feedback {feedback.FeedbackID}: {ex.Message}");
                    }
                }

                // Cập nhật giao diện
                dgvFeedbacks.Refresh();

                // Hiển thị số lượng phản ánh
                if (lblTotalCount != null)
                {
                    lblTotalCount.Text = $"Tổng số: {feedbacks.Count} phản ánh";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }


        // XỬ LÝ ĐỒNG BỘ DỮ LIỆU
        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblSyncStatus.Text = "Đang đồng bộ...";
                lblSyncStatus.ForeColor = Color.Blue;

                // Hiển thị thông báo đang đồng bộ
                Application.DoEvents();

                // Dùng Task để không block UI
                Task.Run(() => {
                    bool result = false;
                    Exception error = null;
                    List<FeedbackDTO> syncedFeedbacks = null;
                    int newCount = 0;

                    try
                    {
                        // Gọi BLL để đồng bộ dữ liệu
                        (result, syncedFeedbacks, newCount) = FeedbackBLL.SyncFeedbacksFromGoogleSheetAndReturn();
                    }
                    catch (Exception ex)
                    {
                        error = ex;
                    }

                    // Cập nhật UI trên thread chính
                    this.Invoke((MethodInvoker)delegate {
                        Cursor = Cursors.Default;

                        if (error != null)
                        {
                            lblSyncStatus.Text = "Đồng bộ thất bại!";
                            lblSyncStatus.ForeColor = Color.Red;
                            MessageBox.Show("Lỗi: " + error.Message, "Lỗi đồng bộ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (result && syncedFeedbacks != null)
                        {
                            lblSyncStatus.Text = "Đồng bộ thành công!";
                            lblSyncStatus.ForeColor = Color.Green;

                            // Cập nhật danh sách phản hồi và hiển thị
                            feedbackList = syncedFeedbacks;
                            BindDataToGrid(feedbackList);

                            // Cập nhật số lượng nếu có
                            if (lblTotalCount != null)
                            {
                                lblTotalCount.Text = $"Tổng số: {feedbackList.Count} phản ánh";
                            }

                            MessageBox.Show($"Đã đồng bộ thành công! Thêm mới {newCount} phản ánh.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            lblSyncStatus.Text = "Không có dữ liệu mới!";
                            lblSyncStatus.ForeColor = Color.Blue;
                            MessageBox.Show("Không có dữ liệu mới để đồng bộ. Tất cả phản ánh đã tồn tại.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                lblSyncStatus.Text = "Đồng bộ thất bại!";
                lblSyncStatus.ForeColor = Color.Red;
                MessageBox.Show("Lỗi đồng bộ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm hàm mới để tải dữ liệu nhưng giữ nguyên trạng thái đã xử lý
        private void LoadFeedbackDataPreserveStatus(List<string> resolvedFeedbackIds)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Gọi BLL để lấy danh sách feedback theo tòa nhà
                feedbackList = FeedbackBLL.GetFeedbacksByBuildingID(currentBuildingID);

                if (feedbackList == null)
                {
                    feedbackList = new List<FeedbackDTO>();
                    MessageBox.Show("Không thể tải dữ liệu phản ánh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Cập nhật trạng thái theo danh sách đã lưu
                    foreach (var feedback in feedbackList)
                    {
                        if (resolvedFeedbackIds.Contains(feedback.FeedbackID))
                        {
                            feedback.Status = "RESOLVED"; // Đảm bảo trạng thái được giữ nguyên
                        }
                    }
                }

                // Hiển thị danh sách lên grid
                BindDataToGrid(feedbackList);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Sửa hàm btnFilter_Click để thêm điều kiện lọc theo tòa nhà
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Console.WriteLine("Bắt đầu tìm kiếm...");

                // Lấy các điều kiện lọc
                string status = cboStatus.SelectedIndex > 0 ? cboStatus.SelectedItem.ToString() : null;
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;
                string searchText = txtSearch.Text.Trim();

                // Chuyển đổi trạng thái hiển thị sang giá trị lưu trong DB
                if (status == "Chưa xử lý")
                    status = "PENDING";
                else if (status == "Đã xử lý")
                    status = "RESOLVED";

                Console.WriteLine($"Debug - Tìm kiếm với từ khóa: '{searchText}', status: {status}, fromDate: {fromDate}, toDate: {toDate}");

                // Kiểm tra tính hợp lệ của điều kiện lọc
                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }

                // Lọc dữ liệu thủ công nếu không muốn sử dụng SQL phức tạp
                List<FeedbackDTO> allFeedbacks = FeedbackBLL.GetAllFeedbacks();
                List<FeedbackDTO> filteredList = new List<FeedbackDTO>();

                foreach (var feedback in allFeedbacks)
                {
                    // Lọc theo ngày
                    if (feedback.DateSend.Date < fromDate || feedback.DateSend.Date > toDate)
                        continue;

                    // Lọc theo trạng thái
                    if (!string.IsNullOrEmpty(status) && status != "Tất cả" && feedback.Status != status)
                        continue;

                    // Lọc theo từ khóa tìm kiếm
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        bool containsKeyword = false;

                        // Tìm trong tên
                        if (!string.IsNullOrEmpty(feedback.TenantName) &&
                            feedback.TenantName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            containsKeyword = true;
                        }

                        // Tìm trong email
                        if (!string.IsNullOrEmpty(feedback.Email) &&
                            feedback.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            containsKeyword = true;
                        }

                        // Tìm trong nội dung
                        if (!string.IsNullOrEmpty(feedback.Content) &&
                            feedback.Content.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            containsKeyword = true;
                        }

                        if (!containsKeyword)
                            continue;
                    }

                    // Nếu vượt qua tất cả điều kiện lọc, thêm vào danh sách kết quả
                    filteredList.Add(feedback);
                }

                Console.WriteLine($"Debug - Số lượng kết quả tìm thấy: {filteredList.Count}");

                // Hiển thị kết quả
                if (filteredList.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phản ánh nào phù hợp với điều kiện lọc.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BindDataToGrid(filteredList);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
        // XỬ LÝ RESET


        // Thay đổi thành
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // Thông báo bắt đầu reset
                Cursor = Cursors.WaitCursor;
                Console.WriteLine("Bắt đầu reset filter...");

                // Reset các điều kiện lọc về mặc định
                txtSearch.Text = "";
                cboStatus.SelectedIndex = 0;
                dtpFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpToDate.Value = DateTime.Now;

                // Tải lại toàn bộ dữ liệu
                LoadFeedbackData();

                // Thông báo hoàn tất reset
                Console.WriteLine("Đã reset filter!");
                Cursor = Cursors.Default;

                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Đã reset bộ lọc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi reset: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Lỗi reset: " + ex.Message);
            }
        }

        private void btnSetResolved_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dòng nào được chọn không
                if (dgvFeedbacks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phản ánh cần đánh dấu đã xử lý.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Cursor = Cursors.WaitCursor;

                int successCount = 0;
                foreach (DataGridViewRow row in dgvFeedbacks.SelectedRows)
                {
                    string feedbackId = row.Cells["ID"].Value.ToString();

                    // Gọi BLL để cập nhật trạng thái
                    if (FeedbackBLL.UpdateFeedbackStatus(feedbackId, "RESOLVED"))
                    {
                        successCount++;
                        // Cập nhật hiển thị trên grid
                        row.Cells["Trạng thái"].Value = "Đã xử lý";
                    }
                }

                Cursor = Cursors.Default;

                if (successCount > 0)
                {
                    MessageBox.Show($"Đã đánh dấu {successCount} phản ánh là đã xử lý.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật trạng thái của phản ánh.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvFeedbacks.Visible)
            {
                ExcelExporter.ExportToExcel(dgvFeedbacks, "Danh sách phản hồi");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Helper để lấy tên cột Excel (A, B, ..., AA, AB, ...)
        private string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";
            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }
            return columnName;
        }
        // XỬ LÝ XEM CHI TIẾT VÀ CẬP NHẬT TRẠNG THÁI
        private void dgvFeedbacks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Lấy dữ liệu từ dòng được chọn một cách an toàn
                    string feedbackId = dgvFeedbacks.Rows[e.RowIndex].Tag?.ToString();
                    if (string.IsNullOrEmpty(feedbackId))
                    {
                        MessageBox.Show("Không thể xác định phản ánh được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tìm feedback trong danh sách
                    var feedback = feedbackList.FirstOrDefault(f => f.FeedbackID == feedbackId);
                    if (feedback == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin phản ánh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tạo thông điệp chi tiết
                    string roomInfo = !string.IsNullOrEmpty(feedback.RoomName) ? $"\nPhòng: {feedback.RoomName}" : "";
                    string message = $"Chi tiết phản ánh từ: {feedback.Email}{roomInfo}\n\n{feedback.Content}\n\nBạn có muốn đánh dấu phản ánh này là đã xử lý không?";

                    // Hiển thị hộp thoại chi tiết
                    DialogResult result = MessageBox.Show(
                        message,
                        "Chi tiết phản ánh",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes && feedback.Status != "RESOLVED")
                    {
                        // Cập nhật trạng thái
                        bool updateResult = FeedbackBLL.UpdateFeedbackStatus(feedbackId, "RESOLVED");

                        if (updateResult)
                        {
                            MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadFeedbackData(); // Refresh dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật trạng thái không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý phản ánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        // Thêm label hiển thị trạng thái đồng bộ và tổng số phản ánh
        private Label lblSyncStatus;
        private Label lblTotalCount;

        // Các thao tác khởi tạo UI control bổ sung
        private void InitializeAdditionalControls()
        {
            lblSyncStatus = new Label();
            lblSyncStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSyncStatus.AutoSize = true;
            lblSyncStatus.Location = new Point(btnSync.Left, btnSync.Bottom + 5);
            lblSyncStatus.Text = "";
            this.Controls.Add(lblSyncStatus);

            lblTotalCount = new Label();
            lblTotalCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(10, dgvFeedbacks.Bottom + 10);
            lblTotalCount.Text = "Tổng số: 0 phản ánh";
            this.Controls.Add(lblTotalCount);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}