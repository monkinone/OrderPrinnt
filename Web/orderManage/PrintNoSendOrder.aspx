<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintNoSendOrder.aspx.cs" Inherits="OrderPrintWeb.orderManage.PrintNoSendOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
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
      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UP_Search" UpdateMode="Conditional" OnLoad="UP_Search_Load">
            <ContentTemplate>
                <div id="QueryArea" class="queryarea">
                   
                    <div class="btnarea">
                      
                       
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="UP_DocumentShare" UpdateMode="Conditional" OnLoad="UP_DocumentShare_Load">
            <ContentTemplate>--%>
                <div id="ListArea" class="listarea" style="overflow-x:hidden; overflow-y:auto;">
                    <div id="OptArea" class="optarea">
                        <div class="fl tishi">
                            <span>未完成订单列表</span>
                        </div>
                        <div class="fr">
                            <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                        </div>
                    </div>
                    <div id="List" class="listS">
                         <table width="90%">
                        <tr>
                            <td class="title1">
                                订单号： <input type="text" id="txtorderNum" runat="server" class="tbox" style="width: 100px;" />
                                &nbsp;&nbsp;产品型号:<input type="text" id="txtproType" runat="server" class="tbox" style="width: 100px;"/>
                                  &nbsp;&nbsp;客户名称:<input type="text" id="txtcustomNum" runat="server" class="tbox" style="width: 100px;" />
                                  &nbsp;&nbsp;  <asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                            OnClick="btnSearch_Click" ToolTip="查询" />
                                  &nbsp;&nbsp; <asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current"  Text="清空"
                            OnClick="IBtn_Empty_Click" />
                            </td>
                        </tr>
                       
                    </table>
                        <!--startprint-->
                         <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" >
                             <tr>
                                 <td>
                                      未完成订单总量：<asp:Label ID="lblCount" runat="server"></asp:Label>
                                 </td>
                             </tr>
                             </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="border-top:1px solid #004EA2;">
                            <tr>
                                <td >订单号
                                </td>
                                <td >客户名称
                                </td>
                                <td >型号</td>
                                <td>数量</td>
                                <td>参数</td>
                                <td>发货方式</td>
                                <td >计划发货日期</td>
                            </tr>
                            <asp:Repeater ID="rpt_userinfo" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("orderNum")%>
                                        </td>
                                        <td>
                                            <%# Eval("companyName")%>
                                        </td>
                                        <td>
                                            <%# Eval("proType")%>
                                        </td>
                                        <td>
                                            <%# Eval("dcNoSendCount")%>
                                        </td>
                                        <td>
                                            <%# GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()) %>
                                           <%-- <label  title="<%# GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()) %>"><%# GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()).ToString().Length>20?GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()).ToString().Substring(0,20)+"...":GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()).ToString() %></label>--%>
                                        </td>
                                        <td>
                                            <%# Eval("remark").ToString() %>
                                           <%-- <label  title="<%# Eval("remark").ToString() %>"><%# Eval("remark").ToString().Length>20?Eval("remark").ToString().Substring(0,20)+"...":Eval("remark").ToString() %></label>--%>
                                        </td>
                                        <td>
                                            <%# Eval("planSendTime","{0:yyyy-MM-dd}")%>
                                        </td>
                                      
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                         <!--endprint-->
                    </div>
                   
                </div>

         <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
