using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GuardianService4.Model.Guardian
{
    public class GuardianModel
    {
        private GuardianModel()
        {
        }

        #region Instance

        private static GuardianModel _instance;
        public static GuardianModel Instance
        {
            get
            {
                if(_instance == null) _instance = new GuardianModel();
                return _instance;
            }
        }

        #endregion

        public void RecreateInmateHazards(List<InmateHazard> inmateHazards)
        {
            try
            {
                using (var entity = new GuardianEntity())
                {
                    foreach (InmateHazard obj in entity.InmateHazards)
                    {
                        entity.DeleteObject(obj);
                    }

                    foreach (InmateHazard obj in inmateHazards)
                    {
                        entity.AddToInmateHazards(obj);
                    }
                    entity.SaveChanges();
                }
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }
        }

        public void MergeInmates(List<Tiburon.Tiburon.Inmates_In_Custody_spRow> inmates)
        {
            try
            {
                using (var entity = new GuardianEntity())
                {


                    foreach (Tiburon.Tiburon.Inmates_In_Custody_spRow row in inmates)
                    {
                        var exists = true;
                        var inmate = entity.Inmates.FirstOrDefault(x => x.SSN == row.JRN);
                        var cell = entity.Cells.FirstOrDefault(x => x.JSID == row.Room);

                        if (inmate == null)
                        {
                            inmate = new Inmate();
                            exists = false;
                        }

                        if (cell == null)
                        {
                            TraceLog.Write("Cannot " +  (exists ? "merge" : "create") + " Inmate SSN = '" + row.JRN + "' because Cell.JSID = '" + row.Room + "' does not exists", GetType(), MethodBase.GetCurrentMethod());
                            continue;
                        }

                        if (!exists)
                        {
                            entity.AddToInmates(inmate);
                        }


                        if(
                            !exists
                            || inmate.CurrentBookingNbr != row.Booking
                            || inmate.InmateLastName != row.InmateLastName
                            || inmate.InmateFirstName != row.InmateFirstName
                            || inmate.InmateMidName != row.InmateMiddleName
                            || inmate.DOB != row.DOB
                            || inmate.Race != row.Race
                            || inmate.Sex != row.Sex
                            || inmate.Height != row.Height
                            || inmate.Weight != row.Weight
                            || inmate.Hair != row.Hair
                            || inmate.Eyes != row.Eyes
                            || inmate.SSN != row.JRN
                            || inmate.Photo != row.Mug
                            || inmate.Cell != cell
                            )
                        {
                            inmate.CurrentBookingNbr = row.Booking;
                            inmate.InmateLastName = row.InmateLastName;
                            inmate.InmateFirstName = row.InmateFirstName;
                            inmate.InmateMidName = row.InmateMiddleName;
                            inmate.DOB = row.DOB;
                            inmate.Race = row.Race;
                            inmate.Sex = row.Sex;
                            inmate.Height = row.Height;
                            inmate.Weight = row.Weight;
                            inmate.Hair = row.Hair;
                            inmate.Eyes = row.Eyes;
                            inmate.SSN = row.JRN;
                            inmate.Photo = row.Mug;
                            //row.Active - Ignore
                            //row.Unit - Ignore
                            inmate.Cell = cell;
                            inmate.last_modified = DateTime.Now;
                        }
                    }

                    entity.SaveChanges();

                }
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }
            
        }

        public void RecreateInmateKeepSeparates(List<InmateKeepSeparate> inmatesKeepSeparate)
        {
            try
            {
                using (var entity = new GuardianEntity())
                {
                    foreach (InmateKeepSeparate obj in entity.InmateKeepSeparates)
                    {
                        entity.DeleteObject(obj);
                    }

                    foreach (InmateKeepSeparate obj in inmatesKeepSeparate)
                    {
                        entity.AddToInmateKeepSeparates(obj);
                    }
                    entity.SaveChanges();
                }
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }          
        }

        public void RecreateRestrictions(List<InmateRestriction> restrictions)
        {
            try
            {
                using (var entity = new GuardianEntity())
                {
                    foreach (InmateRestriction obj in entity.InmateRestrictions)
                    {
                        entity.DeleteObject(obj);
                    }

                    foreach (InmateRestriction obj in restrictions)
                    {
                        entity.AddToInmateRestrictions(obj);
                    }
                    entity.SaveChanges();
                }
            }
            catch (Exception e)
            {
                TraceLog.WriteException(e, GetType(), MethodBase.GetCurrentMethod());
            }           
            
        }

    }
}
