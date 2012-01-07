using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Model;

namespace nodepool.Event
{
    public delegate void NodeInstanceStandardOutputEventHandler(object sender, NodeInstanceStandardOutputEventArgs e);

    public class NodeInstanceStandardOutputEventArgs
    {
        public NodeInstance nodeInstance;
        public String newString;

        public NodeInstanceStandardOutputEventArgs(NodeInstance n, String news)
        {
            this.nodeInstance = n;
            this.newString = news;
        }
    }
}
