using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using OrderPrintSystem.Modules;
using OrderPrintSystem.DAO;

namespace OrderPrintSystem.BLL
{
   public class UserManageBLL
    {
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetUserAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return UserManageDAO.GetUserAll(PageSize,PageIndex,out PageCount,strWhere);
        }
        /// <summary>
       /// 获取用户信息无分页
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
        public static DataSet GetUserAll(string strWhere)
        {
            return UserManageDAO.GetUserAll(strWhere);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="dtoUserList">用户对象</param>
        /// <returns></returns>
        public static int InsertUser(UserManageMOD user)
        {
            return UserManageDAO.InsertUser(user);

        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="dtoUserList">用户数据对象</param>
        /// <returns></returns>
        public static int UpdateUser(UserManageMOD user)
        {
            return UserManageDAO.UpdateUser(user);
        }
        /// <summary>
       /// 修改用户密码
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
        public static int UpdateUserPass(string pass, string userid)
        {
            return UserManageDAO.UpdateUserPass(pass,userid);
        }
       /// <summary>
       /// 修改用户登录次数
       /// </summary>
       /// <param name="userid"></param>
       /// <param name="loginNUM"></param>
       /// <returns></returns>
        public static int UpdateUserLoginNum(string userid, int loginNUM)
        {
            return UserManageDAO.UpdateUserLoginNum(userid,loginNUM);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return UserManageDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserManageMOD GetUserByid(int id)
        {
            return UserManageDAO.GetUserByid(id);
        }
        /// <summary>
       /// 根据用户名及密码判断用户是否存在
       /// </summary>
       /// <param name="userName"></param>
       /// <param name="userPass"></param>
       /// <returns></returns>
        public static UserManageMOD isExitUser(string userName, string userPass)
        {
            return UserManageDAO.isExitUser(userName, userPass);
        }
    }
}
