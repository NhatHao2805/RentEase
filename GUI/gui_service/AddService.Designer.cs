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
            this.Service = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Room = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2CustomGradientPanel18 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.AddBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Delete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel12 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            this.guna2GradientPanel3.SuspendLayout();
            this.guna2GradientPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TenantName
            // 
            this.TenantName.BackColor = System.Drawing.Color.Transparent;
            this.TenantName.BorderRadius = 10;
            this.TenantName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TenantName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TenantName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenantName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TenantName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TenantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.TenantName.ItemHeight = 30;
            this.TenantName.Location = new System.Drawing.Point(175, 11);
            this.TenantName.Name = "TenantName";
            this.TenantName.ShadowDecoration.BorderRadius = 10;
            this.TenantName.ShadowDecoration.Enabled = true;
            this.TenantName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.TenantName.Size = new System.Drawing.Size(317, 36);
            this.TenantName.TabIndex = 0;
            // 
            // Service
            // 
            this.Service.BackColor = System.Drawing.Color.Transparent;
            this.Service.BorderRadius = 10;
            this.Service.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Service.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Service.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Service.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Service.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Service.ItemHeight = 30;
            this.Service.Location = new System.Drawing.Point(174, 10);
            this.Service.Name = "Service";
            this.Service.ShadowDecoration.BorderRadius = 10;
            this.Service.ShadowDecoration.Enabled = true;
            this.Service.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.Service.Size = new System.Drawing.Size(317, 36);
            this.Service.TabIndex = 4;
            // 
            // Room
            // 
            this.Room.BackColor = System.Drawing.Color.Transparent;
            this.Room.BorderRadius = 10;
            this.Room.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Room.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Room.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Room.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Room.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Room.ItemHeight = 30;
            this.Room.Location = new System.Drawing.Point(174, 10);
            this.Room.Name = "Room";
            this.Room.ShadowDecoration.BorderRadius = 10;
            this.Room.ShadowDecoration.Enabled = true;
            this.Room.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.Room.Size = new System.Drawing.Size(317, 36);
            this.Room.TabIndex = 10;
            this.Room.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
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
            this.label22.Size = new System.Drawing.Size(187, 20);
            this.label22.TabIndex = 122;
            this.label22.Text = "Thêm dịch vụ mới vào bảng";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(93, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(160, 29);
            this.label23.TabIndex = 123;
            this.label23.Text = "Thêm dịch vụ";
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddBtn.BorderColor = System.Drawing.Color.Transparent;
            this.AddBtn.BorderRadius = 10;
            this.AddBtn.BorderThickness = 1;
            this.AddBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.AddBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.AddBtn.Location = new System.Drawing.Point(304, 291);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.ShadowDecoration.BorderRadius = 15;
            this.AddBtn.ShadowDecoration.Depth = 50;
            this.AddBtn.ShadowDecoration.Enabled = true;
            this.AddBtn.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.AddBtn.Size = new System.Drawing.Size(120, 50);
            this.AddBtn.TabIndex = 137;
            this.AddBtn.Text = "Đăng ký";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Transparent;
            this.Delete.BorderColor = System.Drawing.Color.Transparent;
            this.Delete.BorderRadius = 10;
            this.Delete.BorderThickness = 1;
            this.Delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Delete.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Delete.FillColor = System.Drawing.Color.Maroon;
            this.Delete.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Delete.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Delete.Location = new System.Drawing.Point(127, 291);
            this.Delete.Name = "Delete";
            this.Delete.ShadowDecoration.BorderRadius = 15;
            this.Delete.ShadowDecoration.Depth = 50;
            this.Delete.ShadowDecoration.Enabled = true;
            this.Delete.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.Delete.Size = new System.Drawing.Size(120, 50);
            this.Delete.TabIndex = 138;
            this.Delete.Text = "Hủy đăng ký";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // guna2GradientPanel12
            // 
            this.guna2GradientPanel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel12.Controls.Add(this.exitButton);
            this.guna2GradientPanel12.Controls.Add(this.guna2PictureBox5);
            this.guna2GradientPanel12.Controls.Add(this.guna2CustomGradientPanel18);
            this.guna2GradientPanel12.Controls.Add(this.label22);
            this.guna2GradientPanel12.Controls.Add(this.label23);
            this.guna2GradientPanel12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel12.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel12.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel12.Name = "guna2GradientPanel12";
            this.guna2GradientPanel12.Size = new System.Drawing.Size(554, 70);
            this.guna2GradientPanel12.TabIndex = 136;
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Image = global::GUI.Properties.Resources.icons8_service_50;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(15, 5);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(60, 60);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox5.TabIndex = 132;
            this.guna2PictureBox5.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.BorderColor = System.Drawing.Color.DimGray;
            this.exitButton.BorderRadius = 1;
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.FillColor = System.Drawing.Color.IndianRed;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::GUI.Properties.Resources.icon_2;
            this.exitButton.Location = new System.Drawing.Point(520, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel4);
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel3);
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel2);
            this.guna2GradientPanel1.Controls.Add(this.AddBtn);
            this.guna2GradientPanel1.Controls.Add(this.Delete);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Honeydew;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(2, 71);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(550, 365);
            this.guna2GradientPanel1.TabIndex = 139;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.Gray;
            this.guna2GradientPanel2.BorderRadius = 10;
            this.guna2GradientPanel2.BorderThickness = 1;
            this.guna2GradientPanel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel2.Controls.Add(this.TenantName);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.GhostWhite;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(15, 44);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel2.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel2.Size = new System.Drawing.Size(525, 60);
            this.guna2GradientPanel2.TabIndex = 139;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(19, 18);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(134, 25);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Tên Khách Hàng:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(19, 18);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(111, 25);
            this.guna2HtmlLabel2.TabIndex = 140;
            this.guna2HtmlLabel2.Text = "Mã Số Phòng:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(19, 18);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(100, 25);
            this.guna2HtmlLabel3.TabIndex = 141;
            this.guna2HtmlLabel3.Text = "Tên Dịch Vụ:";
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BorderColor = System.Drawing.Color.Gray;
            this.guna2GradientPanel3.BorderRadius = 10;
            this.guna2GradientPanel3.BorderThickness = 1;
            this.guna2GradientPanel3.Controls.Add(this.Room);
            this.guna2GradientPanel3.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.GhostWhite;
            this.guna2GradientPanel3.Location = new System.Drawing.Point(15, 121);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel3.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel3.Size = new System.Drawing.Size(525, 60);
            this.guna2GradientPanel3.TabIndex = 142;
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BorderColor = System.Drawing.Color.Gray;
            this.guna2GradientPanel4.BorderRadius = 10;
            this.guna2GradientPanel4.BorderThickness = 1;
            this.guna2GradientPanel4.Controls.Add(this.Service);
            this.guna2GradientPanel4.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.GhostWhite;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(15, 196);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientPanel4.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel4.Size = new System.Drawing.Size(525, 60);
            this.guna2GradientPanel4.TabIndex = 143;
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(554, 437);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2GradientPanel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddService";
            this.Load += new System.EventHandler(this.AddService_Load);
            this.guna2GradientPanel12.ResumeLayout(false);
            this.guna2GradientPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.guna2GradientPanel4.ResumeLayout(false);
            this.guna2GradientPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox TenantName;
        private Guna.UI2.WinForms.Guna2ComboBox Service;
        private Guna.UI2.WinForms.Guna2ComboBox Room;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel18;
        private Label label22;
        private Label label23;
        private Guna.UI2.WinForms.Guna2GradientButton AddBtn;
        private Guna.UI2.WinForms.Guna2GradientButton Delete;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel12;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
    }
}