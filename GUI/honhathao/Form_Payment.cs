using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.honhathao
{
    public partial class Form_Payment: Form
    {
        private string buildingid;
        public Form_Payment(string buildingid)
        {
            this.buildingid = buildingid;
            InitializeComponent();
            loadInfo(null);
        }

        private void loadInfo(string texts)
        {
           DataTable dt = BLL.honhathao.PaymentBLL.PaymentBLL_load_payment(buildingid, texts, null);
            dgv_payment.DataSource = dt;
            foreach (DataGridViewRow row in dgv_payment.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[5].Value = Language.translate(row.Cells[5].Value.ToString());
                }
            }
            dgv_payment.DataSource = dt;
            loadLanguage();
        }
        private void loadLanguage()
        {

            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {

                    case "payment.table_header.payment_id":
                        dgv_payment.Columns[0].HeaderText = a.Value;

                        break;
                    case "payment.table_header.tenant_id":
                        dgv_payment.Columns[1].HeaderText = a.Value;

                        break;
                    case "payment.table_header.first_name":
                        dgv_payment.Columns[2].HeaderText = a.Value;
                        break;
                    case "payment.table_header.last_name":
                        dgv_payment.Columns[3].HeaderText = a.Value;
                        break;
                    case "payment.table_header.bill_id":
                        dgv_payment.Columns[4].HeaderText = a.Value;
                        break;
                    case "payment.table_header.method":
                        dgv_payment.Columns[5].HeaderText = a.Value;
                        break;
                    case "payment.table_header.total":
                        dgv_payment.Columns[6].HeaderText = a.Value;
                        break;
                    case "payment.table_header.payment_time":
                        dgv_payment.Columns[7].HeaderText = a.Value;
                        break;
                    case "payment_history.title":
                        label23.Text = a.Value;
                        break;
                    case "payment_history.detail_title":
                        label22.Text = a.Value;
                        break; 

                    case "export_to_excel":
                        button41.Text = a.Value;
                        break;
                    case "search":
                        button_tk_contract.Text = a.Value;
                        break;
                    case "checkbox_theoten":
                        guna2HtmlLabel1.Text = a.Value;
                        break;
                }
            }
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

        private void button38_Click(object sender, EventArgs e)
        {

        }

        private void button_tk_contract_Click(object sender, EventArgs e)
        {
            loadInfo(guna2TextBox1.Text);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (dgv_payment.Visible)
            {
                ExcelExporter.ExportToExcel(dgv_payment, "Danh sách thanh toán");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
