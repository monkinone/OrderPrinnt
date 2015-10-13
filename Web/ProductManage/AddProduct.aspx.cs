using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.Model;
using OrderPrintSystem.BLL;
using System.IO;
using System.Web.Services;

public partial class ProductManage_AddProduct : PageBase
{
    ProductsMOD mod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (UserInfo.UserType == 2)
            {
                txtbaoHeDian.Enabled = false;
                txtbianbi.Enabled = false;
                txtbiaoShiAddress.Enabled = false;
                txtbiaoShiNo.Enabled = false;


                fuwaiXingTZ.Enabled = false;
                txtcaiLiao.Enabled = false;

                txtchajianCount.Enabled = false;

                txtchajianNo.Enabled = false;

                txtchujXianJing.Enabled = false;

                txtchujZaShu.Enabled = false;
                txtchuLiMethod.Enabled = false;


                txtcijXianJing.Enabled = false;

                txtcijZaShu.Enabled = false;
                txtcpjccsEquip.Enabled = false;
                txtcpjccsFuZai.Enabled = false;
                txtCpjccsJiaoChaBH.Enabled = false;
                txtcpjccsNaiYa.Enabled = false;
                txtcpjccsShuChuState.Enabled = false;
                txtcpjccsShuRuState.Enabled = false;
                txtcpjccsTongMD.Enabled = false;
                txteDingJC.Enabled = false;
                txtguanJiaoZhenLX.Enabled = false;
                txtguanJIaoZhenLXCount.Enabled = false;
                txtguanJiaoZhenLXTOW.Enabled = false;
                txtguanJiaoZhenLXTOWCount.Enabled = false;
                txtguiGe.Enabled = false;
                txtjingDu.Enabled = false;
                txtNeiBZ.Enabled = false;


                txtproductName.Enabled = false;
                txtproductNum.Enabled = false;
                txtremark.Disabled = false;
                txtshuChu.Enabled = false;
                txtshuChuXC.Enabled = false;
                txtshuRu.Enabled = false;
                txtshuRuXC.Enabled = false;
                txttieXiCount.Enabled = false;
                txtwaiBZ.Enabled = false;

                txtwaiKeCount.Enabled = false;
                txtwaiKeNo.Enabled = false;
                txtxianQuanCount.Enabled = false;

                txtxianXingdu.Enabled = false;
                txtxingNeng.Enabled = false;
                txtxqjcyqEquip.Enabled = false;
                txtxqjcyqFuZai.Enabled = false;
                txtxqjcyqJiaoCha.Enabled = false;
                txtxqjcyqShuChuState.Enabled = false;
                txtxqjcyqShuRuState.Enabled = false;

                txtGongyi.Disabled = false;



                txtbaoZhuangHeGG.Enabled = false;
                txtbaoZhuangXiangGG.Enabled = false;
                txtbaoHeDianTestTJ.Enabled = false;
                //取料单
                txtguJia.Enabled = false;
                txttongPai.Enabled = false;
                txtciHuan.Enabled = false;
                txtduanZi.Enabled = false;
                txtxianLuBan.Enabled = false;
                txtjiaoPian.Enabled = false;
                txtpingBi.Enabled = false;
                txtwenYaGuan.Enabled = false;
                txtdianZu.Enabled = false;
                txtluoSi.Enabled = false;
                txtreSuoTaoGuan.Enabled = false;
                txtanZhuangPJ.Enabled = false;
                txtyuanQiJian1.Enabled = false;
                txtyuanQiJian2.Enabled = false;
                txtyuanQiJian3.Enabled = false;
                txtyuanQiJian4.Enabled = false;

                txtgujiaCanshu.Enabled = false;
                txtgujiaCount.Enabled = false;
                txttongpaiCanshu.Enabled = false;
                txttongpaiCount.Enabled = false;
                txtcihuanCanshu.Enabled = false;
                txtcihuanCount.Enabled = false;
                txtduanziCanshu.Enabled = false;
                txtduanziCount.Enabled = false;
                txtxianlubanCanshu.Enabled = false;
                txtxianlubanCount.Enabled = false;
                txtjiaopianCanshu.Enabled = false;
                txtjiaopianCount.Enabled = false;
                txtpingbiCanshu.Enabled = false;
                txtpingbiCount.Enabled = false;
                txtwenyaguanCanshu.Enabled = false;
                txtwenyaguanCount.Enabled = false;
                txtdianzuCanshu.Enabled = false;
                txtdianzuCount.Enabled = false;
                txtluosiCanshu.Enabled = false;
                txtluosiCount.Enabled = false;
                txtresuotaoguanCanshu.Enabled = false;
                txtresuotaoguanCount.Enabled = false;
                txtanzhuangPJCanshu.Enabled = false;
                txtanzhuangPJCount.Enabled = false;
                txtyuanQiJian1Canshu.Enabled = false;
                txtyuanQiJian1Count.Enabled = false;
                txtyuanQiJian2Canshu.Enabled = false;
                txtyuanQiJian2Count.Enabled = false;
                txtyuanQiJian3Canshu.Enabled = false;
                txtyuanQiJian3Count.Enabled = false;
                txtyuanQiJian4Canshu.Enabled = false;
                txtyuanQiJian4Count.Enabled = false;
            }
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
                    if (mod.biaoShiPicture != "")
                    {
                        imgbiaoShiPicture.ImageUrl = mod.biaoShiPicture;
                    }
                    else
                    {
                        imgbiaoShiPicture.ImageUrl = "/images/nophoto.jpg";
                    }
                    if (mod.waiXingTZ != "")
                    {
                        imgWaiXingTZ.ImageUrl = mod.waiXingTZ;
                    }
                    else
                    {
                        imgWaiXingTZ.ImageUrl = "/images/nophoto.jpg";
                    }

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
                    if (UserInfo.UserType == 2)
                    {
                        divRemark.InnerHtml = mod.remark;
                        divRemark.Visible = true;
                        txtremark.Visible = false;

                    }
                    else
                    {
                        txtremark.Value = mod.remark;
                        divRemark.Visible = false;
                        txtremark.Visible = true;
                    }
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
                    txtGongyi.Value = mod.GongyiZYSX;



