using NewsSystem.DBUtility;
using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OrderPrintSystem.BLL
{
    public class GuiGeShuBLL
    {
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return GuiGeShuDAO.GetmodAll(strWhere);
        }
         /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return GuiGeShuDAO.GetmodAll(PageSize,PageIndex,out PageCount,strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(GuiGeShuMOD mod)
        {
            return GuiGeShuDAO.Insertmod(mod);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(GuiGeShuMOD mod)
        {
            return GuiGeShuDAO.Updatemod(mod);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string productNo)
        {
            return GuiGeShuDAO.Delete(productNo);
        }
          /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GuiGeShuMOD GetmodByid(string productNo)
        {
            return GuiGeShuDAO.GetmodByid(productNo);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GuiGeShuMOD GetmodByProduct(string productNo)
        {
            return GuiGeShuDAO.GetmodByProduct(productNo);
        }
    }
}
