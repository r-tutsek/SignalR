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
        List<QuoteEntity> GetAllQuotes();
        void AddQuote(QuoteEntity quoteEntity);
        void DeleteQuote(int quoteId);
    }
}
