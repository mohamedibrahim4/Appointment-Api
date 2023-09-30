using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.ApiClasses
{
   public static class DataDirectory
    {
        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string StartDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo !=null)
                {
                    StartDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                StartDirectory = parent.FullName;
            }
            return Path.Combine(StartDirectory,"");
        }
    }
}
