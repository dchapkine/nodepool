using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Model;

namespace nodepool.Event
{
    // le sender peut etre NodePool ou NodeInstance
    public delegate void NodeInstanceStoppedEventHandler(object sender, NodeInstanceStoppedEventArgs e);

    public class NodeInstanceStoppedEventArgs
    {
        public NodeInstance nodeInstance;
        public bool nodeCrashed;

        public NodeInstanceStoppedEventArgs(NodeInstance n, bool nc = false)
        {
            nodeInstance = n;
            nodeCrashed = nc;
        }
    }
}
