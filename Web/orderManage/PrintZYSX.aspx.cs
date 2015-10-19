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
using OrderPrintSystem.Model;

public partial class orderManage_PrintZYSX : PageBase
{
    public string orderNum = "";
    public string proType = "";
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
                if (customer != null)
                {
                    lblAddress.Text = customer.CompanyAddress;
                    lblCompanyName.Text = customer.CompanyName;
                    lblCompanyNames.Text = customer.CompanyName;
                    lblphone.Text = customer.Phone;
                    lblShouhuoren.Text = customer.Contacts;
                    lblTelphone.Text = customer.TelPhone;

                }
                //绑定客户注意事项
                MattersNeedingAttentionMOD mattMod = MattersNeedingAttentionBLL.GetmodByid(customerNo);
                if (mattMod != null)
                {
                    lblzysx.Text = mattMod.Contents;

                }
            }
            //订单号
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
                ProOrdersMOD orderMod = ProOrdersBLL.GetModel(orderNum);
                if (orderMod != null)
                {
                    lbltsyq.Text = orderMod.remark;

                    if (orderMod.remark != "")
                    {
                        if (orderMod.remark.Contains("收货人"))
                        {
                            lblShouhuoren.Text = "";
                        }
                        if (orderMod.remark.Contains("电话"))
                        {
                            lblphone.Text = "";
                        }
                        if (orderMod.remark.Contains("手机"))
                        {
                            lblTelphone.Text = "";
                        }
                        if (orderMod.remark.Contains("公司名称"))
                        {
                            lblCompanyNames.Text = "";
                        }
                        if (orderMod.remark.Contains("地址"))
                        {
                            lblAddress.Text = "";
                        }
                    }
                }
            }

            //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
            }
        }
    }
}