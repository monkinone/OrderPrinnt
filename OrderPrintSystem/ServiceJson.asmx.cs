using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
using DCQWBOA.W8.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BLL;
using System.Net;
using System.IO;
using System.Text;
using Beyondbit.OA.Common;
using DCQWBOA.W8.BLL.ShortcutMenu;
using Beyondbit.OA.Modules.User;
using System.Data;

namespace DCQWBOA.W8
{
    /// <summary>
    /// Service 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://dcqwboa.w8/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [ScriptService]
    public class ServiceJson : System.Web.Services.WebService
    {
        Privilege PrivilegeBiz = new Privilege();
        WorkitemBiz workitem = new WorkitemBiz();
        AttachmentBiz AttachmentBizObj = new AttachmentBiz();
        UserCustomBiz UserCustomBizObj = new UserCustomBiz();
        CalenderBiz Calender = new CalenderBiz();

        [WebMethod]

        public string HelloWorld()
        {
            return "Hello World";

        }
        #region 获取全部应用
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAllApplyByAuthority_Code(string Authority_Code)
        {
            return JsonConvert.SerializeObject(ShortcutMenuBiz.GetAllApply(Authority_Code), new DataTableConverter());
        }
        #endregion

        #region 获取用户快捷菜单信息
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getShortcutMenuByUserId(int UserId)
        {
            UserModule model = (UserModule)Session["UserInfo"];
            string[] PrwCode = model.Purview.Split(',');
            string PCode = "" ;
            foreach (string pc in PrwCode)            {
                PCode += "'" + pc + "',";
            }
            PCode = PCode.TrimEnd(',');
            DataTable ShortcutMenu = ShortcutMenuBiz.SelShortcutMenu(UserId, PCode);
			//获取当前用户的所有权限代码 删除已经在bua里取消的权限。
            return JsonConvert.SerializeObject(ShortcutMenu, new DataTableConverter());

        }
        #endregion



        #region 功能点

        /// <summary>
        /// 获取用户所有功能点
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getUserAllPrivilege(string userid)
        {
            return JsonConvert.SerializeObject(PrivilegeBiz.getAllUserPrivilege(userid), new DataTableConverter());

        }

        /// <summary>
        /// 获取用户大类功能点
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getUserFirstPrivilege(string userid)
        {
            return JsonConvert.SerializeObject(PrivilegeBiz.getUserFirstPrivilege(userid), new DataTableConverter());
        }

        /// <summary>
        /// 获取用户下一级功能点ID
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="parentid">父级ID</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getUserPrivilegeByParentID(string userid, string parentid)
        {
            return JsonConvert.SerializeObject(PrivilegeBiz.getUserPrivilegeByParentID(userid, parentid), new DataTableConverter());
        }

        /// <summary>
        /// 根据用户ID和类别代码获取可查看的机构
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="TypeCode">类别代码</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetOrgByUserIdAndTypeCode(string UserId, string TypeCode)
        {
            return JsonConvert.SerializeObject(PrivilegeBiz.GetOrgByUserIdAndTypeCode(UserId, TypeCode));
        }
        /// <summary>
        /// 根据用户ID和类别代码获取可查看的机构 TypeCode不加KS的
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="TypeCode">权限编码</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetOrgByUserIdAndTypeCodeNotKS(int Unit_ID) 
        {
            return JsonConvert.SerializeObject(PrivilegeBiz.GetOrgByUserIdAndTypeCodeNotKS(Unit_ID));
        } 
             

        #endregion

        #region 机构

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAllOrg()
        {
            UserModule userinfo =(UserModule) Session["UserInfo"];
            return JsonConvert.SerializeObject(OrgBiz.GetAllOrg(userinfo.UnitID));
        }

        #endregion

        #region 待办列表

