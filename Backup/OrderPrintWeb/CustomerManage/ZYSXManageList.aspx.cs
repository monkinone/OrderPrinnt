using OrderPrintSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderPrintWeb.CustomerManage
{
    public partial class ZYSXManageList : PageBase
    {
        string strWhere = "";
        public string customerNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
                {
                    customerNo = Request.QueryString["customerNo"].ToString();
                }
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
                strWhere += " and customerNo='" + customerNo + "'";
                DataSet ds = new DataSet();
                ds = MattersNeedingAttentionBLL.GetmodAll(strWhere);
                if (ds != null)
                {
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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_userinfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "del")
            {
                int num = MattersNeedingAttentionBLL.Delete(id.ToString());
                if (num > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除成功');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('删除失败');", true);
                }
            }

            LoadDataBind(strWhere);
        }
    }
}