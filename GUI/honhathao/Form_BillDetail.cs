using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI.honhathao
{
    public partial class Form_BillDetail: Form
    {
        private string billid;
        public Form_BillDetail(string billid)
        {
            this.billid = billid;
            InitializeComponent();
            loadInfo();
            loadLanguage();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "invoice_title":
                        label23.Text = a.Value;
                        break;
                    case "invoice_description":
                        label22.Text = a.Value;
                        break;
                    case "bill_id":
                        dgv_billdetail.Columns[0].HeaderText = a.Value;
                        break;
                    case "record_id":
                        dgv_billdetail.Columns[1].HeaderText = a.Value;
                        break;
                    case "service_name":
                        dgv_billdetail.Columns[2].HeaderText = a.Value;
                        break;
                    case "amount":
                        dgv_billdetail.Columns[3].HeaderText = a.Value;
                        break;
                }
            }
        }
//        bill_id:Bill Id
//record_id:Id
//service_name:Service Name
//amount:Amount
        //        invoice_title:Invoice Details
        //invoice_description:Customer payment invoice details
        private void loadInfo()
        {
            DataTable dataTable = BLL.honhathao.BillDetailBLL.load_BillDetail(billid);

            dgv_billdetail.DataSource = dataTable;
            foreach (DataGridViewRow row in dgv_billdetail.Rows)
            {
                if (!row.IsNewRow)
                {   
                    row.Cells[2].Value = Language.translate(row.Cells[2].Value.ToString());
                }
            }
        }

        private void dgv_billdetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
