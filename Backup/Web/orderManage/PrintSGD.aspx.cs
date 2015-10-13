using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_PrintSGD : PageBase
{
    public static string orderNum = "";
    public static string proType = "";
    public static string proNum = "";
    public static string customNum = "";
    public static string suigongdan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            #region 随工单号
            suigongdan = Request.QueryString["withWorkNo"] + "";
            lblSuigongdan.Text = suigongdan;
            #endregion

            //计划发货时间
            if (Request.QueryString["planTime"] != null && Request.QueryString["planTime"].ToString() != "")
            {
                lblPlanTime.Text = Request.QueryString["planTime"].ToString();
            }
            if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
            {
                customNum = Request.QueryString["customNum"].ToString();
            }
            //订单号
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
                lblOrderNUM.Text = orderNum;
                //客户特殊要求
                //ordermod = ProOrdersBLL.GetModel(orderNum);
                //if (ordermod != null)
                //{
                //    lblTeshuYaoqiu.Text = ordermod.remark;
                //}
            }
            //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
                lblproType.Text = proType;
                if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
                {
                    //客户参数要求
                    string customNum = Request.QueryString["customNum"].ToString();
                    ProductParamMOD MOD = ProductParamBLL.GetmodByid(customNum, proType);
                    if (MOD != null)
                    {
                        lblCanshuYaoqiu.Text = MOD.ParamContent;
                    }
                }
                //绑定产品基本信息
                ProductsMOD mod = ProductsBLL.GetModel(proType);
                if (mod != null)
                {
                    txtbaoHeDian.Text = mod.baoHeDian;
                    txtbianbi.Text = mod.bian;
                    txtbiaoShiAddress.Text = mod.biaoShiAddress;
                    txtbiaoShiNo.Text = mod.biaoShiNo;
                    // imgbiaoShiPicture.ImageUrl = mod.biaoShiPicture;
                    if (mod.waiXingTZ != "")
                    {
                        imgWaiXingTZ.ImageUrl = mod.waiXingTZ;
                        imgWaiXingTZ.Visible = true;
                    }
                    else
                    {
                        imgWaiXingTZ.Visible = false;
                    }

                    txtcaiLiao.Text = mod.caiLiao;
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
                    txtguanJiaoZhenLXTOW.Text = mod.guanJiaoZhenLXTOW;
                    txtguiGe.Text = mod.guiGe;
                    txtjingDu.Text = mod.jingDu;
                    txtpeiXianSC.Text = mod.peiXianSC;
                    txtpeiXianSR.Text = mod.peiXianSR;
                    txtremark.InnerHtml = mod.remark;
                    
                    txtshuChu.Text = mod.shuChu;
                    txtshuRu.Text = mod.shuRu;
                    txtwaiKeNo.Text = mod.waiKeNo;
                    txtxianXingdu.Text = mod.xianXingdu;
                    txtxingNeng.Text = mod.xingNeng;
                    txtxqjcyqEquip.Text = mod.xqjcyqEquip;
                    txtxqjcyqFuZai.Text = mod.xqjcyqFuZai;
                    txtxqjcyqJiaoCha.Text = mod.xqjcyqJiaoCha;
                    txtxqjcyqShuChuState.Text = mod.xqjcyqShuChuState;
                    txtxqjcyqShuRuState.Text = mod.xqjcyqShuRuState;
                    txtyongJiaoCS.Text = mod.yongJiaoCS;
                    lblGongyi.InnerHtml = mod.GongyiZYSX;
                    txtbaoHeDianTestTJ.Text = mod.BaoHeDianTestTJ;
                    txtbaoZhuangHeGG.Text = mod.BaoZhuangHeGG;
                    txtbaoZhuangXiangGG.Text = mod.BaoZhuangXiangGG;
                    //如果在“客户特殊要求”填写的内容里边检索到“输入线长”，“输出线长”，需要将输入线长，输出线长单元格原有的内容清除

                    ProductParamMOD paramMod = ProductParamBLL.GetmodByid(customNum, proType);
                    if (paramMod != null)
                    {
                        if (paramMod.IsWriteFahuoInfo == 1)
                        {
                            txtshuRuXC.Text = "";
                        }
                        else
                        {
                            txtshuRuXC.Text = mod.shuRuXC;
                        }
                        if (paramMod.IsWriteXianChang == 1)
                        {
                            txtshuChuXC.Text = "";
                        }
                        else
                        {
                            txtshuChuXC.Text = mod.shuChuXC;
                        }
                        if (paramMod.IsWriteXianChang != 1 && paramMod.IsWriteFahuoInfo != 1)
                        {
                            txtshuRuXC.Text = mod.shuRuXC;
                            txtshuChuXC.Text = mod.shuChuXC;
                        }
                    }
                    else
                    {
                        txtshuRuXC.Text = mod.shuRuXC;
                        txtshuChuXC.Text = mod.shuChuXC;
                    }
                }
            }
            //产品数量
            proNum = Request.QueryString["proNum"]+"";
            lblProNUM.Text = proNum;
            //批号
            if (Request.QueryString["pihao"] != null && Request.QueryString["pihao"].ToString() != "")
            {
                string pihao = Request.QueryString["pihao"].ToString();
                lblPihao.Text = pihao;
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
        return ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printSGDTime", "printSGDCount");
    }
    [WebMethod]
    public static int UpdatePrintCount()
    {
        int count = 0;
        if (proNum != "")
        {
            count = Convert.ToInt32(proNum);
            PrintSGDCountMOD mod = PrintSGDCountBLL.GetmodByid(orderNum, proType);
            if (mod != null)
            {
                if (mod.PrintCount.ToString() != "")
                {
                    mod.PrintCount = mod.PrintCount + count;
                }
                else
                {
                    mod.PrintCount = count;
                }
                mod.OrderNum = orderNum;
                mod.ProType = proType;
                return PrintSGDCountBLL.Updatemod(mod);
            }
            else
            {
                mod = new PrintSGDCountMOD();
                mod.PrintCount = count;
                mod.OrderNum = orderNum;
                mod.ProType = proType;
                return PrintSGDCountBLL.Insertmod(mod);
            }
        }
        else
        {
            return 0;
        }
    }
    [WebMethod]
    public static int AddSuigongdan()
    {
        SGDRecordMOD mod = new SGDRecordMOD();
        mod.OrderNum = orderNum;
        mod.ProType = proType;
        mod.CustomerNum = customNum;
        mod.Suigongdan = suigongdan;
        mod.PrintCount = proNum;

       return SGDRecordBLL.Insertmod(mod);
    }
}