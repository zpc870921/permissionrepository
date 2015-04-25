using EFFrameTest2.Model.Entites;
using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EFFrameTest2.Data.Infrastructure;

namespace EFFrameTest2.Data.Repository
{
    public class PermissionReRoleModuleRepostory : RepositoryBase<PermissionReRoleModule>, IPermissionReRoleModuleRepostory
    {
        private static readonly string SQL_Connection = ConfigurationManager.ConnectionStrings["ContactStore"].ConnectionString;

        public PermissionReRoleModuleRepostory(IDatabaseFactory databaseFactory) : base(databaseFactory) { }


        private const string SQL_ReRoleAndModule = @"merge [dbo].[PermissionReRoleModule] as roleModule using @tvb as tvbrolemodule
on(
  roleModule.RoleId=tvbrolemodule.RoleId and roleModule.ModuleId=tvbrolemodule.ModuleId and roleModule.FuncCode=tvbrolemodule.FuncCode
)
when matched then
update set roleModule.FuncCode=tvbrolemodule.FuncCode,roleModule.OptScope=tvbrolemodule.OptScope
when not matched then
Insert (RoleId,ModuleId,FuncCode,OptScope) values(tvbrolemodule.RoleId,tvbrolemodule.ModuleId,tvbrolemodule.FuncCode,tvbrolemodule.OptScope)
when not matched by source and roleModule.RoleId=@roleid then delete;
";
        public int SaveReRoleAndModule(IList<PermissionReRoleModule> list, int roleid)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("RoleId", typeof(Int32)), 
                new DataColumn("ModuleId", typeof(Int32)), 
                new DataColumn("FuncCode", typeof(Int32)), 
                new DataColumn("OptScope", typeof(Int32)) });
            foreach (var item in list)
            {
                dt.Rows.Add(new object[]{
                 item.RoleId,
                 item.ModuleId,
                 item.FuncCode,
                 item.OptScope
                });
            }
            using (var con = new SqlConnection(SQL_Connection))
            {
                using (var cmd = new SqlCommand(SQL_ReRoleAndModule, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@roleid", roleid);
                    var param = cmd.Parameters.AddWithValue("@tvb", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.RoleModuleTb";
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private const string SQL_GetByRoleListAndUrl = @"
            SELECT [Id]
      ,[RoleId]
      ,[ModuleId]
      ,[FuncCode]
      ,[OptScope]
  FROM [PermissionReRoleModule] prm where prm.RoleId in (@roleids) and exists(select 1 from [PermissionModule] pm where pm.Id=prm.ModuleId and @url like  pm.Url+'%')
        ";
        public IList<PermissionReRoleModule> GetByRoleList(IList<int> roleid, string url)
        {
            using (SqlConnection con = new SqlConnection(SQL_Connection))
            {
                con.Open();
                using (var cmd = new SqlCommand(SQL_GetByRoleListAndUrl,con))
                {
                    cmd.Parameters.AddWithValue("@roleids", String.Join(",", roleid));
                    cmd.Parameters.AddWithValue("@url",url);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            IList<PermissionReRoleModule> list = new List<PermissionReRoleModule>();
                            while (reader.Read())
                            {
                                list.Add(new PermissionReRoleModule
                                {
                                    Id = reader.GetInt32(0),
                                    RoleId = reader.GetInt32(1),
                                    ModuleId = reader.GetInt32(2),
                                    FuncCode = reader.GetInt32(3),
                                    OptScope = reader.GetInt32(4)
                                });
                            }
                            return list;
                        }
                        return null;
                    }
                }
            }
        }
    }

    public partial interface IPermissionReRoleModuleRepostory : IRepository<PermissionReRoleModule>
    {
        int SaveReRoleAndModule(IList<PermissionReRoleModule> list, int roleid);
        IList<PermissionReRoleModule> GetByRoleList(IList<int> roleid, string url);
    }
}
