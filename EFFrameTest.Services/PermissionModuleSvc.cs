using EFFrameTest2.Data.Repository;
using EFFrameTest2.Model;
using EFFrameTest2.Model.Entites;
using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Services
{
    public partial class PermissionSvc:IPermission
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IPermissionModuleRepostory permissionModuleRepostory;
        protected readonly IPermissionRoleRepository permissionRoleRepository;
        protected readonly IPermissionReRoleModuleRepostory permissionReRoleModuleRepostory;
        protected readonly IUserRepository userRepository;
        protected readonly IUserReRoleRepository userReRoleRepository;
        public PermissionSvc(IUnitOfWork unitofwork, IPermissionModuleRepostory permissionModuleRepostory, IPermissionRoleRepository permissionRoleRepository, IPermissionReRoleModuleRepostory permissionReRoleModuleRepostory, IUserRepository userRepository, IUserReRoleRepository userReRoleRepository)
        {
            this.unitOfWork = unitofwork;
            this.permissionModuleRepostory = permissionModuleRepostory;
            this.permissionRoleRepository = permissionRoleRepository;
            this.permissionReRoleModuleRepostory = permissionReRoleModuleRepostory;
            this.userRepository = userRepository;
            this.userReRoleRepository = userReRoleRepository;
        }

        public int AddOrUpdateModules(PermissionModule module)
        {
            if(module.Id>0){
                this.permissionModuleRepostory.Update(module);
            }else{
                this.permissionModuleRepostory.Add(module);
            }
            this.unitOfWork.Commit();
            return module.Id;
        }

        public IList<PermissionModule> GetChildByParentId(int parentId)
        {
            return this.permissionModuleRepostory.GetMany(m => m.ParentId == parentId).ToList();
        }

        public PermissionModule Get(int id)
        {
            return this.permissionModuleRepostory.GetById(id);
        }

        public int ModulesManager(IList<PermissionModule> modules)
        {
            try
            {
                foreach (var item in modules)
                {
                    this.AddOrUpdateModules(item);
                }
               // this.unitOfWork.Commit();
                return 1;
            }
            catch
            {
                return 0;
            }
            //return this.permissionModuleRepostory.ModulesManager(modules);
        }
    }
}
