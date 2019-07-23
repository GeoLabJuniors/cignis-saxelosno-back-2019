using LittleBooks.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace LittleBooks.Common.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoginModel user = (LoginModel)filterContext.HttpContext.Session["LoggedUser"];
            if (user != null)
            {
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if ( controllerName != "Admin")
                {
                    filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {{ "Controller", "Admin"},
                                        { "Action" , "Index"}
                                       });
                }

            }
            else
            {
                var actionName = filterContext.ActionDescriptor.ActionName;
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (!(actionName == "Login" && controllerName == "Account"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {{ "Controller", "Account"},
                        { "Action" , "Login"}
                        });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}