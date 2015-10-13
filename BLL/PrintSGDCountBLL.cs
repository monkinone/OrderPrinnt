using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderPrintSystem.BLL
{
   public class PrintSGDCountBLL
    {
         /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(PrintSGDCountMOD mod)
        {
            return PrintSGDCountDAO.Insertmod(mod);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(PrintSGDCountMOD mod)
        {
            return PrintSGDCountDAO.Updatemod(mod);
        }

        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PrintSGDCountMOD GetmodByid(string orderNum, string proType)
        {
            return PrintSGDCountDAO.GetmodByid(orderNum,proType);
        }
    }
}
