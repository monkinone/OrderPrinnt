using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OrderPrintSystem.Modules;
using System.Data;
using NewsSystem.DBUtility;

namespace OrderPrintSystem.DAO
{
   public class PriceManageDAO
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select p.*,c.companyName from PriceManage p inner join customer c on p.customNo=c.customerNo Where 1=1  " + strWhere;
            string orderSql = " order by priceId desc";
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
            string sqlCommandString = @"select p.*,c.companyName from PriceManage p inner join customer c on p.customNo=c.customerNo Where 1=1  " + strWhere;
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
        public static int Insertmod(PriceManageMOD mod)
        {
            string sqlCommandString = "Insert Into PriceManage(customNo,productNo,price)Values(@customNo,@productNo,@price)";
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@customNo", mod.CustomNo);
            arParams[1] = new SqlParameter("@productNo", mod.ProductNo);
            arParams[2] = new SqlParameter("@price", mod.Price);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(PriceManageMOD mod)
        {
            string sqlCommandString = "Update PriceManage Set price=@price Where priceId=@priceId";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@priceId", mod.PriceId);
            arParams[1] = new SqlParameter("@price", mod.Price);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From PriceManage Where priceId in (" + id + ")";

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
        public static PriceManageMOD GetmodByid(int id)
        {
            PriceManageMOD mod = new PriceManageMOD();
            string sqlcommandString = "select * from PriceManage where priceId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ProductNo = reader["ProductNo"].ToString();
                    mod.CustomNo = reader["CustomNo"].ToString();
                    mod.PriceId = Convert.ToInt32(reader["PriceId"].ToString());
                    mod.Price =Convert.ToDecimal( reader["Price"].ToString());
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
        public static PriceManageMOD GetmodByid(string CustomNo,string proType)
        {
            PriceManageMOD mod = new PriceManageMOD();
            string sqlcommandString = "select * from PriceManage where CustomNo='"+CustomNo+"' and ProductNo='"+proType+"'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ProductNo = reader["ProductNo"].ToString();
                    mod.CustomNo = reader["CustomNo"].ToString();
                    mod.PriceId = Convert.ToInt32(reader["PriceId"].ToString());
                    mod.Price = Convert.ToDecimal(reader["Price"].ToString());
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
