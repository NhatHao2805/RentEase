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
            dgv_AllService.DataSource = listDichVu;

            // Sau khi set DataSource cho DataGridView
            dgv_AllService.Columns["GiaDichVu"].DefaultCellStyle.Format = "N0";  // Định dạng số có dấu phẩy
            dgv_AllService.Columns["GiaDichVu"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
            // Thêm "VND" vào sau giá tiền
            dgv_AllService.Columns["GiaDichVu"].DefaultCellStyle.Format = "#,##0 VND";
        }

        private void SeeAllService_Load(object sender, EventArgs e)
        {
            // Tùy chỉnh tên cột (nếu cần)
            dgv_AllService.Columns["ID"].HeaderText = "ID Dịch vụ";
            dgv_AllService.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            dgv_AllService.Columns["GiaDichVu"].HeaderText = "Đơn giá";

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
