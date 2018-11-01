using lyq.Dto;
using lyq.Infrastructure.Extension;
using lyq.Infrastructure.Ioc;
using lyq.Infrastructure.Log;
using lyq.Infrastructure.Web;
using lyq.IService;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace lyq.Mvc.Filter
{
    public class ExceptionFilterAttribute : HandleErrorAttribute
    {
        ILogger logger = AutoFacMvcConfig.Resolve<ILogger>();

        ILogService logService = AutoFacMvcConfig.Resolve<ILogService>();

        public override void OnException(ExceptionContext filterContext)
        {
            var stackTrace = filterContext.Exception.StackTrace;
            var message = filterContext.Exception.Message;
            var method = filterContext.HttpContext.Request.HttpMethod;
            var requestUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;

            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var client = filterContext.HttpContext.Request.UserAgent;
            var query = filterContext.HttpContext.Request.Url.Query;
            var form = string.Join("&", filterContext.HttpContext.Request.Form.AllKeys.Select(t => $"{t}={filterContext.HttpContext.Request.Form[t]}"));

            logService.AddAsync(new LogErrorDto
            {
                RequestUrl = requestUrl,
                Message = message,
                Method = method,
                Query = query,
                Form = form,
                IP = ip,
                Client = client,
                CreateUserId = filterContext.HttpContext.User.Identity.Name.As<int>()
            });

            logger.Error($"异常描述：{message}\r\n 堆栈信息：{stackTrace}");


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