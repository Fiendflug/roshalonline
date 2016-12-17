using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Roshalonline.Web.Filters
{
    public class AuthenticationAdminFilter : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var currUser = filterContext.HttpContext.User;
            if (currUser == null || !currUser.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Management" }, { "action", "Login"} }
                );
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var currUser = filterContext.HttpContext.User;
            if (currUser == null || !currUser.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Management" }, { "action", "Login"} }
                );
            }
        }
    }
}