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
    public class ClsAppointmentReasons
    {
        string SQLStr;
        //int _AppointmentReasonsID;
        //string _AppointmentReasons;
        //int _ClinicID;
        //Int16 _Color;
        //Int16 _Interval;
        #region "class Properties "
        public int AppointmentReasonsID
        {
            get;
            set;
        }
        public string AppointmentReasons
        {
            get;
            set;
        }
        public int? ClinicID
        {
            get;
            set;
        }
        public Int16? Color
        {
            get;
            set;
        }
        public Int16? Interval
        {
            get;
            set;
        }
        #endregion
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into AppointmentReasons ( ";
                SQLStr += "AppointmentReasonsID ";
                SQLStr += " , AppointmentReasons ";
                SQLStr += " , ClinicID ";
                SQLStr += " , Color ";
                SQLStr += " , Interval ";
                SQLStr += " ) values ( ";
                SQLStr += " @AppointmentReasonsID";
                SQLStr += " , @AppointmentReasons";
                SQLStr += " , @ClinicID";
                SQLStr += " , @Color";
                SQLStr += " , @Interval";
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
                SQLStr = " Update AppointmentReasons set ";
                SQLStr += " AppointmentReasons = @AppointmentReasons";
                SQLStr += " , ClinicID = @ClinicID";
                SQLStr += " , Color = @Color";
                SQLStr += " , Interval = @Interval";
                SQLStr += " Where AppointmentReasonsID = @AppointmentReasonsID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  AppointmentReasons ";
                SQLStr += " Where AppointmentReasonsID = " + AppointmentReasonsID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  AppointmentReasons ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppointmentReasons").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData()
        {
            try
            {
                SQLStr = " Select ";
                SQLStr += " AppointmentReasonsID ";
                SQLStr += " , AppointmentReasons ";
                SQLStr += " , ClinicID ";
                SQLStr += " , Color ";
                SQLStr += " , CoalEsce(Interval,0) AS  Interval ";
                SQLStr += " From  AppointmentReasons ";
                SQLStr += "Where ClinicID = " + ClinicID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppointmentReasons").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  AppointmentReasons ";
                SQLStr += " Where AppointmentReasonsID = " + AppointmentReasonsID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppointmentReasons").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsAppointmentReasons).GetProperty(myMatches[i].Value.Replace("@", ""));
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
    }
}
