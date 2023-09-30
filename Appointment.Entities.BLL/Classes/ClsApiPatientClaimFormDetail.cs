using Appointment.Entities.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
   public class ClsApiPatientClaimFormDetail
    {
        string SQLStr;
      
        [Required]
        public int PatientClaimDetailID { get; set; }
        public String ICD9 { get; set; }
        public String Diagnosis { get; set; }
        public int? PatientClaimFormID { get; set; }
        public Int16 TypeID { get; set; }
        public String Type { get; set; }
        public int WaitingID { get; set; }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into PatientClaimFormDetail ( ";
                SQLStr += " ICD9 ";
                SQLStr += " , Diagnosis ";
                SQLStr += " , PatientClaimFormID ";
                SQLStr += " , TypeID ";
                SQLStr += " , Type ";
                SQLStr += " , WaitingID ";
                SQLStr += " , UpdatedBy ";
                SQLStr += " , LastUpdated ";
                SQLStr += " ) values ( ";
                SQLStr += " @ICD9";
                SQLStr += " , @Diagnosis";
                SQLStr += " , @PatientClaimFormID";
                SQLStr += " , @TypeID";
                SQLStr += " , @Type";
                SQLStr += " , @WaitingID ";
                //SQLStr += " ,  " + Appointment.Properties.Settings.Default.UserID.ToString();
                SQLStr += " , GetDate() ";
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
                SQLStr = " Update PatientClaimFormDetail set ";
                SQLStr += " ICD9 = @ICD9";
                SQLStr += " , Diagnosis = @Diagnosis";
                SQLStr += " , PatientClaimFormID = @PatientClaimFormID";
                SQLStr += " , TypeID = @TypeID";
                SQLStr += " , Type = @Type";
                SQLStr += " , WaitingID =  @WaitingID ";
                //SQLStr += " ,  UpdatedBy = " + Appointment.Properties.Settings.Default.UserID.ToString();
                SQLStr += " , LastUpdated = GetDate() ";

                SQLStr += " Where PatientClaimDetailID = @PatientClaimDetailID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  PatientClaimFormDetail ";
                SQLStr += " Where PatientClaimDetailID = " + PatientClaimDetailID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  PatientClaimFormDetail ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientClaimFormDetail").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataByWaitingID()
        {
            try
            {
                SQLStr = " Select * From  PatientClaimFormDetail ";
                SQLStr += " Where  WaitingID = "+ WaitingID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetDataByWaitingID").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterDataByVisitID(int WaitingID)
        {
            //SP_Patient_ICD9
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {


                SQLPrameter = new SqlParameter("@VisitID", WaitingID);
                SQLPrameters[0] = SQLPrameter;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_ICD9", "FoundPatientICD9", SQLPrameters).Tables["FoundPatientICD9"];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        //SP_Patient_ICD9_OLD
        public DataTable FilterOldDataByVisitID(int WaitingID, int FileNo, int DoctorID)
        {
            //SP_Patient_ICD9
            SqlParameter[] SQLPrameters = new SqlParameter[3];
            SqlParameter SQLPrameterVisitID = null;
            SqlParameter SQLPrameterFileNo = null;
            SqlParameter SQLPrameterDoctorID = null;

            try
            {


                SQLPrameterVisitID = new SqlParameter("@VisitID", WaitingID);
                SQLPrameterFileNo = new SqlParameter("@FileNo", FileNo);
                SQLPrameterDoctorID = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameterVisitID;
                SQLPrameters[1] = SQLPrameterFileNo;
                SQLPrameters[2] = SQLPrameterDoctorID;

                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_ICD9_OLD", "FoundPatientICD9", SQLPrameters).Tables["FoundPatientICD9"];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameterVisitID = null;
                SQLPrameterFileNo = null;
                SQLPrameterDoctorID = null;

            }
        }
        public static Int16 DiagnosisCount(int WaitingID)
        {
            string SQLStr;
            try
            {
                SQLStr = " Select COALESCE( Count(PatientClaimDetailID),0) From  PatientClaimFormDetail ";
                SQLStr += "Where WaitingID = " + WaitingID.ToString();
                return Convert.ToInt16(GeneralFunctionsDAC.DDLScalarReader(SQLStr));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLStr = null;
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiPatientClaimFormDetail).GetProperty(myMatches[i].Value.Replace("@", ""));
                if (prop != null)
                {
                    SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                    if (typeof(ClsApiPatientClaimFormDetail).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
                    {
                        SQLPrameter.DbType = DbType.String;
                    }

                    else if (typeof(ClsApiPatientClaimFormDetail).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
                    {
                        SQLPrameter.DbType = DbType.Int16;
                    }
                    else if (typeof(ClsApiPatientClaimFormDetail).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
                    {
                        SQLPrameter.DbType = DbType.Int32;
                    }

                    else if (typeof(ClsApiPatientClaimFormDetail).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "System.Boolean")
                    {
                        SQLPrameter.DbType = DbType.Boolean;
                    }
                    SQLPrameters[SQLPrameters.Length - 1] = SQLPrameter;
                }
                i += 1;
            }
            return SQLPrameters;
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
        public DataTable FilterDataByPatientID(int DoctorID, int PatientID)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[3];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            SqlParameter SQLPrameter2 = null;
            try
            {


                SQLPrameter = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[1] = SQLPrameter1;
                SQLPrameter2 = new SqlParameter("@VisitID", WaitingID);
                SQLPrameters[2] = SQLPrameter2;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_PatientClaimFormDetail_CopyLastdiagnosis", "FoundPatientDiagnosis", SQLPrameters).Tables["FoundPatientDiagnosis"];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
                SQLPrameter1 = null;
            }
        }
    }
}
