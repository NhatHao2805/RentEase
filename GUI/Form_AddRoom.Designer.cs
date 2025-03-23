namespace GUI
{
    partial class Form_AddRoom
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
            this.RoomID_tb = new System.Windows.Forms.TextBox();
            this.convenient_tb = new System.Windows.Forms.TextBox();
            this.area_tb = new System.Windows.Forms.TextBox();
            this.price_tb = new System.Windows.Forms.TextBox();
            this.type_cb = new System.Windows.Forms.ComboBox();
            this.birth_datepicker = new System.Windows.Forms.DateTimePicker();
            this.add_bt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.day_tb = new System.Windows.Forms.TextBox();
            this.month_tb = new System.Windows.Forms.TextBox();
            this.year_tb = new System.Windows.Forms.TextBox();
            this.status_grbox = new System.Windows.Forms.GroupBox();
            this.HetHan_chbox = new System.Windows.Forms.CheckBox();
            this.SapHetHan_chbox = new System.Windows.Forms.CheckBox();
            this.DangNoTien_chbox = new System.Windows.Forms.CheckBox();
            this.DangCoc_chbox = new System.Windows.Forms.CheckBox();
            this.DangKetThuc_chbox = new System.Windows.Forms.CheckBox();
            this.DangTrong_chbox = new System.Windows.Forms.CheckBox();
            this.DangO_chbox = new System.Windows.Forms.CheckBox();
            this.status_grbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoomID_tb
            // 
            this.RoomID_tb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RoomID_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RoomID_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.RoomID_tb.Location = new System.Drawing.Point(15, 30);
            this.RoomID_tb.Multiline = true;
            this.RoomID_tb.Name = "RoomID_tb";
            this.RoomID_tb.Size = new System.Drawing.Size(195, 23);
            this.RoomID_tb.TabIndex = 0;
            // 
            // convenient_tb
            // 
            this.convenient_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.convenient_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.convenient_tb.Location = new System.Drawing.Point(15, 69);
            this.convenient_tb.Multiline = true;
            this.convenient_tb.Name = "convenient_tb";
            this.convenient_tb.Size = new System.Drawing.Size(195, 23);
            this.convenient_tb.TabIndex = 2;
            // 
            // area_tb
            // 
            this.area_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.area_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.area_tb.Location = new System.Drawing.Point(15, 150);
            this.area_tb.Multiline = true;
            this.area_tb.Name = "area_tb";
            this.area_tb.Size = new System.Drawing.Size(195, 23);
            this.area_tb.TabIndex = 3;
            this.area_tb.TextChanged += new System.EventHandler(this.area_tb_TextChanged);
            // 
            // price_tb
            // 
            this.price_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.price_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.price_tb.Location = new System.Drawing.Point(15, 109);
            this.price_tb.Multiline = true;
            this.price_tb.Name = "price_tb";
            this.price_tb.Size = new System.Drawing.Size(195, 23);
            this.price_tb.TabIndex = 4;
            this.price_tb.TextChanged += new System.EventHandler(this.price_tb_TextChanged);
            // 
            // type_cb
            // 
            this.type_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.type_cb.FormattingEnabled = true;
            this.type_cb.Location = new System.Drawing.Point(258, 30);
            this.type_cb.Name = "type_cb";
            this.type_cb.Size = new System.Drawing.Size(244, 30);
            this.type_cb.TabIndex = 5;
            // 
            // birth_datepicker
            // 
            this.birth_datepicker.Location = new System.Drawing.Point(190, 209);
            this.birth_datepicker.Name = "birth_datepicker";
            this.birth_datepicker.Size = new System.Drawing.Size(20, 24);
            this.birth_datepicker.TabIndex = 7;
            // 
            // add_bt
            // 
            this.add_bt.Location = new System.Drawing.Point(190, 144);
            this.add_bt.Name = "add_bt";
            this.add_bt.Size = new System.Drawing.Size(75, 30);
            this.add_bt.TabIndex = 9;
            this.add_bt.Text = "Thêm";
            this.add_bt.UseVisualStyleBackColor = true;
            this.add_bt.Click += new System.EventHandler(this.add_bt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Phân loại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ngày bảo trì gần nhất";
            // 
            // day_tb
            // 
            this.day_tb.BackColor = System.Drawing.Color.White;
            this.day_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.day_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.day_tb.Location = new System.Drawing.Point(15, 209);
            this.day_tb.Multiline = true;
            this.day_tb.Name = "day_tb";
            this.day_tb.ReadOnly = true;
            this.day_tb.Size = new System.Drawing.Size(52, 26);
            this.day_tb.TabIndex = 71;
            this.day_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // month_tb
            // 
            this.month_tb.BackColor = System.Drawing.Color.White;
            this.month_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.month_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.month_tb.Location = new System.Drawing.Point(73, 209);
            this.month_tb.Multiline = true;
            this.month_tb.Name = "month_tb";
            this.month_tb.ReadOnly = true;
            this.month_tb.Size = new System.Drawing.Size(47, 26);
            this.month_tb.TabIndex = 72;
            this.month_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // year_tb
            // 
            this.year_tb.BackColor = System.Drawing.Color.White;
            this.year_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.year_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.year_tb.Location = new System.Drawing.Point(126, 209);
            this.year_tb.Multiline = true;
            this.year_tb.Name = "year_tb";
            this.year_tb.ReadOnly = true;
            this.year_tb.Size = new System.Drawing.Size(51, 26);
            this.year_tb.TabIndex = 73;
            this.year_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // status_grbox
            // 
            this.status_grbox.Controls.Add(this.HetHan_chbox);
            this.status_grbox.Controls.Add(this.SapHetHan_chbox);
            this.status_grbox.Controls.Add(this.DangNoTien_chbox);
            this.status_grbox.Controls.Add(this.DangCoc_chbox);
            this.status_grbox.Controls.Add(this.DangKetThuc_chbox);
            this.status_grbox.Controls.Add(this.DangTrong_chbox);
            this.status_grbox.Controls.Add(this.add_bt);
            this.status_grbox.Controls.Add(this.DangO_chbox);
            this.status_grbox.Location = new System.Drawing.Point(258, 69);
            this.status_grbox.Name = "status_grbox";
            this.status_grbox.Size = new System.Drawing.Size(379, 183);
            this.status_grbox.TabIndex = 74;
            this.status_grbox.TabStop = false;
            this.status_grbox.Text = "Tình trạng";
            // 
            // HetHan_chbox
            // 
            this.HetHan_chbox.AutoSize = true;
            this.HetHan_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.HetHan_chbox.Location = new System.Drawing.Point(19, 147);
            this.HetHan_chbox.Name = "HetHan_chbox";
            this.HetHan_chbox.Size = new System.Drawing.Size(211, 28);
            this.HetHan_chbox.TabIndex = 87;
            this.HetHan_chbox.Text = "Đã hết hạn hộp đồng";
            this.HetHan_chbox.UseVisualStyleBackColor = true;
            this.HetHan_chbox.CheckedChanged += new System.EventHandler(this.HetHan_chbox_CheckedChanged);
            // 
            // SapHetHan_chbox
            // 
            this.SapHetHan_chbox.AutoSize = true;
            this.SapHetHan_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SapHetHan_chbox.Location = new System.Drawing.Point(191, 110);
            this.SapHetHan_chbox.Name = "SapHetHan_chbox";
            this.SapHetHan_chbox.Size = new System.Drawing.Size(221, 28);
            this.SapHetHan_chbox.TabIndex = 86;
            this.SapHetHan_chbox.Text = "Sắp hết hạn hợp đồng";
            this.SapHetHan_chbox.UseVisualStyleBackColor = true;
            this.SapHetHan_chbox.CheckedChanged += new System.EventHandler(this.SapHetHan_chbox_CheckedChanged);
            // 
            // DangNoTien_chbox
            // 
            this.DangNoTien_chbox.AutoSize = true;
            this.DangNoTien_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DangNoTien_chbox.Location = new System.Drawing.Point(19, 110);
            this.DangNoTien_chbox.Name = "DangNoTien_chbox";
            this.DangNoTien_chbox.Size = new System.Drawing.Size(139, 28);
            this.DangNoTien_chbox.TabIndex = 85;
            this.DangNoTien_chbox.Text = "Đang nợ tiền";
            this.DangNoTien_chbox.UseVisualStyleBackColor = true;
            this.DangNoTien_chbox.CheckedChanged += new System.EventHandler(this.DangNoTien_chbox_CheckedChanged);
            // 
            // DangCoc_chbox
            // 
            this.DangCoc_chbox.AutoSize = true;
            this.DangCoc_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DangCoc_chbox.Location = new System.Drawing.Point(191, 68);
            this.DangCoc_chbox.Name = "DangCoc_chbox";
            this.DangCoc_chbox.Size = new System.Drawing.Size(181, 28);
            this.DangCoc_chbox.TabIndex = 84;
            this.DangCoc_chbox.Text = "Đang cọc giữ chỗ";
            this.DangCoc_chbox.UseVisualStyleBackColor = true;
            this.DangCoc_chbox.CheckedChanged += new System.EventHandler(this.DangCoc_chbox_CheckedChanged);
            // 
            // DangKetThuc_chbox
            // 
            this.DangKetThuc_chbox.AutoSize = true;
            this.DangKetThuc_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DangKetThuc_chbox.Location = new System.Drawing.Point(19, 68);
            this.DangKetThuc_chbox.Name = "DangKetThuc_chbox";
            this.DangKetThuc_chbox.Size = new System.Drawing.Size(184, 28);
            this.DangKetThuc_chbox.TabIndex = 83;
            this.DangKetThuc_chbox.Text = "Đang báo kết thúc";
            this.DangKetThuc_chbox.UseVisualStyleBackColor = true;
            this.DangKetThuc_chbox.CheckedChanged += new System.EventHandler(this.DangKetThuc_chbox_CheckedChanged);
            // 
            // DangTrong_chbox
            // 
            this.DangTrong_chbox.AutoSize = true;
            this.DangTrong_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DangTrong_chbox.Location = new System.Drawing.Point(191, 30);
            this.DangTrong_chbox.Name = "DangTrong_chbox";
            this.DangTrong_chbox.Size = new System.Drawing.Size(125, 28);
            this.DangTrong_chbox.TabIndex = 82;
            this.DangTrong_chbox.Text = "Đang trống";
            this.DangTrong_chbox.UseVisualStyleBackColor = true;
            this.DangTrong_chbox.CheckedChanged += new System.EventHandler(this.DangTrong_chbox_CheckedChanged);
            // 
            // DangO_chbox
            // 
            this.DangO_chbox.AutoSize = true;
            this.DangO_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DangO_chbox.Location = new System.Drawing.Point(19, 29);
            this.DangO_chbox.Name = "DangO_chbox";
            this.DangO_chbox.Size = new System.Drawing.Size(93, 28);
            this.DangO_chbox.TabIndex = 81;
            this.DangO_chbox.Text = "Đang ở";
            this.DangO_chbox.UseVisualStyleBackColor = true;
            this.DangO_chbox.CheckedChanged += new System.EventHandler(this.DangO_chbox_CheckedChanged);
            // 
            // Form_AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 260);
            this.Controls.Add(this.status_grbox);
            this.Controls.Add(this.year_tb);
            this.Controls.Add(this.month_tb);
            this.Controls.Add(this.day_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.birth_datepicker);
            this.Controls.Add(this.type_cb);
            this.Controls.Add(this.price_tb);
            this.Controls.Add(this.area_tb);
            this.Controls.Add(this.convenient_tb);
            this.Controls.Add(this.RoomID_tb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Name = "Form_AddRoom";
            this.ShowIcon = false;
            this.Text = "Thêm phòng";
            this.Load += new System.EventHandler(this.Form_AddRoom_Load);
            this.status_grbox.ResumeLayout(false);
            this.status_grbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RoomID_tb;
        private System.Windows.Forms.TextBox convenient_tb;
        private System.Windows.Forms.TextBox area_tb;
        private System.Windows.Forms.TextBox price_tb;
        private System.Windows.Forms.ComboBox type_cb;
        private System.Windows.Forms.DateTimePicker birth_datepicker;
        private System.Windows.Forms.Button add_bt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox day_tb;
        private System.Windows.Forms.TextBox month_tb;
        private System.Windows.Forms.TextBox year_tb;
        private System.Windows.Forms.GroupBox status_grbox;
        private System.Windows.Forms.CheckBox HetHan_chbox;
        private System.Windows.Forms.CheckBox SapHetHan_chbox;
        private System.Windows.Forms.CheckBox DangNoTien_chbox;
        private System.Windows.Forms.CheckBox DangCoc_chbox;
        private System.Windows.Forms.CheckBox DangKetThuc_chbox;
        private System.Windows.Forms.CheckBox DangTrong_chbox;
        private System.Windows.Forms.CheckBox DangO_chbox;
    }
}