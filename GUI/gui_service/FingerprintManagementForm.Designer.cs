// GUI.gui_service/FingerprintManagementForm.Designer.cs
namespace GUI.gui_service
{
    partial class FingerprintManagementForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.dgvFingerprints = new System.Windows.Forms.DataGridView();
            this.panelEnroll = new System.Windows.Forms.Panel();
            this.lblImageStatus = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdateImage = new Guna.UI2.WinForms.Guna2Button();
            this.btnSelectImage = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBoxFingerprint = new System.Windows.Forms.PictureBox();
            this.btnTestFingerprint = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdatePermission = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEnroll = new Guna.UI2.WinForms.Guna2Button();
            this.labelAreaPermission = new System.Windows.Forms.Label();
            this.checkedListAreas = new System.Windows.Forms.CheckedListBox();
            this.lblSelectedTenant = new System.Windows.Forms.Label();
            this.labelSelectTenant = new System.Windows.Forms.Label();
            this.cboTenants = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelRegister = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFingerprints)).BeginInit();
            this.panelEnroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 65);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ VÂN TAY";
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
            this.btnBack.FillColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnBack.Image = global::GUI.Properties.Resources.icons8_back_50;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.Location = new System.Drawing.Point(1216, 7);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.BorderRadius = 10;
            this.btnBack.ShadowDecoration.Enabled = true;
            this.btnBack.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(113, 45);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvFingerprints
            // 
            this.dgvFingerprints.AllowUserToAddRows = false;
            this.dgvFingerprints.AllowUserToDeleteRows = false;
            this.dgvFingerprints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFingerprints.BackgroundColor = System.Drawing.Color.White;
            this.dgvFingerprints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFingerprints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFingerprints.Location = new System.Drawing.Point(21, 112);
            this.dgvFingerprints.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFingerprints.MultiSelect = false;
            this.dgvFingerprints.Name = "dgvFingerprints";
            this.dgvFingerprints.ReadOnly = true;
            this.dgvFingerprints.RowHeadersWidth = 51;
            this.dgvFingerprints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFingerprints.Size = new System.Drawing.Size(867, 663);
            this.dgvFingerprints.TabIndex = 1;
            this.dgvFingerprints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFingerprints_CellContentClick);
            this.dgvFingerprints.SelectionChanged += new System.EventHandler(this.dgvFingerprints_SelectionChanged);
            // 
            // panelEnroll
            // 
            this.panelEnroll.BackColor = System.Drawing.Color.White;
            this.panelEnroll.Controls.Add(this.lblImageStatus);
            this.panelEnroll.Controls.Add(this.guna2Button2);
            this.panelEnroll.Controls.Add(this.guna2Button1);
            this.panelEnroll.Controls.Add(this.btnUpdateImage);
            this.panelEnroll.Controls.Add(this.btnSelectImage);
            this.panelEnroll.Controls.Add(this.pictureBoxFingerprint);
            this.panelEnroll.Controls.Add(this.btnTestFingerprint);
            this.panelEnroll.Controls.Add(this.btnUpdatePermission);
            this.panelEnroll.Controls.Add(this.btnDelete);
            this.panelEnroll.Controls.Add(this.btnEnroll);
            this.panelEnroll.Controls.Add(this.labelAreaPermission);
            this.panelEnroll.Controls.Add(this.checkedListAreas);
            this.panelEnroll.Controls.Add(this.lblSelectedTenant);
            this.panelEnroll.Controls.Add(this.labelSelectTenant);
            this.panelEnroll.Controls.Add(this.cboTenants);
            this.panelEnroll.Controls.Add(this.labelRegister);
            this.panelEnroll.Location = new System.Drawing.Point(907, 98);
            this.panelEnroll.Margin = new System.Windows.Forms.Padding(4);
            this.panelEnroll.Name = "panelEnroll";
            this.panelEnroll.Size = new System.Drawing.Size(411, 677);
            this.panelEnroll.TabIndex = 2;
            // 
            // lblImageStatus
            // 
            this.lblImageStatus.AutoSize = true;
            this.lblImageStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblImageStatus.Location = new System.Drawing.Point(19, 406);
            this.lblImageStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageStatus.Name = "lblImageStatus";
            this.lblImageStatus.Size = new System.Drawing.Size(108, 18);
            this.lblImageStatus.TabIndex = 14;
            this.lblImageStatus.Text = "Chưa chọn ảnh";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.CadetBlue;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(208, 433);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.BorderRadius = 10;
            this.guna2Button2.ShadowDecoration.Enabled = true;
            this.guna2Button2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2Button2.Size = new System.Drawing.Size(180, 44);
            this.guna2Button2.TabIndex = 13;
            this.guna2Button2.Text = "Cập nhật ảnh";
            this.guna2Button2.Click += new System.EventHandler(this.btnUpdateImage_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.MediumTurquoise;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(23, 433);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.BorderRadius = 10;
            this.guna2Button1.ShadowDecoration.Enabled = true;
            this.guna2Button1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2Button1.Size = new System.Drawing.Size(177, 44);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "Chọn ảnh";
            this.guna2Button1.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnUpdateImage
            // 
            this.btnUpdateImage.BorderRadius = 5;
            this.btnUpdateImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdateImage.FillColor = System.Drawing.Color.CadetBlue;
            this.btnUpdateImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateImage.ForeColor = System.Drawing.Color.White;
            this.btnUpdateImage.Location = new System.Drawing.Point(208, 433);
            this.btnUpdateImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateImage.Name = "btnUpdateImage";
            this.btnUpdateImage.Size = new System.Drawing.Size(180, 44);
            this.btnUpdateImage.TabIndex = 13;
            this.btnUpdateImage.Text = "Cập nhật ảnh";
            this.btnUpdateImage.Click += new System.EventHandler(this.btnUpdateImage_Click);
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BorderRadius = 5;
            this.btnSelectImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelectImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelectImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnSelectImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectImage.ForeColor = System.Drawing.Color.White;
            this.btnSelectImage.Location = new System.Drawing.Point(23, 433);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(177, 44);
            this.btnSelectImage.TabIndex = 12;
            this.btnSelectImage.Text = "Chọn ảnh";
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // pictureBoxFingerprint
            // 
            this.pictureBoxFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFingerprint.Location = new System.Drawing.Point(23, 329);
            this.pictureBoxFingerprint.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxFingerprint.Name = "pictureBoxFingerprint";
            this.pictureBoxFingerprint.Size = new System.Drawing.Size(365, 73);
            this.pictureBoxFingerprint.TabIndex = 11;
            this.pictureBoxFingerprint.TabStop = false;
            // 
            // btnTestFingerprint
            // 
            this.btnTestFingerprint.BackColor = System.Drawing.Color.Transparent;
            this.btnTestFingerprint.BorderColor = System.Drawing.Color.Silver;
            this.btnTestFingerprint.BorderRadius = 5;
            this.btnTestFingerprint.BorderThickness = 1;
            this.btnTestFingerprint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTestFingerprint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTestFingerprint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTestFingerprint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTestFingerprint.FillColor = System.Drawing.Color.Maroon;
            this.btnTestFingerprint.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestFingerprint.ForeColor = System.Drawing.Color.White;
            this.btnTestFingerprint.Location = new System.Drawing.Point(23, 566);
            this.btnTestFingerprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestFingerprint.Name = "btnTestFingerprint";
            this.btnTestFingerprint.ShadowDecoration.BorderRadius = 10;
            this.btnTestFingerprint.ShadowDecoration.Enabled = true;
            this.btnTestFingerprint.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnTestFingerprint.Size = new System.Drawing.Size(365, 55);
            this.btnTestFingerprint.TabIndex = 9;
            this.btnTestFingerprint.Text = "Kiểm tra vân tay";
            this.btnTestFingerprint.Click += new System.EventHandler(this.btnTestFingerprint_Click);
            // 
            // btnUpdatePermission
            // 
            this.btnUpdatePermission.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdatePermission.BorderColor = System.Drawing.Color.Silver;
            this.btnUpdatePermission.BorderRadius = 5;
            this.btnUpdatePermission.BorderThickness = 1;
            this.btnUpdatePermission.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdatePermission.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdatePermission.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdatePermission.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdatePermission.FillColor = System.Drawing.Color.MediumTurquoise;
            this.btnUpdatePermission.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePermission.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePermission.Location = new System.Drawing.Point(208, 485);
            this.btnUpdatePermission.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdatePermission.Name = "btnUpdatePermission";
            this.btnUpdatePermission.ShadowDecoration.BorderRadius = 10;
            this.btnUpdatePermission.ShadowDecoration.Enabled = true;
            this.btnUpdatePermission.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnUpdatePermission.Size = new System.Drawing.Size(180, 55);
            this.btnUpdatePermission.TabIndex = 8;
            this.btnUpdatePermission.Text = "Cập nhật quyền";
            this.btnUpdatePermission.Click += new System.EventHandler(this.btnUpdatePermission_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderColor = System.Drawing.Color.Silver;
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.BorderThickness = 1;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.DeepPink;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(23, 485);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.BorderRadius = 10;
            this.btnDelete.ShadowDecoration.Enabled = true;
            this.btnDelete.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnDelete.Size = new System.Drawing.Size(177, 55);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa vân tay";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.Transparent;
            this.btnEnroll.BorderColor = System.Drawing.Color.Silver;
            this.btnEnroll.BorderRadius = 5;
            this.btnEnroll.BorderThickness = 1;
            this.btnEnroll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnroll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnroll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnroll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(166)))), ((int)(((byte)(17)))));
            this.btnEnroll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.Location = new System.Drawing.Point(23, 110);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.ShadowDecoration.BorderRadius = 10;
            this.btnEnroll.ShadowDecoration.Enabled = true;
            this.btnEnroll.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnEnroll.Size = new System.Drawing.Size(365, 44);
            this.btnEnroll.TabIndex = 6;
            this.btnEnroll.Text = "Đăng ký vân tay mới";
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // labelAreaPermission
            // 
            this.labelAreaPermission.AutoSize = true;
            this.labelAreaPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAreaPermission.Location = new System.Drawing.Point(19, 169);
            this.labelAreaPermission.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAreaPermission.Name = "labelAreaPermission";
            this.labelAreaPermission.Size = new System.Drawing.Size(153, 18);
            this.labelAreaPermission.TabIndex = 5;
            this.labelAreaPermission.Text = "Quyền truy cập khu";
            // 
            // checkedListAreas
            // 
            this.checkedListAreas.FormattingEnabled = true;
            this.checkedListAreas.Location = new System.Drawing.Point(23, 191);
            this.checkedListAreas.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListAreas.Name = "checkedListAreas";
            this.checkedListAreas.Size = new System.Drawing.Size(364, 106);
            this.checkedListAreas.TabIndex = 4;
            // 
            // lblSelectedTenant
            // 
            this.lblSelectedTenant.AutoSize = true;
            this.lblSelectedTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTenant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblSelectedTenant.Location = new System.Drawing.Point(19, 310);
            this.lblSelectedTenant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedTenant.Name = "lblSelectedTenant";
            this.lblSelectedTenant.Size = new System.Drawing.Size(126, 18);
            this.lblSelectedTenant.TabIndex = 3;
            this.lblSelectedTenant.Text = "Chưa chọn dữ liệu";
            // 
            // labelSelectTenant
            // 
            this.labelSelectTenant.AutoSize = true;
            this.labelSelectTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTenant.Location = new System.Drawing.Point(19, 52);
            this.labelSelectTenant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectTenant.Name = "labelSelectTenant";
            this.labelSelectTenant.Size = new System.Drawing.Size(124, 18);
            this.labelSelectTenant.TabIndex = 2;
            this.labelSelectTenant.Text = "Chọn khách trọ";
            // 
            // cboTenants
            // 
            this.cboTenants.BackColor = System.Drawing.Color.Transparent;
            this.cboTenants.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTenants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenants.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenants.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenants.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTenants.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTenants.ItemHeight = 30;
            this.cboTenants.Location = new System.Drawing.Point(23, 74);
            this.cboTenants.Margin = new System.Windows.Forms.Padding(4);
            this.cboTenants.Name = "cboTenants";
            this.cboTenants.Size = new System.Drawing.Size(364, 36);
            this.cboTenants.TabIndex = 1;
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.labelRegister.Location = new System.Drawing.Point(17, 14);
            this.labelRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(208, 25);
            this.labelRegister.TabIndex = 0;
            this.labelRegister.Text = "ĐĂNG KÝ VÂN TAY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "DANH SÁCH VÂN TAY";
            // 
            // FingerprintManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1333, 800);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelEnroll);
            this.Controls.Add(this.dgvFingerprints);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FingerprintManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý vân tay";
            this.Load += new System.EventHandler(this.FingerprintManagementForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFingerprints)).EndInit();
            this.panelEnroll.ResumeLayout(false);
            this.panelEnroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.DataGridView dgvFingerprints;
        private System.Windows.Forms.Panel panelEnroll;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Label labelSelectTenant;
        private Guna.UI2.WinForms.Guna2ComboBox cboTenants;
        private System.Windows.Forms.Label lblSelectedTenant;
        private System.Windows.Forms.CheckedListBox checkedListAreas;
        private System.Windows.Forms.Label labelAreaPermission;
        private Guna.UI2.WinForms.Guna2Button btnEnroll;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnUpdatePermission;
        private Guna.UI2.WinForms.Guna2Button btnTestFingerprint;
        private System.Windows.Forms.PictureBox pictureBoxFingerprint;
        private Guna.UI2.WinForms.Guna2Button btnSelectImage;
        private Guna.UI2.WinForms.Guna2Button btnUpdateImage;
        private System.Windows.Forms.Label lblImageStatus;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}