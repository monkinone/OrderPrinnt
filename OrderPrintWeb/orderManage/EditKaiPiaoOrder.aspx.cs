using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderPrintWeb.orderManage
{
    public partial class EditKaiPiaoOrder : System.Web.UI.Page
    {
        ProOrdersMOD orderMod = null;
        ProOrdersDetailMOD orderDetail = null;
        CustomerManageMod customer = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    string orderNum = Request.QueryString["id"].ToString();
                    //加载订单基本信息
                    orderMod = ProOrdersBLL.GetModel(orderNum);
                    if (orderMod != null)
                    {
                        txtcustomManager.Text = orderMod.customManager;
                        txtcustomNum.Text = orderMod.customNum;
                        txtcustomOrderNum.Text = orderMod.customOrderNum;
                        txtcustomWLBH.Text = orderMod.customWLBH;
                        txtheTongNum.Text = orderMod.heTongNum;
                        txtorderNum.Text = orderMod.orderNum;
                        txtremark.Text = orderMod.remark;
                        txtYijiekuanMoney.Text = orderMod.YijiekuanMoney.ToString();
                        txtYikaipiaoMoney.Text = orderMod.YikaipiaoMoney.ToString();
                        txtFapiaoDanhao.Text = orderMod.FaPiaoDanhao;
                        txtChengduihao.Text = orderMod.ChengShuiHao;
                        txtRemark1.Text = orderMod.Remark1;
                    }
                    //加载订单产品
                    string strWhere = " and orderNum='" + orderNum + "'";
                    DataSet ds = ProOrdersDetailBLL.GetList(strWhere);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        rptYongpin.DataSource = ds;
                        rptYongpin.DataBind();

                    }

                    //除结款和开票外其他不允许修改
                    txtorderNum.Enabled = false;
                    txtcustomNum.Enabled = false;
                    txtcustomManager.Enabled = false;
                    txtcustomNum.Enabled = false;
                    txtcustomOrderNum.Enabled = false;
                    txtcustomWLBH.Enabled = false;
                    txtheTongNum.Enabled = false;
                    txtorderNum.Enabled = false;
                    txtremark.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                //修改订单基本信息
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    string orderNum = Request.QueryString["id"].ToString();
                    //加载订单基本信息
                    orderMod = ProOrdersBLL.GetModel(orderNum);
                    orderMod.customManager = txtcustomManager.Text.Trim();
                    orderMod.customOrderNum = txtcustomOrderNum.Text.Trim();
                    orderMod.customWLBH = txtcustomWLBH.Text.Trim();
                    orderMod.heTongNum = txtheTongNum.Text.Trim();
                    orderMod.remark = txtremark.Text.Trim();
                    orderMod.UpdateTime = DateTime.Now;
                    orderMod.FaPiaoDanhao = txtFapiaoDanhao.Text.Trim();
                    orderMod.ChengShuiHao = txtChengduihao.Text.Trim();
                    orderMod.Remark1 = txtRemark1.Text.Trim();
                    if (txtYijiekuanMoney.Text.Trim() != "")
                    {
                        orderMod.YijiekuanMoney = Convert.ToDecimal(txtYijiekuanMoney.Text.Trim());
                    }
                    else
                    {
                        orderMod.YijiekuanMoney = 0;
                    }
                    if (txtYikaipiaoMoney.Text.Trim() != "")
                    {
                        orderMod.YikaipiaoMoney = Convert.ToDecimal(txtYikaipiaoMoney.Text.Trim());
                    }
                    else
                    {
                        orderMod.YikaipiaoMoney = 0;
                    }
                    num = ProOrdersBLL.Update(orderMod);
                }


                if (num > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "DetailsPageControl.CloseBox();alert('提交成功！');DetailsPageControl.ReflushList('orderManage/OrderKaiPiaoManage.aspx');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('提交失败！')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('提交失败，您输入的信息有误！')", true);
            }
        }
    }
}