using lyq.Infrastructure.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lyq.Web.Controllers
{
    public class ControllerBase : Controller
    {
        public JsonResult Json()
        {
            return new JsonNetResult();
        }
    }
}