using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL
{
    public class ErrorResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public string instance { get; set; }

        public List<ValidationError> validationErrors { get; set; }
    }

}
