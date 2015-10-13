using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class GuiGeShuMOD
    {
        private int _id;
        private string _fileUrl;
        private string _productNo;
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProductNo
        {
            get { return _productNo; }
            set { _productNo = value; }
        }
        /// <summary>
        /// 规格书路径
        /// </summary>
        public string FileUrl
        {
            get { return _fileUrl; }
            set { _fileUrl = value; }
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
