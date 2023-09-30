using Appointment.Entities.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.ApiClasses
{
    public class ClsDoctorCalenerCancelObj
    {
        string SQLStr;

        [Required]
        public int DocCalenderID { get; set; }
        [Required]
        public int UpdatedBy { get; set; }

        public Boolean AppCanceled()
        {
            try
            {
                SQLStr = " Update DoctorCalender set ";
                SQLStr += " Canceled = 1, ";
                SQLStr += " StatusID = 15 ";
                SQLStr += " , UpdatedBy = " + UpdatedBy;
                SQLStr += " Where DocCalenderID = " + DocCalenderID.ToString();
                return GeneralFunctionsDAC.DMLStatment(SQLStr);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
