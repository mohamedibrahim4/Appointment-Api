using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.BLL.Classes
{
   public    class ClsApiSetting
    {
        public int AppStartTime { get; set; }= int.Parse(ConfigurationManager.AppSettings.Get("AppStartTime"));
        public int AppInterval { get; set; } = int.Parse(ConfigurationManager.AppSettings.Get("AppInterval"));
        public int AppEndTime { get; set; }= int.Parse(ConfigurationManager.AppSettings.Get("AppEndTime"));
    }
}
