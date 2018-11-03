using lyq.Dto;
using lyq.Infrastructure.Log;
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
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public ILogger logger { get; set; }

        public ILogService logService { get; set; }

        Stopwatch stopWatch = new Stopwatch();

        public LogFilterAttribute()
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

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}