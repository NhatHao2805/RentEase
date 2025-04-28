using BLL;
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
using GUI;
using DTO.DTO_Service;
using DTO;
using Microsoft.Win32;
using System.Web.UI.WebControls;
namespace GUI.GUI_Service
{
    
    public partial class AddService: Form
    {
        
        private string buildingID;
        private quanlynha parentForm;
        public AddService(string buildingid, quanlynha parent = null)
        {
            this.buildingID = buildingid;
            this.parentForm = parent;
            InitializeComponent();
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "service_registration.title":
                        label23.Text = a.Value;
                        break;
                    case "service_registration.subtitle":
                        label22.Text = a.Value;
                        break;
                    case "service_registration.customer_name":
                        this.guna2HtmlLabel1.Text = a.Value;
                        break;
                    case "service_registration.room_code":
                        this.guna2HtmlLabel2.Text = a.Value;
                        break;
                    case "service_registration.service_name":
                        this.guna2HtmlLabel3.Text = a.Value;
                        break;
                    case "service_registration.cancel_button":
                        Delete.Text = a.Value;
                        break;
                    case "service_registration.register_button":
                        AddBtn.Text = a.Value;
                        break;

                }
            }
        }
//        service_registration.title: Service Registration
//service_registration.subtitle: Add new service to table
//service_registration.customer_name: Customer Name
//service_registration.room_code: Room Number
//service_registration.service_name: Service Name
//service_registration.cancel_button: Cancel Registration
//service_registration.register_button: Register
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private PhongBLL phongBLL = new PhongBLL();
        private DichVuBLL dichVuBLL = new DichVuBLL();


        public void AddService_Load(object sender, EventArgs e)
        {
          
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                      (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            LoadComboBoxData();
        }


        private void TenantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID của khách hàng được chọn
                if (TenantName.SelectedValue != null)
                {
                    // Lấy ID khách hàng từ SelectedValue vì đã set ValueMember = "ID"
                    string tenantID = TenantName.SelectedValue.ToString();

                    // Tạo instance của PhongBLL nếu chưa có
                    if (phongBLL == null)
                        phongBLL = new PhongBLL();

                    // Lấy danh sách phòng của khách hàng
                    List<PhongDTO> rooms = phongBLL.GetPhongByTenantID(tenantID, buildingID);

                    // Hiển thị danh sách phòng vào ComboBox
                    Room.DataSource = rooms;
                    Room.DisplayMember = "Name"; // Hiển thị tên phòng (ROOMNAME)
                    Room.ValueMember = "ID";   // Giá trị là ID phòng (ROOMID)

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin phòng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadComboBoxData()
        {
            // Load danh sách khách hàng
            TenantName.DataSource = khachHangBLL.GetKhachHangForComboBox(buildingID);
            TenantName.DisplayMember = "Name";
            TenantName.ValueMember = "ID";


            TenantName.SelectedIndexChanged += TenantName_SelectedIndexChanged;

            Room.DisplayMember = "Name";  // Đảm bảo hiển thị tên phòng (ROOMNAME)
            Room.ValueMember = "ID";      // Giá trị là ID phòng (ROOMID)




            // Load danh sách dịch vụ
            Service.DataSource = dichVuBLL.GetDichVuForComboBox();

            Service.DisplayMember = "Name";
            Service.ValueMember = "ID";

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
        private ServiceUsageBLL serviceUsageBLL = new ServiceUsageBLL();
        //private void btnDangKy_Click(object sender, EventArgs e)
        //{
        //    string tenantID = TenantName.SelectedValue.ToString();  // Lấy ID từ ComboBox
        //    string serviceID = Service.SelectedValue.ToString();  // Lấy ID từ ComboBox

        //    bool isSuccess = serviceUsageBLL.RegisterServiceUsage(tenantID, serviceID);

        //    if (isSuccess)
        //    {
        //        MessageBox.Show("Đăng ký dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Nut Dang Ky
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string tenantID = TenantName.SelectedValue.ToString();  // Lấy ID từ ComboBox
            string serviceID = Service.SelectedValue.ToString();  // Lấy ID từ ComboBox

            bool isSuccess = serviceUsageBLL.RegisterServiceUsage(tenantID, serviceID, "insert");

            if (isSuccess)
            {
                MessageBox.Show("Đăng ký dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh data in parent form if it exists
                if (parentForm != null)
                {
                    parentForm.LoadDichVu();
                }
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Khách hàng đã đăng ký dịch vụ này rồi vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            // Đóng form đăng ký sau khi thành công
            this.Close();
        }

        private void guna2HtmlLabel1_Click_2(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string tenantID = TenantName.SelectedValue.ToString();  // Lấy ID từ ComboBox
            string serviceID = Service.SelectedValue.ToString();  // Lấy ID từ ComboBox

            bool isSuccess = serviceUsageBLL.RegisterServiceUsage(tenantID, serviceID,"delete");

          
            if (isSuccess)
            {
                MessageBox.Show("Hủy đăng ký dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh data in parent form if it exists
                if (parentForm != null)
                {
                    parentForm.LoadDichVu();
                }
            }
            else
            {
                MessageBox.Show("Hủy đăng ký thất bại. Chưa có dịch vụ để hủy, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void TenantName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