                    txtbaoZhuangHeGG.Text = mod.BaoZhuangHeGG;
                    txtbaoZhuangXiangGG.Text = mod.BaoZhuangXiangGG;
                    txtbaoHeDianTestTJ.Text = mod.BaoHeDianTestTJ;
                    //取料单
                    txtguJia.Text = mod.GuJia;
                    txttongPai.Text = mod.TongPai;
                    txtciHuan.Text = mod.CiHuan;
                    txtduanZi.Text = mod.DuanZi;
                    txtxianLuBan.Text = mod.XianLuBan;
                    txtjiaoPian.Text = mod.JiaoPian;
                    txtpingBi.Text = mod.PingBi;
                    txtwenYaGuan.Text = mod.WenYaGuan;
                    txtdianZu.Text = mod.DianZu;
                    txtluoSi.Text = mod.LuoSi;
                    txtreSuoTaoGuan.Text = mod.ReSuoTaoGuan;
                    txtanZhuangPJ.Text = mod.AnZhuangPJ;
                    txtyuanQiJian1.Text = mod.YuanQiJian1;
                    txtyuanQiJian2.Text = mod.YuanQiJian2;
                    txtyuanQiJian3.Text = mod.YuanQiJian3;
                    txtyuanQiJian4.Text = mod.YuanQiJian4;


