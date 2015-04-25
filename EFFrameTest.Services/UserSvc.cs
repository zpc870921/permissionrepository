using EFFrameTest2.Model.DTO;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFFrameTest2.Services
{
  

    public partial class PermissionSvc
    {
        public int SaveUserReRole(IList<UserReRole> reRoleList, int userId)
        {
            return this.userReRoleRepository.SaveUserReRole(reRoleList, userId);
        }

        public int AddOrUpdateUser(UserDTO userDto)
        {

            using (var tran = this.unitOfWork.BeginTransaction())
            {
                try
                {
                    if (userDto.User.Id > 0)
                    {
                        this.userRepository.Update(userDto.User);
                    }
                    else
                    {
                        this.userRepository.Add(userDto.User);
                    }
                    this.unitOfWork.Commit();
                    this.SaveUserReRole(userDto.RoleList, userDto.User.Id);
                    this.unitOfWork.Commit();
                    tran.Commit();
                    return userDto.User.Id;
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
               
            }
           
        }

        public User GetByNameAndPwd(string username, string password)
        {
            return this.userRepository.Get(f => f.UserName == username && f.Password == password);
        }

        public IList<User> GetPagedUserList(int pageIndex, int pageSize, string keyword, out int totalCount)
        {
            return this.userRepository.GetPagedUserList(pageIndex, pageSize, keyword, out totalCount);
        }

        public User GetById(int id)
        {
            var user= this.userRepository.GetById(id);
            if(null!=user)
            {
                user.RoleList = this.userReRoleRepository.GetMany(u => u.UserId == user.Id).ToList();
            }
            return user;
        }
    }
}
