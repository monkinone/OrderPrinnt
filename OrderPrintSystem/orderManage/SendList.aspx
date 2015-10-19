<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendList.aspx.cs" Inherits="orderManage_SendList" %>

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
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).resize(function () {
            ListPageControl.ResizeWindow();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UP_Search" UpdateMode="Conditional" OnLoad="UP_Search_Load">
            <ContentTemplate>
                <div id="QueryArea" class="queryarea">
                    <table width="90%">
                        <tr>
                            <td class="title1">客户名称
                            </td>
                            <td class="cond">
                                <input type="text" id="txtcompanyName" runat="server" class="tbox" width="80%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">产品型号
                            </td>
                            <td class="cond">
                                <input type="text" id="txtproType" runat="server" class="tbox" width="80%" />
                            </td>
                        </tr>
                    </table>
                    <div class="btnarea">
                        <asp:ImageButton ID="IBtn_Query" runat="server" CssClass="btn" ImageUrl="~/themes/default/images/btn/btn_execute_w_h.png"
                            OnClick="btnSearch_Click" ToolTip="查询" />
                        <asp:ImageButton ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn" ImageUrl="~/themes/default/images/btn/btn_empty_w_h.png"
                            OnClick="IBtn_Empty_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="UP_DocumentShare" UpdateMode="Conditional" OnLoad="UP_DocumentShare_Load">
            <ContentTemplate>
                <div id="ListArea" class="listarea">
                    <div id="OptArea" class="optarea">
                        <div class="fl tishi">
                            <span>发货情况列表</span>
                        </div>
                        <div class="fr">
                            <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./orderManage/SendList.aspx','打印','80%','90%')"
                                src="~/themes/default/images/btn/btn_print_nbyj_b_h.png" alt="打印" title="打印" />
                        </div>
                    </div>
                    <div id="List" class="listS">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                            <tr>
                                <th>订单号
                                </th>
                                <th>客户名称
                                </th>
                                <th>产品型号</th>
                                <th>订单总数量</th>
                                <th>客户参数</th>
                                <th>已发货数量累计</th>
                                <th>本次发货数量</th>
                                <th>装箱明细</th>
                                <th>件数</th>
                                <th>特殊要求</th>
                                <th>发货时间</th>
                                <th>发货单号</th>
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
                                          <%#Eval("companyName") %>
                                        </td>
                                        <td>
                                            <%# Eval("proType") %>
                                        </td>
                                        <td>
                                             <%# Eval("proNum") %>
                                        </td>
                                        <td>
                                           <%#Eval("paramContent") %>
                                        </td>
                                         <td>
                                             <%# GetSendCount( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("sendProNum") %>--%>
                                             <%# GetLastSendCount( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                        </td>
                                       
                                        <td>
                                           <%# GetBZ(Eval("proType").ToString(),Eval("proNum").ToString()) %>
                                        </td>
                                        <td>
                                            <%# Jianshu( Eval("proType").ToString(),Eval("proNum").ToString()) %>
                                        </td>
                                        <td>
                                            <%#Eval("remark") %>
                                        </td>
                                        <td>
                                          <%--  <%#Eval("sendTime","{0:yyyy-MM-dd}") %>--%>
                                             <%# GetLastSendTime( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                        </td>
                                        <td>
                                            <%# GetSendNum( Eval("orderNum").ToString()) %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="pagearea" id="PageArea">
                        <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                            PageSize="8" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                            PagingButtonSpacing="6px" PagingButtonType="Image" runat="server" LayoutType="Table"
                            AlwaysShow="True" ShowPageIndex="false" ShowPageIndexBox="Never" ShowMoreButtons="false"
                            HorizontalAlign="Center" OnPageChanging="Pager_DocumentShare_PageChanging">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
