using EFFrameTest2.Model.DTO;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model
{
    [ServiceContract]
    public interface IPermission
    {
        [OperationContract]
        int AddOrUpdateRole(PermissionRole role);
        [OperationContract]
        int AddOrUpdateModules(PermissionModule module);
        [OperationContract]
        int AddOrUpdateReRoleModule(PermissionReRoleModule model);
        [OperationContract]
        IList<PermissionModule> GetChildByParentId(int parentId);

        [OperationContract]
        int ModulesManager(IList<PermissionModule> modules);

        [OperationContract]
        PermissionModule Get(int id);

        [OperationContract]
        PermissionRole GetRoleById(int id);

        [OperationContract]
        IList<PermissionReRoleModule> GetByModuleAndRole(int roleid, int moduleid);

        [OperationContract]
        int SaveReRoleAndModule(IList<PermissionReRoleModule> list, int roleid);

        [OperationContract]
        IList<PermissionReRoleModule> GetByRoleList(IList<int> roleid, string url);

        [OperationContract]
        IList<PermissionRole> GetAllRole();

        [OperationContract]
        User GetById(int id);

        [OperationContract]
        User GetByNameAndPwd(string username, string password);

        [OperationContract]
        IList<PermissionRole> GetPagedRoleList(int pageIndex, int pageSize, string keyword, out int totalCount);

        [OperationContract]
        IList<User> GetPagedUserList(int pageIndex, int pageSize, string keyword, out int totalCount);

        [OperationContract]
        int AddOrUpdateUser(UserDTO user);

        [OperationContract]
        int SaveUserReRole(IList<UserReRole> reRoleList, int userId);
    }
}
