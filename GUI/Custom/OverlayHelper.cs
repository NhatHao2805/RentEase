using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Custom
{
    public class OverlayForm : Form
    {
        public OverlayForm(Form owner)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.Black;
            this.Opacity = 0.5;
            this.ShowInTaskbar = false;
            this.Bounds = owner.Bounds;
            this.Owner = owner;
        }
    }

    public static class OverlayManager
    {
        public static void ShowWithOverlay(Form parent, Form childForm)
        {
            using (OverlayForm overlay = new OverlayForm(parent))
            {
                overlay.Show();
                childForm.StartPosition = FormStartPosition.CenterParent;
                childForm.ShowDialog(overlay);
            }
        }
    }
}
