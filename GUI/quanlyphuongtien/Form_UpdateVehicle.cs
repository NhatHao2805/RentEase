using BLL;
using BLL.honhathao;
using DTO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_UpdateVehicle : Form
    {
        VehicleBLL vehicleBLL = new VehicleBLL();
        quanlynha form;
        Vehicle vehicle = new Vehicle();
        private Vehicle infor;
        public Form_UpdateVehicle( Vehicle vehicle)
        {
            InitializeComponent();
            infor = vehicle;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            vehicle.TenantID = tenantid_cb.SelectedItem.ToString();
            vehicle.VehicleUnitPriceID = unitpriceid_tb.Text;
            vehicle.Type = type_cb.Text;
            vehicle.LicensePlate = licenseplate_tb.Text;

            string check = VehicleBLL.CheckLogic(vehicle);

            switch (check)
            {
                case "required_tenantid":
                    MessageBox.Show("Bạn chưa chọn mã khách thuê");
                    return;
                case "required_type":
                    MessageBox.Show("Bạn chưa phân loại xe");
                    return;
                case "required_unitpriceid":
                    MessageBox.Show("Bạn chưa chọn mã đơn giá");
                    return;
                case "required_unitprice":
                    MessageBox.Show("Bạn chưa nhập đơn giá");
                    return;
                case "invalid_unitprice_format":
                    MessageBox.Show("Đơn giá không hợp lệ");
                    unitprice_tb.Text = string.Empty;
                    return;
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Add Successfully":
                    MessageBox.Show("Thêm phương tiện thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;

                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }

        private void Form_UpdateVehicle_Load(object sender, EventArgs e)
        {
            tenantid_cb.Items.Clear();
            foreach (string tenantid in TenantBLL.TenantBll_Load_TenantID())
            {
                tenantid_cb.Items.Add(tenantid);
            }

            type_cb.Items.Clear();
            type_cb.Items.Add("Ô tô");
            type_cb.Items.Add("Xe máy");
            type_cb.Items.Add("Xe đạp");
            vehicleid_tb.Text = vehicle.VehicleID;

            vehicleid_tb.Enabled = false;
            unitprice_tb.Enabled = false;
        }
    }
}
