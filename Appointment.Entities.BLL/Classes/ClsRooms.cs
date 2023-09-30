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
    public class ClsRooms
    {
        string SQLStr;
        //Int16 _RoomID;
        //string _Room;
        //int _ClinicID;
        //int _DoctorID;
        #region "class Properties "
        public Int16 RoomID
        {
            get;
            set;
        }
        public string Room
        {
            get;
            set;
        }
        public int? ClinicID
        {
            get;
            set;
        }
        //DoctorID
        public int? DoctorID
        {
            get;
            set;
        }
        #endregion
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into Rooms ( ";
                SQLStr += "RoomID ";
                SQLStr += " , Room ";
                SQLStr += " , ClinicID ";
                SQLStr += " ) values ( ";
                SQLStr += " @RoomID";
                SQLStr += " , @Room";
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
                SQLStr = " Update Rooms set ";
                SQLStr += " Room = @Room";
                SQLStr += " , ClinicID = @ClinicID";
                SQLStr += " Where RoomID = @RoomID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  Rooms ";
                SQLStr += " Where RoomID = " + RoomID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  Rooms ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Rooms").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData(string SelectedDoctor = "")
        {
            try
            {
                SQLStr = "Select RoomID , Room , Room + '-'  +  CONVERT(varchar(10),COALESCE( DoctorID,0)) DoctorRoom , DoctorID From Rooms ";
                if (SelectedDoctor != "")
                { SQLStr += " Where DoctorID in ( " + SelectedDoctor.ToString() + " ) "; }
                //else
                //{ SQLStr += " Where DoctorID = " + DoctorID.ToString(); }

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Rooms").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  Rooms ";
                SQLStr += " Where RoomID = " + RoomID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Rooms").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsRooms).GetProperty(myMatches[i].Value.Replace("@", ""));
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
