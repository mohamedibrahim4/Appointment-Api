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
    public class ClsApiPatientDrugs
    {
        string SQLStr = "";
        [Required]
        public int PatientDrugID { get; set; }

        //public int DoctorID { get; set; }
        //public string ArrDate { get; set; }
        public int PatientID { get; set; }
        public int WaitingID { get; set; }

        public String DrugCode { get; set; }
        public String PackageName { get; set; }
        public String GenericName { get; set; }
        public string ProductName { get; set; }
        public string Dose { get; set; }
        public String Instructions { get; set; }

        public String Duration { get; set; }
        public  Double Qty { get; set; }
        public String Form { get; set; }
        public bool del { get; set; }
        public int DrugID { get; set; }
        public int DrugType { get; set; }
        //public String OrderDate { get; set; }
        //public String MedStartDate { get; set; }
        public String Unit { get; set; }
        public String DurationPeriod { get; set; }
        public int DurationQty { get; set; }
        public int DoseQty { get; set; }
        public String DoseUnit { get; set; }
        public String DrugRoute { get; set; }
        public String QuantityTimingPriority { get; set; }
        public int DrugInstruction { get; set; }
        public String DrugInstructionstxt { get; set; }






        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into PatientDrugs ( ";
                SQLStr += " WaitingID ";
                SQLStr += " , PatientID ";
                SQLStr += " , DrugCode ";
                SQLStr += " , PackageName ";
                SQLStr += " , GenericName ";
                SQLStr += " , ProductName ";
                SQLStr += " , Dose ";
                SQLStr += " , Instructions ";
                SQLStr += " , Duration ";
                SQLStr += " , Refill ";
                SQLStr += " , Qty ";
                SQLStr += " , Form ";
                SQLStr += " , DrugID ";
                SQLStr += " , DrugType ";
                SQLStr += " , PrintDrug ";
                SQLStr += " , Unit";
                SQLStr += " , DrugRoute ";

                SQLStr += " , DoseQty";
                SQLStr += " , DoseUnit";
                SQLStr += " , DurationQty";
                SQLStr += " , DurationPeriod";
                SQLStr += " , StartPeriod";
                //mb
                SQLStr += " , UpdatedBy ";
                SQLStr += " , LastUpdated ";


                SQLStr += " ) values ( ";
                SQLStr += " @WaitingID";
                SQLStr += " , @PatientID";
                SQLStr += " , @DrugCode";
                SQLStr += " , @PackageName";
                SQLStr += " , @GenericName";
                SQLStr += " , @ProductName";
                SQLStr += " , @Dose";
                SQLStr += " , @Instructions";
                SQLStr += " , @Duration";
                SQLStr += " , @Refill";
                SQLStr += " , @Qty";
                SQLStr += " , @Form";
                SQLStr += " , @DrugID ";
                SQLStr += " , @DrugType ";
                SQLStr += " , @PrintDrug ";
                SQLStr += " , @Unit";
                SQLStr += " , @DrugRoute ";
                SQLStr += " , @DoseQty";
                SQLStr += " , @DoseUnit";
                SQLStr += " , @DurationQty";
                SQLStr += " , @DurationPeriod";
                SQLStr += " , Getdate() ";
                //mb
                //SQLStr += " , " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " , getdate()";

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
                SQLStr = " Update PatientDrugs set ";


                //SQLStr +=" PackageName = @PackageName";
                //SQLStr +=" , GenericName = @GenericName";
                //SQLStr +=" , ProductName = @ProductName";
                SQLStr += "  Dose = @Dose";
                SQLStr += " , Instructions = @Instructions";
                SQLStr += " , Duration = @Duration";
                SQLStr += " , Refill = @Refill";
                SQLStr += " , Qty = @Qty";
                SQLStr += " , Form = @Form";
                SQLStr += " , PrintDrug = @PrintDrug ";
                //SQLStr +=" , del = @del";
                SQLStr += " , Unit =@Unit";
                SQLStr += " , DrugRoute = @DrugRoute ";
                //mb
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " , LastUpdated = getdate()";

                SQLStr += " Where PatientDrugID = @PatientDrugID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        //public bool DeleteData()
        //{
        //    try
        //    {
        //        SQLStr = " Delete From  PatientDrugs ";
        //        SQLStr += " Where PatientDrugID = " + PatientDrugID.ToString();
        //        return GeneralFunctionsDAC.DMLStatment(SQLStr);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  PatientDrugs ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientDrugs").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        //public DataTable FilterData()
        //{
        //    try
        //    {
        //        SQLStr = " Select * From  PatientDrugs ";
        //        SQLStr += "Where WaitingID = " + WaitingID.ToString();
        //        return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientDrugs").Tables[0];
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        //public DataTable FindData()
        //{
        //    try
        //    {
        //        SQLStr = " Select * From  VPatientDrugs ";
        //        SQLStr += " Where WaitingID = " + WaitingID.ToString();
        //        return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientDrugs").Tables[0];
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        public DataTable Logo()
        {
            try
            {
                SQLStr = " Select top 1 * From  ClinicCenterLogo ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientDrugs").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataTable FilterDataByVisitID()
        //{
        //    SqlParameter[] SQLPrameters = new SqlParameter[1];
        //    SqlParameter SQLPrameter = null;

        //    try
        //    {


        //        SQLPrameter = new SqlParameter("@VisitID", WaitingID);
        //        SQLPrameters[0] = SQLPrameter;
        //        return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_Drug_Requests_ByVisitID", "FoundPatientDrug", SQLPrameters).Tables["FoundPatientDrug"];

        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //    finally
        //    {
        //        SQLPrameters = null;
        //        SQLPrameter = null;
        //    }
        //}
        //public DataTable FilterDataByPatientID(int DoctorID)
        //{
        //    SqlParameter[] SQLPrameters = new SqlParameter[4];
        //    SqlParameter SQLPrameter = null;
        //    SqlParameter SQLPrameter1 = null;
        //    SqlParameter SQLPrameter2 = null;
        //    SqlParameter SQLPrameter3 = null;
        //    try
        //    {


        //        SQLPrameter = new SqlParameter("@PatientID", PatientID);
        //        SQLPrameters[0] = SQLPrameter;
        //        SQLPrameter1 = new SqlParameter("@DoctorID", DoctorID);
        //        SQLPrameters[1] = SQLPrameter1;

        //        SQLPrameter2 = new SqlParameter("@WaitingID", WaitingID);
        //        SQLPrameters[2] = SQLPrameter2;





        //        return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_Drug_Requests_ByPatientID_FromLastVisit", "FoundPatientDrug", SQLPrameters).Tables["FoundPatientDrug"];



        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //    finally
        //    {
        //        SQLPrameters = null;
        //        SQLPrameter = null;
        //        SQLPrameter1 = null;
        //        SQLPrameter2 = null;
        //        SQLPrameter3 = null;
        //    }
        //}
        //public DataTable FilterDataPricesByVisitID()
        //{
        //    SqlParameter[] SQLPrameters = new SqlParameter[1];
        //    SqlParameter SQLPrameter = null;

        //    try
        //    {


        //        SQLPrameter = new SqlParameter("@VisitID", WaitingID);
        //        SQLPrameters[0] = SQLPrameter;
        //        return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_Drug_Req_Fees_ByVisitID", "FoundPatientDrug", SQLPrameters).Tables["FoundPatientDrug"];

        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //    finally
        //    {
        //        SQLPrameters = null;
        //        SQLPrameter = null;
        //    }
        //}
        //public int GetLastPrescriptionVisitID()
        //{
        //    try
        //    {
        //        SQLStr = " Select Max([WaitingID]) from [PatientDrugs]";
        //        SQLStr += "  where PatientID = " + PatientID.ToString();

        //        return Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReader(SQLStr));
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}
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
                System.Reflection.PropertyInfo prop = typeof(ClsApiPatientDrugs).GetProperty(myMatches[i].Value.Replace("@", ""));
                if (prop != null)
                {

                    if (typeof(ClsApiPatientDrugs).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
                    {

                        if (!prop.GetValue(this, null).Equals(""))
                        {
                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        }
                        else
                        {
                            SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                        }
                        SQLPrameter.DbType = DbType.String;

                    }

                    else if (typeof(ClsApiPatientDrugs).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Double")
                    {

                        SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        SQLPrameter.DbType = DbType.Double;
                    }
                    else if (typeof(ClsApiPatientDrugs).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
                    {
                        if (!prop.GetValue(this, null).Equals(0))
                        {
                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        }
                        else
                        {
                            SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                        }
                        SQLPrameter.DbType = DbType.Int16;
                    }

                    else if (typeof(ClsApiPatientDrugs).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
                    {
                        if (!prop.GetValue(this, null).Equals(0))
                        {
                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                        }
                        else
                        {
                            SQLPrameter = new SqlParameter(prop.Name, DBNull.Value);
                        }
                        SQLPrameter.DbType = DbType.Int32;
                    }

                    else if (typeof(ClsApiPatientDrugs).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Boolean")
                    {
                        SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
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
                    cmd.CommandText += " SELECT @PatientDrugID = @@IDENTITY; ";
                    SqlParameter ParPatientDrugID = new SqlParameter();
                    ParPatientDrugID.ParameterName = "@PatientDrugID";
                    ParPatientDrugID.DbType = DbType.Int32;
                    ParPatientDrugID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ParPatientDrugID);


                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        PatientDrugID = Convert.ToInt32(cmd.Parameters["@PatientDrugID"].Value.ToString());
                        return true;
                    }
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
        public DataTable GetAppPatientDrugs()
        {
            try
            {
                SQLStr = " select DoctorID,ArrDate,WaitingPatient.PatientID ,WaitingPatient.WaitingID  from WaitingPatient inner join PatientDrugs on WaitingPatient.WaitingID=PatientDrugs.WaitingID where WaitingPatient.PatientID= " + PatientID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppPatientDrugs").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable GetDrugsByWaiting()
        {
            try
            {
                SQLStr = " SELECT PatientDrugID, DrugCode, WaitingID,PatientID, PackageName,ProductName,Form,DrugID,DrugType, GenericName, Dose, Form, Instructions, Duration, Qty, Refill, AuthorizationNo,DenialCode, Unit, PatientDrugs.DrugRoute, DrugStatus,DurationPeriod , DurationQty ,DoseQty ,DoseUnit ,QuantityTimingPriority  ,DrugRoute.DrugRouteDesc , case QuantityTimingPriority when 'ST' then 'STAT' when 'AS' then 'ASAP' when 'RT' then 'Routine' when 'TM' then 'TIMED'  else 'TIMED' end  as QuantityTimingPriorityDesc ,DrugInstruction,DrugInstructionstxt  FROM PatientDrugs inner join DrugRoute on DrugRoute.DrugRoute=PatientDrugs.DrugRoute  where WaitingID= " + WaitingID;
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "AppPatientDrugs").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

