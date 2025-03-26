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
            this.Service_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Service = new Guna.UI2.WinForms.Guna2ComboBox();
            this.AddBtn = new Guna.UI2.WinForms.Guna2Button();
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
            // AddBtn
            // 
            this.AddBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(242, 191);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(132, 45);
            this.AddBtn.TabIndex = 9;
            this.AddBtn.Text = "Thêm Dịch Vụ";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.Service_Label);
            this.Controls.Add(this.Service);
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
        private Guna.UI2.WinForms.Guna2HtmlLabel Service_Label;
        private Guna.UI2.WinForms.Guna2ComboBox Service;
        private Guna.UI2.WinForms.Guna2Button AddBtn;
    }
}