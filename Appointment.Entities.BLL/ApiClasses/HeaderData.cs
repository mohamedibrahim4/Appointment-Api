using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.ApiClasses
{
   public  class HeaderData
    {
        public DateTime CurrentDate { get; set; }
        public String APIKey { get; set; }
        public Language Lang { get; set; }
    }
    public enum Language
    {
             Arabic=1
            ,English=2
    }
}
