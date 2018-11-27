using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Errors_Handler
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorize : System.Web.Mvc.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult(403);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}