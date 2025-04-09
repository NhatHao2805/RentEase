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
    public partial class Form_AddVehicle : Form
    {
        VehicleBLL vehicleBLL = new VehicleBLL();
        quanlynha form;
        Vehicle vehicle = new Vehicle();
        public Form_AddVehicle()
        {
            InitializeComponent();

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

        private void Form_AddVehicle_Load(object sender, EventArgs e)
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

            unitprice_tb.Enabled = false;
        }

        private void type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_cb.SelectedItem == null)
            {
                unitpriceid_tb.Text = string.Empty;
                unitprice_tb.Text = string.Empty;
                return;
            }

            try
            {
                string selectedType = type_cb.SelectedItem.ToString();
                Console.WriteLine($"Selected type: {selectedType}");
                Console.WriteLine($"Selected type length: {selectedType.Length}");
                Console.WriteLine($"Selected type bytes: {System.Text.Encoding.UTF8.GetBytes(selectedType).Length}");

                // Kiểm tra dữ liệu trong bảng VEHICLE_UNITPRICE
                using (System.Data.DataTable allPrices = VehicleBLL.GetAllVehicleUnitPrices())
                {
                    Console.WriteLine("All vehicle unit prices:");
                    foreach (DataRow row in allPrices.Rows)
                    {
                        string dbType = row["TYPE"].ToString();
                        Console.WriteLine($"ID: {row["VEHICLE_UNITPRICE_ID"]}, Type: '{dbType}', Type length: {dbType.Length}, Type bytes: {System.Text.Encoding.UTF8.GetBytes(dbType).Length}, Price: {row["UNITPRICE"]}");
                        
                        // So sánh trực tiếp
                        if (dbType.Equals(selectedType, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Found exact match!");
                            unitpriceid_tb.Text = row["VEHICLE_UNITPRICE_ID"].ToString();
                            unitprice_tb.Text = row["UNITPRICE"].ToString();
                            return;
                        }
                    }
                }

                MessageBox.Show($"Chưa có đơn giá cho loại phương tiện '{selectedType}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unitpriceid_tb.Text = string.Empty;
                unitprice_tb.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                unitpriceid_tb.Text = string.Empty;
                unitprice_tb.Text = string.Empty;
            }
        }
    }
}
