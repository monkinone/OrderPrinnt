<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCustomer.aspx.cs" Inherits="CustomerManage_AddCustomer" %>

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
    </script>
    <style type="text/css">
        .selecter
        {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
    <div id="OptBar" class="optbar">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="info">
                    编辑客户信息
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
        <div class="rightinfo" id="RightInfoArea" style="width: auto; height:600px;  overflow:scroll; overflow-x:hidden;">
            <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                <tr>
                    <td class="title1">
                        客户编号：
                    </td>
                    <td class="title1">
                        公司名称：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcustomerNo" runat="server" CssClass="tbox" Rows="5" datatype="*"
                            nullmsg="请输入客户编号！" errormsg="请输入客户编号！"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtcompanyName" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        联系人：
                    </td>
                    <td class="title1">
                        职务：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtcontacts" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtposition" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        联系电话：
                    </td>
                    <td class="title1">
                        手机：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtphone" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txttelPhone" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        传真：
                    </td>
                    <td class="title1">
                        客户折扣：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txttax" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtdiscount" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        开票方式：
                    </td>
                    <td class="title1">
                        回款方式：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtInvoiceMethod" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtbackMethod" runat="server" CssClass="tbox" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        是否客户提供合同范本：
                    </td>
                    <td class="info">
                        <asp:RadioButton ID="rdoIsFanbenYes" runat="server" Text="是" GroupName="rdoISFanben" />
                        <asp:RadioButton ID="rdoIsFanbenNo" runat="server" Text="否" GroupName="rdoISFanben" />
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        公司地址：
                    </td>
                </tr>
                <tr>
                    <td class="info" colspan="2">
                        <asp:TextBox ID="txtcompanyAddress" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        联它联系档案：
                    </td>
                </tr>
                <tr>
                    <td class="info" colspan="2">
                        <asp:TextBox ID="txtotherDangAn" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        调价记录：
                    </td>
                </tr>
                <tr>
                    <td class="info" colspan="2">
                        <asp:TextBox ID="txtmodifyPriceRecord" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        联系性别与性格描述：
                    </td>
                </tr>
                <tr>
                    <td class="info" colspan="2">
                        <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" CssClass="tarea" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        <a onclick="openZYSX()">发货前注意事项</a><a onclick="openProductParam()"> 客户产品参数表</a><a onclick="openPrice()"> 单价查询</a>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        打印送货单时是否显示单价：
                    </td>
                    <td class="info">
                        <asp:RadioButton ID="rdoIsShowPriceYes" runat="server" Text="是" GroupName="rdoIsShowPrice" />
                        <asp:RadioButton ID="rdoIsShowPriceNo" runat="server" Text="否" GroupName="rdoIsShowPrice" />
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
