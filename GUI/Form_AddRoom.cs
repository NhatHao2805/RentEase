using BLL;
using DTO;
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
    public partial class Form_AddRoom : Form
    {
        RoomBLL roomBLL = new RoomBLL();
        QuanLyNha form;
        Room room = new Room();

        public Form_AddRoom()
        {
            InitializeComponent();
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            // Loại bỏ placeholder nếu có
            room.roomID = (RoomID_tb.Text == "  ID phòng") ? "" : RoomID_tb.Text;
            room.buildingID = buildingID.Text;
            room.type = type_cb.Text;
            room.convenient = (convenient_tb.Text == "  Tiện ích") ? "" : convenient_tb.Text;
            room.area = (area_tb.Text == "  Diện tích(m2)") ? "" : area_tb.Text;
            room.price = (price_tb.Text == "  Giá(VND)") ? "" : price_tb.Text;

            string status = "";
            foreach (Control control in status_grbox.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    status += checkBox.Text + "; ";
                }
            }
            room.status = status.TrimEnd(';', ' ');

            room.lastMaintenanceDate = birth_datepicker.Value.ToString("yyyy-MM-dd");

            string check = roomBLL.CheckLogic(room);

            switch (check)
            {
                case "required_roomid":
                    MessageBox.Show("Bạn chưa nhập mã phòng");
                    return;
                case "required_area":
                    MessageBox.Show("Bạn chưa nhập diện tích");
                    return;
                case "required_price":
                    MessageBox.Show("Bạn chưa nhập giá");
                    return;
                case "required_last_maintenance_date":
                    MessageBox.Show("Bạn chưa nhập ngày bảo trì gần nhất");
                    return;
                case "Đã xảy ra lỗi khi thêm!":
                    MessageBox.Show("Đã xảy ra lỗi khi thêm!");
                    return;
                case "Phòng đã tồn tại!":
                    MessageBox.Show("Phòng đã tồn tại!");
                    return;
                case "Thêm thành công!":
                    MessageBox.Show("Thêm thành công");
                    form = new QuanLyNha();
                    form.Show();
                    this.Hide();
                    return;
            }
        }
        private void Form_AddRoom_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            RoomID_tb.Text = "  ID phòng";
            RoomID_tb.ForeColor = Color.Silver;
            RoomID_tb.Enter += new EventHandler(RoomID_tb_Enter);
            RoomID_tb.Leave += new EventHandler(RoomID_tb_Leave);

            buildingID_cb.Items.Add("B001");

            type_cb.Focus();
            type_cb.Items.Add("Nhà trọ");
            type_cb.Items.Add("Căn hộ");
            type_cb.Items.Add("Biệt thự");
            type_cb.Items.Add("Khác");
            type_cb.SelectedIndex = 0;

            convenient_tb.Text = "  Tiện ích";
            convenient_tb.ForeColor = Color.Silver;
            convenient_tb.Enter += new EventHandler(convenient_tb_Enter);
            convenient_tb.Leave += new EventHandler(convenient_tb_Leave);

            area_tb.Text = "  Diện tích(m2)";
            area_tb.ForeColor = Color.Silver;
            area_tb.Enter += new EventHandler(area_tb_Enter);
            area_tb.Leave += new EventHandler(area_tb_Leave);

            price_tb.Text = "  Giá(VND)";
            price_tb.ForeColor = Color.Silver;
            price_tb.Enter += new EventHandler(price_tb_Enter);
            price_tb.Leave += new EventHandler(price_tb_Leave);

            year_tb.Text = " Năm";
            year_tb.ForeColor = Color.Silver;
            year_tb.Enter += new EventHandler(year_tb_Enter);
            year_tb.Leave += new EventHandler(year_tb_Leave);

            month_tb.Text = " Tháng";
            month_tb.ForeColor = Color.Silver;
            month_tb.Enter += new EventHandler(month_tb_Enter);
            month_tb.Leave += new EventHandler(month_tb_Leave);

            day_tb.Text = " Ngày";
            day_tb.ForeColor = Color.Silver;
            day_tb.Enter += new EventHandler(day_tb_Enter);
            day_tb.Leave += new EventHandler(day_tb_Leave);

            birth_datepicker.ValueChanged += new EventHandler(birth_datepicker_ValueChanged);

        }
        private void RoomID_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(RoomID_tb, "  ID phòng");
        }

        private void RoomID_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(RoomID_tb, "  ID phòng");
        }

        private void convenient_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(convenient_tb, "  Tiện ích");
        }

        private void convenient_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(convenient_tb, "  Tiện ích");
        }

        private void area_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(area_tb, "  Diện tích(m2)");
        }

        private void area_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(area_tb, "  Diện tích(m2)");
        }

        private void price_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(price_tb, "  Giá(VND)");
        }

        private void price_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(price_tb, "  Giá(VND)");
        }

        private void year_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(year_tb, " Năm");
            check_validity();

        }

        private void year_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(year_tb, " Năm");
            check_validity();

        }

        private void month_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(month_tb, " Tháng");
            check_validity();

        }

        private void month_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(month_tb, " Tháng");
            check_validity();

        }

        private void day_tb_Enter(object sender, EventArgs e)
        {
            placeHolderText_2(day_tb, " Ngày");
            check_validity();

        }

        private void day_tb_Leave(object sender, EventArgs e)
        {
            placeHolderText_1(day_tb, " Ngày");
            check_validity();
        }

        private void birth_datepicker_ValueChanged(object sender, EventArgs e)
        {
            year_tb.Text = birth_datepicker.Value.Year.ToString();
            month_tb.Text = birth_datepicker.Value.Month.ToString();
            day_tb.Text = birth_datepicker.Value.Day.ToString();
            year_tb.ForeColor = Color.Black;
            month_tb.ForeColor = Color.Black;
            day_tb.ForeColor = Color.Black;
        }

        private void check_validity()
        {
            bool validYear = int.TryParse(year_tb.Text, out int year);
            bool validMonth = int.TryParse(month_tb.Text, out int month);
            bool validDay = int.TryParse(day_tb.Text, out int day);

            if (year_tb.Text != "  Năm" && month_tb.Text != "  Tháng" && day_tb.Text != "  Ngày")
            {
                if (validYear && validMonth && validDay)
                {
                    year_tb.ForeColor = Color.Black;
                    month_tb.ForeColor = Color.Black;
                    day_tb.ForeColor = Color.Black;

                    if (month < 1 || month > 12)
                    {
                        month_tb.ForeColor = Color.Red;
                        return;
                    }

                    int daysInMonth = DateTime.DaysInMonth(year, month);

                    if (day < 1 || day > daysInMonth)
                    {
                        day_tb.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (!validYear)
                    {
                        year_tb.ForeColor = Color.Red;
                    }
                    if (!validMonth)
                    {
                        month_tb.ForeColor = Color.Red;
                    }
                    if (!validDay)
                    {
                        day_tb.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void placeHolderText_1(TextBox tb, string text)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = text;
                tb.ForeColor = Color.Silver;
            }
        }

        private void placeHolderText_2(TextBox tb, string text)
        {
            if (tb.Text == text)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void price_tb_TextChanged(object sender, EventArgs e)
        {
            this.price_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
        }

        private void area_tb_TextChanged(object sender, EventArgs e)
        {
            this.area_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
        }

        private void DangO_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangO_chbox.Checked && DangTrong_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang ở' vừa 'Đang trống'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangO_chbox.Checked = false;
            }
        }

        private void DangTrong_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangTrong_chbox.Checked && DangO_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang trống' vừa 'Đang ở'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangTrong_chbox.Checked = false;
            }
        }

        private void DangKetThuc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangKetThuc_chbox.Checked && DangCoc_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đang báo kết thúc' vừa 'Đang cọc giữ chỗ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangKetThuc_chbox.Checked = false;
            }
        }

        private void DangCoc_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DangCoc_chbox.Checked && (DangO_chbox.Checked || DangKetThuc_chbox.Checked))
            {
                MessageBox.Show("Không thể vừa 'Đang cọc giữ chỗ' vừa 'Đang ở' hoặc 'Đang báo kết thúc'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DangCoc_chbox.Checked = false;
            }
        }

        private void DangNoTien_chbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SapHetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SapHetHan_chbox.Checked && HetHan_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Sắp hết hạn hợp đồng' vừa 'Đã quá hạn hợp đồng'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SapHetHan_chbox.Checked = false;
            }
        }

        private void HetHan_chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (HetHan_chbox.Checked && SapHetHan_chbox.Checked)
            {
                MessageBox.Show("Không thể vừa 'Đã quá hạn hợp đồng' vừa 'Sắp hết hạn hợp đồng'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HetHan_chbox.Checked = false;
            }
        }
    }
}
