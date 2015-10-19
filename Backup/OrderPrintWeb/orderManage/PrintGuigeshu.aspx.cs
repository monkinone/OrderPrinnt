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

namespace OrderPrintWeb.orderManage
{
    public partial class PrintGuigeshu : PageBase
    {
        private string strWhere;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

              //  LoadDataBind(strWhere);
            }
        }
       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txt_productNo.Value.Trim() != "")
            {
                GuiGeShuMOD mod = GuiGeShuBLL.GetmodByProduct(txt_productNo.Value.Trim());
              if (mod != null)
              {
                  if (mod.FileUrl != "")
                  {
                      print.HRef = mod.FileUrl;
                      print.InnerText = mod.FileUrl.Replace("~/fileUpload/", "");
                  }
                  else
                  {
                      print.InnerText = "该型号没有上传规格书！";
                  }
              }
              else
              {
                  print.InnerText = "该型号没有上传规格书！";
              }
            }
        }
    }
}