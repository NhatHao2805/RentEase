namespace GUI
{
    partial class Form1
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
            this.buttonXemPass2 = new System.Windows.Forms.Button();
            this.buttonXemPass1 = new System.Windows.Forms.Button();
            this.labelMK_DK2 = new System.Windows.Forms.Label();
            this.labelMK_DK1 = new System.Windows.Forms.Label();
            this.labelTK_DK = new System.Windows.Forms.Label();
            this.textBoxMK_DK2 = new System.Windows.Forms.TextBox();
            this.textBoxMK_DK1 = new System.Windows.Forms.TextBox();
            this.textBoxTK_DK = new System.Windows.Forms.TextBox();
            this.buttonDangKy2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.buttonXemPass = new System.Windows.Forms.Button();
            this.textBoxTK_DN = new System.Windows.Forms.TextBox();
            this.textBoxMK_DN = new System.Windows.Forms.TextBox();
            this.labelTK_DN = new System.Windows.Forms.Label();
            this.labelMK_DN = new System.Windows.Forms.Label();
            this.buttonDangNhap1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonXemPass2
            // 
            this.buttonXemPass2.Location = new System.Drawing.Point(691, 258);
            this.buttonXemPass2.Name = "buttonXemPass2";
            this.buttonXemPass2.Size = new System.Drawing.Size(25, 23);
            this.buttonXemPass2.TabIndex = 9;
            this.buttonXemPass2.UseVisualStyleBackColor = true;
            this.buttonXemPass2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass2_MouseDown);
            this.buttonXemPass2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass2_MouseUp);
            // 
            // buttonXemPass1
            // 
            this.buttonXemPass1.Location = new System.Drawing.Point(691, 187);
            this.buttonXemPass1.Name = "buttonXemPass1";
            this.buttonXemPass1.Size = new System.Drawing.Size(25, 23);
            this.buttonXemPass1.TabIndex = 8;
            this.buttonXemPass1.UseVisualStyleBackColor = true;
            this.buttonXemPass1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass1_MouseDown);
            this.buttonXemPass1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXemPass1_MouseUp);
            // 
            // labelMK_DK2
            // 
            this.labelMK_DK2.AutoSize = true;
            this.labelMK_DK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.labelMK_DK2.Location = new System.Drawing.Point(469, 232);
            this.labelMK_DK2.Name = "labelMK_DK2";
            this.labelMK_DK2.Size = new System.Drawing.Size(117, 16);
            this.labelMK_DK2.TabIndex = 7;
            this.labelMK_DK2.Text = "Mật khẩu xác nhận";
            // 
            // labelMK_DK1
            // 
            this.labelMK_DK1.AutoSize = true;
            this.labelMK_DK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.labelMK_DK1.Location = new System.Drawing.Point(469, 161);
            this.labelMK_DK1.Name = "labelMK_DK1";
            this.labelMK_DK1.Size = new System.Drawing.Size(61, 16);
            this.labelMK_DK1.TabIndex = 6;
            this.labelMK_DK1.Text = "Mật khẩu";
            // 
            // labelTK_DK
            // 
            this.labelTK_DK.AutoSize = true;
            this.labelTK_DK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.labelTK_DK.Location = new System.Drawing.Point(469, 79);
            this.labelTK_DK.Name = "labelTK_DK";
            this.labelTK_DK.Size = new System.Drawing.Size(67, 16);
            this.labelTK_DK.TabIndex = 5;
            this.labelTK_DK.Text = "Tài khoản";
            // 
            // textBoxMK_DK2
            // 
            this.textBoxMK_DK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMK_DK2.Location = new System.Drawing.Point(472, 251);
            this.textBoxMK_DK2.Multiline = true;
            this.textBoxMK_DK2.Name = "textBoxMK_DK2";
            this.textBoxMK_DK2.PasswordChar = '*';
            this.textBoxMK_DK2.Size = new System.Drawing.Size(255, 40);
            this.textBoxMK_DK2.TabIndex = 4;
            // 
            // textBoxMK_DK1
            // 
            this.textBoxMK_DK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMK_DK1.Location = new System.Drawing.Point(472, 180);
            this.textBoxMK_DK1.Multiline = true;
            this.textBoxMK_DK1.Name = "textBoxMK_DK1";
            this.textBoxMK_DK1.PasswordChar = '*';
            this.textBoxMK_DK1.Size = new System.Drawing.Size(255, 40);
            this.textBoxMK_DK1.TabIndex = 3;
            // 
            // textBoxTK_DK
            // 
            this.textBoxTK_DK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxTK_DK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTK_DK.Location = new System.Drawing.Point(472, 103);
            this.textBoxTK_DK.Multiline = true;
            this.textBoxTK_DK.Name = "textBoxTK_DK";
            this.textBoxTK_DK.Size = new System.Drawing.Size(255, 40);
            this.textBoxTK_DK.TabIndex = 2;
            // 
            // buttonDangKy2
            // 
            this.buttonDangKy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonDangKy2.Location = new System.Drawing.Point(472, 313);
            this.buttonDangKy2.Name = "buttonDangKy2";
            this.buttonDangKy2.Size = new System.Drawing.Size(255, 40);
            this.buttonDangKy2.TabIndex = 1;
            this.buttonDangKy2.Text = "Đăng ký";
            this.buttonDangKy2.UseVisualStyleBackColor = true;
            this.buttonDangKy2.Click += new System.EventHandler(this.buttonDangKy2_Click);
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
            this.buttonXemPass.Location = new System.Drawing.Point(281, 187);
            this.buttonXemPass.Name = "buttonXemPass";
            this.buttonXemPass.Size = new System.Drawing.Size(25, 23);
            this.buttonXemPass.TabIndex = 18;
            this.buttonXemPass.UseVisualStyleBackColor = true;
            // 
            // textBoxTK_DN
            // 
            this.textBoxTK_DN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxTK_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTK_DN.Location = new System.Drawing.Point(68, 103);
            this.textBoxTK_DN.Multiline = true;
            this.textBoxTK_DN.Name = "textBoxTK_DN";
            this.textBoxTK_DN.Size = new System.Drawing.Size(250, 40);
            this.textBoxTK_DN.TabIndex = 16;
            // 
            // textBoxMK_DN
            // 
            this.textBoxMK_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMK_DN.Location = new System.Drawing.Point(70, 180);
            this.textBoxMK_DN.Multiline = true;
            this.textBoxMK_DN.Name = "textBoxMK_DN";
            this.textBoxMK_DN.PasswordChar = '*';
            this.textBoxMK_DN.Size = new System.Drawing.Size(248, 40);
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(0, 444);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 500);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(288, 425);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 16);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Đăng ký";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(405, 425);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(72, 16);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Đăng nhập";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.buttonXemPass);
            this.Controls.Add(this.textBoxTK_DN);
            this.Controls.Add(this.textBoxMK_DN);
            this.Controls.Add(this.labelTK_DN);
            this.Controls.Add(this.labelMK_DN);
            this.Controls.Add(this.buttonDangNhap1);
            this.Controls.Add(this.buttonXemPass2);
            this.Controls.Add(this.buttonXemPass1);
            this.Controls.Add(this.labelMK_DK2);
            this.Controls.Add(this.labelMK_DK1);
            this.Controls.Add(this.textBoxTK_DK);
            this.Controls.Add(this.labelTK_DK);
            this.Controls.Add(this.textBoxMK_DK2);
            this.Controls.Add(this.buttonDangKy2);
            this.Controls.Add(this.textBoxMK_DK1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelMK_DK2;
        private System.Windows.Forms.Label labelMK_DK1;
        private System.Windows.Forms.Label labelTK_DK;
        private System.Windows.Forms.TextBox textBoxMK_DK2;
        private System.Windows.Forms.TextBox textBoxMK_DK1;
        private System.Windows.Forms.TextBox textBoxTK_DK;
        private System.Windows.Forms.Button buttonDangKy2;
        private System.Windows.Forms.Button buttonXemPass2;
        private System.Windows.Forms.Button buttonXemPass1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button buttonXemPass;
        private System.Windows.Forms.TextBox textBoxTK_DN;
        private System.Windows.Forms.TextBox textBoxMK_DN;
        private System.Windows.Forms.Label labelTK_DN;
        private System.Windows.Forms.Label labelMK_DN;
        private System.Windows.Forms.Button buttonDangNhap1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

