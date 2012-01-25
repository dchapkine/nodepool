using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nodepool.Model
{
    public class NodeInstanceToolStripItem : System.Windows.Forms.ToolStripMenuItem
    {
        private NodeInstance _nodeInstance;

        public NodeInstanceToolStripItem(NodeInstance n)
            : base(n.name)
        {
            _nodeInstance = n;



            //
            var tmp = new ToolStripButton("output", global::nodepool.Resources.icon.cmd_16, onOutput);
            tmp.Width = 50;
            this.DropDownItems.Add(tmp);

            //this.DropDownItems.Add("-");

            tmp = new ToolStripButton("start", global::nodepool.Resources.icon.play_16, onStart);
            tmp.Width = 50;
            this.DropDownItems.Add(tmp);

            tmp = new ToolStripButton("kill", global::nodepool.Resources.icon.stop_16, onStop);
            tmp.Width = 50;
            this.DropDownItems.Add(tmp);

            tmp = new ToolStripButton("restart", global::nodepool.Resources.icon.restart_16, onRestart);
            tmp.Width = 50;
            this.DropDownItems.Add(tmp);

            tmp = new ToolStripButton("remove", global::nodepool.Resources.icon.remove_16, onRemove);
            tmp.Width = 50;
            this.DropDownItems.Add(tmp);

        }

        public void onStart(object sender, EventArgs e)
        {
            _nodeInstance.run();
        }

        public void onStop(object sender, EventArgs e)
        {
            _nodeInstance.kill();
        }

        public void onRestart(object sender, EventArgs e)
        {
            _nodeInstance.restart();
        }

        public void onRemove(object sender, EventArgs e)
        {
            _nodeInstance.kill();
            _nodeInstance.Dispose();
            NodePool.getInstance().removeNodeInstance(_nodeInstance);

            Parent.Items.Remove(this);
        }

        public void onOutput(object sender, EventArgs e)
        {
            new Form.NodeInstanceStandardOutputForm(_nodeInstance).Show();
        }
    }

    /*public class NodeInstanceToolStripItem : System.Windows.Forms.ToolStripDropDownButton
    {
        private NodeInstance _nodeInstance;

        public NodeInstanceToolStripItem(NodeInstance n): base(n.name)
        {
            _nodeInstance = n;


            //
            this.DropDownItems.Add(new ToolStripButton("start", global::nodepool.Resources.icon.play_16, onStart));
            this.DropDownItems.Add(new ToolStripButton("kill", global::nodepool.Resources.icon.stop_16, onStop));
            this.DropDownItems.Add(new ToolStripButton("restart", global::nodepool.Resources.icon.restart_16, onRestart));

        }

        public void onStart(object sender, EventArgs e)
        {
            _nodeInstance.run();
        }

        public void onStop(object sender, EventArgs e)
        {
            _nodeInstance.kill();
        }

        public void onRestart(object sender, EventArgs e)
        {
            _nodeInstance.restart();
        }
    }*/
}
