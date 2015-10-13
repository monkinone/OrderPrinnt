<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderProManage.aspx.cs" Inherits="orderManage_OrderProManage" %>

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
                            <td class="title1">产品型号
                            </td>
                            <td class="cond">
                                <input type="text" id="txtproType" runat="server" class="tbox" width="80%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">客户编号
                            </td>
                            <td class="cond">
                                <input type="text" id="txtcustomNum" runat="server" class="tbox" width="80%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">是否打印
                            </td>
                            <td class="cond">
                                <asp:DropDownList ID="ddlIsPrint" runat="server">
                                    <asp:ListItem Value="0">未打印</asp:ListItem>
                                    <asp:ListItem Value="1">已打印</asp:ListItem>
                                    <asp:ListItem Value="2">部分打印</asp:ListItem>
                                </asp:DropDownList>
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
                            <span>打印单据管理列表</span>
                        </div>
                        <div class="fr">
                        </div>
                    </div>
                    <div id="List" class="listS">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                            <tr>
                                <th>订单号
                                </th>
                                <th>客户编号
                                </th>
                                <th>产品型号</th>
                                <th>总数量</th>
                                <th>已发货数量</th>
                                <th>打印时间</th>
                                <th>已打印数量</th>
                                <th>下单时间</th>
                                <th>操作
                                </th>
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
                                            <%# Eval("customNum")%>
                                        </td>
                                        <td>
                                            <%# Eval("proType")%>
                                        </td>
                                        <td>
                                            <%# Eval("proNum")%>
                                        </td>
                                        <td><%# Eval("sendProNum") %>
                                        </td>
                                        <td>
                                            <%# Eval("printSGDTime").ToString()!=""?Eval("printSGDTime","{0:yyyy-MM-dd}"):"未打印"%>
                                        </td>
                                        <td><%# Eval("printTotalCount") %>
                                        </td>
                                        <td>
                                            <%# Eval("editTime","{0:yyyy-MM-dd}")%>
                                        </td>
                                        <td>
                                            <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/OrderPrint.aspx?id=<%# Eval("orderDetailId") %>','打印产品订单','70%','90%')">详细</a>

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
