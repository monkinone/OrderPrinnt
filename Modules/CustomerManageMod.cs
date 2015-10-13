using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class CustomerManageMod
    {
        private int _customerId;
        private string _customerNo;
        private string _companyName;
        private string _contacts;
        private string _position;
        private string _phone;
        private string _telPhone;
        private string _tax;
        private string _discount;
        private string _InvoiceMethod;
        private string _backMethod;
        private int _isFanben;
        private string _modifyPriceRecord;
        private string _description;
        private int _isShowPrice;
        private int _islock;
        private string _companyAddress;
        private string _otherDangAn;
        private string _zhangHao;
        private string _shuiHao;
        private int _isAddInfo;
       /// <summary>
        /// 是否在订单里填写客户信息（1是 0 否）
       /// </summary>
        public int IsAddInfo
        {
            get { return _isAddInfo; }
            set { _isAddInfo = value; }
        }

       /// <summary>
       /// 税号
       /// </summary>
        public string ShuiHao
        {
            get { return _shuiHao; }
            set { _shuiHao = value; }
        }
       /// <summary>
       /// 账号
       /// </summary>
        public string ZhangHao
        {
            get { return _zhangHao; }
            set { _zhangHao = value; }
        }
       /// <summary>
       /// 其他联系档案
       /// </summary>
        public string OtherDangAn
        {
            get { return _otherDangAn; }
            set { _otherDangAn = value; }
        }
       /// <summary>
       /// 公司地址
       /// </summary>
        public string CompanyAddress
        {
            get { return _companyAddress; }
            set { _companyAddress = value; }
        }
       /// <summary>
       /// 是否冻结 1是 0否
       /// </summary>
        public int Islock
        {
            get { return _islock; }
            set { _islock = value; }
        }
       /// <summary>
       /// 打印时是否显示单价
       /// </summary>
        public int IsShowPrice
        {
            get { return _isShowPrice; }
            set { _isShowPrice = value; }
        }
       /// <summary>
        /// 联系性别与性格描述
       /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
       /// <summary>
       /// 调价记录
       /// </summary>
        public string ModifyPriceRecord
        {
            get { return _modifyPriceRecord; }
            set { _modifyPriceRecord = value; }
        }
       /// <summary>
       /// 是否合同范本
       /// </summary>
        public int IsFanben
        {
            get { return _isFanben; }
            set { _isFanben = value; }
        }
       /// <summary>
       /// 汇款方式
       /// </summary>
        public string BackMethod
        {
            get { return _backMethod; }
            set { _backMethod = value; }
        }
       /// <summary>
       /// 开票方式
       /// </summary>
        public string InvoiceMethod
        {
            get { return _InvoiceMethod; }
            set { _InvoiceMethod = value; }
        }
       /// <summary>
       /// 客户折扣
       /// </summary>
        public string Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
       /// <summary>
       /// 传真
       /// </summary>
        public string Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
       /// <summary>
       /// 手机
       /// </summary>
        public string TelPhone
        {
            get { return _telPhone; }
            set { _telPhone = value; }
        }
       /// <summary>
       /// 联系电话
       /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
       /// <summary>
       /// 职务
       /// </summary>
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
       /// <summary>
       /// 联系人
       /// </summary>
        public string Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }
       /// <summary>
       /// 公司名称
       /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
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
       /// 客户id
       /// </summary>
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }
    }
}
