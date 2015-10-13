using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// AddProduct 的摘要说明
    /// </summary>
    public class AddProduct : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation = context.Request["opr"] + "";
            switch (operation)
            {
                case "isExistProType"://判断产品型号是否存在
                    isExistProType(context);
                    break;             
            }
        }
        /// <summary>
        /// 判断产品型号是否存在
        /// </summary>
        /// <param name="context"></param>
        public void isExistProType(HttpContext context)
        {
            int num = 0;
            string proType = context.Request["proType"];
            ProductsMOD mod = ProductsBLL.GetModel(proType);
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