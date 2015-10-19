<%@ Page Language="C#" AutoEventWireup="true" Inherits="OrderPrintWeb.orderManage.OrderPrint" CodeBehind="OrderPrint.aspx.cs" %>

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

        function PrintMe() {
            var txtproNum = $("#txtproNum").val();
            var txtpiHao = $("#txtpiHao").val();
            var txtplanSendTime = $("#txtplanSendTime").val();
            var txtproductAddress = $("#txtproductAddress").val();
            var win = window.open('/orderManage/OrderPrint.aspx?opr=print&txtproNum=' + txtproNum + '&txtpiHao=' + txtpiHao
                                                   +'&txtplanSendTime=' + txtplanSendTime + '&txtproductAddress='+txtproductAddress
                                                   + '&id=<%=Request.QueryString["id"]%>', '80%', '90%', false, false);
            win.autoPrint = true;
        }
        $(function () {
            if (window.autoPrint) {
                $(".optbtn").hide();
                window.print();
            }
        });

    </script>
    <style type="text/css">
        .current {font-size: 16px;}
        .vertify{ color:Red; font-size:15px;}
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <!--打印开始-->
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印产品订单
                    </td>
                    <td class="optbtn">

                        <input type="image" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" onclick="PrintMe(); return false;" />

<%--                        <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                            ToolTip="提交" CssClass="btn" />--%>
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
                            <asp:TextBox ID="txtproType" runat="server" CssClass="tbox" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="title2">数量：
                        </td>
                        <td class="info">
                            <asp:Label ID="lblproNum" runat="server"></asp:Label>
                        </td>
                        <td class="title2">
                        <asp:Label  Text="随工单打印数量：" runat="server" ID="随工单打印数量"></asp:Label>
                        <span class="vertify">*</span>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproNum" runat="server" CssClass="tbox" datatype="n"
                                nullmsg="请输入随工单打印数量！" errormsg="只能输入数字！"></asp:TextBox>
                        </td>
                        <td class="title2"><asp:Label Text="批号：" runat="server" ID="批号"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtpiHao" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入批号！" errormsg="请输入批号！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title2">随工单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtwithWorkNo" runat="server" CssClass="tbox" Enabled="false"  ></asp:TextBox>
                        </td>
                        <td class="title2">
                        <asp:Label runat="server" Text="计划发货日期：" ID="计划发货日期"></asp:Label>
                        <span class="vertify">*</span>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtplanSendTime" ReadOnly="true" runat="server" CssClass="tbox" onclick="WdatePicker()" datatype="*" nullmsg="请输入计划发货日期！"></asp:TextBox>
                        </td>
                        <td class="title2"><asp:Label runat="server" Text="生产地：" ID="生产地"></asp:Label>
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtproductAddress" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title2" colspan="8" style="font-size: 14px; font-weight: bold;">要打印文档：<br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="info" colspan="8">&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" value="随工单" onclick="printSGD()" class="current" />
                            &nbsp;&nbsp;<input type="button" value="随工单记录" class="current" onclick="printSGDJL()" />
                            &nbsp;&nbsp;<input type="button" value="取料单" class="current" onclick="printQLD()" />
                            &nbsp;&nbsp;<input type="button" value="出厂检验报告" class="current" onclick="printInspectionReport()" />
                            &nbsp;&nbsp;<input type="button" value="送货单" class="current" onclick="printSendList()" />
                            &nbsp;&nbsp;<input type="button" value="包装标签" class="current" onclick="printBZBQ()" />
                            &nbsp;&nbsp;<input type="button" value="客户发货注意事项" class="current" onclick="printZYSX()" />
                            &nbsp;&nbsp;<input type="button" value="样品确认单" class="current" onclick="printYPQRD()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!--打印结束-->
        <div style="position: absolute; top: 200px; left: 200px; display: none; width: 400px; height: 500px;" id="imgTishi" runat="server">
            <input type="button" class="current" onclick="printSuiGongdan();" value="关闭" style="float: right;" />
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
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                window.open(Config.AppStartupDir + 'InspectionReport.aspx?customerNo=' + customNum + '&proType=' + proType + '&orderNum=' + orderNum + '&detailId=' + detailId + '&pihao=' + pihao + '&proNum=' + proNum, '打印出厂检验报告', '80%', '90%', false, false);
            }
            function printZYSX() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                window.open(Config.AppStartupDir + 'PrintZYSX.aspx?customerNo=' + customNum + '&proType=' + proType + '&orderNum=' + orderNum, '打印客户发货注意事项', '80%', '90%', false, false);
            }

            function printSGDJL() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                window.open(Config.AppStartupDir + 'PrintSGDJL.aspx?proType=' + proType + '&proNum=' + proNum + '&orderNum=' + orderNum, '打印随工单记录', '80%', '90%', false, false);
            }

            function printSendList() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                window.open(Config.AppStartupDir + 'PrintSendList.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&withWorkNo=' + withWorkNo, '修改送货单', '80%', '90%', false, false);
            }

            function printSuiGongdan() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();//随工单打印数量
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                $('#imgTishi').css("display", "none");
                window.open(Config.AppStartupDir + 'PrintSGD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&planTime=' + planTime + '&proNum=' + proNum + '&pihao=' + pihao + '&withWorkNo=' + withWorkNo, '打印随工单', '80%', '90%', false, false);
            }
            //
            // 随工单
            //
            function printSGD() {
                //验证
                var proNum = $('#txtproNum').val();
                if ($.trim(proNum) == "") {
                    alert("请输入随工单打印数量！");
                    $('#txtproNum').focus();
                    return;
                }
                else {
                    var reg = /^[0-9]*[1-9][0-9]*$/;
                    if (!reg.test($.trim(proNum)))
                    {
                        alert("输入随工单数量有误，请检查！");
                        $('#txtproNum').focus();
                        return;
                    }
                }
                var PlanSendTime = $("#txtplanSendTime").val();
                if ($.trim(PlanSendTime) == "") {
                    alert("请输入计划发货日期！");
                    return;
                }

                var PiHao = $("#txtpiHao").val();
                var ProductAddress = $("#txtproductAddress").val();
                var withWorkNo = $("#txtwithWorkNo").val();
                var id = getQueryString("id");
                
                //修改订单详情
                $.ajax({
                    type: "Get",
                    async: false,
                    url: "/Service/Order.ashx",
                    data: { opr: "updateproordersdetail",PlanSendTime:PlanSendTime,PiHao:PiHao,withWorkNo:withWorkNo,id:id},
                    success: function (data) {
                    }
                });
                

                //设置按钮不可用s
                $('#txtproNum').attr("disabled", "disabled");
                $('#txtplanSendTime').attr("disabled", "disabled");
                $('#txtpiHao').attr("disabled", "disabled");
                $('#txtproductAddress').attr("disabled", "disabled");
                //设置按钮不可用e

                var result = false;
                var printCount = 0;

                //获取随工单打印次数
                $.ajax({
                    type: "Get",
                    async: false,
                    url: "/Service/Order.ashx",
                    data: { opr:"getprintsgdcount", proType: proType, orderNum: orderNum },
                    contentType:"application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        printCount = data.d;

                        //前两次打印弹出图片提示,否则直接跳转到打印页面
                        if (printCount <= 2) {
                            $.ajax({
                                type: "Get",
                                async: false,
                                url: "/Service/Order.ashx",
                                data: { opr: 'isUpdateWaikeImg', proType: proType },
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    if (data.d > 0) {
                                        result = true;
                                        $.ajax({
                                            type: "Get",
                                            async: false,
                                            url: "/Service/Order.ashx",
                                            data: { opr: 'GetWaikwImg', proType: proType },
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
                                        // alert('失败');
                                    }
                                }
                            });

                            $.ajax({
                                type: "Get",
                                async: false,
                                url: "/Service/Order.ashx",
                                data: { opr: 'isUpdateBiaoshiImg', proType: proType },
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    if (data.d > 0) {
                                        result = true;
                                        $.ajax({
                                            type: "Get",
                                            async: false,
                                            url: "/Service/Order.ashx",
                                            data: { opr: 'GetBiaoshiImg', proType: proType },
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
                                        // alert('失败');
                                    }
                                }
                            });
                            if (!result) {
                                var customNum = $('#txtcustomNum').html();
                                var proType = $('#txtproType').val();
                                var orderNum = $('#txtorderNum').html();
                                var proNum = $('#txtproNum').val();
                                var planTime = $('#txtplanSendTime').val();
                                var pihao = $('#txtpiHao').val();
                                var withWorkNo = $('#txtwithWorkNo').val();//随工单号
                                var address = $('#txtproductAddress').val();
                                var detailId =<%=orderDetailId%>
                                window.open(Config.AppStartupDir + 'PrintSGD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&planTime=' + planTime + '&proNum=' + proNum + '&pihao=' + pihao + '&withWorkNo=' + withWorkNo, '打印随工单', '80%', '90%', false, false);
                            }
                        } else {
                            //将产品及外壳修改参数改为0
                            $.ajax({
                                type: "Get",
                                async: false,
                                url: "/Service/Order.ashx",
                                data: { opr: 'UpdateIsModify', proType: proType },
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                success: function (data) {

                                    if (data.d > 0) {
                                        //  alert('成功');
                                    } else {
                                        //  alert('失败');
                                    }
                                }
                            });
                            var customNum = $('#txtcustomNum').html();
                            var proType = $('#txtproType').val();
                            var orderNum = $('#txtorderNum').html();
                            var proNum = $('#txtproNum').val();
                            var planTime = $('#txtplanSendTime').val();
                            var pihao = $('#txtpiHao').val();
                            var withWorkNo = $('#txtwithWorkNo').val();
                            var address = $('#txtproductAddress').val();
                            var detailId =<%=orderDetailId%>
                            window.open(Config.AppStartupDir + 'PrintSGD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&planTime=' + planTime + '&proNum=' + proNum + '&pihao=' + pihao + '&withWorkNo='+withWorkNo, '打印随工单', '80%', '90%', false, false);
                        }
                    }
                });


            }
            function printQLD() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();
                var proNum = $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                window.open(Config.AppStartupDir + 'PrintQLD.aspx?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&withWorkNo=' + withWorkNo + '&proNum=' + proNum, '打印取料单', '80%', '90%', false, false);
            }
            function printYPQRD() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = "";// $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>
                window.open(Config.AppStartupDir + 'PrintYPQRD.aspx?proType=' + proType + '&customNum=' + customNum + '&proNum=' + proNum + '&address=' + address + '&orderNum=' + orderNum + '&planTime=' + planTime, '打印样品确认单', '80%', '90%', false, false);
            }

            function printBZBQ() {
                var customNum = $('#txtcustomNum').html();
                var proType = $('#txtproType').val();
                var orderNum = $('#txtorderNum').html();
                var proNum = $('#txtproNum').val();
                var planTime = $('#txtplanSendTime').val();
                var pihao = $('#txtpiHao').val();
                var withWorkNo = $('#txtwithWorkNo').val();
                var address = $('#txtproductAddress').val();
                var detailId =<%=orderDetailId%>

                window.open('/OrderManage/PrintBZBQ?proType=' + proType + '&orderNum=' + orderNum + '&customNum=' + customNum + '&proNum=' + proNum, '打印外包装标签', '80%', '90%', false, false);
            }

            function getQueryString(name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
                var r = window.location.search.substr(1).match(reg);
                if (r != null) return unescape(r[2]); return null;
            }
        </script>
    </form>
</body>
</html>
