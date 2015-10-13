using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Web;

namespace OrderPrintSystem.BLL
{
    public class PageBase : System.Web.UI.Page
    {
        //写入Cookie中的用户信息
        public UserManageMOD UserInfo;

        protected override void OnInit(EventArgs e)
        {
            checkUser();
            base.OnInit(e);
        }

        public void checkUser()
        {
            var jser = new JavaScriptSerializer();

            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                Response.Redirect("/Error.htm");
                return;
            }
            UserInfo = jser.Deserialize<UserManageMOD>(FormsAuthentication.Decrypt(authCookie.Value).UserData);
        }
        /// <summary>
        /// 注销登陆
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            try
            {

                HttpCookie cok = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cok != null)
                {
                    cok.Expires = DateTime.Now.AddHours(-24);//删除整个Cookie
                    Response.AppendCookie(cok);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
