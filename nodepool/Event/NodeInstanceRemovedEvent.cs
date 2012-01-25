using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Model;

namespace nodepool.Event
{
    public delegate void NodeInstanceRemovedEventHandler(nodepool.Model.NodePool sender, NodeInstanceRemovedEventArgs e);

    public class NodeInstanceRemovedEventArgs
    {
        public NodeInstance nodeInstance;

        public NodeInstanceRemovedEventArgs(NodeInstance n)
        {
            this.nodeInstance = n;
        }
    }
}
