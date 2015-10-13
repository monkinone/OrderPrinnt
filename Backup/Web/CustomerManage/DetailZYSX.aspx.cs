using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;

public partial class CustomerManage_DetailZYSX :PageBase
{
    string strWhere = "";
    string customerNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                customerNo = Request.QueryString["customerNo"].ToString();
                MattersNeedingAttentionMOD mod = MattersNeedingAttentionBLL.GetmodByid(customerNo);
                if (mod != null)
                {
                    txtCustomerNo.Text = customerNo;
                    txtContents.Text = mod.Contents;
                }
            }
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
            //strWhere += " and customerNo='" + Request.QueryString["customerNo"].ToString() + "'";
            //DataSet ds = new DataSet();
            //ds = MattersNeedingAttentionBLL.GetmodAll(strWhere);
            //if (ds != null)
            //{
            //    rpt_userinfo.DataSource = ds;
            //    rpt_userinfo.DataBind();
            //}
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}