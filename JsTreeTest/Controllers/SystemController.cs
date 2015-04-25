using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JsTreeTest.Models;
using System.ServiceModel;
using System.ServiceModel.Channels;
using EFFrameTest2.Model;
using JsTreeTest.Models.Enum;
using EFFrameTest2.Model.Entites;
using System.Web.Security;
using EFFrameTest2.Model.Utils;



namespace JsTreeTest.Controllers
{
    public class SystemController:Controller
    {
        

        public ActionResult TestTree()
        {
            return View();
        }

        //
        // GET: /System/
        public ActionResult Index()
        {
            User currentUser = UserHelper.CurrentUser();
            return View(currentUser);
        }

        public ActionResult TestJq()
        {
            return View();
        }

        public ActionResult roles()
        {
            return View();
        }

        public JsonResult RoleList(int pageIndex = 1, int pageSize = 10,string keyword="")
        {
            int totalCount = 0;
            var rolelist = Utility.PermissionSvc.GetPagedRoleList(pageIndex, pageSize, keyword, out totalCount);
            return Json(new { data = rolelist, count = totalCount });
        }

        public JsonResult SavePermission(IList<PermissionReRoleModule> tree,int roleid)
        {
            var result = Utility.PermissionSvc.SaveReRoleAndModule(tree, roleid);
            return Json(new { id=result});
        }

        public JsonResult GetByModuleAndRole(int roleid,int moduleid)
        {
            var data = Utility.PermissionSvc.GetByModuleAndRole(roleid, moduleid);
            return Json(data);
        }

        /// <summary>
        /// 设置角色对应的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetReRoleModule(int id)
        {
            var role = Utility.PermissionSvc.GetRoleById(id);
            if(null==role)
            {
                throw new ArgumentException("id");
            }
            ReRoleModuleModel model = new ReRoleModuleModel {
             Role=role,
             OptCodeEnum = Utility.EnumToDict(typeof(PageOperation)),
             OptScopeEnum=Utility.EnumToDict(typeof(OperationScope))
            };
            return View(model);
        }

        public JsonResult ModuleManager(PermissionModule module)
        {
            var result= Utility.PermissionSvc.AddOrUpdateModules(module);
            return Json(new { id=result});
        }

        

        [HttpPost]
        public JsonResult getmodule(int id)
        {
            var permission = Utility.PermissionSvc.Get(id);
            if (null == permission)
            {
                throw new ArgumentException("id");
            }
            return Json(permission);
        }

        public JsonResult ModuleChildrenJson()
        {
            var parentId = Request["root"].ConvertTo<int>(0);
            //var factory = new ChannelFactory<IPermission>("basicHttpBinding_IPermission");
            //IPermission permissionsvc = factory.CreateChannel();
            var data = Utility.PermissionSvc.GetChildByParentId(parentId);
            //var data = Common.PermissionSvc.AllModules(parentId);
            //var returndata = from m in data select new { id = m.Id, text = m.Name, children = m.HasChild };
            return Json(data, JsonRequestBehavior.AllowGet);

            //return Json();
        }

        private dynamic getjson(PermissionModule m)
        {
            //if (m.HasChild)
            //{
            //    return getlist(m);
            //}
            return false;
        }

        private IList<dynamic> getlist(PermissionModule m)
        {
            //if (m.HasChild)
            //{
            //    var childModule= Utility.PermissionSvc.GetChildByParentId(m.Id);
            //    if (null != childModule && childModule.Any())
            //    {
            //        return childModule.Select(p => new{ id = p.Id, text = p.Name, children = getjson(p) }).ToList<dynamic>();   
            //    }
            //}
            return null;
        }

        public JsonResult ModuleChildren()
        {
            var parentId = Request["root"].ConvertTo<int>(0);
            //var factory = new ChannelFactory<IPermission>("basicHttpBinding_IPermission");
            //IPermission permissionsvc = factory.CreateChannel();
            var data = Utility.PermissionSvc.GetChildByParentId(parentId);
            //var data = Common.PermissionSvc.AllModules(parentId);
            return Json(data, JsonRequestBehavior.AllowGet);
            
            //return Json();
        }

        public JsonResult ModulesTree(IList<PermissionModule> tree)
        {
            var result = Utility.PermissionSvc.ModulesManager(tree);
            return Json(new { ret = result });
        }

        public ActionResult Modules()
        {
            var data = Utility.EnumToDict(typeof(PageOperation));
            return View(data);
        }
	}
}