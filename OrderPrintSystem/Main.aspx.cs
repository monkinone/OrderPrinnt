using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System.Data;

public partial class Main : System.Web.UI.Page
{
    UserManageMOD userinfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserInfo"] != null)
        {
            userinfo = (UserManageMOD)Session["UserInfo"];
            //获取用户登录次数，如是首次登录提示修改密码
            if (userinfo.LoginNum > 1)
            {
                spanTishi.Visible = false;
            }
            else
            {
                spanTishi.Visible = true;
            }
        }

    }
    /// <summary>
    /// 提交按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["UserInfo"] != null)
        {
            userinfo = (UserManageMOD)Session["UserInfo"];
        }
        int num = 0;
        string strWhere = " and userid=" + userinfo.UserId + " and userpass='" + txtOldPass.Text.Trim() + "'";
        DataSet ds = UserManageBLL.GetUserAll(strWhere);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            num = UserManageBLL.UpdateUserPass(txtNewPass.Text.Trim(), userinfo.UserId.ToString());
            if (num > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('密码修改成功');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('密码修改失败！');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('原密码不正确！');", true);
        }
    }
   
}