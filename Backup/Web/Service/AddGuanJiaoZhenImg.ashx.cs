using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// AddGuanJiaoZhenImg 的摘要说明
    /// </summary>
    public class AddGuanJiaoZhenImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation = context.Request["opr"] + "";
            switch (operation)
            {
                case "isExistGuanjiaozhen"://判断管脚针型号是否存在
                    isExistGuanjiaozhen(context);
                    break;
              
            }
        }
        
        /// 判断管脚针型号是否存在


        public void isExistGuanjiaozhen(HttpContext context)
        {
            int num = 0;
            string guanjiaozhenNo = context.Request["guanjiaozhenNo"];
            GuanJiaoZhenImgMOD mod = GuanJiaoZhenImgBLL.GetmodByid(guanjiaozhenNo);
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