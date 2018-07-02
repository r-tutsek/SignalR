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
        void UpdateData(QuoteEntity quoteEntity);
        void DeleteData(int quoteId);
        List<QuoteEntity> GetAllData();
        void Save();
    }
}
