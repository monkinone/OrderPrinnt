using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OrderPrintSystem.Modules;
using NewsSystem.DBUtility;
using System.Data;

namespace OrderPrintSystem.DAO
{
    public class GuanJiaoZhenImgDAO
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from GuanJiaoZhenImg  Where 1=1  " + strWhere;
            string orderSql = " order by imgId desc";
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
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            string sqlCommandString = @"select * from GuanJiaoZhenImg Where 1=1  " + strWhere;
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
        public static int Insertmod(GuanJiaoZhenImgMOD mod)
        {
            string sqlCommandString = string.Format(
            @"IF not exists(select 1 from GuanJiaoZhenImg where guanJiaoZhenNo='{0}') 
                BEGIN
                Insert Into GuanJiaoZhenImg(guanJiaoZhenNo,guanJiaoZhenImg) Values (@guanJiaoZhenNo,@guanJiaoZhenImg) 
                END",mod.GuanJiaoZhenNo);
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@guanJiaoZhenNo", mod.GuanJiaoZhenNo);
            arParams[1] = new SqlParameter("@guanJiaoZhenImg", mod.GuanJiaoZhenImg);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(GuanJiaoZhenImgMOD mod)
        {
            string sqlCommandString = "Update GuanJiaoZhenImg Set guanJiaoZhenImg=@guanJiaoZhenImg Where imgId=@imgId";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@imgId", mod.ImgId);
            arParams[1] = new SqlParameter("@guanJiaoZhenImg", mod.GuanJiaoZhenImg);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From GuanJiaoZhenImg Where imgId in (" + id + ")";

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
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GuanJiaoZhenImgMOD GetmodByid(int id)
        {
            GuanJiaoZhenImgMOD mod = new GuanJiaoZhenImgMOD();
            string sqlcommandString = "select * from GuanJiaoZhenImg where imgId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.GuanJiaoZhenImg = reader["GuanJiaoZhenImg"].ToString();
                    mod.GuanJiaoZhenNo = reader["GuanJiaoZhenNo"].ToString();
                    mod.ImgId = Convert.ToInt32(reader["imgId"].ToString());

                }
                reader.Close();
                return mod;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 根据主键管脚真型号查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GuanJiaoZhenImgMOD GetmodByid(string GuanJiaoZhenNo)
        {
            GuanJiaoZhenImgMOD mod = new GuanJiaoZhenImgMOD();
            string sqlcommandString = "select * from GuanJiaoZhenImg where GuanJiaoZhenNo='" + GuanJiaoZhenNo + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.GuanJiaoZhenImg = reader["GuanJiaoZhenImg"].ToString();
                    mod.GuanJiaoZhenNo = reader["GuanJiaoZhenNo"].ToString();
                    mod.ImgId = Convert.ToInt32(reader["imgId"].ToString());
                    reader.Close();
                    return mod;
                }
                else
                {
                    reader.Close();
                    return null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
