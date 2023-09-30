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
    public class ClsDoctors
    {
        string SQLStr;
        //int _DoctorID;
        //string _Name;
        //int _DoctorSpecialityID;
        //string _Mobile;
        //string _HomeTel;
        //string _PasspoerNo;
        //int _NationalityID;
        //DateTime _PasswordExp;
        //string _CardID;
        //DateTime _CardExp;
        //Int16 _SexID;
        //Int16 _DoctorCategoryID;
        //Int16 _MaritalStatusID;
        //string _Email;
        //DateTime _LastUpdated;
        //int _UpdatedBy;
        //int _ClinicID;
        //string _LicenseNo;
        //int _BranchID;

        #region "class Properties "
        public int DoctorID
        {
            get;

            set;
            
        }
        public string Name
        {
            get;


            set;
            
        }
        public int? DoctorSpecialityID
        {
            get;


            set;
            
        }
        public string Mobile
        {
            get;


            set;
            
        }
        public string HomeTel
        {
            get;


            set;
            
        }
        public string PasspoerNo
        {
            get;


            set;
            
        }
        public int NationalityID
        {
            get;


            set;
            
        }
        public DateTime PasswordExp
        {
            get;


            set;
            
        }
        public string CardID
        {
            get;


            set;
            
        }
        public DateTime? CardExp
        {
            get;


            set;
            
        }
        public Int16? SexID
        {
            get;


            set;
            
        }
        public Int16? DoctorCategoryID
        {
            get;


            set;
            
        }
        public Int16? MaritalStatusID
        {
            get;


            set;
            
        }
        public string Email
        {
            get;


            set;
            
        }
        public DateTime? LastUpdated
        {
            get;


            set;
            
        }
        public int? UpdatedBy
        {
            get;


            set;
            
        }
        public int? ClinicID
        {
            get;


            set;
            
        }
        public string LicenseNo
        {
            get;
            set;
        }
        public int? BranchID
        {
            get;
            set;
        }
        #endregion
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into Doctors ( ";
                SQLStr += "DoctorID ";
                SQLStr += " , Name ";
                SQLStr += " , DoctorSpecialityID ";
                SQLStr += " , Mobile ";
                SQLStr += " , HomeTel ";
                SQLStr += " , PasspoerNo ";
                SQLStr += " , NationalityID ";
                SQLStr += " , PasswordExp ";
                SQLStr += " , CardID ";
                SQLStr += " , CardExp ";
                SQLStr += " , SexID ";
                SQLStr += " , DoctorCategoryID ";
                SQLStr += " , MaritalStatusID ";
                SQLStr += " , Email ";
                SQLStr += " , LastUpdated ";
                SQLStr += " , UpdatedBy ";
                SQLStr += " , ClinicID ";
                SQLStr += " ) values ( ";
                SQLStr += " @DoctorID";
                SQLStr += " , @Name";
                SQLStr += " , @DoctorSpecialityID";
                SQLStr += " , @Mobile";
                SQLStr += " , @HomeTel";
                SQLStr += " , @PasspoerNo";
                SQLStr += " , @NationalityID";
                SQLStr += " , @PasswordExp";
                SQLStr += " , @CardID";
                SQLStr += " , @CardExp";
                SQLStr += " , @SexID";
                SQLStr += " , @DoctorCategoryID";
                SQLStr += " , @MaritalStatusID";
                SQLStr += " , @Email";
                SQLStr += " , @LastUpdated";
                SQLStr += " , @UpdatedBy";
                SQLStr += " , @ClinicID";
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
                SQLStr = " Update Doctors set ";
                SQLStr += " Name = @Name";
                SQLStr += " , DoctorSpecialityID = @DoctorSpecialityID";
                SQLStr += " , Mobile = @Mobile";
                SQLStr += " , HomeTel = @HomeTel";
                SQLStr += " , PasspoerNo = @PasspoerNo";
                SQLStr += " , NationalityID = @NationalityID";
                SQLStr += " , PasswordExp = @PasswordExp";
                SQLStr += " , CardID = @CardID";
                SQLStr += " , CardExp = @CardExp";
                SQLStr += " , SexID = @SexID";
                SQLStr += " , DoctorCategoryID = @DoctorCategoryID";
                SQLStr += " , MaritalStatusID = @MaritalStatusID";
                SQLStr += " , Email = @Email";
                SQLStr += " , LastUpdated = @LastUpdated";
                SQLStr += " , UpdatedBy = @UpdatedBy";
                SQLStr += " , ClinicID = @ClinicID";
                SQLStr += " Where DoctorID = @DoctorID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  Doctors ";
                SQLStr += " Where DoctorID = " + DoctorID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  Doctors ";
                SQLStr += " WHERE Active = 1 ";
                SQLStr += " AND BranchID =  "+BranchID.ToString();
                //SQLStr += "  AND dbo.[Doctors].BranchID = " + Appointment.Entities.BLL.Properties.Settings.Default.BranchID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataByWorkingTime(string SearchTime)
        {
            try
            {
                SQLStr = " Select * From  Doctors ";
                SQLStr += " WHERE Active = 1 ";
                //SQLStr += "  AND dbo.[Doctors].BranchID = " + Appointment.Properties.Settings.Default.BranchID;
                //SQLStr += " AND DoctorID in (Select DoctorID from DoctorNonWorkingTime WHERE '" + SearchTime.ToString() + "' between StartDateTime and EndDateTime) ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDoctorForPh()
        {
            try
            {
                SQLStr = " SELECT [DoctorID] ";
                SQLStr += " ,[Name] AS DoctorName ";
                SQLStr += " ,[LicenseNo] as DoctorLic ";
                SQLStr += " FROM [Appointment].[dbo].[Doctors] ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PhDoctors").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable FilterData()
        {
            try
            {
                SQLStr = " Select * From  Doctors Order By Name";
                //SQLStr += "Where Name like '" + Name.ToString() + "'";

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterDataByClinic()
        {

            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@ClinicID", ClinicID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@BranchID", Convert.ToInt32(Properties.Settings.Default.BranchID));
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_GetDoctors", "FoundDoctors", SQLPrameters).Tables["FoundDoctors"];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  Doctors ";
                SQLStr += " Where DoctorID = " + DoctorID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
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
                System.Reflection.PropertyInfo prop = typeof(ClsDoctors).GetProperty(myMatches[i].Value.Replace("@", ""));
                if (prop != null)
                {
                    if (!GeneralFunctionsDAC.IsDate(prop.GetValue(this, null).ToString()))
                    {
                        SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        if (GeneralFunctionsDAC.IsDate(prop.GetValue(this, null).ToString()))
                        {
                            if (!prop.GetValue(this, null).Equals(DateTime.MinValue))
                            {
                                SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            }
                            else
                            {
                                SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                            }
                        }
                        SQLPrameters[SQLPrameters.Length - 1] = SQLPrameter;
                    }
                }
                i += 1;
            }
            return SQLPrameters;
        }
        public string GetDocLicenseNo()
        {
            SQLStr = " Select LicenseNo From Doctors ";
            SQLStr += " WHERE DoctorID = " + DoctorID.ToString();
            return Convert.ToString(GeneralFunctionsDAC.DDLScalarReader(SQLStr));
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
                    cmd.CommandText = SQLInsertSp();
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
        public Int32 GetClinicIDByDoctorID()
        {
            try
            {
                SQLStr = " Select ClinicID From  Doctors ";
                SQLStr += " WHERE DoctorID = " + DoctorID;
                SQLStr += " AND Active = 1 ";
                SQLStr += "  AND dbo.[Doctors].BranchID = " +Properties.Settings.Default.BranchID;

                return Convert.ToInt32(GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0].Rows[0]["ClinicID"]);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
