﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using OrderPrintSystem.BLL;

namespace OrderPrintWeb.ProductManage
{
    public partial class BiaoShiImageManage : PageBase
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
                if (txt_biaoshiNo.Value.Trim() != "")
                {
                    strWhere += " and biaoShiNo like '%" + txt_biaoshiNo.Value.Trim() + "%'";
                }

                DataSet ds = new DataSet();
                int PageCount;
                ds = BiaoShiImgBLL.GetmodAll(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
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

            LoadDataBind(strWhere);

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            ScriptManager.RegisterStartupScript(UP_Search, typeof(UpdatePanel), "QueryArea", "ListPageControl.ReflushListBtnID = \"" + IBtn_Empty.ClientID + "\";", true);
        }

        /// <summary>
        /// 查询区域更新后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UP_Search_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ScriptManager.RegisterStartupScript(UP_Search, typeof(UpdatePanel), "QueryArea", "ListPageControl.SetEveryView('QueryArea');", true);
            }
        }

        /// <summary>
        /// 列表区域更新后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UP_DocumentShare_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ScriptManager.RegisterStartupScript(UP_DocumentShare, typeof(UpdatePanel), "ListArea", "ListPageControl.SetEveryView('ListArea');", true);
            }
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void IBtn_Empty_Click(object sender, ImageClickEventArgs e)
        {
            txt_biaoshiNo.Value = "";
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind(strWhere);
            UP_DocumentShare.Update();
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind(strWhere);
            UP_DocumentShare.Update();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_userinfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "del")
            {
                int num = BiaoShiImgBLL.Delete(id.ToString());
                if (num > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除成功');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除失败');", true);
                }
            }

            LoadDataBind(strWhere);
        }
    }
}