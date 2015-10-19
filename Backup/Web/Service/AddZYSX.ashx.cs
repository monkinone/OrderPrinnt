using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <summary>
    /// AddZYSX 的摘要说明
    /// </summary>
    public class AddZYSX : IHttpHandler
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
                case "isExistCustomZYSX"://
                    isExistCustomZYSX(context);
                    break;
            }
        }

        /// 判断客户编号是否存在

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

      //
        public void isExistCustomZYSX(HttpContext context)
        {
            int num = 0;
            string customerNum = context.Request["customerNum"];
            MattersNeedingAttentionMOD mod = MattersNeedingAttentionBLL.GetmodByid(customerNum);
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