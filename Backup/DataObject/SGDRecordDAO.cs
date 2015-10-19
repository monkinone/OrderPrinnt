using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderPrintSystem.DAO
{
    public class SGDRecordDAO
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(SGDRecordMOD mod)
        {
            string sqlCommandString = @"IF(not exists(select * from SGDRecord where suigongdan=@suigongdan))
                                                               BEGIN
                                                               Insert Into SGDRecord(orderNum,customerNum,proType,suigongdan,PrintCount) Values 
                                                               (@orderNum,@customerNum,@proType,@suigongdan,@PrintCount)
                                                               END";
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@orderNum", mod.OrderNum);
            arParams[1] = new SqlParameter("@customerNum", mod.ProType);
            arParams[2] = new SqlParameter("@proType", mod.ProType);
            arParams[3] = new SqlParameter("@suigongdan", mod.Suigongdan);
            arParams[4] = new SqlParameter("@PrintCount", mod.PrintCount);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 获取当天最大随工单号
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static object GetSuigondanMax(string date)
        {
            string sqlCommandString = @"select suigongdan from SGDRecord Where suigongdan like '%" + date + "%' order by  suigongdan desc";
            try
            {
                List<SqlParameter> commandParameters = new List<SqlParameter>();
                return SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlCommandString, commandParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public System.Data.DataSet SearchSGD(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select distinct orderNum,customerNum,proType,suigongdan,PrintCount 
                                                          from SGDRecord  where 1=1 " + strWhere;
            string orderSql = " order by suigongdan desc";
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
    }
}
