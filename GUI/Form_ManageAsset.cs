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
    public partial class Form_ManageAsset : Form
    {
        public Form_ManageAsset()
        {
            InitializeComponent();
        }

        private void Form_ManageAsset_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
