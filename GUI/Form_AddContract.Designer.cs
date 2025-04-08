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
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.DiaChiToaNha = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TenKhachHang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2DateTimePicker3 = new Guna.UI2.WinForms.Guna2DateTimePicker();
=======
            this.ListTenantID = new Guna.UI2.WinForms.Guna2ComboBox();
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
            this.GiaThue = new Guna.UI2.WinForms.Guna2TextBox();
            this.LichThanhToan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TienDatCoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.GhiChu = new Guna.UI2.WinForms.Guna2TextBox();
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            // DiaChiToaNha
            // 
            this.DiaChiToaNha.BackColor = System.Drawing.Color.Transparent;
            this.DiaChiToaNha.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DiaChiToaNha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiaChiToaNha.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DiaChiToaNha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DiaChiToaNha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DiaChiToaNha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.DiaChiToaNha.ItemHeight = 30;
            this.DiaChiToaNha.Location = new System.Drawing.Point(224, 60);
            this.DiaChiToaNha.Name = "DiaChiToaNha";
            this.DiaChiToaNha.Size = new System.Drawing.Size(357, 36);
            this.DiaChiToaNha.TabIndex = 23;
            this.DiaChiToaNha.SelectedValueChanged += new System.EventHandler(this.guna2ComboBox1_SelectedValueChanged);
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
            this.TenKhachHang.Location = new System.Drawing.Point(224, 164);
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Size = new System.Drawing.Size(357, 36);
            this.TenKhachHang.TabIndex = 24;
