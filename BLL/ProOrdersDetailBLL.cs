using System;
using System.Collections.Generic;
using System.Text;
using OrderPrintSystem.DAL;
using System.Data;

namespace OrderPrintSystem.BLL
{
    public class ProOrdersDetailBLL
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(OrderPrintSystem.Model.ProOrdersDetailMOD model)
        {
            return ProOrdersDetailDAO.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int UpdateOrder(OrderPrintSystem.Model.ProOrdersDetailMOD model)
        {
            return ProOrdersDetailDAO.UpdateOrder(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(OrderPrintSystem.Model.ProOrdersDetailMOD model)
        {
            return ProOrdersDetailDAO.Update(model);
        }
        /// <summary>
        /// 更新数量
        /// </summary>
        public static int Update(int orderDetailId, int num)
        {
            return ProOrdersDetailDAO.Update(orderDetailId, num);
        }
        /// <summary>
        /// 修改打印信息
        /// </summary>
        /// <returns></returns>
        public static int UpdatePrintInfo(string orderNum, string proType, string colume1, string colume2)
        {
            return ProOrdersDetailDAO.UpdatePrintInfo(orderNum, proType, colume1, colume2);
        }
        /// <summary>
        /// 修改打印信息
        /// </summary>
        /// <returns></returns>
        public static int UpdatePrintInfo(string proType)
        {
            return ProOrdersDetailDAO.UpdatePrintInfo(proType);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int Delete(int orderDetailId)
        {
            return ProOrdersDetailDAO.Delete(orderDetailId);
        }

        /// <summary>
        /// 根据订单号删除订单详情
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static int Delete(string orderNum)
        {
            return ProOrdersDetailDAO.Delete(orderNum);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static int DeleteList(string orderDetailIdlist)
        {
            return ProOrdersDetailDAO.DeleteList(orderDetailIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModelByWhere(string strWhere)
        {
            return ProOrdersDetailDAO.GetModelByWhere(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModel(int orderDetailId)
        {
            return ProOrdersDetailDAO.GetModel(orderDetailId);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModel(string proType)
        {

            return ProOrdersDetailDAO.GetModel(proType);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModelByOrderNum(string orderNUM)
        {
            return ProOrdersDetailDAO.GetModelByOrderNum(orderNUM);
        }
        /// <summary>
        /// 根据订单号获取订单详情
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetAllOrderDetail(string strWhere)
        {
            return ProOrdersDetailDAO.GetAllOrderDetail(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return ProOrdersDetailDAO.GetList(strWhere);
        }
        /// <summary>
        /// 获得订单详情列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return ProOrdersDetailDAO.GetList(PageSize, PageIndex, out PageCount, strWhere);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProOrdersDetailMOD GetModel(string proType, string orderNum)
        {
            return ProOrdersDetailDAO.GetModel(proType, orderNum);
        }
        /// <summary>
        /// 根据订单号获取该订单的总额
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static string GetOrderTotalPrice(string orderNum)
        {
            return ProOrdersDetailDAO.GetOrderTotalPrice(orderNum).ToString();
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
            return ProOrdersDetailDAO.GetUserAll(PageSize, PageIndex, out PageCount, strWhere);
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
            return ProOrdersDetailDAO.GetAllProduct(PageSize, PageIndex, out PageCount, strWhere);
        }
        /// <summary>
        /// 精确查询 精确查询 按订单编号查询产品
        /// </summary>
        /// <param name="OrderNum">订单编号</param>
        /// <returns></returns>
        public static DataSet  GetProductByOrderNum(string OrderNum)
        {
            return ProOrdersDetailDAO.GetProductByOrderNum(OrderNum);
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
            return ProOrdersDetailDAO.GetNoSendOrder(PageSize, PageIndex, out PageCount, strWhere);
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
            return ProOrdersDetailDAO.GetNoSendOrder(strWhere);
        }
        /// <summary>
        /// 该订单是否已被打印
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static object GetPrintCount(string orderNum)
        {
            return ProOrdersDetailDAO.GetPrintCount(orderNum);
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
            return ProOrdersDetailDAO.GetAllProductSendList(PageSize, PageIndex, out PageCount, strWhere);
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
            return ProOrdersDetailDAO.GetAllProductSendList(strWhere);
        }
        /// <summary>
        /// 获取当前型号发货总量
        /// </summary>
        /// <returns></returns>
        public static object GetProSendCount(string orderNum, string proType)
        {
            return ProOrdersDetailDAO.GetProSendCount(orderNum, proType);
        }
        #endregion  BasicMethod
    }
}
