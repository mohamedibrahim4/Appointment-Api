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
  public  class ClsApiDoctorAttachment
    {
        string SQLStr = "";
        [Required]
        public int AttachmentID { get; set; }
        public int PatientID { get; set; }
        public String Description { get; set; }
        public String FileName { get; set; }
        public int? DoctorID { get; set; }
        public String AttachmentDate { get; set; }
        public Boolean Del { get; set; }
        public int? DoctorAttachmentTypeID { get; set; }
        public int? VisitID { get; set; }

        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into DoctorAttachment ( ";
                SQLStr += " AttachmentID ";
                SQLStr += "  , PatientID ";
                SQLStr += " , Description ";
                SQLStr += " , FileName ";
                //SQLStr +=" , DoctorID ";
                //SQLStr +=" , AttachmentDate ";
                //SQLStr +=" , Del ";
                SQLStr += " , DoctorAttachmentTypeID ";
                //SQLStr +=" , VisitID ";
                SQLStr += " ) values ( ";
                SQLStr += " @AttachmentID";
                SQLStr += "  , @PatientID";
                SQLStr += " , @Description";
                SQLStr += " , @FileName";
                //SQLStr += " , @DoctorID";
                //SQLStr += " , @AttachmentDate";
                //SQLStr += " , @Del";
                SQLStr += " , @DoctorAttachmentTypeID";
                //SQLStr += " , @VisitID";
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
                SQLStr = " Update DoctorAttachment set ";

                SQLStr += "  Description = @Description";
                SQLStr += " , FileName = @FileName";
                SQLStr += " , DoctorID = @DoctorID";
                SQLStr += " , AttachmentDate = @AttachmentDate";
                SQLStr += " , Del = @Del";
                SQLStr += " , DoctorAttachmentTypeID = @DoctorAttachmentTypeID";

                SQLStr += " Where AttachmentID = @AttachmentID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  DoctorAttachment ";
                SQLStr += " Where AttachmentID = " + AttachmentID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataAttachmentByType()
        {
            try
            {
                SQLStr = "SELECT  [AttachmentID],[PatientID],[Description],[FileName],[DoctorID],[AttachmentDate],[Del],case when [DoctorAttachmentTypeID] is  NULL   then 0 else  [DoctorAttachmentTypeID] end as  DoctorAttachmentTypeID,[VisitID] FROM [dbo].[DoctorAttachment] ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                SQLStr += " and DoctorAttachmentTypeID = " + DoctorAttachmentTypeID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable GetDataAttachmentForPatient()
        {
            try
            {
                SQLStr = "SELECT  [AttachmentID],[PatientID],[Description],[FileName],[DoctorID],[AttachmentDate],[Del],case when [DoctorAttachmentTypeID] is  NULL   then 0 else  [DoctorAttachmentTypeID] end as  DoctorAttachmentTypeID,[VisitID] FROM [dbo].[DoctorAttachment] ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int GetID()
        {
            try
            {
                SQLStr = " Select  Max(AttachmentID)  From  DoctorAttachment ";
                return Convert.ToInt32(GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0].Rows[0][0]) + 1;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable FilterData()
        {
            try
            {
                SQLStr = " Select * From  DoctorAttachment ";
                SQLStr += "Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterMissingConsents()
        {
            try
            {
                SQLStr = " SELECT ID, FileID, dbo.FunFormatDateTimeString(VisitDate) AS ConsentDate, DamanConsentFile, UpdatedBy FROM  MissingConsents ";

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static int GetConsentCount(int PatientID)
        {
            string SQLStr;



            try
            {
                SQLStr = " Select * From  DoctorAttachment ";
                SQLStr += "Where PatientID = " + PatientID.ToString();
                SQLStr += " AND DoctorAttachment.Description Not Like 'General%Consent%' ";
                SQLStr += " AND DoctorAttachment.Description Like '%Consent%' ";
                SQLStr += " AND DoctorAttachment.AttachmentDate between '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + " 00:00:00'  AND '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + " 23:59:59" + "' ";




                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0].Rows.Count;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { SQLStr = null; }
        }
        public static int GetGeneralConsentCount(int PatientID)
        {
            string SQLStr;
            try
            {
                SQLStr = " Select * From  DoctorAttachment ";
                SQLStr += "Where PatientID = " + PatientID.ToString();
                SQLStr += " AND DoctorAttachment.Description Like 'General%Consent%' ";

                //'Daman Consent Form

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0].Rows.Count;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { SQLStr = null; }
        }
        public static int GetDamanCount(int PatientID)
        {
            string SQLStr;
            try
            {
                SQLStr = " Select * From  DoctorAttachment ";
                SQLStr += "Where PatientID = " + PatientID.ToString();
                SQLStr += " AND DoctorAttachment.Description = 'Daman Consent Form' ";


                //'Daman Consent Form

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0].Rows.Count;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { SQLStr = null; }
        }
        //
        public DataTable FilterAttachment()
        {
            try
            {
                SQLStr = " SELECT        DoctorAttachment.PatientID, DoctorAttachment.AttachmentID,  DoctorAttachmentTypes.DoctorAttachmentType, DoctorAttachment.Description,  ";
                SQLStr += "                dbo.FunFormatDateString(DoctorAttachment.AttachmentDate) AS AttachDate, Doctors.Name AS Doctor , DoctorAttachment.FileName ";

                SQLStr += " FROM            DoctorAttachment Left Outer JOIN ";
                SQLStr += "                 Doctors ON DoctorAttachment.DoctorID = Doctors.DoctorID LEFT OUTER JOIN ";
                SQLStr += "                 DoctorAttachmentTypes ON DoctorAttachment.DoctorAttachmentTypeID = DoctorAttachmentTypes.DoctorAttachmentTypeID ";
                //SQLStr += " WHERE        (DoctorAttachment.PatientID = " & txtFileNo.Text & " ) AND (DoctorAttachment.Del = 0) ";
                SQLStr += "Where PatientID = " + PatientID.ToString() + " AND (DoctorAttachment.Del = 0) ";
                if (DoctorAttachmentTypeID != 0) SQLStr += " AND DoctorAttachment.DoctorAttachmentTypeID = " + DoctorAttachmentTypeID.ToString();
                if (AttachmentDate != "") SQLStr += " AND dbo.FunFormatDateString(DoctorAttachment.AttachmentDate) = '" + AttachmentDate.ToString() + "'";
                SQLStr += " Order By DoctorAttachment.AttachmentDate Desc ";

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  DoctorAttachment ";
                SQLStr += " Where AttachmentID = " + AttachmentID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachment").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiDoctorAttachment).GetProperty(myMatches[i].Value.Replace("@", ""));
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
