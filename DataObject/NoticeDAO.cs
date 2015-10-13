using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderPrintSystem.DAO
{
    public class NoticeDAO
    {
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            string sqlCommandString = @"select * from Notice Where 1=1  " + strWhere;
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
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(NoticeMOD mod)
        {
            string sqlCommandString = "Insert Into Notice(title,contents)Values(@title,@contents)";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@title", mod.Title);
            arParams[1] = new SqlParameter("@contents", mod.Contents);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(NoticeMOD mod)
        {
            string sqlCommandString = "Update Notice Set Title=@Title, contents=@contents";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Title", mod.Title);
            arParams[1] = new SqlParameter("@contents", mod.Contents);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NoticeMOD GetmodByid(int id)
        {
            NoticeMOD mod = new NoticeMOD();
            string sqlcommandString = "select * from Notice where imgId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.Contents = reader["Contents"].ToString();
                    mod.Title = reader["Title"].ToString();
                    mod.NoticeId = Convert.ToInt32(reader["NoticeId"].ToString());

                }
                reader.Close();
                return mod;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
