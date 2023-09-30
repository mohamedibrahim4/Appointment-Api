using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
    public class ClsSex
    {
        public int SexID { get; set; }
        public string Sex { get; set; }
        public string SexAR { get; set; }
        public string SexCode { get; set; }
        public ClsSex()
        {

        }
       
        public ClsSex(int _SexID, string _Sex, string _SexAR, string _SexCode)
        {
            SexID = _SexID;
            Sex = _Sex;
            SexAR = _SexAR;
            SexCode = _SexCode;
        }
        public List<ClsSex> Read()
        {
            ClsSex sex = new ClsSex(1, "Male", "مذكر", "M");
            ClsSex sex1 = new ClsSex(2, "Female", "مؤنث", "F");
            ClsSex sex2 = new ClsSex(3, "Unknown", "غير معرف", "U");
            ClsSex sex3 = new ClsSex(4, "Not Available", "غير متوافر", "N");
            List<ClsSex> sexes = new List<ClsSex>();
            sexes.Add(sex);
            sexes.Add(sex1);
            sexes.Add(sex2);
            sexes.Add(sex3);
            return sexes;
        }


    }
}
