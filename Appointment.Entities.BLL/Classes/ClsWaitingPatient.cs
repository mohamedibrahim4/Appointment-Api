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
    public class ClsWaitingPatient
    {
        string SQLStr;

        #region "class Properties "
        public int WaitingID
        {
            get;
            set;
        }
        public int DoctorID
        {
            get;
            set;
        }


        public int MainOrderDoctorID
        {
            get;
            set;
        }


        public int PatientID
        {
            get;
            set;
        }
        public string Patient
        {
            get;
            set;
        }
        public DateTime ArrDate
        {
            get;
            set;
        }
        public string AppDate
        {
            get;
            set;
        }
        public Int16 TimeID
        {
            get;
            set;
        }
        public bool Finish
        {
            get;
            set;
        }
        public string LastUpdated
        {
            get;
            set;
        }
        public int UpdatedBy
        {
            get;
            set;
        }
        public int DocCalendarID
        {
            get;
            set;
        }
        public int PatientSerial
        {
            get;
            set;
        }
        public string EndDate
        {
            get;
            set;
        }
        public Int16 EncounterType
        {
            get;
            set;
        }
        public Int16 EncounterStartType
        {
            get;
            set;
        }
        public bool AtDoctor
        {
            get;
            set;
        }
        public Int16 RoomID
        {
            get;
            set;
        }
        public Int16 RoomTypeID
        {
            get;
            set;
        }
        public Int16 ServiceTypeID
        {
            get;
            set;
        }
        public int ReferralVisitID
        {
            get;
            set;
        }
        public int CategoryID
        {
            get;
            set;
        }
        public Int16 NetworkID
        {
            get;
            set;
        }
        public Int16 SubCategoryID
        {
            get;
            set;
        }
        public int DischargeBy
        {
            get;
            set;
        }
        public Int16 VisitStatusID
        {
            get;
            set;
        }
        public string VisitComment
        {
            get;
            set;
        }
        public double CashDisc
        {
            get;
            set;
        }
        public double InsDisc
        {
            get;
            set;
        }
        public Int16 CashDiscRatio
        {
            get;
            set;
        }
        public string TempArr
        {
            get;
            set;
        }
        public string EligibilityIDPayer
        {
            get;
            set;

        }


        #endregion
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into WaitingPatient ( ";
                //SQLStr +="WaitingID ";
                SQLStr += " DoctorID ";
                SQLStr += " MainOrderDoctorID ";
                SQLStr += " , PatientID ";
                SQLStr += " , Patient ";
                if (TempArr != "" && TempArr != null)
                {
                    SQLStr += " , ArrDate ";
                }
                //SQLStr +=" , AppDate ";
                //SQLStr +=" , TimeID ";
                SQLStr += " , UpdatedBy ";
                //SQLStr +=" , DocCalendarID ";
                SQLStr += " , PatientSerial ";
                //SQLStr +=" , EndDate ";
                SQLStr += " , EncounterType ";
                SQLStr += " , EncounterStartType ";
                SQLStr += " , ServiceTypeID ";
                //SQLStr +=" , ReferralVisitID ";

                SQLStr += " , CategoryID ";
                //if (_NetworkID != 0) SQLStr += " , NetworkID ";
                //if (_SubCategoryID != 0) SQLStr += " , SubCategoryID ";
                SQLStr += " , EligibilityIDPayer ";


                SQLStr += " ) values ( ";
                //SQLStr += " @WaitingID";
                SQLStr += "  @DoctorID";
                SQLStr += "  @MainOrderDoctorID";
                SQLStr += " , @PatientID";
                SQLStr += " , @Patient";
                if (TempArr != "" && TempArr != null)
                {
                    SQLStr += " , @TempArr";
                }
                //SQLStr += " , @AppDate";
                //SQLStr += " , @TimeID";
                SQLStr += " , @UpdatedBy ";
                //SQLStr += " , @DocCalendarID";
                SQLStr += " , @PatientSerial";
                //SQLStr += " , @EndDate";
                SQLStr += " , @EncounterType";
                SQLStr += " , @EncounterStartType";
                SQLStr += " , @ServiceTypeID";
                //SQLStr += " , @ReferralVisitID";
                SQLStr += " , @CategoryID";
                //if (_NetworkID != 0) SQLStr += " , @NetworkID ";
                //if (_SubCategoryID != 0) SQLStr += " , @SubCategoryID ";
                SQLStr += " , @EligibilityIDPayer ";
                SQLStr += " ) ";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLInsertIPSp()
        {
            try
            {
                SQLStr = " insert into WaitingPatient ( ";
                //SQLStr +="WaitingID ";
                SQLStr += " PatientID ";
                SQLStr += " , Patient ";
                //SQLStr +=" , ArrDate ";
                //SQLStr +=" , AppDate ";
                //SQLStr +=" , TimeID ";
                SQLStr += " , UpdatedBy ";
                //SQLStr +=" , DocCalendarID ";
                SQLStr += " , PatientSerial ";
                //SQLStr +=" , EndDate ";
                SQLStr += " , EncounterType ";
                SQLStr += " , EncounterStartType ";
                SQLStr += " , ServiceTypeID ";
                //SQLStr +=" , ReferralVisitID ";
                SQLStr += " , CategoryID ";
                SQLStr += " , EligibilityIDPayer ";
                SQLStr += " ) values ( ";
                //SQLStr += " @WaitingID";
                SQLStr += PatientID;
                SQLStr += " , @Patient";
                //SQLStr += " , @ArrDate";
                //SQLStr += " , @AppDate";
                //SQLStr += " , @TimeID";
                //SQLStr += " , " + Appointment.Properties.Settings.Default.UserID;
                //SQLStr += " , @DocCalendarID";
                SQLStr += " , 0 ";
                //SQLStr += " , @EndDate";
                SQLStr += " , " + EncounterType;
                SQLStr += " , " + EncounterStartType;
                SQLStr += " , " + ServiceTypeID;
                //SQLStr += " , @ReferralVisitID";
                SQLStr += " , " + CategoryID;
                SQLStr += " , @EligibilityIDPayer ";
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
                SQLStr = " Update WaitingPatient set ";
                //SQLStr += " DoctorID = @DoctorID";
                //SQLStr +=" , PatientID = @PatientID";
                //SQLStr +=" , Patient = @Patient";
                //SQLStr +=" , ArrDate = @ArrDate";
                //SQLStr +=" , AppDate = @AppDate";
                //SQLStr +=" , TimeID = @TimeID";
                //SQLStr +=" , Finish = @Finish";
                SQLStr += " LastUpdated  = '" + System.DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "'";
                ////SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                //SQLStr +=" , DocCalendarID = @DocCalendarID";

                //SQLStr +=" , EndDate = @EndDate";
                SQLStr += " , EncounterType = @EncounterType";
                SQLStr += " , EncounterStartType = @EncounterStartType";
                //SQLStr +=" , AtDoctor = @AtDoctor";
                //SQLStr +=" , RoomID = @RoomID";
                //SQLStr +=" , RoomTypeID = @RoomTypeID";
                SQLStr += " , ServiceTypeID = @ServiceTypeID";
                //SQLStr +=" , ReferralVisitID = @ReferralVisitID";
                SQLStr += " , CategoryID = @CategoryID";
                SQLStr += " , EligibilityIDPayer = @EligibilityIDPayer ";
                SQLStr += " , NetworkID = @NetworkID ";
                SQLStr += " , SubCategoryID = @SubCategoryID ";
                SQLStr += " Where WaitingID = @WaitingID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLUpdateDescriptionSp()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                SQLStr += " LastUpdated = GetDate() ";
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " , VisitComment = @VisitComment";
                SQLStr += " Where WaitingID = @WaitingID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLUpdateDiscSp()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                //SQLStr += " CashDisc = " + _CashDisc.ToString();
                //SQLStr += " , CashDiscRatio = " + _CashDiscRatio.ToString();
                //SQLStr += " , InsDisc = " + _InsDisc.ToString();
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string SQLUpdateAppNoSp()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                //SQLStr += " DocCalendarID = " + _DocCalendarID.ToString();
                SQLStr += " , LastUpdated = GetDate() ";
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean PatientDischarge()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                SQLStr += " Finish = 1 ";
                SQLStr += " , EndDate = '" + System.DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "'";
                SQLStr += " , DischargeBy = " + DischargeBy.ToString();
                SQLStr += " , LastUpdated = GetDate() ";
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean UpdateVisitStatus()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                SQLStr += " VisitStatusID = " + VisitStatusID.ToString();
                //SQLStr += " , EndDate = '" + System.string.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "'";
                //SQLStr += " , DischargeBy = " + DischargeBy.ToString();
                SQLStr += " , LastUpdated = GetDate() ";
                //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean UpdateNurseSeen()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                SQLStr += " NurseSeenTime = GetDate() ";
                //SQLStr += " , NurseSeenUser = " + Appointment.Properties.Settings.Default.UserID;

                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                SQLStr += " AND NurseSeenUser is null ";
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean UpdateDoctorSeen(string Seentime = "")
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                //SQLStr += " DoctorSeenUser = " + Appointment.Properties.Settings.Default.UserID;
                if (Seentime == "")
                {
                    SQLStr += " , DoctorSeenTime = GetDate() ";
                }
                else
                {
                    SQLStr += " , DoctorSeenTime = '" + Seentime.ToString() + "' ";
                }
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                // SQLStr += " AND NurseSeenUser is null ";
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean InsertReferralVisit()
        {
            SQLStr = " INSERT INTO [WaitingPatient] ( ";
            SQLStr += " [DoctorID], ";
            SQLStr += " [PatientID], ";
            SQLStr += " [Patient], ";
            SQLStr += " [UpdatedBy], ";
            SQLStr += " [PatientSerial],";
            SQLStr += " [EncounterType],";
            SQLStr += " [EncounterStartType],";
            SQLStr += " [ServiceTypeID] ";
            SQLStr += " , [ReferralVisitID] ";
            SQLStr += " , [VisitComment]) ";
            SQLStr += " Select " + DoctorID.ToString();
            SQLStr += " , PatientID  ";
            SQLStr += " , Patient ";
            //SQLStr += " , " + Appointment.Properties.Settings.Default.UserID;
            SQLStr += " , " + GetPatientSerial().ToString();
            SQLStr += " , [EncounterType] ";
            SQLStr += " , [EncounterStartType] ";
            SQLStr += " , [ServiceTypeID] ";
            SQLStr += " ," + WaitingID.ToString();
            SQLStr += " , '" + VisitComment.ToString() + "'";
            SQLStr += " From WaitingPatient ";
            SQLStr += " Where WaitingID = " + WaitingID.ToString();
            return GeneralFunctionsDAC.DMLStatment(SQLStr);
            //SQLStr += "   VALUES ( " & cmbDoctor.SelectedValue & ", " & txtFileNo.Text & " , '" & txtPatient.Text & "' , " & Session("UserID") & " , " & Waitpat.GetPatientSerial.ToString & ", 1 , 1 ,6, " & HFVisitID.Value & ") "    
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  WaitingPatient ";
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  WaitingPatient ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "WaitingPatient").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterData(string SearchDate, string Status = "", Int16 RoomID = 0)
        {
            try
            {
                SQLStr = " SELECT     WaitingPatient.WaitingID, dbo.FunFormatDateString(WaitingPatient.ArrDate) AS ArrDate, CONVERT(nvarchar(20), WaitingPatient.ArrDate, 108) AS ChkIn ";
                SQLStr += " , CONVERT(nvarchar(20), WaitingPatient.AppDate, 108) AS AppTime ";
                SQLStr += "          , CONVERT(nvarchar(20), WaitingPatient.EndDate, 108) AS ChkOut, EligibilityIDPayer, WaitingPatient.PatientID, WaitingPatient.Patient, COALESCE (FeeCategory.Category, ";
                SQLStr += "          FeeCategory.Category) AS Category, WaitingPatient.DocCalendarID, WaitingPatient.VisitStatusID StatusID ";
                SQLStr += " , (Select COALESCE(MobileCountryCode,'') +  COALESCE(MobileAreaCode,'') +  Mobile AS Mobile From Patients WHERE Patients.PatientID = WaitingPatient.PatientID) AS MobileNo, COALESCE(Unlock,-1) AS Unlock ";
                SQLStr += " ,  substring( ";
                SQLStr += " ( ";
                SQLStr += " Select ','+ convert(nvarchar(20),ST1.InvoiceID)  AS [text()] ";
                SQLStr += " From dbo.Invoice ST1 ";
                SQLStr += " Where ST1.VisitID = WaitingPatient.WaitingID AND Del =0  ";
                SQLStr += " For XML PATH ('') ";
                SQLStr += " ), 2, 1000) [InvoiceID] ";
                SQLStr += " , VisitComment, WaitingPatient.DocCalendarID ";
                SQLStr += " FROM         dbo.FeeCategory AS FeeCategory RIGHT OUTER JOIN ";
                SQLStr += "          dbo.WaitingPatient AS WaitingPatient ON FeeCategory.CategoryID = WaitingPatient.CategoryID ";
                if (RoomID > 0)
                {
                    SQLStr += " RIGHT OUTER JOIN DoctorCalender ON dbo.DoctorCalender.RoomID =  WaitingPatient.DocCalendarID ";

                }
                SQLStr += " WHERE Convert(nvarchar(25),WaitingPatient.ArrDate,105)= '" + SearchDate.ToString() + "' ";
                if (RoomID > 0)
                {
                    SQLStr += " AND dbo.DoctorCalender.RoomID = " + RoomID.ToString();
                }
                if (DoctorID != 0)
                {
                    SQLStr += " AND WaitingPatient.DoctorID = " + DoctorID.ToString();
                }
                if (Status != "")
                {
                    SQLStr += " AND  WaitingPatient.VisitStatusID  in ( " + Status + " ) ";
                }
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "WaitingPatient").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlDataReader FindData()
        {
            try
            {
                SQLStr = " Select * From  WaitingPatient ";
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                return GeneralFunctionsDAC.DDLReader(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterDoctorWaitingPatientByDate()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@Date", ArrDate.ToString("dd-MM-yyyy"));
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Doctor_WaitingPatient", "DoctorWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterDoctorWaitingRadiologyPatientByDate()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@Date", ArrDate.ToString("dd-MM-yyyy"));
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Doctor_WaitingPatient_Radiology", "DoctorWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }

        public SqlDataReader GetVisitCount()
        {

            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@Date", ArrDate.ToString("dd-MM-yyyy"));
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DMLSPReaderWithPar("SP_Doctor_WaitingPatient_Count", SQLPrameters);

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public SqlDataReader GetLastVisit(int PatientID, int ClinicID)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@ClinicID", ClinicID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DMLSPReaderWithPar("SP_CheckFollowUp", SQLPrameters);

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        //SP_Doctor_WaitingPatient_ForNurses
        public DataTable FilterNurseWaitingPatientByDate()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];

            SqlParameter SQLPrameter1 = null;
            try
            {



                SQLPrameter1 = new SqlParameter("@Date", ArrDate.ToString("dd-MM-yyyy"));
                SQLPrameters[0] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Doctor_WaitingPatient_ForNurses", "DoctorWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter1 = null;
            }
        }

        //SP_Doctor_Patients_Visits

        public DataTable FilterDoctorWaitingPatientByPatientID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Doctor_Patients_Visits", "DoctorWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }

        public DataTable FilterDoctorWaitingRadiologyPatientByPatientID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {


                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Doctor_Patients_Visits_Radiology", "DoctorWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }

        public DataTable FilterIPWaitingPatientAll(string FilterDate)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {

                SQLPrameter = new SqlParameter("@Date", FilterDate);
                SQLPrameters[0] = SQLPrameter;

                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_IP_All", "IPWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterIPWaitingPatient(string FilterDate)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;
            //SqlParameter SQLPrameter1 = null;
            try
            {


                //SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                //SQLPrameters[0] = SQLPrameter;
                SQLPrameter = new SqlParameter("@Date", FilterDate);
                SQLPrameters[0] = SQLPrameter;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_IP", "IPWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterIPWaitingPatientPreOP(string FilterDate)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;
            try
            {
                SQLPrameter = new SqlParameter("@Date", FilterDate);
                SQLPrameters[0] = SQLPrameter;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_IP_PreOP", "IPWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterIPWaitingPatientDoctor(string FilterDate)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;
            try
            {
                SQLPrameter = new SqlParameter("@Date", FilterDate);
                SQLPrameters[0] = SQLPrameter;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_IP_Doctor", "IPWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterIPWaitingPatientByPatientID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {


                SQLPrameter = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[0] = SQLPrameter;

                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_IP_ByPatientID", "IPWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                //SQLPrameters = null;
                //SQLPrameter = null;
            }
        }
        public DataTable FilterPHWaitingPatientByDoctor()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try
            {

                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@Date", ArrDate.ToString("dd-MM-yyyy"));
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_PH", "PHWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterPHWaitingPatientByDate()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {


                SQLPrameter = new SqlParameter("@Date", ArrDate.ToString("dd-MM-yyyy"));
                SQLPrameters[0] = SQLPrameter;
                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_PH_ByDate", "PHWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public DataTable FilterPHWaitingPatientByPatientID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {

                SQLPrameter = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[0] = SQLPrameter;

                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_WaitingPatient_PH_ByPatientID", "PHWaitingPatient", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        public string GetPatientType()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[3];
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            SqlParameter SQLPrameter2 = null;
            SqlDataReader dr;
            try
            {

                SQLPrameter = new SqlParameter("@DoctorID", DoctorID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameter1 = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[1] = SQLPrameter1;
                SQLPrameter2 = new SqlParameter("@WaitingID", WaitingID);
                SQLPrameters[2] = SQLPrameter2;
                dr = GeneralFunctionsDAC.DMLSPReaderWithPar("SP_Doctor_GetPatientType", SQLPrameters);

                if (dr.HasRows == true)
                    return "Established Patient";
                else
                    return "New Patient";

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
                SQLPrameter1 = null;
                SQLPrameter2 = null;

            }
        }
        public DataTable FilterPatientVisitsByPatientID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {


                SQLPrameter = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[0] = SQLPrameter;

                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_Visits", "DoctorPatientVisits", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }


        public Boolean CheckMalaffiSent()
        {
            try
            {
                SQLStr = " Select COALESCE(MalaffiSent,0) AS MalaffiSent From WaitingPatient ";
                SQLStr += " Where WaitingID = " + WaitingID.ToString();
                //return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];

                // Return Convert.ToBoolean(Appointment.DataAccess.GeneralFunctionDAC.DDLStatement(SQLStr).Tables(0).Rows(0).Item(0))

                return Convert.ToBoolean(GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows[0][0]);




            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean UpdateMalaffiSent()
        {
            try
            {
                SQLStr = " Update WaitingPatient set ";
                SQLStr += " MalaffiSent =  1 ";
                SQLStr += " Where WaitingID = " + WaitingID.ToString();

                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        //SP_Patient_Visits_Medical
        public DataTable FilterPatientVisits_MedicalSummery_ByPatientID()
        {
            SqlParameter[] SQLPrameters = new SqlParameter[1];
            SqlParameter SQLPrameter = null;

            try
            {


                SQLPrameter = new SqlParameter("@PatientID", PatientID);
                SQLPrameters[0] = SQLPrameter;

                return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patient_Visits_Medical", "DoctorPatientVisits", SQLPrameters).Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
            }
        }
        //ClsWaitingPatient

        public SqlParameter[] CreateParameters(string sSQLStr)
        {
            System.Text.RegularExpressions.MatchCollection myMatches;
            Int16 i = 0;
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("@\\w+");
            myMatches = myRegex.Matches(sSQLStr);
            try
            {
                SqlParameter[] SQLPrameters = new SqlParameter[0];



                SqlParameter SQLPrameter = null;

                while (i < myMatches.Count)
                {
                    Array.Resize(ref SQLPrameters, SQLPrameters.Length + 1);
                    System.Reflection.PropertyInfo prop = typeof(ClsWaitingPatient).GetProperty(myMatches[i].Value.Replace("@", ""));
                    if (prop != null)
                    {

                        if (typeof(ClsWaitingPatient).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
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

                        else if (typeof(ClsWaitingPatient).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Double")
                        {

                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            SQLPrameter.DbType = DbType.Double;
                        }
                        else if (typeof(ClsWaitingPatient).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
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

                        else if (typeof(ClsWaitingPatient).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
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

                        else if (typeof(ClsWaitingPatient).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "System.Boolean")
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
            catch (Exception ex)
            {
                { throw new Exception("ClsWaitingPatient - CreateParameters " + myMatches[i].Value.ToString() + ex.Message.ToString()); }
            }
        }
        public int InsertSP()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    //if (TempArr != "" && TempArr != null)
                    //{
                    //    cmd.CommandText = "SP_WaitingPatient_Insert_Temp";
                    //}
                    //else
                    //{
                    cmd.CommandText = "SP_WaitingPatient_FromCalendar_InsertApi";
                    //}
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] a;
                    a = CreateParameters(SQLInsertSp());
                    //for (Int16 i = 0; i <= a.Length - 1; i++)
                    //{
                    //    if (GeneralFunctionsDAC.IsNumeric(a[i].Value.ToString()) == true)
                    //    {
                    //        if (a[i].Value == null)
                    //        { a[i].Value = DBNull.Value; }
                    //    }
                    //    else
                    //    {
                    //        if (a[i].Value.ToString() == "")
                    //        {
                    //            a[i].Value = DBNull.Value;
                    //        }
                    //    }
                    //    cmd.Parameters.Add(a[i]);
                    //}
                    SqlParameter ParWaitingID = new SqlParameter();
                    ParWaitingID.ParameterName = "@WaitingID";
                    ParWaitingID.DbType = DbType.Int32;
                    ParWaitingID.Direction = ParameterDirection.Output;              
                    cmd.Parameters.Add(ParWaitingID);

                    SqlParameter ParUpdatedBy = new SqlParameter();
                    ParUpdatedBy.ParameterName = "@UpdatedBy";
                    ParUpdatedBy.Value = UpdatedBy;
                    ParUpdatedBy.DbType = DbType.Int32;
                    cmd.Parameters.Add(ParUpdatedBy);

                    SqlParameter ParEncounterType = new SqlParameter();
                    ParEncounterType.ParameterName = "@EncounterType";
                    ParEncounterType.Value = EncounterType;

                    ParEncounterType.DbType = DbType.Int32;
                    cmd.Parameters.Add(ParEncounterType);

                    SqlParameter ParEncounterStartType = new SqlParameter();
                    ParEncounterStartType.ParameterName = "@EncounterStartType";
                    ParEncounterStartType.Value = EncounterStartType;

                    ParEncounterStartType.DbType = DbType.Int32;
                    cmd.Parameters.Add(ParEncounterStartType);


                    SqlParameter ParServiceTypeID = new SqlParameter();
                    ParServiceTypeID.ParameterName = "@ServiceTypeID";
                    ParServiceTypeID.Value = ServiceTypeID;

                    ParServiceTypeID.DbType = DbType.Int32;
                    cmd.Parameters.Add(ParServiceTypeID);

                    SqlParameter ParEligibilityIDPayer = new SqlParameter();
                    ParEligibilityIDPayer.ParameterName = "@EligibilityIDPayer";
                    ParEligibilityIDPayer.Value = EligibilityIDPayer;

                    ParEligibilityIDPayer.DbType = DbType.String;
                    cmd.Parameters.Add(ParEligibilityIDPayer);

                    SqlParameter ParDocCalenderID = new SqlParameter();
                    ParDocCalenderID.ParameterName = "@DocCalenderID";
                    ParDocCalenderID.Value = DocCalendarID;

                    ParDocCalenderID.DbType = DbType.Int32;
                    cmd.Parameters.Add(ParDocCalenderID);


                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters["@WaitingID"].Value.ToString());

                    //if (cmd.ExecuteNonQuery() > 0)
                    //    {return true;}
                    //else
                    //    { return false;}
                }

            }

            catch (Exception ex)
            { throw ex; }
            finally
            { con.Dispose(); }
        }
        public bool EditSP(string UpdateSQL)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = ConnectionManager.GetConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = UpdateSQL;
                    cmd.CommandType = CommandType.Text;
                    SqlParameter[] a;
                    a = CreateParameters(UpdateSQL);
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
        public int GetWaitingPatientCount()
        {
            try
            {
                SQLStr = " Select Count(*) from WaitingPatient ";
                return Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReader(SQLStr));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetPatientSerial()
        {
            try
            {

                SQLStr = " SELECT Max(PatientSerial)+1 From WaitingPatient ";
                SQLStr += " WHERE DoctorID = " + DoctorID.ToString() + " ";
                SQLStr += " AND (CONVERT (nvarchar(25), WaitingPatient.ArrDate, 105) = CONVERT (nvarchar(25), GETDATE(), 105)) ";

                return Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReader(SQLStr));

            }
            catch (Exception)
            {
                return 1;
            }
        }
        public Boolean CheckPatient(Boolean AllVisits = false)
        {
            try
            {
                SQLStr = " SELECT WaitingPatient.WaitingID From WaitingPatient";
                SQLStr += " WHERE (WaitingPatient.DoctorID = " + DoctorID.ToString() + " ) ";
                SQLStr += " AND PatientID = " + PatientID.ToString();
                SQLStr += "  AND (CONVERT (nvarchar(25), WaitingPatient.ArrDate, 105) = CONVERT (nvarchar(25), GETDATE(), 105)) ";
                if (AllVisits == false) SQLStr += " AND (WaitingPatient.Finish = 0)  ";
                SQLStr += " AND WaitingPatient.EncounterType = " + EncounterType.ToString();


                if (GeneralFunctionsDAC.DDLStatment(SQLStr, "dt").Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Boolean CheckPatientFinish()
        {
            DataTable dt;
            try
            {
                SQLStr = " SELECT WaitingPatient.WaitingID From WaitingPatient ";
                SQLStr += " WHERE (WaitingPatient.DoctorID = " + DoctorID.ToString() + " ) ";
                SQLStr += " AND PatientID = " + PatientID.ToString();
                SQLStr += "  AND (CONVERT (nvarchar(25), WaitingPatient.ArrDate, 105) = CONVERT (nvarchar(25), GETDATE(), 105)) ";
                SQLStr += " AND (WaitingPatient.Finish = 1)  ";



                dt = GeneralFunctionsDAC.DDLStatment(SQLStr, "dt").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    SQLStr = " Update WaitingPatient set ";
                    SQLStr += " WaitingPatient.Finish = 0  ";
                    //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
                    SQLStr += "Where WaitingID = " + dt.Rows[0][0];
                    GeneralFunctionsDAC.DMLStatment(SQLStr);
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable FilterVisitsByPatientID()
        {
            try
            {
                SQLStr = " select WaitingID as VisitID , WaitingPatient.PatientID, Patients.Name as Patient, dbo.FunFormatDateString( ArrDate) as VisitDate  ,";
                SQLStr += " dbo.FunFormatTimeString(ArrDate) as VisitTime ,Doctors.Name as DoctorName , VisitStatus.VisitStatus as status, ";
                SQLStr += " WaitingPatient.VisitStatusID, Doctors.ClinicID, Doctors.DoctorID  ";
                //SQLstr += " from WaitingPatient , Doctors , VisitStatus, Patients where WaitingPatient.DoctorID = Doctors.DoctorID and WaitingPatient.VisitStatusID= VisitStatus.VisitStatusID and WaitingPatient.PatientID = Patients.PatientID";

                SQLStr += " FROM         dbo.WaitingPatient INNER JOIN ";
                SQLStr += "         dbo.Doctors ON dbo.WaitingPatient.DoctorID = dbo.Doctors.DoctorID INNER JOIN ";
                SQLStr += "         dbo.Patients ON dbo.WaitingPatient.PatientID = dbo.Patients.PatientID LEFT OUTER JOIN ";
                SQLStr += "      dbo.VisitStatus ON dbo.WaitingPatient.VisitStatusID = dbo.VisitStatus.VisitStatusID ";

                SQLStr += " WHERE WaitingPatient.PatientID = " + PatientID.ToString();
                if (TempArr != "")
                {
                    SQLStr += " AND dbo.FunFormatDateString( ArrDate) = '" + TempArr + "'";
                }
                SQLStr += " Order By ArrDate Desc ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "WaitingPatient").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SqlDataReader GetLastVisit(int PatientID, Int16 ClinicID)
        {
            SqlParameter[] SQLPrameters = new SqlParameter[2]; ;
            SqlParameter SQLPrameter = null;
            SqlParameter SQLPrameter1 = null;
            try

            {
                SQLPrameter = new SqlParameter("ClinicID", ClinicID);
                SQLPrameter1 = new SqlParameter("PatientID", PatientID);
                SQLPrameters[0] = SQLPrameter;
                SQLPrameters[1] = SQLPrameter1;
                return GeneralFunctionsDAC.DMLSPReaderWithPar("SP_CheckFollowUp", SQLPrameters);
                //Return DataAccess.GeneralFunctionDAC.DMLSPReaderWithPar("SP_CheckFollowUp", SQLPrameters)
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLPrameters = null;
                SQLPrameter = null;
                SQLPrameter1 = null;
            }
        }
        public SqlDataReader GetDisc()
        {
            try
            {
                SQLStr = " Select CoalEsce(CashDisc,0) AS CashDisc, CoalEsce(InsDisc,0) as InsDisc, CoalEsce(CashDiscRatio,0) as CashDiscRatio ";
                SQLStr += " From WaitingPatient ";
                SQLStr += "Where WaitingID = " + WaitingID.ToString();
                return GeneralFunctionsDAC.DDLReader(SQLStr);
            }

            catch (Exception ex)
            { throw new Exception("ClsWaitingPatient - GetDisc " + ex.Message.ToString()); }

        }

        public Boolean PatientFinish()
        {

            SQLStr = "Update WaitingPatient set ";
            SQLStr += " Finish = 1 ";
            //SQLStr += " , UpdatedBy = " + Appointment.Properties.Settings.Default.UserID;
            SQLStr += " Where WaitingID = " + WaitingID.ToString();
            return GeneralFunctionsDAC.DMLStatment(SQLStr);

        }
        public Int32 CalcVisitTime()
        {

            SqlParameter[] SQLPrameters = new SqlParameter[1]; ;
            SqlParameter SQLPrameter = null;

            try

            {
                SQLPrameter = new SqlParameter("VisitID", WaitingID);

                SQLPrameters[0] = SQLPrameter;

                return Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReaderWithPar("SP_WaitingPatient_CalcVisitTime", SQLPrameters));


            }

            catch (Exception ex)
            { throw new Exception("ClsWaitingPatient - GetDisc " + ex.Message.ToString()); }

        }

        public static bool CalcVisitTimeDuration(int VisitID)
        {


            //System.DateTime StDate;
            //System.DateTime EndDate;
            //System.TimeSpan diffResult;
            SqlParameter[] SQLPrameters = new SqlParameter[1]; ;
            SqlParameter SQLPrameter = null;
            Int32 diffResult;
            Int16 LockTime;

            try
            {
                if (VisitID == 0)
                {
                    return false;
                }

                SQLPrameter = new SqlParameter("VisitID", VisitID);

                SQLPrameters[0] = SQLPrameter;

                diffResult = Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReaderWithPar("SP_WaitingPatient_CalcVisitTime", SQLPrameters));



                LockTime = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["LockTime"]);
                if (diffResult >= LockTime)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ClsWaitingPatients - CalcVisitTime " + ex.Message);

            }
            finally
            {

            }

        }

    }

}
