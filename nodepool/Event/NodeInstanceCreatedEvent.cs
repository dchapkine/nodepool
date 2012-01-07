using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Model;

namespace nodepool.Event
{
    public delegate void NodeInstanceCreatedEventHandler(nodepool.Model.NodePool sender, NodeInstanceCreatedEventArgs e);

    public class NodeInstanceCreatedEventArgs
    {
        public NodeInstance nodeInstance;

        public NodeInstanceCreatedEventArgs(NodeInstance n)
        {
            this.nodeInstance = n;
        }
    }
}
