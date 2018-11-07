using lyq.Mvc.Filter;
using System.Web.Mvc;

namespace lyq.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilterAttribute());
            filters.Add(new AuthorizeFilterAttribute());
            filters.Add(new JsonFilterAttribute());
        }
    }
}
