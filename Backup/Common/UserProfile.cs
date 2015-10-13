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
		#region ��Ա����
		private String _id;//�û�ID��
		private String _uid;//�û�Ӣ�����ƣ���¼�ã�
		private String _name;//�û�ȫ��
		private String _sex;//�Ա�
        private String _deptid;//���Ŵ���
		private String _deptname;//��������
		private Boolean _flag;//�˺��Ƿ�ͣ��
		private String _demo;//��ע
        private String _unitid;//
		private String _unitname;//
        private String _skin;
        private ArrayList _callBoardRoles;//���û����е�֪ͨ����Ľ�ɫ
        private String _briefOrgInfo;//��Ϣ������������������ί��λ������ͳ���ã�
        private ArrayList _deptRoles;  //����Эͬ��ɫ��Ϣ edit by whc time 20100513
		#endregion

		#region ���캯��
		public UserProfile() 
		{
		}

        //public UserProfile(XmlNode node)
        //{
        //    BuildByXML(node);
        //}

		#endregion

		#region ��������


		/// <summary>
		/// �û�ID��
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
		/// �û�Ӣ�����ƣ���¼�ã�
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
		/// �û�ȫ��
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
		/// �Ա�
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
		/// ���Ŵ���
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
		/// ��������
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
		/// �˺��Ƿ�ͣ��
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
		/// ��ע
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
        /// ��ȡ����Эͬ��ɫ��Ϣ
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
        ///// ͨ��XML�����û���Ϣ
        ///// </summary>
        ///// <param name="node">XML�ڵ�</param>
        //private void BuildByXML(XmlNode node)
        //{
        //    if (null == node)
        //        throw new ArgumentNullException("��ͳһ��Ȩ���ص�XML������Ч!");
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
        //        throw new Exception("��ͳһ��Ȩ���ص�XML������Ч!");
        //    }
        //}

        /// <summary>
        /// ��Session��õ�¼�û���Ϣ
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
        ///// ��UserModule�������Session
        ///// </summary>
        ///// <param name="objSession">session</param>
        //public static void SetUserInfo2Session(HttpSessionState objSession, UserBaseInfo cenInfo,UserProfile locInfo)
        //{
        //    if (null == cenInfo)
        //        throw new ArgumentNullException("��ͳһ��Ȩ���ص�������Ч!");

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
        //        throw new Exception("��ͳһ��Ȩ���ص�XML������Ч!");
        //    }
        //    objSession[C_SESSION_KEY] = locInfo;
        //}

        /// <summary>
        /// ��UserModule�������Session
        /// </summary>
        /// <param name="objSession">session</param>
        //public static void SetUserInfo2Session(HttpSessionState objSession, UserProfile locInfo)
        //{
        //    if (objSession[C_SESSION_KEY] == null)
        //    {
        //        string userUid = Beyondbit.SingleSignOn.ClientForAspNet20.SSOClient.UserUid;
        //        if (string.IsNullOrEmpty(userUid))
        //            throw new ArgumentNullException("�ӵ����¼��ȡ�û����ʧ��!");

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
        //                //��ȡ�û�����Эͬ��ɫ��Ϣ
        //                if (HasDeptRole(user.UnitCode))
        //                    locInfo.DeptRoles = GetDeptRole(user.UserUid);
        //            }
        //            catch { }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("��ͳһ��Ȩ���ص�XML������Ч!");
        //        }
        //        objSession[C_SESSION_KEY] = locInfo;
        //    }
        //}

        private static string GetBriefInfo(string orgCode)
        {
            if (orgCode.Trim() == System.Configuration.ConfigurationManager.AppSettings["BriefOrgCodeQf"].ToString().Trim())
                return "������";
            else if (orgCode.Trim() == System.Configuration.ConfigurationManager.AppSettings["BriefOrgCodeQw"].ToString().Trim())
                return "��ί��";
            else
                return "";
        }


        #region ��ȡ����Эͬ��ɫ edit by whc 20100513
        /// <summary>
        /// ��ȡ����Эͬ�Ľ�ɫ����
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
        /// �жϵ�ǰ�����Ƿ��в���Эͬϵͳ
        /// edit by whc 20100513
        /// </summary>
        /// <returns></returns>
        private static bool HasDeptRole(string UnitCode)
        {
            bool flag = false;
            string[] DeptsCode = null;
            if (System.Configuration.ConfigurationManager.AppSettings["DeptsCode"] != null)
            {
                //DeptsCode�Զ��ŷָ���Ӣ�Ĵ�д
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
