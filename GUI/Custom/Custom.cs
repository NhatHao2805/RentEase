using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;
namespace GUI.Custom
{
    public class CustomForm : Form
    {
        private Button btnClose;

        public CustomForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = ColorTranslator.FromHtml("#BFDEF8");
           
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Padding = new Padding(10);

            // Tạo nút đóng
            btnClose = new Button()
            {
                Text = "X",
                ForeColor = Color.White,
                BackColor = Color.Red,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(this.Width - 40, 10)
            };

            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close(); // Đóng form khi nhấn

            this.Controls.Add(btnClose);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Cập nhật vị trí nút đóng khi thay đổi kích thước form
            btnClose.Location = new Point(this.Width - 40, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 10;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }
    }


    public class CustomButton : Button
    {
        public CustomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = ColorTranslator.FromHtml("#3FA2F6");
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.Size = new Size(250, 40);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 10;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }
    }

    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            this.BorderStyle = BorderStyle.None;
            this.BackColor = ColorTranslator.FromHtml("#16375F");
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10);
            this.Width = 250;
            this.Height = 30;
            this.Padding = new Padding(5);
        }
    }
    //public class NumericTextBox : CustomTextBox
    //{
    //    public int MinValue { get; set; } = int.MinValue;
    //    public int MaxValue { get; set; } = int.MaxValue;

      

    //    protected override void OnTextChanged(EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        if (int.TryParse(this.Text, out int value))
    //        {
    //            if (value < MinValue) this.Text = MinValue.ToString();
    //            if (value > MaxValue) this.Text = MaxValue.ToString();
    //        }
    //    }
    //}

    public class MyGunaButton : Guna2Button
    {
     
        public MyGunaButton()
        {

            this.Font = new Font("Arial", 12, FontStyle.Bold);
            this.BorderRadius = 10;                        // Bo góc
            this.TextAlign = HorizontalAlignment.Center;   // Căn giữa chữ
            this.Size = new Size(250, 50);                 // Kích thước cố định

            // Thêm hiệu ứng hover
            this.HoverState.FillColor = Color.FromArgb(85, 60, 150); // Màu khi hover
        }
       
       
    }
    public class MyGunaTextBox : Guna2TextBox
    {
        [DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr hWnd);

        public MyGunaTextBox()
        {
            // 🌟 Thiết lập giao diện mặc định
            this.BorderRadius = 10; // Bo tròn góc
            this.BorderThickness = 1;
            this.BorderColor = Color.Gray; // Màu viền mặc định
            this.FillColor = Color.White; // Màu nền
            this.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            this.ForeColor = Color.Black;
            this.PlaceholderForeColor = Color.Gray;

            this.Height = 45; // Độ cao phù hợp
           
            this.Padding = new Padding(10, 0, 10, 0);  // Để top & bottom bằng 0
            this.TextOffset = new Point(5, 0);  // Không lệch xuống


            // 🌟 Sự kiện focus để đảm bảo hiển thị Caret
            this.Enter += (s, e) => ShowCaret(this.Handle);
            this.Click += (s, e) => this.Focus();

            // 🌟 Hiệu ứng nhấp nháy viền khi nhập
            this.GotFocus += (s, e) => this.BorderColor = Color.FromArgb(100, 149, 237); // Màu xanh dương nhạt
            this.LostFocus += (s, e) => this.BorderColor = Color.Gray; // Trả lại màu viền gốc
        }
    }

}
