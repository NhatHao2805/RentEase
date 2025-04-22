using GUI.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bắt đầu ứng dụng với Loading Form
            //Loading loadingForm = new Loading();
            //loadingForm.ShowDialog(); 



            Application.Run(new Form_Login());
            //Application.Run(new Loading());
        }
    }
}
