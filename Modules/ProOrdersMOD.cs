/**  版本信息模板在安装目录下，可自行修改。
* proOrders.cs
*
* 功 能： N/A
* 类 名： proOrders
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
	/// proOrders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProOrdersMOD
	{
        public ProOrdersMOD()
		{}
		#region Model
		private int _orderid;
		private string _ordernum;
		private string _customnum;
		private string _hetongnum;
		private string _customordernum;
		private string _customwlbh;
		private string _custommanager;
		private string _remark;
		private DateTime? _edittime;
        private DateTime? _updateTime;
        private decimal _yikaipiaoMoney;
        private decimal _yijiekuanMoney;
        private string _faPiaoDanhao;
        private string _chengShuiHao;
        private string _remark1;
        private int _editUser;
        private int _isTiXing;
        private string _shuRuXianchang;
        private string _shuChuXianchang;
        /// <summary>
        /// 输入线长
        /// </summary>
        public string ShuChuXianchang
        {
            get { return _shuChuXianchang; }
            set { _shuChuXianchang = value; }
        }
        /// <summary>
        /// 输出线长
        /// </summary>
        public string ShuRuXianchang
        {
            get { return _shuRuXianchang; }
            set { _shuRuXianchang = value; }
        }
        /// <summary>
        /// 是否提醒（0是1否）
        /// </summary>
        public int IsTiXing
        {
            get { return _isTiXing; }
            set { _isTiXing = value; }
        }
        /// <summary>
        /// 编辑人
        /// </summary>
        public int EditUser
        {
            get { return _editUser; }
            set { _editUser = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }
        /// <summary>
        /// 承兑号
        /// </summary>
        public string ChengShuiHao
        {
            get { return _chengShuiHao; }
            set { _chengShuiHao = value; }
        }
        /// <summary>
        /// 发票邮寄单号
        /// </summary>
        public string FaPiaoDanhao
        {
            get { return _faPiaoDanhao; }
            set { _faPiaoDanhao = value; }
        }
        /// <summary>
        /// 已结款金额
        /// </summary>
        public decimal YijiekuanMoney
        {
            get { return _yijiekuanMoney; }
            set { _yijiekuanMoney = value; }
        }
        /// <summary>
        /// 已开票金额
        /// </summary>
        public decimal YikaipiaoMoney
        {
            get { return _yikaipiaoMoney; }
            set { _yikaipiaoMoney = value; }
        }

        public DateTime? UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customNum
		{
			set{ _customnum=value;}
			get{return _customnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string heTongNum
		{
			set{ _hetongnum=value;}
			get{return _hetongnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customOrderNum
		{
			set{ _customordernum=value;}
			get{return _customordernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customWLBH
		{
			set{ _customwlbh=value;}
			get{return _customwlbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customManager
		{
			set{ _custommanager=value;}
			get{return _custommanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? editTime
		{
			set{ _edittime=value;}
			get{return _edittime;}
		}
        public string 发货状态 { get; set; }
		#endregion Model

	}
}

