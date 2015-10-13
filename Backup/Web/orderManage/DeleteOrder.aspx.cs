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
    public partial class DeleteOrder : System.Web.UI.Page
    {
        private string strWhere;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                if (txtBeginTime.Value.Trim() != "")
                {
                    strWhere += " and editTime>='" + txtBeginTime.Value.Trim() + "'";
                }
                if (txtEndTime.Value.Trim() != "")
                {
                    strWhere += "  and editTime<='" + Convert.ToDateTime(txtEndTime.Value.Trim()).AddDays(1) + "'";
                }
                if (txtCompanyName.Text.Trim() != "")
                {
                    strWhere += " and companyName like '%" + txtCompanyName.Text.Trim() + "%'";
                }
                if (txtorderNum.Text.Trim() != "")
                {
                    strWhere += " and orderNum like '%" + txtorderNum.Text.Trim() + "%'";
                }
                if (txtProduct.Text.Trim() != "")
                {
                    strWhere += " and o.orderNum in (select  orderNum from proOrdersDetail where proType like '%" + txtProduct.Text.Trim() + "%')";
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
            if (e.CommandName == "Del")  //删除订单
            {
                //如果此订单已经被生产人员打印，则弹出提醒，“请通知生产人员取消此订单”
                if (ProOrdersDetailBLL.GetPrintCount(orderNO).ToString() != "")
                {
                    int printCount = Convert.ToInt32(ProOrdersDetailBLL.GetPrintCount(orderNO));
                    if (printCount > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "DDGL", "alert('此订单已经被生产人员打印,请通知生产人员取消此订单！')", true);
                    }
                }
                //删除发货明细
                SendDetailBLL.Delete(orderNO);
                //删除订单产品
                ProOrdersDetailBLL.Delete(orderNO);
                //删除订单
                ProOrdersBLL.Delete(orderNO);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "DDGL", "alert('该订单已删除！')", true);
                LoadDataBind();
            }
        }


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
                if (yikai != "")
                {
                    return (total - Convert.ToDecimal(yikai)).ToString();
                }
                else
                {
                    return total.ToString();
                }
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
                if (yijie != "")
                {
                    return (total - Convert.ToDecimal(yijie)).ToString();
                }
                else
                {
                    return total.ToString();
                }
            }
            else
            {
                return total.ToString();
            }
        }
        /// <summary>
        /// 订单总额
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="yijie"></param>
        /// <returns></returns>
        public string GetTotalPrice(string orderNum)
        {
            decimal total = 0;
            if (ProOrdersDetailBLL.GetOrderTotalPrice(orderNum) != "")
            {
                total = Convert.ToDecimal(ProOrdersDetailBLL.GetOrderTotalPrice(orderNum));
            }
            return total.ToString();
        }
    }
}