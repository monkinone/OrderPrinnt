using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderManage_AddWuliu : PageBase
{
    SendDetailMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                string orderNum = Request.QueryString["id"];
                mod = SendDetailBLL.GetModByOrderNum(orderNum);
                if (mod != null)
                {
                    lblOrderNum.Text = mod.OrderNum;
                    txtpackingCompanyName.Text = mod.PackingCompanyName;
                    txtsendNum.Text = mod.SendNum;
                }
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
            string orderNum = Request.QueryString["id"];
            mod = SendDetailBLL.GetModByOrderNum(orderNum);
            mod.SendNum = txtsendNum.Text.Trim();
                mod.PackingCompanyName=txtpackingCompanyName.Text.Trim();

            num = SendDetailBLL.UpdateSendInfoByOrderNum(mod.OrderNum,mod.SendNum,mod.PackingCompanyName);
        }
       
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('orderManage/SendListOrAddSend.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
}