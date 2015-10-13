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

namespace OrderPrintWeb.ProductManage
{
    public partial class TongjiProduct : System.Web.UI.Page
    {
        private string strWhere;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadDataBind(strWhere);

            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="strWhere"></param>
        protected void LoadDataBind(string strWhere)
        {
            try
            {
                if (txtBeginTime.Value.Trim() != "")
                {
                    strWhere += " and editTime >='"+txtBeginTime.Value.Trim()+"'";
                }
                if (txtEndTime.Value.Trim() != "")
                {
                    strWhere += " and editTime <'"+Convert.ToDateTime( txtEndTime.Value.Trim()).AddDays(1)+"'";
                }
                if (txtCompanyName.Value.Trim() != "")
                {
                    strWhere += " and companyName like '%"+txtCompanyName.Value.Trim()+"%'";
                }
                if (txtOrderNum.Value.Trim() != "")
                {
                    strWhere += " and s.orderNum like '%" + txtOrderNum.Value.Trim() + "%'";
                }
                if (txtProType.Value.Trim() != "")
                {
                    strWhere += " and s.proType like '%" + txtProType.Value.Trim() + "%'";
                }
                if(txtSgd.Value.Trim()!="")
                {
                    //strWhere += " and s.orderNum in (select orderNum from proOrdersDetail where withWorkNo like '%" + txtSgd.Value.Trim() + "%')";
                    strWhere += " and s.suiGongDanNum like '%"+txtSgd.Value.Trim()+"%'";
                }
                strWhere += " and s.sendProNum>0";
                DataSet ds = new DataSet();
                int PageCount;
                ds = SendDetailBLL.GetProList(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
                int Count = 0;
                if (ds != null)
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sendProNum"] != null && ds.Tables[0].Rows[i]["sendProNum"].ToString() != "")
                    //        {
                    //            Count += Convert.ToInt32(ds.Tables[0].Rows[i]["sendProNum"].ToString());
                    //        }
                    //    }
                    //}
                    //totalCount.InnerText = Count.ToString();

                    totalCount.InnerText = (NewsSystem.DBUtility.SqlHelper.GetSingle("select sum(sendProNum) from SendDetail s left join proOrders o on o.orderNum=s.orderNum left join customer c on o.customNum=c.customerNo Where 1=1  " + strWhere)??"0") .ToString();

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

            LoadDataBind(strWhere);

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
            txtSgd.Value = "";
            txtProType.Value = "";
            txtOrderNum.Value = "";
            txtEndTime.Value = "";
            txtCompanyName.Value = "";
            txtBeginTime.Value = "";
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind(strWhere);
          //  UP_DocumentShare.Update();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind(strWhere);
          //  UP_DocumentShare.Update();
        }
        /// <summary>
        /// 根据订单号获取随工单号
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public string GetSGD(string orderNum)
        {
            string str = "";
            ProOrdersDetailMOD mod = ProOrdersDetailBLL.GetModelByOrderNum(orderNum);
          if (mod != null)
          {
              str = mod.withWorkNo;
          }
          return str;
        }
    }
}