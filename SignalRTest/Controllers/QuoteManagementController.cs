using Microsoft.AspNet.SignalR;
using SignalRTest.Hubs;
using SignalRTestData.DAL;
using SignalRTestEntity.Entity;
using SignalRTestService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalRTest.Controllers
{
    public class QuoteManagementController : ApiController
    {
        private readonly IQuoteService _quoteService;
        private readonly IHubContext _hubContext;

        public QuoteManagementController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<QuoteManagementHub>();
        }

        [HttpPost]
        public IHttpActionResult AddQuote(QuoteEntity quoteEntity)
        {
            _quoteService.AddQuote(quoteEntity);
            _hubContext.Clients.All.AddQuote(quoteEntity);
            return Ok();
        }
    }
}
