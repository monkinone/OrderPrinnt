using System;
using System.Collections.Generic;
using System.Data;
using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;

namespace OrderPrintSystem.BLL
{
    public class GuanJiaoZhenImgBLL
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetmodAll(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return GuanJiaoZhenImgDAO.GetmodAll(PageSize, PageIndex, out PageCount, strWhere);
        }
        /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return GuanJiaoZhenImgDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(GuanJiaoZhenImgMOD mod)
        {
            return GuanJiaoZhenImgDAO.Insertmod(mod);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(GuanJiaoZhenImgMOD mod)
        {
            return GuanJiaoZhenImgDAO.Updatemod(mod);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns></returns>
        public static int Delete(string id)
        {
            return GuanJiaoZhenImgDAO.Delete(id);
        }
        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GuanJiaoZhenImgMOD GetmodByid(int id)
        {
            return GuanJiaoZhenImgDAO.GetmodByid(id);
        }
           /// <summary>
        /// 根据主键管脚真型号查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GuanJiaoZhenImgMOD GetmodByid(string GuanJiaoZhenNo)
        {
            return GuanJiaoZhenImgDAO.GetmodByid(GuanJiaoZhenNo);
        }
    }
}
