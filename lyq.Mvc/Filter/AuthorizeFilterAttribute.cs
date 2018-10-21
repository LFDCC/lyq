using lyq.Infrastructure.Web;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;

namespace lyq.Mvc.Filter
{
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {
        public char[] _splitParameter = new char[1] { ',' };

        private string[] _rolesSplit
        {
            get
            {
                return SplitString(Roles);
            }
        }

        private string[] _usersSplit
        {
            get
            {
                return SplitString(Users);
            }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    IPrincipal user = filterContext.HttpContext.User;
                    if (!user.Identity.IsAuthenticated)
                    {
                        filterContext.Result = new JsonNetResult { Data = new HttpResult { status = ResultState.timeout, data = CookieAuthenticationDefaults.LoginPath, msg = "请求超时" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        if (_usersSplit.Length != 0 && !_usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                        {
                            filterContext.Result = new JsonNetResult { Data = new HttpResult { status = ResultState.unright, msg = "没权限访问" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                        }
                        else if (_rolesSplit.Length != 0)
                        {
                            string[] rolesSplit = _rolesSplit;
                            IPrincipal principal = user;
                            if (!rolesSplit.Any(principal.IsInRole))
                            {
                                filterContext.Result = new JsonNetResult { Data = new HttpResult { status = ResultState.unright, msg = "没权限访问" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                            }
                        }
                    }
                }
                else
                {
                    base.OnAuthorization(filterContext);
                }
            }
        }

        private string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return new string[0];
            }
            return (from piece in original.Split(_splitParameter)
                    let trimmed = piece.Trim()
                    where !string.IsNullOrEmpty(trimmed)
                    select trimmed).ToArray();
        }


    }
}