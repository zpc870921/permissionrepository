using EFFrameTest2.Model.Criteria;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using EFFrameTest2.Data.Infrastructure;

namespace EFFrameTest2.Data
{
    public partial class ContactRepostory:RepositoryBase<Contact>,IContactRepostory
    {
        public ContactRepostory(IDatabaseFactory databaseFactory):base(databaseFactory) { }


        public IList<Contact> ContactPaging(Pagination pageInfo, ContactCriteria criteria)
        {
            Expression<Func<Contact, bool>> condition = t => true;

            if (null != criteria)
            {
                if (!String.IsNullOrEmpty(criteria.Keyword))
                {
                    condition = condition.And(c => c.Name.Contains(criteria.Keyword) || c.Mobile.Contains(criteria.Keyword));
                }
                if (criteria.Id > 0)
                {
                    condition = condition.And(c => c.ContactId.Equals(criteria.Id));
                }
            }

            var result = this.GetPage(pageInfo, condition, p => p.CreateTime).ToList();
            return result;
        }

        public IList<Contact> GetContactListByProc(int contactId)
        {
            return this.DataContext.Database.SqlQuery<Contact>("GetContactListById @p0",contactId).ToList();
        }

        public IList<Contact> OrderByTest()
        {
            var query = from p in this.DataContext.Set<Contact>()
                        orderby p.Age descending, p.ContactId ascending
                        select p;

           // var query = this.DataContext.Set<Contact>().OrderByDescending(p => p.Age).OrderBy(p => p.ContactId);
            return query.ToList();
        }

        public int QueryLocal()
        {
            //直接读取内存
//            return this.DataContext.Set<Contact>().Local.Count;    


            //先加载到内存然后读取内存
            //var query = from p in this.DataContext.Set<Contact>()
                       // where p.ContactId <= 3
              //          select p;
            //foreach (var item in query)
            //{ 
                
            //}
            //return this.DataContext.Set<Contact>().Local.Count;

            //load方式加载到内存
            var query = from p in this.DataContext.Set<Contact>()
                        select p;
            return 0;
                            
        }


        public Contact FindSingleObj(int id)
        {
           // return this.DataContext.Set<Contact>().Find(id);
            //var query = from p in this.DataContext.Set<Contact>()
            //            where p.ContactId == 2
            //            select p;
            //return query.Single();

            var query = from p in this.DataContext.Set<Contact>()
                        where p.ContactId == 2
                        select p;
            return null;
        }

        public IList<Contact> GetCustomContactList()
        {
            //this.DataContext.Database.ExecuteSqlCommand()

            return this.DataContext.Set<Contact>().SqlQuery(@"select  TOP 1000 [ContactId]
      ,[Name]
      ,[Age]
      ,[Address]
      ,[Mobile]
      ,[Sex]
      ,[Rating]
      ,[remark]
      ,[Grade] from [Contact]").ToList();

//            return this.DataContext.Database.SqlQuery<Contact>(@"select  TOP 1000 [ContactId]
//      ,[Name]
//      ,[Age]
//      ,[Address]
//      ,[Mobile]
//      ,[Sex]
//      ,[Rating]
//      ,[remark]
//      ,[Grade] from [Contact]").ToList();
        }
    }
    public partial interface IContactRepostory:IRepository<Contact> {
        IList<Contact> ContactPaging(Pagination pageInfo, ContactCriteria criteria);
        IList<Contact> GetCustomContactList();
        IList<Contact> GetContactListByProc(int contactId);
        IList<Contact> OrderByTest();

        int QueryLocal();

        Contact FindSingleObj(int id);

    }
}
