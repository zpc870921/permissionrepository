using JsTreeTest.Controllers;
using JsTreeTest.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsTreeTest.Models
{
    public class VerifyAttribute:ActionFilterAttribute
    {
        public bool Verify { get; set; }

        public int ViewScope { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Verify&&!PageOptLogic.PageOperationFunc((int)PageOperation.View))
            {
                //var funcList = PageOptLogic.CurrentPageFuncList();
                //if (null == funcList || !funcList.Any())
                //{
                    throw new Exception("对不起，你没有权限查看本页面");
                //}
                //this.ViewScope = funcList.Min(f => f.OptScope);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}