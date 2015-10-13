using OrderPrintSystem.BLL;
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
    public partial class YeWuOrderList : System.Web.UI.Page
    {
        private string strWhere;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //隐藏订单详情
                //divOrderDetail.Visible = false;
                //加载订单信息
                LoadDataBind();

            }
        }

        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="strWhere"></param>
        protected void LoadDataBind()
        {
            try
            {
               
                if (txtCompanyName.Text.Trim() != "")
                {
                    strWhere += " and customNum like '%" + txtCompanyName.Text.Trim() + "%'";
                }
                if (txtWeiHuren.Text.Trim() != "")
                {
                    strWhere += " and customManager like '%" + txtWeiHuren.Text.Trim() + "%'";
                }
                DataSet ds = new DataSet();
                int PageCount;
                ds = ProOrdersBLL.GetUserAll(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
                if (ds != null)
                {
                    Pager_DocumentShare.RecordCount = PageCount;
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
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_DocumentShare_PageChanging(object sender, PageChangingEventArgs e)
        {
            Pager_DocumentShare.CurrentPageIndex = e.NewPageIndex;

            LoadDataBind();

        }
        /// <summary>
        ///订单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_userinfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            string orderNO = e.CommandArgument.ToString();
            ViewState["orderNo"] = orderNO;
            if (e.CommandName == "Detail")
            {
               // divOrderDetail.Visible = true;
               // LoadOrderDetail();
            }
           
        }

        ///// <summary>
        ///// 加载订单详情
        ///// </summary>
        //public void LoadOrderDetail()
        //{
        //    try
        //    {
        //        string strOrderDetail = " and orderNum='" + ViewState["orderNo"].ToString() + "'";
        //        if (txtproType.Text.Trim() != "")
        //        {
        //            strOrderDetail += " and proType like '%" + txtproType.Text.Trim() + "%'";
        //        }
        //        DataSet ds = new DataSet();
        //        ds = ProOrdersDetailBLL.GetList(strOrderDetail);
        //        if (ds != null)
        //        {
        //            rptOrderDetail.DataSource = ds;
        //            rptOrderDetail.DataBind();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        /// <summary>
        /// 订单搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchOrder_Click(object sender, EventArgs e)
        {
            LoadDataBind();
        }
        /// <summary>
        /// 产品搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSearchProduct_Click(object sender, EventArgs e)
        //{
        //    LoadOrderDetail();
        //}
        /// <summary>
        /// 未开票金额
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="yikai"></param>
        /// <returns></returns>
        public string GetWeiKai(string orderNum, string yikai)
        {
            decimal total = 0;
            if (ProOrdersDetailBLL.GetOrderTotalPrice(orderNum) != "")
            {
                 total = Convert.ToDecimal(ProOrdersDetailBLL.GetOrderTotalPrice(orderNum));
            }
            if (yikai != "")
            {
                return (total - Convert.ToDecimal(yikai)).ToString();
            }
            else
            {
                return total.ToString();
            }
        }
        /// <summary>
        /// 未结款金额
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="yijie"></param>
        /// <returns></returns>
        public string GetWeiJie(string orderNum, string yijie)
        {
            decimal total = 0;
            if (ProOrdersDetailBLL.GetOrderTotalPrice(orderNum) != "")
            {
                 total = Convert.ToDecimal(ProOrdersDetailBLL.GetOrderTotalPrice(orderNum));
            }
            if (yijie != "")
            {
                return (total - Convert.ToDecimal(yijie)).ToString();
            }
            else
            {
                return total.ToString();
            }
        }
    }
}