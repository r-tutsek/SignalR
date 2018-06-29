using SignalRTestEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestService.Service
{
    public interface IQuoteService
    {
        void AddQuote(QuoteEntity quoteEntity);
    }
}
