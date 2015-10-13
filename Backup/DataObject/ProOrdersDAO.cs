
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using System.Collections.Generic;
namespace OrderPrintSystem.DAL
{
    /// <summary>
    /// 数据访问类:proOrders
    /// </summary>
    public partial class ProOrdersDAO
    {
        public ProOrdersDAO()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(OrderPrintSystem.Model.ProOrdersMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("IF not exists(select 1 from proOrders where orderNum='{0}') BEGIN ",model.orderNum);
            strSql.Append("insert into proOrders(");
            strSql.Append("orderNum,customNum,heTongNum,customOrderNum,customWLBH,customManager,remark,editTime,ShuChuXianchang,ShuRuXianchang,发货状态)");
            strSql.Append(" values (");
            strSql.Append("@orderNum,@customNum,@heTongNum,@customOrderNum,@customWLBH,@customManager,@remark,@editTime,@ShuChuXianchang,@ShuRuXianchang,@发货状态)");
            strSql.Append(";select @@IDENTITY");
            strSql.Append(" END");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100),
					new SqlParameter("@customNum", SqlDbType.VarChar,100),
					new SqlParameter("@heTongNum", SqlDbType.VarChar,100),
					new SqlParameter("@customOrderNum", SqlDbType.VarChar,100),
					new SqlParameter("@customWLBH", SqlDbType.VarChar,100),
					new SqlParameter("@customManager", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@editTime", SqlDbType.DateTime),
                    new SqlParameter("@ShuChuXianchang",SqlDbType.VarChar,100),
                    new SqlParameter("@ShuRuXianchang",SqlDbType.VarChar,100),
                    new SqlParameter("@发货状态",SqlDbType.VarChar,100)
                                        
                                        };
            parameters[0].Value = model.orderNum;
            parameters[1].Value = model.customNum;
            parameters[2].Value = model.heTongNum;
            parameters[3].Value = model.customOrderNum;
            parameters[4].Value = model.customWLBH;
            parameters[5].Value = model.customManager;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.editTime;
            parameters[8].Value = model.ShuChuXianchang;
            parameters[9].Value = model.ShuRuXianchang;
            parameters[10].Value = model.发货状态;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(OrderPrintSystem.Model.ProOrdersMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update proOrders set ");
            strSql.Append("orderNum=@orderNum,");
            strSql.Append("customNum=@customNum,");
            strSql.Append("heTongNum=@heTongNum,");
            strSql.Append("customOrderNum=@customOrderNum,");
            strSql.Append("customWLBH=@customWLBH,");
            strSql.Append("customManager=@customManager,");
            strSql.Append("remark=@remark,");
            strSql.Append("editTime=@editTime,");
            strSql.Append("updateTime=@updateTime,");
            strSql.Append("yikaipiaoMoney=@yikaipiaoMoney,");
            strSql.Append("yijiekuanMoney=@yijiekuanMoney,");
            strSql.Append("FaPiaoDanhao=@FaPiaoDanhao,");
            strSql.Append("ChengShuiHao=@ChengShuiHao,");
            strSql.Append("Remark1=@Remark1,");
            strSql.Append("EditUser=@EditUser,");
            strSql.Append("IsTiXing=@IsTiXing,");
            strSql.Append("ShuChuXianchang=@ShuChuXianchang,");
            strSql.Append("ShuRuXianchang=@ShuRuXianchang");
            strSql.Append(" where orderId=@orderId");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNum", SqlDbType.VarChar,100),
					new SqlParameter("@customNum", SqlDbType.VarChar,100),
					new SqlParameter("@heTongNum", SqlDbType.VarChar,100),
					new SqlParameter("@customOrderNum", SqlDbType.VarChar,100),
					new SqlParameter("@customWLBH", SqlDbType.VarChar,100),
					new SqlParameter("@customManager", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@editTime", SqlDbType.DateTime),
                    new SqlParameter("@updateTime",SqlDbType.DateTime),
                    new SqlParameter("@yikaipiaoMoney",SqlDbType.Decimal),
                    new SqlParameter("@yijiekuanMoney",SqlDbType.Decimal),

                    new SqlParameter("@FaPiaoDanhao", SqlDbType.VarChar,100),
                    new SqlParameter("@ChengShuiHao", SqlDbType.VarChar,100),
                    new SqlParameter("@Remark1", SqlDbType.VarChar,5000),
                    new SqlParameter("@EditUser",SqlDbType.Int,4),
                    new SqlParameter("@IsTiXing",SqlDbType.Int,4),
                     new SqlParameter("@ShuChuXianchang", SqlDbType.VarChar,100),
                    new SqlParameter("@ShuRuXianchang", SqlDbType.VarChar,100),
					new SqlParameter("@orderId", SqlDbType.Int,4)};
            parameters[0].Value = model.orderNum;
            parameters[1].Value = model.customNum;
            parameters[2].Value = model.heTongNum;
            parameters[3].Value = model.customOrderNum;
            parameters[4].Value = model.customWLBH;
            parameters[5].Value = model.customManager;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.editTime;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.YikaipiaoMoney;
            parameters[10].Value = model.YijiekuanMoney;
            parameters[11].Value = model.FaPiaoDanhao;
            parameters[12].Value = model.ChengShuiHao;
            parameters[13].Value = model.Remark1;
            parameters[14].Value = model.EditUser;
            parameters[15].Value = model.IsTiXing;
            parameters[16].Value = model.ShuChuXianchang;
            parameters[17].Value = model.ShuRuXianchang;
            parameters[18].Value = model.orderId;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(string orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update proOrders set ");
            strSql.Append("IsTiXing=1");
            strSql.Append(" where orderId=@orderId");
            SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4)};
            parameters[0].Value = orderID;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int Delete(int orderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from proOrders ");
            strSql.Append(" where orderId=@orderId");
            SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4)
			};
            parameters[0].Value = orderId;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 根据订单编号删除订单
        /// </summary>
        /// <param name="orderNUM"></param>
        /// <returns></returns>
        public static int Delete(string orderNUM)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from proOrders ");
            strSql.Append(" where orderNUM=@orderNUM");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNUM", SqlDbType.VarChar,100)
			};
            parameters[0].Value = orderNUM;

            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            return readers;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static int DeleteList(string orderIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from proOrders ");
            strSql.Append(" where orderId in (" + orderIdlist + ")  ");
            int readers = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
            return readers;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersMOD GetModel(int orderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderId,orderNum,customNum,heTongNum,customOrderNum,customWLBH,customManager,remark,editTime,YijiekuanMoney,YikaipiaoMoney,FaPiaoDanhao,ChengShuiHao,Remark1,ShuChuXianchang,ShuRuXianchang from proOrders ");
            strSql.Append(" where orderId=" + orderId);

            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            OrderPrintSystem.Model.ProOrdersMOD model = new OrderPrintSystem.Model.ProOrdersMOD();
            if (reader.Read())
            {
                if (reader["orderId"] != null && reader["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(reader["orderId"].ToString());
                }
                if (reader["orderNum"] != null)
                {
                    model.orderNum = reader["orderNum"].ToString();
                }
                if (reader["customNum"] != null)
                {
                    model.customNum = reader["customNum"].ToString();
                }
                if (reader["heTongNum"] != null)
                {
                    model.heTongNum = reader["heTongNum"].ToString();
                }
                if (reader["customOrderNum"] != null)
                {
                    model.customOrderNum = reader["customOrderNum"].ToString();
                }
                if (reader["customWLBH"] != null)
                {
                    model.customWLBH = reader["customWLBH"].ToString();
                }
                if (reader["customManager"] != null)
                {
                    model.customManager = reader["customManager"].ToString();
                }
                if (reader["remark"] != null)
                {
                    model.remark = reader["remark"].ToString();
                }
                if (reader["editTime"] != null && reader["editTime"].ToString() != "")
                {
                    model.editTime = DateTime.Parse(reader["editTime"].ToString());
                }
                if (reader["YijiekuanMoney"] != null && reader["YijiekuanMoney"].ToString() != "")
                {
                    model.YijiekuanMoney = Convert.ToDecimal(reader["YijiekuanMoney"].ToString());
                }
                if (reader["YikaipiaoMoney"] != null && reader["YikaipiaoMoney"].ToString() != "")
                {
                    model.YikaipiaoMoney = Convert.ToDecimal(reader["YikaipiaoMoney"].ToString());
                }
                model.FaPiaoDanhao = reader["FaPiaoDanhao"].ToString();
                model.ChengShuiHao = reader["ChengShuiHao"].ToString();
                model.Remark1 = reader["Remark1"].ToString();
                model.ShuChuXianchang = reader["ShuChuXianchang"].ToString();
                model.ShuRuXianchang = reader["ShuRuXianchang"].ToString();
            }
            reader.Close();
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersMOD GetModel(string orderNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderId,orderNum,customNum,heTongNum,customOrderNum,customWLBH,customManager,remark,editTime,YijiekuanMoney,YikaipiaoMoney,FaPiaoDanhao,ChengShuiHao,Remark1,ShuChuXianchang,ShuRuXianchang from proOrders ");
            strSql.Append(" where orderNum='" + orderNum + "'");

            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            OrderPrintSystem.Model.ProOrdersMOD model = new OrderPrintSystem.Model.ProOrdersMOD();
            if (reader.Read())
            {
                if (reader["orderId"] != null && reader["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(reader["orderId"].ToString());
                }
                if (reader["orderNum"] != null)
                {
                    model.orderNum = reader["orderNum"].ToString();
                }
                if (reader["customNum"] != null)
                {
                    model.customNum = reader["customNum"].ToString();
                }
                if (reader["heTongNum"] != null)
                {
                    model.heTongNum = reader["heTongNum"].ToString();
                }
                if (reader["customOrderNum"] != null)
                {
                    model.customOrderNum = reader["customOrderNum"].ToString();
                }
                if (reader["customWLBH"] != null)
                {
                    model.customWLBH = reader["customWLBH"].ToString();
                }
                if (reader["customManager"] != null)
                {
                    model.customManager = reader["customManager"].ToString();
                }
                if (reader["remark"] != null)
                {
                    model.remark = reader["remark"].ToString();
                }
                if (reader["editTime"] != null && reader["editTime"].ToString() != "")
                {
                    model.editTime = DateTime.Parse(reader["editTime"].ToString());
                }
                if (reader["YijiekuanMoney"] != null && reader["YijiekuanMoney"].ToString() != "")
                {
                    model.YijiekuanMoney = Convert.ToDecimal(reader["YijiekuanMoney"].ToString());
                }
                if (reader["YikaipiaoMoney"] != null && reader["YikaipiaoMoney"].ToString() != "")
                {
                    model.YikaipiaoMoney = Convert.ToDecimal(reader["YikaipiaoMoney"].ToString());
                }
                model.FaPiaoDanhao = reader["FaPiaoDanhao"].ToString();
                model.ChengShuiHao = reader["ChengShuiHao"].ToString();
                model.Remark1 = reader["Remark1"].ToString();
                model.ShuChuXianchang = reader["ShuChuXianchang"].ToString();
                model.ShuRuXianchang = reader["ShuRuXianchang"].ToString();
                reader.Close();
                return model;
            }
            else
            { reader.Close(); return null; }

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            string sqlCommandString = @"select * from  proOrders where 1=1  " + strWhere;
          //  string orderSql = " order by updateTime desc";
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
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetUserAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select o.*,c.companyName from proOrders o left join  customer c on c.customerNo=o.customNum Where 1=1  " + strWhere;
            string orderSql = " order by orderId desc";
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


        #endregion  BasicMethod

    }
}

