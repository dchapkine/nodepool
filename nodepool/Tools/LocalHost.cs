using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;

namespace nodepool.Tools
{
    public class LocalHost
    {
        /**
         * [EN]
         * Gets nearest opened port on local host, starting from min
         * 
         * @see http://stackoverflow.com/questions/570098/in-c-how-to-check-if-a-tcp-port-is-available
         */
        public static int getOpenedPort(int min = 8080)
        {
            int port = min-1;
            bool isAvailable = false;

            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] objEndPoints = ipGlobalProperties.GetActiveTcpListeners();

            while (!isAvailable)
            {
                isAvailable = true;
                port++;
                foreach (IPEndPoint tcpi in objEndPoints)
                {
                    if (tcpi.Port == port)
                    {
                        isAvailable = false;
                        break;
                    }
                }
            }

            return port;
        }

        /**
         * [EN]
         * Lists installed versions of node
         */
        public static List<String> listInstalledNodeVersions()
        {
            String nodeMainDir = Path.Combine(Directory.GetCurrentDirectory(), "Resources/nodejs");
            List<String> ret = new List<String>();

            var nodeVersions = Directory.GetDirectories(nodeMainDir, "node*");
            foreach (string directory in nodeVersions)
            {
                ret.Add(new DirectoryInfo(directory).Name);
            }

            return ret;
        }

        /**
         * [EN]
         * Returns latest installed node version
         */
        public static String getLatestInstalledNodeVersion()
        {
            List<String> v = listInstalledNodeVersions();
            if (v.Count > 0)
            {
                return v[v.Count - 1];
            }
            return null;
        }
    }
}