=======
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SoPhong = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel12 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CustomGradientPanel18 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel28 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel5 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2DateTimePicker3 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel6 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel7 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel8 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel9 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.saveButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            this.guna2CustomGradientPanel28.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            this.guna2GradientPanel3.SuspendLayout();
            this.guna2GradientPanel4.SuspendLayout();
            this.guna2GradientPanel5.SuspendLayout();
            this.guna2GradientPanel6.SuspendLayout();
            this.guna2GradientPanel7.SuspendLayout();
            this.guna2GradientPanel8.SuspendLayout();
            this.guna2GradientPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListTenantID
            // 
            this.ListTenantID.BackColor = System.Drawing.Color.Transparent;
            this.ListTenantID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ListTenantID.BorderRadius = 10;
            this.ListTenantID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListTenantID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListTenantID.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ListTenantID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ListTenantID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ListTenantID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ListTenantID.ItemHeight = 30;
            this.ListTenantID.Location = new System.Drawing.Point(115, 7);
            this.ListTenantID.Name = "ListTenantID";
            this.ListTenantID.ShadowDecoration.BorderRadius = 10;
            this.ListTenantID.ShadowDecoration.Enabled = true;
            this.ListTenantID.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.ListTenantID.Size = new System.Drawing.Size(220, 36);
            this.ListTenantID.TabIndex = 24;
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
            // 
            // GiaThue
            // 
            this.GiaThue.BackColor = System.Drawing.Color.Transparent;
            this.GiaThue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GiaThue.BorderRadius = 10;
            this.GiaThue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GiaThue.DefaultText = "";
            this.GiaThue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GiaThue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GiaThue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GiaThue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GiaThue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GiaThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GiaThue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GiaThue.Location = new System.Drawing.Point(239, 10);
            this.GiaThue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GiaThue.Name = "GiaThue";
            this.GiaThue.PlaceholderText = "";
            this.GiaThue.ReadOnly = true;
            this.GiaThue.SelectedText = "";
            this.GiaThue.ShadowDecoration.BorderRadius = 10;
            this.GiaThue.ShadowDecoration.Enabled = true;
            this.GiaThue.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.GiaThue.Size = new System.Drawing.Size(329, 36);
            this.GiaThue.TabIndex = 28;
            // 
            // LichThanhToan
            // 
            this.LichThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.LichThanhToan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LichThanhToan.BorderRadius = 10;
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
            this.LichThanhToan.Location = new System.Drawing.Point(145, 9);
            this.LichThanhToan.Name = "LichThanhToan";
            this.LichThanhToan.ShadowDecoration.BorderRadius = 10;
            this.LichThanhToan.ShadowDecoration.Enabled = true;
            this.LichThanhToan.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.LichThanhToan.Size = new System.Drawing.Size(200, 36);
            this.LichThanhToan.TabIndex = 29;
            this.LichThanhToan.SelectedIndexChanged += new System.EventHandler(this.LichThanhToan_SelectedIndexChanged);
            // 
            // TienDatCoc
            // 
            this.TienDatCoc.BackColor = System.Drawing.Color.Transparent;
            this.TienDatCoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TienDatCoc.BorderRadius = 10;
            this.TienDatCoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TienDatCoc.DefaultText = " ";
            this.TienDatCoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TienDatCoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TienDatCoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TienDatCoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TienDatCoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TienDatCoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TienDatCoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TienDatCoc.Location = new System.Drawing.Point(132, 9);
            this.TienDatCoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TienDatCoc.Name = "TienDatCoc";
            this.TienDatCoc.PlaceholderText = "";
            this.TienDatCoc.SelectedText = "";
            this.TienDatCoc.ShadowDecoration.BorderRadius = 10;
            this.TienDatCoc.ShadowDecoration.Enabled = true;
            this.TienDatCoc.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.TienDatCoc.Size = new System.Drawing.Size(170, 36);
            this.TienDatCoc.TabIndex = 30;
            // 
            // GhiChu
            // 
            this.GhiChu.BackColor = System.Drawing.Color.Transparent;
            this.GhiChu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GhiChu.BorderRadius = 10;
            this.GhiChu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GhiChu.DefaultText = "";
            this.GhiChu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GhiChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GhiChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GhiChu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GhiChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GhiChu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GhiChu.Location = new System.Drawing.Point(97, 13);
            this.GhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.PlaceholderText = "";
            this.GhiChu.SelectedText = "";
            this.GhiChu.ShadowDecoration.BorderRadius = 10;
            this.GhiChu.ShadowDecoration.Enabled = true;
            this.GhiChu.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.GhiChu.Size = new System.Drawing.Size(619, 102);
            this.GhiChu.TabIndex = 32;
            // 
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(40, 69);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(101, 18);
            this.guna2HtmlLabel1.TabIndex = 34;
            this.guna2HtmlLabel1.Text = "Địa Chỉ Tòa Nhà";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(40, 173);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(103, 18);
            this.guna2HtmlLabel2.TabIndex = 35;
            this.guna2HtmlLabel2.Text = "Tên Khách Hàng";
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
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(40, 121);
=======
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(10, 14);
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(77, 25);
            this.guna2HtmlLabel9.TabIndex = 46;
            this.guna2HtmlLabel9.Text = "Số phòng";
            // 
            // SoPhong
            // 
            this.SoPhong.BackColor = System.Drawing.Color.Transparent;
            this.SoPhong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SoPhong.BorderRadius = 10;
            this.SoPhong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SoPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SoPhong.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SoPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SoPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SoPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.SoPhong.ItemHeight = 30;
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
            this.SoPhong.Location = new System.Drawing.Point(224, 112);
