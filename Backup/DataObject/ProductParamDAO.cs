using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.DAO
{
    public class ProductParamDAO
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select p.*,c.companyName from ProductParam p left join customer c on p.customNo=c.customerNo Where 1=1  " + strWhere;
            string orderSql = " order by paramId desc";
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
            string sqlCommandString = @"select p.*,c.companyName from ProductParam p inner join customer c on p.customNo=c.customerNo Where 1=1  " + strWhere;
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
        public static int Insertmod(ProductParamMOD mod)
        {
            string sqlCommandString = "Insert Into ProductParam(customNo,productNo,paramContent,isWriteFahuoInfo,isWriteXianChang,wuliaobian)Values(@customNo,@productNo,@paramContent,@isWriteFahuoInfo,@isWriteXianChang,@wuliaobian)";
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@customNo", mod.CustomNo);
            arParams[1] = new SqlParameter("@productNo", mod.ProductNo);
            arParams[2] = new SqlParameter("@paramContent", mod.ParamContent);
            arParams[3] = new SqlParameter("@isWriteFahuoInfo", mod.IsWriteFahuoInfo);
            arParams[4] = new SqlParameter("@isWriteXianChang", mod.IsWriteXianChang);
            arParams[5] = new SqlParameter("@wuliaobian",mod.Wuliaobian);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(ProductParamMOD mod)
        {
            string sqlCommandString = "Update ProductParam Set paramContent=@paramContent,isWriteFahuoInfo=@isWriteFahuoInfo,isWriteXianChang=@isWriteXianChang,wuliaobian=@wuliaobian Where paramId=@paramId";
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@paramId", mod.ParamId);
            arParams[1] = new SqlParameter("@paramContent", mod.ParamContent);
            arParams[2] = new SqlParameter("@isWriteFahuoInfo", mod.IsWriteFahuoInfo);
            arParams[3] = new SqlParameter("@isWriteXianChang", mod.IsWriteXianChang);
            arParams[4] = new SqlParameter("@wuliaobian", mod.Wuliaobian);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlCommandString, arParams);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            string sqlCommandString = "Delete From ProductParam Where paramId in (" + id + ")";

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
        public static ProductParamMOD GetmodByid(int id)
        {
            ProductParamMOD mod = new ProductParamMOD();
            string sqlcommandString = "select * from ProductParam where paramId=" + id;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ProductNo = reader["ProductNo"].ToString();
                    mod.CustomNo = reader["CustomNo"].ToString();
                    mod.ParamId = Convert.ToInt32(reader["ParamId"].ToString());
                    mod.ParamContent = reader["ParamContent"].ToString();
                    if (reader["IsWriteFahuoInfo"] != null && reader["IsWriteFahuoInfo"].ToString() != "")
                    {
                        mod.IsWriteFahuoInfo = Convert.ToInt32(reader["IsWriteFahuoInfo"]);
                    }
                    if (reader["IsWriteXianChang"] != null && reader["IsWriteXianChang"].ToString() != "")
                    {
                        mod.IsWriteXianChang = Convert.ToInt32(reader["IsWriteXianChang"]);
                    }
                    mod.Wuliaobian = reader["wuliaobian"].ToString();
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
        /// <summary>
        /// 根据主键客户编号和产品型号查询客户参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductParamMOD GetmodByid(string CustomNo, string ProductNo)
        {
            ProductParamMOD mod = new ProductParamMOD();
            string sqlcommandString = "select * from ProductParam where CustomNo='" + CustomNo + "' and ProductNo='" + ProductNo + "'";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sqlcommandString);
                if (reader.Read())
                {
                    mod.ProductNo = reader["ProductNo"].ToString();
                    mod.CustomNo = reader["CustomNo"].ToString();
                    mod.ParamId = Convert.ToInt32(reader["ParamId"].ToString());
                    mod.ParamContent = reader["ParamContent"].ToString();
                    if (reader["IsWriteFahuoInfo"] != null && reader["IsWriteFahuoInfo"].ToString() != "")
                    {
                        mod.IsWriteFahuoInfo = Convert.ToInt32(reader["IsWriteFahuoInfo"]);
                    }
                    if (reader["IsWriteXianChang"] != null && reader["IsWriteXianChang"].ToString() != "")
                    {
                        mod.IsWriteXianChang = Convert.ToInt32(reader["IsWriteXianChang"]);
                    }
                    mod.Wuliaobian = reader["wuliaobian"].ToString();
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
