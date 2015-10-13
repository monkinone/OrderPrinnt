using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Web.Service
{   
    /// <summary>
    /// 基础服务类
    /// </summary>
    public class BaseService:IHttpHandler
    {
        //写入Cookie中的用户信息
        public UserManageMOD UserInfo;
        /// <summary>
        /// 数据源
        /// </summary>
        public Model.OrderPrintEntities db;

        public virtual void ProcessRequest(HttpContext context)
        {
            var authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            var jser = new JavaScriptSerializer();
            UserInfo = jser.Deserialize<UserManageMOD>(FormsAuthentication.Decrypt(authCookie.Value).UserData);

            //实例化数据
            db = new Model.OrderPrintEntities(); 
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}