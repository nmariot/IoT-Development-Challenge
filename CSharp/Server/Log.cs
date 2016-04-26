using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    static class Log
    {
        [Conditional("DEBUG")]
        public static void Debug(string message)
        {
            string msg = string.Format("{0:hh:mm:ss} {1}", DateTime.Now, message);
            Console.WriteLine(msg);
            System.Diagnostics.Debug.WriteLine(msg);

        }

        [Conditional("DEBUG")]
        public static void Debug(string message, params object[] args)
        {
            Debug(string.Format(message, args));
        }
    }
}
