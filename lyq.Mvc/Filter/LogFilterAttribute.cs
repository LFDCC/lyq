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
    /// 记录日志
    /// </summary>
    public class LogFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 是否记录到数据库
        /// </summary>
        public bool IntoDb { get; set; } = true;

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
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var flag = filterContext.ActionDescriptor.IsDefined(typeof(LogFilterAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(LogFilterAttribute), true);
            if (flag)
            {
                var method = filterContext.HttpContext.Request.HttpMethod;
                var requestUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
                var controller = filterContext.RouteData.Values["controller"].ToString();
                var action = filterContext.RouteData.Values["action"].ToString();
                var query = filterContext.HttpContext.Request.Url.Query;
                var form = string.Join("&", filterContext.HttpContext.Request.Form.AllKeys.Select(t => $"{t}={filterContext.HttpContext.Request.Form[t]}"));

                stopWatch.Stop();
                if (IntoDb)
                {
                    logService.AddAsync(new LogErrorDto
                    {
                        Message = $"用时：{stopWatch.Elapsed.TotalMilliseconds}ms",
                        Method = method,
                        RequestUrl = requestUrl,
                        Query = query,
                        Form = form,
                        CreateUserId = filterContext.HttpContext.User.Identity.Name.As<int>()
                    });
                }
                logger.Info($"控制器：{controller}，Action：{action}，query：{query}，form：{form}，times：{stopWatch.Elapsed.TotalMilliseconds}ms");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}