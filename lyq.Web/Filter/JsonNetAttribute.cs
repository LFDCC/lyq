using lyq.Infrastructure.Web;
using System.Web.Mvc;

namespace lyq.Web.Filter
{
    public class JsonNetAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is JsonResult && !(filterContext.Result is JsonNetResult))
            {
                JsonResult jsonResult = (JsonResult)filterContext.Result;
                JsonNetResult jsonNetResult = new JsonNetResult
                {
                    ContentEncoding = jsonResult.ContentEncoding,
                    ContentType = jsonResult.ContentType,
                    Data = jsonResult.Data,
                    JsonRequestBehavior = jsonResult.JsonRequestBehavior,
                    MaxJsonLength = jsonResult.MaxJsonLength,
                    RecursionLimit = jsonResult.RecursionLimit
                };
                filterContext.Result = jsonNetResult;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}