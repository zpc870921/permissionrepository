using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsTreeTest.Models.VO
{
    public class UserVO
    {
        public User User { get; set; }
        public IList<PermissionRole> RoleList { get; set; }
    }
}