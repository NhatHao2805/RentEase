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
    public partial class DeleteService: Form
    {
        private quanlynha parentForm;
        public DeleteService(quanlynha parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private PhongBLL phongBLL = new PhongBLL();
        private DichVuBLL dichVuBLL = new DichVuBLL();

        private void DeleteService_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                      (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            // Load danh sách dịch vụ
            serviceComboBoX.DataSource = dichVuBLL.GetDichVuForComboBox();

            serviceComboBoX.DisplayMember = "Name";
            serviceComboBoX.ValueMember = "ID";

            updateCost_btn.Enabled = false;
        }


        // Delete
        private void deleteService_btn_Click(object sender, EventArgs e)
        {
            if (serviceComboBoX.SelectedValue != null)
            {
                string id = serviceComboBoX.SelectedValue.ToString();

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteDichVuBLL del = new DeleteDichVuBLL();
                    if (del.XoaDichVu(id))
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm.btn_dichvu_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Dịch vụ đang có người sử dụng, không thể xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Đóng form đăng ký sau khi thành công
            this.Close();

           

        }

        // CHinh Gia
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //updateCost_btn
            string serviceName = serviceComboBoX.SelectedValue.ToString();

            decimal newPrice;

            if (serviceName == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }

            // Kiểm tra nếu TextBox rỗng
            if (string.IsNullOrWhiteSpace(updateCost.Text))
            {
                MessageBox.Show("Vui lòng nhập giá dịch vụ!");
                return;
            }
     

            if (!decimal.TryParse(updateCost.Text, out newPrice))
            {
                MessageBox.Show("Giá trị nhập không hợp lệ!");
                return;
            }

            ServiceBLL sBLL = new ServiceBLL();
            bool isUpdated = sBLL.UpdateServicePrice(serviceName, newPrice);

            if (isUpdated)
            {
                MessageBox.Show("Cập nhật giá thành công!");
                // load lai du lieu
                parentForm.btn_dichvu_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại! Vì dịch vụ đang chọn có khách đang được sử dụng. Chỉ cập nhật được dành cho dịch vụ chưa có người dùng");
            }

            // Đóng form đăng ký sau khi thành công
            this.Close();

           


        }

        // text dieu chinh gia
        private void updateCost_TextChanged(object sender, EventArgs e)
        {
            updateCost_btn.Enabled = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void serviceComboBoX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
