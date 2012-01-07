using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using nodepool.Event;
using nodepool.Tools;

namespace nodepool.Model
{
    public class NodeInstance : IDisposable
    {
        #region Attributes

        // Unique name given to the instance
        public string name;
        
        // Full path to main javascript file of the node application
        public string mainJsFilePath;

        // Restart this node instance on crash or not ??
        public bool restartOnCrash;

        // Restart this node instance on main file change?
        private bool _restartOnMainJsFileChange;

        // Node process
        private System.Diagnostics.Process _process;

        // File system change watcher
        private FileSystemWatcher _fsWatcher;

        // Directory from were run the script
        private String _workingDirectory;

        // Threa reading STDOUT of node process
        private System.Threading.Thread _readThread;

        // String, line by line of node's STDOUT
        private string _processOutputString;

        // Port used by nodejs to expose debug capabilities
        private int _debugPort;

        // Tells us if last run was in a debug context or as simple run
        private bool _lastlyDebugged;

        // nodejs version to use
        private string _nodeVersion;

        
        // Node inspector process
        private System.Diagnostics.Process _inspectorProcess;

        // Port used by node inspector to expose debugger UI via HTTP
        private int _webDebugPort;


        #endregion


        #region Properties


        public String workingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = value; }
        }

        public string nodeVersion
        {
            get { return _nodeVersion; }
        }

        public int webDebugPort
        {
            get { return _webDebugPort; }
        }

        public int debugPort
        {
            get { return _debugPort; }
        }

        public bool isDebugModeOn
        {
            get { return _lastlyDebugged; }
        }

        public bool isRunning
        {
            get { return (_process != null); }
        }

        public bool restartOnMainJsFileChange
        {
            get { return _restartOnMainJsFileChange; }
            set
            {
                if (value == true)
                {
                    //_fsWatcher = new FileSystemWatcher(Path.GetDirectoryName(mainJsFilePath), Path.GetFileName(mainJsFilePath));
                    _fsWatcher = new FileSystemWatcher();
                    _fsWatcher.Path = Path.GetDirectoryName(mainJsFilePath);
                    _fsWatcher.NotifyFilter = NotifyFilters.LastWrite;
                    /*_fsWatcher.NotifyFilter =
                        NotifyFilters.LastAccess |
                        NotifyFilters.CreationTime |
                        NotifyFilters.Size |
                        NotifyFilters.LastWrite |
                        NotifyFilters.FileName |
                        NotifyFilters.DirectoryName;*/

                    _fsWatcher.Filter = Path.GetFileName(mainJsFilePath);
                    _fsWatcher.Changed += new FileSystemEventHandler(_fsWatcher_Changed);
                    _fsWatcher.EnableRaisingEvents = true;

                    //Console.WriteLine("Start listerning fs");
                }
                else
                {
                    if (_fsWatcher != null)
                    {
                        _fsWatcher.Changed -= _fsWatcher_Changed;
                    }
                    _fsWatcher = null;
                }
                _restartOnMainJsFileChange = value;
            }
        }


        public string standardOutputString
        {
            get { return _processOutputString; }
        }

        #endregion

        #region Constructors

        public NodeInstance(String nodeVersion)
        {
            restartOnCrash = false;
            _lastlyDebugged = false;
            _restartOnMainJsFileChange = false;
            _fsWatcher = null;
            _debugPort = -1;
            _webDebugPort = -1;
            _processOutputString = "";
            _nodeVersion = nodeVersion;
            _workingDirectory = null;

            _readThread = new System.Threading.Thread(this.readingThread);
            _readThread.Start();


            // inspector is starting even if debug is never asked... that speeds up debugging if used later
            runInspector();
        }

        #endregion

        #region Events

        public event NodeInstanceStartedEventHandler NodeInstanceStarted;
        public event NodeInstanceStoppedEventHandler NodeInstanceStopped;
        public event NodeInstanceStandardOutputEventHandler NodeInstanceStandardOutput;

        #endregion


        #region EventShortCuts

        public void OnNodeInstanceStarted(NodeInstanceStartedEventArgs e = null)
        {
            if (NodeInstanceStarted != null)
                NodeInstanceStarted(this, e);

            String msg = "// [>] NODE STARTED //";
            if (_lastlyDebugged)
                msg += " DEBUG_PORT=" + _debugPort + " NODE_INSPECTOR_PORT=" + _webDebugPort;
            _processOutputString = _processOutputString + "\r\n" + msg;
            OnNodeInstanceStandardOutput(new NodeInstanceStandardOutputEventArgs(this, msg));
        }

        public void OnNodeInstanceStopped(NodeInstanceStoppedEventArgs e = null)
        {
            if (NodeInstanceStopped != null)
                NodeInstanceStopped(this, e);

            String msg = "// [x] NODE STOPPED //";
            _processOutputString = _processOutputString + "\r\n" + msg;
            OnNodeInstanceStandardOutput(new NodeInstanceStandardOutputEventArgs(this, msg));
        }

        public void OnNodeInstanceStandardOutput(NodeInstanceStandardOutputEventArgs e = null)
        {
            if (NodeInstanceStandardOutput != null)
                NodeInstanceStandardOutput(this, e);
            if (e!=null)
                Console.WriteLine("on data "+e.newString);
        }

        #endregion


        #region Methods

        /**
         * [EN]
         * Gets new debug port
         */
        public void regenerateDebugPort()
        {
            if (_debugPort == -1)
                _debugPort = LocalHost.getOpenedPort(8081);
            else
                _debugPort = LocalHost.getOpenedPort(_debugPort);
        }

        /**
         * [EN]
         * Gets new web debug port
         */
        public void regenerateWebDebugPort()
        {
            if (_webDebugPort == -1)
                _webDebugPort = LocalHost.getOpenedPort(8282);
            else
                _webDebugPort = LocalHost.getOpenedPort(_webDebugPort);
        }

        /**
         * Starts node inspector if not running yet
         */
        public bool runInspector()
        {
            String nodeInspectorMainFile = @".\Resources\node-inspector\bin\inspector.js";
            if (File.Exists(nodeInspectorMainFile) && _inspectorProcess == null)
            {

                regenerateWebDebugPort();

                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(
                    @".\Resources\nodejs\" + _nodeVersion + @"\node.exe",
                    " ./" + Path.GetFileName(nodeInspectorMainFile) + " --web-port=" + _webDebugPort);

                
                info.WorkingDirectory = Path.GetDirectoryName(nodeInspectorMainFile);
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                _inspectorProcess = System.Diagnostics.Process.Start(info);
                _inspectorProcess.EnableRaisingEvents = true;
                //_inspectorProcess.Exited += new EventHandler(process_Exited);
                //_inspectorProcess.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                //_inspectorProcess.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
                //OnNodeInstanceStarted(new NodeInstanceStartedEventArgs(this));
                






                System.Console.WriteLine("NODE INSPECTOR RUNNNNING");

                return true;
            }
            return false;
        }

        /**
         * Stops node inspector process
         */
        public void killInspector()
        {
            if (_inspectorProcess != null)
            {
                if (!_inspectorProcess.HasExited)
                {
                    /*foreach (var i in Process.GetProcessesByName(_process.ProcessName))
                        i.Kill();*/
                    _inspectorProcess.Kill();
                }
                _inspectorProcess = null;
                //OnNodeInstanceStopped(new NodeInstanceStoppedEventArgs(this));
            }
        }

        public void writeToStdIn(string p)
        {
            if (_process != null && !_process.HasExited)
            {
                _process.StandardInput.WriteLine(p);
            }
        }

        public void clearStandardOutputString()
        {
            _processOutputString = "";
        }

        /**
         * [EN]
         * Starts this node instance with debugging enabled on $_debugPort
         */
        public bool debug()
        {
            if (name != "" && File.Exists(mainJsFilePath) && _process == null)
            {

                _lastlyDebugged = true;
                regenerateDebugPort();
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(
                    @".\Resources\nodejs\" + _nodeVersion + @"\node.exe",
                    " --debug=" + _debugPort + " " + ((_workingDirectory != null) ? mainJsFilePath : Path.GetFileName(mainJsFilePath)));

                info.WorkingDirectory = _workingDirectory != null ? _workingDirectory : Path.GetDirectoryName(mainJsFilePath);
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                _process = System.Diagnostics.Process.Start(info);
                _process.EnableRaisingEvents = true;
                _process.Exited += new EventHandler(process_Exited);
                _process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                _process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
                OnNodeInstanceStarted(new NodeInstanceStartedEventArgs(this));
                return true;
            }
            return false;
        }




        /**
         * [EN]
         * Starts this node instance withOUT debugging
         */
        public bool run(String args = "")
        {
            if (name != "" && File.Exists(mainJsFilePath) && _process == null)
            {
                _lastlyDebugged = false;
                regenerateDebugPort();

                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(
                        @".\Resources\nodejs\" + _nodeVersion + @"\node.exe",
                        " " + ((_workingDirectory != null) ? mainJsFilePath : Path.GetFileName(mainJsFilePath)) + " " + args);
                
                info.WorkingDirectory = _workingDirectory != null ? _workingDirectory : Path.GetDirectoryName(mainJsFilePath);
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                
                _process = System.Diagnostics.Process.Start(info);
                _process.EnableRaisingEvents = true;
                _process.Exited += new EventHandler(process_Exited);
                _process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                _process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
                OnNodeInstanceStarted(new NodeInstanceStartedEventArgs(this));
                return true;
            }
            return false;
        }

        /**
         * [EN]
         * Kills this node instance X-/
         */
        public NodeInstance kill()
        {
            if (_process != null)
            {
                if (!_process.HasExited)
                {
                    /*foreach (var i in Process.GetProcessesByName(_process.ProcessName))
                        i.Kill();*/
                    _process.Kill();
                }
                _process = null;
                OnNodeInstanceStopped(new NodeInstanceStoppedEventArgs(this));
            }
            return this;
        }

        /**
         * [EN]
         * Restarts this node instance. Keeps the debug mode if it was active.
         */
        public void restart()
        {
            kill();
            Thread.Sleep(400);
            if (_lastlyDebugged)
                debug();
            else
                run();
        }

        #endregion


        #region ProcessEventHandlers

        /* Verifier si les evenements sont bien appelés, en tt cas si c la cas e.Data vaut rien du tt :/// */
        private void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine("process_ErrorDataReceived: " + e.Data);
        }

        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine("process_OutputDataReceived: "+e.Data);
        }

        private void process_Exited(object sender, System.EventArgs e)
        {
            if (_process != null)
            {
                try
                {
                    String b = "";
                    // On lit le stdOUT jusqu'au bout
                    while ((b = _process.StandardOutput.ReadLine()) != null)
                    {
                        //_processOutputString = b + "\r\n" + _processOutputString;
                        _processOutputString = _processOutputString + "\r\n" + b;
                        OnNodeInstanceStandardOutput(new NodeInstanceStandardOutputEventArgs(this, b));
                    }
                    // On lit le stdERR jusqu'au bout
                    while ((b = _process.StandardError.ReadLine()) != null)
                    {
                        //_processOutputString = b + "\r\n" + _processOutputString;
                        _processOutputString = _processOutputString + "\r\n" + b;
                        OnNodeInstanceStandardOutput(new NodeInstanceStandardOutputEventArgs(this, b));
                    }
                    

                    //Console.WriteLine(_process.StandardOutput.ReadToEnd());
                    //Console.WriteLine(_process.StandardError.ReadToEnd());
                    //Console.WriteLine("Exit time:    {0}\r\n" + "Exit code:    {1}\r\nElapsed time: ???", _process.ExitTime, _process.ExitCode);





                }
                catch
                {}

                _process = null;
                OnNodeInstanceStopped(new NodeInstanceStoppedEventArgs(this, true));
                if (restartOnCrash)
                    restart();
            }
        }

        #endregion


        #region FileSystemWatcherEventHandlers

        public void _fsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("file chenged " + e.FullPath);
            
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    restart();
                    break;

                case WatcherChangeTypes.Created:
                    restart();
                    break;

                case WatcherChangeTypes.Deleted:
                    kill();
                    break;

                case WatcherChangeTypes.Renamed:
                    kill();
                    break;
            }
        }

        #endregion


        #region ProcessOutputReaders

        private void readingThread()
        {
            Console.WriteLine("+Start node's output reading thread");
            string b = "";
            while (true)
            {
                if (_process != null && !_process.HasExited && (b = _process.StandardOutput.ReadLine()) != null)
                {
                    //_processOutputString = b + "\r\n" + _processOutputString;
                    _processOutputString = _processOutputString + "\r\n" + b;
                    OnNodeInstanceStandardOutput(new NodeInstanceStandardOutputEventArgs(this, b));
                }
                Thread.Sleep(5);
            }
        }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                _readThread.Abort();
                killInspector(); // inspector suicide
                Console.WriteLine("NodeInstance destructor");
            }
            catch
            { }
        }

        #endregion
    }
}
