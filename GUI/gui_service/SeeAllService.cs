using BLL;
using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.gui_service
{
    public partial class SeeAllService: Form
    {
        public SeeAllService(List<DichVuDTO> listDichVu)
        {
            InitializeComponent();
            
            try
            {
                // Kiểm tra danh sách dịch vụ có dữ liệu không
                if (listDichVu == null || !listDichVu.Any())
                {
                    MessageBox.Show("Không có dữ liệu dịch vụ để hiển thị!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BeginInvoke(new Action(() => this.Close()));
                    return;
                }

                dgv_AllService.DataSource = listDichVu;

                // Sau khi set DataSource cho DataGridView
                if (dgv_AllService.Columns.Contains("GiaDichVu"))
                {
                    dgv_AllService.Columns["GiaDichVu"].DefaultCellStyle.Format = "N0";  // Định dạng số có dấu phẩy
                    dgv_AllService.Columns["GiaDichVu"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
                    // Thêm "VND" vào sau giá tiền
                    dgv_AllService.Columns["GiaDichVu"].DefaultCellStyle.Format = "#,##0 VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi hiển thị dữ liệu dịch vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }
            
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "service.list.title":
                        label23.Text = a.Value;
                        break;
                    case "service.list.subtitle":

                        label22.Text = a.Value;
                        break;
                 

                }
            }
        }

//        service.list.title: Tất cả dịch vụ
//service.list.subtitle: Mọi dịch vụ đều hiển thị ở đây
        private void SeeAllService_Load(object sender, EventArgs e)
        {
            try
            {
                // Tùy chỉnh tên cột (nếu cần)
                if (dgv_AllService.Columns.Contains("ID"))
                    dgv_AllService.Columns["ID"].HeaderText = "ID Dịch vụ";
                if (dgv_AllService.Columns.Contains("TenDichVu"))
                    dgv_AllService.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
                if (dgv_AllService.Columns.Contains("GiaDichVu"))
                    dgv_AllService.Columns["GiaDichVu"].HeaderText = "Đơn giá";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tùy chỉnh hiển thị: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
