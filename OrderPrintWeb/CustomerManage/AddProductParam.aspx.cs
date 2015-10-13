using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Modules;
using OrderPrintSystem.BLL;
using System.Web.Services;
using OrderPrintSystem.Model;

public partial class CustomerManage_ProductParam : PageBase
{
    ProductParamMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                mod = ProductParamBLL.GetmodByid(id);
                if (mod != null)
                {
                    //加载客户信息
                    txtcustomerNo.Text = mod.CustomNo;
                    txtparamContent.Text = mod.ParamContent;
                    txtproductNO.Text = mod.ProductNo;
                    txtWuliaobian.Text = mod.Wuliaobian;
                    if (mod.IsWriteFahuoInfo != null && mod.IsWriteFahuoInfo.ToString() != "")
                    {
                        switch (mod.IsWriteFahuoInfo)
                        {
                            case 0:
                                rdoCusYes.Checked = false;
                                rdoCusNo.Checked = true;
                                break;
                            case 1:

                                rdoCusYes.Checked = true;
                                rdoCusNo.Checked = false;
                                break;
                            default:
                                rdoCusYes.Checked = false;
                                rdoCusNo.Checked = false;
                                break;
                        }
                    }
                    else
                    {
                        rdoCusYes.Checked = false;
                        rdoCusNo.Checked = false;
                    }
                    if (mod.IsWriteXianChang != null && mod.IsWriteXianChang.ToString() != "")
                    {
                        switch (mod.IsWriteXianChang)
                        {
                            case 0:
                                rdoProYes.Checked = false;
                                rdoProNo.Checked = true;

                                break;
                            case 1:
                                rdoProYes.Checked = true;
                                rdoProNo.Checked = false;
                                break;
                            default:
                                rdoProYes.Checked = false;
                                rdoProNo.Checked = false;
                                break;
                        }
                    }
                    else
                    {
                        rdoProYes.Checked = false;
                        rdoProNo.Checked = false;
                    }
                }
                //客户编号不允许修改
                txtcustomerNo.Enabled = false;
                txtproductNO.Enabled = false;
            }
        }
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        int num = 0;

        if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            mod = ProductParamBLL.GetmodByid(id);
            mod.ParamContent = txtparamContent.Text.Trim();
            if (rdoCusYes.Checked)
            {
                mod.IsWriteFahuoInfo = 1;
            }
            else
            {
                mod.IsWriteFahuoInfo = 0;
            }
            if (rdoProYes.Checked)
            {
                mod.IsWriteXianChang = 1;
            }
            else
            {
                mod.IsWriteXianChang = 0;
            }
            mod.Wuliaobian = txtWuliaobian.Text.Trim();
            num = ProductParamBLL.Updatemod(mod);
        }
        else
        {
            mod = ProductParamBLL.GetmodByid(txtcustomerNo.Text.Trim(), txtproductNO.Text.Trim());
            if (mod != null)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('该客户的产品参数已存在！');", true);
                return;
            }
            else
            {
                mod = new ProductParamMOD();
                mod.CustomNo = txtcustomerNo.Text.Trim();
                mod.ParamContent = txtparamContent.Text.Trim();
                mod.ProductNo = txtproductNO.Text.Trim();
                mod.Wuliaobian = txtWuliaobian.Text.Trim();
                if (rdoCusYes.Checked)
                {
                    mod.IsWriteFahuoInfo = 1;
                }
                else
                {
                    mod.IsWriteFahuoInfo = 0;
                }
                if (rdoProYes.Checked)
                {
                    mod.IsWriteXianChang = 1;
                }
                else
                {
                    mod.IsWriteXianChang = 0;
                }
                num = ProductParamBLL.Insertmod(mod);
            }
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('CustomerManage/ProductParamManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
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

    /// <summary>
    /// 判断产品型号是否存在
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    [WebMethod]
    public static int isExistProType(string proType)
    {
        int num = 0;
        ProductsMOD mod = ProductsBLL.GetModel(proType);
        if (mod != null)
        {
            num = 1;
        }
        return num;
    }
    /// <summary>
    /// 是否填写客户信息
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    [WebMethod]
    public static string isAdd(string customNum)
    {
        string num = "";
        CustomerManageMod customerMod = CustomerManageBLL.GetcustomerByid(customNum.Trim());
        if (customerMod != null)
        {
            if (customerMod.IsAddInfo.ToString() != "")
            {
                num = customerMod.IsAddInfo.ToString();
            }
        }
        return num;
    }
}