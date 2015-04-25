using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data.Infrastructure
{
    public class UnityOfWork : IUnitOfWork
    {

        private readonly IDatabaseFactory databaseFactory;
        private ContactDbContext dbContext;
        public UnityOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        private ContactDbContext DbContext
        {
            get { return dbContext ?? (dbContext = databaseFactory.Get()); }
        }


        public void Commit()
        {
            this.DbContext.Commit();
        }


        public void Commit(params object[] refreshObj)
        {

            this.DbContext.Commit();
            foreach (var item in refreshObj)
            {
                this.Refresh(item);
            }
            //this.DbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        


        public void Refresh(object obj)
        {
            this.DbContext.Entry(obj).Reload();
            //((IObjectContextAdapter)this.DbContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, obj);
            //throw new NotImplementedException();
        }

        public DbContextTransaction BeginTransaction()
        {
            return this.DbContext.Database.BeginTransaction();
        }
    }
}
