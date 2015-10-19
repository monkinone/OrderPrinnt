using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// AddBiaoShiImage 的摘要说明
    /// </summary>
    public class AddBiaoShiImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation=context.Request["opr"];
            switch (operation)
            {
                case "isExistBiaoshi"://判断标识位置编号是否存在
                 isExistBiaoshi(context);
                 break;
            }
        }

        /// <summary>
        /// 判断标识位置编号是否存在
        /// </summary>
        public void isExistBiaoshi(HttpContext context)
        {
            int num = 0;
            string biaoshiNo = context.Request["biaoshiNo"]+"";
            BiaoShiImgMOD mod = BiaoShiImgBLL.GetmodByid(biaoshiNo);
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