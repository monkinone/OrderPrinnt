using System;
using System.Collections.Generic;
using System.Text;
using OrderPrintSystem.Modules;
using OrderPrintSystem.DAO;
using System.Data;

namespace OrderPrintSystem.BLL
{
   public class WaiKeImgBLL
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return WaiKeImgDAO.GetmodAll(PageSize,PageIndex,out PageCount,strWhere);
        }
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return WaiKeImgDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(WaiKeImgMOD mod)
        {
            return WaiKeImgDAO.Insertmod(mod);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(WaiKeImgMOD mod)
        {
            return WaiKeImgDAO.Updatemod(mod);
        }
          /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(string waiKeNo)
        {
            return WaiKeImgDAO.Updatemod(waiKeNo);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return WaiKeImgDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static WaiKeImgMOD GetmodByid(int id)
        {
            return WaiKeImgDAO.GetmodByid(id);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static WaiKeImgMOD GetmodByid(string waiKeNo)
        {
            return WaiKeImgDAO.GetmodByid(waiKeNo);
        }
    }
}
