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
using System.Web.Services;

public partial class orderManage_PrintBZBQ : System.Web.UI.Page
{
    public string htmlStr = "";
    public static string orderNum = "";
    string customNum = "";
    CustomerManageMod customerMod = null;
    ProductsMOD productMod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
            }
            if (Request.QueryString["customNum"] != null && Request.QueryString["customNum"].ToString() != "")
            {
                customNum = Request.QueryString["customNum"].ToString();
                customerMod = new CustomerManageMod();
                customerMod = CustomerManageBLL.GetcustomerByid(customNum);
            }
            string strOrderDetail = " and orderNum='" + orderNum + "'";
            ProOrdersMOD proOrderMOD = ProOrdersBLL.GetModel(orderNum);
            DataSet ds = ProOrdersDetailBLL.GetList(strOrderDetail);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string proType = ds.Tables[0].Rows[i]["proType"].ToString();
                    string proNum = ds.Tables[0].Rows[i]["proNum"].ToString();


                    //根据产品型号和数量计算出外包装盒和内包装盒标签个数
                    int neiCount = 0;
                    int waiCount = 0;
                    productMod = ProductsBLL.GetModel(proType);
                    string nei = "";
                    string wai = "";
                    if (productMod != null)
                    {
                        nei = productMod.NeiBZ;
                        wai = productMod.waiBZ.ToString();
                        if (Convert.ToInt32(proNum) % Convert.ToInt32(nei) == 0)
                        {
                            neiCount = Convert.ToInt32(proNum) / Convert.ToInt32(nei);
                        }
                        else
                        {
                            neiCount = (Convert.ToInt32(proNum) / Convert.ToInt32(nei)) + 1;
                        }

                        if (neiCount % Convert.ToInt32(wai) == 0)
                        {
                            waiCount = neiCount / Convert.ToInt32(wai);
                        }
                        else
                        {
                            waiCount = (neiCount / Convert.ToInt32(wai)) + 1;
                        }
                    }
                    //内包装标签

                    //  htmlStr += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px;' align='center'><tr><td colspan='2'>内包装盒标签</tr></td></table>";
                    for (int j = 0; j < neiCount; j++)
                    {
                        int num = 0;
                        if (Convert.ToInt32(proNum) % Convert.ToInt32(nei) == 0)
                        {
                            num = Convert.ToInt32(nei);
                        }
                        else
                        {
                            num = (Convert.ToInt32(proNum) % Convert.ToInt32(nei));
                        }

                        htmlStr += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px; border: 1px solid #808080' align='center'>";
                        htmlStr += "<tr><td colspan='2' align='center'>内包装盒标签</td></tr>";
                        htmlStr += "<tr><td>客户名称：<br />Customer name</td><td>" + customerMod.CompanyName + "</td></tr>";
                        htmlStr += " <tr><td>型号：<br />Model number </td><td>" + proType + "</td></tr>";
                        htmlStr += "<tr><td>规格参数：<br />Parameters </td><td>" + productMod.bian + "</td></tr>";
                        htmlStr += " <tr><td>数    量：<br /> Quantity</td><td>" + num + "</td></tr>";
                        htmlStr += "<tr><td>封 装 日 期：<br />Packaging date</td><td>" + DateTime.Now.ToShortDateString() + "</td></tr>";
                        htmlStr += "</table>";
                    }
                    htmlStr += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px;' align='center'><tr><td colspan='2'>外包装盒标签</tr></td></table>";
                    //外包装标签
                    for (int k = 0; k < waiCount; k++)
                    {
                        int num = 0;
                        if (neiCount % Convert.ToInt32(wai) == 0)
                        {
                            num = Convert.ToInt32(wai) * Convert.ToInt32(nei);  //如果是整除 产品数量为内包装个数*每个内包装里的产品数

                        }
                        else
                        {
                            num = (neiCount % Convert.ToInt32(wai)) * Convert.ToInt32(nei);  //如果不整除 产品数量为外包装盒和内包装盒取余*每个内包装盒里的产品数
                        }
                        htmlStr += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px; border: 1px solid #808080' align='center'>";
                        htmlStr += "<tr><td colspan='2' align='center'>外包装盒标签</td></tr>";
                        htmlStr += "<tr><td>客户名称：<br />Customer name</td><td>" + customerMod.CompanyName + "</td></tr>";
                        htmlStr += " <tr><td>型号：<br />Model number </td><td>" + proType + "</td></tr>";
                        htmlStr += "<tr><td>规格参数：<br />Parameters </td><td>" + productMod.bian + "</td></tr>";
                        htmlStr += " <tr><td>数    量：<br /> Quantity</td><td>" + num + "</td></tr>";
                        htmlStr += "<tr><td>合同编号：<br /> Contract No.</td><td>" + proOrderMOD.heTongNum + "</td></tr>";
                        htmlStr += "<tr> <td>物料编号：<br />Material Code</td><td>" + proOrderMOD.customWLBH + "</td></tr>";
                        htmlStr += "<tr><td>客户单号：<br />Purchase order No.</td><td>" + proOrderMOD.customOrderNum + "</td></tr>";
                        htmlStr += "<tr><td>供应商名称：<br />Vendor Company</td><td>北京霍远科技</td></tr>";
                        htmlStr += "<tr><td>件      数：<br />Number of packages</td><td>" + waiCount + "</td></tr>";
                        htmlStr += "</table>";
                    }
                }
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
        int num = 0;
        try
        {

            DataSet ds = SendDetailBLL.GetmodAll(" and orderNum='"+orderNum+"'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProOrdersDetailBLL.UpdatePrintInfo(orderNum, ds.Tables[0].Rows[i]["proType"].ToString(), "printBZBQTime", "printBZBQCount");
                }
                num = 1;
            }
            else
            {
                num = 0;
            }
        }
        catch (Exception ex)
        {
            num = 0;
        }
        return num;
    }
}