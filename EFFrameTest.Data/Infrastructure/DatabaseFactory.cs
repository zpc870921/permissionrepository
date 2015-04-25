using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Infrastructure
{
   public class DatabaseFactory : Disposable, IDatabaseFactory
    {
       private ContactDbContext dbContext;

       public ContactDbContext Get()
        {
            return dbContext ?? (dbContext = new ContactDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext = null;
            }
            //base.DisposeCore();
        }
    }
}
