<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderPrint.aspx.cs" Inherits="orderManage_OrderPrint" %>

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

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印产品订单
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
            <div class="rightinfo" id="RightInfoArea" style="width: auto">
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">订单信息
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">订单号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtorderNum" runat="server"></asp:Label>
                        </td>
                        <td class="title1">客户编号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomNum" runat="server"></asp:Label>
                        </td>
                        <td class="title1">合同编号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtheTongNum" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td class="title1">客户订单号：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomOrderNum" runat="server"></asp:Label>
                        </td>
                        <td class="title1">客户物料编：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomWLBH" runat="server"></asp:Label>
                        </td>
                        <td class="title1">客户维护人：
                        </td>
                        <td class="info">
                            <asp:Label ID="txtcustomManager" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">特殊要求：
                        </td>
                        <td class="info" colspan="5">
                            <asp:Label ID="txtremark" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">产品信息
                        </td>
                    </tr>
                    <tr>

                        <td class="title1">型号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproType" runat="server" CssClass="tbox" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="title1">数量：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproNum" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                        <td class="title1">批号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtpiHao" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入批号！" errormsg="请输入批号！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>

                        <td class="title1">随工单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtwithWorkNo" runat="server" CssClass="tbox" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="title1">计划发货日期：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtplanSendTime" runat="server" CssClass="tbox" onclick="WdatePicker()"></asp:TextBox>
                        </td>
                        <td class="title1">生产地：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproductAddress" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>

                        <td class="title1">要打印文档：
                        </td>

                    </tr>
                    <tr>
                        <td class="info" colspan="6">
                            <input type="button" value="随工单" onclick="printSGD()" class="current" />
                            &nbsp;&nbsp;<input type="button" value="随工单记录" class="current" onclick="printSGDJL()" />
                            &nbsp;&nbsp;<input type="button" value="取料单" class="current" onclick="printQLD()" />
                            &nbsp;&nbsp;<input type="button" value="出厂检验报告" class="current" onclick="    printInspectionReport()" />
                            &nbsp;&nbsp;<input type="button" value="送货单" class="current" onclick="printSendList()" />
                            &nbsp;&nbsp;<input type="button" value="包装标签" class="current" onclick="printBZBQ()" />
                            &nbsp;&nbsp;<input type="button" value="客户发货注意事项" class="current" onclick="printZYSX()" />
                            &nbsp;&nbsp;<input type="button" value="样品确认单" class="current" onclick="printYPQRD()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="position: absolute; top: 200px; left: 200px; display: none; width:400px; height:500px;" id="imgTishi" runat="server">
            <input type="button" class="current" onclick="printSuiGongdan();" value="关闭"  style="float:right;"/>
            <img src="" width="200" height="200" id="imgWaike" runat="server" style="display: none;" />
            <img src="" width="200" height="200" id="imgBiaoshi" runat="server" style="display: none;" />
        </div>
        <script type="text/javascript">

            var customNum = $('#txtcustomNum').html();
            var proType = $('#txtproType').val();
            var orderNum = $('#txtorderNum').html();
            var proNum = $('#txtproNum').val();
            var planTime = $('#txtplanSendTime').val();
            var pihao = $('#txtpiHao').val();
            var withWorkNo = $('#txtwithWorkNo').val();
            var address = $('#txtproductAddress').val();
            var detailId =<%=orderDetailId%>

            function printInspectionReport() {

                window.open(Config.AppStartupDir + 'InspectionReport.aspx?customerNo=' + customNum + '&proType=' + proType + '&orderNum=' + orderNum + '&detailId=' + detailId, '打印出厂检验报告', '80%', '90%', false, false);
            }
            function printZYSX() {

                window.open(Config.AppStartupDir + 'PrintZYSX.aspx?customerNo=' + customNum + '&proType=' + proType + '&orderNum=' + orderNum, '打印客户发货注意事项', '80%', '90%', false, false);
            }

            function printSGDJL() {
                window.open(Config.AppStartupDir + 'PrintSGDJL.aspx?proType=' + proType + '&proNum=' + proNum + '&orderNum=' + orderNum, '打印随工单记录', '80%', '90%', false, false);
            }

            function printSendList() {

                window.open(Config.AppStartupDir + 'PrintSendList.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum, '修改送货单', '80%', '90%', false, false);
            }

            function printSuiGongdan() {
                $('#imgTishi').css("display", "none");
                window.open(Config.AppStartupDir + 'PrintSGD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&planTime=' + planTime + '&proNum=' + proNum + '&pihao=' + pihao, '打印随工单', '80%', '90%', false, false);
            }
            function printSGD() {
                var result = false;
                var printCount = 0;

                //获取随工单打印次数
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "OrderPrint.aspx/GetPrintSGDCount",
                    data: "{'proType':\"" + proType + "\",'orderNum':\"" + orderNum + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        printCount = data.d;
                    }
                });
                //前两次打印弹出图片提示,否则直接跳转到打印页面
                if (printCount <= 2) {
                    $.ajax({
                        type: "Post",
                        async: false,
                        url: "OrderPrint.aspx/isUpdateWaikeImg",
                        data: "{'proType':\"" + proType + "\"}",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d > 0) {
                                result = true;
                             
                                $.ajax({
                                    type: "Post",
                                    async: false,
                                    url: "OrderPrint.aspx/GetWaikwImg",
                                    data: "{'proType':\"" + proType + "\"}",
                                    contentType: "application/json;charset=utf-8",
                                    dataType: "json",
                                    success: function (data) {
                                        if (data.d != null) {
                                            alert('waike');
                                            $('#imgWaike').attr("src", data.d);
                                            $('#imgWaike').css("display", "block");
                                            $('#imgTishi').css("display", "block");
                                        } else {
                                            $('#imgTishi').css("display", "block");
                                        }
                                    }
                                });
                            } else {
                                //  alert('失败');
                            }
                        }
                    });

                    $.ajax({
                        type: "Post",
                        async: false,
                        url: "OrderPrint.aspx/isUpdateBiaoshiImg",
                        data: "{'proType':\"" + proType + "\"}",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d > 0) {
                                result = true;
                                $.ajax({
                                    type: "Post",
                                    async: false,
                                    url: "OrderPrint.aspx/GetBiaoshiImg",
                                    data: "{'proType':\"" + proType + "\"}",
                                    contentType: "application/json;charset=utf-8",
                                    dataType: "json",
                                    success: function (data) {

                                        if (data.d != null) {
                                            $('#imgBiaoshi').attr("src", data.d.toString().replace("~/", "../"));
                                            $('#imgBiaoshi').css("display", "block");
                                            $('#imgTishi').css("display", "block");
                                        } else {
                                            $('#imgTishi').css("display", "block");
                                        }
                                    }
                                });
                            } else {
                                //  alert('失败');
                            }
                        }
                    });
                } else {
                    //将产品及外壳修改参数改为0
                    $.ajax({
                        type: "Post",
                        async: false,
                        url: "OrderPrint.aspx/UpdateIsModify",
                        data: "{'proType':\"" + proType + "\"}",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {

                            if (data.d > 0) {
                                // alert('成功');
                            } else {
                                // alert('失败');
                            }
                        }
                    });
                    window.open(Config.AppStartupDir + 'PrintSGD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&planTime=' + planTime + '&proNum=' + proNum + '&pihao=' + pihao, '打印随工单', '80%', '90%', false, false);
                }
            }
            function printQLD() {
                window.open(Config.AppStartupDir + 'PrintQLD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&withWorkNo=' + withWorkNo + '&proNum=' + proNum, '打印取料单', '80%', '90%', false, false);
            }
            function printYPQRD() {
                window.open(Config.AppStartupDir + 'PrintYPQRD.aspx?proType=' + proType + '&customNum=' + customNum + '&proNum=' + proNum + '&address=' + address + '&orderNum=' + orderNum, '打印样品确认单', '80%', '90%', false, false);
            }

            function printBZBQ() {
                window.open(Config.AppStartupDir + 'PrintBZBQ.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum, '打印外包装标签', '80%', '90%', false, false);
            }
        </script>
    </form>
</body>
</html>
