using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

namespace nodepool.Tools
{
    public class LocalHost
    {
        /**
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
    }
}
