using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_Maintenance : Form
    {
        MaintenanceBLL maintenanceBLL = new MaintenanceBLL();
        QuanLyNha form;
        Maintenance maintenance = new Maintenance();

        public Form_Maintenance(QuanLyNha f1)
        {
            InitializeComponent();
            this.form = f1;
        }

        private void Form_Maintenance_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            LoadMaintenance();
            form.CustomizeDataGridView(maintenance_dtgridview);
        }

        private void LoadMaintenance()
        {

            DataTable dt = new DataTable();
            dt = maintenanceBLL.GetMaintenance();
            maintenance_dtgridview.AutoGenerateColumns = true;
            maintenance_dtgridview.DataSource = dt;
            maintenance_dtgridview.ReadOnly = true;

            maintenance_dtgridview.Columns["MAINTENANCEID"].HeaderText = "Mã bảo trì";
            maintenance_dtgridview.Columns["ASSETID"].HeaderText = "Mã tài sản";
            maintenance_dtgridview.Columns["MAINTENANCE_DATE"].HeaderText = "Ngày bảo trì";
            maintenance_dtgridview.Columns["DESCRIPTION"].HeaderText = "Mô tả";
            maintenance_dtgridview.Columns["STATUS"].HeaderText = "Tình trạng";

        }
    }
}
