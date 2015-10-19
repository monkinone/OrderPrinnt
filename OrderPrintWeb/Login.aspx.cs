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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { }
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

                Session["UserInfo"] = UM;
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
}