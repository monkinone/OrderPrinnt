/**  版本信息模板在安装目录下，可自行修改。
* proOrdersDetail.cs
*
* 功 能： N/A
* 类 名： proOrdersDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-5-14 11:03:07   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace OrderPrintSystem.Model
{
    /// <summary>
    /// proOrdersDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProOrdersDetailMOD
    {
        public ProOrdersDetailMOD()
        { }
        #region Model
        private int _orderdetailid;
        private string _ordernum;
        private string _protype;
        private int? _pronum;
        private decimal? _proprice;
        private string _withworkno;
        private DateTime? _printtime;
        private string _printtype;
        private int? _printcount;
        private string _piHao;
        private DateTime? _planSendTime;
        private string _productAddress;
        private DateTime _printSGDTime;
        private int _printSGDCount;
        private DateTime _printSGDJLTime;
        private int _printSGDJLCount;
        private DateTime _printQLDTime;
        private int _printQLDCount;
        private DateTime _printCCJYBGTime;
        private int _printCCJYBGCount;
        private DateTime _printSHDTime;
        private int _printSHDCount;
        private DateTime _printBZBQTime;
        private int _printBZBQCount;
        private DateTime _printZYSXTime;
        private int _printZYSXCount;
        private DateTime _printYYQRDTime;
        private int _printYYQRDCount;
        private int _sGDCount;
        private string _wuliaobian;

        public string Wuliaobian
        {
            get { return _wuliaobian; }
            set { _wuliaobian = value; }
        }
        /// <summary>
        /// 随工单已打印数量
        /// </summary>
        public int SGDCount
        {
            get { return _sGDCount; }
            set { _sGDCount = value; }
        }


        public int PrintYYQRDCount
        {
            get { return _printYYQRDCount; }
            set { _printYYQRDCount = value; }
        }

        public DateTime PrintYYQRDTime
        {
            get { return _printYYQRDTime; }
            set { _printYYQRDTime = value; }
        }

        public int PrintZYSXCount
        {
            get { return _printZYSXCount; }
            set { _printZYSXCount = value; }
        }

        public DateTime PrintZYSXTime
        {
            get { return _printZYSXTime; }
            set { _printZYSXTime = value; }
        }

        public int PrintBZBQCount
        {
            get { return _printBZBQCount; }
            set { _printBZBQCount = value; }
        }

        public DateTime PrintBZBQTime
        {
            get { return _printBZBQTime; }
            set { _printBZBQTime = value; }
        }

        public int PrintSHDCount
        {
            get { return _printSHDCount; }
            set { _printSHDCount = value; }
        }

        public DateTime PrintSHDTime
        {
            get { return _printSHDTime; }
            set { _printSHDTime = value; }
        }

        public int PrintCCJYBGCount
        {
            get { return _printCCJYBGCount; }
            set { _printCCJYBGCount = value; }
        }

        public DateTime PrintCCJYBGTime
        {
            get { return _printCCJYBGTime; }
            set { _printCCJYBGTime = value; }
        }

        public int PrintQLDCount
        {
            get { return _printQLDCount; }
            set { _printQLDCount = value; }
        }
        public DateTime PrintQLDTime
        {
            get { return _printQLDTime; }
            set { _printQLDTime = value; }
        }


        public int PrintSGDJLCount
        {
            get { return _printSGDJLCount; }
            set { _printSGDJLCount = value; }
        }

        public DateTime PrintSGDJLTime
        {
            get { return _printSGDJLTime; }
            set { _printSGDJLTime = value; }
        }

        public int PrintSGDCount
        {
            get { return _printSGDCount; }
            set { _printSGDCount = value; }
        }

        public DateTime PrintSGDTime
        {
            get { return _printSGDTime; }
            set { _printSGDTime = value; }
        }
        /// <summary>
        /// 生产地
        /// </summary>
        public string ProductAddress
        {
            get { return _productAddress; }
            set { _productAddress = value; }
        }
        /// <summary>
        /// 计划发货日期
        /// </summary>
        public DateTime? PlanSendTime
        {
            get { return _planSendTime; }
            set { _planSendTime = value; }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string PiHao
        {
            get { return _piHao; }
            set { _piHao = value; }
        }
        /// <summary>
        /// 主键id
        /// </summary>
        public int orderDetailId
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string proType
        {
            set { _protype = value; }
            get { return _protype; }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int? proNum
        {
            set { _pronum = value; }
            get { return _pronum; }
        }
        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal? ProPrice
        {
            set { _proprice = value; }
            get { return _proprice; }
        }
        /// <summary>
        /// 随工单号
        /// </summary>
        public string withWorkNo
        {
            set { _withworkno = value; }
            get { return _withworkno; }
        }
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? printTime
        {
            set { _printtime = value; }
            get { return _printtime; }
        }
        /// <summary>
        /// 打印类型
        /// </summary>
        public string printType
        {
            set { _printtype = value; }
            get { return _printtype; }
        }
        /// <summary>
        /// 打印次数
        /// </summary>
        public int? printCount
        {
            set { _printcount = value; }
            get { return _printcount; }
        }
        #endregion Model

    }
}

