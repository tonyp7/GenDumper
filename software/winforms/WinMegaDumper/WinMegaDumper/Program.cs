using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCartDumper
{
    static class Program
    {
        public static readonly string VERSION = "Mega Dumper v1.0";
        public static readonly string COPYRIGHT = "Copyright © 2020 Tony Pottier";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
