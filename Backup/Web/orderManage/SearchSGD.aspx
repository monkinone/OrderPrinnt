<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchSGD.aspx.cs" Inherits="Web.orderManage.SearchSGD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <%--  <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />--%>
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>随工单列表</span>
                </div>
                <div class="fr">
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1">
                            随工单号:<input type="text" id="txtSGD" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;<asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                               ToolTip="查询" OnClick="IBtn_Query_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top:5px;">
                    <tr>
                        <th>随工单号</th>
                        <th>订单号</th>
                        <th>客户编号</th>
                        <th>产品型号</th>
                        <th>随工单打印数量</th>
                        <th>操作</th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                   <%# Eval("suigongdan")%>                
                                </td>
                                <td>
                                    <%# Eval("orderNum")%>
                                </td>
                                <td>
                                    <%# Eval("customerNum")%>
                                </td>
                                <td><%# Eval("proType") %>
                                </td>
                                <td>
                                    <%# Eval("PrintCount")%>
                                </td>
                                <td>
                                    <a href="javascript:void(0);" onclick="ListPageControl.OpenBox('./orderManage/DetailSGD.aspx?suigongdan=<%# Eval("suigongdan") %>&proType=<%# Eval("proType") %>&PrintCount=<%# Eval("PrintCount") %>&orderNum=<%# Eval("orderNum") %>','随工单','1050px','500px')">详细</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
         <div class="pagearea" id="PageArea">          
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
    </form>
</body>
</html>
