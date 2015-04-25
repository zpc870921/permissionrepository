using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EFFrameTest2.Data.Infrastructure;

namespace EFFrameTest2.Data.Repository
{
    public partial class PermissionRoleRepository : RepositoryBase<PermissionRole>, IPermissionRoleRepository
    {
        public PermissionRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public IList<PermissionRole> GetPagedRoleList(int pageIndex, int pageSize, string keyword, out int totalCount)
        {
            totalCount = 0;
            //var param = Expression.Parameter(typeof(PermissionRole), "p");

            Expression<Func<PermissionRole, bool>> cond = p => true;
            if(!String.IsNullOrWhiteSpace(keyword))
            {
                cond=cond.And(p=>p.Name.Contains(keyword.Trim()));
            }

            Expression<Func<PermissionRole,int>> orderCond=p => p.Id;

            var pageInfo=new Pagination { PageIndex = pageIndex, PageSize = pageSize };
            var result= this.GetPage(pageInfo, cond, orderCond);
            totalCount = pageInfo.TotalItem;
            return result;
        }

    }

    public partial interface IPermissionRoleRepository : IRepository<PermissionRole>
    {
        IList<PermissionRole> GetPagedRoleList(int pageIndex, int pageSize, string keyword, out int totalCount);
    }
}
