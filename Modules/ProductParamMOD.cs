using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class ProductParamMOD
    {
        private int _paramId;
        private string _customNo;
        private string _productNo;
        private string _paramContent;
        private int _isWriteFahuoInfo;
        private int _isWriteXianChang;
        private string _wuliaobian;
       /// <summary>
       /// 物料编
       /// </summary>
        public string Wuliaobian
        {
            get { return _wuliaobian; }
            set { _wuliaobian = value; }
        }
       /// <summary>
        /// 是否填写输入、输出线长（20140603新增）0 填写 1不填写
       /// </summary>
        public int IsWriteXianChang
        {
            get { return _isWriteXianChang; }
            set { _isWriteXianChang = value; }
        }
       /// <summary>
        /// 是否填写客户发货信息（20140603新增）  0 填写 1不填写
       /// </summary>
        public int IsWriteFahuoInfo
        {
            get { return _isWriteFahuoInfo; }
            set { _isWriteFahuoInfo = value; }
        }
       /// <summary>
       /// 客户参数
       /// </summary>
        public string ParamContent
        {
            get { return _paramContent; }
            set { _paramContent = value; }
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
       /// 参数id
       /// </summary>
        public int ParamId
        {
            get { return _paramId; }
            set { _paramId = value; }
        }
    }
}
