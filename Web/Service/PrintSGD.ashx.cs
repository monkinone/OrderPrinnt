using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;

namespace Web.Service
{
    /// <summary>
    /// PrintSGD 的摘要说明
    /// </summary>
    public class PrintSGD : IHttpHandler
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
                case "UpdatePrintCount"://修改打印数量
                    UpdatePrintCount(context);
                    break;
                case "AddSuigongdan"://添加随工单
                    AddSuigongdan(context);
                    break;
            }
        }
        /// <summary>
        /// 修改打印次数及时间
        /// </summary>
        private void UpdatePrint(HttpContext context)
        {
            int num = 0;
            string orderNum = context.Request["orderNum"] + "";
            string proType = context.Request["proType"] + "";
            num = ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printQLDTime", "printQLDCount");
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 修改打印数量
        /// </summary>
        public void UpdatePrintCount(HttpContext context)
        {
            int count = 0;
            int num = 0;
            string proNum = context.Request["proNum"] + "";
            string orderNum = context.Request["orderNum"] + "";
            string proType = context.Request["proType"] + "";
            if (proNum != "")
            {
                count = Convert.ToInt32(proNum);
                PrintSGDCountMOD mod = PrintSGDCountBLL.GetmodByid(orderNum, proType);
                if (mod != null)
                {
                    if (mod.PrintCount.ToString() != "")
                    {
                        mod.PrintCount = mod.PrintCount + count;
                    }
                    else
                    {
                        mod.PrintCount = count;
                    }
                    mod.OrderNum = orderNum;
                    mod.ProType = proType;
                    num= PrintSGDCountBLL.Updatemod(mod);
                }
                else
                {
                    mod = new PrintSGDCountMOD();
                    mod.PrintCount = count;
                    mod.OrderNum = orderNum;
                    mod.ProType = proType;
                    num = PrintSGDCountBLL.Insertmod(mod);
                }
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 添加随工单
        /// </summary>
        public void AddSuigongdan(HttpContext context)
        {
            int num = 0;
            string orderNum = context.Request["orderNum"] + "";
            string proType = context.Request["proType"] + "";
            string customNum = context.Request["customNum"] + "";
            string suigongdan = context.Request["suigongdan"] + "";
            string proNum = context.Request["proNum"]+"";
            SGDRecordMOD mod = new SGDRecordMOD() { 
                    OrderNum = orderNum,
                    ProType = proType,
                    CustomerNum = customNum,
                    Suigongdan = suigongdan,
                    PrintCount = proNum
            };
            num = SGDRecordBLL.Insertmod(mod);
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