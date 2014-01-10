using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ServiceProcess;

using System.Configuration.Install;
using GuardianSync;

namespace Install
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                var procesServiceInstaller = new ServiceProcessInstaller();
                procesServiceInstaller.Account = ServiceAccount.LocalSystem;

                var serviceInstallerObj = new ServiceInstaller();
                var path = String.Format("/assemblypath={0}", AppDomain.CurrentDomain.BaseDirectory + "GuardianSync.exe");
                String[] cmdline = { path };

                var context = new InstallContext(AppDomain.CurrentDomain.BaseDirectory + "TraceLog.txt", cmdline);
                serviceInstallerObj.Context = context;
                serviceInstallerObj.DisplayName = "GuardianService4";
                serviceInstallerObj.Description = "Synchronization for Guardian.";
                serviceInstallerObj.ServiceName = "GuardianService4";
                serviceInstallerObj.StartType = ServiceStartMode.Automatic;
                serviceInstallerObj.Parent = procesServiceInstaller;

                var state = new System.Collections.Specialized.ListDictionary();
                serviceInstallerObj.Install(state);
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, null, MethodBase.GetCurrentMethod());
            }

        }
    }
}
