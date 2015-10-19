using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;


public partial class UserManage_AddUser : PageBase
{
    UserManageMOD userinfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                userinfo = UserManageBLL.GetUserByid(id);
                if (userinfo != null)
                {
                    txtPassword.Text = userinfo.UserPass;
                    txtPhone.Text = userinfo.Phone;
                    txtTrueName.Text = userinfo.TrueName;
                    txtUserName.Text = userinfo.UserName;
                    ddlUserType.SelectedValue = userinfo.UserType.ToString();
                }
                txtTrueName.Enabled = false;
                txtUserName.Enabled = false;
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
        int num = 0;

        if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            userinfo = UserManageBLL.GetUserByid(id);
            userinfo.UserType = Convert.ToInt32(ddlUserType.SelectedValue);
            userinfo.Phone = txtPhone.Text.Trim();
            userinfo.UserPass = txtPassword.Text.Trim();
            num = UserManageBLL.UpdateUser(userinfo);
        }
        else
        {
            userinfo = new UserManageMOD();
            userinfo.UserType = Convert.ToInt32(ddlUserType.SelectedValue);
            userinfo.UserPass = txtPassword.Text.Trim();
            userinfo.UserName = txtUserName.Text.Trim();
            userinfo.TrueName = txtTrueName.Text.Trim();
            userinfo.Phone = txtPhone.Text.Trim();
            userinfo.LoginNum = 0;
            num = UserManageBLL.InsertUser(userinfo);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('UserManage/UserManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
}