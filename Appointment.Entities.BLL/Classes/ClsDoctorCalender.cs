using Appointment.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
    public class ClsDoctorCalender
    {
        string SQLStr;     
        public int DocCalenderID
        {
            get;
            set;
        }
        public int DoctorID
        {
            get;
            set;
        }
        public virtual string AppDate
        {
            get;
            set;
        }
        public int PatientID
        {
            get;
            set;
        }
        public string Patient
        {
            get;
            set;
        }
        public string MobileNo
        {
            get;
            set;
        }
        public virtual string LastUpdated
        {
            get;
            set;
        }
        public virtual int UpdatedBy
        {
            get;
            set;
        }
        public Boolean Canceled
        {
            get;
            set;
        }
        public Boolean Attend
        {
            get;
            set;
        }
        public Boolean Finish
        {
            get;
            set;
        }
        public Int16 RoomID
        {
            get;
            set;
        }
        public int AppointmentReasonsID
        {
            get;
            set;
        }
        public string StDate
        {
            get;
            set;
        }
        public string EndDate
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public Int16 NonArabic
        {
            get;
            set;
        }
        public Int16 HowToKnow
        {
            get;
            set;
        }
        public Int16 StatusID
        {
            get;
            set;
        }
        public string Room
        {
            get;
            set;
        }
        public virtual string CreateDate
        {
            get;
            set;
        }
        public virtual string CreatedBy
        {
            get;
            set;
        }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into DoctorCalender ( ";

                SQLStr += "  DoctorID ";
                SQLStr += " , AppDate ";
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
                SQLStr += " , HowToKnow ";
                SQLStr += " , LastUpdated ";
             
                SQLStr += " ) values ( ";

                SQLStr += "  @DoctorID";
                SQLStr += " , @AppDate";
                SQLStr += " , @PatientID";
                SQLStr += " , @Patient";
                SQLStr += " , @MobileNo";
                SQLStr += " , @UpdatedBy";
                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , 0";
                SQLStr += " , @RoomID";
                SQLStr += " , @AppointmentReasonsID";
                SQLStr += " , @StDate";
                SQLStr += " , @EndDate";
                SQLStr += " , @Description";
                SQLStr += " , @NonArabic";
                SQLStr += " , @HowToKnow ";
                SQLStr += " ,getdate()";
       
                SQLStr += " ) ";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLUpdateSp()
        {
            try
            {
                SQLStr = " Update DoctorCalender set ";
                SQLStr += "   AppDate = @AppDate";
                SQLStr += "   DoctorID = @DoctorID";
                SQLStr += " , PatientID = @PatientID";
                SQLStr += " , Patient = @Patient";
                SQLStr += " , MobileNo = @MobileNo";
                SQLStr += " , LastUpdated = getdate()";
                SQLStr += " , UpdatedBy =@UpdatedBy ";
                SQLStr += " , RoomID = @RoomID";
                SQLStr += " , AppointmentReasonsID = @AppointmentReasonsID";
                SQLStr += " , StDate = @StDate";
                SQLStr += " , EndDate = @EndDate";
                SQLStr += " , Description = @Description";
                SQLStr += " , NonArabic = @NonArabic";               
                SQLStr += " , HowToKnow = @HowToKnow ";
                SQLStr += " Where DocCalenderID = @DocCalenderID";
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
                SQLStr += " LastUpdated = @LastUpdated";
                SQLStr += " , UpdatedBy = " + Properties.Settings.Default.UserID;
                SQLStr += " , Description = @Description";
                SQLStr += " Where DocCalenderID = @DocCalenderID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLUpdatePatient()
        {
            try
            {
                SQLStr = " Update DoctorCalender set ";
                SQLStr += " PatientID = @PatientID";
                SQLStr += " , Patient = @Patient";
                SQLStr += " , MobileNo = @MobileNo";
                SQLStr += " , LastUpdated = @LastUpdated";
                SQLStr += " , UpdatedBy = " + Properties.Settings.Default.UserID;
                SQLStr += " Where DocCalenderID = @DocCalenderID";
                return SQLStr;
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
                SQLStr += " , UpdatedBy = " + Properties.Settings.Default.UserID;
                SQLStr += " Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  DoctorCalender ";
                SQLStr += " Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  DoctorCalender ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorCalender").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetTimePeriodData()
        {
            try
            {
                SQLStr = " Select * From  TimePeriod ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "TimePeriod").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterDataForAllDoctors(string SearchDate, string EndSearchDate)
        {

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.Parameters.AddWithValue("@SearchDate", SearchDate);
                            cmd.Parameters.AddWithValue("@EndSearchDate", EndSearchDate);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_GetAppForAllDoctors";

                            da.SelectCommand = cmd;

                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable FilterDataForInpatient(string SearchDate, string EndSearchDate)
        {

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.Parameters.AddWithValue("@SearchDate", SearchDate);
                            cmd.Parameters.AddWithValue("@EndSearchDate", EndSearchDate);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_GetAppForInpatient";

                            da.SelectCommand = cmd;

                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }

                }
            }
            catch (Exception ex)
            { throw ex; }




            //try
            //{
            //    SQLStr = " SELECT     dbo.DoctorCalender.DocCalenderID, dbo.FunFormatDateString(dbo.DoctorCalender.AppDate) AS AppDate, dbo.FunFormatTimeString(dbo.DoctorCalender.AppDate) AS AppTime,  ";
            //    SQLStr += "          CONVERT(nvarchar(20), dbo.DoctorCalender.AppDate, 108) AS AppTimeOrd, COALESCE( dbo.DoctorCalender.PatientID,0) AS PatientID, dbo.DoctorCalender.Patient, dbo.DoctorCalender.MobileNo, DATEDIFF(day, dbo.DoctorCalender.StDate, ";
            //    SQLStr += "         dbo.DoctorCalender.EndDate) AS DayInterval, dbo.DoctorCalender.Description, coalEsce( dbo.DoctorCalender.StatusID,1) AS StatusID, dbo.Rooms.Room, dbo.AppointmentReasons.AppointmentReasons , dbo.FeePackages.FeePackage, dbo.DoctorCalender.Canceled, dbo.DoctorCalender.StDate, dbo.DoctorCalender.EndDate, dbo.DoctorCalender.DoctorID, Patients.OldFileNo ";
            //    SQLStr += " , dbo.DoctorCalender.FeePackageID,dbo.Doctors.ClinicID, dbo.DoctorCalender.NurseID, Doctors.Name AS Nurse, dbo.DoctorCalender.MachineID, Machines.MachineName ";
            //    SQLStr += " , Users_2.Name AS CUserName, Users_1.Name AS UpdatedByName,VisitStatus.VisitStatus, dbo.Patients.Notes "; //, Users_3.Name AS MakatingUser
            //    SQLStr += " FROM         dbo.DoctorCalender LEFT OUTER JOIN ";
            //    SQLStr += "          dbo.Patients ON dbo.DoctorCalender.PatientID = dbo.Patients.PatientID ";
            //    SQLStr += "  inner join VisitStatus on dbo.DoctorCalender.StatusID=VisitStatus.VisitStatusID";
            //   SQLStr += " LEFT OUTER JOIN AppointmentReasons ON dbo.DoctorCalender.AppointmentReasonsID =  AppointmentReasons.AppointmentReasonsID ";
            //    SQLStr += " LEFT OUTER JOIN Rooms ON dbo.DoctorCalender.RoomID =  Rooms.RoomID ";
            //    SQLStr += " LEFT OUTER JOIN dbo.FeePackages ON dbo.DoctorCalender.FeePackageID = dbo.FeePackages.FeePackageID ";
            //    SQLStr += " LEFT OUTER JOIN dbo.Doctors ON dbo.DoctorCalender.NurseID = dbo.Doctors.DoctorID ";
            //    SQLStr += " LEFT OUTER JOIN dbo.Machines ON dbo.DoctorCalender.MachineID = dbo.Machines.MachineID ";
            //    SQLStr += " INNER JOIN dbo.Users AS Users_2 ON Users_2.UserID = dbo.DoctorCalender.CUSER ";
            //    SQLStr += " INNER JOIN dbo.Users AS Users_1 ON dbo.DoctorCalender.UpdatedBy = Users_1.UserID";
            //   // SQLStr += " INNER JOIN dbo.Users AS Users_3 ON dbo.DoctorCalender.MakatingUserID = Users_3.UserID";

            //    SQLStr += " WHERE  ( DoctorCalender.AppDate between '" + SearchDate.ToString() + "' and '" + EndSearchDate .ToString() + "' ) ";


            //    return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorCalender").Tables[0];
            //}
            //catch (Exception ex)
            //{ throw ex; }
        }
        public DataTable FilterData(string SearchDate, string Status = "", string h = "")
        {
            try
            {
                SQLStr = " SELECT     dbo.DoctorCalender.DocCalenderID, dbo.FunFormatDateString(dbo.DoctorCalender.AppDate) AS AppDate, dbo.FunFormatTimeString(dbo.DoctorCalender.AppDate) AS AppTime,  ";
                SQLStr += "          CONVERT(nvarchar(20), dbo.DoctorCalender.AppDate, 108) AS AppTimeOrd, COALESCE( dbo.DoctorCalender.PatientID,0) AS PatientID, dbo.DoctorCalender.Patient, dbo.DoctorCalender.MobileNo, DATEDIFF(Mi, dbo.DoctorCalender.StDate, ";
                SQLStr += "         dbo.DoctorCalender.EndDate) AS Interval, dbo.DoctorCalender.Description, coalEsce( dbo.DoctorCalender.StatusID,1) AS StatusID, dbo.Rooms.Room, dbo.AppointmentReasons.AppointmentReasons , dbo.FeePackages.FeePackage, dbo.DoctorCalender.Canceled, dbo.DoctorCalender.StDate, dbo.DoctorCalender.EndDate, dbo.DoctorCalender.DoctorID, Patients.OldFileNo ";
                SQLStr += " , dbo.DoctorCalender.FeePackageID, dbo.DoctorCalender.NurseID, Doctors.Name AS Nurse, dbo.DoctorCalender.MachineID, Machines.MachineName ";
                SQLStr += " , Users_2.Name AS CUserName, Users_1.Name AS UpdatedByName, dbo.Patients.Notes "; //, Users_3.Name AS MakatingUser
                SQLStr += " FROM         dbo.DoctorCalender LEFT OUTER JOIN ";
                SQLStr += "          dbo.Patients ON dbo.DoctorCalender.PatientID = dbo.Patients.PatientID ";
                SQLStr += " LEFT OUTER JOIN AppointmentReasons ON dbo.DoctorCalender.AppointmentReasonsID =  AppointmentReasons.AppointmentReasonsID ";
                SQLStr += " LEFT OUTER JOIN Rooms ON dbo.DoctorCalender.RoomID =  Rooms.RoomID ";
                SQLStr += " LEFT OUTER JOIN dbo.FeePackages ON dbo.DoctorCalender.FeePackageID = dbo.FeePackages.FeePackageID ";
                SQLStr += " LEFT OUTER JOIN dbo.Doctors ON dbo.DoctorCalender.NurseID = dbo.Doctors.DoctorID ";
                SQLStr += " LEFT OUTER JOIN dbo.Machines ON dbo.DoctorCalender.MachineID = dbo.Machines.MachineID ";
                SQLStr += " INNER JOIN dbo.Users AS Users_2 ON Users_2.UserID = dbo.DoctorCalender.CUSER ";
                SQLStr += " INNER JOIN dbo.Users AS Users_1 ON dbo.DoctorCalender.UpdatedBy = Users_1.UserID";
                // SQLStr += " INNER JOIN dbo.Users AS Users_3 ON dbo.DoctorCalender.MakatingUserID = Users_3.UserID";

                SQLStr += " WHERE ( Convert(nvarchar(25),DoctorCalender.AppDate,105)= '" + SearchDate.ToString() + "'  OR dbo.DoctorCalender.StatusID = 31 ) ";


                //SQLStr += " AND  dbo.DoctorCalender.Canceled = 0 ";
                if (DoctorID != 0)
                {
                    SQLStr += " AND dbo.DoctorCalender.DoctorID = " + DoctorID.ToString();
                }
                if (Status != "")
                {
                    SQLStr += " AND dbo.DoctorCalender.StatusID in ( " + Status + " ) ";
                }
                if (RoomID != 0)
                {
                    SQLStr += " AND dbo.DoctorCalender.RoomID = " + RoomID.ToString();
                }
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorCalender").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData(string SearchStDate, string SearchEndDate, Boolean CanceledApp = false)
        {
            try
            {
                SQLStr = " SELECT     dbo.DoctorCalender.DocCalenderID, dbo.FunFormatDateString(dbo.DoctorCalender.AppDate) AS AppDate, dbo.FunFormatTimeString(dbo.DoctorCalender.AppDate) AS AppTime,  ";
                SQLStr += "          CONVERT(nvarchar(20), dbo.DoctorCalender.AppDate, 108) AS AppTimeOrd,COALESCE( dbo.DoctorCalender.PatientID,0) AS PatientID, dbo.DoctorCalender.Patient, dbo.DoctorCalender.MobileNo, DATEDIFF(Mi, dbo.DoctorCalender.StDate, ";
                SQLStr += "         dbo.DoctorCalender.EndDate) AS Interval, dbo.DoctorCalender.Description, coalEsce( COALESCE (  dbo.WaitingPatient.VisitStatusID, dbo.DoctorCalender.StatusID),1) AS StatusID, dbo.AppointmentReasons.AppointmentReasons, dbo.FeePackages.FeePackage, dbo.DoctorCalender.Canceled, dbo.DoctorCalender.StDate, dbo.DoctorCalender.EndDate, dbo.DoctorCalender.DoctorID ";
                SQLStr += " , COALESCE (  dbo.WaitingPatient.WaitingID , 0 ) AS WaitingID , Doctors.Name AS DoctorName ";
                SQLStr += " , dbo.DoctorCalender.AppointmentReasonsID,  dbo.DoctorCalender.RoomID , dbo.Rooms.Room";
                SQLStr += " , dbo.FunFormatTimeString(dbo.WaitingPatient.ArrDate) AS CheckIN , dbo.FunFormatTimeString(dbo.WaitingPatient.EndDate) AS CheckOut ";
                SQLStr += " , dbo.WaitingPatient.ArrDate, Doctors.ClinicID ";
                SQLStr += " , dbo.WaitingPatient.CategoryID, FeeCategory.Category, VisitStatusColor, dbo.DoctorCalender.FeePackageID , dbo.DoctorCalender.NurseID, Users.Name AS Nurse ";
                SQLStr += " FROM         dbo.DoctorCalender LEFT OUTER JOIN ";
                SQLStr += "          dbo.Patients ON dbo.DoctorCalender.PatientID = dbo.Patients.PatientID ";
                SQLStr += "          LEFT OUTER JOIN WaitingPatient ON dbo.DoctorCalender.DocCalenderID = dbo.WaitingPatient.DocCalendarID ";
                SQLStr += "  LEFT OUTER JOIN FeeCategory ON WaitingPatient.CategoryID = FeeCategory.CategoryID ";
                SQLStr += " LEFT OUTER JOIN AppointmentReasons ON dbo.DoctorCalender.AppointmentReasonsID =  AppointmentReasons.AppointmentReasonsID ";
                SQLStr += " LEFT OUTER JOIN Rooms ON dbo.DoctorCalender.RoomID =  Rooms.RoomID ";
                SQLStr += "  INNER JOIN VisitStatus ON VisitStatus.VisitStatusID = coalEsce( COALESCE (  dbo.WaitingPatient.VisitStatusID, dbo.DoctorCalender.StatusID),1) ";
                SQLStr += " INNER JOIN Doctors ON  dbo.DoctorCalender.DoctorID = Doctors.DoctorID ";
                SQLStr += " LEFT OUTER JOIN dbo.FeePackages ON dbo.DoctorCalender.FeePackageID = dbo.FeePackages.FeePackageID ";
                SQLStr += " LEFT OUTER JOIN dbo.Users ON dbo.DoctorCalender.NurseID = dbo.Users.UserID ";
                if (SearchEndDate == "")
                {
                    SQLStr += " WHERE Convert(nvarchar(25),DoctorCalender.AppDate,105)= '" + SearchStDate.ToString() + "' ";
                }
                else
                {
                    SQLStr += " WHERE DoctorCalender.AppDate between '" + SearchStDate.ToString() + "'  and  '" + SearchEndDate.ToString() + "'";
                }
                if (CanceledApp == true)
                {
                    SQLStr += " AND  dbo.DoctorCalender.Canceled = 0 ";
                }
                if (DoctorID != 0)
                {
                    SQLStr += " AND dbo.DoctorCalender.DoctorID = " + DoctorID.ToString();
                }

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorCalender").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterAppByPatientID()
        {
            try
            {
                SQLStr = " select DocCalenderID as AppID ,dbo.FunFormatDateString( StDate) as AppDate  ,dbo.FunFormatTimeString(StDate) as AppTime , Patient , MobileNo , Description , Users.Name AS UpdatedBy , dbo.FunFormatDateTimeString(DoctorCalender.LastUpdated) AS LastUpdated, Doctors.Name as DoctorName , VisitStatus.VisitStatus as status, StDate AS OrdDate, coalEsce( dbo.DoctorCalender.StatusID,1) AS StatusID ";
                SQLStr += " ,  DoctorCalender.DoctorID , Doctors.ClinicID  ,  DoctorCalender.PatientID ";
                SQLStr += " from DoctorCalender , Doctors , VisitStatus, Users ";
                SQLStr += " where DoctorCalender.DoctorID = Doctors.DoctorID and DoctorCalender.StatusID= VisitStatus.VisitStatusID ";
                SQLStr += " AND DoctorCalender.UpdatedBy = Users.UserID ";
                if (PatientID != 0)
                {
                    SQLStr += " and PatientID = " + PatientID.ToString();
                }
                else if (MobileNo != "")
                {
                    SQLStr += " and MobileNo like '" + MobileNo.ToString() + "'";
                }
                SQLStr += " Order By OrdDate Desc ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorCalender").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlDataReader FindData()
        {
            try
            {
                SQLStr = " Select *,datediff(mi,StDate,EndDate) AS Interval ,  InvoiceDetail.Description AS ServiceDesc From  DoctorCalender ";
                SQLStr += " LEFT Outer Join InvoiceDetail ON DoctorCalender.InvoiceDetailID = InvoiceDetail.InvoiceDetailID ";
                SQLStr += " Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DDLReader(SQLStr);
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
                    System.Reflection.PropertyInfo prop = typeof(ClsDoctorCalender).GetProperty(myMatches[i].Value.Replace("@", ""));
                    if (prop != null)
                    {

                        if (typeof(ClsDoctorCalender).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
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

                        else if (typeof(ClsDoctorCalender).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Double")
                        {

                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            SQLPrameter.DbType = DbType.Double;
                        }
                        else if (typeof(ClsDoctorCalender).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
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

                        else if (typeof(ClsDoctorCalender).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
                        {
                            if (!prop.GetValue(this, null).Equals(0))
                            {
                                SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            }
                            else
                            {
                                //SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                                SQLPrameter = new SqlParameter(prop.Name, Convert.ToInt32(0));
                            }
                            SQLPrameter.DbType = DbType.Int32;
                        }

                        else if (typeof(ClsDoctorCalender).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "System.Boolean")
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
                { throw new Exception("ClsDoctorCalender - CreateParameters " + myMatches[i].Value.ToString() + ex.Message.ToString()); }
            }
        }
        public int InsertSP()
        {
            SqlConnection con = new SqlConnection();
            SqlTransaction transaction1;

            con.Open();
            transaction1 = con.BeginTransaction();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SP_DoctorCalenderApi_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    SqlParameter ParDocCalenderID = new SqlParameter();
                    ParDocCalenderID.ParameterName = "@DocCalenderID";
                    ParDocCalenderID.DbType = DbType.Int32;
                    ParDocCalenderID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ParDocCalenderID);

                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters["@DocCalenderID"].Value.ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Dispose(); }
        }
        public bool EditSP(string SQLSP)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = SQLSP;
                    cmd.CommandType = CommandType.Text;
                    SqlParameter[] a;
                    a = CreateParameters(SQLSP);
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
        public Boolean AttendApp()
        {
            try
            {

                SQLStr = " Update DoctorCalender set ";
                SQLStr += " Attend = 1 ";
                SQLStr += " , StatusID = 2 ";
                SQLStr += " , UpdatedBy = " + Properties.Settings.Default.UserID;
                SQLStr += "Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Boolean UpdateStatus()
        {
            try
            {

                SQLStr = " Update DoctorCalender set ";
                SQLStr += " StatusID = " + StatusID.ToString();
                SQLStr += " , UpdatedBy = " + Properties.Settings.Default.UserID;
                SQLStr += "Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int InsertintoWaitingTable()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SP_WaitingPatient_DoctorCalender_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ParDocCalenderID = new SqlParameter();
                    ParDocCalenderID.ParameterName = "@DocCalenderID";
                    ParDocCalenderID.DbType = DbType.Int32;
                    ParDocCalenderID.Direction = ParameterDirection.Input;
                    ParDocCalenderID.Value = DocCalenderID;
                    cmd.Parameters.Add(ParDocCalenderID);

                    SqlParameter ParUpdatedBy = new SqlParameter();
                    ParUpdatedBy.ParameterName = "@UpdatedBy";
                    ParUpdatedBy.DbType = DbType.Int32;
                    ParUpdatedBy.Direction = ParameterDirection.Input;
                    ParUpdatedBy.Value = UpdatedBy;
                    cmd.Parameters.Add(ParUpdatedBy);

                    SqlParameter ParWaitingID = new SqlParameter();
                    ParWaitingID.ParameterName = "@WaitingID";
                    ParWaitingID.DbType = DbType.Int32;
                    ParWaitingID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ParWaitingID);

                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters["@WaitingID"].Value.ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Dispose(); }


            //try
            //{

            //    SQLStr = " insert into WaitingPatient (DoctorID,AppDate,TimeID,PatientID,Patient,UpdatedBy, DocCalendarID, CategoryID,VisitStatusID) ";
            //    SQLStr += " Select DoctorCalender.DoctorID , AppDate , AppTimeID , PatientID , Patient , " + UpdatedBy + " , DocCalenderID, ";
            //    SQLStr += " (Select InsuranceCompany From Patients WHERE Patients.PatientID = DoctorCalender.PatientID ),2 ";
            //    SQLStr += " from DoctorCalender ";
            //    SQLStr += " Where ( DocCalenderID = " + DocCalenderID.ToString() + " ) ";
            //    //SP_WaitingPatient_DoctorCalender_Insert

            //    return GeneralFunctionsDAC.DMLStatment(SQLStr);

            //}
            //   catch(Exception ex)
            //{
            //       throw ex;
            //   }

        }
        public Boolean PatientFinish()
        {
            SQLStr = " Update DoctorCalender set ";
            SQLStr += " Finish = 1 ";
            SQLStr += " , UpdatedBy = " + Properties.Settings.Default.UserID;
            SQLStr += "Where DocCalenderID = " + DocCalenderID.ToString();
            return GeneralFunctionsDAC.DMLStatment(SQLStr);
        }
        //public Boolean ValidateData(int CalenderID = 0)
        //{
        //    SqlDataReader dr = null; ;

        //    try

        //    {
        //        if (StDate.Substring(0, 9) != EndDate.Substring(0, 9))
        //        {
        //            return true;
        //        }
        //        SQLStr = "Select DocCalenderID, PatientID, Patient From DoctorCalender ";
        //        SQLStr += " WHERE StDate is not null ";
        //        SQLStr += " AND DoctorID = " + DoctorID.ToString();
        //        SQLStr += " AND convert(datetime,'" + StDate.ToString() + "') ";

        //        SQLStr += " between StDate  AND dateadd(minute , -1, EndDate) ";

        //        SQLStr += " AND Canceled = 0 ";
        //        if (RoomID != 0)
        //        {
        //            SQLStr += " AND RoomID = " + RoomID;
        //        }
        //        //if (MachineID != 0)
        //        //{
        //        //    SQLStr += " AND MachineID = " + MachineID;
        //        //}
        //        if (CalenderID != 0)
        //        {
        //            SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
        //        }
        //        dr = GeneralFunctionsDAC.DDLReader(SQLStr);
        //        if (dr.HasRows == true)
        //        {
        //            dr.Read();
        //            throw new Exception("The Start Time is already Booked For Patient " + dr["Patient"].ToString());
        //        }
        //        SQLStr = "Select DocCalenderID, PatientID, Patient  From DoctorCalender ";
        //        SQLStr += " WHERE StDate is not null ";
        //        SQLStr += " AND DoctorID = " + DoctorID.ToString();
        //        SQLStr += " AND convert(datetime,'" + EndDate.ToString() + "') ";
        //        SQLStr += " between dateadd(minute , 1, StDate)  AND EndDate ";
        //        SQLStr += " AND Canceled = 0 ";
        //        if (RoomID != 0)
        //        {
        //            SQLStr += " AND RoomID = " + RoomID;
        //        }
        //        if (CalenderID != 0)
        //        {
        //            SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
        //        }
        //        dr = GeneralFunctionsDAC.DDLReader(SQLStr);
        //        if (dr.HasRows == true)
        //        {
        //            dr.Read();
        //            throw new Exception("The End Time is already Booked Patient " + dr["Patient"].ToString());
        //        }
        //        if (RoomID > 0)
        //        {
        //            ValidateRoomData(CalenderID);
        //        }
        //        if (MachineID > 0)
        //        {
        //            ValidateMachineData(CalenderID);
        //        }

        //        if (NurseID > 0)
        //        {
        //            ValidateNurseData(CalenderID);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            if (dr.IsClosed == false)
        //            {
        //                dr.Close();
        //            }
        //            dr = null;
        //        }
        //    }

        //}
        public Boolean ValidateRoomData(int CalenderID = 0)
        {
            SqlDataReader dr;

            try
            {
                SQLStr = "Select DocCalenderID From DoctorCalender ";
                SQLStr += " WHERE StDate is not null ";

                SQLStr += " AND convert(datetime,'" + StDate.ToString() + "') ";

                SQLStr += " between StDate  AND dateadd(minute , -1, EndDate) ";

                SQLStr += " AND Canceled = 0 ";
                if (RoomID != 0)
                {
                    SQLStr += " AND RoomID = " + RoomID;
                }
                if (CalenderID != 0)
                {
                    SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
                }
                dr = GeneralFunctionsDAC.DDLReader(SQLStr);
                if (dr.HasRows == true)
                {
                    throw new Exception("The Start Time is already Booked for This Room");
                }
                SQLStr = "Select DocCalenderID From DoctorCalender ";
                SQLStr += " WHERE StDate is not null ";

                SQLStr += " AND convert(datetime,'" + EndDate.ToString() + "') ";
                SQLStr += " between dateadd(minute , 1, StDate)  AND EndDate ";
                SQLStr += " AND Canceled = 0 ";
                if (RoomID != 0)
                {
                    SQLStr += " AND RoomID = " + RoomID;
                }
                if (CalenderID != 0)
                {
                    SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
                }
                dr = GeneralFunctionsDAC.DDLReader(SQLStr);
                if (dr.HasRows == true)
                {
                    throw new Exception("The End Time is already Booked For This Room");
                }


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr = null;
            }

        }
        //public Boolean ValidateMachineData(int CalenderID = 0)
        //{
        //    SqlDataReader dr;

        //    try
        //    {
        //        SQLStr = "Select DocCalenderID From DoctorCalender ";
        //        SQLStr += " WHERE StDate is not null ";

        //        SQLStr += " AND convert(datetime,'" + StDate.ToString() + "') ";

        //        SQLStr += " between StDate  AND dateadd(minute , -1, EndDate) ";

        //        SQLStr += " AND Canceled = 0 ";
        //        if (MachineID != 0)
        //        {
        //            SQLStr += " AND MachineID = " + MachineID;
        //        }
        //        if (CalenderID != 0)
        //        {
        //            SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
        //        }
        //        dr = GeneralFunctionsDAC.DDLReader(SQLStr);
        //        if (dr.HasRows == true)
        //        {
        //            throw new Exception("The Start Time is already Booked for This Machine");
        //        }
        //        SQLStr = "Select DocCalenderID From DoctorCalender ";
        //        SQLStr += " WHERE StDate is not null ";

        //        SQLStr += " AND convert(datetime,'" + EndDate.ToString() + "') ";
        //        SQLStr += " between dateadd(minute , 1, StDate)  AND EndDate ";
        //        SQLStr += " AND Canceled = 0 ";
        //        if (MachineID != 0)
        //        {
        //            SQLStr += " AND MachineID = " + MachineID;
        //        }
        //        if (CalenderID != 0)
        //        {
        //            SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
        //        }
        //        dr = GeneralFunctionsDAC.DDLReader(SQLStr);
        //        if (dr.HasRows == true)
        //        {
        //            throw new Exception("The End Time is already Booked For This Machine");
        //        }


        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dr = null;
        //    }

        //}
        //public Boolean ValidateNurseData(int CalenderID = 0)
        //{
        //    SqlDataReader dr;

        //    try
        //    {
        //        SQLStr = "Select DocCalenderID From DoctorCalender ";
        //        SQLStr += " WHERE StDate is not null ";

        //        SQLStr += " AND convert(datetime,'" + StDate.ToString() + "') ";

        //        SQLStr += " between StDate  AND dateadd(minute , -1, EndDate) ";

        //        SQLStr += " AND Canceled = 0 ";
        //        if (NurseID != 0)
        //        {
        //            SQLStr += " AND NurseID = " + NurseID;
        //        }
        //        if (CalenderID != 0)
        //        {
        //            SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
        //        }
        //        dr = GeneralFunctionsDAC.DDLReader(SQLStr);
        //        if (dr.HasRows == true)
        //        {
        //            throw new Exception("The Start Time is already Booked for This Nurse");
        //        }
        //        SQLStr = "Select DocCalenderID From DoctorCalender ";
        //        SQLStr += " WHERE StDate is not null ";

        //        SQLStr += " AND convert(datetime,'" + EndDate.ToString() + "') ";
        //        SQLStr += " between dateadd(minute , 1, StDate)  AND EndDate ";
        //        SQLStr += " AND Canceled = 0 ";
        //        if (NurseID != 0)
        //        {
        //            SQLStr += " AND NurseID = " + NurseID;
        //        }
        //        if (CalenderID != 0)
        //        {
        //            SQLStr += " AND DocCalenderID <> " + CalenderID.ToString();
        //        }
        //        dr = GeneralFunctionsDAC.DDLReader(SQLStr);
        //        if (dr.HasRows == true)
        //        {
        //            throw new Exception("The End Time is already Booked For This NurseID");
        //        }


        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dr = null;
        //    }

        //}

        public DataTable FilterNonArabic()
        {
            try
            {
                SQLStr = " select NonArabic ";
                SQLStr += " from DoctorCalender ";
                SQLStr += " where DoctorCalender.DocCalenderID = " + DocCalenderID.ToString();

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "FilterNonArabic").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetAppointmentByDate()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("StartDate", StDate);
                sqlParameters[1] = new SqlParameter("EndDate", EndDate);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_GetAppointmentByDate", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetAppointmentByDateAndDoctor()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("StartDate", StDate);
                sqlParameters[1] = new SqlParameter("EndDate", EndDate);
                sqlParameters[2] = new SqlParameter("DoctorID", DoctorID);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_GetAppointmentByDateAndDoctor", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetAppointmentHistoryByMobile()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("MobileNo", MobileNo);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_FindAppointmentHistoryByMobile", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetLastAppointmentHistoryByPatientID()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("PatientID", PatientID);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_FindAppointmentHistoryByPatientID", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetAppointmentHistoryByPatientID()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("PatientID", PatientID);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_FindAppointmentHistoryFileNo", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetAppointmentHistoryByDocCalenderID()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("DocCalenderID", DocCalenderID);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_FindAppointmentHistoryDocCalenderID", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetFutureAppointment()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("Patient", Patient);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_FindFutureAppointment", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }

}
