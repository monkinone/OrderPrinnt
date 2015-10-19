
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NewsSystem.DBUtility;
using System.Collections.Generic;
namespace OrderPrintSystem.DAL
{
    /// <summary>
    /// 数据访问类:products
    /// </summary>
    public partial class ProductsDAO
    {
        public ProductsDAO()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(OrderPrintSystem.Model.ProductsMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into products(");
            strSql.Append(@"productName,productNum,waiBZ,NeiBZ,NeiBZDW,bian,jingDu,xianXingdu,eDingJC,tieXiCount,guiGe,caiLiao,xingNeng,chuLiMethod,baoHeDian,xianQuanCount,chujZaShu,chujXianJing,chujRaoXianZD,chujXianTouCD,chujXiantouCL,chujTongMD,cijZaShu,cijXianJing,cijRaoXianZD,cijXianTouCD,cijXianTouCL,cijTongMD,xqjcyqEquip,xqjcyqShuRuState,xqjcyqShuChuState,xqjcyqJiaoCha,xqjcyqFuZai,biaoShiNo,waiKeNo,waiKeCount,yongJiaoCS,shuRu,shuChu,biaoShiAddress,chajianNo,chajianCount,waiXingTZ,cpjccsEquip,cpjccsShuRuState,cpjccsShuChuState,CpjccsJiaoChaBH,cpjccsFuZai,cpjccsNaiYa,cpjccsTongMD,guanJiaoZhenLX,guanJIaoZhenLXCount,guanJiaoZhenLXTOW,guanJiaoZhenLXTOWCount,shuRuXC,shuChuXC,peiXianSR,peiXianSRCount,peiXianSC,peiXianSCCount,remark,isModifyTZ,biaoShiPicture,isModifyWaikeNo,GongyiZYSX,
baoZhuangHeGG,
baoZhuangXiangGG,
baoHeDianTestTJ,
guJia,
tongPai,
ciHuan,
duanZi,
xianLuBan,
jiaoPian,
pingBi,
wenYaGuan,
dianZu,
luoSi,
reSuoTaoGuan,
anZhuangPJ,
yuanQiJian1,
yuanQiJian2,
yuanQiJian3,
yuanQiJian4,
gujiaCanshu,
gujiaCount,
tongpaiCanshu,
tongpaoCount,
cihuanCanshu,
cihuanCount,
duanziCanshu,
duanziCount,
xianlubanCanshu,
xianlubanCount,
jiaopianCanshu,
jiaopianCount,
pingbiCanshu,
pingbiCount,
wenyaguanCanshu,
wenyaguanCount,
dianzuCanshu,
dianzuCount,
luosiCanshu,
luosiCount,
resuotaoguanCanshu,
resuotaoguanCount,
anzhuangPJCanshu,
anzhuangPJCount,
yuanqijian1Canshu,
Yuanqijian1Count,
Yuanqijian2Canshu,
Yuanqijian2Count,
Yuanqijian3Canshu,
Yuanqijian3Count,
Yuanqijian4Canshu,
Yuanqijian4Count)");
            strSql.Append(" values (");
            strSql.Append(@"@productName,@productNum,@waiBZ,@NeiBZ,@NeiBZDW,@bian,@jingDu,@xianXingdu,@eDingJC,@tieXiCount,@guiGe,@caiLiao,@xingNeng,@chuLiMethod,@baoHeDian,@xianQuanCount,@chujZaShu,@chujXianJing,@chujRaoXianZD,@chujXianTouCD,@chujXiantouCL,@chujTongMD,@cijZaShu,@cijXianJing,@cijRaoXianZD,@cijXianTouCD,@cijXianTouCL,@cijTongMD,@xqjcyqEquip,@xqjcyqShuRuState,@xqjcyqShuChuState,@xqjcyqJiaoCha,@xqjcyqFuZai,@biaoShiNo,@waiKeNo,@waiKeCount,@yongJiaoCS,@shuRu,@shuChu,@biaoShiAddress,@chajianNo,@chajianCount,@waiXingTZ,@cpjccsEquip,@cpjccsShuRuState,@cpjccsShuChuState,@CpjccsJiaoChaBH,@cpjccsFuZai,@cpjccsNaiYa,@cpjccsTongMD,@guanJiaoZhenLX,@guanJIaoZhenLXCount,@guanJiaoZhenLXTOW,@guanJiaoZhenLXTOWCount,@shuRuXC,@shuChuXC,@peiXianSR,@peiXianSRCount,@peiXianSC,@peiXianSCCount,@remark,@isModifyTZ,@biaoShiPicture,@isModifyWaikeNo,@GongyiZYSX,
                @baoZhuangHeGG,
@baoZhuangXiangGG,
@baoHeDianTestTJ,
@guJia,
@tongPai,
@ciHuan,
@duanZi,
@xianLuBan,
@jiaoPian,
@pingBi,
@wenYaGuan,
@dianZu,
@luoSi,
@reSuoTaoGuan,
@anZhuangPJ,
@yuanQiJian1,
@yuanQiJian2,
@yuanQiJian3,
@yuanQiJian4,
@gujiaCanshu,
@gujiaCount,
@tongpaiCanshu,
@tongpaoCount,
@cihuanCanshu,
@cihuanCount,
@duanziCanshu,
@duanziCount,
@xianlubanCanshu,
@xianlubanCount,
@jiaopianCanshu,
@jiaopianCount,
@pingbiCanshu,
@pingbiCount,
@wenyaguanCanshu,
@wenyaguanCount,
@dianzuCanshu,
@dianzuCount,
@luosiCanshu,
@luosiCount,
@resuotaoguanCanshu,
@resuotaoguanCount,
@anzhuangPJCanshu,
@anzhuangPJCount,
@yuanqijian1Canshu,
@Yuanqijian1Count,
@Yuanqijian2Canshu,
@Yuanqijian2Count,
@Yuanqijian3Canshu,
@Yuanqijian3Count,
@Yuanqijian4Canshu,
@Yuanqijian4Count)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@productName", SqlDbType.VarChar,500),
					new SqlParameter("@productNum", SqlDbType.VarChar,500),
					new SqlParameter("@waiBZ", SqlDbType.Int,4),
					new SqlParameter("@NeiBZ", SqlDbType.VarChar,500),
					new SqlParameter("@NeiBZDW", SqlDbType.VarChar,500),
					new SqlParameter("@bian", SqlDbType.VarChar,500),
					new SqlParameter("@jingDu", SqlDbType.VarChar,500),
					new SqlParameter("@xianXingdu", SqlDbType.VarChar,500),
					new SqlParameter("@eDingJC", SqlDbType.VarChar,500),
					new SqlParameter("@tieXiCount", SqlDbType.Int,4),
					new SqlParameter("@guiGe", SqlDbType.VarChar,500),
					new SqlParameter("@caiLiao", SqlDbType.VarChar,500),
					new SqlParameter("@xingNeng", SqlDbType.VarChar,500),
					new SqlParameter("@chuLiMethod", SqlDbType.VarChar,500),
					new SqlParameter("@baoHeDian", SqlDbType.VarChar,500),
					new SqlParameter("@xianQuanCount", SqlDbType.Decimal),
					new SqlParameter("@chujZaShu", SqlDbType.VarChar,500),
					new SqlParameter("@chujXianJing", SqlDbType.VarChar,500),
					new SqlParameter("@chujRaoXianZD", SqlDbType.VarChar,500),
					new SqlParameter("@chujXianTouCD", SqlDbType.VarChar,500),
					new SqlParameter("@chujXiantouCL", SqlDbType.VarChar,500),
					new SqlParameter("@chujTongMD", SqlDbType.VarChar,500),
					new SqlParameter("@cijZaShu", SqlDbType.VarChar,500),
					new SqlParameter("@cijXianJing", SqlDbType.VarChar,500),
					new SqlParameter("@cijRaoXianZD", SqlDbType.VarChar,500),
					new SqlParameter("@cijXianTouCD", SqlDbType.VarChar,500),
					new SqlParameter("@cijXianTouCL", SqlDbType.VarChar,500),
					new SqlParameter("@cijTongMD", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqEquip", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqShuRuState", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqShuChuState", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqJiaoCha", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqFuZai", SqlDbType.VarChar,500),
					new SqlParameter("@biaoShiNo", SqlDbType.VarChar,500),
					new SqlParameter("@waiKeNo", SqlDbType.VarChar,500),
					new SqlParameter("@waiKeCount", SqlDbType.Int,4),
					new SqlParameter("@yongJiaoCS", SqlDbType.VarChar,500),
					new SqlParameter("@shuRu", SqlDbType.VarChar,500),
					new SqlParameter("@shuChu", SqlDbType.VarChar,500),
					new SqlParameter("@biaoShiAddress", SqlDbType.VarChar,500),
					new SqlParameter("@chajianNo", SqlDbType.VarChar,500),
					new SqlParameter("@chajianCount", SqlDbType.Int,4),
					new SqlParameter("@waiXingTZ", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsEquip", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsShuRuState", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsShuChuState", SqlDbType.VarChar,500),
					new SqlParameter("@CpjccsJiaoChaBH", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsFuZai", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsNaiYa", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsTongMD", SqlDbType.VarChar,500),
					new SqlParameter("@guanJiaoZhenLX", SqlDbType.VarChar,500),
					new SqlParameter("@guanJIaoZhenLXCount", SqlDbType.Int,4),
					new SqlParameter("@guanJiaoZhenLXTOW", SqlDbType.VarChar,500),
					new SqlParameter("@guanJiaoZhenLXTOWCount", SqlDbType.Int,4),
					new SqlParameter("@shuRuXC", SqlDbType.VarChar,500),
					new SqlParameter("@shuChuXC", SqlDbType.VarChar,500),
					new SqlParameter("@peiXianSR", SqlDbType.VarChar,500),
					new SqlParameter("@peiXianSRCount", SqlDbType.Decimal,9),
					new SqlParameter("@peiXianSC", SqlDbType.VarChar,500),
					new SqlParameter("@peiXianSCCount", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@isModifyTZ", SqlDbType.Int,4),
					new SqlParameter("@biaoShiPicture", SqlDbType.VarChar,500),
                                        new SqlParameter("@isModifyWaikeNo",SqlDbType.Int,4),
                                        new SqlParameter("@GongyiZYSX",SqlDbType.VarChar,5000),
                                         new SqlParameter("@baoZhuangHeGG",SqlDbType.VarChar,100),
                                        new SqlParameter("@baoZhuangXiangGG",SqlDbType.VarChar,100),
                                        new SqlParameter("@baoHeDianTestTJ",SqlDbType.VarChar,100),
                                        new SqlParameter("@guJia",SqlDbType.VarChar,100),
                                        new SqlParameter("@tongPai",SqlDbType.VarChar,100),
                                        new SqlParameter("@ciHuan",SqlDbType.VarChar,100),
                                        new SqlParameter("@duanZi",SqlDbType.VarChar,100),
                                        new SqlParameter("@xianLuBan",SqlDbType.VarChar,100),
                                        new SqlParameter("@jiaoPian",SqlDbType.VarChar,100),
                                        new SqlParameter("@pingBi",SqlDbType.VarChar,100),
                                        new SqlParameter("@wenYaGuan",SqlDbType.VarChar,100),
                                        new SqlParameter("@dianZu",SqlDbType.VarChar,100),
                                        new SqlParameter("@luoSi",SqlDbType.VarChar,100),
                                        new SqlParameter("@reSuoTaoGuan",SqlDbType.VarChar,100),
                                        new SqlParameter("@anZhuangPJ",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian1",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian2",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian3",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian4",SqlDbType.VarChar,100),

                                       new SqlParameter("@gujiaCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@gujiaCount",SqlDbType.Decimal),
                                        new SqlParameter("@tongpaiCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@tongpaoCount",SqlDbType.Decimal),
                                        new SqlParameter("@cihuanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@cihuanCount",SqlDbType.Decimal),
                                        new SqlParameter("@duanziCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@duanziCount",SqlDbType.Decimal),
                                        new SqlParameter("@xianlubanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@xianlubanCount",SqlDbType.Decimal),
                                        new SqlParameter("@jiaopianCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@jiaopianCount",SqlDbType.Decimal),
                                        new SqlParameter("@pingbiCanshu",SqlDbType.VarChar,500),
                                       new SqlParameter("@pingbiCount",SqlDbType.Decimal),
                                        new SqlParameter("@wenyaguanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@wenyaguanCount",SqlDbType.Decimal),
                                        new SqlParameter("@dianzuCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@dianzuCount",SqlDbType.Decimal),
                                        new SqlParameter("@luosiCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@luosiCount",SqlDbType.Decimal),
                                       new SqlParameter("@resuotaoguanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@resuotaoguanCount",SqlDbType.Int,4),
                                        new SqlParameter("@anzhuangPJCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@anzhuangPJCount",SqlDbType.Decimal),
                                        new SqlParameter("@yuanqijian1Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian1Count",SqlDbType.Decimal),
                                        new SqlParameter("@Yuanqijian2Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian2Count",SqlDbType.Decimal),
                                        new SqlParameter("@Yuanqijian3Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian3Count",SqlDbType.Decimal),
                                        new SqlParameter("@Yuanqijian4Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian4Count",SqlDbType.Decimal)
        };
            parameters[0].Value = model.productName;
            parameters[1].Value = model.productNum;
            parameters[2].Value = model.waiBZ;
            parameters[3].Value = model.NeiBZ;
            parameters[4].Value = model.NeiBZDW;
            parameters[5].Value = model.bian;
            parameters[6].Value = model.jingDu;
            parameters[7].Value = model.xianXingdu;
            parameters[8].Value = model.eDingJC;
            parameters[9].Value = model.tieXiCount;
            parameters[10].Value = model.guiGe;
            parameters[11].Value = model.caiLiao;
            parameters[12].Value = model.xingNeng;
            parameters[13].Value = model.chuLiMethod;
            parameters[14].Value = model.baoHeDian;
            parameters[15].Value = model.xianQuanCount;
            parameters[16].Value = model.chujZaShu;
            parameters[17].Value = model.chujXianJing;
            parameters[18].Value = model.chujRaoXianZD;
            parameters[19].Value = model.chujXianTouCD;
            parameters[20].Value = model.chujXiantouCL;
            parameters[21].Value = model.chujTongMD;
            parameters[22].Value = model.cijZaShu;
            parameters[23].Value = model.cijXianJing;
            parameters[24].Value = model.cijRaoXianZD;
            parameters[25].Value = model.cijXianTouCD;
            parameters[26].Value = model.cijXianTouCL;
            parameters[27].Value = model.cijTongMD;
            parameters[28].Value = model.xqjcyqEquip;
            parameters[29].Value = model.xqjcyqShuRuState;
            parameters[30].Value = model.xqjcyqShuChuState;
            parameters[31].Value = model.xqjcyqJiaoCha;
            parameters[32].Value = model.xqjcyqFuZai;
            parameters[33].Value = model.biaoShiNo;
            parameters[34].Value = model.waiKeNo;
            parameters[35].Value = model.waiKeCount;
            parameters[36].Value = model.yongJiaoCS;
            parameters[37].Value = model.shuRu;
            parameters[38].Value = model.shuChu;
            parameters[39].Value = model.biaoShiAddress;
            parameters[40].Value = model.chajianNo;
            parameters[41].Value = model.chajianCount;
            parameters[42].Value = model.waiXingTZ??"";
            parameters[43].Value = model.cpjccsEquip;
            parameters[44].Value = model.cpjccsShuRuState;
            parameters[45].Value = model.cpjccsShuChuState;
            parameters[46].Value = model.CpjccsJiaoChaBH;
            parameters[47].Value = model.cpjccsFuZai;
            parameters[48].Value = model.cpjccsNaiYa;
            parameters[49].Value = model.cpjccsTongMD;
            parameters[50].Value = model.guanJiaoZhenLX;
            parameters[51].Value = model.guanJIaoZhenLXCount;
            parameters[52].Value = model.guanJiaoZhenLXTOW;
            parameters[53].Value = model.guanJiaoZhenLXTOWCount;
            parameters[54].Value = model.shuRuXC;
            parameters[55].Value = model.shuChuXC;
            parameters[56].Value = model.peiXianSR;
            parameters[57].Value = model.peiXianSRCount;
            parameters[58].Value = model.peiXianSC;
            parameters[59].Value = model.peiXianSCCount;
            parameters[60].Value = model.remark;
            parameters[61].Value = model.isModifyTZ;
            parameters[62].Value = model.biaoShiPicture;
            parameters[63].Value = model.IsModifyWaikeNo;
            parameters[64].Value = model.GongyiZYSX;


            parameters[65].Value = model.BaoZhuangHeGG;
            parameters[66].Value = model.BaoZhuangXiangGG;
            parameters[67].Value = model.BaoHeDianTestTJ;
            parameters[68].Value = model.GuJia;
            parameters[69].Value = model.TongPai;
            parameters[70].Value = model.CiHuan;
            parameters[71].Value = model.DuanZi;
            parameters[72].Value = model.XianLuBan;
            parameters[73].Value = model.JiaoPian;
            parameters[74].Value = model.PingBi;
            parameters[75].Value = model.WenYaGuan;
            parameters[76].Value = model.DianZu;
            parameters[77].Value = model.LuoSi;
            parameters[78].Value = model.ReSuoTaoGuan;
            parameters[79].Value = model.AnZhuangPJ;
            parameters[80].Value = model.YuanQiJian1;
            parameters[81].Value = model.YuanQiJian2;
            parameters[82].Value = model.YuanQiJian3;
            parameters[83].Value = model.YuanQiJian4;

            parameters[84].Value = model.GujiaCanshu;
            parameters[85].Value = model.GujiaCount;
            parameters[86].Value = model.TongpaiCanshu;
            parameters[87].Value = model.TongpaoCount;
            parameters[88].Value = model.CihuanCanshu;
            parameters[89].Value = model.CihuanCount;
            parameters[90].Value = model.DuanziCanshu;
            parameters[91].Value = model.DuanziCount;
            parameters[92].Value = model.XianlubanCanshu;
            parameters[93].Value = model.XianlubanCount;
            parameters[94].Value = model.JiaopianCanshu;
            parameters[95].Value = model.JiaopianCount;
            parameters[96].Value = model.PingbiCanshu;
            parameters[97].Value = model.PingbiCount;
            parameters[98].Value = model.WenyaguanCanshu;
            parameters[99].Value = model.WenyaguanCount;
            parameters[100].Value = model.DianzuCanshu;
            parameters[101].Value = model.DianzuCount;
            parameters[102].Value = model.LuosiCanshu;
            parameters[103].Value = model.LuosiCount;
            parameters[104].Value = model.ResuotaoguanCanshu;
            parameters[105].Value = model.ResuotaoguanCount;
            parameters[106].Value = model.AnzhuangPJCanshu;
            parameters[107].Value = model.AnzhuangPJCount;
            parameters[108].Value = model.Yuanqijian1Canshu;
            parameters[109].Value = model.Yuanqijian1Count1;
            parameters[110].Value = model.Yuanqijian2Canshu1;
            parameters[111].Value = model.Yuanqijian2Count1;
            parameters[112].Value = model.Yuanqijian3Canshu1;
            parameters[113].Value = model.Yuanqijian3Count1;
            parameters[114].Value = model.Yuanqijian4Canshu1;
            parameters[115].Value = model.Yuanqijian4Count1;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(OrderPrintSystem.Model.ProductsMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update products set ");
            strSql.Append("productName=@productName,");
            strSql.Append("productNum=@productNum,");
            strSql.Append("waiBZ=@waiBZ,");
            strSql.Append("NeiBZ=@NeiBZ,");
            strSql.Append("NeiBZDW=@NeiBZDW,");
            strSql.Append("bian=@bian,");
            strSql.Append("jingDu=@jingDu,");
            strSql.Append("xianXingdu=@xianXingdu,");
            strSql.Append("eDingJC=@eDingJC,");
            strSql.Append("tieXiCount=@tieXiCount,");
            strSql.Append("guiGe=@guiGe,");
            strSql.Append("caiLiao=@caiLiao,");
            strSql.Append("xingNeng=@xingNeng,");
            strSql.Append("chuLiMethod=@chuLiMethod,");
            strSql.Append("baoHeDian=@baoHeDian,");
            strSql.Append("xianQuanCount=@xianQuanCount,");
            strSql.Append("chujZaShu=@chujZaShu,");
            strSql.Append("chujXianJing=@chujXianJing,");
            strSql.Append("chujRaoXianZD=@chujRaoXianZD,");
            strSql.Append("chujXianTouCD=@chujXianTouCD,");
            strSql.Append("chujXiantouCL=@chujXiantouCL,");
            strSql.Append("chujTongMD=@chujTongMD,");
            strSql.Append("cijZaShu=@cijZaShu,");
            strSql.Append("cijXianJing=@cijXianJing,");
            strSql.Append("cijRaoXianZD=@cijRaoXianZD,");
            strSql.Append("cijXianTouCD=@cijXianTouCD,");
            strSql.Append("cijXianTouCL=@cijXianTouCL,");
            strSql.Append("cijTongMD=@cijTongMD,");
            strSql.Append("xqjcyqEquip=@xqjcyqEquip,");
            strSql.Append("xqjcyqShuRuState=@xqjcyqShuRuState,");
            strSql.Append("xqjcyqShuChuState=@xqjcyqShuChuState,");
            strSql.Append("xqjcyqJiaoCha=@xqjcyqJiaoCha,");
            strSql.Append("xqjcyqFuZai=@xqjcyqFuZai,");
            strSql.Append("biaoShiNo=@biaoShiNo,");
            strSql.Append("waiKeNo=@waiKeNo,");
            strSql.Append("waiKeCount=@waiKeCount,");
            strSql.Append("yongJiaoCS=@yongJiaoCS,");
            strSql.Append("shuRu=@shuRu,");
            strSql.Append("shuChu=@shuChu,");
            strSql.Append("biaoShiAddress=@biaoShiAddress,");
            strSql.Append("chajianNo=@chajianNo,");
            strSql.Append("chajianCount=@chajianCount,");
            strSql.Append("waiXingTZ=@waiXingTZ,");
            strSql.Append("cpjccsEquip=@cpjccsEquip,");
            strSql.Append("cpjccsShuRuState=@cpjccsShuRuState,");
            strSql.Append("cpjccsShuChuState=@cpjccsShuChuState,");
            strSql.Append("CpjccsJiaoChaBH=@CpjccsJiaoChaBH,");
            strSql.Append("cpjccsFuZai=@cpjccsFuZai,");
            strSql.Append("cpjccsNaiYa=@cpjccsNaiYa,");
            strSql.Append("cpjccsTongMD=@cpjccsTongMD,");
            strSql.Append("guanJiaoZhenLX=@guanJiaoZhenLX,");
            strSql.Append("guanJIaoZhenLXCount=@guanJIaoZhenLXCount,");
            strSql.Append("guanJiaoZhenLXTOW=@guanJiaoZhenLXTOW,");
            strSql.Append("guanJiaoZhenLXTOWCount=@guanJiaoZhenLXTOWCount,");
            strSql.Append("shuRuXC=@shuRuXC,");
            strSql.Append("shuChuXC=@shuChuXC,");
            strSql.Append("peiXianSR=@peiXianSR,");
            strSql.Append("peiXianSRCount=@peiXianSRCount,");
            strSql.Append("peiXianSC=@peiXianSC,");
            strSql.Append("peiXianSCCount=@peiXianSCCount,");
            strSql.Append("remark=@remark,");
            strSql.Append("isModifyTZ=@isModifyTZ,");
            strSql.Append("biaoShiPicture=@biaoShiPicture,");
            strSql.Append("IsModifyWaikeNo=@IsModifyWaikeNo,");
            strSql.Append("GongyiZYSX=@GongyiZYSX,");
            strSql.Append("baoZhuangHeGG=@baoZhuangHeGG,");
            strSql.Append("baoZhuangXiangGG=@baoZhuangXiangGG,");
            strSql.Append("baoHeDianTestTJ=@baoHeDianTestTJ,");
            strSql.Append("guJia=@guJia,");
            strSql.Append("tongPai=@tongPai,");
            strSql.Append("ciHuan=@ciHuan,");
            strSql.Append("duanZi=@duanZi,");
            strSql.Append("xianLuBan=@xianLuBan,");
            strSql.Append("jiaoPian=@jiaoPian,");
            strSql.Append("pingBi=@pingBi,");
            strSql.Append("wenYaGuan=@wenYaGuan,");
            strSql.Append("dianZu=@dianZu,");
            strSql.Append("luoSi=@luoSi,");
            strSql.Append("reSuoTaoGuan=@reSuoTaoGuan,");
            strSql.Append("anZhuangPJ=@anZhuangPJ,");
            strSql.Append("yuanQiJian1=@yuanQiJian1,");
            strSql.Append("yuanQiJian2=@yuanQiJian2,");
            strSql.Append("yuanQiJian3=@yuanQiJian3,");
            strSql.Append("yuanQiJian4=@yuanQiJian4,");
            strSql.Append("gujiaCanshu=@gujiaCanshu,");
            strSql.Append("gujiaCount=@gujiaCount,");
            strSql.Append("tongpaiCanshu=@tongpaiCanshu,");
            strSql.Append("tongpaoCount=@tongpaoCount,");
            strSql.Append("cihuanCanshu=@cihuanCanshu,");
            strSql.Append("cihuanCount=@cihuanCount,");
            strSql.Append("duanziCanshu=@duanziCanshu,");
            strSql.Append("duanziCount=@duanziCount,");
            strSql.Append("xianlubanCanshu=@xianlubanCanshu,");
            strSql.Append("xianlubanCount=@xianlubanCount,");
            strSql.Append("jiaopianCanshu=@jiaopianCanshu,");
            strSql.Append("jiaopianCount=@jiaopianCount,");
            strSql.Append("pingbiCanshu=@pingbiCanshu,");
            strSql.Append("pingbiCount=@pingbiCount,");
            strSql.Append("wenyaguanCanshu=@wenyaguanCanshu,");
            strSql.Append("wenyaguanCount=@wenyaguanCount,");
            strSql.Append("dianzuCanshu=@dianzuCanshu,");
            strSql.Append("dianzuCount=@dianzuCount,");
            strSql.Append("luosiCanshu=@luosiCanshu,");
            strSql.Append("luosiCount=@luosiCount,");
            strSql.Append("resuotaoguanCanshu=@resuotaoguanCanshu,");
            strSql.Append("resuotaoguanCount=@resuotaoguanCount,");
            strSql.Append("anzhuangPJCanshu=@anzhuangPJCanshu,");
            strSql.Append("anzhuangPJCount=@anzhuangPJCount,");
            strSql.Append("yuanqijian1Canshu=@yuanqijian1Canshu,");
            strSql.Append("Yuanqijian1Count=@Yuanqijian1Count,");
            strSql.Append("Yuanqijian2Canshu=@Yuanqijian2Canshu,");
            strSql.Append("Yuanqijian2Count=@Yuanqijian2Count,");
            strSql.Append("Yuanqijian3Canshu=@Yuanqijian3Canshu,");
            strSql.Append("Yuanqijian3Count=@Yuanqijian3Count,");
            strSql.Append("Yuanqijian4Canshu=@Yuanqijian4Canshu,");
            strSql.Append("Yuanqijian4Count=@Yuanqijian4Count");
            strSql.Append(" where productId=@productId");
            SqlParameter[] parameters = {
					new SqlParameter("@productName", SqlDbType.VarChar,500),
					new SqlParameter("@productNum", SqlDbType.VarChar,500),
					new SqlParameter("@waiBZ", SqlDbType.Int,4),
					new SqlParameter("@NeiBZ", SqlDbType.VarChar,500),
					new SqlParameter("@NeiBZDW", SqlDbType.VarChar,500),
					new SqlParameter("@bian", SqlDbType.VarChar,500),
					new SqlParameter("@jingDu", SqlDbType.VarChar,500),
					new SqlParameter("@xianXingdu", SqlDbType.VarChar,500),
					new SqlParameter("@eDingJC", SqlDbType.VarChar,500),
					new SqlParameter("@tieXiCount", SqlDbType.Int,4),
					new SqlParameter("@guiGe", SqlDbType.VarChar,500),
					new SqlParameter("@caiLiao", SqlDbType.VarChar,500),
					new SqlParameter("@xingNeng", SqlDbType.VarChar,500),
					new SqlParameter("@chuLiMethod", SqlDbType.VarChar,500),
					new SqlParameter("@baoHeDian", SqlDbType.VarChar,500),
					new SqlParameter("@xianQuanCount", SqlDbType.Int,4),
					new SqlParameter("@chujZaShu", SqlDbType.VarChar,500),
					new SqlParameter("@chujXianJing", SqlDbType.VarChar,500),
					new SqlParameter("@chujRaoXianZD", SqlDbType.VarChar,500),
					new SqlParameter("@chujXianTouCD", SqlDbType.VarChar,500),
					new SqlParameter("@chujXiantouCL", SqlDbType.VarChar,500),
					new SqlParameter("@chujTongMD", SqlDbType.VarChar,500),
					new SqlParameter("@cijZaShu", SqlDbType.VarChar,500),
					new SqlParameter("@cijXianJing", SqlDbType.VarChar,500),
					new SqlParameter("@cijRaoXianZD", SqlDbType.VarChar,500),
					new SqlParameter("@cijXianTouCD", SqlDbType.VarChar,500),
					new SqlParameter("@cijXianTouCL", SqlDbType.VarChar,500),
					new SqlParameter("@cijTongMD", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqEquip", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqShuRuState", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqShuChuState", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqJiaoCha", SqlDbType.VarChar,500),
					new SqlParameter("@xqjcyqFuZai", SqlDbType.VarChar,500),
					new SqlParameter("@biaoShiNo", SqlDbType.VarChar,500),
					new SqlParameter("@waiKeNo", SqlDbType.VarChar,500),
					new SqlParameter("@waiKeCount", SqlDbType.Int,4),
					new SqlParameter("@yongJiaoCS", SqlDbType.VarChar,500),
					new SqlParameter("@shuRu", SqlDbType.VarChar,500),
					new SqlParameter("@shuChu", SqlDbType.VarChar,500),
					new SqlParameter("@biaoShiAddress", SqlDbType.VarChar,500),
					new SqlParameter("@chajianNo", SqlDbType.VarChar,500),
					new SqlParameter("@chajianCount", SqlDbType.Int,4),
					new SqlParameter("@waiXingTZ", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsEquip", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsShuRuState", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsShuChuState", SqlDbType.VarChar,500),
					new SqlParameter("@CpjccsJiaoChaBH", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsFuZai", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsNaiYa", SqlDbType.VarChar,500),
					new SqlParameter("@cpjccsTongMD", SqlDbType.VarChar,500),
					new SqlParameter("@guanJiaoZhenLX", SqlDbType.VarChar,500),
					new SqlParameter("@guanJIaoZhenLXCount", SqlDbType.Int,4),
					new SqlParameter("@guanJiaoZhenLXTOW", SqlDbType.VarChar,500),
					new SqlParameter("@guanJiaoZhenLXTOWCount", SqlDbType.Int,4),
					new SqlParameter("@shuRuXC", SqlDbType.VarChar,500),
					new SqlParameter("@shuChuXC", SqlDbType.VarChar,500),
					new SqlParameter("@peiXianSR", SqlDbType.VarChar,500),
					new SqlParameter("@peiXianSRCount", SqlDbType.Decimal,9),
					new SqlParameter("@peiXianSC", SqlDbType.VarChar,500),
					new SqlParameter("@peiXianSCCount", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@isModifyTZ", SqlDbType.Int,4),
					new SqlParameter("@biaoShiPicture", SqlDbType.VarChar,500),
                    new SqlParameter("@IsModifyWaikeNo",SqlDbType.Int,4),
                    new SqlParameter("@GongyiZYSX",SqlDbType.VarChar,5000),
                     new SqlParameter("@baoZhuangHeGG",SqlDbType.VarChar,100),
                                        new SqlParameter("@baoZhuangXiangGG",SqlDbType.VarChar,100),
                                        new SqlParameter("@baoHeDianTestTJ",SqlDbType.VarChar,100),
                                        new SqlParameter("@guJia",SqlDbType.VarChar,100),
                                        new SqlParameter("@tongPai",SqlDbType.VarChar,100),
                                        new SqlParameter("@ciHuan",SqlDbType.VarChar,100),
                                        new SqlParameter("@duanZi",SqlDbType.VarChar,100),
                                        new SqlParameter("@xianLuBan",SqlDbType.VarChar,100),
                                        new SqlParameter("@jiaoPian",SqlDbType.VarChar,100),
                                        new SqlParameter("@pingBi",SqlDbType.VarChar,100),
                                        new SqlParameter("@wenYaGuan",SqlDbType.VarChar,100),
                                        new SqlParameter("@dianZu",SqlDbType.VarChar,100),
                                        new SqlParameter("@luoSi",SqlDbType.VarChar,100),
                                        new SqlParameter("@reSuoTaoGuan",SqlDbType.VarChar,100),
                                        new SqlParameter("@anZhuangPJ",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian1",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian2",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian3",SqlDbType.VarChar,100),
                                        new SqlParameter("@yuanQiJian4",SqlDbType.VarChar,100),
                                       new SqlParameter("@gujiaCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@gujiaCount",SqlDbType.Decimal),
                                        new SqlParameter("@tongpaiCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@tongpaoCount",SqlDbType.Decimal),
                                        new SqlParameter("@cihuanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@cihuanCount",SqlDbType.Decimal),
                                        new SqlParameter("@duanziCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@duanziCount",SqlDbType.Decimal),
                                        new SqlParameter("@xianlubanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@xianlubanCount",SqlDbType.Decimal),
                                        new SqlParameter("@jiaopianCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@jiaopianCount",SqlDbType.Decimal),
                                        new SqlParameter("@pingbiCanshu",SqlDbType.VarChar,500),
                                       new SqlParameter("@pingbiCount",SqlDbType.Decimal),
                                        new SqlParameter("@wenyaguanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@wenyaguanCount",SqlDbType.Decimal),
                                        new SqlParameter("@dianzuCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@dianzuCount",SqlDbType.Decimal),
                                        new SqlParameter("@luosiCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@luosiCount",SqlDbType.Decimal),
                                       new SqlParameter("@resuotaoguanCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@resuotaoguanCount",SqlDbType.Decimal),
                                        new SqlParameter("@anzhuangPJCanshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@anzhuangPJCount",SqlDbType.Decimal),
                                        new SqlParameter("@yuanqijian1Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian1Count",SqlDbType.Decimal),
                                        new SqlParameter("@Yuanqijian2Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian2Count",SqlDbType.Decimal),
                                        new SqlParameter("@Yuanqijian3Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian3Count",SqlDbType.Decimal),
                                        new SqlParameter("@Yuanqijian4Canshu",SqlDbType.VarChar,500),
                                        new SqlParameter("@Yuanqijian4Count",SqlDbType.Decimal),
					new SqlParameter("@productId", SqlDbType.Int,4)};
            parameters[0].Value = model.productName;
            parameters[1].Value = model.productNum;
            parameters[2].Value = model.waiBZ;
            parameters[3].Value = model.NeiBZ;
            parameters[4].Value = model.NeiBZDW;
            parameters[5].Value = model.bian;
            parameters[6].Value = model.jingDu;
            parameters[7].Value = model.xianXingdu;
            parameters[8].Value = model.eDingJC;
            parameters[9].Value = model.tieXiCount;
            parameters[10].Value = model.guiGe;
            parameters[11].Value = model.caiLiao;
            parameters[12].Value = model.xingNeng;
            parameters[13].Value = model.chuLiMethod;
            parameters[14].Value = model.baoHeDian;
            parameters[15].Value = model.xianQuanCount;
            parameters[16].Value = model.chujZaShu;
            parameters[17].Value = model.chujXianJing;
            parameters[18].Value = model.chujRaoXianZD;
            parameters[19].Value = model.chujXianTouCD;
            parameters[20].Value = model.chujXiantouCL;
            parameters[21].Value = model.chujTongMD;
            parameters[22].Value = model.cijZaShu;
            parameters[23].Value = model.cijXianJing;
            parameters[24].Value = model.cijRaoXianZD;
            parameters[25].Value = model.cijXianTouCD;
            parameters[26].Value = model.cijXianTouCL;
            parameters[27].Value = model.cijTongMD;
            parameters[28].Value = model.xqjcyqEquip;
            parameters[29].Value = model.xqjcyqShuRuState;
            parameters[30].Value = model.xqjcyqShuChuState;
            parameters[31].Value = model.xqjcyqJiaoCha;
            parameters[32].Value = model.xqjcyqFuZai;
            parameters[33].Value = model.biaoShiNo;
            parameters[34].Value = model.waiKeNo;
            parameters[35].Value = model.waiKeCount;
            parameters[36].Value = model.yongJiaoCS;
            parameters[37].Value = model.shuRu;
            parameters[38].Value = model.shuChu;
            parameters[39].Value = model.biaoShiAddress;
            parameters[40].Value = model.chajianNo;
            parameters[41].Value = model.chajianCount;
            parameters[42].Value = model.waiXingTZ;
            parameters[43].Value = model.cpjccsEquip;
            parameters[44].Value = model.cpjccsShuRuState;
            parameters[45].Value = model.cpjccsShuChuState;
            parameters[46].Value = model.CpjccsJiaoChaBH;
            parameters[47].Value = model.cpjccsFuZai;
            parameters[48].Value = model.cpjccsNaiYa;
            parameters[49].Value = model.cpjccsTongMD;
            parameters[50].Value = model.guanJiaoZhenLX;
            parameters[51].Value = model.guanJIaoZhenLXCount;
            parameters[52].Value = model.guanJiaoZhenLXTOW;
            parameters[53].Value = model.guanJiaoZhenLXTOWCount;
            parameters[54].Value = model.shuRuXC;
            parameters[55].Value = model.shuChuXC;
            parameters[56].Value = model.peiXianSR;
            parameters[57].Value = model.peiXianSRCount;
            parameters[58].Value = model.peiXianSC;
            parameters[59].Value = model.peiXianSCCount;
            parameters[60].Value = model.remark;
            parameters[61].Value = model.isModifyTZ;
            parameters[62].Value = model.biaoShiPicture;
            parameters[63].Value = model.IsModifyWaikeNo;
            parameters[64].Value = model.GongyiZYSX;
            parameters[65].Value = model.BaoZhuangHeGG;
            parameters[66].Value = model.BaoZhuangXiangGG;
            parameters[67].Value = model.BaoHeDianTestTJ;
            parameters[68].Value = model.GuJia;
            parameters[69].Value = model.TongPai;
            parameters[70].Value = model.CiHuan;
            parameters[71].Value = model.DuanZi;
            parameters[72].Value = model.XianLuBan;
            parameters[73].Value = model.JiaoPian;
            parameters[74].Value = model.PingBi;
            parameters[75].Value = model.WenYaGuan;
            parameters[76].Value = model.DianZu;
            parameters[77].Value = model.LuoSi;
            parameters[78].Value = model.ReSuoTaoGuan;
            parameters[79].Value = model.AnZhuangPJ;
            parameters[80].Value = model.YuanQiJian1;
            parameters[81].Value = model.YuanQiJian2;
            parameters[82].Value = model.YuanQiJian3;
            parameters[83].Value = model.YuanQiJian4;
            parameters[84].Value = model.GujiaCanshu;
            parameters[85].Value = model.GujiaCount;
            parameters[86].Value = model.TongpaiCanshu;
            parameters[87].Value = model.TongpaoCount;
            parameters[88].Value = model.CihuanCanshu;
            parameters[89].Value = model.CihuanCount;
            parameters[90].Value = model.DuanziCanshu;
            parameters[91].Value = model.DuanziCount;
            parameters[92].Value = model.XianlubanCanshu;
            parameters[93].Value = model.XianlubanCount;
            parameters[94].Value = model.JiaopianCanshu;
            parameters[95].Value = model.JiaopianCount;
            parameters[96].Value = model.PingbiCanshu;
            parameters[97].Value = model.PingbiCount;
            parameters[98].Value = model.WenyaguanCanshu;
            parameters[99].Value = model.WenyaguanCount;
            parameters[100].Value = model.DianzuCanshu;
            parameters[101].Value = model.DianzuCount;
            parameters[102].Value = model.LuosiCanshu;
            parameters[103].Value = model.LuosiCount;
            parameters[104].Value = model.ResuotaoguanCanshu;
            parameters[105].Value = model.ResuotaoguanCount;
            parameters[106].Value = model.AnzhuangPJCanshu;
            parameters[107].Value = model.AnzhuangPJCount;
            parameters[108].Value = model.Yuanqijian1Canshu;
            parameters[109].Value = model.Yuanqijian1Count1;
            parameters[110].Value = model.Yuanqijian2Canshu1;
            parameters[111].Value = model.Yuanqijian2Count1;
            parameters[112].Value = model.Yuanqijian3Canshu1;
            parameters[113].Value = model.Yuanqijian3Count1;
            parameters[114].Value = model.Yuanqijian4Canshu1;
            parameters[115].Value = model.Yuanqijian4Count1;
            parameters[116].Value = model.productId;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(string productNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update products set ");
            strSql.Append("isModifyTZ=@isModifyTZ,");
            strSql.Append("IsModifyWaikeNo=@IsModifyWaikeNo");
            strSql.Append(" where productNum=@productNum");
            SqlParameter[] parameters = {
					new SqlParameter("@isModifyTZ", SqlDbType.Int,4),
                    new SqlParameter("@IsModifyWaikeNo",SqlDbType.Int,4),
					new SqlParameter("@productNum", SqlDbType.VarChar,100)};
            parameters[0].Value = 0;
            parameters[1].Value = 0;
            parameters[2].Value = productNum;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static int Delete(int productId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from products ");
            strSql.Append(" where productId=@productId");
            SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static int DeleteList(string productIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from products ");
            strSql.Append(" where productId in (" + productIdlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProductsMOD GetModel(int productId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  top 1 productId,productName,productNum,waiBZ,NeiBZ,NeiBZDW,bian,jingDu,xianXingdu,eDingJC,tieXiCount,guiGe,caiLiao,xingNeng,chuLiMethod,baoHeDian,xianQuanCount,chujZaShu,chujXianJing,chujRaoXianZD,chujXianTouCD,chujXiantouCL,chujTongMD,cijZaShu,cijXianJing,cijRaoXianZD,cijXianTouCD,cijXianTouCL,cijTongMD,xqjcyqEquip,xqjcyqShuRuState,xqjcyqShuChuState,xqjcyqJiaoCha,xqjcyqFuZai,biaoShiNo,waiKeNo,waiKeCount,yongJiaoCS,shuRu,shuChu,biaoShiAddress,chajianNo,chajianCount,waiXingTZ,cpjccsEquip,cpjccsShuRuState,cpjccsShuChuState,CpjccsJiaoChaBH,cpjccsFuZai,cpjccsNaiYa,cpjccsTongMD,guanJiaoZhenLX,guanJIaoZhenLXCount,guanJiaoZhenLXTOW,guanJiaoZhenLXTOWCount,shuRuXC,shuChuXC,peiXianSR,peiXianSRCount,peiXianSC,peiXianSCCount,remark,isModifyTZ,biaoShiPicture,IsModifyWaikeNo,GongyiZYSX,baoZhuangHeGG,
baoZhuangXiangGG,
baoHeDianTestTJ,
guJia,
tongPai,
ciHuan,
duanZi,
xianLuBan,
jiaoPian,
pingBi,
wenYaGuan,
dianZu,
luoSi,
reSuoTaoGuan,
anZhuangPJ,
yuanQiJian1,
yuanQiJian2,
yuanQiJian3,
yuanQiJian4,gujiaCanshu,
gujiaCount,
tongpaiCanshu,
tongpaoCount,
cihuanCanshu,
cihuanCount,
duanziCanshu,
duanziCount,
xianlubanCanshu,
xianlubanCount,
jiaopianCanshu,
jiaopianCount,
pingbiCanshu,
pingbiCount,
wenyaguanCanshu,
wenyaguanCount,
dianzuCanshu,
dianzuCount,
luosiCanshu,
luosiCount,
resuotaoguanCanshu,
resuotaoguanCount,
anzhuangPJCanshu,
anzhuangPJCount,
yuanqijian1Canshu,
Yuanqijian1Count,
Yuanqijian2Canshu,
Yuanqijian2Count,
Yuanqijian3Canshu,
Yuanqijian3Count,
Yuanqijian4Canshu,
Yuanqijian4Count from products ");
            strSql.Append(" where productId=" + productId);
            
            OrderPrintSystem.Model.ProductsMOD model = new OrderPrintSystem.Model.ProductsMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["productId"] != null && reader["productId"].ToString() != "")
                {
                    model.productId = int.Parse(reader["productId"].ToString());
                }
                if (reader["productName"] != null)
                {
                    model.productName = reader["productName"].ToString();
                }
                if (reader["productNum"] != null)
                {
                    model.productNum = reader["productNum"].ToString();
                }
                if (reader["waiBZ"] != null && reader["waiBZ"].ToString() != "")
                {
                    model.waiBZ = int.Parse(reader["waiBZ"].ToString());
                }
                if (reader["NeiBZ"] != null)
                {
                    model.NeiBZ = reader["NeiBZ"].ToString();
                }
                if (reader["NeiBZDW"] != null)
                {
                    model.NeiBZDW = reader["NeiBZDW"].ToString();
                }
                if (reader["bian"] != null)
                {
                    model.bian = reader["bian"].ToString();
                }
                if (reader["jingDu"] != null)
                {
                    model.jingDu = reader["jingDu"].ToString();
                }
                if (reader["xianXingdu"] != null)
                {
                    model.xianXingdu = reader["xianXingdu"].ToString();
                }
                if (reader["eDingJC"] != null)
                {
                    model.eDingJC = reader["eDingJC"].ToString();
                }
                if (reader["tieXiCount"] != null && reader["tieXiCount"].ToString() != "")
                {
                    model.tieXiCount = int.Parse(reader["tieXiCount"].ToString());
                }
                if (reader["guiGe"] != null)
                {
                    model.guiGe = reader["guiGe"].ToString();
                }
                if (reader["caiLiao"] != null)
                {
                    model.caiLiao = reader["caiLiao"].ToString();
                }
                if (reader["xingNeng"] != null)
                {
                    model.xingNeng = reader["xingNeng"].ToString();
                }
                if (reader["chuLiMethod"] != null)
                {
                    model.chuLiMethod = reader["chuLiMethod"].ToString();
                }
                if (reader["baoHeDian"] != null)
                {
                    model.baoHeDian = reader["baoHeDian"].ToString();
                }
                if (reader["xianQuanCount"] != null && reader["xianQuanCount"].ToString() != "")
                {
                    model.xianQuanCount = int.Parse(reader["xianQuanCount"].ToString());
                }
                if (reader["chujZaShu"] != null)
                {
                    model.chujZaShu = reader["chujZaShu"].ToString();
                }
                if (reader["chujXianJing"] != null)
                {
                    model.chujXianJing = reader["chujXianJing"].ToString();
                }
                if (reader["chujRaoXianZD"] != null)
                {
                    model.chujRaoXianZD = reader["chujRaoXianZD"].ToString();
                }
                if (reader["chujXianTouCD"] != null)
                {
                    model.chujXianTouCD = reader["chujXianTouCD"].ToString();
                }
                if (reader["chujXiantouCL"] != null)
                {
                    model.chujXiantouCL = reader["chujXiantouCL"].ToString();
                }
                if (reader["chujTongMD"] != null)
                {
                    model.chujTongMD = reader["chujTongMD"].ToString();
                }
                if (reader["cijZaShu"] != null)
                {
                    model.cijZaShu = reader["cijZaShu"].ToString();
                }
                if (reader["cijXianJing"] != null)
                {
                    model.cijXianJing = reader["cijXianJing"].ToString();
                }
                if (reader["cijRaoXianZD"] != null)
                {
                    model.cijRaoXianZD = reader["cijRaoXianZD"].ToString();
                }
                if (reader["cijXianTouCD"] != null)
                {
                    model.cijXianTouCD = reader["cijXianTouCD"].ToString();
                }
                if (reader["cijXianTouCL"] != null)
                {
                    model.cijXianTouCL = reader["cijXianTouCL"].ToString();
                }
                if (reader["cijTongMD"] != null)
                {
                    model.cijTongMD = reader["cijTongMD"].ToString();
                }
                if (reader["xqjcyqEquip"] != null)
                {
                    model.xqjcyqEquip = reader["xqjcyqEquip"].ToString();
                }
                if (reader["xqjcyqShuRuState"] != null)
                {
                    model.xqjcyqShuRuState = reader["xqjcyqShuRuState"].ToString();
                }
                if (reader["xqjcyqShuChuState"] != null)
                {
                    model.xqjcyqShuChuState = reader["xqjcyqShuChuState"].ToString();
                }
                if (reader["xqjcyqJiaoCha"] != null)
                {
                    model.xqjcyqJiaoCha = reader["xqjcyqJiaoCha"].ToString();
                }
                if (reader["xqjcyqFuZai"] != null)
                {
                    model.xqjcyqFuZai = reader["xqjcyqFuZai"].ToString();
                }
                if (reader["biaoShiNo"] != null)
                {
                    model.biaoShiNo = reader["biaoShiNo"].ToString();
                }
                if (reader["waiKeNo"] != null)
                {
                    model.waiKeNo = reader["waiKeNo"].ToString();
                }
                if (reader["waiKeCount"] != null && reader["waiKeCount"].ToString() != "")
                {
                    model.waiKeCount = int.Parse(reader["waiKeCount"].ToString());
                }
                if (reader["yongJiaoCS"] != null)
                {
                    model.yongJiaoCS = reader["yongJiaoCS"].ToString();
                }
                if (reader["shuRu"] != null)
                {
                    model.shuRu = reader["shuRu"].ToString();
                }
                if (reader["shuChu"] != null)
                {
                    model.shuChu = reader["shuChu"].ToString();
                }
                if (reader["biaoShiAddress"] != null)
                {
                    model.biaoShiAddress = reader["biaoShiAddress"].ToString();
                }
                if (reader["chajianNo"] != null)
                {
                    model.chajianNo = reader["chajianNo"].ToString();
                }
                if (reader["chajianCount"] != null && reader["chajianCount"].ToString() != "")
                {
                    model.chajianCount = int.Parse(reader["chajianCount"].ToString());
                }
                if (reader["waiXingTZ"] != null)
                {
                    model.waiXingTZ = reader["waiXingTZ"].ToString();
                }
                if (reader["cpjccsEquip"] != null)
                {
                    model.cpjccsEquip = reader["cpjccsEquip"].ToString();
                }
                if (reader["cpjccsShuRuState"] != null)
                {
                    model.cpjccsShuRuState = reader["cpjccsShuRuState"].ToString();
                }
                if (reader["cpjccsShuChuState"] != null)
                {
                    model.cpjccsShuChuState = reader["cpjccsShuChuState"].ToString();
                }
                if (reader["CpjccsJiaoChaBH"] != null)
                {
                    model.CpjccsJiaoChaBH = reader["CpjccsJiaoChaBH"].ToString();
                }
                if (reader["cpjccsFuZai"] != null)
                {
                    model.cpjccsFuZai = reader["cpjccsFuZai"].ToString();
                }
                if (reader["cpjccsNaiYa"] != null)
                {
                    model.cpjccsNaiYa = reader["cpjccsNaiYa"].ToString();
                }
                if (reader["cpjccsTongMD"] != null)
                {
                    model.cpjccsTongMD = reader["cpjccsTongMD"].ToString();
                }
                if (reader["guanJiaoZhenLX"] != null)
                {
                    model.guanJiaoZhenLX = reader["guanJiaoZhenLX"].ToString();
                }
                if (reader["guanJIaoZhenLXCount"] != null && reader["guanJIaoZhenLXCount"].ToString() != "")
                {
                    model.guanJIaoZhenLXCount = int.Parse(reader["guanJIaoZhenLXCount"].ToString());
                }
                if (reader["guanJiaoZhenLXTOW"] != null)
                {
                    model.guanJiaoZhenLXTOW = reader["guanJiaoZhenLXTOW"].ToString();
                }
                if (reader["guanJiaoZhenLXTOWCount"] != null && reader["guanJiaoZhenLXTOWCount"].ToString() != "")
                {
                    model.guanJiaoZhenLXTOWCount = int.Parse(reader["guanJiaoZhenLXTOWCount"].ToString());
                }
                if (reader["shuRuXC"] != null)
                {
                    model.shuRuXC = reader["shuRuXC"].ToString();
                }
                if (reader["shuChuXC"] != null)
                {
                    model.shuChuXC = reader["shuChuXC"].ToString();
                }
                if (reader["peiXianSR"] != null)
                {
                    model.peiXianSR = reader["peiXianSR"].ToString();
                }
                if (reader["peiXianSRCount"] != null && reader["peiXianSRCount"].ToString() != "")
                {
                    model.peiXianSRCount = decimal.Parse(reader["peiXianSRCount"].ToString());
                }
                if (reader["peiXianSC"] != null)
                {
                    model.peiXianSC = reader["peiXianSC"].ToString();
                }
                if (reader["peiXianSCCount"] != null && reader["peiXianSCCount"].ToString() != "")
                {
                    model.peiXianSCCount = decimal.Parse(reader["peiXianSCCount"].ToString());
                }
                if (reader["remark"] != null)
                {
                    model.remark = reader["remark"].ToString();
                }
                if (reader["isModifyTZ"] != null && reader["isModifyTZ"].ToString() != "")
                {
                    model.isModifyTZ = int.Parse(reader["isModifyTZ"].ToString());
                }
                if (reader["biaoShiPicture"] != null)
                {
                    model.biaoShiPicture = reader["biaoShiPicture"].ToString();
                }
                model.GongyiZYSX = reader["GongyiZYSX"].ToString();
                model.BaoZhuangHeGG = reader["baoZhuangHeGG"].ToString();
                model.BaoZhuangXiangGG = reader["baoZhuangXiangGG"].ToString();
                model.BaoHeDianTestTJ = reader["baoHeDianTestTJ"].ToString();
                model.GuJia = reader["guJia"].ToString();
                model.TongPai = reader["tongPai"].ToString();
                model.CiHuan = reader["ciHuan"].ToString();
                model.DuanZi = reader["duanZi"].ToString();
                model.XianLuBan = reader["xianLuBan"].ToString();
                model.JiaoPian = reader["jiaoPian"].ToString();
                model.PingBi = reader["pingBi"].ToString();
                model.WenYaGuan = reader["wenYaGuan"].ToString();
                model.DianZu = reader["dianZu"].ToString();
                model.LuoSi = reader["luoSi"].ToString();
                model.ReSuoTaoGuan = reader["reSuoTaoGuan"].ToString();
                model.AnZhuangPJ = reader["anZhuangPJ"].ToString();
                model.YuanQiJian1 = reader["yuanQiJian1"].ToString();
                model.YuanQiJian2 = reader["yuanQiJian2"].ToString();
                model.YuanQiJian3 = reader["yuanQiJian3"].ToString();
                model.YuanQiJian4 = reader["yuanQiJian4"].ToString();
                model.GujiaCanshu = reader["gujiaCanshu"].ToString();
                if (reader["gujiaCount"] != null && reader["gujiaCount"].ToString() != "")
                {
                    model.GujiaCount = Convert.ToDecimal(reader["gujiaCount"].ToString());
                }
                if (reader["tongpaoCount"] != null && reader["tongpaoCount"].ToString() != "")
                {
                    model.TongpaoCount = Convert.ToDecimal(reader["tongpaoCount"].ToString());
                }
                if (reader["cihuanCount"] != null && reader["cihuanCount"].ToString() != "")
                {
                    model.CihuanCount = Convert.ToDecimal(reader["cihuanCount"].ToString());
                }
                if (reader["duanziCount"] != null && reader["duanziCount"].ToString() != "")
                {
                    model.DuanziCount = Convert.ToDecimal(reader["duanziCount"].ToString());
                }
                if (reader["xianlubanCount"] != null && reader["xianlubanCount"].ToString() != "")
                {
                    model.XianlubanCount = Convert.ToDecimal(reader["xianlubanCount"].ToString());
                }
                if (reader["jiaopianCount"] != null && reader["jiaopianCount"].ToString() != "")
                {
                    model.JiaopianCount = Convert.ToDecimal(reader["jiaopianCount"].ToString());
                }
                if (reader["pingbiCount"] != null && reader["pingbiCount"].ToString() != "")
                {
                    model.PingbiCount = Convert.ToDecimal(reader["pingbiCount"].ToString());
                }
                if (reader["wenyaguanCount"] != null && reader["wenyaguanCount"].ToString() != "")
                {
                    model.WenyaguanCount = Convert.ToDecimal(reader["wenyaguanCount"].ToString());
                }
                if (reader["dianzuCount"] != null && reader["dianzuCount"].ToString() != "")
                {
                    model.DianzuCount = Convert.ToDecimal(reader["dianzuCount"].ToString());
                } if (reader["luosiCount"] != null && reader["luosiCount"].ToString() != "")
                {
                    model.LuosiCount = Convert.ToDecimal(reader["luosiCount"].ToString());
                } if (reader["resuotaoguanCount"] != null && reader["resuotaoguanCount"].ToString() != "")
                {
                    model.ResuotaoguanCount = Convert.ToDecimal(reader["resuotaoguanCount"].ToString());
                } if (reader["anzhuangPJCount"] != null && reader["anzhuangPJCount"].ToString() != "")
                {
                    model.AnzhuangPJCount = Convert.ToDecimal(reader["anzhuangPJCount"].ToString());
                } if (reader["Yuanqijian1Count"] != null && reader["Yuanqijian1Count"].ToString() != "")
                {
                    model.Yuanqijian1Count1 = Convert.ToDecimal(reader["Yuanqijian1Count"].ToString());
                } if (reader["Yuanqijian2Count"] != null && reader["Yuanqijian2Count"].ToString() != "")
                {
                    model.Yuanqijian2Count1 = Convert.ToDecimal(reader["Yuanqijian2Count"].ToString());
                } if (reader["Yuanqijian3Count"] != null && reader["Yuanqijian3Count"].ToString() != "")
                {
                    model.Yuanqijian3Count1 = Convert.ToDecimal(reader["Yuanqijian3Count"].ToString());
                } if (reader["Yuanqijian4Count"] != null && reader["Yuanqijian4Count"].ToString() != "")
                {
                    model.Yuanqijian4Count1 = Convert.ToDecimal(reader["Yuanqijian4Count"].ToString());
                }
                model.TongpaiCanshu = reader["tongpaiCanshu"].ToString();

                model.CihuanCanshu = reader["cihuanCanshu"].ToString();

                model.DuanziCanshu = reader["duanziCanshu"].ToString();

                model.XianlubanCanshu = reader["xianlubanCanshu"].ToString();

                model.JiaopianCanshu = reader["jiaopianCanshu"].ToString();

                model.PingbiCanshu = reader["pingbiCanshu"].ToString();

                model.WenyaguanCanshu = reader["wenyaguanCanshu"].ToString();

                model.DianzuCanshu = reader["dianzuCanshu"].ToString();

                model.LuosiCanshu = reader["luosiCanshu"].ToString();

                model.ResuotaoguanCanshu = reader["resuotaoguanCanshu"].ToString();

                model.AnzhuangPJCanshu = reader["anzhuangPJCanshu"].ToString();

                model.Yuanqijian1Canshu = reader["yuanqijian1Canshu"].ToString();

                model.Yuanqijian2Canshu1 = reader["Yuanqijian2Canshu"].ToString();

                model.Yuanqijian3Canshu1 = reader["Yuanqijian3Canshu"].ToString();

                model.Yuanqijian4Canshu1 = reader["Yuanqijian4Canshu"].ToString();
                reader.Close();
                return model;
            }
            else
            { reader.Close(); return null; }

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OrderPrintSystem.Model.ProductsMOD GetModel(string protype)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  top 1 productId,productName,productNum,waiBZ,NeiBZ,NeiBZDW,bian,jingDu,xianXingdu,eDingJC,tieXiCount,guiGe,caiLiao,xingNeng,chuLiMethod,baoHeDian,xianQuanCount,chujZaShu,chujXianJing,chujRaoXianZD,chujXianTouCD,chujXiantouCL,chujTongMD,cijZaShu,cijXianJing,cijRaoXianZD,cijXianTouCD,cijXianTouCL,cijTongMD,xqjcyqEquip,xqjcyqShuRuState,xqjcyqShuChuState,xqjcyqJiaoCha,xqjcyqFuZai,biaoShiNo,waiKeNo,waiKeCount,yongJiaoCS,shuRu,shuChu,biaoShiAddress,chajianNo,chajianCount,waiXingTZ,cpjccsEquip,cpjccsShuRuState,cpjccsShuChuState,CpjccsJiaoChaBH,cpjccsFuZai,cpjccsNaiYa,cpjccsTongMD,guanJiaoZhenLX,guanJIaoZhenLXCount,guanJiaoZhenLXTOW,guanJiaoZhenLXTOWCount,shuRuXC,shuChuXC,peiXianSR,peiXianSRCount,peiXianSC,peiXianSCCount,remark,isModifyTZ,biaoShiPicture,IsModifyWaikeNo,GongyiZYSX,baoZhuangHeGG,
baoZhuangXiangGG,
baoHeDianTestTJ,
guJia,
tongPai,
ciHuan,
duanZi,
xianLuBan,
jiaoPian,
pingBi,
wenYaGuan,
dianZu,
luoSi,
reSuoTaoGuan,
anZhuangPJ,
yuanQiJian1,
yuanQiJian2,
yuanQiJian3,
yuanQiJian4,
gujiaCanshu,
gujiaCount,
tongpaiCanshu,
tongpaoCount,
cihuanCanshu,
cihuanCount,
duanziCanshu,
duanziCount,
xianlubanCanshu,
xianlubanCount,
jiaopianCanshu,
jiaopianCount,
pingbiCanshu,
pingbiCount,
wenyaguanCanshu,
wenyaguanCount,
dianzuCanshu,
dianzuCount,
luosiCanshu,
luosiCount,
resuotaoguanCanshu,
resuotaoguanCount,
anzhuangPJCanshu,
anzhuangPJCount,
yuanqijian1Canshu,
Yuanqijian1Count,
Yuanqijian2Canshu,
Yuanqijian2Count,
Yuanqijian3Canshu,
Yuanqijian3Count,
Yuanqijian4Canshu,
Yuanqijian4Count from products ");
            strSql.Append(" where productNum='" + protype + "'");

            OrderPrintSystem.Model.ProductsMOD model = new OrderPrintSystem.Model.ProductsMOD();
            SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                if (reader["productId"] != null && reader["productId"].ToString() != "")
                {
                    model.productId = int.Parse(reader["productId"].ToString());
                }
                if (reader["productName"] != null)
                {
                    model.productName = reader["productName"].ToString();
                }
                if (reader["productNum"] != null)
                {
                    model.productNum = reader["productNum"].ToString();
                }
                if (reader["waiBZ"] != null && reader["waiBZ"].ToString() != "")
                {
                    model.waiBZ = int.Parse(reader["waiBZ"].ToString());
                }
                if (reader["NeiBZ"] != null)
                {
                    model.NeiBZ = reader["NeiBZ"].ToString();
                }
                if (reader["NeiBZDW"] != null)
                {
                    model.NeiBZDW = reader["NeiBZDW"].ToString();
                }
                if (reader["bian"] != null)
                {
                    model.bian = reader["bian"].ToString();
                }
                if (reader["jingDu"] != null)
                {
                    model.jingDu = reader["jingDu"].ToString();
                }
                if (reader["xianXingdu"] != null)
                {
                    model.xianXingdu = reader["xianXingdu"].ToString();
                }
                if (reader["eDingJC"] != null)
                {
                    model.eDingJC = reader["eDingJC"].ToString();
                }
                if (reader["tieXiCount"] != null && reader["tieXiCount"].ToString() != "")
                {
                    model.tieXiCount = int.Parse(reader["tieXiCount"].ToString());
                }
                if (reader["guiGe"] != null)
                {
                    model.guiGe = reader["guiGe"].ToString();
                }
                if (reader["caiLiao"] != null)
                {
                    model.caiLiao = reader["caiLiao"].ToString();
                }
                if (reader["xingNeng"] != null)
                {
                    model.xingNeng = reader["xingNeng"].ToString();
                }
                if (reader["chuLiMethod"] != null)
                {
                    model.chuLiMethod = reader["chuLiMethod"].ToString();
                }
                if (reader["baoHeDian"] != null)
                {
                    model.baoHeDian = reader["baoHeDian"].ToString();
                }
                if (reader["xianQuanCount"] != null && reader["xianQuanCount"].ToString() != "")
                {
                    model.xianQuanCount = int.Parse(reader["xianQuanCount"].ToString());
                }
                if (reader["chujZaShu"] != null)
                {
                    model.chujZaShu = reader["chujZaShu"].ToString();
                }
                if (reader["chujXianJing"] != null)
                {
                    model.chujXianJing = reader["chujXianJing"].ToString();
                }
                if (reader["chujRaoXianZD"] != null)
                {
                    model.chujRaoXianZD = reader["chujRaoXianZD"].ToString();
                }
                if (reader["chujXianTouCD"] != null)
                {
                    model.chujXianTouCD = reader["chujXianTouCD"].ToString();
                }
                if (reader["chujXiantouCL"] != null)
                {
                    model.chujXiantouCL = reader["chujXiantouCL"].ToString();
                }
                if (reader["chujTongMD"] != null)
                {
                    model.chujTongMD = reader["chujTongMD"].ToString();
                }
                if (reader["cijZaShu"] != null)
                {
                    model.cijZaShu = reader["cijZaShu"].ToString();
                }
                if (reader["cijXianJing"] != null)
                {
                    model.cijXianJing = reader["cijXianJing"].ToString();
                }
                if (reader["cijRaoXianZD"] != null)
                {
                    model.cijRaoXianZD = reader["cijRaoXianZD"].ToString();
                }
                if (reader["cijXianTouCD"] != null)
                {
                    model.cijXianTouCD = reader["cijXianTouCD"].ToString();
                }
                if (reader["cijXianTouCL"] != null)
                {
                    model.cijXianTouCL = reader["cijXianTouCL"].ToString();
                }
                if (reader["cijTongMD"] != null)
                {
                    model.cijTongMD = reader["cijTongMD"].ToString();
                }
                if (reader["xqjcyqEquip"] != null)
                {
                    model.xqjcyqEquip = reader["xqjcyqEquip"].ToString();
                }
                if (reader["xqjcyqShuRuState"] != null)
                {
                    model.xqjcyqShuRuState = reader["xqjcyqShuRuState"].ToString();
                }
                if (reader["xqjcyqShuChuState"] != null)
                {
                    model.xqjcyqShuChuState = reader["xqjcyqShuChuState"].ToString();
                }
                if (reader["xqjcyqJiaoCha"] != null)
                {
                    model.xqjcyqJiaoCha = reader["xqjcyqJiaoCha"].ToString();
                }
                if (reader["xqjcyqFuZai"] != null)
                {
                    model.xqjcyqFuZai = reader["xqjcyqFuZai"].ToString();
                }
                if (reader["biaoShiNo"] != null)
                {
                    model.biaoShiNo = reader["biaoShiNo"].ToString();
                }
                if (reader["waiKeNo"] != null)
                {
                    model.waiKeNo = reader["waiKeNo"].ToString();
                }
                if (reader["waiKeCount"] != null && reader["waiKeCount"].ToString() != "")
                {
                    model.waiKeCount = int.Parse(reader["waiKeCount"].ToString());
                }
                if (reader["yongJiaoCS"] != null)
                {
                    model.yongJiaoCS = reader["yongJiaoCS"].ToString();
                }
                if (reader["shuRu"] != null)
                {
                    model.shuRu = reader["shuRu"].ToString();
                }
                if (reader["shuChu"] != null)
                {
                    model.shuChu = reader["shuChu"].ToString();
                }
                if (reader["biaoShiAddress"] != null)
                {
                    model.biaoShiAddress = reader["biaoShiAddress"].ToString();
                }
                if (reader["chajianNo"] != null)
                {
                    model.chajianNo = reader["chajianNo"].ToString();
                }
                if (reader["chajianCount"] != null && reader["chajianCount"].ToString() != "")
                {
                    model.chajianCount = int.Parse(reader["chajianCount"].ToString());
                }
                if (reader["waiXingTZ"] != null)
                {
                    model.waiXingTZ = reader["waiXingTZ"].ToString();
                }
                if (reader["cpjccsEquip"] != null)
                {
                    model.cpjccsEquip = reader["cpjccsEquip"].ToString();
                }
                if (reader["cpjccsShuRuState"] != null)
                {
                    model.cpjccsShuRuState = reader["cpjccsShuRuState"].ToString();
                }
                if (reader["cpjccsShuChuState"] != null)
                {
                    model.cpjccsShuChuState = reader["cpjccsShuChuState"].ToString();
                }
                if (reader["CpjccsJiaoChaBH"] != null)
                {
                    model.CpjccsJiaoChaBH = reader["CpjccsJiaoChaBH"].ToString();
                }
                if (reader["cpjccsFuZai"] != null)
                {
                    model.cpjccsFuZai = reader["cpjccsFuZai"].ToString();
                }
                if (reader["cpjccsNaiYa"] != null)
                {
                    model.cpjccsNaiYa = reader["cpjccsNaiYa"].ToString();
                }
                if (reader["cpjccsTongMD"] != null)
                {
                    model.cpjccsTongMD = reader["cpjccsTongMD"].ToString();
                }
                if (reader["guanJiaoZhenLX"] != null)
                {
                    model.guanJiaoZhenLX = reader["guanJiaoZhenLX"].ToString();
                }
                if (reader["guanJIaoZhenLXCount"] != null && reader["guanJIaoZhenLXCount"].ToString() != "")
                {
                    model.guanJIaoZhenLXCount = int.Parse(reader["guanJIaoZhenLXCount"].ToString());
                }
                if (reader["guanJiaoZhenLXTOW"] != null)
                {
                    model.guanJiaoZhenLXTOW = reader["guanJiaoZhenLXTOW"].ToString();
                }
                if (reader["guanJiaoZhenLXTOWCount"] != null && reader["guanJiaoZhenLXTOWCount"].ToString() != "")
                {
                    model.guanJiaoZhenLXTOWCount = int.Parse(reader["guanJiaoZhenLXTOWCount"].ToString());
                }
                if (reader["shuRuXC"] != null)
                {
                    model.shuRuXC = reader["shuRuXC"].ToString();
                }
                if (reader["shuChuXC"] != null)
                {
                    model.shuChuXC = reader["shuChuXC"].ToString();
                }
                if (reader["peiXianSR"] != null)
                {
                    model.peiXianSR = reader["peiXianSR"].ToString();
                }
                if (reader["peiXianSRCount"] != null && reader["peiXianSRCount"].ToString() != "")
                {
                    model.peiXianSRCount = decimal.Parse(reader["peiXianSRCount"].ToString());
                }
                if (reader["peiXianSC"] != null)
                {
                    model.peiXianSC = reader["peiXianSC"].ToString();
                }
                if (reader["peiXianSCCount"] != null && reader["peiXianSCCount"].ToString() != "")
                {
                    model.peiXianSCCount = decimal.Parse(reader["peiXianSCCount"].ToString());
                }
                if (reader["remark"] != null)
                {
                    model.remark = reader["remark"].ToString();
                }
                if (reader["isModifyTZ"] != null && reader["isModifyTZ"].ToString() != "")
                {
                    model.isModifyTZ = int.Parse(reader["isModifyTZ"].ToString());
                }
                if (reader["IsModifyWaikeNo"] != null && reader["IsModifyWaikeNo"].ToString() != "")
                {
                    model.IsModifyWaikeNo = int.Parse(reader["IsModifyWaikeNo"].ToString());
                }
                if (reader["biaoShiPicture"] != null)
                {
                    model.biaoShiPicture = reader["biaoShiPicture"].ToString();
                }
                model.GongyiZYSX = reader["GongyiZYSX"].ToString();
                model.BaoZhuangHeGG = reader["baoZhuangHeGG"].ToString();
                model.BaoZhuangXiangGG = reader["baoZhuangXiangGG"].ToString();
                model.BaoHeDianTestTJ = reader["baoHeDianTestTJ"].ToString();
                model.GuJia = reader["guJia"].ToString();
                model.TongPai = reader["tongPai"].ToString();
                model.CiHuan = reader["ciHuan"].ToString();
                model.DuanZi = reader["duanZi"].ToString();
                model.XianLuBan = reader["xianLuBan"].ToString();
                model.JiaoPian = reader["jiaoPian"].ToString();
                model.PingBi = reader["pingBi"].ToString();
                model.WenYaGuan = reader["wenYaGuan"].ToString();
                model.DianZu = reader["dianZu"].ToString();
                model.LuoSi = reader["luoSi"].ToString();
                model.ReSuoTaoGuan = reader["reSuoTaoGuan"].ToString();
                model.AnZhuangPJ = reader["anZhuangPJ"].ToString();
                model.YuanQiJian1 = reader["yuanQiJian1"].ToString();
                model.YuanQiJian2 = reader["yuanQiJian2"].ToString();
                model.YuanQiJian3 = reader["yuanQiJian3"].ToString();
                model.YuanQiJian4 = reader["yuanQiJian4"].ToString();
                model.GujiaCanshu = reader["gujiaCanshu"].ToString();

                if (reader["gujiaCount"] != null && reader["gujiaCount"].ToString() != "")
                {
                    model.GujiaCount = Convert.ToDecimal(reader["gujiaCount"].ToString());
                }
                if (reader["tongpaoCount"] != null && reader["tongpaoCount"].ToString() != "")
                {
                    model.TongpaoCount = Convert.ToDecimal(reader["tongpaoCount"].ToString());
                }
                if (reader["cihuanCount"] != null && reader["cihuanCount"].ToString() != "")
                {
                    model.CihuanCount = Convert.ToDecimal(reader["cihuanCount"].ToString());
                }
                if (reader["duanziCount"] != null && reader["duanziCount"].ToString() != "")
                {
                    model.DuanziCount = Convert.ToDecimal(reader["duanziCount"].ToString());
                }
                if (reader["xianlubanCount"] != null && reader["xianlubanCount"].ToString() != "")
                {
                    model.XianlubanCount = Convert.ToDecimal(reader["xianlubanCount"].ToString());
                }
                if (reader["jiaopianCount"] != null && reader["jiaopianCount"].ToString() != "")
                {
                    model.JiaopianCount = Convert.ToDecimal(reader["jiaopianCount"].ToString());
                }
                if (reader["pingbiCount"] != null && reader["pingbiCount"].ToString() != "")
                {
                    model.PingbiCount = Convert.ToDecimal(reader["pingbiCount"].ToString());
                }
                if (reader["wenyaguanCount"] != null && reader["wenyaguanCount"].ToString() != "")
                {
                    model.WenyaguanCount = Convert.ToDecimal(reader["wenyaguanCount"].ToString());
                }
                if (reader["dianzuCount"] != null && reader["dianzuCount"].ToString() != "")
                {
                    model.DianzuCount = Convert.ToDecimal(reader["dianzuCount"].ToString());
                } if (reader["luosiCount"] != null && reader["luosiCount"].ToString() != "")
                {
                    model.LuosiCount = Convert.ToDecimal(reader["luosiCount"].ToString());
                } if (reader["resuotaoguanCount"] != null && reader["resuotaoguanCount"].ToString() != "")
                {
                    model.ResuotaoguanCount = Convert.ToDecimal(reader["resuotaoguanCount"].ToString());
                } if (reader["anzhuangPJCount"] != null && reader["anzhuangPJCount"].ToString() != "")
                {
                    model.AnzhuangPJCount = Convert.ToDecimal(reader["anzhuangPJCount"].ToString());
                } if (reader["Yuanqijian1Count"] != null && reader["Yuanqijian1Count"].ToString() != "")
                {
                    model.Yuanqijian1Count1 = Convert.ToDecimal(reader["Yuanqijian1Count"].ToString());
                } if (reader["Yuanqijian2Count"] != null && reader["Yuanqijian2Count"].ToString() != "")
                {
                    model.Yuanqijian2Count1 = Convert.ToDecimal(reader["Yuanqijian2Count"].ToString());
                } if (reader["Yuanqijian3Count"] != null && reader["Yuanqijian3Count"].ToString() != "")
                {
                    model.Yuanqijian3Count1 = Convert.ToDecimal(reader["Yuanqijian3Count"].ToString());
                } if (reader["Yuanqijian4Count"] != null && reader["Yuanqijian4Count"].ToString() != "")
                {
                    model.Yuanqijian4Count1 = Convert.ToDecimal(reader["Yuanqijian4Count"].ToString());
                }
                model.TongpaiCanshu = reader["tongpaiCanshu"].ToString();

                model.CihuanCanshu = reader["cihuanCanshu"].ToString();

                model.DuanziCanshu = reader["duanziCanshu"].ToString();

                model.XianlubanCanshu = reader["xianlubanCanshu"].ToString();

                model.JiaopianCanshu = reader["jiaopianCanshu"].ToString();

                model.PingbiCanshu = reader["pingbiCanshu"].ToString();

                model.WenyaguanCanshu = reader["wenyaguanCanshu"].ToString();

                model.DianzuCanshu = reader["dianzuCanshu"].ToString();

                model.LuosiCanshu = reader["luosiCanshu"].ToString();

                model.ResuotaoguanCanshu = reader["resuotaoguanCanshu"].ToString();

                model.AnzhuangPJCanshu = reader["anzhuangPJCanshu"].ToString();

                model.Yuanqijian1Canshu = reader["yuanqijian1Canshu"].ToString();

                model.Yuanqijian2Canshu1 = reader["Yuanqijian2Canshu"].ToString();

                model.Yuanqijian3Canshu1 = reader["Yuanqijian3Canshu"].ToString();

                model.Yuanqijian4Canshu1 = reader["Yuanqijian4Canshu"].ToString();

                reader.Close();
                return model;
            }
            else
            { reader.Close(); return null; }
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetList(int PageSize, int PageIndex, out int PageCount, string strWhere)
        {
            string sqlCommandString = @"select * from products Where 1=1  " + strWhere;
            string orderSql = " order by productId desc";
            try
            {
                List<SqlParameter> commandParameters = new List<SqlParameter>();
                return SqlHelper.getDataSetOfPage(PageSize, PageIndex, out PageCount, sqlCommandString, commandParameters, CommandType.Text, orderSql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select productId,productName,productNum,waiBZ,NeiBZ,NeiBZDW,bian,jingDu,xianXingdu,eDingJC,tieXiCount,guiGe,caiLiao,xingNeng,chuLiMethod,baoHeDian,xianQuanCount,chujZaShu,chujXianJing,chujRaoXianZD,chujXianTouCD,chujXiantouCL,chujTongMD,cijZaShu,cijXianJing,cijRaoXianZD,cijXianTouCD,cijXianTouCL,cijTongMD,xqjcyqEquip,xqjcyqShuRuState,xqjcyqShuChuState,xqjcyqJiaoCha,xqjcyqFuZai,biaoShiNo,waiKeNo,waiKeCount,yongJiaoCS,shuRu,shuChu,biaoShiAddress,chajianNo,chajianCount,waiXingTZ,cpjccsEquip,cpjccsShuRuState,cpjccsShuChuState,CpjccsJiaoChaBH,cpjccsFuZai,cpjccsNaiYa,cpjccsTongMD,guanJiaoZhenLX,guanJIaoZhenLXCount,guanJiaoZhenLXTOW,guanJiaoZhenLXTOWCount,shuRuXC,shuChuXC,peiXianSR,peiXianSRCount,peiXianSC,peiXianSCCount,remark,isModifyTZ,biaoShiPicture,GongyiZYSX ");
            strSql.Append(" FROM products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 根据产品型号获取产品名称
        /// </summary>
        /// <param name="proType">产品型号</param>
        /// <returns></returns>
        public string GetProductNameByProductNum(string proType)
        {
            string strSql = "select productName from products where productNum=@productNum";
            return SqlHelper.GetSingle(strSql,new SqlParameter("@productNum",proType))+"";
        }


        #endregion  BasicMethod

    }
}

