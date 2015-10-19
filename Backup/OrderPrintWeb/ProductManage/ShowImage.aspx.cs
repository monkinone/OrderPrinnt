using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderPrintWeb.ProductManage
{
    public partial class ShowImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    string bianhao = Request.QueryString["id"];
                    if (Request.QueryString["type"] != "" && Request.QueryString["type"] != null)
                    {
                        string type = Request.QueryString["type"];
                        switch (type)
                        {
                            case "biaoshi":
                                BiaoShiImgMOD mod = BiaoShiImgBLL.GetmodByid(bianhao);
                                if (mod != null)
                                {
                                    if (mod.BiaoShiImg != "")
                                    {
                                        img.ImageUrl = mod.BiaoShiImg;
                                    }
                                    else
                                    {
                                        img.ImageUrl = "/images/nophoto.jpg";
                                    }
                                }
                                else
                                {
                                    img.ImageUrl = "/images/nophoto.jpg";
                                }
                                break;
                            case "waike":
                                WaiKeImgMOD waikemod = WaiKeImgBLL.GetmodByid(bianhao);
                                if (waikemod != null)
                                {
                                    if (waikemod.WaiKeImg != "")
                                    {
                                        img.ImageUrl = waikemod.WaiKeImg;
                                    }
                                    else
                                    {
                                        img.ImageUrl = "/images/nophoto.jpg";
                                    }
                                }
                                else
                                {
                                    img.ImageUrl = "/images/nophoto.jpg";
                                }
                                break;
                            case "guanjiaozhen":
                                GuanJiaoZhenImgMOD guanjiaoMod = GuanJiaoZhenImgBLL.GetmodByid(bianhao);
                                if (guanjiaoMod != null)
                                {
                                    if (guanjiaoMod.GuanJiaoZhenImg != "")
                                    {
                                        img.ImageUrl = guanjiaoMod.GuanJiaoZhenImg;
                                    }
                                    else
                                    {
                                        img.ImageUrl = "/images/nophoto.jpg";
                                    }
                                }
                                else
                                {
                                    img.ImageUrl = "/images/nophoto.jpg";
                                }
                                break;
                        }
                    }

                }
                else
                {
                    img.ImageUrl = "/images/nophoto.jpg";
                }
            }
        }
    }
}