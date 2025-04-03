namespace GUI.honhathao
{
    partial class Form_Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.TenKhachHang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SoPhong = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ngayDk = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.ngayHethan = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.luu = new Guna.UI2.WinForms.Guna2Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.exitButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 36);
            this.panel3.TabIndex = 24;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            // 
            // exitButton
            // 
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::GUI.Properties.Resources.icon_2;
            this.exitButton.Location = new System.Drawing.Point(534, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 36);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.TenKhachHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TenKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TenKhachHang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenKhachHang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TenKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.TenKhachHang.ItemHeight = 30;
            this.TenKhachHang.Location = new System.Drawing.Point(274, 78);
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Size = new System.Drawing.Size(256, 36);
            this.TenKhachHang.TabIndex = 25;
            // 
            // SoPhong
            // 
            this.SoPhong.BackColor = System.Drawing.Color.Transparent;
            this.SoPhong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SoPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SoPhong.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SoPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SoPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SoPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.SoPhong.ItemHeight = 30;
            this.SoPhong.Location = new System.Drawing.Point(274, 147);
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.Size = new System.Drawing.Size(256, 36);
            this.SoPhong.TabIndex = 26;
            // 
            // TrangThai
            // 
            this.TrangThai.BackColor = System.Drawing.Color.Transparent;
            this.TrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.TrangThai.ItemHeight = 30;
            this.TrangThai.Items.AddRange(new object[] {
            "Đang chờ",
            "Đã duyệt"});
            this.TrangThai.Location = new System.Drawing.Point(274, 390);
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Size = new System.Drawing.Size(256, 36);
            this.TrangThai.TabIndex = 27;
            // 
            // ngayDk
            // 
            this.ngayDk.Checked = true;
            this.ngayDk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngayDk.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ngayDk.Location = new System.Drawing.Point(274, 223);
            this.ngayDk.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngayDk.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngayDk.Name = "ngayDk";
            this.ngayDk.Size = new System.Drawing.Size(256, 36);
            this.ngayDk.TabIndex = 28;
            this.ngayDk.Value = new System.DateTime(2025, 4, 1, 23, 29, 33, 238);
            // 
            // ngayHethan
            // 
            this.ngayHethan.Checked = true;
            this.ngayHethan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngayHethan.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ngayHethan.Location = new System.Drawing.Point(274, 303);
            this.ngayHethan.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngayHethan.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngayHethan.Name = "ngayHethan";
            this.ngayHethan.Size = new System.Drawing.Size(256, 36);
            this.ngayHethan.TabIndex = 29;
            this.ngayHethan.Value = new System.DateTime(2025, 4, 1, 23, 29, 33, 238);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(39, 78);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(99, 18);
            this.guna2HtmlLabel1.TabIndex = 30;
            this.guna2HtmlLabel1.Text = "Tên khách hàng";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(39, 165);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(63, 18);
            this.guna2HtmlLabel2.TabIndex = 31;
            this.guna2HtmlLabel2.Text = "Mã phòng";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(39, 241);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(98, 18);
            this.guna2HtmlLabel3.TabIndex = 32;
            this.guna2HtmlLabel3.Text = "Ngày đăng ký ở";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(39, 321);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(82, 18);
            this.guna2HtmlLabel4.TabIndex = 33;
            this.guna2HtmlLabel4.Text = "Ngày hết hạn";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(39, 390);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(63, 18);
            this.guna2HtmlLabel5.TabIndex = 34;
            this.guna2HtmlLabel5.Text = "Trạng thái";
            // 
            // luu
            // 
            this.luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.luu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.luu.ForeColor = System.Drawing.Color.White;
            this.luu.Location = new System.Drawing.Point(192, 461);
            this.luu.Name = "luu";
            this.luu.Size = new System.Drawing.Size(180, 45);
            this.luu.TabIndex = 35;
            this.luu.Text = "Lưu";
            this.luu.Click += new System.EventHandler(this.luu_Click);
            // 
            // Form_Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 518);
            this.Controls.Add(this.luu);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.ngayHethan);
            this.Controls.Add(this.ngayDk);
            this.Controls.Add(this.TrangThai);
            this.Controls.Add(this.SoPhong);
            this.Controls.Add(this.TenKhachHang);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Registration";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2ComboBox TenKhachHang;
        private Guna.UI2.WinForms.Guna2ComboBox SoPhong;
        private Guna.UI2.WinForms.Guna2ComboBox TrangThai;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngayDk;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngayHethan;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2Button luu;
    }
}