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
            vehicle.VehicleID = infor.VehicleID;
            vehicle.TenantID = tenantid_cb.SelectedItem.ToString();
            vehicle.VehicleUnitPriceID = unitpriceid_tb.Text;
            vehicle.Type = type_cb.Text;
            vehicle.LicensePlate = licenseplate_tb.Text;

            string check = VehicleBLL.UpdateVehicle(vehicle);

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
                case "Update Successfully":
                    MessageBox.Show("Sửa phương tiện thành công!");
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
            vehicleid_tb.Text = infor.VehicleID;
            licenseplate_tb.Text = infor.LicensePlate;

            tenantid_cb.Items.Clear();
            foreach (string tenantid in TenantBLL.TenantBll_Load_TenantID())
            {
                tenantid_cb.Items.Add(tenantid);
            }
            tenantid_cb.SelectedItem = infor.TenantID;

            type_cb.Items.Clear();
            foreach (DataRow row in VehicleBLL.GetAllVehicle().Rows)
            {
                type_cb.Items.Add(row["TYPE"].ToString());
            }
            type_cb.SelectedItem= infor.Type;

            
            unitpriceid_cb.Items.Clear();
            foreach (DataRow row in VehicleBLL.GetAllVehicleUnitPrices().Rows)
            {
                unitpriceid_cb.Items.Add(row["VEHICLE_UNITPRICE_ID"].ToString());
            }
            unitpriceid_cb.SelectedItem = infor.VehicleUnitPriceID;

            vehicleid_tb.Enabled = false;
            unitpriceid_cb.Enabled = false;
            licenseplate_tb.Enabled = false;
        }

        private void type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitpriceid_cb.SelectedItem = VehicleBLL.GetVehicleUnitPriceIdByType(type_cb.SelectedItem.ToString()).ToString();
            if (type_cb.SelectedItem == null) return;

            try
            {
                // Lấy DataTable chứa ID đơn giá
                System.Data.DataTable dt = VehicleBLL.GetVehicleUnitPriceIdByType(type_cb.SelectedItem.ToString());

                if (dt.Rows.Count > 0)
                {
                    string unitPriceId = dt.Rows[0]["VEHICLE_UNITPRICE_ID"].ToString();
                    unitpriceid_cb.SelectedItem = unitPriceId;

                    float price = VehicleBLL.GetVehicleUnitPriceById(unitPriceId);
                    unitprice_tb.Text = price.ToString();
                }
                else
                {
                    unitprice_tb.Text = "Không tìm thấy đơn giá";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
