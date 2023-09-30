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
    public class ApiPatientsController : ApiController
    {
        [HttpGet]
        [Route("~/api/ApiPatientsController/GetPatientDataByPatientID")]
        public IHttpActionResult GetPatientDataByPatientID([FromUri] int PatientID)
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
                    //List<ClsApiDoctorAttachment> DoctorAttachmentlst = new List<ClsApiDoctorAttachment>();

                    if (PatientID >= 0)
                    {
                        ClsApiPatients ApiPatientObj = new ClsApiPatients();
                        ApiPatientObj.PatientID = PatientID;
                        dt = ApiPatientObj.GetPatientDataByPatientID();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow aRow in dt.Rows)
                            {
                                ApiPatientObj.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                ApiPatientObj.Code = Convert.ToString(aRow["Code"]);
                                ApiPatientObj.Name = Convert.ToString(aRow["Name"]);
                                ApiPatientObj.Mobile = Convert.ToString(aRow["Mobile"]);
                                ApiPatientObj.HomeTel = Convert.ToString(aRow["HomeTel"]);
                                ApiPatientObj.InsuranceCardID = Convert.ToString(aRow["InsuranceCardID"]);
                                //ApiPatientObj.InsuranceCardExp = Convert.ToString(aRow["InsuranceCardExp"]);
                                if (aRow["InsuranceCardExp"].ToString() =="")
                                {
                                    ApiPatientObj.InsuranceCardExp = "";
                                }
                                else
                                {
                                    ApiPatientObj.InsuranceCardExp = Convert.ToDateTime(Convert.ToString(aRow["InsuranceCardExp"])).ToString("yyyy-MM-dd HH:mm");

                                }
                                ApiPatientObj.InsuranceCardID = Convert.ToString(aRow["InsuranceCardID"]);
                                ApiPatientObj.InsuranceCompany = (aRow["InsuranceCompany"]) as int?;
                                ApiPatientObj.InsuranceCompanyName = Convert.ToString(aRow["InsuranceCompanyName"]);
                                ApiPatientObj.NetworkID = (aRow["NetworkID"]) as int?;
                                ApiPatientObj.InsuranceCardID = Convert.ToString(aRow["InsuranceCardID"]);
                                ApiPatientObj.FeeSubCategoryID = (aRow["FeeSubCategoryID"]) as int?;
                                ApiPatientObj.FeeSubCategory = Convert.ToString(aRow["FeeSubCategory"]);
                                ApiPatientObj.SexID= Convert.ToInt32(aRow["SexID"]);
                                if (int.TryParse(aRow["SexID"].ToString(), out int SexID))
                                {
                                    ClsSex sex = new ClsSex();
                                    List<ClsSex> sexes = new List<ClsSex>();
                                    sexes = sex.Read();
                                    ClsSex ResultSex = new ClsSex();
                                    ResultSex = sexes.FirstOrDefault(c => c.SexID == SexID);
                                    ApiPatientObj.Sex = ResultSex.Sex;
                                }
                                else
                                {
                                    ApiPatientObj.Sex = "Not Available";
                                }
                                ApiPatientObj.DateofBirth= Convert.ToDateTime(Convert.ToString(aRow["DateofBirth"])).ToString("yyyy-MM-dd HH:mm");                               
                                if (int.TryParse(aRow["MaritalStatusID"].ToString(), out int MaritalStatusID))
                                {
                                    ApiPatientObj.MaritalStatusID = MaritalStatusID;
                                }
                                else
                                {
                                    ApiPatientObj.MaritalStatusID = 0;
                                }

                                if (int.TryParse(aRow["Weight"].ToString(), out int Weight))
                                {
                                    ApiPatientObj.Weight = Weight;
                                }
                                else
                                {
                                    ApiPatientObj.Weight = 0;
                                }

                                ApiPatientObj.RegDate = Convert.ToDateTime(Convert.ToString(aRow["RegDate"])).ToString("yyyy-MM-dd HH:mm");
                                //ApiPatientObj.BloodGroupID = Convert.ToInt32(aRow["BloodGroupID"]);
                                ApiPatientObj.BloodGroupID = (aRow["BloodGroupID"]) as int?;
                                ApiPatientObj.Mobile2 = Convert.ToString(aRow["Mobile2"]);
                                ApiPatientObj.Mobile3 = Convert.ToString(aRow["Mobile3"]);
                                ApiPatientObj.Company = Convert.ToString(aRow["Company"]);
                                ApiPatientObj.NationalityID = Convert.ToInt16(aRow["NationalityID"]);
                                ApiPatientObj.Mobile3 = Convert.ToString(aRow["Mobile3"]);
                                ApiPatientObj.EmiratesID = Convert.ToString(aRow["EmiratesID"]);
                                ApiPatientObj.ArabicName = Convert.ToString(aRow["ArabicName"]);
                                ApiPatientObj.CardImg = Convert.ToString(aRow["CardImg"]);
                                ApiPatientObj.Job = Convert.ToString(aRow["Job"]);
                                ApiPatientObj.Address = Convert.ToString(aRow["Address"]);
                                ApiPatientObj.Email = Convert.ToString(aRow["Email"]);
                                ApiPatientObj.FriendName = Convert.ToString(aRow["FriendName"]);
                                ApiPatientObj.FriendTel = Convert.ToString(aRow["FriendTel"]);
                                ApiPatientObj.Relations = Convert.ToString(aRow["Relations"]);
                                if (Int16.TryParse(aRow["FriendGendar"].ToString(), out Int16 FriendGendar))
                                {
                                    ApiPatientObj.FriendGendar = FriendGendar;
                                }
                                else
                                {
                                    ApiPatientObj.FriendGendar = 0;
                                }
                                if (Int16.TryParse(aRow["PC"].ToString(), out Int16 PC))
                                {
                                    ApiPatientObj.PC = PC;
                                }
                                else
                                {
                                    ApiPatientObj.PC = 0;
                                }
                                if (Int16.TryParse(aRow["GP"].ToString(), out Int16 GP))
                                {
                                    ApiPatientObj.GP = GP;
                                }
                                else
                                {
                                    ApiPatientObj.GP = 0;
                                }
                                if (Int16.TryParse(aRow["Ded"].ToString(), out Int16 Ded))
                                {
                                    ApiPatientObj.Ded = Ded;
                                }
                                else
                                {
                                    ApiPatientObj.Ded = 0;
                                }
                                if (Int16.TryParse(aRow["DN"].ToString(), out Int16 DN))
                                {
                                    ApiPatientObj.DN = DN;
                                }
                                else
                                {
                                    ApiPatientObj.DN = 0;
                                }
                                if (Int16.TryParse(aRow["PH"].ToString(), out Int16 PH))
                                {
                                    ApiPatientObj.PH = PH;
                                }
                                else
                                {
                                    ApiPatientObj.PH = 0;
                                }
                                if (Int16.TryParse(aRow["MAXCash"].ToString(), out Int16 MAXCash))
                                {
                                    ApiPatientObj.MAXCash = MAXCash;
                                }
                                else
                                {
                                    ApiPatientObj.MAXCash = 0;
                                }
                                ApiPatientObj.Product = Convert.ToString(aRow["Product"]);
                                if (Int16.TryParse(aRow["CoPay"].ToString(), out Int16 CoPay))
                                {
                                    ApiPatientObj.CoPay = CoPay;
                                }
                                else
                                {
                                    ApiPatientObj.CoPay = 0;
                                }
                                ApiPatientObj.FamilyHistory = Convert.ToString(aRow["FamilyHistory"]);
                                if (Int16.TryParse(aRow["PatientTypeID"].ToString(), out Int16 PatientTypeID))
                                {
                                    ApiPatientObj.PatientTypeID = PatientTypeID;
                                }
                                else
                                {
                                    ApiPatientObj.PatientTypeID = 0;
                                }
                                if (Int16.TryParse(aRow["InsuranceCompany2"].ToString(), out Int16 InsuranceCompany2))
                                {
                                    ApiPatientObj.InsuranceCompany2 = InsuranceCompany2;
                                }
                                else
                                {
                                    ApiPatientObj.InsuranceCompany2 = 0;
                                }
                                if (Int16.TryParse(aRow["FeeSubCategoryID2"].ToString(), out Int16 FeeSubCategoryID2))
                                {
                                    ApiPatientObj.FeeSubCategoryID2 = FeeSubCategoryID2;
                                }
                                else
                                {
                                    ApiPatientObj.FeeSubCategoryID2 = 0;
                                }
                                ApiPatientObj.Product2 = Convert.ToString(aRow["Product2"]);
                                ApiPatientObj.InsuranceCardID2 = Convert.ToString(aRow["InsuranceCardID2"]);
                                //ApiPatientObj.InsuranceCardExp2 = Convert.ToString(aRow["InsuranceCardExp2"]);
                                if (aRow["InsuranceCardExp2"].ToString() == "")
                                {
                                    ApiPatientObj.InsuranceCardExp2 = "";
                                }
                                else
                                {
                                    ApiPatientObj.InsuranceCardExp2 = Convert.ToDateTime(Convert.ToString(aRow["InsuranceCardExp2"])).ToString("yyyy-MM-dd HH:mm");

                                }

                                if (Int16.TryParse(aRow["PC2"].ToString(), out Int16 PC2))
                                {
                                    ApiPatientObj.PC2 = PC2;
                                }
                                else
                                {
                                    ApiPatientObj.PC2 = 0;
                                }
                                if (Int16.TryParse(aRow["GP2"].ToString(), out Int16 GP2))
                                {
                                    ApiPatientObj.GP2 = GP2;
                                }
                                else
                                {
                                    ApiPatientObj.GP2 = 0;
                                }
                                if (Int16.TryParse(aRow["Ded2"].ToString(), out Int16 Ded2))
                                {
                                    ApiPatientObj.Ded2 = Ded2;
                                }
                                else
                                {
                                    ApiPatientObj.Ded2 = 0;
                                }
                                if (Int16.TryParse(aRow["DN2"].ToString(), out Int16 DN2))
                                {
                                    ApiPatientObj.DN2 = Ded2;
                                }
                                else
                                {
                                    ApiPatientObj.DN2 = 0;
                                }
                                if (Int16.TryParse(aRow["PH2"].ToString(), out Int16 PH2))
                                {
                                    ApiPatientObj.PH2 = PH2;
                                }
                                else
                                {
                                    ApiPatientObj.PH2 = 0;
                                }
                                if (Int16.TryParse(aRow["MAXCash2"].ToString(), out Int16 MAXCash2))
                                {
                                    ApiPatientObj.MAXCash2 = MAXCash2;
                                }
                                else
                                {
                                    ApiPatientObj.MAXCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["CoPay2"].ToString(), out Int16 CoPay2))
                                {
                                    ApiPatientObj.CoPay2 = CoPay2;
                                }
                                else
                                {
                                    ApiPatientObj.CoPay2 = 0;
                                }
                                ApiPatientObj.CardImg2 = Convert.ToString(aRow["CardImg2"]);
                                if (Int16.TryParse(aRow["CoPayCash"].ToString(), out Int16 CoPayCash))
                                {
                                    ApiPatientObj.CoPayCash = CoPayCash;
                                }
                                else
                                {
                                    ApiPatientObj.CoPayCash = 0;
                                }
                                if (Int16.TryParse(aRow["DNCash"].ToString(), out Int16 DNCash))
                                {
                                    ApiPatientObj.DNCash = DNCash;
                                }
                                else
                                {
                                    ApiPatientObj.DNCash = 0;
                                }
                                if (Int16.TryParse(aRow["MaxCoPay"].ToString(), out Int16 MaxCoPay))
                                {
                                    ApiPatientObj.MaxCoPay = MaxCoPay;
                                }
                                else
                                {
                                    ApiPatientObj.MaxCoPay = 0;
                                }
                                if (Int16.TryParse(aRow["CoPayCash2"].ToString(), out Int16 CoPayCash2))
                                {
                                    ApiPatientObj.CoPayCash2 = CoPayCash2;
                                }
                                else
                                {
                                    ApiPatientObj.CoPayCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["DNCash2"].ToString(), out Int16 DNCash2))
                                {
                                    ApiPatientObj.DNCash2 = DNCash2;
                                }
                                else
                                {
                                    ApiPatientObj.DNCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["MaxCoPay2"].ToString(), out Int16 MaxCoPay2))
                                {
                                    ApiPatientObj.MaxCoPay2 = MaxCoPay2;
                                }
                                else
                                {
                                    ApiPatientObj.MaxCoPay2 = 0;
                                }
                                ApiPatientObj.Notes = Convert.ToString(aRow["Notes"]);
                                if (Int16.TryParse(aRow["GPPer"].ToString(), out Int16 GPPer))
                                {
                                    ApiPatientObj.GPPer = GPPer;
                                }
                                else
                                {
                                    ApiPatientObj.GPPer = 0;
                                }
                                if (Int16.TryParse(aRow["GPPer2"].ToString(), out Int16 GPPer2))
                                {
                                    ApiPatientObj.GPPer2 = GPPer2;
                                }
                                else
                                {
                                    ApiPatientObj.GPPer2 = 0;
                                }
                                if (Int16.TryParse(aRow["GPMax"].ToString(), out Int16 GPMax))
                                {
                                    ApiPatientObj.GPMax = GPMax;
                                }
                                else
                                {
                                    ApiPatientObj.GPMax = 0;
                                }
                                if (Int16.TryParse(aRow["GPMax2"].ToString(), out Int16 GPMax2))
                                {
                                    ApiPatientObj.GPMax2 = GPMax2;
                                }
                                else
                                {
                                    ApiPatientObj.GPMax2 = 0;
                                }
                                if (Int16.TryParse(aRow["Lab"].ToString(), out Int16 Lab))
                                {
                                    ApiPatientObj.Lab = Lab;
                                }
                                else
                                {
                                    ApiPatientObj.Lab = 0;
                                }
                                if (Int16.TryParse(aRow["LabCash"].ToString(), out Int16 LabCash))
                                {
                                    ApiPatientObj.LabCash = LabCash;
                                }
                                else
                                {
                                    ApiPatientObj.LabCash = 0;
                                }
                                if (Int16.TryParse(aRow["Lab2"].ToString(), out Int16 Lab2))
                                {
                                    ApiPatientObj.Lab2 = Lab2;
                                }
                                else
                                {
                                    ApiPatientObj.Lab2 = 0;
                                }
                                if (Int16.TryParse(aRow["LabCash2"].ToString(), out Int16 LabCash2))
                                {
                                    ApiPatientObj.LabCash2 = LabCash2;
                                }
                                else
                                {
                                    ApiPatientObj.LabCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["Xray"].ToString(), out Int16 Xray))
                                {
                                    ApiPatientObj.Xray = Xray;
                                }
                                else
                                {
                                    ApiPatientObj.Xray = 0;
                                }
                                if (Int16.TryParse(aRow["XrayCash"].ToString(), out Int16 XrayCash))
                                {
                                    ApiPatientObj.XrayCash = XrayCash;
                                }
                                else
                                {
                                    ApiPatientObj.XrayCash = 0;
                                }
                                if (Int16.TryParse(aRow["Xray2"].ToString(), out Int16 Xray2))
                                {
                                    ApiPatientObj.Xray2 = Xray2;
                                }
                                else
                                {
                                    ApiPatientObj.Xray2 = 0;
                                }
                                if (Int16.TryParse(aRow["XrayCash2"].ToString(), out Int16 XrayCash2))
                                {
                                    ApiPatientObj.XrayCash2 = XrayCash2;
                                }
                                else
                                {
                                    ApiPatientObj.XrayCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["PhCash"].ToString(), out Int16 PhCash))
                                {
                                    ApiPatientObj.PhCash = PhCash;
                                }
                                else
                                {
                                    ApiPatientObj.PhCash = 0;
                                }
                                if (Int16.TryParse(aRow["PhCash2"].ToString(), out Int16 PhCash2))
                                {
                                    ApiPatientObj.PhCash2 = PhCash2;
                                }
                                else
                                {
                                    ApiPatientObj.PhCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["NonArabic"].ToString(), out Int16 NonArabic))
                                {
                                    ApiPatientObj.NonArabic = NonArabic;
                                }
                                else
                                {
                                    ApiPatientObj.NonArabic = 0;
                                }
                                ApiPatientObj.CardImgBack = Convert.ToString(aRow["CardImgBack"]);
                                ApiPatientObj.CardImgBack2 = Convert.ToString(aRow["CardImgBack2"]);
                                ApiPatientObj.SecondName = Convert.ToString(aRow["SecondName"]);
                                ApiPatientObj.ThirdName = Convert.ToString(aRow["ThirdName"]);
                                ApiPatientObj.POBox = Convert.ToString(aRow["POBox"]);
                                ApiPatientObj.City = Convert.ToString(aRow["City"]);
                                ApiPatientObj.Emirates = Convert.ToString(aRow["Emirates"]);
                                ApiPatientObj.Area = Convert.ToString(aRow["Area"]);
                                ApiPatientObj.FirstName = Convert.ToString(aRow["FirstName"]);
                                ApiPatientObj.ID = Convert.ToString(aRow["ID"]);
                                if (Int16.TryParse(aRow["IDTypeID"].ToString(), out Int16 IDTypeID))
                                {
                                    ApiPatientObj.IDTypeID = IDTypeID;
                                }
                                else
                                {
                                    ApiPatientObj.IDTypeID = 0;
                                }
                                if (Int16.TryParse(aRow["PHMax"].ToString(), out Int16 PHMax))
                                {
                                    ApiPatientObj.PHMax = PHMax;
                                }
                                else
                                {
                                    ApiPatientObj.PHMax = 0;
                                }
                                if (Int16.TryParse(aRow["PHMax2"].ToString(), out Int16 PHMax2))
                                {
                                    ApiPatientObj.PHMax2 = PHMax2;
                                }
                                else
                                {
                                    ApiPatientObj.PHMax2 = 0;
                                }
                                if (Int16.TryParse(aRow["DNPC"].ToString(), out Int16 DNPC))
                                {
                                    ApiPatientObj.DNPC = DNPC;
                                }
                                else
                                {
                                    ApiPatientObj.DNPC = 0;
                                }
                                if (Int16.TryParse(aRow["DNPC2"].ToString(), out Int16 DNPC2))
                                {
                                    ApiPatientObj.DNPC2 = DNPC2;
                                }
                                else
                                {
                                    ApiPatientObj.DNPC2 = 0;
                                }
                                ApiPatientObj.NetworkID2 = (aRow["NetworkID2"]) as int?;
                                ApiPatientObj.EmiratesIdImg = Convert.ToString(aRow["EmiratesIdImg"]);
                                if (int.TryParse(aRow["HowToKnow"].ToString(), out int HowToKnow))
                                {
                                    ApiPatientObj.HowToKnow = HowToKnow;
                                }
                                else
                                {
                                    ApiPatientObj.HowToKnow = 0;
                                }
                                ApiPatientObj.HowToKnowDetail = Convert.ToString(aRow["HowToKnowDetail"]);
                                ApiPatientObj.OldFileNo = Convert.ToString(aRow["OldFileNo"]);
                                if (int.TryParse(aRow["FeeCategoryPlanID"].ToString(), out int FeeCategoryPlanID))
                                {
                                    ApiPatientObj.FeeCategoryPlanID = FeeCategoryPlanID;
                                }
                                else
                                {
                                    ApiPatientObj.FeeCategoryPlanID = 0;
                                }
                                if (Int16.TryParse(aRow["MakatingUserID"].ToString(), out Int16 MakatingUserID))
                                {
                                    ApiPatientObj.MakatingUserID = MakatingUserID;
                                }
                                else
                                {
                                    ApiPatientObj.MakatingUserID = 0;
                                }
                                ApiPatientObj.TitleCode = Convert.ToString(aRow["TitleCode"]);
                                ApiPatientObj.ReligionCode = Convert.ToString(aRow["ReligionCode"]);
                                ApiPatientObj.LanguageCode = Convert.ToString(aRow["LanguageCode"]);
                                ApiPatientObj.KinContactRoleCode = Convert.ToString(aRow["KinContactRoleCode"]);
                                ApiPatientObj.KinCountryCode = Convert.ToString(aRow["KinCountryCode"]);
                                ApiPatientObj.KinContactCode = Convert.ToString(aRow["KinContactCode"]);
                                ApiPatientObj.EmailTypeCode = Convert.ToString(aRow["EmailTypeCode"]);
                                ApiPatientObj.KinPhoneType = Convert.ToString(aRow["KinPhoneType"]);
                                if (int.TryParse(aRow["EmirateID"].ToString(), out int EmirateID))
                                {
                                    ApiPatientObj.EmirateID = EmirateID;
                                }
                                else
                                {
                                    ApiPatientObj.EmirateID = 0;
                                }
                                ApiPatientObj.KinFirstName = Convert.ToString(aRow["KinFirstName"]);
                                ApiPatientObj.KinMiddleName = Convert.ToString(aRow["KinMiddleName"]);
                                ApiPatientObj.KinLastName = Convert.ToString(aRow["KinLastName"]);
                                ApiPatientObj.KinTitleCode = Convert.ToString(aRow["KinTitleCode"]);
                                ApiPatientObj.RelationshipCode = Convert.ToString(aRow["RelationshipCode"]);
                                ApiPatientObj.MobileAreaCode = Convert.ToString(aRow["MobileAreaCode"]);
                            }


                            //String Result = DataDirectory.GetDataDir_Data();
                            return Ok(ApiPatientObj);
                        }
                        else
                        {
                            vError = new ValidationError();
                            vError.name = HttpStatusCode.NotFound.ToString();
                            vError.description = "No Data For this File No ";
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
                    vError.description = "File No IS Missing " + Exp;
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
        [Route("~/api/ApiPatientsController/GetPatientDataBySearch")]
        public IHttpActionResult GetPatientDataBySearch([FromUri] string Name)
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
                    //List<ClsApiDoctorAttachment> DoctorAttachmentlst = new List<ClsApiDoctorAttachment>();
                    List<ClsApiPatients> ApiPatientsLst = new List<ClsApiPatients>();


                    Dictionary<string, object> CalenderLookup = new Dictionary<string, object>();

                    if (Name != "")
                    {
                        ClsApiPatients ApiPatientObj = new ClsApiPatients();

                        if (int.TryParse(Name, out int NameInt))
                        {
                            ApiPatientObj.Name =Convert.ToString( NameInt);

                        }
                        else
                        {
                            ApiPatientObj.Name = Name;

                        }



                        dt = ApiPatientObj.GetPatientDataBySearch();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow aRow in dt.Rows)
                            {
                                ClsApiPatients Result = new ClsApiPatients();
                                Result.PatientID = Convert.ToInt32(aRow["PatientID"]);
                                Result.Code = Convert.ToString(aRow["Code"]);
                                Result.Name = Convert.ToString(aRow["Name"]);
                                Result.Mobile = Convert.ToString(aRow["Mobile"]);
                                Result.HomeTel = Convert.ToString(aRow["HomeTel"]);
                                Result.InsuranceCardID = Convert.ToString(aRow["InsuranceCardID"]);
                                if (aRow["InsuranceCardExp"].ToString() == "")
                                {
                                    Result.InsuranceCardExp = "";
                                }
                                else
                                {
                                    Result.InsuranceCardExp = Convert.ToDateTime(Convert.ToString(aRow["InsuranceCardExp"])).ToString("yyyy-MM-dd HH:mm");

                                }
                                Result.InsuranceCardID = Convert.ToString(aRow["InsuranceCardID"]);
                                Result.InsuranceCompany = (aRow["InsuranceCompany"]) as int?;
                                Result.InsuranceCompanyName = Convert.ToString(aRow["InsuranceCompanyName"]);
                                Result.NetworkID = (aRow["NetworkID"]) as int?;
                                Result.InsuranceCardID = Convert.ToString(aRow["InsuranceCardID"]);
                                Result.FeeSubCategoryID = (aRow["FeeSubCategoryID"]) as int?;
                                Result.FeeSubCategory = Convert.ToString(aRow["FeeSubCategory"]);
                                Result.SexID = Convert.ToInt32(aRow["SexID"]);
                                if (int.TryParse(aRow["SexID"].ToString(), out int SexID))
                                {
                                    ClsSex sex = new ClsSex();
                                    List<ClsSex> sexes = new List<ClsSex>();
                                    sexes = sex.Read();
                                    ClsSex ResultSex = new ClsSex();
                                    ResultSex = sexes.FirstOrDefault(c => c.SexID == SexID);
                                    Result.Sex = ResultSex.Sex;
                                }
                                else
                                {
                                    Result.Sex = "Not Available";
                                }
                                Result.DateofBirth = Convert.ToDateTime(Convert.ToString(aRow["DateofBirth"])).ToString("yyyy-MM-dd HH:mm");
                                if (int.TryParse(aRow["MaritalStatusID"].ToString(), out int MaritalStatusID))
                                {
                                    Result.MaritalStatusID = MaritalStatusID;
                                }
                                else
                                {
                                    Result.MaritalStatusID = 0;
                                }

                                if (int.TryParse(aRow["Weight"].ToString(), out int Weight))
                                {
                                    Result.Weight = Weight;
                                }
                                else
                                {
                                    ApiPatientObj.Weight = 0;
                                }

                                Result.RegDate = Convert.ToDateTime(Convert.ToString(aRow["RegDate"])).ToString("yyyy-MM-dd HH:mm");
                                //Result.BloodGroupID = Convert.ToInt32(aRow["BloodGroupID"]);
                                Result.BloodGroupID = (aRow["BloodGroupID"]) as int?;
                                Result.Mobile2 = Convert.ToString(aRow["Mobile2"]);
                                Result.Mobile3 = Convert.ToString(aRow["Mobile3"]);
                                Result.Company = Convert.ToString(aRow["Company"]);
                                Result.NationalityID = Convert.ToInt16(aRow["NationalityID"]);
                                Result.Mobile3 = Convert.ToString(aRow["Mobile3"]);
                                Result.EmiratesID = Convert.ToString(aRow["EmiratesID"]);
                                Result.ArabicName = Convert.ToString(aRow["ArabicName"]);
                                Result.CardImg = Convert.ToString(aRow["CardImg"]);
                                Result.Job = Convert.ToString(aRow["Job"]);
                                Result.Address = Convert.ToString(aRow["Address"]);
                                Result.Email = Convert.ToString(aRow["Email"]);
                                Result.FriendName = Convert.ToString(aRow["FriendName"]);
                                Result.FriendTel = Convert.ToString(aRow["FriendTel"]);
                                Result.Relations = Convert.ToString(aRow["Relations"]);
                                if (Int16.TryParse(aRow["FriendGendar"].ToString(), out Int16 FriendGendar))
                                {
                                    Result.FriendGendar = FriendGendar;
                                }
                                else
                                {
                                    Result.FriendGendar = 0;
                                }
                                if (Int16.TryParse(aRow["PC"].ToString(), out Int16 PC))
                                {
                                    Result.PC = PC;
                                }
                                else
                                {
                                    Result.PC = 0;
                                }
                                if (Int16.TryParse(aRow["GP"].ToString(), out Int16 GP))
                                {
                                    Result.GP = GP;
                                }
                                else
                                {
                                    Result.GP = 0;
                                }
                                if (Int16.TryParse(aRow["Ded"].ToString(), out Int16 Ded))
                                {
                                    Result.Ded = Ded;
                                }
                                else
                                {
                                    Result.Ded = 0;
                                }
                                if (Int16.TryParse(aRow["DN"].ToString(), out Int16 DN))
                                {
                                    Result.DN = DN;
                                }
                                else
                                {
                                    Result.DN = 0;
                                }
                                if (Int16.TryParse(aRow["PH"].ToString(), out Int16 PH))
                                {
                                    Result.PH = PH;
                                }
                                else
                                {
                                    Result.PH = 0;
                                }
                                if (Int16.TryParse(aRow["MAXCash"].ToString(), out Int16 MAXCash))
                                {
                                    Result.MAXCash = MAXCash;
                                }
                                else
                                {
                                    Result.MAXCash = 0;
                                }
                                Result.Product = Convert.ToString(aRow["Product"]);
                                if (Int16.TryParse(aRow["CoPay"].ToString(), out Int16 CoPay))
                                {
                                    Result.CoPay = CoPay;
                                }
                                else
                                {
                                    Result.CoPay = 0;
                                }
                                Result.FamilyHistory = Convert.ToString(aRow["FamilyHistory"]);
                                if (Int16.TryParse(aRow["PatientTypeID"].ToString(), out Int16 PatientTypeID))
                                {
                                    Result.PatientTypeID = PatientTypeID;
                                }
                                else
                                {
                                    Result.PatientTypeID = 0;
                                }
                                if (Int16.TryParse(aRow["InsuranceCompany2"].ToString(), out Int16 InsuranceCompany2))
                                {
                                    Result.InsuranceCompany2 = InsuranceCompany2;
                                }
                                else
                                {
                                    Result.InsuranceCompany2 = 0;
                                }
                                if (Int16.TryParse(aRow["FeeSubCategoryID2"].ToString(), out Int16 FeeSubCategoryID2))
                                {
                                    Result.FeeSubCategoryID2 = FeeSubCategoryID2;
                                }
                                else
                                {
                                    Result.FeeSubCategoryID2 = 0;
                                }
                                Result.Product2 = Convert.ToString(aRow["Product2"]);
                                Result.InsuranceCardID2 = Convert.ToString(aRow["InsuranceCardID2"]);
                                //Result.InsuranceCardExp2 = Convert.ToString(aRow["InsuranceCardExp2"]);
                                if (aRow["InsuranceCardExp2"].ToString() == "")
                                {
                                    Result.InsuranceCardExp2 = "";
                                }
                                else
                                {
                                    Result.InsuranceCardExp2 = Convert.ToDateTime(Convert.ToString(aRow["InsuranceCardExp2"])).ToString("yyyy-MM-dd HH:mm");

                                }

                                if (Int16.TryParse(aRow["PC2"].ToString(), out Int16 PC2))
                                {
                                    Result.PC2 = PC2;
                                }
                                else
                                {
                                    Result.PC2 = 0;
                                }
                                if (Int16.TryParse(aRow["GP2"].ToString(), out Int16 GP2))
                                {
                                    Result.GP2 = GP2;
                                }
                                else
                                {
                                    Result.GP2 = 0;
                                }
                                if (Int16.TryParse(aRow["Ded2"].ToString(), out Int16 Ded2))
                                {
                                    Result.Ded2 = Ded2;
                                }
                                else
                                {
                                    Result.Ded2 = 0;
                                }
                                if (Int16.TryParse(aRow["DN2"].ToString(), out Int16 DN2))
                                {
                                    Result.DN2 = Ded2;
                                }
                                else
                                {
                                    Result.DN2 = 0;
                                }
                                if (Int16.TryParse(aRow["PH2"].ToString(), out Int16 PH2))
                                {
                                    Result.PH2 = PH2;
                                }
                                else
                                {
                                    Result.PH2 = 0;
                                }
                                if (Int16.TryParse(aRow["MAXCash2"].ToString(), out Int16 MAXCash2))
                                {
                                    Result.MAXCash2 = MAXCash2;
                                }
                                else
                                {
                                    Result.MAXCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["CoPay2"].ToString(), out Int16 CoPay2))
                                {
                                    Result.CoPay2 = CoPay2;
                                }
                                else
                                {
                                    Result.CoPay2 = 0;
                                }
                                Result.CardImg2 = Convert.ToString(aRow["CardImg2"]);
                                if (Int16.TryParse(aRow["CoPayCash"].ToString(), out Int16 CoPayCash))
                                {
                                    Result.CoPayCash = CoPayCash;
                                }
                                else
                                {
                                    Result.CoPayCash = 0;
                                }
                                if (Int16.TryParse(aRow["DNCash"].ToString(), out Int16 DNCash))
                                {
                                    Result.DNCash = DNCash;
                                }
                                else
                                {
                                    Result.DNCash = 0;
                                }
                                if (Int16.TryParse(aRow["MaxCoPay"].ToString(), out Int16 MaxCoPay))
                                {
                                    Result.MaxCoPay = MaxCoPay;
                                }
                                else
                                {
                                    Result.MaxCoPay = 0;
                                }
                                if (Int16.TryParse(aRow["CoPayCash2"].ToString(), out Int16 CoPayCash2))
                                {
                                    Result.CoPayCash2 = CoPayCash2;
                                }
                                else
                                {
                                    Result.CoPayCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["DNCash2"].ToString(), out Int16 DNCash2))
                                {
                                    Result.DNCash2 = DNCash2;
                                }
                                else
                                {
                                    Result.DNCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["MaxCoPay2"].ToString(), out Int16 MaxCoPay2))
                                {
                                    Result.MaxCoPay2 = MaxCoPay2;
                                }
                                else
                                {
                                    Result.MaxCoPay2 = 0;
                                }
                                Result.Notes = Convert.ToString(aRow["Notes"]);
                                if (Int16.TryParse(aRow["GPPer"].ToString(), out Int16 GPPer))
                                {
                                    Result.GPPer = GPPer;
                                }
                                else
                                {
                                    Result.GPPer = 0;
                                }
                                if (Int16.TryParse(aRow["GPPer2"].ToString(), out Int16 GPPer2))
                                {
                                    Result.GPPer2 = GPPer2;
                                }
                                else
                                {
                                    Result.GPPer2 = 0;
                                }
                                if (Int16.TryParse(aRow["GPMax"].ToString(), out Int16 GPMax))
                                {
                                    Result.GPMax = GPMax;
                                }
                                else
                                {
                                    Result.GPMax = 0;
                                }
                                if (Int16.TryParse(aRow["GPMax2"].ToString(), out Int16 GPMax2))
                                {
                                    Result.GPMax2 = GPMax2;
                                }
                                else
                                {
                                    Result.GPMax2 = 0;
                                }
                                if (Int16.TryParse(aRow["Lab"].ToString(), out Int16 Lab))
                                {
                                    Result.Lab = Lab;
                                }
                                else
                                {
                                    Result.Lab = 0;
                                }
                                if (Int16.TryParse(aRow["LabCash"].ToString(), out Int16 LabCash))
                                {
                                    Result.LabCash = LabCash;
                                }
                                else
                                {
                                    Result.LabCash = 0;
                                }
                                if (Int16.TryParse(aRow["Lab2"].ToString(), out Int16 Lab2))
                                {
                                    Result.Lab2 = Lab2;
                                }
                                else
                                {
                                    Result.Lab2 = 0;
                                }
                                if (Int16.TryParse(aRow["LabCash2"].ToString(), out Int16 LabCash2))
                                {
                                    Result.LabCash2 = LabCash2;
                                }
                                else
                                {
                                    Result.LabCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["Xray"].ToString(), out Int16 Xray))
                                {
                                    Result.Xray = Xray;
                                }
                                else
                                {
                                    Result.Xray = 0;
                                }
                                if (Int16.TryParse(aRow["XrayCash"].ToString(), out Int16 XrayCash))
                                {
                                    Result.XrayCash = XrayCash;
                                }
                                else
                                {
                                    Result.XrayCash = 0;
                                }
                                if (Int16.TryParse(aRow["Xray2"].ToString(), out Int16 Xray2))
                                {
                                    Result.Xray2 = Xray2;
                                }
                                else
                                {
                                    Result.Xray2 = 0;
                                }
                                if (Int16.TryParse(aRow["XrayCash2"].ToString(), out Int16 XrayCash2))
                                {
                                    Result.XrayCash2 = XrayCash2;
                                }
                                else
                                {
                                    Result.XrayCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["PhCash"].ToString(), out Int16 PhCash))
                                {
                                    Result.PhCash = PhCash;
                                }
                                else
                                {
                                    Result.PhCash = 0;
                                }
                                if (Int16.TryParse(aRow["PhCash2"].ToString(), out Int16 PhCash2))
                                {
                                    Result.PhCash2 = PhCash2;
                                }
                                else
                                {
                                    Result.PhCash2 = 0;
                                }
                                if (Int16.TryParse(aRow["NonArabic"].ToString(), out Int16 NonArabic))
                                {
                                    Result.NonArabic = NonArabic;
                                }
                                else
                                {
                                    Result.NonArabic = 0;
                                }
                                Result.CardImgBack = Convert.ToString(aRow["CardImgBack"]);
                                Result.CardImgBack2 = Convert.ToString(aRow["CardImgBack2"]);
                                Result.SecondName = Convert.ToString(aRow["SecondName"]);
                                Result.ThirdName = Convert.ToString(aRow["ThirdName"]);
                                Result.POBox = Convert.ToString(aRow["POBox"]);
                                Result.City = Convert.ToString(aRow["City"]);
                                Result.Emirates = Convert.ToString(aRow["Emirates"]);
                                Result.Area = Convert.ToString(aRow["Area"]);
                                Result.FirstName = Convert.ToString(aRow["FirstName"]);
                                Result.ID = Convert.ToString(aRow["ID"]);
                                if (Int16.TryParse(aRow["IDTypeID"].ToString(), out Int16 IDTypeID))
                                {
                                    Result.IDTypeID = IDTypeID;
                                }
                                else
                                {
                                    Result.IDTypeID = 0;
                                }
                                if (Int16.TryParse(aRow["PHMax"].ToString(), out Int16 PHMax))
                                {
                                    Result.PHMax = PHMax;
                                }
                                else
                                {
                                    Result.PHMax = 0;
                                }
                                if (Int16.TryParse(aRow["PHMax2"].ToString(), out Int16 PHMax2))
                                {
                                    Result.PHMax2 = PHMax2;
                                }
                                else
                                {
                                    Result.PHMax2 = 0;
                                }
                                if (Int16.TryParse(aRow["DNPC"].ToString(), out Int16 DNPC))
                                {
                                    Result.DNPC = DNPC;
                                }
                                else
                                {
                                    Result.DNPC = 0;
                                }
                                if (Int16.TryParse(aRow["DNPC2"].ToString(), out Int16 DNPC2))
                                {
                                    Result.DNPC2 = DNPC2;
                                }
                                else
                                {
                                    Result.DNPC2 = 0;
                                }
                                Result.NetworkID2 = (aRow["NetworkID2"]) as int?;
                                Result.EmiratesIdImg = Convert.ToString(aRow["EmiratesIdImg"]);
                                if (int.TryParse(aRow["HowToKnow"].ToString(), out int HowToKnow))
                                {
                                    Result.HowToKnow = HowToKnow;
                                }
                                else
                                {
                                    Result.HowToKnow = 0;
                                }
                                Result.HowToKnowDetail = Convert.ToString(aRow["HowToKnowDetail"]);
                                Result.OldFileNo = Convert.ToString(aRow["OldFileNo"]);
                                if (int.TryParse(aRow["FeeCategoryPlanID"].ToString(), out int FeeCategoryPlanID))
                                {
                                    Result.FeeCategoryPlanID = FeeCategoryPlanID;
                                }
                                else
                                {
                                    Result.FeeCategoryPlanID = 0;
                                }
                                if (Int16.TryParse(aRow["MakatingUserID"].ToString(), out Int16 MakatingUserID))
                                {
                                    Result.MakatingUserID = MakatingUserID;
                                }
                                else
                                {
                                    Result.MakatingUserID = 0;
                                }
                                Result.TitleCode = Convert.ToString(aRow["TitleCode"]);
                                Result.ReligionCode = Convert.ToString(aRow["ReligionCode"]);
                                Result.LanguageCode = Convert.ToString(aRow["LanguageCode"]);
                                Result.KinContactRoleCode = Convert.ToString(aRow["KinContactRoleCode"]);
                                Result.KinCountryCode = Convert.ToString(aRow["KinCountryCode"]);
                                Result.KinContactCode = Convert.ToString(aRow["KinContactCode"]);
                                Result.EmailTypeCode = Convert.ToString(aRow["EmailTypeCode"]);
                                Result.KinPhoneType = Convert.ToString(aRow["KinPhoneType"]);
                                if (int.TryParse(aRow["EmirateID"].ToString(), out int EmirateID))
                                {
                                    Result.EmirateID = EmirateID;
                                }
                                else
                                {
                                    Result.EmirateID = 0;
                                }
                                Result.KinFirstName = Convert.ToString(aRow["KinFirstName"]);
                                Result.KinMiddleName = Convert.ToString(aRow["KinMiddleName"]);
                                Result.KinLastName = Convert.ToString(aRow["KinLastName"]);
                                Result.KinTitleCode = Convert.ToString(aRow["KinTitleCode"]);
                                Result.RelationshipCode = Convert.ToString(aRow["RelationshipCode"]);
                                Result.MobileAreaCode = Convert.ToString(aRow["MobileAreaCode"]);

                                ApiPatientsLst.Add(Result);
                            }
                            CalenderLookup.Add("Patients", ApiPatientsLst);


                            //String Result = DataDirectory.GetDataDir_Data();
                            return Ok(CalenderLookup);
                        }
                        else
                        {
                            //vError = new ValidationError();
                            //vError.name = HttpStatusCode.NotFound.ToString();
                            //vError.description = "No Data For this File No ";
                            //vErrors = new List<ValidationError>();
                            //vErrors.Add(vError);
                            //eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                            //return Content(HttpStatusCode.BadRequest, eResp);

                            return Ok("No Data For this File No ");

                        }


                    }
                    else
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "Min Length 3";
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
                    vError.description = "File No IS Missing " + Exp;
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
