using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EFFrameTest2.Data.Repository
{
    public class UserReRoleRepository : RepositoryBase<UserReRole>, IUserReRoleRepository
    {
        public UserReRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public int SaveUserReRole(IList<UserReRole> reRoleList, int userId)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(
                new DataColumn[] { 
                        new DataColumn("UserId",typeof(Int32)),
                        new DataColumn("RoleId",typeof(Int32))
                        }
                );
            foreach(var item in reRoleList)
            {
                dt.Rows.Add(new object[]{userId,item.RoleId});
            }
            using (SqlConnection conn = new SqlConnection(SQL_Conn))
            { 
                //when matched then 
//update set T.UserId=S.UserId, T.RoleId=S.RoleId
                string cmdtxt=@"Merge [dbo].[UserReRole] as T
    using @tvb as S
on (T.UserId=S.UserId and T.RoleId=S.UserId)
when not matched then
Insert  (UserId,RoleId) values(S.UserId,S.RoleId)
when not matched by Source and T.UserId=@userid then delete;
";
                using(SqlCommand cmd=new SqlCommand(cmdtxt,conn))
                {
                    cmd.Parameters.AddWithValue("@userid",userId);
                    var param= cmd.Parameters.AddWithValue("@tvb",dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.UserReRole";
                    if(conn.State!=ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }

    public partial interface IUserReRoleRepository : IRepository<UserReRole>
    {
        int SaveUserReRole(IList<UserReRole> reRoleList,int userId);
    }
}
