<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSendList.aspx.cs" Inherits="orderManage_PrintSendList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function check() {
            var result = true;
            var Repeater = document.getElementById("<%=rptPro.ClientID %>");
            var txt = Repeater.getElementsByTagName("input");

            for (var i = 0; i < txt.length; i++) {
                if (txt[i].value == "") {
                    result = false;
                    break;

                }
            }
            if (result) {
                return true;
            } else {
                return false;
            }
        }
        function doPrint() {
            // pagesetup_null();
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
                    <td class="info">修改送货单
                    </td>
                    <td class="optbtn">
                        <%--  <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />--%>
                        <%--   <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../themes/default/images/btn/btn_print_nbyj_b_h.png" ToolTip="打印" OnClick="btnPrint_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details" style="text-align: left; height: 800px; width: auto; overflow: scroll; overflow-x: hidden;">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea" style="margin-top: 15px;">
                <div style="text-align: center;">
                    <h1 style="font-size: 28px; font-weight: bold;">送 货 单</h1>
                </div>
                <table class="form" cellpadding="0" cellspacing="0" style="width: 800px; margin-top: 10px;" align="center">
                    <tr>
                        <td>收货单位Receiving unit：</td>
                        <td>
                            <asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
                        <td>发货日期Shipped Date:</td>
                        <td>
                            <asp:Label ID="lblPrintTime" runat="server"></asp:Label></td>

                    </tr>
                </table>
                <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #004EA2; width: 800px;" align="center" id="Table1">

                    <tr>
                        <th>序号<br />
                            number</th>
                        <th>名称<br />
                            Name</th>
                        <th>规格型号<br />
                            Model number</th>
                        <th>变比<br />
                            turns ratio</th>
                        <th>单位<br />
                            unit</th>
                        <th>数量<br />
                            Quantity</th>
                        <th>单价<br />
                            Unit Price</th>
                        <th>金额<br />
                            amount</th>
                        <th>备注<br />
                            Note</th>
                    </tr>
                    <asp:Repeater ID="rptPro" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.ItemIndex + 1 %></td>
                                <td>互感器<br />
                                    Transformers</td>
                                <td>
                                    <asp:Label ID="lblProType" runat="server" Text=' <%# Eval("proType") %>'></asp:Label></td>
                                <td><%# GetBianBi(Eval("proType").ToString()) %></td>
                                <td>PCS</td>
                                <td>
                                    <asp:TextBox ID="txtProNum" runat="server" AutoPostBack="True" BorderStyle="None" OnTextChanged="txtProNum_TextChanged" Width="50"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="lblPrice" runat="server" Text=' <%# Eval("proPrice") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="200" BorderStyle="None"></asp:TextBox></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

                <table class="form " cellpadding="0" cellspacing="0" style="width: 800px; margin-top: 10px;" align="center">
                    <tr>
                        <td>发货单位及经办人：</td>
                        <td></td>
                        <td>订单号：</td>
                        <td></td>
                        <td>收货单位及经手人：</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">请在收货后三天内核对以下项目：1、出厂检验报告1份。2、送货单2份，超过以上期限，视为默认接收。</td>

                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center;">白联（存根)</td>
                        <td colspan="3">红联、黄联（交客户）</td>
                    </tr>

                </table>

            </div>
            <!--endprint-->
        </div>
    </form>
</body>
</html>
