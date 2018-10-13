using lyq.IService;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}
