using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System.IO;

public partial class ProductManage_AddWaiKeImg : System.Web.UI.Page
{
    WaiKeImgMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                mod = WaiKeImgBLL.GetmodByid(id);
                if (mod != null)
                {
                    //加载客户信息
                    txtwaiKeNo.Text = mod.WaiKeNo;
                    imgwaiKeImg.ImageUrl = mod.WaiKeImg;
                }
                txtwaiKeNo.Enabled = false;
                imgwaiKeImg.Visible = true;
            }
            else
            {
                imgwaiKeImg.Visible = false;
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
            mod = WaiKeImgBLL.GetmodByid(id);
            Boolean fileOK = false;
            //上传外形图纸
            if (fuwaiKeImg.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fuwaiKeImg.FileName).ToLower();
                // 允许的文件后缀
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                // 看包含的文件是否是被允许的文件后缀
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        // 如果是，标志位置为真
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    string url = "~/fileUpload/" + fuwaiKeImg.FileName;

                    if (fuwaiKeImg.HasFile)
                    {
                        string fileType = fuwaiKeImg.PostedFile.ContentType;

                        string name = fuwaiKeImg.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fuwaiKeImg.SaveAs(Server.MapPath(url));
                            mod.WaiKeImg = url;
                            mod.IsModify = 1;
                            fileOK = false;


                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('上传有误，请重新上传!');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('只能上传gif,png,jpeg,jpg格式的文件!');</script>");
                    return;
                }
            }
            num = WaiKeImgBLL.Updatemod(mod);
        }
        else
        {
            mod = new WaiKeImgMOD();
            mod.IsModify = 0;
            mod.WaiKeNo = txtwaiKeNo.Text.Trim();
            Boolean fileOK = false;
            //上传外形图纸
            if (fuwaiKeImg.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fuwaiKeImg.FileName).ToLower();
                // 允许的文件后缀
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                // 看包含的文件是否是被允许的文件后缀
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        // 如果是，标志位置为真
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    string url = "~/fileUpload/" + fuwaiKeImg.FileName;

                    if (fuwaiKeImg.HasFile)
                    {
                        string fileType = fuwaiKeImg.PostedFile.ContentType;

                        string name = fuwaiKeImg.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fuwaiKeImg.SaveAs(Server.MapPath(url));
                            mod.WaiKeImg = url;
                            fileOK = false;
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('上传有误，请重新上传!');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('只能上传gif,png,jpeg,jpg格式的文件!');</script>");
                    return;
                }
            }
            else
            {
                mod.WaiKeImg = "";
            }
            num = WaiKeImgBLL.Insertmod(mod);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('ProductManage/WaiKeImgManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
}