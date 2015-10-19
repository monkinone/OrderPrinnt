using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
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
    public partial class OrderDetail : PageBase
    {
        string strWhere = "";
        string orderNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
                {
                    orderNum = Request.QueryString["orderNum"].ToString();
                }
                LoadOrderDetail();
                if (UserInfo.UserType == 2)
                {
                    //取消修改提醒
                    ProOrdersMOD mod = ProOrdersBLL.GetModel(orderNum);
                    if (mod != null)
                    {
                        ProOrdersBLL.Update(mod.orderId.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 加载订单详情
        /// </summary>
        public void LoadOrderDetail()
        {
            try
            {
                strWhere += " and orderNum='" + Request.QueryString["orderNum"].ToString() + "'";
                if (txtproType.Text.Trim() != "")
                {
                    strWhere += " and proType like '%" + txtproType.Text.Trim() + "%'";
                }
                DataSet ds = new DataSet();
                int PageCount;
                ds = ProOrdersDetailBLL.GetList(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
                if (ds != null)
                {
                    Pager_DocumentShare.RecordCount = PageCount;
                    rptOrderDetail.DataSource = ds;
                    rptOrderDetail.DataBind();


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

            LoadOrderDetail();

        }
        /// <summary>
        /// 产品搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchProduct_Click(object sender, EventArgs e)
        {
            LoadOrderDetail();
        }
    }
}