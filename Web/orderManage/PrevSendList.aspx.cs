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
using Web.Model;

namespace OrderPrintWeb.orderManage
{
    public partial class PrevSendList : System.Web.UI.Page
    {
        public static string orderNum = "";
        public static string proType = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["songhuodan"] = "1";
            if (!IsPostBack)
            {
                if (Session["SendList"] != null)
                {
                    List<PrevProductMOD> list = (List<PrevProductMOD>)Session["SendList"];

                    List<PrevProductMOD> newList = new List<PrevProductMOD>();
                    foreach (var m in list)
                    {
                        if (m.ProNum != "" && m.ProNum != "0")
                        {
                            newList.Add(m);
                        }
                    }

                    Repeater1.DataSource = newList;
                    Repeater1.DataBind();
                    rptPro.DataSource = newList;
                    rptPro.DataBind();
                }
                if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
                {
                    orderNum = Request.QueryString["orderNum"].ToString();
                    lblOrderNum.Text = orderNum;
                }
                if (Request.QueryString["sendTime"] != null && Request.QueryString["sendTime"].ToString() != "")
                {
                    lblPrintTime.Value = Request.QueryString["sendTime"].ToString();

                }
                if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
                {
                    string customNum = Request.QueryString["customerNo"].ToString();
                    CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customNum);
                    if (mod != null)
                    {
                        using (var db = new Web.Model.OrderPrintEntities())
                        {
                            var dtl = db.SendDetail.OrderByDescending(r => r.sendId).FirstOrDefault(r => r.orderNum == orderNum);
                            if (dtl != null && !string.IsNullOrEmpty(dtl.PrintCompanyName))
                            {
                                txtCompanyName.Text = dtl.PrintCompanyName;
                            }
                            else
                            {
                                txtCompanyName.Text = mod.CompanyName;
                            }
                        }
                        if (mod.IsShowPrice == 0)   //显示
                        {
                            div1.Visible = false;
                            div2.Visible = true;
                        }
                        else   //不显示
                        {
                            div1.Visible = true;
                            div2.Visible = false;
                        }
                    }
                    else
                    {
                        div1.Visible = true;
                        div2.Visible = false;
                    }
                }
                //产品型号
                if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
                {
                    proType = Request.QueryString["proType"].ToString();
                }
                //打印时间
                //  lblPrintTime.Value = DateTime.Now.ToShortDateString();

            }

        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            bool result = true;
            if (rptPro.Items.Count > 0)
            {
                List<PrevProductMOD> list = (List<PrevProductMOD>)Session["SendList"];
                List<SendDetail> listSendDetail = new List<SendDetail>();
                if (chkRepeatPrint.Checked == true)
                {
                    Session["RepeatPrint"] = "1";//是否重复打印
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].ProNum != ""&&list[i].ProNum!="0")
                        {
                            SendDetail mod = new SendDetail()
                            { 
                             orderNum = Request.QueryString["orderNum"].ToString(),
                             proType = list[i].ProType,
                             remark = list[i].Beizhu,
                             sendProNum = Convert.ToInt32(list[i].ProNum),
                             sendTime = Convert.ToDateTime(lblPrintTime.Value),
                             UnitPrice = Convert.ToDecimal(list[i].Danjia),
                             suiGongDanNum = Request.QueryString["withWorkNo"].ToString(),
                             PrintCompanyName = txtCompanyName.Text,
                             packingCompanyName="",
                             sendId=0,
                             sendNum="",
                             packingCount=0,
                             packingDetail=""
                            };

                            listSendDetail.Add(mod);
                        }
                    }
                    Session["SendDetailList"] = listSendDetail;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "doPrint();", true);
                    return;
                }
                else
                {
                    Session["RepeatPrint"] = "0";//是否重复打印
                    //打印前先将信息保存
                    // DataSet ds = ProOrdersDetailBLL.GetAllOrderDetail(" and orderNum='"+orderNum+"'");
                    Session["songhuodan"] = "1";
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            //Label lblProType = this.Repeater1.Items[i].FindControl("lblProType") as Label;
                            //Label lblPrice = this.Repeater1.Items[i].FindControl("lblPrice") as Label;
                            //Label txtProNum = this.Repeater1.Items[i].FindControl("txtProNum") as Label;
                            ////  Label hiddProNum = (Label)Repeater1.Items[i].FindControl("hiddProNum");
                            //Label txtRemark = this.Repeater1.Items[i].FindControl("txtRemark") as Label;
                            SendDetailMOD mod = new SendDetailMOD();
                            mod.OrderNum = Request.QueryString["orderNum"].ToString();
                            mod.ProType = list[i].ProType;
                            mod.Remark = list[i].Beizhu;
                            if (list[i].ProNum != "")
                            {
                                mod.SendProNum = Convert.ToInt32(list[i].ProNum);
                            }
                            else
                            {
                                mod.SendProNum = 0;
                            }
                            mod.SendTime = Convert.ToDateTime(lblPrintTime.Value);
                            mod.UnitPrice = Convert.ToDecimal(list[i].Danjia);
                            mod.SuiGongDanNum = Request.QueryString["withWorkNo"].ToString();
                            mod.PrintCompanyName = txtCompanyName.Text;
                            int num = SendDetailBLL.Insertmod(mod);
                            if (num < 0)
                            {
                                result = false;
                                SendDetailBLL.Delete(Request.QueryString["orderNum"].ToString());
                                break;
                            }
                        }
                        if (result)
                        {
                            for (int i = 0; i < Repeater1.Items.Count; i++)
                            {
                                Label lblProType = this.Repeater1.Items[i].FindControl("lblProType") as Label;
                                ProOrdersDetailBLL.UpdatePrintInfo(orderNum, lblProType.Text, "printSHDTime", "printSHDCount");
                            }
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "doPrint();", true);
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('打印失败！');", true);
                        }
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "BGYPSQLB", "alert('您没有要发货的型号！');", true);
                return;
            }
        }
    }
}