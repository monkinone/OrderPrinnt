<%@ Page Language="C#" AutoEventWireup="true" Inherits="CustomerManage_AddPrice" CodeBehind="AddPrice.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    <script type="text/javascript" language="javascript">
        $(function () {
            DetailsPageControl.SetEveryAreaSize();
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                },
                datatype: {

                    "price": function () {
                        var reg1 = $("#txtprice").val();
                        if (reg1.length > 0) {
                            var re = /^[0-9]{0}([0-9]|[.])+$/;
                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return false; }
                    }
                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }

        function isExistCustom() {
            if ($('#txtcustomerNo').val() != '') {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddPrice.aspx/isExistCustom",
                    data: "{'customerNum':\"" + $('#txtcustomerNo').val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            alert('该客户编号不存在！');
                            $('#txtcustomerNo').val('');
                            return false;
                        } else {
                            return true;
                        }
                    }
                });
            }
        }

        function isExistProType() {
            if ($('#txtproductNO').val() != '') {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddPrice.aspx/isExistProType",
                    data: "{'proType':\"" + $('#txtproductNO').val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            alert('该产品型号不存在！');
                            $('#txtproductNO').val('');
                            return false;
                        } else {
                            return true;
                        }
                    }
                });
            }
        }
    </script>
    <style type="text/css">
        .selecter {
            width: 195px;
        }

        .details .rightinfo .title1 {
            padding-left: 0px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">编辑单价
                    </td>
                    <td class="optbtn">
                        <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                            ToolTip="提交" CssClass="btn" />
                        <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
            <div class="rightinfo" id="RightInfoArea">
                <table class="" cellpadding="4" cellspacing="0" align="center" width="50%" style="margin-top: 10px;">
                    <tr>
                        <td class="title1">客户编号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomerNo" runat="server" CssClass="tbox" datatype="*" nullmsg="请输入客户编号!"
                                errormsg="请输入客户编号！" onblur="isExistCustom();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">产品型号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproductNO" runat="server" CssClass="tbox" datatype="*" nullmsg="请输入产品型号！"
                                errormsg="请输入产品型号！" onblur="isExistProType()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">单价：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtprice" runat="server" CssClass="tbox" datatype="price" nullmsg="请输入单价！" errmsg="您输入的格式不正确！"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