=======
            this.SoPhong.Location = new System.Drawing.Point(115, 7);
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.ShadowDecoration.BorderRadius = 10;
            this.SoPhong.ShadowDecoration.Enabled = true;
            this.SoPhong.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.SoPhong.Size = new System.Drawing.Size(220, 36);
            this.SoPhong.TabIndex = 45;
            this.SoPhong.SelectedValueChanged += new System.EventHandler(this.guna2ComboBox4_SelectedValueChanged);
            // 
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
=======
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(10, 14);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(93, 25);
            this.guna2HtmlLabel1.TabIndex = 48;
            this.guna2HtmlLabel1.Text = "Khách Thuê";
            // 
            // guna2GradientPanel12
            // 
            this.guna2GradientPanel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel12.Controls.Add(this.guna2PictureBox5);
            this.guna2GradientPanel12.Controls.Add(this.guna2CustomGradientPanel18);
            this.guna2GradientPanel12.Controls.Add(this.label22);
            this.guna2GradientPanel12.Controls.Add(this.label23);
            this.guna2GradientPanel12.FillColor = System.Drawing.Color.LightCyan;
            this.guna2GradientPanel12.FillColor2 = System.Drawing.Color.Lavender;
            this.guna2GradientPanel12.Location = new System.Drawing.Point(0, 39);
            this.guna2GradientPanel12.Name = "guna2GradientPanel12";
            this.guna2GradientPanel12.Size = new System.Drawing.Size(800, 70);
            this.guna2GradientPanel12.TabIndex = 131;
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Image = global::GUI.Properties.Resources.icons8_document;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(22, 5);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(60, 60);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox5.TabIndex = 132;
            this.guna2PictureBox5.TabStop = false;
            // 
            // guna2CustomGradientPanel18
            // 
            this.guna2CustomGradientPanel18.BorderRadius = 2;
            this.guna2CustomGradientPanel18.FillColor = System.Drawing.Color.PaleGreen;
            this.guna2CustomGradientPanel18.FillColor2 = System.Drawing.Color.Black;
            this.guna2CustomGradientPanel18.FillColor3 = System.Drawing.Color.DarkKhaki;
            this.guna2CustomGradientPanel18.FillColor4 = System.Drawing.Color.Lime;
            this.guna2CustomGradientPanel18.Location = new System.Drawing.Point(94, 8);
            this.guna2CustomGradientPanel18.Name = "guna2CustomGradientPanel18";
            this.guna2CustomGradientPanel18.Size = new System.Drawing.Size(7, 50);
            this.guna2CustomGradientPanel18.TabIndex = 125;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(102, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 20);
            this.label22.TabIndex = 122;
            this.label22.Text = "Thêm hợp đồng mới";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(100, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(182, 29);
            this.label23.TabIndex = 123;
            this.label23.Text = "Thêm hợp đồng";
            // 
            // guna2CustomGradientPanel28
            // 
            this.guna2CustomGradientPanel28.Controls.Add(this.guna2Button1);
            this.guna2CustomGradientPanel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel28.FillColor = System.Drawing.Color.Honeydew;
            this.guna2CustomGradientPanel28.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.guna2CustomGradientPanel28.FillColor3 = System.Drawing.Color.LightSeaGreen;
            this.guna2CustomGradientPanel28.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.guna2CustomGradientPanel28.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel28.Name = "guna2CustomGradientPanel28";
            this.guna2CustomGradientPanel28.Size = new System.Drawing.Size(800, 40);
            this.guna2CustomGradientPanel28.TabIndex = 135;
            this.guna2CustomGradientPanel28.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Button1.BorderRadius = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Button1.FillColor = System.Drawing.Color.IndianRed;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::GUI.Properties.Resources.icon_2;
            this.guna2Button1.Location = new System.Drawing.Point(760, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(40, 40);
            this.guna2Button1.TabIndex = 20;
            this.guna2Button1.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.BorderThickness = 1;
            this.guna2GradientPanel1.Controls.Add(this.SoPhong);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel9);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(36, 128);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel1.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(360, 55);
            this.guna2GradientPanel1.TabIndex = 136;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel2.BorderRadius = 10;
            this.guna2GradientPanel2.BorderThickness = 1;
            this.guna2GradientPanel2.Controls.Add(this.ListTenantID);
            this.guna2GradientPanel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel2.Location = new System.Drawing.Point(407, 128);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel2.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel2.Size = new System.Drawing.Size(360, 55);
            this.guna2GradientPanel2.TabIndex = 137;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.BackColor = System.Drawing.Color.Transparent;
            this.guna2DateTimePicker1.BorderRadius = 10;
            this.guna2DateTimePicker1.BorderThickness = 1;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.guna2DateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(86)))), ((int)(((byte)(71)))));
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(218, 7);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.ShadowDecoration.BorderRadius = 10;
            this.guna2DateTimePicker1.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.guna2DateTimePicker1.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.guna2DateTimePicker1.ShadowDecoration.Depth = 60;
            this.guna2DateTimePicker1.ShadowDecoration.Enabled = true;
            this.guna2DateTimePicker1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(347, 40);
            this.guna2DateTimePicker1.TabIndex = 138;
            this.guna2DateTimePicker1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2DateTimePicker1.Value = new System.DateTime(2025, 4, 7, 0, 0, 0, 0);
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel3.BorderRadius = 10;
            this.guna2GradientPanel3.BorderThickness = 1;
            this.guna2GradientPanel3.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel3.Controls.Add(this.guna2DateTimePicker1);
            this.guna2GradientPanel3.Location = new System.Drawing.Point(36, 196);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel3.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel3.Size = new System.Drawing.Size(731, 55);
            this.guna2GradientPanel3.TabIndex = 139;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(49, 14);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(74, 25);
            this.guna2HtmlLabel2.TabIndex = 46;
            this.guna2HtmlLabel2.Text = "Ngày tạo";
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel4.BorderRadius = 10;
            this.guna2GradientPanel4.BorderThickness = 1;
            this.guna2GradientPanel4.Controls.Add(this.guna2DateTimePicker2);
            this.guna2GradientPanel4.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GradientPanel4.Location = new System.Drawing.Point(36, 265);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel4.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel4.Size = new System.Drawing.Size(360, 55);
            this.guna2GradientPanel4.TabIndex = 140;
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.BackColor = System.Drawing.Color.Transparent;
            this.guna2DateTimePicker2.BorderRadius = 10;
            this.guna2DateTimePicker2.BorderThickness = 1;
            this.guna2DateTimePicker2.Checked = true;
            this.guna2DateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.guna2DateTimePicker2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2DateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.guna2DateTimePicker2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(86)))), ((int)(((byte)(71)))));
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(144, 6);
            this.guna2DateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.ShadowDecoration.BorderRadius = 10;
            this.guna2DateTimePicker2.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.guna2DateTimePicker2.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.guna2DateTimePicker2.ShadowDecoration.Depth = 60;
            this.guna2DateTimePicker2.ShadowDecoration.Enabled = true;
            this.guna2DateTimePicker2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(177, 40);
            this.guna2DateTimePicker2.TabIndex = 139;
            this.guna2DateTimePicker2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2DateTimePicker2.Value = new System.DateTime(2025, 4, 7, 0, 0, 0, 0);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(10, 14);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(110, 25);
            this.guna2HtmlLabel3.TabIndex = 46;
            this.guna2HtmlLabel3.Text = "Ngày Bắt Đầu";
            // 
            // guna2GradientPanel5
            // 
            this.guna2GradientPanel5.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel5.BorderRadius = 10;
            this.guna2GradientPanel5.BorderThickness = 1;
            this.guna2GradientPanel5.Controls.Add(this.guna2DateTimePicker3);
            this.guna2GradientPanel5.Controls.Add(this.guna2HtmlLabel4);
            this.guna2GradientPanel5.Location = new System.Drawing.Point(407, 265);
            this.guna2GradientPanel5.Name = "guna2GradientPanel5";
            this.guna2GradientPanel5.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel5.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel5.Size = new System.Drawing.Size(360, 55);
            this.guna2GradientPanel5.TabIndex = 141;
            // 
            // guna2DateTimePicker3
            // 
            this.guna2DateTimePicker3.BackColor = System.Drawing.Color.Transparent;
            this.guna2DateTimePicker3.BorderRadius = 10;
            this.guna2DateTimePicker3.BorderThickness = 1;
            this.guna2DateTimePicker3.Checked = true;
            this.guna2DateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.guna2DateTimePicker3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2DateTimePicker3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.guna2DateTimePicker3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(86)))), ((int)(((byte)(71)))));
            this.guna2DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker3.Location = new System.Drawing.Point(144, 6);
            this.guna2DateTimePicker3.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker3.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker3.Name = "guna2DateTimePicker3";
            this.guna2DateTimePicker3.ShadowDecoration.BorderRadius = 10;
            this.guna2DateTimePicker3.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.guna2DateTimePicker3.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.guna2DateTimePicker3.ShadowDecoration.Depth = 60;
            this.guna2DateTimePicker3.ShadowDecoration.Enabled = true;
            this.guna2DateTimePicker3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2DateTimePicker3.Size = new System.Drawing.Size(177, 40);
            this.guna2DateTimePicker3.TabIndex = 139;
            this.guna2DateTimePicker3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2DateTimePicker3.Value = new System.DateTime(2025, 4, 7, 0, 0, 0, 0);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(10, 14);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(116, 25);
            this.guna2HtmlLabel4.TabIndex = 46;
            this.guna2HtmlLabel4.Text = "Ngày Kết Thúc";
            // 
            // guna2GradientPanel6
            // 
            this.guna2GradientPanel6.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel6.BorderRadius = 10;
            this.guna2GradientPanel6.BorderThickness = 1;
            this.guna2GradientPanel6.Controls.Add(this.guna2HtmlLabel6);
            this.guna2GradientPanel6.Controls.Add(this.guna2HtmlLabel5);
            this.guna2GradientPanel6.Controls.Add(this.GiaThue);
            this.guna2GradientPanel6.Location = new System.Drawing.Point(36, 333);
            this.guna2GradientPanel6.Name = "guna2GradientPanel6";
            this.guna2GradientPanel6.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel6.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel6.Size = new System.Drawing.Size(731, 55);
            this.guna2GradientPanel6.TabIndex = 142;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.Green;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(578, 18);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(33, 22);
            this.guna2HtmlLabel6.TabIndex = 47;
            this.guna2HtmlLabel6.Text = "VnĐ";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(49, 13);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(171, 25);
            this.guna2HtmlLabel5.TabIndex = 46;
            this.guna2HtmlLabel5.Text = "Giá Thuê Hàng Tháng";
            // 
            // guna2GradientPanel7
            // 
            this.guna2GradientPanel7.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel7.BorderRadius = 10;
            this.guna2GradientPanel7.BorderThickness = 1;
            this.guna2GradientPanel7.Controls.Add(this.guna2HtmlLabel7);
            this.guna2GradientPanel7.Controls.Add(this.guna2HtmlLabel11);
            this.guna2GradientPanel7.Controls.Add(this.TienDatCoc);
            this.guna2GradientPanel7.Location = new System.Drawing.Point(406, 402);
            this.guna2GradientPanel7.Name = "guna2GradientPanel7";
            this.guna2GradientPanel7.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel7.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel7.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel7.Size = new System.Drawing.Size(360, 55);
            this.guna2GradientPanel7.TabIndex = 144;
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(10, 14);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(101, 25);
            this.guna2HtmlLabel11.TabIndex = 46;
            this.guna2HtmlLabel11.Text = "Tiền Đặt Cọc";
            // 
            // guna2GradientPanel8
            // 
            this.guna2GradientPanel8.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel8.BorderRadius = 10;
            this.guna2GradientPanel8.BorderThickness = 1;
            this.guna2GradientPanel8.Controls.Add(this.guna2HtmlLabel12);
            this.guna2GradientPanel8.Controls.Add(this.LichThanhToan);
            this.guna2GradientPanel8.Location = new System.Drawing.Point(35, 402);
            this.guna2GradientPanel8.Name = "guna2GradientPanel8";
            this.guna2GradientPanel8.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel8.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel8.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel8.Size = new System.Drawing.Size(360, 55);
            this.guna2GradientPanel8.TabIndex = 143;
            // 
            // guna2HtmlLabel12
            // 
            this.guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel12.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel12.Location = new System.Drawing.Point(10, 14);
            this.guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            this.guna2HtmlLabel12.Size = new System.Drawing.Size(123, 25);
            this.guna2HtmlLabel12.TabIndex = 46;
            this.guna2HtmlLabel12.Text = "Lịch thanh toán";
            // 
            // guna2GradientPanel9
            // 
            this.guna2GradientPanel9.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel9.BorderRadius = 10;
            this.guna2GradientPanel9.BorderThickness = 1;
            this.guna2GradientPanel9.Controls.Add(this.guna2HtmlLabel8);
            this.guna2GradientPanel9.Controls.Add(this.GhiChu);
            this.guna2GradientPanel9.Location = new System.Drawing.Point(35, 476);
            this.guna2GradientPanel9.Name = "guna2GradientPanel9";
            this.guna2GradientPanel9.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel9.ShadowDecoration.Depth = 60;
            this.guna2GradientPanel9.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel9.Size = new System.Drawing.Size(731, 131);
            this.guna2GradientPanel9.TabIndex = 143;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(11, 45);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(62, 25);
            this.guna2HtmlLabel8.TabIndex = 46;
            this.guna2HtmlLabel8.Text = "Ghi chú";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.BorderColor = System.Drawing.Color.Transparent;
            this.saveButton.BorderRadius = 10;
            this.saveButton.BorderThickness = 1;
            this.saveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.saveButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.saveButton.Location = new System.Drawing.Point(314, 628);
            this.saveButton.Name = "saveButton";
            this.saveButton.ShadowDecoration.BorderRadius = 15;
            this.saveButton.ShadowDecoration.Depth = 50;
            this.saveButton.ShadowDecoration.Enabled = true;
            this.saveButton.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.saveButton.Size = new System.Drawing.Size(180, 50);
            this.saveButton.TabIndex = 145;
            this.saveButton.Text = "Lưu dữ liệu";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.Green;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(312, 17);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(33, 22);
            this.guna2HtmlLabel7.TabIndex = 48;
            this.guna2HtmlLabel7.Text = "VnĐ";
            // 
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
            // Form_AddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
            this.ClientSize = new System.Drawing.Size(654, 651);
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
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.GhiChu);
            this.Controls.Add(this.TienDatCoc);
            this.Controls.Add(this.LichThanhToan);
            this.Controls.Add(this.GiaThue);
            this.Controls.Add(this.guna2DateTimePicker3);
            this.Controls.Add(this.guna2DateTimePicker2);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.TenKhachHang);
            this.Controls.Add(this.DiaChiToaNha);
            this.Controls.Add(this.panel3);
