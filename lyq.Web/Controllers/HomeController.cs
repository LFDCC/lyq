using lyq.Common;
using lyq.Common.Encrypt;
using lyq.Common.Extension;
using lyq.Dto;
using lyq.IService;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace lyq.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        IUserService userService;
        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task<ActionResult> Index()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            foreach (var item in principal.Claims)
            {

            }
            /*
            var userDto = new UserDto
            {
                UserName = "liyanqi",
                RoleId = 222,
                RealName = "liyanqi",
                Phone = "18105207689",
                Password = "asdfasdf"
            };
            int result = await userService.AddAsync(userDto);

            ViewBag.Title = "Home Page";
            */

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoginAsync(string username, string password, string returnUrl)
        {
            password = MD5.Encrypt(password).ToUpper();
            UserDto user = await userService.GetUserAsync(username: username);
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
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.MobilePhone,user.Phone),
                        new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                    }, DefaultAuthenticationTypes.ApplicationCookie);
                    
                    HttpContext.GetOwinContext().Authentication.SignIn(identity);


                    return Json(new { status = HttpResult.success, jumpUrl = returnUrl ?? "/Claim/Index" });
                }
            }

        }

        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}
