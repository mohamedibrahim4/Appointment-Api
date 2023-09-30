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
   public class ClsDoctorCalenderBase
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
        public virtual string LastUpdated
        {
            get;
            set;
        }
        public virtual int UpdatedBy
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
        public Int16 RoomID
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
        public string CreatedBy
        {
            get;
            set;
        }
        public Int16 NonArabic
        {
            get;
            set;
        }
        public Int16 HowToKnow
        {
            get;
            set;
        }
        public Int16 StatusID
        {
            get;
            set;
        }
        public DataTable GetAppointmentByDocCalenderID()
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("DocCalenderID", DocCalenderID);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_FindAppointmentByDocCalenderID", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
