<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditKaiPiaoOrder.aspx.cs" Inherits="OrderPrintWeb.orderManage.EditKaiPiaoOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" language="javascript">
        $(function () {
            DetailsPageControl.SetEveryAreaSize();
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                },
                datatype: {

                    "kprice": function () {

                        var reg1 = $("#txtYikaipiaoMoney").val();

                        var re = /^[0-9]{0}([0-9]|[.])+$/;
                        if (reg1.length > 0) {
                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "hprice": function () {
                        var reg2 = $("#txtYijiekuanMoney").val();
                        var re = /^[0-9]{0}([0-9]|[.])+$/;

                        if (reg2.length > 0) {
                            if (reg2 == "" || TestRgexp(re, reg2)) { return true; }
                            else { return false; }
                        } else {
                            return true;
                        }
                    }
                }
            });
            //默认添加一行
            //  AddSignRow();
        })

        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }

    </script>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">编辑订单回开票回款信息
                    </td>
                    <td class="optbtn">
                        <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                            ToolTip="提交" CssClass="btn" />
                        <%--  <asp:ImageButton ID="IBtn_Print" runat="server" OnClick="Print_Click" ImageUrl="../themes/default/images/btn/btn_print_nbyj_b_h.png"
                            ToolTip="打印合同" CssClass="btn" />--%>
                        <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
            <div class="rightinfo" id="RightInfoArea">
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">订单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtorderNum" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入客户编号！" errormsg="请输入客户编号！"></asp:TextBox>
                        </td>
                        <td class="title1">客户编号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomNum" runat="server" CssClass="tbox" Rows="5" datatype="*" nullmsg="请输入客户编号！"
                                errormsg="请输入客户编号！"></asp:TextBox>
                        </td>
                        <td class="title1">合同编号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtheTongNum" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入产品型号！" errormsg="请输入产品型号！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">客户订单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomOrderNum" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入产品型号！" errormsg="请输入产品型号！"></asp:TextBox>
                        </td>
                        <td class="title1" style="display:none;">客户物料编：
                        </td>
                        <td class="info" style="display:none;">
                            <asp:TextBox ID="txtcustomWLBH" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                        <td class="title1">客户维护人：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomManager" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">特殊要求：
                        </td>
                        <td class="info" colspan="5">
                            <asp:TextBox ID="txtremark" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine" Width="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="title1">已开票金额：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtYikaipiaoMoney" runat="server" CssClass="tbox" datatype="kprice" errmsg="您输入的格式不正确！"></asp:TextBox>
                        </td>
                        <td class="title1">已结款金额：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtYijiekuanMoney" runat="server" CssClass="tbox" datatype="hprice" errmsg="您输入的格式不正确！"></asp:TextBox>
                        </td>
                        <td class="title1"></td>
                        <td class="info"></td>
                    </tr>
                    <tr>
                        <td class="title1">发票邮寄单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtFapiaoDanhao" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                        <td class="title1">承兑号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtChengduihao" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                        <td class="title1"></td>
                        <td class="info"></td>
                    </tr>
                    <tr>
                        <td class="title1">备注：
                        </td>
                        <td class="info" colspan="6">
                            <asp:TextBox ID="txtRemark1" runat="server" CssClass="tarea" TextMode="MultiLine" Width="600"></asp:TextBox>
                        </td>

                        <td class="title1"></td>
                        <td class="info"></td>
                    </tr>
                    <tr>
                        <td class="title1">产品信息
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="SignFrame" class="tb"
                                align="center" style="border-top:1px solid #004EA2;">

                                <asp:Repeater ID="rptYongpin" runat="server">
                                    <ItemTemplate>
                                        <tr id='tr_<%#Container.ItemIndex+1%>' class="BGYPDH">
                                            <td>
                                                <%#Container.ItemIndex+1%>
                                                <asp:HiddenField ID="hdborderDetailId" runat="server" Value='<%# Eval("orderDetailId")%>' />
                                            </td>
                                            <td>型号</td>
                                            <td>
                                                <asp:Label ID="lblProType" runat="server" Text='<%# Eval("ProType")%>'>
                                                </asp:Label>
                                            </td>
                                            <td>数量</td>
                                            <td  >
                                                <asp:Label ID="txtProNum" runat="server" Width="60" Text='<%# Eval("ProNum")%>'> </asp:Label>
                                                </td>
                                            <td>单价</td>
                                                <td>
                                                    <asp:Label ID="lblProPrice" runat="server" Text='<%# Eval("ProPrice")%>'>
                                                    </asp:Label>
                                                </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>


                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
