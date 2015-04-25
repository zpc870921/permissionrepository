using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsTreeTest.Models
{
    public class ReRoleModuleModel
    {
        public PermissionRole Role { get; set; }
        public IDictionary<int, string> OptCodeEnum { get; set; }
        public IDictionary<int, string> OptScopeEnum { get; set; }
    }
}