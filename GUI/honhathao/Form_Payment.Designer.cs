namespace GUI.honhathao
{
    partial class Form_Payment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitButton = new Guna.UI2.WinForms.Guna2Button();
            this.dgv_payment = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button_tk_contract = new Guna.UI2.WinForms.Guna2Button();
            this.timkiem_contract = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.button38 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button40 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button39 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button41 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_payment)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.exitButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 36);
            this.panel3.TabIndex = 23;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            // 
            // exitButton
            // 
            this.exitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::GUI.Properties.Resources.icon_2;
            this.exitButton.Location = new System.Drawing.Point(760, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 36);
            this.exitButton.TabIndex = 20;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dgv_payment
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_payment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_payment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_payment.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_payment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_payment.Location = new System.Drawing.Point(21, 195);
            this.dgv_payment.Name = "dgv_payment";
            this.dgv_payment.RowHeadersVisible = false;
            this.dgv_payment.RowHeadersWidth = 51;
            this.dgv_payment.RowTemplate.Height = 24;
            this.dgv_payment.Size = new System.Drawing.Size(745, 338);
            this.dgv_payment.TabIndex = 24;
            this.dgv_payment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_payment.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_payment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_payment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_payment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_payment.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_payment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_payment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_payment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_payment.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_payment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_payment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_payment.ThemeStyle.HeaderStyle.Height = 4;
            this.dgv_payment.ThemeStyle.ReadOnly = false;
            this.dgv_payment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_payment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_payment.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_payment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_payment.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_payment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_payment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(37, 146);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(121, 20);
            this.guna2HtmlLabel3.TabIndex = 42;
            this.guna2HtmlLabel3.Text = "Tìm kiếm theo tên";
            // 
            // button_tk_contract
            // 
            this.button_tk_contract.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_tk_contract.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_tk_contract.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_tk_contract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_tk_contract.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_tk_contract.ForeColor = System.Drawing.Color.White;
            this.button_tk_contract.Location = new System.Drawing.Point(336, 142);
            this.button_tk_contract.Name = "button_tk_contract";
            this.button_tk_contract.Size = new System.Drawing.Size(107, 29);
            this.button_tk_contract.TabIndex = 41;
            this.button_tk_contract.Text = "Tìm kiếm";
            // 
            // timkiem_contract
            // 
            this.timkiem_contract.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.timkiem_contract.DefaultText = "";
            this.timkiem_contract.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.timkiem_contract.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.timkiem_contract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.timkiem_contract.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.timkiem_contract.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.timkiem_contract.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timkiem_contract.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.timkiem_contract.Location = new System.Drawing.Point(172, 142);
            this.timkiem_contract.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timkiem_contract.Name = "timkiem_contract";
            this.timkiem_contract.PlaceholderText = "";
            this.timkiem_contract.SelectedText = "";
            this.timkiem_contract.Size = new System.Drawing.Size(135, 29);
            this.timkiem_contract.TabIndex = 40;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.guna2GradientPanel1.Controls.Add(this.button38);
            this.guna2GradientPanel1.Controls.Add(this.button40);
            this.guna2GradientPanel1.Controls.Add(this.button39);
            this.guna2GradientPanel1.Controls.Add(this.button41);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(280, 53);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(508, 70);
            this.guna2GradientPanel1.TabIndex = 127;
            // 
            // button38
            // 
            this.button38.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button38.BackColor = System.Drawing.Color.Transparent;
            this.button38.BorderColor = System.Drawing.Color.Transparent;
            this.button38.BorderRadius = 33;
            this.button38.BorderThickness = 2;
            this.button38.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button38.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button38.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button38.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button38.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button38.FillColor = System.Drawing.Color.Transparent;
            this.button38.FillColor2 = System.Drawing.Color.Transparent;
            this.button38.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button38.ForeColor = System.Drawing.Color.Black;
            this.button38.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.button38.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button38.HoverState.FillColor = System.Drawing.Color.MintCream;
            this.button38.HoverState.FillColor2 = System.Drawing.Color.LightGreen;
            this.button38.Image = global::GUI.Properties.Resources.icons8_plus_240;
            this.button38.ImageSize = new System.Drawing.Size(50, 50);
            this.button38.Location = new System.Drawing.Point(23, 1);
            this.button38.Name = "button38";
            this.button38.PressedColor = System.Drawing.Color.Transparent;
            this.button38.ShadowDecoration.BorderRadius = 15;
            this.button38.ShadowDecoration.Depth = 50;
            this.button38.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.button38.Size = new System.Drawing.Size(66, 66);
            this.button38.TabIndex = 129;
            this.button38.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button38.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // button40
            // 
            this.button40.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button40.BackColor = System.Drawing.Color.Transparent;
            this.button40.BorderColor = System.Drawing.Color.SteelBlue;
            this.button40.BorderRadius = 10;
            this.button40.BorderThickness = 2;
            this.button40.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button40.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button40.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button40.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button40.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button40.FillColor = System.Drawing.Color.White;
            this.button40.FillColor2 = System.Drawing.Color.Lavender;
            this.button40.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button40.ForeColor = System.Drawing.Color.Black;
            this.button40.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.button40.Image = global::GUI.Properties.Resources.icons8_edit_901;
            this.button40.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button40.ImageSize = new System.Drawing.Size(22, 22);
            this.button40.Location = new System.Drawing.Point(95, 9);
            this.button40.Name = "button40";
            this.button40.ShadowDecoration.BorderRadius = 15;
            this.button40.ShadowDecoration.Depth = 50;
            this.button40.ShadowDecoration.Enabled = true;
            this.button40.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.button40.Size = new System.Drawing.Size(138, 50);
            this.button40.TabIndex = 128;
            this.button40.Text = "Chỉnh sửa";
            this.button40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button39
            // 
            this.button39.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button39.BackColor = System.Drawing.Color.Transparent;
            this.button39.BorderColor = System.Drawing.Color.SteelBlue;
            this.button39.BorderRadius = 10;
            this.button39.BorderThickness = 2;
            this.button39.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button39.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button39.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button39.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button39.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button39.FillColor = System.Drawing.Color.White;
            this.button39.FillColor2 = System.Drawing.Color.Lavender;
            this.button39.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button39.ForeColor = System.Drawing.Color.Maroon;
            this.button39.HoverState.BorderColor = System.Drawing.Color.Maroon;
            this.button39.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button39.HoverState.FillColor2 = System.Drawing.Color.Yellow;
            this.button39.Image = global::GUI.Properties.Resources.icons8_trash_128;
            this.button39.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button39.ImageOffset = new System.Drawing.Point(-5, 0);
            this.button39.ImageSize = new System.Drawing.Size(22, 22);
            this.button39.Location = new System.Drawing.Point(239, 9);
            this.button39.Name = "button39";
            this.button39.ShadowDecoration.BorderRadius = 15;
            this.button39.ShadowDecoration.Depth = 50;
            this.button39.ShadowDecoration.Enabled = true;
            this.button39.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.button39.Size = new System.Drawing.Size(80, 50);
            this.button39.TabIndex = 127;
            this.button39.Text = "Xóa";
            this.button39.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.button39.TextOffset = new System.Drawing.Point(3, 0);
            // 
            // button41
            // 
            this.button41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button41.BackColor = System.Drawing.Color.Transparent;
            this.button41.BorderColor = System.Drawing.Color.Transparent;
            this.button41.BorderRadius = 10;
            this.button41.BorderThickness = 1;
            this.button41.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button41.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button41.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button41.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button41.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button41.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.button41.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.button41.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.button41.ForeColor = System.Drawing.Color.White;
            this.button41.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button41.Location = new System.Drawing.Point(341, 9);
            this.button41.Name = "button41";
            this.button41.ShadowDecoration.BorderRadius = 15;
            this.button41.ShadowDecoration.Depth = 50;
            this.button41.ShadowDecoration.Enabled = true;
            this.button41.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, -7, 0, 5);
            this.button41.Size = new System.Drawing.Size(145, 50);
            this.button41.TabIndex = 125;
            this.button41.Text = "Xuất sang Excel";
            // 
            // Form_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.button_tk_contract);
            this.Controls.Add(this.timkiem_contract);
            this.Controls.Add(this.dgv_payment);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Payment";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_payment)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_payment;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button button_tk_contract;
        private Guna.UI2.WinForms.Guna2TextBox timkiem_contract;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientButton button38;
        private Guna.UI2.WinForms.Guna2GradientButton button40;
        private Guna.UI2.WinForms.Guna2GradientButton button39;
        private Guna.UI2.WinForms.Guna2GradientButton button41;
    }
}