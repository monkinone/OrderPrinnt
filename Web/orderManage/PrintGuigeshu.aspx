<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintGuigeshu.aspx.cs" Inherits="OrderPrintWeb.orderManage.PrintGuigeshu" %>

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

        <div id="ListArea" class="listarea">
            <div id="OptArea" class="optarea">
                <div class="fl tishi">
                    <span>打印规格书</span>
                </div>
                <div class="fr">
                    <%--     <img class="btn" id="btnSave" runat="server" onclick="ListPageControl.OpenBox('./orderManage/AddGuigeshu.aspx','上传规格书','30%','70%')"
                                src="~/themes/default/images/btn/btn_new_w_h.png" alt="添加" title="添加" />--%>
                </div>
            </div>
            <div id="List" class="listS">
                <table width="100%"  style="text-align:center;">
                    <tr>
                        <td class="title1" style="text-align: center;">请输入产品型号: <input type="text" id="txt_productNo" runat="server" class="tbox" width="80%" />&nbsp;&nbsp;
                            <asp:Button ID="IBtn_Query" runat="server" CssClass="btn  current"  Text="查询"
                                OnClick="btnSearch_Click" ToolTip="查询"  />
                        </td>
                    </tr>

                    <tr>
                        <td  style="text-align: center;"><a id="print" runat="server" target="_blank"></a></td>
                    </tr>
                </table>

            </div>

        </div>

    </form>
</body>
</html>
