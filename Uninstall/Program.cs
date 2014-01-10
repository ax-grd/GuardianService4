using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ServiceProcess;

using System.Configuration.Install;
using GuardianSync;

namespace Uninstall
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var serviceInstallerObj = new ServiceInstaller();
                var context = new InstallContext(AppDomain.CurrentDomain.BaseDirectory + "TraceLog.txt", null);
                serviceInstallerObj.Context = context;
                serviceInstallerObj.ServiceName = "GuardianService4";
                serviceInstallerObj.Uninstall(null); 
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, null, MethodBase.GetCurrentMethod());
            }

        }
    }
}
