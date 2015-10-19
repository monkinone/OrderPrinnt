using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System.IO;
using System.Web.Services;

public partial class ProductManage_AddGuanJiaoZhenImg : PageBase
{
    GuanJiaoZhenImgMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                mod = GuanJiaoZhenImgBLL.GetmodByid(id);
                if (mod != null)
                {
                    txtguanJiaoZhenNo.Text = mod.GuanJiaoZhenNo;
                    if (mod.GuanJiaoZhenImg != "")
                    {
                        imgguanJiaoZhenImg.ImageUrl = mod.GuanJiaoZhenImg;
                    }
                    else
                    {
                        imgguanJiaoZhenImg.ImageUrl = "/images/nophoto.jpg";
                    }
                }
                imgguanJiaoZhenImg.Visible = true;
                txtguanJiaoZhenNo.Enabled = false;
            }
            else
            {
                imgguanJiaoZhenImg.Visible = false;
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
            mod = GuanJiaoZhenImgBLL.GetmodByid(id);
            Boolean fileOK = false;
            //上传外形图纸
            if (fuguanJiaoZhenImg.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fuguanJiaoZhenImg.FileName).ToLower();
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
                    string url = "~/fileUpload/gjz_" + mod.GuanJiaoZhenNo+fileExtension;

                    if (fuguanJiaoZhenImg.HasFile)
                    {
                        string fileType = fuguanJiaoZhenImg.PostedFile.ContentType;

                        string name = fuguanJiaoZhenImg.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fuguanJiaoZhenImg.SaveAs(Server.MapPath(url));
                            mod.GuanJiaoZhenImg = url;
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

            num = GuanJiaoZhenImgBLL.Updatemod(mod);
        }
        else
        {
            mod = new GuanJiaoZhenImgMOD();
            mod.GuanJiaoZhenNo = txtguanJiaoZhenNo.Text.Trim();
            Boolean fileOK = false;
            //上传外形图纸
            if (fuguanJiaoZhenImg.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fuguanJiaoZhenImg.FileName).ToLower();
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
                    string url = "~/fileUpload/gjz_" + mod.GuanJiaoZhenNo + fileExtension;

                    if (fuguanJiaoZhenImg.HasFile)
                    {
                        string fileType = fuguanJiaoZhenImg.PostedFile.ContentType;

                        string name = fuguanJiaoZhenImg.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fuguanJiaoZhenImg.SaveAs(Server.MapPath(url));
                            mod.GuanJiaoZhenImg = url;
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
                mod.GuanJiaoZhenImg = "";
            }

            num = GuanJiaoZhenImgBLL.Insertmod(mod);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('ProductManage/GuanJiaoZhenImgManage.aspx');", true);
        }
        else if(num==0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
    /// <summary>
    /// 判断管脚针型号是否存在
    /// </summary>
    /// <param name="proType"></param>
    /// <returns></returns>
    [WebMethod]
    public static int isExistGuanjiaozhen(string guanjiaozhenNo)
    {
        int num = 0;
        GuanJiaoZhenImgMOD mod = GuanJiaoZhenImgBLL.GetmodByid(guanjiaozhenNo);
        if (mod != null)
        {
            num = 1;
        }
        return num;
    }
}