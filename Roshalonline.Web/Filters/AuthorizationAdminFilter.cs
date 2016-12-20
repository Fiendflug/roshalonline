using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roshalonline.Web.Filters
{
    public class AuthorizationAdminFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var role = filterContext.HttpContext.User.Identity.Name.Split('|')[1];
            if (role == "Client")
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Management" }, { "action", "Login" }
                });
            }
        }
    }
}