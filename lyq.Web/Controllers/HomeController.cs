using lyq.Common.Encrypt;
using lyq.Dto;
using lyq.IService;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace lyq.Web.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;
        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task<ActionResult> Index()
        {
            int result = await userService.AddAsync();

            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoginAsync(string username, string password, string returnUrl)
        {

            if (!Request.IsAjaxRequest())
            {
                return View();
            }
            password = MD5.Encrypt(password).ToUpper();
            UserDto user = await userService.GetUserAsync(username);
            if (user == null)
            {
                return Json(new { status = HttpResult.fail, message = "用户名不存在！" });
            }
            else
            {
                user = await userService.GetUserAsync(username, password);
                if (user == null)
                {
                    return Json(new { status = HttpResult.fail, message = "密码错误！" });
                }
                else
                {
                    var identity = new ClaimsIdentity(new List<Claim> {
                        new Claim(ClaimTypes.Name, user.ToJson()),
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                         new Claim(ClaimTypes.Role, "admin")
                    }, DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(identity);

                    return Json(new { status = HttpResult.success, jumpUrl = returnUrl ?? "/Claim/Index" });
                }
            }

        }

        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
