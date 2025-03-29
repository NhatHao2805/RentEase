namespace GUI
{
    partial class Form_RentalHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_RentalHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.close_btn = new Guna.UI2.WinForms.Guna2Button();
            this.ExcelExporter_btn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RentalHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_RentalHistory
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgv_RentalHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_RentalHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RentalHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_RentalHistory.ColumnHeadersHeight = 50;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RentalHistory.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_RentalHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_RentalHistory.Location = new System.Drawing.Point(25, 24);
            this.dgv_RentalHistory.Name = "dgv_RentalHistory";
            this.dgv_RentalHistory.ReadOnly = true;
            this.dgv_RentalHistory.RowHeadersVisible = false;
            this.dgv_RentalHistory.RowHeadersWidth = 100;
            this.dgv_RentalHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_RentalHistory.RowTemplate.Height = 24;
            this.dgv_RentalHistory.Size = new System.Drawing.Size(739, 391);
            this.dgv_RentalHistory.TabIndex = 10;
            this.dgv_RentalHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_RentalHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_RentalHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_RentalHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_RentalHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_RentalHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_RentalHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_RentalHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_RentalHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_RentalHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_RentalHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_RentalHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_RentalHistory.ThemeStyle.HeaderStyle.Height = 50;
            this.dgv_RentalHistory.ThemeStyle.ReadOnly = true;
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_RentalHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // close_btn
            // 
            this.close_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.close_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.close_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.close_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.close_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.close_btn.ForeColor = System.Drawing.Color.White;
            this.close_btn.Location = new System.Drawing.Point(632, 433);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(132, 31);
            this.close_btn.TabIndex = 64;
            this.close_btn.Text = "Đóng";
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // ExcelExporter_btn
            // 
            this.ExcelExporter_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExcelExporter_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExcelExporter_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExcelExporter_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExcelExporter_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ExcelExporter_btn.ForeColor = System.Drawing.Color.White;
            this.ExcelExporter_btn.Location = new System.Drawing.Point(417, 433);
            this.ExcelExporter_btn.Name = "ExcelExporter_btn";
            this.ExcelExporter_btn.Size = new System.Drawing.Size(184, 31);
            this.ExcelExporter_btn.TabIndex = 65;
            this.ExcelExporter_btn.Text = "Xuất sang Excel";
            this.ExcelExporter_btn.Click += new System.EventHandler(this.ExcelExporter_btn_Click);
            // 
            // Form_RentalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.ExcelExporter_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.dgv_RentalHistory);
            this.Name = "Form_RentalHistory";
            this.Text = "Form_RentalHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RentalHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_RentalHistory;
        private Guna.UI2.WinForms.Guna2Button close_btn;
        private Guna.UI2.WinForms.Guna2Button ExcelExporter_btn;
    }
}