        /// <summary>
        /// 获取指定用户按条件筛选过的待办事项，仅获取大于指定时间的
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="MaxDateTime">指定时间</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getWorkItemByUserID(string UserId, string MaxDateTime,int pageSize)
        {
            return JsonConvert.SerializeObject(workitem.getWorkItemByUserID(UserId, MaxDateTime, pageSize));
        }

        #endregion

        #region 附件

        /// <summary>
        /// 根据ID删除附件
        /// </summary>
        /// <param name="AttachID">附件ID</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool DelAttach(string AttachID)
        {
            return AttachmentBiz.DeleteAttachmentByID(AttachID);
        }

        #endregion

        #region 自定义设置

        /// <summary>
        /// 根据用户ID和功能点获取用户设置
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <param name="TypeCode">功能点代码</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetFuncCustomByUserIdAndTypeCode(string UserId, string TypeCode)
        {
            return JsonConvert.SerializeObject(UserCustomBizObj.GetFuncCustomByUserIdAndTypeCode(UserId, TypeCode));
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="TypeCode">功能点代码</param>
        /// <param name="OrgList">部门列表，以逗号分割，前面也加“,”</param>
        /// <param name="Days">天数</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool SaveFuncCustom(string UserId, string TypeCode, string OrgList, string Days)
        {
            return UserCustomBizObj.SaveFuncCustom(UserId, TypeCode, OrgList, Days);
        }
        #endregion

        #region 日程提醒列表

        /// <summary>
        /// 获取指定用户提醒
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="MaxDateTime">指定时间</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getRemindNoteByUserID(string UserId)
        {
            return JsonConvert.SerializeObject(Calender.getRemindNoteByUserID(UserId));
        }

        #endregion

        #region 取消日程提醒

        /// <summary>
        /// 取消日程提醒
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="MaxDateTime">指定时间</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string editCalenderRemindByUserID(string UserId, string CalenderIDs)
        {
            return JsonConvert.SerializeObject(Calender.editCalenderRemindByUserID(UserId, CalenderIDs));
        }

        #endregion

        #region 天气查询

        /// <summary>
        /// 获取城市代码
        /// </summary>
        /// <returns>q:返回的总是北京的！</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        private static string GetCityId()
        {
            HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create("http://61.4.185.48:81/g/");
            HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();

            wNetr.ContentType = "text/html";
            wNetr.Method = "Get";

            Stream Streams = wNetp.GetResponseStream();
            StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);

            string ReCode = Reads.ReadToEnd();

            //关闭暂时不适用的资源
            Reads.Dispose();
            Streams.Dispose();
            wNetp.Close();

            //分析返回代码
            string[] Temp = ReCode.Split(';');
            ReCode = Temp[1].Replace("var id=", "");

            return ReCode;
        }

        /// <summary>
        /// 获取城市的天气状况
        /// </summary>
        /// <returns>json</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetWeather()
        {

            string wUrl = string.Format("http://m.weather.com.cn/data/{0}.html", "101010100");

            HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create(wUrl);
            HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();
            wNetr.ContentType = "text/html";
            wNetr.Method = "Get";
            Stream Streams = wNetp.GetResponseStream();
            StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);

            string ReCode = Reads.ReadToEnd();

            //关闭暂时不适用的资源

            Reads.Dispose();

            Streams.Dispose();

            wNetp.Close();

            return ReCode.ToString();

        }

        #endregion

        #region 日程提醒列表

        /// <summary>
        /// 获取指定用户提醒
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="MaxDateTime">指定时间</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getDeptUserIDByUnit(string UserUnitid)
        {
            return JsonConvert.SerializeObject(Function.getDeptUserIDByUnit(UserUnitid));
        }

        #endregion

        /// <summary>
        /// 取用户所有代办条数
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetTSTypeCodeCount()
        {
            return JsonConvert.SerializeObject(ShortcutMenuBiz.GetCountByTypecode(((UserModule)Session["UserInfo"]).ID).Tables[0]);
        }
    }
}
