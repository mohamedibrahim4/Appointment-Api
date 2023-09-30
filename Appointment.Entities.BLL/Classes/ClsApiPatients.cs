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
   public class ClsApiPatients
    {
        string SQLStr = "";
        [Required]
        public int PatientID { get; set; }
        public string Code { get; set; }
        public String Name { get; set; }
        public String Mobile { get; set; }
        public String HomeTel { get; set; }
        public String InsuranceCardID { get; set; }
        public String InsuranceCardExp { get; set; }
        public int? InsuranceCompany { get; set; }
        public string InsuranceCompanyName { get; set; }
        public int? NetworkID { get; set; }
        public int? FeeSubCategoryID { get; set; }
        public string FeeSubCategory { get; set; }
        public int SexID { get; set; }
        public String Sex { get; set; }
        public String DateofBirth { get; set; }
        public int MaritalStatusID { get; set; }
        public Double Weight { get; set; }
        public string RegDate { get; set; }
        public int UpdatedBy { get; set; }
        public int? BloodGroupID { get; set; }
        public string Mobile2 { get; set; }
        public string Mobile3 { get; set; }
        public string Company { get; set; }
        public Int16 NationalityID { get; set; }
        public string EmiratesID { get; set; }
        public string ArabicName { get; set; }
        public string CardImg { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FriendName { get; set; }
        public string FriendTel { get; set; }
        public string Relations { get; set; }
        public Int16 FriendGendar { get; set; }
        public Int16 PC { get; set; }
        public Int16 GP { get; set; }
        public Int16 Ded { get; set; }
        public Int16 DN { get; set; }
        public Int16 PH { get; set; }
        public Int16 MAXCash { get; set; }
        public string Product { get; set; }
        public Int16 CoPay { get; set; }
        public string FamilyHistory { get; set; }
        public Int16 PatientTypeID { get; set; }
        public Int16 InsuranceCompany2 { get; set; }
        public int? NetworkID2 { get; set; }
        public Int16 FeeSubCategoryID2 { get; set; }
        public string Product2 { get; set; }
        public string InsuranceCardID2 { get; set; }
        public string InsuranceCardExp2 { get; set; }
        public Int16 PC2 { get; set; }
        public Int16 GP2 { get; set; }
        public Int16 Ded2 { get; set; }
        public Int16 DN2 { get; set; }
        public Int16 PH2 { get; set; }
        public Int16 MAXCash2 { get; set; }
        public Int16 CoPay2 { get; set; }
        public string CardImg2 { get; set; }
        public Int16 CoPayCash { get; set; }
        public Int16 DNCash { get; set; }
        public Int16 MaxCoPay { get; set; }
        public Int16 CoPayCash2 { get; set; }
        public Int16 DNCash2 { get; set; }
        public Int16 MaxCoPay2 { get; set; }
        public string Notes { get; set; }
        public Int16 GPPer { get; set; }
        public Int16 GPPer2 { get; set; }
        public Int16 GPMax { get; set; }
        public Int16 GPMax2 { get; set; }
        public Int16 Lab { get; set; }
        public Int16 LabCash { get; set; }
        public Int16 Lab2 { get; set; }
        public Int16 LabCash2 { get; set; }
        public Int16 Xray { get; set; }
        public Int16 XrayCash { get; set; }
        public Int16 Xray2 { get; set; }
        public Int16 XrayCash2 { get; set; }
        public Int16 PhCash { get; set; }
        public Int16 PhCash2 { get; set; }
        public Int16 NonArabic { get; set; }
        public string CardImgBack { get; set; }
        public string CardImgBack2 { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string POBox { get; set; }
        public string City { get; set; }
        public string Emirates { get; set; }
        public string Area { get; set; }
        public string FirstName { get; set; }
        public string ID { get; set; }
        public Int16 IDTypeID { get; set; }
        public Int16 PHMax { get; set; }
        public Int16 PHMax2 { get; set; }
        public Int16 DNPC { get; set; }
        public Int16 DNPC2 { get; set; }
        public string EmiratesIdImg { get; set; }
        public string OldFileNo { get; set; }
        public int FeeCategoryPlanID { get; set; }
        public int HowToKnow { get; set; }
        public string HowToKnowDetail { get; set; }
        public Int16 MakatingUserID { get; set; }
        public string TitleCode { get; set; }
        public string ReligionCode { get; set; }
        public string LanguageCode { get; set; }
        public string KinContactRoleCode { get; set; }
        public string KinCountryCode { get; set; }
        public string KinContactCode { get; set; }
        public string EmailTypeCode { get; set; }
        public string KinPhoneType { get; set; }
        public int EmirateID { get; set; }
        public string KinFirstName { get; set; }
        public string KinMiddleName { get; set; }
        public string KinLastName { get; set; }
        public string KinTitleCode { get; set; }
        public string RelationshipCode { get; set; }
        public string MobileAreaCode { get; set; }
        public string MobileCountryCode { get; set; }
        public bool MalaffiSent { get; set; }
        public string imgPhotography { get; set; }
        public string SQLInsertSp()
        {
            try
            {
                SQLStr = " insert into Patients ( ";
                SQLStr += "PatientID ";
                //SQLStr +=" , Code ";
                SQLStr += " , Name ";
                SQLStr += " , Mobile ";
                SQLStr += " , HomeTel ";
                SQLStr += " , InsuranceCardID ";
                SQLStr += " , InsuranceCardExp ";
                SQLStr += " , InsuranceCompany ";
                SQLStr += " , NetworkID ";
                SQLStr += " , FeeSubCategoryID ";
                SQLStr += " , SexID ";
                SQLStr += " , DateofBirth ";
                SQLStr += " , MaritalStatusID ";
                //SQLStr +=" , Weight ";
                //SQLStr +=" , RegDate ";
                SQLStr += " , UpdatedBy ";
                SQLStr += " , BloodGroupID ";
                //SQLStr +=" , LastUpdated ";
                SQLStr += " , Mobile2 ";
                SQLStr += " , Mobile3 ";
                SQLStr += " , Company ";
                SQLStr += " , NationalityID ";
                SQLStr += " , EmiratesID ";
                SQLStr += " , ArabicName ";
                //SQLStr +=" , CardImg ";
                SQLStr += " , Job ";
                SQLStr += " , Address ";
                SQLStr += " , Email ";
                SQLStr += " , FriendName ";
                SQLStr += " , FriendTel ";
                SQLStr += " , Relations ";
                SQLStr += " , FriendGendar ";
                SQLStr += " , PC ";
                SQLStr += " , GP ";
                SQLStr += " , Ded ";
                SQLStr += " , DN ";
                SQLStr += " , PH ";
                SQLStr += " , MAXCash ";
                SQLStr += " , Product ";
                SQLStr += " , CoPay ";
                //SQLStr +=" , FamilyHistory ";
                SQLStr += " , PatientTypeID ";
                SQLStr += " , InsuranceCompany2 ";
                SQLStr += " , NetworkID2 ";
                SQLStr += " , FeeSubCategoryID2 ";
                SQLStr += " , Product2 ";
                SQLStr += " , InsuranceCardID2 ";
                SQLStr += " , InsuranceCardExp2 ";
                SQLStr += " , PC2 ";
                SQLStr += " , GP2 ";
                SQLStr += " , Ded2 ";
                SQLStr += " , DN2 ";
                SQLStr += " , PH2 ";
                SQLStr += " , MAXCash2 ";
                SQLStr += " , CoPay2 ";
                //SQLStr +=" , CardImg2 ";
                SQLStr += " , CoPayCash ";
                SQLStr += " , DNCash ";
                SQLStr += " , MaxCoPay ";
                SQLStr += " , CoPayCash2 ";
                SQLStr += " , DNCash2 ";
                SQLStr += " , MaxCoPay2 ";
                SQLStr += " , Notes ";
                SQLStr += " , GPPer ";
                SQLStr += " , GPPer2 ";
                SQLStr += " , GPMax ";
                SQLStr += " , GPMax2 ";
                SQLStr += " , Lab ";
                SQLStr += " , LabCash ";
                SQLStr += " , Lab2 ";
                SQLStr += " , LabCash2 ";
                SQLStr += " , Xray ";
                SQLStr += " , XrayCash ";
                SQLStr += " , Xray2 ";
                SQLStr += " , XrayCash2 ";
                SQLStr += " , PhCash ";
                SQLStr += " , PhCash2 ";
                SQLStr += " , NonArabic ";
                //SQLStr +=" , CardImgBack ";
                //SQLStr +=" , CardImgBack2 ";
                SQLStr += " , SecondName ";
                SQLStr += " , ThirdName ";
                SQLStr += " , POBox ";
                SQLStr += " , City ";
                SQLStr += " , Emirates ";
                SQLStr += " , Area ";
                SQLStr += " , FirstName ";
                SQLStr += " , ID ";
                SQLStr += " , IDTypeID ";
                SQLStr += " , PHMax ";
                SQLStr += " , PHMax2 ";
                SQLStr += " , DNPC ";
                SQLStr += " , DNPC2 ";
                SQLStr += " , OldFileNo ";
                SQLStr += " , FeeCategoryPlanID ";
                SQLStr += " , FeeCategoryPlanID2 ";
                SQLStr += " , HowToKnow ";
                SQLStr += " , HowToKnowDetail ";
                SQLStr += " , MakatingUserID ";
                SQLStr += " , TitleCode ";
                SQLStr += " , ReligionCode ";
                SQLStr += " , LanguageCode ";
                SQLStr += " , KinContactRoleCode ";
                SQLStr += " , KinCountryCode ";
                SQLStr += " , KinContactCode ";
                SQLStr += " , EmailTypeCode ";
                SQLStr += " , KinPhoneType ";
                SQLStr += " , EmirateID ";
                SQLStr += " , KinFirstName ";
                SQLStr += " , KinMiddleName ";
                SQLStr += " , KinLastName ";
                SQLStr += " , KinTitleCode ";
                SQLStr += " , RelationshipCode ";
                SQLStr += " , MobileAreaCode  ";
                SQLStr += " , MobileCountryCode";

                SQLStr += " ) values ( ";
                SQLStr += " @PatientID";
                //SQLStr += " , @Code";
                SQLStr += " , @Name";
                SQLStr += " , @Mobile";
                SQLStr += " , @HomeTel";
                SQLStr += " , @InsuranceCardID";
                SQLStr += " , @InsuranceCardExp";
                SQLStr += " , @InsuranceCompany";
                SQLStr += " , @NetworkID ";
                SQLStr += " , @FeeSubCategoryID";
                SQLStr += " , @SexID";
                SQLStr += " , @DateofBirth";
                SQLStr += " , @MaritalStatusID";
                //SQLStr += " , @Weight";
                //SQLStr += " , @RegDate";
                SQLStr += " , @UpdatedBy";
                SQLStr += " , @BloodGroupID";
                //SQLStr += " , @LastUpdated";
                SQLStr += " , @Mobile2";
                SQLStr += " , @Mobile3";
                SQLStr += " , @Company";
                SQLStr += " , @NationalityID";
                SQLStr += " , @EmiratesID";
                SQLStr += " , @ArabicName";
                //SQLStr += " , @CardImg";
                SQLStr += " , @Job";
                SQLStr += " , @Address";
                SQLStr += " , @Email";
                SQLStr += " , @FriendName";
                SQLStr += " , @FriendTel";
                SQLStr += " , @Relations";
                SQLStr += " , @FriendGendar";
                SQLStr += " , @PC";
                SQLStr += " , @GP";
                SQLStr += " , @Ded";
                SQLStr += " , @DN";
                SQLStr += " , @PH";
                SQLStr += " , @MAXCash";
                SQLStr += " , @Product";
                SQLStr += " , @CoPay";
                //SQLStr += " , @FamilyHistory";
                SQLStr += " , @PatientTypeID";
                SQLStr += " , @InsuranceCompany2";
                SQLStr += " , @NetworkID2 ";
                SQLStr += " , @FeeSubCategoryID2";
                SQLStr += " , @Product2";
                SQLStr += " , @InsuranceCardID2";
                SQLStr += " , @InsuranceCardExp2";
                SQLStr += " , @PC2";
                SQLStr += " , @GP2";
                SQLStr += " , @Ded2";
                SQLStr += " , @DN2";
                SQLStr += " , @PH2";
                SQLStr += " , @MAXCash2";
                SQLStr += " , @CoPay2";
                //SQLStr += " , @CardImg2";
                SQLStr += " , @CoPayCash";
                SQLStr += " , @DNCash";
                SQLStr += " , @MaxCoPay";
                SQLStr += " , @CoPayCash2";
                SQLStr += " , @DNCash2";
                SQLStr += " , @MaxCoPay2";
                SQLStr += " , @Notes";
                SQLStr += " , @GPPer";
                SQLStr += " , @GPPer2";
                SQLStr += " , @GPMax";
                SQLStr += " , @GPMax2";
                SQLStr += " , @Lab";
                SQLStr += " , @LabCash";
                SQLStr += " , @Lab2";
                SQLStr += " , @LabCash2";
                SQLStr += " , @Xray";
                SQLStr += " , @XrayCash";
                SQLStr += " , @Xray2";
                SQLStr += " , @XrayCash2";
                SQLStr += " , @PhCash";
                SQLStr += " , @PhCash2";
                SQLStr += " , @NonArabic";
                //SQLStr += " , @CardImgBack";
                //SQLStr += " , @CardImgBack2";
                SQLStr += " , @SecondName";
                SQLStr += " , @ThirdName";
                SQLStr += " , @POBox";
                SQLStr += " , @City";
                SQLStr += " , @Emirates";
                SQLStr += " , @Area";
                SQLStr += " , @FirstName";
                SQLStr += " , @ID";
                SQLStr += " , @IDTypeID";
                SQLStr += " , @PHMax";
                SQLStr += " , @PHMax2";
                SQLStr += " , @DNPC";
                SQLStr += " , @DNPC2";
                SQLStr += " , @OldFileNo ";
                SQLStr += " , @FeeCategoryPlanID ";
                SQLStr += " , @FeeCategoryPlanID2 ";
                SQLStr += " , @HowToKnow ";
                SQLStr += " , @HowToKnowDetail ";
                SQLStr += " , @MakatingUserID ";
                SQLStr += " , @TitleCode ";
                SQLStr += " , @ReligionCode ";
                SQLStr += " , @LanguageCode ";
                SQLStr += " , @KinContactRoleCode ";
                SQLStr += " , @KinCountryCode ";
                SQLStr += " , @KinContactCode ";
                SQLStr += " , @EmailTypeCode ";
                SQLStr += " , @KinPhoneType ";
                SQLStr += " , @EmirateID ";
                SQLStr += " , @KinFirstName ";
                SQLStr += " , @KinMiddleName ";
                SQLStr += " , @KinLastName ";
                SQLStr += " , @KinTitleCode ";
                SQLStr += " , @RelationshipCode ";
                SQLStr += " , @MobileAreaCode  ";
                SQLStr += " , @MobileCountryCode";

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
                SQLStr = " Update Patients set ";
                //SQLStr += " Code = @Code";
                SQLStr += "  Name = @Name";
                SQLStr += " , Mobile = @Mobile";
                SQLStr += " , HomeTel = @HomeTel";
                SQLStr += " , InsuranceCardID = @InsuranceCardID";
                SQLStr += " , InsuranceCardExp = @InsuranceCardExp";
                SQLStr += " , InsuranceCompany = @InsuranceCompany";
                SQLStr += " , NetworkID = @NetworkID ";
                SQLStr += " , FeeSubCategoryID = @FeeSubCategoryID";
                SQLStr += " , SexID = @SexID";
                SQLStr += " , DateofBirth = @DateofBirth";
                SQLStr += " , MaritalStatusID = @MaritalStatusID";
                //SQLStr +=" , Weight = @Weight";
                //SQLStr +=" , RegDate = @RegDate";
                SQLStr += " , UpdatedBy = @UpdatedBy";
                SQLStr += " , BloodGroupID = @BloodGroupID";
                SQLStr += " , LastUpdated = @LastUpdated";
                SQLStr += " , Mobile2 = @Mobile2";
                SQLStr += " , Mobile3 = @Mobile3";
                SQLStr += " , Company = @Company";
                SQLStr += " , NationalityID = @NationalityID";
                SQLStr += " , EmiratesID = @EmiratesID";
                SQLStr += " , ArabicName = @ArabicName";
                //SQLStr +=" , CardImg = @CardImg";
                SQLStr += " , Job = @Job";
                SQLStr += " , Address = @Address";
                SQLStr += " , Email = @Email";
                SQLStr += " , FriendName = @FriendName";
                SQLStr += " , FriendTel = @FriendTel";
                SQLStr += " , Relations = @Relations";
                SQLStr += " , FriendGendar = @FriendGendar";
                SQLStr += " , PC = @PC";
                SQLStr += " , GP = @GP";
                SQLStr += " , Ded = @Ded";
                SQLStr += " , DN = @DN";
                SQLStr += " , PH = @PH";
                SQLStr += " , MAXCash = @MAXCash";
                SQLStr += " , Product = @Product";
                SQLStr += " , CoPay = @CoPay";
                //SQLStr +=" , FamilyHistory = @FamilyHistory";
                SQLStr += " , PatientTypeID = @PatientTypeID";
                SQLStr += " , InsuranceCompany2 = @InsuranceCompany2";
                SQLStr += " , NetworkID2 = @NetworkID2 ";
                SQLStr += " , FeeSubCategoryID2 = @FeeSubCategoryID2";
                SQLStr += " , Product2 = @Product2";
                SQLStr += " , InsuranceCardID2 = @InsuranceCardID2";
                SQLStr += " , InsuranceCardExp2 = @InsuranceCardExp2";
                SQLStr += " , PC2 = @PC2";
                SQLStr += " , GP2 = @GP2";
                SQLStr += " , Ded2 = @Ded2";
                SQLStr += " , DN2 = @DN2";
                SQLStr += " , PH2 = @PH2";
                SQLStr += " , MAXCash2 = @MAXCash2";
                SQLStr += " , CoPay2 = @CoPay2";
                //SQLStr +=" , CardImg2 = @CardImg2";
                SQLStr += " , CoPayCash = @CoPayCash";
                SQLStr += " , DNCash = @DNCash";
                SQLStr += " , MaxCoPay = @MaxCoPay";
                SQLStr += " , CoPayCash2 = @CoPayCash2";
                SQLStr += " , DNCash2 = @DNCash2";
                SQLStr += " , MaxCoPay2 = @MaxCoPay2";
                SQLStr += " , Notes = @Notes";
                SQLStr += " , GPPer = @GPPer";
                SQLStr += " , GPPer2 = @GPPer2";
                SQLStr += " , GPMax = @GPMax";
                SQLStr += " , GPMax2 = @GPMax2";
                SQLStr += " , Lab = @Lab";
                SQLStr += " , LabCash = @LabCash";
                SQLStr += " , Lab2 = @Lab2";
                SQLStr += " , LabCash2 = @LabCash2";
                SQLStr += " , Xray = @Xray";
                SQLStr += " , XrayCash = @XrayCash";
                SQLStr += " , Xray2 = @Xray2";
                SQLStr += " , XrayCash2 = @XrayCash2";
                SQLStr += " , PhCash = @PhCash";
                SQLStr += " , PhCash2 = @PhCash2";
                SQLStr += " , NonArabic = @NonArabic";
                //SQLStr +=" , CardImgBack = @CardImgBack";
                //SQLStr +=" , CardImgBack2 = @CardImgBack2";
                SQLStr += " , SecondName = @SecondName";
                SQLStr += " , ThirdName = @ThirdName";
                SQLStr += " , POBox = @POBox";
                SQLStr += " , City = @City";
                SQLStr += " , Emirates = @Emirates";
                SQLStr += " , Area = @Area";
                SQLStr += " , FirstName = @FirstName";
                SQLStr += " , ID = @ID";
                SQLStr += " , IDTypeID = @IDTypeID";
                SQLStr += " , PHMax = @PHMax";
                SQLStr += " , PHMax2 = @PHMax2";
                SQLStr += " , DNPC = @DNPC";
                SQLStr += " , DNPC2 = @DNPC2";
                SQLStr += " , OldFileNo = @OldFileNo ";
                SQLStr += " , FeeCategoryPlanID =  @FeeCategoryPlanID ";
                SQLStr += " , FeeCategoryPlanID2 = @FeeCategoryPlanID2 ";
                SQLStr += " , HowToKnow = @HowToKnow ";
                SQLStr += " , HowToKnowDetail = @HowToKnowDetail ";
                SQLStr += " , MakatingUserID = @MakatingUserID ";
                SQLStr += " , TitleCode = @TitleCode ";
                SQLStr += " , ReligionCode = @ReligionCode ";
                SQLStr += " , LanguageCode = @LanguageCode ";
                SQLStr += " , KinContactRoleCode = @KinContactRoleCode ";
                SQLStr += " , KinCountryCode = @KinCountryCode ";
                SQLStr += " , KinContactCode = @KinContactCode ";
                SQLStr += " , EmailTypeCode = @EmailTypeCode ";
                SQLStr += " , KinPhoneType = @KinPhoneType ";
                SQLStr += " , EmirateID = @EmirateID ";
                SQLStr += " ,KinFirstName = @KinFirstName ";
                SQLStr += " ,KinMiddleName  = @KinMiddleName";
                SQLStr += " ,KinLastName = @KinLastName ";
                SQLStr += " , KinTitleCode = @KinTitleCode ";
                SQLStr += " , RelationshipCode = @RelationshipCode ";
                SQLStr += " , MobileAreaCode = @MobileAreaCode  ";
                SQLStr += " , MobileCountryCode = @MobileCountryCode";
                SQLStr += " Where PatientID = @PatientID";
                return SQLStr;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean SQLUpdateCardImg(string FieldName, string FileName)
        {
            try
            {
                SQLStr = " Update Patients set ";
                SQLStr += FieldName + " = '" + FileName + "' ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool DeleteData()
        {
            try
            {
                SQLStr = " Delete From  Patients ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetData()
        {
            try
            {
                SQLStr = " Select * From  Patients ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string GetOldFile()
        {
            try
            {
                SQLStr = " Select CoalESCE(OldFileNo,'-') From  Patients ";
                SQLStr += " WHERE PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetPatientMobileLst()
        {
            try
            {
                SQLStr = " Select Distinct Mobile From  Patients ";
                SQLStr += " WHERE Mobile is Not Null ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterPatient()
        {
            try
            {
                //SQLStr = " Select * From  Patients ";
                SQLStr = "SELECT     dbo.FeeCategory.Category, dbo.FeeSubCategory.FeeSubCategory, FeeCategory_1.Category AS Category2, ";
                SQLStr += "  FeeSubCategory_1.FeeSubCategory AS FeeSubCategory2, dbo.Patients.PatientID,dbo.Patients.Code, dbo.Patients.Name, (coalesce(MobileAreaCode,'')+ Mobile) as Mobile, dbo.Patients.HomeTel, ";
                SQLStr += "   dbo.Patients.Mobile2, dbo.Patients.Mobile3, dbo.Patients.Product, dbo.Patients.InsuranceCardID, dbo.Patients.Product2, dbo.Patients.InsuranceCardID2, ";
                SQLStr += "   dbo.Patients.InsuranceCardExp2, dbo.Patients.InsuranceCardExp, dbo.Patients.InsuranceCompany, dbo.Patients.PH, dbo.Patients.PhCash, ";
                SQLStr += " dbo.Patients.InsuranceCompany2, dbo.Patients.FeeSubCategoryID,dbo.patients.EmiratesID, dbo.Patients.FeeSubCategoryID2, dbo.Patients.PH2, dbo.Patients.PhCash2 , dbo.Patients.OldFileNo , dbo.Patients.Notes ";

                SQLStr += " , VPatientAdvancePayment.AdvancePayment , VPatientBalance.Balance ";
                //--Created By Eng/ Mohamed Ibrahim Abdelkader
                SQLStr += " ,dbo.patients.NonArabic ";
                SQLStr += " FROM         dbo.FeeSubCategory RIGHT OUTER JOIN ";
                SQLStr += "           dbo.FeeSubCategory AS FeeSubCategory_1 RIGHT OUTER JOIN ";
                SQLStr += " dbo.Patients LEFT OUTER JOIN ";
                SQLStr += " dbo.Nationality ON dbo.Patients.NationalityID = dbo.Nationality.NationalityID LEFT OUTER JOIN ";
                SQLStr += " dbo.FeeCategory AS FeeCategory_1 ON dbo.Patients.InsuranceCompany2 = FeeCategory_1.CategoryID ON  ";
                SQLStr += " FeeSubCategory_1.FeeSubCategoryID = dbo.Patients.FeeSubCategoryID2 ON ";
                SQLStr += " dbo.FeeSubCategory.FeeSubCategoryID = dbo.Patients.FeeSubCategoryID LEFT OUTER JOIN ";
                SQLStr += " dbo.FeeCategory ON dbo.Patients.InsuranceCompany = dbo.FeeCategory.CategoryID ";
                SQLStr += " LEFT Outer Join VPatientAdvancePayment On dbo.Patients.PatientID =  VPatientAdvancePayment.PatientID ";
                SQLStr += " LEFT Outer Join VPatientBalance On dbo.Patients.PatientID =  VPatientBalance.PatientID ";

                SQLStr += " WHERE 1 = 1 ";
                if (Name != "")
                {
                    Name = "%" + Name + "%";
                    SQLStr += " AND dbo.Patients.Name like '" + Name.ToString() + "'";
                    //SQLStr = Name.ToString();
                }
                else
                {
                    // SQLStr = "'%'";
                }
                if (OldFileNo != "")
                {
                    OldFileNo = "%" + OldFileNo + "%";
                    SQLStr += " AND OldFileNo like '" + OldFileNo.ToString() + "'";
                }
                if (Code != "")
                {
                    SQLStr += " AND dbo.Patients.Code like '" + Code.ToString() + "'";
                }
                if (PatientID != 0)
                {
                    SQLStr += " AND dbo.Patients.PatientID = " + PatientID.ToString();
                }



                if (InsuranceCompany != 0)
                {
                    SQLStr += " AND ( InsuranceCompany = " + InsuranceCompany.ToString();
                    SQLStr += " OR InsuranceCompany2 = " + InsuranceCompany2.ToString() + ")";
                }
                if (InsuranceCardID != "")
                {
                    InsuranceCardID = '%' + InsuranceCardID + '%';
                    SQLStr += "AND ( InsuranceCardID like '" + InsuranceCardID.ToString() + "'";
                    SQLStr += " Or InsuranceCardID2 like '" + InsuranceCardID.ToString() + "' ) ";
                }
                if (EmiratesID != "")
                {
                    //InsuranceCardID = '%' + EmiratesID + '%';
                    //SQLStr += " AND dbo.Patients.EmiratesID = " + EmiratesID.ToString();
                    SQLStr += " AND dbo.Patients.EmiratesID =" + "'" + EmiratesID.ToString() + "'";

                }
                if (Mobile != "")
                {
                    Mobile = '%' + Mobile + '%';
                    SQLStr += " AND ( MobileAreaCode + Mobile like '" + Mobile.ToString() + "'";
                    SQLStr += " Or Mobile2 like '" + Mobile.ToString() + "'";
                    SQLStr += " Or Mobile3 like '" + Mobile.ToString() + "' ) ";

                }
                else
                {
                    //SQLStr += " AND  Mobile like '%'";
                }

                if (FirstName != "")
                {
                    SQLStr += " AND FirstName Like '" + FirstName.ToString() + "'";
                }
                if (ThirdName != "")
                {
                    SQLStr += " AND ThirdName Like '" + ThirdName.ToString() + "'";
                }
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];
                /*
                SqlParameter[] SQLPrameters = new SqlParameter[1];
                SqlParameter SQLPrameter = null;

                try
                {


                    SQLPrameter = new SqlParameter("@FilterPar", SQLStr);
                    SQLPrameters[0] = SQLPrameter;
                    return GeneralFunctionsDAC.DDLSPStatmentWithPar("SP_Patients_Filter", "FoundPatient", SQLPrameters).Tables["FoundPatient"];

                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    SQLPrameters = null;
                    SQLPrameter = null;
                }*/
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable FilterPatientFromCalendar()
        {
            try
            {
                //SQLStr = " Select * From  Patients ";
                //SQLStr = "SELECT  PatientID, '0' AS Code, Patient as Name, MobileNo,  AS Mobile from DoctorCalender ";
                //mb
                SQLStr = "SELECT  PatientID, '0' AS Code, Patient as Name, MobileNo  AS Mobile from DoctorCalender ";

                SQLStr += " WHERE PatientID = 0 ";
                if (Name != "")
                {
                    Name = "%" + Name + "%";
                    SQLStr += " AND Patient like '" + Name.ToString() + "'";

                }
                else
                {
                    // SQLStr = "'%'";
                }





                if (Mobile != "")
                {
                    Mobile = '%' + Mobile + '%';
                    SQLStr += " AND ( MobileNo like '" + Mobile.ToString() + "' ) ";

                }

                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];

            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlDataReader FindData()
        {
            try
            {
                SQLStr = " Select * From  Patients ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                //return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];
                return GeneralFunctionsDAC.DDLReader(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean CheckMissingData()
        {
            try
            {
                SQLStr = " Select RelationshipCode From  Patients ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                //return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0];
                if (GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows[0]["RelationshipCode"] != DBNull.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean CheckMalaffiSent()
        {
            try
            {
                SQLStr = " Select COALESCE(MalaffiSent,0) AS MalaffiSent From Patients ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
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
                SQLStr = " Update Patients set ";
                SQLStr += " MalaffiSent =  1 ";
                SQLStr += " Where PatientID = " + PatientID.ToString();

                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataRow FindPatientPhInsuranceInformation()
        {
            try
            {
                SQLStr = " Select Name, Mobile,FeeCategoryPlanID,  InsuranceCardID, InsuranceCardExp, InsuranceCompany, FeeSubCategoryID, PH, PHCash, Product, EmiratesID, DateofBirth, Company, NationalityID, SexID ";
                SQLStr += " ,FeeCategoryPlanID2 ,  InsuranceCardID2, InsuranceCardExp2, InsuranceCompany2, FeeSubCategoryID2, PH2, PHCash2, Product2 ";
                SQLStr += " From Patients ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
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
                    System.Reflection.PropertyInfo prop = typeof(ClsApiPatients).GetProperty(myMatches[i].Value.Replace("@", ""));
                    if (prop != null)
                    {

                        if (typeof(ClsApiPatients).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "String")
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

                        else if (typeof(ClsApiPatients).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Double")
                        {

                            SQLPrameter = new SqlParameter(prop.Name, prop.GetValue(this, null));
                            SQLPrameter.DbType = DbType.Double;
                        }
                        else if (typeof(ClsApiPatients).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int16")
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

                        else if (typeof(ClsApiPatients).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "Int32")
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

                        else if (typeof(ClsApiPatients).GetProperty(myMatches[i].Value.Replace("@", "")).PropertyType.Name == "System.Boolean")
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
                { throw new Exception("ClsApiPatients - CreateParameters " + myMatches[i].Value.ToString() + ex.Message.ToString()); }
            }
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
            { throw new Exception("ClsApiPatients - InsertSP " + ex.Message.ToString()); }
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
        public DataRow PatientDetail()
        {
            try
            {
                SQLStr = " SELECT    dbo.Patients.SexID, dbo.Sex.Sex, dbo.CalcAge(dbo.Patients.DateofBirth) AS AGE, dbo.Patients.NationalityID, ";
                SQLStr += " dbo.FunFormatDateString( dbo.Patients.DateofBirth) AS DateofBirth ";
                SQLStr += " FROM         dbo.Sex INNER JOIN ";
                SQLStr += " dbo.Patients ON dbo.Sex.SexID = dbo.Patients.SexID ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow PatientInsurance()
        {
            try
            {
                SQLStr = " SELECT [PatientID]  ";
                SQLStr += " ,[FeeCategoryPlanID]  ";
                SQLStr += " ,[InsuranceCardID]  ";
                SQLStr += " ,[InsuranceCardExp]  ";
                SQLStr += " ,[InsuranceCompany]  ";
                SQLStr += " ,[FeeSubCategoryID]  ";
                SQLStr += " ,[NetworkID]  ";
                SQLStr += " ,[EmiratesID]  ";
                SQLStr += " ,[PH]  ";
                SQLStr += " ,[FeeCategoryPlanID2]  ";
                SQLStr += " ,[InsuranceCompany2]  ";
                SQLStr += " ,[FeeSubCategoryID2]  ";
                SQLStr += " ,[NetworkID2]  ";
                SQLStr += " ,[InsuranceCardID2]  ";
                SQLStr += " ,[InsuranceCardExp2]  ";
                SQLStr += " ,[PH2]  ";
                SQLStr += " ,[PhCash]  ";
                SQLStr += " ,[PhCash2]  ";
                SQLStr += " FROM [Appointment].[dbo].[Patients]";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int PatientHaveDamanOrThiqa(int PatientID)
        {
            string SQLStr;
            try
            {
                SQLStr = " SELECT [PatientID]  ";

                SQLStr += " FROM [Appointment].[dbo].[Patients] INNER JOIN FeeCategory ";
                SQLStr += " ON Patients.InsuranceCompany = FeeCategory.CategoryID ";
                SQLStr += " Where PatientID = " + PatientID.ToString();
                SQLStr += " AND ( UPPER(Category) Like '%DAMAN%' OR  UPPER(Category) Like '%THIQA%' ) ";
                //SQLStr += " AND [InsuranceCompany] in (2,5) ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Patients").Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetID()
        {
            try
            {
                SQLStr = " Select max(PatientID) + 1 From  Patients ";
                return Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReader(SQLStr));
            }
            catch
            { return 1; }
        }
        public DataTable GetNationalities()
        {
            try
            {
                SQLStr = " Select * From  Nationality ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Nationality").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetGender()
        {
            try
            {
                SQLStr = " Select * From  Sex ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Sex").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetMaritalStatus()
        {
            try
            {
                SQLStr = " Select * From  MaritalStatus ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "MaritalStatus").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetEmiratesIDOptions()
        {
            try
            {
                SQLStr = " Select * From  EmiratesIDOptions ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "EmiratesIDOptions").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetPercentage()
        {
            try
            {
                SQLStr = "Select Percentage , Convert(nvarchar(3),Percentage) + ' %' AS PercentValue From Percentage ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "Percentage").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetIDTypes()
        {
            try
            {
                SQLStr = " Select * From  IDType ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "IDType").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetTypes()
        {
            try
            {
                SQLStr = " Select * From  PatientType ";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientType").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Int16 GetSex()
        {
            try
            {
                SQLStr = " Select SexID From  Sex ";
                return Convert.ToInt16(GeneralFunctionsDAC.DDLStatment(SQLStr, "Sex").Tables[0].Rows[0][0]);
            }
            catch (Exception)
            { return 0; }
        }
        ////mohamed ibrahim
        //public int GetFileNO( string FName, string SName , string TName)
        //{
        //    try
        //    {
        //        SQLStr = " Select PatientID From  Patients ";
        //        SQLStr += " Where FirstName = " +"'" +FName.ToString(); 
        //        SQLStr += "' and SecondName = " + "'" + SName.ToString();
        //        SQLStr += "' and ThirdName = " + "'" + TName.ToString()+"'";
        //        return Convert.ToInt32(GeneralFunctionsDAC.DDLScalarReader(SQLStr));
        //    }
        //    catch
        //    { return 1; }
        //}
        ////mohamed ibrahim
        public DataTable CheckEmiratesIDExists(string EmiratesIDNO)
        {
            try
            {
                SQLStr = " Select * From  Patients where EmiratesID= '" + EmiratesIDNO + "'";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "EmiratesIDExists").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable GetPatientDataByPatientID()
        {
            try
            {
                SQLStr = " SELECT  [PatientID],[Code],[Name],[Mobile],[HomeTel],[InsuranceCardID],[InsuranceCardExp],[InsuranceCompany],FeeSubCategory.FeeSubCategory,[SexID],[DateofBirth],[MaritalStatusID],[Weight],[RegDate],[UpdatedBy],[BloodGroupID],[LastUpdated],[Mobile2],[Mobile3],[Company],[NationalityID],[EmiratesID],[ArabicName],[CardImg],[Job],[Address],[Email],[FriendName],[FriendTel],[Relations],[FriendGendar],[PC],[GP],[Ded],[DN],[PH],[MAXCash],[Product],[CoPay],[FamilyHistory],[PatientTypeID],[InsuranceCompany2],Patients.FeeSubCategoryID,[FeeSubCategoryID2],[Product2],[InsuranceCardID2],[InsuranceCardExp2],[PC2],[GP2],[Ded2],[DN2],[PH2],[MAXCash2],[CoPay2],[CardImg2],[CoPayCash],[DNCash],[MaxCoPay],[CoPayCash2],[DNCash2],[MaxCoPay2],[GPPer],[GPPer2],[GPMax],[GPMax2],[Lab],[LabCash],[Lab2],[LabCash2],[Xray],[XrayCash],[Xray2],[XrayCash2],[PhCash],[PhCash2],[NonArabic],[CardImgBack],[CardImgBack2],[SecondName],[ThirdName],[POBox],[City],[Emirates],[Area],[FirstName],[ID],[IDTypeID],[PHMax],[PHMax2],[DNPC],[DNPC2],FeeSubCategory.[NetworkID],[NetworkID2],[EmiratesIdImg],[NonFasting],[HowToKnow],[HowToKnowDetail],[OldFileNo],[FeeCategoryPlanID],[FeeCategoryPlanID2],[MakatingUserID],[PatientImg],[EmiratesIdBackImg],[TitleCode],[ReligionCode],[LanguageCode],[KinContactRoleCode],[KinCountryCode],[KinContactCode],[EmailTypeCode],[KinPhoneType],[EmirateID],[KinFirstName],[KinMiddleName],[KinLastName],[KinTitleCode],[RelationshipCode],[MobileAreaCode],[MobileCountryCode],[CompanyID],[MalaffiSent],FeeCategory.Category as InsuranceCompanyName,Patients.Notes FROM [Appointment].[dbo].[Patients] inner join FeeCategory on FeeCategory.CategoryID=Patients.InsuranceCompany inner join FeeSubCategory on FeeSubCategory.FeeSubCategoryID=Patients.FeeSubCategoryID where PatientID= " + PatientID.ToString() + "";
                return GeneralFunctionsDAC.DDLStatment(SQLStr, "PatientDataByPatientID").Tables[0];
            }
            catch (Exception ex)
            { throw ex; }
        }
        //public DataTable GetPatientDataBySearch()
        //{
        //    try
        //    {
        //        SQLStr = " SELECT  [PatientID],[Code],[Name],[Mobile],[HomeTel],[InsuranceCardID],[InsuranceCardExp],[InsuranceCompany],FeeSubCategory.FeeSubCategory,[SexID],[DateofBirth],[MaritalStatusID],[Weight],[RegDate],[UpdatedBy],[BloodGroupID],[LastUpdated],[Mobile2],[Mobile3],[Company],[NationalityID],[EmiratesID],[ArabicName],[CardImg],[Job],[Address],[Email],[FriendName],[FriendTel],[Relations],[FriendGendar],[PC],[GP],[Ded],[DN],[PH],[MAXCash],[Product],[CoPay],[FamilyHistory],[PatientTypeID],[InsuranceCompany2],Patients.FeeSubCategoryID,[FeeSubCategoryID2],[Product2],[InsuranceCardID2],[InsuranceCardExp2],[PC2],[GP2],[Ded2],[DN2],[PH2],[MAXCash2],[CoPay2],[CardImg2],[CoPayCash],[DNCash],[MaxCoPay],[CoPayCash2],[DNCash2],[MaxCoPay2],[GPPer],[GPPer2],[GPMax],[GPMax2],[Lab],[LabCash],[Lab2],[LabCash2],[Xray],[XrayCash],[Xray2],[XrayCash2],[PhCash],[PhCash2],[NonArabic],[CardImgBack],[CardImgBack2],[SecondName],[ThirdName],[POBox],[City],[Emirates],[Area],[FirstName],[ID],[IDTypeID],[PHMax],[PHMax2],[DNPC],[DNPC2],FeeSubCategory.[NetworkID],[NetworkID2],[EmiratesIdImg],[NonFasting],[HowToKnow],[HowToKnowDetail],[OldFileNo],[FeeCategoryPlanID],[FeeCategoryPlanID2],[MakatingUserID],[PatientImg],[EmiratesIdBackImg],[TitleCode],[ReligionCode],[LanguageCode],[KinContactRoleCode],[KinCountryCode],[KinContactCode],[EmailTypeCode],[KinPhoneType],[EmirateID],[KinFirstName],[KinMiddleName],[KinLastName],[KinTitleCode],[RelationshipCode],[MobileAreaCode],[MobileCountryCode],[CompanyID],[MalaffiSent],FeeCategory.Category as InsuranceCompanyName,Patients.Notes FROM [Appointment].[dbo].[Patients] inner join FeeCategory on FeeCategory.CategoryID=Patients.InsuranceCompany inner join FeeSubCategory on FeeSubCategory.FeeSubCategoryID=Patients.FeeSubCategoryID where PatientID Like '%" + Name.ToString() + "%'"+ "or Name like '%" + Name.ToString() + "%'" + "or Mobile like '%" + Name.ToString() + "%'" + "or EmiratesID like '%" + Name.ToString() + "%'" + "or InsuranceCardID like '%" + Name.ToString() + "%'" + "or Mobile2 like '%" + Name.ToString() + "%'" + "or Mobile3 like '%" + Name.ToString() + "%'";
        //        return GeneralFunctionsDAC.DDLStatment(SQLStr, "GetPatientDataBySearch").Tables[0];
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public DataTable GetPatientDataBySearch()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("Search", Name);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_GetPatientDataBySearch", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
