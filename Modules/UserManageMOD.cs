using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class UserManageMOD
    {
        private int _userId;
        private string _userName;
        private string _trueName;
        private string _phone;
        private int _userType;
        private string _userPass;
        private int _loginNum;
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginNum
        {
            get { return _loginNum; }
            set { _loginNum = value; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass
        {
            get { return _userPass; }
            set { _userPass = value; }
        }
        /// <summary>
        /// 用户身份（管理1，生产2，技术3）
        /// </summary>
        public int UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName
        {
            get { return _trueName; }
            set { _trueName = value; }
        }
        /// <summary>
        ///  用户登录名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
