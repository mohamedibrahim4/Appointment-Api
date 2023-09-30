﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace AppointmentAPI.Hubs
{
    [HubName("appHub")]
    public class AppHub : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
        [HubMethodName("appChange")]
        public void AppChange()
        {
            Clients.All.UpdateApp();
        }
    }
}