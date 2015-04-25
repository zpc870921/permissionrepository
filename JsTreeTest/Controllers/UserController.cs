using JsTreeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JsTreeTest.Models.Enum;
using EFFrameTest2.Model;
using EFFrameTest2.Model.Utils;
using JsTreeTest.Models.VO;
using EFFrameTest2.Model.Entites;
using EFFrameTest2.Model.DTO;
using EFFrameTest2.Model.Enum;

namespace JsTreeTest.Controllers
{
    public class UserController:Controller
    {

        [Authorize]
        [HttpGet]
        public ActionResult Add(int id=0)
        {
            User user=null;
            if(id>0)
            {
                user= Utility.PermissionSvc.GetById(id);
            }
            UserVO vo = new UserVO {
            User=user,
            RoleList = Utility.PermissionSvc.GetAllRole()
            };
            return View(vo);
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            string rolelist = Request["rolelist"].ConvertTo<string>("");
            if(String.IsNullOrWhiteSpace(rolelist))
            {
                return View(user);
            }
            IList<string> roleList=rolelist.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
            IList<UserReRole> roleIdList =
                roleList.Select(r => new UserReRole { RoleId = int.Parse(r) }).ToList();
                //(from r in rolelist select new UserReRole{ RoleId= Convert.ToInt32(r)}).ToList();
            user.CreateTime = DateTime.Now;
            user.UpdateTime = DateTime.Now;
            user.Status = (int)UserStatus.Normal;
            user.CompanyId = 1;
            user.Password = "123456".Md5();
            var userdto = new UserDTO {
             User=user,
             RoleList = roleIdList
            };
            int result= Utility.PermissionSvc.AddOrUpdateUser(userdto); 
            if(result>0)
            {
                return RedirectToAction("list");
            }
            return View(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListJson(int pageIndex,int pageSize,string keyword="")
        {
            int totalCount=0;
            var data = Utility.PermissionSvc.GetPagedUserList(pageIndex, pageSize, keyword, out totalCount);
            return Json(new { data = data ,count=totalCount});
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = Utility.PermissionSvc.GetByNameAndPwd(username, password.Md5());
            if (null == user)
            {
                ViewBag.errmsg = "用户名或密码错误";
                return View();
            }

            FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
            return RedirectToAction("index","system");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("login");
        }
    }
}