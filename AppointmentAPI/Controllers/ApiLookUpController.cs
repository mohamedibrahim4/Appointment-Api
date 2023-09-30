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
using System.Web.Http;

namespace AppointmentAPI.Controllers
{
    public class ApiLookUpController : ApiController
    {
        [HttpGet]
        [Route("~/api/ApiLookUpController/GetLookup")]
        public IHttpActionResult GetLookup(string lang="En")
        {
            ClsApiLookUp apiLookUp = new ClsApiLookUp();
            ClsApiClinicCenterLogo centerLogo = new ClsApiClinicCenterLogo();
            ClsApiDrugUnit DrugUnit = new ClsApiDrugUnit();
            ClsApiDrugRoute DrugRoute = new ClsApiDrugRoute();
            ClsApiDrugInstruction DrugInstruction = new ClsApiDrugInstruction();
            ClsApiDoctorAttachmentTypes DoctorAttachmentType = new ClsApiDoctorAttachmentTypes();
            ErrorResponse eResp;
            ValidationError vError;
            List<ValidationError> vErrors;
            GeneralFunction gen = new GeneralFunction();
            HeaderData header = gen.ReadHeaderData(this.Request.Headers);
            bool IsValid = gen.ValidateHeader(header);
            if (IsValid)
            { 
                //English Return
                //if (header.Lang==Language.English)
                //{
                    try
                    {
                        DataTable dtDoctors = new DataTable();
                        DataTable dtNonActiveDoctors = new DataTable();
                        DataTable dtClinics = new DataTable();
                        DataTable dtBranches = new DataTable();
                        DataTable dtNationality = new DataTable();
                        DataTable dtClinicCenterLogo = new DataTable();
                        DataTable dtDrugUnit = new DataTable();
                        DataTable dtDrugRoute = new DataTable();
                        DataTable dtDrugInstruction = new DataTable();
                        DataTable dtDoctorAttachmentType = new DataTable();
                        dtDoctors = apiLookUp.GetDataDoctors();
                        dtNonActiveDoctors = apiLookUp.GetDataNonActiveDoctors();
                        dtClinics = apiLookUp.GetDataClinics();
                        dtBranches = apiLookUp.GetDataBranches();
                        dtNationality = apiLookUp.GetDataNationality();
                        dtClinicCenterLogo = centerLogo.GetDataClinicCenterLogo();
                        dtDrugUnit = DrugUnit.GetDataDrugUnit();
                        dtDrugRoute = DrugRoute.GetDataDrugRoute();
                        dtDrugInstruction = DrugInstruction.GetDataDrugInstruction();
                        dtDoctorAttachmentType = DoctorAttachmentType.GetDataDoctorAttachmentTypes();
                        List<ClsApiLookUp> DoctorLookUpS = new List<ClsApiLookUp>();
                        List<ClsApiLookUp> NonActiveDoctorsLookUpS = new List<ClsApiLookUp>();
                        Dictionary<string, object> ResultsLookup = new Dictionary<string, object>();
                        if (dtDoctors != null && dtDoctors.Rows.Count > 0 && dtClinics != null && dtClinics.Rows.Count > 0 && dtBranches != null && dtBranches.Rows.Count > 0 && dtNationality != null && dtNationality.Rows.Count > 0 && dtClinicCenterLogo != null && dtClinicCenterLogo.Rows.Count > 0 && dtDrugUnit != null && dtDrugUnit.Rows.Count > 0 && dtDrugRoute != null && dtDrugRoute.Rows.Count > 0 && dtDoctorAttachmentType != null && dtDoctorAttachmentType.Rows.Count > 0)
                        {

                            //ActiveDoctor
                            foreach (DataRow aRow in dtDoctors.Rows)
                            {

                                ClsApiLookUp Doctor = new ClsApiLookUp();
                                Doctor.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                Doctor.Name = Convert.ToString(aRow["Name"]);
                                Doctor.NameEn = Convert.ToString(aRow["Name"]);
                                Doctor.NameAr = Convert.ToString(aRow["NameAr"]);
                                Doctor.DoctorSpecialityID = Convert.ToString(aRow["DoctorSpecialityID"]);
                                Doctor.Mobile = Convert.ToString(aRow["Mobile"]);

                                if (int.TryParse(aRow["HomeTel"].ToString(), out int number))
                                {
                                    Doctor.HomeTel = number;
                                }
                                else
                                {
                                    Doctor.HomeTel = 0;
                                }
                                Doctor.PasspoerNo = Convert.ToString(aRow["PasspoerNo"]);
                                Doctor.CardID = Convert.ToString(aRow["CardID"]);
                                Doctor.CardExp = Convert.ToString(aRow["CardExp"]);

                                if (int.TryParse(aRow["SexID"].ToString(), out int SexID))
                                {
                                    ClsSex sex = new ClsSex();
                                    List<ClsSex> sexes = new List<ClsSex>();
                                    sexes = sex.Read();
                                    ClsSex Result = new ClsSex();
                                    Result = sexes.FirstOrDefault(c => c.SexID == SexID);
                                    Doctor.Sex = Result.Sex;
                                    Doctor.SexEN = Result.Sex;
                                    Doctor.SexAr = Result.SexAR;

                                }
                                else
                                {
                                    Doctor.Sex = "Not Available";
                                    Doctor.SexEN = "Not Available";
                                    Doctor.SexAr = "غير متوافر";
                                }
                                if (short.TryParse(aRow["DoctorCategoryID"].ToString(), out short DoctorCategoryID))
                                {
                                    Doctor.DoctorCategoryID = DoctorCategoryID;
                                }
                                else
                                {
                                    Doctor.DoctorCategoryID = 0;
                                }

                                if (short.TryParse(aRow["MaritalStatusID"].ToString(), out short MaritalStatusID))
                                {
                                    Doctor.MaritalStatusID = MaritalStatusID;
                                }
                                else
                                {
                                    Doctor.MaritalStatusID = 0;
                                }
                                Doctor.Email = Convert.ToString(aRow["Email"]);
                                Doctor.LicenseNo = Convert.ToString(aRow["LicenseNo"]);
                                if (int.TryParse(aRow["BranchID"].ToString(), out int BranchID))
                                {
                                    Doctor.BranchID = BranchID;
                                }
                                else
                                {
                                    Doctor.BranchID = 0;
                                }
                                if (int.TryParse(aRow["ClinicID"].ToString(), out int ClinicID))
                                {
                                    Doctor.ClinicID = ClinicID;
                                }
                                else
                                {
                                    Doctor.ClinicID = 0;
                                }

                               string LangKnownGet = aRow["LangKnown"].ToString();
                                if (LangKnownGet != "")
                                {
                                 
                                    Doctor.LangKnown = aRow["LangKnown"].ToString().Split(',');
                                }
                                else
                                {
                                    string[]  EmpArr= { "Empty" };
                                    Doctor.LangKnown = EmpArr;
                                }

                                Doctor.Biograohy = Convert.ToString(aRow["Biograohy"]);
                                Doctor.BiograohyEn = Convert.ToString(aRow["Biograohy"]);
                                Doctor.BiograohyAr = Convert.ToString(aRow["BiograohyAr"]);
                                Doctor.YearsExp = Convert.ToString(aRow["YearsExp"]);
                                Doctor.ImgPath = Convert.ToString(aRow["ImgPath"]);
                                Doctor.TeleMedicine = Convert.ToBoolean(aRow["TeleMedicine"]);
                                Doctor.Email = Convert.ToString(aRow["Email"]);
                                Doctor.LicenseNo = Convert.ToString(aRow["LicenseNo"]);
                                Doctor.Stamp = (Byte[])aRow["Stamp"];
                                //var ms = new MemoryStream(Doctor.Stamp) { Position = 0 };
                                ////Doctor.Stamp = ms;
                                Doctor.UserSign = (Byte[])aRow["UserSign"];
                                DoctorLookUpS.Add(Doctor);
                            }
                            //NonActiveDoctor
                            foreach (DataRow aRow in dtNonActiveDoctors.Rows)
                            {

                                ClsApiLookUp Doctor = new ClsApiLookUp();
                                Doctor.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                                Doctor.Name = Convert.ToString(aRow["Name"]);
                                Doctor.NameEn = Convert.ToString(aRow["Name"]);
                                Doctor.NameAr = Convert.ToString(aRow["NameAr"]);
                                Doctor.DoctorSpecialityID = Convert.ToString(aRow["DoctorSpecialityID"]);
                                Doctor.Mobile = Convert.ToString(aRow["Mobile"]);

                                if (int.TryParse(aRow["HomeTel"].ToString(), out int number))
                                {
                                    Doctor.HomeTel = number;
                                }
                                else
                                {
                                    Doctor.HomeTel = 0;
                                }
                                //Doctor.HomeTel = Convert.ToInt32(aRow["HomeTel"]);
                                Doctor.PasspoerNo = Convert.ToString(aRow["PasspoerNo"]);
                                Doctor.CardID = Convert.ToString(aRow["CardID"]);
                                Doctor.CardExp = Convert.ToString(aRow["CardExp"]);
                                if (int.TryParse(aRow["SexID"].ToString(), out int SexID))
                                {
                                    ClsSex sex = new ClsSex();
                                    List<ClsSex> sexes = new List<ClsSex>();
                                    sexes = sex.Read();
                                    ClsSex Result = new ClsSex();
                                    Result = sexes.FirstOrDefault(c => c.SexID == SexID);
                                    Doctor.Sex = Result.Sex;
                                    Doctor.SexEN = Result.Sex;
                                    Doctor.SexAr = Result.SexAR;

                                }
                                else
                                {
                                    Doctor.Sex = "Not Available";
                                    Doctor.SexEN = "Not Available";
                                    Doctor.SexAr = "غير متوافر";
                                }
                                if (short.TryParse(aRow["DoctorCategoryID"].ToString(), out short DoctorCategoryID))
                                {
                                    Doctor.DoctorCategoryID = DoctorCategoryID;
                                }
                                else
                                {
                                    Doctor.DoctorCategoryID = 0;
                                }
                                //Doctor.DoctorCategoryID = Convert.ToInt16(aRow["DoctorCategoryID"]);

                                if (short.TryParse(aRow["MaritalStatusID"].ToString(), out short MaritalStatusID))
                                {
                                    Doctor.MaritalStatusID = MaritalStatusID;
                                }
                                else
                                {
                                    Doctor.MaritalStatusID = 0;
                                }
                                //Doctor.MaritalStatusID = Convert.ToInt16(aRow["MaritalStatusID"]);
                                Doctor.Email = Convert.ToString(aRow["Email"]);
                                Doctor.LicenseNo = Convert.ToString(aRow["LicenseNo"]);
                                if (int.TryParse(aRow["BranchID"].ToString(), out int BranchID))
                                {
                                    Doctor.BranchID = BranchID;
                                }
                                else
                                {
                                    Doctor.BranchID = 0;
                                }
                                //Doctor.BranchID = Convert.ToInt16(aRow["BranchID"]);
                                if (int.TryParse(aRow["ClinicID"].ToString(), out int ClinicID))
                                {
                                    Doctor.ClinicID = ClinicID;
                                }
                                else
                                {
                                    Doctor.ClinicID = 0;
                                }
                                string LangKnownGet = aRow["LangKnown"].ToString();
                                if (LangKnownGet != "")
                                {

                                    Doctor.LangKnown = aRow["LangKnown"].ToString().Split(',');
                                }
                                else
                                {
                                    string[] EmpArr = { "Empty" };
                                    Doctor.LangKnown = EmpArr;
                                }
                                Doctor.Biograohy = Convert.ToString(aRow["Biograohy"]);
                                Doctor.BiograohyEn = Convert.ToString(aRow["Biograohy"]);
                                Doctor.BiograohyAr = Convert.ToString(aRow["BiograohyAr"]);
                                Doctor.YearsExp = Convert.ToString(aRow["YearsExp"]);
                                Doctor.ImgPath = Convert.ToString(aRow["ImgPath"]);
                                Doctor.TeleMedicine = Convert.ToBoolean(aRow["TeleMedicine"]);
                                Doctor.Stamp = (Byte[])aRow["Stamp"];
                                Doctor.UserSign = (Byte[])aRow["UserSign"];

                                NonActiveDoctorsLookUpS.Add(Doctor);
                            }
                            //Clinics
                            List<KeyValueTwoPair> kvPairsClinics = new List<KeyValueTwoPair>();
                            foreach (DataRow aRow in dtClinics.Rows)
                            {

                                KeyValueTwoPair kvp = new KeyValueTwoPair();
                                kvp.Id = Convert.ToInt32(aRow["CinicID"]);
                                kvp.NameEn = Convert.ToString(aRow["Clinic"]);
                                kvp.NameAr = Convert.ToString(aRow["ClinicAr"]);
                                kvp.ImgPath = Convert.ToString(aRow["ImgPath"]);


                                kvPairsClinics.Add(kvp);
                            }
                            //Branches
                            List<KeyValuePair> kvPairsBranches = new List<KeyValuePair>();
                            foreach (DataRow aRow in dtBranches.Rows)
                            {

                                KeyValuePair kvp = new KeyValuePair();
                                kvp.Id= Convert.ToInt32(aRow["BranchID"]);
                                kvp.NameEn = Convert.ToString(aRow["Branch"]);
                                kvp.NameAr = Convert.ToString(aRow["BranchAr"]);


                                kvPairsBranches.Add(kvp);
                            }
                            //Nationality 
                            List<KeyValuePair> kvPairsNationality = new List<KeyValuePair>();
                            foreach (DataRow aRow in dtNationality.Rows)
                            {

                                KeyValuePair kvp = new KeyValuePair();
                                kvp.Id = Convert.ToInt32(aRow["NationalityID"]);
                                kvp.NameEn = Convert.ToString(aRow["Nationality"]);
                                kvp.NameAr = Convert.ToString(aRow["NationalityAr"]);


                                kvPairsNationality.Add(kvp);
                            }
                            //ClinicCenterLogo 
                            List<ClsApiClinicCenterLogo> ClinicCenterLogos = new List<ClsApiClinicCenterLogo>();
                            foreach (DataRow aRow in dtClinicCenterLogo.Rows)
                            {

                                ClsApiClinicCenterLogo ClinicCenterLogoObj = new ClsApiClinicCenterLogo();
                                ClinicCenterLogoObj.ID = Convert.ToInt32(aRow["ID"]);
                                ClinicCenterLogoObj.ClinicCenter = Convert.ToString(aRow["ClinicCenter"]);
                                ClinicCenterLogoObj.Header =(Byte[]) aRow["Header"];
                                ClinicCenterLogoObj.Logo = (Byte[]) aRow["Logo"];
                                ClinicCenterLogoObj.Footer = (Byte[]) aRow["Footer"];
                                ClinicCenterLogoObj.ProviderNo = Convert.ToString(aRow["ProviderNo"]);
                                ClinicCenterLogoObj.Provider_Name = Convert.ToString(aRow["Provider Name"]);
                                ClinicCenterLogoObj.HaadLicense = Convert.ToString(aRow["HaadLicense"]);
                                ClinicCenterLogoObj.HaadUserName = Convert.ToString(aRow["HaadUserName"]);
                                ClinicCenterLogoObj.HaadPassword = Convert.ToString(aRow["HaadPassword"]);
                                ClinicCenterLogos.Add(ClinicCenterLogoObj);
                            }
                            //DrugUnit 
                            List<KeykeyPair> DrugUnits = new List<KeykeyPair>();
                            foreach (DataRow aRow in dtDrugUnit.Rows)
                            {

                                KeykeyPair DrugUnitObj = new KeykeyPair();
                                DrugUnitObj.key = Convert.ToString(aRow["DrugUnit"]);
                                DrugUnitObj.NameEn = Convert.ToString(aRow["DrugUnit"]);
                                DrugUnitObj.NameAr = Convert.ToString(aRow["DrugUnitAr"]);

                                DrugUnits.Add(DrugUnitObj);
                            }
                            //DrugRoute 
                            List<KeykeyPair> DrugRoutes = new List<KeykeyPair>();
                            foreach (DataRow aRow in dtDrugRoute.Rows)
                            {

                                KeykeyPair DrugRouteObj = new KeykeyPair();
                                DrugRouteObj.NameEn = Convert.ToString(aRow["DrugRouteDesc"]);
                                DrugRouteObj.NameAr = Convert.ToString(aRow["DrugRouteDescAr"]);
                                DrugRouteObj.key = Convert.ToString(aRow["DrugRoute"]);

                                DrugRoutes.Add(DrugRouteObj);
                            }
                            //DrugInstruction 
                            List<KeyValuePair> DrugInstructions = new List<KeyValuePair>();
                            foreach (DataRow aRow in dtDrugInstruction.Rows)
                            {

                                KeyValuePair DrugInstructionObj = new KeyValuePair();
                                DrugInstructionObj.Id = Convert.ToInt32(aRow["DrugInstructionID"]);
                                DrugInstructionObj.NameEn = Convert.ToString(aRow["DrugInstruction"]);
                                DrugInstructionObj.NameAr = Convert.ToString(aRow["DrugInstructionAr"]);
                                DrugInstructions.Add(DrugInstructionObj);
                            }
                            //DoctorAttachmentTypes 
                            List<KeyValuePair> DoctorAttachmentTypelst = new List<KeyValuePair>();
                            foreach (DataRow aRow in dtDoctorAttachmentType.Rows)
                            {

                                KeyValuePair DoctorAttachmentTypesObj = new KeyValuePair();
                                DoctorAttachmentTypesObj.Id = Convert.ToInt32(aRow["DoctorAttachmentTypeID"]);
                                DoctorAttachmentTypesObj.NameEn = Convert.ToString(aRow["DoctorAttachmentType"]);
                                DoctorAttachmentTypesObj.NameAr = Convert.ToString(aRow["DoctorAttachmentTypesAr"]);
                                DoctorAttachmentTypelst.Add(DoctorAttachmentTypesObj);
                            }


                            ResultsLookup.Add("Doctors", DoctorLookUpS);
                            ResultsLookup.Add("NonActiveDoctors", NonActiveDoctorsLookUpS);
                            ResultsLookup.Add("Clinics", kvPairsClinics);
                            ResultsLookup.Add("Branches", kvPairsBranches);
                            ResultsLookup.Add("Nationality", kvPairsNationality);
                            ResultsLookup.Add("ClinicCenterLogo", ClinicCenterLogos);
                            ResultsLookup.Add("DrugUnit", DrugUnits);
                            ResultsLookup.Add("DrugRoute", DrugRoutes);
                            ResultsLookup.Add("DrugInstruction", DrugInstructions);
                            ResultsLookup.Add("DoctorAttachmentType", DoctorAttachmentTypelst);
                        }
                        else
                        {
                            //return Content(HttpStatusCode.BadRequest, "Lookups not exists");
                            return Ok("Lookups not exists");
                        }
                        return Ok(ResultsLookup);
                    }
                    catch (Exception Exp)
                    {
                        vError = new ValidationError();
                        vError.name = HttpStatusCode.NotFound.ToString();
                        vError.description = "There is Problem With Look Ups" + Exp;
                        vErrors = new List<ValidationError>();
                        vErrors.Add(vError);

                        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);

                        return Content(HttpStatusCode.BadRequest, eResp);
                    }
                //}
                //Arabic Return
                //else
                //{
                //    try
                //    {
                //        DataTable dtDoctors = new DataTable();
                //        DataTable dtNonActiveDoctors = new DataTable();
                //        DataTable dtClinics = new DataTable();
                //        DataTable dtBranches = new DataTable();
                //        DataTable dtNationality = new DataTable();
                //        DataTable dtClinicCenterLogo = new DataTable();
                //        DataTable dtDrugUnit = new DataTable();
                //        DataTable dtDrugRoute = new DataTable();
                //        DataTable dtDrugInstruction = new DataTable();
                //        DataTable dtDoctorAttachmentType = new DataTable();

                //        dtDoctors = apiLookUp.GetDataDoctors();
                //        dtNonActiveDoctors = apiLookUp.GetDataNonActiveDoctors();
                //        dtClinics = apiLookUp.GetDataClinics();
                //        dtBranches = apiLookUp.GetDataBranches();
                //        dtNationality = apiLookUp.GetDataNationality();
                //        dtClinicCenterLogo = centerLogo.GetDataClinicCenterLogo();
                //        dtDrugUnit = DrugUnit.GetDataDrugUnit();
                //        dtDrugRoute = DrugRoute.GetDataDrugRoute();
                //        dtDrugInstruction = DrugInstruction.GetDataDrugInstruction();
                //        dtDoctorAttachmentType = DoctorAttachmentType.GetDataDoctorAttachmentTypes();

                //        List<ClsApiLookUp> DoctorLookUpS = new List<ClsApiLookUp>();
                //        List<ClsApiLookUp> NonActiveDoctorsLookUpS = new List<ClsApiLookUp>();
                //        Dictionary<string, object> ResultsLookup = new Dictionary<string, object>();
                //        if (dtDoctors != null && dtDoctors.Rows.Count > 0 && dtClinics != null && dtClinics.Rows.Count > 0 && dtBranches != null && dtBranches.Rows.Count > 0 && dtNationality != null && dtNationality.Rows.Count > 0 && dtNationality != null && dtNationality.Rows.Count > 0 && dtDoctorAttachmentType != null && dtDoctorAttachmentType.Rows.Count > 0)
                //        {
                //            //ActiveDoctor
                //            foreach (DataRow aRow in dtDoctors.Rows)
                //            {

                //                ClsApiLookUp Doctor = new ClsApiLookUp();
                //                Doctor.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                //                Doctor.Name = Convert.ToString(aRow["NameAr"]);
                //                Doctor.DoctorSpecialityID = Convert.ToString(aRow["DoctorSpecialityID"]);
                //                Doctor.Mobile = Convert.ToString(aRow["Mobile"]);

                //                if (int.TryParse(aRow["HomeTel"].ToString(), out int number))
                //                {
                //                    Doctor.HomeTel = number;
                //                }
                //                else
                //                {
                //                    Doctor.HomeTel = 0;
                //                }
                //                //Doctor.HomeTel = Convert.ToInt32(aRow["HomeTel"]);
                //                Doctor.PasspoerNo = Convert.ToString(aRow["PasspoerNo"]);
                //                Doctor.CardID = Convert.ToString(aRow["CardID"]);
                //                Doctor.CardExp = Convert.ToString(aRow["CardExp"]);

                //                if (int.TryParse(aRow["SexID"].ToString(), out int SexID))
                //                {

                //                    ClsSex sex = new ClsSex();
                //                    List<ClsSex> sexes = new List<ClsSex>();
                //                    sexes = sex.Read();
                //                    ClsSex Result = new ClsSex();
                //                    Result = sexes.FirstOrDefault(c => c.SexID == SexID);
                //                    Doctor.Sex = Result.SexAR;
                //                }
                //                else
                //                {
                //                    Doctor.Sex = "غير متوافر";
                //                }
                //                //Doctor.SexID = Convert.ToInt16(aRow["SexID"]);
                //                if (short.TryParse(aRow["DoctorCategoryID"].ToString(), out short DoctorCategoryID))
                //                {
                //                    Doctor.DoctorCategoryID = DoctorCategoryID;
                //                }
                //                else
                //                {
                //                    Doctor.DoctorCategoryID = 0;
                //                }
                //                //Doctor.DoctorCategoryID = Convert.ToInt16(aRow["DoctorCategoryID"]);

                //                if (short.TryParse(aRow["MaritalStatusID"].ToString(), out short MaritalStatusID))
                //                {
                //                    Doctor.MaritalStatusID = MaritalStatusID;
                //                }
                //                else
                //                {
                //                    Doctor.MaritalStatusID = 0;
                //                }
                //                //Doctor.MaritalStatusID = Convert.ToInt16(aRow["MaritalStatusID"]);
                //                Doctor.Email = Convert.ToString(aRow["Email"]);
                //                Doctor.LicenseNo = Convert.ToString(aRow["LicenseNo"]);
                //                if (int.TryParse(aRow["BranchID"].ToString(), out int BranchID))
                //                {
                //                    Doctor.BranchID = BranchID;
                //                }
                //                else
                //                {
                //                    Doctor.BranchID = 0;
                //                }
                //                //Doctor.BranchID = Convert.ToInt16(aRow["BranchID"]);
                //                if (int.TryParse(aRow["ClinicID"].ToString(), out int ClinicID))
                //                {
                //                    Doctor.ClinicID = ClinicID;
                //                }
                //                else
                //                {
                //                    Doctor.ClinicID = 0;
                //                }
                //                string LangKnownGet = aRow["LangKnown"].ToString();
                //                if (LangKnownGet != "")
                //                {

                //                    Doctor.LangKnown = aRow["LangKnown"].ToString().Split(',');
                //                }
                //                else
                //                {
                //                    string[] EmpArr = { "Empty" };
                //                    Doctor.LangKnown = EmpArr;
                //                }
                //                Doctor.Biograohy = Convert.ToString(aRow["BiograohyAr"]);
                //                Doctor.YearsExp = Convert.ToString(aRow["YearsExp"]);
                //                Doctor.ImgPath = Convert.ToString(aRow["ImgPath"]);
                //                Doctor.Stamp = (Byte[])aRow["Stamp"];
                //                Doctor.UserSign = (Byte[])aRow["UserSign"];
                //                DoctorLookUpS.Add(Doctor);
                //            }
                //            //NonActiveDoctor
                //            foreach (DataRow aRow in dtNonActiveDoctors.Rows)
                //            {

                //                ClsApiLookUp Doctor = new ClsApiLookUp();
                //                Doctor.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                //                Doctor.Name = Convert.ToString(aRow["NameAr"]);
                //                Doctor.DoctorSpecialityID = Convert.ToString(aRow["DoctorSpecialityID"]);
                //                Doctor.Mobile = Convert.ToString(aRow["Mobile"]);

                //                if (int.TryParse(aRow["HomeTel"].ToString(), out int number))
                //                {
                //                    Doctor.HomeTel = number;
                //                }
                //                else
                //                {
                //                    Doctor.HomeTel = 0;
                //                }
                //                //Doctor.HomeTel = Convert.ToInt32(aRow["HomeTel"]);
                //                Doctor.PasspoerNo = Convert.ToString(aRow["PasspoerNo"]);
                //                Doctor.CardID = Convert.ToString(aRow["CardID"]);
                //                Doctor.CardExp = Convert.ToString(aRow["CardExp"]);

                //                if (int.TryParse(aRow["SexID"].ToString(), out int SexID))
                //                {

                //                    ClsSex sex = new ClsSex();
                //                    List<ClsSex> sexes = new List<ClsSex>();
                //                    sexes = sex.Read();
                //                    ClsSex Result = new ClsSex();
                //                    Result = sexes.FirstOrDefault(c => c.SexID == SexID);
                //                    Doctor.Sex = Result.SexAR;
                //                }
                //                else
                //                {
                //                    Doctor.Sex = "غير متوافر";
                //                }
                //                //Doctor.SexID = Convert.ToInt16(aRow["SexID"]);
                //                if (short.TryParse(aRow["DoctorCategoryID"].ToString(), out short DoctorCategoryID))
                //                {
                //                    Doctor.DoctorCategoryID = DoctorCategoryID;
                //                }
                //                else
                //                {
                //                    Doctor.DoctorCategoryID = 0;
                //                }
                //                //Doctor.DoctorCategoryID = Convert.ToInt16(aRow["DoctorCategoryID"]);

                //                if (short.TryParse(aRow["MaritalStatusID"].ToString(), out short MaritalStatusID))
                //                {
                //                    Doctor.MaritalStatusID = MaritalStatusID;
                //                }
                //                else
                //                {
                //                    Doctor.MaritalStatusID = 0;
                //                }
                //                //Doctor.MaritalStatusID = Convert.ToInt16(aRow["MaritalStatusID"]);
                //                Doctor.Email = Convert.ToString(aRow["Email"]);
                //                Doctor.LicenseNo = Convert.ToString(aRow["LicenseNo"]);
                //                if (int.TryParse(aRow["BranchID"].ToString(), out int BranchID))
                //                {
                //                    Doctor.BranchID = BranchID;
                //                }
                //                else
                //                {
                //                    Doctor.BranchID = 0;
                //                }
                //                //Doctor.BranchID = Convert.ToInt16(aRow["BranchID"]);
                //                if (int.TryParse(aRow["ClinicID"].ToString(), out int ClinicID))
                //                {
                //                    Doctor.ClinicID = ClinicID;
                //                }
                //                else
                //                {
                //                    Doctor.ClinicID = 0;
                //                }
                //                string LangKnownGet = aRow["LangKnown"].ToString();
                //                if (LangKnownGet != "")
                //                {

                //                    Doctor.LangKnown = aRow["LangKnown"].ToString().Split(',');
                //                }
                //                else
                //                {
                //                    string[] EmpArr = { "Empty" };
                //                    Doctor.LangKnown = EmpArr;
                //                }
                //                Doctor.Biograohy = Convert.ToString(aRow["BiograohyAr"]);
                //                Doctor.YearsExp = Convert.ToString(aRow["YearsExp"]);
                //                Doctor.ImgPath = Convert.ToString(aRow["ImgPath"]);
                //                Doctor.TeleMedicine = Convert.ToBoolean(aRow["TeleMedicine"]);
                //                Doctor.Stamp = (Byte[])aRow["Stamp"];
                //                Doctor.UserSign = (Byte[])aRow["UserSign"];
                //                NonActiveDoctorsLookUpS.Add(Doctor);
                //            }
                //            //Clinics
                //            List<KeyValueTwoPair> kvPairsClinics = new List<KeyValueTwoPair>();
                //            foreach (DataRow aRow in dtClinics.Rows)
                //            {

                //                KeyValueTwoPair kvp = new KeyValueTwoPair();
                //                kvp.Id = Convert.ToInt32(aRow["CinicID"]);
                //                kvp.Name = Convert.ToString(aRow["ClinicAr"]);
                //                kvp.ImgPath = Convert.ToString(aRow["ImgPath"]);

                //                kvPairsClinics.Add(kvp);
                //            }
                //            //Branches
                //            List<KeyValuePair> kvPairsBranches = new List<KeyValuePair>();
                //            foreach (DataRow aRow in dtBranches.Rows)
                //            {

                //                KeyValuePair kvp = new KeyValuePair();
                //                kvp.Id = Convert.ToInt32(aRow["BranchID"]);
                //                kvp.Name = Convert.ToString(aRow["BranchAr"]);


                //                kvPairsBranches.Add(kvp);
                //            }
                //            //Nationality 
                //            List<KeyValuePair> kvPairsNationality = new List<KeyValuePair>();
                //            foreach (DataRow aRow in dtNationality.Rows)
                //            {

                //                KeyValuePair kvp = new KeyValuePair();
                //                kvp.Id = Convert.ToInt32(aRow["NationalityID"]);
                //                kvp.Name = Convert.ToString(aRow["NationalityAr"]);


                //                kvPairsNationality.Add(kvp);
                //            }
                //            //ClinicCenterLogo 
                //            List<ClsApiClinicCenterLogo> ClinicCenterLogos = new List<ClsApiClinicCenterLogo>();
                //            foreach (DataRow aRow in dtClinicCenterLogo.Rows)
                //            {

                //                ClsApiClinicCenterLogo ClinicCenterLogoObj = new ClsApiClinicCenterLogo();
                //                ClinicCenterLogoObj.ID = Convert.ToInt32(aRow["ID"]);
                //                ClinicCenterLogoObj.ClinicCenter = Convert.ToString(aRow["ClinicCenterArabic"]);
                //                ClinicCenterLogoObj.Header = (Byte[])aRow["Header"];
                //                ClinicCenterLogoObj.Logo = (Byte[])aRow["Logo"];
                //                ClinicCenterLogoObj.Footer = (Byte[])aRow["Footer"];
                //                ClinicCenterLogoObj.ProviderNo = Convert.ToString(aRow["ProviderNo"]);
                //                ClinicCenterLogoObj.Provider_Name = Convert.ToString(aRow["Provider Name"]);
                //                ClinicCenterLogoObj.HaadLicense = Convert.ToString(aRow["HaadLicense"]);
                //                ClinicCenterLogoObj.HaadUserName = Convert.ToString(aRow["HaadUserName"]);
                //                ClinicCenterLogoObj.HaadPassword = Convert.ToString(aRow["HaadPassword"]);
                //                ClinicCenterLogos.Add(ClinicCenterLogoObj);
                //            }
                //            //DrugUnit 
                //            List<KeykeyPair> DrugUnits = new List<KeykeyPair>();

                //            foreach (DataRow aRow in dtDrugUnit.Rows)
                //            {

                //                KeykeyPair DrugUnitObj = new KeykeyPair();
                //                DrugUnitObj.key = Convert.ToString(aRow["DrugUnit"]);
                //                DrugUnitObj.Name = Convert.ToString(aRow["DrugUnitAr"]);

                //                DrugUnits.Add(DrugUnitObj);
                //            }
                //            //DrugRoute 
                //            List<KeykeyPair> DrugRoutes = new List<KeykeyPair>();
                //            foreach (DataRow aRow in dtDrugRoute.Rows)
                //            {

                //                KeykeyPair DrugRouteObj = new KeykeyPair();
                //                //DrugRouteObj.DrugRouteID = Convert.ToInt32(aRow["DrugRouteID"]);
                //                DrugRouteObj.Name = Convert.ToString(aRow["DrugRouteDescAr"]);
                //                DrugRouteObj.key = Convert.ToString(aRow["DrugRoute"]);

                //                DrugRoutes.Add(DrugRouteObj);
                //            }
                //            //DrugInstruction 
                //            List<KeyValuePair> DrugInstructions = new List<KeyValuePair>();
                //            foreach (DataRow aRow in dtDrugInstruction.Rows)
                //            {

                //                KeyValuePair DrugInstructionObj = new KeyValuePair();
                //                DrugInstructionObj.Id = Convert.ToInt32(aRow["DrugInstructionID"]);
                //                DrugInstructionObj.Name = Convert.ToString(aRow["DrugInstructionAr"]);
                //                DrugInstructions.Add(DrugInstructionObj);
                //            }
                //            //DoctorAttachmentTypes 
                //            List<KeyValuePair> DoctorAttachmentTypelst = new List<KeyValuePair>();
                //            foreach (DataRow aRow in dtDoctorAttachmentType.Rows)
                //            {

                //                KeyValuePair DoctorAttachmentTypesObj = new KeyValuePair();
                //                DoctorAttachmentTypesObj.Id = Convert.ToInt32(aRow["DoctorAttachmentTypeID"]);
                //                DoctorAttachmentTypesObj.Name = Convert.ToString(aRow["DoctorAttachmentTypesAr"]);
                //                DoctorAttachmentTypelst.Add(DoctorAttachmentTypesObj);
                //            }

                //            ResultsLookup.Add("Doctors", DoctorLookUpS);
                //            ResultsLookup.Add("NonActiveDoctors", NonActiveDoctorsLookUpS);
                //            ResultsLookup.Add("Clinics", kvPairsClinics);
                //            ResultsLookup.Add("Branches", kvPairsBranches);
                //            ResultsLookup.Add("Nationality", kvPairsNationality);
                //            ResultsLookup.Add("ClinicCenterLogo", ClinicCenterLogos);
                //            ResultsLookup.Add("DrugUnit", DrugUnits);
                //            ResultsLookup.Add("DrugRoute", DrugRoutes);
                //            ResultsLookup.Add("DrugInstruction", DrugInstructions);
                //            ResultsLookup.Add("DoctorAttachmentType", DoctorAttachmentTypelst);
                //        }
                //        else
                //        {
                //            //return Content(HttpStatusCode.BadRequest, "Lookups not exists");
                //            return Ok("Lookups not exists");
                //        }
                //        return Ok(ResultsLookup);
                //    }
                //    catch (Exception Exp)
                //    {
                //        vError = new ValidationError();
                //        vError.name = HttpStatusCode.NotFound.ToString();
                //        vError.description = "Users not exists";
                //        vErrors = new List<ValidationError>();
                //        vErrors.Add(vError);
                //        eResp = PopulateErrorResponse(MethodBase.GetCurrentMethod().Name, HttpStatusCode.NotFound, vErrors);
                //        return Content(HttpStatusCode.BadRequest, eResp);
                //    }
                //}
            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Users not Authorize to Login");
            }
        }
        [HttpGet]
        [Route("~/api/ApiLookUpController/GetLookupCalender")]
        public IHttpActionResult GetLookupCalender([FromUri] int branchId)
        {
            ClsDoctors Doctors = new ClsDoctors();
            ClsClinics Clinics = new ClsClinics();
            ClsHowToKnow HowToKnows = new ClsHowToKnow();
            ClsRooms Rooms = new ClsRooms();
            ClsAppointmentReasons AppointmentReasons = new ClsAppointmentReasons();
            ClsVisitStatus VisitStatuses = new ClsVisitStatus();

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
                    DataTable dtDoctors = new DataTable();
                    DataTable dtClinics = new DataTable();
                    DataTable dtHowToKnow = new DataTable();
                    DataTable dtRooms = new DataTable();
                    DataTable dtAppointmentReasons = new DataTable();
                    DataTable dtVisitStatus = new DataTable();

                    Doctors.BranchID = branchId;
                       dtDoctors = Doctors.GetData();
                    dtClinics = Clinics.GetData();
                    dtHowToKnow = HowToKnows.GetData();
                    dtRooms = Rooms.GetData();
                    dtAppointmentReasons = AppointmentReasons.GetData();
                    dtVisitStatus = VisitStatuses.GetData();


                    List<ClsDoctors> DoctorsLst = new List<ClsDoctors>();
                    List<KeyValuePairEN> ClinicsLst = new List<KeyValuePairEN>();
                    List<KeyValuePairEN> HowToKnowLst = new List<KeyValuePairEN>();
                    List<ClsRooms> RoomsLst = new List<ClsRooms>();
                    List<ClsAppointmentReasons> AppointmentReasonsLst = new List<ClsAppointmentReasons>();
                    List<ClsVisitStatus> VisitStatusLst = new List<ClsVisitStatus>();


                    Dictionary<string, object> CalenderLookup = new Dictionary<string, object>();
                    if (dtDoctors != null && dtDoctors.Rows.Count > 0 && dtClinics != null && dtClinics.Rows.Count > 0    && dtHowToKnow != null && dtHowToKnow.Rows.Count > 0 && dtRooms != null && dtRooms.Rows.Count > 0 && dtAppointmentReasons != null && dtAppointmentReasons.Rows.Count > 0)
                    {
                        //Doctors
                        foreach (DataRow aRow in dtDoctors.Rows)
                        {

                            ClsDoctors Doctor = new ClsDoctors();
                            Doctor.DoctorID = Convert.ToInt32(aRow["DoctorID"]);
                            Doctor.Name = Convert.ToString(aRow["Name"]);
                            Doctor.DoctorSpecialityID = (aRow["DoctorSpecialityID"]) as int?;
                            Doctor.Mobile = Convert.ToString(aRow["Mobile"]);
                            Doctor.HomeTel = Convert.ToString(aRow["HomeTel"]);                           
                            Doctor.PasspoerNo = Convert.ToString(aRow["PasspoerNo"]);
                            Doctor.CardID = Convert.ToString(aRow["CardID"]);
                            Doctor.CardExp = (aRow["DoctorSpecialityID"]) as DateTime?;
                            Doctor.SexID = (aRow["SexID"]) as Int16?;
                            Doctor.DoctorCategoryID = (aRow["DoctorCategoryID"]) as Int16?;
                            Doctor.MaritalStatusID = (aRow["MaritalStatusID"]) as Int16?;
                            Doctor.Email = Convert.ToString(aRow["Email"]);
                            Doctor.LastUpdated = (aRow["LastUpdated"]) as DateTime?;
                            Doctor.UpdatedBy = (aRow["UpdatedBy"]) as int?;
                            Doctor.ClinicID = (aRow["ClinicID"]) as int?;
                            Doctor.LicenseNo = Convert.ToString(aRow["LicenseNo"]);
                            Doctor.BranchID = (aRow["BranchID"]) as int?;
                            DoctorsLst.Add(Doctor);
                        }

                        //Clinics
                        foreach (DataRow aRow in dtClinics.Rows)
                        {

                            //ClsClinics Clinic = new ClsClinics();
                            KeyValuePairEN Clinic = new KeyValuePairEN();
                            Clinic.Id = Convert.ToInt32(aRow["CinicID"]);
                            Clinic.Name = Convert.ToString(aRow["Clinic"]);



                            ClinicsLst.Add(Clinic);
                        }

                        //HowToKnow
                        foreach (DataRow aRow in dtHowToKnow.Rows)
                        {

                            KeyValuePairEN HowToKnow = new KeyValuePairEN();
                            HowToKnow.Id = Convert.ToInt16(aRow["HowToKnowID"]);
                            HowToKnow.Name = Convert.ToString(aRow["HowToKnow"]);



                            HowToKnowLst.Add(HowToKnow);
                        }

                        //Rooms
                        foreach (DataRow aRow in dtRooms.Rows)
                        {

                            ClsRooms Room = new ClsRooms();
                            Room.RoomID = Convert.ToInt16(aRow["RoomID"]);
                            Room.Room = Convert.ToString(aRow["Room"]);
                            Room.ClinicID = (aRow["ClinicID"]) as int?;
                            Room.DoctorID = (aRow["DoctorID"]) as int?;
                            RoomsLst.Add(Room);
                        }
                        //AppointmentReason
                        foreach (DataRow aRow in dtAppointmentReasons.Rows)
                        {

                            ClsAppointmentReasons AppointmentReason = new ClsAppointmentReasons();
                            AppointmentReason.AppointmentReasonsID = Convert.ToInt32(aRow["AppointmentReasonsID"]);
                            AppointmentReason.AppointmentReasons = Convert.ToString(aRow["AppointmentReasons"]);
                            AppointmentReason.ClinicID =  (aRow["ClinicID"]) as int?;
                            AppointmentReason.Color =  (aRow["Color"]) as Int16?;
                            AppointmentReason.Interval =  (aRow["Interval"]) as Int16?;
                            AppointmentReasonsLst.Add(AppointmentReason);
                        }

                        //VisitStatus
                        foreach (DataRow aRow in dtVisitStatus.Rows)
                        {

                            ClsVisitStatus VisitStatus = new ClsVisitStatus();
                            VisitStatus.VisitStatusID = Convert.ToInt16(aRow["VisitStatusID"]);
                            VisitStatus.VisitStatus = Convert.ToString(aRow["VisitStatus"]);
                            VisitStatus.VisitStatusColor = Convert.ToString(aRow["VisitStatusColor"]);
                            VisitStatus.ColorHexa = Convert.ToString(aRow["ColorHexa"]);
                            VisitStatus.StatusTypeID = Convert.ToInt16(aRow["StatusTypeID"]);
                            VisitStatusLst.Add(VisitStatus);
                        }

                        CalenderLookup.Add("Doctors", DoctorsLst);
                        CalenderLookup.Add("Clinics", ClinicsLst);
                        CalenderLookup.Add("HowToKnows", HowToKnowLst);
                        CalenderLookup.Add("Rooms", RoomsLst);
                        CalenderLookup.Add("AppointmentReasons", AppointmentReasonsLst);
                        CalenderLookup.Add("VisitStatuses", VisitStatusLst);
                        CalenderLookup.Add("CalenderSetting", new ClsApiSetting());
                    }
                    else
                    {
                        //return Content(HttpStatusCode.BadRequest, "Lookups not exists");
                        return Ok("Calender Lookup not exists");
                    }
                    return Ok(CalenderLookup);
                }
                catch (Exception Exp)
                {
                    vError = new ValidationError();
                    vError.name = HttpStatusCode.NotFound.ToString();
                    vError.description = "There is Problem With Look Ups" + Exp;
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
