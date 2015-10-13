<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TongjiProduct.aspx.cs" Inherits="OrderPrintWeb.ProductManage.TongjiProduct" %>

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
                    <span>产品统计列表</span>
                </div>
                <div class=" fr">
                   
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="title1">起始日期:
                            <input type="text" id="txtBeginTime" runat="server" class="tbox" onclick="WdatePicker()"  style="width:100px;"/>&nbsp;&nbsp;
                            截止日期:<input type="text" id="txtEndTime" runat="server" class="tbox" onclick="WdatePicker()" style="width:100px;" />&nbsp;&nbsp;
                            客户名称:<input type="text" id="txtCompanyName" runat="server" class="tbox" style="width:100px;" />&nbsp;&nbsp;
                            订单号:
                            <input type="text" id="txtOrderNum" runat="server" class="tbox" style="width:100px;"/>&nbsp;&nbsp;
                            产品型号:
                            <input type="text" id="txtProType" runat="server" class="tbox" style="width:100px;" />&nbsp;&nbsp;
                           <%-- 按随工单号: --%><input type="text" id="txtSgd" runat="server" class="tbox" style="display: none;" />
                            <asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                                OnClick="btnSearch_Click" ToolTip="查询" />
                            <asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current" Text="清空"
                                OnClick="IBtn_Empty_Click" />
                        </td>
                        <td>
                             <div style="text-align: center; ">出货总数量：<span id="totalCount" runat="server"></span></div>
                        </td>
                    </tr>
                </table>
                
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top:5px;">
                    <tr>
                        <th>序号
                        </th>
                        <th>订单号
                        </th>
                        <th>客户名称
                        </th>
                        <th>型号
                        </th>
                        <th>数量
                        </th>
                        <th>订货日期
                        </th>
                        <th>发货日期
                        </th>
                        <%--   <th>
                                随工单号
                            </th>--%>
                        <th>货运公司
                        </th>
                        <th>发货单号
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Container.ItemIndex + 1 %>
                                </td>
                                <td>
                                    <%# Eval("orderNum")%>
                                </td>
                                <td>
                                    <label title="<%# Eval("companyName").ToString() %>"><%# Eval("companyName").ToString().Length>10?Eval("companyName").ToString().Substring(0,10)+"...":Eval("companyName").ToString() %></label>
                                </td>
                                <td>
                                    <%#  Eval("proType")%>
                                </td>
                                <td>
                                    <%#  Eval("sendProNum")%>
                                </td>
                                <td>
                                    <%# Eval("editTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%# Eval("sendTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <%--<td>
                                     <%#GetSGD(Eval("orderNum").ToString())%>
                                         <%#  Eval("suiGongDanNum")%>
                                    </td>--%>
                                <td>
                                    <%-- <%#  Eval("packingCompanyName")%>--%>
                                    <label title="<%# Eval("packingCompanyName").ToString() %>"><%# Eval("packingCompanyName").ToString().Length>10?Eval("packingCompanyName").ToString().Substring(0,10)+"...":Eval("packingCompanyName").ToString() %></label>
                                </td>
                                <td>
                                    <%-- <%#  Eval("sendNum")%>--%>
                                    <label title="<%# Eval("sendNum").ToString() %>"><%# Eval("sendNum").ToString().Length>10?Eval("sendNum").ToString().Substring(0,10)+"...":Eval("sendNum").ToString() %></label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>

        </div>
        <div class="pagearea" id="PageArea">
<%--            <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
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
