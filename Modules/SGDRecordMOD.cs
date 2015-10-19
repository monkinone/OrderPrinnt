using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class SGDRecordMOD
    {
        private int _id;
        private string _orderNum;
        private string _customerNum;
        private string _proType;
        private string _suigongdan;

        public string Suigongdan
        {
            get { return _suigongdan; }
            set { _suigongdan = value; }
        }

        public string ProType
        {
            get { return _proType; }
            set { _proType = value; }
        }

        public string CustomerNum
        {
            get { return _customerNum; }
            set { _customerNum = value; }
        }

        public string OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 随工单打印数量
        /// </summary>
        public string PrintCount { get; set; }
    }
}
