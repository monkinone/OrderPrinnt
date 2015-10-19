
using System;
using System.Data;
using System.Collections.Generic;
using OrderPrintSystem.Model;
using System.Text;
using OrderPrintSystem.DAL;
namespace OrderPrintSystem.BLL
{
	/// <summary>
	/// products
	/// </summary>
	public partial class ProductsBLL
	{
        public ProductsBLL()
		{}
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(OrderPrintSystem.Model.ProductsMOD model)
        {

            return ProductsDAO.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(OrderPrintSystem.Model.ProductsMOD model)
        {
            return ProductsDAO.Update(model);
           

        }
         /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(string productNum)
        {
            return ProductsDAO.Update(productNum);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int Delete(int productId)
        {

            return ProductsDAO.Delete(productId);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static int DeleteList(string productIdlist)
        {

            return ProductsDAO.DeleteList(productIdlist);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProductsMOD GetModel(int productId)
        {
            return ProductsDAO.GetModel(productId);
           
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProductsMOD GetModel(string protype)
        {
            return ProductsDAO.GetModel(protype);

        }
        /// <summary>
        /// 获取所有产品信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetList(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            return ProductsDAO.GetList(PageSize,PageIndex,out PageCount,strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return ProductsDAO.GetList(strWhere);
        }

        /// 根据产品型号获取产品名称
        /// </summary>
        /// <param name="proType">产品型号</param>
        /// <returns></returns>
        public string GetProductNameByProductNum(string proType)
        {
            return new ProductsDAO().GetProductNameByProductNum(proType);
        }

        #endregion  BasicMethod
	}
}

