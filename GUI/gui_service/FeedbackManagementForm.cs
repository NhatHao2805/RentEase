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
            InitializeAdditionalControls();
            this.currentBuildingID = buildingID;
            btnResetFilter.Click += new EventHandler(btnResetFilter_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
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
                cboStatus.Items.Add("Tất cả");
                cboStatus.Items.Add("PENDING");
                cboStatus.Items.Add("RESOLVED");
                cboStatus.SelectedIndex = 0;

                // Khởi tạo datepicker
                dtpFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpToDate.Value = DateTime.Now;

                // Khởi tạo các control bổ sung (nếu có)
                InitializeAdditionalControls();

                // QUAN TRỌNG: Chỉ load dữ liệu từ DATABASE, không đồng bộ
                LoadFeedbackDataFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                // Lưu trữ danh sách hiện tại (nếu có) để giữ lại trạng thái đã xử lý
                List<FeedbackDTO> currentFeedbacks = feedbackList ?? new List<FeedbackDTO>();

                // Tạo từ điển để dễ dàng tìm kiếm bằng key là FeedbackID
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

                Cursor = Cursors.Default;

                // In log để kiểm tra
                Console.WriteLine($"Đã tải {newFeedbackList.Count} phản ánh, giữ lại {mergedList.Count(f => f.Status == "RESOLVED")} phản ánh đã xử lý");
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void BindDataToGrid(List<FeedbackDTO> list)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Tên khách hàng", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Nội dung", typeof(string));
                dt.Columns.Add("Ngày gửi", typeof(string));
                dt.Columns.Add("Trạng thái", typeof(string));

                foreach (var feedback in list)
                {
                    dt.Rows.Add(
                        feedback.FeedbackID,
                        string.IsNullOrEmpty(feedback.TenantName) ? "Không có thông tin" : feedback.TenantName,
                        string.IsNullOrEmpty(feedback.Email) ? "Không có email" : feedback.Email,
                        feedback.Content,
                        feedback.DateSend.ToString("dd/MM/yyyy HH:mm"), // Hiển thị đúng định dạng ngày tháng
                        feedback.Status == "PENDING" ? "Chưa xử lý" : "Đã xử lý"
                    );
                }

                // Bind DataTable vào DataGridView
                dgvFeedbacks.DataSource = dt;

                // Định dạng lại các cột
                if (dgvFeedbacks.Columns.Count > 0)
                {
                    dgvFeedbacks.Columns["Nội dung"].Width = 300;
                    dgvFeedbacks.Columns["Email"].Width = 150;
                    dgvFeedbacks.Columns["Tên khách hàng"].Width = 150;

                    // Ẩn cột ID
                    dgvFeedbacks.Columns["ID"].Visible = false;
                }

                // Hiển thị số lượng phản ánh
                if (lblTotalCount != null)
                {
                    lblTotalCount.Text = $"Tổng số: {list.Count} phản ánh";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi binding dữ liệu: {ex.Message}");
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
            try
            {
                Cursor = Cursors.WaitCursor;
                Console.WriteLine("Bắt đầu xuất Excel...");

                // Kiểm tra có dữ liệu không
                if (dgvFeedbacks.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }

                // Phương pháp 1: Sử dụng ExcelExporter có sẵn
                if (typeof(ExcelExporter) != null)
                {
                    ExcelExporter.ExportToExcel(dgvFeedbacks, "Danh sách phản ánh khách hàng");
                }
                else
                {
                    // Phương pháp 2: Xuất Excel thủ công nếu ExcelExporter không có
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    saveDialog.Title = "Xuất danh sách phản ánh";
                    saveDialog.FileName = "DanhSachPhanAnh_" + DateTime.Now.ToString("yyyyMMdd");

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Tạo Excel application
                        Excel.Application excelApp = new Excel.Application();
                        excelApp.Visible = false;
                        Excel.Workbook workbook = excelApp.Workbooks.Add();
                        Excel.Worksheet worksheet = workbook.ActiveSheet;

                        // Tiêu đề
                        worksheet.Cells[1, 1] = "DANH SÁCH PHẢN ÁNH KHÁCH HÀNG";
                        Excel.Range titleRange = worksheet.Range["A1", GetExcelColumnName(dgvFeedbacks.Columns.Count) + "1"];
                        titleRange.Merge();
                        titleRange.Font.Bold = true;
                        titleRange.Font.Size = 14;
                        titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        // Header
                        for (int i = 0; i < dgvFeedbacks.Columns.Count; i++)
                        {
                            if (dgvFeedbacks.Columns[i].Visible)
                            {
                                worksheet.Cells[2, i + 1] = dgvFeedbacks.Columns[i].HeaderText;
                                worksheet.Cells[2, i + 1].Font.Bold = true;
                            }
                        }

                        // Dữ liệu
                        for (int i = 0; i < dgvFeedbacks.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvFeedbacks.Columns.Count; j++)
                            {
                                if (dgvFeedbacks.Columns[j].Visible && dgvFeedbacks.Rows[i].Cells[j].Value != null)
                                {
                                    worksheet.Cells[i + 3, j + 1] = dgvFeedbacks.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                        }

                        // Tự động điều chỉnh cột
                        worksheet.Columns.AutoFit();

                        // Lưu file
                        workbook.SaveAs(saveDialog.FileName);
                        workbook.Close();
                        excelApp.Quit();

                        MessageBox.Show("Xuất Excel thành công!\nFile: " + saveDialog.FileName,
                                       "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Lỗi xuất Excel: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
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
                    // Lấy dữ liệu từ dòng được chọn
                    string feedbackId = dgvFeedbacks.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    string email = dgvFeedbacks.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    string content = dgvFeedbacks.Rows[e.RowIndex].Cells["Nội dung"].Value.ToString();
                    string status = dgvFeedbacks.Rows[e.RowIndex].Cells["Trạng thái"].Value.ToString();

                    // Hiển thị hộp thoại chi tiết
                    DialogResult result = MessageBox.Show(
                        $"Chi tiết phản ánh từ: {email}\n\n{content}\n\nBạn có muốn đánh dấu phản ánh này là đã xử lý không?",
                        "Chi tiết phản ánh",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes && status == "Chưa xử lý")
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
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}