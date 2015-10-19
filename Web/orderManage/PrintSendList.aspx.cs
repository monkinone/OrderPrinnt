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

public partial class orderManage_PrintSendList : PageBase
{
    public static string orderNum = "";
    public static string proType = "";
    public static string customNum = "";
    public static string withWorkNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["withWorkNo"] != null && Request.QueryString["withWorkNo"].ToString() != "")
            {
                withWorkNo = Request.QueryString["withWorkNo"].ToString();
            }
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
                lblOrderNum.Text = orderNum;
                //绑定所有订单产品
                DataSet ds = ProOrdersDetailBLL.GetList(" and orderNum='" + orderNum + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //不显示单价
                    rptPro.DataSource = ds;
                    rptPro.DataBind();
                    //显示单价
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
            }
            if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
            {
                customNum = Request.QueryString["customNum"].ToString();
                CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customNum);
                if (mod != null)
                {
                    lblCompanyName.Text = mod.CompanyName;
                    if (mod.IsShowPrice == 0)   //显示
                    {
                        div1.Visible = false;
                        div2.Visible = true;
                    }
                    else   //不显示
                    {
                        div1.Visible = true;
                        div2.Visible = false;
                    }
                }
                else
                {
                    div1.Visible = true;
                    div2.Visible = false;
                }
            }
            //产品型号
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
            }
            //打印时间
            lblPrintTime.Value = DateTime.Now.ToShortDateString();

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
            //Label hiddProNum = (Label)repeaterItem.FindControl("hiddProNum");
            //hiddProNum.Text = textBox.Text.Trim();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('请正确填写数量！')", true);
        }
    }

    /// <summary>
    /// 预览
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        bool result = true;
        if (div1.Visible == true)
        {
            List<PrevProductMOD> list = new List<PrevProductMOD>();
            for (int i = 0; i < rptPro.Items.Count; i++)
            {
                PrevProductMOD mod = new PrevProductMOD();
                Label lblProType = this.rptPro.Items[i].FindControl("lblProType") as Label;
                Label lblPrice = this.rptPro.Items[i].FindControl("lblPrice") as Label;
                TextBox txtProNum = this.rptPro.Items[i].FindControl("txtProNum") as TextBox;
               // Label lblTotalPrice = this.rptPro.Items[i].FindControl("lblTotalPrice") as Label;
                Label lblBianbi = this.rptPro.Items[i].FindControl("lblBianbi") as Label;
                TextBox txtRemark = this.rptPro.Items[i].FindControl("txtRemark") as TextBox;
                //if (txtProNum != null && txtProNum.Text.Trim() != ""&&txtProNum.Text.Trim()!="0")
                //{
                mod.Beizhu = txtRemark.Text;
                mod.Bianbi = lblBianbi.Text;
                mod.Danjia = lblPrice.Text;
                mod.Danwei = "PCS";
                if (txtProNum.Text.Trim() != "")
                {
                    mod.Jine = (Convert.ToInt32(txtProNum.Text.Trim()) * Convert.ToDecimal(lblPrice.Text.Trim())).ToString();
                }
                else
                {
                    mod.Jine = "0.00";
                }
                mod.ProName = "互感器<br />Transformers";
                mod.ProNum = txtProNum.Text;
                mod.ProType = lblProType.Text;
                mod.SuiGongDanNum = Request.QueryString["withWorkNo"].ToString();
                list.Add(mod);
                //}
            }

            Session["SendList"] = list;

            if (result)
            {
                Response.Redirect("PrevSendList.aspx?orderNum=" + orderNum + "&customerNo=" + customNum + "&proType=" + proType + "&withWorkNo=" + withWorkNo + "&sendTime=" + lblPrintTime.Value.Trim());
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('您输入的信息有误！');", true);
            }
        }
        else
        {
            List<PrevProductMOD> list = new List<PrevProductMOD>();
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                PrevProductMOD mod = new PrevProductMOD();
                Label lblProType = this.Repeater1.Items[i].FindControl("lblProType") as Label;
                Label lblPrice = this.Repeater1.Items[i].FindControl("lblPrice") as Label;

                Label lblTotalPrice = this.Repeater1.Items[i].FindControl("lblTotalPrice") as Label;
                Label lblBianbi = this.Repeater1.Items[i].FindControl("lblBianbi") as Label;
                TextBox txtProNum = this.Repeater1.Items[i].FindControl("txtProNum") as TextBox;

                TextBox txtRemark = this.Repeater1.Items[i].FindControl("txtRemark") as TextBox;
                //if (txtProNum != null && txtProNum.Text.Trim() != ""&&txtProNum.Text.Trim()!="0")
                //{
                mod.Beizhu = txtRemark.Text;
                mod.Bianbi = lblBianbi.Text;
                mod.Danjia = lblPrice.Text;
                mod.Danwei = "PCS";
                if (txtProNum.Text.Trim() != "")
                {
                    mod.Jine = (Convert.ToInt32(txtProNum.Text.Trim()) * Convert.ToDecimal(lblPrice.Text.Trim())).ToString();
                }
                else
                {
                    mod.Jine = "0.00";
                }
                mod.ProName = "互感器<br />Transformers";
                mod.ProNum = txtProNum.Text;
                mod.ProType = lblProType.Text;
                list.Add(mod);
                // }
            }
            Session["SendList"] = list;
            if (result)
            {
                Response.Redirect("PrevSendList.aspx?orderNum=" + orderNum + "&customerNo=" + customNum + "&proType=" + proType + "&withWorkNo=" + withWorkNo + "&sendTime=" + lblPrintTime.Value.Trim());
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('您输入的信息有误！');", true);
            }
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
        ProductsMOD MOD = ProductsBLL.GetModel(proType);
        if (MOD != null)
        {
            bianbi = MOD.bian;
        }
        return bianbi;
    }
}