using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderPrintSystem.BLL
{
    public class SendDetailBLL
    {
          /// <summary>
        /// 获取当前订单当前型号最后一次发货数量
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        public static object GetSendCountByProType(string proType, string orderNum)
        {
            return SendDetailDAO.GetSendCountByProType(proType,orderNum);
        }
         /// <summary>
        /// 获取当天最大随工单号
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static object GetSuigondanMax(string date)
        {
            return SendDetailDAO.GetSuigondanMax(date);
        }
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return SendDetailDAO.GetmodAll(PageSize, PageIndex, out PageCount, strWhere);
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
            return SendDetailDAO.GetProList(PageSize, PageIndex, out PageCount, strWhere);
        }
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return SendDetailDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(SendDetailMOD mod)
        {
            return SendDetailDAO.Insertmod(mod);

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="orderNUM"></param>
        /// <returns></returns>
        public static int Delete(string orderNUM)
        {
            return SendDetailDAO.Delete(orderNUM);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(SendDetailMOD mod)
        {
            return SendDetailDAO.Updatemod(mod);
        }
         /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SendDetailMOD GetmodByid(string ProType, string orderNum)
        {
            return SendDetailDAO.GetmodByid(ProType,orderNum);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SendDetailMOD GetmodByid(string ProType)
        {
            return SendDetailDAO.GetmodByid(ProType);
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
            return SendDetailDAO.UpdateSendInfoByOrderNum(orderNum, sendNum, packingCompanyName);
        }
        /// <summary>
        /// 根据订单号查询发货明细
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static SendDetailMOD GetModByOrderNum(string orderNum)
        {
            return SendDetailDAO.GetModByOrderNum(orderNum);
        }
    }
}
