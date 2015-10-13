using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderPrintSystem.BLL
{
    public class SGDRecordBLL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(SGDRecordMOD mod)
        {
            return SGDRecordDAO.Insertmod(mod);
        }
        /// <summary>
        /// 获取当天最大随工单号
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static object GetSuigondanMax(string date)
        {
            return SGDRecordDAO.GetSuigondanMax(date);
        }
        /// <summary>
        /// 随工单查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageCount"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataSet SearchSGD(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            SGDRecordDAO dao = new SGDRecordDAO();
            return dao.SearchSGD(PageSize,  PageIndex, out PageCount,  strWhere);
        }
    }
}
