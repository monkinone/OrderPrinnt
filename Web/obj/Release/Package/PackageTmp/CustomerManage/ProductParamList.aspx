<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="CustomerManage_ProductParamList" Codebehind="ProductParamList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
  
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div id="OptBar" class="optbar">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="info">
                    客户产品参数表
                </td>
                <td class="optbtn">
                    <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                        title="返回" />
                </td>
            </tr>
        </table>
    </div>
    <div class="details">
        <div class="rightinfo" id="RightInfoArea" style=" height: 500px;  width:100%;">
            <div id="List" class="listS" style="min-height:350px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb"  style="margin-top:10px;">
                    <tr>
                        <th>
                            型号
                        </th>
                        <th>
                            客户参数
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#  Eval("productNo")%>
                                </td>
                                <td>
                                    <%# Eval("paramContent")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="pagearea" id="PageArea" style="margin-top:10px;">
                <webdiyer:AspNetPager ID="Pager_DocumentShare" ImagePath="~/themes/default/images/pager"
                    PageSize="8" ButtonImageNameExtension="n" ButtonImageExtension=".png" DisabledButtonImageNameExtension="g"
                    PagingButtonSpacing="6px" PagingButtonType="Image" runat="server" LayoutType="Table"
                    AlwaysShow="True" ShowPageIndex="false" ShowPageIndexBox="Never" ShowMoreButtons="false"
                    HorizontalAlign="Center" OnPageChanging="Pager_DocumentShare_PageChanging">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
