using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
   public class ClsApiGetAppPatientDrugs
    {
        public int DoctorID { get; set; }
        public string ArrDate { get; set; }
        public int PatientID { get; set; }
        public int WaitingID { get; set; }
    }
}
