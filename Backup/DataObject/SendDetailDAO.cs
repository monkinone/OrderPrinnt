using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderPrintSystem.DAO
{
    public class SendDetailDAO
    {
        /// <summary>
        /// 获取当前订单当前型号最后一次发货数量
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        public static object GetSendCountByProType(string proType,string orderNum)
        {
            string sqlCommandString = @"select sendProNum from SendDetail Where proType = '" + proType + "' and orderNum='"+orderNum+"' order by  sendId desc";
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
        /// <summary>
        /// 获取当天最大随工单号
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static object GetSuigondanMax(string date)
        {
            string sqlCommandString = @"select suiGongDanNum from SendDetail Where suiGongDanNum like '%" + date + "%' order by  suiGongDanNum desc";
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
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from SendDetail Where 1=1  " + strWhere;
            string orderSql = " order by sendId desc";
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
        /// 产品数量统计列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetProList(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select s.sendId,s.orderNum,s.proType,s.sendProNum,s.sendTime,s.packingCompanyName,s.sendNum,s.SuiGongDanNum
,o.editTime
,c.companyName 
from SendDetail s
left join proOrders o on o.orderNum=s.orderNum
left join customer c on o.customNum=c.customerNo Where 1=1  " + strWhere;
            string orderSql = " order by sendId desc";
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
            string sqlCommandString = @"select * from SendDetail Where 1=1  " + strWhere + " order by sendId desc";
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
        public static int Insertmod(SendDetailMOD mod)
        {
            string sqlCommandString = "Insert Into SendDetail(OrderNum,ProType,SendProNum,UnitPrice,SendTime,Remark,SuiGongDanNum,PrintCompanyName)Values(@OrderNum,@ProType,@SendProNum,@UnitPrice,@SendTime,@Remark,@SuiGongDanNum,@PrintCompanyName)";
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@OrderNum", mod.OrderNum);
            arParams[1] = new SqlParameter("@ProType", mod.ProType);
            arParams[2] = new SqlParameter("@SendProNum", mod.SendProNum);
            arParams[3] = new SqlParameter("@UnitPrice", mod.UnitPrice);
            arParams[4] = new SqlParameter("@SendTime", mod.SendTime);
            arParams[5] = new SqlParameter("@Remark", mod.Remark);
            arParams[6] = new SqlParameter("@SuiGongDanNum", mod.SuiGongDanNum);
            arParams[7] = new SqlParameter("@PrintCompanyName", mod.PrintCompanyName);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(SendDetailMOD mod)
        {
            string sqlCommandString = "Update SendDetail Set SendProNum=@SendProNum Where OrderNum=@OrderNum";
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@OrderNum", mod.OrderNum);
            arParams[1] = new SqlParameter("@SendProNum", mod.SendProNum);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 根据订单号修改发货信息
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="sendNum"></param>
        /// <param name="packingCompanyName"></param>
        /// <returns></returns>
        public static int UpdateSendInfoByOrderNum(string orderNum, string sendNum, string packingCompanyName)
        {
            string sqlCommandString = "Update SendDetail Set sendNum=@sendNum,packingCompanyName=@packingCompanyName Where OrderNum=@OrderNum";
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@sendNum", sendNum);
            arParams[1] = new SqlParameter("@packingCompanyName", packingCompanyName);
            arParams[2] = new SqlParameter("@OrderNum", orderNum);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="orderNUM"></param>
        /// <returns></returns>
        public static int Delete(string orderNUM)
        {
            string sqlCommandString = "delete from  SendDetail  Where OrderNum=@OrderNum";
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@OrderNum", orderNUM);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SendDetailMOD GetmodByid(string ProType)
        {
            SendDetailMOD mod = new SendDetailMOD();
            string sqlcommandString = "select * from SendDetail where ProType='" + ProType + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.OrderNum = reader["OrderNum"].ToString();
                    mod.ProType = reader["ProType"].ToString();
                    mod.SendId = Convert.ToInt32(reader["SendId"].ToString());
                    mod.SendProNum = Convert.ToInt32(reader["SendProNum"].ToString());
                    mod.SendTime = Convert.ToDateTime(reader["SendTime"].ToString());
                    mod.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    mod.Remark = reader["Remark"].ToString();
                    mod.SendNum = reader["SendNum"].ToString();
                    mod.PackingCompanyName = reader["PackingCompanyName"].ToString();
                    mod.SuiGongDanNum = reader["SuiGongDanNum"].ToString();
                    mod.PrintCompanyName = reader["PrintCompanyName"].ToString();
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
        public static SendDetailMOD GetmodByid(string ProType,string orderNum)
        {
            SendDetailMOD mod = new SendDetailMOD();
            string sqlcommandString = "select * from SendDetail where ProType='" + ProType + "' and OrderNum='" + orderNum + "' order by SendId desc";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.OrderNum = reader["OrderNum"].ToString();
                    mod.ProType = reader["ProType"].ToString();
                    mod.SendId = Convert.ToInt32(reader["SendId"].ToString());
                    mod.SendProNum = Convert.ToInt32(reader["SendProNum"].ToString());
                    mod.SendTime = Convert.ToDateTime(reader["SendTime"].ToString());
                    mod.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    mod.Remark = reader["Remark"].ToString();
                    mod.SendNum = reader["SendNum"].ToString();
                    mod.PackingCompanyName = reader["PackingCompanyName"].ToString();
                    mod.SuiGongDanNum = reader["SuiGongDanNum"].ToString();
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
        /// 根据订单号查询发货明细
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static SendDetailMOD GetModByOrderNum(string orderNum)
        {
            SendDetailMOD mod = new SendDetailMOD();
            string sqlcommandString = "select * from SendDetail where OrderNum='" + orderNum + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.OrderNum = reader["OrderNum"].ToString();
                    mod.ProType = reader["ProType"].ToString();
                    mod.SendId = Convert.ToInt32(reader["SendId"].ToString());
                    mod.SendProNum = Convert.ToInt32(reader["SendProNum"].ToString());
                    mod.SendTime = Convert.ToDateTime(reader["SendTime"].ToString());
                    mod.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    mod.Remark = reader["Remark"].ToString();
                    mod.SendNum = reader["SendNum"].ToString();
                    mod.PackingCompanyName = reader["PackingCompanyName"].ToString();
                    mod.SuiGongDanNum = reader["SuiGongDanNum"].ToString();
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
