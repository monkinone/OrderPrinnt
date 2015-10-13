<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YewuPrintFaHuoList.aspx.cs" Inherits="OrderPrintWeb.orderManage.YewuPrintFaHuoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).resize(function () {
            ListPageControl.ResizeWindow();
        });
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
    <form id="form1" runat="server" autocomplete="off">
        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>发货情况列表</span>
                </div>
                <div class="fr">
                    <img class="btn" id="btnSave" runat="server" onclick="doPrint()"
                        src="~/themes/default/images/btn/btn_print_nbyj_b_h.png" alt="打印" title="打印" />
                    <%-- <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                </div>
            </div>
            <div id="List" class="listS" style="text-align: left; overflow-x:hidden; overflow-y:auto;" align="center">
                <!--startprint-->
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="border-top: 1px solid #004EA2;">
                    <tr>
                        <th>订单号
                        </th>
                        <th>客户编号
                        </th>
                        <th>产品型号</th>
                        <th>订单总数量</th>
                        <th>已发货数量累计</th>
                        <th>本次发货数量</th>
                        <th>装箱明细</th>
                        <th>件数</th>
                        <th>发货单号</th>
                        <th>货运公司</th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("orderNum") %>
                                </td>
                                <td>
                                    <%#Eval("customNum") %>
                                </td>
                                <td>
                                    <%# Eval("proType") %>
                                </td>
                                <td>
                                    <%# Eval("proNum") %>
                                </td>
                                <td>
                                    <%# GetSendCount( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                </td>
                                <td>
                                    <%# GetLastSendCount( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                </td>
                                <td>
                                    <%# GetBZ(Eval("proType").ToString(),Eval("proNum").ToString()) %>
                                </td>
                                <td>
                                   <%-- <%# Jianshu( Eval("proType").ToString(),Eval("proNum").ToString()) %>--%>
                                     <%# Jianshu( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                </td>

                                <td>
                                    <%# GetSendNum( Eval("orderNum").ToString()) %>
                                </td>
                                <td>
                                    <%#GetHuoyunCom(Eval("orderNum").ToString()) %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <!--endprint-->
            </div>
        </div>
    </form>
</body>
</html>
