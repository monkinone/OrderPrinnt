using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.DAO
{
    public class CustomerManageDAO
    {
        /// <summary>
        /// 获取所有客户信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetcustomerAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from customer Where 1=1  " + strWhere;
            string orderSql = " order by customerId desc";
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
        /// 获取客户信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetcustomerAll(string strWhere)
        {
            string sqlCommandString = @"select * from customer Where 1=1  " + strWhere;
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
        /// 添加客户
        /// </summary>
        /// <param name="dtocustomerList">客户对象</param>
        /// <returns></returns>
        public static int Insertcustomer(CustomerManageMod customer)
        {
            string sqlCommandString = "Insert Into customer(customerNo,companyName,contacts,position,phone,telPhone,tax,discount,InvoiceMethod,backMethod,isFanben,CompanyAddress,OtherDangAn,modifyPriceRecord,description,isShowPrice,islock,ZhangHao,ShuiHao,isAddInfo)Values(@customerNo,@companyName,@contacts,@position,@phone,@telPhone,@tax,@discount,@InvoiceMethod,@backMethod,@isFanben,@CompanyAddress,@OtherDangAn,@modifyPriceRecord,@description,@isShowPrice,@islock,@ZhangHao,@ShuiHao,@isAddInfo)";
            SqlParameter[] arParams = new SqlParameter[20];
            arParams[0] = new SqlParameter("@customerNo", customer.CustomerNo);
            arParams[1] = new SqlParameter("@companyName", customer.CompanyName);
            arParams[2] = new SqlParameter("@contacts", customer.Contacts);
            arParams[3] = new SqlParameter("@position", customer.Position);
            arParams[4] = new SqlParameter("@phone", customer.Phone);
            arParams[5] = new SqlParameter("@telPhone", customer.TelPhone);
            arParams[6] = new SqlParameter("@tax", customer.Tax);
            arParams[7] = new SqlParameter("@discount", customer.Discount);
            arParams[8] = new SqlParameter("@InvoiceMethod", customer.InvoiceMethod);
            arParams[9] = new SqlParameter("@backMethod", customer.BackMethod);
            arParams[10] = new SqlParameter("@isFanben", customer.IsFanben);
            arParams[11] = new SqlParameter("@CompanyAddress", customer.CompanyAddress);
            arParams[12] = new SqlParameter("@OtherDangAn", customer.OtherDangAn);
            arParams[13] = new SqlParameter("@modifyPriceRecord", customer.ModifyPriceRecord);
            arParams[14] = new SqlParameter("@description", customer.Description);
            arParams[15] = new SqlParameter("@isShowPrice", customer.IsShowPrice);
            arParams[16] = new SqlParameter("@islock", customer.Islock);
            arParams[17] = new SqlParameter("@ZhangHao", customer.ZhangHao);
            arParams[18] = new SqlParameter("@ShuiHao", customer.ShuiHao);
            arParams[19] = new SqlParameter("@isAddInfo",customer.IsAddInfo);

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="dtocustomerList">客户数据对象</param>
        /// <returns></returns>
        public static int Updatecustomer(CustomerManageMod customer)
        {
            string sqlCommandString = "Update customer Set customerNo=@customerNo,companyName=@companyName,contacts=@contacts,position=@position,phone=@phone,telPhone=@telPhone,tax=@tax,discount=@discount,InvoiceMethod=@InvoiceMethod,backMethod=@backMethod,isFanben=@isFanben,CompanyAddress=@CompanyAddress,OtherDangAn=@OtherDangAn,modifyPriceRecord=@modifyPriceRecord,description=@description,isShowPrice=@isShowPrice,islock=@islock,ZhangHao=@ZhangHao,ShuiHao=@ShuiHao,isAddInfo=@isAddInfo Where customerId=@customerId";
            SqlParameter[] arParams = new SqlParameter[21];

            arParams[0] = new SqlParameter("@customerNo", customer.CustomerNo);
            arParams[1] = new SqlParameter("@companyName", customer.CompanyName);
            arParams[2] = new SqlParameter("@contacts", customer.Contacts);
            arParams[3] = new SqlParameter("@position", customer.Position);
            arParams[4] = new SqlParameter("@phone", customer.Phone);
            arParams[5] = new SqlParameter("@telPhone", customer.TelPhone);
            arParams[6] = new SqlParameter("@tax", customer.Tax);
            arParams[7] = new SqlParameter("@discount", customer.Discount);
            arParams[8] = new SqlParameter("@InvoiceMethod", customer.InvoiceMethod);
            arParams[9] = new SqlParameter("@backMethod", customer.BackMethod);
            arParams[10] = new SqlParameter("@isFanben", customer.IsFanben);
            arParams[11] = new SqlParameter("@CompanyAddress", customer.CompanyAddress);
            arParams[12] = new SqlParameter("@OtherDangAn", customer.OtherDangAn);
            arParams[13] = new SqlParameter("@modifyPriceRecord", customer.ModifyPriceRecord);
            arParams[14] = new SqlParameter("@description", customer.Description);
            arParams[15] = new SqlParameter("@isShowPrice", customer.IsShowPrice);
            arParams[16] = new SqlParameter("@islock", customer.Islock);
            arParams[17] = new SqlParameter("@customerId", customer.CustomerId);
            arParams[18] = new SqlParameter("@ZhangHao", customer.ZhangHao);
            arParams[19] = new SqlParameter("@ShuiHao", customer.ShuiHao);
            arParams[20] = new SqlParameter("@isAddInfo",customer.IsAddInfo);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }


        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From customer Where customerId in (" + id + ")";

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
        /// 根据主键id查询客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerManageMod GetcustomerByid(int id)
        {
            CustomerManageMod customer = new CustomerManageMod();
            string sqlcommandString = "select * from customer where customerId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    customer.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                    customer.BackMethod = reader["Phone"].ToString();
                    customer.CompanyName = reader["CompanyName"].ToString();
                    customer.Contacts = reader["Contacts"].ToString();
                    customer.CustomerNo = reader["CustomerNo"].ToString();
                    customer.Description = reader["Description"].ToString();
                    customer.Discount = reader["Discount"].ToString();
                    customer.InvoiceMethod = reader["InvoiceMethod"].ToString();
                    customer.IsFanben = Convert.ToInt32(reader["IsFanben"].ToString());
                    customer.Islock = Convert.ToInt32(reader["Islock"].ToString());
                    customer.IsShowPrice = Convert.ToInt32(reader["IsShowPrice"].ToString());
                    customer.ModifyPriceRecord = reader["ModifyPriceRecord"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Position = reader["Position"].ToString();
                    customer.Tax = reader["Tax"].ToString();
                    customer.TelPhone = reader["TelPhone"].ToString();
                    customer.IsFanben = Convert.ToInt32(reader["IsFanben"].ToString());
                    customer.CompanyAddress = reader["CompanyAddress"].ToString();
                    customer.OtherDangAn = reader["OtherDangAn"].ToString();
                    customer.ZhangHao = reader["ZhangHao"].ToString();
                    customer.ShuiHao = reader["ShuiHao"].ToString();
                    customer.BackMethod = reader["BackMethod"].ToString();
                    if (reader["isAddInfo"] != null && reader["isAddInfo"].ToString() != "")
                    {
                        customer.IsAddInfo = Convert.ToInt32(reader["isAddInfo"]);
                    }
                    reader.Close();
                    return customer;
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
        /// <summary>
        /// 根据客户编号查询客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerManageMod GetcustomerByid(string CustomerNo)
        {
            CustomerManageMod customer = new CustomerManageMod();
            string sqlcommandString = "select * from customer where CustomerNo='" + CustomerNo + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    customer.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                    customer.BackMethod = reader["BackMethod"].ToString();
                    customer.CompanyName = reader["CompanyName"].ToString();
                    customer.Contacts = reader["Contacts"].ToString();
                    customer.CustomerNo = reader["CustomerNo"].ToString();
                    customer.Description = reader["Description"].ToString();
                    customer.Discount = reader["Discount"].ToString();
                    customer.InvoiceMethod = reader["InvoiceMethod"].ToString();
                    customer.IsFanben = Convert.ToInt32(reader["IsFanben"].ToString());
                    customer.Islock = Convert.ToInt32(reader["Islock"].ToString());
                    customer.IsShowPrice = Convert.ToInt32(reader["IsShowPrice"].ToString());
                    customer.ModifyPriceRecord = reader["ModifyPriceRecord"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Position = reader["Position"].ToString();
                    customer.Tax = reader["Tax"].ToString();
                    customer.TelPhone = reader["TelPhone"].ToString();
                    customer.IsFanben = Convert.ToInt32(reader["IsFanben"].ToString());
                    customer.CompanyAddress = reader["CompanyAddress"].ToString();
                    customer.OtherDangAn = reader["OtherDangAn"].ToString();
                    customer.ZhangHao = reader["ZhangHao"].ToString();
                    customer.ShuiHao = reader["ShuiHao"].ToString();
                    if (reader["isAddInfo"] != null && reader["isAddInfo"].ToString() != "")
                    {
                        customer.IsAddInfo = Convert.ToInt32(reader["isAddInfo"]);
                    }
                    reader.Close();
                    return customer;
                }
                else
                {
                    reader.Close();
                    return null; }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
             /// <summary>
        /// 根据客户编号查询客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerManageMod GetcustomerByName(string CompanyName)
        {
            CustomerManageMod customer = new CustomerManageMod();
            string sqlcommandString = "select * from customer where CompanyName='" + CompanyName + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    customer.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                    customer.BackMethod = reader["BackMethod"].ToString();
                    customer.CompanyName = reader["CompanyName"].ToString();
                    customer.Contacts = reader["Contacts"].ToString();
                    customer.CustomerNo = reader["CustomerNo"].ToString();
                    customer.Description = reader["Description"].ToString();
                    customer.Discount =reader["Discount"].ToString();
                    customer.InvoiceMethod = reader["InvoiceMethod"].ToString();
                    customer.IsFanben = Convert.ToInt32(reader["IsFanben"].ToString());
                    customer.Islock = Convert.ToInt32(reader["Islock"].ToString());
                    customer.IsShowPrice = Convert.ToInt32(reader["IsShowPrice"].ToString());
                    customer.ModifyPriceRecord = reader["ModifyPriceRecord"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Position = reader["Position"].ToString();
                    customer.Tax = reader["Tax"].ToString();
                    customer.TelPhone = reader["TelPhone"].ToString();
                    customer.IsFanben = Convert.ToInt32(reader["IsFanben"].ToString());
                    customer.CompanyAddress = reader["CompanyAddress"].ToString();
                    customer.OtherDangAn = reader["OtherDangAn"].ToString();
                    customer.ZhangHao = reader["ZhangHao"].ToString();
                    customer.ShuiHao = reader["ShuiHao"].ToString();
                    if (reader["isAddInfo"] != null && reader["isAddInfo"].ToString() != "")
                    {
                        customer.IsAddInfo = Convert.ToInt32(reader["isAddInfo"]);
                    }
                    reader.Close();
                    return customer;
                }
                else
                {
                    reader.Close();
                    return null; }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
