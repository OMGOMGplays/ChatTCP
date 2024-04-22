using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CA1416 // Disable annoying squiggly lines informing about old Windows support

namespace ChatTCP
{
    internal static class Program
    {
        // Accessible MainClient variable for other classes to use
        public static MainClient mainClient;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainClient = new MainClient());
        }
    }
}
