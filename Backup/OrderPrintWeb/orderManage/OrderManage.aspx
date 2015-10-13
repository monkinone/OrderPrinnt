<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_OrderManage" CodeBehind="OrderManage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                    <img class="btn" id="btnSave" runat="server" onclick="window.open('../orderManage/AddOrder.aspx','下发订单信息','900px','500px')"
                        src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />
                </div>
            </div>
            <div id="List" class="listS">
                <table class="form" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="title1">起始日期:
                            <input class=" tbox" readonly="readonly" id="txtBeginTime" type="text" name="txtTime" onclick="WdatePicker()"
                                runat="server"   style="width:100px;"/>
                            &nbsp;&nbsp;截止日期:<input class=" tbox" readonly="readonly" id="txtEndTime" type="text" name="txtTime" onclick="WdatePicker()"
                                runat="server" style="width:100px;"/>&nbsp;&nbsp;
                            &nbsp;&nbsp;客户名称:
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="tbox" style="width:100px;"></asp:TextBox>
                            &nbsp;&nbsp;订单编号:<asp:TextBox ID="txtorderNum" runat="server" CssClass="tbox" style="width:100px;"></asp:TextBox>
                            &nbsp;&nbsp;产品型号:<asp:TextBox ID="txtProduct" runat="server" CssClass="tbox" style="width:100px;"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Button ID="btnSearchOrder" runat="server" Text="搜索" CssClass="current" OnClick="btnSearchOrder_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb fl" style="margin-top: 10px;">
                    <tr>
                    </tr>
                    <tr>
                        <th >序号</th>
                        <th >订单号
                        </th>
                        <th >客户编号
                        </th>
                        <th >客户名称
                        </th>
                        <th >订单录入时间</th>
                        <th >订单总额</th>
                        <th>已开票金额</th>
                        <th >发票邮寄单号</th>
                        <th >承兑号</th>
                        <th >未开票金额</th>
                        <th >已结款金额</th>
                        <th >未结款金额</th>
                        <th >客户维护人</th>
                       <%-- <th>备注</th>--%>
                        <th >操作</th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server" OnItemCommand="rpt_userinfo_ItemCommand">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.ItemIndex + 1 %></td>
                                <td>
                                   
                                     <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/OrderDetail.aspx?orderNum=<%# Eval("orderNum") %>','订单详情','900px','500px')"> <%# Eval("orderNum")%></a>
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
                                <td><%# GetTotalPrice(Eval("orderNum").ToString())%></td>
                                <td><%# Eval("yikaipiaoMoney")%></td>
                                <td><%# Eval("faPiaoDanhao")%></td>
                                <td><%# Eval("chengShuiHao")%></td>
                                <td><%# GetWeiKai( Eval("orderNum").ToString(),Eval("yikaipiaoMoney").ToString())%></td>
                                <td><%# Eval("yijiekuanMoney")%></td>
                                <td><%#GetWeiJie( Eval("orderNum").ToString(),Eval("yijiekuanMoney").ToString())%></td>
                                <td>
                                    <%# Eval("customManager")%>
                                </td>
                              <%--  <td>
                                    <label title="<%# Eval("Remark1")%>"><%# Eval("Remark1").ToString().Length>20?Eval("Remark1").ToString().Substring(0,20)+"...":Eval("Remark1").ToString()%></label>
                                </td>--%>
                                <td>
                                    <a href="javascript:void;" onclick="window.open('../orderManage/EditOrder.aspx?id=<%# Eval("orderNum") %>','下发订单信息','900px','500px')">编辑</a>&nbsp;|&nbsp;
                                   <%-- <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CommandName="Del" CommandArgument='<%#  Eval("orderNum") %>' OnClientClick="return confirm('确定要删除该订单吗？')"></asp:LinkButton>&nbsp;|&nbsp;--%>
                                    <%--  <asp:LinkButton ID="Button1" runat="server" Text="详细" CommandName="Detail" CommandArgument='<%#  Eval("orderNum") %>'></asp:LinkButton>--%>
                                    <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/OrderDetail.aspx?orderNum=<%# Eval("orderNum") %>','订单详情','900px','500px')">详细</a>
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
    </form>
</body>
</html>
