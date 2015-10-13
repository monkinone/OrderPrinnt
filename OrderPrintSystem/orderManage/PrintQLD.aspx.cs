using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_PrintQLD : System.Web.UI.Page
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
            //产品数量
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
                    txtguiGe.Text = mod.guiGe;

                    txtpeiXianSC.Text = mod.peiXianSC;
                    txtpeiXianSR.Text = mod.peiXianSR;

                    txtwaiKeNo.Text = mod.waiKeNo;

                    txtxingNeng.Text = mod.xingNeng;



                    if (mod.tieXiCount != 0)
                    {
                        txttieXiCount.Text = mod.tieXiCount.ToString();
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