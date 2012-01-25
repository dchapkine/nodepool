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
using System.Reflection;

namespace nodepool
{
    public partial class MainForm : System.Windows.Forms.Form //: ApplicationContext
    {
        // Real close flag
        private bool realClose;
        private NodePool pool;

        public MainForm()
        {
            //
            InitializeComponent();

            //
            realClose = false;

            //
            //MainForm_Load(this, EventArgs.Empty);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!realClose)
            {
                e.Cancel = true; // On annule la fermeture de la fenetre
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        // On ajoute une instance de node
        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddNodeForm().Show();
        }

        // On quite
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // On sauvegarde le profil
            UserProfile.getInstance().save();

            // On kill tous les nodes qui tournent
            //NodePool.getInstance().Dispose();
            NodePool.disposeAllInstances();

            //
            realClose = true;
            Close();

            //
            System.Windows.Forms.Application.Exit();
        }

        // Au chargement
        public void manualOnLoad()
        {
            MainForm_Load(null, EventArgs.Empty);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            /*Show();
            WindowState = FormWindowState.Minimized;
            Hide();
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.SetBounds(3000, 3000, 0, 0);
            */

            //
            pool = NodePool.getInstance();
            pool.NodeInstanceCreated += new Event.NodeInstanceCreatedEventHandler(pool_NodeInstanceCreated);
            pool.NodeInstanceStarted += new Event.NodeInstanceStartedEventHandler(pool_NodeInstanceStarted);
            pool.NodeInstanceStopped += new Event.NodeInstanceStoppedEventHandler(pool_NodeInstanceStopped);

            //
            systrayMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(systrayMenuStrip_ItemClicked);

            // Load user config (=profile)
            UserProfile.getInstance().load();

            //
            systray.ShowBalloonTip(100, "NodePool", "\nNodePool is now running in background...\n", new ToolTipIcon());

        }

        public void pool_NodeInstanceCreated(NodePool sender, NodeInstanceCreatedEventArgs e)
        {
            
            /*
            var nodeinst = new System.Windows.Forms.ToolStripDropDownButton(e.nodeInstance.name, null);
            nodeinst.DropDownItems.Add(new ToolStripButton("start"));
            nodeinst.DropDownItems.Add(new ToolStripButton("kill"));
            nodeinst.DropDownItems.Add(new ToolStripButton("restart"));
            */

            var nodeinst = new NodeInstanceToolStripItem(e.nodeInstance);
            nodeinst.Image = global::nodepool.Resources.icon.stop_16;
            systrayMenuStrip.Items.Insert(0, nodeinst);
        }

        // TODO: tester si un item au nom identique ne tourne pas deja
        public void pool_NodeInstanceStarted(object sender, NodeInstanceStartedEventArgs e)
        {
            foreach (ToolStripItem i in systrayMenuStrip.Items)
            {
                if (i.Text == e.nodeInstance.name)
                {
                    //systray.ShowBalloonTip(100, "NodePool", "\n\"" + e.nodeInstance.name + "\" node started\n", new ToolTipIcon());
                    //Console.WriteLine("Node instance started");
                    i.Image = global::nodepool.Resources.icon.play_16;
                    break;
                }
            }
        }

        public delegate void pool_NodeInstanceStoppedDelegate(object sender, NodeInstanceStoppedEventArgs e);
        public void pool_NodeInstanceStopped(object sender, NodeInstanceStoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new pool_NodeInstanceStoppedDelegate(pool_NodeInstanceStopped), new object[] { sender, e });
            }
            else
            {
                foreach (ToolStripItem i in systrayMenuStrip.Items)
                {
                    if (i.Text == e.nodeInstance.name)
                    {
                        if (e.nodeCrashed)
                        {
                            string txt = "\n\"" + e.nodeInstance.name + "\" node crashed x|";
                            if (e.nodeInstance.restartOnCrash)
                                txt += ".\n\nIt will be automaticly restarted according to restart-on-crash settings.\n";
                            txt += "\n";
                            systray.ShowBalloonTip(1500, "NodePool", txt, new ToolTipIcon());
                        }
                        else
                        {
                            //systray.ShowBalloonTip(100, "NodePool", "\n\"" + e.nodeInstance.name + "\" node stopped\n", new ToolTipIcon());
                        }
                        //Console.WriteLine("Node instance stopped");
                        i.Image = global::nodepool.Resources.icon.stop_16;
                        break;
                    }
                }
            }
        }

        public void systrayMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Console.WriteLine(e.ClickedItem);
        }

        // tue tous les nodes
        private void killAllNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodePool.getInstance().killAllNodeInstances();
        }

        // demarre tous les nodes
        private void startAllNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodePool.getInstance().startAllNodeInstances();
        }

        // redemerre tous les nodes
        private void restartAllNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodePool.getInstance().restartAllNodeInstances();
        }

        private void systray_MouseClick(object sender, MouseEventArgs e)
        {
            /* ne veut pas disparaitre si je fais ça :/
                systrayMenuStrip.Show(
                MousePosition.X - systrayMenuStrip.Width/2,
                MousePosition.Y - systrayMenuStrip.Height);*/

            //systray.ShowBalloonTip(1500, "NodeJS roxxxx", "realy rooooxx", new ToolTipIcon());

            // Affiche le menu du systray...   @see http://stackoverflow.com/questions/3545640/how-to-show-the-context-menu-programmatically-when-click-on-notification-icon
            MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu",
            BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfo.Invoke(systray, null);
        }
    }
}
