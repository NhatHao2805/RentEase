using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GUI.Custom;
using DTO;
using BLL;

namespace GUI
{
    public class ContractForm : CustomForm
    {
        private MyGunaTextBox txtContractID;
        private MyGunaTextBox txtHouseID;
        private MyGunaTextBox txtTenantID;

        private DateTimePicker dtpCreateDate;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private MyGunaTextBox txtMonthlyRent;
        private MyGunaTextBox txtPaymentSchedule;
        private MyGunaTextBox txtDeposit;

        private MyGunaTextBox txtStatus;
        private MyGunaTextBox txtNotes;

        private CustomButton btnSubmit;
        private ContractBLL contractBLL;
        private ThongtinkhachthueBLL tenantBLL;

        public ContractForm()
        {
            InitializeControls();
            InitializeEventHandlers();
            contractBLL = new ContractBLL();
            tenantBLL = new ThongtinkhachthueBLL();
        }

        private void InitializeControls()
        {
            this.Text = "Create Contract";
            this.Size = new Size(700, 600);

            Label titleLabel = new Label()
            {
                Text = "Create New Contract",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(150, 20)
            };

            // Sử dụng các hàm create có sẵn
            string[] labels = { "Contract ID", "House ID", "Tenant ID", "Create Date", "Start Date", "End Date", "Monthly Rent", "Payment Schedule", "Deposit", "Status", "Notes" };
            int startY = 70;
            int spacing = 40;
            int labelX = 75;
            int controlX = 240;

            // Contract ID
            txtContractID = CreateTextBox(controlX, startY);

            this.Controls.Add(CreateLabel(labels[0], labelX, startY));
            this.Controls.Add(txtContractID);

            // House ID
            txtHouseID = CreateTextBox(controlX, startY + spacing);

            this.Controls.Add(CreateLabel(labels[1], labelX, startY + spacing));
            this.Controls.Add(txtHouseID);

            // Tenant ID
            txtTenantID = CreateTextBox(controlX, startY + spacing * 2);

            this.Controls.Add(CreateLabel(labels[2], labelX, startY + spacing * 2));
            this.Controls.Add(txtTenantID);

            // Create Date
            dtpCreateDate = CreateDatePicker(controlX, startY + spacing * 3);
            dtpCreateDate.Value = DateTime.Now;
            this.Controls.Add(CreateLabel(labels[3], labelX, startY + spacing * 3));
            this.Controls.Add(dtpCreateDate);

            // Start Date
            dtpStartDate = CreateDatePicker(controlX, startY + spacing * 4);
            dtpStartDate.Value = DateTime.Now;
            this.Controls.Add(CreateLabel(labels[4], labelX, startY + spacing * 4));
            this.Controls.Add(dtpStartDate);

            // End Date
            dtpEndDate = CreateDatePicker(controlX, startY + spacing * 5);
            dtpEndDate.Value = DateTime.Now.AddYears(1); // Default to 1 year contract
            this.Controls.Add(CreateLabel(labels[5], labelX, startY + spacing * 5));
            this.Controls.Add(dtpEndDate);

            // Monthly Rent
            txtMonthlyRent = CreateTextBox(controlX, startY + spacing * 6);

            this.Controls.Add(CreateLabel(labels[6], labelX, startY + spacing * 6));
            this.Controls.Add(txtMonthlyRent);

            // Payment Schedule
            txtPaymentSchedule = CreateTextBox(controlX, startY + spacing * 7);

            this.Controls.Add(CreateLabel(labels[7], labelX, startY + spacing * 7));
            this.Controls.Add(txtPaymentSchedule);

            // Deposit
            txtDeposit = CreateTextBox(controlX, startY + spacing * 8); // Adjusted for multiline payment schedule

            this.Controls.Add(CreateLabel(labels[8], labelX, startY + spacing * 8));
            this.Controls.Add(txtDeposit);

            // Status
            txtStatus = CreateTextBox(controlX, startY + spacing * 9);

            txtStatus.Text = "Đang hiệu lực";
            txtStatus.Enabled = false;
       
            this.Controls.Add(CreateLabel(labels[9], labelX, startY + spacing * 9));
            this.Controls.Add(txtStatus);

            // Notes
            txtNotes = CreateTextBox(controlX, startY + spacing * 10);



            this.Controls.Add(CreateLabel(labels[10], labelX, startY + spacing * 10));
            this.Controls.Add(txtNotes);

            // Submit button
            btnSubmit = new CustomButton()
            {
                Text = "SUBMIT",
                Location = new Point(125, 530)
            };
            this.Controls.Add(btnSubmit);
            this.Controls.Add(titleLabel);
        }

        private void InitializeEventHandlers()
        {
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
        }

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label()
            {
                Text = text + ":",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(x, y)
            };
        }

        private MyGunaTextBox CreateTextBox(int x, int y)
        {
            
            var textBox = new MyGunaTextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(250, 20);
            return textBox;
            
        }

        private DateTimePicker CreateDatePicker(int x, int y)
        {
            return new DateTimePicker()
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(x, y),
                Width = 250
            };
        }

     
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(txtTenantID.Text) || 
                    string.IsNullOrEmpty(txtContractID.Text) ||
                    string.IsNullOrEmpty(txtHouseID.Text) ||
                    string.IsNullOrEmpty(txtMonthlyRent.Text) ||
                    string.IsNullOrEmpty(txtPaymentSchedule.Text) ||
                    string.IsNullOrEmpty(txtDeposit.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng tenant mới
                var tenant = new ThongtinkhachthueDTO(
                    txtTenantID.Text.Trim(),
                    "", // FirstName - sẽ được cập nhật sau
                    "", // LastName - sẽ được cập nhật sau
                    DateTime.Now, // Birthday - sẽ được cập nhật sau
                    "", // Gender - sẽ được cập nhật sau
                    "", // Phone - sẽ được cập nhật sau
                    "", // Email - sẽ được cập nhật sau
                    string.Empty // Profile picture path
                );

                // Tạo đối tượng contract mới
                var contract = new ContractDTO(
                    txtContractID.Text.Trim(),
                    txtHouseID.Text.Trim(),
                    tenant.TenantID,
                    dtpCreateDate.Value,
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    float.Parse(txtMonthlyRent.Text.Trim()),
                    txtPaymentSchedule.Text.Trim(),
                    float.Parse(txtDeposit.Text.Trim()),
                    txtStatus.Text,
                    txtNotes.Text?.Trim() ?? string.Empty,
                    true, // Auto renew
                    string.Empty, // Termination reason
                    "/contracts/" + txtContractID.Text.Trim() + ".pdf" // Contract file path
                );

                // Lưu hợp đồng
                bool contractSaved = contractBLL.SaveContract(contract);
                if (!contractSaved)
                {
                    MessageBox.Show("Không thể lưu hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ! Vui lòng kiểm tra lại số tiền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ContractForm
            // 
            this.ClientSize = new System.Drawing.Size(764, 524);
            this.Name = "ContractForm";
            this.Load += new System.EventHandler(this.ContractForm_Load);
            this.ResumeLayout(false);

        }

        private void ContractForm_Load(object sender, EventArgs e)
        {

        }
    }
}
