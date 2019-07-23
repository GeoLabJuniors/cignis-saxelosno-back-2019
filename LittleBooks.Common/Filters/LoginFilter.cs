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
            LoginModel user = (LoginModel)filterContext.HttpContext.Session["LogedUser"];
            if (user != null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {{ "Controller", "Admin"},
                        { "Action" , "Index"}
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}