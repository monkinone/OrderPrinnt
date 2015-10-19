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

public partial class orderManage_PrintYPQRD : PageBase
{
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
            }
            //if (Request.QueryString["planTime"] != null && Request.QueryString["planTime"].ToString() != "")
            //{
            //    lblSendTime.Text = Convert.ToDateTime(Request.QueryString["planTime"].ToString()).ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    lblSendTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
                lblProType.Text = proType;
                //绑定产品基本信息
                ProductsMOD mod = ProductsBLL.GetModel(proType);
                if (mod != null)
                {
                    lblProName.Text = mod.productName;
                }
                //产品数量
                if (Request.QueryString["proNum"] != null && Request.QueryString["proNum"].ToString() != "")
                {
                    lblProNum.Text = Request.QueryString["proNum"].ToString();
                }
                else
                {
                    SendDetailMOD detail = SendDetailBLL.GetmodByid(proType, orderNum);
                    if (detail != null)
                    {
                        if (detail.SendTime.ToString() != "0001/1/1 0:00:00")
                        {
                            lblSendTime.Text = detail.SendTime.ToShortDateString();
                        }
                        if (detail.SendProNum.ToString() != "" && detail.SendProNum.ToString() != "0")
                        {
                            lblProNum.Text = detail.SendProNum.ToString();
                        }
                    }
                }
            }

            //客户编号
            if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
            {
                string customNum = Request.QueryString["customNum"].ToString();
                CustomerManageMod customer = CustomerManageBLL.GetcustomerByid(customNum);
                if (customer != null)
                {
                    txtCompanyName.Text = customer.CompanyName;
                }
            }
            //生产地
            if (Request.QueryString["address"] != null && Request.QueryString["address"].ToString() != "")
            {
                lblAddress.Text = Request.QueryString["address"].ToString();
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
        return ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printYYQRDTime", "printYYQRDCount");
    }

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {

        ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "doPrint();", true);
    }
}