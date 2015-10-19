using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OrderPrintSystem.BLL;

namespace Web.Service
{
    /// <summary>
    /// PrintBZBQ 的摘要说明
    /// </summary>
    public class PrintBZBQ : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string operation = context.Request["opr"] + "";
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
            try
            {
                DataSet ds = SendDetailBLL.GetmodAll(" and orderNum='" + orderNum + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ProOrdersDetailBLL.UpdatePrintInfo(orderNum, ds.Tables[0].Rows[i]["proType"].ToString(), "printBZBQTime", "printBZBQCount");
                    }
                    num = 1;
                }
                else
                {
                    num = 0;
                }
            }
            catch (Exception ex)
            {
                num = 0;
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