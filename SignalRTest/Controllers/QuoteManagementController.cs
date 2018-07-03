using Microsoft.AspNet.SignalR;
using SignalRTest.Hubs;
using SignalRTest.Models;
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
        public IHttpActionResult AddQuote(QuoteRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var quoteEntity = new QuoteEntity
                {
                    Value = requestModel.Value
                };
                _quoteService.AddQuote(quoteEntity);
                _hubContext.Clients.Group("add").AddQuote(quoteEntity);
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateQuote(QuoteRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var quoteEntity = new QuoteEntity
                {
                    Id = requestModel.Id,
                    Value = requestModel.Value
                };
                _quoteService.UpdateQuote(quoteEntity);
                _hubContext.Clients.Group("update").UpdateQuote(quoteEntity);
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteQuote(QuoteRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var quoteEntity = new QuoteEntity
                {
                    Id = requestModel.Id,
                    Value = requestModel.Value
                };
                _quoteService.DeleteQuote(requestModel.Id);
                _hubContext.Clients.Group("delete").DeleteQuote(requestModel.Id);
            }
            return Ok();
        }
    }
}
