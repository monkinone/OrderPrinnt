using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrderPrintSystem.BLL;
using Wuqi.Webdiyer;
using OrderPrintSystem.Modules;

public partial class CustomerManage_CustomerManage : System.Web.UI.Page
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
            if (txt_companyName.Value.Trim() != "")
            {
                strWhere += " and companyName like '%" + txt_companyName.Value.Trim() + "%'";
            }
            if (txt_customerNO.Value.Trim() != "")
            {
                strWhere += " and customerNo like '%" + txt_customerNO.Value.Trim() + "%'";
            }
            DataSet ds = new DataSet();
            int PageCount;
            ds = CustomerManageBLL.GetcustomerAll(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
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
        txt_customerNO.Value = "";
        txt_companyName.Value = "";
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
            int num = CustomerManageBLL.Delete(id.ToString());
            if (num > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除成功');DetailsPageControl.ReflushList();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除失败');DetailsPageControl.ReflushList();", true);
            }
        }
        else if (e.CommandName == "dongjie")
        {
            CustomerManageMod MOD = new CustomerManageMod();
            MOD = CustomerManageBLL.GetcustomerByid(id);
            switch (MOD.Islock)
            {
                case 1:
                    MOD.Islock = 0;
                    break;
                case 0:
                    MOD.Islock = 1;
                    break;
            }
            int num = CustomerManageBLL.Updatecustomer(MOD);
            if (num > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('冻结/解冻成功');DetailsPageControl.ReflushList();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('冻结/解冻失败');DetailsPageControl.ReflushList();", true);
            }
        }
        LoadDataBind(strWhere);
    }


    public string GetStr(string islock)
    {
        string lockName = "";
        switch (islock)
        { 
            case "0":
                lockName = "冻结";
                break;
            case "1":
                lockName = "解冻";
                break;
        }
        return lockName;
    }
}