namespace GUI.GUI_Service
{
    partial class DeleteService
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
            this.serviceComboBoX = new Guna.UI2.WinForms.Guna2ComboBox();
            this.deleteService_btn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Cost_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.updateCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.updateCost_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // serviceComboBoX
            // 
            this.serviceComboBoX.BackColor = System.Drawing.Color.Transparent;
            this.serviceComboBoX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.serviceComboBoX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceComboBoX.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.serviceComboBoX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.serviceComboBoX.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.serviceComboBoX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.serviceComboBoX.ItemHeight = 30;
            this.serviceComboBoX.Location = new System.Drawing.Point(52, 160);
            this.serviceComboBoX.Name = "serviceComboBoX";
            this.serviceComboBoX.Size = new System.Drawing.Size(305, 36);
            this.serviceComboBoX.TabIndex = 0;
            // 
            // deleteService_btn
            // 
            this.deleteService_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteService_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteService_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteService_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteService_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteService_btn.ForeColor = System.Drawing.Color.White;
            this.deleteService_btn.Location = new System.Drawing.Point(52, 227);
            this.deleteService_btn.Name = "deleteService_btn";
            this.deleteService_btn.Size = new System.Drawing.Size(180, 45);
            this.deleteService_btn.TabIndex = 1;
            this.deleteService_btn.Text = "Xóa";
            this.deleteService_btn.Click += new System.EventHandler(this.deleteService_btn_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(52, 106);
            this.guna2HtmlLabel1.MinimumSize = new System.Drawing.Size(120, 30);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(120, 30);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Tên dịch vụ";
            // 
            // Cost_Label
            // 
            this.Cost_Label.BackColor = System.Drawing.Color.Transparent;
            this.Cost_Label.Location = new System.Drawing.Point(385, 106);
            this.Cost_Label.MinimumSize = new System.Drawing.Size(120, 30);
            this.Cost_Label.Name = "Cost_Label";
            this.Cost_Label.Size = new System.Drawing.Size(120, 30);
            this.Cost_Label.TabIndex = 3;
            this.Cost_Label.Text = "Giá dịch vụ";
            // 
            // updateCost
            // 
            this.updateCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.updateCost.DefaultText = "";
            this.updateCost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.updateCost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.updateCost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.updateCost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.updateCost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.updateCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.updateCost.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.updateCost.Location = new System.Drawing.Point(385, 160);
            this.updateCost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateCost.Name = "updateCost";
            this.updateCost.PlaceholderText = "";
            this.updateCost.SelectedText = "";
            this.updateCost.Size = new System.Drawing.Size(229, 36);
            this.updateCost.TabIndex = 4;
            this.updateCost.TextChanged += new System.EventHandler(this.updateCost_TextChanged);
            // 
            // updateCost_btn
            // 
            this.updateCost_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.updateCost_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.updateCost_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateCost_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.updateCost_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.updateCost_btn.ForeColor = System.Drawing.Color.White;
            this.updateCost_btn.Location = new System.Drawing.Point(385, 227);
            this.updateCost_btn.Name = "updateCost_btn";
            this.updateCost_btn.Size = new System.Drawing.Size(180, 45);
            this.updateCost_btn.TabIndex = 5;
            this.updateCost_btn.Text = "Điều chỉnh phí";
            this.updateCost_btn.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // DeleteService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 450);
            this.Controls.Add(this.updateCost_btn);
            this.Controls.Add(this.updateCost);
            this.Controls.Add(this.Cost_Label);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.deleteService_btn);
            this.Controls.Add(this.serviceComboBoX);
            this.Name = "DeleteService";
            this.Text = "DeleteService";
            this.Load += new System.EventHandler(this.DeleteService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox serviceComboBoX;
        private Guna.UI2.WinForms.Guna2Button deleteService_btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Cost_Label;
        private Guna.UI2.WinForms.Guna2TextBox updateCost;
        private Guna.UI2.WinForms.Guna2Button updateCost_btn;
    }
}