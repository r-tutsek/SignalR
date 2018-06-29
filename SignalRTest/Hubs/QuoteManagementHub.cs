using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRTestEntity.Entity;

namespace SignalRTest.Hubs
{
    public class QuoteManagementHub : Hub
    {
        public void AddQuote(QuoteEntity quoteEntity)
        {
            Clients.All.AddQuote(quoteEntity);
        }

        public void DeleteQuote(int quoteId)
        {
            Clients.All.RemoveQuote(quoteId);
        }
    }
}