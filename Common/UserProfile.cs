using System;
using System.Collections.Generic;
using System.Text;
using System.Web.SessionState;
using System.Xml;

using System.Collections;

namespace Beyondbit.OA.Common
{
    [Serializable]
    public class UserProfile
    {
         public const string C_SESSION_KEY = "USERINFO_KEY";
		#region 成员变量
		private String _id;//用户ID号
		private String _uid;//用户英文名称（登录用）
		private String _name;//用户全名
		private String _sex;//性别
        private String _deptid;//部门代号
		private String _deptname;//部门名称
		private Boolean _flag;//账号是否停用
		private String _demo;//备注
        private String _unitid;//
		private String _unitname;//
        private String _skin;
        private ArrayList _callBoardRoles;//该用户具有的通知公告的角色
        private String _briefOrgInfo;//信息发布属于区府还是区委单位（刊物统计用）
        private ArrayList _deptRoles;  //部门协同角色信息 edit by whc time 20100513
		#endregion

		#region 构造函数
		public UserProfile() 
		{
		}

        //public UserProfile(XmlNode node)
        //{
        //    BuildByXML(node);
        //}

		#endregion

		#region 公有属性


		/// <summary>
		/// 用户ID号
		/// </summary>
		public String ID
		{
			get 
			{
				return _id;
			}
			set 
			{
				_id = value;
			}
		}
		/// <summary>
		/// 用户英文名称（登录用）
		/// </summary>
		public String UID 
		{
			get 
			{
				return _uid;
			}
			set 
			{
				_uid = value;
			}
		}
		/// <summary>
		/// 用户全名
		/// </summary>
		public String Name 
		{
			get 
			{
				return _name;
			}
			set 
			{
				_name = value;
			}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public String Sex 
		{
			get 
			{
				return _sex;
			}
			set 
			{
				_sex = value;
			}
		}
		/// <summary>
		/// 部门代号
		/// </summary>
		public String DeptID 
		{
			get 
			{
				return _deptid;
			}
			set 
			{
				_deptid = value;
			}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public String DeptName 
		{
			get 
			{
				return _deptname;
			}
			set 
			{
				_deptname = value;
			}
		}
		/// <summary>
		/// 账号是否停用
		/// </summary>
		public Boolean Flag 
		{
			get 
			{
				return _flag;
			}
			set 
			{
				_flag = value;
			}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public String Demo 
		{
			get 
			{
				return _demo;
			}
			set 
			{
				_demo = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public String UnitID 
		{
			get 
			{
				return _unitid;
			}
			set 
			{
				_unitid = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public String UnitName 
		{
			get 
			{
				return _unitname;
			}
			set 
			{
				_unitname = value;
			}
		}

        public String SkinPath
        {
            get
            {
                return _skin;
            }
            set
            {
                _skin = value;
            }
        }

        public ArrayList CallBoardRoles
        {
            get
            {
                return _callBoardRoles;
            }
            set
            {
                _callBoardRoles = value;
            }
        }

        /// <summary>
        /// create by whc
        /// time 20100513
        /// 获取部门协同角色信息
        /// </summary>
        public ArrayList DeptRoles
        {
            get { return _deptRoles; }
            set { _deptRoles = value; }
        }



        public String BriefOrgInfo
        {
            get
            {
                return _briefOrgInfo;
            }
            set
            {
                _briefOrgInfo = value;
            }
        }
		#endregion

        ///// <summary>
        ///// 通过XML加载用户信息
        ///// </summary>
        ///// <param name="node">XML节点</param>
        //private void BuildByXML(XmlNode node)
        //{
        //    if (null == node)
        //        throw new ArgumentNullException("从统一授权返回的XML数据无效!");
        //    try
        //    {
        //        this.ID = node.ChildNodes[0].Attributes["dn"].Value;
        //        this.UID = node.ChildNodes[0].Attributes["userName"].Value;
        //        this.Name = node.ChildNodes[0].Attributes["realName"].Value;
        //        this.DeptID = node.ChildNodes[0].Attributes["orgDn"].Value;
        //        this.DeptName = node.ChildNodes[0].Attributes["department"].Value;
        //        this.UnitID = node.ChildNodes[0].Attributes["secondLayerOrg"].Value;
        //        this.UnitName = node.ChildNodes[0].Attributes["company"].Value;
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("从统一授权返回的XML数据无效!");
        //    }
        //}

        /// <summary>
        /// 从Session获得登录用户信息
        /// </summary>
        /// <param name="objSession">Session</param>
        /// <returns>UserModule</returns>
        public static UserProfile GetUserInfo4Session(HttpSessionState objSession)
        {
            UserProfile info = null;
            if (objSession != null && objSession.Keys.Count != 0)
            {
                info = (UserProfile)objSession[C_SESSION_KEY];
            }
            return info;
        }

        ///// <summary>
        ///// 将UserModule对象放入Session
        ///// </summary>
        ///// <param name="objSession">session</param>
        //public static void SetUserInfo2Session(HttpSessionState objSession, UserBaseInfo cenInfo,UserProfile locInfo)
        //{
        //    if (null == cenInfo)
        //        throw new ArgumentNullException("从统一授权返回的数据无效!");

        //    locInfo.SkinPath = System.Configuration.ConfigurationManager.AppSettings["SkinPath"].ToString();
        //    Beyondbit.Portal.Security.BUAProvider20 bua = new BUAProvider20();
        //    try
        //    {
        //        locInfo.ID = cenInfo.UserUid;
        //        locInfo.UID = cenInfo.UserUid;
        //        locInfo.Name = cenInfo.UserName;
        //        locInfo.DeptID = cenInfo.OrgCode;
        //        locInfo.DeptName = bua.GetOrgBaseInfo(OrgType.ORG,cenInfo.OrgCode).OrgName;
        //        //while (!String.IsNullOrEmpty(orgInfo.ParentOrgCode))
        //        //{
        //        //    orgInfo = bua.GetOrgBaseInfo(OrgType.ORG, cenInfo.ParentOrgCode);
        //        //}
        //        locInfo.UnitID = cenInfo.UnitCode;
        //        locInfo.UnitName = bua.GetOrgBaseInfo(OrgType.ORG, cenInfo.UnitCode).OrgName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("从统一授权返回的XML数据无效!");
        //    }
        //    objSession[C_SESSION_KEY] = locInfo;
        //}

        /// <summary>
        /// 将UserModule对象放入Session
        /// </summary>
        /// <param name="objSession">session</param>
        //public static void SetUserInfo2Session(HttpSessionState objSession, UserProfile locInfo)
        //{
        //    if (objSession[C_SESSION_KEY] == null)
        //    {
        //        string userUid = Beyondbit.SingleSignOn.ClientForAspNet20.SSOClient.UserUid;
        //        if (string.IsNullOrEmpty(userUid))
        //            throw new ArgumentNullException("从单点登录获取用户身份失败!");

        //        locInfo.SkinPath = System.Configuration.ConfigurationManager.AppSettings["SkinPath"].ToString();
        //        User user = ServiceFactory.Instance().GetUserService().GetUserBaseInfo(userUid);
        //        Org org = ServiceFactory.Instance().GetOrgService().GetOrgBaseInfo(Beyondbit.BUA.Client.ObjectType.Org, user.OrgCode);
        //        Org unit = ServiceFactory.Instance().GetOrgService().GetOrgBaseInfo(Beyondbit.BUA.Client.ObjectType.Org, user.UnitCode);

        //        try
        //        {
        //            locInfo.ID = userUid;
        //            locInfo.UID = userUid;
        //            locInfo.Name = user.UserName;
        //            locInfo.DeptID = user.OrgCode;
        //            locInfo.DeptName = org.OrgName;
        //            locInfo.UnitID = user.UnitCode;
        //            locInfo.UnitName = unit.OrgName;
        //            locInfo.CallBoardRoles = new ArrayList();
        //            locInfo._briefOrgInfo = GetBriefInfo(user.OrgCode);
        //            try
        //            {
        //                Role[] roles = ServiceFactory.Instance().GetRoleService().QueryUserRoles(userUid);
        //                string appCode = System.Configuration.ConfigurationManager.AppSettings["visitSys"].ToString();
        //                for (int i = 0; i < roles.Length; i++)
        //                {
        //                    locInfo.CallBoardRoles.Add(roles[i].RoleCode);
        //                }
        //                //edit by whc 20100513
        //                //获取用户部门协同角色信息
        //                if (HasDeptRole(user.UnitCode))
        //                    locInfo.DeptRoles = GetDeptRole(user.UserUid);
        //            }
        //            catch { }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("从统一授权返回的XML数据无效!");
        //        }
        //        objSession[C_SESSION_KEY] = locInfo;
        //    }
        //}

        private static string GetBriefInfo(string orgCode)
        {
            if (orgCode.Trim() == System.Configuration.ConfigurationManager.AppSettings["BriefOrgCodeQf"].ToString().Trim())
                return "政府办";
            else if (orgCode.Trim() == System.Configuration.ConfigurationManager.AppSettings["BriefOrgCodeQw"].ToString().Trim())
                return "区委办";
            else
                return "";
        }


        #region 获取部门协同角色 edit by whc 20100513
        /// <summary>
        /// 获取部门协同的角色集合
        /// edit by whc 20100513
        /// </summary>
        /// <param name="userUid"></param>
        /// <returns></returns>
        //private static ArrayList GetDeptRole(string userUid)
        //{
        //    ArrayList list = new ArrayList();
        //    RuntimeConfig.Instance.ApplicationCode = "BMXT";
        //    RuntimeConfig.Instance.ApplicationPassword = "BMXT";
        //    Role[] roles = ServiceFactory.Instance().GetRoleService().QueryUserRoles(userUid);
        //    for (int i = 0; i < roles.Length; i++)
        //    {
        //        list.Add(roles[i].RoleCode);
        //    }
        //    return list;
        //}

        /// <summary>
        /// 判断当前机构是否有部门协同系统
        /// edit by whc 20100513
        /// </summary>
        /// <returns></returns>
        private static bool HasDeptRole(string UnitCode)
        {
            bool flag = false;
            string[] DeptsCode = null;
            if (System.Configuration.ConfigurationManager.AppSettings["DeptsCode"] != null)
            {
                //DeptsCode以逗号分隔，英文大写
                DeptsCode = System.Configuration.ConfigurationManager.AppSettings["DeptsCode"].ToString().Split(',');
                for (int i = 0; i < DeptsCode.Length; i++)
                {
                    if (DeptsCode[i] == UnitCode)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        #endregion
    }
}
