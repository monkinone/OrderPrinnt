<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoSendList.aspx.cs" Inherits="OrderPrintWeb.orderManage.NoSendList" %>

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
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
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
        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>未完成订单列表</span>
                </div>
                <div class="fr">
                    <img class="btn" id="btnSave" runat="server" onclick="window.open('PrintNoSendOrder.aspx','打印','80%','90%')"
                        src="~/themes/default/images/btn/btn_print_nbyj_b_h.png" alt="打印" title="打印" />
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1">订单号:<input type="text" id="txtorderNum" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;产品型号:<input type="text" id="txtproType" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;客户名称:<input type="text" id="txtcustomNum" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;<asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                                OnClick="btnSearch_Click" ToolTip="查询" />
                            &nbsp;&nbsp;<asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current" Text="清空"
                                OnClick="IBtn_Empty_Click" />
                        </td>
                        <td>
                            未完成订单总量：<asp:Label ID="lblCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top: 5px;">
                    <tr>
                        <th>订单号
                        </th>
                        <th>客户名称
                        </th>
                        <th >型号</th>
                        <th>数量</th>
                        <th>参数</th>
                        <th>特殊要求</th>
                        <th>计划发货日期</th>
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
                                   <%-- <%# Eval("companyName")%>--%>
                                     <label title="<%# Eval("companyName").ToString() %>"><%# Eval("companyName").ToString().Length>10?Eval("companyName").ToString().Substring(0,10)+"...":Eval("companyName").ToString() %></label>
                                </td>
                                <td>
                                    <%# Eval("proType")%>
                                </td>
                                <td>
                                    <%# Eval("dcNoSendCount")%>
                                </td>
                                <td>
                                    <label title="<%# GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()) %>"><%# GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()).ToString().Length>20?GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()).ToString().Substring(0,20)+"...":GetCanshu(Eval("customerNo").ToString(),Eval("proType").ToString()).ToString() %></label>
                                </td>
                                <td>
                                    <label title="<%# Eval("remark").ToString() %>"><%# Eval("remark").ToString().Length>10?Eval("remark").ToString().Substring(0,10)+"...":Eval("remark").ToString() %></label>
                                </td>
                                <td>
                                    <%# Eval("planSendTime","{0:yyyy-MM-dd}")%>
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="pagearea" id="PageArea">
            <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                PageSize="12" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                PagingButtonSpacing="6px" PagingButtonType="Image" runat="server" LayoutType="Table"
                AlwaysShow="True" ShowPageIndex="false" ShowPageIndexBox="Never" ShowMoreButtons="false"
                HorizontalAlign="Center" OnPageChanging="Pager_DocumentShare_PageChanging">
            </webdiyer:AspNetPager>
        </div>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
