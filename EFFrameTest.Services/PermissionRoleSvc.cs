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
        //protected readonly IUnitOfWork unitOfWork;
        //protected readonly IPermissionRoleRepository permissionRoleRepository;
        //public PermissionSvc(IUnitOfWork unitofwork, IPermissionRoleRepository permissionRoleRepository)
        //{
        //    this.unitOfWork = unitofwork;
        //    this.permissionRoleRepository = permissionRoleRepository;
        //}

        public int AddOrUpdateRole(PermissionRole role)
        {
            if (role.Id > 0)
            {
                this.permissionRoleRepository.Update(role);
            }
            else
            {
                this.permissionRoleRepository.Add(role);
            }
            this.unitOfWork.Commit();
            return role.Id;
        }

        public PermissionRole GetRoleById(int id)
        {
            return this.permissionRoleRepository.GetById(id);
        }

        public IList<PermissionRole> GetAllRole()
        {
            return this.permissionRoleRepository.GetAll().ToList();
        }

        public IList<PermissionRole> GetPagedRoleList(int pageIndex, int pageSize, string keyword, out int totalCount) {
            return this.permissionRoleRepository.GetPagedRoleList(pageIndex, pageSize, keyword, out totalCount);
        }

    }
}
