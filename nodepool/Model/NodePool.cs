using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nodepool.Event;

namespace nodepool.Model
{
    public class NodePool : IDisposable
    {

        #region Singleton

        private static Dictionary<String, NodePool> _instance = new Dictionary<string,NodePool>();

        public static NodePool getInstance(String key = "apps")
        {
            if (!_instance.ContainsKey(key))
                _instance[key] = new NodePool();
            return _instance[key];
        }

        public static void disposeAllInstances()
        {
            foreach (NodePool i in _instance.Values)
            {
                i.Dispose();
            }
        }

        #endregion


        #region Attributs

        private List<NodeInstance> _nodeInstances;

        #endregion


        #region Events

        public event NodeInstanceCreatedEventHandler NodeInstanceCreated;
        public event NodeInstanceStartedEventHandler NodeInstanceStarted;
        public event NodeInstanceStoppedEventHandler NodeInstanceStopped;

        #endregion


        #region Constructors

        private NodePool()
        {
            _nodeInstances = new List<NodeInstance>();
        }

        #endregion


        #region EventShortCuts

        public void OnNodeInstanceCreated(NodeInstanceCreatedEventArgs e = null)
        {
            if (NodeInstanceCreated != null)
                NodeInstanceCreated(this, e);
        }

        public void OnNodeInstanceStarted(NodeInstanceStartedEventArgs e = null)
        {
            if (NodeInstanceStarted != null)
                NodeInstanceStarted(this, e);
        }

        public void OnNodeInstanceStopped(NodeInstanceStoppedEventArgs e = null)
        {
            if (NodeInstanceStopped != null)
                NodeInstanceStopped(this, e);
        }

        #endregion


        #region Forwards_NodeInstanceEvents

        // TODO: tester si un item au nom identique ne tourne pas deja
        public void pool_NodeInstanceStarted(object sender, NodeInstanceStartedEventArgs e)
        {
            OnNodeInstanceStarted(e);
        }

        public void pool_NodeInstanceStopped(object sender, NodeInstanceStoppedEventArgs e)
        {
            OnNodeInstanceStopped(e);
        }

        #endregion


        #region Methods

        public NodeInstance createNodeInstance(string nodeVersion, string name, string mainJsFilePath)
        {
            var i = new NodeInstance(nodeVersion);
            i.name = name;
            i.mainJsFilePath = mainJsFilePath;
            i.NodeInstanceStarted += new Event.NodeInstanceStartedEventHandler(pool_NodeInstanceStarted);
            i.NodeInstanceStopped += new Event.NodeInstanceStoppedEventHandler(pool_NodeInstanceStopped);
            _nodeInstances.Add(i);
            OnNodeInstanceCreated(new NodeInstanceCreatedEventArgs(i));
            return i;
        }

        /*public void addNodeInstance(NodeInstance i)
        {
            _nodeInstances.Add(i);
        }*/

        public void killAllNodeInstances()
        {
            foreach (NodeInstance i in _nodeInstances)
            {
                i.kill();
            }
        }

        public void startAllNodeInstances()
        {
            foreach (NodeInstance i in _nodeInstances)
            {
                i.run();
            }
        }

        public void restartAllNodeInstances()
        {
            foreach (NodeInstance i in _nodeInstances)
            {
                i.restart();
            }
        }

        public IEnumerable<NodeInstance> getAllNodeInstances()
        {
            return _nodeInstances;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            killAllNodeInstances();
            while (_nodeInstances.Count > 0)
            {
                _nodeInstances[0].Dispose();
                _nodeInstances[0] = null;
                _nodeInstances.RemoveAt(0);
            }
        }

        #endregion
    }
}
