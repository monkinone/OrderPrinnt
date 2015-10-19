<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YulanWaikeImg.aspx.cs" Inherits="OrderPrintWeb.ProductManage.YulanWaikeImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>

    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).resize(function () {
            ListPageControl.ResizeWindow();
        });
    </script>
    <style type="text/css">
        .selecter {
            width: 195px;
        }
    </style>

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
                            <td class="title1 " colspan="2">
                                <a href="YulanImg.aspx" title="标示位置图片" style="width: 100px; float: left; margin-right: 5px;">标示位置图片</a>
                                <a href="YulanWaikeImg.aspx" title="外壳图片" style="width: 100px; float: left; margin-right: 5px; background: #004ea2;">外壳图片</a>
                                <a href="YulanGuanjiaoZhen.aspx" title="管脚针图片" style="width: 100px; float: left;">管脚针图片</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">按外壳编号
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
                    </div>
                    <div id="List" class="listS">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                            <tr>
                                <th>外壳编号
                                </th>
                                <th>外壳图片
                                </th>
                                <th>操作
                                </th>
                            </tr>
                            <asp:Repeater ID="rpt_userinfo" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("waiKeNo")%>
                                        </td>
                                        <td>
                                            <img src='<%# Eval("waiKeImg").ToString()!=""?"../"+Eval("waiKeImg").ToString().Replace("~/",""):"/images/nophoto.jpg"%>' width="50" height="50" />
                                        </td>
                                        <td>
                                            <a href="javascript:void;" onclick="ListPageControl.OpenBox('./ProductManage/ShowImage.aspx?id=<%# Eval("waiKeNo") %>&type=waike','预览图片','70%','90%')">预览</a>
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
