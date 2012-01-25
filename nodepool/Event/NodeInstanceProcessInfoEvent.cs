using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Model;

namespace nodepool.Event
{
    public delegate void NodeInstanceProcessInfoEventHandler(nodepool.Model.NodeInstance sender, NodeInstanceProcessInfoEventArgs e);

    public class NodeInstanceProcessInfoEventArgs
    {
        public NodeInstance nodeInstance;

        public NodeInstanceProcessInfoEventArgs(NodeInstance n)
        {
            this.nodeInstance = n;
        }
    }
}
