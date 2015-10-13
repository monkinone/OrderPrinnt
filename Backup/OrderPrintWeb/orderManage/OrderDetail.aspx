<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="OrderPrintWeb.orderManage.OrderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
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

    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>订单详情列表</span>
                </div>
                <div class="fr">
                    <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                        title="返回" />
                </div>
            </div>
            <div id="List" class="listS" align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1" style="text-align: center;">产品型号:<asp:TextBox ID="txtproType" runat="server" CssClass="tbox"></asp:TextBox>
                            <asp:Button ID="btnSearchProduct" runat="server" Text="搜索" OnClick="btnSearchProduct_Click" CssClass="btn current" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top: 10px;">
                    <tr>
                        <th>产品型号
                        </th>
                        <th>单价
                        </th>
                        <th>数量
                        </th>
                        <th>已发货数量</th>
                        <th>合计金额</th>
                    </tr>
                    <asp:Repeater ID="rptOrderDetail" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("proType")%>
                                </td>
                                <td>
                                    <%# Eval("ProPrice")%>
                                </td>
                                <td>
                                    <%# Eval("proNum")%>
                                </td>
                                <td>
                                    <%# Eval("SendCount").ToString()%>
                                </td>
                                <td>
                                    <%# Eval("totalPrice")%>
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
    </form>
</body>
</html>
