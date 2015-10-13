using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using System.Data;
using OrderPrintSystem.Modules;

public partial class orderManage_EditOrder : System.Web.UI.Page
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
                }
                //加载订单产品
                string strWhere = " and orderNum='" + orderNum + "'";
                DataSet ds = ProOrdersDetailBLL.GetList(strWhere);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptYongpin.DataSource = ds;
                    rptYongpin.DataBind();
                    txtTRLastIndex.Value = ds.Tables[0].Rows.Count.ToString();
                }
                else
                {
                    txtTRLastIndex.Value = "0";
                }
                //查看客户是否客户提供合同范本，如客户提供，打印合同按钮隐藏
                customer = CustomerManageBLL.GetcustomerByid(orderMod.customNum);
                if (customer != null)
                {
                    if (customer.IsFanben == 0)
                    {
                        IBtn_Print.Visible = false;
                    }
                    else
                    {
                        IBtn_Print.Visible = true;
                    }
                }
                //订单号、客户编号不允许修改
                txtorderNum.Enabled = false;
                txtcustomNum.Enabled = false;
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
        bool real = true;
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
            ProOrdersBLL.Update(orderMod);
        }
        //修改订单详情

        string[] xinghao = Request.Params.GetValues("proType");
        string[] shuliang = Request.Params.GetValues("proNum");
        string[] danjia = Request.Params.GetValues("ProPrice");

        string xianyouyongpin = "";

        //原有产品的增加和修改
        for (int i = 0; i < rptYongpin.Items.Count; i++)
        {
            Label lblProType = this.rptYongpin.Items[i].FindControl("lblProType") as Label;
            TextBox txtProNum = this.rptYongpin.Items[i].FindControl("txtProNum") as TextBox;
            Label lblProPrice = this.rptYongpin.Items[i].FindControl("lblProPrice") as Label;
            HiddenField hdborderDetailId = this.rptYongpin.Items[i].FindControl("hdborderDetailId") as HiddenField;
            xianyouyongpin += lblProType.Text.Trim() + ",";

            if (txtProNum != null && txtProNum.Text.Trim() != "" && int.Parse(txtProNum.Text.Trim()) != 0)
            {
                //修改产品数量
                int Updcount = ProOrdersDetailBLL.Update(Convert.ToInt32(hdborderDetailId.Value), Convert.ToInt32(txtProNum.Text));
                if (!(Updcount > 0))
                {
                    real = false;
                }
            }
            else
            {
                //删除产品型号
                ProOrdersDetailBLL.Delete(Convert.ToInt32(hdborderDetailId.Value));
            }
        }
        //新增产品
        if (xinghao != null && xinghao.Length > 0)
        {
            for (int i = 0; i < xinghao.Length; i++)
            {
                if (shuliang[i].ToString().Trim() != "" && int.Parse(shuliang[i].ToString().Trim()) != 0)
                {
                    string xinYongpin = xinghao[i].ToString().Trim();
                    int num = 0;
                    int osid = 0;
                    if (xianyouyongpin.Contains(xinYongpin))   //如果新增产品已经存在于原有的产品中，则数量合并
                    {
                        DataSet ds = ProOrdersDetailBLL.GetList(" and proType='" + xinghao[i].Trim() + "' and orderNum='" + txtorderNum.Text.Trim() + "'");
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            num = Convert.ToInt32(ds.Tables[0].Rows[0]["proNum"].ToString());
                            osid = Convert.ToInt32(ds.Tables[0].Rows[0]["orderDetailId"].ToString());
                            int newNUM = num + Convert.ToInt32(shuliang[i].Trim());
                            //修改产品数量
                            int Updcount = ProOrdersDetailBLL.Update(osid, newNUM);
                            if (!(Updcount > 0))
                            {
                                real = false;
                            }
                        }
                        else
                        {
                            orderDetail = new ProOrdersDetailMOD();
                            orderDetail.orderNum = txtorderNum.Text.Trim();
                            orderDetail.proNum = Convert.ToInt32(shuliang[i].Trim());
                            orderDetail.ProPrice = Convert.ToDecimal(danjia[i].Trim());
                            orderDetail.proType = xinghao[i].Trim();
                            int Addcounts = ProOrdersDetailBLL.Add(orderDetail);
                            if (!(Addcounts > 0))
                            {
                                real = false;
                            }
                        }
                    }
                    else   //直接添加
                    {
                        orderDetail = new ProOrdersDetailMOD();
                        orderDetail.orderNum = txtorderNum.Text.Trim();
                        orderDetail.proNum = Convert.ToInt32(shuliang[i].Trim());
                        orderDetail.ProPrice = Convert.ToDecimal(danjia[i].Trim());
                        orderDetail.proType = xinghao[i].Trim();
                        int Addcounts = ProOrdersDetailBLL.Add(orderDetail);
                        if (!(Addcounts > 0))
                        {
                            real = false;
                        }
                    }
                }
            }
        }
        if (real)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "DetailsPageControl.CloseBox();alert('提交成功！');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('提交失败！')", true);
        }
    }

}



