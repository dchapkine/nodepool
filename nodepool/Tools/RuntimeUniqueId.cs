using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nodepool.Tools
{
    class RuntimeUniqueId
    {
        private static int _id = 1;

        public static int getAsInt()
        {
            return _id++;
        }

        public static string getAsString()
        {
            return String.Format("{0}", getAsInt());
        }
    }
}
