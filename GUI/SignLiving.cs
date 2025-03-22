using BLL;
using DTO;
using GUI.Custom;
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
    public partial class SignLiving: Form
    {
        public SignLiving()
        {
            InitializeComponent();
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
