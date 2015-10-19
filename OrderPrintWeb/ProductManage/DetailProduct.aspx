<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailProduct.aspx.cs" Inherits="OrderPrintWeb.ProductManage.DetailProduct" %>

<!DOCTYPE html>

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
                    <td class="info">预览产品信息
                    </td>
                    <td class="optbtn">
                   
                        <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
            <div class="rightinfo" id="RightInfoArea"  >
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">产品名称：
                        </td>
                        <td class="title1">产品型号：
                        </td>
                        <td class="title1">外包装：
                        </td>
                        <td class="title1">内包装：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:Label ID="txtproductName" runat="server"  datatype="*"
                                nullmsg="请输入产品名称！" errormsg="请输入产品名称！"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtproductNum" runat="server"  datatype="*" errmsg="请输入产品型号！" onblur="isExistProType();"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtwaiBZ" runat="server"  datatype="n" errmsg="请输入数字！"></asp:Label>&nbsp;盒
                        </td>
                        <td class="info">
                            <asp:Label ID="txtNeiBZ" runat="server"  datatype="n" errmsg="请输入数字！"></asp:Label>&nbsp;PSC
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
                            <asp:Label ID="txtbaoZhuangHeGG" runat="server"  datatype="*"
                                nullmsg="请输入包装盒规格！" errormsg="请输入包装盒规格！"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtbaoZhuangXiangGG" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">成品参数<br />
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
                            <asp:Label ID="txtbianbi" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtjingDu" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtxianXingdu" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txteDingJC" runat="server"  ></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">铁芯参数<br />
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
                            <asp:Label ID="txttieXiCount" runat="server"  datatype="n" errmsg="请输入数字！"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtguiGe" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcaiLiao" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtxingNeng" runat="server"  ></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">处理方式：
                        </td>
                        <td class="title1">饱和点：
                        </td>  <td class="title1">饱和点测试条件：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:Label ID="txtchuLiMethod" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtbaoHeDian" runat="server"  ></asp:Label>
                        </td>  <td class="info">
                            <asp:Label ID="txtbaoHeDianTestTJ" runat="server"  nullmsg="请输入饱和点测试条件！" errormsg="请输入饱和点测试条件！"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">线圈参数<br />
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
                            <asp:Label ID="txtxianQuanCount" runat="server"  datatype="n" errmsg="请输入数字！"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtchujZaShu" runat="server" ></asp:Label>
                        </td>

                        <td class="info">
                            <asp:Label ID="txtchujXianJing" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtchujRaoXianZD" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtchujXianTouCD" runat="server" ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtchujXiantouCL" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtchujTongMD" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtcijZaShu" runat="server" ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcijXianJing" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcijRaoXianZD" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcijXianTouCD" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtcijXianTouCL" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcijTongMD" runat="server"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">线圈检测要求<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">设备名称：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:Label ID="txtxqjcyqEquip" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtxqjcyqShuRuState" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtxqjcyqShuChuState" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtxqjcyqJiaoCha" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtxqjcyqFuZai" runat="server"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">外形参数<br />
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
                            <asp:Label ID="txtbiaoShiNo" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtbiaoShiAddress" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtwaiKeNo" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtwaiKeCount" runat="server"  datatype="n" errmsg="请输入数字！"></asp:Label>
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
                            <asp:Label ID="txtyongJiaoCS" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtshuRu" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtshuChu" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtchajianNo" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtchajianCount" runat="server"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">成品检测参数<br />
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
                            <asp:Label ID="txtcpjccsEquip" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcpjccsShuRuState" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcpjccsShuChuState" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtCpjccsJiaoChaBH" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtcpjccsFuZai" runat="server" ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcpjccsNaiYa" runat="server" ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcpjccsTongMD" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">辅料信息<br />
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
                            <asp:Label ID="txtguanJiaoZhenLX" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtguanJIaoZhenLXCount" runat="server" ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtguanJiaoZhenLXTOW" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtguanJiaoZhenLXTOWCount" runat="server" ></asp:Label>
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
                            <asp:Label ID="txtshuRuXC" runat="server"   ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtshuChuXC" runat="server"   ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtpeiXianSR" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtpeiXianSC" runat="server"  ></asp:Label>
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
                            <asp:Label ID="txtpeiXianSRCount" runat="server"  ></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="txtpeiXianSCCount" runat="server"  ></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td class="title1" colspan="4">外形图纸：
                        </td>
                        <td class="title1" style="display:none;">标示图片：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                            <asp:Image ID="imgWaiXingTZ" runat="server" style="max-width:500px; max-height:300px;"  />
                          
                        </td>
                        <td class="info"  style="display:none;">
                            <asp:Image ID="imgbiaoShiPicture" runat="server" Width="200" Height="200" />
                        
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">其他制作要求：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                            <%-- <asp:Label ID="" runat="server" CssClass="tarea"  TextMode="MultiLine" ></asp:Label>--%>
                            <div id="txtremark"  runat="server"></div>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">工艺注意事项：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                           
                            <div  id="txtGongyi"  runat="server"></div>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="4" style="font-size:14px; font-weight:bold;">取料单参数<br />
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
                                        <asp:Label ID="txtguJia" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtgujiaCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtgujiaCanshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txttongPai" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txttongpaiCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txttongpaiCanshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtciHuan" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtcihuanCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtcihuanCanshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtduanZi" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtduanziCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtduanziCanshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtxianLuBan" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtxianlubanCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtxianlubanCanshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtjiaoPian" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtjiaopianCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtjiaopianCanshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtpingBi" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtpingbiCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtpingbiCanshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtwenYaGuan" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtwenyaguanCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtwenyaguanCanshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtdianZu" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtdianzuCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtdianzuCanshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtluoSi" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtluosiCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtluosiCanshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtreSuoTaoGuan" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtresuotaoguanCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtresuotaoguanCanshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtanZhuangPJ" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtanzhuangPJCount" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtanzhuangPJCanshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtyuanQiJian1" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian1Count" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian1Canshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian2" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian2Count" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian2Canshu" runat="server" ></asp:Label>
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
                                        <asp:Label ID="txtyuanQiJian3" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian3Count" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian3Canshu" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian4" runat="server"  Rows="5"></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian4Count" runat="server" ></asp:Label>
                                    </td>
                                    <td class="info">
                                        <asp:Label ID="txtyuanQiJian4Canshu" runat="server" ></asp:Label>
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
