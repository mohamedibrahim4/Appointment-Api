using Appointment.Entities.BLL;
using Appointment.Entities.BLL.ApiClasses;
using Appointment.Entities.BLL.Classes;
using Appointment.Entitiies.ApiClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
//using System.Web.Mvc;

namespace AppointmentAPI.Controllers
{
    public class ApiAppointmentController : ApiController
    {
        public List<AvailableTime> GetAppointmentSlots([FromUri]string RequestDate)
        {
            ClsApiAppointment App = new ClsApiAppointment();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            try
            {
                List<AvailableTime> AppointmentSlots = new List<AvailableTime>();

                if (RequestDate != null || RequestDate != "")
                {
                    DateTime RequestDateTime = Convert.ToDateTime(RequestDate);
                    AppointmentSlots = App.GetAllSlot(RequestDateTime);


               
                }
                else
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "The  RequestDate Is Required";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return null;
                }
                if (AppointmentSlots != null && AppointmentSlots.Count > 0)
                {
                    return AppointmentSlots;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Exp)
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  RequestDate Is Required Or Format is InnCorrect" + Exp;
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return null;
            }
        }
        public List<AvailableTime> GetAppointmentSlotsBeforeNow([FromUri]string RequestDate)
        {
            ClsApiAppointment App = new ClsApiAppointment();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            try
            {
                List<AvailableTime> AppointmentSlots = new List<AvailableTime>();
                List<AvailableTime> SlotsBeforeNow = new List<AvailableTime>();

                if (RequestDate != null || RequestDate != "")
                {
                    DateTime RequestDateTime = Convert.ToDateTime(RequestDate);
                    AppointmentSlots = App.GetAllSlot(RequestDateTime);


                    DateTime SlotBeforeNow = Convert.ToDateTime(RequestDate);
                    SlotsBeforeNow = App.GetAllSlotBeforeNow(SlotBeforeNow);
                }
                else
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "The  RequestDate Is Required";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return null;
                }
                if (AppointmentSlots != null && AppointmentSlots.Count > 0)
                {
                    return AppointmentSlots;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Exp)
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  RequestDate Is Required Or Format is InnCorrect" + Exp;
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return null;
            }
        }
        public List<AvailableTime> GetNonWorkingTimePerDr([FromUri]string RequestDate,int DoctorID)
        {
            DataTable dt = new DataTable();
            ClsApiAppointment App = new ClsApiAppointment();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            try
            {
                List<AvailableTime> NonWorkingTimePerDrLst = new List<AvailableTime>();

                if (RequestDate != null || RequestDate !="" )
                {
                    string RequestDateTime = Convert.ToDateTime(RequestDate).ToString("dd-MMM-yyyy");
                    dt = App.GetNonWorkingTimePerDr(RequestDateTime, DoctorID);
                    //dt = App.GetBookedAppForDr(RequestDateTime, DoctorID);
                    foreach (DataRow aRow in dt.Rows)
                    {
                        AvailableTime available = new AvailableTime();
                        available.StartTime = Convert.ToDateTime(aRow["startDate"]);
                        available.EndTime = Convert.ToDateTime(aRow["EndDate"]);
                        NonWorkingTimePerDrLst.Add(available);
                    }
                }
                else
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "The  RequestDate Is Required";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return null;
                }            
                if (NonWorkingTimePerDrLst != null && NonWorkingTimePerDrLst.Count > 0)
                {
                    return NonWorkingTimePerDrLst;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Exp)
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  RequestDate Is Required Or Format is InnCorrect" + Exp ;
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return null;
            }
        }
        public List<AvailableTime> GetSlotsBeforeNow([FromUri]string RequestDate, int DoctorID)
        {
            DataTable dt = new DataTable();
            ClsApiAppointment App = new ClsApiAppointment();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            try
            {
                List<AvailableTime> SlotsBeforeNowLst = new List<AvailableTime>();

                if (RequestDate != null || RequestDate != "")
                {
                    string RequestDateTime = Convert.ToDateTime(RequestDate).ToString("dd-MMM-yyyy");
                    dt = App.GetNonWorkingTimePerDr(RequestDateTime, DoctorID);
                    //dt = App.GetBookedAppForDr(RequestDateTime, DoctorID);
                    foreach (DataRow aRow in dt.Rows)
                    {
                        AvailableTime available = new AvailableTime();
                        available.StartTime = Convert.ToDateTime(aRow["startDate"]);
                        available.EndTime = Convert.ToDateTime(aRow["EndDate"]);
                        SlotsBeforeNowLst.Add(available);
                    }
                }
                else
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "The  RequestDate Is Required";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return null;
                }
                if (SlotsBeforeNowLst != null && SlotsBeforeNowLst.Count > 0)
                {
                    return SlotsBeforeNowLst;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Exp)
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  RequestDate Is Required Or Format is InnCorrect" + Exp;
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return null;
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetFreeAppForDr")]
        public IHttpActionResult GetFreeAppForDr([FromUri]string RequestDate,int DoctorID)
        {
            DataTable dt = new DataTable();
            DataTable dtNonWorkingTime = new DataTable();
            //DataTable dtNonWorkingTimeSlots = new DataTable();
            ClsApiAppointment App = new ClsApiAppointment();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
            {
                List<AvailableTime> BookedAppPerDR = new List<AvailableTime>();
                List<AvailableTime> NonWorkingTimePerDrLST = new List<AvailableTime>();
                List<AvailableTime> NonWorkingSlotsLST = new List<AvailableTime>();
                List<AvailableTime> AppointmentSlots = new List<AvailableTime>();
                    List<AvailableTime> SlotsBeforeNow = new List<AvailableTime>();

                    List<AvailableTime> result = new List<AvailableTime>();
                if (RequestDate != null || RequestDate != "")
                {
                        ////All slots 
                        string RequestDateTime = Convert.ToDateTime(RequestDate).ToString("dd-MMM-yyyy");
                        AppointmentSlots = GetAppointmentSlots(RequestDateTime);



                        string RequestDateTime2 = Convert.ToDateTime(RequestDate).ToString("dd-MMM-yyyy hh:mm:ss");
                        //SlotsBeforeNow = App.GetAllSlotBeforeNow(SlotBeforeNow);
                        DateTime SlotBeforeNow = Convert.ToDateTime(RequestDateTime2);
                        SlotsBeforeNow = App.GetAllSlotBeforeNow(SlotBeforeNow);




                        dt = App.GetBookedAppForDr(RequestDateTime, DoctorID);
                    foreach (DataRow aRow in dt.Rows)
                    {
                        AvailableTime available = new AvailableTime();
                        available.StartTime = Convert.ToDateTime(aRow["startDate"]);
                        available.EndTime = Convert.ToDateTime(aRow["EndDate"]);
                        BookedAppPerDR.Add(available);
                    }
                    result = AppointmentSlots;
                    result.RemoveAll((AvailableTime time) => {

                        return BookedAppPerDR.Contains(time);
                    });

                        dtNonWorkingTime = App.GetNonWorkingTimePerDr(RequestDateTime, DoctorID);
                        foreach (DataRow aRow in dtNonWorkingTime.Rows)
                        {
                            AvailableTime available = new AvailableTime();
                            available.StartTime = Convert.ToDateTime(aRow["startDate"]);
                            available.EndTime = Convert.ToDateTime(aRow["EndDate"]);
                            NonWorkingSlotsLST = App.FragmentNonWorkToSlot(available.StartTime, available.EndTime);
                        }
                        result.RemoveAll((AvailableTime time) => {

                            return NonWorkingSlotsLST.Contains(time);
                        });

                    }
                else
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "The  RequestDate Is Required";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }
                    return Ok(result);             
            }
            catch (Exception Exp)
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  RequestDate Is Required Or Format is InnCorrect or Doctor ID IS Missing" + Exp;
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/AddAppointment")]
        public IHttpActionResult AddAppointment([FromBody]ClsApiAppointment App)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsApiAppointment Result = new ClsApiAppointment();
                    if (App != null)
                    {
                        Result.DoctorID = App.DoctorID;
                        Result.AppDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        //Result.AppDate = App.StDate;
                        Result.Patient = App.Patient;
                        Result.PatientID = App.PatientID;
                        Result.MobileNo = App.MobileNo;
                        Result.StDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm"); 
                        Result.EndDate = Convert.ToDateTime(App.EndDate).ToString("yyyy-MM-dd HH:mm");
                        Result.TeleMedicine = App.TeleMedicine;
                        bool InsertResult = Result.InsertSP();
                        if (InsertResult == true)
                        {
                            return Ok(Result);

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Appointment not saved");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Appointment is  missing");
                    }
                    return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Add Appointment Have error!" +Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }       
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAllAppForDr")]
        public IHttpActionResult GetAllAppForDr([FromUri] int DoctorID)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsApiAppointment> AllAppForDr = new List<ClsApiAppointment>();

                    if (DoctorID > 0 )
                    {
                        ////Get All Appointment for Doctor 
                        ClsApiAppointment App = new ClsApiAppointment();

                        dt = App.GetAllAppForDr(DoctorID);
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsApiAppointment ResultApp = new ClsApiAppointment();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);

                            ResultApp.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString( aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.AppDate = Convert.ToDateTime(Convert.ToString(aRow["AppDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.TeleMedicine = Convert.ToInt32(aRow["TeleMedicine"]);
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);

                            AllAppForDr.Add(ResultApp);
                        }
                        return Ok(AllAppForDr);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "Doctor Id Is Required";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Doctor ID IS Missing Or check Appointment Data :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAllAppForPatient")]
        public IHttpActionResult GetAllAppForPatient([FromUri] int PatientID)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsApiAppointment> AllAppForPatient = new List<ClsApiAppointment>();

                    if (PatientID >= 0)
                    {
                        ////Get All Appointment for Doctor 
                        ClsApiAppointment App = new ClsApiAppointment();

                        dt = App.GetAllAppForPatient(PatientID);
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsApiAppointment ResultApp = new ClsApiAppointment();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);

                            ResultApp.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.AppDate = Convert.ToDateTime(Convert.ToString(aRow["AppDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            //ResultApp.TeleMedicine = Convert.ToInt32(aRow["TeleMedicine"]);
                            if (int.TryParse(aRow["TeleMedicine"].ToString(), out int TeleMedicine))
                            {
                                ResultApp.TeleMedicine = TeleMedicine;
                            }
                            else
                            {
                                ResultApp.TeleMedicine = 1;
                            }
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);

                            AllAppForPatient.Add(ResultApp);
                        }
                        return Ok(AllAppForPatient);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "File No Is Required";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "File No IS Missing Or check Appointment Data :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/CancelAppointment")]
        public IHttpActionResult CancelAppointment([FromUri]int DocCalenderID)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsApiAppointment Result = new ClsApiAppointment();
                    if (DocCalenderID > 0)
                    {
                        Result.DocCalenderID = DocCalenderID;
                        
                        bool CancelCalender = Result.AppCanceled();
                        if (CancelCalender == true)
                        {
                            return Ok("Success To cancel Appointment");

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Unable to cancel Appointment ");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Cancel Appointment Required ID to Cancel");
                    }
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "CancelAppointment Have error!" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        private string LogApiException(Exception exp, string MethodName)
        {
            string guid = Guid.NewGuid().ToString();
            //attAPI.Log_API_Error(guid, MethodName, exp.Message, string.Format(" TRACE {0} : INNER EXCEPTION {1}", exp.StackTrace, exp.InnerException), "UDP", ServiceUserName, ServicePassword, ref Result);

            return guid;
        }
        public ErrorResponse PopulateErrorResponse(string MethodName, HttpStatusCode Code, List<ValidationError> ValidationErrors)
        {

            ErrorResponse aResp = new ErrorResponse();
            aResp.instance = MethodName;
            aResp.code = Convert.ToInt32(Code).ToString();
            aResp.message = Code.ToString();
            aResp.validationErrors = ValidationErrors;

            return aResp;

        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/UpdateAppointment")]
        public IHttpActionResult UpdateAppointment([FromBody]ClsApiAppointment App)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsApiAppointment Result = new ClsApiAppointment();
                    if (App != null)
                    {
                        Result.DocCalenderID = App.DocCalenderID;
                        Result.DoctorID = App.DoctorID;
                        Result.AppDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        //Result.AppDate = App.StDate;
                        Result.Patient = App.Patient;
                        Result.PatientID = App.PatientID;
                        Result.MobileNo = App.MobileNo;
                        Result.StDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        Result.EndDate = Convert.ToDateTime(App.EndDate).ToString("yyyy-MM-dd HH:mm");
                        Result.TeleMedicine = App.TeleMedicine;
                        bool EditResult = Result.EditSP(Result.SQLUpdateDescription());
                        if (EditResult == true)
                        {
                            return Ok(Result);

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Appointment not Edit");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Appointment is  missing");
                    }
                    //return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Add Appointment Have error!" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/ChangeStatus")]
        public IHttpActionResult ChangeStatus([FromUri] Int16 StatusID,int LoggedUserID, int DocCalenderID)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsDoctorCalender Result = new ClsDoctorCalender();
                    if (StatusID != 0 && LoggedUserID !=0 && DocCalenderID !=0)
                    {
                        Result.StatusID = StatusID;
                        Result.UpdatedBy = LoggedUserID;
                        Result.DocCalenderID = DocCalenderID;
                        bool ChangeStatus = Result.UpdateStatus();
                        if (ChangeStatus == true)
                        {
                            return Ok(Result);

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Status not Edit");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Status ID is  missing Or User ID OR Doctor Calender ID");
                    }
                    //return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "ChangeStatus Have error! :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/AddAppointmentCalender")]
        public IHttpActionResult AddAppointmentCalender([FromBody]ClsDoctorCalender App)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            DataTable dt = new DataTable();

            if (IsValid)
            {
                try
                {
                    ClsDoctorCalender Result = new ClsDoctorCalender();
                    ClsDoctorCalenderBase ResultAfterSave = new ClsDoctorCalenderBase();

                    if (App != null)
                    {
                        Result.DoctorID = App.DoctorID;
                        Result.AppDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        Result.Patient = App.Patient;
                        Result.PatientID = App.PatientID;
                        Result.MobileNo = App.MobileNo;
                        Result.UpdatedBy = App.UpdatedBy;
                        Result.RoomID = App.RoomID;
                        Result.AppointmentReasonsID = App.AppointmentReasonsID;
                        Result.StDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        Result.EndDate = Convert.ToDateTime(App.EndDate).ToString("yyyy-MM-dd HH:mm");
                        Result.Description = App.Description;
                        Result.NonArabic = App.NonArabic;
                        Result.HowToKnow = App.HowToKnow;
                        int InsertResult = Result.InsertSP();

                        ResultAfterSave.DocCalenderID = InsertResult;
                        dt = ResultAfterSave.GetAppointmentByDocCalenderID();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow aRow in dt.Rows)
                            {
                                ResultAfterSave.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                                ResultAfterSave.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                ResultAfterSave.AppDate = Convert.ToDateTime(aRow["AppDate"]).ToString("yyyy-MM-dd HH:mm");
                                ResultAfterSave.Patient = Convert.ToString(aRow["Patient"]);
                                ResultAfterSave.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                ResultAfterSave.MobileNo = Convert.ToString(aRow["MobileNo"]);
                                ResultAfterSave.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                                if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                                {
                                    ResultAfterSave.RoomID = Convert.ToInt16(RoomID);
                                }
                                else
                                {
                                    ResultAfterSave.RoomID = 0;
                                }
                                if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                                {
                                    ResultAfterSave.AppointmentReasonsID = AppointmentReasonsID;
                                }
                                else
                                {
                                    ResultAfterSave.AppointmentReasonsID = 0;
                                }
                                ResultAfterSave.StDate = Convert.ToDateTime(aRow["StDate"]).ToString("yyyy-MM-dd HH:mm");
                                ResultAfterSave.EndDate = Convert.ToDateTime(aRow["EndDate"]).ToString("yyyy-MM-dd HH:mm");
                                ResultAfterSave.Description = Convert.ToString(aRow["Description"]);
                                ResultAfterSave.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                                ResultAfterSave.HowToKnow = Convert.ToInt16(aRow["HowToKnow"]);
                                ResultAfterSave.LastUpdated = Convert.ToDateTime(aRow["LastUpdated"]).ToString("yyyy-MM-dd HH:mm");
                                ResultAfterSave.StatusID = Convert.ToInt16(aRow["StatusID"]);
                                ResultAfterSave.CreatedBy = Convert.ToString(aRow["CreatedBy"]);



                            }
                        }

                        if (InsertResult > 0)
                        {
                            return Ok(ResultAfterSave);

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Appointment not saved");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Appointment is  missing");
                    }
                    return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Add Appointment Have error!" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/UpdateAppointmentCalender")]
        public IHttpActionResult UpdateAppointmentCalender([FromBody]ClsDoctorCalender App)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            DataTable dt = new DataTable();

            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsDoctorCalenderBase ResultAfterSave = new ClsDoctorCalenderBase();

                    ClsDoctorCalender Result = new ClsDoctorCalender();
                    if (App != null)
                    {
                        Result.DocCalenderID = App.DocCalenderID;
                        Result.DoctorID = App.DoctorID;
                        Result.AppDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        Result.Patient = App.Patient;
                        Result.PatientID = App.PatientID;
                        Result.MobileNo = App.MobileNo;
                        Result.UpdatedBy = App.UpdatedBy;
                        Result.RoomID = App.RoomID;
                        Result.AppointmentReasonsID = App.AppointmentReasonsID;
                        Result.StDate = Convert.ToDateTime(App.StDate).ToString("yyyy-MM-dd HH:mm");
                        Result.EndDate = Convert.ToDateTime(App.EndDate).ToString("yyyy-MM-dd HH:mm");
                        Result.Description = App.Description;
                        Result.NonArabic = App.NonArabic;
                        Result.HowToKnow = App.HowToKnow;

                        bool EditResult = Result.EditSP(Result.SQLUpdateSp());
                        if (EditResult == true)
                        {
                            ResultAfterSave.DocCalenderID = App.DocCalenderID;
                            dt = ResultAfterSave.GetAppointmentByDocCalenderID();
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow aRow in dt.Rows)
                                {
                                    ResultAfterSave.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                                    ResultAfterSave.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                    ResultAfterSave.AppDate = Convert.ToDateTime(aRow["AppDate"]).ToString("yyyy-MM-dd HH:mm");
                                    ResultAfterSave.Patient = Convert.ToString(aRow["Patient"]);
                                    ResultAfterSave.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                    ResultAfterSave.MobileNo = Convert.ToString(aRow["MobileNo"]);
                                    ResultAfterSave.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                                    if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                                    {
                                        ResultAfterSave.RoomID = Convert.ToInt16(RoomID);
                                    }
                                    else
                                    {
                                        ResultAfterSave.RoomID = 0;
                                    }
                                    if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                                    {
                                        ResultAfterSave.AppointmentReasonsID = AppointmentReasonsID;
                                    }
                                    else
                                    {
                                        ResultAfterSave.AppointmentReasonsID = 0;
                                    }
                                    ResultAfterSave.StDate = Convert.ToDateTime(aRow["StDate"]).ToString("yyyy-MM-dd HH:mm");
                                    ResultAfterSave.EndDate = Convert.ToDateTime(aRow["EndDate"]).ToString("yyyy-MM-dd HH:mm");
                                    ResultAfterSave.Description = Convert.ToString(aRow["Description"]);
                                    ResultAfterSave.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                                    ResultAfterSave.HowToKnow = Convert.ToInt16(aRow["HowToKnow"]);
                                    ResultAfterSave.LastUpdated = Convert.ToDateTime(aRow["LastUpdated"]).ToString("yyyy-MM-dd HH:mm");
                                    ResultAfterSave.StatusID = Convert.ToInt16(aRow["StatusID"]);
                                    ResultAfterSave.CreatedBy = Convert.ToString(aRow["CreatedBy"]);



                                }
                            }


                            return Ok(ResultAfterSave);

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Appointment not Edit");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Appointment is  missing");
                    }
                    //return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Add Appointment Have error!" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/CancelAppointmentCalender")]
        public IHttpActionResult CancelAppointmentCalender([FromBody]ClsDoctorCalenerCancelObj DoctorCalenerCancelObj)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsDoctorCalenerCancelObj Result = new ClsDoctorCalenerCancelObj();
                    if (DoctorCalenerCancelObj != null)
                    {
                        Result.DocCalenderID = DoctorCalenerCancelObj.DocCalenderID;
                        Result.UpdatedBy = DoctorCalenerCancelObj.UpdatedBy;
                        Result.DocCalenderID = DoctorCalenerCancelObj.DocCalenderID;

                        bool CancelCalender = Result.AppCanceled();
                        if (CancelCalender == true)
                        {
                            return Ok("Success To cancel Appointment");

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Unable to cancel Appointment ");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Cancel Appointment Required ID to Cancel or Updated By");
                    }
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "CancelAppointment Have error!" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        [HttpPost]
        [Route("~/api/ApiAppointmentController/ChangeStatusCalender")]
        public IHttpActionResult ChangeStatusCalender([FromBody]ClsDoctorCalenerChangeStatusObj DoctorCalenerChangeStatusObj)
        {
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    ClsDoctorCalenerChangeStatusObj Result = new ClsDoctorCalenerChangeStatusObj();
                    ClsDoctorCalenderBase ResultAfterSave = new ClsDoctorCalenderBase();
                    ClsDoctorCalenderBase DoctorCalenderCheck = new ClsDoctorCalenderBase();
                    DataTable dt = new DataTable();

                    if (DoctorCalenerChangeStatusObj != null)
                    {
                        Result.StatusID = DoctorCalenerChangeStatusObj.StatusID;
                        Result.UpdatedBy = DoctorCalenerChangeStatusObj.UpdatedBy;
                        Result.DocCalenderID = DoctorCalenerChangeStatusObj.DocCalenderID;

                        DoctorCalenderCheck.DocCalenderID = DoctorCalenerChangeStatusObj.DocCalenderID;
                        dt = DoctorCalenderCheck.GetAppointmentByDocCalenderID();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow aRow in dt.Rows)
                            {
                                DoctorCalenderCheck.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                                DoctorCalenderCheck.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                DoctorCalenderCheck.AppDate = Convert.ToDateTime(aRow["AppDate"]).ToString("yyyy-MM-dd HH:mm");
                                DoctorCalenderCheck.Patient = Convert.ToString(aRow["Patient"]);
                                DoctorCalenderCheck.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                DoctorCalenderCheck.MobileNo = Convert.ToString(aRow["MobileNo"]);
                                DoctorCalenderCheck.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                                if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                                {
                                    DoctorCalenderCheck.RoomID = Convert.ToInt16(RoomID);
                                }
                                else
                                {
                                    DoctorCalenderCheck.RoomID = 0;
                                }
                                if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                                {
                                    DoctorCalenderCheck.AppointmentReasonsID = AppointmentReasonsID;
                                }
                                else
                                {
                                    DoctorCalenderCheck.AppointmentReasonsID = 0;
                                }
                                DoctorCalenderCheck.StDate = Convert.ToDateTime(aRow["StDate"]).ToString("yyyy-MM-dd HH:mm");
                                DoctorCalenderCheck.EndDate = Convert.ToDateTime(aRow["EndDate"]).ToString("yyyy-MM-dd HH:mm");
                                DoctorCalenderCheck.Description = Convert.ToString(aRow["Description"]);
                                DoctorCalenderCheck.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                                DoctorCalenderCheck.HowToKnow = Convert.ToInt16(aRow["HowToKnow"]);
                                DoctorCalenderCheck.LastUpdated = Convert.ToDateTime(aRow["LastUpdated"]).ToString("yyyy-MM-dd HH:mm");
                                DoctorCalenderCheck.StatusID = Convert.ToInt16(aRow["StatusID"]);

                                if (DoctorCalenderCheck.StatusID == Result.StatusID)
                                {
                                    vError = new ValidationError();
                                    vError.name = HttpStatusCode.NotFound.ToString();
                                    vError.description = "Status Have error! status are the same ^^";
                                    vErrors = new List<ValidationError>();
                                    vErrors.Add(vError);

                                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                                    return Content(HttpStatusCode.BadRequest, eResp);
                                }

                            }
                        }

                        if (Result.StatusID==2)
                        {
                            ClsWaitingPatient WaitingPatient = new ClsWaitingPatient();
                            WaitingPatient.DocCalendarID= DoctorCalenerChangeStatusObj.DocCalenderID;
                            WaitingPatient.Patient= DoctorCalenerChangeStatusObj.Patient;

                            WaitingPatient.UpdatedBy= DoctorCalenerChangeStatusObj.UpdatedBy;
                            WaitingPatient.EncounterType = 1;
                            WaitingPatient.EncounterStartType = 1;
                            WaitingPatient.ServiceTypeID = 1;
                            WaitingPatient.EligibilityIDPayer = "";
                            WaitingPatient.EligibilityIDPayer = "";
                            int waitingID = WaitingPatient.InsertSP();
                            if (waitingID >0)
                            {

                                bool ChangeStatus = Result.UpdateStatus();
                                if (ChangeStatus == true)
                                {
                                    ResultAfterSave.DocCalenderID = DoctorCalenerChangeStatusObj.DocCalenderID;
                                    dt = ResultAfterSave.GetAppointmentByDocCalenderID();
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow aRow in dt.Rows)
                                        {
                                            ResultAfterSave.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                                            ResultAfterSave.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                            ResultAfterSave.AppDate = Convert.ToDateTime(aRow["AppDate"]).ToString("yyyy-MM-dd HH:mm");
                                            ResultAfterSave.Patient = Convert.ToString(aRow["Patient"]);
                                            ResultAfterSave.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                            ResultAfterSave.MobileNo = Convert.ToString(aRow["MobileNo"]);
                                            ResultAfterSave.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                                            if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                                            {
                                                ResultAfterSave.RoomID = Convert.ToInt16(RoomID);
                                            }
                                            else
                                            {
                                                ResultAfterSave.RoomID = 0;
                                            }
                                            if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                                            {
                                                ResultAfterSave.AppointmentReasonsID = AppointmentReasonsID;
                                            }
                                            else
                                            {
                                                ResultAfterSave.AppointmentReasonsID = 0;
                                            }
                                            ResultAfterSave.StDate = Convert.ToDateTime(aRow["StDate"]).ToString("yyyy-MM-dd HH:mm");
                                            ResultAfterSave.EndDate = Convert.ToDateTime(aRow["EndDate"]).ToString("yyyy-MM-dd HH:mm");
                                            ResultAfterSave.Description = Convert.ToString(aRow["Description"]);
                                            ResultAfterSave.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                                            ResultAfterSave.HowToKnow = Convert.ToInt16(aRow["HowToKnow"]);
                                            ResultAfterSave.LastUpdated = Convert.ToDateTime(aRow["LastUpdated"]).ToString("yyyy-MM-dd HH:mm");
                                            ResultAfterSave.StatusID = Convert.ToInt16(aRow["StatusID"]);
                                            ResultAfterSave.CreatedBy = Convert.ToString(aRow["CreatedBy"]);



                                        }
                                    }
                                    return Ok(ResultAfterSave);

                                }
                                else
                                {
                                    return Content(HttpStatusCode.BadRequest, "Status not Edit");

                                }
                            }


                        }
                        else
                        {
                            bool ChangeStatus = Result.UpdateStatus();
                            if (ChangeStatus == true)
                            {
                                ResultAfterSave.DocCalenderID = DoctorCalenerChangeStatusObj.DocCalenderID;
                                dt = ResultAfterSave.GetAppointmentByDocCalenderID();
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    foreach (DataRow aRow in dt.Rows)
                                    {
                                        ResultAfterSave.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                                        ResultAfterSave.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                        ResultAfterSave.AppDate = Convert.ToDateTime(aRow["AppDate"]).ToString("yyyy-MM-dd HH:mm");
                                        ResultAfterSave.Patient = Convert.ToString(aRow["Patient"]);
                                        ResultAfterSave.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                        ResultAfterSave.MobileNo = Convert.ToString(aRow["MobileNo"]);
                                        ResultAfterSave.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                                        if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                                        {
                                            ResultAfterSave.RoomID = Convert.ToInt16(RoomID);
                                        }
                                        else
                                        {
                                            ResultAfterSave.RoomID = 0;
                                        }
                                        if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                                        {
                                            ResultAfterSave.AppointmentReasonsID = AppointmentReasonsID;
                                        }
                                        else
                                        {
                                            ResultAfterSave.AppointmentReasonsID = 0;
                                        }
                                        ResultAfterSave.StDate = Convert.ToDateTime(aRow["StDate"]).ToString("yyyy-MM-dd HH:mm");
                                        ResultAfterSave.EndDate = Convert.ToDateTime(aRow["EndDate"]).ToString("yyyy-MM-dd HH:mm");
                                        ResultAfterSave.Description = Convert.ToString(aRow["Description"]);
                                        ResultAfterSave.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                                        ResultAfterSave.HowToKnow = Convert.ToInt16(aRow["HowToKnow"]);
                                        ResultAfterSave.LastUpdated = Convert.ToDateTime(aRow["LastUpdated"]).ToString("yyyy-MM-dd HH:mm");
                                        ResultAfterSave.StatusID = Convert.ToInt16(aRow["StatusID"]);
                                        ResultAfterSave.CreatedBy = Convert.ToString(aRow["CreatedBy"]);



                                    }
                                }
                                return Ok(ResultAfterSave);

                            }
                            else
                            {
                                return Content(HttpStatusCode.BadRequest, "Status not Edit");

                            }
                        }

                        return Ok(ResultAfterSave);

                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Status ID is  missing Or User ID OR Doctor Calender ID");
                    }
                    //return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "ChangeStatus Have error! :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Add Appointment");

            }

        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAppointmentByDate")]
        public IHttpActionResult GetAppointmentByDate([FromUri]string StartDate, [FromUri]string EndDate)
        {
            DataTable dt = new DataTable();
            DataTable dtDoctorNonWorkingTime = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalender> AppointmentByDateLst = new List<ClsDoctorCalender>();
                    //NonWorkingTime
                    List<ClsDoctorNonWorkingTime> DoctorNonWorkingTimeLst = new List<ClsDoctorNonWorkingTime>();
                    Dictionary<string, object> AppointmentByDateDic = new Dictionary<string, object>();
                    List<List<NonWorkingSlotsObj>> NonWorkingSlotsLSTOfLST = new List<List<NonWorkingSlotsObj>>() ;

                    //List<NonWorkingSlotsObj> NonWorkingSlotsLST = new List<NonWorkingSlotsObj>();
                    ClsApiAppointment App = new ClsApiAppointment();

                    if (StartDate != null || StartDate != "" && EndDate != null || EndDate != "")
                    {
                        ////Get All Appointment for Doctor 
                        ClsDoctorCalender DoctorCalender = new ClsDoctorCalender();
                        DoctorCalender.StDate= Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");
                        DoctorCalender.EndDate= Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");
                        dt = DoctorCalender.GetAppointmentByDate();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalender ResultApp = new ClsDoctorCalender();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.LastUpdated = Convert.ToDateTime(Convert.ToString(aRow["LastUpdated"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                            //ResultApp.AppointmentReasonsID = Convert.ToInt32(aRow["AppointmentReasonsID"]);
                            if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                            {
                                ResultApp.AppointmentReasonsID = AppointmentReasonsID;
                            }
                            else
                            {
                                ResultApp.AppointmentReasonsID = 0;
                            }
                            if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                            {
                                ResultApp.RoomID =Convert.ToInt16( RoomID);
                            }
                            else
                            {
                                ResultApp.RoomID = 0;
                            }


                            if (int.TryParse(aRow["HowToKnow"].ToString(), out int HowToKnow))
                            {
                                ResultApp.HowToKnow = Convert.ToInt16(HowToKnow);
                            }
                            else
                            {
                                ResultApp.HowToKnow = 0;
                            }
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.StatusID = Convert.ToInt16(aRow["StatusID"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.CreateDate = Convert.ToDateTime(Convert.ToString(aRow["CreateDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.CreatedBy = Convert.ToString(aRow["CreatedBy"]);


                            AppointmentByDateLst.Add(ResultApp);
                        }
                        //NonWorkingTime
                        ClsDoctorNonWorkingTime DoctorNonWorkingTime = new ClsDoctorNonWorkingTime();
                        string StDateNonWorkingTime = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");
                        string EndDateNonWorkingTime = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");
                        dtDoctorNonWorkingTime = DoctorNonWorkingTime.GetNonWorkingTimePeriodc(StDateNonWorkingTime, EndDateNonWorkingTime);
                        foreach (DataRow aRow in dtDoctorNonWorkingTime.Rows)
                        {
                            ClsDoctorNonWorkingTime ResultAppNonWorkingTime = new ClsDoctorNonWorkingTime();

                            ResultAppNonWorkingTime.StartTime = Convert.ToDateTime(Convert.ToString(aRow["startDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultAppNonWorkingTime.EndTime = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");

                            ResultAppNonWorkingTime.DoctorID = Convert.ToInt32(aRow["DoctorID"]);

                            List<NonWorkingSlotsObj> NonWorkingSlotsLST = new List<NonWorkingSlotsObj>();
                            NonWorkingSlotsLST = App.FragmentNonWorkToSlotDoctorID(Convert.ToDateTime(Convert.ToString(aRow["startDate"])), Convert.ToDateTime(Convert.ToString(aRow["EndDate"])), ResultAppNonWorkingTime.DoctorID);

                            NonWorkingSlotsLSTOfLST.Add(NonWorkingSlotsLST);

                            DoctorNonWorkingTimeLst.Add(ResultAppNonWorkingTime);
                        }


                        List<NonWorkingSlotsObj> NonWorkingSlotsLSTResult = new List<NonWorkingSlotsObj>();
                        NonWorkingSlotsLSTResult = NonWorkingSlotsLSTOfLST.SelectMany(x => x).ToList();

                        AppointmentByDateDic.Add("GetAppointmentByDate", AppointmentByDateLst);
                        AppointmentByDateDic.Add("DoctorNonWorkingTime", DoctorNonWorkingTimeLst);
                        //AppointmentByDateDic.Add("DoctorNonWorkingTimeSlots", NonWorkingSlotsLSTOfLST);
                        AppointmentByDateDic.Add("DoctorNonWorkingTimeSlotsObj", NonWorkingSlotsLSTResult);

                        return Ok(AppointmentByDateDic);
                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "StartDate Is Required,EndDate Is Required";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "StartDate Is Required,EndDate Is Required :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAppointmentByDateAndDoctor")]
        public IHttpActionResult GetAppointmentByDateAndDoctor([FromUri]string StartDate, [FromUri]string EndDate, [FromUri] int DoctorID)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalender> AppointmentByDateLst = new List<ClsDoctorCalender>();
                    Dictionary<string, object> AppointmentByDateDic = new Dictionary<string, object>();

                    if (StartDate != null || StartDate != "" && EndDate != null || EndDate != "")
                    {
                        ////Get All Appointment for Doctor 
                        ClsDoctorCalender DoctorCalender = new ClsDoctorCalender();
                        DoctorCalender.StDate = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");
                        DoctorCalender.EndDate = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");
                        DoctorCalender.DoctorID = DoctorID;
                        dt = DoctorCalender.GetAppointmentByDateAndDoctor();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalender ResultApp = new ClsDoctorCalender();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.LastUpdated = Convert.ToDateTime(Convert.ToString(aRow["LastUpdated"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.UpdatedBy = Convert.ToInt32(aRow["UpdatedBy"]);
                            //ResultApp.AppointmentReasonsID = Convert.ToInt32(aRow["AppointmentReasonsID"]);
                            if (int.TryParse(aRow["AppointmentReasonsID"].ToString(), out int AppointmentReasonsID))
                            {
                                ResultApp.AppointmentReasonsID = AppointmentReasonsID;
                            }
                            else
                            {
                                ResultApp.AppointmentReasonsID = 0;
                            }
                            if (int.TryParse(aRow["RoomID"].ToString(), out int RoomID))
                            {
                                ResultApp.RoomID = Convert.ToInt16(RoomID);
                            }
                            else
                            {
                                ResultApp.RoomID = 0;
                            }


                            if (int.TryParse(aRow["HowToKnow"].ToString(), out int HowToKnow))
                            {
                                ResultApp.HowToKnow = Convert.ToInt16(HowToKnow);
                            }
                            else
                            {
                                ResultApp.HowToKnow = 0;
                            }
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.StatusID = Convert.ToInt16(aRow["StatusID"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.CreateDate = Convert.ToDateTime(Convert.ToString(aRow["CreateDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.CreatedBy = Convert.ToString(aRow["CreatedBy"]);


                            AppointmentByDateLst.Add(ResultApp);
                        }

                        AppointmentByDateDic.Add("GetAppointmentByDateAndDoctor", AppointmentByDateLst);

                        return Ok(AppointmentByDateDic);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "StartDate Is Required,EndDate Is Required,DoctorID Is Required";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "StartDate Is Required,EndDate Is Required,DoctorID Is Required :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAppointmentHistoryByMobile")]
        public IHttpActionResult GetAppointmentHistoryByMobile([FromUri]string MobileNo)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalender> AppointmentHistoryByMobilest = new List<ClsDoctorCalender>();
                    Dictionary<string, object> AppointmentHistoryByMobileDic = new Dictionary<string, object>();

                    if (MobileNo != null || MobileNo != "")
                    {
                        ////Get All Appointment for Doctor 
                        ClsDoctorCalenderByMobile DoctorCalender = new ClsDoctorCalenderByMobile();
                        DoctorCalender.MobileNo = MobileNo;
                        dt = DoctorCalender.GetAppointmentHistoryByMobile();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalenderByMobile ResultApp = new ClsDoctorCalenderByMobile();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.UpdatedBy = Convert.ToString(aRow["UpdatedBy"]);
                            ResultApp.Doctor = Convert.ToString(aRow["Doctor"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.AppointmentReasons = Convert.ToString(aRow["AppointmentReasons"]);
                            ResultApp.VisitStatus = Convert.ToString(aRow["VisitStatus"]);
                            ResultApp.HowToKnow = Convert.ToString(aRow["HowToKnow"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.Action = Convert.ToString(aRow["Action"]);
                            ResultApp.ActionDt = Convert.ToDateTime(Convert.ToString(aRow["ActionDt"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);


                            AppointmentHistoryByMobilest.Add(ResultApp);
                        }

                        AppointmentHistoryByMobileDic.Add("AppointmentHistoryByMobile", AppointmentHistoryByMobilest);

                        return Ok(AppointmentHistoryByMobileDic);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "Pattern of MobileNo is Missing";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Appointment History By Mobile have Error :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetLAstAppointmentHistoryByPatientID")]
        public IHttpActionResult GetLAstAppointmentHistoryByPatientID([FromUri]int PatientID)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalender> AppointmentHistoryByMobilest = new List<ClsDoctorCalender>();
                    Dictionary<string, object> AppointmentHistoryByMobileDic = new Dictionary<string, object>();

                    if (PatientID != 0 &&PatientID > 0)
                    {
                        ////Get All Appointment for Doctor 
                        ClsDoctorCalenderByMobile DoctorCalender = new ClsDoctorCalenderByMobile();
                        DoctorCalender.PatientID = PatientID;
                        dt = DoctorCalender.GetLastAppointmentHistoryByPatientID();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalenderByMobile ResultApp = new ClsDoctorCalenderByMobile();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.UpdatedBy = Convert.ToString(aRow["UpdatedBy"]);
                            ResultApp.Doctor = Convert.ToString(aRow["Doctor"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.AppointmentReasons = Convert.ToString(aRow["AppointmentReasons"]);
                            ResultApp.VisitStatus = Convert.ToString(aRow["VisitStatus"]);
                            ResultApp.HowToKnow = Convert.ToString(aRow["HowToKnow"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.Action = Convert.ToString(aRow["Action"]);
                            ResultApp.ActionDt = Convert.ToDateTime(Convert.ToString(aRow["ActionDt"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);


                            AppointmentHistoryByMobilest.Add(ResultApp);
                        }

                        AppointmentHistoryByMobileDic.Add("AppointmentHistoryByMobile", AppointmentHistoryByMobilest);

                        return Ok(AppointmentHistoryByMobileDic);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "PatientID is Missing";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "LAst Appointment History By Patient ID have Error :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAppointmentHistoryByPatientID")]
        public IHttpActionResult GetAppointmentHistoryByPatientID([FromUri]int PatientID)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalenderByPatientID> AppointmentHistoryByByPatientIDlst = new List<ClsDoctorCalenderByPatientID>();
                    Dictionary<string, object> AppointmentHistoryByPatientIDDic = new Dictionary<string, object>();

                    if (PatientID  != 0 && PatientID >0)
                    {
                        ////Get All Appointment for Doctor 
                        ClsDoctorCalenderByMobile DoctorCalender = new ClsDoctorCalenderByMobile();
                        DoctorCalender.PatientID = PatientID;
                        dt = DoctorCalender.GetAppointmentHistoryByPatientID();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalenderByPatientID ResultApp = new ClsDoctorCalenderByPatientID();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.UpdatedBy = Convert.ToString(aRow["UpdatedBy"]);
                            ResultApp.Doctor = Convert.ToString(aRow["Doctor"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.AppointmentReasons = Convert.ToString(aRow["AppointmentReasons"]);
                            ResultApp.VisitStatus = Convert.ToString(aRow["VisitStatus"]);
                            ResultApp.HowToKnow = Convert.ToString(aRow["HowToKnow"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.Action = Convert.ToString(aRow["Action"]);
                            ResultApp.ActionDt = Convert.ToDateTime(Convert.ToString(aRow["ActionDt"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);


                            AppointmentHistoryByByPatientIDlst.Add(ResultApp);
                        }

                        AppointmentHistoryByPatientIDDic.Add("AppointmentHistoryByByPatientID", AppointmentHistoryByByPatientIDlst);

                        return Ok(AppointmentHistoryByPatientIDDic);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "File No is Missing";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Appointment History By File No have Error :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetAppointmentHistoryByDocCalenderID")]
        public IHttpActionResult GetAppointmentHistoryByDocCalenderID([FromUri]int DocCalenderID)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalenderByPatientID> AppointmentHistoryByByPatientIDlst = new List<ClsDoctorCalenderByPatientID>();
                    Dictionary<string, object> AppointmentHistoryByPatientIDDic = new Dictionary<string, object>();

                    if (DocCalenderID != 0 && DocCalenderID > 0)
                    {
                        ////Get All Appointment for Doctor 
                        ClsDoctorCalenderByMobile DoctorCalender = new ClsDoctorCalenderByMobile();
                        DoctorCalender.DocCalenderID = DocCalenderID;
                        dt = DoctorCalender.GetAppointmentHistoryByDocCalenderID();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalenderByPatientID ResultApp = new ClsDoctorCalenderByPatientID();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.UpdatedBy = Convert.ToString(aRow["UpdatedBy"]);
                            ResultApp.Doctor = Convert.ToString(aRow["Doctor"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.AppointmentReasons = Convert.ToString(aRow["AppointmentReasons"]);
                            ResultApp.VisitStatus = Convert.ToString(aRow["VisitStatus"]);
                            ResultApp.HowToKnow = Convert.ToString(aRow["HowToKnow"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.Action = Convert.ToString(aRow["Action"]);
                            ResultApp.ActionDt = Convert.ToDateTime(Convert.ToString(aRow["ActionDt"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);


                            AppointmentHistoryByByPatientIDlst.Add(ResultApp);
                        }

                        AppointmentHistoryByPatientIDDic.Add("AppointmentHistoryByByPatientID", AppointmentHistoryByByPatientIDlst);

                        return Ok(AppointmentHistoryByPatientIDDic);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "DocCalenderID is Missing";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Appointment History By DocCalender ID have Error :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiAppointmentController/GetFutureAppointment")]
        public IHttpActionResult GetFutureAppointment([FromUri]string Name)
        {
            DataTable dt = new DataTable();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            {
                try
                {
                    List<ClsDoctorCalender> AppointmentHistoryByMobilest = new List<ClsDoctorCalender>();
                    Dictionary<string, object> AppointmentHistoryByMobileDic = new Dictionary<string, object>();
                    ////Get All Appointment for Doctor 
                    ClsDoctorCalenderByMobile DoctorCalender = new ClsDoctorCalenderByMobile();
                    if (Name != "")
                    {
                        if (int.TryParse(Name, out int NameInt))
                        {
                            DoctorCalender.Patient = Convert.ToString(NameInt);
                        }
                        else
                        {
                            DoctorCalender.Patient = Name;
                        }
                        dt = DoctorCalender.GetFutureAppointment();
                        foreach (DataRow aRow in dt.Rows)
                        {
                            ClsDoctorCalenderByMobile ResultApp = new ClsDoctorCalenderByMobile();

                            ResultApp.DocCalenderID = Convert.ToInt32(aRow["DocCalenderID"]);
                            ResultApp.StDate = Convert.ToDateTime(Convert.ToString(aRow["StDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.EndDate = Convert.ToDateTime(Convert.ToString(aRow["EndDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.AppDate = Convert.ToDateTime(Convert.ToString(aRow["AppDate"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.PatientID = Convert.ToInt32(aRow["PatientID"]);
                            ResultApp.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                            ResultApp.Patient = Convert.ToString(aRow["Patient"]);
                            ResultApp.MobileNo = Convert.ToString(aRow["MobileNo"]);
                            ResultApp.UpdatedBy = Convert.ToString(aRow["UpdatedBy"]);
                            ResultApp.Doctor = Convert.ToString(aRow["Doctor"]);
                            ResultApp.Description = Convert.ToString(aRow["Description"]);
                            ResultApp.AppointmentReasons = Convert.ToString(aRow["AppointmentReasons"]);
                            ResultApp.VisitStatus = Convert.ToString(aRow["VisitStatus"]);
                            ResultApp.HowToKnow = Convert.ToString(aRow["HowToKnow"]);
                            ResultApp.Room = Convert.ToString(aRow["Room"]);
                            ResultApp.Action = "";
                            ResultApp.ActionDt = Convert.ToDateTime(Convert.ToString(aRow["ActionDt"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.LastUpdated = Convert.ToDateTime(Convert.ToString(aRow["ActionDt"])).ToString("yyyy-MM-dd HH:mm");
                            ResultApp.Canceled = Convert.ToBoolean(aRow["Canceled"]);
                            ResultApp.Attend = Convert.ToBoolean(aRow["Attend"]);
                            ResultApp.Finish = Convert.ToBoolean(aRow["Finish"]);
                            ResultApp.NonArabic = Convert.ToInt16(aRow["NonArabic"]);


                            AppointmentHistoryByMobilest.Add(ResultApp);
                        }

                        AppointmentHistoryByMobileDic.Add("FutureAppointment", AppointmentHistoryByMobilest);

                        return Ok(AppointmentHistoryByMobileDic);

                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "PatientID is Missing";
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);
                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "LAst Appointment History By Patient ID have Error :" + Exp;
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);
                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                vError = new ValidationError();
                vError.name = HttpStatusCode.NotFound.ToString();
                vError.description = "The  User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }



    }
}
