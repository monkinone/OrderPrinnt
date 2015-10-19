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
    /// AddGuigeshu 的摘要说明
    /// </summary>
    public class AddGuigeshu : IHttpHandler
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
                case "isExistGuigeshu"://判断产品型号规格书是否已上传
                    isExistGuigeshu(context);
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

        
        /// <summary>
        /// 判断产品型号规格书是否已上传
        /// </summary>
        /// <param name="context"></param>
        public void isExistGuigeshu(HttpContext context)
        {
            int num = 0;
            string proType = context.Request["proType"];
            GuiGeShuMOD mod = GuiGeShuBLL.GetmodByid(proType);
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