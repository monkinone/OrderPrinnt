using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;

namespace Web.orderManage
{
    public partial class DetailSGD : System.Web.UI.Page
    {
        ProOrdersMOD orderMod = null;
        ProOrdersDetailMOD orderDetail = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string suigongdan = Request.QueryString["suigongdan"];//随工单号
                string PrintCount = Request.QueryString["PrintCount"];//随工单打印数量
                string orderNum = Request.QueryString["orderNum"];//订单编号
                string proType = Request.QueryString["proType"];//产品型号
                if (!string.IsNullOrEmpty(orderNum)&&!string.IsNullOrEmpty(proType))
                {
                    string strWhere = string.Format(" and orderNum='{0}' and proType='{1}' ",orderNum,proType);
                    orderDetail = ProOrdersDetailBLL.GetModelByWhere(strWhere);

                    if (orderDetail != null)
                    {
                        lblpiHao.Text = orderDetail.PiHao;
                        try
                        {
                            if (orderDetail.PlanSendTime != null && Convert.ToDateTime(orderDetail.PlanSendTime).ToString("yyyy-MM-dd") != "0001-01-01")
                            {
                                lblplanSendTime.Text = Convert.ToDateTime(orderDetail.PlanSendTime).ToString("yyyy-MM-dd");
                            }
                        }
                        catch (Exception) { }
                        lblproductAddress.Text = orderDetail.ProductAddress;
                        lblproNum.Text = orderDetail.proNum.ToString();
                        lblproType.Text = orderDetail.proType;

                        //随工单号
                        lblSuiGongDan.Text = suigongdan;
                        //随工单打印数量
                        lblPrintCount.Text = PrintCount;
                        //加载订单基本信息
                        orderMod = ProOrdersBLL.GetModel(orderDetail.orderNum);
                        if (orderMod != null)
                        {
                            txtcustomManager.Text = orderMod.customManager;
                            txtcustomNum.Text = orderMod.customNum;
                            txtcustomOrderNum.Text = orderMod.customOrderNum;
                            txtcustomWLBH.Text = orderMod.customWLBH;
                            txtheTongNum.Text = orderMod.heTongNum;
                            txtorderNum.Text = orderMod.orderNum;
                            txtremark.Text = orderMod.remark;


                            var db = new Web.Model.OrderPrintEntities();
                            var intorderDetailId = orderDetail.orderDetailId;
                            var gt_order = db.proOrders.FirstOrDefault(r => r.orderId == orderMod.orderId);
                            if (!string.IsNullOrEmpty(gt_order.发货状态))
                            {
                                lbl发货状态.Text = gt_order.发货状态;
                            }
                        }
                    }
                }
            }
        }
    }
}