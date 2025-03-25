namespace GUI
{
    partial class Form_RepairRequest
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
            this.repairRequest_dtgridview = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.repairRequest_dtgridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // repairRequest_dtgridview
            // 
            this.repairRequest_dtgridview.AllowUserToAddRows = false;
            this.repairRequest_dtgridview.AllowUserToDeleteRows = false;
            this.repairRequest_dtgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.repairRequest_dtgridview.Location = new System.Drawing.Point(23, 21);
            this.repairRequest_dtgridview.Name = "repairRequest_dtgridview";
            this.repairRequest_dtgridview.ReadOnly = true;
            this.repairRequest_dtgridview.RowHeadersWidth = 51;
            this.repairRequest_dtgridview.RowTemplate.Height = 24;
            this.repairRequest_dtgridview.Size = new System.Drawing.Size(694, 363);
            this.repairRequest_dtgridview.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.repairRequest_dtgridview);
            this.groupBox1.Location = new System.Drawing.Point(20, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 406);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin yêu cầu";
            // 
            // Form_RepairRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_RepairRequest";
            this.ShowIcon = false;
            this.Text = "Yêu cầu sửa chữa";
            this.Load += new System.EventHandler(this.Form_RepairRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repairRequest_dtgridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView repairRequest_dtgridview;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}