using SignalRTestEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestData.DAL
{
    public interface IQuoteRespository
    {
        void InsertData(QuoteEntity quoteEntity);
        List<QuoteEntity> GetAllData();
        void Save();
    }
}
