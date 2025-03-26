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
    public partial class AddService: Form
    {
        public AddService()
        {
            InitializeComponent();
        }
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private PhongBLL phongBLL = new PhongBLL();
        private DichVuBLL dichVuBLL = new DichVuBLL();

        public void AddService_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }
        private void TenantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TenantName.SelectedValue != null)
            {
  
                string selectedTenantID = TenantName.SelectedValue.ToString();
                Room.DataSource = phongBLL.GetPhongByTenantID(selectedTenantID);
                
            }
        }
   

        public void LoadComboBoxData()
        {
            // Load danh sách khách hàng
            TenantName.DataSource = khachHangBLL.GetKhachHangForComboBox();

            TenantName.DisplayMember = "Name";
            TenantName.ValueMember = "ID";

            TenantName.SelectedIndexChanged += TenantName_SelectedIndexChanged;

            // Load danh sách phòng
            Room.DataSource = phongBLL.GetPhongForComboBox();
            Room.DisplayMember = "ID";
            Room.ValueMember = "ID";

            // Load danh sách dịch vụ
            Service.DataSource = dichVuBLL.GetDichVuForComboBox();

            Service.DisplayMember = "Name";
            Service.ValueMember = "ID";

            // Load danh sách đơn vị (dữ liệu tĩnh)
            DonVi.Items.AddRange(new object[] { "1 tháng", "1 lần", "1 kwh" }); 
            DonVi.SelectedIndex = 0;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Room_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }
        //todo: fix lai cai dgvServiceInfo
        //todo: fix ham ben duoi ( chi truyen vao 2 cai, BE se xu ly lay gia tri cua cai con lai)
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (TenantName.SelectedValue == null || Room.SelectedValue == null || Service.SelectedValue == null || string.IsNullOrEmpty(Cost.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //todo: tao hang create id khach hang theo index
            if (dichVuBLL.AddService("T00" + TenantName.SelectedIndex, Room.SelectedValue.ToString(), Service.SelectedValue.ToString(), int.Parse(Cost.Text)))
            {
                MessageBox.Show("Thêm dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
