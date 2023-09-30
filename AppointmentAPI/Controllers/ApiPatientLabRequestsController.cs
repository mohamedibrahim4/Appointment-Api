using Appointment.Entities.BLL;
using Appointment.Entities.BLL.ApiClasses;
using Appointment.Entities.BLL.Classes;
using Appointment.Entitiies.ApiClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace AppointmentAPI.Controllers
{
    public class ApiPatientLabRequestsController : ApiController
    {
        [HttpGet]
        [Route("~/api/ApiPatientLabRequestsController/GetAppPatientLabs")]
        public IHttpActionResult GetAppPatientLabs([FromUri]int FileNo)
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

                    if (FileNo > 0)
                    {
                        ClsApiPatientLabRequests ApiPatientLabs = new ClsApiPatientLabRequests();
                        List<ClsApiGetAppPatientLabs> ApiPatientLabAppLst = new List<ClsApiGetAppPatientLabs>();
                        ApiPatientLabs.PatientID = FileNo;
                        dt = ApiPatientLabs.GetAppPatientLabs();
                        if (dt != null && dt.Rows.Count > 0)
                        {


                            foreach (DataRow aRow in dt.Rows)
                            {
                                ClsApiGetAppPatientLabs Result = new ClsApiGetAppPatientLabs();


                                Result.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                Result.ArrDate = Convert.ToDateTime(Convert.ToString(aRow["ArrDate"])).ToString("yyyy-MM-dd HH:mm");
                                Result.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                Result.WaitingID = Convert.ToInt32(aRow["WaitingID"]);


                                ApiPatientLabAppLst.Add(Result);
                            }

                            return Ok(ApiPatientLabAppLst);

                        }
                        else
                        {
                            return Ok(ApiPatientLabAppLst);
                        }
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
                    vError.description = "App Patient Prescribtion :" + Exp;
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
                vError.description = "User not Authirize to get Data";
                vErrors = new List<ValidationError>();
                vErrors.Add(vError);
                eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                return Content(HttpStatusCode.BadRequest, eResp);
            }
        }
        [HttpGet]
        [Route("~/api/ApiPatientLabRequestsController/GetLabsRequestedByWaiting")]
        public IHttpActionResult GetLabsRequestedByWaiting([FromUri]int WaitingID)
        {
            DataTable dtLabRequests = new DataTable();
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

                    if (WaitingID > 0)
                    {
                        ClsApiPatientLabRequests ApiPatientLabs = new ClsApiPatientLabRequests();
                        List<ClsApiPatientLabRequests> ApiPatientLabsLst = new List<ClsApiPatientLabRequests>();

                        Dictionary<string, object> ResultsLookup = new Dictionary<string, object>();

                        ApiPatientLabs.WaitingID = WaitingID;
                        dtLabRequests = ApiPatientLabs.GetLabsByWaiting();
                        if (dtLabRequests != null && dtLabRequests.Rows.Count > 0 )
                        {

                            //LabsRequested
                            foreach (DataRow aRow in dtLabRequests.Rows)
                            {
                                ClsApiPatientLabRequests Result = new ClsApiPatientLabRequests();


                                Result.LabTestID = Convert.ToInt32(aRow["LabTestID"]);
                                Result.WaitingID = Convert.ToInt32(aRow["WaitingID"]);
                                //Result.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                Result.TestCode = Convert.ToString(aRow["TestCode"]);
                                Result.Test = Convert.ToString(aRow["Test"]);
                                Result.TestID = (aRow["TestID"]) as int?;
                                if (aRow["ResultDate"].ToString() == "")
                                {
                                    Result.ResultDate = "";
                                }
                                else
                                {
                                    Result.ResultDate = Convert.ToDateTime(Convert.ToString(aRow["ResultDate"])).ToString("yyyy-MM-dd HH:mm");

                                }
                                Result.ResultNotes = Convert.ToString(aRow["ResultNotes"]);
                                Result.ResultStatus = (aRow["ResultStatus"]) as int?;


                                ApiPatientLabsLst.Add(Result);
                            }
                            ResultsLookup.Add("LabRequests", ApiPatientLabsLst);

                            



                            return Ok(ResultsLookup);

                        }
                        else
                        {
                            return Ok("No Lab Requests in this Visit Number");
                        }


                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "Visit Number  Is Required";
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
                    vError.description = "There is aproblem when reterive Lab :" + Exp;
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
    }
}
