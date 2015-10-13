using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class PriceManageMOD
    {
        private int _priceId;
        private string _customNo;
        private string _productNo;
        private decimal _price;
       /// <summary>
       /// 单价
       /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
       /// <summary>
       /// 产品型号
       /// </summary>
        public string ProductNo
        {
            get { return _productNo; }
            set { _productNo = value; }
        }
       /// <summary>
       /// 客户编号
       /// </summary>
        public string CustomNo
        {
            get { return _customNo; }
            set { _customNo = value; }
        }
       /// <summary>
       /// 价格表id
       /// </summary>
        public int PriceId
        {
            get { return _priceId; }
            set { _priceId = value; }
        }
    }
}
