using GUI.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class TenantForm : CustomForm
    {
        public TenantForm()
        {
            this.Text = "Tenant Information";
            this.Size = new System.Drawing.Size(500, 600);
            this.FormBorderStyle = FormBorderStyle.None;

            Label lblTitle = new Label()
            {
                Text = "Your Requirements",
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            int startY = 60;
            int spacing = 50;

            string[] labels = { "Tenant ID", "First Name", "Last Name", "Birthday", "Gender", "Phone Number", "Email", "Profile Picture" };
            MyGunaTextBox[] textBoxes = new MyGunaTextBox[labels.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label()
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(20, startY + (i * spacing)),
                    AutoSize = true
                };
                this.Controls.Add(lbl);

                textBoxes[i] = new MyGunaTextBox()
                {
                    Location = new System.Drawing.Point(150, startY + (i * spacing)),
                    Width = 300
                };
                this.Controls.Add(textBoxes[i]);
            }

            MyGunaButton btnSubmit = new MyGunaButton()
            {
                Text = "Submit",
                Location = new System.Drawing.Point(150, startY + labels.Length * spacing + 10),
                Width = 100
            };
            this.Controls.Add(btnSubmit);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TenantForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "TenantForm";
            this.Load += new System.EventHandler(this.TenantForm_Load);
            this.ResumeLayout(false);

        }

        private void TenantForm_Load(object sender, EventArgs e)
        {

        }
    }
 }
