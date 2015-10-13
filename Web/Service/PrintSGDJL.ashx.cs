using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderPrintSystem.BLL;

namespace Web.Service
{
    /// <summary>
    /// PrintSGDJL 的摘要说明
    /// </summary>
    public class PrintSGDJL : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation = context.Request["opr"];
            switch (operation)
            {
                case "UpdatePrint"://修改打印次数及时间
                    UpdatePrint(context);
                    break;
            }
        }
        /// <summary>
        /// 修改打印次数及时间
        /// </summary>
        public void UpdatePrint(HttpContext context)
        {
            int num = 0;
            string orderNum = context.Request["orderNum"] + "";
            string proType = context.Request["proType"] + "";
            num = ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printQLDTime", "printQLDCount");
            context.Response.Write("{\"d\":" + num + "}");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}