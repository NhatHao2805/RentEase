using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GUI.Custom;
namespace GUI
{
    public class ContractForm : CustomForm
    {
        public ContractForm()
        {
            this.Text = "Create Contract";
            this.Size = new Size(500, 600);

            Label titleLabel = new Label()
            {
                Text = "Create New Contract",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(150, 20)
            };

            string[] labels = { "Contract ID", "House ID", "Tenant ID", "Create Date", "Start Date", "End Date", "Monthly Rent", "Payment Schedule", "Deposit", "Status", "Notes" };
            Control[] inputs = new Control[labels.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label()
                {
                    Text = labels[i] + ":",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(50, 70 + i * 40)
                };

                if (labels[i].Contains("Date"))
                {
                    inputs[i] = new DateTimePicker()
                    {
                        Format = DateTimePickerFormat.Short,
                        Location = new Point(200, 70 + i * 40),
                        Width = 250
                    };
                }
                else if (labels[i] == "Monthly Rent" || labels[i] == "Deposit")
                {
                    inputs[i] = new NumericTextBox()
                    {
                        Location = new Point(200, 70 + i * 40),
                        Width = 250
                    };
                }
                else if (labels[i] == "Payment Schedule")
                {
                    inputs[i] = new NumericTextBox()
                    {
                        Location = new Point(200, 70 + i * 40),
                        Width = 250,
                        MinValue = 1,
                        MaxValue = 12
                    };
                }
                else
                {
                    inputs[i] = new CustomTextBox()
                    {
                        Location = new Point(200, 70 + i * 40),
                        Width = 250
                    };
                }

                this.Controls.Add(lbl);
                this.Controls.Add(inputs[i]);
            }

            CustomButton btnSubmit = new CustomButton()
            {
                Text = "SUBMIT",
                Location = new Point(125, 530)
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(btnSubmit);
        }
    }
}
