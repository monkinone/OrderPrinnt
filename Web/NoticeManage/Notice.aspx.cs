using OrderPrintSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NoticeManage_Notice : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = NoticeBLL.GetmodAll("");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                lblContents.Text = ds.Tables[0].Rows[0]["contents"].ToString();
            }
        }
    }
}