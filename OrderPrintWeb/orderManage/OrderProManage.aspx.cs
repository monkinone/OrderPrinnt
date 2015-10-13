using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

public partial class orderManage_OrderProManage : PageBase
{
    private string strWhere;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //查询修改提醒订单
            DataSet ds = ProOrdersBLL.GetList("  and (isTiXing is null or isTiXing=0) and updateTime is not null ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                yulan.Visible = true;
                tixing.InnerHtml = "请注意！</br>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string editUser = "0";
                    string userName = "";
                    if (ds.Tables[0].Rows[i]["editUser"] != null && ds.Tables[0].Rows[i]["editUser"].ToString() != "")
                    {
                        editUser = ds.Tables[0].Rows[i]["editUser"].ToString();
                        UserManageMOD mod = UserManageBLL.GetUserByid(Convert.ToInt32(editUser));
                        if (mod != null)
                        {
                            userName = mod.TrueName;
                        }
                    }
                    string updateTime = "";
                    if (ds.Tables[0].Rows[i]["updateTime"] != null)
                    {
                        updateTime = ds.Tables[0].Rows[i]["updateTime"].ToString();
                    }
                    string orderNum = ds.Tables[0].Rows[i]["orderNum"].ToString();
                    string orderId = ds.Tables[0].Rows[i]["orderId"].ToString();
                    tixing.InnerHtml += "管理人员" + userName + "&nbsp;&nbsp;" + updateTime + "修改了订单编号为：<a href=\"javascript:void;\" onclick=\"ListPageControl.OpenBox('./orderManage/OrderDetail.aspx?orderNum=" + orderNum + "','打印产品订单','1050px','500px')\">" + orderNum + "</a>的订单<br/>";
                }
            }
            else
            {
                yulan.Visible = false;
            }
            //绑定所有订单产品
            LoadDataBind(strWhere);

        }
    }

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="strWhere"></param>
    protected void LoadDataBind(string strWhere)
    {
        try
        {
            if (txtproType.Value.Trim() != "")
            {
                strWhere += " and proType like '%" + txtproType.Value.Trim() + "%'";
            }
            if (txtcustomNum.Value.Trim() != "")
            {
                strWhere += " and customNum like '%" + txtcustomNum.Value.Trim() + "%'";
            }
            if (txtorderNum.Value.Trim() != "")
            {
                strWhere += " and orderNum like '%" + txtorderNum.Value.Trim() + "%'";
            }
            if (ddlIsPrint.SelectedValue != "3")
            {
                if (ddlIsPrint.SelectedValue == "0")  //未打印(已发货数量小于订单数量)
                {
                    strWhere += " and (proNum>SendCount or SendCount is null)";
                }
                else if (ddlIsPrint.SelectedValue == "1")  //已打印（打印了随工单）
                {
                    strWhere += " and printSGDCount>0";
                }
                else   //部分打印
                {
                    strWhere += " and (printSGDCount>0 or printSGDJLCount>0 or printQLDCount>0 or printCCJYBGCount>0 or printSHDCount>0 or printBZBQCount>0 or printZYSXCount>0 or printYYQRDCount>0)";
                }
            }
            DataSet ds = new DataSet();
            int PageCount;
            ds = ProOrdersDetailBLL.GetAllProduct(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
            if (ds != null)
            {
                Pager_DocumentShare.RecordCount = PageCount;
                rpt_userinfo.DataSource = ds;
                rpt_userinfo.DataBind();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Pager_DocumentShare_PageChanging(object sender, PageChangingEventArgs e)
    {
        Pager_DocumentShare.CurrentPageIndex = e.NewPageIndex;

        LoadDataBind(strWhere);

    }

    //protected override void OnLoadComplete(EventArgs e)
    //{
    //    base.OnLoadComplete(e);
    //    ScriptManager.RegisterStartupScript(UP_Search, typeof(UpdatePanel), "QueryArea", "ListPageControl.ReflushListBtnID = \"" + IBtn_Empty.ClientID + "\";", true);
    //}
    //protected void UP_BTN_Load(object sender, EventArgs e)
    //{
    //    if (IsPostBack)
    //    {
    //        ScriptManager.RegisterStartupScript(UP_BTN, typeof(UpdatePanel), "OptBar", "ListPageControl.SetEveryView('OptBar');", true);

    //    }

    //}
    /// <summary>
    /// 查询区域更新后事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void UP_Search_Load(object sender, EventArgs e)
    //{
    //    if (IsPostBack)
    //    {
    //        ScriptManager.RegisterStartupScript(UP_Search, typeof(UpdatePanel), "QueryArea", "ListPageControl.SetEveryView('QueryArea');", true);
    //    }
    //}

    /// <summary>
    /// 列表区域更新后事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void UP_DocumentShare_Load(object sender, EventArgs e)
    //{
    //    if (IsPostBack)
    //    {
    //        ScriptManager.RegisterStartupScript(UP_DocumentShare, typeof(UpdatePanel), "ListArea", "ListPageControl.SetEveryView('ListArea');", true);
    //    }
    //}
    /// <summary>
    /// 清空
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void IBtn_Empty_Click(object sender, EventArgs e)
    {
        txtproType.Value = "";
        txtcustomNum.Value = "";
        txtorderNum.Value = "";
        ddlIsPrint.SelectedValue = "0";
        Pager_DocumentShare.CurrentPageIndex = 1;
        LoadDataBind(strWhere);
        //  UP_DocumentShare.Update();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Pager_DocumentShare.CurrentPageIndex = 1;
        LoadDataBind(strWhere);
        // UP_DocumentShare.Update();
    }
}