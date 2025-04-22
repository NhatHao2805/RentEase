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
            this.panelStep1 = new System.Windows.Forms.Panel();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.labelOTP = new System.Windows.Forms.Label();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();

            this.panelStep2 = new System.Windows.Forms.Panel();
            this.lblPasswordRequirements = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();

            this.panelStep1.SuspendLayout();
            this.panelStep2.SuspendLayout();
            this.SuspendLayout();

            // panelStep1
            this.panelStep1.Controls.Add(this.lblCountdown);
            this.panelStep1.Controls.Add(this.btnVerify);
            this.panelStep1.Controls.Add(this.txtOTP);
            this.panelStep1.Controls.Add(this.labelOTP);
            this.panelStep1.Controls.Add(this.btnSendOTP);
            this.panelStep1.Controls.Add(this.txtEmail);
            this.panelStep1.Controls.Add(this.labelEmail);
            this.panelStep1.Location = new System.Drawing.Point(12, 12);
            this.panelStep1.Name = "panelStep1";
            this.panelStep1.Size = new System.Drawing.Size(355, 230);
            this.panelStep1.TabIndex = 0;

            // panelStep2
            this.panelStep2.Controls.Add(this.lblPasswordRequirements);
            this.panelStep2.Controls.Add(this.btnResetPassword);
            this.panelStep2.Controls.Add(this.txtConfirmPassword);
            this.panelStep2.Controls.Add(this.labelConfirmPassword);
            this.panelStep2.Controls.Add(this.txtNewPassword);
            this.panelStep2.Controls.Add(this.labelNewPassword);
            this.panelStep2.Location = new System.Drawing.Point(12, 12);
            this.panelStep2.Name = "panelStep2";
            this.panelStep2.Size = new System.Drawing.Size(355, 230);
            this.panelStep2.TabIndex = 1;
            this.panelStep2.Visible = false;

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(4, 6);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 16);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(4, 26);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(345, 22);
            this.txtEmail.TabIndex = 1;

            // btnSendOTP
            this.btnSendOTP.Location = new System.Drawing.Point(4, 58);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(345, 28);
            this.btnSendOTP.TabIndex = 2;
            this.btnSendOTP.Text = "Send OTP";
            this.btnSendOTP.UseVisualStyleBackColor = true;
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);

            // labelOTP
            this.labelOTP.AutoSize = true;
            this.labelOTP.Location = new System.Drawing.Point(4, 98);
            this.labelOTP.Name = "labelOTP";
            this.labelOTP.Size = new System.Drawing.Size(38, 16);
            this.labelOTP.TabIndex = 3;
            this.labelOTP.Text = "OTP:";

            // txtOTP
            this.txtOTP.Enabled = false;
            this.txtOTP.Location = new System.Drawing.Point(4, 118);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(345, 22);
            this.txtOTP.TabIndex = 4;

            // btnVerify
            this.btnVerify.Enabled = false;
            this.btnVerify.Location = new System.Drawing.Point(4, 150);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(345, 28);
            this.btnVerify.TabIndex = 5;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            // lblCountdown
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(4, 190);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(0, 16);
            this.lblCountdown.TabIndex = 6;

            // labelNewPassword
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(4, 6);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(100, 16);
            this.labelNewPassword.TabIndex = 0;
            this.labelNewPassword.Text = "New Password:";

            // txtNewPassword
            this.txtNewPassword.Location = new System.Drawing.Point(4, 26);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(345, 22);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);

            // labelConfirmPassword
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(4, 58);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(118, 16);
            this.labelConfirmPassword.TabIndex = 2;
            this.labelConfirmPassword.Text = "Confirm Password:";

            // txtConfirmPassword
            this.txtConfirmPassword.Location = new System.Drawing.Point(4, 78);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(345, 22);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);

            // btnResetPassword
            this.btnResetPassword.Location = new System.Drawing.Point(4, 110);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(345, 28);
            this.btnResetPassword.TabIndex = 4;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // lblPasswordRequirements
            this.lblPasswordRequirements.AutoSize = true;
            this.lblPasswordRequirements.Location = new System.Drawing.Point(4, 150);
            this.lblPasswordRequirements.Name = "lblPasswordRequirements";
            this.lblPasswordRequirements.Size = new System.Drawing.Size(193, 64);
            this.lblPasswordRequirements.TabIndex = 5;
            this.lblPasswordRequirements.Text = "Password must contain:\n• At least 8 characters\n• At least one number\n• At least one special character";

            // Form_ForgotPassword
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 260);
            this.Controls.Add(this.panelStep1);
            this.Controls.Add(this.panelStep2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forgot Password";
            this.panelStep1.ResumeLayout(false);
            this.panelStep1.PerformLayout();
            this.panelStep2.ResumeLayout(false);
            this.panelStep2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelStep1;
        private System.Windows.Forms.Panel panelStep2;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSendOTP;
        private System.Windows.Forms.Label labelOTP;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblPasswordRequirements;
    }
}