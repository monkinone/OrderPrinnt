using OrderPrintSystem.BLL;
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
    public partial class NoSendList : System.Web.UI.Page
    {
        private string strWhere;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定所有订单产品
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
                if (txtproType.Value.Trim() != "")
                {
                    strWhere += " and proType like '%" + txtproType.Value.Trim() + "%'";
                }
                if (txtcustomNum.Value.Trim() != "")
                {
                    strWhere += " and companyName like '%" + txtcustomNum.Value.Trim() + "%'";
                }
                if (txtorderNum.Value.Trim() != "")
                {
                    strWhere += " and orderNum like '%" + txtorderNum.Value.Trim() + "%'";
                }
                //if (ddlIsPrint.SelectedValue == "0")  //未打印
                //{
                //    strWhere += " and (printSGDCount=0 and printSGDJLCount=0 and printQLDCount=0 and printCCJYBGCount=0 and printSHDCount=0 and printBZBQCount=0 and printZYSXCount=0 and printYYQRDCount=0)";
                //}
                //else if (ddlIsPrint.SelectedValue == "1")  //已打印
                //{
                //    strWhere += " and (printSGDCount>0 and printSGDJLCount>0 and printQLDCount>0 and printCCJYBGCount>0 and printSHDCount>0 and printBZBQCount>0 and printZYSXCount>0 and printYYQRDCount>0)";
                //}
                //else   //部分打印
                //{
                //    strWhere += " and (printSGDCount>0 or printSGDJLCount>0 or printQLDCount>0 or printCCJYBGCount>0 or printSHDCount>0 or printBZBQCount>0 or printZYSXCount>0 or printYYQRDCount>0)";
                //}
                DataSet ds = new DataSet();
                int PageCount;
                ds = ProOrdersDetailBLL.GetNoSendOrder(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
                DataColumn dcNoSendCount = new DataColumn("dcNoSendCount", typeof(string));
                ds.Tables[0].Columns.Add(dcNoSendCount);
               
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int proNum = Convert.ToInt32(ds.Tables[0].Rows[i]["proNum"].ToString());
                            string sendCount = ds.Tables[0].Rows[i]["SendCount"].ToString();
                            int noSendCount = 0;
                            if (sendCount != "")
                            {
                                noSendCount = proNum - Convert.ToInt32(sendCount);
                            }
                            else
                            {
                                noSendCount = proNum;
                            }
                            ds.Tables[0].Rows[i]["dcNoSendCount"] = noSendCount.ToString();
                         
                        }
                    }
                    Pager_DocumentShare.RecordCount = PageCount;
                    rpt_userinfo.DataSource = ds;
                    rpt_userinfo.DataBind();
                }
                //获取未完成总量
                int totalCount = 0;
               DataSet ds1 = ProOrdersDetailBLL.GetNoSendOrder(strWhere);
               if (ds1 != null)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            int proNum = Convert.ToInt32(ds1.Tables[0].Rows[i]["proNum"].ToString());
                            string sendCount = ds1.Tables[0].Rows[i]["SendCount"].ToString();
                            int noSendCount = 0;
                            if (sendCount != "")
                            {
                                noSendCount = proNum - Convert.ToInt32(sendCount);
                            }
                            else
                            {
                                noSendCount = proNum;
                            }
                            totalCount += noSendCount;
                        }
                    }
                }
                lblCount.Text = totalCount.ToString();
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
            txtproType.Value = "";
            txtcustomNum.Value = "";
            txtorderNum.Value = "";
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

        public string GetCanshu(string customer, string proType)
        {
            string str = "";
            ProductParamMOD MOD = ProductParamBLL.GetmodByid(customer, proType);
            if (MOD != null)
            {
                str = MOD.ParamContent;
            }
            return str;
        }
    }
}