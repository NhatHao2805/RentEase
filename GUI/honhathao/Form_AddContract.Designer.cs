namespace GUI
{
    partial class Form_AddContract
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
            this.ListTenantID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2DateTimePicker3 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.GiaThue = new Guna.UI2.WinForms.Guna2TextBox();
            this.LichThanhToan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TienDatCoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.GhiChu = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.saveButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SoPhong = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            this.panel3.Size = new System.Drawing.Size(654, 36);
            this.panel3.TabIndex = 22;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
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
            this.exitButton.Location = new System.Drawing.Point(614, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 36);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ListTenantID
            // 
            this.ListTenantID.BackColor = System.Drawing.Color.Transparent;
            this.ListTenantID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListTenantID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListTenantID.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ListTenantID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ListTenantID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ListTenantID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ListTenantID.ItemHeight = 30;
            this.ListTenantID.Location = new System.Drawing.Point(224, 157);
            this.ListTenantID.Name = "ListTenantID";
            this.ListTenantID.Size = new System.Drawing.Size(357, 36);
            this.ListTenantID.TabIndex = 24;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(224, 220);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(357, 36);
            this.guna2DateTimePicker1.TabIndex = 25;
            this.guna2DateTimePicker1.Value = new System.DateTime(2025, 3, 23, 17, 17, 55, 772);
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.Checked = true;
            this.guna2DateTimePicker2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2DateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(224, 262);
            this.guna2DateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(357, 36);
            this.guna2DateTimePicker2.TabIndex = 26;
            this.guna2DateTimePicker2.Value = new System.DateTime(2025, 3, 23, 17, 17, 59, 75);
            // 
            // guna2DateTimePicker3
            // 
            this.guna2DateTimePicker3.Checked = true;
            this.guna2DateTimePicker3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2DateTimePicker3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker3.Location = new System.Drawing.Point(224, 304);
            this.guna2DateTimePicker3.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker3.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker3.Name = "guna2DateTimePicker3";
            this.guna2DateTimePicker3.Size = new System.Drawing.Size(357, 36);
            this.guna2DateTimePicker3.TabIndex = 27;
            this.guna2DateTimePicker3.Value = new System.DateTime(2025, 3, 23, 17, 18, 1, 356);
            // 
            // GiaThue
            // 
            this.GiaThue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GiaThue.DefaultText = "";
            this.GiaThue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GiaThue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GiaThue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GiaThue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GiaThue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GiaThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GiaThue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GiaThue.Location = new System.Drawing.Point(224, 355);
            this.GiaThue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GiaThue.Name = "GiaThue";
            this.GiaThue.PlaceholderText = "";
            this.GiaThue.ReadOnly = true;
            this.GiaThue.SelectedText = "";
            this.GiaThue.Size = new System.Drawing.Size(357, 36);
            this.GiaThue.TabIndex = 28;
            // 
            // LichThanhToan
            // 
            this.LichThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.LichThanhToan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LichThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LichThanhToan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LichThanhToan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LichThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LichThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.LichThanhToan.ItemHeight = 30;
            this.LichThanhToan.Items.AddRange(new object[] {
            "Đầu tháng",
            "Cuối tháng"});
            this.LichThanhToan.Location = new System.Drawing.Point(224, 404);
            this.LichThanhToan.Name = "LichThanhToan";
            this.LichThanhToan.Size = new System.Drawing.Size(357, 36);
            this.LichThanhToan.TabIndex = 29;
            // 
            // TienDatCoc
            // 
            this.TienDatCoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TienDatCoc.DefaultText = "";
            this.TienDatCoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TienDatCoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TienDatCoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TienDatCoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TienDatCoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TienDatCoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TienDatCoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TienDatCoc.Location = new System.Drawing.Point(224, 455);
            this.TienDatCoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TienDatCoc.Name = "TienDatCoc";
            this.TienDatCoc.PlaceholderText = "";
            this.TienDatCoc.SelectedText = "";
            this.TienDatCoc.Size = new System.Drawing.Size(357, 36);
            this.TienDatCoc.TabIndex = 30;
            // 
            // GhiChu
            // 
            this.GhiChu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GhiChu.DefaultText = "";
            this.GhiChu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GhiChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GhiChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GhiChu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GhiChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GhiChu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GhiChu.Location = new System.Drawing.Point(224, 508);
            this.GhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.PlaceholderText = "";
            this.GhiChu.SelectedText = "";
            this.GhiChu.Size = new System.Drawing.Size(357, 36);
            this.GhiChu.TabIndex = 32;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(40, 229);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(64, 18);
            this.guna2HtmlLabel3.TabIndex = 36;
            this.guna2HtmlLabel3.Text = "Ngày Tạo";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(40, 271);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(86, 18);
            this.guna2HtmlLabel4.TabIndex = 37;
            this.guna2HtmlLabel4.Text = "Ngày Bắt Đầu";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(40, 313);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(91, 18);
            this.guna2HtmlLabel5.TabIndex = 38;
            this.guna2HtmlLabel5.Text = "Ngày Kết Thúc";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(40, 364);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(136, 18);
            this.guna2HtmlLabel6.TabIndex = 39;
            this.guna2HtmlLabel6.Text = "Giá Thuê Hàng Tháng";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(40, 413);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(91, 18);
            this.guna2HtmlLabel7.TabIndex = 40;
            this.guna2HtmlLabel7.Text = "Lịch thanh toán";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(40, 464);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(80, 18);
            this.guna2HtmlLabel8.TabIndex = 41;
            this.guna2HtmlLabel8.Text = "Tiền Đặt Cọc";
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(40, 517);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(47, 18);
            this.guna2HtmlLabel10.TabIndex = 43;
            this.guna2HtmlLabel10.Text = "Ghi chú";
            // 
            // saveButton
            // 
            this.saveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(224, 580);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(180, 45);
            this.saveButton.TabIndex = 44;
            this.saveButton.Text = "Lưu";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(40, 119);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(61, 18);
            this.guna2HtmlLabel9.TabIndex = 46;
            this.guna2HtmlLabel9.Text = "Số phòng";
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
            this.SoPhong.Location = new System.Drawing.Point(224, 110);
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.Size = new System.Drawing.Size(357, 36);
            this.SoPhong.TabIndex = 45;
            this.SoPhong.SelectedValueChanged += new System.EventHandler(this.guna2ComboBox4_SelectedValueChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(40, 170);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(74, 18);
            this.guna2HtmlLabel1.TabIndex = 48;
            this.guna2HtmlLabel1.Text = "Khách Thuê";
            // 
            // Form_AddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 651);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.SoPhong);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.GhiChu);
            this.Controls.Add(this.TienDatCoc);
            this.Controls.Add(this.LichThanhToan);
            this.Controls.Add(this.GiaThue);
            this.Controls.Add(this.guna2DateTimePicker3);
            this.Controls.Add(this.guna2DateTimePicker2);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.ListTenantID);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AddContract";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2ComboBox ListTenantID;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker3;
        private Guna.UI2.WinForms.Guna2TextBox GiaThue;
        private Guna.UI2.WinForms.Guna2ComboBox LichThanhToan;
        private Guna.UI2.WinForms.Guna2TextBox TienDatCoc;
        private Guna.UI2.WinForms.Guna2TextBox GhiChu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox SoPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}