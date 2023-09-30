using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.ApiClasses
{
    public class KeykeyPair
    {
        [Required]
        public string key { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]

        public string NameAr { get; set; }
    }
}
