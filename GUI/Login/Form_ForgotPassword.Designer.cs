namespace GUI
{
    partial class Form_ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ForgotPassword));
            this.panelStep2 = new System.Windows.Forms.Panel();
            this.lblPasswordRequirements = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelOTP = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.panelStep1 = new System.Windows.Forms.Panel();
            this.btnVerify = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtOTP = new GUI.Custom.MyGunaTextBox();
            this.btnSendOTP = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtEmail = new GUI.Custom.MyGunaTextBox();
            this.guna2GradientPanel12 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CustomGradientPanel18 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNewPassword = new GUI.Custom.MyGunaTextBox();
            this.txtConfirmPassword = new GUI.Custom.MyGunaTextBox();
            this.btnResetPassword = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panelStep2.SuspendLayout();
            this.panelStep1.SuspendLayout();
            this.guna2GradientPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStep2
            // 
            this.panelStep2.BackColor = System.Drawing.Color.AliceBlue;
            this.panelStep2.Controls.Add(this.btnResetPassword);
            this.panelStep2.Controls.Add(this.txtConfirmPassword);
            this.panelStep2.Controls.Add(this.txtNewPassword);
            this.panelStep2.Controls.Add(this.lblPasswordRequirements);
            this.panelStep2.Controls.Add(this.labelConfirmPassword);
            this.panelStep2.Controls.Add(this.labelNewPassword);
            this.panelStep2.Location = new System.Drawing.Point(4, 70);
            this.panelStep2.Name = "panelStep2";
            this.panelStep2.Size = new System.Drawing.Size(390, 340);
            this.panelStep2.TabIndex = 1;
            this.panelStep2.Visible = false;
            // 
            // lblPasswordRequirements
            // 
            this.lblPasswordRequirements.AutoSize = true;
            this.lblPasswordRequirements.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblPasswordRequirements.ForeColor = System.Drawing.Color.Maroon;
            this.lblPasswordRequirements.Location = new System.Drawing.Point(20, 242);
            this.lblPasswordRequirements.Name = "lblPasswordRequirements";
            this.lblPasswordRequirements.Size = new System.Drawing.Size(245, 92);
            this.lblPasswordRequirements.TabIndex = 5;
            this.lblPasswordRequirements.Text = "Password must contain:\n• At least 8 characters\n• At least one number\n• At least o" +
    "ne special character";
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelConfirmPassword.Location = new System.Drawing.Point(20, 92);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(153, 23);
            this.labelConfirmPassword.TabIndex = 2;
            this.labelConfirmPassword.Text = "Confirm Password:";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelNewPassword.Location = new System.Drawing.Point(20, 6);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(126, 23);
            this.labelNewPassword.TabIndex = 0;
            this.labelNewPassword.Text = "New Password:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelEmail.Location = new System.Drawing.Point(13, 6);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(55, 23);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email:";
            // 
            // labelOTP
            // 
            this.labelOTP.AutoSize = true;
            this.labelOTP.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelOTP.Location = new System.Drawing.Point(13, 161);
            this.labelOTP.Name = "labelOTP";
            this.labelOTP.Size = new System.Drawing.Size(45, 23);
            this.labelOTP.TabIndex = 3;
            this.labelOTP.Text = "OTP:";
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(56, 382);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(0, 16);
            this.lblCountdown.TabIndex = 6;
            // 
            // panelStep1
            // 
            this.panelStep1.BackColor = System.Drawing.Color.AliceBlue;
            this.panelStep1.Controls.Add(this.btnVerify);
            this.panelStep1.Controls.Add(this.txtOTP);
            this.panelStep1.Controls.Add(this.btnSendOTP);
            this.panelStep1.Controls.Add(this.txtEmail);
            this.panelStep1.Controls.Add(this.lblCountdown);
            this.panelStep1.Controls.Add(this.labelOTP);
            this.panelStep1.Controls.Add(this.labelEmail);
            this.panelStep1.Location = new System.Drawing.Point(4, 70);
            this.panelStep1.Name = "panelStep1";
            this.panelStep1.Size = new System.Drawing.Size(390, 340);
            this.panelStep1.TabIndex = 0;
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.Transparent;
            this.btnVerify.BorderColor = System.Drawing.Color.Transparent;
            this.btnVerify.BorderRadius = 10;
            this.btnVerify.BorderThickness = 1;
            this.btnVerify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerify.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerify.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.btnVerify.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnVerify.Location = new System.Drawing.Point(114, 254);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.ShadowDecoration.BorderRadius = 15;
            this.btnVerify.ShadowDecoration.Depth = 50;
            this.btnVerify.ShadowDecoration.Enabled = true;
            this.btnVerify.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnVerify.Size = new System.Drawing.Size(160, 50);
            this.btnVerify.TabIndex = 140;
            this.btnVerify.Text = "Verify";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtOTP
            // 
            this.txtOTP.BackColor = System.Drawing.Color.Transparent;
            this.txtOTP.BorderColor = System.Drawing.Color.Silver;
            this.txtOTP.BorderRadius = 10;
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.DefaultText = "";
            this.txtOTP.Font = new System.Drawing.Font("Segoe UI", 11.2F);
            this.txtOTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOTP.Location = new System.Drawing.Point(19, 197);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.txtOTP.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtOTP.PlaceholderText = "OTP...";
            this.txtOTP.SelectedText = "";
            this.txtOTP.ShadowDecoration.BorderRadius = 10;
            this.txtOTP.ShadowDecoration.Enabled = true;
            this.txtOTP.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtOTP.Size = new System.Drawing.Size(349, 44);
            this.txtOTP.TabIndex = 139;
            this.txtOTP.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.BackColor = System.Drawing.Color.Transparent;
            this.btnSendOTP.BorderColor = System.Drawing.Color.Transparent;
            this.btnSendOTP.BorderRadius = 10;
            this.btnSendOTP.BorderThickness = 1;
            this.btnSendOTP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendOTP.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendOTP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnSendOTP.FillColor2 = System.Drawing.Color.Teal;
            this.btnSendOTP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendOTP.ForeColor = System.Drawing.Color.White;
            this.btnSendOTP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSendOTP.Location = new System.Drawing.Point(114, 90);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.ShadowDecoration.BorderRadius = 15;
            this.btnSendOTP.ShadowDecoration.Depth = 50;
            this.btnSendOTP.ShadowDecoration.Enabled = true;
            this.btnSendOTP.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnSendOTP.Size = new System.Drawing.Size(160, 50);
            this.btnSendOTP.TabIndex = 138;
            this.btnSendOTP.Text = "Send OTP";
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.Silver;
            this.txtEmail.BorderRadius = 10;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11.2F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.Location = new System.Drawing.Point(19, 33);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtEmail.PlaceholderText = "Enter your email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.BorderRadius = 10;
            this.txtEmail.ShadowDecoration.Enabled = true;
            this.txtEmail.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtEmail.Size = new System.Drawing.Size(349, 44);
            this.txtEmail.TabIndex = 17;
            this.txtEmail.TextOffset = new System.Drawing.Point(10, 0);
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
            this.guna2GradientPanel12.Location = new System.Drawing.Point(1, 0);
            this.guna2GradientPanel12.Name = "guna2GradientPanel12";
            this.guna2GradientPanel12.Size = new System.Drawing.Size(396, 70);
            this.guna2GradientPanel12.TabIndex = 150;
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
            this.exitButton.Location = new System.Drawing.Point(361, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Image = global::GUI.Properties.Resources.icons8_lock;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(7, 5);
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
            this.guna2CustomGradientPanel18.Location = new System.Drawing.Point(76, 8);
            this.guna2CustomGradientPanel18.Name = "guna2CustomGradientPanel18";
            this.guna2CustomGradientPanel18.Size = new System.Drawing.Size(7, 50);
            this.guna2CustomGradientPanel18.TabIndex = 125;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.label22.Location = new System.Drawing.Point(84, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(194, 25);
            this.label22.TabIndex = 122;
            this.label22.Text = "Đổi mật khẩu của bạn";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(82, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(208, 35);
            this.label23.TabIndex = 123;
            this.label23.Text = "Quên mật khẩu";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtNewPassword.BorderRadius = 10;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 11.2F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewPassword.Location = new System.Drawing.Point(24, 27);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNewPassword.PlaceholderText = "Enter new password";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.ShadowDecoration.BorderRadius = 10;
            this.txtNewPassword.ShadowDecoration.Enabled = true;
            this.txtNewPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtNewPassword.Size = new System.Drawing.Size(349, 44);
            this.txtNewPassword.TabIndex = 18;
            this.txtNewPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtConfirmPassword.BorderRadius = 10;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11.2F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, 119);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtConfirmPassword.PlaceholderText = "Cornfirm password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.ShadowDecoration.BorderRadius = 10;
            this.txtConfirmPassword.ShadowDecoration.Enabled = true;
            this.txtConfirmPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.txtConfirmPassword.Size = new System.Drawing.Size(349, 44);
            this.txtConfirmPassword.TabIndex = 19;
            this.txtConfirmPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnResetPassword.BorderColor = System.Drawing.Color.Transparent;
            this.btnResetPassword.BorderRadius = 10;
            this.btnResetPassword.BorderThickness = 1;
            this.btnResetPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetPassword.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.btnResetPassword.FillColor2 = System.Drawing.Color.Teal;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnResetPassword.Location = new System.Drawing.Point(105, 181);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.ShadowDecoration.BorderRadius = 15;
            this.btnResetPassword.ShadowDecoration.Depth = 50;
            this.btnResetPassword.ShadowDecoration.Enabled = true;
            this.btnResetPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.btnResetPassword.Size = new System.Drawing.Size(180, 50);
            this.btnResetPassword.TabIndex = 139;
            this.btnResetPassword.Text = "Reset Password";
            // 
            // Form_ForgotPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(398, 415);
            this.Controls.Add(this.guna2GradientPanel12);
            this.Controls.Add(this.panelStep1);
            this.Controls.Add(this.panelStep2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forgot Password";
            this.Load += new System.EventHandler(this.Form_ForgotPassword_Load);
            this.panelStep2.ResumeLayout(false);
            this.panelStep2.PerformLayout();
            this.panelStep1.ResumeLayout(false);
            this.panelStep1.PerformLayout();
            this.guna2GradientPanel12.ResumeLayout(false);
            this.guna2GradientPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelStep2;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.Label lblPasswordRequirements;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelOTP;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Panel panelStep1;
        private Custom.MyGunaTextBox txtEmail;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel12;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private Guna.UI2.WinForms.Guna2GradientButton btnSendOTP;
        private Custom.MyGunaTextBox txtOTP;
        private Guna.UI2.WinForms.Guna2GradientButton btnVerify;
        private Custom.MyGunaTextBox txtConfirmPassword;
        private Custom.MyGunaTextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnResetPassword;
    }
}