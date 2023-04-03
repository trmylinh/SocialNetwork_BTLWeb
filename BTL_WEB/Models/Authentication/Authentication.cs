using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTL_WEB.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("email") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller", "LoginRegis" },
                    {"Action", "Login" }
                });
            }

        }

    }
}
