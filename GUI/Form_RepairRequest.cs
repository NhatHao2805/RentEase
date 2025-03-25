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
    public partial class Form_RepairRequest : Form
    {
        RepairRequestBLL repairRequestBLL = new RepairRequestBLL();
        QuanLyNha form;
        RepairRequesst repairRequesst = new RepairRequesst();

        public Form_RepairRequest(QuanLyNha f1)
        {
            InitializeComponent();
            this.form = f1;
        }

        private void Form_RepairRequest_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            LoadRepairRequest();
            form.CustomizeDataGridView(repairRequest_dtgridview);
        }

        private void LoadRepairRequest()
        {

            DataTable dt = new DataTable();
            dt = repairRequestBLL.GetRepairRequest();
            repairRequest_dtgridview.AutoGenerateColumns = true;
            repairRequest_dtgridview.DataSource = dt;
            repairRequest_dtgridview.ReadOnly = true;

            repairRequest_dtgridview.Columns["REQUESTID"].HeaderText = "Mã yêu cầu";
            repairRequest_dtgridview.Columns["ASSETID"].HeaderText = "Mã tài sản";
            repairRequest_dtgridview.Columns["TENANTID"].HeaderText = "Mã khách thuê";
            repairRequest_dtgridview.Columns["REQUEST_DATE"].HeaderText = "Ngày yêu cầu";
            repairRequest_dtgridview.Columns["DESCRIPTION"].HeaderText = "Mô tả";
            repairRequest_dtgridview.Columns["STATUS"].HeaderText = "Tình trạng";

        }
    }
}