=======
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.guna2GradientPanel9);
            this.Controls.Add(this.guna2GradientPanel7);
            this.Controls.Add(this.guna2GradientPanel8);
            this.Controls.Add(this.guna2GradientPanel6);
            this.Controls.Add(this.guna2GradientPanel5);
            this.Controls.Add(this.guna2GradientPanel4);
            this.Controls.Add(this.guna2GradientPanel3);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2CustomGradientPanel28);
            this.Controls.Add(this.guna2GradientPanel12);
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AddContract";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_AddContract_Load);
            this.guna2GradientPanel12.ResumeLayout(false);
            this.guna2GradientPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            this.guna2CustomGradientPanel28.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.guna2GradientPanel4.ResumeLayout(false);
            this.guna2GradientPanel4.PerformLayout();
            this.guna2GradientPanel5.ResumeLayout(false);
            this.guna2GradientPanel5.PerformLayout();
            this.guna2GradientPanel6.ResumeLayout(false);
            this.guna2GradientPanel6.PerformLayout();
            this.guna2GradientPanel7.ResumeLayout(false);
            this.guna2GradientPanel7.PerformLayout();
            this.guna2GradientPanel8.ResumeLayout(false);
            this.guna2GradientPanel8.PerformLayout();
            this.guna2GradientPanel9.ResumeLayout(false);
            this.guna2GradientPanel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2ComboBox DiaChiToaNha;
        private Guna.UI2.WinForms.Guna2ComboBox TenKhachHang;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker3;
=======
        private Guna.UI2.WinForms.Guna2ComboBox ListTenantID;
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
        private Guna.UI2.WinForms.Guna2TextBox GiaThue;
        private Guna.UI2.WinForms.Guna2ComboBox LichThanhToan;
        private Guna.UI2.WinForms.Guna2TextBox TienDatCoc;
        private Guna.UI2.WinForms.Guna2TextBox GhiChu;
<<<<<<< Updated upstream:GUI/Form_AddContract.Designer.cs
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
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
=======
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox SoPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel12;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel28;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel5;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel12;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2GradientButton saveButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
>>>>>>> Stashed changes:GUI/honhathao/Form_AddContract.Designer.cs
    }
}