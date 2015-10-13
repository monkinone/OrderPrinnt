using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// Customer 的摘要说明
    /// </summary>
    public class Customer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation=context.Request["opr"]+"";
            switch (operation)
            {
                case "isExistCustom"://判断客户编号是否存在
                  isExistCustom(context);
                  break;
                case "isExistCusName"://判断客户公司名称是否存在
                  isExistCusName(context);
                  break;             
            }
        }

        /// <summary>
        /// 判断客户编号是否存在
        /// </summary>
        public void isExistCustom(HttpContext context)
        {
            int num = 0;
            string customerNum = context.Request["customerNum"];
            CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customerNum);
            if (mod != null)
            {
                num = 1;
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 判断客户公司名称是否存在
        /// </summary>
        /// <returns></returns>
        public void isExistCusName(HttpContext context)
        {
            int num = 0;
            string companyName = context.Request["companyName"];
            CustomerManageMod mod = CustomerManageBLL.GetcustomerByName(companyName);
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