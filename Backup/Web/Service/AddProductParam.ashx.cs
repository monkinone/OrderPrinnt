using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// AddProductParam 的摘要说明
    /// </summary>
    public class AddProductParam : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation = context.Request["opr"] + "";
            switch (operation)
            {
                case "isExistCustom"://判断客户编号是否存在
                    isExistCustom(context);
                    break;
                case "isExistProType":// 判断产品型号是否存在
                    isExistProType(context);
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
        /// 判断产品型号是否存在

        public void isExistProType(HttpContext context)
        {
            int num = 0;
            string proType = context.Request["proType"];
            CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(proType);
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
