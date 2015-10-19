using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class SendDetailMOD
    {
        /// <summary>
        /// 随工单号
        /// </summary>
        public string PrintCompanyName
        {
            get;
            set;
        }
        private int _sendId;
        private string _orderNum;
        private string _proType;
        private int _sendProNum;
        private decimal _unitPrice;
        private DateTime _sendTime;
        private string _remark;
        private string _sendNum;
        private string _packingCompanyName;
        private string _suiGongDanNum;
        /// <summary>
        /// 随工单号
        /// </summary>
        public string SuiGongDanNum
        {
            get { return _suiGongDanNum; }
            set { _suiGongDanNum = value; }
        }
        /// <summary>
        /// 货运公司名称
        /// </summary>
        public string PackingCompanyName
        {
            get { return _packingCompanyName; }
            set { _packingCompanyName = value; }
        }
        /// <summary>
        /// 运单号
        /// </summary>
        public string SendNum
        {
            get { return _sendNum; }
            set { _sendNum = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime SendTime
        {
            get { return _sendTime; }
            set { _sendTime = value; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        /// <summary>
        /// 发货数量
        /// </summary>
        public int SendProNum
        {
            get { return _sendProNum; }
            set { _sendProNum = value; }
        }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProType
        {
            get { return _proType; }
            set { _proType = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }
        /// <summary>
        /// 主键id
        /// </summary>
        public int SendId
        {
            get { return _sendId; }
            set { _sendId = value; }
        }
    }
}
