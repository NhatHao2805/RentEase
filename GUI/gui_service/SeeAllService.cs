using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
