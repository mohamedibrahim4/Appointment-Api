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
   public class ClsApiLookUp
    {
        string SQLStr = "";
        [Required]
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DoctorSpecialityID { get; set; }
        public string Mobile { get; set; }
        public int? HomeTel { get; set; }
        public string PasspoerNo { get; set; }
        public String CardID { get; set; }
        public String CardExp { get; set; }
        public String Sex { get; set; }
        public String SexEN { get; set; }
        public String SexAr { get; set; }
        public Int16? DoctorCategoryID { get; set; }
        public Int16? MaritalStatusID { get; set; }
        public string Email { get; set; }
        public string LicenseNo { get; set; }
        public int? BranchID { get; set; }
        public int? ClinicID { get; set; }
        public string Biograohy { get; set; }
        public string BiograohyEn { get; set; }
        public string BiograohyAr { get; set; }
        public string YearsExp { get; set; }
        public  string [] LangKnown { get; set; }
        public string ImgPath { get; set; }
        public Boolean TeleMedicine { get; set; }
        public Byte[] UserSign { get; set; }
        public Byte[] Stamp { get; set; }


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
        public DataTable GetDataDoctors()
        {
            try
            {
                SQLStr = " SELECT  [DoctorID],concat([Title],[Name]) as Name ,[DoctorSpecialityID],[Mobile],[HomeTel],[PasspoerNo],[NationalityID],[PasswordExp],[CardID],[CardExp],[SexID],[DoctorCategoryID],[MaritalStatusID],[Email],[LastUpdated],[UpdatedBy],[ClinicID],[Active],[LicenseNo],[DocAcc],[BranchID],[DocSign],[UserSign],[Stamp],[DoctorSign],[Title],[DocFName],[DocMName],[DocLName],[NameAr],[LangKnown],[Biograohy],[BiograohyAr],[YearsExp] ,[ImgPath],[TeleMedicine],[UserSign],[Stamp] FROM [dbo].[Doctors]";
                SQLStr += " WHERE Active = 1 ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataNonActiveDoctors()
        {
            try
            {
                SQLStr = " SELECT  [DoctorID],concat([Title],[Name]) as Name ,[DoctorSpecialityID],[Mobile],[HomeTel],[PasspoerNo],[NationalityID],[PasswordExp],[CardID],[CardExp],[SexID],[DoctorCategoryID],[MaritalStatusID],[Email],[LastUpdated],[UpdatedBy],[ClinicID],[Active],[LicenseNo],[DocAcc],[BranchID],[DocSign],[UserSign],[Stamp],[DoctorSign],[Title],[DocFName],[DocMName],[DocLName],[NameAr],[LangKnown],[Biograohy],[BiograohyAr],[YearsExp] ,[ImgPath],[TeleMedicine]  FROM  [dbo].[Doctors]";
                SQLStr += " WHERE Active = 0 ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Doctors").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataClinics()
        {
            try
            {
                SQLStr = " Select CinicID,Clinic ,ClinicAr,ImgPath From  Clinics ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Clinics").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataBranches()
        {
            try
            {
                SQLStr = " Select BranchID,Branch,BranchAr From  Branches ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Branches").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataNationality()
        {
            try
            {
                SQLStr = " Select NationalityID,Nationality,NationalityAr From  Nationality ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Nationality").Tables[0];
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
        public DataTable GetDataDrugUnit()
        {
            try
            {
                SQLStr = "SELECT  [DrugUnit],[ID],[DrugUnitAr] FROM [dbo].[DrugUnit] ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DrugUnit").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataDrugRoute()
        {
            try
            {
                SQLStr = "SELECT [DrugRouteID],[DrugRoute],[DrugRouteDesc],[DrugRouteDescAr] FROM  [dbo].[DrugRoute]";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DrugRoute").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataDrugInstruction()
        {
            try
            {
                SQLStr = "SELECT  [DrugInstructionID],[DrugInstruction],[DrugInstructionAr] FROM [dbo].[DrugInstruction]";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DrugInstruction").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiLookUp).GetProperty(myMatches[i].Value.Replace("@", ""));
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

        



    }
    

}
