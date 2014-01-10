using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace GuardianSync
{
    public partial class GuardianSyncService : ServiceBase
    {
        Timer _timer = null;

        public GuardianSyncService()
        {
            InitializeComponent();
            try
            {
                TraceLog.Write("Starting Service...", GetType());
                Synchronizer.Sync();
            }
            catch (Exception ex)
            {
                TraceLog.WriteException(ex, this.GetType(), MethodBase.GetCurrentMethod());
            }
            
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _timer = new Timer();
                _timer.Interval = Properties.Settings.Default.IntervalSeconds * 1000;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
                TraceLog.Write("Service started.", GetType());
            }
            catch (Exception ex)
            {
                TraceLog.WriteException(ex, this.GetType(), MethodBase.GetCurrentMethod());
            }

        }

        protected override void OnStop()
        {
            _timer.Elapsed -= _timer_Elapsed;
            _timer = null;

        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Synchronizer.Sync();
            }
            catch (Exception ex)
            {
                TraceLog.WriteException(ex, this.GetType(), MethodBase.GetCurrentMethod());
            }
        }
        

    }
}
