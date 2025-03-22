using GUI.Custom;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public class TenantForm : CustomForm
    {
        // Thêm biến thành viên để lưu trữ các controls
        private MyGunaTextBox[] textBoxes;
        private MyGunaButton btnSubmit;

        public TenantForm()
        {
            this.Text = "Tenant Information";
            this.Size = new System.Drawing.Size(500, 600);
            this.FormBorderStyle = FormBorderStyle.None;

            Label lblTitle = new Label()
            {
                Text = "Thông Tin Khách Thuê",
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            int startY = 60;
            int spacing = 50;

            string[] labels = { "Tenant ID", "First Name", "Last Name", "Birthday", "Gender", "Phone Number", "Email", "Profile Picture" };
            textBoxes = new MyGunaTextBox[labels.Length]; // Chuyển thành biến thành viên

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label()
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(20, startY + (i * spacing)),
                    AutoSize = true
                };
                this.Controls.Add(lbl);

                textBoxes[i] = new MyGunaTextBox()
                {
                    Location = new System.Drawing.Point(150, startY + (i * spacing)),
                    Width = 300
                };
                this.Controls.Add(textBoxes[i]);
            }

            btnSubmit = new MyGunaButton() // Chuyển thành biến thành viên
            {
                Text = "Submit",
                Location = new System.Drawing.Point(150, startY + labels.Length * spacing + 10),
                Width = 100
            };
            // Thêm sự kiện Click
            btnSubmit.Click += btnSubmit_Click;
            this.Controls.Add(btnSubmit);

            // Tự động tạo ID khách thuê
            GenerateTenantId();
            textBoxes[0].Enabled = true; // Không cho sửa ID
        }

        private void GenerateTenantId()
        {
            try
            {
                ThongtinkhachthueBLL tenantBLL = new ThongtinkhachthueBLL();
                List<ThongtinkhachthueDTO> tenants = tenantBLL.GetAllTenants();

                //string prefix = "T";
                //int nextNumber = tenants.Count + 1;

                //textBoxes[0].Text = $"{prefix}{nextNumber.ToString("D4")}";
            }
            catch (Exception)
            {
                // Nếu có lỗi, dùng timestamp
                textBoxes[0].Text = $"TN{DateTime.Now.ToString("yyMMddHHmmss")}";
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TenantForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "TenantForm";
            this.Load += new System.EventHandler(this.TenantForm_Load);
            this.ResumeLayout(false);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu
                if (!ValidateData())
                    return;

                // Tạo đối tượng DTO
                ThongtinkhachthueDTO tenant = new ThongtinkhachthueDTO(
                    textBoxes[0].Text.Trim(),                        // TenantID
                    textBoxes[1].Text.Trim(),                        // FirstName
                    textBoxes[2].Text.Trim(),                        // LastName
                    DateTime.Parse(textBoxes[3].Text.Trim()),        // Birthday
                    textBoxes[4].Text.Trim(),                        // Gender
                    textBoxes[5].Text.Trim(),                        // PhoneNumber
                    textBoxes[6].Text.Trim(),                        // Email
                    string.IsNullOrEmpty(textBoxes[7].Text.Trim()) ? null : textBoxes[7].Text.Trim() // ProfilePicture
                );

                // Lưu thông tin khách thuê
                ThongtinkhachthueBLL tenantBLL = new ThongtinkhachthueBLL();
                bool result = tenantBLL.SaveTenant(tenant);

                if (result)
                {
                    MessageBox.Show("Thêm khách thuê thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm khách thuê thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateData()
        {
            // Kiểm tra trường bắt buộc
            if (string.IsNullOrWhiteSpace(textBoxes[1].Text)) // FirstName
            {
                MessageBox.Show("Vui lòng nhập tên khách thuê!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxes[1].Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxes[2].Text)) // LastName
            {
                MessageBox.Show("Vui lòng nhập họ khách thuê!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxes[2].Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxes[3].Text)) // Birthday
            {
                MessageBox.Show("Vui lòng nhập ngày sinh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxes[3].Focus();
                return false;
            }

            try
            {
                DateTime birthday = DateTime.Parse(textBoxes[3].Text);
            }
            catch
            {
                MessageBox.Show("Ngày sinh không hợp lệ! (MM/dd/yyyy)", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxes[3].Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxes[4].Text)) // Gender
            {
                MessageBox.Show("Vui lòng nhập giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxes[4].Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxes[5].Text)) // PhoneNumber
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxes[5].Focus();
                return false;
            }

            return true;
        }

        private void TenantForm_Load(object sender, EventArgs e)
        {
            // Không cần thêm code ở đây
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}