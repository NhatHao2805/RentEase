using BLL;
using BLL.honhathao;
using DTO;
using Guna.UI2.WinForms;
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
            vehicle.TenantID = tenantid_cb.Text;
            vehicle.VehicleUnitPriceID = unitpriceid_tb.Text;
            vehicle.Type = Language.reverseTranslate(type_cb.Text);
            vehicle.LicensePlate = licenseplate_tb.Text;

            var (success, message) = ParkingAreaBLL.checkCapacity(areaid_cb.Text);

            if (success)
            {

                string check = VehicleBLL.CheckLogic(vehicle, areaid_cb.Text, unitprice_tb.Text);

                switch (check)
                {
                    case "required_tenantid":
                        MessageBox.Show("Bạn chưa chọn mã khách thuê");
                        return;
                    case "required_type":
                        MessageBox.Show("Bạn chưa phân loại xe");
                        return;
                    case "required_areaid":
                        MessageBox.Show("Bạn chưa chọn mã bãi xe");
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
                    case "required_licenseplate":
                        MessageBox.Show("Bạn chưa nhập biển số xe");
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
            else
            {
                MessageBox.Show(message,
                          success ? "Thành công" : "Lỗi",
                          MessageBoxButtons.OK,
                          success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }

        private void Form_AddVehicle_Load(object sender, EventArgs e)
        {
            tenantid_cb.Items.Clear();
            foreach (string tenantid in TenantBLL.Load_TenantID_By_Buildingid(_buildingid))
            {
                tenantid_cb.Items.Add(tenantid);
            }

            type_cb.Items.Clear();
            type_cb.Items.Add(Language.translate("xeoto"));
            type_cb.Items.Add(Language.translate("xemay"));
            type_cb.Items.Add(Language.translate("xedap"));
            unitpriceid_tb.Items.Clear();
            foreach (DataRow row in VehicleBLL.GetAllVehicleUnitPrices().Rows)
            {
                unitpriceid_tb.Items.Add(row["VEHICLE_UNITPRICE_ID"].ToString());
            }

            unitpriceid_tb.Enabled = false;
        }

        private void type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaid_cb.Items.Clear();
            System.Data.DataTable areaData = ParkingAreaBLL.GetAreaId(Language.reverseTranslate(type_cb.Text), _buildingid);

            if (areaData != null && areaData.Rows.Count > 0)
            {
                foreach (DataRow row in areaData.Rows)
                {
                    areaid_cb.Items.Add(row["AREAID"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bãi đậu xe cho loại xe đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            unitpriceid_tb.SelectedItem = VehicleBLL.GetVehicleUnitPriceIdByType(type_cb.Text).ToString();
            if (type_cb.SelectedItem == null) return;

            try
            {
                System.Data.DataTable dt = VehicleBLL.GetVehicleUnitPriceIdByType(Language.reverseTranslate(type_cb.Text));

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
