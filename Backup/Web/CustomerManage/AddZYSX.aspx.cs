using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Modules;
using System.Data;
using OrderPrintSystem.BLL;
using System.Web.Services;

public partial class CustomerManage_AddZYSX : PageBase
{
    string strWhere = "";
    string customerNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                customerNo = Request.QueryString["customerNo"].ToString();
                MattersNeedingAttentionMOD mod = MattersNeedingAttentionBLL.GetmodByid(customerNo);
                if (mod != null)
                {
                    txtCustomerNo.Text = customerNo;
                    txtContents.Text = mod.Contents; txtCustomerNo.Enabled = false;
                }
            }
            else
            {
                txtCustomerNo.Enabled = true;
            }
        }
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, EventArgs e)
    {
        int num = 0;
        if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
        {
            customerNo = Request.QueryString["customerNo"].ToString();
            MattersNeedingAttentionMOD mod = MattersNeedingAttentionBLL.GetmodByid(customerNo);
            if (mod != null)
            {
                mod.Contents = txtContents.Text;
                num = MattersNeedingAttentionBLL.Updatemod(mod);
            }
        }
        else
        {
            MattersNeedingAttentionMOD mod = new MattersNeedingAttentionMOD();

            mod.CustomerNo = txtCustomerNo.Text.Trim();
            mod.Contents = txtContents.Text.Trim();
            num = MattersNeedingAttentionBLL.Insertmod(mod);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('CustomerManage/ZYSXManage.aspx')", true);

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交失败');", true);
        }
    }
    /// <summary>
    /// 判断客户编号是否存在
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns></returns>
    [WebMethod]
    public static int isExistCustom(string customerNum)
    {
        int num = 0;
        CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customerNum);
        if (mod != null)
        {
            num = 1;
        }
        return num;
    }

    [WebMethod]
    public static int isExistCustomZYSX(string customerNum)
    {
        int num = 0;
        MattersNeedingAttentionMOD mod = MattersNeedingAttentionBLL.GetmodByid(customerNum);
        if (mod != null)
        {
            num = 1;
        }
        return num;
    }
}