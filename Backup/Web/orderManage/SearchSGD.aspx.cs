using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using Wuqi.Webdiyer;
using System.Web.Security;

namespace Web.orderManage
{
    public partial class SearchSGD : System.Web.UI.Page
    {
        private string strWhere=string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //这里是判断是否已经登陆 （先加一个测试一下）
                var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {  //Cookie中不存在，表示没有登陆，需要跳转到登陆页面
                    Response.Redirect("/Login.aspx");
                    return;
                }

                LoadDataBind(strWhere);
            }
        }

        protected void IBtn_Query_Click(object sender, EventArgs e)
        {
            Pager_DocumentShare.CurrentPageIndex = 1;
            LoadDataBind(strWhere);
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
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="strWhere"></param>
        protected void LoadDataBind(string strWhere)
        {
            try
            {
                strWhere = string.Format(" and suigongdan like '%{0}%' ",txtSGD.Value);
                DataSet ds = new DataSet();
                int PageCount;
                ds =new SGDRecordBLL().SearchSGD(Pager_DocumentShare.PageSize, Pager_DocumentShare.CurrentPageIndex, out PageCount, strWhere);
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
    }
}