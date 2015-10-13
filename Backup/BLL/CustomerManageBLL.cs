using System;
using System.Collections.Generic;
using OrderPrintSystem.Modules;
using System.Data;
using OrderPrintSystem.DAO;

namespace OrderPrintSystem.BLL
{
   public class CustomerManageBLL
    {
        /// <summary>
        /// 获取所有客户信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetcustomerAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return CustomerManageDAO.GetcustomerAll(PageSize,PageIndex,out PageCount,strWhere);
        }
        /// <summary>
        /// 获取客户信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetcustomerAll(string strWhere)
        {
            return CustomerManageDAO.GetcustomerAll(strWhere);
        }
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="dtocustomerList">客户对象</param>
        /// <returns></returns>
        public static int Insertcustomer(CustomerManageMod customer)
        {
            return CustomerManageDAO.Insertcustomer(customer);

        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="dtocustomerList">客户数据对象</param>
        /// <returns></returns>
        public static int Updatecustomer(CustomerManageMod customer)
        {
            return CustomerManageDAO.Updatecustomer(customer);
        }


        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return CustomerManageDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerManageMod GetcustomerByid(int id)
        {
            return CustomerManageDAO.GetcustomerByid(id);
        }
        /// <summary>
        /// 根据客户编号查询客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerManageMod GetcustomerByid(string customNUM)
        {
            return CustomerManageDAO.GetcustomerByid(customNUM);
        }
        /// <summary>
        /// 根据客户名称查询客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerManageMod GetcustomerByName(string customNUM)
        {
            return CustomerManageDAO.GetcustomerByName(customNUM);
        }
    }
}
