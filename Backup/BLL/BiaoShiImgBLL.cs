using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderPrintSystem.BLL
{
   public class BiaoShiImgBLL
    {
         /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return BiaoShiImgDAO.GetmodAll(PageSize,PageIndex,out PageCount,strWhere);
        }
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return BiaoShiImgDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(BiaoShiImgMOD mod)
        {
            return BiaoShiImgDAO.Insertmod(mod);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(BiaoShiImgMOD mod)
        {
            return BiaoShiImgDAO.Updatemod(mod);
        }
      

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return BiaoShiImgDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BiaoShiImgMOD GetmodByid(int id)
        {
            return BiaoShiImgDAO.GetmodByid(id);
        }

        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BiaoShiImgMOD GetmodByid(string BiaoShiNo)
        {
            return BiaoShiImgDAO.GetmodByid(BiaoShiNo);
        }
    }
}
