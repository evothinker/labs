using System;

using System.Windows.Forms;

namespace contrmodview
{
    static class Program
    {
        /// <summary>
        /// entry pointu aplicatiei.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            
            Form1 view = new Form1();
            Modelu mdl = new IncModel();
            Controleru cnt = new IncController(view,mdl);
            Application.Run(view);
        }
    }
}
