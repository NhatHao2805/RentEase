using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Login
{
    public partial class Loading : Form
    {
        private Timer timer;
        private int progressValue = 0;

        public Loading()
        {
            InitializeComponent();
            this.Opacity = 0; // Bắt đầu với hiệu ứng mờ
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            // Bắt đầu hiệu ứng quay của ProgressIndicator
            guna2ProgressIndicator1.Start();

            // Khởi tạo Timer để xử lý hiệu ứng tải
            timer = new Timer();
            timer.Interval = 60; // Điều chỉnh tốc độ tải
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) // Hiệu ứng Fade-in cho Form
                this.Opacity += 0.05;

            if (progressValue < 100)
            {
                progressValue += 2; // Tăng tiến trình tải
                loadNgang.Value = progressValue;
            }
            else
            {
                timer.Stop();
                guna2ProgressIndicator1.Stop(); // Ngừng quay khi tải xong

                this.Hide(); // Ẩn Form Loading

                // Chuyển sang Form Login
                Form_Login loginForm = new Form_Login();
                loginForm.Show();
            }
        }
    }
}