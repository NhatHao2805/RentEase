namespace GUI
{
    partial class Form_Maintenance
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
            this.maintenance_dtgridview = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.maintenance_dtgridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maintenance_dtgridview
            // 
            this.maintenance_dtgridview.AllowUserToAddRows = false;
            this.maintenance_dtgridview.AllowUserToDeleteRows = false;
            this.maintenance_dtgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.maintenance_dtgridview.Location = new System.Drawing.Point(21, 21);
            this.maintenance_dtgridview.Name = "maintenance_dtgridview";
            this.maintenance_dtgridview.ReadOnly = true;
            this.maintenance_dtgridview.RowHeadersWidth = 51;
            this.maintenance_dtgridview.RowTemplate.Height = 24;
            this.maintenance_dtgridview.Size = new System.Drawing.Size(725, 350);
            this.maintenance_dtgridview.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maintenance_dtgridview);
            this.groupBox1.Location = new System.Drawing.Point(16, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 393);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bảo trì";
            // 
            // Form_Maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Maintenance";
            this.ShowIcon = false;
            this.Text = "Tình trạng bảo trì";
            this.Load += new System.EventHandler(this.Form_Maintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maintenance_dtgridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView maintenance_dtgridview;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}