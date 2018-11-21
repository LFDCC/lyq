using lyq.Infrastructure.Web;
using lyq.Mvc.Filter;
using System;
using System.Web.Mvc;

namespace lyq.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AuthorizeFilter(Roles = "111")]
        public ActionResult Success()
        {
            return Json(new HttpResult { data = "Success", msg = "成功啦", status = ResultState.success }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Fail()
        {
            return Json(new HttpResult { data = "Fail", msg = "失败啦", status = ResultState.fail }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Error()
        {
            throw new Exception("出错啦");
            return Json(new HttpResult { data = "Error", msg = "出错啦", status = ResultState.error }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult TimeOut()
        {
            return Json(new HttpResult { data = "TimeOut", msg = "清除cookie重试", status = ResultState.success }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [AuthorizeFilter(Roles = "9999")]
        public ActionResult UnRight()
        {
            return Json(new HttpResult { data = "UnRight", msg = "无权访问", status = ResultState.success }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}