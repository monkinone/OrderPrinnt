
using System;
namespace OrderPrintSystem.Model
{
    /// <summary>
    /// products:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductsMOD
    {
        public ProductsMOD()
        { }
        #region Model
        private int _productid;
        private string _productname;
        private string _productnum;
        private int? _waibz;
        private string _neibz;
        private string _neibzdw;
        private string _bian;
        private string _jingdu;
        private string _xianxingdu;
        private string _edingjc;
        private int? _tiexicount;
        private string _guige;
        private string _cailiao;
        private string _xingneng;
        private string _chulimethod;
        private string _baohedian;
        private int? _xianquancount;
        private string _chujzashu;
        private string _chujxianjing;
        private string _chujraoxianzd;
        private string _chujxiantoucd;
        private string _chujxiantoucl;
        private string _chujtongmd;
        private string _cijzashu;
        private string _cijxianjing;
        private string _cijraoxianzd;
        private string _cijxiantoucd;
        private string _cijxiantoucl;
        private string _cijtongmd;
        private string _xqjcyqequip;
        private string _xqjcyqshurustate;
        private string _xqjcyqshuchustate;
        private string _xqjcyqjiaocha;
        private string _xqjcyqfuzai;
        private string _biaoshino;
        private string _waikeno;
        private int? _waikecount;
        private string _yongjiaocs;
        private string _shuru;
        private string _shuchu;
        private string _biaoshiaddress;
        private string _chajianno;
        private int? _chajiancount;
        private string _waixingtz;
        private string _cpjccsequip;
        private string _cpjccsshurustate;
        private string _cpjccsshuchustate;
        private string _cpjccsjiaochabh;
        private string _cpjccsfuzai;
        private string _cpjccsnaiya;
        private string _cpjccstongmd;
        private string _guanjiaozhenlx;
        private int? _guanjiaozhenlxcount;
        private string _guanjiaozhenlxtow;
        private int? _guanjiaozhenlxtowcount;
        private string _shuruxc;
        private string _shuchuxc;
        private string _peixiansr;
        private decimal? _peixiansrcount;
        private string _peixiansc;
        private decimal? _peixiansccount;
        private string _remark;
        private int? _ismodifytz;
        private string _biaoshipicture;
        private int? _isModifyWaikeNo;
        private string _gongyiZYSX;
        private string baoZhuangHeGG;
        private string gujiaCanshu;

        public string GujiaCanshu
        {
            get { return gujiaCanshu; }
            set { gujiaCanshu = value; }
        }
        private decimal gujiaCount;

        public decimal GujiaCount
        {
            get { return gujiaCount; }
            set { gujiaCount = value; }
        }
        private string tongpaiCanshu;

        public string TongpaiCanshu
        {
            get { return tongpaiCanshu; }
            set { tongpaiCanshu = value; }
        }
        private decimal tongpaoCount;

        public decimal TongpaoCount
        {
            get { return tongpaoCount; }
            set { tongpaoCount = value; }
        }
        private string cihuanCanshu;

        public string CihuanCanshu
        {
            get { return cihuanCanshu; }
            set { cihuanCanshu = value; }
        }
        private decimal cihuanCount;

        public decimal CihuanCount
        {
            get { return cihuanCount; }
            set { cihuanCount = value; }
        }
        private string duanziCanshu;

        public string DuanziCanshu
        {
            get { return duanziCanshu; }
            set { duanziCanshu = value; }
        }
        private decimal duanziCount;

        public decimal DuanziCount
        {
            get { return duanziCount; }
            set { duanziCount = value; }
        }
        private string xianlubanCanshu;

        public string XianlubanCanshu
        {
            get { return xianlubanCanshu; }
            set { xianlubanCanshu = value; }
        }
        private decimal xianlubanCount;

        public decimal XianlubanCount
        {
            get { return xianlubanCount; }
            set { xianlubanCount = value; }
        }
        private string jiaopianCanshu;

        public string JiaopianCanshu
        {
            get { return jiaopianCanshu; }
            set { jiaopianCanshu = value; }
        }
        private decimal jiaopianCount;

        public decimal JiaopianCount
        {
            get { return jiaopianCount; }
            set { jiaopianCount = value; }
        }
        private string pingbiCanshu;

        public string PingbiCanshu
        {
            get { return pingbiCanshu; }
            set { pingbiCanshu = value; }
        }
        private decimal pingbiCount;

        public decimal PingbiCount
        {
            get { return pingbiCount; }
            set { pingbiCount = value; }
        }
        private string wenyaguanCanshu;

        public string WenyaguanCanshu
        {
            get { return wenyaguanCanshu; }
            set { wenyaguanCanshu = value; }
        }
        private decimal wenyaguanCount;

        public decimal WenyaguanCount
        {
            get { return wenyaguanCount; }
            set { wenyaguanCount = value; }
        }
        private string dianzuCanshu;

        public string DianzuCanshu
        {
            get { return dianzuCanshu; }
            set { dianzuCanshu = value; }
        }
        private decimal dianzuCount;

        public decimal DianzuCount
        {
            get { return dianzuCount; }
            set { dianzuCount = value; }
        }
        private string luosiCanshu;

        public string LuosiCanshu
        {
            get { return luosiCanshu; }
            set { luosiCanshu = value; }
        }
        private decimal luosiCount;

        public decimal LuosiCount
        {
            get { return luosiCount; }
            set { luosiCount = value; }
        }
        private string resuotaoguanCanshu;

        public string ResuotaoguanCanshu
        {
            get { return resuotaoguanCanshu; }
            set { resuotaoguanCanshu = value; }
        }
        private decimal resuotaoguanCount;

        public decimal ResuotaoguanCount
        {
            get { return resuotaoguanCount; }
            set { resuotaoguanCount = value; }
        }
        private string anzhuangPJCanshu;

        public string AnzhuangPJCanshu
        {
            get { return anzhuangPJCanshu; }
            set { anzhuangPJCanshu = value; }
        }
        private decimal anzhuangPJCount;

        public decimal AnzhuangPJCount
        {
            get { return anzhuangPJCount; }
            set { anzhuangPJCount = value; }
        }
        private string yuanqijian1Canshu;

        public string Yuanqijian1Canshu
        {
            get { return yuanqijian1Canshu; }
            set { yuanqijian1Canshu = value; }
        }
        private decimal Yuanqijian1Count;

        public decimal Yuanqijian1Count1
        {
            get { return Yuanqijian1Count; }
            set { Yuanqijian1Count = value; }
        }
        private string Yuanqijian2Canshu;

        public string Yuanqijian2Canshu1
        {
            get { return Yuanqijian2Canshu; }
            set { Yuanqijian2Canshu = value; }
        }
        private decimal Yuanqijian2Count;

        public decimal Yuanqijian2Count1
        {
            get { return Yuanqijian2Count; }
            set { Yuanqijian2Count = value; }
        }
        private string Yuanqijian3Canshu;

        public string Yuanqijian3Canshu1
        {
            get { return Yuanqijian3Canshu; }
            set { Yuanqijian3Canshu = value; }
        }
        private decimal Yuanqijian3Count;

        public decimal Yuanqijian3Count1
        {
            get { return Yuanqijian3Count; }
            set { Yuanqijian3Count = value; }
        }
        private string Yuanqijian4Canshu;

        public string Yuanqijian4Canshu1
        {
            get { return Yuanqijian4Canshu; }
            set { Yuanqijian4Canshu = value; }
        }
        private decimal Yuanqijian4Count;

        public decimal Yuanqijian4Count1
        {
            get { return Yuanqijian4Count; }
            set { Yuanqijian4Count = value; }
        }
        public string BaoZhuangHeGG
        {
            get { return baoZhuangHeGG; }
            set { baoZhuangHeGG = value; }
        }
        private string baoZhuangXiangGG;

        public string BaoZhuangXiangGG
        {
            get { return baoZhuangXiangGG; }
            set { baoZhuangXiangGG = value; }
        }
        private string baoHeDianTestTJ;

        public string BaoHeDianTestTJ
        {
            get { return baoHeDianTestTJ; }
            set { baoHeDianTestTJ = value; }
        }
        private string guJia;

        public string GuJia
        {
            get { return guJia; }
            set { guJia = value; }
        }
        private string tongPai;

        public string TongPai
        {
            get { return tongPai; }
            set { tongPai = value; }
        }
        private string ciHuan;

        public string CiHuan
        {
            get { return ciHuan; }
            set { ciHuan = value; }
        }
        private string duanZi;

        public string DuanZi
        {
            get { return duanZi; }
            set { duanZi = value; }
        }
        private string xianLuBan;

        public string XianLuBan
        {
            get { return xianLuBan; }
            set { xianLuBan = value; }
        }
        private string jiaoPian;

        public string JiaoPian
        {
            get { return jiaoPian; }
            set { jiaoPian = value; }
        }
        private string pingBi;

        public string PingBi
        {
            get { return pingBi; }
            set { pingBi = value; }
        }
        private string wenYaGuan;

        public string WenYaGuan
        {
            get { return wenYaGuan; }
            set { wenYaGuan = value; }
        }
        private string dianZu;

        public string DianZu
        {
            get { return dianZu; }
            set { dianZu = value; }
        }
        private string luoSi;

        public string LuoSi
        {
            get { return luoSi; }
            set { luoSi = value; }
        }
        private string reSuoTaoGuan;

        public string ReSuoTaoGuan
        {
            get { return reSuoTaoGuan; }
            set { reSuoTaoGuan = value; }
        }
        private string anZhuangPJ;

        public string AnZhuangPJ
        {
            get { return anZhuangPJ; }
            set { anZhuangPJ = value; }
        }
        private string yuanQiJian1;

        public string YuanQiJian1
        {
            get { return yuanQiJian1; }
            set { yuanQiJian1 = value; }
        }
        private string yuanQiJian2;

        public string YuanQiJian2
        {
            get { return yuanQiJian2; }
            set { yuanQiJian2 = value; }
        }
        private string yuanQiJian3;

        public string YuanQiJian3
        {
            get { return yuanQiJian3; }
            set { yuanQiJian3 = value; }
        }
        private string yuanQiJian4;

        public string YuanQiJian4
        {
            get { return yuanQiJian4; }
            set { yuanQiJian4 = value; }
        }
        /// <summary>
        /// 工艺注意事项
        /// </summary>
        public string GongyiZYSX
        {
            get { return _gongyiZYSX; }
            set { _gongyiZYSX = value; }
        }

        /// <summary>
        /// 是否修改了外壳编号  0 否 1是
        /// </summary>
        public int? IsModifyWaikeNo
        {
            get { return _isModifyWaikeNo; }
            set { _isModifyWaikeNo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int productId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productNum
        {
            set { _productnum = value; }
            get { return _productnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? waiBZ
        {
            set { _waibz = value; }
            get { return _waibz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NeiBZ
        {
            set { _neibz = value; }
            get { return _neibz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NeiBZDW
        {
            set { _neibzdw = value; }
            get { return _neibzdw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bian
        {
            set { _bian = value; }
            get { return _bian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jingDu
        {
            set { _jingdu = value; }
            get { return _jingdu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xianXingdu
        {
            set { _xianxingdu = value; }
            get { return _xianxingdu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eDingJC
        {
            set { _edingjc = value; }
            get { return _edingjc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tieXiCount
        {
            set { _tiexicount = value; }
            get { return _tiexicount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string guiGe
        {
            set { _guige = value; }
            get { return _guige; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string caiLiao
        {
            set { _cailiao = value; }
            get { return _cailiao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xingNeng
        {
            set { _xingneng = value; }
            get { return _xingneng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chuLiMethod
        {
            set { _chulimethod = value; }
            get { return _chulimethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string baoHeDian
        {
            set { _baohedian = value; }
            get { return _baohedian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? xianQuanCount
        {
            set { _xianquancount = value; }
            get { return _xianquancount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chujZaShu
        {
            set { _chujzashu = value; }
            get { return _chujzashu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chujXianJing
        {
            set { _chujxianjing = value; }
            get { return _chujxianjing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chujRaoXianZD
        {
            set { _chujraoxianzd = value; }
            get { return _chujraoxianzd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chujXianTouCD
        {
            set { _chujxiantoucd = value; }
            get { return _chujxiantoucd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chujXiantouCL
        {
            set { _chujxiantoucl = value; }
            get { return _chujxiantoucl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chujTongMD
        {
            set { _chujtongmd = value; }
            get { return _chujtongmd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cijZaShu
        {
            set { _cijzashu = value; }
            get { return _cijzashu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cijXianJing
        {
            set { _cijxianjing = value; }
            get { return _cijxianjing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cijRaoXianZD
        {
            set { _cijraoxianzd = value; }
            get { return _cijraoxianzd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cijXianTouCD
        {
            set { _cijxiantoucd = value; }
            get { return _cijxiantoucd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cijXianTouCL
        {
            set { _cijxiantoucl = value; }
            get { return _cijxiantoucl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cijTongMD
        {
            set { _cijtongmd = value; }
            get { return _cijtongmd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqjcyqEquip
        {
            set { _xqjcyqequip = value; }
            get { return _xqjcyqequip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqjcyqShuRuState
        {
            set { _xqjcyqshurustate = value; }
            get { return _xqjcyqshurustate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqjcyqShuChuState
        {
            set { _xqjcyqshuchustate = value; }
            get { return _xqjcyqshuchustate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqjcyqJiaoCha
        {
            set { _xqjcyqjiaocha = value; }
            get { return _xqjcyqjiaocha; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqjcyqFuZai
        {
            set { _xqjcyqfuzai = value; }
            get { return _xqjcyqfuzai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string biaoShiNo
        {
            set { _biaoshino = value; }
            get { return _biaoshino; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waiKeNo
        {
            set { _waikeno = value; }
            get { return _waikeno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? waiKeCount
        {
            set { _waikecount = value; }
            get { return _waikecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yongJiaoCS
        {
            set { _yongjiaocs = value; }
            get { return _yongjiaocs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shuRu
        {
            set { _shuru = value; }
            get { return _shuru; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shuChu
        {
            set { _shuchu = value; }
            get { return _shuchu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string biaoShiAddress
        {
            set { _biaoshiaddress = value; }
            get { return _biaoshiaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chajianNo
        {
            set { _chajianno = value; }
            get { return _chajianno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? chajianCount
        {
            set { _chajiancount = value; }
            get { return _chajiancount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waiXingTZ
        {
            set { _waixingtz = value; }
            get { return _waixingtz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpjccsEquip
        {
            set { _cpjccsequip = value; }
            get { return _cpjccsequip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpjccsShuRuState
        {
            set { _cpjccsshurustate = value; }
            get { return _cpjccsshurustate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpjccsShuChuState
        {
            set { _cpjccsshuchustate = value; }
            get { return _cpjccsshuchustate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CpjccsJiaoChaBH
        {
            set { _cpjccsjiaochabh = value; }
            get { return _cpjccsjiaochabh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpjccsFuZai
        {
            set { _cpjccsfuzai = value; }
            get { return _cpjccsfuzai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpjccsNaiYa
        {
            set { _cpjccsnaiya = value; }
            get { return _cpjccsnaiya; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpjccsTongMD
        {
            set { _cpjccstongmd = value; }
            get { return _cpjccstongmd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string guanJiaoZhenLX
        {
            set { _guanjiaozhenlx = value; }
            get { return _guanjiaozhenlx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? guanJIaoZhenLXCount
        {
            set { _guanjiaozhenlxcount = value; }
            get { return _guanjiaozhenlxcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string guanJiaoZhenLXTOW
        {
            set { _guanjiaozhenlxtow = value; }
            get { return _guanjiaozhenlxtow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? guanJiaoZhenLXTOWCount
        {
            set { _guanjiaozhenlxtowcount = value; }
            get { return _guanjiaozhenlxtowcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shuRuXC
        {
            set { _shuruxc = value; }
            get { return _shuruxc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shuChuXC
        {
            set { _shuchuxc = value; }
            get { return _shuchuxc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string peiXianSR
        {
            set { _peixiansr = value; }
            get { return _peixiansr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? peiXianSRCount
        {
            set { _peixiansrcount = value; }
            get { return _peixiansrcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string peiXianSC
        {
            set { _peixiansc = value; }
            get { return _peixiansc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? peiXianSCCount
        {
            set { _peixiansccount = value; }
            get { return _peixiansccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isModifyTZ
        {
            set { _ismodifytz = value; }
            get { return _ismodifytz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string biaoShiPicture
        {
            set { _biaoshipicture = value; }
            get { return _biaoshipicture; }
        }
        #endregion Model

    }
}

