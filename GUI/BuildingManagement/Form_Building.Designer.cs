using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace GUI.BuildingManagement
{
    partial class Form_Building
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Component declarations
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnManage;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Panel panelAddBuilding;
        private Guna.UI2.WinForms.Guna2TextBox txtBuildingKey;
        private Guna.UI2.WinForms.Guna2TextBox txtBuildingName;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2NumericUpDown numFloors;
        private Guna.UI2.WinForms.Guna2NumericUpDown numRooms;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBuildings;
        private Guna.UI2.WinForms.Guna2TabControl tabControl;
        private System.Windows.Forms.TabPage tabManageBuilding;
        private System.Windows.Forms.TabPage tabAddBuilding;
        private System.Windows.Forms.Label lblBuildingKey;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFloors;
        private System.Windows.Forms.Label lblNumRooms;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnManage = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.panelAddBuilding = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBuildingKey = new System.Windows.Forms.Label();
            this.txtBuildingKey = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFloors = new System.Windows.Forms.Label();
            this.numFloors = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblNumRooms = new System.Windows.Forms.Label();
            this.numRooms = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBuildings = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabManageBuilding = new System.Windows.Forms.TabPage();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.tabAddBuilding = new System.Windows.Forms.TabPage();
            this.guna2Panel1.SuspendLayout();
            this.panelAddBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuildings)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabManageBuilding.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.tabAddBuilding.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.guna2Panel1.Controls.Add(this.guna2Button2);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.btnBack);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1200, 60);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(1150, 12);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(40, 36);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Text = "X";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1102, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(40, 36);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "_";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderRadius = 10;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 36);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.OnBackClick);
            // 
            // btnManage
            // 
            this.btnManage.BorderRadius = 8;
            this.btnManage.Enabled = false;
            this.btnManage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManage.ForeColor = System.Drawing.Color.White;
            this.btnManage.Location = new System.Drawing.Point(450, 12);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(120, 36);
            this.btnManage.TabIndex = 2;
            this.btnManage.Text = "Quản lý";
            this.btnManage.Click += new System.EventHandler(this.OnManageClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(10, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm tòa nhà...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(320, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.OnRefreshClick);
            // 
            // panelAddBuilding
            // 
            this.panelAddBuilding.BackColor = System.Drawing.Color.White;
            this.panelAddBuilding.Controls.Add(this.lblBuildingKey);
            this.panelAddBuilding.Controls.Add(this.txtBuildingKey);
            this.panelAddBuilding.Controls.Add(this.lblAddress);
            this.panelAddBuilding.Controls.Add(this.txtAddress);
            this.panelAddBuilding.Controls.Add(this.lblFloors);
            this.panelAddBuilding.Controls.Add(this.numFloors);
            this.panelAddBuilding.Controls.Add(this.lblNumRooms);
            this.panelAddBuilding.Controls.Add(this.numRooms);
            this.panelAddBuilding.Controls.Add(this.buttonPanel);
            this.panelAddBuilding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddBuilding.Location = new System.Drawing.Point(10, 10);
            this.panelAddBuilding.Name = "panelAddBuilding";
            this.panelAddBuilding.Padding = new System.Windows.Forms.Padding(20);
            this.panelAddBuilding.Size = new System.Drawing.Size(992, 712);
            this.panelAddBuilding.TabIndex = 0;
            // 
            // lblBuildingKey
            // 
            this.lblBuildingKey.AutoSize = true;
            this.lblBuildingKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuildingKey.Location = new System.Drawing.Point(30, 30);
            this.lblBuildingKey.Name = "lblBuildingKey";
            this.lblBuildingKey.Size = new System.Drawing.Size(108, 23);
            this.lblBuildingKey.TabIndex = 0;
            this.lblBuildingKey.Text = "Building Key:";
            // 
            // txtBuildingKey
            // 
            this.txtBuildingKey.BorderRadius = 5;
            this.txtBuildingKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuildingKey.DefaultText = "";
            this.txtBuildingKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuildingKey.Location = new System.Drawing.Point(190, 30);
            this.txtBuildingKey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBuildingKey.Name = "txtBuildingKey";
            this.txtBuildingKey.PlaceholderText = "";
            this.txtBuildingKey.SelectedText = "";
            this.txtBuildingKey.Size = new System.Drawing.Size(300, 36);
            this.txtBuildingKey.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(30, 86);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(74, 23);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(190, 86);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(300, 36);
            this.txtAddress.TabIndex = 5;
            // 
            // lblFloors
            // 
            this.lblFloors.AutoSize = true;
            this.lblFloors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFloors.Location = new System.Drawing.Point(30, 142);
            this.lblFloors.Name = "lblFloors";
            this.lblFloors.Size = new System.Drawing.Size(147, 23);
            this.lblFloors.TabIndex = 6;
            this.lblFloors.Text = "Number of Floors:";
            // 
            // numFloors
            // 
            this.numFloors.BackColor = System.Drawing.Color.Transparent;
            this.numFloors.BorderRadius = 5;
            this.numFloors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numFloors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFloors.Location = new System.Drawing.Point(190, 142);
            this.numFloors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numFloors.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numFloors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFloors.Name = "numFloors";
            this.numFloors.Size = new System.Drawing.Size(300, 36);
            this.numFloors.TabIndex = 7;
            this.numFloors.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumRooms
            // 
            this.lblNumRooms.AutoSize = true;
            this.lblNumRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNumRooms.Location = new System.Drawing.Point(30, 199);
            this.lblNumRooms.Name = "lblNumRooms";
            this.lblNumRooms.Size = new System.Drawing.Size(154, 23);
            this.lblNumRooms.TabIndex = 8;
            this.lblNumRooms.Text = "Number of Rooms:";
            // 
            // numRooms
            // 
            this.numRooms.BackColor = System.Drawing.Color.Transparent;
            this.numRooms.BorderRadius = 5;
            this.numRooms.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numRooms.Location = new System.Drawing.Point(190, 199);
            this.numRooms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numRooms.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numRooms.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(300, 36);
            this.numRooms.TabIndex = 9;
            this.numRooms.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.btnSave);
            this.buttonPanel.Controls.Add(this.btnCancel);
            this.buttonPanel.Location = new System.Drawing.Point(30, 255);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(460, 50);
            this.buttonPanel.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(210, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(340, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // dgvBuildings
            // 
            this.dgvBuildings.AllowUserToAddRows = false;
            this.dgvBuildings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuildings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBuildings.ColumnHeadersHeight = 40;
            this.dgvBuildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuildings.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBuildings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBuildings.Location = new System.Drawing.Point(10, 80);
            this.dgvBuildings.Name = "dgvBuildings";
            this.dgvBuildings.ReadOnly = true;
            this.dgvBuildings.RowHeadersVisible = false;
            this.dgvBuildings.RowHeadersWidth = 51;
            this.dgvBuildings.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBuildings.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBuildings.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBuildings.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBuildings.RowTemplate.Height = 35;
            this.dgvBuildings.Size = new System.Drawing.Size(992, 642);
            this.dgvBuildings.TabIndex = 1;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBuildings.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBuildings.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.dgvBuildings.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBuildings.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvBuildings.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBuildings.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvBuildings.ThemeStyle.ReadOnly = true;
            this.dgvBuildings.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBuildings.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBuildings.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBuildings.ThemeStyle.RowsStyle.Height = 35;
            this.dgvBuildings.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBuildings.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBuildings.SelectionChanged += new System.EventHandler(this.OnBuildingSelectionChanged);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabManageBuilding);
            this.tabControl.Controls.Add(this.tabAddBuilding);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 740);
            this.tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.tabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
            // 
            // tabManageBuilding
            // 
            this.tabManageBuilding.BackColor = System.Drawing.Color.White;
            this.tabManageBuilding.Controls.Add(this.searchPanel);
            this.tabManageBuilding.Controls.Add(this.dgvBuildings);
            this.tabManageBuilding.Location = new System.Drawing.Point(184, 4);
            this.tabManageBuilding.Name = "tabManageBuilding";
            this.tabManageBuilding.Padding = new System.Windows.Forms.Padding(10);
            this.tabManageBuilding.Size = new System.Drawing.Size(1012, 732);
            this.tabManageBuilding.TabIndex = 0;
            this.tabManageBuilding.Text = "Quản lý tòa nhà";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.btnManage);
            this.searchPanel.Controls.Add(this.btnRefresh);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(10, 10);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(992, 60);
            this.searchPanel.TabIndex = 0;
            // 
            // tabAddBuilding
            // 
            this.tabAddBuilding.BackColor = System.Drawing.Color.White;
            this.tabAddBuilding.Controls.Add(this.panelAddBuilding);
            this.tabAddBuilding.Location = new System.Drawing.Point(184, 4);
            this.tabAddBuilding.Name = "tabAddBuilding";
            this.tabAddBuilding.Padding = new System.Windows.Forms.Padding(10);
            this.tabAddBuilding.Size = new System.Drawing.Size(1012, 732);
            this.tabAddBuilding.TabIndex = 1;
            this.tabAddBuilding.Text = "Thêm tòa nhà";
            // 
            // Form_Building
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Building";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.guna2Panel1.ResumeLayout(false);
            this.panelAddBuilding.ResumeLayout(false);
            this.panelAddBuilding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuildings)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabManageBuilding.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.tabAddBuilding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}