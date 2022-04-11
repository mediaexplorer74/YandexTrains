using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uiTest
{
     static class Program
     {
        public static bool FirstStart = false;

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // -- 
            SuburbanContext.SearchCity("");
            data.Config cfg = data.Config.Fetch();
            if (cfg == null)
                FirstStart = true;
            else SuburbanContext.SetCity(cfg.City);

            // --


            Application.Run(new Form1());
        }
    }
}

