using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Model;

namespace nodepool.Event
{
    // le sender peut etre NodePool ou NodeInstance
    public delegate void NodeInstanceStartedEventHandler(object sender, NodeInstanceStartedEventArgs e);

    public class NodeInstanceStartedEventArgs
    {
        public NodeInstance nodeInstance;

        public NodeInstanceStartedEventArgs(NodeInstance n)
        {
            this.nodeInstance = n;
        }
    }
}
