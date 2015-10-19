using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderPrintWeb.ProductManage
{
    public partial class DetailProduct : PageBase
    {
        ProductsMOD mod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    imgWaiXingTZ.Visible = true;
                    imgbiaoShiPicture.Visible = true;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    mod = ProductsBLL.GetModel(id);
                    if (mod != null)
                    {
                        txtbaoHeDian.Text = mod.baoHeDian;
                        txtbianbi.Text = mod.bian;
                        txtbiaoShiAddress.Text = mod.biaoShiAddress;
                        txtbiaoShiNo.Text = mod.biaoShiNo;
                        if (mod.biaoShiPicture != "")
                        {
                            imgbiaoShiPicture.ImageUrl = mod.biaoShiPicture;
                        }
                        else
                        {
                            imgbiaoShiPicture.ImageUrl = "/images/nophoto.jpg";
                        }
                        if (mod.waiXingTZ != "")
                        {
                            imgWaiXingTZ.ImageUrl = mod.waiXingTZ;
                        }
                        else
                        {
                            imgWaiXingTZ.ImageUrl = "/images/nophoto.jpg";
                        }

                        txtcaiLiao.Text = mod.caiLiao;

                        txtchajianCount.Text = mod.chajianCount.ToString();

                        txtchajianNo.Text = mod.chajianNo;
                        txtchujRaoXianZD.Text = mod.chujRaoXianZD;
                        txtchujTongMD.Text = mod.chujTongMD;
                        txtchujXianJing.Text = mod.chujXianJing;
                        txtchujXianTouCD.Text = mod.chujXianTouCD;
                        txtchujXiantouCL.Text = mod.chujXiantouCL;
                        txtchujZaShu.Text = mod.chujZaShu;
                        txtchuLiMethod.Text = mod.chuLiMethod;
                        txtcijRaoXianZD.Text = mod.cijRaoXianZD;
                        txtcijTongMD.Text = mod.cijTongMD;
                        txtcijXianJing.Text = mod.cijXianJing;
                        txtcijXianTouCD.Text = mod.cijXianTouCD;
                        txtcijXianTouCL.Text = mod.cijXianTouCL;
                        txtcijZaShu.Text = mod.cijZaShu;
                        txtcpjccsEquip.Text = mod.cpjccsEquip;
                        txtcpjccsFuZai.Text = mod.cpjccsFuZai;
                        txtCpjccsJiaoChaBH.Text = mod.CpjccsJiaoChaBH;
                        txtcpjccsNaiYa.Text = mod.cpjccsNaiYa;
                        txtcpjccsShuChuState.Text = mod.cpjccsShuChuState;
                        txtcpjccsShuRuState.Text = mod.cpjccsShuRuState;
                        txtcpjccsTongMD.Text = mod.cpjccsTongMD;
                        txteDingJC.Text = mod.eDingJC;
                        txtguanJiaoZhenLX.Text = mod.guanJiaoZhenLX;
                        txtguanJIaoZhenLXCount.Text = mod.guanJIaoZhenLXCount.ToString();
                        txtguanJiaoZhenLXTOW.Text = mod.guanJiaoZhenLXTOW;
                        txtguanJiaoZhenLXTOWCount.Text = mod.guanJiaoZhenLXTOWCount.ToString();
                        txtguiGe.Text = mod.guiGe;
                        txtjingDu.Text = mod.jingDu;
                        txtNeiBZ.Text = mod.NeiBZ;
                        txtpeiXianSC.Text = mod.peiXianSC;
                        txtpeiXianSCCount.Text = mod.peiXianSCCount.ToString();
                        txtpeiXianSR.Text = mod.peiXianSR;
                        txtpeiXianSRCount.Text = mod.peiXianSRCount.ToString();
                        txtproductName.Text = mod.productName;
                        txtproductNum.Text = mod.productNum;
                        txtremark.InnerHtml = mod.remark;
                        txtshuChu.Text = mod.shuChu;
                        txtshuChuXC.Text = mod.shuChuXC;
                        txtshuRu.Text = mod.shuRu;
                        txtshuRuXC.Text = mod.shuRuXC;
                        txttieXiCount.Text = mod.tieXiCount.ToString();
                        txtwaiBZ.Text = mod.waiBZ.ToString();

                        txtwaiKeCount.Text = mod.waiKeCount.ToString();
                        txtwaiKeNo.Text = mod.waiKeNo;
                        txtxianQuanCount.Text = mod.xianQuanCount.ToString();

                        txtxianXingdu.Text = mod.xianXingdu;
                        txtxingNeng.Text = mod.xingNeng;
                        txtxqjcyqEquip.Text = mod.xqjcyqEquip;
                        txtxqjcyqFuZai.Text = mod.xqjcyqFuZai;
                        txtxqjcyqJiaoCha.Text = mod.xqjcyqJiaoCha;
                        txtxqjcyqShuChuState.Text = mod.xqjcyqShuChuState;
                        txtxqjcyqShuRuState.Text = mod.xqjcyqShuRuState;
                        txtyongJiaoCS.Text = mod.yongJiaoCS;
                        txtGongyi.InnerHtml = mod.GongyiZYSX;

                        txtbaoZhuangHeGG.Text = mod.BaoZhuangHeGG;
                        txtbaoZhuangXiangGG.Text = mod.BaoZhuangXiangGG;
                        txtbaoHeDianTestTJ.Text = mod.BaoHeDianTestTJ;
                        //取料单
                        txtguJia.Text = mod.GuJia;
                        txttongPai.Text = mod.TongPai;
                        txtciHuan.Text = mod.CiHuan;
                        txtduanZi.Text = mod.DuanZi;
                        txtxianLuBan.Text = mod.XianLuBan;
                        txtjiaoPian.Text = mod.JiaoPian;
                        txtpingBi.Text = mod.PingBi;
                        txtwenYaGuan.Text = mod.WenYaGuan;
                        txtdianZu.Text = mod.DianZu;
                        txtluoSi.Text = mod.LuoSi;
                        txtreSuoTaoGuan.Text = mod.ReSuoTaoGuan;
                        txtanZhuangPJ.Text = mod.AnZhuangPJ;
                        txtyuanQiJian1.Text = mod.YuanQiJian1;
                        txtyuanQiJian2.Text = mod.YuanQiJian2;
                        txtyuanQiJian3.Text = mod.YuanQiJian3;
                        txtyuanQiJian4.Text = mod.YuanQiJian4;

                        txtgujiaCanshu.Text = mod.GujiaCanshu;
                        txtgujiaCount.Text = mod.GujiaCount.ToString() == "0" ? "" : mod.GujiaCount.ToString();
                        txttongpaiCanshu.Text = mod.TongpaiCanshu;
                        txttongpaiCount.Text = mod.TongpaoCount.ToString() == "0" ? "" : mod.TongpaoCount.ToString();
                        txtcihuanCanshu.Text = mod.CihuanCanshu;
                        txtcihuanCount.Text = mod.CihuanCount.ToString() == "0" ? "" : mod.CihuanCount.ToString();
                        txtduanziCanshu.Text = mod.DuanziCanshu;
                        txtduanziCount.Text = mod.DuanziCount.ToString() == "0" ? "" : mod.DuanziCount.ToString();
                        txtxianlubanCanshu.Text = mod.XianlubanCanshu;
                        txtxianlubanCount.Text = mod.XianlubanCount.ToString() == "0" ? "" : mod.XianlubanCount.ToString();
                        txtjiaopianCanshu.Text = mod.JiaopianCanshu;
                        txtjiaopianCount.Text = mod.JiaopianCount.ToString() == "0" ? "" : mod.JiaopianCount.ToString();
                        txtpingbiCanshu.Text = mod.PingbiCanshu;
                        txtpingbiCount.Text = mod.PingbiCount.ToString() == "0" ? "" : mod.PingbiCount.ToString();
                        txtwenyaguanCanshu.Text = mod.WenyaguanCanshu;
                        txtwenyaguanCount.Text = mod.WenyaguanCount.ToString() == "0" ? "" : mod.WenyaguanCount.ToString();
                        txtdianzuCanshu.Text = mod.DianzuCanshu;
                        txtdianzuCount.Text = mod.DianzuCount.ToString() == "0" ? "" : mod.DianzuCount.ToString();
                        txtluosiCanshu.Text = mod.LuosiCanshu;
                        txtluosiCount.Text = mod.LuosiCount.ToString() == "0" ? "" : mod.LuosiCount.ToString();
                        txtresuotaoguanCanshu.Text = mod.ResuotaoguanCanshu;
                        txtresuotaoguanCount.Text = mod.ResuotaoguanCount.ToString() == "0" ? "" : mod.ResuotaoguanCount.ToString();
                        txtanzhuangPJCanshu.Text = mod.AnzhuangPJCanshu;
                        txtanzhuangPJCount.Text = mod.AnzhuangPJCount.ToString() == "0" ? "" : mod.AnzhuangPJCount.ToString();
                        txtyuanQiJian1Canshu.Text = mod.Yuanqijian1Canshu;
                        txtyuanQiJian1Count.Text = mod.Yuanqijian1Count1.ToString() == "0" ? "" : mod.Yuanqijian1Count1.ToString();
                        txtyuanQiJian2Canshu.Text = mod.Yuanqijian2Canshu1;
                        txtyuanQiJian2Count.Text = mod.Yuanqijian2Count1.ToString() == "0" ? "" : mod.Yuanqijian2Count1.ToString();
                        txtyuanQiJian3Canshu.Text = mod.Yuanqijian3Canshu1;
                        txtyuanQiJian3Count.Text = mod.Yuanqijian3Count1.ToString() == "0" ? "" : mod.Yuanqijian3Count1.ToString();
                        txtyuanQiJian4Canshu.Text = mod.Yuanqijian4Canshu1;
                        txtyuanQiJian4Count.Text = mod.Yuanqijian4Count1.ToString() == "0" ? "" : mod.Yuanqijian4Count1.ToString();
                    }
                    //产品编号不允许修改
                    txtproductNum.Enabled = false;
                }
                else
                {
                    imgWaiXingTZ.Visible = false;
                    imgbiaoShiPicture.Visible = false;
                }
            }
        }
    }
}