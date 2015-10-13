﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Modules;
using OrderPrintSystem.BLL;

public partial class CustomerManage_ProductParam : System.Web.UI.Page
{
    ProductParamMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                mod = ProductParamBLL.GetmodByid(id);
                if (mod != null)
                {
                    //加载客户信息
                    txtcustomerNo.Text = mod.CustomNo;
                    txtparamContent.Text = mod.ParamContent;
                    txtproductNO.Text = mod.ProductNo;
                }
                //客户编号不允许修改
                txtcustomerNo.Enabled = false;
                txtproductNO.Enabled = false;
            }
        }
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
            mod = ProductParamBLL.GetmodByid(id);
            mod.ParamContent = txtparamContent.Text.Trim();
            num = ProductParamBLL.Updatemod(mod);
        }
        else
        {
            mod = new ProductParamMOD();
            mod.CustomNo = txtcustomerNo.Text.Trim();
            mod.ParamContent = txtparamContent.Text.Trim();
            mod.ProductNo = txtproductNO.Text.Trim();
            num = ProductParamBLL.Insertmod(mod);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('CustomerManage/ProductParamManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
}