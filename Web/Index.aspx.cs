using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Index : PageBase
{
    public  string UserType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (Request.Cookies["cookie"] != null) Response.Write("浏览器支持cookie!");
      //  Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
        
        if (!IsPostBack)
        {
          
            
            //这里是判断是否已经登陆 （先加一个测试一下）
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {  //Cookie中不存在，表示没有登陆，需要跳转到登陆页面
                Response.Redirect("/Login.aspx");
                return;
            } 
            try
            {
                if (UserInfo != null)
                {
                    UserType = UserInfo.UserType + "";
                    Session["UserType"] = UserType;
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
                    else if (UserInfo.UserType==6)
                    {
                        fzsc.Visible = true;
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
            case 6:
                desk.Attributes.Add("src", "orderManage/OrderProManage.aspx?UserType=6");
                break;
            default:
                desk.Attributes.Add("src", "UserManage/UserManage.aspx");
                break;
        }
    }
    /// <summary>
    /// 注销登陆
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