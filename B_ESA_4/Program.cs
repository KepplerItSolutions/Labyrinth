using B_ESA_4.Forms;
using System;
using System.Windows.Forms;

namespace B_ESA_4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string labyrinthFile = (args != null && args.Length > 0) ? args[args.Length - 1] : null;
            Application.Run(new frmLabyrinthGame(labyrinthFile));
        }
    }
}
