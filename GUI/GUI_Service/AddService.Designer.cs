namespace GUI.GUI_Service
{
    partial class AddService
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
            this.TenantName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TenantName_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Room_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Room = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Service_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Service = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Cost_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Cost = new Guna.UI2.WinForms.Guna2TextBox();
            this.AddBtn = new Guna.UI2.WinForms.Guna2Button();
            this.Donvi_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DonVi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // TenantName
            // 
            this.TenantName.BackColor = System.Drawing.Color.Transparent;
            this.TenantName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TenantName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TenantName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenantName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenantName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TenantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.TenantName.ItemHeight = 30;
            this.TenantName.Location = new System.Drawing.Point(225, 76);
            this.TenantName.Name = "TenantName";
            this.TenantName.Size = new System.Drawing.Size(205, 36);
            this.TenantName.TabIndex = 0;
            // 
            // TenantName_Label
            // 
            this.TenantName_Label.BackColor = System.Drawing.Color.Transparent;
            this.TenantName_Label.Location = new System.Drawing.Point(105, 85);
            this.TenantName_Label.Name = "TenantName_Label";
            this.TenantName_Label.Size = new System.Drawing.Size(103, 18);
            this.TenantName_Label.TabIndex = 1;
            this.TenantName_Label.Text = "Tên Khách Hàng";
            this.TenantName_Label.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // Room_Label
            // 
            this.Room_Label.BackColor = System.Drawing.Color.Transparent;
            this.Room_Label.Location = new System.Drawing.Point(472, 85);
            this.Room_Label.Name = "Room_Label";
            this.Room_Label.Size = new System.Drawing.Size(42, 18);
            this.Room_Label.TabIndex = 3;
            this.Room_Label.Text = "Phòng";
            // 
            // Room
            // 
            this.Room.BackColor = System.Drawing.Color.Transparent;
            this.Room.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Room.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Room.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Room.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Room.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Room.ItemHeight = 30;
            this.Room.Location = new System.Drawing.Point(543, 76);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(138, 36);
            this.Room.TabIndex = 2;
            this.Room.SelectedIndexChanged += new System.EventHandler(this.Room_SelectedIndexChanged);
            // 
            // Service_Label
            // 
            this.Service_Label.BackColor = System.Drawing.Color.Transparent;
            this.Service_Label.Location = new System.Drawing.Point(105, 139);
            this.Service_Label.Name = "Service_Label";
            this.Service_Label.Size = new System.Drawing.Size(76, 18);
            this.Service_Label.TabIndex = 5;
            this.Service_Label.Text = "Tên Dịch Vụ";
            // 
            // Service
            // 
            this.Service.BackColor = System.Drawing.Color.Transparent;
            this.Service.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Service.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Service.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Service.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Service.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Service.ItemHeight = 30;
            this.Service.Location = new System.Drawing.Point(225, 130);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(205, 36);
            this.Service.TabIndex = 4;
            // 
            // Cost_Label
            // 
            this.Cost_Label.BackColor = System.Drawing.Color.Transparent;
            this.Cost_Label.Location = new System.Drawing.Point(105, 193);
            this.Cost_Label.Name = "Cost_Label";
            this.Cost_Label.Size = new System.Drawing.Size(54, 18);
            this.Cost_Label.TabIndex = 7;
            this.Cost_Label.Text = "Giá Tiền";
            this.Cost_Label.Click += new System.EventHandler(this.guna2HtmlLabel1_Click_1);
            // 
            // Cost
            // 
            this.Cost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Cost.DefaultText = "";
            this.Cost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Cost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Cost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Cost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Cost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Cost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Cost.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Cost.Location = new System.Drawing.Point(225, 184);
            this.Cost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cost.Name = "Cost";
            this.Cost.PlaceholderText = "";
            this.Cost.SelectedText = "";
            this.Cost.Size = new System.Drawing.Size(205, 36);
            this.Cost.TabIndex = 8;
            // 
            // AddBtn
            // 
            this.AddBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(225, 248);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(132, 45);
            this.AddBtn.TabIndex = 9;
            this.AddBtn.Text = "Thêm Dịch Vụ";
            // 
            // Donvi_Label
            // 
            this.Donvi_Label.BackColor = System.Drawing.Color.Transparent;
            this.Donvi_Label.Location = new System.Drawing.Point(472, 139);
            this.Donvi_Label.Name = "Donvi_Label";
            this.Donvi_Label.Size = new System.Drawing.Size(40, 18);
            this.Donvi_Label.TabIndex = 11;
            this.Donvi_Label.Text = "Đơn vị";
            // 
            // DonVi
            // 
            this.DonVi.BackColor = System.Drawing.Color.Transparent;
            this.DonVi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DonVi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DonVi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DonVi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DonVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.DonVi.ItemHeight = 30;
            this.DonVi.Location = new System.Drawing.Point(543, 130);
            this.DonVi.Name = "DonVi";
            this.DonVi.Size = new System.Drawing.Size(138, 36);
            this.DonVi.TabIndex = 10;
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Donvi_Label);
            this.Controls.Add(this.DonVi);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.Cost_Label);
            this.Controls.Add(this.Service_Label);
            this.Controls.Add(this.Service);
            this.Controls.Add(this.Room_Label);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.TenantName_Label);
            this.Controls.Add(this.TenantName);
            this.Name = "AddService";
            this.Text = "AddService";
            this.Load += new System.EventHandler(this.AddService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox TenantName;
        private Guna.UI2.WinForms.Guna2HtmlLabel TenantName_Label;
        private Guna.UI2.WinForms.Guna2HtmlLabel Room_Label;
        private Guna.UI2.WinForms.Guna2ComboBox Room;
        private Guna.UI2.WinForms.Guna2HtmlLabel Service_Label;
        private Guna.UI2.WinForms.Guna2ComboBox Service;
        private Guna.UI2.WinForms.Guna2HtmlLabel Cost_Label;
        private Guna.UI2.WinForms.Guna2TextBox Cost;
        private Guna.UI2.WinForms.Guna2Button AddBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Donvi_Label;
        private Guna.UI2.WinForms.Guna2ComboBox DonVi;
    }
}