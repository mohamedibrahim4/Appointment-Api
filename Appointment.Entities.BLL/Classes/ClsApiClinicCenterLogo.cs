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
  public  class ClsApiClinicCenterLogo
    {
        string SQLStr = "";
        [Required]
        public int ID { get; set; }
        public string ClinicCenter { get; set; }
        public Byte[] Header { get; set; }
        public Byte[] Logo { get; set; }
        public Byte[] Footer { get; set; }
        public string ProviderNo { get; set; }
        public string Provider_Name { get; set; }
        public string HaadLicense { get; set; }
        public string HaadUserName { get; set; }
        public string HaadPassword { get; set; }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into ClinicCenterLogo ( ";
                //SQLStr +="ID ";
                SQLStr += " ClinicCenter ";
                SQLStr += " , Header ";
                SQLStr += " , Logo ";
                SQLStr += " , Footer ";
                SQLStr += " , ProviderNo ";
                SQLStr += " , [Provider Name] ";
                SQLStr += " , HaadLicense ";
                SQLStr += " , HaadUserName ";
                SQLStr += " , HaadPassword ";
                SQLStr += " ) values ( ";
                //SQLStr += " @ID";
                SQLStr += " @ClinicCenter";
                SQLStr += " , @Header";
                SQLStr += " , @Logo";
                SQLStr += " , @Footer";
                SQLStr += " , @ProviderNo";
                SQLStr += " , @Provider_Name";
                SQLStr += " , @HaadLicense";
                SQLStr += " , @HaadUserName";
                SQLStr += " , @HaadPassword";
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
                SQLStr = " Update ClinicCenterLogo set ";
                SQLStr += " ClinicCenter = @ClinicCenter";
                SQLStr += " , Header = @Header";
                SQLStr += " , Logo = @Logo";
                SQLStr += " , Footer = @Footer";
                SQLStr += " , ProviderNo = @ProviderNo";
                SQLStr += " , [Provider Name] = @Provider Name";
                SQLStr += " , HaadLicense = @HaadLicense";
                SQLStr += " , HaadUserName = @HaadUserName";
                SQLStr += " , HaadPassword = @HaadPassword";
                SQLStr += " Where ID = @ID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  ClinicCenterLogo ";
                SQLStr += " Where ID = " + ID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataClinicCenterLogo()
        {
            try
            {
                SQLStr = "SELECT [ID],[ClinicCenter],[Header],[Logo],[Footer],[ProviderNo],[Provider Name],[HaadLicense],[HaadUserName],[HaadPassword],[BranchID],[SenderID],[SMSUserID],[SMSPassword],[ClinicCenterArabic],[VatRegistrationNo],[Loyalty],[MalafiCode] FROM [dbo].[ClinicCenterLogo] ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "ClinicCenterLogo").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData()
        {
            try
            {
                SQLStr = " Select * From  ClinicCenterLogo ";
                SQLStr += " WHERE ClinicCenter = 'Pharmacy' ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "ClinicCenterLogo").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetHeader()
        {

            try
            {

                SQLStr = " Select top 1 Header From  ClinicCenterLogo ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "ClinicCenterLogo").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlDataReader GetSMSSetting()
        {
            SQLStr = " Select Top 1 SenderID , SMSUserID , SMSPassword From  ClinicCenterLogo ";

            return GeneralFunctionsDAC.DDLReader(SQLStr);
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  ClinicCenterLogo ";
                SQLStr += " Where ID = " + ID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "ClinicCenterLogo").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiClinicCenterLogo).GetProperty(myMatches[i].Value.Replace("@", ""));
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
        public string GetPhSenderID()
        {
            try
            {

                SQLStr = "Select HaadLicense From ClinicCenterLogo WHERE ClinicCenter = 'Pharmacy'";

                return Convert.ToString(GeneralFunctionsDAC.DDLStatment(SQLStr, "PHSender").Tables[0].Rows[0][0]);
            }
            catch (Exception ex)
            { throw ex; }

        }


    }
}
