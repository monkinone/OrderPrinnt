﻿using OrderPrintSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_PrintSGDJL : PageBase
{
    public string orderNum = "";
    public string proType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["proType"] != null && Request.QueryString["proType"].ToString() != "")
            {
                proType = Request.QueryString["proType"].ToString();
                lblProtype.Text = Request.QueryString["proType"].ToString();
            }
            if (Request.QueryString["proNum"] != null && Request.QueryString["proNum"].ToString() != "")
            {
                lblProNum.Text = Request.QueryString["proNum"].ToString();
            }
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                orderNum = Request.QueryString["orderNum"].ToString();
            }
        }
    }
}