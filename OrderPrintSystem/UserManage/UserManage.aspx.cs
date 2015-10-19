using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrderPrintSystem.BLL;
using Wuqi.Webdiyer;

public partial class UserManage_UserManage : System.Web.UI.Page
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
            if (txt_trueName.Value.Trim() != "")
            {
                strWhere += " and trueName like '%" + txt_trueName.Value.Trim() + "%'";
            }
            if (txt_userName.Value.Trim() != "")
            {
                strWhere += " and userName like '%" + txt_userName.Value.Trim() + "%'";
            }
            DataSet ds = new DataSet();
            int PageCount;
            ds = UserManageBLL.GetUserAll(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
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
        txt_userName.Value = "";
        txt_trueName.Value = "";
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
    protected void Delete_Click(object sender, ImageClickEventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < rpt_userinfo.Items.Count; i++)
        {
            CheckBox chk = rpt_userinfo.Items[i].FindControl("chkPro") as CheckBox;
            if (chk.Checked)
            {
                HiddenField hidd = rpt_userinfo.Items[i].FindControl("hiddId") as HiddenField;
                sb.Append(hidd.Value + ",");
            }
        }
        if (sb.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('您没有选择任何项');", true);
            return;
        }
        else
        {
            try
            {
                UserManageBLL.Delete(sb.ToString().Substring(0,sb.ToString().Length-1));
                LoadDataBind(strWhere);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('出现错误!请重新尝试!');", true);
            }
        }  
    }
}