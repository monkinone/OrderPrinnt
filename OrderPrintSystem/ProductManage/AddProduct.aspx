<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="ProductManage_AddProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../scripts/Validform/css/style.css" />
    <link href="../scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }
    </script>
    <style type="text/css">
        .selecter
        {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
    <div id="OptBar" class="optbar">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="info">
                    编辑产品信息
                </td>
                <td class="optbtn">
                    <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                        ToolTip="提交" CssClass="btn" />
                    <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                        title="返回" />
                </td>
            </tr>
        </table>
    </div>
    <div class="details">
        <div class="rightinfo" id="RightInfoArea" style="width: auto; height:600px;  overflow:scroll; overflow-x:hidden;">
            <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                <tr>
                    <td class="title1">
                        产品名称：
                    </td>
                    <td class="title1">
                        产品型号：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtproductName" runat="server" CssClass="tbox" Rows="5" datatype="*"
                            nullmsg="请输入产品名称！" errormsg="请输入产品名称！"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtproductNum" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        外包装：
                    </td>
                    <td class="title1">
                        内包装：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtwaiBZ" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>盒
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtNeiBZ" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>PSC
                    </td>
                </tr>
                <tr>
                    <td class="title1" colspan="2">
                        成品参数
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        变比：
                    </td>
                    <td class="title1">
                        精度：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtbianbi" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtjingDu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        线性度：
                    </td>
                    <td class="title1">
                        额定角差：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtxianXingdu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txteDingJC" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        铁芯参数
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        铁芯数量：
                    </td>
                    <td class="title1">
                        规格：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txttieXiCount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtguiGe" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        材料：
                    </td>
                    <td class="title1">
                        性能：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcaiLiao" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtxingNeng" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        处理方式：
                    </td>
                    <td class="title1">
                        饱和点：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchuLiMethod" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtbaoHeDian" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        线圈参数
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        线圈数量：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtxianQuanCount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        初级匝数：
                    </td>
                    <td class="title1">
                        次级匝数：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchujZaShu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcijZaShu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        线径：
                    </td>
                    <td class="title1">
                        线径：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchujXianJing" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcijXianJing" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        绕线指导：
                    </td>
                    <td class="title1">
                        绕线指导：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchujRaoXianZD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcijRaoXianZD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        线头长度：
                    </td>
                    <td class="title1">
                        线头长度：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchujXianTouCD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcijXianTouCD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        线头处理：
                    </td>
                    <td class="title1">
                        线头处理：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchujXiantouCL" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcijXianTouCL" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        同名端：
                    </td>
                    <td class="title1">
                        同名端：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchujTongMD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcijTongMD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info" colspan="2">
                        线圈检测要求
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        设备名称：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtxqjcyqEquip" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        输入状态：
                    </td>
                    <td class="title1">
                        输出状态：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtxqjcyqShuRuState" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtxqjcyqShuChuState" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        角差：
                    </td>
                    <td class="title1">
                        负载：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtxqjcyqJiaoCha" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtxqjcyqFuZai" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        外形参数
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        标示编号：
                    </td>
                    <td class="title1">
                        标识位置：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtbiaoShiNo" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtbiaoShiAddress" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        外壳编号：
                    </td>
                    <td class="title1">
                        外壳数量：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtwaiKeNo" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtwaiKeCount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        用胶参数：
                    </td>
                    <td class="title1">
                        输入方式：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtyongJiaoCS" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtshuRu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        输出方式：
                    </td>
                    <td class="title1">
                        接插件型号：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtshuChu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtchajianNo" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        接插件数量：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtchajianCount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        成品检测参数
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        设备名称：
                    </td>
                    <td class="title1">
                        输入状态：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcpjccsEquip" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcpjccsShuRuState" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        输出状态：
                    </td>
                    <td class="title1">
                        角差：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcpjccsShuChuState" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtCpjccsJiaoChaBH" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        负载：
                    </td>
                    <td class="title1">
                        耐压：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcpjccsFuZai" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcpjccsNaiYa" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        同名端：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcpjccsTongMD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        辅料信息
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        管脚针型号：
                    </td>
                    <td class="title1">
                        管脚针数量：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtguanJiaoZhenLX" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtguanJIaoZhenLXCount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        管脚针型号：
                    </td>
                    <td class="title1">
                        管脚针数量：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtguanJiaoZhenLXTOW" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtguanJiaoZhenLXTOWCount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        输入线长(外留)
                    </td>
                    <td class="title1">
                        输出线长(外留)：
                    </td>
                </tr>
                <tr >
                    <td class="info">
                        <asp:TextBox ID="txtshuRuXC" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtshuChuXC" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        配线要求（输入）：
                    </td>
                    <td class="title1">
                        配线要求（输出）：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtpeiXianSR" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtpeiXianSC" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        输入长度：
                    </td>
                    <td class="title1">
                        输出长度：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtpeiXianSRCount" runat="server" CssClass="tbox" ></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtpeiXianSCCount" runat="server" CssClass="tbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        外形图纸：
                    </td>
                    <td class="title1">
                        标示图片：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:Image ID="imgWaiXingTZ" runat="server" />
                        <asp:FileUpload ID="fuwaiXingTZ" runat="server" />
                    </td>
                    <td class="info">
                        <asp:Image ID="imgbiaoShiPicture" runat="server" />
                        <asp:FileUpload ID="fubiaoShiPicture" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        其他制作要求：
                    </td>
                </tr>
                <tr>
                    <td class="info" colspan="4">
                        <asp:TextBox ID="txtremark" runat="server" CssClass="tarea"  TextMode="MultiLine" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
