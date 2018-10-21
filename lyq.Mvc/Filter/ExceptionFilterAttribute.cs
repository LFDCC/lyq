using lyq.Dto;
using lyq.Infrastructure.Ioc;
using lyq.Infrastructure.Log;
using lyq.Infrastructure.Web;
using lyq.IService;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Linq;

namespace lyq.Mvc.Filter
{
    public class ExceptionFilterAttribute : HandleErrorAttribute
    {
        ILogger logger = AutoFacConfig.Resolve<ILogger>();

        ILogService logService = AutoFacConfig.Resolve<ILogService>();

        public override void OnException(ExceptionContext filterContext)
        {
            var message = filterContext.Exception.Message;
            var query = filterContext.HttpContext.Request.Url.Query;
            var method = filterContext.HttpContext.Request.HttpMethod;
            var requestUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var form =string.Join("&",filterContext.HttpContext.Request.Form.AllKeys.Select(t => $"{t}={filterContext.HttpContext.Request.Form[t]}"));


            logService.AddAsync(new LogDto
            {
                Level = 1,
                ControllerName = controller,
                ActionName = action,
                Message = message,
                Method = method,
                RequestUrl = requestUrl,
                Query = query,
                Form = form,
                CreateUserId = filterContext.HttpContext.User.Identity.Name.As<int>()
            });

            logger.Error($"控制器：{controller}，Action：{action}，error：{message}");


            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {//ajax异常处理
                filterContext.Result = new JsonNetResult { Data = new HttpResult { status = ResultState.error, msg = filterContext.Exception.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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