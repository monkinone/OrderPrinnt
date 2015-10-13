<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderKaiPiaoManage.aspx.cs" Inherits="OrderPrintWeb.orderManage.OrderKaiPiaoManage" %>

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
    <%-- <script src="../scripts/Custom/DateControl.js" type="text/javascript"></script>--%>
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
                    <span>订单管理列表</span>
                </div>
                <div class="fr">
                </div>
            </div>
            <div id="List" class="listS">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1">起始日期:
                                    <input class=" tbox" readonly="readonly" id="txtBeginTime" type="text" name="txtTime" onclick="WdatePicker()" runat="server" style="width: 100px;" />
                            &nbsp;&nbsp;截止日期:<input class=" tbox" readonly="readonly" id="txtEndTime" type="text" name="txtTime" onclick="WdatePicker()" runat="server" style="width: 100px;" />
                            &nbsp;&nbsp;客户名称:<asp:TextBox ID="txtCompanyName" runat="server" CssClass="tbox" Style="width: 100px;"></asp:TextBox>
                            &nbsp;&nbsp;订单编号:<asp:TextBox ID="txtorderNum" runat="server" CssClass="tbox" Style="width: 100px;"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" OnClick="btnSearch_Click" ToolTip="查询" Text="查询" />
                            &nbsp;&nbsp;
                            <asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current" OnClick="IBtn_Empty_Click" Text="清空" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb fl" style="margin-top: 10px;">

                    <tr>
                        <th >序号</th>
                        <th >订单号
                        </th>
                        <th >客户编号
                        </th>
                        <th >客户名称
                        </th>
                        <th>订单录入时间</th>
                        <th >已开票金额</th>
                        <th >发票邮寄单号</th>
                        <th>承兑号</th>
                        <th >未开票金额</th>
                        <th>已结款金额</th>
                        <th >未结款金额</th>
                        <th>客户维护人</th>
                        <th>备注</th>
                        <th >操作</th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.ItemIndex + 1 %></td>
                                <td>
                                    <%# Eval("orderNum")%>
                                </td>
                                <td>
                                    <%# Eval("customNum")%>
                                    
                                </td>
                                <td>
                                    <%-- <%# Eval("companyName")%>--%>
                                    <label title="<%# Eval("companyName")%>"><%# Eval("companyName").ToString().Length>8?Eval("companyName").ToString().Substring(0,8)+"...":Eval("companyName")%></label>
                                </td>
                                <td>
                                    <%# Eval("editTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td><%# Eval("yikaipiaoMoney")%></td>
                                <td><%# Eval("faPiaoDanhao")%></td>
                                <td><%# Eval("chengShuiHao")%></td>
                                <td><%# GetWeiKai( Eval("orderNum").ToString(),Eval("yikaipiaoMoney").ToString())%></td>
                                <td><%# Eval("yijiekuanMoney")%></td>
                                <td><%#GetWeiJie( Eval("orderNum").ToString(),Eval("yijiekuanMoney").ToString())%></td>
                                <td>
                                    <%# Eval("customManager")%>
                                </td>
                                <td>
                                    <label title="<%# Eval("Remark1")%>"><%# Eval("Remark1").ToString().Length>10?Eval("Remark1").ToString().Substring(0,10)+"...":Eval("Remark1")%></label>
                                </td>
                                <td>
                                    <a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/EditKaiPiaoOrder.aspx?id=<%# Eval("orderNum") %>','编辑订单信息','70%','90%')">编辑开票回款信息</a>
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
        <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
