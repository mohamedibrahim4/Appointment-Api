using Appointment.Entities.BLL.ApiClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entitiies.ApiClasses
{
   public class GeneralFunction
    {
        public HeaderData ReadHeaderData(HttpRequestHeaders headers)
        {
            try
            {

            
            HeaderData header = new HeaderData();
            string apikey = string.Empty;
            string language = string.Empty;
            DateTime CuDate = DateTime.Now;
            if (headers.Contains("apikey"))
            {
                apikey = headers.GetValues("apikey").First();
            }
            if (headers.Contains("lang"))
            {
                language = headers.GetValues("lang").First();
            }
            if (headers.Contains("lang"))
            {
                language = headers.GetValues("lang").First();
            }
            if (headers.Contains("CurrentDate"))
            {
                CuDate =DateTime.Parse(headers.GetValues("CurrentDate").First());
            }

            header.APIKey = apikey;
            header.Lang = (language == "ar" ? Language.Arabic : Language.English);
            header.CurrentDate = CuDate;


                return header;
            }
            catch (Exception ex)
            {

                throw  ex;
            }
        }
        public bool ValidateHeader(HeaderData header)
        {
            try
            {

                return header.APIKey.Equals("EngMohamedIbrahim");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
