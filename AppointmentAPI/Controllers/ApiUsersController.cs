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
    public class ApiUsersController : ApiController
    {
        [HttpPost]
        [Route("~/api/ApiUsersController/Login")]
        public IHttpActionResult Login([FromBody]ClsApiUsers apiUsers )
        {
            DataTable dt = new DataTable();
            ClsApiUsers ApiUsersLog = new ClsApiUsers();

            ApiUsersLog.ApiUserName = apiUsers.ApiUserName;
            ApiUsersLog.password = apiUsers.password;
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
                    dt = ApiUsersLog.GetUser();
                    ClsApiUsers Result = new ClsApiUsers();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow aRow = dt.Rows[0];

                        Result.ApiUserID = Convert.ToInt32(aRow["ApiUserID"]);
                        Result.ApiUserName = Convert.ToString(aRow["ApiUserName"]);
                        Result.ApiUserEmail = Convert.ToString(aRow["ApiUserEmail"]);
                        Result.ApiUserPhone = Convert.ToString(aRow["ApiUserPhone"]);
                        Result.Doc_Type = Convert.ToInt32(aRow["Doc_Type"]);
                        Result.Doc_Id = Convert.ToString(aRow["Doc_Id"]);
                        Result.password = Convert.ToString(aRow["password"]);
                        Result.PicPath = Convert.ToString(aRow["PicPath"]);
                        Result.FileNo = Convert.ToInt32(aRow["FileNo"]);
                        Result.IsActive = Convert.ToBoolean(aRow["IsActive"]);
                        Result.PicPath = Convert.ToString(aRow["PicPath"]);
                        Result.RoleTypeId = Convert.ToInt32(aRow["RoleTypeId"]);
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Users not exists");
                    }
                    return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Users not exists";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Login");

            }

        }
        [HttpPost]
        [Route("~/api/ApiUsersController/Register")]
        public IHttpActionResult Register([FromBody]ClsApiUsers apiUsersInsert)
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
                    ClsApiUsers Result = new ClsApiUsers();
                    if (apiUsersInsert != null)
                    {
                        Result.ApiUserID = apiUsersInsert.ApiUserID;
                        Result.ApiUserName = apiUsersInsert.ApiUserName;
                        Result.ApiUserEmail = apiUsersInsert.ApiUserEmail;
                        Result.ApiUserPhone = apiUsersInsert.ApiUserPhone;
                        Result.Doc_Type = apiUsersInsert.Doc_Type;
                        Result.Doc_Id = apiUsersInsert.Doc_Id;
                        Result.password = apiUsersInsert.password;
                        Result.PicPath = "";
                        Result.FileNo = 0;
                        Result.IsActive = true;
                        Result.PicPath = "";
                        Result.RoleTypeId =(int)RoleUserType.Patient;

                        bool InsertResult=Result.InsertSP();
                        if (InsertResult ==true)
                        {
                            return Ok(Result);

                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, "Users not exists");

                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "Users not exists");
                    }
                    return Ok(Result);
                }
                catch (Exception Exp)
                {

                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "Users not exists";
                    vErrors = new List<ValidationError>();
                    vErrors.Add(vError);

                    eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                    return Content(HttpStatusCode.BadRequest, eResp);
                }

            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Login");

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
