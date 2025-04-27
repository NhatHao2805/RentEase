namespace GUI
{
    partial class Form_SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SignUp));
            this.labelMK_DK2 = new System.Windows.Forms.Label();
            this.labelMK_DK1 = new System.Windows.Forms.Label();
            this.labelTK_DK = new System.Windows.Forms.Label();
            this.name_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.email_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.sdt_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.diachi_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.ns_datetimepicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.info_account = new Guna.UI2.WinForms.Guna2GroupBox();
            this.buttonXemPass2 = new Guna.UI2.WinForms.Guna2Button();
            this.buttonXemPass1 = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxTK_DK = new GUI.Custom.MyGunaTextBox();
            this.buttonDangKy = new GUI.Custom.MyGunaButton();
            this.textBoxMK_DK1 = new GUI.Custom.MyGunaTextBox();
            this.textBoxMK_DK2 = new GUI.Custom.MyGunaTextBox();
            this.info_user = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gt_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2GradientPanel12 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CustomGradientPanel18 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.info_account.SuspendLayout();
            this.info_user.SuspendLayout();
            this.guna2GradientPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMK_DK2
            // 
            this.labelMK_DK2.AutoSize = true;
            this.labelMK_DK2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMK_DK2.ForeColor = System.Drawing.Color.Black;
            this.labelMK_DK2.Location = new System.Drawing.Point(51, 238);
            this.labelMK_DK2.Name = "labelMK_DK2";
            this.labelMK_DK2.Size = new System.Drawing.Size(160, 23);
            this.labelMK_DK2.TabIndex = 16;
            this.labelMK_DK2.Text = "Xác nhận mật khẩu";
            // 
            // labelMK_DK1
            // 
            this.labelMK_DK1.AutoSize = true;
            this.labelMK_DK1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMK_DK1.ForeColor = System.Drawing.Color.Black;
            this.labelMK_DK1.Location = new System.Drawing.Point(51, 163);
            this.labelMK_DK1.Name = "labelMK_DK1";
            this.labelMK_DK1.Size = new System.Drawing.Size(84, 23);
            this.labelMK_DK1.TabIndex = 15;
            this.labelMK_DK1.Text = "Mật khẩu";
            // 
            // labelTK_DK
            // 
            this.labelTK_DK.AutoSize = true;
            this.labelTK_DK.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTK_DK.ForeColor = System.Drawing.Color.Black;
            this.labelTK_DK.Location = new System.Drawing.Point(51, 75);
            this.labelTK_DK.Name = "labelTK_DK";
            this.labelTK_DK.Size = new System.Drawing.Size(83, 23);
            this.labelTK_DK.TabIndex = 14;
            this.labelTK_DK.Text = "Tài khoản";
            // 
            // name_tb
            // 
            this.name_tb.BorderColor = System.Drawing.Color.Gray;
            this.name_tb.BorderRadius = 10;
            this.name_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.name_tb.DefaultText = "";
            this.name_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.name_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.name_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.name_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name_tb.Location = new System.Drawing.Point(21, 89);
            this.name_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.name_tb.Name = "name_tb";
            this.name_tb.PlaceholderText = "";
            this.name_tb.SelectedText = "";
            this.name_tb.Size = new System.Drawing.Size(255, 39);
            this.name_tb.TabIndex = 3;
            // 
            // email_tb
            // 
            this.email_tb.BackColor = System.Drawing.Color.Transparent;
            this.email_tb.BorderColor = System.Drawing.Color.Silver;
            this.email_tb.BorderRadius = 10;
            this.email_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email_tb.DefaultText = "";
            this.email_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.email_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.email_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.email_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email_tb.Location = new System.Drawing.Point(313, 89);
            this.email_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.email_tb.Name = "email_tb";
            this.email_tb.PlaceholderText = "";
            this.email_tb.SelectedText = "";
            this.email_tb.ShadowDecoration.BorderRadius = 10;
            this.email_tb.ShadowDecoration.Enabled = true;
            this.email_tb.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.email_tb.Size = new System.Drawing.Size(255, 39);
            this.email_tb.TabIndex = 4;
            // 
            // sdt_tb
            // 
            this.sdt_tb.BackColor = System.Drawing.Color.Transparent;
            this.sdt_tb.BorderColor = System.Drawing.Color.Silver;
            this.sdt_tb.BorderRadius = 10;
            this.sdt_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sdt_tb.DefaultText = "";
            this.sdt_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sdt_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.sdt_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sdt_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sdt_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sdt_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sdt_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sdt_tb.Location = new System.Drawing.Point(313, 267);
            this.sdt_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sdt_tb.Name = "sdt_tb";
            this.sdt_tb.PlaceholderText = "";
            this.sdt_tb.SelectedText = "";
            this.sdt_tb.ShadowDecoration.BorderRadius = 10;
            this.sdt_tb.ShadowDecoration.Enabled = true;
            this.sdt_tb.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.sdt_tb.Size = new System.Drawing.Size(255, 39);
            this.sdt_tb.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Họ và tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(317, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(317, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Địa Chỉ";
            // 
            // diachi_tb
            // 
            this.diachi_tb.BackColor = System.Drawing.Color.Transparent;
            this.diachi_tb.BorderColor = System.Drawing.Color.Silver;
            this.diachi_tb.BorderRadius = 10;
            this.diachi_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.diachi_tb.DefaultText = "";
            this.diachi_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.diachi_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.diachi_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.diachi_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.diachi_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.diachi_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.diachi_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.diachi_tb.Location = new System.Drawing.Point(313, 175);
            this.diachi_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.diachi_tb.Name = "diachi_tb";
            this.diachi_tb.PlaceholderText = "";
            this.diachi_tb.SelectedText = "";
            this.diachi_tb.ShadowDecoration.BorderRadius = 10;
            this.diachi_tb.ShadowDecoration.Enabled = true;
            this.diachi_tb.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.diachi_tb.Size = new System.Drawing.Size(255, 39);
            this.diachi_tb.TabIndex = 5;
            // 
            // ns_datetimepicker
            // 
            this.ns_datetimepicker.BackColor = System.Drawing.Color.White;
            this.ns_datetimepicker.BorderColor = System.Drawing.Color.Gray;
            this.ns_datetimepicker.BorderRadius = 10;
            this.ns_datetimepicker.Checked = true;
            this.ns_datetimepicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ns_datetimepicker.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ns_datetimepicker.ForeColor = System.Drawing.Color.Black;
            this.ns_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ns_datetimepicker.Location = new System.Drawing.Point(25, 175);
            this.ns_datetimepicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ns_datetimepicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ns_datetimepicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ns_datetimepicker.Name = "ns_datetimepicker";
            this.ns_datetimepicker.Size = new System.Drawing.Size(255, 39);
            this.ns_datetimepicker.TabIndex = 8;
            this.ns_datetimepicker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ns_datetimepicker.Value = new System.DateTime(2025, 3, 18, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(27, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "Ngày sinh";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // info_account
            // 
            this.info_account.Controls.Add(this.buttonXemPass2);
            this.info_account.Controls.Add(this.buttonXemPass1);
            this.info_account.Controls.Add(this.textBoxTK_DK);
            this.info_account.Controls.Add(this.buttonDangKy);
            this.info_account.Controls.Add(this.labelTK_DK);
            this.info_account.Controls.Add(this.labelMK_DK1);
            this.info_account.Controls.Add(this.labelMK_DK2);
            this.info_account.Controls.Add(this.textBoxMK_DK1);
            this.info_account.Controls.Add(this.textBoxMK_DK2);
            this.info_account.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.info_account.FillColor = System.Drawing.Color.AliceBlue;
            this.info_account.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_account.ForeColor = System.Drawing.Color.White;
            this.info_account.Location = new System.Drawing.Point(599, 71);
            this.info_account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.info_account.Name = "info_account";
            this.info_account.Size = new System.Drawing.Size(340, 411);
            this.info_account.TabIndex = 92;
            this.info_account.Text = "Thông tin tài khoản";
            this.info_account.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonXemPass2
            // 
            this.buttonXemPass2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonXemPass2.BorderThickness = 1;
            this.buttonXemPass2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonXemPass2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonXemPass2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonXemPass2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonXemPass2.FillColor = System.Drawing.Color.White;
            this.buttonXemPass2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonXemPass2.ForeColor = System.Drawing.Color.White;
            this.buttonXemPass2.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.buttonXemPass2.Image = ((System.Drawing.Image)(resources.GetObject("buttonXemPass2.Image")));
            this.buttonXemPass2.ImageSize = new System.Drawing.Size(25, 25);
            this.buttonXemPass2.Location = new System.Drawing.Point(259, 265);
            this.buttonXemPass2.Name = "buttonXemPass2";
            this.buttonXemPass2.Size = new System.Drawing.Size(33, 33);
            this.buttonXemPass2.TabIndex = 152;
            this.buttonXemPass2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass2_MouseDown);
            this.buttonXemPass2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass2_MouseUp);
            // 
            // buttonXemPass1
            // 
            this.buttonXemPass1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonXemPass1.BorderThickness = 1;
            this.buttonXemPass1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonXemPass1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonXemPass1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonXemPass1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonXemPass1.FillColor = System.Drawing.Color.White;
            this.buttonXemPass1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonXemPass1.ForeColor = System.Drawing.Color.White;
            this.buttonXemPass1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.buttonXemPass1.Image = ((System.Drawing.Image)(resources.GetObject("buttonXemPass1.Image")));
            this.buttonXemPass1.ImageSize = new System.Drawing.Size(25, 25);
            this.buttonXemPass1.Location = new System.Drawing.Point(259, 192);
            this.buttonXemPass1.Name = "buttonXemPass1";
            this.buttonXemPass1.Size = new System.Drawing.Size(33, 33);
            this.buttonXemPass1.TabIndex = 151;
            this.buttonXemPass1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass1_MouseDown);
            this.buttonXemPass1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass1_MouseUp);
            // 
            // textBoxTK_DK
            // 
            this.textBoxTK_DK.BackColor = System.Drawing.Color.Transparent;
            this.textBoxTK_DK.BorderColor = System.Drawing.Color.Silver;
            this.textBoxTK_DK.BorderRadius = 10;
            this.textBoxTK_DK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTK_DK.DefaultText = "";
            this.textBoxTK_DK.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxTK_DK.ForeColor = System.Drawing.Color.Black;
            this.textBoxTK_DK.Location = new System.Drawing.Point(45, 104);
            this.textBoxTK_DK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTK_DK.Multiline = true;
            this.textBoxTK_DK.Name = "textBoxTK_DK";
            this.textBoxTK_DK.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.textBoxTK_DK.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxTK_DK.PlaceholderText = "";
            this.textBoxTK_DK.SelectedText = "";
            this.textBoxTK_DK.ShadowDecoration.BorderRadius = 10;
            this.textBoxTK_DK.ShadowDecoration.Enabled = true;
            this.textBoxTK_DK.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxTK_DK.Size = new System.Drawing.Size(255, 39);
            this.textBoxTK_DK.TabIndex = 0;
            this.textBoxTK_DK.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // buttonDangKy
            // 
            this.buttonDangKy.BorderColor = System.Drawing.Color.Transparent;
            this.buttonDangKy.BorderRadius = 10;
            this.buttonDangKy.FillColor = System.Drawing.Color.Teal;
            this.buttonDangKy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangKy.ForeColor = System.Drawing.Color.White;
            this.buttonDangKy.Location = new System.Drawing.Point(45, 339);
            this.buttonDangKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDangKy.Name = "buttonDangKy";
            this.buttonDangKy.Size = new System.Drawing.Size(255, 39);
            this.buttonDangKy.TabIndex = 9;
            this.buttonDangKy.Text = "Đăng ký";
            this.buttonDangKy.Click += new System.EventHandler(this.buttonDangKy_Click);
            // 
            // textBoxMK_DK1
            // 
            this.textBoxMK_DK1.BackColor = System.Drawing.Color.Transparent;
            this.textBoxMK_DK1.BorderColor = System.Drawing.Color.Silver;
            this.textBoxMK_DK1.BorderRadius = 10;
            this.textBoxMK_DK1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxMK_DK1.DefaultText = "";
            this.textBoxMK_DK1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxMK_DK1.ForeColor = System.Drawing.Color.Black;
            this.textBoxMK_DK1.Location = new System.Drawing.Point(45, 189);
            this.textBoxMK_DK1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMK_DK1.Multiline = true;
            this.textBoxMK_DK1.Name = "textBoxMK_DK1";
            this.textBoxMK_DK1.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.textBoxMK_DK1.PasswordChar = '*';
            this.textBoxMK_DK1.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxMK_DK1.PlaceholderText = "";
            this.textBoxMK_DK1.SelectedText = "";
            this.textBoxMK_DK1.ShadowDecoration.BorderRadius = 10;
            this.textBoxMK_DK1.ShadowDecoration.Enabled = true;
            this.textBoxMK_DK1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxMK_DK1.Size = new System.Drawing.Size(255, 39);
            this.textBoxMK_DK1.TabIndex = 1;
            this.textBoxMK_DK1.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // textBoxMK_DK2
            // 
            this.textBoxMK_DK2.BackColor = System.Drawing.Color.Transparent;
            this.textBoxMK_DK2.BorderColor = System.Drawing.Color.Silver;
            this.textBoxMK_DK2.BorderRadius = 10;
            this.textBoxMK_DK2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxMK_DK2.DefaultText = "";
            this.textBoxMK_DK2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxMK_DK2.ForeColor = System.Drawing.Color.Black;
            this.textBoxMK_DK2.Location = new System.Drawing.Point(45, 262);
            this.textBoxMK_DK2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMK_DK2.Multiline = true;
            this.textBoxMK_DK2.Name = "textBoxMK_DK2";
            this.textBoxMK_DK2.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.textBoxMK_DK2.PasswordChar = '*';
            this.textBoxMK_DK2.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxMK_DK2.PlaceholderText = "";
            this.textBoxMK_DK2.SelectedText = "";
            this.textBoxMK_DK2.ShadowDecoration.BorderRadius = 10;
            this.textBoxMK_DK2.ShadowDecoration.Enabled = true;
            this.textBoxMK_DK2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxMK_DK2.Size = new System.Drawing.Size(255, 39);
            this.textBoxMK_DK2.TabIndex = 2;
            this.textBoxMK_DK2.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // info_user
            // 
            this.info_user.Controls.Add(this.label7);
            this.info_user.Controls.Add(this.gt_cb);
            this.info_user.Controls.Add(this.email_tb);
            this.info_user.Controls.Add(this.name_tb);
            this.info_user.Controls.Add(this.label6);
            this.info_user.Controls.Add(this.guna2DateTimePicker1);
            this.info_user.Controls.Add(this.sdt_tb);
            this.info_user.Controls.Add(this.ns_datetimepicker);
            this.info_user.Controls.Add(this.label2);
            this.info_user.Controls.Add(this.label5);
            this.info_user.Controls.Add(this.label3);
            this.info_user.Controls.Add(this.diachi_tb);
            this.info_user.Controls.Add(this.label4);
            this.info_user.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.info_user.FillColor = System.Drawing.Color.AliceBlue;
            this.info_user.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_user.ForeColor = System.Drawing.Color.White;
            this.info_user.Location = new System.Drawing.Point(6, 71);
            this.info_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.info_user.Name = "info_user";
            this.info_user.Size = new System.Drawing.Size(587, 411);
            this.info_user.TabIndex = 91;
            this.info_user.Text = "Thông tin khách hàng";
            this.info_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(29, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 38;
            this.label7.Text = "Giới tính";
            // 
            // gt_cb
            // 
            this.gt_cb.BackColor = System.Drawing.Color.Transparent;
            this.gt_cb.BorderRadius = 10;
            this.gt_cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gt_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gt_cb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gt_cb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gt_cb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gt_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.gt_cb.ItemHeight = 24;
            this.gt_cb.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác..."});
            this.gt_cb.Location = new System.Drawing.Point(25, 271);
            this.gt_cb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gt_cb.Name = "gt_cb";
            this.gt_cb.Size = new System.Drawing.Size(255, 30);
            this.gt_cb.TabIndex = 7;
            this.gt_cb.SelectedIndexChanged += new System.EventHandler(this.gt_cb_SelectedIndexChanged);
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.BackColor = System.Drawing.Color.Transparent;
            this.guna2DateTimePicker1.BorderColor = System.Drawing.Color.Silver;
            this.guna2DateTimePicker1.BorderRadius = 10;
            this.guna2DateTimePicker1.BorderThickness = 1;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(25, 175);
            this.guna2DateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.ShadowDecoration.BorderRadius = 10;
            this.guna2DateTimePicker1.ShadowDecoration.Enabled = true;
            this.guna2DateTimePicker1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(255, 39);
            this.guna2DateTimePicker1.TabIndex = 8;
            this.guna2DateTimePicker1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2DateTimePicker1.Value = new System.DateTime(2025, 3, 18, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(317, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "Số điện thoại";
            // 
            // guna2GradientPanel12
            // 
            this.guna2GradientPanel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel12.Controls.Add(this.btnBack);
            this.guna2GradientPanel12.Controls.Add(this.guna2PictureBox1);
            this.guna2GradientPanel12.Controls.Add(this.guna2CustomGradientPanel18);
            this.guna2GradientPanel12.Controls.Add(this.label22);
            this.guna2GradientPanel12.Controls.Add(this.label1);
            this.guna2GradientPanel12.Controls.Add(this.guna2Button2);
            this.guna2GradientPanel12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.guna2GradientPanel12.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.guna2GradientPanel12.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel12.Name = "guna2GradientPanel12";
            this.guna2GradientPanel12.Size = new System.Drawing.Size(948, 70);
            this.guna2GradientPanel12.TabIndex = 149;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.Silver;
            this.btnBack.BorderRadius = 5;
            this.btnBack.BorderThickness = 1;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.MintCream;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnBack.Image = global::GUI.Properties.Resources.icons8_back_50;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.Location = new System.Drawing.Point(825, 1);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.BorderRadius = 10;
            this.btnBack.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(120, 30);
            this.btnBack.TabIndex = 138;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.icons8_list1;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 7);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(60, 60);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 137;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2CustomGradientPanel18
            // 
            this.guna2CustomGradientPanel18.BorderRadius = 2;
            this.guna2CustomGradientPanel18.FillColor = System.Drawing.Color.Honeydew;
            this.guna2CustomGradientPanel18.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2CustomGradientPanel18.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel18.Location = new System.Drawing.Point(75, 10);
            this.guna2CustomGradientPanel18.Name = "guna2CustomGradientPanel18";
            this.guna2CustomGradientPanel18.Size = new System.Drawing.Size(7, 50);
            this.guna2CustomGradientPanel18.TabIndex = 136;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(88, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(155, 20);
            this.label22.TabIndex = 134;
            this.label22.Text = "Đăng ký tài khoản mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(86, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 35);
            this.label1.TabIndex = 135;
            this.label1.Text = "Đăng ký";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Button2.Image = global::GUI.Properties.Resources.icon_0;
            this.guna2Button2.Location = new System.Drawing.Point(794, 1);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(30, 30);
            this.guna2Button2.TabIndex = 133;
            this.guna2Button2.Click += new System.EventHandler(this.minimizedButton_Click);
            // 
            // Form_SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(948, 501);
            this.Controls.Add(this.guna2GradientPanel12);
            this.Controls.Add(this.info_user);
            this.Controls.Add(this.info_account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.info_account.ResumeLayout(false);
            this.info_account.PerformLayout();
            this.info_user.ResumeLayout(false);
            this.info_user.PerformLayout();
            this.guna2GradientPanel12.ResumeLayout(false);
            this.guna2GradientPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelMK_DK2;
        private System.Windows.Forms.Label labelMK_DK1;
        private Custom.MyGunaTextBox textBoxTK_DK;
        private System.Windows.Forms.Label labelTK_DK;
        private Custom.MyGunaButton buttonDangKy;
        private Custom.MyGunaTextBox textBoxMK_DK1;
        private Guna.UI2.WinForms.Guna2TextBox name_tb;
        private Guna.UI2.WinForms.Guna2TextBox email_tb;
        private Guna.UI2.WinForms.Guna2TextBox sdt_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox diachi_tb;
        private Guna.UI2.WinForms.Guna2DateTimePicker ns_datetimepicker;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2GroupBox info_account;
        private Guna.UI2.WinForms.Guna2GroupBox info_user;
        private Guna.UI2.WinForms.Guna2ComboBox gt_cb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Custom.MyGunaTextBox textBoxMK_DK2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel12;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2Button buttonXemPass1;
        private Guna.UI2.WinForms.Guna2Button buttonXemPass2;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}