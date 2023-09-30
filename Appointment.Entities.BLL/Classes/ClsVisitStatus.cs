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
    public class ClsVisitStatus
    {
        string SQLStr;

        public Int16 VisitStatusID
        {
            get;
            set;
        }
        public string VisitStatus
        {
            get;
            set;
        }
        public string VisitStatusColor
        {
            get;
            set;
        }
      
        public Int16 StatusTypeID
        {
            get;
            set;
        }
        public string ColorHexa
        {
            get;
            set;
        }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into VisitStatus ( ";

                SQLStr += " VisitStatus ";
                SQLStr += " , VisitStatusColor ";
                SQLStr += " , ColorHexa ";
                SQLStr += " ) values ( ";

                SQLStr += " @VisitStatus";
                SQLStr += " , @VisitStatusColor";
                SQLStr += " , @ColorHexa";
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
                SQLStr = " Update VisitStatus set ";
                SQLStr += " VisitStatus = @VisitStatus";
                SQLStr += " , VisitStatusColor = @VisitStatusColor";
                SQLStr += " , ColorHexa = @ColorHexa";
                SQLStr += " Where VisitStatusID = @VisitStatusID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  VisitStatus ";
                SQLStr += " Where VisitStatusID = " + VisitStatusID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  VisitStatus ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "VisitStatus").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlDataReader FilterData()
        {
            try
            {
                SQLStr = " Select * From  VisitStatus ";
                SQLStr += "Where StatusTypeID = " + StatusTypeID.ToString();
                return GeneralFunctionsDAC.DDLReader(SQLStr);
                //return GeneralFunctionsDAC.DDLStatment(SQLStr,"VisitStatus").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  VisitStatus ";
                SQLStr += " Where VisitStatusID = " + VisitStatusID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "VisitStatus").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static string StatusColor(Int16 VisitStatusID)
        {
            string SQLStr;
            try
            {
                SQLStr = " Select VisitStatusColor From  VisitStatus ";
                SQLStr += " Where VisitStatusID = " + VisitStatusID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "VisitStatus").Tables[0].Rows[0]["VisitStatusColor"].ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static string StatusColorFromName(string VisitStatus)
        {
            string SQLStr;
            try
            {
                SQLStr = " Select VisitStatusColor From  VisitStatus ";
                SQLStr += " Where VisitStatus = '" + VisitStatus.ToString() + "'";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "VisitStatus").Tables[0].Rows[0]["VisitStatusColor"].ToString();
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
                System.Reflection.PropertyInfo prop = typeof(ClsVisitStatus).GetProperty(myMatches[i].Value.Replace("@", ""));
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
