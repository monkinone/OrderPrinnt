using OrderPrintSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderPrintWeb
{
    public partial class LoginOut :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Logout())
            {
                //Response.Redirect("~/Login.aspx");
                Response.Write("<script>top.location.href=\"/Login.aspx\"</script>");
            }
        }
    }
}