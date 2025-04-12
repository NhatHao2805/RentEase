using BLL;
using BLL.honhathao;
using DTO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_AddVehicle : Form
    {
        VehicleBLL vehicleBLL = new VehicleBLL();
        quanlynha form;
        Vehicle vehicle = new Vehicle();
        string _buildingid;
        public Form_AddVehicle(string buildingid)
        {
            InitializeComponent();
            _buildingid = buildingid;
            loadLanguage();
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "vehicle.add_title":
                        label23.Text = a.Value;
                        break;
                    case "vehicle.add_subtitle":
                        
                        label22.Text = a.Value;
                        break;
                    case "vehicle.tenant_id":
                        guna2HtmlLabel14.Text = a.Value;
                        break;
                    case "vehicle.type":
                        guna2HtmlLabel16.Text = a.Value;
                        break;
                    case "vehicle.parking_id":
                        guna2HtmlLabel15.Text = a.Value;
                        break;
                    case "vehicle.monthly_fee":
                        guna2HtmlLabel4.Text = a.Value;
                        break;
                    case "vehicle.license_plate":
                        guna2HtmlLabel5.Text = a.Value;
                        break;
                    case "vehicle.price_id":
                        guna2HtmlLabel11.Text = a.Value;
                        break;

                    case "btn_save":
                        add_btn.Text = a.Value;
                        break;

                }
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            vehicle.TenantID = tenantid_cb.SelectedItem.ToString();
            vehicle.VehicleUnitPriceID = unitpriceid_tb.Text;
            vehicle.Type = type_cb.SelectedItem.ToString();
            vehicle.LicensePlate = licenseplate_tb.Text;


            string check = VehicleBLL.CheckLogic(vehicle, areaid_cb.SelectedItem.ToString());

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

        private void Form_AddVehicle_Load(object sender, EventArgs e)
        {
            tenantid_cb.Items.Clear();
            foreach (string tenantid in TenantBLL.TenantBll_Load_TenantID())
            {
                tenantid_cb.Items.Add(tenantid);
            }

            type_cb.Items.Clear();
            foreach (DataRow row in VehicleBLL.GetAllVehicle().Rows)
            {
                type_cb.Items.Add(row["TYPE"].ToString());
            }

            unitpriceid_tb.Items.Clear();
            foreach (DataRow row in VehicleBLL.GetAllVehicleUnitPrices().Rows)
            {
                unitpriceid_tb.Items.Add(row["VEHICLE_UNITPRICE_ID"].ToString());
            }

            unitpriceid_tb.Enabled = false;
        }

        private void type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //areaid_cb.Items.Clear();
            //foreach (DataRow row in ParkingAreaBLL.GetAreaId(type_cb.SelectedItem.ToString(), _buildingid).Rows)
            //{
            //    areaid_cb.Items.Add(row["AREAID"].ToString());
            //}
            
            // Xóa các mục hiện có trong ComboBox
            areaid_cb.Items.Clear();
            // Lấy dữ liệu từ phương thức
            System.Data.DataTable areaData = ParkingAreaBLL.GetAreaId(type_cb.SelectedItem.ToString(), _buildingid);

            // Kiểm tra xem DataTable có dữ liệu không
            if (areaData != null && areaData.Rows.Count > 0)
            {
                foreach (DataRow row in areaData.Rows)
                {
                    areaid_cb.Items.Add(row["AREAID"].ToString());
                }
            }
            else
            {
                // Thông báo nếu không có dữ liệu
                MessageBox.Show("Không tìm thấy bãi đậu xe cho loại xe đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            unitpriceid_tb.SelectedItem = VehicleBLL.GetVehicleUnitPriceIdByType(type_cb.SelectedItem.ToString()).ToString();
            if (type_cb.SelectedItem == null) return;

            try
            {
                // Lấy DataTable chứa ID đơn giá
                System.Data.DataTable dt = VehicleBLL.GetVehicleUnitPriceIdByType(type_cb.SelectedItem.ToString());

                if (dt.Rows.Count > 0)
                {
                    string unitPriceId = dt.Rows[0]["VEHICLE_UNITPRICE_ID"].ToString();
                    unitpriceid_tb.SelectedItem = unitPriceId;

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

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
