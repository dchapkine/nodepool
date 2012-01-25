using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nodepool.Model;

namespace nodepool.Form
{
    public partial class RestartOnChangePatternsForm : System.Windows.Forms.Form
    {
        private NodeInstance _nodeInstance;

        public RestartOnChangePatternsForm(NodeInstance i)
        {
            InitializeComponent();

            _nodeInstance = i;

            //
            patternsTextBox.Text = _nodeInstance.restartOnFileChangePatternsString;
        }

        private void patternsTextBox_TextChanged(object sender, EventArgs e)
        {
            _nodeInstance.restartOnFileChangePatternsString = patternsTextBox.Text;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
