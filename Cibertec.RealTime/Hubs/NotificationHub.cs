using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.RealTime.Hubs
{
    public class NotificationHub : Hub
    {
        public void UpdateProduct(int id)
        {
            Clients.All.updateProduct(id);
        }
    }
}