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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.labelTK_DN = new System.Windows.Forms.Label();
            this.labelMK_DN = new System.Windows.Forms.Label();
            this.dk_lb = new System.Windows.Forms.Label();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dmk_lb = new System.Windows.Forms.Label();
            this.dkm_lb = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.hienMk = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.textBoxTK_DN = new GUI.Custom.MyGunaTextBox();
            this.buttonDangNhap1 = new GUI.Custom.MyGunaButton();
            this.textBoxMK_DN = new GUI.Custom.MyGunaTextBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTK_DN
            // 
            this.labelTK_DN.AutoSize = true;
            this.labelTK_DN.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTK_DN.Location = new System.Drawing.Point(77, 160);
            this.labelTK_DN.Name = "labelTK_DN";
            this.labelTK_DN.Size = new System.Drawing.Size(129, 23);
            this.labelTK_DN.TabIndex = 12;
            this.labelTK_DN.Text = "Tên Đăng Nhập";
            // 
            // labelMK_DN
            // 
            this.labelMK_DN.AutoSize = true;
            this.labelMK_DN.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMK_DN.Location = new System.Drawing.Point(77, 240);
            this.labelMK_DN.Name = "labelMK_DN";
            this.labelMK_DN.Size = new System.Drawing.Size(85, 23);
            this.labelMK_DN.TabIndex = 13;
            this.labelMK_DN.Text = "Mật Khẩu";
            // 
            // dk_lb
            // 
            this.dk_lb.AutoSize = true;
            this.dk_lb.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dk_lb.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dk_lb.Location = new System.Drawing.Point(239, 404);
            this.dk_lb.Name = "dk_lb";
            this.dk_lb.Size = new System.Drawing.Size(75, 23);
            this.dk_lb.TabIndex = 21;
            this.dk_lb.Text = "Đăng ký";
            this.dk_lb.Click += new System.EventHandler(this.dk_lb_Click);
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2ComboBox1.BorderRadius = 10;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(220, 494);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ComboBox1.ShadowDecoration.Enabled = true;
            this.guna2ComboBox1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.guna2ComboBox1.Size = new System.Drawing.Size(140, 36);
            this.guna2ComboBox1.TabIndex = 22;
            this.guna2ComboBox1.SelectionChangeCommitted += new System.EventHandler(this.guna2ComboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(112, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 38);
            this.label1.TabIndex = 123;
            this.label1.Text = "Đăng nhập";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.Controls.Add(this.dkm_lb);
            this.guna2GradientPanel1.Controls.Add(this.guna2Button1);
            this.guna2GradientPanel1.Controls.Add(this.guna2Button2);
            this.guna2GradientPanel1.Controls.Add(this.guna2Button3);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.Controls.Add(this.guna2PictureBox5);
            this.guna2GradientPanel1.Controls.Add(this.textBoxTK_DN);
            this.guna2GradientPanel1.Controls.Add(this.buttonDangNhap1);
            this.guna2GradientPanel1.Controls.Add(this.guna2ComboBox1);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.labelMK_DN);
            this.guna2GradientPanel1.Controls.Add(this.dk_lb);
            this.guna2GradientPanel1.Controls.Add(this.labelTK_DN);
            this.guna2GradientPanel1.Controls.Add(this.textBoxMK_DN);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Honeydew;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.AliceBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(528, -5);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(372, 555);
            this.guna2GradientPanel1.TabIndex = 149;
            // 
            // dmk_lb
            // 
            this.dmk_lb.AutoSize = true;
            this.dmk_lb.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmk_lb.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dmk_lb.Location = new System.Drawing.Point(695, 425);
            this.dmk_lb.Name = "dmk_lb";
            this.dmk_lb.Size = new System.Drawing.Size(172, 23);
            this.dmk_lb.TabIndex = 151;
            this.dmk_lb.Text = "Quên/Đổi mật khẩu?";
            this.dmk_lb.Click += new System.EventHandler(this.dmk_lb_Click);
            // 
            // dkm_lb
            // 
            this.dkm_lb.Location = new System.Drawing.Point(0, 0);
            this.dkm_lb.Name = "dkm_lb";
            this.dkm_lb.Size = new System.Drawing.Size(100, 23);
            this.dkm_lb.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button1.BorderRadius = 1;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(340, 6);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(30, 30);
            this.guna2Button1.TabIndex = 20;
            this.guna2Button1.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.LightCyan;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.Location = new System.Drawing.Point(309, 6);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(30, 30);
            this.guna2Button2.TabIndex = 133;
            this.guna2Button2.Click += new System.EventHandler(this.minimizedButton_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Button3.BorderThickness = 1;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2Button3.Location = new System.Drawing.Point(280, 269);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(33, 33);
            this.guna2Button3.TabIndex = 150;
            this.hienMk.SetToolTip(this.guna2Button3, "Ấn giữ để hiện mật khẩu");
            this.guna2Button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseDown);
            this.guna2Button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseUp);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(71, 406);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(172, 21);
            this.guna2HtmlLabel1.TabIndex = 124;
            this.guna2HtmlLabel1.Text = "Don\'t have an account?";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Image = global::GUI.Properties.Resources.Logo;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(-10, 3);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(110, 65);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox5.TabIndex = 132;
            this.guna2PictureBox5.TabStop = false;
            // 
            // hienMk
            // 
            this.hienMk.AllowLinksHandling = true;
            this.hienMk.MaximumSize = new System.Drawing.Size(0, 0);
            this.hienMk.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.hienMk.ToolTipTitle = "Hiện mật khẩu";
            this.hienMk.Popup += new System.Windows.Forms.PopupEventHandler(this.hienMk_Popup);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources._5603109;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, -5);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(531, 555);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 150;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // textBoxTK_DN
            // 
            this.textBoxTK_DN.BackColor = System.Drawing.Color.Transparent;
            this.textBoxTK_DN.BorderColor = System.Drawing.Color.Silver;
            this.textBoxTK_DN.BorderRadius = 10;
            this.textBoxTK_DN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTK_DN.DefaultText = "";
            this.textBoxTK_DN.Font = new System.Drawing.Font("Segoe UI", 11.2F);
            this.textBoxTK_DN.ForeColor = System.Drawing.Color.Black;
            this.textBoxTK_DN.Location = new System.Drawing.Point(71, 186);
            this.textBoxTK_DN.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxTK_DN.Name = "textBoxTK_DN";
            this.textBoxTK_DN.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.textBoxTK_DN.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBoxTK_DN.PlaceholderText = "User name...";
            this.textBoxTK_DN.SelectedText = "";
            this.textBoxTK_DN.ShadowDecoration.BorderRadius = 10;
            this.textBoxTK_DN.ShadowDecoration.Enabled = true;
            this.textBoxTK_DN.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxTK_DN.Size = new System.Drawing.Size(250, 50);
            this.textBoxTK_DN.TabIndex = 16;
            this.textBoxTK_DN.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // buttonDangNhap1
            // 
            this.buttonDangNhap1.BackColor = System.Drawing.Color.Transparent;
            this.buttonDangNhap1.BorderColor = System.Drawing.Color.Silver;
            this.buttonDangNhap1.BorderRadius = 10;
            this.buttonDangNhap1.BorderThickness = 1;
            this.buttonDangNhap1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.buttonDangNhap1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangNhap1.ForeColor = System.Drawing.Color.White;
            this.buttonDangNhap1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonDangNhap1.Location = new System.Drawing.Point(71, 342);
            this.buttonDangNhap1.Name = "buttonDangNhap1";
            this.buttonDangNhap1.ShadowDecoration.BorderRadius = 10;
            this.buttonDangNhap1.ShadowDecoration.Enabled = true;
            this.buttonDangNhap1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.buttonDangNhap1.Size = new System.Drawing.Size(250, 50);
            this.buttonDangNhap1.TabIndex = 14;
            this.buttonDangNhap1.Text = "Đăng nhập";
            this.buttonDangNhap1.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // textBoxMK_DN
            // 
            this.textBoxMK_DN.BackColor = System.Drawing.Color.Transparent;
            this.textBoxMK_DN.BorderColor = System.Drawing.Color.Silver;
            this.textBoxMK_DN.BorderRadius = 10;
            this.textBoxMK_DN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxMK_DN.DefaultText = "";
            this.textBoxMK_DN.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxMK_DN.ForeColor = System.Drawing.Color.Black;
            this.textBoxMK_DN.Location = new System.Drawing.Point(71, 266);
            this.textBoxMK_DN.Name = "textBoxMK_DN";
            this.textBoxMK_DN.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.textBoxMK_DN.PasswordChar = '*';
            this.textBoxMK_DN.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBoxMK_DN.PlaceholderText = "Password...";
            this.textBoxMK_DN.SelectedText = "";
            this.textBoxMK_DN.ShadowDecoration.BorderRadius = 10;
            this.textBoxMK_DN.ShadowDecoration.Enabled = true;
            this.textBoxMK_DN.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.textBoxMK_DN.Size = new System.Drawing.Size(250, 40);
            this.textBoxMK_DN.TabIndex = 17;
            this.textBoxMK_DN.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // Form_Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.dmk_lb);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyGunaTextBox textBoxTK_DN;
        private MyGunaTextBox textBoxMK_DN;
        private System.Windows.Forms.Label labelTK_DN;
        private System.Windows.Forms.Label labelMK_DN;

        private MyGunaButton buttonDangNhap1;
        private System.Windows.Forms.Label dk_lb;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip hienMk;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.Windows.Forms.Label dkm_lb;
        private System.Windows.Forms.Label dmk_lb;
    }
}

