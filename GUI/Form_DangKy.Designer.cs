namespace GUI
{
    partial class Form_DangKy
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
            this.username_tb = new System.Windows.Forms.TextBox();
            this.fullname_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.email_tb = new System.Windows.Forms.TextBox();
            this.numberphone_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.birthday_lb = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gender_lb = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.address_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.repassword_tb = new System.Windows.Forms.TextBox();
            this.gender_cb = new System.Windows.Forms.ComboBox();
            this.seePassword_1 = new System.Windows.Forms.CheckBox();
            this.seePassword_2 = new System.Windows.Forms.CheckBox();
            this.year_tb = new System.Windows.Forms.TextBox();
            this.month_tb = new System.Windows.Forms.TextBox();
            this.day_tb = new System.Windows.Forms.TextBox();
            this.birth_datepicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // username_tb
            // 
            this.username_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_tb.Location = new System.Drawing.Point(122, 62);
            this.username_tb.Multiline = true;
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(325, 26);
            this.username_tb.TabIndex = 0;
            // 
            // fullname_tb
            // 
            this.fullname_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fullname_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullname_tb.Location = new System.Drawing.Point(122, 110);
            this.fullname_tb.Multiline = true;
            this.fullname_tb.Name = "fullname_tb";
            this.fullname_tb.Size = new System.Drawing.Size(325, 26);
            this.fullname_tb.TabIndex = 1;
            // 
            // password_tb
            // 
            this.password_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_tb.Location = new System.Drawing.Point(122, 161);
            this.password_tb.Multiline = true;
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(325, 26);
            this.password_tb.TabIndex = 2;
            this.password_tb.TextChanged += new System.EventHandler(this.password_tb_TextChanged);
            // 
            // email_tb
            // 
            this.email_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_tb.Location = new System.Drawing.Point(122, 269);
            this.email_tb.Multiline = true;
            this.email_tb.Name = "email_tb";
            this.email_tb.Size = new System.Drawing.Size(325, 26);
            this.email_tb.TabIndex = 3;
            // 
            // numberphone_tb
            // 
            this.numberphone_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberphone_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberphone_tb.Location = new System.Drawing.Point(122, 432);
            this.numberphone_tb.Multiline = true;
            this.numberphone_tb.Name = "numberphone_tb";
            this.numberphone_tb.Size = new System.Drawing.Size(325, 26);
            this.numberphone_tb.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "username";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "email";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "password";
            this.label3.Visible = false;
            // 
            // birthday_lb
            // 
            this.birthday_lb.AutoSize = true;
            this.birthday_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthday_lb.Location = new System.Drawing.Point(123, 325);
            this.birthday_lb.Name = "birthday_lb";
            this.birthday_lb.Size = new System.Drawing.Size(73, 18);
            this.birthday_lb.TabIndex = 10;
            this.birthday_lb.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "address";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "numberphone";
            this.label6.Visible = false;
            // 
            // gender_lb
            // 
            this.gender_lb.AutoSize = true;
            this.gender_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender_lb.Location = new System.Drawing.Point(123, 368);
            this.gender_lb.Name = "gender_lb";
            this.gender_lb.Size = new System.Drawing.Size(62, 18);
            this.gender_lb.TabIndex = 13;
            this.gender_lb.Text = "Giới tính";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "fullname";
            this.label8.Visible = false;
            // 
            // address_tb
            // 
            this.address_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.address_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_tb.Location = new System.Drawing.Point(122, 493);
            this.address_tb.Multiline = true;
            this.address_tb.Name = "address_tb";
            this.address_tb.Size = new System.Drawing.Size(325, 26);
            this.address_tb.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "repassword";
            this.label9.Visible = false;
            // 
            // repassword_tb
            // 
            this.repassword_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.repassword_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repassword_tb.Location = new System.Drawing.Point(122, 216);
            this.repassword_tb.Multiline = true;
            this.repassword_tb.Name = "repassword_tb";
            this.repassword_tb.Size = new System.Drawing.Size(325, 26);
            this.repassword_tb.TabIndex = 16;
            this.repassword_tb.TextChanged += new System.EventHandler(this.repassword_tb_TextChanged);
            // 
            // gender_cb
            // 
            this.gender_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gender_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gender_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender_cb.FormattingEnabled = true;
            this.gender_cb.Location = new System.Drawing.Point(209, 365);
            this.gender_cb.Name = "gender_cb";
            this.gender_cb.Size = new System.Drawing.Size(104, 26);
            this.gender_cb.TabIndex = 19;
            // 
            // seePassword_1
            // 
            this.seePassword_1.AutoSize = true;
            this.seePassword_1.Location = new System.Drawing.Point(453, 166);
            this.seePassword_1.Name = "seePassword_1";
            this.seePassword_1.Size = new System.Drawing.Size(18, 17);
            this.seePassword_1.TabIndex = 20;
            this.seePassword_1.UseVisualStyleBackColor = true;
            this.seePassword_1.CheckedChanged += new System.EventHandler(this.seePassword_1_CheckedChanged);
            // 
            // seePassword_2
            // 
            this.seePassword_2.AutoSize = true;
            this.seePassword_2.Location = new System.Drawing.Point(453, 222);
            this.seePassword_2.Name = "seePassword_2";
            this.seePassword_2.Size = new System.Drawing.Size(18, 17);
            this.seePassword_2.TabIndex = 21;
            this.seePassword_2.UseVisualStyleBackColor = true;
            this.seePassword_2.CheckedChanged += new System.EventHandler(this.seePassword_2_CheckedChanged);
            // 
            // year_tb
            // 
            this.year_tb.BackColor = System.Drawing.Color.White;
            this.year_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.year_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year_tb.Location = new System.Drawing.Point(209, 325);
            this.year_tb.Multiline = true;
            this.year_tb.Name = "year_tb";
            this.year_tb.ReadOnly = true;
            this.year_tb.Size = new System.Drawing.Size(84, 26);
            this.year_tb.TabIndex = 70;
            // 
            // month_tb
            // 
            this.month_tb.BackColor = System.Drawing.Color.White;
            this.month_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.month_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month_tb.Location = new System.Drawing.Point(302, 325);
            this.month_tb.Multiline = true;
            this.month_tb.Name = "month_tb";
            this.month_tb.ReadOnly = true;
            this.month_tb.Size = new System.Drawing.Size(75, 26);
            this.month_tb.TabIndex = 71;
            this.month_tb.TextChanged += new System.EventHandler(this.month_tb_TextChanged);
            // 
            // day_tb
            // 
            this.day_tb.BackColor = System.Drawing.Color.White;
            this.day_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.day_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day_tb.Location = new System.Drawing.Point(385, 325);
            this.day_tb.Multiline = true;
            this.day_tb.Name = "day_tb";
            this.day_tb.ReadOnly = true;
            this.day_tb.Size = new System.Drawing.Size(62, 26);
            this.day_tb.TabIndex = 72;
            this.day_tb.TextChanged += new System.EventHandler(this.day_tb_TextChanged);
            // 
            // birth_datepicker
            // 
            this.birth_datepicker.Location = new System.Drawing.Point(452, 326);
            this.birth_datepicker.Name = "birth_datepicker";
            this.birth_datepicker.Size = new System.Drawing.Size(22, 22);
            this.birth_datepicker.TabIndex = 73;
            this.birth_datepicker.ValueChanged += new System.EventHandler(this.birth_datepicker_ValueChanged);
            // 
            // Form_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 606);
            this.Controls.Add(this.birth_datepicker);
            this.Controls.Add(this.day_tb);
            this.Controls.Add(this.month_tb);
            this.Controls.Add(this.year_tb);
            this.Controls.Add(this.seePassword_2);
            this.Controls.Add(this.seePassword_1);
            this.Controls.Add(this.gender_cb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.repassword_tb);
            this.Controls.Add(this.address_tb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gender_lb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.birthday_lb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberphone_tb);
            this.Controls.Add(this.email_tb);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.fullname_tb);
            this.Controls.Add(this.username_tb);
            this.Name = "Form_DangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.Form_DangKy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_tb;
        private System.Windows.Forms.TextBox fullname_tb;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.TextBox email_tb;
        private System.Windows.Forms.TextBox numberphone_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label birthday_lb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label gender_lb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox address_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox repassword_tb;
        private System.Windows.Forms.ComboBox gender_cb;
        private System.Windows.Forms.CheckBox seePassword_1;
        private System.Windows.Forms.CheckBox seePassword_2;
        private System.Windows.Forms.TextBox year_tb;
        private System.Windows.Forms.TextBox month_tb;
        private System.Windows.Forms.TextBox day_tb;
        private System.Windows.Forms.DateTimePicker birth_datepicker;
    }
}