using lyq.Common;
using lyq.Common.Encrypt;
using lyq.Common.Images;
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
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {

        IUserService userService;
        public AccountController(IUserService _userService)
        {
            userService = _userService;
        }
        public ActionResult Login(string ReturnUrl)
        {
            ViewData["returnUrl"] = ReturnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(string username, string password, string checkcode, string returnUrl)
        {
            string sessionCode = Session["checkcode"].ToString();
            if (sessionCode.ToLower() != checkcode.ToLower())
            {
                return Json(new { status = HttpResult.fail, message = "验证码错误！" });
            }
            else
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


                        return Json(new { status = HttpResult.success, jumpUrl = returnUrl ?? "/Home/Index" });
                    }
                }
            }

        }
        [Authorize]
        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
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