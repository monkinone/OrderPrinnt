using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderPrintSystem.DAO
{
    public class GuiGeShuDAO
    {
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            string sqlCommandString = @"select * from GuiGeShu Where 1=1  " + strWhere;
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
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from GuiGeShu  Where 1=1  " + strWhere;
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
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(GuiGeShuMOD mod)
        {
            string sqlCommandString = "Insert Into GuiGeShu(FileUrl,productNo)Values(@FileUrl,@productNo)";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@FileUrl", mod.FileUrl);
            arParams[1] = new SqlParameter("@productNo", mod.ProductNo);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(GuiGeShuMOD mod)
        {
            string sqlCommandString = "Update GuiGeShu Set FileUrl=@FileUrl where productNo=@productNo";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@FileUrl", mod.FileUrl);
            arParams[1] = new SqlParameter("@productNo", mod.ProductNo);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string productNo)
        {
            string sqlCommandString = "Delete From GuiGeShu Where productNo ='" + productNo + "'";

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
        public static GuiGeShuMOD GetmodByid(string productNo)
        {
            GuiGeShuMOD mod = new GuiGeShuMOD();
            string sqlcommandString = "select * from GuiGeShu where productNo like '%" + productNo + "%'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.Id = Convert.ToInt32(reader["id"].ToString());
                    mod.FileUrl = reader["FileUrl"].ToString();
                    mod.ProductNo = reader["productNo"].ToString();
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

        public static GuiGeShuMOD GetmodByProduct(string productNo)
        {
            GuiGeShuMOD mod = new GuiGeShuMOD();
            string sqlcommandString = "select * from GuiGeShu where productNo='" + productNo + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.Id = Convert.ToInt32(reader["id"].ToString());
                    mod.FileUrl = reader["FileUrl"].ToString();
                    mod.ProductNo = reader["productNo"].ToString();
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
