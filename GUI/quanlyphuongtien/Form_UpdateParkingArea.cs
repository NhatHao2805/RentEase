using BLL;
using DTO;
using Guna.UI2.WinForms;
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
    public partial class Form_UpdateParkingArea : Form
    {
        ParkingAreaBLL parkingAreaBLL = new ParkingAreaBLL();
        quanlynha form;
        ParkingArea area = new ParkingArea();
        private string _username;
        private ParkingArea infor;
        public Form_UpdateParkingArea(string username, ParkingArea selectedArea)
        {
            InitializeComponent();

            _username = username;
            infor = selectedArea;
            loadLanguage();
        }

        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "parking.update_title":
                        label23.Text = a.Value;
                        break;
                    case "parking.update_subtitle":
                        label22.Text = a.Value;
                        break;

                    case "parking.id_parking":
                        guna2HtmlLabel5.Text = a.Value;
                        break;
                    case "parking.address":
                        guna2HtmlLabel6.Text = a.Value;
                        break;
                    case "parking.type":
                        guna2HtmlLabel4.Text = a.Value;
                        break;
                    case "parking.capacity":
                        guna2HtmlLabel3.Text = a.Value;
                        break;
                    case "btn_save":
                        add_btn.Text = a.Value;
                        break;
                }
            }
        }

        private void Form_UpdateParkingArea_Load_1(object sender, EventArgs e)
        {
            type_cb.Items.Clear();
            type_cb.Items.Add(infor.Type);
            string[] a = { Language.translate("xeoto"), Language.translate("xemay/xedap"), Language.translate("honhop") };
            foreach (string item in a)
            {
                if(!type_cb.Items.Contains(item))
                {
                    type_cb.Items.Add(item);
                }
            }

            areaid_tb.Text = infor.AreaId;
            address_tb.Text = infor.Address;
            type_cb.SelectedItem = infor.Type;
            capacity_tb.Text = infor.Capacity;

            areaid_tb.Enabled = false;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            area.AreaId = infor.AreaId;
            area.BuildingId = infor.BuildingId;
            area.Address = address_tb.Text;
            area.Type = type_cb.Text;
            area.Capacity = capacity_tb.Text;

            string check = ParkingAreaBLL.UpdateArea(area);

            switch (check)
            {
                case "required_address":
                    MessageBox.Show("Bạn chưa nhập địa chỉ");
                    return;
                case "required_type":
                    MessageBox.Show("Bạn chưa chọn loại bãi giữ xe");
                    return;
                case "required_capacity":
                    MessageBox.Show("Bạn chưa nhập sức chứa bãi giữ xe");
                    return;
                case "invalid_capacity_format":
                    MessageBox.Show("Sức chứa không hợp lệ");
                    capacity_tb.Text = string.Empty;
                    area.Capacity = null;
                    return;
                case "Database connection failed!":
                    MessageBox.Show("Kết nối thất bại");
                    return;
                case "Update Successfully":
                    MessageBox.Show("Sửa bãi xe thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;

                default:
                    MessageBox.Show($"Lỗi không xác định: {check}");
                    return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
