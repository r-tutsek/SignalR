using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRTest.Models
{
    public class CrudGroup
    {
        public string ConnectionId { get; set; }
        public List<string> SubscribedGroups { get; set; }
    }
}