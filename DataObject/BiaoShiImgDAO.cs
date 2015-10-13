using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderPrintSystem.DAO
{
   public class BiaoShiImgDAO
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from BiaoShiImg  Where 1=1  " + strWhere;
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
            string sqlCommandString = @"select * from  Where 1=1  " + strWhere;
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
        public static int Insertmod(BiaoShiImgMOD mod)
        {
            string sqlCommandString = string.Format(
            @"IF not exists(select 1 from BiaoShiImg where BiaoShiNo='{0}') 
                 BEGIN
                 Insert Into BiaoShiImg(BiaoShiNo,BiaoShiImg) Values (@BiaoShiNo,@BiaoShiImg) 
                 END ",mod.BiaoShiNo);
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@BiaoShiNo", mod.BiaoShiNo);
            arParams[1] = new SqlParameter("@BiaoShiImg", mod.BiaoShiImg);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(BiaoShiImgMOD mod)
        {
            string sqlCommandString = "Update BiaoShiImg Set BiaoShiImg=@BiaoShiImg Where imgId=@imgId";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@imgId", mod.ImgId);
            arParams[1] = new SqlParameter("@BiaoShiImg", mod.BiaoShiImg);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
      

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From BiaoShiImg Where imgId in (" + id + ")";

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
        public static BiaoShiImgMOD GetmodByid(int id)
        {
            BiaoShiImgMOD mod = new BiaoShiImgMOD();
            string sqlcommandString = "select * from BiaoShiImg where imgId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ImgId = Convert.ToInt32(reader["ImgId"].ToString());
                    mod.BiaoShiNo = reader["BiaoShiNo"].ToString();
                    mod.BiaoShiImg = reader["BiaoShiImg"].ToString();
                
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
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BiaoShiImgMOD GetmodByid(string BiaoShiNo)
        {
            BiaoShiImgMOD mod = new BiaoShiImgMOD();
            string sqlcommandString = "select * from BiaoShiImg where BiaoShiNo='" + BiaoShiNo + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ImgId = Convert.ToInt32(reader["ImgId"].ToString());
                    mod.BiaoShiNo = reader["BiaoShiNo"].ToString();
                    mod.BiaoShiImg = reader["BiaoShiImg"].ToString();
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
