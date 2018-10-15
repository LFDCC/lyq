using lyq.Web.Filter;
using System.Web;
using System.Web.Mvc;

namespace lyq.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new JsonNetAttribute());
        }
    }
}
