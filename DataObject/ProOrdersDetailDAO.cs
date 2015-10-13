
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using System.Collections.Generic;
namespace OrderPrintSystem.DAL
{
    /// <summary>
    /// 数据访问类:proOrdersDetail
    /// </summary>
    public partial class ProOrdersDetailDAO
    {
        public ProOrdersDetailDAO()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(OrderPrintSystem.Model.ProOrdersDetailMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into proOrdersDetail(");
            strSql.Append("orderNum,proType,proNum,ProPrice)");
            strSql.Append(" values (");
            strSql.Append("@orderNum,@proType,@proNum,@ProPrice)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100),
					new SqlParameter("@proType", SqlDbType.VarChar,100),
					new SqlParameter("@proNum", SqlDbType.Int,4),
					new SqlParameter("@ProPrice", SqlDbType.Decimal,9)};
            parameters[0].Value = model.orderNum;
            parameters[1].Value = model.proType;
            parameters[2].Value = model.proNum;
            parameters[3].Value = model.ProPrice;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(OrderPrintSystem.Model.ProOrdersDetailMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update proOrdersDetail set ");
            strSql.Append("orderNum=@orderNum,");
            strSql.Append("proType=@proType,");
            strSql.Append("proNum=@proNum,");
            strSql.Append("ProPrice=@ProPrice,");
            strSql.Append("withWorkNo=@withWorkNo,");
            strSql.Append("piHao=@piHao,");
            strSql.Append("planSendTime=@planSendTime,");
            strSql.Append("productAddress=@productAddress");
            strSql.Append(" where orderDetailId=@orderDetailId");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100),
					new SqlParameter("@proType", SqlDbType.VarChar,100),
					new SqlParameter("@proNum", SqlDbType.Int,4),
					new SqlParameter("@ProPrice", SqlDbType.Decimal,9),
					new SqlParameter("@withWorkNo", SqlDbType.VarChar,50),
                    new SqlParameter("@piHao",SqlDbType.VarChar,50),
                    new SqlParameter("@planSendTime",SqlDbType.DateTime),
                    new SqlParameter("@productAddress",SqlDbType.VarChar,100),
                    new SqlParameter("@orderDetailId", SqlDbType.Int,4)};
            parameters[0].Value = model.orderNum;
            parameters[1].Value = model.proType;
            parameters[2].Value = model.proNum;
            parameters[3].Value = model.ProPrice;
            parameters[4].Value = model.withWorkNo;
            parameters[5].Value = model.PiHao;
            parameters[6].Value = model.PlanSendTime;
            parameters[7].Value = model.ProductAddress;
            parameters[8].Value = model.orderDetailId;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int UpdateOrder(OrderPrintSystem.Model.ProOrdersDetailMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update proOrdersDetail set ");
            strSql.Append("piHao=@piHao,");
            strSql.Append("planSendTime=@planSendTime,");
            strSql.Append("productAddress=@productAddress,");
            strSql.Append("SGDCount=@SGDCount");
            strSql.Append(" where orderDetailId=@orderDetailId");
            SqlParameter[] parameters = {
                                        new SqlParameter("@piHao",SqlDbType.VarChar,50),
                                        new SqlParameter("@planSendTime",SqlDbType.DateTime),
                                        new SqlParameter("@productAddress",SqlDbType.VarChar,100),
                                        new SqlParameter("@SGDCount",SqlDbType.Int,4),
                                        new SqlParameter("@orderDetailId", SqlDbType.Int,4)
                                        };

            parameters[0].Value = model.PiHao;
            parameters[1].Value = model.PlanSendTime;
            parameters[2].Value = model.ProductAddress;
            parameters[3].Value = model.SGDCount;
            parameters[4].Value = model.orderDetailId;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 更新数量
        /// </summary>
        public static int Update(int orderDetailId, int num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update proOrdersDetail set ");
            strSql.Append("proNum=@proNum");
            strSql.Append(" where orderDetailId=@orderDetailId");
            SqlParameter[] parameters = {
					new SqlParameter("@proNum", SqlDbType.Int,4),
					new SqlParameter("@orderDetailId", SqlDbType.Int,4)};
            parameters[0].Value = num;
            parameters[1].Value = orderDetailId;


            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int Delete(int orderDetailId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from proOrdersDetail ");
            strSql.Append(" where orderDetailId=@orderDetailId");
            SqlParameter[] parameters = {
					new SqlParameter("@orderDetailId", SqlDbType.Int,4)
			};
            parameters[0].Value = orderDetailId;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 根据订单号删除订单详情
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static int Delete(string orderNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from proOrdersDetail ");
            strSql.Append(" where orderNum=@orderNum");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100)
			};
            parameters[0].Value = orderNum;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static int DeleteList(string orderDetailIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from proOrdersDetail ");
            strSql.Append(" where orderDetailId in (" + orderDetailIdlist + ")  ");
            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            return readers;
        }

        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModelByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderDetailId,orderNum,proType,proNum,ProPrice,withWorkNo,printTime,printType,printCount,PiHao,PlanSendTime,ProductAddress,SGDCount from proOrdersDetail ");
            strSql.Append(" where 1=1 " + strWhere);

            OrderPrintSystem.Model.ProOrdersDetailMOD model = new OrderPrintSystem.Model.ProOrdersDetailMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["orderDetailId"] != null && reader["orderDetailId"].ToString() != "")
                {
                    model.orderDetailId = int.Parse(reader["orderDetailId"].ToString());
                }
                if (reader["orderNum"] != null)
                {
                    model.orderNum = reader["orderNum"].ToString();
                }
                if (reader["proType"] != null)
                {
                    model.proType = reader["proType"].ToString();
                }
                if (reader["proNum"] != null && reader["proNum"].ToString() != "")
                {
                    model.proNum = int.Parse(reader["proNum"].ToString());
                }
                if (reader["ProPrice"] != null && reader["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(reader["ProPrice"].ToString());
                }
                if (reader["withWorkNo"] != null)
                {
                    model.withWorkNo = reader["withWorkNo"].ToString();
                }
                if (reader["printTime"] != null && reader["printTime"].ToString() != "")
                {
                    model.printTime = DateTime.Parse(reader["printTime"].ToString());
                }
                if (reader["printType"] != null)
                {
                    model.printType = reader["printType"].ToString();
                }
                if (reader["printCount"] != null && reader["printCount"].ToString() != "")
                {
                    model.printCount = int.Parse(reader["printCount"].ToString());
                }
                if (reader["PiHao"] != null && reader["PiHao"].ToString() != "")
                {
                    model.PiHao = reader["PiHao"].ToString();
                }
                if (reader["PlanSendTime"] != null && reader["PlanSendTime"].ToString() != "")
                {
                    model.PlanSendTime = Convert.ToDateTime(reader["PlanSendTime"].ToString());
                }
                if (reader["ProductAddress"] != null && reader["ProductAddress"].ToString() != "")
                {
                    model.ProductAddress = reader["ProductAddress"].ToString();
                }
                if (reader["SGDCount"] != null && reader["SGDCount"].ToString() != "")
                {
                    model.SGDCount = Convert.ToInt32(reader["SGDCount"].ToString());
                }
                reader.Close();
                return model;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModel(int orderDetailId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderDetailId,orderNum,proType,proNum,ProPrice,withWorkNo,printTime,printType,printCount,PiHao,PlanSendTime,ProductAddress,SGDCount from proOrdersDetail ");
            strSql.Append(" where orderDetailId=" + orderDetailId);

            OrderPrintSystem.Model.ProOrdersDetailMOD model = new OrderPrintSystem.Model.ProOrdersDetailMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["orderDetailId"] != null && reader["orderDetailId"].ToString() != "")
                {
                    model.orderDetailId = int.Parse(reader["orderDetailId"].ToString());
                }
                if (reader["orderNum"] != null)
                {
                    model.orderNum = reader["orderNum"].ToString();
                }
                if (reader["proType"] != null)
                {
                    model.proType = reader["proType"].ToString();
                }
                if (reader["proNum"] != null && reader["proNum"].ToString() != "")
                {
                    model.proNum = int.Parse(reader["proNum"].ToString());
                }
                if (reader["ProPrice"] != null && reader["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(reader["ProPrice"].ToString());
                }
                if (reader["withWorkNo"] != null)
                {
                    model.withWorkNo = reader["withWorkNo"].ToString();
                }
                if (reader["printTime"] != null && reader["printTime"].ToString() != "")
                {
                    model.printTime = DateTime.Parse(reader["printTime"].ToString());
                }
                if (reader["printType"] != null)
                {
                    model.printType = reader["printType"].ToString();
                }
                if (reader["printCount"] != null && reader["printCount"].ToString() != "")
                {
                    model.printCount = int.Parse(reader["printCount"].ToString());
                }
                if (reader["PiHao"] != null && reader["PiHao"].ToString() != "")
                {
                    model.PiHao = reader["PiHao"].ToString();
                }
                if (reader["PlanSendTime"] != null && reader["PlanSendTime"].ToString() != "")
                {
                    model.PlanSendTime = Convert.ToDateTime(reader["PlanSendTime"].ToString());
                }
                if (reader["ProductAddress"] != null && reader["ProductAddress"].ToString() != "")
                {
                    model.ProductAddress = reader["ProductAddress"].ToString();
                }
                if (reader["SGDCount"] != null && reader["SGDCount"].ToString() != "")
                {
                    model.SGDCount = Convert.ToInt32(reader["SGDCount"].ToString());
                }
                reader.Close();
                return model;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModel(string proType, string orderNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PrintSGDCount from proOrdersDetail ");
            strSql.Append(" where proType='" + proType + "' and orderNum='" + orderNum + "'");

            OrderPrintSystem.Model.ProOrdersDetailMOD model = new OrderPrintSystem.Model.ProOrdersDetailMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["PrintSGDCount"] != null && reader["PrintSGDCount"].ToString() != "")
                {
                    model.PrintSGDCount = int.Parse(reader["PrintSGDCount"].ToString());
                }
            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModel(string proType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderDetailId,orderNum,proType,proNum,ProPrice,withWorkNo,printTime,printType,printCount,PiHao,PlanSendTime,ProductAddress,SGDCount from proOrdersDetail ");
            strSql.Append(" where proType='" + proType + "'");

            OrderPrintSystem.Model.ProOrdersDetailMOD model = new OrderPrintSystem.Model.ProOrdersDetailMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["orderDetailId"] != null && reader["orderDetailId"].ToString() != "")
                {
                    model.orderDetailId = int.Parse(reader["orderDetailId"].ToString());
                }
                if (reader["orderNum"] != null)
                {
                    model.orderNum = reader["orderNum"].ToString();
                }
                if (reader["proType"] != null)
                {
                    model.proType = reader["proType"].ToString();
                }
                if (reader["proNum"] != null && reader["proNum"].ToString() != "")
                {
                    model.proNum = int.Parse(reader["proNum"].ToString());
                }
                if (reader["ProPrice"] != null && reader["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(reader["ProPrice"].ToString());
                }
                if (reader["withWorkNo"] != null)
                {
                    model.withWorkNo = reader["withWorkNo"].ToString();
                }
                if (reader["printTime"] != null && reader["printTime"].ToString() != "")
                {
                    model.printTime = DateTime.Parse(reader["printTime"].ToString());
                }
                if (reader["printType"] != null)
                {
                    model.printType = reader["printType"].ToString();
                }
                if (reader["printCount"] != null && reader["printCount"].ToString() != "")
                {
                    model.printCount = int.Parse(reader["printCount"].ToString());
                }
                if (reader["PiHao"] != null && reader["PiHao"].ToString() != "")
                {
                    model.PiHao = reader["PiHao"].ToString();
                }
                if (reader["PlanSendTime"] != null && reader["PlanSendTime"].ToString() != "")
                {
                    model.PlanSendTime = Convert.ToDateTime(reader["PlanSendTime"].ToString());
                }
                if (reader["ProductAddress"] != null && reader["ProductAddress"].ToString() != "")
                {
                    model.ProductAddress = reader["ProductAddress"].ToString();
                }
                if (reader["SGDCount"] != null && reader["SGDCount"].ToString() != "")
                {
                    model.SGDCount = Convert.ToInt32(reader["SGDCount"].ToString());
                }
            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModelByOrderNum(string orderNUM)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderDetailId,orderNum,proType,proNum,ProPrice,withWorkNo,printTime,printType,printCount,PiHao,PlanSendTime,ProductAddress,SGDCount from proOrdersDetail ");
            strSql.Append(" where orderNum='" + orderNUM + "'");

            OrderPrintSystem.Model.ProOrdersDetailMOD model = new OrderPrintSystem.Model.ProOrdersDetailMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["orderDetailId"] != null && reader["orderDetailId"].ToString() != "")
                {
                    model.orderDetailId = int.Parse(reader["orderDetailId"].ToString());
                }
                if (reader["orderNum"] != null)
                {
                    model.orderNum = reader["orderNum"].ToString();
                }
                if (reader["proType"] != null)
                {
                    model.proType = reader["proType"].ToString();
                }
                if (reader["proNum"] != null && reader["proNum"].ToString() != "")
                {
                    model.proNum = int.Parse(reader["proNum"].ToString());
                }
                if (reader["ProPrice"] != null && reader["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(reader["ProPrice"].ToString());
                }
                if (reader["withWorkNo"] != null)
                {
                    model.withWorkNo = reader["withWorkNo"].ToString();
                }
                if (reader["printTime"] != null && reader["printTime"].ToString() != "")
                {
                    model.printTime = DateTime.Parse(reader["printTime"].ToString());
                }
                if (reader["printType"] != null)
                {
                    model.printType = reader["printType"].ToString();
                }
                if (reader["printCount"] != null && reader["printCount"].ToString() != "")
                {
                    model.printCount = int.Parse(reader["printCount"].ToString());
                }
                if (reader["PiHao"] != null && reader["PiHao"].ToString() != "")
                {
                    model.PiHao = reader["PiHao"].ToString();
                }
                if (reader["PlanSendTime"] != null && reader["PlanSendTime"].ToString() != "")
                {
                    model.PlanSendTime = Convert.ToDateTime(reader["PlanSendTime"].ToString());
                }
                if (reader["ProductAddress"] != null && reader["ProductAddress"].ToString() != "")
                {
                    model.ProductAddress = reader["ProductAddress"].ToString();
                }
                if (reader["SGDCount"] != null && reader["SGDCount"].ToString() != "")
                {
                    model.SGDCount = Convert.ToInt32(reader["SGDCount"].ToString());
                }
            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// 根据订单号获取订单详情
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetAllOrderDetail(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * FROM proOrdersDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select orderDetailId,orderNum,proType,proNum,ProPrice,withWorkNo,(proNum*ProPrice) as totalPrice 
,(
    SELECT SUM(s.sendProNum)
    FROM [SendDetail] AS s
    WHERE (s.[orderNum] = d.[orderNum]) AND (s.[proType] = d.[proType])
    ) AS SendCount ");
            strSql.Append(" FROM proOrdersDetail d ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得订单详情列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select orderDetailId,orderNum,proType,proNum,ProPrice,withWorkNo,(proNum*ProPrice) as totalPrice 
,(
    SELECT SUM(s.sendProNum)
    FROM [SendDetail] AS s
    WHERE (s.[orderNum] = d.[orderNum]) AND (s.[proType] = d.[proType])
    ) AS SendCount from proOrdersDetail d Where 1=1  " + strWhere;
            string orderSql = " order by orderDetailId desc";
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
        /// 根据订单号获取该订单的总额
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static object GetOrderTotalPrice(string orderNum)
        {
            string sql = "select sum(ProPrice*proNum) as totalPrice from proOrdersDetail where orderNum=@orderNum";
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100)
			};
            parameters[0].Value = orderNum;
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sql, parameters);
        }
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetUserAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from proOrdersDetail Where 1=1  " + strWhere;
            string orderSql = " order by orderDetailId desc";
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
        /// 获取所有产品信息机及对应订单信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetAllProduct(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from view_OrderList where 1=1 " + strWhere;
            string orderSql = " order by orderDetailId desc";
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
        /// 精确查询 按订单编号查询产品
        /// </summary>
        /// <param name="orderNum">点单编号</param>
        /// <returns></returns>
        public static DataSet GetProductByOrderNum(string orderNum)
        {
            string sqlCommandString = string.Format("select * from view_OrderList where orderNum='{0}'", orderNum);
            try
            {
                return SqlHelper.Query(sqlCommandString);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 获取未打印送货单产品（未完成订单）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetNoSendOrder(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            //            string sqlCommandString = @"select d.orderDetailId,d.orderNum,d.proType,d.proNum,d.printSHDCount,d.planSendTime,o.remark,c.companyName,c.customerNo from proOrdersDetail d
            //left join proOrders o on o.orderNum=d.orderNum 
            //left join customer c on c.customerNo=o.customNum
            // Where 1=1  and (printSHDCount=0 or printSHDCount is NULL) " + strWhere;
            string sqlCommandString = "select * from view_NoWanChengOrder  Where (printSHDCount=0 or printSHDCount is NULL   or SendCount<proNum) " + strWhere;
            string orderSql = " order by orderDetailId desc";
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
        /// 获取未打印送货单产品（未完成订单）无分页
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetNoSendOrder(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from view_NoWanChengOrder  Where (printSHDCount=0 or printSHDCount is NULL   or SendCount<proNum) "+strWhere);

            strSql.Append(" order by orderDetailId desc");
            return SqlHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取所有产品发货情况
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetAllProductSendList(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = "select * from view_SendOrder where 1=1 " + strWhere;
            string orderSql = " order by orderDetailId desc";
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
        /// 获取所有产品发货情况
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetAllProductSendList(string strWhere)
        {
            string sqlCommandString = @"select d.*
            ,o.customNum,o.editTime,o.remark
            ,c.companyName
            ,pp.paramContent
            ,(
                SELECT SUM(s.sendProNum)
                FROM [SendDetail] AS s
                WHERE (s.[orderNum] = d.[orderNum]) AND (s.[proType] = d.[proType])
                ) AS sendProNum
            from proOrdersDetail d 
             left join proOrders o on o.orderNum=d.orderNum 
             left join customer c on c.customerNo=o.customNum
            left join ProductParam pp on pp.customNo=o.customNum and pp.productNo=d.proType
             Where 1=1 and printSHDCount>0" + strWhere + " order by orderDetailId desc";

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
        /// 获取当前型号发货总量
        /// </summary>
        /// <returns></returns>
        public static object GetProSendCount(string orderNum, string proType)
        {
            string sql = "select SUM(sendProNum) from SendDetail where orderNum=@orderNum and proType=@proType";
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100),
                    new SqlParameter("@proType",SqlDbType.VarChar,100)
			};
            parameters[0].Value = orderNum;
            parameters[1].Value = proType;
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sql, parameters);
        }
        /// <summary>
        /// 该订单是否已被打印
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static object GetPrintCount(string orderNum)
        {
            string sql = @"select SUM(printBZBQCount+printCCJYBGCount+printQLDCount+printSGDCount+printSGDJLCount+printSHDCount+printYYQRDCount+printZYSXCount)
 from proOrdersDetail where orderNum=@orderNum";
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100)
			};
            parameters[0].Value = orderNum;
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sql, parameters);
        }
        /// <summary>
        /// 修改打印信息
        /// </summary>
        /// <returns></returns>
        public static int UpdatePrintInfo(string orderNum, string proType, string colume1, string colume2)
        {
            string sqlCommandString = "Update proOrdersDetail Set " + colume1 + "='" + DateTime.Now + "'," + colume2 + "+=1 Where orderNum='" + orderNum + "' and proType='" + proType + "'";
            //string sqlCommandString = "Update proOrdersDetail Set @colume1='" + DateTime.Now + "',@colume2=(@colume2+1) Where orderNum=@orderNum and proType=@proType";
            //SqlParameter[] arParams = new SqlParameter[4];
            //arParams[0] = new SqlParameter("@colume1",colume1);
            //arParams[1] = new SqlParameter("@colume2",colume2);
            //arParams[2] = new SqlParameter("@orderNum", orderNum);
            //arParams[3] = new SqlParameter("@proType", proType);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, null);
        }


        /// <summary>
        /// 修改打印信息
        /// </summary>
        /// <returns></returns>
        public static int UpdatePrintInfo(string proType)
        {
            string sqlCommandString = "Update proOrdersDetail Set printSGDCount=0 Where proType='" + proType + "'";
            //string sqlCommandString = "Update proOrdersDetail Set @colume1='" + DateTime.Now + "',@colume2=(@colume2+1) Where orderNum=@orderNum and proType=@proType";
            //SqlParameter[] arParams = new SqlParameter[4];
            //arParams[0] = new SqlParameter("@colume1",colume1);
            //arParams[1] = new SqlParameter("@colume2",colume2);
            //arParams[2] = new SqlParameter("@orderNum", orderNum);
            //arParams[3] = new SqlParameter("@proType", proType);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, null);
        }
        #endregion  BasicMethodk
    }
}

