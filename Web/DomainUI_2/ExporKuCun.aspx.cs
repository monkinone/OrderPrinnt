using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.DomainUI_2
{
    public partial class ExporKuCun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            doExportExcel();
        }

        private void doExportExcel()
        {
            string sql = @"select ModelNumber,MaterialName,CategoryName,UnitName,AttributeName,TechnicalParameter,
                                    (select SUM(mw.KuCun) from domain_Material_WareHouse mw where ModelNumber = mw.MaterialModelNumber and MaterialName=mw.MaterialName) as KuCun
                                    from base_Material ";
             DataTable dt = NewsSystem.DBUtility.SqlHelper.Query(sql).Tables[0];
             string columnName = "物料型号,物料名称,分类名称,单位,属性,技术参数,总库存量";
             string fileName = HttpContext.Current.Server.MapPath("../outfile") + "\\kucun.xls";
             Eagle.Module.Office.Excel.ExportExcelByMyXls(dt, columnName, fileName, "库存清单", true);
        }
    }
}