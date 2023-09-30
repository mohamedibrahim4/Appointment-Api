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
  public  class ClsApiDoctorAttachmentTypes
    {
        string SQLStr = "";
        [Required]
        public int DoctorAttachmentTypeID { get; set; }
        public String DoctorAttachmentType { get; set; }
        public String DoctorAttachmentTypesAr { get; set; }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into DoctorAttachmentTypes ( ";
                SQLStr += "DoctorAttachmentTypeID ";
                SQLStr += " , DoctorAttachmentType ";
                SQLStr += " ) values ( ";
                SQLStr += " @DoctorAttachmentTypeID";
                SQLStr += " , @DoctorAttachmentType";
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
                SQLStr = " Update DoctorAttachmentTypes set ";
                SQLStr += " DoctorAttachmentType = @DoctorAttachmentType";
                SQLStr += " Where DoctorAttachmentTypeID = @DoctorAttachmentTypeID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  DoctorAttachmentTypes ";
                SQLStr += " Where DoctorAttachmentTypeID = " + DoctorAttachmentTypeID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetDataDoctorAttachmentTypes()
        {
            try
            {
                SQLStr = " Select [DoctorAttachmentTypeID],[DoctorAttachmentType],[DoctorAttachmentTypesAr] From  DoctorAttachmentTypes ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachmentTypes").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData()
        {
            try
            {
                SQLStr = " Select * From  DoctorAttachmentTypes ";
                SQLStr += "Where DoctorAttachmentType like '" + DoctorAttachmentType.ToString() + "'";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachmentTypes").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FindData()
        {
            try
            {
                SQLStr = " Select * From  DoctorAttachmentTypes ";
                SQLStr += " Where DoctorAttachmentTypeID = " + DoctorAttachmentTypeID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "DoctorAttachmentTypes").Tables[0];
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiDoctorAttachmentTypes).GetProperty(myMatches[i].Value.Replace("@", ""));
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

        public ClsApiDoctorAttachmentTypes()
        {

        }
        public ClsApiDoctorAttachmentTypes(int _DoctorAttachmentTypeID, string _DoctorAttachmentType, string _DoctorAttachmentTypesAr)
        {
            DoctorAttachmentTypeID = _DoctorAttachmentTypeID;
            DoctorAttachmentType = _DoctorAttachmentType;
            DoctorAttachmentTypesAr = _DoctorAttachmentTypesAr;
        }
        public List<ClsApiDoctorAttachmentTypes> Read()
        {
            ClsApiDoctorAttachmentTypes OtherTypes = new ClsApiDoctorAttachmentTypes(1, "Other", "أخري");
            ClsApiDoctorAttachmentTypes LabTypes = new ClsApiDoctorAttachmentTypes(1, "Lab", "لاب");
            ClsApiDoctorAttachmentTypes RadiologyTypes = new ClsApiDoctorAttachmentTypes(1, "Radiology", "الاشعة");
            ClsApiDoctorAttachmentTypes MedicalRecordsTypes = new ClsApiDoctorAttachmentTypes(1, "Medical Records", "سجلات طبية");
            ClsApiDoctorAttachmentTypes UltrasoundTypes = new ClsApiDoctorAttachmentTypes(1, "Ultrasound Report", "تقارير الموجات فوق الصوتية");
            ClsApiDoctorAttachmentTypes InsuranceCardTypes = new ClsApiDoctorAttachmentTypes(1, "Insurance Card", "بطاقة التأمين");
            ClsApiDoctorAttachmentTypes DentalXrayTypes = new ClsApiDoctorAttachmentTypes(1, "Dental Xray", "الأشعة السينية للأسنان");
       
            List<ClsApiDoctorAttachmentTypes> DoctorAttachmentTypesLst = new List<ClsApiDoctorAttachmentTypes>();
            DoctorAttachmentTypesLst.Add(OtherTypes);
            DoctorAttachmentTypesLst.Add(LabTypes);
            DoctorAttachmentTypesLst.Add(RadiologyTypes);
            DoctorAttachmentTypesLst.Add(MedicalRecordsTypes);
            DoctorAttachmentTypesLst.Add(UltrasoundTypes);
            DoctorAttachmentTypesLst.Add(InsuranceCardTypes);
            DoctorAttachmentTypesLst.Add(DentalXrayTypes);
            return DoctorAttachmentTypesLst;
        }

    }
}
