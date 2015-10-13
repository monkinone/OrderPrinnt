using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using System.Text;
using System.Collections;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Redirect("/login.aspx");
            return null;
        }

        public ActionResult KeepAlive()
        {
            return Content("ok");
        }
    }
}
