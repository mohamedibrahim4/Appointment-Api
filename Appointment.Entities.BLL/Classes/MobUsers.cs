using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
   public class MobUsers
    {
        string SQLStr = "";
        [Required]
        public int MobUserID { get; set; }
        public string MobUserName { get; set; }
        public string MobUserPhone { get; set; }
        public string MobUserEmail { get; set; }
        public Int32 Doc_Type { get; set; }
        public string Doc_Id { get; set; }
        public String password { get; set; }


    }
}
