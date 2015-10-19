<%@ Page Language="C#" AutoEventWireup="true" Inherits="CustomerManage_AddCustomer" CodeBehind="AddCustomer.aspx.cs" %>

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
                        var reg1 = $("#txtdiscount").val();
                        if (reg1.length > 0) {
                            var re = /^[0-9]{0}([0-9]|[.])+$/;
                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "isTiGongHetong": function () {
                        if ($("#rdoIsFanbenYes").attr("checked") != "checked" && $("#rdoIsFanbenNo").attr("checked") != "checked") {
                            return false;
                        } else {
                            return true;
                        }
                    }
                    ,
                    "isAddCustomer": function () {
                        if ($("#rdoIsAdd").attr("checked") != "checked" && $("#rdoIsNotAdd").attr("checked") != "checked") {
                            return false;
                        } else {
                            return true;
                        }
                    }
                    ,
                    "isShowPrice": function () {
                        if ($("#rdoIsShowPriceYes").attr("checked") != "checked" && $("#rdoIsShowPriceNo").attr("checked") != "checked") {
                            return false;
                        } else {
                            return true;
                        }
                    }
                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }
        function isExistCustom() {
            if ($('#txtcustomerNo').val() != "") {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddCustomer.aspx/isExistCustom",
                    data: "{'customerNum':\"" + $('#txtcustomerNo').val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            return true;
                        } else {
                            alert('该客户编号已存在！');
                            $('#txtcustomerNo').val('');
                            return false;
                        }
                    }
                });
            }
        }
        function isExistCusName() {
            if ($("#txtcompanyName").val() != "") {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddCustomer.aspx/isExistCusName",
                    data: "{'companyName':\"" + $('#txtcompanyName').val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            return true;
                        } else {
                            alert('该客户名称已存在！');
                            $('#txtcompanyName').val('');
                            return false;
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
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">编辑客户信息
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
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">客户编号：
                        </td>
                        <td class="title1">公司名称：
                        </td>
                        <td class="title1">联系人：
                        </td>
                        <td class="title1">职务：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtcustomerNo" runat="server" CssClass="tbox" Rows="5" datatype="*"
                                nullmsg="请输入客户编号！" errormsg="请输入客户编号！" onblur="isExistCustom();"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcompanyName" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入公司名称！" errormsg="请输入公司名称！" onblur="isExistCusName()"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcontacts" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入联系人！" errormsg="请输入联系人！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtposition" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">联系电话：
                        </td>
                        <td class="title1">手机：
                        </td>
                        <td class="title1">传真：
                        </td>

                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtphone" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入联系电话！" errormsg="请输入联系电话！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txttelPhone" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txttax" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td class="title1" colspan="4">客户折扣(元)：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="4">
                            <asp:TextBox ID="txtdiscount" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">开票方式：
                        </td>
                        <td class="title1">回款方式：
                        </td>
                        <td class="title1">是否客户提供合同范本：
                        </td>
                        <td class="title1">是否在订单里输入客户信息：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:TextBox ID="txtInvoiceMethod" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入开票方式！" errormsg="请输入开票方式！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtbackMethod" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入回款方式！" errormsg="请输入回款方式！"></asp:TextBox>
                        </td>
                        <td class="info">
                            <asp:RadioButton ID="rdoIsFanbenYes" runat="server" Text="是" GroupName="rdoISFanben" datatype="isTiGongHetong" nullmsg="请选择是否客户提供合同范本！" />
                            <asp:RadioButton ID="rdoIsFanbenNo" runat="server" Text="否" GroupName="rdoISFanben" datatype="isTiGongHetong" nullmsg="请选择是否客户提供合同范本！" />
                        </td>
                        <td class="info">
                            <asp:RadioButton ID="rdoIsAdd" runat="server" Text="填写" GroupName="rdo" datatype="isAddCustomer" nullmsg="请选择是否在订单里输入客户信息！" />
                            <asp:RadioButton ID="rdoIsNotAdd" runat="server" Text="不填写" GroupName="rdo" datatype="isAddCustomer" nullmsg="请选择是否在订单里输入客户信息！" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="2">账号：
                        </td>
                        <td class="title1" colspan="2">税号：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="2">
                            <asp:TextBox ID="txtZhangHao" runat="server" CssClass="tbox" Width="92%"></asp:TextBox>
                        </td>
                        <td class="info" colspan="2">
                            <asp:TextBox ID="txtShuiHao" runat="server" CssClass="tbox" Width="92%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="2">公司地址：
                        </td>
                        <td class="title1" colspan="2">其他联系人档案：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="2">
                            <asp:TextBox ID="txtcompanyAddress" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5" datatype="*"
                                nullmsg="请输入公司地址！" errormsg="请输入公司地址！"></asp:TextBox>
                        </td>
                        <td class="info" colspan="2">
                            <asp:TextBox ID="txtotherDangAn" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1" colspan="2">调价记录：
                        </td>
                        <td class="title1" colspan="2">联系人性别与性格描述：
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="2">
                            <asp:TextBox ID="txtmodifyPriceRecord" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                        </td>
                        <td class="info" colspan="2">
                            <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1" colspan="2">
                            <a href="javascript:void;" onclick="openZYSX()">发货前注意事项</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="javascript:void;" onclick="openProductParam()">客户产品参数表</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="javascript:void;" onclick="openPrice()">单价查询</a>
                        </td>
                        <td class="title2">打印送货单时是否显示单价：
                        </td>
                        <td class="info">
                            <asp:RadioButton ID="rdoIsShowPriceYes" runat="server" Text="是" GroupName="rdoIsShowPrice" datatype="isShowPrice" nullmsg="请选择打印送货单时是否显示单价！" />
                            <asp:RadioButton ID="rdoIsShowPriceNo" runat="server" Text="否" GroupName="rdoIsShowPrice" datatype="isShowPrice" nullmsg="请选择打印送货单时是否显示单价！" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <script type="text/javascript">
            function openZYSX() {
                var customerNo = $("#txtcustomerNo").val();
                BoxControl.Show(Config.AppStartupDir + 'DetailZYSX.aspx?customerNo=' + customerNo, '发货前注意事项', '700px', '500px', false, false);
            }
            function openProductParam() {
                var customerNo = $("#txtcustomerNo").val();
                BoxControl.Show(Config.AppStartupDir + 'ProductParamList.aspx?customerNo=' + customerNo, '客户产品参数表', '700px', '500px', false, false);
            }
            function openPrice() {
                var customerNo = $("#txtcustomerNo").val();
                BoxControl.Show(Config.AppStartupDir + 'PriceList.aspx?customerNo=' + customerNo, '单价查询', '700px', '500px', false, false);
            }
        </script>
    </form>
</body>
</html>
