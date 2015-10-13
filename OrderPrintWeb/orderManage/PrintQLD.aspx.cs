using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_PrintQLD : PageBase
{
    string proNum = "";
    public static string orderNum = "";
    public static string proType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //订单号
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
                lblOrderNUM.Text = orderNum;
            }
            //随工单打印数量
            if (Request.QueryString["proNum"] != null && Request.QueryString["proNum"].ToString() != "")
            {
                proNum = Request.QueryString["proNum"].ToString();
            }
            //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
                lblproType.Text = proType;
                //绑定产品基本信息
                ProductsMOD mod = ProductsBLL.GetModel(proType);
                if (mod != null)
                {

                    txtchajianNo.Text = mod.chajianNo;

                    txtchuLiMethod.Text = mod.chuLiMethod;

                    txtguanJiaoZhenLX.Text = mod.guanJiaoZhenLX;
                    txtguanJiaoZhenLXTOW.Text = mod.guanJiaoZhenLXTOW;
                    txtguiGe.Text = mod.guiGe + "&" + mod.caiLiao;

                    txtpeiXianSC.Text = mod.peiXianSC;
                    txtpeiXianSR.Text = mod.peiXianSR;

                    txtwaiKeNo.Text = mod.waiKeNo;

                    txtxingNeng.Text = mod.xingNeng;

                    lblXianquan.Text = mod.cijZaShu + "*" + mod.cijXianJing;
                    lbltongxian.Text = mod.cijXianJing;
                    lbltongxianCount.Text = proNum;

                    lblgujia.Text = mod.GuJia;
                    lbltongpai.Text = mod.TongPai;
                    lblcihuan.Text = mod.CiHuan;
                    lblduanzi.Text = mod.DuanZi;
                    lblxianluban.Text = mod.XianLuBan;
                    lbljiaopian.Text = mod.JiaoPian;
                    lblpingbi.Text = mod.PingBi;
                    lblwenyaguan.Text = mod.WenYaGuan;
                    lbldianzu.Text = mod.DianZu;
                    lblluosi.Text = mod.LuoSi;
                    lblresuotaoguan.Text = mod.ReSuoTaoGuan;
                    lblanzhuangpeijian.Text = mod.AnZhuangPJ;
                    lblyuanqijian1.Text = mod.YuanQiJian1;
                    lblyuanqijian2.Text = mod.YuanQiJian2;
                    lblyuanqijian3.Text = mod.YuanQiJian3;
                    lblyuanqijian4.Text = mod.YuanQiJian4;
                    txtgujiaCanshu.Text = mod.GujiaCanshu;

                    txttongpaiCanshu.Text = mod.TongpaiCanshu;
                    txtcihuanCanshu.Text = mod.CihuanCanshu;
                    txtduanziCanshu.Text = mod.DuanziCanshu;
                    txtxianlubanCanshu.Text = mod.XianlubanCanshu;
                    txtjiaopianCanshu.Text = mod.JiaopianCanshu;
                    txtpingbiCanshu.Text = mod.PingbiCanshu;
                    txtwenyaguanCanshu.Text = mod.WenyaguanCanshu;
                    txtdianzuCanshu.Text = mod.DianzuCanshu;
                    txtluosiCanshu.Text = mod.LuosiCanshu;
                    txtresuotaoguanCanshu.Text = mod.ResuotaoguanCanshu;
                    txtanzhuangPJCanshu.Text = mod.AnzhuangPJCanshu;
                    txtyuanQiJian1Canshu.Text = mod.Yuanqijian1Canshu;
                    txtyuanQiJian2Canshu.Text = mod.Yuanqijian2Canshu1;
                    txtyuanQiJian3Canshu.Text = mod.Yuanqijian3Canshu1;
                    txtyuanQiJian4Canshu.Text = mod.Yuanqijian4Canshu1;




                    if (proNum != "")
                    {
                        if (mod.tieXiCount != 0)
                        {
                            if ((Convert.ToInt32(proNum) * mod.tieXiCount).ToString() != "0")
                            {
                                txttieXiCount.Text = (Convert.ToInt32(proNum) * mod.tieXiCount).ToString();
                            }
                        }
                        if (mod.xianQuanCount != 0)
                        {
                            if ((Convert.ToInt32(proNum) * mod.xianQuanCount).ToString() != "0")
                            {
                                lblXianQuanCount.Text = (Convert.ToInt32(proNum) * mod.xianQuanCount).ToString();
                            }
                        }
                        if (mod.waiKeCount != 0)
                        {
                            if ((Convert.ToInt32(proNum) * mod.waiKeCount).ToString() != "0")
                            {
                                lblWaikeCount.Text = (Convert.ToInt32(proNum) * mod.waiKeCount).ToString();
                            }
                        }
                        if ((Convert.ToInt32(proNum) * mod.chajianCount).ToString() != "0")
                        {
                            txtchajianCount.Text = (Convert.ToInt32(proNum) * mod.chajianCount).ToString();
                        }
                        if ((Convert.ToInt32(proNum) * Convert.ToDecimal(mod.peiXianSCCount)).ToString() != "0.00")
                        {
                            txtpeiXianSCCount.Text = (Convert.ToInt32(proNum) * Convert.ToDecimal(mod.peiXianSCCount)).ToString();
                        }
                        if ((Convert.ToInt32(proNum) * Convert.ToDecimal(mod.peiXianSRCount)).ToString() != "0.00")
                        {
                            txtpeiXianSRCount.Text = (Convert.ToInt32(proNum) * Convert.ToDecimal(mod.peiXianSRCount)).ToString();
                        }
                        if ((Convert.ToInt32(proNum) * mod.guanJiaoZhenLXTOWCount).ToString() != "0")
                        {
                            txtguanJiaoZhenLXTOWCount.Text = (Convert.ToInt32(proNum) * mod.guanJiaoZhenLXTOWCount).ToString();
                        }
                        if ((Convert.ToInt32(proNum) * mod.guanJIaoZhenLXCount).ToString() != "0")
                        {
                            txtguanJIaoZhenLXCount.Text = (Convert.ToInt32(proNum) * mod.guanJIaoZhenLXCount).ToString();
                        }
                        txtgujiaCount.Text = (mod.GujiaCount * Convert.ToInt32(proNum)).ToString();

                        txttongpaiCount.Text = (mod.TongpaoCount * Convert.ToInt32(proNum)).ToString();

                        txtcihuanCount.Text = (mod.CihuanCount * Convert.ToInt32(proNum)).ToString();

                        txtduanziCount.Text = (mod.DuanziCount * Convert.ToInt32(proNum)).ToString();

                        txtxianlubanCount.Text = (mod.XianlubanCount * Convert.ToInt32(proNum)).ToString();

                        txtjiaopianCount.Text = (mod.JiaopianCount * Convert.ToInt32(proNum)).ToString();

                        txtpingbiCount.Text = (mod.PingbiCount * Convert.ToInt32(proNum)).ToString();

                        txtwenyaguanCount.Text = (mod.WenyaguanCount * Convert.ToInt32(proNum)).ToString();

                        txtdianzuCount.Text = (mod.DianzuCount * Convert.ToInt32(proNum)).ToString();

                        txtluosiCount.Text = (mod.LuosiCount * Convert.ToInt32(proNum)).ToString();

                        txtresuotaoguanCount.Text = (mod.ResuotaoguanCount * Convert.ToInt32(proNum)).ToString();

                        txtanzhuangPJCount.Text = (mod.AnzhuangPJCount * Convert.ToInt32(proNum)).ToString();

                        txtyuanQiJian1Count.Text = (mod.Yuanqijian1Count1 * Convert.ToInt32(proNum)).ToString();

                        txtyuanQiJian2Count.Text = (mod.Yuanqijian2Count1 * Convert.ToInt32(proNum)).ToString();

                        txtyuanQiJian3Count.Text = (mod.Yuanqijian3Count1 * Convert.ToInt32(proNum)).ToString();

                        txtyuanQiJian4Count.Text = (mod.Yuanqijian4Count1 * Convert.ToInt32(proNum)).ToString();
                    }
                }
            }

            //客户编号
            if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
            {
                string customNum = Request.QueryString["customNum"].ToString();
                lblCustomerNo.Text = customNum;
            }
            //随工单号
            if (Request.QueryString["withWorkNo"] != null && Request.QueryString["withWorkNo"].ToString() != "")
            {
                string withWorkNo = Request.QueryString["withWorkNo"].ToString();
                lblwithWorkNo.Text = withWorkNo;
            }
        }
    }
    /// <summary>
    /// 修改打印次数及时间
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns></returns>
    [WebMethod]
    public static int UpdatePrint()
    {
        return ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printQLDTime", "printQLDCount");
    }
}