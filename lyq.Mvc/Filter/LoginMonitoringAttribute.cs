using lyq.Dto;
using lyq.Infrastructure.Extension;
using lyq.Infrastructure.Log;
using lyq.Infrastructure.Network;
using lyq.Infrastructure.Web;
using lyq.IService;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace lyq.Mvc.Filter
{
    /// <summary>
    /// 登录监控
    /// </summary>
    public class LoginMonitoringAttribute : ActionFilterAttribute
    {
        public ILogger logger { get; set; }

        public ILogService logService { get; set; }

        Stopwatch stopWatch = new Stopwatch();

        public LoginMonitoringAttribute()
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
            stopWatch.Stop();
            var method = filterContext.HttpContext.Request.HttpMethod;
            var requestUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
            var query = filterContext.HttpContext.Request.Url.Query;
            var form = string.Join("&", filterContext.HttpContext.Request.Form.AllKeys.Select(t => $"{t}={filterContext.HttpContext.Request.Form[t]}"));
            var client = filterContext.HttpContext.Request.UserAgent;
            var userName = filterContext.Controller.ViewData["UserName"];
            if (filterContext.Result is JsonResult || filterContext.Result is JsonNetResult)
            {
                JsonResult jsonResult = filterContext.Result.As<JsonResult>();
                HttpResult httpResult = jsonResult.Data.As<HttpResult>();

                logService.AddLoginLogAsync(new LoginLogDto
                {
                    ClientIP = Net.Ip,
                    ClientName = client,
                    IsSuccess = httpResult.status == ResultState.success,
                    Message = httpResult.msg,
                    UserName = userName.ToString(),
                    ElapsedTime = stopWatch.ElapsedMilliseconds
                });
                logger.Info($"用户名：{userName}；登录状态：{httpResult.msg}；登录耗时：{stopWatch.ElapsedMilliseconds}ms");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}