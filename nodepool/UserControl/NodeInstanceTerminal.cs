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

namespace nodepool.UserControl
{
    public partial class NodeInstanceTerminal : System.Windows.Forms.UserControl
    {
        private NodeInstance _nodeInstance;

        private List<String> _stdin;
        private int _curCompletion;

        public NodeInstanceTerminal()
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
                    //
                    _nodeInstance = value;

                    //
                    outTextBox.Text = _nodeInstance.standardOutputString;

                    //
                    if (_nodeInstance.isRunning)
                    {
                        startButton.Enabled = false;
                        debugButton.Enabled = false;
                        stopButton.Enabled = true;
                    }
                    else
                    {
                        startButton.Enabled = true;
                        debugButton.Enabled = true;
                        stopButton.Enabled = false;
                    }

                    //
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
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { startButton.Enabled = false; debugButton.Enabled = false; });
                Invoke((MethodInvoker)delegate { stopButton.Enabled = true; });
            }
            else
            {
                startButton.Enabled = false;
                debugButton.Enabled = false;
                stopButton.Enabled = true;
            }

            // debug window
            if (_nodeInstance.isDebugModeOn)
            {
                System.Diagnostics.Process.Start("http://localhost:" + _nodeInstance.webDebugPort + "/debug?port=" + _nodeInstance.debugPort);
            }
        }

        /**
         * [FR]
         * Notre instance de node vient de s'arreter
         */
        public void _nodeInstance_NodeInstanceStopped(object sender, NodeInstanceStoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { startButton.Enabled = true; debugButton.Enabled = true; });
                Invoke((MethodInvoker)delegate { stopButton.Enabled = false; });
            }
            else
            {
                startButton.Enabled = true;
                debugButton.Enabled = true;
                stopButton.Enabled = false;
            }
        }







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
                _nodeInstance.writeToStdIn(inTextBox.Text);

                _stdin.Add(inTextBox.Text);
                _curCompletion = _stdin.Count() - 1;
                inTextBox.Text = "";
                e.Handled = true;
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















        /**
         * [EN]
         * Run instance
         */
        private void startButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.run();
        }

        /**
         * [EN]
         * Stop the node instance
         */
        private void stopButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.kill();
        }


        /**
         * [EN]
         * Restart the node instance
         */
        private void restartButton_Click(object sender, EventArgs e)
        {
            // TODO: remember debug or run only mode and restore it  
            _nodeInstance.restart();
        }


        /**
         * [EN]
         * Clears STDOUT of the node process
         */
        private void clearButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.clearStandardOutputString();
            outTextBox.Text = "";
        }

        /**
         * [EN]
         * Opens in windows explorer the folder that contains mains js file
         */
        private void openInExplorerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(_nodeInstance.mainJsFilePath));
        }

        /**
         * [EN]
         * Debug in external browser
         * 
         * Awesomium support dropped: too slow and buggy (<select> elements doesn't show off)
            webControl.Source = new System.Uri("http://localhost:" + _nodeInstance.webDebugPort + "/debug?port=" + _nodeInstance.debugPort);
            webControl.InputController.IsKeyboardIgnored = false; // not necessary
            webControl.InputController.IsMouseIgnored = false; // not necessary
            tabControl.TabPages.Add(_debugTabPage);
            webControl.Focus();
         */
        private void debugInExternalBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _nodeInstance.debug();
        }

        /**
         * [EN]
         * Debug (default action)
         */
        private void debugButton_ButtonClick(object sender, EventArgs e)
        {
            _nodeInstance.debug();
        }



        public void focusStdIn()
        {
            inTextBox.Focus();
        }
    }
}
