using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrderPrintSystem.BLL;
using Wuqi.Webdiyer;

public partial class CustomerManage_PriceList : PageBase
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
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                strWhere += " and customNo='" + Request.QueryString["customerNo"].ToString() + "'";
            }

            DataSet ds = new DataSet();
            int PageCount;
            ds = PriceManageBLL.GetmodAll(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
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
}