using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using EFFrameTest2.Data.Infrastructure;

namespace EFFrameTest2.Data.Repository
{
    public partial class PermissionModuleRepository : RepositoryBase<PermissionModule>, IPermissionModuleRepostory
    {
        public PermissionModuleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        //private const string SQL_Modules = @"merge [dbo].[]";

        public int ModulesManager(IList<PermissionModule> modules)
        {

            return 0;
        }
    }

    public partial interface IPermissionModuleRepostory : IRepository<PermissionModule>
    {
        int ModulesManager(IList<PermissionModule> modules);
    }
}
