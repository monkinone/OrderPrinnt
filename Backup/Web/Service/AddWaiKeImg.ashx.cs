using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// AddWaiKeImg 的摘要说明
    /// </summary>
    public class AddWaiKeImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation = context.Request["opr"] + "";
            switch (operation)
            {
                case "isExistWaike":// 判断外壳编号是否存在
                    isExistWaike(context);
                    break;
                
            }
        }
        /// 判断外壳编号是否存在
        public void isExistWaike(HttpContext context)
        {
            int num = 0;
            string waikeNo = context.Request["waikeNo"];
            WaiKeImgMOD mod = WaiKeImgBLL.GetmodByid(waikeNo);
            if (mod != null)
            {
                num = 1;
            }
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