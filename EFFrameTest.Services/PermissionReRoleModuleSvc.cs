using EFFrameTest2.Data.Repository;
using EFFrameTest2.Model.Entites;
using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Services
{
    public partial class PermissionSvc
    {

        public int AddOrUpdateReRoleModule(PermissionReRoleModule model)
        { 
            if(model.Id>0)
            {
                this.permissionReRoleModuleRepostory.Update(model);
            }else{
                this.permissionReRoleModuleRepostory.Add(model);
            }
            this.unitOfWork.Commit();
            return model.Id;
        }

        public int SaveReRoleAndModule(IList<PermissionReRoleModule> list, int roleid)
        {
            return this.permissionReRoleModuleRepostory.SaveReRoleAndModule(list,roleid);
        }

        public IList<PermissionReRoleModule> GetByModuleAndRole(int roleid,int moduleid)
        {
            return this.permissionReRoleModuleRepostory.GetMany(m => m.RoleId == roleid && m.ModuleId == moduleid).ToList();
        }

        public IList<PermissionReRoleModule> GetByRoleList(IList<int> roleid, string url)
        {
            return this.permissionReRoleModuleRepostory.GetByRoleList(roleid, url);
        }

        //protected readonly IUnitOfWork unitOfWork;
        //protected readonly IPermissionReRoleModuleRepostory permissionReRoleModuleRepostory;
        //public PermissionReRoleModuleSvc(IUnitOfWork unitofwork, IPermissionReRoleModuleRepostory permissionReRoleModuleRepostory)
        //{
        //    this.unitOfWork = unitofwork;
        //    this.permissionReRoleModuleRepostory = permissionReRoleModuleRepostory;
        //}
    }
}
