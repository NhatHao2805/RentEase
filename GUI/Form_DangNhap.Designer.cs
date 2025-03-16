namespace GUI
{
    partial class Form_DangNhap
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
            this.btnClose = new System.Windows.Forms.Button();
            this.buttonXemPass = new System.Windows.Forms.Button();
            this.textBoxTK_DN = new System.Windows.Forms.TextBox();
            this.textBoxMK_DN = new System.Windows.Forms.TextBox();
            this.labelTK_DN = new System.Windows.Forms.Label();
            this.labelMK_DN = new System.Windows.Forms.Label();
            this.buttonDangNhap1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnClose.Location = new System.Drawing.Point(762, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // buttonXemPass
            // 
            this.buttonXemPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonXemPass.Location = new System.Drawing.Point(324, 185);
            this.buttonXemPass.Name = "buttonXemPass";
            this.buttonXemPass.Size = new System.Drawing.Size(20, 20);
            this.buttonXemPass.TabIndex = 18;
            this.buttonXemPass.UseVisualStyleBackColor = true;
            this.buttonXemPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseDown);
            this.buttonXemPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass_MouseUp);
            // 
            // textBoxTK_DN
            // 
            this.textBoxTK_DN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxTK_DN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTK_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTK_DN.Location = new System.Drawing.Point(68, 103);
            this.textBoxTK_DN.Multiline = true;
            this.textBoxTK_DN.Name = "textBoxTK_DN";
            this.textBoxTK_DN.Size = new System.Drawing.Size(248, 26);
            this.textBoxTK_DN.TabIndex = 16;
            // 
            // textBoxMK_DN
            // 
            this.textBoxMK_DN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMK_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMK_DN.Location = new System.Drawing.Point(70, 180);
            this.textBoxMK_DN.Multiline = true;
            this.textBoxMK_DN.Name = "textBoxMK_DN";
            this.textBoxMK_DN.PasswordChar = '*';
            this.textBoxMK_DN.Size = new System.Drawing.Size(248, 26);
            this.textBoxMK_DN.TabIndex = 17;
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
            this.labelMK_DN.Location = new System.Drawing.Point(67, 156);
            this.labelMK_DN.Name = "labelMK_DN";
            this.labelMK_DN.Size = new System.Drawing.Size(62, 16);
            this.labelMK_DN.TabIndex = 13;
            this.labelMK_DN.Text = "Mật Khẩu";
            // 
            // buttonDangNhap1
            // 
            this.buttonDangNhap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonDangNhap1.Location = new System.Drawing.Point(65, 242);
            this.buttonDangNhap1.Name = "buttonDangNhap1";
            this.buttonDangNhap1.Size = new System.Drawing.Size(253, 40);
            this.buttonDangNhap1.TabIndex = 14;
            this.buttonDangNhap1.Text = "Đăng nhập";
            this.buttonDangNhap1.UseVisualStyleBackColor = true;
            this.buttonDangNhap1.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(260, 285);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 16);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Đăng ký";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 468);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.buttonXemPass);
            this.Controls.Add(this.textBoxTK_DN);
            this.Controls.Add(this.textBoxMK_DN);
            this.Controls.Add(this.labelTK_DN);
            this.Controls.Add(this.labelMK_DN);
            this.Controls.Add(this.buttonDangNhap1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button buttonXemPass;
        private System.Windows.Forms.TextBox textBoxTK_DN;
        private System.Windows.Forms.TextBox textBoxMK_DN;
        private System.Windows.Forms.Label labelTK_DN;
        private System.Windows.Forms.Label labelMK_DN;
        private System.Windows.Forms.Button buttonDangNhap1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

