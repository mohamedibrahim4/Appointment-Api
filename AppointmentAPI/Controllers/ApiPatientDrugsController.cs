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
    public class ApiPatientDrugsController : ApiController
    {
        [HttpGet]
        [Route("~/api/ApiPatientDrugsController/GetAppPatientDrugs")]
        public IHttpActionResult GetAppPatientDrugs([FromUri]int FileNo)
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
                        ClsApiPatientDrugs ApiPatientDrugs = new ClsApiPatientDrugs();
                        List<ClsApiGetAppPatientDrugs> ApiPatientDrugsApp = new List<ClsApiGetAppPatientDrugs>();
                        ApiPatientDrugs.PatientID = FileNo;
                        dt = ApiPatientDrugs.GetAppPatientDrugs();
                        if (dt != null && dt.Rows.Count > 0)
                        {


                            foreach (DataRow aRow in dt.Rows)
                            {
                                ClsApiGetAppPatientDrugs Result = new ClsApiGetAppPatientDrugs();


                                Result.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                Result.ArrDate = Convert.ToDateTime(Convert.ToString(aRow["ArrDate"])).ToString("yyyy-MM-dd HH:mm");
                                Result.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                Result.WaitingID = Convert.ToInt32(aRow["WaitingID"]);


                                ApiPatientDrugsApp.Add(Result);
                            }

                            return Ok(ApiPatientDrugsApp);

                        }
                        else
                        {
                            return Ok(ApiPatientDrugsApp);
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
        [Route("~/api/ApiPatientDrugsController/GetDrugsAndDiagnosisByWaiting")]
        public IHttpActionResult GetDrugsAndDiagnosisByWaiting([FromUri]int WaitingID)
        {
            DataTable dtDrugs = new DataTable();
            DataTable dtDiagnosis = new DataTable();
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
                        ClsApiPatientDrugs ApiPatientDrugs = new ClsApiPatientDrugs();
                        ClsApiPatientClaimFormDetail ApiClaimFormDetail = new ClsApiPatientClaimFormDetail();
                        List<ClsApiPatientDrugs> ApiPatientDrugsLst = new List<ClsApiPatientDrugs>();
                        List<ClsApiPatientClaimFormDetail> ApiClaimFormDetailLst = new List<ClsApiPatientClaimFormDetail>();

                        Dictionary<string, object> ResultsLookup = new Dictionary<string, object>();

                        ApiPatientDrugs.WaitingID = WaitingID;
                        ApiClaimFormDetail.WaitingID = WaitingID;
                        dtDrugs = ApiPatientDrugs.GetDrugsByWaiting();
                        dtDiagnosis = ApiClaimFormDetail.GetDataByWaitingID();
                        if (dtDrugs != null && dtDrugs.Rows.Count > 0 && dtDiagnosis != null && dtDiagnosis.Rows.Count > 0)
                        {

                            //drugs
                            foreach (DataRow aRow in dtDrugs.Rows)
                            {
                                ClsApiPatientDrugs Result = new ClsApiPatientDrugs();


                                Result.PatientDrugID = Convert.ToInt32(aRow["PatientDrugID"]);
                                Result.WaitingID = Convert.ToInt32(aRow["WaitingID"]);
                                Result.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                Result.DrugCode = Convert.ToString(aRow["DrugCode"]);
                                Result.PackageName = Convert.ToString(aRow["PackageName"]);
                                Result.GenericName = Convert.ToString(aRow["GenericName"]);
                                Result.ProductName = Convert.ToString(aRow["ProductName"]);
                                Result.Dose = Convert.ToString(aRow["Dose"]);
                                Result.Instructions = Convert.ToString(aRow["Instructions"]);
                                Result.Duration = Convert.ToString(aRow["Duration"]);
                                Result.Qty = Convert.ToUInt32(aRow["Qty"]);
                                Result.Unit = Convert.ToString(aRow["Unit"]);
                                Result.DurationPeriod = Convert.ToString(aRow["DurationPeriod"]);
                                Result.DurationQty = Convert.ToInt32(aRow["DurationQty"]);
                                Result.DrugID = Convert.ToInt32(aRow["DrugID"]);
                                Result.DrugType = Convert.ToInt32(aRow["DrugType"]);
                                Result.DoseQty = Convert.ToInt32(aRow["DoseQty"]);
                                Result.DoseUnit = Convert.ToString(aRow["DoseUnit"]);
                                Result.DrugRoute = Convert.ToString(aRow["DrugRoute"]);
                                Result.QuantityTimingPriority = Convert.ToString(aRow["QuantityTimingPriorityDesc"]);
                                Result.DrugInstruction = Convert.ToInt32(aRow["DrugInstruction"]);
                                Result.DrugInstructionstxt = Convert.ToString(aRow["DrugInstructionstxt"]);
                                Result.Form = Convert.ToString(aRow["Form"]);


                                ApiPatientDrugsLst.Add(Result);
                            }
                            ResultsLookup.Add("Drugs", ApiPatientDrugsLst);

                            //Diagnosis
                            foreach (DataRow aRow in dtDiagnosis.Rows)
                            {
                                ClsApiPatientClaimFormDetail Result2 = new ClsApiPatientClaimFormDetail();


                                Result2.PatientClaimDetailID = Convert.ToInt32(aRow["PatientClaimDetailID"]);
                                Result2.ICD9 = Convert.ToString(aRow["ICD9"]);
                                Result2.Diagnosis = Convert.ToString(aRow["Diagnosis"]);
                                //Result2.PatientClaimFormID = Convert.ToInt32(aRow["PatientClaimFormID"]);
                                Result2.PatientClaimFormID = (aRow["PatientClaimFormID"]) as int?;
                                Result2.TypeID = Convert.ToInt16(aRow["TypeID"]);
                                Result2.Type = Convert.ToString(aRow["Type"]);
                                Result2.WaitingID = Convert.ToInt32(aRow["WaitingID"]);



                                ApiClaimFormDetailLst.Add(Result2);
                            }
                            ResultsLookup.Add("Diagnosis", ApiClaimFormDetailLst);



                            return Ok(ResultsLookup);

                        }
                        else
                        {
                            return Ok("No Prescribtion in this Visit Number");
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
                    vError.description = "There is aproblem when reterive Prescription :" + Exp;
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
