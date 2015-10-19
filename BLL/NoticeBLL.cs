using OrderPrintSystem.DAO;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderPrintSystem.BLL
{
    public class NoticeBLL
    {
         /// <summary>
        /// 获取信息无分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetmodAll(string strWhere)
        {
            return NoticeDAO.GetmodAll(strWhere);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dtomodList">对象</param>
        /// <returns></returns>
        public static int Insertmod(NoticeMOD mod)
        {
            return NoticeDAO.Insertmod(mod);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dtomodList">数据对象</param>
        /// <returns></returns>
        public static int Updatemod(NoticeMOD mod)
        {
            return NoticeDAO.Updatemod(mod);
        }

        /// <summary>
        /// 根据主键id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NoticeMOD GetmodByid(int id)
        {
            return NoticeDAO.GetmodByid(id);
        }
    }
}
