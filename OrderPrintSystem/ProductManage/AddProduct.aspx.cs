using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Model;
using OrderPrintSystem.BLL;
using System.IO;

public partial class ProductManage_AddProduct : System.Web.UI.Page
{
    ProductsMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                imgWaiXingTZ.Visible = true;
                imgbiaoShiPicture.Visible = true;
                int id = Convert.ToInt32(Request.QueryString["id"]);
                mod = ProductsBLL.GetModel(id);
                if (mod != null)
                {
                    txtbaoHeDian.Text = mod.baoHeDian;
                    txtbianbi.Text = mod.bian;
                    txtbiaoShiAddress.Text = mod.biaoShiAddress;
                    txtbiaoShiNo.Text = mod.biaoShiNo;
                    imgbiaoShiPicture.ImageUrl = mod.biaoShiPicture;
                    imgWaiXingTZ.ImageUrl = mod.waiXingTZ;

                    txtcaiLiao.Text = mod.caiLiao;

                    txtchajianCount.Text = mod.chajianCount.ToString();

                    txtchajianNo.Text = mod.chajianNo;
                    txtchujRaoXianZD.Text = mod.chujRaoXianZD;
                    txtchujTongMD.Text = mod.chujTongMD;
                    txtchujXianJing.Text = mod.chujXianJing;
                    txtchujXianTouCD.Text = mod.chujXianTouCD;
                    txtchujXiantouCL.Text = mod.chujXiantouCL;
                    txtchujZaShu.Text = mod.chujZaShu;
                    txtchuLiMethod.Text = mod.chuLiMethod;
                    txtcijRaoXianZD.Text = mod.cijRaoXianZD;
                    txtcijTongMD.Text = mod.cijTongMD;
                    txtcijXianJing.Text = mod.cijXianJing;
                    txtcijXianTouCD.Text = mod.cijXianTouCD;
                    txtcijXianTouCL.Text = mod.cijXianTouCL;
                    txtcijZaShu.Text = mod.cijZaShu;
                    txtcpjccsEquip.Text = mod.cpjccsEquip;
                    txtcpjccsFuZai.Text = mod.cpjccsFuZai;
                    txtCpjccsJiaoChaBH.Text = mod.CpjccsJiaoChaBH;
                    txtcpjccsNaiYa.Text = mod.cpjccsNaiYa;
                    txtcpjccsShuChuState.Text = mod.cpjccsShuChuState;
                    txtcpjccsShuRuState.Text = mod.cpjccsShuRuState;
                    txtcpjccsTongMD.Text = mod.cpjccsTongMD;
                    txteDingJC.Text = mod.eDingJC;
                    txtguanJiaoZhenLX.Text = mod.guanJiaoZhenLX;
                    txtguanJIaoZhenLXCount.Text = mod.guanJIaoZhenLXCount.ToString();
                    txtguanJiaoZhenLXTOW.Text = mod.guanJiaoZhenLXTOW;
                    txtguanJiaoZhenLXTOWCount.Text = mod.guanJiaoZhenLXTOWCount.ToString();
                    txtguiGe.Text = mod.guiGe;
                    txtjingDu.Text = mod.jingDu;
                    txtNeiBZ.Text = mod.NeiBZ;
                    txtpeiXianSC.Text = mod.peiXianSC;
                    txtpeiXianSCCount.Text = mod.peiXianSCCount.ToString();
                    txtpeiXianSR.Text = mod.peiXianSR;
                    txtpeiXianSRCount.Text = mod.peiXianSRCount.ToString();
                    txtproductName.Text = mod.productName;
                    txtproductNum.Text = mod.productNum;
                    txtremark.Text = mod.remark;
                    txtshuChu.Text = mod.shuChu;
                    txtshuChuXC.Text = mod.shuChuXC;
                    txtshuRu.Text = mod.shuRu;
                    txtshuRuXC.Text = mod.shuRuXC;
                    txttieXiCount.Text = mod.tieXiCount.ToString();
                    txtwaiBZ.Text = mod.waiBZ.ToString();

                    txtwaiKeCount.Text = mod.waiKeCount.ToString();
                    txtwaiKeNo.Text = mod.waiKeNo;
                    txtxianQuanCount.Text = mod.xianQuanCount.ToString();

                    txtxianXingdu.Text = mod.xianXingdu;
                    txtxingNeng.Text = mod.xingNeng;
                    txtxqjcyqEquip.Text = mod.xqjcyqEquip;
                    txtxqjcyqFuZai.Text = mod.xqjcyqFuZai;
                    txtxqjcyqJiaoCha.Text = mod.xqjcyqJiaoCha;
                    txtxqjcyqShuChuState.Text = mod.xqjcyqShuChuState;
                    txtxqjcyqShuRuState.Text = mod.xqjcyqShuRuState;
                    txtyongJiaoCS.Text = mod.yongJiaoCS;
                }
                //产品编号不允许修改
                txtproductNum.Enabled = false;
            }
            else
            {
                imgWaiXingTZ.Visible = true;
                imgbiaoShiPicture.Visible = true;
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
        bool isModifyPrintSGDCount = false;
        if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            mod = ProductsBLL.GetModel(id);
            if (mod.biaoShiNo != txtbiaoShiNo.Text.Trim())
            {
                mod.isModifyTZ = 1;
                isModifyPrintSGDCount = true;
            }
            if (mod.waiKeNo != txtwaiKeNo.Text.Trim())
            {
                mod.IsModifyWaikeNo = 1;
                isModifyPrintSGDCount = true;
            }
            mod.baoHeDian = txtbaoHeDian.Text.Trim();
            mod.bian = txtbianbi.Text.Trim();
            mod.biaoShiAddress = txtbiaoShiAddress.Text.Trim();
            mod.biaoShiNo = txtbiaoShiNo.Text.Trim();


            Boolean fileOK = false;
            //上传外形图纸
            if (fuwaiXingTZ.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fuwaiXingTZ.FileName).ToLower();
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
                    string url = "~/fileUpload/" + fuwaiXingTZ.FileName;

                    if (fuwaiXingTZ.HasFile)
                    {
                        string fileType = fuwaiXingTZ.PostedFile.ContentType;

                        string name = fuwaiXingTZ.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fuwaiXingTZ.SaveAs(Server.MapPath(url));
                            mod.waiXingTZ = url;
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


            //上传标示图片


            if (fubiaoShiPicture.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fubiaoShiPicture.FileName).ToLower();
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
                    string url = "~/fileUpload/" + fubiaoShiPicture.FileName;

                    if (fubiaoShiPicture.HasFile)
                    {
                        string fileType = fubiaoShiPicture.PostedFile.ContentType;

                        string name = fubiaoShiPicture.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fubiaoShiPicture.SaveAs(Server.MapPath(url));
                            mod.biaoShiPicture = url;
                            fileOK = false;
                            mod.isModifyTZ = 1;
                            isModifyPrintSGDCount = true;
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
            mod.caiLiao = txtcaiLiao.Text.Trim();
            if (txtchajianCount.Text.Trim() != "")
            {
                mod.chajianCount = Convert.ToInt32(txtchajianCount.Text.Trim());
            }
            else
            {
                mod.chajianCount = 0;
            }
            mod.chajianNo = txtchajianNo.Text.Trim();
            mod.chujRaoXianZD = txtchujRaoXianZD.Text.Trim();
            mod.chujTongMD = txtchujTongMD.Text.Trim();
            mod.chujXianJing = txtchujXianJing.Text.Trim();
            mod.chujXianTouCD = txtchujXianTouCD.Text.Trim();
            mod.chujXiantouCL = txtchujXiantouCL.Text.Trim();
            mod.chujZaShu = txtchujZaShu.Text.Trim();
            mod.chuLiMethod = txtchuLiMethod.Text.Trim();
            mod.cijRaoXianZD = txtcijRaoXianZD.Text.Trim();
            mod.cijTongMD = txtcijTongMD.Text.Trim();
            mod.cijXianJing = txtcijXianJing.Text.Trim();
            mod.cijXianTouCD = txtcijXianTouCD.Text.Trim();
            mod.cijXianTouCL = txtcijXianTouCL.Text.Trim();
            mod.cijZaShu = txtcijZaShu.Text.Trim();
            mod.cpjccsEquip = txtcpjccsEquip.Text.Trim();
            mod.cpjccsFuZai = txtcpjccsFuZai.Text.Trim();
            mod.CpjccsJiaoChaBH = txtCpjccsJiaoChaBH.Text.Trim();
            mod.cpjccsNaiYa = txtcpjccsNaiYa.Text.Trim();
            mod.cpjccsShuChuState = txtcpjccsShuChuState.Text.Trim();
            mod.cpjccsShuRuState = txtcpjccsShuRuState.Text.Trim();
            mod.cpjccsTongMD = txtcpjccsTongMD.Text.Trim();
            mod.eDingJC = txteDingJC.Text.Trim();
            mod.guanJiaoZhenLX = txtguanJiaoZhenLX.Text.Trim();
            if (txtguanJIaoZhenLXCount.Text.Trim() != "")
            {
                mod.guanJIaoZhenLXCount = Convert.ToInt32(txtguanJIaoZhenLXCount.Text.Trim());
            }
            else
            {
                mod.guanJIaoZhenLXCount = 0;
            }
            mod.guanJiaoZhenLXTOW = txtguanJiaoZhenLXTOW.Text.Trim();
            if (txtguanJiaoZhenLXTOWCount.Text.Trim() != "")
            {
                mod.guanJiaoZhenLXTOWCount = Convert.ToInt32(txtguanJiaoZhenLXTOWCount.Text.Trim());
            }
            else
            {
                mod.guanJiaoZhenLXTOWCount = 0;
            }
            mod.guiGe = txtguiGe.Text.Trim();

            mod.jingDu = txtjingDu.Text.Trim();
            mod.NeiBZ = txtNeiBZ.Text.Trim();
            mod.NeiBZDW = "psc";
            mod.peiXianSC = txtpeiXianSC.Text.Trim();
            if (txtpeiXianSCCount.Text.Trim() != "")
            {
                mod.peiXianSCCount = Convert.ToDecimal(txtpeiXianSCCount.Text.Trim());
            }
            else
            {
                mod.peiXianSCCount = 0;
            }
            mod.peiXianSR = txtpeiXianSR.Text.Trim();
            if (txtpeiXianSRCount.Text.Trim() != "")
            {
                mod.peiXianSRCount = Convert.ToDecimal(txtpeiXianSRCount.Text.Trim());
            }
            else
            {
                mod.peiXianSRCount = 0;
            }
            mod.productName = txtproductName.Text.Trim();
            mod.productNum = txtproductNum.Text.Trim();
            mod.remark = txtremark.Text.Trim();
            mod.shuChu = txtshuChu.Text.Trim();
            mod.shuChuXC = txtshuChuXC.Text.Trim();
            mod.shuRu = txtshuRu.Text.Trim();
            mod.shuRuXC = txtshuRuXC.Text.Trim();
            if (txttieXiCount.Text.Trim() != "")
            {
                mod.tieXiCount = Convert.ToInt32(txttieXiCount.Text.Trim());
            }
            else
            {
                mod.tieXiCount = 0;
            }
            if (txtwaiBZ.Text.Trim() != "")
            {
                mod.waiBZ = Convert.ToInt32(txtwaiBZ.Text.Trim());
            }
            else
            {
                mod.waiBZ = 0;
            }
            if (txtwaiKeCount.Text.Trim() != "")
            {
                mod.waiKeCount = Convert.ToInt32(txtwaiKeCount.Text.Trim());
            }
            else
            {
                mod.waiKeCount = 0;
            }
            mod.waiKeNo = txtwaiKeNo.Text.Trim();

            if (txtxianQuanCount.Text.Trim() != "")
            {
                mod.xianQuanCount = Convert.ToInt32(txtxianQuanCount.Text.Trim());
            }
            else
            {
                mod.xianQuanCount = 0;
            }
            mod.xianXingdu = txtxianXingdu.Text.Trim();
            mod.xingNeng = txtxingNeng.Text.Trim();
            mod.xqjcyqEquip = txtxqjcyqEquip.Text.Trim();
            mod.xqjcyqFuZai = txtxqjcyqFuZai.Text.Trim();
            mod.xqjcyqJiaoCha = txtxqjcyqJiaoCha.Text.Trim();
            mod.xqjcyqShuChuState = txtxqjcyqShuChuState.Text.Trim();
            mod.xqjcyqShuRuState = txtxqjcyqShuRuState.Text.Trim();
            mod.yongJiaoCS = txtyongJiaoCS.Text.Trim();
            num = ProductsBLL.Update(mod);
            if (isModifyPrintSGDCount)
            {
                //随工单打印次数改为0
                ProOrdersDetailBLL.UpdatePrintInfo(txtproductNum.Text.Trim());
            }
        }
        else
        {
            mod = new ProductsMOD();
            mod.baoHeDian = txtbaoHeDian.Text.Trim();
            mod.bian = txtbianbi.Text.Trim();
            mod.biaoShiAddress = txtbiaoShiAddress.Text.Trim();
            mod.biaoShiNo = txtbiaoShiNo.Text.Trim();


            Boolean fileOK = false;
            //上传外形图纸
            if (fuwaiXingTZ.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fuwaiXingTZ.FileName).ToLower();
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
                    string url = "~/fileUpload/" + fuwaiXingTZ.FileName;

                    if (fuwaiXingTZ.HasFile)
                    {
                        string fileType = fuwaiXingTZ.PostedFile.ContentType;

                        string name = fuwaiXingTZ.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fuwaiXingTZ.SaveAs(Server.MapPath(url));
                            mod.waiXingTZ = url;
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
                mod.waiXingTZ = "";
            }


            //上传标示图片


            if (fubiaoShiPicture.HasFile)
            {
                // 得到文件的后缀
                String fileExtension =
                    System.IO.Path.GetExtension(fubiaoShiPicture.FileName).ToLower();
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
                    string url = "~/fileUpload/" + fubiaoShiPicture.FileName;

                    if (fubiaoShiPicture.HasFile)
                    {
                        string fileType = fubiaoShiPicture.PostedFile.ContentType;

                        string name = fubiaoShiPicture.PostedFile.FileName;  //文件路径
                        FileInfo fileInfo = new FileInfo(name);
                        try
                        {
                            fubiaoShiPicture.SaveAs(Server.MapPath(url));
                            mod.biaoShiPicture = url;
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
                mod.biaoShiPicture = "";
            }
            mod.caiLiao = txtcaiLiao.Text.Trim();
            if (txtchajianCount.Text.Trim() != "")
            {
                mod.chajianCount = Convert.ToInt32(txtchajianCount.Text.Trim());
            }
            else
            {
                mod.chajianCount = 0;
            }
            mod.chajianNo = txtchajianNo.Text.Trim();
            mod.chujRaoXianZD = txtchujRaoXianZD.Text.Trim();
            mod.chujTongMD = txtchujTongMD.Text.Trim();
            mod.chujXianJing = txtchujXianJing.Text.Trim();
            mod.chujXianTouCD = txtchujXianTouCD.Text.Trim();
            mod.chujXiantouCL = txtchujXiantouCL.Text.Trim();
            mod.chujZaShu = txtchujZaShu.Text.Trim();
            mod.chuLiMethod = txtchuLiMethod.Text.Trim();
            mod.cijRaoXianZD = txtcijRaoXianZD.Text.Trim();
            mod.cijTongMD = txtcijTongMD.Text.Trim();
            mod.cijXianJing = txtcijXianJing.Text.Trim();
            mod.cijXianTouCD = txtcijXianTouCD.Text.Trim();
            mod.cijXianTouCL = txtcijXianTouCL.Text.Trim();
            mod.cijZaShu = txtcijZaShu.Text.Trim();
            mod.cpjccsEquip = txtcpjccsEquip.Text.Trim();
            mod.cpjccsFuZai = txtcpjccsFuZai.Text.Trim();
            mod.CpjccsJiaoChaBH = txtCpjccsJiaoChaBH.Text.Trim();
            mod.cpjccsNaiYa = txtcpjccsNaiYa.Text.Trim();
            mod.cpjccsShuChuState = txtcpjccsShuChuState.Text.Trim();
            mod.cpjccsShuRuState = txtcpjccsShuRuState.Text.Trim();
            mod.cpjccsTongMD = txtcpjccsTongMD.Text.Trim();
            mod.eDingJC = txteDingJC.Text.Trim();
            mod.guanJiaoZhenLX = txtguanJiaoZhenLX.Text.Trim();
            if (txtguanJIaoZhenLXCount.Text.Trim() != "")
            {
                mod.guanJIaoZhenLXCount = Convert.ToInt32(txtguanJIaoZhenLXCount.Text.Trim());
            }
            else
            {
                mod.guanJIaoZhenLXCount = 0;
            }
            mod.guanJiaoZhenLXTOW = txtguanJiaoZhenLXTOW.Text.Trim();
            if (txtguanJiaoZhenLXTOWCount.Text.Trim() != "")
            {
                mod.guanJiaoZhenLXTOWCount = Convert.ToInt32(txtguanJiaoZhenLXTOWCount.Text.Trim());
            }
            else
            {
                mod.guanJiaoZhenLXTOWCount = 0;
            }
            mod.guiGe = txtguiGe.Text.Trim();
            mod.isModifyTZ = 0;
            mod.IsModifyWaikeNo = 0;
            mod.jingDu = txtjingDu.Text.Trim();
            mod.NeiBZ = txtNeiBZ.Text.Trim();
            mod.NeiBZDW = "psc";
            mod.peiXianSC = txtpeiXianSC.Text.Trim();
            if (txtpeiXianSCCount.Text.Trim() != "")
            {
                mod.peiXianSCCount = Convert.ToDecimal(txtpeiXianSCCount.Text.Trim());
            }
            else
            {
                mod.peiXianSCCount = 0;
            }
            mod.peiXianSR = txtpeiXianSR.Text.Trim();
            if (txtpeiXianSRCount.Text.Trim() != "")
            {
                mod.peiXianSRCount = Convert.ToDecimal(txtpeiXianSRCount.Text.Trim());
            }
            else
            {
                mod.peiXianSRCount = 0;
            }
            mod.productName = txtproductName.Text.Trim();
            mod.productNum = txtproductNum.Text.Trim();
            mod.remark = txtremark.Text.Trim();
            mod.shuChu = txtshuChu.Text.Trim();
            mod.shuChuXC = txtshuChuXC.Text.Trim();
            mod.shuRu = txtshuRu.Text.Trim();
            mod.shuRuXC = txtshuRuXC.Text.Trim();
            if (txttieXiCount.Text.Trim() != "")
            {
                mod.tieXiCount = Convert.ToInt32(txttieXiCount.Text.Trim());
            }
            else
            {
                mod.tieXiCount = 0;
            }
            if (txtwaiBZ.Text.Trim() != "")
            {
                mod.waiBZ = Convert.ToInt32(txtwaiBZ.Text.Trim());
            }
            else
            {
                mod.waiBZ = 0;
            }
            if (txtwaiKeCount.Text.Trim() != "")
            {
                mod.waiKeCount = Convert.ToInt32(txtwaiKeCount.Text.Trim());
            }
            else
            {
                mod.waiKeCount = 0;
            }
            mod.waiKeNo = txtwaiKeNo.Text.Trim();

            if (txtxianQuanCount.Text.Trim() != "")
            {
                mod.xianQuanCount = Convert.ToInt32(txtxianQuanCount.Text.Trim());
            }
            else
            {
                mod.xianQuanCount = 0;
            }
            mod.xianXingdu = txtxianXingdu.Text.Trim();
            mod.xingNeng = txtxingNeng.Text.Trim();
            mod.xqjcyqEquip = txtxqjcyqEquip.Text.Trim();
            mod.xqjcyqFuZai = txtxqjcyqFuZai.Text.Trim();
            mod.xqjcyqJiaoCha = txtxqjcyqJiaoCha.Text.Trim();
            mod.xqjcyqShuChuState = txtxqjcyqShuChuState.Text.Trim();
            mod.xqjcyqShuRuState = txtxqjcyqShuRuState.Text.Trim();
            mod.yongJiaoCS = txtyongJiaoCS.Text.Trim();

            num = ProductsBLL.Add(mod);
        }
        if (num > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "DetailsPageControl.CloseBox();alert('提交成功');DetailsPageControl.ReflushList('ProductManage/ProductManage.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ListArea", "alert('提交失败');", true);
        }
    }
    /// <summary>
    /// 上传外部图纸
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOk_Click(object sender, EventArgs e)
    {

    }

}