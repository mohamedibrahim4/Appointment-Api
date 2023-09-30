using Appointment.Entities.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
 public   class ClsApiAppointment
    {
        string SQLStr = "";
        [Required]
        public int DocCalenderID { get; set; }
        public int DoctorID { get; set; }
        public string AppDate { get; set; }
        //public int AppTimeID { get; set; }
        public int PatientID { get; set; }
        public string Patient { get; set; }
        public string MobileNo { get; set; }
        //public bool Canceled { get; set; }
        //public bool Attend { get; set; }
        //public bool Finish { get; set; }
        //public short RoomID { get; set; }
        public string StDate { get; set; }
        public string EndDate { get; set; }
        public int TeleMedicine { get; set; }
        public bool Canceled { get; set; }
        //public string Description { get; set; }
        //public short StatusID { get; set; }
        //public int FeePackageID { get; set; }
        //public int FeeBackageDetailID { get; set; }
        //public int NurseID { get; set; }
        //public string AuthorizationNo { get; set; }
        //public short AuthStatusID { get; set; }
        //public int AssisstantDoctorID { get; set; }
        public List<AvailableTime> GetAllSlot(DateTime RequestDate)
        {
            int startTime = int.Parse(ConfigurationManager.AppSettings.Get("AppStartTime"));
            int EndTime = int.Parse(ConfigurationManager.AppSettings.Get("AppEndTime"));
            int SlotVal = int.Parse(ConfigurationManager.AppSettings.Get("AppInterval"));
            DateTime start = RequestDate.AddHours(startTime);
            DateTime End = RequestDate.AddHours(EndTime);
            //DateTime End = RequestDate.Add(EndTime);
            List<AvailableTime> times = new List<AvailableTime>();
            for (DateTime appointment = start; appointment < End; appointment = appointment.AddMinutes(SlotVal))
            {
                AvailableTime available = new AvailableTime();
                available.StartTime = appointment;
                available.EndTime = appointment.AddMinutes(SlotVal);
                times.Add(available);
            }
            return times;
        }
        public List<AvailableTime> GetAllSlotBeforeNow(DateTime RequestDate)
        {
            int startTime = int.Parse(ConfigurationManager.AppSettings.Get("AppStartTime"));
            int EndTime = int.Parse(ConfigurationManager.AppSettings.Get("AppEndTime"));
            int SlotVal = int.Parse(ConfigurationManager.AppSettings.Get("AppInterval"));
            List<int> slotinhours= new List<int>();
            int RequestDateH = RequestDate.Hour;
            if (RequestDateH >= startTime && RequestDateH <= EndTime)
            {
                for (int i = 0; i <= 60; i+= SlotVal)
                {
                    slotinhours.Add(i);
                } 

            }
            int RequestDateM = RequestDate.Minute;
            int ClosestMinute = slotinhours.Aggregate((x,y) => Math.Abs(x- RequestDateM) <Math.Abs(y- RequestDateM) ?x:y);

            if (RequestDateM > ClosestMinute)
            {
                ClosestMinute = 0;
            }

            DateTime start = RequestDate.AddHours(startTime);
            DateTime End = RequestDate.AddMinutes(ClosestMinute);
            
            List<AvailableTime> times = new List<AvailableTime>();
            for (DateTime appointment = start; appointment < End; appointment = appointment.AddMinutes(SlotVal))
            {
                AvailableTime available = new AvailableTime();
                available.StartTime = appointment;
                available.EndTime = appointment.AddMinutes(SlotVal);
                times.Add(available);
            }
            return times;
        }
        public DataTable GetBookedAppForDr(string RequestDate, int DoctorID)
        {

            try
            {
                SQLStr = " Select StDate as startDate,EndDate From  DoctorCalender ";
                SQLStr += " WHERE StDate between  '" + RequestDate + " 00:00:00' and '" + RequestDate;
                SQLStr += " 23:59:59' and EndDate between  '" + RequestDate + " 00:00:00' and '" + RequestDate;
                SQLStr += " 23:59:59' and   DoctorID =  " + DoctorID;

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetBookedAppForDr").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into DoctorCalender ( ";

                SQLStr += "  DoctorID ";
                SQLStr += " , AppDate ";
                SQLStr += " , AppTimeID ";
                SQLStr += " , PatientID ";
                SQLStr += " , Patient ";
                SQLStr += " , MobileNo ";

                SQLStr += " , UpdatedBy ";
                SQLStr += " , Canceled ";
                SQLStr += " , Attend ";
                SQLStr += " , Finish ";
                SQLStr += " , RoomID ";
                SQLStr += " , AppointmentReasonsID ";
                SQLStr += " , StDate ";
                SQLStr += " , EndDate ";
                SQLStr += " , Description ";
                SQLStr += " , NonArabic ";
                SQLStr += " , FeePackageID ";
                SQLStr += " , NurseID ";
                SQLStr += " , MachineID ";
                SQLStr += " , MakatingUserID ";
                SQLStr += " , CategoryID ";
                SQLStr += " , InvoiceDetailID ";
                SQLStr += " , Gross ";
                SQLStr += " , Net ";
                SQLStr += " , TeleMedicine ";

                SQLStr += " ) values ( ";

                SQLStr += "  @DoctorID";
                SQLStr += " , @AppDate";
                SQLStr += " , NULL";
                SQLStr += " , @PatientID";
                SQLStr += " , @Patient";
                SQLStr += " , @MobileNo";

                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , @StDate";
                SQLStr += " , @EndDate";
                SQLStr += " , 0";
                SQLStr += " ,0";
                SQLStr += " , 0 ";
                SQLStr += " , 0";
                SQLStr += " , 0 ";
                SQLStr += " , 0";
                SQLStr += " , 0 ";
                SQLStr += " , 0 ";
                SQLStr += " , 0 ";
                SQLStr += " , 0 ";
                SQLStr += " , @TeleMedicine ";

                SQLStr += " ) ";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLUpdateDescription()
        {
            try
            {
                SQLStr = " Update DoctorCalender set ";
                SQLStr += " DoctorID = @DoctorID";
                SQLStr += " , AppDate = @AppDate";
                SQLStr += " , PatientID = @PatientID";
                SQLStr += " , Patient = @Patient";
                SQLStr += " , MobileNo = @MobileNo";
                SQLStr += " , StDate = @StDate";
                SQLStr += " , EndDate = @EndDate";
                SQLStr += " , TeleMedicine = @TeleMedicine";

                SQLStr += " Where DocCalenderID = @DocCalenderID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlParameter[] CreateParameters(string sSQLStr)
        {
            System.Text.RegularExpressions.MatchCollection myMatches;
            Int16 i = 0;
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("@\\w+");
            myMatches = myRegex.Matches(sSQLStr);
            try
            {
                SqlParameter[] SQLPrameters = new SqlParameter[0];



                SqlParameter SQLPrameter = null;

                while (i < myMatches.Count)
                {
                    Array.Resize(ref SQLPrameters, SQLPrameters.Length + 1);
                    System.Reflection.PropertyInfo prop = typeof(ClsApiAppointment).GetProperty(myMatches[i].Value.Replace("@", ""));
                    if (prop != null)
                    {

                        if (typeof(ClsApiAppointment).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
                        {

                            if (!prop.GetValue(this, null).Equals(""))
                            {
                                SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            }
                            else
                            {
                                SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                            }
                            SQLPrameter.DbType = DbType.String;

                        }

                        else if (typeof(ClsApiAppointment).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Double")
                        {

                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            SQLPrameter.DbType = DbType.Double;
                        }
                        else if (typeof(ClsApiAppointment).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
                        {
                            if (!prop.GetValue(this, null).Equals(0))
                            {
                                SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            }
                            else
                            {
                                SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                            }
                            SQLPrameter.DbType = DbType.Int16;
                        }

                        else if (typeof(ClsApiAppointment).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
                        {
                            if (!prop.GetValue(this, null).Equals(0))
                            {
                                SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            }
                            else
                            {
                                SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                            }
                            SQLPrameter.DbType = DbType.Int32;
                        }

                        else if (typeof(ClsApiAppointment).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "System.Boolean")
                        {
                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            SQLPrameter.DbType = DbType.Boolean;
                        }
                        SQLPrameters[SQLPrameters.Length - 1] = SQLPrameter;
                    }
                    i += 1;
                }
                return SQLPrameters;
            }
            catch (Exception ex)
            {
                { throw new Exception("ClsApiAppointment - CreateParameters " + myMatches[i].Value.ToString() + ex.Message.ToString()); }
            }
        }
        public bool InsertSP()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = SQLInsertSp();
                    cmd.CommandType = CommandType.Text;
                    SqlParameter[] a;
                    a = CreateParameters(SQLInsertSp());
                    for (Int16 i = 0; i <= a.Length - 1; i++)
                    {
                        if (GeneralFunctionsDAC.IsNumeric(a[i].Value.ToString()) == true)
                        {
                            if (a[i].Value == null)
                            { a[i].Value = DBNull.Value; }
                        }
                        else
                        {
                            if (a[i].Value.ToString() == "")
                            {
                                a[i].Value = DBNull.Value;
                            }
                        }
                        cmd.Parameters.Add(a[i]);
                    }
                    if (cmd.ExecuteNonQuery() > 0)
                    { return true; }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Dispose(); }
        }
        public bool EditSP(string UpdateSQL)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = UpdateSQL;
                    cmd.CommandType = CommandType.Text;
                    SqlParameter[] a;
                    a = CreateParameters(UpdateSQL);
                    for (Int16 i = 0; i <= a.Length - 1; i++)
                    {
                        if (GeneralFunctionsDAC.IsNumeric(a[i].Value.ToString()) == true)
                        {
                            if (a[i].Value == null)
                            { a[i].Value = DBNull.Value; }
                        }
                        else
                        {
                            if (a[i].Value.ToString() == "")
                            {
                                a[i].Value = DBNull.Value;
                            }
                        }
                        cmd.Parameters.Add(a[i]);
                    }
                    if (cmd.ExecuteNonQuery() > 0)
                    { return true; }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Dispose(); }
        }
        public DataTable GetAllAppForDr( int DoctorID)
        {

            try
            {
                SQLStr = " Select * From  DoctorCalender ";
                SQLStr += " WHERE DoctorID =  " + DoctorID;
                

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetAllAppForDr").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetAllAppForPatient(int PatientID)
        {

            try
            {
                SQLStr = " Select * From  DoctorCalender ";
                SQLStr += " WHERE PatientID =  " + PatientID;


                return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetAllAppForPatient").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean AppCanceled()
        {
            try
            {
                SQLStr = " Update DoctorCalender set ";
                SQLStr += " Canceled = 1, ";
                SQLStr += " StatusID = 15 ";
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetNonWorkingTimePerDr(string RequestDate, int DoctorID)
        {
            try
            {
                SQLStr = " Select StartDateTime as startDate,EndDateTime as EndDate From  DoctorNonWorkingTime";
                SQLStr += " WHERE StartDateTime between  '" + RequestDate + " 00:00:00' and '" + RequestDate;
                SQLStr += " 23:59:59' and EndDateTime between  '" + RequestDate + " 00:00:00' and '" + RequestDate;
                SQLStr += " 23:59:59' and   DoctorID =  " + DoctorID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetNonWorkingTimePerDr").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<AvailableTime> FragmentNonWorkToSlot(DateTime startPar, DateTime EndPar)
        {
            int SlotVal = int.Parse(ConfigurationManager.AppSettings.Get("AppInterval"));
            DateTime start = startPar;
            DateTime End = EndPar;
            List<AvailableTime> times = new List<AvailableTime>();
            for (DateTime appointment = start; appointment < End; appointment = appointment.AddMinutes(SlotVal))
            {
                AvailableTime available = new AvailableTime();
                available.StartTime = appointment;
                available.EndTime = appointment.AddMinutes(SlotVal);
                times.Add(available);
            }
            return times;
        }
        public List<NonWorkingSlotsObj> FragmentNonWorkToSlotDoctorID(DateTime startPar, DateTime EndPar, int DoctorID)
        {
            int SlotVal = int.Parse(ConfigurationManager.AppSettings.Get("AppInterval"));
            DateTime start = startPar;
            DateTime End = EndPar;
            List<NonWorkingSlotsObj> times = new List<NonWorkingSlotsObj>();
            for (DateTime appointment = start; appointment < End; appointment = appointment.AddMinutes(SlotVal))
            {
                NonWorkingSlotsObj available = new NonWorkingSlotsObj();
                available.StartTime = appointment;
                available.EndTime = appointment.AddMinutes(SlotVal);
                available.DoctorID = DoctorID;
                times.Add(available);
            }
            return times;
        }
        public DataTable GetNonWorkingTimePeriodc(string RequestDate, int DoctorID)
        {
            try
            {
                SQLStr = " Select StartDateTime as startDate,EndDateTime as EndDate,DoctorID From  DoctorNonWorkingTime";
                SQLStr += " WHERE StartDateTime between  '" + RequestDate + " 00:00:00' and '" + RequestDate;
                SQLStr += " 23:59:59' and EndDateTime between  '" + RequestDate + " 00:00:00' and '" + RequestDate;
                SQLStr += " 23:59:59' and   DoctorID =  " + DoctorID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetNonWorkingTimePerDr").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }



    }








    public class AvailableTime
        {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //public int CompareTo(object obj)
        //{
        //    AvailableTime availableTime = (AvailableTime)obj;
        //    return availableTime.StartTime.CompareTo(this.StartTime);
        //}

     

        public override bool Equals(object obj)
        {
            if (obj is AvailableTime)
            {
                AvailableTime availableTime = (AvailableTime)obj;
                if (this.StartTime.Equals(availableTime.StartTime) || this.EndTime.Equals(availableTime.EndTime))
                    return true;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return (this.StartTime.GetHashCode() + this.EndTime.GetHashCode());
        }



    }
    public class NonWorkingSlotsObj
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorID { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is AvailableTime)
            {
                AvailableTime availableTime = (AvailableTime)obj;
                if (this.StartTime.Equals(availableTime.StartTime) || this.EndTime.Equals(availableTime.EndTime))
                    return true;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return (this.StartTime.GetHashCode() + this.EndTime.GetHashCode());
        }



    }

}
