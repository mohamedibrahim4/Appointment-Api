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
   public  class ClsApiPatientLabRequests
    {
        string SQLStr;
       

        public int LabTestID
        {
            get;
            set;
        }
        public int WaitingID
        {
            get;
            set;
        }
        public string TestCode
        {
            get;
            set;
        }
        public string Test
        {
            get;
            set;
        }
        public bool Done
        {
            get;
            set;
        }
        public int? TestID
        {
            get;
            set;
        }
        public int PatientID { get; set; }
        public string ResultDate
        {
            get;
            set;
        }
        public string ResultNotes
        {
            get;
            set;
        }
        public int? ResultStatus
        {
            get;
            set;
        }
      


        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into PatientLabRequests ( ";
                SQLStr += " TestID ";
                SQLStr += " , WaitingID ";
                SQLStr += " , TestCode ";
                SQLStr += " , Test ";
                //mb
                SQLStr += " , UpdatedBy ";
                SQLStr += " , LastUpdated ";

                SQLStr += " ) values ( ";
                SQLStr += " @TestID";
                SQLStr += " , @WaitingID";
                SQLStr += " , @TestCode";
                SQLStr += " , @Test";
                //mb
                //SQLStr += " , " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " , getdate()";

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
                SQLStr = " Update PatientLabRequests set ";
                SQLStr += " WaitingID = @WaitingID";
                SQLStr += " , TestCode = @TestCode";
                SQLStr += " , Test = @Test";
                SQLStr += " , Done = @Done";
                SQLStr += " , ResultDate = @ResultDate";
                SQLStr += " , ResultNotes = @ResultNotes";
                SQLStr += " , ResultStatus = @ResultStatus";
                SQLStr += " , LastUpdated = GetDate()";
                //SQLStr += " , UpdatedBy = @UpdatedBy";
                //mb
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;


                SQLStr += " Where LabTestID = @LabTestID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  PatientLabRequests ";
                SQLStr += " Where LabTestID = " + LabTestID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  PatientLabRequests ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientLabRequests").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData()
        {
            try
            {
                SQLStr = " Select * From  PatientLabRequests ";
                SQLStr += "Where WaitingID = " + WaitingID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientLabRequests").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  PatientLabRequests ";
                SQLStr += " Where LabTestID = " + LabTestID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientLabRequests").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterDataByVisitID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {


                SQLPrameter = new SqlParameter("@VisitID", WaitingID);
                SQLPrameters[0] = SQLPrameter;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_Lab_Requests_ByVisitID", "FoundPatientLab", SQLPrameters).Tables["FoundPatientLab"];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public SqlParameter[] CreateParameters(string sSQLStr)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[0];
            System.Text.RegularExpressions.MatchCollection myMatches;
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("@\\w+");
            myMatches = myRegex.Matches(sSQLStr);
            SqlParameter SQLPrameter = null;
            Int16 i = 0;
            while (i < myMatches.Count)
            {
                Array.Resize(ref SQLPrameters, SQLPrameters.Length + 1);
                System.Reflection.PropertyInfo prop = typeof(ClsApiPatientLabRequests).GetProperty(myMatches[i].Value.Replace("@", ""));
                if (prop != null)
                {
                    SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                    if (prop.GetValue(this, null) == null)
                    {
                        SQLPrameters[SQLPrameters.Length - 1] = SQLPrameter;
                        i += 1;
                        continue;
                    }

                    if (typeof(ClsApiPatientLabRequests).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
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

                    else if (typeof(ClsApiPatientLabRequests).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Double")
                    {

                        SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        SQLPrameter.DbType = DbType.Double;
                    }
                    else if (typeof(ClsApiPatientLabRequests).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
                    {
                        if (!prop.GetValue(this, null).Equals(Convert.ToInt16(0)))
                        {
                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        }
                        else
                        {
                            SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                        }
                        SQLPrameter.DbType = DbType.Int16;
                    }

                    else if (typeof(ClsApiPatientLabRequests).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
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

                    else if (typeof(ClsApiPatientLabRequests).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Boolean")
                    {
                        SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        SQLPrameter.DbType = DbType.Boolean;
                    }
                    else
                    {
                        SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                    }

                    SQLPrameters[SQLPrameters.Length - 1] = SQLPrameter;
                }
                i += 1;
            }
            return SQLPrameters;
        }

        public DataTable FilterOldlab(int PatientId, int DoctorID)
        {
            try
            {
                SQLStr = "select 0 as [LabTestID],[WaitingID] ,[TestID],[TestCode],[Test] from PatientLabRequests WHERE dbo.PatientLabRequests.WaitingID = (Select Max(VisitID) from  [dbo].[DoctorGP] inner join WaitingPatient on WaitingPatient.WaitingID=[dbo].[DoctorGP].VisitID ";
                SQLStr += " Where VisitID <>   " + WaitingID.ToString() + " and dbo.DoctorGP.FileNo =" + PatientId.ToString() + " and WaitingPatient.DoctorID =" + DoctorID.ToString() + ")";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientCPTRequests").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
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
        public bool EditSP()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = SQLUpdateSp();
                    cmd.CommandType = CommandType.Text;
                    SqlParameter[] a;
                    a = CreateParameters(SQLUpdateSp());
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
        public DataTable GetAppPatientLabs()
        {
            try
            {
                SQLStr = " select DoctorID,ArrDate,WaitingPatient.PatientID ,WaitingPatient.WaitingID  from WaitingPatient  inner join PatientLabRequests  on WaitingPatient.WaitingID=PatientLabRequests.WaitingID where WaitingPatient.PatientID= " + PatientID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppPatientLabs").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetLabsByWaiting()
        {
            try
            {
                SQLStr = " SELECT  [LabTestID],[WaitingID],[TestID],[TestCode],[Test],[Done],[ResultDate],[ResultNotes],[ResultStatus],[LastUpdated],[CDATE],[CUSER],[SampleCollected],[LabSubmitted] FROM [PatientLabRequests] where WaitingID= " + WaitingID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppPatientDrugs").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
