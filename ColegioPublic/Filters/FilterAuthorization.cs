using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ColegioPublic.Filters
{
    public class FilterAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            /// user is logged in (the "loggedIn" should be set in Login action upon a successful login request)
            //if (session["loggedIn"] != null && (bool)session["loggedIn"])
            //    return;

            ///// if the request is ajax then we return a json object
            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    filterContext.Result = new JsonResult
            //    {
            //        Data = "UnauthorizedAccess",
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //    };
            //}
            var controllername = filterContext.Controller.ControllerContext.RouteData.Values["controller"];
            var action = filterContext.Controller.ControllerContext.RouteData.Values["action"];
            if(controllername.Equals("Login"))
            {
                return;
            }

            if (!session.IsLogin())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
            var filter = filterContext;
       
        }


    }
}