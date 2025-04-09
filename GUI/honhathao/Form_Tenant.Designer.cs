namespace GUI.honhathao
{
    partial class Form_Tenant
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
            this.hodem = new Guna.UI2.WinForms.Guna2TextBox();
            this.ten = new Guna.UI2.WinForms.Guna2TextBox();
            this.sdt = new Guna.UI2.WinForms.Guna2TextBox();
            this.email = new Guna.UI2.WinForms.Guna2TextBox();
            this.ngaysinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.gioitinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            this.panel3.Size = new System.Drawing.Size(592, 36);
            this.panel3.TabIndex = 23;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            this.exitButton.Location = new System.Drawing.Point(552, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 36);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // hodem
            // 
            this.hodem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hodem.DefaultText = "";
            this.hodem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.hodem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.hodem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.hodem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.hodem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.hodem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hodem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.hodem.Location = new System.Drawing.Point(250, 61);
            this.hodem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hodem.Name = "hodem";
            this.hodem.PlaceholderText = "";
            this.hodem.SelectedText = "";
            this.hodem.Size = new System.Drawing.Size(275, 48);
            this.hodem.TabIndex = 24;
            this.hodem.Enter += new System.EventHandler(this.hodem_Enter);
            this.hodem.Leave += new System.EventHandler(this.hodem_Leave);
            // 
            // ten
            // 
            this.ten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ten.DefaultText = "";
            this.ten.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ten.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ten.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ten.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ten.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ten.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ten.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ten.Location = new System.Drawing.Point(250, 126);
            this.ten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ten.Name = "ten";
            this.ten.PlaceholderText = "";
            this.ten.SelectedText = "";
            this.ten.Size = new System.Drawing.Size(275, 48);
            this.ten.TabIndex = 25;
            this.ten.Enter += new System.EventHandler(this.ten_Enter);
            this.ten.Leave += new System.EventHandler(this.ten_Leave);
            // 
            // sdt
            // 
            this.sdt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sdt.DefaultText = "";
            this.sdt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sdt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.sdt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sdt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sdt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sdt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sdt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sdt.Location = new System.Drawing.Point(250, 295);
            this.sdt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sdt.Name = "sdt";
            this.sdt.PlaceholderText = "";
            this.sdt.SelectedText = "";
            this.sdt.Size = new System.Drawing.Size(275, 48);
            this.sdt.TabIndex = 26;
            this.sdt.Enter += new System.EventHandler(this.sdt_Enter);
            this.sdt.Leave += new System.EventHandler(this.sdt_Leave);
            // 
            // email
            // 
            this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email.DefaultText = "";
            this.email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email.Location = new System.Drawing.Point(250, 369);
            this.email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.email.Name = "email";
            this.email.PlaceholderText = "";
            this.email.SelectedText = "";
            this.email.Size = new System.Drawing.Size(275, 48);
            this.email.TabIndex = 27;
            this.email.Enter += new System.EventHandler(this.email_Enter);
            this.email.Leave += new System.EventHandler(this.email_Leave);
            // 
            // ngaysinh
            // 
            this.ngaysinh.Checked = true;
            this.ngaysinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ngaysinh.Location = new System.Drawing.Point(250, 190);
            this.ngaysinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngaysinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(275, 48);
            this.ngaysinh.TabIndex = 28;
            this.ngaysinh.Value = new System.DateTime(2025, 3, 31, 1, 29, 9, 698);
            // 
            // gioitinh
            // 
            this.gioitinh.BackColor = System.Drawing.Color.Transparent;
            this.gioitinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gioitinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gioitinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gioitinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gioitinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gioitinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.gioitinh.ItemHeight = 30;
            this.gioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.gioitinh.Location = new System.Drawing.Point(250, 248);
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.Size = new System.Drawing.Size(275, 36);
            this.gioitinh.TabIndex = 29;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(53, 75);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(62, 22);
            this.guna2HtmlLabel1.TabIndex = 30;
            this.guna2HtmlLabel1.Text = "Họ đệm";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(53, 144);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(31, 22);
            this.guna2HtmlLabel2.TabIndex = 31;
            this.guna2HtmlLabel2.Text = "Tên";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(53, 202);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(77, 22);
            this.guna2HtmlLabel3.TabIndex = 32;
            this.guna2HtmlLabel3.Text = "Ngày sinh";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(53, 262);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(65, 22);
            this.guna2HtmlLabel4.TabIndex = 33;
            this.guna2HtmlLabel4.Text = "Giới tính";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(53, 321);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(36, 22);
            this.guna2HtmlLabel5.TabIndex = 34;
            this.guna2HtmlLabel5.Text = "SĐT";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(53, 380);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(45, 22);
            this.guna2HtmlLabel6.TabIndex = 35;
            this.guna2HtmlLabel6.Text = "Email";
            // 
            // luu
            // 
            this.luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.luu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.luu.ForeColor = System.Drawing.Color.White;
            this.luu.Location = new System.Drawing.Point(207, 443);
            this.luu.Name = "luu";
            this.luu.Size = new System.Drawing.Size(180, 45);
            this.luu.TabIndex = 36;
            this.luu.Text = "Lưu";
            this.luu.Click += new System.EventHandler(this.luu_Click);
            // 
            // Form_Tenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 515);
            this.Controls.Add(this.luu);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.gioitinh);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.email);
            this.Controls.Add(this.sdt);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.hodem);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Tenant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2TextBox hodem;
        private Guna.UI2.WinForms.Guna2TextBox ten;
        private Guna.UI2.WinForms.Guna2TextBox sdt;
        private Guna.UI2.WinForms.Guna2TextBox email;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngaysinh;
        private Guna.UI2.WinForms.Guna2ComboBox gioitinh;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2Button luu;
    }
}