<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeWuOrderList.aspx.cs" Inherits="OrderPrintWeb.orderManage.YeWuOrderList" %>

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
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script src="../scripts/My97DatePicker/WdatePicker.js"></script>

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
                    <span>订单管理列表</span>
                </div>
                <div class="fr">
                   <%-- <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./orderManage/AddOrder.aspx','编辑订单信息','80%','90%')"
                        src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />--%>
                </div>
            </div>
            <div id="List" class="listS">
                <table class="form" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>

                        <td class="title1" style="width: 70px;">客户编号</td>
                        <td class="info" style="width: 50px;">
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="tbox" style="width: 100px;"></asp:TextBox></td>
                        <td class="title1" style="width: 70px;">业务员名称</td>
                        <td class="info" style="width: 50px;">
                            <asp:TextBox ID="txtWeiHuren" runat="server" CssClass="tbox" style="width: 100px;"></asp:TextBox></td>
                        <td class="title1">
                            <asp:Button ID="btnSearchOrder" runat="server" Text="搜索" CssClass="current" OnClick="btnSearchOrder_Click" /></td>

                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb fl" style=" margin-top: 10px;">
                    <tr>
                    </tr>
                    <tr>
                        <th >订单号
                        </th>
                        <th >客户编号
                        </th>

                        <th>订单录入时间</th>
                        <th >已开票金额</th>
                        <th >未开票金额</th>
                        <th>已结款金额</th>
                        <th >未结款金额</th>
                        <th >客户维护人</th>
                        <th >操作</th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server" OnItemCommand="rpt_userinfo_ItemCommand">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                     <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/OrderDetail.aspx?orderNum=<%# Eval("orderNum") %>','订单详情','50%','90%')"> <%# Eval("orderNum")%></a>
                                   
                                </td>
                                <td>
                                    <%# Eval("customNum")%>
                                </td>

                                <td>
                                    <%# Eval("editTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td><%# Eval("yikaipiaoMoney")%></td>
                                <td><%# GetWeiKai( Eval("orderNum").ToString(),Eval("yikaipiaoMoney").ToString())%></td>
                                <td><%# Eval("yijiekuanMoney")%></td>
                                <td><%#GetWeiJie( Eval("orderNum").ToString(),Eval("yijiekuanMoney").ToString())%></td>
                                <td>
                                    <%# Eval("customManager")%>
                                </td>
                                <td>
                                     <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/OrderDetail.aspx?orderNum=<%# Eval("orderNum") %>','订单详情','50%','90%')">详细</a>
                                  <%--  <asp:LinkButton ID="Button1" runat="server" Text="详细" CommandName="Detail" CommandArgument='<%#  Eval("orderNum") %>'></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
              
               <%-- <div style="height: 400px; float: left; margin-top: -25px;" scroll-x="no" id="divOrderDetail" runat="server">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                        <tr>
                            <td class="title1" style="width: 70px;">产品型号</td>
                            <td class="info" style="width: 70px;">
                                <asp:TextBox ID="txtproType" runat="server" CssClass="tbox"></asp:TextBox></td>
                            <td class="title1" style="width: 70px;">
                                <asp:Button ID="btnSearchProduct" runat="server" Text="搜索" OnClick="btnSearchProduct_Click" CssClass="current" /></td>
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
                                    <td> <%# Eval("SendCount").ToString()%>
                                    </td>
                                    <td>
                                        <%# Eval("totalPrice")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>--%>
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
    </form>
</body>
</html>
