using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class MattersNeedingAttentionMOD
    {
        private int _id;
        private string _customerNo;
        private string _customerName;
        private string _contents;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get { return _contents; }
            set { _contents = value; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNo
        {
            get { return _customerNo; }
            set { _customerNo = value; }
        }
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
