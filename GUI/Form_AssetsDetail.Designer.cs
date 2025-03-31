namespace GUI
{
    partial class Form_AssetsDetail
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
            this.ExcelExporter_btn = new Guna.UI2.WinForms.Guna2Button();
            this.close_btn = new Guna.UI2.WinForms.Guna2Button();
            this.dgv_AssetsDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AssetsDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelExporter_btn
            // 
            this.ExcelExporter_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExcelExporter_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExcelExporter_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExcelExporter_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExcelExporter_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ExcelExporter_btn.ForeColor = System.Drawing.Color.White;
            this.ExcelExporter_btn.Location = new System.Drawing.Point(422, 431);
            this.ExcelExporter_btn.Name = "ExcelExporter_btn";
            this.ExcelExporter_btn.Size = new System.Drawing.Size(184, 31);
            this.ExcelExporter_btn.TabIndex = 68;
            this.ExcelExporter_btn.Text = "Xuất sang Excel";
            this.ExcelExporter_btn.Click += new System.EventHandler(this.ExcelExporter_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.close_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.close_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.close_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.close_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.close_btn.ForeColor = System.Drawing.Color.White;
            this.close_btn.Location = new System.Drawing.Point(637, 431);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(132, 31);
            this.close_btn.TabIndex = 67;
            this.close_btn.Text = "Đóng";
            // 
            // dgv_AssetsDetail
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_AssetsDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_AssetsDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AssetsDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_AssetsDetail.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_AssetsDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_AssetsDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_AssetsDetail.Location = new System.Drawing.Point(30, 22);
            this.dgv_AssetsDetail.Name = "dgv_AssetsDetail";
            this.dgv_AssetsDetail.ReadOnly = true;
            this.dgv_AssetsDetail.RowHeadersVisible = false;
            this.dgv_AssetsDetail.RowHeadersWidth = 100;
            this.dgv_AssetsDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_AssetsDetail.RowTemplate.Height = 24;
            this.dgv_AssetsDetail.Size = new System.Drawing.Size(739, 391);
            this.dgv_AssetsDetail.TabIndex = 66;
            this.dgv_AssetsDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_AssetsDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_AssetsDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_AssetsDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_AssetsDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_AssetsDetail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_AssetsDetail.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_AssetsDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_AssetsDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_AssetsDetail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_AssetsDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_AssetsDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_AssetsDetail.ThemeStyle.HeaderStyle.Height = 50;
            this.dgv_AssetsDetail.ThemeStyle.ReadOnly = true;
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_AssetsDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Form_AssetsDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.ExcelExporter_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.dgv_AssetsDetail);
            this.Name = "Form_AssetsDetail";
            this.Text = "Form_AssetsDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AssetsDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button ExcelExporter_btn;
        private Guna.UI2.WinForms.Guna2Button close_btn;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_AssetsDetail;
    }
}