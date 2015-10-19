<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YulanImg.aspx.cs" Inherits="OrderPrintWeb.ProductManage.YulanImg" %>

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
                            <td class="title1  " colspan="2">
                                <a href="YulanImg.aspx" title="标示位置图片" style="width: 100px; float: left; background: #004ea2; margin-right: 5px;">标示位置图片</a>
                                <a href="YulanWaikeImg.aspx" title="外壳图片" style="width: 100px; float: left; margin-right: 5px;">外壳图片</a>
                                <a href="YulanGuanjiaoZhen.aspx" title="管脚针图片" style="width: 100px; float: left;">管脚针图片</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">按标示位置编号
                            </td>
                            <td class="cond">
                                <input type="text" id="txt_biaoshiNo" runat="server" class="tbox" width="80%" />
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
                                <th>标示位置编号
                                </th>
                                <th>图片
                                </th>
                                <th>预览
                                </th>
                            </tr>
                            <asp:Repeater ID="rpt_userinfo" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("biaoShiNo")%>
                                        </td>
                                        <td>
                                            <img src='<%# Eval("biaoShiImg").ToString()!=""?"../"+Eval("biaoShiImg").ToString().Replace("~/",""):"/images/nophoto.jpg"%>' width="50"
                                                height="50" />
                                        </td>
                                        <td>
                                            <a href="javascript:void;" onclick="ListPageControl.OpenBox('./ProductManage/ShowImage.aspx?id=<%# Eval("biaoShiNo") %>&type=biaoshi','预览图片','70%','90%')">预览</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="pagearea" id="PageArea">
<%--                        <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                            PageSize="8" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
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
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="7" PrevPageText="上一页" 
                CustomInfoHTML="%CurrentPageIndex%/%PageCount%页"  
                CustomInfoSectionWidth="50"
                ShowCustomInfoSection="Right"
                ShowInputBox="Never" OnPageChanging="Pager_DocumentShare_PageChanging" CustomInfoTextAlign="Left" LayoutType="Table" ShowPageIndexBox="Always" SubmitButtonText="Go"  >
            </webdiyer:AspNetPager>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
