using System.Drawing;
using System.Windows.Forms;

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
            this.Room_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Room = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Delete = new Guna.UI2.WinForms.Guna2Button();
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
            this.TenantName.Location = new System.Drawing.Point(283, 75);
            this.TenantName.Name = "TenantName";
            this.TenantName.Size = new System.Drawing.Size(317, 36);
            this.TenantName.TabIndex = 0;
            // 
            // TenantName_Label
            // 
            this.TenantName_Label.BackColor = System.Drawing.Color.Transparent;
            this.TenantName_Label.Location = new System.Drawing.Point(135, 84);
            this.TenantName_Label.MinimumSize = new System.Drawing.Size(120, 30);
            this.TenantName_Label.Name = "TenantName_Label";
            this.TenantName_Label.Size = new System.Drawing.Size(120, 30);
            this.TenantName_Label.TabIndex = 1;
            this.TenantName_Label.Text = "Tên Khách Hàng";
            this.TenantName_Label.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // Service_Label
            // 
            this.Service_Label.BackColor = System.Drawing.Color.Transparent;
            this.Service_Label.Location = new System.Drawing.Point(135, 226);
            this.Service_Label.MinimumSize = new System.Drawing.Size(120, 30);
            this.Service_Label.Name = "Service_Label";
            this.Service_Label.Size = new System.Drawing.Size(120, 30);
            this.Service_Label.TabIndex = 5;
            this.Service_Label.Text = "Tên Dịch Vụ";
            this.Service_Label.Click += new System.EventHandler(this.Service_Label_Click);
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
            this.Service.Location = new System.Drawing.Point(283, 217);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(317, 36);
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
            this.AddBtn.Location = new System.Drawing.Point(283, 295);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(132, 45);
            this.AddBtn.TabIndex = 9;
            this.AddBtn.Text = "Đăng ký ";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // Room_Label
            // 
            this.Room_Label.BackColor = System.Drawing.Color.Transparent;
            this.Room_Label.Location = new System.Drawing.Point(135, 151);
            this.Room_Label.MinimumSize = new System.Drawing.Size(120, 30);
            this.Room_Label.Name = "Room_Label";
            this.Room_Label.Size = new System.Drawing.Size(120, 30);
            this.Room_Label.TabIndex = 11;
            this.Room_Label.Text = "Mã Số Phòng";
            this.Room_Label.Click += new System.EventHandler(this.guna2HtmlLabel1_Click_2);
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
            this.Room.Location = new System.Drawing.Point(283, 142);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(317, 36);
            this.Room.TabIndex = 10;
            this.Room.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // Delete
            // 
            this.Delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Delete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(468, 295);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(132, 45);
            this.Delete.TabIndex = 12;
            this.Delete.Text = "Hủy đăng ký ";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Room_Label);
            this.Controls.Add(this.Room);
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
        private Guna.UI2.WinForms.Guna2HtmlLabel Room_Label;
        private Guna.UI2.WinForms.Guna2ComboBox Room;
        private Guna.UI2.WinForms.Guna2Button Delete;
    }
}