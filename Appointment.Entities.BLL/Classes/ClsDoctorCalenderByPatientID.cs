using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
   public class ClsDoctorCalenderByPatientID
    {
        public int DocCalenderID
        {
            get;
            set;
        }
        public int DoctorID
        {
            get;
            set;
        }
        public virtual string AppDate
        {
            get;
            set;
        }
        public int PatientID
        {
            get;
            set;
        }
        public string Patient
        {
            get;
            set;
        }
        public string MobileNo
        {
            get;
            set;
        }    
        public Boolean Canceled
        {
            get;
            set;
        }
        public Boolean Attend
        {
            get;
            set;
        }
        public Boolean Finish
        {
            get;
            set;
        }  
        public int AppointmentReasonsID
        {
            get;
            set;
        }
        public string StDate
        {
            get;
            set;
        }
        public string EndDate
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public Int16 NonArabic
        {
            get;
            set;
        }       
        public string VisitStatus
        {
            get;
            set;
        }
        public  string UpdatedBy
        {
            get;
            set;
        }
        public string Doctor
        {
            get;
            set;
        }
        public string AppointmentReasons
        {
            get;
            set;
        }
        public  string HowToKnow
        {
            get;
            set;
        }
        public  string Room
        {
            get;
            set;
        }
        public string Action
        {
            get;
            set;
        }
        public string ActionDt
        {
            get;
            set;
        }
       
    }
}
