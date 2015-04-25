using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    public class Role
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
