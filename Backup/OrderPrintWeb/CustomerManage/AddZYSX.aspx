﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="CustomerManage_AddZYSX" CodeBehind="AddZYSX.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../scripts/Validform/css/style.css" />
    <link href="../scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/table.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/ListPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            DetailsPageControl.SetEveryAreaSize();
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }

        function isExistCustom() {
            if ($('#txtCustomerNo').val() != "") {
                $.ajax({
                    type: "GET",
                    async: false,
                  
                    url: "/Service/AddZYSX.ashx",
                    data: {opr:"isExistCustom",customerNum:$('#txtCustomerNo').val() },
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            alert('该客户编号不存在！');
                            $('#txtCustomerNo').val('');
                            return false;
                        } else {
                            $.ajax({
                                type: "GET",
                                async: false,
                                url: "/Service/AddZYSX.ashx",
                                
                                data: { opr: "isExistCustomZYSX", customerNum: $('#txtCustomerNo').val() },
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    if (data.d == 0) {
                                        return true;
                                    } else {
                                        alert('该客户注意事项已存在，不能不重复填写');
                                        $('#txtCustomerNo').val('');
                                        return false;
                                    }
                                }
                            });
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
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="info">编辑发货前注意事项
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
                <table class="" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">客户编号：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtCustomerNo" runat="server" CssClass="tbox" Rows="5" datatype="*" nullmsg="请输入客户编号！"
                                errormsg="请输入客户编号！" onblur="isExistCustom()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">注意事项：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtContents" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"
                                datatype="*" nullmsg="请输入注意事项！" errormsg="请输入注意事项！"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </form>
</body>
</html>
