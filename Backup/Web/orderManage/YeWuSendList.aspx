<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeWuSendList.aspx.cs" Inherits="OrderPrintWeb.orderManage.YeWuSendList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
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
                    <span>发货情况列表</span>
                </div>
                <div class="fr">
                    <%-- <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./orderManage/SendList.aspx','打印','80%','90%')"
                                src="~/themes/default/images/btn/btn_print_nbyj_b_h.png" alt="打印" title="打印" />--%>
                    <img class="btn" id="btnSave" runat="server" onclick="window.open('YewuPrintFaHuoList.aspx','打印','80%','90%')"
                        src="~/themes/default/images/btn/btn_print_nbyj_b_h.png" alt="打印" title="打印" />
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" class="form" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="title1">客户编号:<input type="text" id="txtcompanyName" runat="server" class="tbox" style="width: 100px;" />&nbsp;&nbsp;
                                业务员:<input type="text" id="txtWeiHuren" runat="server" class="tbox" width="80%" style="width: 100px;"/>
                            &nbsp;&nbsp; 
                            <asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                                OnClick="btnSearch_Click" ToolTip="查询" />
                            &nbsp;&nbsp;
                            <asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current"  Text="清空"
                                OnClick="IBtn_Empty_Click" />

                        </td>
                        
                    </tr>
                  
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top:5px;">
                    <tr>
                        <th>业务员</th>
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
                                    <%# Eval("customManager") %>
                                </td>
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
                                    <%--   <%# Jianshu( Eval("proType").ToString(),Eval("proNum").ToString()) %>--%>
                                    <%# Jianshu( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                </td>

                                <td>
                                     <label title=" <%# GetSendNum( Eval("orderNum").ToString()) %>"><%#GetSendNum( Eval("orderNum").ToString()).ToString().Length>10?GetSendNum( Eval("orderNum").ToString()).ToString().Substring(0,10)+"...":GetSendNum( Eval("orderNum").ToString()).ToString() %></label>
                                </td>
                                <td>
                                    <label title=" <%#GetHuoyunCom(Eval("orderNum").ToString()) %>"><%#GetHuoyunCom(Eval("orderNum").ToString()).ToString().Length>10?GetHuoyunCom(Eval("orderNum").ToString()).ToString().Substring(0,10)+"...":GetHuoyunCom(Eval("orderNum").ToString()).ToString() %></label>
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
        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
