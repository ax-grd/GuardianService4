using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using GuardianService4.Model.Guardian;
using GuardianService4.Model.Tiburon;

namespace GuardianService4
{
    public class Synchronizer
    {

        public static void Sync()
        {

            SyncInmates();
            SyncInmateHazards();
            SyncInmateKeepSeparates();
            SyncInmateRestrictions();

        }

        #region Private Methods

        private static void SyncInmateRestrictions()
        {
            try
            {
                var restrictions = TiburonModel.Instance.GetInmateRestrictions();
                GuardianModel.Instance.RecreateRestrictions(restrictions);
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, typeof(Synchronizer), MethodBase.GetCurrentMethod());
            }
        }

        private static void SyncInmateKeepSeparates()
        {
            try
            {
                var inmatesKeepSeparate = TiburonModel.Instance.GetInmateKeepSeparates();
                GuardianModel.Instance.RecreateInmateKeepSeparates(inmatesKeepSeparate);
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, typeof(Synchronizer), MethodBase.GetCurrentMethod());
            }
        }

        private static void SyncInmateHazards()
        {
            try
            {
                var inmateHazards = TiburonModel.Instance.GetInmateHazards();
                GuardianModel.Instance.RecreateInmateHazards(inmateHazards);
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, typeof(Synchronizer), MethodBase.GetCurrentMethod());
            }

        }

        private static void SyncInmates()
        {
            try
            {
                var inmates = TiburonModel.Instance.GetInmates();
                GuardianModel.Instance.MergeInmates(inmates);
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, typeof(Synchronizer), MethodBase.GetCurrentMethod());
            }
        }

        #endregion


    }
}
