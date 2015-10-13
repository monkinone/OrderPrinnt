using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace OrderPrintWeb.orderManage
{
    public partial class PrintFaHuoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string txtcompanyName = Request.QueryString["txtcompanyName"]+"";
                string txtproType = Request.QueryString["txtproType"]+"";
                string txtOrderNum = Request.QueryString["txtOrderNum"]+"";
                string ddlOrderType = Request.QueryString["ddlOrderType"]+"";
                string _pageSize = Request.QueryString["pageSize"]+"";
                string _pageIndex = Request.QueryString["pageIndex"]+"";

                int pageSize = 12;
                int pageIndex = 1;
                if (!int.TryParse(_pageSize, out pageSize)) { pageSize = 12; }
                if (!int.TryParse(_pageIndex, out pageIndex)) { pageIndex = 1; }
                //查询条件
                string strWhere="";
                if (txtproType.Trim() != "")
                {
                    strWhere += " and proType like '%" + txtproType.Trim() + "%'";
                }
                if (txtcompanyName.Trim() != "")
                {
                    strWhere += " and companyName like '%" + txtcompanyName.Trim() + "%'";
                }
                if (ddlOrderType!=""&& ddlOrderType != "0")
                {
                    if (ddlOrderType == "1")
                    {
                        strWhere += " and SendCount>=proNum ";
                    }
                    else
                    {
                        strWhere += " and SendCount<proNum ";
                    }
                }
                if (txtOrderNum.Trim()!="")
                {
                    strWhere += string.Format(" and orderNum like '%{0}%' ", txtOrderNum);
                }

                LoadDataBind(pageSize,pageIndex,strWhere);
            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="strWhere"></param>
        protected void LoadDataBind(int pageSize,int pageIndex,string strWhere)
        {
            try
            {
                DataSet ds = new DataSet();
                int PageCount;
                ds = ProOrdersDetailBLL.GetAllProductSendList(pageSize,pageIndex,out PageCount,strWhere);
                if (ds != null)
                {

                    rpt_userinfo.DataSource = ds;
                    rpt_userinfo.DataBind();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取当前型号发货总量
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="proType"></param>
        /// <returns></returns>
        public string GetSendCount(string orderNum, string proType)
        {
            return ProOrdersDetailBLL.GetProSendCount(orderNum, proType).ToString();
        }
        public string GetLastSendCount(string orderNum, string proType)
        {
            string count = "";
            DataSet ds = SendDetailBLL.GetmodAll(" and orderNum='" + orderNum + "' and proType='" + proType + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                count = ds.Tables[0].Rows[0]["sendProNum"].ToString();
            }
            return count;
        }
        public string GetLastSendTime(string orderNum, string proType)
        {
            string time = "";
            DataSet ds = SendDetailBLL.GetmodAll(" and orderNum='" + orderNum + "' and proType='" + proType + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                time = Convert.ToDateTime(ds.Tables[0].Rows[0]["sendTime"]).ToString("yyyy-MM-dd");
            }
            return time;
        }
        /// <summary>
        /// 包装明细
        /// </summary>
        /// <param name="proType"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public string GetBZ(string proType, string totalCount)
        {
            string detail = "";
            ProductsMOD MOD = ProductsBLL.GetModel(proType);
            if (MOD != null)
            {
                string nei = MOD.NeiBZ;
                string wai = MOD.waiBZ.ToString();

                detail = "内包装" + nei + "/pcs,外包装：" + wai + "/盒";
            }
            return detail;
        }
        public string Jianshu(string orderNum, string proType)
        {
            int neiCount = 0;
            int waiCount = 0;
            int totalCount = 0;
            string result = "";// ProOrdersDetailBLL.GetProSendCount(orderNum, proType).ToString();
            DataSet ds = SendDetailBLL.GetmodAll(" and orderNum='" + orderNum + "' and proType='" + proType + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0]["sendProNum"].ToString();
            }
            if (result != "")
            {
                totalCount = Convert.ToInt32(result);
            }
            if (totalCount > 0)
            {
                ProductsMOD MOD = ProductsBLL.GetModel(proType);
                if (MOD != null)
                {
                    string nei = MOD.NeiBZ;
                    string wai = MOD.waiBZ.ToString();
                    if (nei != "0")
                    {
                        if (Convert.ToInt32(totalCount) % Convert.ToInt32(nei) == 0)
                        {
                            neiCount = Convert.ToInt32(totalCount) / Convert.ToInt32(nei);
                        }
                        else
                        {
                            neiCount = (Convert.ToInt32(totalCount) / Convert.ToInt32(nei)) + 1;

                        }
                    }
                    if (wai != "0")
                    {
                        if (neiCount % Convert.ToInt32(wai) == 0)
                        {
                            waiCount = neiCount / Convert.ToInt32(wai);
                        }
                        else
                        {
                            waiCount = (neiCount / Convert.ToInt32(wai)) + 1;
                        }
                    }
                }
            }
            return waiCount.ToString();
        }
        public string GetSendNum(string orderNum)
        {
            string sendNum = "";
            SendDetailMOD mod = SendDetailBLL.GetModByOrderNum(orderNum);
            if (mod != null)
            {
                sendNum = mod.SendNum;
            }
            return sendNum;
        }
        public string GetHuoyunCom(string orderNum)
        {
            string name = "";
            SendDetailMOD mod = SendDetailBLL.GetModByOrderNum(orderNum);
            if (mod != null)
            {
                name = mod.PackingCompanyName;
            }
            return name;
        }
    }
}