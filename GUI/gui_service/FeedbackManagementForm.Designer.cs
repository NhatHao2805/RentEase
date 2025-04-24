namespace GUI
{
    partial class FeedbackManagementForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackManagementForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnResetFilter = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnFilter = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSync = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvFeedbacks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnExport = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2GradientPanel12 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CustomGradientPanel18 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).BeginInit();
            this.guna2GradientPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnResetFilter);
            this.panel2.Controls.Add(this.btnFilter);
            this.panel2.Controls.Add(this.dtpToDate);
            this.panel2.Controls.Add(this.dtpFromDate);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSync);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 123);
            this.panel2.TabIndex = 1;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnResetFilter.BorderColor = System.Drawing.Color.Transparent;
            this.btnResetFilter.BorderRadius = 10;
            this.btnResetFilter.BorderThickness = 1;
            this.btnResetFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetFilter.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetFilter.FillColor = System.Drawing.Color.LightSlateGray;
            this.btnResetFilter.FillColor2 = System.Drawing.Color.DarkSlateGray;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnResetFilter.ForeColor = System.Drawing.Color.White;
            this.btnResetFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnResetFilter.Location = new System.Drawing.Point(664, 70);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.ShadowDecoration.BorderRadius = 15;
            this.btnResetFilter.ShadowDecoration.Depth = 50;
            this.btnResetFilter.ShadowDecoration.Enabled = true;
            this.btnResetFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnResetFilter.Size = new System.Drawing.Size(116, 40);
            this.btnResetFilter.TabIndex = 145;
            this.btnResetFilter.Text = "Làm mới";
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.BorderColor = System.Drawing.Color.Transparent;
            this.btnFilter.BorderRadius = 10;
            this.btnFilter.BorderThickness = 1;
            this.btnFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilter.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilter.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnFilter.FillColor2 = System.Drawing.Color.Teal;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFilter.Location = new System.Drawing.Point(542, 70);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.ShadowDecoration.BorderRadius = 15;
            this.btnFilter.ShadowDecoration.Depth = 50;
            this.btnFilter.ShadowDecoration.Enabled = true;
            this.btnFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnFilter.Size = new System.Drawing.Size(116, 40);
            this.btnFilter.TabIndex = 144;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpToDate.BorderRadius = 10;
            this.dtpToDate.BorderThickness = 1;
            this.dtpToDate.Checked = true;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dtpToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(86)))), ((int)(((byte)(71)))));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(376, 75);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShadowDecoration.BorderRadius = 10;
            this.dtpToDate.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.dtpToDate.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.dtpToDate.ShadowDecoration.Enabled = true;
            this.dtpToDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.dtpToDate.Size = new System.Drawing.Size(149, 30);
            this.dtpToDate.TabIndex = 145;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.Value = new System.DateTime(2025, 4, 13, 11, 51, 0, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpFromDate.BorderRadius = 10;
            this.dtpFromDate.BorderThickness = 1;
            this.dtpFromDate.Checked = true;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dtpFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(86)))), ((int)(((byte)(71)))));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(110, 75);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShadowDecoration.BorderRadius = 10;
            this.dtpFromDate.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.dtpFromDate.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.dtpFromDate.ShadowDecoration.Enabled = true;
            this.dtpFromDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.dtpFromDate.Size = new System.Drawing.Size(149, 30);
            this.dtpFromDate.TabIndex = 144;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.Value = new System.DateTime(2025, 4, 13, 11, 51, 0, 0);
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cboStatus.BorderRadius = 10;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboStatus.ItemHeight = 30;
            this.cboStatus.Location = new System.Drawing.Point(547, 9);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.ShadowDecoration.BorderRadius = 10;
            this.cboStatus.ShadowDecoration.Enabled = true;
            this.cboStatus.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.cboStatus.Size = new System.Drawing.Size(160, 36);
            this.cboStatus.TabIndex = 126;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(110, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 10;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.Teal;
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtSearch.Size = new System.Drawing.Size(250, 35);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.Transparent;
            this.btnSync.BorderColor = System.Drawing.Color.Transparent;
            this.btnSync.BorderRadius = 10;
            this.btnSync.BorderThickness = 1;
            this.btnSync.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSync.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSync.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSync.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSync.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSync.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(49)))), ((int)(((byte)(193)))));
            this.btnSync.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(19)))), ((int)(((byte)(94)))));
            this.btnSync.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSync.ForeColor = System.Drawing.Color.White;
            this.btnSync.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSync.Location = new System.Drawing.Point(785, 6);
            this.btnSync.Name = "btnSync";
            this.btnSync.ShadowDecoration.BorderRadius = 15;
            this.btnSync.ShadowDecoration.Depth = 50;
            this.btnSync.ShadowDecoration.Enabled = true;
            this.btnSync.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnSync.Size = new System.Drawing.Size(250, 50);
            this.btnSync.TabIndex = 144;
            this.btnSync.Text = "Đồng bộ dữ liệu từ Google Form";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(795, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 44);
            this.label6.TabIndex = 11;
            this.label6.Text = "Click đúp vào một dòng để xem chi tiết nội dung phản ánh";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(281, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(19, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Từ ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(432, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trạng thái:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm kiếm:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvFeedbacks);
            this.panel3.Location = new System.Drawing.Point(0, 191);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panel3.Size = new System.Drawing.Size(1044, 378);
            this.panel3.TabIndex = 2;
            // 
            // dgvFeedbacks
            // 
            this.dgvFeedbacks.AllowUserToAddRows = false;
            this.dgvFeedbacks.AllowUserToDeleteRows = false;
            this.dgvFeedbacks.AllowUserToResizeColumns = false;
            this.dgvFeedbacks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFeedbacks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFeedbacks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.dgvFeedbacks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFeedbacks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(101)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeedbacks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFeedbacks.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeedbacks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFeedbacks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.dgvFeedbacks.Location = new System.Drawing.Point(5, 1);
            this.dgvFeedbacks.Name = "dgvFeedbacks";
            this.dgvFeedbacks.ReadOnly = true;
            this.dgvFeedbacks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvFeedbacks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(242)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeedbacks.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFeedbacks.RowHeadersVisible = false;
            this.dgvFeedbacks.RowHeadersWidth = 100;
            this.dgvFeedbacks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFeedbacks.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFeedbacks.RowTemplate.Height = 24;
            this.dgvFeedbacks.Size = new System.Drawing.Size(1034, 375);
            this.dgvFeedbacks.TabIndex = 152;
            this.dgvFeedbacks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFeedbacks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvFeedbacks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvFeedbacks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.dgvFeedbacks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvFeedbacks.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.dgvFeedbacks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.dgvFeedbacks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvFeedbacks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFeedbacks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFeedbacks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFeedbacks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFeedbacks.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvFeedbacks.ThemeStyle.ReadOnly = true;
            this.dgvFeedbacks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFeedbacks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFeedbacks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFeedbacks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvFeedbacks.ThemeStyle.RowsStyle.Height = 24;
            this.dgvFeedbacks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvFeedbacks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvFeedbacks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFeedbacks_CellDoubleClick);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderRadius = 10;
            this.btnExport.BorderThickness = 1;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.btnExport.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExport.Location = new System.Drawing.Point(771, 576);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShadowDecoration.BorderRadius = 15;
            this.btnExport.ShadowDecoration.Depth = 50;
            this.btnExport.ShadowDecoration.Enabled = true;
            this.btnExport.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnExport.Size = new System.Drawing.Size(159, 50);
            this.btnExport.TabIndex = 143;
            this.btnExport.Text = "Xuất sang Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // guna2GradientPanel12
            // 
            this.guna2GradientPanel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel12.Controls.Add(this.exitButton);
            this.guna2GradientPanel12.Controls.Add(this.guna2PictureBox5);
            this.guna2GradientPanel12.Controls.Add(this.guna2CustomGradientPanel18);
            this.guna2GradientPanel12.Controls.Add(this.label22);
            this.guna2GradientPanel12.Controls.Add(this.label23);
            this.guna2GradientPanel12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(254)))), ((int)(((byte)(218)))));
            this.guna2GradientPanel12.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel12.Location = new System.Drawing.Point(4, 0);
            this.guna2GradientPanel12.Name = "guna2GradientPanel12";
            this.guna2GradientPanel12.Size = new System.Drawing.Size(1041, 70);
            this.guna2GradientPanel12.TabIndex = 144;
            // 
            // exitButton
            // 
            this.exitButton.BorderColor = System.Drawing.Color.DimGray;
            this.exitButton.BorderRadius = 1;
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitButton.Image = global::GUI.Properties.Resources.icon_2;
            this.exitButton.Location = new System.Drawing.Point(1005, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Image = global::GUI.Properties.Resources.icons8_feedback_50;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(15, 5);
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
            this.guna2CustomGradientPanel18.Location = new System.Drawing.Point(87, 8);
            this.guna2CustomGradientPanel18.Name = "guna2CustomGradientPanel18";
            this.guna2CustomGradientPanel18.Size = new System.Drawing.Size(7, 50);
            this.guna2CustomGradientPanel18.TabIndex = 125;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(95, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(268, 20);
            this.label22.TabIndex = 122;
            this.label22.Text = "Mọi phản ánh của khách hàng đều ở đây";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(93, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(394, 35);
            this.label23.TabIndex = 123;
            this.label23.Text = "Quản lý phản ánh khách hàng";
            // 
            // FeedbackManagementForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1042, 635);
            this.Controls.Add(this.guna2GradientPanel12);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FeedbackManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phản ánh khách hàng";
            this.Load += new System.EventHandler(this.FeedbackManagementForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).EndInit();
            this.guna2GradientPanel12.ResumeLayout(false);
            this.guna2GradientPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2GradientButton btnExport;
        private Guna.UI2.WinForms.Guna2GradientButton btnSync;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel12;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2GradientButton btnFilter;
        private Guna.UI2.WinForms.Guna2GradientButton btnResetFilter;
        private Guna.UI2.WinForms.Guna2DataGridView dgvFeedbacks;
    }
}