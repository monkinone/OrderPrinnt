using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_AddOrder : System.Web.UI.Page
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
                orderMod.customWLBH = txtcustomWLBH.Text.Trim();
                orderMod.editTime = DateTime.Now;
                orderMod.heTongNum = txtheTongNum.Text.Trim();
                orderMod.orderNum = txtorderNum.Text.Trim();
                orderMod.remark = txtremark.Text.Trim();


                //添加订单详细

                string[] xinghao = Request.Params.GetValues("proType");
                string[] shuliang = Request.Params.GetValues("proNum");
                string[] danjia = Request.Params.GetValues("ProPrice");

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
                                orderDetailMOD.proNum = Convert.ToInt32(shuliang[i].Trim());
                                orderDetailMOD.ProPrice = Convert.ToDecimal(danjia[i].Trim());
                                orderDetailMOD.proType = xinghao[i].Trim();
                                if (!(ProOrdersDetailBLL.Add(orderDetailMOD) > 0))
                                {
                                    flag2 = false;
                                    break;
                                }
                            }
                        }
                        if (flag2)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
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
}