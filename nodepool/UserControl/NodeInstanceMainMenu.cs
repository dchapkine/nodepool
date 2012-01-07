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
    public partial class NodeInstanceMainMenu : System.Windows.Forms.UserControl
    {
        private NodeInstance _nodeInstance;

        public NodeInstanceMainMenu()
        {
            InitializeComponent();
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
                    restartOnCrashButton.Checked = _nodeInstance.restartOnCrash;
                    restartOnSourceChangeButton.Checked = _nodeInstance.restartOnMainJsFileChange;

                    //
                    if (_nodeInstance.isRunning)
                    {
                        startButton.Enabled = false;
                        debugButton.Enabled = false;
                        stopButton.Enabled = true;


                    }
                    else
                    {
                        //startButton.Enabled = true;
                        //debugButton.Enabled = true;
                        //stopButton.Enabled = false;
                    }

                    //
                    _nodeInstance.NodeInstanceStarted += new NodeInstanceStartedEventHandler(_nodeInstance_NodeInstanceStarted);
                    _nodeInstance.NodeInstanceStopped += new NodeInstanceStoppedEventHandler(_nodeInstance_NodeInstanceStopped);


                }
            }
        }

        #endregion


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


        private void stopButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.kill();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.run();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.restart();
        }

        private void restartOnCrashButton_Click(object sender, EventArgs e)
        {
            restartOnCrashButton.Checked = !restartOnCrashButton.Checked;
            _nodeInstance.restartOnCrash = restartOnCrashButton.Checked;
        }

        private void restartOnSourceChangeButton_Click(object sender, EventArgs e)
        {
            restartOnSourceChangeButton.Checked = !restartOnSourceChangeButton.Checked;
            _nodeInstance.restartOnMainJsFileChange = restartOnSourceChangeButton.Checked;
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            _nodeInstance.debug();
        }
    }
}
