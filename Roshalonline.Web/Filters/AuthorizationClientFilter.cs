using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roshalonline.Web.Models;
using Roshalonline.Logic.Interfaces;

namespace Roshalonline.Web.Filters
{
    public class AuthorizationClientFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var role = filterContext.HttpContext.User.Identity.Name.Split('|')[1];
            if (role == "Administrator")
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Home" }, { "action", "Login" }
                });
            }
        }
    }
}