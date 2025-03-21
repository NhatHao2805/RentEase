using DTO;
using GUI.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class SignLiving : CustomForm
    {
        public SignLiving()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "Đăng Ký Tạm Trú";
            this.Size = new System.Drawing.Size(800, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add controls
            SetupFormControls();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupFormControls()
        {
            // Labels
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "THÔNG TIN ĐĂNG KÝ TẠM TRÚ";
            lblTitle.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(250, 20);
            this.Controls.Add(lblTitle);

            int labelWidth = 100;
            int textBoxWidth = 175; // Rút ngắn xuống còn 100px
            int textBoxHeight = 30; // Tăng chiều cao lên 30px
            int addressWidth = 250; // Giữ nguyên chiều dài cho địa chỉ
            int marginLeft = 50;
            int marginTop = 70;
            int verticalSpacing = 50; // Tăng khoảng cách dọc do tăng chiều cao control
            int horizontalSpacing = 40;

            // TENANTID - Required field
            CreateLabelAndTextBox("ID người thuê:", "txtTenantId", marginLeft, marginTop, labelWidth, textBoxWidth, textBoxHeight, true);

            // First and Last Name on the same row
            CreateLabelAndTextBox("Họ:", "txtLastName", marginLeft, marginTop + verticalSpacing, labelWidth, textBoxWidth, textBoxHeight);
            CreateLabelAndTextBox("Tên:", "txtFirstName", marginLeft + labelWidth + textBoxWidth + horizontalSpacing, marginTop + verticalSpacing, labelWidth, textBoxWidth, textBoxHeight);

            // Birthday and Gender on the same row
            CreateLabelAndTextBox("Ngày sinh:", "dtpBirthday", marginLeft, marginTop + verticalSpacing * 2, labelWidth, textBoxWidth, textBoxHeight, false, "date");
            CreateLabelAndTextBox("Giới tính:", "cboGender", marginLeft + labelWidth + textBoxWidth + horizontalSpacing, marginTop + verticalSpacing * 2, labelWidth, textBoxWidth, textBoxHeight, false, "combobox", new string[] { "Nam", "Nữ" }); // Chỉ Nam hoặc Nữ

            // Phone and Email on the same row
            CreateLabelAndTextBox("Số điện thoại:", "txtPhoneNumber", marginLeft, marginTop + verticalSpacing * 3, labelWidth, textBoxWidth, textBoxHeight);
            CreateLabelAndTextBox("Email:", "txtEmail", marginLeft + labelWidth + textBoxWidth + horizontalSpacing, marginTop + verticalSpacing * 3, labelWidth, textBoxWidth, textBoxHeight);

            // Addresses - each on their own row since they're longer
            CreateLabelAndTextBox("Địa chỉ thường trú:", "txtPermanentAddress", marginLeft, marginTop + verticalSpacing * 4, labelWidth, addressWidth * 2, textBoxHeight);
            CreateLabelAndTextBox("Địa chỉ đăng ký:", "txtRegistedAddress", marginLeft, marginTop + verticalSpacing * 5, labelWidth, addressWidth * 2, textBoxHeight);

            // Start Date and Expiry Date on the same row
            CreateLabelAndTextBox("Ngày bắt đầu:", "dtpStartDate", marginLeft, marginTop + verticalSpacing * 6, labelWidth, textBoxWidth, textBoxHeight, false, "date");
            CreateLabelAndTextBox("Ngày hết hạn:", "dtpExpiryDate", marginLeft + labelWidth + textBoxWidth + horizontalSpacing, marginTop + verticalSpacing * 6, labelWidth, textBoxWidth, textBoxHeight, false, "date");

            // Notes
            CreateLabelAndTextBox("Ghi chú:", "txtNotes", marginLeft, marginTop + verticalSpacing * 7, labelWidth, addressWidth * 2, textBoxHeight * 2, false, "multiline");

            // Registration File Path
            CreateLabelAndTextBox("Đường dẫn giấy tờ:", "txtRegistrationFilePath", marginLeft, marginTop + verticalSpacing * 9, labelWidth, addressWidth * 2, textBoxHeight);

            // Browse button for file path
            MyGunaButton btnBrowse = new MyGunaButton();
            btnBrowse.Text = "Chọn tệp";
            btnBrowse.Location = new System.Drawing.Point(marginLeft + labelWidth + addressWidth * 2 + 10, marginTop + verticalSpacing * 9);
            btnBrowse.Size = new System.Drawing.Size(100, textBoxHeight);
            btnBrowse.Click += new EventHandler(BtnBrowse_Click);
            this.Controls.Add(btnBrowse);

            // Action buttons
            MyGunaButton btnSave = new MyGunaButton();
            btnSave.Text = "Lưu";
            btnSave.Location = new System.Drawing.Point(marginLeft + labelWidth + textBoxWidth, marginTop + verticalSpacing * 11);
            btnSave.Size = new System.Drawing.Size(100, 35);
            btnSave.Click += new EventHandler(BtnSave_Click);
            this.Controls.Add(btnSave);

            MyGunaButton btnCancel = new MyGunaButton();
            btnCancel.Text = "Hủy";
            btnCancel.Location = new System.Drawing.Point(marginLeft + labelWidth + textBoxWidth + 120, marginTop + verticalSpacing * 11);
            btnCancel.Size = new System.Drawing.Size(100, 35);
            btnCancel.Click += new EventHandler(BtnCancel_Click);
            this.Controls.Add(btnCancel);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các control
                string tenantId = GetControlValue("txtTenantId");
                string lastName = GetControlValue("txtLastName");
                string firstName = GetControlValue("txtFirstName");
                DateTime birthday = GetDateTimePickerValue("dtpBirthday");
                string gender = GetComboBoxValue("cboGender");
                string phoneNumber = GetControlValue("txtPhoneNumber");
                string email = GetControlValue("txtEmail");
                string permanentAddress = GetControlValue("txtPermanentAddress");
                string registeredAddress = GetControlValue("txtRegistedAddress");
                DateTime startDate = GetDateTimePickerValue("dtpStartDate");
                DateTime expiryDate = GetDateTimePickerValue("dtpExpiryDate");
                string notes = GetControlValue("txtNotes");
                string registrationFilePath = GetControlValue("txtRegistrationFilePath");

                // Kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrEmpty(tenantId))
                {
                    MessageBox.Show("Vui lòng nhập ID người thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng TemporaryResidenceDTO
                TemporaryResidenceDTO residence = new TemporaryResidenceDTO(
                    tenantId,
                    firstName,
                    lastName,
                    birthday,
                    gender,
                    phoneNumber,
                    email,
                    permanentAddress,
                    registeredAddress,
                    startDate,
                    notes,
                    expiryDate,
                    registrationFilePath
                );

                // Lưu vào database thông qua BLL
                TemporaryResidenceBLL bll = new TemporaryResidenceBLL();
                bool success = bll.AddTemporaryResidence(residence);

                if (success)
                {
                    MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể lưu thông tin. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetControlValue(string controlName)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MyGunaTextBox && control.Name == controlName)
                {
                    return ((MyGunaTextBox)control).Text;
                }
            }
            return string.Empty;
        }

        private DateTime GetDateTimePickerValue(string controlName)
        {
            foreach (Control control in this.Controls)
            {
                if (control is DateTimePicker && control.Name == controlName)
                {
                    return ((DateTimePicker)control).Value;
                }
            }
            return DateTime.Now;
        }

        private string GetComboBoxValue(string controlName)
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox && control.Name == controlName)
                {
                    return ((ComboBox)control).SelectedItem?.ToString() ?? string.Empty;
                }
            }
            return string.Empty;
        }

        private void CreateLabelAndTextBox(string labelText, string textBoxName, int x, int y, int labelWidth, int textBoxWidth, int height, bool required = false, string type = "text", string[] items = null)
        {
            // Create label
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = labelText + (required ? " *" : "");
            label.Location = new System.Drawing.Point(x, y + height / 2 - 10); // Điều chỉnh vị trí label để căn giữa với textbox cao hơn
            label.Size = new System.Drawing.Size(labelWidth, height);
            label.AutoSize = true;
            this.Controls.Add(label);

            // Create appropriate control based on type
            if (type == "date")
            {
                // Sử dụng thực sự DateTimePicker thay vì MyGunaTextBox
                DateTimePicker dateTimePicker = new DateTimePicker();
                dateTimePicker.Name = textBoxName;
                dateTimePicker.Location = new System.Drawing.Point(x + labelWidth, y);
                dateTimePicker.Size = new System.Drawing.Size(textBoxWidth, height);
                dateTimePicker.Format = DateTimePickerFormat.Short;
                this.Controls.Add(dateTimePicker);
            }
            else if (type == "combobox")
            {
                // Sử dụng ComboBox thực sự cho giới tính
                ComboBox comboBox = new ComboBox();
                comboBox.Name = textBoxName;
                comboBox.Location = new System.Drawing.Point(x + labelWidth, y);
                comboBox.Size = new System.Drawing.Size(textBoxWidth, height);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                // Thêm các item
                if (items != null)
                {
                    foreach (string item in items)
                    {
                        comboBox.Items.Add(item);
                    }
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                this.Controls.Add(comboBox);
            }
            else if (type == "multiline")
            {
                // Create a multiline textbox for notes
                MyGunaTextBox multilineBox = new MyGunaTextBox();
                multilineBox.Name = textBoxName;
                multilineBox.Location = new System.Drawing.Point(x + labelWidth, y);
                multilineBox.Size = new System.Drawing.Size(textBoxWidth, height);
                multilineBox.Tag = "multiline";
                this.Controls.Add(multilineBox);
            }
            else
            {
                // Default text box
                MyGunaTextBox textBox = new MyGunaTextBox();
                textBox.Name = textBoxName;
                textBox.Location = new System.Drawing.Point(x + labelWidth, y);
                textBox.Size = new System.Drawing.Size(textBoxWidth, height);
                this.Controls.Add(textBox);
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Code to open file dialog would go here
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Files|*.pdf|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog.FileName;

                // Find the textbox and set its text to the file path
                foreach (Control control in this.Controls)
                {
                    if (control is MyGunaTextBox && control.Name == "txtRegistrationFilePath")
                    {
                        ((MyGunaTextBox)control).Text = filePath;
                        break;
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}





