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

        [HttpGet]
        public List<QuoteEntity> GetAllQuotes()
        {
            return _quoteService.GetAllQuotes();
        }

        [HttpPost]
        public IHttpActionResult AddQuote(QuoteEntity quoteEntity)
        {
            _quoteService.AddQuote(quoteEntity);
            _hubContext.Clients.All.AddQuote(quoteEntity);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateQuote(QuoteEntity quoteEntity)
        {
            _quoteService.UpdateQuote(quoteEntity);
            _hubContext.Clients.All.UpdateQuote(quoteEntity);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteQuote(QuoteEntity quoteEntity)
        {
            _quoteService.DeleteQuote(quoteEntity.Id);
            _hubContext.Clients.All.DeleteQuote(quoteEntity.Id);
            return Ok();
        }
    }
}
