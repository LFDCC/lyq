using lyq.Dto;
using lyq.Infrastructure.Extension;
using lyq.Infrastructure.Tools.Images;
using lyq.Infrastructure.Web;
using lyq.IService;
using lyq.Mvc.Filter;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace lyq.Web.Controllers
{
    [AllowAnonymous]

    public class AccountController : Controller
    {
        IUserService userService;
        public AccountController(IUserService _userService)
        {
            userService = _userService;
        }
        public ActionResult Login(string ReturnUrl)
        {
            ViewData["returnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [LogFilter(IntoDb = false)]
        public async Task<ActionResult> Login(string username, string password, string checkcode, string returnUrl)
        {
            throw new Exception("出错啦");
            string sessionCode = Session["checkcode"]?.ToString();
            if (sessionCode == null)
            {
                return Json(new HttpResult { status = ResultState.fail, msg = "验证码过期，请刷新！" });
            }
            else if (sessionCode.ToLower() != checkcode.ToLower())
            {
                return Json(new HttpResult { status = ResultState.fail, msg = "验证码错误！" });
            }
            else
            {
                password = password.ToMd5().ToUpper();
                UserDto user = await userService.GetUserAsync(username: username);
                if (user == null)
                {
                    return Json(new HttpResult { status = ResultState.fail, msg = "用户名不存在！" });
                }
                else
                {
                    user = await userService.GetUserAsync(username, password);
                    if (user == null)
                    {
                        return Json(new HttpResult { status = ResultState.fail, msg = "密码错误！" });
                    }
                    else
                    {
                        var identity = new ClaimsIdentity(new List<Claim> {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.MobilePhone,user.Phone),
                        new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                    }, CookieAuthenticationDefaults.AuthenticationType);

                        HttpContext.GetOwinContext().Authentication.SignIn(identity);

                        return Json(new HttpResult { status = ResultState.success, data = returnUrl.IsNullOrWhiteSpace() ? "/Home/Index" : returnUrl });
                    }
                }
            }

        }
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return RedirectToAction("Login");
        }
        public ActionResult GetCheckCode()
        {
            VerificationCode vh = new VerificationCode();
            string code = vh.GetRandomNumberString(4);
            Session["checkcode"] = code;
            byte[] img = vh.CreateImage(code);
            return File(img, "image/jpeg");
        }
    }
}