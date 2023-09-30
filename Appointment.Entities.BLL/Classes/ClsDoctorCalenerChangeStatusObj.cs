using Appointment.Entities.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.ApiClasses
{
    public class ClsDoctorCalenerChangeStatusObj
    {
        string SQLStr;

        [Required]
        public int DocCalenderID { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]

        public int StatusID { get; set; }

        public string Patient
        {
            get;
            set;
        }

        public Boolean UpdateStatus()
        {
            try
            {

                SQLStr = " Update DoctorCalender set ";
                SQLStr += " StatusID = " + StatusID.ToString();
                SQLStr += " , UpdatedBy = " + UpdatedBy;
                SQLStr += "Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
