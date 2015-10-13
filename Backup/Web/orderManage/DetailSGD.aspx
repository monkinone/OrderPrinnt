<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailSGD.aspx.cs" Inherits="Web.orderManage.DetailSGD" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../scripts/Validform/css/style.css" />
    <link href="../scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <script src="../scripts/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .current {
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="details">
            <div class="rightinfo" id="RightInfoArea">
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%" style="padding-top: 10px;">
                    <tr>
                          <td class="title2" colspan="6" style="font-size: 14px; font-weight: bold;">

                            <span style="float: left">订单信息</span>
                            <br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title2">订单号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtorderNum" runat="server"></asp:Label>
                        </td>
                        <td class="title2">客户编号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomNum" runat="server"></asp:Label>
                        </td>
                        <td class="title2">合同编号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtheTongNum" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td class="title2">客户订单号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomOrderNum" runat="server"></asp:Label>
                        </td>
                        <td class="title2" style="display: none;">客户物料编：
                        </td>
                        <td class="info" style="display: none;">
                            <asp:Label ID="txtcustomWLBH" runat="server"></asp:Label>
                        </td>
                        <td class="title2">客户维护人：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomManager" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="title2">特殊要求：
                        </td>
                        <td class="info" colspan="5">
                            <asp:Label ID="txtremark" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="info" colspan="7"></td>
                    </tr>

                    <tr>
                        <td class="title2" colspan="8" style="font-size: 14px; font-weight: bold;">

                            <span style="float: left">产品信息</span>

                            <div style="float: left; margin-left: 200px" class="info">
                                <asp:Label runat="server" ID="lbl发货状态" />
                            </div>
                            <br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="title2">型号：
                        </td>
                        <td class="info">
                            <asp:Label ID="lblproType" runat="server" ></asp:Label>
                        </td>
                        <td class="title2">数量：
                        </td>
                        <td class="info">
                            <asp:Label ID="lblproNum" runat="server"></asp:Label>
                        </td>
                        <td class="title2"><asp:Label  Text="随工单打印数量：" runat="server" ID="随工单打印数量"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="lblPrintCount" runat="server"></asp:Label>
                        </td>
                        <td class="title2"><asp:Label Text="批号：" runat="server" ID="批号"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="lblpiHao" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title2">随工单号：
                        </td>
                        <td class="info">
                            <asp:Label ID="lblSuiGongDan" runat="server"></asp:Label>
                        </td>
                        <td class="title2"><asp:Label runat="server" Text="计划发货日期：" ID="计划发货日期"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="lblplanSendTime" runat="server"></asp:Label>
                        </td>
                        <td class="title2"><asp:Label runat="server" Text="生产地：" ID="生产地"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:Label ID="lblproductAddress" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
