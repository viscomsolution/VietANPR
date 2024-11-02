using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;

namespace VietANPRdemo
{
    public enum ReadingMode
    {
        All,
        TopLeft,
        Biggest,
        Center
    }

    static class Program
    {
        public static PlateReader reader;

        public static ReadingMode readingMode = ReadingMode.TopLeft;
        public static string delimiter = ";";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormMain.GetInstance());
        }
    }
}
