using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Modules;
using OrderPrintSystem.BLL;
using System.Data;
using NewsSystem.DBUtility;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {  //Cookie中存在，表示已经登陆了，不用再登陆，直接跳转到首页
                Response.Redirect("Index.aspx");
            }
        }
    }
    protected void IBtn_Login_Click(object sender, ImageClickEventArgs e)
    {
        if (tbx_name.Text == "" || tbx_pwd.Text == "")
        {
            Message.Visible = true;
            Message.Text = "请输入用户名或密码！";
            return;
        }
        else
        {
            string strWhere = " and username='" + tbx_name.Text.Trim() + "' and userpass='" + tbx_pwd.Text.Trim() + "'";
            DataSet ds = UserManageBLL.GetUserAll(strWhere);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //修改用户登录次数
                UserManageBLL.UpdateUserLoginNum(ds.Tables[0].Rows[0]["userid"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["LoginNum"]) + 1);
                //将用户信息存入session
                UserManageMOD UM = UserManageBLL.isExitUser(tbx_name.Text.Trim(), tbx_pwd.Text.Trim());
                //写入Cookie
                SignIn(tbx_name.Text.Trim(), UM);

                Response.Redirect("Index.aspx");
            }
            else
            {
                Message.Visible = true;
                Message.Text = "用户名或密码错误！";
                return;
            }
        }
    }

    private static void SignIn(string loginName, object userData)
    {
        var jser = new JavaScriptSerializer();
        var data = jser.Serialize(userData);

        //创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
        var ticket = new FormsAuthenticationTicket(2,
            loginName, DateTime.Now, DateTime.Now.AddDays(1), true, data);

        //加密Ticket，变成一个加密的字符串。
        var cookieValue = FormsAuthentication.Encrypt(ticket);

        //根据加密结果创建登录Cookie
        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
        {
            HttpOnly = true,
            Secure = FormsAuthentication.RequireSSL,
            Domain = FormsAuthentication.CookieDomain,
            Path = FormsAuthentication.FormsCookiePath
        };
        //在配置文件里读取Cookie保存的时间
        double expireHours = Convert.ToDouble(ConfigurationManager.AppSettings["loginExpireHours"]);
        if (expireHours > 0)
            cookie.Expires = DateTime.Now.AddHours(expireHours);

        var context = System.Web.HttpContext.Current;
        if (context == null)
            throw new InvalidOperationException();

        //写登录Cookie
        context.Response.Cookies.Remove(cookie.Name);
        context.Response.Cookies.Add(cookie);
    }

    public void SingOut()
    {
        FormsAuthentication.SignOut();
        Response.Redirect("/login");
    }

}