                    txtgujiaCanshu.Text = mod.GujiaCanshu;
                    txtgujiaCount.Text = mod.GujiaCount.ToString() == "0" ? "" : mod.GujiaCount.ToString();
                    txttongpaiCanshu.Text = mod.TongpaiCanshu;
                    txttongpaiCount.Text = mod.TongpaoCount.ToString() == "0" ? "" : mod.TongpaoCount.ToString();
                    txtcihuanCanshu.Text = mod.CihuanCanshu;
                    txtcihuanCount.Text = mod.CihuanCount.ToString() == "0" ? "" : mod.CihuanCount.ToString();
                    txtduanziCanshu.Text = mod.DuanziCanshu;
                    txtduanziCount.Text = mod.DuanziCount.ToString() == "0" ? "" : mod.DuanziCount.ToString();
                    txtxianlubanCanshu.Text = mod.XianlubanCanshu;
                    txtxianlubanCount.Text = mod.XianlubanCount.ToString() == "0" ? "" : mod.XianlubanCount.ToString();
                    txtjiaopianCanshu.Text = mod.JiaopianCanshu;
                    txtjiaopianCount.Text = mod.JiaopianCount.ToString() == "0" ? "" : mod.JiaopianCount.ToString();
                    txtpingbiCanshu.Text = mod.PingbiCanshu;
                    txtpingbiCount.Text = mod.PingbiCount.ToString() == "0" ? "" : mod.PingbiCount.ToString();
                    txtwenyaguanCanshu.Text = mod.WenyaguanCanshu;
                    txtwenyaguanCount.Text = mod.WenyaguanCount.ToString() == "0" ? "" : mod.WenyaguanCount.ToString();
                    txtdianzuCanshu.Text = mod.DianzuCanshu;
                    txtdianzuCount.Text = mod.DianzuCount.ToString() == "0" ? "" : mod.DianzuCount.ToString();
                    txtluosiCanshu.Text = mod.LuosiCanshu;
                    txtluosiCount.Text = mod.LuosiCount.ToString() == "0" ? "" : mod.LuosiCount.ToString();
                    txtresuotaoguanCanshu.Text = mod.ResuotaoguanCanshu;
                    txtresuotaoguanCount.Text = mod.ResuotaoguanCount.ToString() == "0" ? "" : mod.ResuotaoguanCount.ToString();
                    txtanzhuangPJCanshu.Text = mod.AnzhuangPJCanshu;
                    txtanzhuangPJCount.Text = mod.AnzhuangPJCount.ToString() == "0" ? "" : mod.AnzhuangPJCount.ToString();
                    txtyuanQiJian1Canshu.Text = mod.Yuanqijian1Canshu;
                    txtyuanQiJian1Count.Text = mod.Yuanqijian1Count1.ToString() == "0" ? "" : mod.Yuanqijian1Count1.ToString();
                    txtyuanQiJian2Canshu.Text = mod.Yuanqijian2Canshu1;
                    txtyuanQiJian2Count.Text = mod.Yuanqijian2Count1.ToString() == "0" ? "" : mod.Yuanqijian2Count1.ToString();
                    txtyuanQiJian3Canshu.Text = mod.Yuanqijian3Canshu1;
                    txtyuanQiJian3Count.Text = mod.Yuanqijian3Count1.ToString() == "0" ? "" : mod.Yuanqijian3Count1.ToString();
                    txtyuanQiJian4Canshu.Text = mod.Yuanqijian4Canshu1;
                    txtyuanQiJian4Count.Text = mod.Yuanqijian4Count1.ToString() == "0" ? "" : mod.Yuanqijian4Count1.ToString();
                }
                //产品编号不允许修改
               // txtproductNum.Enabled = false;
            }
            else
            {
                imgWaiXingTZ.Visible = false;
                imgbiaoShiPicture.Visible = false;
                divRemark.Visible = false;
                txtremark.Visible = true;
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
            else
            {
                mod.isModifyTZ = 0;
            }
            if (mod.waiKeNo != txtwaiKeNo.Text.Trim())
            {
                mod.IsModifyWaikeNo = 1;
                isModifyPrintSGDCount = true;
            }
            else
            {
                mod.IsModifyWaikeNo = 0;
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
                    string url = "~/fileUpload/" + fuwaiXingTZ.FileName.Split('.')[0] + DateTime.Now.ToString("yyyyMMddhhmmss") + fileExtension;

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
                    string url = "~/fileUpload/" + fubiaoShiPicture.FileName ;

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
            if (UserInfo.UserType == 2)
            {
                mod.remark = divRemark.InnerHtml;
            }
            else
            {
                mod.remark = txtremark.Value.Trim();

            }

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
            mod.GongyiZYSX = txtGongyi.Value;

            mod.BaoZhuangHeGG = txtbaoZhuangHeGG.Text.Trim();
            mod.BaoZhuangXiangGG = txtbaoZhuangXiangGG.Text.Trim();
            mod.BaoHeDianTestTJ = txtbaoHeDianTestTJ.Text.Trim();
            mod.GuJia = txtguJia.Text.Trim();
            mod.TongPai = txttongPai.Text.Trim();
            mod.CiHuan = txtciHuan.Text.Trim();
            mod.DuanZi = txtduanZi.Text.Trim();
            mod.XianLuBan = txtxianLuBan.Text.Trim();
            mod.JiaoPian = txtjiaoPian.Text.Trim();
            mod.PingBi = txtpingBi.Text.Trim();
            mod.WenYaGuan = txtwenYaGuan.Text.Trim();
            mod.DianZu = txtdianZu.Text.Trim();
            mod.LuoSi = txtluoSi.Text.Trim();
            mod.ReSuoTaoGuan = txtreSuoTaoGuan.Text.Trim();
            mod.AnZhuangPJ = txtanZhuangPJ.Text.Trim();
            mod.YuanQiJian1 = txtyuanQiJian1.Text.Trim();
            mod.YuanQiJian2 = txtyuanQiJian2.Text.Trim();
            mod.YuanQiJian3 = txtyuanQiJian3.Text.Trim();
            mod.YuanQiJian4 = txtyuanQiJian4.Text.Trim();

            mod.GujiaCanshu = txtgujiaCanshu.Text.Trim();
            if (txtgujiaCount.Text.Trim() != "")
            {
                decimal gujiaCount = 0;
                decimal.TryParse(txtgujiaCount.Text.Trim(), out gujiaCount);
                mod.GujiaCount = gujiaCount;
            }
            else
            {
                mod.GujiaCount = 0;
            }
            mod.TongpaiCanshu = txttongpaiCanshu.Text.Trim();
            if (txttongpaiCount.Text.Trim() != "")
            {
                decimal gujiaCount = 0;
                decimal.TryParse(txttongpaiCount.Text.Trim(), out gujiaCount);
                mod.TongpaoCount = gujiaCount;
            }
            else
            {
                mod.TongpaoCount = 0;
            }
            mod.CihuanCanshu = txtcihuanCanshu.Text.Trim();
            if (txtcihuanCount.Text.Trim() != "")
            {
                decimal gujiaCount = 0;
                decimal.TryParse(txtcihuanCount.Text.Trim(), out gujiaCount);
                mod.CihuanCount = gujiaCount;
            }
            else
            { 
                mod.CihuanCount = 0;
            }
            mod.DuanziCanshu = txtduanziCanshu.Text.Trim();
            if (txtduanziCount.Text.Trim() != "")
            {
                decimal gujiaCount = 0;
                decimal.TryParse(txtduanziCount.Text.Trim(), out gujiaCount);
                mod.DuanziCount = gujiaCount;
            }
            else
            {
                mod.DuanziCount = 0; 
            }
            mod.XianlubanCanshu = txtxianlubanCanshu.Text.Trim();
            if (txtxianlubanCount.Text.Trim() != "") 
            {
                decimal xianlubanCount = 0;
                decimal.TryParse(txtxianlubanCount.Text.Trim(), out xianlubanCount);
                mod.XianlubanCount = xianlubanCount;
            } 
            else 
            { mod.XianlubanCount = 0; 
            }
            mod.JiaopianCanshu = txtjiaopianCanshu.Text.Trim();
            if (txtjiaopianCount.Text.Trim() != "") 
            {
                decimal xianlubanCount = 0;
                decimal.TryParse(txtjiaopianCount.Text.Trim(), out xianlubanCount);
                mod.JiaopianCount = xianlubanCount; 
            } 
            else 
            { 
                mod.JiaopianCount = 0; 
            }
            mod.PingbiCanshu = txtpingbiCanshu.Text.Trim();
            if (txtpingbiCount.Text.Trim() != "") 
            {
                decimal pingbiCount = 0;
                decimal.TryParse(txtpingbiCount.Text.Trim(), out pingbiCount);
                mod.PingbiCount = pingbiCount;
            } 
            else
            { 
                mod.PingbiCount = 0;
            }
            mod.WenyaguanCanshu = txtwenyaguanCanshu.Text.Trim();
            if (txtwenyaguanCount.Text.Trim() != "")
            {
                decimal pingbiCount = 0;
                decimal.TryParse(txtwenyaguanCount.Text.Trim(), out pingbiCount);
                mod.WenyaguanCount = pingbiCount;
            } 
            else
            { 
                mod.WenyaguanCount = 0; 
            }
            mod.DianzuCanshu = txtdianzuCanshu.Text.Trim();
            if (txtdianzuCount.Text.Trim() != "")
            {
                decimal dianzuCount = 0;
                decimal.TryParse(txtdianzuCount.Text.Trim(),out dianzuCount);
                mod.DianzuCount = dianzuCount;
            }
            else
            {
                mod.DianzuCount = 0;
            }
            mod.LuosiCanshu = txtluosiCanshu.Text.Trim();
            if (txtluosiCount.Text.Trim() != "")
            {
                decimal dianzuCount = 0;
                decimal.TryParse(txtluosiCount.Text.Trim(), out dianzuCount);
                mod.LuosiCount = dianzuCount;
            }
            else
            { 
                mod.LuosiCount = 0;
            }
            mod.ResuotaoguanCanshu = txtresuotaoguanCanshu.Text.Trim();
            if (txtresuotaoguanCount.Text.Trim() != "")
            {
                decimal resuotaoguanCount = 0;
                decimal.TryParse(txtresuotaoguanCount.Text.Trim(),out resuotaoguanCount);
                mod.ResuotaoguanCount = resuotaoguanCount;
            }
            else
            { 
                mod.ResuotaoguanCount = 0;
            }
            mod.AnzhuangPJCanshu = txtanzhuangPJCanshu.Text.Trim();
            if (txtanzhuangPJCount.Text.Trim() != "")
            {
                decimal resuotaoguanCount = 0;
                decimal.TryParse(txtanzhuangPJCount.Text.Trim(), out resuotaoguanCount);
                mod.AnzhuangPJCount = resuotaoguanCount;
            }
            else
            {
                mod.AnzhuangPJCount = 0;
            }
            mod.Yuanqijian1Canshu = txtyuanQiJian1Canshu.Text.Trim();
            if (txtyuanQiJian1Count.Text.Trim() != "")
            {
                decimal yuanqjCount1 = 0;
                decimal.TryParse(txtyuanQiJian1Count.Text.Trim(),out yuanqjCount1);
                mod.Yuanqijian1Count1 = yuanqjCount1;
            }
            else
            {
                mod.Yuanqijian1Count1 = 0;
            }
            mod.Yuanqijian2Canshu1 = txtyuanQiJian2Canshu.Text.Trim();
            if (txtyuanQiJian2Count.Text.Trim() != "")
            {
                decimal yuanqjCount2 = 0;
                decimal.TryParse(txtyuanQiJian2Count.Text.Trim(), out yuanqjCount2);
                mod.Yuanqijian2Count1 = yuanqjCount2;
            }
            else
            {
                mod.Yuanqijian2Count1 = 0;
            }
            mod.Yuanqijian3Canshu1 = txtyuanQiJian3Canshu.Text.Trim();
            if (txtyuanQiJian3Count.Text.Trim() != "")
            {
                decimal yuanqj3Count = 0;
                decimal.TryParse(txtyuanQiJian3Count.Text.Trim(), out yuanqj3Count);
                mod.Yuanqijian3Count1 = yuanqj3Count;
            }
            else
            {
                mod.Yuanqijian3Count1 = 0;
            }
            mod.Yuanqijian4Canshu1 = txtyuanQiJian4Canshu.Text.Trim();
            if (txtyuanQiJian4Count.Text.Trim() != "")
            {
                decimal yuanqj4Count = 0;
                decimal.TryParse(txtyuanQiJian4Count.Text.Trim(),out yuanqj4Count);
                mod.Yuanqijian4Count1 = yuanqj4Count;
            }
            else
            {
                mod.Yuanqijian4Count1 = 0;
            }



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
                    string url = "~/fileUpload/" + fuwaiXingTZ.FileName.Split('.')[0] + DateTime.Now.ToString("yyyyMMddhhmmss")+fileExtension;

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
                Response.Write("<script>alert('请上传外形图纸!');</script>");
                return;
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
            mod.remark = txtremark.Value.Trim();
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
            mod.GongyiZYSX = txtGongyi.Value;

            mod.BaoZhuangHeGG = txtbaoZhuangHeGG.Text.Trim();
            mod.BaoZhuangXiangGG = txtbaoZhuangXiangGG.Text.Trim();
            mod.BaoHeDianTestTJ = txtbaoHeDianTestTJ.Text.Trim();
            //取料单
            mod.GuJia = txtguJia.Text.Trim();
            mod.TongPai = txttongPai.Text.Trim();
            mod.CiHuan = txtciHuan.Text.Trim();
            mod.DuanZi = txtduanZi.Text.Trim();
            mod.XianLuBan = txtxianLuBan.Text.Trim();
            mod.JiaoPian = txtjiaoPian.Text.Trim();
            mod.PingBi = txtpingBi.Text.Trim();
            mod.WenYaGuan = txtwenYaGuan.Text.Trim();
            mod.DianZu = txtdianZu.Text.Trim();
            mod.LuoSi = txtluoSi.Text.Trim();
            mod.ReSuoTaoGuan = txtreSuoTaoGuan.Text.Trim();
            mod.AnZhuangPJ = txtanZhuangPJ.Text.Trim();
            mod.YuanQiJian1 = txtyuanQiJian1.Text.Trim();
            mod.YuanQiJian2 = txtyuanQiJian2.Text.Trim();
            mod.YuanQiJian3 = txtyuanQiJian3.Text.Trim();
            mod.YuanQiJian4 = txtyuanQiJian4.Text.Trim();

            mod.GujiaCanshu = txtgujiaCanshu.Text.Trim();
            if (txtgujiaCount.Text.Trim() != "")
            {
                decimal gujiaCount = 0;
                decimal.TryParse(txtgujiaCount.Text.Trim(), out gujiaCount);
                mod.GujiaCount = gujiaCount;
            }
            else
            {
                mod.GujiaCount = 0;
            }
            mod.TongpaiCanshu = txttongpaiCanshu.Text.Trim();
            if (txttongpaiCount.Text.Trim() != "")
            {
                decimal tongpaiCount = 0;
                decimal.TryParse(txttongpaiCount.Text.Trim(),out tongpaiCount);
                mod.TongpaoCount = tongpaiCount;
            }
            else
            {
                mod.TongpaoCount = 0;
            }
            mod.CihuanCanshu = txtcihuanCanshu.Text.Trim();
            if (txtcihuanCount.Text.Trim() != "")
            {
                decimal cihuanCount = 0;
                decimal.TryParse(txtcihuanCount.Text.Trim(), out cihuanCount);
                mod.CihuanCount = cihuanCount;
            }
            else { mod.CihuanCount = 0; }
            mod.DuanziCanshu = txtduanziCanshu.Text.Trim();
            if (txtduanziCount.Text.Trim() != "")
            {
                decimal duanziCount = 0;
                decimal.TryParse(txtduanziCount.Text.Trim(),out duanziCount);
                mod.DuanziCount = duanziCount;
            }
            else 
            { 
                mod.DuanziCount = 0; 
            }
            mod.XianlubanCanshu = txtxianlubanCanshu.Text.Trim();
            if (txtxianlubanCount.Text.Trim() != "") 
            {
                decimal xianlubanCount = 0;
                decimal.TryParse(txtxianlubanCount.Text.Trim(), out xianlubanCount);
                mod.XianlubanCount = xianlubanCount;
            }
            else
            { 
                mod.XianlubanCount = 0;
            }
            mod.JiaopianCanshu = txtjiaopianCanshu.Text.Trim();
            if (txtjiaopianCount.Text.Trim() != "")
            {
                decimal jiaopianCount = 0;
                decimal.TryParse(txtjiaopianCount.Text.Trim(),out jiaopianCount);
                mod.JiaopianCount = jiaopianCount;
            } 
            else 
            { 
                mod.JiaopianCount = 0;
            }
            mod.PingbiCanshu = txtpingbiCanshu.Text.Trim();
            if (txtpingbiCount.Text.Trim() != "") {
                decimal jiaopianCount = 0;
                decimal.TryParse(txtpingbiCount.Text.Trim(), out jiaopianCount);
                mod.PingbiCount = jiaopianCount; 
            }
            else
            { 
                mod.PingbiCount = 0;
            }
            mod.WenyaguanCanshu = txtwenyaguanCanshu.Text.Trim();
            if (txtwenyaguanCount.Text.Trim() != "")
            {
                decimal wenyaguanCount = 0;
                decimal.TryParse(txtwenyaguanCount.Text.Trim(),out wenyaguanCount);
                mod.WenyaguanCount = wenyaguanCount;
            } 
            else
            { 
                mod.WenyaguanCount = 0; 
            }
            mod.DianzuCanshu = txtdianzuCanshu.Text.Trim();
            if (txtdianzuCount.Text.Trim() != "")
            {
                decimal wenyaguanCount = 0;
                decimal.TryParse(txtdianzuCount.Text.Trim(), out wenyaguanCount);
                mod.DianzuCount = wenyaguanCount;
            }
            else
            {
                mod.DianzuCount = 0;
            }
            mod.LuosiCanshu = txtluosiCanshu.Text.Trim();
            if (txtluosiCount.Text.Trim() != "")
            {

                decimal luosiCount = 0;
                decimal.TryParse(txtluosiCount.Text.Trim(),out luosiCount);
                mod.LuosiCount = luosiCount;
            }
            else 
            { 
                mod.LuosiCount = 0; 
            }
            mod.ResuotaoguanCanshu = txtresuotaoguanCanshu.Text.Trim();
            if (txtresuotaoguanCount.Text.Trim() != "")
            {
                decimal luosiCount = 0;
                decimal.TryParse(txtresuotaoguanCount.Text.Trim(), out luosiCount);
                mod.ResuotaoguanCount = luosiCount;
            }
            else { mod.ResuotaoguanCount = 0; }
            mod.AnzhuangPJCanshu = txtanzhuangPJCanshu.Text.Trim();
            if (txtanzhuangPJCount.Text.Trim() != "")
            {
                decimal anzhuangPJCount = 0;
                decimal.TryParse(txtanzhuangPJCount.Text.Trim(),out anzhuangPJCount );
                mod.AnzhuangPJCount = anzhuangPJCount;
            }
            else
            {
                mod.AnzhuangPJCount = 0;
            }
            mod.Yuanqijian1Canshu = txtyuanQiJian1Canshu.Text.Trim();
            if (txtyuanQiJian1Count.Text.Trim() != "")
            {
                decimal anzhuangPJCount = 0;
                decimal.TryParse(txtyuanQiJian1Count.Text.Trim(), out anzhuangPJCount);
                mod.Yuanqijian1Count1 = anzhuangPJCount;
            }
            else
            {
                mod.Yuanqijian1Count1 = 0;
            }
            mod.Yuanqijian2Canshu1 = txtyuanQiJian2Canshu.Text.Trim();
            if (txtyuanQiJian2Count.Text.Trim() != "")
            {
                decimal anzhuangPJCount = 0;
                decimal.TryParse(txtyuanQiJian2Count.Text.Trim(), out anzhuangPJCount);
                mod.Yuanqijian2Count1 = anzhuangPJCount;
            }
            else
            {
                mod.Yuanqijian2Count1 = 0;
            }
            mod.Yuanqijian3Canshu1 = txtyuanQiJian3Canshu.Text.Trim();
            if (txtyuanQiJian3Count.Text.Trim() != "")
            {
                decimal anzhuangPJCount = 0;
                decimal.TryParse(txtyuanQiJian3Count.Text.Trim(), out anzhuangPJCount);
                mod.Yuanqijian3Count1 = anzhuangPJCount;
            }
            else
            {
                mod.Yuanqijian3Count1 = 0;
            }
            mod.Yuanqijian4Canshu1 = txtyuanQiJian4Canshu.Text.Trim();
            if (txtyuanQiJian4Count.Text.Trim() != "")
            {
                decimal anzhuangPJCount = 0;
                decimal.TryParse(txtyuanQiJian4Count.Text.Trim(), out anzhuangPJCount);
                mod.Yuanqijian4Count1 = anzhuangPJCount;
            }
            else
            {
                mod.Yuanqijian4Count1 = 0;
            }
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
}