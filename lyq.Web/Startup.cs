using lyq.Infrastructure.Mapping;
using lyq.Infrastructure.Ioc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(lyq.Web.Startup))]

namespace lyq.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            // 使应用程序可以使用 Cookie 来存储已登录用户的信息
            // 并使用 Cookie 来临时存储有关使用第三方登录提供程序登录的用户的信息
            // 配置登录 Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "lyq.Cookie",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            AutoMapConfig.RegisterMapper();
            AutoFacConfig.RegisterContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
