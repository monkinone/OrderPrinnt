using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using System.Data;
using OrderPrintSystem.Modules;
using System.Web.Services;

public partial class orderManage_PrintZYSX : System.Web.UI.Page
{
    public static string orderNum = "";
    public static string proType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                string customerNo = Request.QueryString["customerNo"].ToString();
                //绑定客户名称及编号
                lblcustomNUM.Text = customerNo;
                CustomerManageMod customer = CustomerManageBLL.GetcustomerByid(customerNo);
                lblCompanyName.Text = customer.CompanyName;
                //绑定客户注意事项
                DataSet ds = MattersNeedingAttentionBLL.GetmodAll(" and customerNo='" + customerNo + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptPro.DataSource = ds;
                    rptPro.DataBind();
                }
            }
             //订单号
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
               
            }
          
            //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
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
        return ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printZYSXTime", "printZYSXCount");
    }
}