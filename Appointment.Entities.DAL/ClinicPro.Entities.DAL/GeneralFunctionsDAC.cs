using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.DAL
{
    public class GeneralFunctionsDAC
    {
        public static bool DMLStatment(string SQLStr, string DBConString = "")
        {

            try
            {

                using (SqlConnection connection = ConnectionManager.GetConnection(DBConString))
                {
                    using (SqlCommand command = new SqlCommand(SQLStr, connection))
                    {
                        command.CommandType = CommandType.Text;

                        if (command.ExecuteNonQuery() <= 0)
                        { return false; }
                        else
                        { return true; }
                    }
                }
            }
            catch (Exception e)
            { throw e; }

        }
        public static DataSet DDLStatment(string SQLStr, string dt, string DBConString = "")
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection(DBConString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(SQLStr, connection))
                    {
                        da.Fill(ds, dt);
                        return ds;
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static DataSet DDLSPStatment(string SQLStr, string dt)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand = cmd;

                            da.Fill(ds, dt);
                            return ds;

                        }
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static DataSet DDLSPStatmentWithPar(string SQLStr, string dt, SqlParameter[] par)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            for (int i = 0; i <= par.Length - 1; i++)
                            {
                                //if (IsNumeric(par[i].Value.ToString()) == true)
                                //{
                                if (par[i].Value == null)
                                    par[i].Value = DBNull.Value;

                                //}
                                else
                                {
                                    if (par[i].Value.ToString() == "")
                                        par[i].Value = DBNull.Value;

                                }
                                cmd.Parameters.Add(par[i]);
                            }

                            da.SelectCommand = cmd;

                            da.Fill(ds, dt);
                            return ds;

                        }
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static DataSet DDLSPStatmentWithPar(string SQLStr, string dt)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand = cmd;

                            da.Fill(ds, dt);
                            return ds;

                        }
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }


        public static bool IsDate(string sdate)
        {
            DateTime dt;
            bool isDate = true;
            try
            {
                dt = DateTime.Parse(sdate);
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }
        public static bool IsNumeric(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsNumeric     
        public static SqlDataReader DMLSPReaderWithPar(string SPName, SqlParameter[] par)

        {
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["AppointmentCon"].ToString();

            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand(SPName, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;


                    for (int i = 0; i <= par.Length - 1; i++)
                    {
                        if (IsNumeric(par[i].Value.ToString()) == true)
                        {
                            if (par[i].Value == null)
                                par[i].Value = DBNull.Value;

                        }
                        else
                        {
                            if (par[i].Value.ToString() == "")
                                par[i].Value = DBNull.Value;

                        }
                        command.Parameters.Add(par[i]);
                    }

                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }
        public static SqlDataReader DMLSPReader(string SPName)
        {
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["AppointmentCon"].ToString();
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand(SPName, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }
        public static SqlDataReader DDLReader(string SQLStr)
        {
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["AppointmentCon"].ToString();
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand(SQLStr, connection))
                {

                    command.CommandType = CommandType.Text;
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }
        public static object DDLScalarReader(string SQLStr)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["AppointmentCon"].ToString();
            SqlConnection connection = new SqlConnection();
            try
            {

                connection.ConnectionString = connectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand(SQLStr, connection))
                {

                    command.CommandType = CommandType.Text;
                    return command.ExecuteScalar();

                }

            }
            catch (Exception ex)
            { throw ex; }

            finally
            {
                connectionString = null;
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }
        }
        public static object DDLScalarReaderWithPar(string SPName, SqlParameter[] par)

        {

            string connectionString = ConfigurationManager.ConnectionStrings["AppointmentCon"].ToString();
            // SqlConnection connection;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // connection = new SqlConnection(connectionString);
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SPName, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        for (int i = 0; i <= par.Length - 1; i++)
                        {
                            if (IsNumeric(par[i].Value.ToString()) == true)
                            {
                                if (par[i].Value == null)
                                    par[i].Value = DBNull.Value;

                            }
                            else
                            {
                                if (par[i].Value.ToString() == "")
                                    par[i].Value = DBNull.Value;

                            }
                            command.Parameters.Add(par[i]);
                        }

                        return command.ExecuteScalar();

                    }
                }

            }
            catch (Exception ex)
            { throw ex; }

            finally
            {
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}
                //connection = null;
                connectionString = null;
            }
        }
        public static string FindStr(String ProssID)
        {

            switch (ProssID)
            {
                case "A":
                    return "SH";
                case "B":
                    return "EY";
                case "C":
                    return "AD";
                case "D":
                    return "AHD";
                case "E":
                    return "ZO";
                case "F":
                    return "DOOF";
                case "G":
                    return "DOOG";
                case "H":
                    return "SAF";
                case "I":
                    return "DNI";
                case "j":
                    return "OODSJ";
                case "K":
                    return "KATI";
                case "L":
                    return "ONG";
                case "M":
                    return "MOON";
                case "N":
                    return "NINE";
                case "O":
                    return "OMI";
                case "P":
                    return "PIMO";
                case "Q":
                    return "NEEN";
                case "R":
                    return "S";
                case "S":
                    return "TAWFAS";
                case "T":
                    return "ABLE";
                case "U":
                    return "OGA";
                case "V":
                    return "AGI";
                case "W":
                    return "ESMAT";
                case "X":
                    return "HEXA";
                case "Y":
                    return "HOGO";
                case "Z":
                    return "ZOOLLL";
                case "0":
                    return "ERT5456FDG3";
                case "1":
                    return "018945KGJI89";
                case "2":
                    return "543WER54312";
                case "3":
                    return "7653DFGERTY2345";
                case "4":
                    return "SDFS3456456DFGFDGDFG";
                case "5":
                    return "345345SDFSDFHJGHJG";
                case "6":
                    return "SDFSD456456SDF";
                case "7":
                    return "DSFSD456456WERWE23423";
                case "8":
                    return "SDFSDF567867SDFSD";
                case "9":
                    return "234242SDFSDFUOUIO";
                default:
                    return ProssID;


            }

        }
        //public static string UploadAttachment(string Path, int PatientID, int DoctorID, string Desc, string AttachDate, Int16 AttachTypeID)
        //{
        //    //http://localhost/Appointment/Login.aspx

        //    AppointmentService1.FeesList ser = new AppointmentService1.FeesList();
        //    ser.Url = ConfigurationManager.AppSettings["LocalWebService"].ToString();
        //    //Read file to byte array

        //    FileStream stream = File.OpenRead(Path);
        //    byte[] fileBytes = new byte[stream.Length];

        //    stream.Read(fileBytes, 0, fileBytes.Length);
        //    stream.Close();
        //    string[] a;
        //    a = Path.ToString().Split('\\');
        //    if (AttachTypeID == 0)
        //    {
        //        return ser.UploadFile(Desc, 0, PatientID, DoctorID, Desc, AttachDate, AttachTypeID, fileBytes).ToString();
        //    }
        //    else
        //    {
        //        return ser.UploadFile(a[a.Length - 1].ToString(), 0, PatientID, DoctorID, Desc, AttachDate, AttachTypeID, fileBytes).ToString();
        //    }
        //}
        //public static string UploadAttachment(Byte[] Pic, int PatientID, int DoctorID, string Desc, string AttachDate, Int16 AttachTypeID, string FileName)
        //{
        //    //http://localhost/Appointment/Login.aspx

        //    AppointmentService1.FeesList ser = new AppointmentService1.FeesList();
        //    ser.Url = ConfigurationManager.AppSettings["LocalWebService"].ToString();
        //    //Read file to byte array



        //    string[] a;

        //    if (AttachTypeID == 9999)
        //    {
        //        return ser.UploadFile(FileName, 0, PatientID, DoctorID, Desc, AttachDate, AttachTypeID, Pic).ToString();
        //    }
        //    else
        //    {
        //        return ser.UploadFile(FileName, 0, PatientID, DoctorID, Desc, AttachDate, AttachTypeID, Pic).ToString();
        //    }
        //}
        //public static Byte[] GetAttachment(string strFileName, Int16 AttachTypeID)
        //{
        //    //http://localhost/Appointment/Login.aspx

        //    AppointmentService1.FeesList ser = new AppointmentService1.FeesList();
        //    ser.Url = ConfigurationManager.AppSettings["LocalWebService"].ToString();
        //    //Read file to byte array
        //    return ser.GetFile(AttachTypeID, strFileName);

        //}
        public static string GetMonthStr(Int16 Month)
        {
            try
            {
                switch (Month)
                {
                    case 1:
                        return "Jan";

                    case 2:
                        return "Feb";
                    case 3:
                        return "Mar";
                    case 4:
                        return "Apr";
                    case 5:
                        return "May";
                    case 6:
                        return "Jun";
                    case 7:
                        return "Jul";
                    case 8:
                        return "Aug";
                    case 9:
                        return "Sep";
                    case 10:
                        return "Oct";
                    case 11:
                        return "Nov";
                    case 12:
                        return "Dec";
                    default:
                        return "";
                }
            }
            catch (Exception e)
            { throw e; }
        }
        //public static void ViewConsent(Int16 ConsentID, int PatientID = 0, int VisitID = 0, int OperationID = 0, int ReportID = 0)
        //{
        //    //            HLPatientInformation.NavigateUrl = "~\ReportForms\PatientInformation.aspx?PatientID=" & txtFileNo.Text
        //    //HLDamanConsent.NavigateUrl = "~\ReportForms\PatientClaimForm.aspx?PatientID=" & txtFileNo.Text & "&InsCompany=Daman_Consent"
        //    //HLGeneralConsent.NavigateUrl = "~\ReportForms\PatientClaimForm.aspx?PatientID=" & txtFileNo.Text & "&InsCompany=General Consent"


        //    // lblCode.Text = dgComplaints.Rows[dgComplaints.CurrentRow.Index].Cells["Fav"].Value.ToString();
        //    string URL;
        //    //switch (ConsentName)
        //    //{
        //    //    case 1:
        //    //        Console.WriteLine("Case 1");
        //    //        break;
        //    //    case 2:
        //    //        Console.WriteLine("Case 2");
        //    //        break;
        //    //    default:
        //    //        Console.WriteLine("Default case");
        //    //        break;
        //    //}
        //    ClsConsentForms Consent = new ClsConsentForms();
        //    System.Data.SqlClient.SqlDataReader drConsent;

        //    //URL = "http://" + ConfigurationManager.AppSettings["Url"].ToString() + "/ReportForms/PatientClaimForm.aspx?InsCompany=General Consent&PatientID=" + dgDoctorPatients.Rows[Convert.ToInt32(lblRowIndex.Text)].Cells["DocCalenderID"].Value.ToString();

        //    Doctor.FrmAttachment Attach;
        //    try
        //    {
        //        Consent.ConsentID = ConsentID;
        //        drConsent = Consent.FindData();
        //        if (drConsent.HasRows == true)
        //        {
        //            drConsent.Read();
        //            URL = "http://" + ConfigurationManager.AppSettings["Url"].ToString() + drConsent["Link"].ToString();
        //            if (Convert.ToBoolean(drConsent["PatientID"]) == true)
        //                URL += "&PatientID=" + PatientID.ToString();
        //            if (Convert.ToBoolean(drConsent["VisitID"]) == true)
        //                URL += "&WaitingID=" + VisitID.ToString();
        //            if (Convert.ToBoolean(drConsent["VisitID"]) == true)
        //                URL += "&VisitID=" + VisitID.ToString();
        //            if (Convert.ToBoolean(drConsent["OperationID"]) == true)
        //                URL += "&OperationID=" + OperationID.ToString();
        //            if (Convert.ToBoolean(drConsent["ReportID"]) == true)
        //                URL += "&ReportID=" + ReportID.ToString();
        //            URL += "&UserID=" + Appointment.Properties.Settings.Default.UserID.ToString();
        //            if (ConsentID == 17 || ConsentID == 29)
        //            {
        //                //string Complications = MessageBox.Show("","",MessageBoxButtons.OKCancel,,,MessageBoxOptions.DefaultDesktopOnly,

        //                URL += "&Complications=" + Microsoft.VisualBasic.Interaction.InputBox("What's the Complications Expected For " + drConsent["Consent"].ToString(), drConsent["Consent"].ToString(), "None");

        //            }
        //            if (ConsentID == 26)
        //            {
        //                //string Complications = MessageBox.Show("","",MessageBoxButtons.OKCancel,,,MessageBoxOptions.DefaultDesktopOnly,
        //                //test(s), treatment(s), operation(s) or procedure(s):
        //                URL += "&procedure=" + Microsoft.VisualBasic.Interaction.InputBox("What's the test(s), treatment(s), operation(s) or procedure(s): " + drConsent["Consent"].ToString(), drConsent["Consent"].ToString(), "None");
        //                URL += "&Complications=" + Microsoft.VisualBasic.Interaction.InputBox("What's the Complications Expected of refusing the offered treatment ", drConsent["Consent"].ToString(), "None");

        //            }

        //            if (ConsentID == 27) //PregnancyConsent
        //            {
        //                //treatment and/or procedure.
        //                URL += "&procedure=" + Microsoft.VisualBasic.Interaction.InputBox("What's treatment and/or procedure for " + drConsent["Consent"].ToString(), drConsent["Consent"].ToString(), "None");
        //                URL += "&Complications=" + Microsoft.VisualBasic.Interaction.InputBox("What's the Complications Expected of offered treatment ", drConsent["Consent"].ToString(), "None");

        //            }
        //            if (ConsentID == 28) //PregnancyConsent
        //            {
        //                //treatment and/or procedure.
        //                URL += "&Procedure=" + Microsoft.VisualBasic.Interaction.InputBox("What's High Risk medical treatment, operation and/or procedure for " + drConsent["Consent"].ToString(), drConsent["Consent"].ToString(), "None");
        //                URL += "&SurgicalSide=" + Microsoft.VisualBasic.Interaction.InputBox("What's High Risk medical treatment, operation and/or procedure Surgical Side ", drConsent["Consent"].ToString(), "None");
        //                URL += "&Complications=" + Microsoft.VisualBasic.Interaction.InputBox("What's the Complications Expected of offered treatment ", drConsent["Consent"].ToString(), "None");

        //            }
        //            if (ConsentID == 31)
        //            {
        //                URL += "&Complications=" + Microsoft.VisualBasic.Interaction.InputBox("What's necessary precautions and complications ", drConsent["Consent"].ToString(), "None");
        //            }

        //            //System.Diagnostics.Process.Start("chrome.exe", URL.Replace(" ", "%20"));
        //            Attach = new Doctor.FrmAttachment(0, "", 0, 0, 0, URL);
        //            Attach.ShowDialog();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ViewConsent Function " + ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        Attach = null;
        //        URL = null;
        //    }


        //}
        //public static bool PrepareSMSMessage(string Message, string Mobile, bool ArLang, int DocCalenderID = 0)
        //{
        //    int i;
        //    ClsSMSLog SMSLog = new ClsSMSLog();

        //    string Result;

        //    try
        //    {
        //        SMSLog.UserSentID = 1;
        //        string SMS;
        //        SMS = Message;

        //        SMS += " OPTOUT@5258";
        //        SMSLog.SMS = SMS;
        //        if (ArLang == true) SMS = ConvertSMSToBinary(SMS);




        //        Mobile = Mobile.Replace("-", "");
        //        Mobile = Mobile.Replace("/", "");


        //        switch (Mobile.Length)
        //        {
        //            case 7:
        //                Mobile = "97150" + Mobile;
        //                break;
        //            case 10:
        //                Mobile = "971" + Mobile.ToString().Substring(1, 9);
        //                break;
        //            case 14:
        //                Mobile = Mobile.Substring(2, 12);
        //                break;
        //            default:
        //                break;
        //        }

        //        if (ArLang == true)
        //        {
        //            Result = SendSMSMessage(Mobile, SMS, 8);
        //        }
        //        else
        //        {
        //            Result = SendSMSMessage(Mobile, SMS, 0);
        //        }

        //        SMSLog.MobileNo = Mobile;
        //        SMSLog.DocCalenderID = DocCalenderID;
        //        SMSLog.SMSRef = Result;
        //        SMSLog.InsertSP();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("PrepareSMSMessage " + ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        i = 0;
        //        SMSLog = null;
        //        Result = null;
        //        GC.Collect();
        //    }

        //}
        //public static string SendSMSMessage(string Mobile, string SMS, Int16 Lang)
        //{
        //    switch (ConfigurationManager.AppSettings["SMSMethod"].ToString())
        //    {
        //        case "IBA":
        //            return SendSMSMessageIBA(Mobile, SMS, Lang);

        //        default:
        //            return "";

        //    }
        //}
        //public static string SendSMSMessageIBA(string Mobile, string SMS, Int16 Coding)
        //{
        //    string urlSms;
        //    string Msender;
        //    Uri uri;
        //    string data;
        //    HttpWebRequest request;
        //    StreamWriter writer;
        //    HttpWebResponse response;
        //    string tmp;
        //    StreamReader reader;

        //    try
        //    {

        //        urlSms = ConfigurationManager.AppSettings["SMSURL"].ToString() + "&api_key=" + ConfigurationManager.AppSettings["SMSUserName"].ToString();
        //        // 'Dim urlSms As String = "http://46.101.142.16/sms/api?action=send-sms&api_key=bGtFcm1pZ051dUVrQXZ4RG9tR3g=&to=971543059191&from=Everlast%20MC&sms=Test%20SMS%20from%20Everlast%20MC&response=json"



        //        Msender = ConfigurationManager.AppSettings["SMSSenderID"].ToString();

        //        uri = new Uri(urlSms);


        //        if (Coding == 8)
        //        {
        //            data = "action=send-sms&api_key=" + ConfigurationManager.AppSettings["SMSUserName"].ToString() + "&to=" + Mobile + "&from=" + Msender + "&sms=" + SMS + "&type=unicode&response=json";
        //        }
        //        else
        //        {
        //            data = "action=send-sms&api_key=" + ConfigurationManager.AppSettings["SMSUserName"].ToString() + "&to=" + Mobile + "&from=" + Msender + "&sms=" + SMS + "&response=json";
        //        }




        //        request = (HttpWebRequest)WebRequest.Create(uri);

        //        request.Method = WebRequestMethods.Http.Post;

        //        //'request.ContentLength = data.Length

        //        request.ContentType = "application/x-www-form-urlencoded";

        //        writer = new StreamWriter(request.GetRequestStream());

        //        writer.Write(data);

        //        writer.Close();

        //        response = (HttpWebResponse)request.GetResponse();

        //        reader = new StreamReader(response.GetResponseStream());

        //        tmp = reader.ReadToEnd();

        //        response.Close();
        //        return tmp;

        //    }
        //    catch (Exception ex)
        //    { throw new Exception(" SendSMSMessageIBA " + ex.Message.ToString()); }
        //    finally
        //    {
        //        urlSms = null;
        //        Msender = null;
        //        uri = null;
        //        data = null;
        //        writer = null;
        //        response = null;
        //        tmp = null;
        //        reader = null;
        //        GC.Collect();
        //    }
        //}

        public static string ConvertSMSToBinary(string input)
        {
            Char[] values = input.ToCharArray();
            StringBuilder hex = new StringBuilder();
            foreach (Char c in values)
            {
                // ' Get the integral value of the character.
                Int32 value = Convert.ToInt32(c);
                // ' Convert the decimal value to a hexadecimal value in string form.
                hex.AppendFormat("{0:X4}", value);
            }


            return hex.ToString();
        }
        public static DataTable DMLSPReaderWithPar3(string SPName, SqlParameter[] par)

        {
            //SqlDataAdapter da = null;
            string connectionString = ConfigurationManager.ConnectionStrings["AppointmentConnectionString"].ToString();


            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter da = new  SqlDataAdapter(SPName, connection);
                DataSet ds = new DataSet();

                using (SqlCommand command = new SqlCommand(SPName, connection))
                {

                    //command.CommandType = CommandType.StoredProcedure;


                    for (int i = 0; i <= par.Length - 1; i++)
                    {
                        if (IsNumeric(par[i].Value.ToString()) == true)
                        {
                            if (par[i].Value == null)
                                par[i].Value = DBNull.Value;

                        }
                        else
                        {
                            if (par[i].Value.ToString() == "")
                                par[i].Value = DBNull.Value;

                        }
                        da.SelectCommand.Parameters.Add(par[i]);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //connection.Open();
                        
                    }


                   



                }
                da.Fill(ds, "DS");

                return ds.Tables[0];
                //return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }



        /*
        public System.Collections.Specialized.NameValueCollection ExecuteReaderNV(System.Data.CommandType CommandType, string CommandText)
        {

            //'
            //'Variable Declarations
            //'
            string sConnectionString;
            //'
            //'Get Connection string from Web.config File
            //'

            sConnectionString = ConfigurationManager.ConnectionStrings["AppointmentCon"].ToString();
            //'
            //'Execute NonQuery
            //'

            return ExecuteReaderNV(sConnectionString, CommandType, CommandText);

        }

        public System.Collections.Specialized.NameValueCollection ExecuteReaderNV(string ConnectionString, System.Data.CommandType CommandType1, string CommandText)
        {


            //'
            //'Check ConnectionString - if null raise exception
            //'
            //if  ConnectionString Is Nothing OrElse ConnectionString.Length = 0 Then Throw New ArgumentNullException("ConnectionString")
            //'
            //'Variable Declarations
            //'
            SqlConnection Connection = null;
            SqlCommand Command = new SqlCommand();
            SqlDataReader DataReader = null;
            System.Collections.Specialized.NameValueCollection NVData = new System.Collections.Specialized.NameValueCollection();
            Boolean MakeConnectionClose = false;

            Int16 i;
            try
            {
                //'
                //'Create Connection and Open it
                //'
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                //'
                //'If Connection failed raise exception
                //'
                //If Connection Is Nothing Then Throw New ArgumentNullException("Connection")
                //'
                //'Prepare Command
                //'
                PrepareCommand(Command, Connection, CType(Nothing, OracleTransaction), CommandType, CommandText, CType(Nothing, OracleParameter()), MakeConnectionClose);
                try
                {
                    //'
                    //'Create DataReader
                    //'
                    DataReader = Command.ExecuteReader(CommandBehavior.CloseConnection);
                    //'
                    //'Read Values into name value collection
                    //'
                    while (DataReader.Read())
                    {
                        for (int ii = 0; ii < DataReader.FieldCount; ii++)
                        {
                            if (DataReader.GetValue(ii) != System.DBNull.Value) NVData.Add(DataReader.GetName(ii).ToString, "");

                            if (DataReader.GetValue(ii) != System.DBNull.Value) NVData.Add(DataReader.GetName(ii).ToString, DataReader.GetValue(ii));

                        }
                    }
                    //'
                    //'Return Values
                    //'
                    return NVData;
                }
                catch (Exception ex1)
                { throw ex1; }
                finally
                {
                    //'
                    //'Close the Reader
                    //'
                    DataReader.Close();
                }
                //'
                //'Close the Connection before exit
                //'
                if (MakeConnectionClose) Connection.Close();
            }
            catch (Exception ex2)
            { throw ex2; }
            finally
            {
                //'
                //'Finally Dispose the Connection
                //'
                if (Connection != null) Connection.Dispose();
            }
        }

        #region "Utility Fuctions"
        //'
        //'Function: PrepareCommand
        //'Description: To build SQLCommand 



        public void PrepareCommand(SqlCommand Command,
                                              SqlConnection Connection,
                                              SqlTransaction Transaction,
                                              CommandType CommandType1,
                                              string CommandText,
                                              SqlParameter[] CommandParameters ,
                                              Boolean MakeConnectionClose)
        {
            //'
            //'Check Command 
            //'
            if (Command is null) throw new ArgumentNullException("Command");
            //'
            //'Check CommandText
            //'
            if (CommandText is null || CommandText.Length == 0) throw new ArgumentNullException("CommandText");
            //'
            //'Check Connection ; if connection is closed then make connection open; 
            //'change the boolean value of MustCloseConnection accordingly
            //'
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
                MakeConnectionClose = true;
            }
            else
            {
                MakeConnectionClose = false;
            }
            //'
            //'Associate the connection
            //'
            Command = Connection.CreateCommand();
            //'
            //'Check the Transaction, if requested by user provide it
            //'
            if   (Transaction != null)
            {
                if (Transaction.Connection is null) throw new ArgumentNullException("Transaction Commited or Rollbacked", "Transaction");
                Command.Transaction = Transaction;
            }
            //'
            //'Set Command Type
            //'
            Command.CommandType = CommandType1;
            //'
            //'Set Command Text
            //'
            Command.CommandText = CommandText;
            //'
            //'Assign Prameters; if provided by user
            //'
            if (CommandParameters != null) AttachParameters(Command, CommandParameters);
          

            return;
        }

        //'
        //'Function: AttachParameters
        //'Description: To Assign parametervalues to  Command
        //'
        public void AttachParameters(SqlCommand Command,
                                            SqlParameter[] CommandParameters)
        {
            //'
            //'Check Command
            //'
            if (Command is null) throw new ArgumentNullException("Command");

            //'
            //'Check Command Parameters
            //'
            if (CommandParameters != null)
            {
                
                foreach (SqlParameter Parameter in CommandParameters)
                {
                    if (Parameter != null)
                    {
                        //'
                        //'check for input parameter, if value is nothing then assign DBNull value)
                        //'
                        if (Parameter.Direction == ParameterDirection.InputOutput) || (Parameter.Direction == ParameterDirection.Input) || Parameter.Value is null) 
                        { 
                            Parameter.Value = DBNull.Value;
                        }
                   }

                    Command.Parameters.Add(Parameter)
               }
           
       }
        #endregion
        */
    }

}
