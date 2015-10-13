using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NoticeManage_AddNotice : System.Web.UI.Page
{
    GuanJiaoZhenImgMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = NoticeBLL.GetmodAll("");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
               txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                txtContents.Value = ds.Tables[0].Rows[0]["contents"].ToString();
            }
        }
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        NoticeMOD mod = null;
        int num = 0;
        DataSet ds = NoticeBLL.GetmodAll("");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            mod = new NoticeMOD();
            mod.Title = txtTitle.Text.Trim();
            mod.Contents = txtContents.Value;
            num = NoticeBLL.Updatemod(mod);
        }
        else
        {
            mod = new NoticeMOD();
            mod.Title = txtTitle.Text.Trim();
            mod.Contents = txtContents.Value;
            num = NoticeBLL.Insertmod(mod);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交成功');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
}