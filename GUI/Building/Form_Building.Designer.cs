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
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel panelAddBuilding;
        private Guna.UI2.WinForms.Guna2TextBox txtBuildingKey;
        private Guna.UI2.WinForms.Guna2TextBox txtBuildingName;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2NumericUpDown numFloors;
        private Guna.UI2.WinForms.Guna2NumericUpDown numRooms;
        private Guna.UI2.WinForms.Guna2TabControl tabControl;
        private System.Windows.Forms.TabPage tabManageBuilding;
        private System.Windows.Forms.TabPage tabAddBuilding;
        private System.Windows.Forms.Label lblBuildingKey;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFloors;
        private System.Windows.Forms.Label lblNumRooms;
        private System.Windows.Forms.Panel buttonPanel;

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
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabManageBuilding = new System.Windows.Forms.TabPage();
            this.dgvBuildings = new Guna.UI2.WinForms.Guna2DataGridView();
            this.searchPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnManage = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabAddBuilding = new System.Windows.Forms.TabPage();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2CustomGradientPanel18 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.panelMain = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btn_quanlynha = new Guna.UI2.WinForms.Guna2Button();
            this.btn_themnha = new Guna.UI2.WinForms.Guna2Button();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panelAddBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabManageBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuildings)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.tabAddBuilding.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
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
            this.txtSearch.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtSearch.Location = new System.Drawing.Point(16, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm tòa nhà...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // panelAddBuilding
            // 
            this.panelAddBuilding.BackColor = System.Drawing.Color.AliceBlue;
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
            this.panelAddBuilding.Size = new System.Drawing.Size(685, 422);
            this.panelAddBuilding.TabIndex = 0;
            // 
            // lblBuildingKey
            // 
            this.lblBuildingKey.AutoSize = true;
            this.lblBuildingKey.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildingKey.Location = new System.Drawing.Point(114, 30);
            this.lblBuildingKey.Name = "lblBuildingKey";
            this.lblBuildingKey.Size = new System.Drawing.Size(109, 23);
            this.lblBuildingKey.TabIndex = 0;
            this.lblBuildingKey.Text = "Building Key:";
            // 
            // txtBuildingKey
            // 
            this.txtBuildingKey.BackColor = System.Drawing.Color.Transparent;
            this.txtBuildingKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBuildingKey.BorderRadius = 10;
            this.txtBuildingKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuildingKey.DefaultText = "";
            this.txtBuildingKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuildingKey.Location = new System.Drawing.Point(274, 30);
            this.txtBuildingKey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBuildingKey.Name = "txtBuildingKey";
            this.txtBuildingKey.PlaceholderText = "";
            this.txtBuildingKey.SelectedText = "";
            this.txtBuildingKey.ShadowDecoration.BorderRadius = 10;
            this.txtBuildingKey.ShadowDecoration.Enabled = true;
            this.txtBuildingKey.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtBuildingKey.Size = new System.Drawing.Size(300, 36);
            this.txtBuildingKey.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(114, 86);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(74, 23);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAddress.BorderRadius = 10;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(274, 86);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.ShadowDecoration.BorderRadius = 10;
            this.txtAddress.ShadowDecoration.Enabled = true;
            this.txtAddress.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtAddress.Size = new System.Drawing.Size(300, 36);
            this.txtAddress.TabIndex = 5;
            // 
            // lblFloors
            // 
            this.lblFloors.AutoSize = true;
            this.lblFloors.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloors.Location = new System.Drawing.Point(114, 142);
            this.lblFloors.Name = "lblFloors";
            this.lblFloors.Size = new System.Drawing.Size(149, 23);
            this.lblFloors.TabIndex = 6;
            this.lblFloors.Text = "Number of Floors:";
            // 
            // numFloors
            // 
            this.numFloors.BackColor = System.Drawing.Color.Transparent;
            this.numFloors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numFloors.BorderRadius = 10;
            this.numFloors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numFloors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFloors.Location = new System.Drawing.Point(274, 142);
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
            this.numFloors.ShadowDecoration.BorderRadius = 10;
            this.numFloors.ShadowDecoration.Enabled = true;
            this.numFloors.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
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
            this.lblNumRooms.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRooms.Location = new System.Drawing.Point(114, 199);
            this.lblNumRooms.Name = "lblNumRooms";
            this.lblNumRooms.Size = new System.Drawing.Size(156, 23);
            this.lblNumRooms.TabIndex = 8;
            this.lblNumRooms.Text = "Number of Rooms:";
            // 
            // numRooms
            // 
            this.numRooms.BackColor = System.Drawing.Color.Transparent;
            this.numRooms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numRooms.BorderRadius = 10;
            this.numRooms.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numRooms.Location = new System.Drawing.Point(274, 199);
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
            this.numRooms.ShadowDecoration.BorderRadius = 10;
            this.numRooms.ShadowDecoration.Enabled = true;
            this.numRooms.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
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
            this.buttonPanel.Controls.Add(this.btnCancel);
            this.buttonPanel.Controls.Add(this.btnSave);
            this.buttonPanel.Location = new System.Drawing.Point(88, 255);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(541, 84);
            this.buttonPanel.TabIndex = 10;
            this.buttonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonPanel_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Teal;
            this.btnCancel.FillColor2 = System.Drawing.Color.SlateGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.Location = new System.Drawing.Point(386, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 15;
            this.btnCancel.ShadowDecoration.Depth = 50;
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.Location = new System.Drawing.Point(224, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.BorderRadius = 15;
            this.btnSave.ShadowDecoration.Depth = 50;
            this.btnSave.ShadowDecoration.Enabled = true;
            this.btnSave.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 141;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabManageBuilding);
            this.tabControl.Controls.Add(this.tabAddBuilding);
            this.tabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl.Location = new System.Drawing.Point(254, 71);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(713, 490);
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
            this.tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
            this.tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tabControl.TabMenuVisible = false;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
            // 
            // tabManageBuilding
            // 
            this.tabManageBuilding.BackColor = System.Drawing.Color.White;
            this.tabManageBuilding.Controls.Add(this.dgvBuildings);
            this.tabManageBuilding.Controls.Add(this.searchPanel);
            this.tabManageBuilding.Location = new System.Drawing.Point(4, 5);
            this.tabManageBuilding.Name = "tabManageBuilding";
            this.tabManageBuilding.Padding = new System.Windows.Forms.Padding(10);
            this.tabManageBuilding.Size = new System.Drawing.Size(705, 481);
            this.tabManageBuilding.TabIndex = 0;
            this.tabManageBuilding.Text = "Quản lý tòa nhà";
            // 
            // dgvBuildings
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBuildings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBuildings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.dgvBuildings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBuildings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(101)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuildings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBuildings.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuildings.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBuildings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.dgvBuildings.Location = new System.Drawing.Point(8, 78);
            this.dgvBuildings.Name = "dgvBuildings";
            this.dgvBuildings.ReadOnly = true;
            this.dgvBuildings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvBuildings.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(242)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuildings.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBuildings.RowHeadersVisible = false;
            this.dgvBuildings.RowHeadersWidth = 100;
            this.dgvBuildings.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBuildings.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBuildings.RowTemplate.Height = 24;
            this.dgvBuildings.Size = new System.Drawing.Size(692, 359);
            this.dgvBuildings.TabIndex = 151;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.dgvBuildings.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBuildings.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.dgvBuildings.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.dgvBuildings.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBuildings.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBuildings.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBuildings.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBuildings.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvBuildings.ThemeStyle.ReadOnly = true;
            this.dgvBuildings.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBuildings.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBuildings.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBuildings.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBuildings.ThemeStyle.RowsStyle.Height = 24;
            this.dgvBuildings.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBuildings.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBuildings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuildings_CellContentClick);
            this.dgvBuildings.SelectionChanged += new System.EventHandler(this.OnBuildingSelectionChanged);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.btnManage);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.btnRefresh);
            this.searchPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.searchPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.searchPanel.Location = new System.Drawing.Point(3, 13);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(702, 60);
            this.searchPanel.TabIndex = 141;
            // 
            // btnManage
            // 
            this.btnManage.BackColor = System.Drawing.Color.Transparent;
            this.btnManage.BorderColor = System.Drawing.Color.Transparent;
            this.btnManage.BorderRadius = 10;
            this.btnManage.BorderThickness = 1;
            this.btnManage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManage.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnManage.FillColor2 = System.Drawing.Color.Teal;
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManage.ForeColor = System.Drawing.Color.White;
            this.btnManage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnManage.Location = new System.Drawing.Point(481, 9);
            this.btnManage.Name = "btnManage";
            this.btnManage.ShadowDecoration.BorderRadius = 15;
            this.btnManage.ShadowDecoration.Depth = 50;
            this.btnManage.ShadowDecoration.Enabled = true;
            this.btnManage.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnManage.Size = new System.Drawing.Size(140, 40);
            this.btnManage.TabIndex = 140;
            this.btnManage.Text = "Quản lý";
            this.btnManage.Click += new System.EventHandler(this.OnManageClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.BorderThickness = 1;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnRefresh.FillColor2 = System.Drawing.Color.Teal;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRefresh.Location = new System.Drawing.Point(329, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShadowDecoration.BorderRadius = 15;
            this.btnRefresh.ShadowDecoration.Depth = 50;
            this.btnRefresh.ShadowDecoration.Enabled = true;
            this.btnRefresh.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnRefresh.Size = new System.Drawing.Size(140, 40);
            this.btnRefresh.TabIndex = 139;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.OnRefreshClick);
            // 
            // tabAddBuilding
            // 
            this.tabAddBuilding.BackColor = System.Drawing.Color.White;
            this.tabAddBuilding.Controls.Add(this.panelAddBuilding);
            this.tabAddBuilding.Location = new System.Drawing.Point(4, 44);
            this.tabAddBuilding.Name = "tabAddBuilding";
            this.tabAddBuilding.Padding = new System.Windows.Forms.Padding(10);
            this.tabAddBuilding.Size = new System.Drawing.Size(705, 442);
            this.tabAddBuilding.TabIndex = 1;
            this.tabAddBuilding.Text = "Thêm tòa nhà";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.exitButton);
            this.guna2Panel1.Controls.Add(this.btnBack);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2CustomGradientPanel18);
            this.guna2Panel1.Controls.Add(this.label22);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.guna2Panel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(967, 70);
            this.guna2Panel1.TabIndex = 150;
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
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(88, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(229, 23);
            this.label22.TabIndex = 134;
            this.label22.Text = "Giao diện quản lý các tòa nhà";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 35);
            this.label1.TabIndex = 135;
            this.label1.Text = "Quản lý Tòa Nhà";
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
            this.panelMain.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(163)))), ((int)(((byte)(96)))));
            this.panelMain.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelMain.Location = new System.Drawing.Point(1, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(251, 490);
            this.panelMain.TabIndex = 151;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.guna2PictureBox8);
            this.panel2.Controls.Add(this.btn_quanlynha);
            this.panel2.Controls.Add(this.btn_themnha);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 460);
            this.panel2.TabIndex = 1;
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.Image = global::GUI.Properties.Resources.LogoApp;
            this.guna2PictureBox8.ImageRotate = 0F;
            this.guna2PictureBox8.Location = new System.Drawing.Point(37, 289);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.Size = new System.Drawing.Size(185, 130);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox8.TabIndex = 2;
            this.guna2PictureBox8.TabStop = false;
            // 
            // btn_quanlynha
            // 
            this.btn_quanlynha.BackColor = System.Drawing.Color.Transparent;
            this.btn_quanlynha.BorderColor = System.Drawing.Color.Gray;
            this.btn_quanlynha.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btn_quanlynha.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_quanlynha.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.btn_quanlynha.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_quanlynha.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_quanlynha.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_quanlynha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_quanlynha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_quanlynha.FillColor = System.Drawing.Color.Transparent;
            this.btn_quanlynha.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_quanlynha.ForeColor = System.Drawing.Color.White;
            this.btn_quanlynha.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.btn_quanlynha.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.btn_quanlynha.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_quanlynha.Image = global::GUI.Properties.Resources.icons8_home_internet_1001;
            this.btn_quanlynha.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_quanlynha.ImageSize = new System.Drawing.Size(50, 50);
            this.btn_quanlynha.Location = new System.Drawing.Point(3, 21);
            this.btn_quanlynha.Name = "btn_quanlynha";
            this.btn_quanlynha.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_quanlynha.ShadowDecoration.BorderRadius = 15;
            this.btn_quanlynha.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btn_quanlynha.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.btn_quanlynha.ShadowDecoration.Depth = 60;
            this.btn_quanlynha.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btn_quanlynha.Size = new System.Drawing.Size(245, 70);
            this.btn_quanlynha.TabIndex = 52;
            this.btn_quanlynha.Text = "Quản lý tòa nhà";
            this.btn_quanlynha.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_quanlynha.Click += new System.EventHandler(this.btn_dichvu_Click);
            // 
            // btn_themnha
            // 
            this.btn_themnha.BackColor = System.Drawing.Color.Transparent;
            this.btn_themnha.BorderColor = System.Drawing.Color.Gray;
            this.btn_themnha.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btn_themnha.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_themnha.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.btn_themnha.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_themnha.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_themnha.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_themnha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_themnha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_themnha.FillColor = System.Drawing.Color.Transparent;
            this.btn_themnha.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_themnha.ForeColor = System.Drawing.Color.White;
            this.btn_themnha.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.btn_themnha.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.btn_themnha.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_themnha.Image = global::GUI.Properties.Resources.icons8_add_home_100;
            this.btn_themnha.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_themnha.ImageSize = new System.Drawing.Size(50, 50);
            this.btn_themnha.Location = new System.Drawing.Point(3, 113);
            this.btn_themnha.Name = "btn_themnha";
            this.btn_themnha.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_themnha.ShadowDecoration.BorderRadius = 15;
            this.btn_themnha.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btn_themnha.ShadowDecoration.CustomizableEdges.TopRight = false;
            this.btn_themnha.ShadowDecoration.Depth = 60;
            this.btn_themnha.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btn_themnha.Size = new System.Drawing.Size(245, 70);
            this.btn_themnha.TabIndex = 53;
            this.btn_themnha.Text = "Thêm tòa nhà";
            this.btn_themnha.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_themnha.TextFormatNoPrefix = true;
            this.btn_themnha.Click += new System.EventHandler(this.btn_csvc_Click);
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
            this.exitButton.Location = new System.Drawing.Point(932, 1);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 139;
            this.exitButton.Click += new System.EventHandler(this.guna2Button2_Click);
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
            this.btnBack.Location = new System.Drawing.Point(841, 35);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.BorderRadius = 10;
            this.btnBack.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(120, 30);
            this.btnBack.TabIndex = 138;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnBack.Click += new System.EventHandler(this.OnBackClick);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.icons8_home;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 7);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(60, 60);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 137;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Button1.Image = global::GUI.Properties.Resources.icon_0;
            this.guna2Button1.Location = new System.Drawing.Point(898, 1);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(30, 30);
            this.guna2Button1.TabIndex = 133;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // Form_Building
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(968, 550);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Building";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_Building_Load);
            this.panelAddBuilding.ResumeLayout(false);
            this.panelAddBuilding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabManageBuilding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuildings)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.tabAddBuilding.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel18;
        private Label label22;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2GradientButton btnManage;
        private Guna.UI2.WinForms.Guna2GradientButton btnRefresh;
        private Guna.UI2.WinForms.Guna2GradientPanel searchPanel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBuildings;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private Guna.UI2.WinForms.Guna2GradientPanel panelMain;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
        private Guna.UI2.WinForms.Guna2Button btn_quanlynha;
        private Guna.UI2.WinForms.Guna2Button btn_themnha;
    }
}