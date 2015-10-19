using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.DAO
{
    public class MattersNeedingAttentionDAO
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from MattersNeedingAttention Where 1=1  " + strWhere;
            string orderSql = " order by id desc";
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
            string sqlCommandString = @"select * from MattersNeedingAttention Where 1=1  " + strWhere;
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
        public static int Insertmod(MattersNeedingAttentionMOD mod)
        {
            string sqlCommandString = "Insert Into MattersNeedingAttention(customerNo,contents)Values(@customerNo,@contents)";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@customerNo", mod.CustomerNo);
            arParams[1] = new SqlParameter("@contents", mod.Contents);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(MattersNeedingAttentionMOD mod)
        {
            string sqlCommandString = "Update MattersNeedingAttention Set contents=@contents Where id=@id";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id", mod.Id);
            arParams[1] = new SqlParameter("@contents", mod.Contents);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From MattersNeedingAttention Where id in (" + id + ")";

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
        public static MattersNeedingAttentionMOD GetmodByid(int id)
        {
            MattersNeedingAttentionMOD mod = new MattersNeedingAttentionMOD();
            string sqlcommandString = "select * from MattersNeedingAttention where id=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.Contents = reader["Contents"].ToString();
                    mod.CustomerNo = reader["CustomerNo"].ToString();
                    mod.Id = Convert.ToInt32(reader["Id"].ToString());
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
        public static MattersNeedingAttentionMOD GetmodByid(string CustomerNo)
        {
            MattersNeedingAttentionMOD mod = new MattersNeedingAttentionMOD();
            string sqlcommandString = "select * from MattersNeedingAttention where CustomerNo like '%"+CustomerNo+"%'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.Contents = reader["Contents"].ToString();
                    mod.CustomerNo = reader["CustomerNo"].ToString();
                    mod.Id = Convert.ToInt32(reader["Id"].ToString());
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
