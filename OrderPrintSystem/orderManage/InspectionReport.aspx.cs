using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System.Data;
using OrderPrintSystem.Model;
using System.Web.Services;

public partial class orderManage_InspectionReport : System.Web.UI.Page
{
    public static string proType = "";
    public static string orderNum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                string customerNo = Request.QueryString["customerNo"].ToString();
                CustomerManageMod customer = CustomerManageBLL.GetcustomerByid(customerNo);
                lblCompanyName.Text = customer.CompanyName;
            }
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                 proType = Request.QueryString["proType"].ToString();
               
                ProductsMOD product = ProductsBLL.GetModel(proType);
                lblBianbi.Text = product.bian;
                lblProtype.Text = proType;
            }
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                 orderNum = Request.QueryString["orderNum"].ToString();
            }
            if (Request.QueryString["detailId"] != null && Request.QueryString["detailId"].ToString() != "")
            {
                string detailId = Request.QueryString["detailId"].ToString();
                ProOrdersDetailMOD orderDetail = ProOrdersDetailBLL.GetModel(Convert.ToInt32(detailId));
                lblPiHAO.Text = orderDetail.PiHao;
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
        return ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printCCJYBGTime", "printCCJYBGCount");
    }
}