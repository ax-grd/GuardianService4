using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GuardianSync
{
    public class TraceLog
    {
        public static void WriteException(Exception ex, Type ownerType, MethodBase method)
        {            
            while (true)
            {
                if(ex.InnerException == null) break;
                ex = ex.InnerException;
            }
            Write(ex.Message, ownerType, method);
        }

        public static void Write(string message, Type ownerType, MethodBase method = null)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "TraceLog.txt";
                string timenow = DateTime.Now.ToLongTimeString();
                string logMessage = 
                        timenow + ": ["
                                + (ownerType == null ? "" : ownerType.Name)
                                + (method == null ? "" : ("." + method.Name))
                                + "] " 
                                + message;
                var sw = new StreamWriter(path, true);
                sw.WriteLine(logMessage);
                sw.Close();
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Trace: {0}", ex.Message));
            }
        }

    }
}
