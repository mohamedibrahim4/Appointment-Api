using Appointment.Entities.BLL;
using Appointment.Entities.BLL.ApiClasses;
using Appointment.Entities.BLL.Classes;
using Appointment.Entitiies.ApiClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AppointmentAPI.Controllers
{
    public class ApiDoctorAttachmentController : ApiController
    {
        [HttpGet]
        [Route("~/api/ApiDoctorAttachmentController/GetAttachmentForPatientByType")]
        public IHttpActionResult GetAttachmentForPatientByType([FromUri] int PatientID, [FromUri] int DoctorAttachmentTypeID)
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
                    List<ClsApiDoctorAttachment> DoctorAttachmentlst = new List<ClsApiDoctorAttachment>();

                    if (PatientID >= 0)
                    {
                        ClsApiDoctorAttachment DoctorAttachmentObj = new ClsApiDoctorAttachment();
                        DoctorAttachmentObj.PatientID = PatientID;
                        DoctorAttachmentObj.DoctorAttachmentTypeID = DoctorAttachmentTypeID;
                        dt = DoctorAttachmentObj.GetDataAttachmentByType();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow aRow in dt.Rows)
                            {
                                ClsApiDoctorAttachment DoctorAttachmentObjResult = new ClsApiDoctorAttachment();
                                DoctorAttachmentObjResult.AttachmentID = Convert.ToInt32(aRow["AttachmentID"]);
                                DoctorAttachmentObjResult.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                DoctorAttachmentObjResult.Description = Convert.ToString(aRow["Description"]);
                                DoctorAttachmentObjResult.FileName = Convert.ToString(aRow["FileName"]);
                                //DoctorAttachmentObjResult.AttachmentDate = Convert.ToDateTime(Convert.ToString(aRow["AttachmentDate"])).ToString("yyyy-MM-dd HH:mm");
                                if (aRow["AttachmentDate"].ToString() == "")
                                {
                                    DoctorAttachmentObjResult.AttachmentDate = "";
                                }
                                else
                                {
                                    DoctorAttachmentObjResult.AttachmentDate = Convert.ToDateTime(Convert.ToString(aRow["AttachmentDate"])).ToString("yyyy-MM-dd HH:mm");

                                }

                                DoctorAttachmentObjResult.Del = Convert.ToBoolean(aRow["Del"]);
                                DoctorAttachmentObjResult.DoctorAttachmentTypeID = (aRow["DoctorAttachmentTypeID"]) as int?;
                                DoctorAttachmentObjResult.DoctorID = (aRow["DoctorID"]) as int?;
                                DoctorAttachmentObjResult.VisitID = (aRow["VisitID"]) as int?;
                                DoctorAttachmentlst.Add(DoctorAttachmentObjResult);
                            }
                            return Ok(DoctorAttachmentlst);
                        }
                        else
                        {
                            return Ok(DoctorAttachmentlst);

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
                    vError.description = "File No IS Missing Or check Attachment Type:" + Exp;
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
        [Route("~/api/ApiDoctorAttachmentController/GetAttachmentForPatient")]
        public IHttpActionResult GetAttachmentForPatient([FromUri] int PatientID)
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
                    List<ClsApiDoctorAttachment> DoctorAttachmentlst = new List<ClsApiDoctorAttachment>();

                    if (PatientID >= 0)
                    {
                        ClsApiDoctorAttachment DoctorAttachmentObj = new ClsApiDoctorAttachment();
                        DoctorAttachmentObj.PatientID = PatientID;
                        dt = DoctorAttachmentObj.GetDataAttachmentForPatient();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow aRow in dt.Rows)
                            {
                                ClsApiDoctorAttachment DoctorAttachmentObjResult = new ClsApiDoctorAttachment();
                                DoctorAttachmentObjResult.AttachmentID = Convert.ToInt32(aRow["AttachmentID"]);
                                DoctorAttachmentObjResult.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                DoctorAttachmentObjResult.Description = Convert.ToString(aRow["Description"]);
                                DoctorAttachmentObjResult.FileName = Convert.ToString(aRow["FileName"]);
                                DoctorAttachmentObjResult.AttachmentDate = Convert.ToDateTime(Convert.ToString(aRow["AttachmentDate"])).ToString("yyyy-MM-dd HH:mm");
                                DoctorAttachmentObjResult.Del = Convert.ToBoolean(aRow["Del"]);
                                DoctorAttachmentObjResult.DoctorAttachmentTypeID = (aRow["DoctorAttachmentTypeID"]) as int?;
                                DoctorAttachmentObjResult.DoctorID = (aRow["DoctorID"]) as int?;
                                DoctorAttachmentObjResult.VisitID = (aRow["VisitID"]) as int?;

                                DoctorAttachmentlst.Add(DoctorAttachmentObjResult);
                            }
                            return Ok(DoctorAttachmentlst);
                        }
                        else
                        {
                            return Ok(DoctorAttachmentlst);

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
                    vError.description = "File No IS Missing Or check Attachment Type:" + Exp;
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
        [Route("~/api/ApiDoctorAttachmentController/SaveConsentSignedForPatient")]
        public async Task<IHttpActionResult> SaveConsentSignedForPatient([FromUri] int PatientID, [FromUri] string AttachedName)
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
                    if (PatientID >0 && AttachedName !="" && AttachedName != null)
                    {


                        var ctx = HttpContext.Current;
                        var root = ctx.Server.MapPath("~/SignedConsents");
                        var provider = new MultipartFormDataStreamProvider(root);
                        try
                        {
                            await Request.Content.ReadAsMultipartAsync(provider);
                            foreach (var file in provider.FileData)
                            {
                                var name = file.Headers.ContentDisposition.FileName;
                                name = name.Trim('"');
                              //  name = name.Split('.')[1];
                              //var   NewName = AttachedName + "@@" + PatientID+"@@"+DateTime.Now.ToString(("yyyy-MM-dd HH:mm"));
                              //  NewName = NewName + "." + name;
                                var localFileName = file.LocalFileName;
                                var filePath = Path.Combine(root, name);
                                File.Move(localFileName, filePath);
                                
                            }

                        }
                        catch (Exception e)
                        {
                            vError = new ValidationError();
                            vError.name = HttpStatusCode.NotFound.ToString();
                            vError.description = $"Error :{e.Message}";
                            vErrors = new List<ValidationError>();
                            vErrors.Add(vError);
                            eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                            return Content(HttpStatusCode.BadRequest, eResp);                    
                        }
                        return Ok("File Uploaded and save Successfully");
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
                    vError.description = "File No IS Missing Or check Attachment Type:" + Exp;
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
        public class AttachedFile
        {
            public int PatientID { get; set; }
            public string AttachedName { get; set; }
        }
    }
}
