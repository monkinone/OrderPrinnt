<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_PrintZYSX" CodeBehind="PrintZYSX.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //  DetailsPageControl.SetEveryAreaSize();
            var HolePageWidth = $(window).width();
            var HolePageHeight = $(window).height();
            var LeftInfoAreaWidth = HolePageWidth * .3;
            var OptBarHeight = $("#OptBar").outerHeight();

            var RightInfoAreaWidth = HolePageWidth;
            $("#RightInfoArea").height(HolePageHeight - OptBarHeight);
            var InfoWidth = HolePageWidth - $(".optbar .title").width() - $(".optbar .optbtn").outerWidth() - 40;
        })
        function js_getDPI() {
            var arrDPI = new Array();
            if (window.screen.deviceXDPI != undefined) {
                arrDPI[0] = window.screen.deviceXDPI;
                arrDPI[1] = window.screen.deviceYDPI;
            }
            else {
                var tmpNode = document.createElement_x("DIV");
                tmpNode.style.cssText = "width:1in;height:1in;position:absolute;left:0px;top:0px;z-index:99;visibility:hidden";
                document.body.appendChild(tmpNode);
                arrDPI[0] = parseInt(tmpNode.offsetWidth);
                arrDPI[1] = parseInt(tmpNode.offsetHeight);
                tmpNode.parentNode.removeChild(tmpNode);
            }
            //分辨率是72像素 / 英寸时，A4纸的尺寸的图像的像素是595×842；

            //分辨率是96像素 / 英寸时，A4纸的尺寸的图像的像素是794×1123；(默认)

            //分辨率是120像素 / 英寸时，A4纸的尺寸的图像的像素是1487×2105；

            //分辨率是150像素 / 英寸时，A4纸的尺寸的图像的像素是1240×1754；

            //分辨率是300像素 / 英寸时，A4纸的尺寸的图像的像素是2480×3508；

            if (arrDPI[0] == 96) {
                $("#tablePrint").css("width", "794px").css("height", "1123px");
            } else if (arrDPI[0 == 72]) {
                $("#tablePrint").css("width", "595px").css("height", "842px");
            } else if (arrDPI[0 == 120]) {
                $("#tablePrint").css("width", "1487px").css("height", "2105px");
            } else if (arrDPI[0 == 150]) {
                $("#tablePrint").css("width", "1240px").css("height", "1754px");
            } else if (arrDPI[0 == 300]) {
                $("#tablePrint").css("width", "2480px").css("height", "3508px");
            }
        }
        //修改打印次数
        function update() {

            $.ajax({
                type: "Post",
                async: false,
                url: "PrintZYSX.aspx/UpdatePrint",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        // alert('成功');
                    } else {
                        // alert('失败');
                    }
                },
                error: function (xml, status) {
                    if (status == 'error') {
                        try {
                            var json = eval('(' + xml.responseText + ')');
                            //                        alert(json.Message + '\n' + json.StackTrace);
                        } catch (e) { }
                    } else {
                        //                    alert(status);
                    }
                }
            });

        }
        function doPrint() {
            // pagesetup_null();
            update();

            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            // window.location.reload();//重新加载
            //DetailsPageControl.CloseBox();//关闭窗口
            //  pagesetup_default()
        }


        function pagesetup_null() {
            //设置网页打印的页眉页脚为空  要降低浏览器安全级别
            var RegWsh = new CreateObject("WScript.Shell");
            RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\header", " ");
            RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\footer", " ");


            //设置页边距   
            //   RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_bottom", "");
            // RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_left", "100");
            //   RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_right", "");
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_top", "10");
        }
        //设置网页打印的页眉页脚为默认值
        function pagesetup_default() {
            var RegWsh = new ActiveXObject("WScript.Shell")
            hkey_key = "header"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&w&b页码，&p/&P")
            hkey_key = "footer"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&u&b&d")
        }


    </script>
     <style type="text/css">
       
        .tb td {
            font-size: 14px;
            padding-left:5px;
            padding-right:5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">客户发货前注意事项
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />

                    </td>
                </tr>
            </table>
        </div>
        <div class="details" style="text-align: left; width: auto;">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea">
                <table id="tablePrint" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td>
                            <table width="768px">
                                <tr><td style="text-align:center; font-size:26px; font-weight:bold;">客户发货前注意事项及装箱清单</td></tr>
                            </table>
                            <table width="768px">
                                <tr><td style="font-size:20px; padding-left:10px; ">客户编号：<asp:Label ID="lblcustomNUM" runat="server"></asp:Label>&nbsp;&nbsp;客户名称：<asp:Label ID="lblCompanyName" runat="server"></asp:Label></td></tr>
                            </table>
                            <table class="form tb" cellpadding="0" cellspacing="0" style="width: 768px; border-top:1px solid #000; border-left-color:#000;" align="center" id="Table1">
                               
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblzysx" runat="server" Style="line-height: 25px; padding-left: 5px; padding-right: 5px;"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>收货人：<asp:Label ID="lblShouhuoren" runat="server"></asp:Label></td>
                                    <td>电话：<asp:Label ID="lblphone" runat="server"></asp:Label></td>
                                    <td>手机：<asp:Label ID="lblTelphone" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">公司名称：<asp:Label ID="lblCompanyNames" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">地址：<asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lbltsyq" runat="server" Style="line-height: 25px; padding-left: 5px; padding-right: 5px;"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!--endprint-->
        </div>
    </form>
</body>
</html>
