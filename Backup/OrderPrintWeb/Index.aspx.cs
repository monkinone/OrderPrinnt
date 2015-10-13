using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (UserInfo != null)
                {
                    L_UserName.Text = UserInfo.UserName;
                    //控制导航显示隐藏
                    if (UserInfo.UserType == 1)
                    {
                        guanli.Visible = true;
                        shengchan.Visible = false;
                        jishu.Visible = false;
                        yewu.Visible = false;
                        yonghu.Visible = false;
                    }
                    else if (UserInfo.UserType == 2)
                    {
                        guanli.Visible = false;
                        shengchan.Visible = true;
                        jishu.Visible = false;
                        yewu.Visible = false;
                        yonghu.Visible = false;
                    }
                    else if (UserInfo.UserType == 3)
                    {
                        guanli.Visible = false;
                        shengchan.Visible = false;
                        jishu.Visible = true;
                        yewu.Visible = false;
                        yonghu.Visible = false;
                    }
                    else if (UserInfo.UserType == 4)
                    {
                        guanli.Visible = false;
                        shengchan.Visible = false;
                        jishu.Visible = false;
                        yewu.Visible = true;
                        yonghu.Visible = false;
                    }
                    else if (UserInfo.UserType == 5)
                    {
                        guanli.Visible = false;
                        shengchan.Visible = false;
                        jishu.Visible = false;
                        yewu.Visible = false;
                        yonghu.Visible = true;
                    }
                    //跳转页面
                    tiaozhuan();
                }
                else
                {
                    //   Response.Redirect("Error.htm");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "<script type='text/javascript'>window.parent.location='Error.htm'<script>", true);
                }
            }
            catch (Exception ex)
            {
                // Response.Redirect("Error.htm");
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "<script type='text/javascript'>window.parent.location='Error.htm'<script>", true);
            }
        }
    }
    public void tiaozhuan()
    {
        //if (UserInfo.LoginNum > 1)
        //{
        switch (UserInfo.UserType)
        {
            case 1:
                desk.Attributes.Add("src", "orderManage/OrderManage.aspx");
                break;
            case 2:
                desk.Attributes.Add("src", "orderManage/OrderProManage.aspx");
                break;
            case 3:
                desk.Attributes.Add("src", "ProductManage/ProductManage.aspx");
                break;
            case 4:
                desk.Attributes.Add("src", "orderManage/YeWuOrderList.aspx");
                break;
            default:
                desk.Attributes.Add("src", "UserManage/UserManage.aspx");
                break;
        }

        //}
        //else
        //{
        //    desk.Attributes.Add("src", "Main.aspx");
        //}
    }
    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExit_Click(object sender, EventArgs e)
    {
        if (Logout())
        {
            Response.Redirect("~/Login.aspx");
        }
     
    }
}