using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.BLL
{
   public class ProductParamBLL
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return ProductParamDAO.GetmodAll(PageSize, PageIndex, out PageCount, strWhere);
        }
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return ProductParamDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(ProductParamMOD mod)
        {
            return ProductParamDAO.Insertmod(mod);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(ProductParamMOD mod)
        {
            return ProductParamDAO.Updatemod(mod);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return ProductParamDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductParamMOD GetmodByid(int id)
        {
          return  ProductParamDAO.GetmodByid(id);
        }
          /// <summary>
        /// 根据主键客户编号和产品型号查询客户参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductParamMOD GetmodByid(string CustomNo, string ProductNo)
        {
           return ProductParamDAO.GetmodByid(CustomNo,ProductNo);
        }
    }
}
