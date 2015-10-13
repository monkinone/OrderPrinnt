using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.DAO
{
    public class UserManageDAO
    {
        public UserManageDAO() : base() { }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetUserAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from UserManage Where 1=1  " + strWhere;
            string orderSql = " order by userId desc";
            try
            {
                List<SqlParameter> commandParameters = new List<SqlParameter>();
                return SqlHelper.getDataSetOfPage(PageSize, PageIndex, out PageCount, sqlCommandString, commandParameters, CommandType.Text, orderSql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 获取用户信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetUserAll(string strWhere)
        {
            string sqlCommandString = @"select * from UserManage Where 1=1  " + strWhere;
            try
            {
                List<SqlParameter> commandParameters = new List<SqlParameter>();
                return SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlCommandString, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="dtoUserList">用户对象</param>
        /// <returns></returns>
        public static int InsertUser(UserManageMOD user)
        {
            string sqlCommandString = "Insert Into UserManage(userName,trueName,phone,userType,userPass,loginNum)Values(@userName,@trueName,@phone,@userType,@userPass,@loginNum)";
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@userName", user.UserName);
            arParams[1] = new SqlParameter("@trueName", user.TrueName);
            arParams[2] = new SqlParameter("@phone", user.Phone);
            arParams[3] = new SqlParameter("@userType", user.UserType);
            arParams[4] = new SqlParameter("@userPass", user.UserPass);
            arParams[5] = new SqlParameter("@loginNum", user.LoginNum);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="dtoUserList">用户数据对象</param>
        /// <returns></returns>
        public static int UpdateUser(UserManageMOD user)
        {
            string sqlCommandString = "Update UserManage Set phone=@phone,userType=@userType,userPass=@userPass Where userId=@userId";
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@userId", user.UserId);
            arParams[1] = new SqlParameter("@phone", user.Phone);
            arParams[2] = new SqlParameter("@userType", user.UserType);
            arParams[3] = new SqlParameter("@userPass", user.UserPass);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateUserPass(string pass, string userid)
        {
            string sqlCommandString = "Update UserManage Set userPass=@userPass Where userId=@userId";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@userId", userid);
            arParams[1] = new SqlParameter("@userPass", pass);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 修改用户登录次数
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="loginNUM"></param>
        /// <returns></returns>
        public static int UpdateUserLoginNum(string userid, int loginNUM)
        {
            string sqlCommandString = "Update UserManage Set loginNum=@loginNum Where userId=@userId";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@userId", userid);
            arParams[1] = new SqlParameter("@loginNum", loginNUM);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From UserManage Where userId in (" + id + ")";

            try
            {
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 根据主键id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserManageMOD GetUserByid(int id)
        {
            UserManageMOD user = new UserManageMOD();
            string sqlcommandString = "select * from UserManage where userId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    user.LoginNum = Convert.ToInt32(reader["LoginNum"].ToString());
                    user.Phone = reader["Phone"].ToString();
                    user.TrueName = reader["TrueName"].ToString();
                    user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.UserPass = reader["UserPass"].ToString();
                    user.UserType = Convert.ToInt32(reader["UserType"].ToString());
                }
                reader.Close();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 根据用户名及密码判断用户是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public static UserManageMOD isExitUser(string userName, string userPass)
        {
            UserManageMOD user = new UserManageMOD();
            string sqlcommandString = "select * from UserManage where UserName='" + userName + "' and UserPass='" + userPass + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    user.LoginNum = Convert.ToInt32(reader["LoginNum"].ToString());
                    user.Phone = reader["Phone"].ToString();
                    user.TrueName = reader["TrueName"].ToString();
                    user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.UserPass = reader["UserPass"].ToString();
                    user.UserType = Convert.ToInt32(reader["UserType"].ToString());
                }
                reader.Close();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
