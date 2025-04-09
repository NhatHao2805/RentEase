namespace GUI
{
    partial class Form_AddParkingArea
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
            this.address_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.abc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.type_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.add_btn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.capacity_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2AnimateWindow3 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.SuspendLayout();
            // 
            // address_tb
            // 
            this.address_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.address_tb.DefaultText = "";
            this.address_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.address_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.address_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.address_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.address_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.address_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.address_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.address_tb.Location = new System.Drawing.Point(155, 27);
            this.address_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.address_tb.Name = "address_tb";
            this.address_tb.PlaceholderText = "";
            this.address_tb.SelectedText = "";
            this.address_tb.Size = new System.Drawing.Size(357, 36);
            this.address_tb.TabIndex = 108;
            // 
            // abc
            // 
            this.abc.BackColor = System.Drawing.Color.Transparent;
            this.abc.Location = new System.Drawing.Point(36, 36);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(43, 18);
            this.abc.TabIndex = 107;
            this.abc.Text = "Địa chỉ";
            // 
            // type_cb
            // 
            this.type_cb.BackColor = System.Drawing.Color.Transparent;
            this.type_cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.type_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_cb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.type_cb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.type_cb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.type_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.type_cb.ItemHeight = 30;
            this.type_cb.Location = new System.Drawing.Point(155, 88);
            this.type_cb.Name = "type_cb";
            this.type_cb.Size = new System.Drawing.Size(357, 36);
            this.type_cb.TabIndex = 106;
            // 
            // add_btn
            // 
            this.add_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add_btn.ForeColor = System.Drawing.Color.White;
            this.add_btn.Location = new System.Drawing.Point(155, 223);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(180, 45);
            this.add_btn.TabIndex = 105;
            this.add_btn.Text = "Thêm";
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click_1);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(36, 162);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(58, 18);
            this.guna2HtmlLabel8.TabIndex = 103;
            this.guna2HtmlLabel8.Text = "Sức chứa";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(36, 97);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(59, 18);
            this.guna2HtmlLabel2.TabIndex = 102;
            this.guna2HtmlLabel2.Text = "Phân loại";
            // 
            // capacity_tb
            // 
            this.capacity_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.capacity_tb.DefaultText = "";
            this.capacity_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.capacity_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.capacity_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.capacity_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.capacity_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.capacity_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.capacity_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.capacity_tb.Location = new System.Drawing.Point(155, 153);
            this.capacity_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.capacity_tb.Name = "capacity_tb";
            this.capacity_tb.PlaceholderText = "";
            this.capacity_tb.SelectedText = "";
            this.capacity_tb.Size = new System.Drawing.Size(357, 36);
            this.capacity_tb.TabIndex = 101;
            // 
            // Form_AddParkingArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 306);
            this.Controls.Add(this.address_tb);
            this.Controls.Add(this.abc);
            this.Controls.Add(this.type_cb);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.capacity_tb);
            this.Name = "Form_AddParkingArea";
            this.Text = "Form_AddParkingArea";
            this.Load += new System.EventHandler(this.Form_AddParkingArea_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox address_tb;
        private Guna.UI2.WinForms.Guna2HtmlLabel abc;
        private Guna.UI2.WinForms.Guna2ComboBox type_cb;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button add_btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox capacity_tb;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow3;
    }
}