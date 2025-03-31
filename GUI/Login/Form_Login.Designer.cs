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
            this.buttonXemPass = new System.Windows.Forms.Button();
            this.labelTK_DN = new System.Windows.Forms.Label();
            this.labelMK_DN = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.minimizedButton = new Guna.UI2.WinForms.Guna2Button();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.dk_lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTK_DN = new GUI.Custom.MyGunaTextBox();
            this.textBoxMK_DN = new GUI.Custom.MyGunaTextBox();
            this.buttonDangNhap1 = new GUI.Custom.MyGunaButton();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonXemPass
            // 
            this.buttonXemPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonXemPass.Location = new System.Drawing.Point(281, 188);
            this.buttonXemPass.Name = "buttonXemPass";
            this.buttonXemPass.Size = new System.Drawing.Size(25, 23);
            this.buttonXemPass.TabIndex = 18;
            this.buttonXemPass.UseVisualStyleBackColor = true;
            this.buttonXemPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseDown);
            this.buttonXemPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseUp);
            // 
            // labelTK_DN
            // 
            this.labelTK_DN.AutoSize = true;
            this.labelTK_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTK_DN.Location = new System.Drawing.Point(65, 79);
            this.labelTK_DN.Name = "labelTK_DN";
            this.labelTK_DN.Size = new System.Drawing.Size(67, 16);
            this.labelTK_DN.TabIndex = 12;
            this.labelTK_DN.Text = "Tài khoản";
            // 
            // labelMK_DN
            // 
            this.labelMK_DN.AutoSize = true;
            this.labelMK_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.labelMK_DN.Location = new System.Drawing.Point(67, 160);
            this.labelMK_DN.Name = "labelMK_DN";
            this.labelMK_DN.Size = new System.Drawing.Size(62, 16);
            this.labelMK_DN.TabIndex = 13;
            this.labelMK_DN.Text = "Mật Khẩu";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(218)))));
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.minimizedButton);
            this.guna2Panel1.Controls.Add(this.exitButton);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(377, 32);
            this.guna2Panel1.TabIndex = 20;
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // minimizedButton
            // 
            this.minimizedButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.minimizedButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.minimizedButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.minimizedButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.minimizedButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizedButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(218)))));
            this.minimizedButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.minimizedButton.ForeColor = System.Drawing.Color.White;
            this.minimizedButton.Image = global::GUI.Properties.Resources.icon_0;
            this.minimizedButton.Location = new System.Drawing.Point(317, 0);
            this.minimizedButton.Margin = new System.Windows.Forms.Padding(10);
            this.minimizedButton.Name = "minimizedButton";
            this.minimizedButton.Size = new System.Drawing.Size(30, 32);
            this.minimizedButton.TabIndex = 20;
            this.minimizedButton.Click += new System.EventHandler(this.minimizedButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(218)))));
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::GUI.Properties.Resources.icon_2;
            this.exitButton.Location = new System.Drawing.Point(347, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(10);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 32);
            this.exitButton.TabIndex = 19;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dk_lb
            // 
            this.dk_lb.AutoSize = true;
            this.dk_lb.Location = new System.Drawing.Point(262, 298);
            this.dk_lb.Name = "dk_lb";
            this.dk_lb.Size = new System.Drawing.Size(56, 16);
            this.dk_lb.TabIndex = 21;
            this.dk_lb.Text = "Đăng ký";
            this.dk_lb.Click += new System.EventHandler(this.dk_lb_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Đăng Nhập";
            // 
            // textBoxTK_DN
            // 
            this.textBoxTK_DN.BorderColor = System.Drawing.Color.Gray;
            this.textBoxTK_DN.BorderRadius = 10;
            this.textBoxTK_DN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTK_DN.DefaultText = "";
            this.textBoxTK_DN.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxTK_DN.ForeColor = System.Drawing.Color.Black;
            this.textBoxTK_DN.Location = new System.Drawing.Point(68, 98);
            this.textBoxTK_DN.Multiline = true;
            this.textBoxTK_DN.Name = "textBoxTK_DN";
            this.textBoxTK_DN.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textBoxTK_DN.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxTK_DN.PlaceholderText = "";
            this.textBoxTK_DN.SelectedText = "";
            this.textBoxTK_DN.Size = new System.Drawing.Size(250, 40);
            this.textBoxTK_DN.TabIndex = 16;
            this.textBoxTK_DN.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // textBoxMK_DN
            // 
            this.textBoxMK_DN.BorderColor = System.Drawing.Color.Gray;
            this.textBoxMK_DN.BorderRadius = 10;
            this.textBoxMK_DN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxMK_DN.DefaultText = "";
            this.textBoxMK_DN.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxMK_DN.ForeColor = System.Drawing.Color.Black;
            this.textBoxMK_DN.Location = new System.Drawing.Point(68, 179);
            this.textBoxMK_DN.Multiline = true;
            this.textBoxMK_DN.Name = "textBoxMK_DN";
            this.textBoxMK_DN.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textBoxMK_DN.PasswordChar = '*';
            this.textBoxMK_DN.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBoxMK_DN.PlaceholderText = "";
            this.textBoxMK_DN.SelectedText = "";
            this.textBoxMK_DN.Size = new System.Drawing.Size(250, 40);
            this.textBoxMK_DN.TabIndex = 17;
            this.textBoxMK_DN.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // buttonDangNhap1
            // 
            this.buttonDangNhap1.BorderRadius = 10;
            this.buttonDangNhap1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(218)))));
            this.buttonDangNhap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonDangNhap1.ForeColor = System.Drawing.Color.White;
            this.buttonDangNhap1.Location = new System.Drawing.Point(68, 246);
            this.buttonDangNhap1.Name = "buttonDangNhap1";
            this.buttonDangNhap1.Size = new System.Drawing.Size(250, 40);
            this.buttonDangNhap1.TabIndex = 14;
            this.buttonDangNhap1.Text = "Đăng nhập";
            this.buttonDangNhap1.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // Form_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(377, 428);
            this.Controls.Add(this.dk_lb);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.buttonXemPass);
            this.Controls.Add(this.textBoxTK_DN);
            this.Controls.Add(this.textBoxMK_DN);
            this.Controls.Add(this.labelTK_DN);
            this.Controls.Add(this.labelMK_DN);
            this.Controls.Add(this.buttonDangNhap1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonXemPass;
        private MyGunaTextBox textBoxTK_DN;
        private MyGunaTextBox textBoxMK_DN;
        private System.Windows.Forms.Label labelTK_DN;
        private System.Windows.Forms.Label labelMK_DN;

        private MyGunaButton buttonDangNhap1;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button minimizedButton;
        private System.Windows.Forms.Label dk_lb;
        private System.Windows.Forms.Label label1;
    }
}

