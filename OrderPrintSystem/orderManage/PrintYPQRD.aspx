<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintYPQRD.aspx.cs" Inherits="orderManage_PrintYPQRD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
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
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印样品确认单
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                        <%--   <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="details" style="text-align: left; height: 685px; width: auto; overflow: scroll; overflow-x: hidden;">
            <!--startprint-->
            <table class="rightinfo" id="RightInfoArea">
                <table class="form " cellpadding="0" cellspacing="0" style="width: 685px;" align="center" id="Table1" runat="server">
                    <tr>
                        <td width="100"></td>
                        <td width="100"></td>
                        <td width="200" style="font-size:28px; font-weight:bold;">样品确认单</td>
                        <td width="100"></td>
                        <td width="100">文件编号：</td>
                        <td width="100"></td>
                    </tr>
                </table>
                <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #004EA2; width: 685px;" align="center" id="tabJingTai" runat="server">

                    <tr>
                        <td>送样编号</td>
                        <td width="100"></td>
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
                        <td></td>
                    </tr>
                    <tr>
                        <td>供应商编号</td>
                        <td></td>
                        <td>供应商名称</td>
                        <td>北京霍远科技</td>
                        <td>产品类别</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>收样人</td>
                        <td></td>
                        <td>送样日期</td>
                        <td>
                            <asp:Label ID="lblSendTime" runat="server"></asp:Label></td>
                        <td>送样原因</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>送检日期</td>
                        <td></td>
                        <td>收样单位</td>
                        <td colspan="3">
                            <asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>是否为代用料</td>
                        <td colspan="3">
                            <input type="checkbox" />是&nbsp;&nbsp;<input type="checkbox" />否</td>
                        <td>评样接受人</td>
                        <td></td>

                    </tr>
                </table>
                <table style="width: 685px; margin-left: 5px; border-bottom: 1px solid #000; border-right: 1px solid #000; border-left: 1px solid #000;" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td colspan="5">检样说明：</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">接受</td>
                        <td colspan="2">拒收</td>
                    </tr>
                    <tr>
                        <td>外观</td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>色差</td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>功能及安装工艺</td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>可靠性</td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>电气性能</td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>温度系数</td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                        <td colspan="2">
                            <input type="checkbox" /></td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>客户检验标准：</td>
                        <td colspan="2">额定变比：</td>
                        <td colspan="2">一次测量范围：</td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">负载电阻：</td>
                        <td colspan="2">相移要求：</td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">测 试 点：</td>
                        <td colspan="2">检验仪器：</td>
                    </tr>
                </table>
                <table style="width: 685px; margin-left: 5px; border-bottom: 1px solid #000; border-right: 1px solid #000; border-left: 1px solid #000;" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td>检验结论：</td>
                        <td colspan="7">合格<input type="checkbox" /></td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="7">不合格<input type="checkbox" />&nbsp;&nbsp;需改进的项目：</td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="8" style="text-align: left;">批量要求：</td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">检样工程师：</td>
                        <td colspan="2">日期：</td>
                        <td colspan="2">审核：</td>
                        <td colspan="2">日期：</td>
                    </tr>
                </table>
        </div>
        <!--endprint-->
        </div>
    </form>
</body>
</html>
