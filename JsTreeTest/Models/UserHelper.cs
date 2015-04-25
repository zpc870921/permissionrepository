using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace JsTreeTest.Models
{
    public class UserHelper
    {
        public static User CurrentUser(int id = 0)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
            }
            User currentUser = null;
            if (id != 0)
            {
                currentUser = Utility.PermissionSvc.GetById(id);
                return currentUser;
            }

            int userId=0;
            if (int.TryParse(HttpContext.Current.User.Identity.Name, out userId)&&userId!=0)
            {
                currentUser = Utility.PermissionSvc.GetById(userId);
            }
            
            return currentUser;
        }
    }
}