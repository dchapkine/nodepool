using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nodepool.Form
{
    public class Class1 : System.Windows.Forms.ApplicationContext
    {
        private MainForm f1;

        public Class1()
        {
            this.f1 = new MainForm();
            this.f1.manualOnLoad();
            this.f1.Visible = false;
            this.f1.VisibleChanged += new EventHandler(this.f1_VisibleChanged);
        }

        private void f1_VisibleChanged(object sender, EventArgs e)
        {
            this.MainForm = this.f1;
        }
    }

}
