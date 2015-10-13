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

public partial class orderManage_InspectionReport : PageBase
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
                if (customer != null)
                {
                    txtCompanyName.Text = customer.CompanyName;
                }
            }
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();

                ProductsMOD product = ProductsBLL.GetModel(proType);
                if (product != null)
                {
                    if (!string.IsNullOrEmpty(product.bian) && product.bian.Contains(':'))
                    {
                        string bianbi = product.bian;
                        lblBianbiQian.Text = bianbi.Split(':')[0].ToString();
                        lblBianbiHou.Text = bianbi.Split(':')[1].ToString();
                    }
                    txtshuChu.Text = product.shuChu;
                    txtshuRu.Text = product.shuRu;
                    txtcpjccsNaiYa.Text = product.cpjccsNaiYa;
                    txtjingDu.Text = product.jingDu;
                    txtxianXingdu.Text = product.xianXingdu;
                    txtxqjcyqFuZai.Text = product.xqjcyqFuZai;
                    txteDingJC.Text = product.eDingJC;
                }
                //产品型号
                lblProtype.Text = proType;
                //产品名称
                lblProductName.Text = new ProductsBLL().GetProductNameByProductNum(proType);
            }
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
            }
            //if (Request.QueryString["proNum"] != null && Request.QueryString["proNum"].ToString() != "")
            //{
            //    lblProNum.Text = Request.QueryString["proNum"].ToString()+"PSC";
            //}
            if (Request.QueryString["detailId"] != null && Request.QueryString["detailId"].ToString() != "")
            {
                string detailId = Request.QueryString["detailId"].ToString();
                ProOrdersDetailMOD orderDetail = ProOrdersDetailBLL.GetModel(Convert.ToInt32(detailId));
                if (orderDetail != null)
                {
                    //  lblPiHAO.Text = orderDetail.PiHao;
                }
            }
            if (Request.QueryString["pihao"] != null && Request.QueryString["pihao"].ToString() != "")
            {
                lblPiHAO.Text = Request.QueryString["pihao"].ToString();
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

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {

        ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "doPrint();", true);
    }
}