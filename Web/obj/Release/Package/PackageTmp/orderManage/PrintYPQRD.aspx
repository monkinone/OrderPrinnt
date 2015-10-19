<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_PrintYPQRD" CodeBehind="PrintYPQRD.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="ProgId" content="Excel.Sheet" />
    <meta name="Generator" content="WPS Office ET" />
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <%-- <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>--%>
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

        });
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
                url: "PrintYPQRD.aspx/UpdatePrint",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //   alert('成功');
                    } else {
                        //  alert('失败');
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
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_bottom", "5");
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_left", "5");
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_right", "5");
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_top", "5");
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
            font-size: 20px;
            padding-left: 5px;
        }
        .tdLable
        {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印样品确认单
                    </td>
                    <td class="optbtn">
                        <%--<input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />--%>
                        <%--   <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../themes/default/images/btn/btn_print_nbyj_b_h.png" ToolTip="打印" OnClick="btnPrint_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details" style="text-align: left;">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea">
                <table id="tablePrint" align="center">
                    <tr>
                        <td>
                            <table class="form " cellpadding="0" cellspacing="0" style="width: 768px; border-top-color: #000;" align="center" id="Table1" runat="server">
                                <tr>
                                    <td width="100"></td>
                                    <td width="100"></td>
                                    <td width="200" style="font-size: 28px; font-weight: bold;">样品确认单</td>
                                    <td width="100"></td>
                                    <td width="100">文件编号：</td>
                                    <td width="100"></td>
                                </tr>
                            </table>
                            <table class="form tb" cellpadding="0" cellspacing="0" style="font-size: 20px; border-top: 1px solid #000; border-left-color: #000; width: 768px;" align="center" id="tabJingTai" runat="server">

                                <tr>
                                    <td>送样编号</td>
                                    <td width="100">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="100" BorderWidth="0"></asp:TextBox></td>
                                    <td>送样数量</td>
                                    <td width="100">
                                        <asp:Label ID="lblProNum" runat="server"></asp:Label></td>
                                    <td>送样工厂</td>
                                    <td width="100">
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>产品名称</td>
                                    <td>
                                        <asp:Label ID="lblProName" runat="server"></asp:Label></td>
                                    <td>型号规格</td>
                                    <td>
                                        <asp:Label ID="lblProType" runat="server"></asp:Label></td>
                                    <td>品牌</td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" Width="100" BorderWidth="0"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>供应商编号</td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" Width="100" BorderWidth="0"></asp:TextBox></td>
                                    <td>供应商名称</td>
                                    <td>北京霍远科技</td>
                                    <td>产品类别</td>
                                    <td>
                                        <asp:TextBox ID="TextBox4" runat="server" Width="100" BorderWidth="0"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>收样人</td>
                                    <td>
                                        <asp:TextBox ID="TextBox5" runat="server" Width="100" BorderWidth="0"></asp:TextBox>


                                    </td>
                                    <td>送样日期</td>
                                    <td>
                                        <asp:Label ID="lblSendTime" runat="server"></asp:Label></td>
                                    <td>送样原因</td>
                                    <td>
                                        <asp:TextBox ID="TextBox6" runat="server" Width="100" BorderWidth="0"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>送检日期</td>
                                    <td></td>
                                    <td>收样单位</td>
                                    <td colspan="3">

                                        <asp:TextBox ID="txtCompanyName" Width="350" BorderStyle="None" TextMode="MultiLine" Font-Size="11pt" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>是否为代用料</td>
                                    <td colspan="3">
                                        <span style="font-size: 20px">□</span>是&nbsp;&nbsp;<span style="font-size: 20px">□</span>否</td>
                                    <td>评样接受人</td>
                                    <td>
                                        <asp:TextBox ID="TextBox7" runat="server" Width="100" BorderWidth="0"></asp:TextBox></td>

                                </tr>
                            </table>
                            <table style="width: 768px; font-size: 20px; padding-left: 10px; margin-left: 6px; border-bottom: 1px solid #000; border-right: 1px solid #000; border-left: 1px solid #000;" cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td colspan="5">检样说明：</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2" class="tdLable">接受</td>
                                    <td colspan="2" class="tdLable">拒收</td>
                                </tr>
                                <tr>
                                    <td>外观</td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>色差</td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>功能及安装工艺</td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>可靠性</td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>电气性能</td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>温度系数</td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                    <td colspan="2" class="tdLable">
                                        <span style="font-size: 20px" >□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>客户检验标准：</td>
                                    <td>额定变比：</td>
                                    <td><input type="text" style="border:none;border-bottom:1px solid"/></td>
                                    <td>一次测量范围：</td>
                                    <td><input type="text" style="border:none;border-bottom:1px solid"/></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td >负载电阻：</td>
                                     <td><input type="text" style="border:none;border-bottom:1px solid"/></td>
                                    <td >相移要求：</td>
                                     <td><input type="text" style="border:none;border-bottom:1px solid"/></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td >测 试 点：</td>
                                     <td><input type="text" style="border:none;border-bottom:1px solid"/></td>
                                    <td >检验仪器：</td>
                                     <td><input type="text" style="border:none;border-bottom:1px solid"/></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <table style="width: 768px; margin-left: 6px; font-size: 20px; padding-left: 10px; border-bottom: 1px solid #000; border-right: 1px solid #000; border-left: 1px solid #000;" cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 120px;">检验结论：</td>
                                    <td colspan="7">合格<span style="font-size: 20px">□</span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="7">不合格<span style="font-size: 20px">□</span>
                                      &nbsp;&nbsp;需改进的项目：
                                      <input type="text" style="width:auto;border:none;border-bottom:1px solid"/>
                                    </td>                   
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="text-align: left; height: 70px;">批量要求：</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>检样工程师：</td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td >日期：</td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td >审核：</td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td >日期：</td>
                                    <td>&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
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
