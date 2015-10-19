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

public partial class orderManage_PrintBZBQ : PageBase
{
    public string htmlStr = "";
    public static string orderNum = "";
    public static string proNum = "";
    string customNum = "";
    string proType = "";
    CustomerManageMod customerMod = null;
    ProductsMOD productMod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (true || Session["songhuodan"] == null)
            {

                string isFahuo = "1";// Session["songhuodan"].ToString();
                if (isFahuo == "1")
                {

                    Session["songhuodan"] = "";
                    if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
                    {
                        orderNum = Request.QueryString["orderNum"].ToString();
                    }
                    if (Request.QueryString["proNum"] != null && Request.QueryString["proNum"].ToString() != "")
                    {
                        proNum = Request.QueryString["proNum"].ToString();
                    }
                    if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
                    {
                        proType = Request.QueryString["proType"].ToString();
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

                        var countN = 0;
                        var countW = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string proType = ds.Tables[0].Rows[i]["proType"].ToString();
                            ProductParamMOD paramMod = ProductParamBLL.GetmodByid(customNum, proType);
                            //    string proNum = ds.Tables[0].Rows[i]["proNum"].ToString();
                            object obj = SendDetailBLL.GetSendCountByProType(proType, orderNum);
                            if (obj != null)
                            {
                                proNum = obj.ToString();
                            }
                            if (proNum != "")
                            {
                                //根据产品型号和数量计算出外包装盒和内包装盒标签个数
                                int neiCount = 0;
                                int waiCount = 0;
                                productMod = ProductsBLL.GetModel(proType);
                                string nei = "";
                                string wai = "";

                                if (productMod != null)
                                {
                                    nei = productMod.NeiBZ;   //内包装盒的产品数
                                    wai = productMod.waiBZ.ToString();  //外包装盒里面内包装盒个数

                                    if (productMod.NeiBZ == "0")
                                    {
                                        //htmlStr += productMod.productName+ "内包装盒的产品数为0，系统无法计算内包装盒数量，请重新设置该产品内包装盒的产品数！";
                                        continue;
                                    }
                                    if (productMod.waiBZ == 0)
                                    {
                                        //htmlStr += productMod.productName+"外包装盒里面内包装盒个数为0，系统无法计算外包装盒数量，请重新设置外包装盒里面内包装盒个数！";
                                        continue;
                                    }

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
                                htmlStr += "<table cellpadding='0' cellspacing='0' align='center'><tr><td>";
                                //  htmlStr += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px;' align='center'><tr><td colspan='2'>内包装盒标签</tr></td></table>";

                                var htmlStrN = "";
                                var htmlStrW = "";

                                for (int j = 0; j < neiCount; j++)
                                {
                                    int num = 0;
                                    if (j == neiCount - 1)
                                    {
                                        num = Convert.ToInt32(proNum) - (Convert.ToInt32(nei) * (neiCount - 1));
                                    }
                                    else
                                    {
                                        num = Convert.ToInt32(nei);
                                    }
                                    if (j % 2 == 0)
                                    {
                                        htmlStrN += "<td/><tr/><tr><td>";
                                    }
                                    else
                                    {
                                        htmlStrN += "<td/><td>";
                                    }
                                    htmlStrN += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px;padding-left:10px;padding-right:10px; border: 1px solid #000;margin-right:10px;' align='center'>";
                                    htmlStrN += "<tr><td colspan='2' align='center'>内包装盒标签</td></tr>";
                                    if (customerMod != null)
                                    {
                                        htmlStrN += "<tr><td style='width:120px;'>客户名称：<br />Customer name</td><td style='font-size:12px;'>" + customerMod.CompanyName + "</td></tr>";
                                    }
                                    else
                                    {
                                        htmlStrN += "<tr><td style='width:120px;'>客户名称：<br />Customer name</td><td></td></tr>";
                                    }
                                    htmlStrN += " <tr><td>型号：<br />Model number </td><td>" + proType + "</td></tr>";
                                    htmlStrN += "<tr><td>规格参数：<br />Parameters </td><td>" + productMod.bian + "</td></tr>";
                                    htmlStrN += " <tr><td>数    量：<br /> Quantity</td><td>" + num + "</td></tr>";
                                    htmlStrN += "<tr><td>封 装 日 期：<br />Packaging date</td><td>" + DateTime.Now.ToShortDateString() + "</td></tr>";
                                    htmlStrN += "</table>";

                                    countN++;
                                    if (countN % 8 == 0)
                                    {
                                        htmlStrN += "<div style='page-break-after:always;'>分页</div>";
                                    }
                                }
                                //  htmlStr += "<table cellpadding='0' cellspacing='0' style='width: 300px; margin-top: 10px;' align='center'><tr><td colspan='2'>外包装盒标签</tr></td></table>";
                                //外包装标签
                                // htmlStr += "<div style='clear:both;'><div/>";


                                for (int k = 0; k < waiCount; k++)
                                {
                                    string waiNUM = "";
                                    if (k == waiCount - 1)
                                    {
                                        // waiNUM = neiCount - (Convert.ToInt32(wai) * (waiCount - 1));   //剩余内包装盒

                                        waiNUM = neiCount - (Convert.ToInt32(wai) * (waiCount - 1)) + "盒(" + (Convert.ToInt32(proNum) - (Convert.ToInt32(wai) * (waiCount - 1) * Convert.ToInt32(nei))) + "PCS)";
                                    }
                                    else
                                    {
                                        waiNUM = Convert.ToInt32(wai) + "盒(" + (Convert.ToInt32(wai) * Convert.ToInt32(nei)) + "PCS)";  //如果是整除 数量为内包装盒个数
                                    }
                                    if (k % 2 == 0)
                                    {
                                        htmlStrW += "<td/><tr/><tr><td>";
                                    }
                                    else
                                    {
                                        htmlStrW += "<td/><td>";
                                    }
                                    htmlStrW += "<table cellpadding='0' cellspacing='0' style='width: 300px;padding-left:10px;padding-right:10px; margin-top: 10px; border: 1px solid #000; margin-right:10px;' align='center'>";
                                    htmlStrW += "<tr><td colspan='2' align='center'>外包装盒标签</td></tr>";
                                    if (customerMod != null)
                                    {
                                        htmlStrW += "<tr><td style='width:140px;'>客户名称：<br />Customer name</td><td style='font-size:12px;'>" + customerMod.CompanyName + "</td></tr>";
                                    }
                                    else
                                    {
                                        htmlStrW += "<tr><td style='width:140px;'>客户名称：<br />Customer name</td><td></td></tr>";
                                    }
                                    htmlStrW += " <tr><td>型号：<br />Model number </td><td>" + proType + "</td></tr>";
                                    htmlStrW += "<tr><td>规格参数：<br />Parameters </td><td>" + productMod.bian + "</td></tr>";
                                    htmlStrW += " <tr><td>数    量：<br /> Quantity</td><td>" + waiNUM + "</td></tr>";
                                    htmlStrW += "<tr><td>合同编号：<br /> Contract No.</td><td>" + proOrderMOD.heTongNum + "</td></tr>";
                                    if (paramMod != null)
                                    {
                                        htmlStrW += "<tr> <td>物料编号：<br />Material Code</td><td>" + paramMod.Wuliaobian + "</td></tr>";
                                    }
                                    else
                                    {
                                        htmlStrW += "<tr> <td>物料编号：<br />Material Code</td><td></td></tr>";
                                    }
                                    htmlStrW += "<tr><td>客户单号：<br />Purchase order No.</td><td>" + proOrderMOD.customOrderNum + "</td></tr>";
                                    htmlStrW += "<tr><td>供应商名称：<br />Vendor Company</td><td>北京霍远科技</td></tr>";
                                    htmlStrW += "<tr><td>件      数：<br />Number of packages</td><td>" + waiCount + "-" + (k + 1) + "</td></tr>";
                                    htmlStrW += "</table>";
                                    countW++;
                                    if (countW % 4 == 0)
                                    {
                                        htmlStrW += "<div style='page-break-after:always;'>分页</div>";
                                    }
                                }
                                htmlStr += htmlStrN;
                                htmlStr += "<div style='page-break-after:always;'>分页</div>";
                                htmlStr += htmlStrW;

                                htmlStr += "</table>";
                            }
                        }
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

            DataSet ds = SendDetailBLL.GetmodAll(" and orderNum='" + orderNum + "'");
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