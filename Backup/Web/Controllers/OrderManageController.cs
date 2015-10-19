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
    public class OrderManageController : Controller
    {
        public ActionResult PrintBZBQ(string orderNum, string customNum)
        {
            ViewBag.orderNum = orderNum;
            ViewBag.customNum = customNum;
            if (Session["songhuodan"] == null || Session["songhuodan"].ToString() != "1")
            {
                return Content("未打印送货单，不能打印标签！");
            }
            else
            {
                Session["songhuodan"] = null;
            }
            return View();
        }
    }
}
