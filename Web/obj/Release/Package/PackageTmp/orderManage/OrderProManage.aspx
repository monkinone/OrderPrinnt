<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_OrderProManage" CodeBehind="OrderProManage.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <%--  <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />--%>
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).resize(function () {
            ListPageControl.ResizeWindow();
        });
        function yulan() {
            $('#yulan').css("display", "none");
        }
    </script>
    <style type="text/css">
        .selecter {
            width: 100px;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>打印单据管理列表</span>
                </div>
                <div class="fr">
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1">订单号:<input type="text" id="txtorderNum" runat="server" class="tbox" style="width: 100px;" />
                            <span id="otherCondition" runat="server">
                             &nbsp;&nbsp;产品型号:<input type="text" id="txtproType" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;客户编号:
                            <input type="text" id="txtcustomNum" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;是否打印:
                            <asp:DropDownList ID="ddlIsPrint" runat="server" Width="100" Height="25">
                                <asp:ListItem Value="0">未打印</asp:ListItem>
                                <asp:ListItem Value="1">已打印</asp:ListItem>
                                <asp:ListItem Value="2">部分打印</asp:ListItem>
                                <asp:ListItem Value="3">全部</asp:ListItem>
                            </asp:DropDownList>
                            </span>
                            &nbsp;&nbsp;<asp:Button ID="IBtn_Query" runat="server" CssClass="btn current" Text="查询"
                                OnClick="btnSearch_Click" ToolTip="查询" />

                            &nbsp;&nbsp;<asp:Button ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn current" Text="清空"
                                OnClick="IBtn_Empty_Click" />
                        </td>
                    </tr>


                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb" style="margin-top:5px;">
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
                                    <a href="javascript:void(0);" onclick="ListPageControl.OpenBox('./orderManage/OrderPrint.aspx?id=<%# Eval("orderDetailId") %>','打印产品订单','1050px','500px')"><%# Eval("orderNum")%></a>
                                    
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
                                <td><%# Eval("SendCount") %>
                                </td>
                                <td>
                                    <%# Eval("printSGDTime").ToString()!=""?Eval("printSGDTime","{0:yyyy-MM-dd}"):"未打印"%>
                                </td>
                                <td><%# Eval("sgdPrintCount") %>
                                </td>
                                <td>
                                    <%# Eval("editTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <a href="javascript:void(0);" onclick="ListPageControl.OpenBox('./orderManage/OrderPrint.aspx?id=<%# Eval("orderDetailId") %>','打印产品订单','1050px','500px')">详细</a>

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
           
            <div id="yulan" runat="server" style="position: absolute; top: 200px; left: 40%; width: 410px; min-height: 200px; z-index: 9999; border: 1px solid #ccc; background: #E5F2FB; font-size: 12px; line-height: 25px;">
                <div id="Div2" class="" style="background:#808080;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="" style="width: 360px; float: left; padding-left:5px;">提醒
                            </td>
                            <td class="">
                                <%-- <asp:ImageButton ID="btnCanleYulan" runat="server" ImageUrl="btn_close_w"
                                            CssClass="btn fr" Width="20" OnClientClick="yulan()" />--%>
                                <img src="../themes/default/images/btn/btn_close_w_n.png" cssclass="btn fr" width="20" onclick="yulan()" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tixing" runat="server" style="padding-left: 5px; ">
                </div>
            </div>
        </div>
         <div class="pagearea" id="PageArea">
<%--                <webdiyer:AspNetPager ID="Pager_DocumentShare" 
                    PageSize="12" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                    PagingButtonSpacing="6px" PagingButtonType="text" runat="server"
                    AlwaysShow="True" 
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
        <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
