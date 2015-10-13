using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Modules;
using System.Data;
using OrderPrintSystem.BLL;

public partial class CustomerManage_AddZYSX : System.Web.UI.Page
{
    string strWhere = "";
    string customerNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                customerNo = Request.QueryString["customerNo"].ToString();
                txtCustomerNo.Text = customerNo;
            }
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
            strWhere += " and customerNo='" + txtCustomerNo.Text.Trim() + "'";
            DataSet ds = new DataSet();
            ds = MattersNeedingAttentionBLL.GetmodAll(strWhere);
            if (ds != null)
            {
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
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_userinfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "del")
        {
            int num = MattersNeedingAttentionBLL.Delete(id.ToString());
            if (num > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除成功');DetailsPageControl.ReflushList();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除失败');DetailsPageControl.ReflushList();", true);
            }
        }

        LoadDataBind(strWhere);
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, EventArgs e)
    {
        int num = 0;

        MattersNeedingAttentionMOD mod = new MattersNeedingAttentionMOD();

        mod.CustomerNo = txtCustomerNo.Text.Trim();
        mod.Contents = txtContents.Text.Trim();
        num = MattersNeedingAttentionBLL.Insertmod(mod);
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交成功');DetailsPageControl.ReflushList('CustomerManage/ZYSXManage.aspx')", true);

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
        LoadDataBind(strWhere);
    }
}