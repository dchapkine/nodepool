using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nodepool.Model;
using nodepool.Event;
using System.IO;

namespace nodepool.UserControl
{
    public partial class NpmTerminal : System.Windows.Forms.UserControl
    {
        private NodeInstance _nodeInstance;

        private List<String> _stdin;
        private int _curCompletion;

        public NpmTerminal()
        {
            InitializeComponent();

            _nodeInstance = null;
            _stdin = new List<string>();
            _curCompletion = 0;

            outTextBox.Focus();
        }

        #region Properties

        public NodeInstance nodeInstance
        {
            get { return _nodeInstance; }
            set
            {
                if (_nodeInstance == null && value != null)
                {
                    _nodeInstance = value;
                    _nodeInstance.NodeInstanceStandardOutput += new Event.NodeInstanceStandardOutputEventHandler(_nodeInstance_NodeInstanceStandardOutput);
                    _nodeInstance.NodeInstanceStarted += new Event.NodeInstanceStartedEventHandler(_nodeInstance_NodeInstanceStarted);
                    _nodeInstance.NodeInstanceStopped += new NodeInstanceStoppedEventHandler(_nodeInstance_NodeInstanceStopped);
                }
            }
        }

        #endregion


        #region Methods

        public void pushLine(String t)
        {

        }



        /**
         * [FR]
         * Notre instance de node vient de demarrer
         */
        public void _nodeInstance_NodeInstanceStarted(object sender, NodeInstanceStartedEventArgs e)
        {}

        /**
         * [FR]
         * Notre instance de node vient de s'arreter
         */
        public void _nodeInstance_NodeInstanceStopped(object sender, NodeInstanceStoppedEventArgs e)
        {}

        /**
         * [FR]
         * Il y a du nouveau sur le sortie standart de cette instance de node
         */
        public void _nodeInstance_NodeInstanceStandardOutput(object sender, NodeInstanceStandardOutputEventArgs e)
        {
            if (InvokeRequired)
            {
                outTextBox.Invoke((MethodInvoker)delegate { outTextBox.Text = e.nodeInstance.standardOutputString; });
                outTextBox.Invoke((MethodInvoker)delegate { outTextBox.SelectionStart = outTextBox.Text.Length; });
                outTextBox.Invoke((MethodInvoker)delegate { outTextBox.ScrollToCaret(); });
            }
            else
            {
                outTextBox.Text = e.nodeInstance.standardOutputString;
                outTextBox.SelectionStart = outTextBox.Text.Length;
                outTextBox.ScrollToCaret();
            }
        }

        private void inTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*
                _nodeInstance.writeToStdIn(inTextBox.Text);
                */

                _nodeInstance.run(inTextBox.Text);
                
                _stdin.Add(inTextBox.Text);
                _curCompletion = _stdin.Count() - 1;
                inTextBox.Text = "";
                e.Handled = true;

                //Console.WriteLine("yooooooo entrééééééé");

                


                /*
                var tmp = @"C:\Users\simpleuser\Dropbox\Work\my_projects\nodepool\nodepool\bin\Release\Resources\nodejs\node0.6.6\node_modules\npm\bin\npm-cli.js";
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(
                    @".\Resources\nodejs\node0.6.6\node.exe",
                    " ./" + Path.GetFileName(tmp));


                info.WorkingDirectory = Path.GetDirectoryName(tmp);
                //info.RedirectStandardInput = true;
                //info.RedirectStandardOutput = true;
                //info.RedirectStandardError = true;
                info.UseShellExecute = false;
                //info.CreateNoWindow = true;

                System.Diagnostics.Process.Start(info);
                */


            }
            else if (e.KeyCode == Keys.Up)
            {
                if (_stdin.Count() > 0 && _curCompletion == _stdin.Count())
                    _curCompletion = _stdin.Count() - 1;
                else if (_stdin.Count() > 0 && _curCompletion == _stdin.Count() - 1)
                    _curCompletion = _stdin.Count() - 1;

                if (_curCompletion >= 0)
                {
                    if (_stdin.Count() > 0 && _curCompletion < _stdin.Count())
                    {
                        inTextBox.Text = _stdin[_curCompletion];
                        inTextBox.Select(inTextBox.Text.Length - 0, 0);
                        Console.WriteLine(_curCompletion);
                    }
                    _curCompletion--;
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (_curCompletion < _stdin.Count())
                {
                    if (_curCompletion == -1)
                        _curCompletion = 0;
                    else if (_curCompletion == 0)
                        _curCompletion = 1;

                    if (_stdin.Count() > 0 && _curCompletion < _stdin.Count())
                    {
                        inTextBox.Text = _stdin[_curCompletion];
                        inTextBox.Select(inTextBox.Text.Length - 0, 0);
                        Console.WriteLine(_curCompletion);
                    }
                    _curCompletion++;
                    e.Handled = true;
                }
            }
        }

        #endregion

        public void focusStdIn()
        {
            inTextBox.Focus();
        }
    }
}
