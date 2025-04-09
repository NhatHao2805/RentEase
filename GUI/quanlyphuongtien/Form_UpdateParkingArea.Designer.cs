namespace GUI
{
    partial class Form_UpdateParkingArea
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
            this.guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.add_btn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.areaid_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2AnimateWindow3 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.type_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.capacity_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.address_tb = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // add_btn
            // 
            this.add_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add_btn.ForeColor = System.Drawing.Color.White;
            this.add_btn.Location = new System.Drawing.Point(201, 283);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(180, 45);
            this.add_btn.TabIndex = 105;
            this.add_btn.Text = "Thêm";
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(48, 222);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(58, 18);
            this.guna2HtmlLabel10.TabIndex = 104;
            this.guna2HtmlLabel10.Text = "Sức chứa";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(48, 99);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(43, 18);
            this.guna2HtmlLabel8.TabIndex = 103;
            this.guna2HtmlLabel8.Text = "Địa chỉ";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(48, 38);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(61, 18);
            this.guna2HtmlLabel2.TabIndex = 102;
            this.guna2HtmlLabel2.Text = "Mã bãi xe";
            // 
            // areaid_tb
            // 
            this.areaid_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.areaid_tb.DefaultText = "";
            this.areaid_tb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.areaid_tb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.areaid_tb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.areaid_tb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.areaid_tb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.areaid_tb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.areaid_tb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.areaid_tb.Location = new System.Drawing.Point(201, 29);
            this.areaid_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.areaid_tb.Name = "areaid_tb";
            this.areaid_tb.PlaceholderText = "";
            this.areaid_tb.SelectedText = "";
            this.areaid_tb.Size = new System.Drawing.Size(357, 36);
            this.areaid_tb.TabIndex = 101;
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
            this.type_cb.Location = new System.Drawing.Point(201, 153);
            this.type_cb.Name = "type_cb";
            this.type_cb.Size = new System.Drawing.Size(357, 36);
            this.type_cb.TabIndex = 111;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(48, 162);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(59, 18);
            this.guna2HtmlLabel1.TabIndex = 110;
            this.guna2HtmlLabel1.Text = "Phân loại";
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
            this.capacity_tb.Location = new System.Drawing.Point(201, 213);
            this.capacity_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.capacity_tb.Name = "capacity_tb";
            this.capacity_tb.PlaceholderText = "";
            this.capacity_tb.SelectedText = "";
            this.capacity_tb.Size = new System.Drawing.Size(357, 36);
            this.capacity_tb.TabIndex = 112;
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
            this.address_tb.Location = new System.Drawing.Point(201, 90);
            this.address_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.address_tb.Name = "address_tb";
            this.address_tb.PlaceholderText = "";
            this.address_tb.SelectedText = "";
            this.address_tb.Size = new System.Drawing.Size(357, 36);
            this.address_tb.TabIndex = 113;
            // 
            // Form_UpdateParkingArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 356);
            this.Controls.Add(this.address_tb);
            this.Controls.Add(this.capacity_tb);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.areaid_tb);
            this.Controls.Add(this.type_cb);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "Form_UpdateParkingArea";
            this.Text = "Form_UpdateParkingArea";
            this.Load += new System.EventHandler(this.Form_UpdateParkingArea_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button add_btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox areaid_tb;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow3;
        private Guna.UI2.WinForms.Guna2ComboBox type_cb;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox capacity_tb;
        private Guna.UI2.WinForms.Guna2TextBox address_tb;
    }
}