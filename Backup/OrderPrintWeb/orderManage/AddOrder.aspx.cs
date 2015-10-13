using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsSystem.DBUtility;


public partial class orderManage_AddOrder : PageBase
{
    ProOrdersMOD orderMod = null;
    ProOrdersDetailMOD orderDetailMOD = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        int num = 0;

        if (Int32.Parse(SqlHelper.GetSingle(string.Format("select count(1) from proOrders where orderNum='{0}'", txtcustomOrderNum.Text)).ToString()) > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('" + "订单号已存在！');DetailsPageControl.CloseBox();DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
            return;
        }


        if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            // num = ProductParamBLL.Updatemod(mod);
        }
        else
        {
            orderMod = new ProOrdersMOD();
            orderDetailMOD = new ProOrdersDetailMOD();
            try
            {
                //订单基本信息
                orderMod.customManager = txtcustomManager.Text.Trim();
                orderMod.customNum = txtcustomNum.Text.Trim();
                orderMod.customOrderNum = txtcustomOrderNum.Text.Trim();
                orderMod.customWLBH = "";// txtcustomWLBH.Text.Trim();
                orderMod.editTime = DateTime.Now;
                orderMod.heTongNum = txtheTongNum.Text.Trim();
                orderMod.orderNum = txtorderNum.Text.Trim();
                orderMod.remark = txtremark.Text.Trim();
                orderMod.ShuChuXianchang = "";// txtshuChuXianchang.Text.Trim();
                orderMod.ShuRuXianchang = "";// txtshuRuXianchang.Text.Trim();

                //添加订单详细

                string[] xinghao = Request.Params.GetValues("proType");
                string[] shuliang = Request.Params.GetValues("proNum");
                string[] danjia = Request.Params.GetValues("ProPrice");
                string[] wuliaobian = Request.Params.GetValues("wuliaobian");
                string errmsg = "";
                int errorCount = 0;
                //判断是否有填写产品信息
                if (xinghao.Length < 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "DDGL", "alert('您还没有填写产品信息！')", true);
                }
                else
                {
                    int flag = ProOrdersBLL.Add(orderMod);
                    if (flag > 0)
                    {
                        bool flag2 = true;

                        for (int i = 0; i < xinghao.Length; i++)
                        {
                            orderDetailMOD.orderNum = txtorderNum.Text.Trim();
                            if (Convert.ToInt32(shuliang[i]) > 0)
                            {
                                ProductParamMOD paramMod = ProductParamBLL.GetmodByid(txtcustomNum.Text.Trim(), xinghao[i].Trim());
                                if (paramMod != null)
                                {
                                    orderDetailMOD.proNum = Convert.ToInt32(shuliang[i].Trim());
                                    orderDetailMOD.ProPrice = Convert.ToDecimal(danjia[i].Trim());
                                    orderDetailMOD.proType = xinghao[i].Trim();
                                    //orderDetailMOD.Wuliaobian = wuliaobian[i].Trim();
                                    if (!(ProOrdersDetailBLL.Add(orderDetailMOD) > 0))
                                    {
                                        flag2 = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    errmsg += xinghao[i].Trim() + ",";
                                    errorCount++;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (flag2)
                        {
                            string isShow = "";
                            if (xinghao.Length - errorCount > 0)
                            {
                                DataSet ds = CustomerManageBLL.GetcustomerAll(" and customerNo='" + txtcustomNum.Text.Trim() + "'");
                                if (ds != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    isShow = ds.Tables[0].Rows[0]["isFanben"].ToString();
                                }
                                if (isShow != "0")
                                {
                                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');print();", true);
                                    if (errmsg == "")
                                    {
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
                                        Response.Redirect("Contract.aspx?customerNo=" + txtcustomNum.Text.Trim() + "&orderNum=" + txtorderNum.Text.Trim());
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('" + errmsg + "没有维护产品参数提交失败，其余添加成功！');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');print();", true);
                                        //  Response.Redirect("Contract.aspx?customerNo=" + txtcustomNum.Text.Trim() + "&orderNum=" + txtorderNum.Text.Trim());
                                    }
                                }
                                else
                                {
                                    if (errmsg == "")
                                    {
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('" + errmsg + "没有维护产品参数提交失败，其余添加成功！');DetailsPageControl.CloseBox();DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
                                    }
                                }
                            }
                            else
                            {
                                ProOrdersDetailBLL.Delete(txtorderNum.Text.Trim());
                                ProOrdersBLL.Delete(txtorderNum.Text.Trim());
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('您没有要添加的型号，添加失败！')", true);
                            }
                        }
                        else
                        {
                            ProOrdersDetailBLL.Delete(txtorderNum.Text.Trim());
                            ProOrdersBLL.Delete(txtorderNum.Text.Trim());
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('添加失败！')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "BGYPSQLB", "alert('添加失败！')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('添加失败！')", true);
            }
        }

    }

    /// <summary>
    /// 获取单价
    /// </summary>
    /// <param name="customerNum">客户编号</param>
    /// <param name="proType">产品型号</param>
    /// <returns></returns>
    [WebMethod]
    public static string GetPrice(string customerNum, string proType)
    {
        string price = "";
        DataSet ds = PriceManageBLL.GetmodAll(" and customNo='" + customerNum + "' and productNo='" + proType + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            price = ds.Tables[0].Rows[0]["price"].ToString();
        }
        return price;
    }
    /// <summary>
    /// 根据客户编号控制打印合同按钮是否显示
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns></returns>
    [WebMethod]
    public static string IsShowPrint(string customerNum)
    {
        string isShow = "";
        DataSet ds = CustomerManageBLL.GetcustomerAll(" and customerNo='" + customerNum + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            isShow = ds.Tables[0].Rows[0]["isFanben"].ToString();
        }
        return isShow;
    }
    /// <summary>
    /// 判断订单编号是否存在
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns></returns>
    [WebMethod]
    public static int isExistOrderNum(string orderNum)
    {
        int num = 0;
        ProOrdersMOD mod = ProOrdersBLL.GetModel(orderNum);
        if (mod != null)
        {
            num = 1;
        }
        return num;
    }
    [WebMethod]
    public static string GetHetongTishi(string customerNum)
    {
        string str = "";
        CustomerManageMod customer = CustomerManageBLL.GetcustomerByid(customerNum);
        if (customer != null)
        {
            if (customer.IsFanben == 0)
            {
                str = "本客户自己提供合同模板，请使用签订客户合同";
            }
        }
        return str;
    }

    /// <summary>
    /// 判断客户编号是否存在
    /// </summary>
    /// <param name="customerNum"></param>
    /// <returns></returns>
    [WebMethod]
    public static string isExistCustom(string customerNum)
    {
        string huikuan = "无";
        CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customerNum);
        if (mod != null)
        {
            huikuan = mod.BackMethod;
        }
        return huikuan;
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

    [WebMethod]
    public static string isAddXianchang(string customerNum, string proType)
    {
        ProductParamMOD mod = ProductParamBLL.GetmodByid(customerNum, proType);
        if (mod != null)
        {
            return mod.IsWriteFahuoInfo + "," + mod.IsWriteXianChang;
        }
        else
        {
            return "";
        }
    }
}