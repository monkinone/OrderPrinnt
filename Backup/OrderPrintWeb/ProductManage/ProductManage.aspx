<%@ Page Language="C#" AutoEventWireup="true" Inherits="ProductManage_ProductManage" Codebehind="ProductManage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
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
    
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UP_Search" UpdateMode="Conditional" OnLoad="UP_Search_Load">
        <ContentTemplate>
            <div id="QueryArea" class="queryarea">
                <table width="90%" style="">
                    <tr>
                        <td class="title1">
                            按产品型号
                        </td>
                        <td class="cond">
                            <input type="text" id="txt_productNum" runat="server" class="tbox" width="80%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">
                            按标示编号
                        </td>
                        <td class="cond">
                            <input type="text" id="txt_biaoShiNo" runat="server" class="tbox" width="80%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">
                            按外壳编号
                        </td>
                        <td class="cond">
                            <input type="text" id="txt_waiKeNo" runat="server" class="tbox" width="80%" />
                        </td>
                    </tr>
                </table>
                <div class="btnarea">
                    <asp:ImageButton ID="IBtn_Query" runat="server" CssClass="btn" ImageUrl="~/themes/default/images/btn/btn_execute_w_h.png"
                        OnClick="btnSearch_Click" ToolTip="查询" />
                    <asp:ImageButton ID="IBtn_Empty" runat="server" ToolTip="清空" CssClass="btn" ImageUrl="~/themes/default/images/btn/btn_empty_w_h.png"
                        OnClick="IBtn_Empty_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="UP_DocumentShare" UpdateMode="Conditional" OnLoad="UP_DocumentShare_Load">
        <ContentTemplate>
            <div id="ListArea" class="listarea">
                <div id="OptArea" class="optarea">
                    <div class="fl tishi">
                        <span>产品管理列表</span>
                    </div>
                    <div class="fr">
                        <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./ProductManage/AddProduct.aspx','编辑产品信息','80%','90%')"
                            src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />
                    </div>
                </div>
                <div id="List" class="listS">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                        <tr>
                            <th>
                                产品型号
                            </th>
                            <th>
                                标示编号
                            </th>
                            <th>
                                外壳编号
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <asp:Repeater ID="rpt_userinfo" runat="server" OnItemCommand="rpt_userinfo_ItemCommand">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("productNum")%>
                                    </td>
                                    <td>
                                        <%# Eval("biaoShiNo")%>
                                    </td>
                                    <td>
                                        <%#  Eval("waiKeNo")%>
                                    </td>
                                    <td>
                                        <a href="javascript:void;" onclick="ListPageControl.OpenBox('./ProductManage/AddProduct.aspx?id=<%# Eval("productId") %>','编辑产品信息','70%','90%')">
                                            编辑</a>&nbsp;&nbsp; <a href="javascript:void;" onclick="ListPageControl.OpenBox('./ProductManage/DetailProduct.aspx?id=<%# Eval("productId") %>','预览产品信息','70%','90%')">
                                            预览</a>&nbsp;&nbsp;
                                        <asp:LinkButton ID="Button1" runat="server" Text="删除" CommandName="del" CommandArgument='<%#  Eval("productId") %>'
                                            OnClientClick="return confirm('确定要删除该条记录吗?')" ></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="pagearea" id="PageArea">
                    <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                        PageSize="12" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                        PagingButtonSpacing="6px" PagingButtonType="Image" runat="server" LayoutType="Table"
                        AlwaysShow="True" ShowPageIndex="false" ShowPageIndexBox="Never" ShowMoreButtons="false"
                        HorizontalAlign="Center" OnPageChanging="Pager_DocumentShare_PageChanging">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
