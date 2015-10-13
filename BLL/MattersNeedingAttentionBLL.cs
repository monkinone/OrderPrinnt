using System;
using System.Collections.Generic;
using System.Text;
using OrderPrintSystem.Modules;
using OrderPrintSystem.DAO;
using System.Data;

namespace OrderPrintSystem.BLL
{
   public class MattersNeedingAttentionBLL
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return MattersNeedingAttentionDAO.GetmodAll(PageSize,PageIndex,out PageCount,strWhere);
        }
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return MattersNeedingAttentionDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(MattersNeedingAttentionMOD mod)
        {
            return MattersNeedingAttentionDAO.Insertmod(mod);
        }
         /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MattersNeedingAttentionMOD GetmodByid(string CustomerNo)
        {
            return MattersNeedingAttentionDAO.GetmodByid(CustomerNo);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(MattersNeedingAttentionMOD mod)
        {
            return MattersNeedingAttentionDAO.Updatemod(mod);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return MattersNeedingAttentionDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MattersNeedingAttentionMOD GetmodByid(int id)
        {
            return MattersNeedingAttentionDAO.GetmodByid(id);
        }
    }
}
