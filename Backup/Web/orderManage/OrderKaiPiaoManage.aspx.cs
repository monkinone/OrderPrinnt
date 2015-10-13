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
    public partial class OrderKaiPiaoManage : System.Web.UI.Page
    {
        private string strWhere;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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

        //protected override void OnLoadComplete(EventArgs e)
        //{
        //    base.OnLoadComplete(e);
        //    ScriptManager.RegisterStartupScript(UP_Search, typeof(UpdatePanel), "QueryArea", "ListPageControl.ReflushListBtnID = \"" + IBtn_Empty.ClientID + "\";", true);
        //}

        /// <summary>
        /// 查询区域更新后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void UP_Search_Load(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        ScriptManager.RegisterStartupScript(UP_Search, typeof(UpdatePanel), "QueryArea", "ListPageControl.SetEveryView('QueryArea');", true);
        //    }
        //}

        /// <summary>
        /// 列表区域更新后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void UP_DocumentShare_Load(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        ScriptManager.RegisterStartupScript(UP_DocumentShare, typeof(UpdatePanel), "ListArea", "ListPageControl.SetEveryView('ListArea');", true);
        //    }
        //}
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void IBtn_Empty_Click(object sender, EventArgs e)
        {
            txtBeginTime.Value = "";
            txtCompanyName.Text = "";
            txtEndTime.Value = "";
            txtorderNum.Text = "";
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind();
            //  UP_DocumentShare.Update();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind();
            //  UP_DocumentShare.Update();
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