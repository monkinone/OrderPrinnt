using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_OrderPrint : PageBase
{
    ProOrdersMOD orderMod = null;
    ProOrdersDetailMOD orderDetail = null;
    CustomerManageMod customer = null;
    public string orderDetailId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                orderDetailId = Request.QueryString["id"].ToString();
                orderDetail = ProOrdersDetailBLL.GetModel(Convert.ToInt32(orderDetailId));
                if (orderDetail != null)
                {
                    txtpiHao.Text = orderDetail.PiHao;
                    if (Convert.ToDateTime(orderDetail.PlanSendTime).ToString("yyyy-MM-dd") != "0001-01-01")
                    {
                        txtplanSendTime.Text = Convert.ToDateTime(orderDetail.PlanSendTime).ToString("yyyy-MM-dd");
                    }
                    txtproductAddress.Text = orderDetail.ProductAddress;
                    lblproNum.Text = orderDetail.proNum.ToString();
                    txtproType.Text = orderDetail.proType;
                    //if (orderDetail.withWorkNo != "")
                    //{
                    //    txtwithWorkNo.Text = orderDetail.withWorkNo;
                    //}
                    //else
                    //{
                    //    txtwithWorkNo.Text = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //}
                    //随工单号
                    string date = DateTime.Now.ToString("yyyyMM");
                    string str = "";
                    if (SGDRecordBLL.GetSuigondanMax(date) != null)
                    {
                        str = SGDRecordBLL.GetSuigondanMax(date).ToString();
                    }
                    if (str == "")
                    {
                        txtwithWorkNo.Text = DateTime.Now.ToString("yyyyMMdd") + "-1";
                    }
                    else
                    {
                        txtwithWorkNo.Text = DateTime.Now.ToString("yyyyMMdd") + "-" + (Convert.ToInt32(str.Split('-')[1]) + 1);
                    }
                    //加载订单基本信息
                    orderMod = ProOrdersBLL.GetModel(orderDetail.orderNum);
                    if (orderMod != null)
                    {
                        txtcustomManager.Text = orderMod.customManager;
                        txtcustomNum.Text = orderMod.customNum;
                        txtcustomOrderNum.Text = orderMod.customOrderNum;
                        txtcustomWLBH.Text = orderMod.customWLBH;
                        txtheTongNum.Text = orderMod.heTongNum;
                        txtorderNum.Text = orderMod.orderNum;
                        txtremark.Text = orderMod.remark;
                      
                    }

                }
            }
        }
    }
    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, EventArgs e)
    {
        int num = 0;
        //修改订单详情
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            string detailId = Request.QueryString["id"].ToString();
            //加载订单基本信息
            orderDetail = ProOrdersDetailBLL.GetModel(Convert.ToInt32(detailId));
            orderDetail.PiHao = txtpiHao.Text.Trim();
            orderDetail.PlanSendTime = Convert.ToDateTime(txtplanSendTime.Text.Trim());
            orderDetail.ProductAddress = txtproductAddress.Text.Trim();
            orderDetail.withWorkNo = txtwithWorkNo.Text.Trim();
            orderDetail.proNum = Convert.ToInt32(lblproNum.Text.Trim());

            num = ProOrdersDetailBLL.Update(orderDetail);
        }

        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "DetailsPageControl.CloseBox();alert('提交成功！');DetailsPageControl.ReflushList('orderManage/OrderProManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('提交失败！')", true);
        }
    }
    /// <summary>
    /// 根据产品型号查询是否修改了外壳图片，外壳编号
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns>1修改  0未修改</returns>
    [WebMethod]
    public static int isUpdateWaikeImg(string proType)
    {
        int isUpdate = 0;
        ProductsMOD productMod = ProductsBLL.GetModel(proType);
        if (productMod != null)
        {
            isUpdate = Convert.ToInt32(productMod.IsModifyWaikeNo);
            if (isUpdate == 0)
            {
                string waiKeNo = productMod.waiKeNo;
                WaiKeImgMOD imgMod = WaiKeImgBLL.GetmodByid(waiKeNo);
                if (imgMod != null)
                {
                    isUpdate = imgMod.IsModify;
                }
            }
        }
        return isUpdate;
    }
    /// <summary>
    /// 根据产品型号查询是否修改了标示图片、标示编号
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns>1修改  0未修改</returns>
    [WebMethod]
    public static int isUpdateBiaoshiImg(string proType)
    {
        int isUpdate = 0;
        ProductsMOD productMod = ProductsBLL.GetModel(proType);
        if (productMod != null)
        {
            isUpdate = Convert.ToInt32(productMod.isModifyTZ);
        }
        return isUpdate;
    }
    /// <summary>
    /// 获取外壳图片
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    [WebMethod]
    public static string GetWaikwImg(string proType)
    {
        string url = "";
        ProductsMOD productMod = ProductsBLL.GetModel(proType);
        if (productMod != null)
        {
            string waiKeNo = productMod.waiKeNo;
            WaiKeImgMOD imgMod = WaiKeImgBLL.GetmodByid(waiKeNo);
            if (imgMod != null)
            {
                url = imgMod.WaiKeImg;
            }
        }
        return url;
    }
    /// <summary>
    /// 获取标示图片
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    [WebMethod]
    public static string GetBiaoshiImg(string proType)
    {
        string url = "";
        ProductsMOD productMod = ProductsBLL.GetModel(proType);
        if (productMod != null)
        {
            url = productMod.biaoShiPicture;
        }
        return url;
    }
    /// <summary>
    /// 获取随工单打印次数
    /// </summary>
    /// <param name="proType"></param>
    /// <param name="orderNum"></param>
    /// <returns></returns>
    [WebMethod]
    public static int GetPrintSGDCount(string proType, string orderNum)
    {
        int count = 0;
        ProOrdersDetailMOD orderDetailMod = ProOrdersDetailBLL.GetModel(proType, orderNum);
        if (orderDetailMod != null)
        {
            count = orderDetailMod.PrintSGDCount;
        }
        return count;
    }
    /// <summary>
    /// 将修改状态改为0
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    [WebMethod]
    public static int UpdateIsModify(string proType)
    {
        int num = 0;
        try
        {
            ProductsMOD productMod = ProductsBLL.GetModel(proType);
            if (productMod != null)
            {
                string waiKeNo = productMod.waiKeNo;
                WaiKeImgBLL.Updatemod(waiKeNo);
            }
            ProductsBLL.Update(proType);
            num = 1;
        }
        catch (Exception ex)
        {
            num = 0;
        }
        return num;
    }
}