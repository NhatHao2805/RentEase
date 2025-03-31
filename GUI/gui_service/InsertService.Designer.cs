namespace GUI.GUI_Service
{
    partial class InsertService
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
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.ServiceName = new Guna.UI2.WinForms.Guna2TextBox();
            this.ServiceName_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Cost_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Cost = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(310, 286);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(165, 45);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Thêm Dịch Vụ";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ServiceName
            // 
            this.ServiceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServiceName.DefaultText = "";
            this.ServiceName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ServiceName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ServiceName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ServiceName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ServiceName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ServiceName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ServiceName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ServiceName.Location = new System.Drawing.Point(310, 132);
            this.ServiceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.PlaceholderText = "";
            this.ServiceName.SelectedText = "";
            this.ServiceName.Size = new System.Drawing.Size(381, 48);
            this.ServiceName.TabIndex = 1;
            // 
            // ServiceName_Label
            // 
            this.ServiceName_Label.BackColor = System.Drawing.Color.Transparent;
            this.ServiceName_Label.Location = new System.Drawing.Point(143, 146);
            this.ServiceName_Label.MinimumSize = new System.Drawing.Size(120, 30);
            this.ServiceName_Label.Name = "ServiceName_Label";
            this.ServiceName_Label.Size = new System.Drawing.Size(120, 30);
            this.ServiceName_Label.TabIndex = 2;
            this.ServiceName_Label.Text = "Tên Dịch Vụ";
            // 
            // Cost_Label
            // 
            this.Cost_Label.BackColor = System.Drawing.Color.Transparent;
            this.Cost_Label.Location = new System.Drawing.Point(143, 216);
            this.Cost_Label.MinimumSize = new System.Drawing.Size(120, 30);
            this.Cost_Label.Name = "Cost_Label";
            this.Cost_Label.Size = new System.Drawing.Size(120, 30);
            this.Cost_Label.TabIndex = 4;
            this.Cost_Label.Text = "Giá Dịch Vụ";
            // 
            // Cost
            // 
            this.Cost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Cost.DefaultText = "";
            this.Cost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Cost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Cost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Cost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Cost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Cost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Cost.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Cost.Location = new System.Drawing.Point(310, 202);
            this.Cost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cost.Name = "Cost";
            this.Cost.PlaceholderText = "";
            this.Cost.SelectedText = "";
            this.Cost.Size = new System.Drawing.Size(381, 48);
            this.Cost.TabIndex = 3;
            // 
            // InsertService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cost_Label);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.ServiceName_Label);
            this.Controls.Add(this.ServiceName);
            this.Controls.Add(this.guna2Button1);
            this.Name = "InsertService";
            this.Text = "InserService";
            this.Load += new System.EventHandler(this.InsertService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox ServiceName;
        private Guna.UI2.WinForms.Guna2HtmlLabel ServiceName_Label;
        private Guna.UI2.WinForms.Guna2HtmlLabel Cost_Label;
        private Guna.UI2.WinForms.Guna2TextBox Cost;
    }
}