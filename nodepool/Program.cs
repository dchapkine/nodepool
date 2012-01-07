using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using nodepool.Form;
using System.Diagnostics;

namespace nodepool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        /*static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new nodepool.Class1());
        }*/


        // Dont show main form hack, see http://bytes.com/topic/c-sharp/answers/338397-start-hidden-form#post1608409
        [STAThread]
        static void Main()
        {

            // Standart
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Standart
            System.Windows.Forms.Application.Run(new Class1());
        }

    }
}
