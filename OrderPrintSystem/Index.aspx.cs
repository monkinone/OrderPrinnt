using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] != null)
            {
                UserManageMOD UM = (UserManageMOD)Session["UserInfo"];
                if (UM.UserType == 1)
                {
                    guanli.Visible = true;
                    shengchan.Visible = false;
                    jishu.Visible = false;
                    yewu.Visible = false;
                }
                else if (UM.UserType == 2)
                {
                    guanli.Visible = false;
                    shengchan.Visible = true;
                    jishu.Visible = false;
                    yewu.Visible = false;
                }
                else if (UM.UserType == 3)
                {
                    guanli.Visible = false;
                    shengchan.Visible = false;
                    jishu.Visible = true;
                    yewu.Visible = false;
                }
                else
                {
                    guanli.Visible = false;
                    shengchan.Visible = false;
                    jishu.Visible = false;
                    yewu.Visible = true;
                }
            }
        }
    }
}