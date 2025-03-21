using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomDataGridView : DataGridView
{
    public CustomDataGridView()
    {
        // Cấu hình chung
        this.BorderStyle = BorderStyle.None;
        this.CellBorderStyle = DataGridViewCellBorderStyle.None;
        this.BackgroundColor = Color.White;
        this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        // Tiêu đề cột
        this.EnableHeadersVisualStyles = false;
        this.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        this.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

        // Cấu hình dòng
        this.RowHeadersVisible = false;
        this.AllowUserToAddRows = false;
        this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.DefaultCellStyle.Font = new Font("Arial", 10);
        this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

        // Zebra Style
        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
        this.DefaultCellStyle.BackColor = Color.White;

        // Gắn sự kiện cho Status
        this.CellFormatting += CustomDataGridView_CellFormatting;
        foreach (DataGridViewColumn col in this.Columns)
        {
            col.MinimumWidth = 100;  // Đặt độ rộng tối thiểu là 100px
        }
        // Scroll
        this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.ScrollBars = ScrollBars.Both;
        this.AllowUserToResizeColumns = true;  // Cho phép kéo thả thay đổi kích thước cột
        this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        this.ReadOnly = true;



    }

    private void CustomDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
        {
            string status = e.Value.ToString();
            if (status == "Completed")
            {
                e.CellStyle.BackColor = Color.FromArgb(220, 255, 220);
                e.CellStyle.ForeColor = Color.Green;
                e.Value = "✔ Completed";
            }
            else if (status == "Failed")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
                e.CellStyle.ForeColor = Color.Red;
                e.Value = "✖ Failed";
            }
            e.CellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
