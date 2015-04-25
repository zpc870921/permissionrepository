using EFFrameTest2.Model.Entites;
using JsTreeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using JsTreeTest.Models.Enum;
using System.Web.Security;

namespace JsTreeTest.Controllers
{
    public class PageOptLogic
    {
        public static OperationScope MaxScope {
            get {
                var funcList= CurrentPageFuncList();
                return (OperationScope)funcList.Min(f => f.OptScope);
            }
        }

        public static bool PageOperationFunc(params int[] funcCode)
        {
            var funcList = CurrentPageFuncList();
            if (null == funcList || !funcList.Any())
            {
                return false;
            }
            return funcList.Any(f=>funcCode.Contains(f.FuncCode));
        }

        public static IList<PermissionReRoleModule> CurrentPageFuncList(IList<int> roleIdList=null,string url=null)
        {
            if (null == roleIdList || !roleIdList.Any())
            {
                    var user=UserHelper.CurrentUser();
                    roleIdList =user.RoleList.Select(u => u.RoleId).ToList();
            }
            
            if (string.IsNullOrWhiteSpace(url))
            {
                url = HttpContext.Current.Request.Url.AbsolutePath;
            }
            IList<PermissionReRoleModule> list = Utility.PermissionSvc.GetByRoleList(roleIdList, url);
            return list;
        }
    }
}