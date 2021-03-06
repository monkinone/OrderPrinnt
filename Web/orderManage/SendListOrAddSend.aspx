﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_SendListOrAddSend" CodeBehind="SendListOrAddSend.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
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
        //打开打印窗体
        function openPrintWindow() {
            var txtcompanyName =decodeURIComponent($("#txtcompanyName").val());//客户名称
            var txtproType =decodeURIComponent( $("#txtproType").val());//产品型号
            var txtOrderNum =decodeURIComponent( $("#txtOrderNum").val());//订单型号
            var ddlOrderType = decodeURIComponent($("#ddlOrderType").val());//订单类型
            var pageSize = 12;
            var pageIndex = $("#pageIndex").val();
            var url = 'PrintFaHuoList.aspx?txtcompanyName=' + txtcompanyName + '&txtproType=' + txtproType
                          + '&txtOrderNum=' + txtOrderNum + '&ddlOrderType=' + ddlOrderType + '&pageSize=' + pageSize
                          + '&pageIndex=' + pageIndex;
            window.open(url, '打印', '80%', '90%');
        }
    </script>
    <style type="text/css">
        .selecter {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>发货情况列表</span>
                </div>
                <div class="fr">
                    <img class="btn" id="btnSave" runat="server" onclick="openPrintWindow()"
                        src="~/themes/default/images/btn/btn_print_nbyj_b_h.png" alt="打印" title="打印" />
                    <asp:HiddenField ID="pageIndex" runat="server" />
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1">
                            <span id="searchCondition1" runat="server">
                             客户名称:<input type="text" id="txtcompanyName" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;产品型号:<input type="text" id="txtproType" runat="server" class="tbox" style="width: 100px;" />
                            </span>
                            &nbsp;&nbsp;订单号:<input type="text" id="txtOrderNum" runat="server" class="tbox" style="width: 100px;" />
                            <span id="searchCondition2" runat="server">
                                &nbsp;&nbsp;订单类型:<asp:DropDownList ID="ddlOrderType" runat="server" Width="100" Height="25">
                                <asp:ListItem Value="0">全部</asp:ListItem>
                                <asp:ListItem Value="1">已完成</asp:ListItem>
                                <asp:ListItem Value="2">部分完成</asp:ListItem>
                            </asp:DropDownList>
                            </span>
                            &nbsp;&nbsp;
                            <asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                                OnClick="btnSearch_Click" ToolTip="查询" />
                            &nbsp;&nbsp;
                            <asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current" Text="清空"
                                OnClick="IBtn_Empty_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top: 5px;">
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
                        <th>操作</th>
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
                                    <label title=" <%#Eval("companyName") %>"><%#Eval("companyName").ToString().Length>10?Eval("companyName").ToString().Substring(0,10)+"...":Eval("companyName").ToString() %></label>
                                    <%--   <%#Eval("companyName") %>--%>
                                </td>
                                <td>
                                    <%# Eval("proType") %>
                                </td>
                                <td>
                                    <%# Eval("proNum") %>
                                </td>
                                <td>
                                    <label title=" <%#Eval("paramContent") %>"><%#Eval("paramContent").ToString().Length>10?Eval("paramContent").ToString().Substring(0,10)+"...":Eval("paramContent").ToString() %></label>
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
                                    <label title=" <%#Eval("remark") %>"><%#Eval("remark").ToString().Length>10?Eval("remark").ToString().Substring(0,10)+"...":Eval("remark").ToString() %></label>
                                </td>
                                <td>
                                    <%# GetLastSendTime( Eval("orderNum").ToString(),Eval("proType").ToString()) %>
                                </td>
                                <td>
                                    <label title=" <%# GetSendNum( Eval("orderNum").ToString()) %>"><%# GetSendNum( Eval("orderNum").ToString()).ToString().Length>10? GetSendNum( Eval("orderNum").ToString()).ToString().Substring(0,10)+"...": GetSendNum( Eval("orderNum").ToString()) %></label>
                                    <%--<%# GetSendNum( Eval("orderNum").ToString()) %>--%>
                                </td>
                                <td><a href="javascript:void;" onclick="ListPageControl.OpenBox('./orderManage/AddWuliu.aspx?id=<%#Eval("orderNum") %>','编辑发货明细','50%','70%')">录入发货明细</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>

        </div>
        <div class="pagearea" id="PageArea">
            <%--                <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                    PageSize="12" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                    PagingButtonSpacing="6px" PagingButtonType="Image" runat="server" LayoutType="Table"
                    AlwaysShow="True" ShowPageIndex="false" ShowPageIndexBox="Never" ShowMoreButtons="false"
                    HorizontalAlign="Center" OnPageChanging="Pager_DocumentShare_PageChanging">
                </webdiyer:AspNetPager>--%>

            <style>
                .paginator {
                    font: 11px Arial, Helvetica, sans-serif;
                    padding: 10px 20px 10px 0;
                    margin: 0px;
                }

                    .paginator a {
                        padding: 1px 6px;
                        border: solid 1px #ddd;
                        background: #fff;
                        text-decoration: none;
                        margin-right: 2px;
                    }

                        .paginator a:visited {
                            padding: 1px 6px;
                            border: solid 1px #ddd;
                            background: #fff;
                            text-decoration: none;
                        }

                    .paginator .cpb {
                        padding: 1px 6px;
                        font-weight: bold;
                        font-size: 13px;
                        border: none;
                    }

                    .paginator a:hover {
                        color: #fff;
                        background: #ffa501;
                        border-color: #ffa501;
                        text-decoration: none;
                    }
            </style>
            <webdiyer:AspNetPager ID="Pager_DocumentShare" CssClass="paginator" CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="12" PrevPageText="上一页" 
                CustomInfoHTML="%CurrentPageIndex%/%PageCount%页"  
                CustomInfoSectionWidth="50"
                ShowCustomInfoSection="Right"
                ShowInputBox="Never" OnPageChanging="Pager_DocumentShare_PageChanging" CustomInfoTextAlign="Left" LayoutType="Table" ShowPageIndexBox="Always" SubmitButtonText="Go"  >
            </webdiyer:AspNetPager>


        </div>
        <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
