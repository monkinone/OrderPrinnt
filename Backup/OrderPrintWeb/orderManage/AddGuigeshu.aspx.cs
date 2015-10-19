using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderPrintWeb.orderManage
{
    public partial class AddGuigeshu : System.Web.UI.Page
    {
        GuiGeShuMOD mod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    txtProductNo.Text = Request.QueryString["id"].ToString();
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
            Boolean fileOK = false;
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                DataSet ds = GuiGeShuBLL.GetmodAll(" and productNo='" + Request.QueryString["id"] + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    mod = new GuiGeShuMOD();
                    mod.ProductNo = txtProductNo.Text.Trim();
                    //上传外形图纸
                    if (fuGuigeshu.HasFile)
                    {
                        // 得到文件的后缀
                        String fileExtension =
                            System.IO.Path.GetExtension(fuGuigeshu.FileName).ToLower();
                        // 允许的文件后缀
                        String[] allowedExtensions = { ".pdf", ".PDF" };
                        // 看包含的文件是否是被允许的文件后缀
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i].ToLower())
                            {
                                // 如果是，标志位置为真
                                fileOK = true;
                            }
                        }

                        if (fileOK)
                        {
                            string url = "~/fileUpload/" + fuGuigeshu.FileName;

                            if (fuGuigeshu.HasFile)
                            {
                                string fileType = fuGuigeshu.PostedFile.ContentType;

                                string name = fuGuigeshu.PostedFile.FileName;  //文件路径
                                FileInfo fileInfo = new FileInfo(name);
                                try
                                {
                                    fuGuigeshu.SaveAs(Server.MapPath(url));
                                    mod.FileUrl = url;
                                    fileOK = false;
                                    num = GuiGeShuBLL.Updatemod(mod);

                                }
                                catch (Exception ex)
                                {
                                    Response.Write("<script>alert('上传有误，请重新上传!');</script>");
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('只能上传pdf格式的文件!');</script>");
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('您没有要上传的文件！');", true);
                        return;
                    }
                }
            }
            else
            {
                mod = new GuiGeShuMOD();
                mod.ProductNo = txtProductNo.Text.Trim();
                //上传外形图纸
                if (fuGuigeshu.HasFile)
                {
                    // 得到文件的后缀
                    String fileExtension =
                        System.IO.Path.GetExtension(fuGuigeshu.FileName).ToLower();
                    // 允许的文件后缀
                    String[] allowedExtensions = { ".pdf", ".PDF" };
                    // 看包含的文件是否是被允许的文件后缀
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i].ToLower())
                        {
                            // 如果是，标志位置为真
                            fileOK = true;
                        }
                    }

                    if (fileOK)
                    {
                        string url = "~/fileUpload/" + fuGuigeshu.FileName;

                        if (fuGuigeshu.HasFile)
                        {
                            string fileType = fuGuigeshu.PostedFile.ContentType;

                            string name = fuGuigeshu.PostedFile.FileName;  //文件路径
                            FileInfo fileInfo = new FileInfo(name);
                            try
                            {
                                fuGuigeshu.SaveAs(Server.MapPath(url));
                                mod.FileUrl = url;
                                fileOK = false;
                                num = GuiGeShuBLL.Insertmod(mod);

                            }
                            catch (Exception ex)
                            {
                                Response.Write("<script>alert('上传有误，请重新上传!');</script>");
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('只能上传pdf格式的文件!');</script>");
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('您没有要上传的文件！');", true);
                    return;
                }


            }
            if (num > 0)
            {
                //  btnPrint.Visible = true;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');')DetailsPageControl.ReflushList('orderManage/GuiGeShu.aspx');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
            }
        }
        /// <summary>
        /// 判断产品型号是否存在
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        [WebMethod]
        public static int isExistProType(string proType)
        {
            int num = 0;
            ProductsMOD mod = ProductsBLL.GetModel(proType);
            if (mod != null)
            {
                num = 1;
            }
            return num;
        }
        /// <summary>
        /// 判断产品型号规格书是否已上传
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        [WebMethod]
        public static int isExistGuigeshu(string proType)
        {
            int num = 0;
            GuiGeShuMOD mod = GuiGeShuBLL.GetmodByid(proType);
            if (mod != null)
            {
                num = 1;
            }
            return num;
        }
    }
}