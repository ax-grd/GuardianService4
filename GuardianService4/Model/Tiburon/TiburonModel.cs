using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GuardianService4.Model.Guardian;
using GuardianService4.Model.Tiburon.TiburonTableAdapters;
using System.Reflection;

namespace GuardianService4.Model.Tiburon
{
    public class TiburonModel
    {

        private TiburonModel()
        {
        }

        #region Instance

        private static TiburonModel _instance;
        public static TiburonModel Instance
        {
            get
            {
                if(_instance == null) _instance = new TiburonModel();
                return _instance;
            }
        }

        #endregion

        #region GetInmateHazards

        public List<InmateHazard> GetInmateHazards()
        {
            var result = new List<InmateHazard>();
            try
            {
                using (var adapter = new Inmate_Hazards_spTableAdapter())
                {
                    foreach (Tiburon.Inmate_Hazards_spRow row in adapter.GetData())
                    {
                        var obj = new InmateHazard()
                            {
                                BookingNbr = row.Booking
                                ,SSN = row.JRN
                                ,Hazard_Code = row.Hazard_Code
                                ,Hazard_Literal = row.Hazard_Literal
                                ,Start_Date = row.Start_Date
                                ,Start_Time = row.Start_Time
                                ,Authorized_by_Operator = row.Authorized_by_Operator
                                ,Clear_Date = row.Clear_Date
                                ,Clear_Time = row.Clear_Time
                                ,Cleared_by_Operator = row.Cleared_by_Operator
                                ,Remarks = row.Remarks
                            };
                        result.Add(obj);
                    }

                }
            }
            catch (Exception e)
            {                
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }

            return result;
        }

        #endregion

        #region GetInmates

        public List<Tiburon.Inmates_In_Custody_spRow> GetInmates()
        {
            var result = new List<Tiburon.Inmates_In_Custody_spRow>();

            try
            {
                using (var adapter = new Inmates_In_Custody_spTableAdapter())
                {
                    result = adapter.GetData().ToList();
                }
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }
            return result;
        }

        #endregion

        #region GetInmateKeepSeparates

        public List<InmateKeepSeparate> GetInmateKeepSeparates()
        {
            var result = new List<InmateKeepSeparate>();

            try
            {

                using (var adapter = new Inmate_Keep_Separate_spTableAdapter())
                {

                    foreach (Tiburon.Inmate_Keep_Separate_spRow row in adapter.GetData())
                    {
                        const string format = "MM/dd/yy";

                        DateTime startDate;
                        var isStartDate = DateTime.TryParseExact(row.Start_Date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                        DateTime endDate;
                        var isEndDate = DateTime.TryParseExact(row.End_Date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                        DateTime clearDate;
                        var isClearDate = DateTime.TryParseExact(row.Clear_Date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out clearDate);

                        var obj = new InmateKeepSeparate()
                        {
                            BookingNbr = row.Booking,
                            SSN_Inmate_must_be_kept_away_from = row.JRN_Inmate_must_be_kept_away_from,
                            SSN_inmate = row.JRN_inmate,
                            Start_Date = isStartDate ? (DateTime?)startDate : null,
                            End_Date = isEndDate ? (DateTime?)endDate : null,
                            Clear_Date = isClearDate ? (DateTime?)clearDate : null,
                        };
                        result.Add(obj);
                    }

                }

            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }

            return result;    

        }

        #endregion

        #region GetInmateRestrictions

        public List<InmateRestriction> GetInmateRestrictions()
        {
            var result = new List<InmateRestriction>();

            try
            {
                using (var adapter = new Inmate_Restrictions_spTableAdapter())
                {
                    foreach (Tiburon.Inmate_Restrictions_spRow row in adapter.GetData())
                    {
                        var obj = new InmateRestriction()
                            {
                                BookingNbr = row.Booking,
                                SSN = row.JRN,
                                Lockdown = row.Lockdown,
                                Lockdown_From_Date = row.Lockdown_From_Date,
                                Lockdown_From_Time = row.Lockdown_From_Time,
                                Lockdown_To_Date = row.Lockdown_To_Date,
                                Lockdown_To_Time = row.Lockdown_To_Time,
                                Lockdown_Days = row.Lockdown_Days,
                                Phone = row.Phone,
                                Phone_From_Date = row.Phone_From_Date,
                                Phone_To_Date = row.Phone_To_Date,
                                Phone_Days = row.Phone_Days,
                                Rem_Program = row.Rem_Program,
                                Program_From_Date = row.Program_From_Date,
                                Program_To_Date = row.Program_To_Date,
                                Program_Days = row.Program_Days,
                                Commissary = row.Commissary,
                                Comm_From_Date = row.Comm_From_Date,
                                Comm_To_Date = row.Comm_To_Date,
                                Comm_Days = row.Comm_Days,
                                Television = row.Television,
                                TV_From_Date = row.TV_From_Date,
                                TV_To_Date = row.TV_To_Date,
                                TV_Days = row.TV_Days,
                                Visitation = row.Visitation,
                                Visit_From_Date = row.Visit_From_Date,
                                Visit_To_Date = row.Visit_To_Date,
                                Visit_Days = row.Visit_Days,
                            };
                        result.Add(obj);
                    }

                }
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }

            return result;
        }

        #endregion
    }
}
