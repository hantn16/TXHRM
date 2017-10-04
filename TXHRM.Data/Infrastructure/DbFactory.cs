using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TXHRMDbContext dbContext;
        public TXHRMDbContext Init()
        {
            return dbContext?? (new TXHRMDbContext()) ;
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            };
        }
    }
}
