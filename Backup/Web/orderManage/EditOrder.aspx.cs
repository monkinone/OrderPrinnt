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
using System.Web.Services;

public partial class orderManage_EditOrder : PageBase
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
                int id;
                if (Int32.TryParse(Request.QueryString["id"], out id))
                {
                    var db=new Web.Model.OrderPrintEntities();
                    orderNum = db.proOrders.Where(r => r.orderId == id).FirstOrDefault().orderNum;
                }


                //加载订单基本信息
                orderMod = ProOrdersBLL.GetModel(orderNum);
                if (orderMod != null)
                {
                    txtcustomManager.Text = orderMod.customManager;
                    txtcustomNum.Text = orderMod.customNum;
                    txtcustomOrderNum.Text = orderMod.customOrderNum;
                    //  txtcustomWLBH.Text = orderMod.customWLBH;
                    txtheTongNum.Text = orderMod.heTongNum;
                    txtorderNum.Text = orderMod.orderNum;
                    txtremark.Text = orderMod.remark;
                    //txtshuChuXianchang.Text = orderMod.ShuChuXianchang;
                    //txtshuRuXianchang.Text = orderMod.ShuRuXianchang;
                    //txtYijiekuanMoney.Text = orderMod.YijiekuanMoney.ToString();
                    //txtYikaipiaoMoney.Text = orderMod.YikaipiaoMoney.ToString();



                    
                    var db = new Web.Model.OrderPrintEntities();
                    var intorderDetailId = id;
                    var gt_order = db.proOrders.FirstOrDefault(r => r.orderId == orderMod.orderId);
                    if (!string.IsNullOrEmpty(gt_order.发货状态))
                    {
                        rbl发货状态.SelectedValue = gt_order.发货状态;
                    }

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
                        tishi.InnerText = "本客户自己提供合同模板，请使用签订客户合同";
                        IBtn_Print.Visible = false;
                    }
                    else
                    {
                        IBtn_Print.Visible = true;
                    }
                }
                else
                {
                    IBtn_Print.Visible = true;
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
        try
        {

            bool real = true;
            //修改订单基本信息
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                string orderNum = Request.QueryString["id"].ToString();
                int id;
                var db = new Web.Model.OrderPrintEntities();
                if (Int32.TryParse(Request.QueryString["id"], out id))
                {
                    orderNum = db.proOrders.Where(r => r.orderId == id).FirstOrDefault().orderNum;
                }

                //加载订单基本信息
                orderMod = ProOrdersBLL.GetModel(orderNum);
                orderMod.customManager = txtcustomManager.Text.Trim();
                orderMod.customOrderNum = txtcustomOrderNum.Text.Trim();
                orderMod.customWLBH = "";// txtcustomWLBH.Text.Trim();
                orderMod.heTongNum = txtheTongNum.Text.Trim();
                orderMod.remark = txtremark.Text.Trim();
                orderMod.UpdateTime = DateTime.Now;
                orderMod.FaPiaoDanhao = "";
                orderMod.ChengShuiHao = "";
                orderMod.Remark1 = "";
                orderMod.EditUser = UserInfo.UserId;
                orderMod.IsTiXing = 0;
                orderMod.ShuRuXianchang = "";// txtshuRuXianchang.Text.Trim();
                orderMod.ShuChuXianchang = "";// txtshuChuXianchang.Text.Trim();

                var intorderDetailId = id;
                var gt_order = db.proOrders.FirstOrDefault(r => r.orderId == orderMod.orderId);
                gt_order.发货状态 = rbl发货状态.SelectedValue;
                db.SaveChanges();





                //if (txtYijiekuanMoney.Text.Trim() != "")
                //{
                //    orderMod.YijiekuanMoney = Convert.ToDecimal(txtYijiekuanMoney.Text.Trim());
                //}
                //else
                //{
                //    orderMod.YijiekuanMoney = 0;
                //}
                //if (txtYikaipiaoMoney.Text.Trim() != "")
                //{
                //    orderMod.YikaipiaoMoney = Convert.ToDecimal(txtYikaipiaoMoney.Text.Trim());
                //}
                //else
                //{
                //    orderMod.YikaipiaoMoney = 0;
                //}
                ProOrdersBLL.Update(orderMod);
            }
            //修改订单详情

            string[] xinghao = Request.Params.GetValues("proType");
            string[] shuliang = Request.Params.GetValues("proNum");
            string[] danjia = Request.Params.GetValues("ProPrice");
            string[] wuliaobian = Request.Params.GetValues("wuliaobian");

            string xianyouyongpin = "";
            string errmsg = "";
            //原有产品的增加和修改
            for (int i = 0; i < rptYongpin.Items.Count; i++)
            {
                Label lblProType = this.rptYongpin.Items[i].FindControl("lblProType") as Label;
                TextBox txtProNum = this.rptYongpin.Items[i].FindControl("txtProNum") as TextBox;
                Label lblProPrice = this.rptYongpin.Items[i].FindControl("lblProPrice") as Label;
                Label lblWuliaobian = this.rptYongpin.Items[i].FindControl("lblWuliaobian") as Label;
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
                        ProductParamMOD paramMod = ProductParamBLL.GetmodByid(txtcustomNum.Text.Trim(), xinghao[i].Trim());
                        if (paramMod != null)
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
                                //orderDetail.Wuliaobian = wuliaobian[i].Trim();
                                int Addcounts = ProOrdersDetailBLL.Add(orderDetail);
                                if (!(Addcounts > 0))
                                {
                                    real = false;
                                }
                            }
                        }
                        else
                        {
                            errmsg += xinghao[i] + ",";
                        }
                    }

                }
            }
            if (real)
            {
                if (errmsg == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);

                    //   ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');print();DetailsPageControl.CloseBox();", true);
                    Response.Redirect("Contract.aspx?customerNo=" + txtcustomNum.Text.Trim() + "&orderNum=" + txtorderNum.Text.Trim());
                }
                else
                {
                    //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert(" + errmsg + "'没有维护单价提交失败，其余提交成功');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('" + errmsg + "没有维护产品参数提交失败，其余提交成功');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
                    Response.Redirect("Contract.aspx?customerNo=" + txtcustomNum.Text.Trim() + "&orderNum=" + txtorderNum.Text.Trim());
                }
                //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "DetailsPageControl.CloseBox();alert('提交成功！');DetailsPageControl.ReflushList('orderManage/OrderManage.aspx');", true);
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



