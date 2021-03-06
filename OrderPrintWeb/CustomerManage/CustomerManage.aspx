﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="CustomerManage_CustomerManage" CodeBehind="CustomerManage.aspx.cs" %>

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
    <%-- <script src="../scripts/Custom/DateControl.js" type="text/javascript"></script>--%>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).resize(function () {
            ListPageControl.ResizeWindow();
        });
        function refresh() {
            this.location = this.location;

        }
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
                    <span>客户管理列表</span>
                </div>
                <div class="fr">
                    <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./CustomerManage/AddCustomer.aspx','编辑客户信息','70%','90%')"
                        src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />
                </div>
            </div>
            <div id="List" class="listS">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td class="title1">公司名称:<input type="text" id="txt_companyName" runat="server" class="tbox" style="width: 100px;" />
                            &nbsp;&nbsp;客户编号:
                            <input type="text" id="txt_customerNO" runat="server" class="tbox" style="width: 100px;" />
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
                        <th>客户编号
                        </th>
                        <th>公司名称
                        </th>
                        <th>联系人
                        </th>
                        <th>联系电话
                        </th>
                        <th>职务
                        </th>
                        <th>查询
                        </th>
                        <th>操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server" OnItemCommand="rpt_userinfo_ItemCommand">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("customerNo")%>
                                </td>
                                <td>
                                    <%# Eval("companyName")%>
                                </td>
                                <td>
                                    <%#  Eval("contacts")%>
                                </td>
                                <td>
                                    <%#  Eval("phone")%>
                                </td>
                                <td>
                                    <%#  Eval("position")%>
                                </td>
                                <td>
                                    <a href="javascript:void;" onclick="ListPageControl.OpenBox('./CustomerManage/DetailZYSX.aspx?customerNo=<%# Eval("customerNo") %>','发货前注意事项','50%','60%')">发货前注意事项</a>&nbsp;|&nbsp;
                                        <a href="javascript:void;" onclick="ListPageControl.OpenBox('./CustomerManage/ProductParamList.aspx?customerNo=<%# Eval("customerNo") %>','客户参数表','50%','60%')">客户参数表</a>&nbsp;|&nbsp;
                                        <a href="javascript:void;" onclick="ListPageControl.OpenBox('./CustomerManage/PriceList.aspx?customerNo=<%# Eval("customerNo") %>','单价查询','50%','60%')">单价查询</a>
                                </td>
                                <td>
                                    <a href="javascript:void;" onclick="ListPageControl.OpenBox('./CustomerManage/AddCustomer.aspx?id=<%# Eval("customerId") %>','编辑客户信息','70%','90%')">编辑</a>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="Button1" runat="server" Text="删除" CommandName="del" CommandArgument='<%#  Eval("customerId") %>'
                                            OnClientClick="return confirm('确定要删除该条记录吗?')"></asp:LinkButton><%--&nbsp;|&nbsp;
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#GetStr(Eval("Islock").ToString())%>'
                                            CommandName="dongjie" CommandArgument='<%#  Eval("customerId") %>' OnClientClick="return confirm('确定要冻结/解冻该客户吗?')"></asp:LinkButton>--%>
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
