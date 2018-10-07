using lyq.IService;
using System.Threading.Tasks;
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
            int result=await userService.Add();

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
