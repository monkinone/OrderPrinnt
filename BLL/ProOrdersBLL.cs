using OrderPrintSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace OrderPrintSystem.BLL
{
    public class ProOrdersBLL
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(OrderPrintSystem.Model.ProOrdersMOD model)
        {
            return ProOrdersDAO.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(OrderPrintSystem.Model.ProOrdersMOD model)
        {
            return ProOrdersDAO.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(string orderID)
        {
            return ProOrdersDAO.Update(orderID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int Delete(int orderId)
        {
            return ProOrdersDAO.Delete(orderId);
        }
        /// <summary>
        /// 根据订单号删除订单
        /// </summary>
        /// <param name="orderNUM"></param>
        /// <returns></returns>
        public static int Delete(string orderNUM)
        {
            return ProOrdersDAO.Delete(orderNUM);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static int DeleteList(string orderIdlist)
        {
            return ProOrdersDAO.DeleteList(orderIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersMOD GetModel(int orderId)
        {
            return ProOrdersDAO.GetModel(orderId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersMOD GetModel(string orderNo)
        {
            return ProOrdersDAO.GetModel(orderNo);
        }

      
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return ProOrdersDAO.GetList(strWhere);
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
            return ProOrdersDAO.GetUserAll(PageSize, PageIndex, out PageCount, strWhere);
        }
        #endregion  BasicMethod
    }
}
