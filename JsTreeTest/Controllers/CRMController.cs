using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsTreeTest.Controllers
{
    public class CRMController:BaseController
    {
        public ActionResult CustomerMgr()
        {
            ViewBag.funclist = base.FuncList;
            return View();
        }
    }
}