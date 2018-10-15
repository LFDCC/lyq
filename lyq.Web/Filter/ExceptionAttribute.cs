using lyq.Infrastructure.Web;
using System.Web.Mvc;

namespace lyq.Web.Filter
{
    public class ExceptionAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {//ajax异常处理
                filterContext.Result =new JsonNetResult { Data = new HttpResult{ status = ResultState.error, msg = filterContext.Exception.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}