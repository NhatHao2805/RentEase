using BLL;
using BLL.BLL_Service;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "service.delete_title":
                        label23.Text = a.Value;
                        break;
                    case "service.delete_subtitle":
                        label22.Text = a.Value;
                        break;
                    case "service.name":
                        this.guna2HtmlLabel1.Text = a.Value;
                        break;
                    case "service.price":
                        this.Cost_Label.Text = a.Value;
                        break;
                    case "service.delete_button":
                        deleteService_btn.Text = a.Value;
                        break;
                    case "service.adjust_fee_button":
                        updateCost_btn.Text = a.Value;
                        break;

                }
            }
        }
//        service.delete_title: Xóa dịch vụ
//service.delete_subtitle: Xóa dịch vụ trong bảng
//service.name: Tên dịch vụ
//service.price: Giá dịch vụ
//service.delete_button: Xóa
//service.adjust_fee_button: Điều chỉnh phí

        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private PhongBLL phongBLL = new PhongBLL();
        private DichVuBLL dichVuBLL = new DichVuBLL();

        private void DeleteService_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
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
            try
            {
                if (serviceComboBoX.SelectedValue == null || serviceComboBoX.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string id = serviceComboBoX.SelectedValue.ToString();

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteDichVuBLL del = new DeleteDichVuBLL();
                    if (del.XoaDichVu(id))
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (parentForm != null)
                        {
                            parentForm.btn_dichvu_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Dịch vụ đang có người sử dụng, không thể xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa dịch vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        // CHinh Gia
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceComboBoX.SelectedValue == null || serviceComboBoX.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string serviceName = serviceComboBoX.SelectedValue.ToString();
                decimal newPrice;

                // Kiểm tra nếu TextBox rỗng
                if (string.IsNullOrWhiteSpace(updateCost.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(updateCost.Text, out newPrice))
                {
                    MessageBox.Show("Giá trị nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newPrice <= 0)
                {
                    MessageBox.Show("Giá dịch vụ phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ServiceBLL sBLL = new ServiceBLL();
                bool isUpdated = sBLL.UpdateServicePrice(serviceName, newPrice);

                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (parentForm != null)
                    {
                        parentForm.btn_dichvu_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại! Vì dịch vụ đang chọn có khách đang được sử dụng. Chỉ cập nhật được dành cho dịch vụ chưa có người dùng", 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi cập nhật giá dịch vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
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
