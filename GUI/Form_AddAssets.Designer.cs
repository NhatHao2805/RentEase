namespace GUI
{
    partial class Form_AddAssets
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
            this.add_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.assetID_tb = new System.Windows.Forms.TextBox();
            this.assetName_tb = new System.Windows.Forms.TextBox();
            this.price_tb = new System.Windows.Forms.TextBox();
            this.roomID_cb = new System.Windows.Forms.ComboBox();
            this.status_cb = new System.Windows.Forms.ComboBox();
            this.useDate_dtpicker = new System.Windows.Forms.DateTimePicker();
            this.selectAll_chbox = new System.Windows.Forms.CheckBox();
            this.roomID_chlistbox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(277, 434);
            this.add_btn.Name = "add_btn";
            this.add_btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.add_btn.Size = new System.Drawing.Size(80, 27);
            this.add_btn.TabIndex = 0;
            this.add_btn.Text = "Thêm";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã tài sản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên tài sản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã phòng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giá (VND)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tình trạng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày đưa vào sử dụng";
            // 
            // assetID_tb
            // 
            this.assetID_tb.Location = new System.Drawing.Point(111, 18);
            this.assetID_tb.Name = "assetID_tb";
            this.assetID_tb.Size = new System.Drawing.Size(246, 22);
            this.assetID_tb.TabIndex = 8;
            // 
            // assetName_tb
            // 
            this.assetName_tb.Location = new System.Drawing.Point(111, 71);
            this.assetName_tb.Name = "assetName_tb";
            this.assetName_tb.Size = new System.Drawing.Size(246, 22);
            this.assetName_tb.TabIndex = 9;
            // 
            // price_tb
            // 
            this.price_tb.Location = new System.Drawing.Point(111, 131);
            this.price_tb.Name = "price_tb";
            this.price_tb.Size = new System.Drawing.Size(246, 22);
            this.price_tb.TabIndex = 10;
            // 
            // roomID_cb
            // 
            this.roomID_cb.FormattingEnabled = true;
            this.roomID_cb.Location = new System.Drawing.Point(111, 239);
            this.roomID_cb.Name = "roomID_cb";
            this.roomID_cb.Size = new System.Drawing.Size(246, 24);
            this.roomID_cb.TabIndex = 11;
            // 
            // status_cb
            // 
            this.status_cb.FormattingEnabled = true;
            this.status_cb.Location = new System.Drawing.Point(111, 194);
            this.status_cb.Name = "status_cb";
            this.status_cb.Size = new System.Drawing.Size(246, 24);
            this.status_cb.TabIndex = 12;
            // 
            // useDate_dtpicker
            // 
            this.useDate_dtpicker.Location = new System.Drawing.Point(111, 378);
            this.useDate_dtpicker.Name = "useDate_dtpicker";
            this.useDate_dtpicker.Size = new System.Drawing.Size(246, 22);
            this.useDate_dtpicker.TabIndex = 15;
            // 
            // selectAll_chbox
            // 
            this.selectAll_chbox.AutoSize = true;
            this.selectAll_chbox.Location = new System.Drawing.Point(111, 304);
            this.selectAll_chbox.Name = "selectAll_chbox";
            this.selectAll_chbox.Size = new System.Drawing.Size(95, 20);
            this.selectAll_chbox.TabIndex = 16;
            this.selectAll_chbox.Text = "Chọn tất cả";
            this.selectAll_chbox.UseVisualStyleBackColor = true;
            this.selectAll_chbox.CheckedChanged += new System.EventHandler(this.selectAll_chbox_CheckedChanged);
            // 
            // roomID_chlistbox
            // 
            this.roomID_chlistbox.FormattingEnabled = true;
            this.roomID_chlistbox.Location = new System.Drawing.Point(111, 260);
            this.roomID_chlistbox.Name = "roomID_chlistbox";
            this.roomID_chlistbox.Size = new System.Drawing.Size(246, 38);
            this.roomID_chlistbox.TabIndex = 17;
            this.roomID_chlistbox.SelectedIndexChanged += new System.EventHandler(this.roomID_chlistbox_SelectedIndexChanged);
            // 
            // Form_AddAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 486);
            this.Controls.Add(this.roomID_chlistbox);
            this.Controls.Add(this.selectAll_chbox);
            this.Controls.Add(this.useDate_dtpicker);
            this.Controls.Add(this.status_cb);
            this.Controls.Add(this.roomID_cb);
            this.Controls.Add(this.price_tb);
            this.Controls.Add(this.assetName_tb);
            this.Controls.Add(this.assetID_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_btn);
            this.Name = "Form_AddAssets";
            this.ShowIcon = false;
            this.Text = "Thêm tài sản";
            this.Load += new System.EventHandler(this.Form_AddAssets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox assetID_tb;
        private System.Windows.Forms.TextBox assetName_tb;
        private System.Windows.Forms.TextBox price_tb;
        private System.Windows.Forms.ComboBox roomID_cb;
        private System.Windows.Forms.ComboBox status_cb;
        private System.Windows.Forms.DateTimePicker useDate_dtpicker;
        private System.Windows.Forms.CheckBox selectAll_chbox;
        private System.Windows.Forms.CheckedListBox roomID_chlistbox;
    }
}