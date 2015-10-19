using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using System.Data;
using OrderPrintSystem.Modules;
using OrderPrintSystem.Model;

public partial class orderManage_PrintSendList : System.Web.UI.Page
{
    public static string orderNum = "";
    public static string proType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                 orderNum = Request.QueryString["orderNum"].ToString();
                //绑定所有订单产品
                DataSet ds = ProOrdersDetailBLL.GetList(" and orderNum='" + orderNum + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptPro.DataSource = ds;
                    rptPro.DataBind();
                }
            }
            if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
            {
                string customNum = Request.QueryString["customNum"].ToString();
                CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customNum);
                if (mod != null)
                {
                    lblCompanyName.Text = mod.CompanyName;
                }
            }
              //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
            }
            //打印时间
            lblPrintTime.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void txtProNum_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox textBox = (TextBox)sender;
            RepeaterItem repeaterItem = (RepeaterItem)textBox.Parent;
            Label lblPrice = (Label)repeaterItem.FindControl("lblPrice");
            Label lblTotalPrice = (Label)repeaterItem.FindControl("lblTotalPrice");
            lblTotalPrice.Text = (Convert.ToInt32(textBox.Text.Trim()) * Convert.ToDecimal(lblPrice.Text.Trim())).ToString();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('请正确填写数量！')", true);
        }
    }
    /// <summary>
    /// 打印
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        bool result = true;
        for (int i = 0; i < rptPro.Items.Count; i++)
        {
            TextBox txtProNum = this.rptPro.Items[i].FindControl("txtProNum") as TextBox;
            if (txtProNum.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('请填写数量！');", true);
                return;
            }
        }
        //打印前先将信息保存
        for (int i = 0; i < rptPro.Items.Count; i++)
        {
            Label lblProType = this.rptPro.Items[i].FindControl("lblProType") as Label;
            Label lblPrice = this.rptPro.Items[i].FindControl("lblPrice") as Label;
            TextBox txtProNum = this.rptPro.Items[i].FindControl("txtProNum") as TextBox;
            TextBox txtRemark = this.rptPro.Items[i].FindControl("txtRemark") as TextBox;
            SendDetailMOD mod = new SendDetailMOD();
            mod.OrderNum = Request.QueryString["orderNum"].ToString();
            mod.ProType = lblProType.Text;
            mod.Remark = txtRemark.Text;
            mod.SendProNum = Convert.ToInt32(txtProNum.Text.Trim());
            mod.SendTime = DateTime.Now;
            mod.UnitPrice = Convert.ToDecimal(lblPrice.Text.Trim());
            int num = SendDetailBLL.Insertmod(mod);
            if (num < 0)
            {
                result = false;
                SendDetailBLL.Delete(Request.QueryString["orderNum"].ToString());
                break;
            }
        }
        if (result)
        {
            ProOrdersDetailBLL.UpdatePrintInfo(orderNum, proType, "printSHDTime", "printSHDCount");
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "doPrint();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('您输入的信息有误！');", true);
        }
    }
    /// <summary>
    /// 变比
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    public string GetBianBi(string proType)
    {
        string bianbi = "";
       ProductsMOD MOD= ProductsBLL.GetModel(proType);
       if (MOD != null)
       {
           bianbi = MOD.bian;
       }
        return bianbi;
    }
}