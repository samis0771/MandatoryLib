using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using System.Diagnostics;

namespace MandatoryLib.LoggerAndPrintMSG
{
    public static class Logger
    {

        public static void WriteLog(string message)
        {
            string logPath = "C:/Users/gamin/Desktop/log.txt";

            using (StreamWriter w = new StreamWriter(logPath, true))
            {
                w.WriteLine($"{DateTime.Now} : {message}");
            }

            Trace.WriteLine(message);
        }
    }
}
