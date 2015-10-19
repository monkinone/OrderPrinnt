using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.DAO
{
  public  class WaiKeImgDAO
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from WaiKeImg  Where 1=1  " + strWhere;
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
        public static int Insertmod(WaiKeImgMOD mod)
        {
            string sqlCommandString =string.Format(
                @" IF not exists(select 1 from WaiKeImg where waiKeNo='{0}') 
                      BEGIN
                      Insert Into WaiKeImg(waiKeNo,waiKeImg,isModify)Values(@waiKeNo,@waiKeImg,@isModify) 
                      END ",mod.WaiKeNo);
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@waiKeNo", mod.WaiKeNo);
            arParams[1] = new SqlParameter("@waiKeImg", mod.WaiKeImg);
            arParams[2] = new SqlParameter("@isModify", mod.IsModify);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(WaiKeImgMOD mod)
        {
            string sqlCommandString = "Update WaiKeImg Set waiKeImg=@waiKeImg,isModify=@isModify Where imgId=@imgId";
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@imgId", mod.ImgId);
            arParams[1] = new SqlParameter("@waiKeImg", mod.WaiKeImg);
            arParams[2] = new SqlParameter("@isModify", mod.IsModify);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(string waiKeNo)
        {
            string sqlCommandString = "Update WaiKeImg Set isModify=0 Where waiKeNo=@waiKeNo";
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@waiKeNo", waiKeNo);
            
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From WaiKeImg Where imgId in (" + id + ")";

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
        public static WaiKeImgMOD GetmodByid(int id)
        {
            WaiKeImgMOD mod = new WaiKeImgMOD();
            string sqlcommandString = "select * from WaiKeImg where imgId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ImgId = Convert.ToInt32(reader["ImgId"].ToString());
                    mod.WaiKeNo = reader["WaiKeNo"].ToString();
                    mod.WaiKeImg = reader["WaiKeImg"].ToString();
                    mod.IsModify =Convert.ToInt32( reader["IsModify"].ToString());
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
        public static WaiKeImgMOD GetmodByid(string waiKeNo)
        {
            WaiKeImgMOD mod = new WaiKeImgMOD();
            string sqlcommandString = "select * from WaiKeImg where waiKeNo='" + waiKeNo + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ImgId = Convert.ToInt32(reader["ImgId"].ToString());
                    mod.WaiKeNo = reader["WaiKeNo"].ToString();
                    mod.WaiKeImg = reader["WaiKeImg"].ToString();
                    mod.IsModify = Convert.ToInt32(reader["IsModify"].ToString());
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
