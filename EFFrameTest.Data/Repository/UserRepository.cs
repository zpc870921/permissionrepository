using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EFFrameTest2.Data.Repository
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public IList<User> GetPagedUserList(int pageIndex, int pageSize, string keyword, out int totalCount)
        {
            totalCount = 0;
            Expression<Func<User,bool>> cond=t=>true;
            if(!String.IsNullOrWhiteSpace(keyword))
            {
                cond = cond.And(u => u.UserName.Contains(keyword.Trim()));
            }
            var pageInfo=new Pagination { PageIndex = pageIndex, PageSize = pageSize };
            var result= this.GetPage(pageInfo, cond, t => t.Id);
            totalCount = pageInfo.TotalItem;
            return result;
        }

    }

    public partial interface IUserRepository : IRepository<User>
    {
        IList<User> GetPagedUserList(int pageIndex, int pageSize, string keyword, out int totalCount);
    }
}
