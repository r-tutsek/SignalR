using SignalRTestData.Context;
using SignalRTestEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        public void UpdateData(QuoteEntity entity)
        {
            var quoteRecord = context.QuoteContext.FirstOrDefault(q => q.Id == entity.Id);
            if (quoteRecord != null)
            {
                quoteRecord.Value = entity.Value;
            }
        }

        public void DeleteData(int quoteId)
        {
            var quoteRecord = context.QuoteContext.FirstOrDefault(q => q.Id == quoteId);
            if(quoteRecord != null)
            {
                context.QuoteContext.Remove(quoteRecord);
            }
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
