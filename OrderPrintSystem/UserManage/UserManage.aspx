<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="UserManage_UserManage" %>

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
        function refresh() {
            this.location = this.location;
          
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel runat="server" ID="UP_Search" UpdateMode="Conditional" OnLoad="UP_Search_Load">
        <ContentTemplate>
            <div id="QueryArea" class="queryarea">
                <table width="90%">
                    <tr>
                        <td class="title1">
                            按真实姓名
                        </td>
                        <td class="cond">
                            <input type="text" id="txt_trueName" runat="server" class="tbox" width="80%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">
                            按登录名
                        </td>
                        <td class="cond">
                          <input type="text" id="txt_userName" runat="server" class="tbox" width="80%" />
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
                        <span>用户管理列表</span>
                    </div>
                    <div class="fr">
                    <asp:ImageButton ID="IBtn_Delete" runat="server" OnClick="Delete_Click" ImageUrl="../themes/default/images/btn/btn_delete_w_h.png"
                        ToolTip="删除" CssClass="btn"  OnClientClick="return confirm('确定要删除选中项？')"/>
                        <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./UserManage/AddUser.aspx','编辑用户信息','50%','60%')" src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />
                    </div>
                </div>
                <div id="List" class="listS">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                        <tr>
                            <th>
                                选择
                            </th>
                            <th>
                                登录名
                            </th>
                            <th>
                                真实姓名
                            </th>
                            <th>
                                联系电话
                            </th>
                            <th>
                                身份
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <asp:Repeater ID="rpt_userinfo" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkPro" runat="server" />
                                <asp:HiddenField ID="hiddId" runat="server" Value='<%#Eval("userid") %>' />
                                    </td>
                                    <td>
                                        <%# Eval("userName")%>
                                    </td>
                                    <td>
                                        <%#  Eval("trueName")%>
                                    </td>
                                    <td>
                                        <%#  Eval("phone")%>
                                    </td>
                                    <td>
                                        <%#  Eval("userType")%>
                                    </td>
                                    <td>
                                        <a href="javascript:void;" onclick="ListPageControl.OpenBox('./UserManage/AddUser.aspx?id=<%# Eval("userid") %>','编辑用户信息','50%','60%')">
                                            编辑</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="pagearea" id="PageArea">
                    <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                        PageSize="8" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
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
