using lyq.Infrastructure.Extension;
using lyq.Infrastructure.Log;
using lyq.Infrastructure.Web;
using lyq.IService;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace lyq.Mvc.Filter
{
    /// <summary>
    /// 登录日志
    /// </summary>
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        public ILogger logger { get; set; }

        public ILogService logService { get; set; }

        Stopwatch stopWatch = new Stopwatch();

        public LoginFilterAttribute()
        {
            stopWatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var method = filterContext.HttpContext.Request.HttpMethod;
            var requestUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
            var query = filterContext.HttpContext.Request.Url.Query;
            var form = string.Join("&", filterContext.HttpContext.Request.Form.AllKeys.Select(t => $"{t}={filterContext.HttpContext.Request.Form[t]}"));
            if (filterContext.Result is JsonResult || filterContext.Result is JsonNetResult)
            {
                JsonResult jsonResult = filterContext.Result.As<JsonResult>();
                HttpResult httpResult = jsonResult.Data.As<HttpResult>();
                if (httpResult.status == ResultState.success)
                {

                }
                else
                {

                }
            }
            //var flag = filterContext.ActionDescriptor.IsDefined(typeof(LogFilterAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(LogFilterAttribute), true);
            //if (flag)
            //{
            //    var method = filterContext.HttpContext.Request.HttpMethod;
            //    var requestUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
            //    var controller = filterContext.RouteData.Values["controller"].ToString();
            //    var action = filterContext.RouteData.Values["action"].ToString();
            //    var query = filterContext.HttpContext.Request.Url.Query;
            //    var form = string.Join("&", filterContext.HttpContext.Request.Form.AllKeys.Select(t => $"{t}={filterContext.HttpContext.Request.Form[t]}"));

            //    stopWatch.Stop();

            //    //logService.AddLoginLogAsync(new LoginLogDto
            //    //{
            //    //    Message = $"用时：{stopWatch.Elapsed.TotalMilliseconds}ms",
            //    //    Method = method,
            //    //    RequestUrl = requestUrl,
            //    //    Query = query,
            //    //    Form = form
            //    //});

            //    logger.Info($"控制器：{controller}，Action：{action}，query：{query}，form：{form}，times：{stopWatch.Elapsed.TotalMilliseconds}ms");
            //}
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 客户端IP
        /// </summary>
        /// <returns></returns>
        private static string ClientIP(ExceptionContext filterContext)
        {
            string result = filterContext.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == string.Empty)
            {
                result = filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == string.Empty)
            {
                result = filterContext.HttpContext.Request.UserHostAddress;
            }
            return result;
        }
    }
}