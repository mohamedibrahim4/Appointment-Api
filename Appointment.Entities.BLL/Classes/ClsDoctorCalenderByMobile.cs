using Appointment.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
    public class ClsDoctorCalenderByMobile:ClsDoctorCalender
    {
        public string VisitStatus
        {
            get;
            set;
        }
        public new string UpdatedBy
        {
            get;
            set;
        }
        public  string Doctor
        {
            get;
            set;
        }
        public string AppointmentReasons
        {
            get;
            set;
        }
        public new string  HowToKnow
        {
            get;
            set;
        }
        public new string Room
        {
            get;
            set;
        }
        public  string Action
        {
            get;
            set;
        }
        public string ActionDt
        {
            get;
            set;
        }
        [Obsolete("Not inherited", true)]
        public override string CreateDate
        {
            get;
            set;
        }
        [Obsolete("Don't use this", true)]
        public override string CreatedBy
        {
            get;
            set;
        }
        //[Obsolete("Don't use this",true)]
        //public override string AppDate
        //{
        //    get;
        //    set;
        //}
        //[Obsolete("Don't use this", true)]
        //public override string LastUpdated
        //{
        //    get;
        //    set;
        //}
        //[Obsolete("Don't use this", true)]
        //public override string CreateDate
        //{
        //    get;
        //    set;
        //}

    }

}
