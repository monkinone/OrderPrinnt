<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderManage.aspx.cs" Inherits="orderManage_OrderManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                    <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./orderManage/AddOrder.aspx','编辑订单信息','80%','90%')"
                        src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />
                </div>
            </div>
            <div id="List" class="listS">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb fl" style="width: auto;">
                    <tr>
                        起始日期
                            <input class=" tbox" readonly="readonly" id="txtBeginTime" type="text" name="txtTime" onclick="WdatePicker()"
                                runat="server" />截止日期
                            <input class=" tbox" readonly="readonly" id="txtEndTime" type="text" name="txtTime" onclick="WdatePicker()"
                                runat="server" />
                        客户名称
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="tbox"></asp:TextBox>
                        订单编号
                            <asp:TextBox ID="txtorderNum" runat="server" CssClass="tbox"></asp:TextBox>
                        <asp:Button ID="btnSearchOrder" runat="server" Text="搜索" OnClick="btnSearchOrder_Click" />
                    </tr>
                    <tr>
                        <th>订单号
                        </th>
                        <th>客户编号
                        </th>
                        <th>客户名称
                        </th>
                        <th>订单录入时间</th>
                        <th>已开票金额</th>
                        <th>未开票金额</th>
                        <th>已结款金额</th>
                        <th>未结款金额</th>
                        <th>客户维护人</th>
                        <th>操作</th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server" OnItemCommand="rpt_userinfo_ItemCommand">
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
                                    <%# Eval("companyName")%>
                                </td>
                                <td>
                                    <%# Eval("editTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td> <%# Eval("yikaipiaoMoney")%></td>
                                <td><%# GetWeiKai( Eval("orderNum").ToString(),Eval("yikaipiaoMoney").ToString())%></td>
                                <td> <%# Eval("yijiekuanMoney")%></td>
                                <td><%#GetWeiJie( Eval("orderNum").ToString(),Eval("yijiekuanMoney").ToString())%></td>
                                <td>
                                    <%# Eval("customManager")%>
                                </td>
                                <td>
                                    <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/EditOrder.aspx?id=<%# Eval("orderNum") %>','编辑订单信息','70%','90%')">编辑</a>&nbsp;|&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CommandName="Del" CommandArgument='<%#  Eval("orderNum") %>' OnClientClick="return confirm('确定要删除该订单吗？')"></asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="Button1" runat="server" Text="详细" CommandName="Detail" CommandArgument='<%#  Eval("orderNum") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="pagearea" id="PageArea">
                    <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                        PageSize="8" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                        PagingButtonSpacing="6px" PagingButtonType="Image" runat="server" LayoutType="Table"
                        AlwaysShow="True" ShowPageIndex="false" ShowPageIndexBox="Never" ShowMoreButtons="false"
                        HorizontalAlign="Center" OnPageChanging="Pager_DocumentShare_PageChanging">
                    </webdiyer:AspNetPager>
                </div>
                <div style="height: 400px; float: left;" scroll-x="no" id="divOrderDetail" runat="server">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                        <tr>
                            产品型号<asp:TextBox ID="txtproType" runat="server" CssClass="tbox"></asp:TextBox>
                            <asp:Button ID="btnSearchProduct" runat="server" Text="搜索" OnClick="btnSearchProduct_Click" />
                        </tr>
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
                                    <td>0
                                    </td>
                                    <td>
                                        <%# Eval("totalPrice")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
