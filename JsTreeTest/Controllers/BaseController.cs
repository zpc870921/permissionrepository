using EFFrameTest2.Model.Entites;
using JsTreeTest.Models;
using JsTreeTest.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsTreeTest.Controllers
{
    [Verify(Verify=true)]
    [Authorize]
    public class BaseController:Controller
    {
        public OperationScope MaxScope
        {
            get {
                return PageOptLogic.MaxScope;
            }
        }

        public IList<PermissionReRoleModule> FuncList
        {
            get;
            set;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.FuncList = PageOptLogic.CurrentPageFuncList();
            base.OnActionExecuting(filterContext);
        }
    }
}