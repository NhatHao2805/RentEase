using BLL;
using BLL.honhathao;
using DTO;
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
    public partial class Form_W_E: Form
    {
        private string usern;
        private string buildingid;
        public Form_W_E(string usern,string buildingid)
        {
            this.usern = usern;
            this.buildingid = buildingid;
            InitializeComponent();
            loadInfo();
           
        }
        private void loadLanguage()
        {
            foreach (KeyValuePair<string, string> a in Language.languages)
            {
                switch (a.Key)
                {
                    case "invoice.title":
                        label23.Text = a.Value;
                        break;
                    case "invoice.subtitle":
                        label22.Text = a.Value;
                        break;
                    case "invoice.utility_prompt":
                        guna2HtmlLabel1.Text = a.Value;
                        break;
                    case "utility.table_header.figure":
                        dgv_we.Columns[0].HeaderText = a.Value;
                        break;
                    case "utility.table_header.unit_price":
                        dgv_we.Columns["UNITPRICEID"].HeaderText = a.Value;
                        break;
                    case "utility.table_header.tenant_id":
                        dgv_we.Columns["TENANTID"].HeaderText = a.Value;
                        break;
                    case "utility.table_header.old_figure":
                        dgv_we.Columns["OLDFIGURE"].HeaderText = a.Value;
                        break;
                    case "utility.table_header.new_figure":
                        dgv_we.Columns["NEWFIGURE"].HeaderText = a.Value;
                        break;
                    case "utility.table_header.unit":
                        dgv_we.Columns["UNIT"].HeaderText = a.Value;
                        break;
                    case "date_headers.start_date":
                        dgv_we.Columns["START_DATE"].HeaderText = a.Value;
                        break;
                    case "date_headers.end_date":
                        dgv_we.Columns["END_DATE"].HeaderText = a.Value;
                        break;
                    case "date_headers.record_date":
                        dgv_we.Columns["RECORD_DATE"].HeaderText = a.Value;
                        break;
                    case "date_headers.type":
                        dgv_we.Columns["TYPE"].HeaderText = a.Value;
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
            Form_Add_W_E form = new Form_Add_W_E(buildingid);
            form.ShowDialog();
            dgv_we.DataSource = null;
            loadInfo();
        }

        private void loadInfo()
        {

            DataTable data = W_E_BLL.W_E_BLL_load_W_E(usern, buildingid);
            dgv_we.DataSource = data;
            foreach (DataGridViewRow row in dgv_we.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[9].Value = Language.translate(row.Cells[9].Value.ToString());
                }
            }
            loadLanguage();
        }
    }
}
