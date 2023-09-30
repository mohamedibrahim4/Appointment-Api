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
   public class ClsDoctorNonWorkingTime
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int DoctorID { get; set;}

        public DataTable GetNonWorkingTimePeriodc(string StDate, string EndDate)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("StDate", StDate);
                sqlParameters[1] = new SqlParameter("EndDate", EndDate);
                return GeneralFunctionsDAC.DMLSPReaderWithPar3("SP_GetNonWorkingTimePeriodc", sqlParameters);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
