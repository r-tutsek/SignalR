using SignalRTestEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTestData.Context
{
    public class SignalRTestContext : DbContext
    {
        public DbSet<QuoteEntity> QuoteContext { get; set; }
    }
}
