using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;
using BLL;
using DTO;

namespace GUI
{
    public partial class ContractTemplateForm : Form
    {
        private RichTextBox rtbTemplate;
        private Button btnSave;
        private Button btnExportPDF;
        private Button btnLoad;
        private Button btnExportPDFDirect;
        private ComboBox cboTemplates;
        private Label lblTitle;
        private TextBox txtTemplateName;
        private Label lblTemplateName;
        private string templatesPath = Path.Combine(Application.StartupPath, "Templates");

        public ContractTemplateForm()
        {
            InitializeComponent();
            // Thiết lập đường dẫn thư mục mẫu
            templatesPath = Path.Combine(Application.StartupPath, "Templates");
            
            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(templatesPath))
            {
                Directory.CreateDirectory(templatesPath);
            }
            
            // Tạo danh sách các mẫu
            LoadTemplateList();
            
            // Thêm nút xuất PDF trực tiếp
            AddExportPDFDirectButton();
        }

        private void InitializeComponent()
        {
            this.rtbTemplate = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cboTemplates = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbTemplate
            // 
            this.rtbTemplate.Location = new System.Drawing.Point(12, 112);
            this.rtbTemplate.Name = "rtbTemplate";
            this.rtbTemplate.Size = new System.Drawing.Size(776, 405);
            this.rtbTemplate.TabIndex = 0;
            this.rtbTemplate.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(556, 533);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu mẫu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(675, 533);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(113, 34);
            this.btnExportPDF.TabIndex = 2;
            this.btnExportPDF.Text = "Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(332, 65);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 29);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Tải mẫu";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cboTemplates
            // 
            this.cboTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplates.FormattingEnabled = true;
            this.cboTemplates.Location = new System.Drawing.Point(114, 66);
            this.cboTemplates.Name = "cboTemplates";
            this.cboTemplates.Size = new System.Drawing.Size(212, 28);
            this.cboTemplates.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(292, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 37);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Mẫu hợp đồng";
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(553, 66);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(235, 26);
            this.txtTemplateName.TabIndex = 6;
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Location = new System.Drawing.Point(470, 69);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(77, 20);
            this.lblTemplateName.TabIndex = 7;
            this.lblTemplateName.Text = "Tên mẫu:";
            // 
            // ContractTemplateForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 579);
            this.Controls.Add(this.lblTemplateName);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cboTemplates);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbTemplate);
            this.Name = "ContractTemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập mẫu hợp đồng";
            this.Load += new System.EventHandler(this.ContractTemplateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ContractTemplateForm_Load(object sender, EventArgs e)
        {
            // Thiết lập RichTextBox để hỗ trợ định dạng phong phú
            rtbTemplate.Font = new Font("Arial", 11);
            rtbTemplate.AcceptsTab = true;
            rtbTemplate.WordWrap = true;
            rtbTemplate.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbTemplate.EnableAutoDragDrop = true;
            
            // Xóa nội dung cũ
            rtbTemplate.Clear();
            
            // Thêm tiêu đề tài liệu với định dạng
            AppendTextWithFormat("HỢP ĐỒNG THUÊ NHÀ", HorizontalAlignment.Center, 18, true, false);
            rtbTemplate.AppendText("\n\n");
            
            // Thêm số hợp đồng
            AppendTextWithFormat("Số: [SỐ_HỢP_ĐỒNG]", HorizontalAlignment.Center, 12, true, false);
            rtbTemplate.AppendText("\n\n");
            
            // Thông tin thời gian và địa điểm
            AppendTextWithFormat("Hôm nay, ngày [NGÀY] tháng [THÁNG] năm [NĂM], tại [ĐỊA ĐIỂM]", HorizontalAlignment.Left, 11, false, false);
            rtbTemplate.AppendText("\n\n");
            
            // Phần mở đầu
            string preamble = "Căn cứ vào Bộ luật Dân sự số 91/2015/QH13 ngày 24/11/2015 và các quy định pháp luật hiện hành;";
            AppendTextWithFormat(preamble, HorizontalAlignment.Left, 11, false, true);
            rtbTemplate.AppendText("\n");
            
            preamble = "Căn cứ nhu cầu và khả năng của các bên;";
            AppendTextWithFormat(preamble, HorizontalAlignment.Left, 11, false, true);
            rtbTemplate.AppendText("\n");
            
            preamble = "Chúng tôi gồm:";
            AppendTextWithFormat(preamble, HorizontalAlignment.Left, 11, false, false);
            rtbTemplate.AppendText("\n\n");
            
            // Bên cho thuê
            AppendTextWithFormat("I. BÊN CHO THUÊ (Gọi tắt là Bên A):", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("Họ và tên: .................................................................\n");
            rtbTemplate.AppendText("Ngày sinh: ...............................................................\n");
            rtbTemplate.AppendText("CMND/CCCD số: ...................... Ngày cấp: ................... Nơi cấp: ..................\n");
            rtbTemplate.AppendText("Địa chỉ thường trú: ...................................................\n");
            rtbTemplate.AppendText("Điện thoại: ...............................................................\n");
            rtbTemplate.AppendText("Email: .....................................................................\n\n");
            
            // Bên thuê
            AppendTextWithFormat("II. BÊN THUÊ (Gọi tắt là Bên B):", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("Họ và tên: [TÊN_KHÁCH_THUÊ]\n");
            rtbTemplate.AppendText("Ngày sinh: [NGÀY_SINH]\n");
            rtbTemplate.AppendText("CMND/CCCD số: [CMND_CCCD]  Ngày cấp: [NGÀY_CẤP]  Nơi cấp: [NƠI_CẤP]\n");
            rtbTemplate.AppendText("Địa chỉ thường trú: [ĐỊA_CHỈ_THƯỜNG_TRÚ]\n");
            rtbTemplate.AppendText("Điện thoại: [SỐ_ĐIỆN_THOẠI]\n");
            rtbTemplate.AppendText("Email: [EMAIL]\n\n");
            
            // Lời mở đầu về thỏa thuận
            AppendTextWithFormat("Sau khi bàn bạc, thỏa thuận, hai bên thống nhất ký kết Hợp đồng thuê nhà với các điều khoản sau:", HorizontalAlignment.Left, 11, false, false);
            rtbTemplate.AppendText("\n\n");
            
            // Điều 1
            AppendTextWithFormat("ĐIỀU 1: ĐỐI TƯỢNG CHO THUÊ", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("1.1. Bên A đồng ý cho Bên B thuê [LOẠI_NHÀ] tại địa chỉ: [ĐỊA_CHỈ_NHÀ].\n");
            rtbTemplate.AppendText("1.2. Hiện trạng nhà: [HIỆN_TRẠNG_NHÀ].\n");
            rtbTemplate.AppendText("1.3. Mục đích sử dụng: [MỤC_ĐÍCH_SỬ_DỤNG].\n\n");
            
            // Điều 2
            AppendTextWithFormat("ĐIỀU 2: GIÁ THUÊ VÀ PHƯƠNG THỨC THANH TOÁN", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("2.1. Giá thuê: [GIÁ_THUÊ] đồng/tháng (Bằng chữ: [GIÁ_THUÊ_BẰNG_CHỮ]).\n");
            rtbTemplate.AppendText("2.2. Tiền đặt cọc: [TIỀN_CỌC] đồng (Bằng chữ: [TIỀN_CỌC_BẰNG_CHỮ]).\n");
            rtbTemplate.AppendText("2.3. Phương thức thanh toán: [PHƯƠNG_THỨC_THANH_TOÁN].\n");
            rtbTemplate.AppendText("2.4. Các chi phí phát sinh khác: [CHI_PHÍ_KHÁC].\n\n");
            
            // Điều 3
            AppendTextWithFormat("ĐIỀU 3: THỜI HẠN THUÊ", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("3.1. Thời hạn thuê là [THỜI_HẠN] tháng, kể từ ngày [NGÀY_BẮT_ĐẦU] đến ngày [NGÀY_KẾT_THÚC].\n");
            rtbTemplate.AppendText("3.2. Điều kiện gia hạn: [ĐIỀU_KIỆN_GIA_HẠN].\n\n");
            
            // Điều 4
            AppendTextWithFormat("ĐIỀU 4: QUYỀN VÀ NGHĨA VỤ CỦA BÊN A", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("4.1. Quyền của Bên A:\n");
            rtbTemplate.AppendText("   - Thu tiền thuê nhà đúng thời hạn đã thỏa thuận.\n");
            rtbTemplate.AppendText("   - Yêu cầu Bên B sử dụng nhà đúng mục đích và bảo quản tài sản trong nhà.\n");
            rtbTemplate.AppendText("   - Đơn phương chấm dứt hợp đồng khi Bên B vi phạm nghiêm trọng các điều khoản đã thỏa thuận.\n");
            rtbTemplate.AppendText("4.2. Nghĩa vụ của Bên A:\n");
            rtbTemplate.AppendText("   - Giao nhà và trang thiết bị đúng thời hạn thỏa thuận.\n");
            rtbTemplate.AppendText("   - Đảm bảo quyền sử dụng nhà ở hợp pháp cho Bên B trong thời gian thuê.\n");
            rtbTemplate.AppendText("   - Bảo trì, sửa chữa những hư hỏng không do lỗi của Bên B.\n\n");
            
            // Điều 5
            AppendTextWithFormat("ĐIỀU 5: QUYỀN VÀ NGHĨA VỤ CỦA BÊN B", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("5.1. Quyền của Bên B:\n");
            rtbTemplate.AppendText("   - Nhận nhà thuê đúng thời hạn đã thỏa thuận.\n");
            rtbTemplate.AppendText("   - Yêu cầu Bên A sửa chữa những hư hỏng không do lỗi của mình.\n");
            rtbTemplate.AppendText("   - Được đơn phương chấm dứt hợp đồng khi Bên A vi phạm nghiêm trọng các điều khoản đã thỏa thuận.\n");
            rtbTemplate.AppendText("5.2. Nghĩa vụ của Bên B:\n");
            rtbTemplate.AppendText("   - Sử dụng nhà đúng mục đích đã thỏa thuận.\n");
            rtbTemplate.AppendText("   - Thanh toán đầy đủ, đúng hạn tiền thuê nhà và các chi phí liên quan.\n");
            rtbTemplate.AppendText("   - Bảo quản, giữ gìn nhà và tài sản trong nhà.\n");
            rtbTemplate.AppendText("   - Trả nhà đúng hiện trạng ban đầu khi kết thúc hợp đồng.\n\n");
            
            // Điều 6
            AppendTextWithFormat("ĐIỀU 6: CHẤM DỨT HỢP ĐỒNG", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("6.1. Hợp đồng chấm dứt trong các trường hợp sau:\n");
            rtbTemplate.AppendText("   - Hết thời hạn ghi trong hợp đồng.\n");
            rtbTemplate.AppendText("   - Theo thỏa thuận của các bên về việc chấm dứt hợp đồng trước thời hạn.\n");
            rtbTemplate.AppendText("   - Một bên đơn phương chấm dứt hợp đồng khi bên kia vi phạm nghiêm trọng các nghĩa vụ.\n\n");
            
            // Điều 7
            AppendTextWithFormat("ĐIỀU 7: ĐIỀU KHOẢN CHUNG", HorizontalAlignment.Left, 12, true, false);
            rtbTemplate.AppendText("\n");
            rtbTemplate.AppendText("7.1. Hai bên cam kết thực hiện đúng và đầy đủ các điều khoản của hợp đồng.\n");
            rtbTemplate.AppendText("7.2. Mọi sửa đổi, bổ sung hợp đồng phải được lập thành văn bản có chữ ký của hai bên.\n");
            rtbTemplate.AppendText("7.3. Mọi tranh chấp phát sinh sẽ được giải quyết trên tinh thần hòa giải. Trường hợp không thể giải quyết được, sẽ đưa ra Tòa án có thẩm quyền để giải quyết.\n");
            rtbTemplate.AppendText("7.4. Hợp đồng này có hiệu lực kể từ ngày ký.\n");
            rtbTemplate.AppendText("7.5. Hợp đồng được lập thành 02 bản có giá trị như nhau, mỗi bên giữ 01 bản.\n\n");
            
            // Phần ký tên - Thêm khoảng trống đủ để hiển thị đầy đủ
            rtbTemplate.AppendText("\n\n");
            
            // Tạo bảng chữ ký 2 cột
            rtbTemplate.SelectionStart = rtbTemplate.TextLength;
            rtbTemplate.SelectionLength = 0;
            rtbTemplate.SelectionTabs = new int[] { 200, 400 };
            
            // Tạo tiêu đề hai bên
            rtbTemplate.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            rtbTemplate.AppendText("BÊN CHO THUÊ (BÊN A)");
            rtbTemplate.AppendText("\t");
            rtbTemplate.AppendText("BÊN THUÊ (BÊN B)");
            rtbTemplate.AppendText("\n");
            
            // Thêm dòng "(Ký và ghi rõ họ tên)"
            rtbTemplate.SelectionFont = new Font("Arial", 11, FontStyle.Italic);
            rtbTemplate.AppendText("(Ký và ghi rõ họ tên)");
            rtbTemplate.AppendText("\t");
            rtbTemplate.AppendText("(Ký và ghi rõ họ tên)");
            rtbTemplate.AppendText("\n\n\n\n\n");
            
            // Thêm dòng chấm chấm để ký tên
            rtbTemplate.SelectionFont = new Font("Arial", 11, FontStyle.Regular);
            rtbTemplate.AppendText("...............................");
            rtbTemplate.AppendText("\t");
            rtbTemplate.AppendText("...............................");
            rtbTemplate.AppendText("\n\n\n");
            
            // Thêm khoảng trống cuối trang để có thể kéo xuống
            rtbTemplate.AppendText("\n\n\n");
            
            rtbTemplate.SelectionStart = 0;
            rtbTemplate.ScrollToCaret();
        }

        // Phương thức hỗ trợ thêm văn bản có định dạng
        private void AppendTextWithFormat(string text, HorizontalAlignment alignment, float fontSize, bool isBold, bool isItalic, int? xPos = null, int? yPos = null)
        {
            // Lưu vị trí hiện tại
            int currentPosition = rtbTemplate.SelectionStart;
            
            // Đặt vị trí cụ thể nếu được chỉ định
            if (xPos.HasValue && yPos.HasValue)
            {
                rtbTemplate.SelectionStart = rtbTemplate.TextLength;
                rtbTemplate.SelectionLength = 0;
            }
            
            // Thiết lập định dạng
            rtbTemplate.SelectionAlignment = alignment;
            
            // Tạo font
            FontStyle style = FontStyle.Regular;
            if (isBold) style |= FontStyle.Bold;
            if (isItalic) style |= FontStyle.Italic;
            rtbTemplate.SelectionFont = new Font("Arial", fontSize, style);
            
            // Thêm văn bản
            rtbTemplate.AppendText(text);
            
            // Thiết lập lại định dạng mặc định
            rtbTemplate.SelectionFont = new Font("Arial", 11, FontStyle.Regular);
            rtbTemplate.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void LoadTemplateList()
        {
            try
            {
                // Create Templates directory if it doesn't exist
                if (!Directory.Exists(templatesPath))
                {
                    Directory.CreateDirectory(templatesPath);
                }

                // Clear the combobox
                cboTemplates.Items.Clear();

                // Add all RTF files from the Templates directory
                string[] files = Directory.GetFiles(templatesPath, "*.rtf");
                foreach (string file in files)
                {
                    cboTemplates.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách mẫu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate template name
                if (string.IsNullOrWhiteSpace(txtTemplateName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên mẫu hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTemplateName.Focus();
                    return;
                }

                // Create file name
                string fileName = Path.Combine(templatesPath, txtTemplateName.Text + ".rtf");

                // Save RTF content
                rtbTemplate.SaveFile(fileName, RichTextBoxStreamType.RichText);

                MessageBox.Show("Mẫu hợp đồng đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload template list
                LoadTemplateList();
                
                // Select the newly saved template
                cboTemplates.SelectedItem = txtTemplateName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu mẫu hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTemplates.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn một mẫu để tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get selected template file path
                string fileName = Path.Combine(templatesPath, cboTemplates.SelectedItem.ToString() + ".rtf");

                // Load RTF content
                rtbTemplate.LoadFile(fileName, RichTextBoxStreamType.RichText);

                // Update template name textbox
                txtTemplateName.Text = cboTemplates.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mẫu hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // If no template name is provided, ask user to save first
                if (string.IsNullOrWhiteSpace(txtTemplateName.Text))
                {
                    MessageBox.Show("Vui lòng lưu mẫu trước khi xuất PDF.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTemplateName.Focus();
                    return;
                }

                // Tạo một file RTF tạm thời
                string rtfFile = Path.Combine(templatesPath, txtTemplateName.Text + ".rtf");
                
                // Lưu phiên bản mới nhất của mẫu
                rtbTemplate.SaveFile(rtfFile, RichTextBoxStreamType.RichText);

                // Tạo đường dẫn file PDF
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveDialog.FileName = txtTemplateName.Text + ".pdf";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string pdfFile = saveDialog.FileName;

                    // Phương pháp đơn giản: Sử dụng Word để chuyển đổi RTF sang PDF nếu có
                    DialogResult result = MessageBox.Show(
                        "Bạn muốn sử dụng phương thức nào để xuất PDF?\n\n" +
                        "- Yes: Sử dụng Microsoft Word (nếu đã cài)\n" +
                        "- No: Sử dụng chức năng In (Print to PDF)",
                        "Chọn phương thức",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Phương thức 1: Sử dụng Microsoft Word nếu có
                        try
                        {
                            // Tạo đường dẫn tạm thời cho file Word
                            string tempDocxFile = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(pdfFile) + ".docx");
                            
                            // Tạo đối tượng Word.Application để chuyển đổi RTF sang PDF
                            Type wordType = Type.GetTypeFromProgID("Word.Application");
                            if (wordType != null)
                            {
                                dynamic wordApp = Activator.CreateInstance(wordType);
                                wordApp.Visible = false;
                                
                                // Mở file RTF
                                dynamic doc = wordApp.Documents.Open(rtfFile);
                                
                                // Lưu dưới dạng PDF
                                object outputFileName = pdfFile;
                                object fileFormat = 17; // wdFormatPDF
                                doc.SaveAs2(ref outputFileName, ref fileFormat);
                                
                                // Đóng tài liệu và Word
                                doc.Close();
                                wordApp.Quit();
                                
                                // Mở file PDF vừa tạo
                                MessageBox.Show("Đã xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Process.Start(pdfFile);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy Microsoft Word trên máy tính. Vui lòng sử dụng phương thức in PDF.", 
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                UsePrintToPDFMethod(pdfFile);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi sử dụng Microsoft Word: " + ex.Message + "\nChuyển sang phương thức in PDF.", 
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            UsePrintToPDFMethod(pdfFile);
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        // Phương thức 2: Sử dụng Print to PDF
                        UsePrintToPDFMethod(pdfFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsePrintToPDFMethod(string pdfFile)
        {
            MessageBox.Show(
                "Hệ thống sẽ mở hộp thoại in. Vui lòng:\n\n" +
                "1. Chọn 'Microsoft Print to PDF' từ danh sách máy in\n" +
                "2. Nhấn 'Print'\n" +
                "3. Lưu file với tên đã chọn\n\n" +
                "Lưu ý: Chọn đúng vị trí lưu file là quan trọng để tìm thấy file PDF sau này.",
                "Hướng dẫn xuất PDF", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );

            // In trực tiếp từ RichTextBox sử dụng PrintDocument
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Contract Template";
            
            // Xử lý sự kiện in trang
            printDoc.PrintPage += (sender, e) => {
                // Lấy nội dung của RichTextBox
                string text = rtbTemplate.Text;
                Font printFont = rtbTemplate.Font;
                
                // Vẽ nội dung lên trang
                e.Graphics.DrawString(text, printFont, Brushes.Black, e.MarginBounds);
            };
            
            // Hiển thị hộp thoại in
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
            
            // Kiểm tra xem file có tồn tại không 
            if (File.Exists(pdfFile))
            {
                if (MessageBox.Show("Bạn có muốn mở file PDF vừa tạo không?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try { Process.Start(pdfFile); }
                    catch { MessageBox.Show("Không thể mở file PDF. Vui lòng mở thủ công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
            else
            {
                MessageBox.Show(
                    "File PDF đã được tạo nhưng có thể được lưu ở vị trí khác.\n" +
                    "Vui lòng kiểm tra vị trí bạn đã chọn trong hộp thoại lưu file.",
                    "Thông báo", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
            }
        }

        private void AddExportPDFDirectButton()
        {
            // Tạo nút xuất PDF trực tiếp mới
            this.btnExportPDFDirect = new System.Windows.Forms.Button();
            this.btnExportPDFDirect.Location = new System.Drawing.Point(417, 533);
            this.btnExportPDFDirect.Name = "btnExportPDFDirect";
            this.btnExportPDFDirect.Size = new System.Drawing.Size(113, 34);
            this.btnExportPDFDirect.TabIndex = 8;
            this.btnExportPDFDirect.Text = "Xuất PDF+";
            this.btnExportPDFDirect.UseVisualStyleBackColor = true;
            this.btnExportPDFDirect.Click += new System.EventHandler(this.btnExportPDFDirect_Click);
            
            // Thêm nút vào form
            this.Controls.Add(this.btnExportPDFDirect);
        }

        // Thêm xử lý sự kiện cho nút mới
        private void btnExportPDFDirect_Click(object sender, EventArgs e)
        {
            try
            {
                // If no template name is provided, ask user to save first
                if (string.IsNullOrWhiteSpace(txtTemplateName.Text))
                {
                    MessageBox.Show("Vui lòng lưu mẫu trước khi xuất PDF.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTemplateName.Focus();
                    return;
                }

                // Tạo một file RTF tạm thời
                string rtfFile = Path.Combine(templatesPath, txtTemplateName.Text + ".rtf");
                
                // Lưu phiên bản mới nhất của mẫu
                rtbTemplate.SaveFile(rtfFile, RichTextBoxStreamType.RichText);

                // Tạo đường dẫn file PDF
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveDialog.FileName = txtTemplateName.Text + ".pdf";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string pdfFile = saveDialog.FileName;
                    
                    // Sử dụng phương thức chuyển đổi HTML sang PDF
                    UsePDFDirectMethod(pdfFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm phương thức chuyển đổi RichText sang HTML cơ bản
        private string ConvertRichTextToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html>");
            html.Append("<html>");
            html.Append("<head>");
            html.Append("<meta charset='utf-8'>");
            html.Append("<title>Hợp đồng thuê nhà</title>");
            html.Append("<style>");
            html.Append("body { font-family: 'Arial', sans-serif; margin: 40px; line-height: 1.5; }");
            html.Append("h1 { text-align: center; font-size: 18pt; margin-bottom: 20px; }");
            html.Append("h2 { text-align: center; font-size: 14pt; margin-bottom: 15px; }");
            html.Append("h3 { font-size: 13pt; font-weight: bold; margin-top: 20px; margin-bottom: 10px; }");
            html.Append("p { margin: 10px 0; }");
            html.Append(".contract-number { text-align: center; font-weight: bold; margin-bottom: 20px; }");
            html.Append(".signature { margin-top: 50px; display: flex; justify-content: space-between; }");
            html.Append(".signature div { width: 45%; text-align: center; }");
            html.Append(".content { text-align: justify; }");
            html.Append("</style>");
            html.Append("</head>");
            html.Append("<body>");
            
            // Nội dung từ RichTextBox được chuyển sang HTML
            // Đầu tiên lấy nội dung văn bản
            string plainText = rtbTemplate.Text;
            
            // Thêm đánh dấu HTML cơ bản cho tiêu đề
            html.Append("<h1>HỢP ĐỒNG THUÊ NHÀ</h1>");
            
            // Xử lý số hợp đồng
            if (plainText.Contains("[SỐ_HỢP_ĐỒNG]"))
            {
                html.Append("<div class='contract-number'>Số: [SỐ_HỢP_ĐỒNG]</div>");
            }
            
            // Thêm phần nội dung chính
            string[] lines = plainText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            bool inHeader = true;
            bool inArticle = false;
            
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                
                // Bỏ qua các dòng đã xử lý ở phần đầu
                if (inHeader && (trimmedLine.Contains("HỢP ĐỒNG THUÊ NHÀ") || trimmedLine.Contains("[SỐ_HỢP_ĐỒNG]")))
                {
                    continue;
                }
                
                // Không còn ở phần header
                inHeader = false;
                
                // Xử lý các tiêu đề điều khoản
                if (trimmedLine.StartsWith("ĐIỀU "))
                {
                    inArticle = true;
                    html.Append($"<h3>{trimmedLine}</h3>");
                    continue;
                }
                
                // Xử lý tên bên A, bên B
                if (trimmedLine.Contains("BÊN CHO THUÊ") || trimmedLine.Contains("BÊN THUÊ"))
                {
                    html.Append($"<h3>{trimmedLine}</h3>");
                    continue;
                }
                
                // Phần nội dung bình thường
                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    html.Append($"<p class='content'>{trimmedLine}</p>");
                }
                else
                {
                    html.Append("<br/>");
                }
            }
            
            // Thêm phần chữ ký
            html.Append("<div class='signature' style='display: flex; justify-content: space-between; margin-top: 50px;'>");
            
            // Bên A
            html.Append("<div style='width: 45%; text-align: center;'>");
            html.Append("<p><strong>BÊN CHO THUÊ (BÊN A)</strong></p>");
            html.Append("<p><em>(Ký và ghi rõ họ tên)</em></p>");
            html.Append("<br/><br/><br/>");
            html.Append("<p>.................................</p>");
            html.Append("</div>");
            
            // Bên B
            html.Append("<div style='width: 45%; text-align: center;'>");
            html.Append("<p><strong>BÊN THUÊ (BÊN B)</strong></p>");
            html.Append("<p><em>(Ký và ghi rõ họ tên)</em></p>");
            html.Append("<br/><br/><br/>");
            html.Append("<p>.................................</p>");
            html.Append("</div>");
            
            html.Append("</div>");
            
            html.Append("</body>");
            html.Append("</html>");
            
            return html.ToString();
        }

        // Thêm phương thức xuất PDF trực tiếp từ HTML
        private void UsePDFDirectMethod(string pdfFile)
        {
            try 
            {
                // Lưu nội dung RichTextBox dưới dạng RTF vào thư mục tạm
                string tempRtfPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(Path.GetTempFileName()) + ".rtf");
                rtbTemplate.SaveFile(tempRtfPath, RichTextBoxStreamType.RichText);

                // Tạo một file HTML tạm để chuyển đổi RTF sang HTML
                string tempHtmlPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(Path.GetTempFileName()) + ".html");
                
                // Chuyển đổi nội dung RichTextBox sang HTML cơ bản
                string htmlContent = ConvertRichTextToHtml();
                File.WriteAllText(tempHtmlPath, htmlContent, Encoding.UTF8);

                // Thông báo cho người dùng
                MessageBox.Show(
                    "Hệ thống đang chuẩn bị tạo file PDF...\n\n" +
                    "Chức năng này yêu cầu máy tính có cài đặt trình duyệt web.\n" +
                    "Sau khi hoàn tất, file PDF sẽ được mở tự động.",
                    "Đang xử lý", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                // Tạo lệnh để chuyển đổi HTML sang PDF bằng Print to PDF của trình duyệt
                // Sử dụng Chrome hoặc Edge nếu có
                string chromeCommand = $"chrome --headless --disable-gpu --print-to-pdf=\"{pdfFile}\" \"{tempHtmlPath}\"";
                string edgeCommand = $"msedge --headless --disable-gpu --print-to-pdf=\"{pdfFile}\" \"{tempHtmlPath}\"";
                
                // Thử sử dụng Chrome trước
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {chromeCommand}",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                try 
                {
                    using (Process process = Process.Start(psi))
                    {
                        process.WaitForExit(10000); // Đợi tối đa 10 giây
                    }
                    
                    // Kiểm tra xem file có được tạo không
                    if (File.Exists(pdfFile))
                    {
                        // Thành công với Chrome
                        // Xóa các file tạm
                        try { File.Delete(tempRtfPath); } catch { }
                        try { File.Delete(tempHtmlPath); } catch { }
                        
                        // Mở file PDF
                        MessageBox.Show("PDF đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(pdfFile);
                        return;
                    }
                }
                catch { /* Nếu Chrome không tồn tại hoặc không thành công, thử Edge */ }

                // Thử với Edge
                psi.Arguments = $"/c {edgeCommand}";
                try 
                {
                    using (Process process = Process.Start(psi))
                    {
                        process.WaitForExit(10000); // Đợi tối đa 10 giây
                    }
                    
                    // Kiểm tra xem file có được tạo không
                    if (File.Exists(pdfFile))
                    {
                        // Thành công với Edge
                        // Xóa các file tạm
                        try { File.Delete(tempRtfPath); } catch { }
                        try { File.Delete(tempHtmlPath); } catch { }
                        
                        // Mở file PDF
                        MessageBox.Show("PDF đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(pdfFile);
                        return;
                    }
                }
                catch { /* Nếu Edge không tồn tại hoặc không thành công, chuyển sang phương pháp in */ }

                // Nếu cả hai cách trên đều không thành công, sử dụng phương pháp in
                MessageBox.Show(
                    "Không thể tạo PDF tự động. Hệ thống sẽ mở hộp thoại in.\n\n" +
                    "Vui lòng:\n" +
                    "1. Chọn 'Microsoft Print to PDF' từ danh sách máy in\n" +
                    "2. Nhấn 'Print'\n" +
                    "3. Lưu file với tên đã chọn\n\n" +
                    "Lưu ý: Chọn đúng vị trí lưu file để dễ dàng tìm thấy file PDF sau này.",
                    "Hướng dẫn xuất PDF", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                // In trực tiếp từ RichTextBox sử dụng PrintDocument
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = "Contract Template";
                
                // Xử lý sự kiện in trang
                printDoc.PrintPage += (sender, e) => {
                    // Lấy nội dung của RichTextBox
                    string text = rtbTemplate.Text;
                    Font printFont = rtbTemplate.Font;
                    
                    // Vẽ nội dung lên trang
                    e.Graphics.DrawString(text, printFont, Brushes.Black, e.MarginBounds);
                };
                
                // Hiển thị hộp thoại in
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }

                // Xóa file tạm
                try { File.Delete(tempRtfPath); } catch { }
                try { File.Delete(tempHtmlPath); } catch { }

                // Mở file sau khi in xong
                if (File.Exists(pdfFile))
                {
                    if (MessageBox.Show("Bạn có muốn mở file PDF vừa tạo không?", "Xác nhận", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(pdfFile);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "File PDF đã được tạo nhưng có thể đã được lưu ở vị trí khác.\n" +
                        "Vui lòng kiểm tra vị trí bạn đã chọn trong hộp thoại lưu file.",
                        "Thông báo", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Quay lại phương pháp in cơ bản nếu có lỗi
                MessageBox.Show(
                    "Hệ thống sẽ mở hộp thoại in. Vui lòng:\n\n" +
                    "1. Chọn 'Microsoft Print to PDF' từ danh sách máy in\n" +
                    "2. Nhấn 'Print'\n" +
                    "3. Lưu file với tên đã chọn\n\n" +
                    "Lưu ý: Chọn đúng vị trí lưu file là quan trọng để tìm thấy file PDF sau này.",
                    "Hướng dẫn xuất PDF", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                // In trực tiếp từ RichTextBox sử dụng PrintDocument
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = "Contract Template";
                
                // Xử lý sự kiện in trang
                printDoc.PrintPage += (sender, e) => {
                    // Lấy nội dung của RichTextBox
                    string text = rtbTemplate.Text;
                    Font printFont = rtbTemplate.Font;
                    
                    // Vẽ nội dung lên trang
                    e.Graphics.DrawString(text, printFont, Brushes.Black, e.MarginBounds);
                };
                
                // Hiển thị hộp thoại in
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }
    }
} 