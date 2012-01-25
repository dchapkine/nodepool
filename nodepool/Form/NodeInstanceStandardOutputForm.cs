using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nodepool.Model;
using nodepool.Event;
using System.Threading;
using System.IO;
using nodepool.Tools;

namespace nodepool.Form
{
    public partial class NodeInstanceStandardOutputForm : System.Windows.Forms.Form
    {
        private NodeInstance _nodeInstance;
        private NodeInstance _npmInstance;

        public NodeInstanceStandardOutputForm(NodeInstance n)
        {
            //
            InitializeComponent();

            //
            // Title
            //
            Text = n.name;

            //
            // NodePool events
            //
            NodePool.getInstance().NodeInstanceRemoved += new NodeInstanceRemovedEventHandler(_NodeInstanceRemoved);

            //
            // APP instance
            //
            _nodeInstance = n;
            nodeInstanceMainMenu1.init();
            nodeInstanceMainMenu1.nodeInstance = _nodeInstance;
            nodeTerminal.nodeInstance = _nodeInstance;
            //_nodeInstance.run();

            //
            // NPM instance
            //
            /*
            _npmInstance = new NodeInstance(_nodeInstance.nodeVersion);
            _npmInstance.name = "______NPM______";
            _npmInstance.mainJsFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Resources\nodejs\node0.6.6\node_modules\npm\cli.js");
            */
            _npmInstance = NodePool.getInstance("npm").createNodeInstance(_nodeInstance.nodeVersion, _nodeInstance.name + "______NPM______" + RuntimeUniqueId.getAsString(), Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Resources\nodejs\" + LocalHost.getLatestInstalledNodeVersion() + @"\node_modules\npm\cli.js"));
            _npmInstance.restartOnCrash = false;
            _npmInstance.restartOnMainJsFileChange = false;
            _npmInstance.workingDirectory = Path.GetDirectoryName(_nodeInstance.mainJsFilePath);// set working directory for local npm
            npmTerminal.nodeInstance = _npmInstance;
            _npmInstance.run();

            //
            nodeTerminal.focusStdIn();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Alors là, on applique un hack pr focus le navigateur (awesomium) au changement manuel de tab
            // Sinon, on reçoit plus les evenements clavier / souris :(
            if (tabControl.SelectedIndex == 2)
            {
                //webControl.Focus();
            }
            // Là on redonne le focus à l'entrée standart de npm
            else if (tabControl.SelectedIndex == 1)
            {
                npmTerminal.focusStdIn();
            }
            // Là on redonne le focus à l'entrée standart 
            else if (tabControl.SelectedIndex == 0)
            {
                nodeTerminal.focusStdIn();
            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            // Alors là, on applique un hack pr focus le navigateur (awesomium) au changement manuel de tab
            // Sinon, on reçoit plus les evenements clavier / souris :(
            if (tabControl.SelectedIndex == 2)
            {
                //webControl.Focus();
            }
            // Là on redonne le focus à l'entrée standart de npm
            else if (tabControl.SelectedIndex == 1)
            {
                npmTerminal.focusStdIn();
            }
            // Là on redonne le focus à l'entrée standart 
            else if (tabControl.SelectedIndex == 0)
            {
                nodeTerminal.focusStdIn();
            }
        }


        private void _NodeInstanceRemoved(object sender, NodeInstanceRemovedEventArgs args)
        {
            if (args.nodeInstance == _nodeInstance)
                Close();
        }
    }
}
