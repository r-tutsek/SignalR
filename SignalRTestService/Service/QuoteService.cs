using SignalRTestData.DAL;
using SignalRTestEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestService.Service
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRespository _quoteRespository;

        public QuoteService(IQuoteRespository quoteRespository)
        {
            _quoteRespository = quoteRespository;
        }

        public List<QuoteEntity> GetAllQuotes()
        {
            return _quoteRespository.GetAllData();
        }

        public void AddQuote(QuoteEntity quoteEntity)
        {
            _quoteRespository.InsertData(quoteEntity);
            _quoteRespository.Save();
        }

        public void DeleteQuote(int quoteId)
        {
            _quoteRespository.DeleteData(quoteId);
            _quoteRespository.Save();
        }
    }
}
