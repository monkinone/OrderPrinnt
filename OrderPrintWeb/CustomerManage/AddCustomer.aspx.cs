using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System.Web.Services;

public partial class CustomerManage_AddCustomer : PageBase
{
    CustomerManageMod customer = null;
    public static int cusId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {

                int id = Convert.ToInt32(Request.QueryString["id"]);
                cusId = id;
                customer = CustomerManageBLL.GetcustomerByid(id);
                if (customer != null)
                {
                    //加载客户信息
                    txtbackMethod.Text = customer.BackMethod;
                    txtcompanyAddress.Text = customer.CompanyAddress;
                    txtcompanyName.Text = customer.CompanyName;
                    txtcontacts.Text = customer.Contacts;
                    txtcustomerNo.Text = customer.CustomerNo;
                    txtdescription.Text = customer.Description;
                    txtdiscount.Text = customer.Discount.ToString();
                    txtInvoiceMethod.Text = customer.InvoiceMethod;
                    txtZhangHao.Text = customer.ZhangHao;
                    txtShuiHao.Text = customer.ShuiHao;
                    switch (customer.IsFanben)
                    {
                        case 0:
                            rdoIsFanbenYes.Checked = true;
                            rdoIsFanbenNo.Checked = false;
                            break;
                        case 1:
                            rdoIsFanbenNo.Checked = true;
                            rdoIsFanbenYes.Checked = false;
                            break;
                    }
                    switch (customer.IsShowPrice)
                    {
                        case 0:
                            rdoIsShowPriceYes.Checked = true;
                            rdoIsShowPriceNo.Checked = false;
                            break;
                        case 1:
                            rdoIsShowPriceNo.Checked = true;
                            rdoIsShowPriceYes.Checked = false;
                            break;
                    }
                    if (customer.IsAddInfo.ToString() != "")
                    {
                        switch (customer.IsAddInfo)
                        {
                            case 0:
                                rdoIsNotAdd.Checked = true;
                                rdoIsAdd.Checked = false;
                                break;
                            case 1:
                                rdoIsNotAdd.Checked = false;
                                rdoIsAdd.Checked = true;
                                break;
                        }
                    }
                    txtmodifyPriceRecord.Text = customer.ModifyPriceRecord;
                    txtotherDangAn.Text = customer.OtherDangAn;
                    txtphone.Text = customer.Phone;
                    txtposition.Text = customer.Position;
                    txttax.Text = customer.Tax;
                    txttelPhone.Text = customer.TelPhone;

                }
                //客户编号不允许修改
                txtcustomerNo.Enabled = false;
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
            customer = CustomerManageBLL.GetcustomerByid(id);
            customer.BackMethod = txtbackMethod.Text.Trim();
            customer.CompanyAddress = txtcompanyAddress.Text.Trim();
            customer.CompanyName = txtcompanyName.Text.Trim();
            customer.Contacts = txtcontacts.Text.Trim();
            customer.Description = txtdescription.Text.Trim();

            customer.Discount = txtdiscount.Text.Trim();

            customer.InvoiceMethod = txtInvoiceMethod.Text.Trim();
            customer.IsFanben = rdoIsFanbenYes.Checked ? 0 : 1;
            customer.IsShowPrice = rdoIsShowPriceYes.Checked ? 0 : 1;
            customer.ModifyPriceRecord = txtmodifyPriceRecord.Text.Trim();
            customer.OtherDangAn = txtotherDangAn.Text.Trim();
            customer.Phone = txtphone.Text.Trim();
            customer.Position = txtposition.Text.Trim();
            customer.Tax = txttax.Text.Trim();
            customer.TelPhone = txttelPhone.Text.Trim();
            customer.ShuiHao = txtShuiHao.Text.Trim();
            customer.ZhangHao = txtZhangHao.Text.Trim();
            if (rdoIsAdd.Checked == true)
            {
                customer.IsAddInfo = 1;
            }
            else
            {
                customer.IsAddInfo = 0;
            }
            num = CustomerManageBLL.Updatecustomer(customer);
        }
        else
        {
            customer = new CustomerManageMod();
            customer.CustomerNo = txtcustomerNo.Text.Trim();
            customer.BackMethod = txtbackMethod.Text.Trim();
            customer.CompanyAddress = txtcompanyAddress.Text.Trim();
            customer.CompanyName = txtcompanyName.Text.Trim();
            customer.Contacts = txtcontacts.Text.Trim();
            customer.Description = txtdescription.Text.Trim();

            customer.Discount = txtdiscount.Text.Trim();

            customer.InvoiceMethod = txtInvoiceMethod.Text.Trim();
            customer.IsFanben = rdoIsFanbenYes.Checked ? 0 : 1;
            customer.IsShowPrice = rdoIsShowPriceYes.Checked ? 0 : 1;
            customer.ModifyPriceRecord = txtmodifyPriceRecord.Text.Trim();
            customer.OtherDangAn = txtotherDangAn.Text.Trim();
            customer.Phone = txtphone.Text.Trim();
            customer.Position = txtposition.Text.Trim();
            customer.Tax = txttax.Text.Trim();
            customer.TelPhone = txttelPhone.Text.Trim();
            customer.ShuiHao = txtShuiHao.Text.Trim();
            customer.ZhangHao = txtZhangHao.Text.Trim();
            if (rdoIsAdd.Checked == true)
            {
                customer.IsAddInfo = 1;
            }
            else
            {
                customer.IsAddInfo = 0;
            }
            num = CustomerManageBLL.Insertcustomer(customer);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('CustomerManage/CustomerManage.aspx');", true);
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
    [WebMethod]
    public static int isExistCusName(string companyName)
    {
        int num = 0;
        if (cusId == 0)
        {
            CustomerManageMod mod = CustomerManageBLL.GetcustomerByName(companyName);
            if (mod != null)
            {
                num = 1;
            }
        }
        return num;
    }
}