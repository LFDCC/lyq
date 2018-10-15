using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lyq.Web.Filter
{
    public class MvcAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var headers = filterContext.HttpContext.Request.Headers;
                string token = headers["token"];
                if (!string.IsNullOrWhiteSpace(token))
                {

                }
                else
                {

                }
            }
            else
            {
                base.OnAuthorization(filterContext);
            }

        }
    }
}