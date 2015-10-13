<%@ Page Language="C#" AutoEventWireup="true" Inherits="CustomerManage_DetailZYSX" CodeBehind="DetailZYSX.aspx.cs" %>

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
    <style type="text/css">
        .selecter {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">发货前注意事项
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
            <div class="rightinfo" id="RightInfoArea" style="height: 500px; width: 100%;">
                <div id="List" class="listS">
                    <%-- <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tb">
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            注意事项
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_userinfo" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("id")%>
                                </td>
                                <td>
                                    <%#  Eval("contents")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>--%>
                    <table class="" cellpadding="4" cellspacing="0" align="center" width="100%">
                        <tr>
                            <td class="title1">客户编号：
                            </td>
                        </tr>
                        <tr>
                            <td class="info">
                                <asp:Label ID="txtCustomerNo" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">注意事项：
                            </td>
                        </tr>
                        <tr>
                            <td class="info">
                                <asp:Label ID="txtContents" runat="server"  style="line-height:25px;"></asp:Label>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
