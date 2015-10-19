using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderPrintSystem.DAO
{
    public class PrintSGDCountDAO
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(PrintSGDCountMOD mod)
        {
            string sqlCommandString = "Insert Into PrintSGDCount(OrderNum,ProType,PrintCount)Values(@OrderNum,@ProType,@PrintCount)";
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@OrderNum", mod.OrderNum);
            arParams[1] = new SqlParameter("@ProType", mod.ProType);
            arParams[2] = new SqlParameter("@PrintCount", mod.PrintCount);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(PrintSGDCountMOD mod)
        {
            string sqlCommandString = "Update PrintSGDCount Set PrintCount=@PrintCount Where OrderNum=@OrderNum and ProType=@ProType";
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@OrderNum", mod.OrderNum);
            arParams[1] = new SqlParameter("@ProType", mod.ProType);
            arParams[2] = new SqlParameter("@PrintCount", mod.PrintCount);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }

        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PrintSGDCountMOD GetmodByid(string orderNum,string proType)
        {
            PrintSGDCountMOD mod = new PrintSGDCountMOD();
            string sqlcommandString = "select * from PrintSGDCount where OrderNum='"+orderNum+"' and ProType='"+proType+"'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    if (reader["PrintCount"] != null && reader["PrintCount"].ToString() != "")
                    {
                        mod.PrintCount = Convert.ToInt32(reader["PrintCount"].ToString());
                    }
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
