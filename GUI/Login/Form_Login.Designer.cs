using GUI.Custom;
using System.Drawing;
namespace GUI
{
    partial class Form_Login
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
            this.labelTK_DN = new System.Windows.Forms.Label();
            this.labelMK_DN = new System.Windows.Forms.Label();
            this.dk_lb = new System.Windows.Forms.Label();
            this.guna2GradientPanel12 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.minimizedButton = new Guna.UI2.WinForms.Guna2Button();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.buttonXemPass2 = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxTK_DN = new GUI.Custom.MyGunaTextBox();
            this.buttonDangNhap1 = new GUI.Custom.MyGunaButton();
            this.textBoxMK_DN = new GUI.Custom.MyGunaTextBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.hienMK = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GradientPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTK_DN
            // 
            this.labelTK_DN.AutoSize = true;
            this.labelTK_DN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTK_DN.Location = new System.Drawing.Point(97, 167);
            this.labelTK_DN.Name = "labelTK_DN";
            this.labelTK_DN.Size = new System.Drawing.Size(81, 19);
            this.labelTK_DN.TabIndex = 12;
            this.labelTK_DN.Text = "Tài khoản";
            // 
            // labelMK_DN
            // 
            this.labelMK_DN.AutoSize = true;
            this.labelMK_DN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMK_DN.Location = new System.Drawing.Point(98, 249);
            this.labelMK_DN.Name = "labelMK_DN";
            this.labelMK_DN.Size = new System.Drawing.Size(81, 19);
            this.labelMK_DN.TabIndex = 13;
            this.labelMK_DN.Text = "Mật Khẩu";
            // 
            // dk_lb
            // 
            this.dk_lb.AutoSize = true;
            this.dk_lb.BackColor = System.Drawing.Color.Transparent;
            this.dk_lb.Font = new System.Drawing.Font("Sylfaen", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dk_lb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(225)))));
            this.dk_lb.Location = new System.Drawing.Point(254, 405);
            this.dk_lb.Name = "dk_lb";
            this.dk_lb.Size = new System.Drawing.Size(68, 19);
            this.dk_lb.TabIndex = 21;
            this.dk_lb.Text = "Đăng ký";
            this.dk_lb.Click += new System.EventHandler(this.dk_lb_Click);
            this.dk_lb.MouseEnter += new System.EventHandler(this.DangKy_Dichuot);
            this.dk_lb.MouseLeave += new System.EventHandler(this.Dangky_Bochuot);
            // 
            // guna2GradientPanel12
            // 
            this.guna2GradientPanel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel12.BorderColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel12.Controls.Add(this.minimizedButton);
            this.guna2GradientPanel12.Controls.Add(this.exitButton);
            this.guna2GradientPanel12.Controls.Add(this.guna2PictureBox5);
            this.guna2GradientPanel12.Controls.Add(this.label22);
            this.guna2GradientPanel12.FillColor = System.Drawing.Color.Lavender;
            this.guna2GradientPanel12.FillColor2 = System.Drawing.Color.LightCyan;
            this.guna2GradientPanel12.Location = new System.Drawing.Point(1, 1);
            this.guna2GradientPanel12.Name = "guna2GradientPanel12";
            this.guna2GradientPanel12.Size = new System.Drawing.Size(432, 70);
            this.guna2GradientPanel12.TabIndex = 138;
            // 
            // minimizedButton
            // 
            this.minimizedButton.BorderColor = System.Drawing.Color.Teal;
            this.minimizedButton.BorderThickness = 1;
            this.minimizedButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.minimizedButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.minimizedButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.minimizedButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.minimizedButton.FillColor = System.Drawing.Color.MediumTurquoise;
            this.minimizedButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.minimizedButton.ForeColor = System.Drawing.Color.White;
            this.minimizedButton.Image = global::GUI.Properties.Resources.icon_0;
            this.minimizedButton.Location = new System.Drawing.Point(372, 0);
            this.minimizedButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.minimizedButton.Name = "minimizedButton";
            this.minimizedButton.Size = new System.Drawing.Size(30, 30);
            this.minimizedButton.TabIndex = 21;
            this.minimizedButton.Click += new System.EventHandler(this.minimizedButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exitButton.BorderRadius = 1;
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.FillColor = System.Drawing.Color.IndianRed;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::GUI.Properties.Resources.icon_2;
            this.exitButton.Location = new System.Drawing.Point(402, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Image = global::GUI.Properties.Resources.icons8_sign_in_100;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(5, -5);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(80, 80);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox5.TabIndex = 132;
            this.guna2PictureBox5.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(91, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(239, 29);
            this.label22.TabIndex = 122;
            this.label22.Text = "RentEase Welcome";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(158, 115);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(130, 29);
            this.label23.TabIndex = 123;
            this.label23.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(111, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 139;
            this.label2.Text = "Chưa có tài khoản?";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.BorderThickness = 1;
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel12);
            this.guna2GradientPanel1.Controls.Add(this.buttonXemPass2);
            this.guna2GradientPanel1.Controls.Add(this.label23);
            this.guna2GradientPanel1.Controls.Add(this.textBoxTK_DN);
            this.guna2GradientPanel1.Controls.Add(this.buttonDangNhap1);
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.labelMK_DN);
            this.guna2GradientPanel1.Controls.Add(this.labelTK_DN);
            this.guna2GradientPanel1.Controls.Add(this.dk_lb);
            this.guna2GradientPanel1.Controls.Add(this.textBoxMK_DN);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Ivory;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(437, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 0;
            this.guna2GradientPanel1.ShadowDecoration.Color = System.Drawing.Color.Teal;
            this.guna2GradientPanel1.ShadowDecoration.Depth = 70;
            this.guna2GradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(435, 549);
            this.guna2GradientPanel1.TabIndex = 141;
            this.guna2GradientPanel1.UseTransparentBackground = true;
            // 
            // buttonXemPass2
            // 
            this.buttonXemPass2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonXemPass2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonXemPass2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonXemPass2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonXemPass2.FillColor = System.Drawing.Color.Transparent;
            this.buttonXemPass2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonXemPass2.ForeColor = System.Drawing.Color.White;
            this.buttonXemPass2.Image = global::GUI.Properties.Resources.icons8_show_password_100;
            this.buttonXemPass2.ImageOffset = new System.Drawing.Point(0, 10);
            this.buttonXemPass2.Location = new System.Drawing.Point(305, 283);
            this.buttonXemPass2.Name = "buttonXemPass2";
            this.buttonXemPass2.Size = new System.Drawing.Size(25, 25);
            this.buttonXemPass2.TabIndex = 148;
            this.buttonXemPass2.Text = "guna2Button1";
            this.hienMK.SetToolTip(this.buttonXemPass2, "Nhấn giữ để hiện mật khẩu vừa nhập");
            this.buttonXemPass2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseDown);
            this.buttonXemPass2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseUp);
            // 
            // textBoxTK_DN
            // 
            this.textBoxTK_DN.BackColor = System.Drawing.Color.Transparent;
            this.textBoxTK_DN.BorderColor = System.Drawing.Color.Gray;
            this.textBoxTK_DN.BorderRadius = 10;
            this.textBoxTK_DN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTK_DN.DefaultText = "";
            this.textBoxTK_DN.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxTK_DN.ForeColor = System.Drawing.Color.Black;
            this.textBoxTK_DN.Location = new System.Drawing.Point(92, 193);
            this.textBoxTK_DN.Multiline = true;
            this.textBoxTK_DN.Name = "textBoxTK_DN";
            this.textBoxTK_DN.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textBoxTK_DN.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxTK_DN.PlaceholderText = "";
            this.textBoxTK_DN.SelectedText = "";
            this.textBoxTK_DN.ShadowDecoration.BorderRadius = 10;
            this.textBoxTK_DN.ShadowDecoration.Enabled = true;
            this.textBoxTK_DN.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxTK_DN.Size = new System.Drawing.Size(250, 40);
            this.textBoxTK_DN.TabIndex = 16;
            this.textBoxTK_DN.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // buttonDangNhap1
            // 
            this.buttonDangNhap1.BackColor = System.Drawing.Color.Transparent;
            this.buttonDangNhap1.BorderRadius = 10;
            this.buttonDangNhap1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.buttonDangNhap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangNhap1.ForeColor = System.Drawing.Color.White;
            this.buttonDangNhap1.HoverState.FillColor = System.Drawing.Color.Aqua;
            this.buttonDangNhap1.Location = new System.Drawing.Point(92, 341);
            this.buttonDangNhap1.Name = "buttonDangNhap1";
            this.buttonDangNhap1.ShadowDecoration.Enabled = true;
            this.buttonDangNhap1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.buttonDangNhap1.Size = new System.Drawing.Size(250, 40);
            this.buttonDangNhap1.TabIndex = 14;
            this.buttonDangNhap1.Text = "Đăng nhập";
            this.buttonDangNhap1.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // textBoxMK_DN
            // 
            this.textBoxMK_DN.BackColor = System.Drawing.Color.Transparent;
            this.textBoxMK_DN.BorderColor = System.Drawing.Color.Gray;
            this.textBoxMK_DN.BorderRadius = 10;
            this.textBoxMK_DN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxMK_DN.DefaultText = "";
            this.textBoxMK_DN.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxMK_DN.ForeColor = System.Drawing.Color.Black;
            this.textBoxMK_DN.Location = new System.Drawing.Point(92, 274);
            this.textBoxMK_DN.Multiline = true;
            this.textBoxMK_DN.Name = "textBoxMK_DN";
            this.textBoxMK_DN.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textBoxMK_DN.PasswordChar = '*';
            this.textBoxMK_DN.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxMK_DN.PlaceholderText = "";
            this.textBoxMK_DN.SelectedText = "";
            this.textBoxMK_DN.ShadowDecoration.BorderRadius = 10;
            this.textBoxMK_DN.ShadowDecoration.Enabled = true;
            this.textBoxMK_DN.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxMK_DN.Size = new System.Drawing.Size(250, 40);
            this.textBoxMK_DN.TabIndex = 17;
            this.textBoxMK_DN.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // hienMK
            // 
            this.hienMK.AllowLinksHandling = true;
            this.hienMK.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.hienMK.ForeColor = System.Drawing.Color.Teal;
            this.hienMK.MaximumSize = new System.Drawing.Size(0, 0);
            this.hienMK.TitleFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.hienMK.TitleForeColor = System.Drawing.Color.DarkBlue;
            this.hienMK.ToolTipTitle = "Hiện Mật Khẩu";
            this.hienMK.Popup += new System.Windows.Forms.PopupEventHandler(this.hienMK_Popup_1);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.DangNhap;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(84, 177);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(162, 158);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 144;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(870, 545);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.guna2GradientPanel12.ResumeLayout(false);
            this.guna2GradientPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MyGunaTextBox textBoxTK_DN;
        private MyGunaTextBox textBoxMK_DN;
        private System.Windows.Forms.Label labelTK_DN;
        private System.Windows.Forms.Label labelMK_DN;

        private MyGunaButton buttonDangNhap1;
        private System.Windows.Forms.Label dk_lb;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel12;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2Button minimizedButton;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button buttonXemPass2;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip hienMK;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}

