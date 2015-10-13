<%@ Page Language="C#" AutoEventWireup="true" Inherits="ProductManage_AddProduct" CodeBehind="AddProduct.aspx.cs" ValidateRequest="false" %>
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
    <%--<script src="../scripts/ckeditor/ckeditor.js" type="text/javascript"></script>--%><script src="../scripts/kindeditor/kindeditor-all-min.js"></script>
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        KindEditor.ready(function (K) {
            window.editor = K.create('.ckeditor', {
                uploadJson: '/scripts/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/scripts/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });
        });

        $(function () {
            $('#txtproductName').focus();
            DetailsPageControl.SetEveryAreaSize();
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                },
                datatype: {

                    "peiXianSRCount": function () {
                        var reg1 = $("#txtpeiXianSRCount").val();

                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        if (reg1.length > 0) {

                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return true; }

                    },
                    "peiXianSCCount": function () {
                        var reg2 = $("#txtpeiXianSCCount").val();
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        if (reg2.length > 0) {
                            if (reg2 == "" || TestRgexp(re, reg2)) { return true; } else { return false; }
                        } else { return true; }
                    },
                    "gujiaCount": function () {
                        var reg1 = $("#txtgujiaCount").val();

                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        if (reg1.length > 0) {
                            if (TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "tongpaiCount": function () {
                        var reg2 = $("#txttongpaiCount").val();
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        if (reg2.length > 0) {
                            if (TestRgexp(re, reg2)) { return true; }
                            else { return false; }
                        } else { return true; }
                    }
                    ,
                    "cihuanCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg3 = $("#txtcihuanCount").val();
                        if (reg3.length > 0) {
                            if (TestRgexp(re, reg3)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "duanziCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg4 = $("#txtduanziCount").val();
                        if (reg4.length > 0) {
                            if (TestRgexp(re, reg4)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "xianlubanCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg5 = $("#txtxianlubanCount").val();
                        if (reg5.length > 0) {
                            if (TestRgexp(re, reg5)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "jiaopianCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg6 = $("#txtjiaopianCount").val();
                        if (reg6.length > 0) {
                            if (TestRgexp(re, reg6)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "pingbiCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg7 = $("#txtpingbiCount").val();
                        if (reg7.length > 0) {
                            if (TestRgexp(re, reg7)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "wenyaguanCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg8 = $("#txtwenyaguanCount").val();
                        if (reg8.length > 0) {
                            if (TestRgexp(re, reg8)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "dianzuCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg9 = $("#txtdianzuCount").val();
                        if (reg9.length > 0) {
                            if (TestRgexp(re, reg9)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "luosiCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg10 = $("#txtluosiCount").val();
                        if (reg10.length > 0) {
                            if (TestRgexp(re, reg10)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "resuotaoguanCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg11 = $("#txtresuotaoguanCount").val();
                        if (reg11.length > 0) {
                            if (TestRgexp(re, reg11)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "anzhuangpjCount": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg12 = $("#txtanzhuangPJCount").val();
                        if (reg12.length > 0) {
                            if (TestRgexp(re, reg12)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "yuanqijian1Count": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg13 = $("#txtyuanQiJian1Count").val();
                        if (reg13.length > 0) {
                            if (TestRgexp(re, reg13)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "yuanqijian2Count": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg14 = $("#txtyuanQiJian2Count").val();
                        if (reg14.length > 0) {
                            if (TestRgexp(re, reg14)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "yuanqijian3Count": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg15 = $("#txtyuanQiJian3Count").val();
                        if (reg15.length > 0) {
                            if (TestRgexp(re, reg15)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "yuanqijian4Count": function () {
                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        var reg16 = $("#txtyuanQiJian4Count").val();

                        if (reg16.length > 0) {
                            if (TestRgexp(re, reg16)) { return true; }
                            else { return false; }
                        } else { return true; }
                    }

                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }

        function isExistProType() {
            if ($('#txtproductNum').val() != "") {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddProduct.aspx/isExistProType",
                    data: "{'proType':\"" + $('#txtproductNum').val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            return true;
                        } else {
                            alert('该产品型号已存在！');
                            $('#txtproductNum').val('');
                            return false;
                        }
                    }
                });
            }
        }
    </script>
    <style type="text/css">
        .selecter {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">编辑产品信息
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
            <div class="rightinfo" id="RightInfoArea">
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">产品名称：
                        </td>
                        <td class="title1">产品型号：
                        </td>
                        <td class="title1">外包装：(盒)
                        </td>
                        <td class="title1">内包装：(PSC)
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtproductName" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入产品名称！" errormsg="请输入产品名称！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproductNum" runat="server" CssClass="tbox" datatype="*" errmsg="请输入产品型号！" onblur="isExistProType();"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtwaiBZ" runat="server" CssClass="tbox" datatype="n" nullmsg="请输入外包装！" errmsg="请输入数字！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtNeiBZ" runat="server" CssClass="tbox" datatype="n" nullmsg="请输入内包装！" errmsg="请输入数字！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">包装盒规格：
                        </td>
                        <td class="title1">包装箱规格：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtbaoZhuangHeGG" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入包装盒规格！" errormsg="请输入包装盒规格！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtbaoZhuangXiangGG" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">成品参数<br />
                            <hr />
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">变比：
                        </td>
                        <td class="title1">精度：
                        </td>
                        <td class="title1">线性度：
                        </td>
                        <td class="title1">额定角差：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtbianbi" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入变比！" errormsg="请输入变比！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtjingDu" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入精度！" errormsg="请输入精度！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtxianXingdu" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入线性度！" errormsg="请输入线性度！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txteDingJC" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入额定角差！" errormsg="请输入额定角差！"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">铁芯参数<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">铁芯数量：
                        </td>
                        <td class="title1">规格：
                        </td>
                        <td class="title1">材料：
                        </td>
                        <td class="title1">性能：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txttieXiCount" runat="server" CssClass="tbox" datatype="n" nullmsg="请输入铁芯数量！" errmsg="请输入数字！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtguiGe" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入规格！" errormsg="请输入规格！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcaiLiao" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入材料！" errormsg="请输入材料！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtxingNeng" runat="server" CssClass="tbox" nullmsg="请输入性能！" errormsg="请输入性能！"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">处理方式：
                        </td>
                        <td class="title1">饱和点：
                        </td>
                        <td class="title1">饱和点测试条件：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtchuLiMethod" runat="server" CssClass="tbox" nullmsg="请输入处理方式！" errormsg="请输入处理方式！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtbaoHeDian" runat="server" CssClass="tbox" nullmsg="请输入饱和点！" errormsg="请输入饱和点！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtbaoHeDianTestTJ" runat="server" CssClass="tbox" nullmsg="请输入饱和点测试条件！" errormsg="请输入饱和点测试条件！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">线圈参数<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">线圈数量：
                        </td>
                        <td class="title1">初级匝数：
                        </td>

                        <td class="title1">线径：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtxianQuanCount" runat="server" CssClass="tbox" datatype="n" nullmsg="请输入线圈数量！" errmsg="请输入数字！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtchujZaShu" runat="server" CssClass="tbox" nullmsg="请输入初级匝数！" errormsg="请输入初级匝数！"></asp:TextBox>
                        </td>

                        <td class="info">
                            <asp:TextBox ID="txtchujXianJing" runat="server" CssClass="tbox" Rows="5" nullmsg="请输入线径！" errormsg="请输入线径！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">绕线指导：
                        </td>
                        <td class="title1">线头长度：
                        </td>
                        <td class="title1">线头处理：
                        </td>
                        <td class="title1">同名端：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtchujRaoXianZD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtchujXianTouCD" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtchujXiantouCL" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtchujTongMD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">次级匝数：
                        </td>

                        <td class="title1">线径：
                        </td>
                        <td class="title1">绕线指导：
                        </td>
                        <td class="title1">线头长度：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtcijZaShu" runat="server" CssClass="tbox" nullmsg="请输入次级匝数！" errormsg="请输入次级匝数！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcijXianJing" runat="server" CssClass="tbox" nullmsg="请输入线径！" errormsg="请输入线径！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcijRaoXianZD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcijXianTouCD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">线头处理：
                        </td>
                        <td class="title1">同名端：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtcijXianTouCL" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcijTongMD" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">线圈检测要求<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">设备名称：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtxqjcyqEquip" runat="server" CssClass="tbox" nullmsg="请输入设备名称！" errormsg="请输入设备名称！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">输入状态：
                        </td>
                        <td class="title1">输出状态：
                        </td>
                        <td class="title1">角差：
                        </td>
                        <td class="title1">负载：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtxqjcyqShuRuState" runat="server" CssClass="tbox" nullmsg="请输入输入状态！" errormsg="请输入输入状态！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtxqjcyqShuChuState" runat="server" CssClass="tbox" nullmsg="请输入输出状态！" errormsg="请输入输出状态！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtxqjcyqJiaoCha" runat="server" CssClass="tbox" nullmsg="请输入角差！" errormsg="请输入角差！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtxqjcyqFuZai" runat="server" CssClass="tbox" nullmsg="请输入负载！" errormsg="请输入负载！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">外形参数<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">标示编号：
                        </td>
                        <td class="title1">标识位置：
                        </td>
                        <td class="title1">外壳编号：
                        </td>
                        <td class="title1">外壳数量：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtbiaoShiNo" runat="server" CssClass="tbox" nullmsg="请输入标示编号！" errormsg="请输入标示编号！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtbiaoShiAddress" runat="server" CssClass="tbox" nullmsg="请输入标识位置！" errormsg="请输入标识位置！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtwaiKeNo" runat="server" CssClass="tbox" nullmsg="请输入外壳编号！" errormsg="请输入外壳编号！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtwaiKeCount" runat="server" CssClass="tbox" datatype="n" nullmsg="请输入外壳数量！" errmsg="请输入数字！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">用胶参数：
                        </td>
                        <td class="title1">输入方式：
                        </td>
                        <td class="title1">输出方式：
                        </td>

                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtyongJiaoCS" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtshuRu" runat="server" CssClass="tbox" nullmsg="请输入输入方式！" errormsg="请输入输入方式！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtshuChu" runat="server" CssClass="tbox" nullmsg="请输入输出方式！" errormsg="请输入输出方式！"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="title1">接插件型号：
                        </td>
                        <td class="title1">接插件数量：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtchajianNo" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtchajianCount" runat="server" CssClass="tbox" datatype="n" nullmsg="请输入接插件数量！" errmsg="请输入数字！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">成品检测参数<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">设备名称：
                        </td>
                        <td class="title1">输入状态：
                        </td>
                        <td class="title1">输出状态：
                        </td>
                        <td class="title1">角差：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtcpjccsEquip" runat="server" CssClass="tbox" nullmsg="请输入设备名称！" errormsg="请输入设备名称！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcpjccsShuRuState" runat="server" CssClass="tbox" nullmsg="请输入输入状态！" errormsg="请输入输入状态！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcpjccsShuChuState" runat="server" CssClass="tbox" nullmsg="请输入输出状态！" errormsg="请输入输出状态！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtCpjccsJiaoChaBH" runat="server" CssClass="tbox" nullmsg="请输入角差！" errormsg="请输入角差！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">负载：
                        </td>
                        <td class="title1">耐压：
                        </td>
                        <td class="title1">同名端：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtcpjccsFuZai" runat="server" CssClass="tbox" nullmsg="请输入负载！" errormsg="请输入负载！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcpjccsNaiYa" runat="server" CssClass="tbox" nullmsg="请输入耐压！" errormsg="请输入耐压！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcpjccsTongMD" runat="server" CssClass="tbox" nullmsg="请输入同名端！" errormsg="请输入同名端！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">辅料信息<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">输入管脚针型号：
                        </td>
                        <td class="title1">输入管脚针数量：
                        </td>
                        <td class="title1">输出管脚针型号：
                        </td>
                        <td class="title1">输出管脚针数量：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtguanJiaoZhenLX" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtguanJIaoZhenLXCount" runat="server" CssClass="tbox" datatype="n" errmsg="请输入数字！" nullmsg="请输入输入管脚针数量！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtguanJiaoZhenLXTOW" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtguanJiaoZhenLXTOWCount" runat="server" CssClass="tbox" datatype="n" errmsg="请输入数字！" nullmsg="请输入输出管脚针数量！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">输入线长(外留)
                        </td>
                        <td class="title1">输出线长(外留)：
                        </td>
                        <td class="title1">配线要求（输入）：
                        </td>
                        <td class="title1">配线要求（输出）：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtshuRuXC" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtshuChuXC" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtpeiXianSR" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtpeiXianSC" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">输入长度：
                        </td>
                        <td class="title1">输出长度：
                        </td>

                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtpeiXianSRCount" runat="server" CssClass="tbox" datatype="peiXianSRCount" errmsg="请输入数字！" nullmsg="请输入输入长度！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtpeiXianSCCount" runat="server" CssClass="tbox" datatype="peiXianSCCount" errmsg="请输入数字！" nullmsg="请输入输出长度！"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="title1" colspan="4">外形图纸：
                        </td>
                        <td class="title1" style="display: none;">标示图片：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                            <asp:Image ID="imgWaiXingTZ" runat="server" Style="max-width: 500px; max-height: 300px;" /><br />
                            <asp:FileUpload ID="fuwaiXingTZ" runat="server" CssClass="filebox" />
                        </td>
                        <td class="info" style="display: none;">
                            <asp:Image ID="imgbiaoShiPicture" runat="server" Width="200" Height="200" />
                            <asp:FileUpload ID="fubiaoShiPicture" runat="server" CssClass="filebox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">其他制作要求：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                            <%-- <asp:TextBox ID="" runat="server" CssClass="tarea"  TextMode="MultiLine" ></asp:TextBox>--%>
                            <div id="divRemark" runat="server"></div>
                            <textarea class="ckeditor" cols="95" id="txtremark" name="editor1" rows="10" runat="server" style="width:790px;height:300px;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">工艺注意事项：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                            <%-- <asp:TextBox ID="" runat="server" CssClass="tarea"  TextMode="MultiLine" ></asp:TextBox>--%>
                            <textarea class="ckeditor" cols="95" id="txtGongyi" name="editor1" rows="10" runat="server" style="width:790px;height:300px;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size: 14px; font-weight: bold;">取料单参数<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%">
                                <tr>
                                    <td class="title1">骨架型号：
                                    </td>
                                    <td class="title1">骨架数量：
                                    </td>
                                    <td class="title1">骨架参数要求：
                                    </td>
                                    <td class="title1">铜排型号：
                                    </td>
                                    <td class="title1">铜排数量：
                                    </td>
                                    <td class="title1">铜排参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtguJia" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtgujiaCount" runat="server" CssClass="tbox" datatype="gujiaCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtgujiaCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txttongPai" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txttongpaiCount" runat="server" CssClass="tbox" datatype="tongpaiCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txttongpaiCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">磁环型号：
                                    </td>
                                    <td class="title1">磁环数量：
                                    </td>
                                    <td class="title1">磁环参数要求：
                                    </td>
                                    <td class="title1">端子型号：
                                    </td>
                                    <td class="title1">端子数量：
                                    </td>
                                    <td class="title1">端子参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtciHuan" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtcihuanCount" runat="server" CssClass="tbox" datatype="cihuanCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtcihuanCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtduanZi" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtduanziCount" runat="server" CssClass="tbox" datatype="duanziCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtduanziCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">线路板型号：
                                    </td>
                                    <td class="title1">线路板数量：
                                    </td>
                                    <td class="title1">线路板参数要求：
                                    </td>
                                    <td class="title1">胶片型号：
                                    </td>
                                    <td class="title1">胶片数量：
                                    </td>
                                    <td class="title1">胶片参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtxianLuBan" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtxianlubanCount" runat="server" CssClass="tbox" datatype="xianlubanCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtxianlubanCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtjiaoPian" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtjiaopianCount" runat="server" CssClass="tbox" datatype="jiaopianCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtjiaopianCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">屏蔽型号：
                                    </td>
                                    <td class="title1">屏蔽数量：
                                    </td>
                                    <td class="title1">屏蔽参数要求：
                                    </td>
                                    <td class="title1">稳压管型号：
                                    </td>
                                    <td class="title1">稳压管数量：
                                    </td>
                                    <td class="title1">稳压管参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtpingBi" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtpingbiCount" runat="server" CssClass="tbox" datatype="pingbiCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtpingbiCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtwenYaGuan" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtwenyaguanCount" runat="server" CssClass="tbox" datatype="wenyaguanCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtwenyaguanCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">电阻型号：
                                    </td>
                                    <td class="title1">电阻数量：
                                    </td>
                                    <td class="title1">电阻参数要求：
                                    </td>
                                    <td class="title1">螺丝型号：
                                    </td>
                                    <td class="title1">螺丝数量：
                                    </td>
                                    <td class="title1">螺丝参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtdianZu" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtdianzuCount" runat="server" CssClass="tbox" datatype="dianzuCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtdianzuCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtluoSi" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtluosiCount" runat="server" CssClass="tbox" datatype="luosiCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtluosiCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">热缩套管型号：
                                    </td>
                                    <td class="title1">热缩套管数量：
                                    </td>
                                    <td class="title1">热缩套管参数要求：
                                    </td>
                                    <td class="title1">安装配件型号：
                                    </td>
                                    <td class="title1">安装配件数量：
                                    </td>
                                    <td class="title1">安装配件参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtreSuoTaoGuan" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtresuotaoguanCount" runat="server" CssClass="tbox" datatype="resuotaoguanCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtresuotaoguanCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtanZhuangPJ" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtanzhuangPJCount" runat="server" CssClass="tbox" datatype="anzhuangpjCount" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtanzhuangPJCanshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">元器件1型号：
                                    </td>
                                    <td class="title1">元器件1数量：
                                    </td>
                                    <td class="title1">元器件1参数要求：
                                    </td>
                                    <td class="title1">元器件2型号：
                                    </td>
                                    <td class="title1">元器件2数量：
                                    </td>
                                    <td class="title1">元器件2参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian1" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian1Count" runat="server" CssClass="tbox" datatype="yuanqijian1Count" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian1Canshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian2" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian2Count" runat="server" CssClass="tbox" datatype="yuanqijian2Count" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian2Canshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title1">元器件3型号：
                                    </td>
                                    <td class="title1">元器件3数量：
                                    </td>
                                    <td class="title1">元器件3参数要求：
                                    </td>
                                    <td class="title1">元器件4型号：
                                    </td>
                                    <td class="title1">元器件4数量：
                                    </td>
                                    <td class="title1">元器件4参数要求：
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian3" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian3Count" runat="server" CssClass="tbox" datatype="yuanqijian3Count" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian3Canshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian4" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian4Count" runat="server" CssClass="tbox" datatype="yuanqijian4Count" errmsg="请输入数字！"></asp:TextBox>
                                    </td>
                                    <td class="info">
                                        <asp:TextBox ID="txtyuanQiJian4Canshu" runat="server" CssClass="tbox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1" colspan="4">&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
