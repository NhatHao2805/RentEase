using GUI.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class TemporaryResidenceForm : CustomForm
    {
        public TemporaryResidenceForm()
        {
            this.Text = "Temporary Residence Registration";
            this.Size = new System.Drawing.Size(600, 700);
            this.FormBorderStyle = FormBorderStyle.None;

            Label lblTitle = new Label()
            {
                Text = "Đăng Ký Tạm Trú",
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            int startY = 60;
            int spacing = 50;

            string[] labels = {
                "Mã Khách Thuê",
                "Tên",
                "Họ",
                "Ngày Sinh",
                "Giới Tính",
                "Số Điện Thoại",
                "Email",
                "Địa Chỉ Thường Trú",
                "Địa Chỉ Tạm Trú",
                "Ngày Bắt Đầu",
                "Ghi Chú",
                "Ngày Hết Hạn",
                "File Đính Kèm"
            };

            MyGunaTextBox[] textBoxes = new MyGunaTextBox[labels.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label()
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(20, startY + (i * spacing)),
                    AutoSize = true
                };
                this.Controls.Add(lbl);

                if (i == 10) // Ghi chú - cần TextBox lớn hơn
                {
                    textBoxes[i] = new MyGunaTextBox()
                    {
                        Location = new System.Drawing.Point(200, startY + (i * spacing)),
                        Width = 350,
                        Height = 80,
                        Multiline = true
                    };
                }
                else if (i == 7 || i == 8) // Địa chỉ - cần TextBox lớn hơn
                {
                    textBoxes[i] = new MyGunaTextBox()
                    {
                        Location = new System.Drawing.Point(200, startY + (i * spacing)),
                        Width = 350,
                        Height = 40,
                        Multiline = true
                    };
                }
                else if (i == 3 || i == 9 || i == 11) // Các trường ngày tháng
                {
                    // Không tạo textbox cho các trường này, thay vào đó sẽ tạo DateTimePicker
                    DateTimePicker datePicker = new DateTimePicker()
                    {
                        Location = new System.Drawing.Point(200, startY + (i * spacing)),
                        Width = 350,
                        Format = DateTimePickerFormat.Short
                    };
                    this.Controls.Add(datePicker);
                    continue;
                }
                else if (i == 4) // Giới tính
                {
                    // Không tạo textbox cho giới tính, thay vào đó tạo ComboBox
                    ComboBox genderComboBox = new ComboBox()
                    {
                        Location = new System.Drawing.Point(200, startY + (i * spacing)),
                        Width = 350,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    genderComboBox.Items.AddRange(new string[] { "Nam", "Nữ" });
                    this.Controls.Add(genderComboBox);
                    continue;
                }
                else if (i == 12) // File đính kèm
                {
                    // Tạo button chọn file
                    MyGunaButton btnChooseFile = new MyGunaButton()
                    {
                        Text = "Chọn File",
                        Location = new System.Drawing.Point(200, startY + (i * spacing)),
                        Width = 120
                    };

                    // Tạo label hiển thị đường dẫn file
                    Label lblFilePath = new Label()
                    {
                        Text = "Chưa chọn file",
                        Location = new System.Drawing.Point(330, startY + (i * spacing)),
                        Width = 220,
                        AutoEllipsis = true
                    };

                    btnChooseFile.Click += (sender, e) => {
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                lblFilePath.Text = Path.GetFileName(openFileDialog.FileName);
                            }
                        }
                    };

                    this.Controls.Add(btnChooseFile);
                    this.Controls.Add(lblFilePath);
                    continue;
                }
                else
                {
                    textBoxes[i] = new MyGunaTextBox()
                    {
                        Location = new System.Drawing.Point(200, startY + (i * spacing)),
                        Width = 350
                    };
                }

                if (textBoxes[i] != null)
                {
                    this.Controls.Add(textBoxes[i]);
                }
            }

            // Tạo nút Submit ở cuối form
            int buttonY = startY + (labels.Length * spacing) + 20;
            MyGunaButton btnSubmit = new MyGunaButton()
            {
                Text = "Đăng Ký",
                Location = new System.Drawing.Point(200, buttonY),
                Width = 120
            };
            this.Controls.Add(btnSubmit);

            // Tạo nút Hủy
            MyGunaButton btnCancel = new MyGunaButton()
            {
                Text = "Hủy",
                Location = new System.Drawing.Point(350, buttonY),
                Width = 120
            };
            btnCancel.Click += (sender, e) => {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancel);

            // Tự động tạo ID và disable ô Mã Khách Thuê
            textBoxes[0].Text = "TR" + DateTime.Now.ToString("yyMMddHHmmss");
            textBoxes[0].Enabled = false;

            // Đặt ngày hiện tại cho DateTimePicker ngày bắt đầu
            ((DateTimePicker)this.Controls.Find("DateTimePicker", true)[0]).Value = DateTime.Today;

            // Đặt ngày hết hạn mặc định là 1 năm sau
            ((DateTimePicker)this.Controls.Find("DateTimePicker", true)[2]).Value = DateTime.Today.AddYears(1);

            // Xử lý nút Submit
            btnSubmit.Click += (sender, e) => {
                if (ValidateInput())
                {
                    MessageBox.Show("Đăng ký tạm trú thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private bool ValidateInput()
        {
            // Logic kiểm tra dữ liệu nhập vào
            // Trong bài toán thực tế, bạn cần kiểm tra tất cả các trường bắt buộc

            // Tìm các control theo loại
            TextBox tenTextBox = (TextBox)this.Controls.Find("TextBox", true)[1]; // Ô "Tên"
            TextBox hoTextBox = (TextBox)this.Controls.Find("TextBox", true)[2]; // Ô "Họ"
            ComboBox genderComboBox = (ComboBox)this.Controls.Find("ComboBox", true)[0]; // Ô "Giới Tính"
            TextBox phoneTextBox = (TextBox)this.Controls.Find("TextBox", true)[5]; // Ô "Số Điện Thoại"
            TextBox diaChiThuongTruTextBox = (TextBox)this.Controls.Find("TextBox", true)[7]; // Ô "Địa Chỉ Thường Trú"
            TextBox diaChiTamTruTextBox = (TextBox)this.Controls.Find("TextBox", true)[8]; // Ô "Địa Chỉ Tạm Trú"

            // Kiểm tra trường Tên
            if (string.IsNullOrWhiteSpace(tenTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTextBox.Focus();
                return false;
            }

            // Kiểm tra trường Họ
            if (string.IsNullOrWhiteSpace(hoTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập họ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hoTextBox.Focus();
                return false;
            }

            // Kiểm tra Giới Tính
            if (genderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                genderComboBox.Focus();
                return false;
            }

            // Kiểm tra Số Điện Thoại
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phoneTextBox.Focus();
                return false;
            }

            // Kiểm tra Địa Chỉ Thường Trú
            if (string.IsNullOrWhiteSpace(diaChiThuongTruTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ thường trú!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                diaChiThuongTruTextBox.Focus();
                return false;
            }

            // Kiểm tra Địa Chỉ Tạm Trú
            if (string.IsNullOrWhiteSpace(diaChiTamTruTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ tạm trú!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                diaChiTamTruTextBox.Focus();
                return false;
            }

            return true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TemporaryResidenceForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Name = "TemporaryResidenceForm";
            this.Load += new System.EventHandler(this.TemporaryResidenceForm_Load);
            this.ResumeLayout(false);
        }

        private void TemporaryResidenceForm_Load(object sender, EventArgs e)
        {
            // Có thể thêm code khởi tạo khi form load ở đây
        }
    }
}