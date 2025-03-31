using BLL.BLL_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_Service
{
    public partial class InsertService: Form
    {
        public InsertService()
        {
            InitializeComponent();
        }

        //Insert
        private InsertServiceBLL serviceBLL = new InsertServiceBLL();
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string serviceName = ServiceName.Text.Trim();
            decimal unitPrice;

            if (string.IsNullOrEmpty(serviceName) || !decimal.TryParse(Cost.Text, out unitPrice))
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isAdded = serviceBLL.AddService(serviceName, unitPrice);

            if (isAdded)
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertService_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                      (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }
    }
}
