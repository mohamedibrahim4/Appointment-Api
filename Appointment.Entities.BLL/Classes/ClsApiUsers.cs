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
   public class ClsApiUsers
    {
        string SQLStr = "";
        [Required]
        public int ApiUserID { get; set; }
        public string ApiUserName { get; set; }
        public string ApiUserPhone { get; set; }
        public string ApiUserEmail { get; set; }
        public int Doc_Type { get; set; }
        public string Doc_Id { get; set; }       
        public String password { get; set; }
        public String PicPath { get; set; }
        public int FileNo { get; set; }
        public bool IsActive { get; set; }
        public int RoleTypeId { get; set; }

        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into ApiUsers ( ";
                SQLStr += "ApiUserName ";
                SQLStr += " , ApiUserPhone ";
                SQLStr += " , ApiUserEmail ";
                SQLStr += " , Doc_Type ";
                SQLStr += " , Doc_Id ";
                SQLStr += " , password ";
                SQLStr += " , PicPath ";
                SQLStr += " , FileNo ";
                SQLStr += " , IsActive ";
                SQLStr += " , RoleTypeId ";
                SQLStr += " ) values ( ";
                SQLStr += " @ApiUserName";
                SQLStr += " , @ApiUserPhone";
                SQLStr += " , @ApiUserEmail ";
                SQLStr += " , @Doc_Type";
                SQLStr += " , @Doc_Id";
                SQLStr += " , @password ";
                SQLStr += " , @PicPath ";
                SQLStr += " , @FileNo ";
                SQLStr += " , @IsActive ";
                SQLStr += " , @RoleTypeId ";

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
                SQLStr = " Update ApiUsers set ";
                SQLStr += " ApiUserName = @ApiUserName";
                SQLStr += " , ApiUserPhone = @ApiUserPhone";
                SQLStr += " , ApiUserEmail = @ApiUserEmail";
                SQLStr += " , Doc_Type = @Doc_Type";
                SQLStr += " , Doc_Id = @Doc_Id";
                SQLStr += " , Doc_Type = @Doc_Type";
                SQLStr += " , password = @password";
                SQLStr += " , FileNo = @FileNo";
                SQLStr += " Where ApiUserID = @ApiUserID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  ApiUsers ";
                SQLStr += " Where ApiUserID = " + ApiUserID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetUser()
        {
            try
            {
                SQLStr = " Select * From  ApiUsers ";
                SQLStr += " where (ApiUserName= '" + ApiUserName.ToString()+ "' OR ApiUserPhone='" + ApiUserName.ToString()+ "' OR ApiUserEmail='" + ApiUserName.ToString()+"')";
                SQLStr += " and password = '" + password.ToString()+"'";
                SQLStr += " and IsActive = 1";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "ApibUsers").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  ApiUsers ";
                SQLStr += " Where ApiUserID = " + ApiUserID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "ApiUsers").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiUsers).GetProperty(myMatches[i].Value.Replace("@", ""));
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



    public enum RoleUserType
    {
              Admin = 1
            , Doctor = 2
            , Patient=3
    }
}
