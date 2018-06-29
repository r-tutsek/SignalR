using SignalRTestData.Context;
using SignalRTestEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestData.DAL
{
    public class QuoteRepository : IQuoteRespository, IDisposable
    {
        private SignalRTestContext context;
        private bool disposed = false;

        public QuoteRepository()
        {
            context = new SignalRTestContext();
        }

        public void InsertData(QuoteEntity entity)
        {
            context.QuoteContext.Add(entity);
        }

        public List<QuoteEntity> GetAllData()
        {
            return context.QuoteContext.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
