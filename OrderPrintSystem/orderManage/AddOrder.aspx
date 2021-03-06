﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="orderManage_AddOrder" %>

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
    <script src="../scripts/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                }
            });
            //默认添加一行
            AddSignRow();
        })

        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }

        //添加一个参与人填写行
        function AddSignRow() { //读取最后一行的行号，存放在txtTRLastIndex文本框中 
            var txtTRLastIndex = findObj("txtTRLastIndex", document);
            var rowID;
            if (txtTRLastIndex != null) {
                rowID = parseInt(txtTRLastIndex.value);
            }

            var signFrame = findObj("SignFrame", document);
            //添加行
            var newTR = signFrame.insertRow(signFrame.rows.length);
            newTR.id = "SignItem" + rowID;

            //添加列:序号
            var newNameTD = newTR.insertCell(0);
            //添加列内容
            newNameTD.innerHTML = newTR.rowIndex + 1;

            //产品型号
            var xinghao = newTR.insertCell(1);
            xinghao.innerHTML = "型号";
            var proType = newTR.insertCell(2);
            proType.innerHTML = "<input type='text' onblur='GetPrice(" + rowID + ")' id='txtproType" + rowID + "' name='proType' size='20' datatype='*' nullmsg='请输入型号！'/>";

            //数量
            var shuliang = newTR.insertCell(3);
            shuliang.innerHTML = "数量";
            var proNum = newTR.insertCell(4);
            proNum.innerHTML = "<input type='text' id='txtproNum" + rowID + "' name='proNum' size='20' datatype='*' nullmsg='请输入数量！'/>";

            //单价
            var danjia = newTR.insertCell(5);
            danjia.innerHTML = "单价";
            var ProPrice = newTR.insertCell(6);
            ProPrice.innerHTML = "<input type='text' id='txtproPrice" + rowID + "' name='ProPrice' size='20' datatype='*' nullmsg='请输入单价！'/>";

            //添加列:删除按钮
            var newDeleteTD = newTR.insertCell(7);
            //添加列内容
            newDeleteTD.innerHTML = "<div style='width:200px;text-align:center'><a href='javascript:;' onclick=\"printYPQRD('" + rowID + "')\">&nbsp;&nbsp;打印样品确认单</a><a href='javascript:;' onclick=\"DeleteSignRow('SignItem" + rowID + "')\">&nbsp;&nbsp;删除</a></div>";
            //将行号推进下一行
            txtTRLastIndex.value = (rowID + 1).toString();

            //当前页面的高度
            //var gao = document.body.scrollHeight;
            //        $("#RightInfoArea").scrollTop(100000);



        }
        //删除指定行
        function DeleteSignRow(rowid) {

            var signFrame = findObj("SignFrame", document);
            var signItem = findObj(rowid, document);

            //获取将要删除的行的Index
            var rowIndex = signItem.rowIndex;
            //删除指定Index的行
            signFrame.deleteRow(rowIndex);

            //重新排列序号，如果没有序号，这一步省略
            for (i = rowIndex; i < signFrame.rows.length; i++) {
                signFrame.rows[i].cells[0].innerHTML = i + 1;
            }
        }

        function findObj(theObj, theDoc) {
            var p, i, foundObj;
            if (!theDoc) theDoc = document;
            if ((p = theObj.indexOf("?")) > 0 && parent.frames.length) {
                theDoc = parent.frames[theObj.substring(p + 1)].document; theObj = theObj.substring(0, p);
            }
            if (!(foundObj = theDoc[theObj]) && theDoc.all)
                foundObj = theDoc.all[theObj];
            for (i = 0; !foundObj && i < theDoc.forms.length; i++)
                foundObj = theDoc.forms[i][theObj];
            for (i = 0; !foundObj && theDoc.layers && i < theDoc.layers.length; i++)
                foundObj = findObj(theObj, theDoc.layers[i].document);
            if (!foundObj && document.getElementById)
                foundObj = document.getElementById(theObj);
            return foundObj;
        }

        function printYPQRD(rowid) {

            var customNum = $('#txtcustomNum').val();
            var orderNum = $('#txtorderNum').val();
            var proNum = $('#txtproNum' + rowid).val();
            var proType = $('#txtproType' + rowid).val();
            var address = '';

            window.open(Config.AppStartupDir + 'PrintYPQRD.aspx?proType=' + proType + '&customNum=' + customNum + '&proNum=' + proNum + '&address=' + address + '&orderNum=' + orderNum, '打印样品确认单', '80%', '90%', false, false);
        }

        //根据型号和客户编号获取价格
        function GetPrice(rowid) {
            if ($('#txtcustomNum').val().trim() != '') {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddOrder.aspx/GetPrice",
                    data: "{'customerNum':\"" + $('#txtcustomNum').val() + "\",'proType':\"" + $('#txtproType' + rowid).val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#txtproPrice' + rowid).val(data.d);
                    },
                    error: function (xml, status) {
                        if (status == 'error') {
                            try {
                                var json = eval('(' + xml.responseText + ')');
                                //                        alert(json.Message + '\n' + json.StackTrace);
                            } catch (e) { }
                        } else {
                            //                    alert(status);
                        }
                    }
                });
            } else { alert('请先填写客户编号！'); }
        }
        //根据客户编号控制打印合同按钮是否显示
        function isShowPrint() {
            if ($('#txtcustomNum').val().trim() != '') {
                $.ajax({
                    type: "Post",
                    async: false,
                    url: "AddOrder.aspx/IsShowPrint",
                    data: "{'customerNum':\"" + $('#txtcustomNum').val() + "\"}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 0) {
                            $('#IBtn_Print').css("display", "none");
                        } else {
                            $('#IBtn_Print').css("display", "inline");
                        }
                    },
                    error: function (xml, status) {
                        if (status == 'error') {
                            try {
                                var json = eval('(' + xml.responseText + ')');
                                //                        alert(json.Message + '\n' + json.StackTrace);
                            } catch (e) { }
                        } else {
                            //                    alert(status);
                        }
                    }
                });
            } else { alert('请先填写客户编号！'); }
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
                    <td class="info">编辑订单信息
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
            <div class="rightinfo" id="RightInfoArea" style="width: auto; height: 600px; overflow: scroll; overflow-x: hidden;">
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">订单信息
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">订单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtorderNum" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入订单号！" errormsg="请输入订单号！"></asp:TextBox>
                        </td>
                        <td class="title1">客户编号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomNum" runat="server" CssClass="tbox" Rows="5" datatype="*" nullmsg="请输入客户编号！"
                                errormsg="请输入客户编号！" onblur="isShowPrint()"></asp:TextBox>
                        </td>
                        <td class="title1">合同编号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtheTongNum" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入合同编号！" errormsg="请输入合同编号！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>

                        <td class="title1">客户订单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomOrderNum" runat="server" CssClass="tbox" datatype="*"
                                nullmsg="请输入客户订单号！" errormsg="请输入客户订单号！"></asp:TextBox>
                        </td>
                        <td class="title1">客户物料编：
                        </td>
                        <td class="info">
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
                            <asp:TextBox ID="txtremark" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            <%-- <textarea class="ckeditor" cols="80" id="editor1" name="editor1" rows="10" runat="server"></textarea>--%>
                        </td>
                    </tr>

                    <tr>
                        <td class="title1">产品信息
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="SignFrame" class="tb"
                                style="margin-top: 5px;" align="center">
                            </table>
                            <div style="width: 700px; text-align: right; margin-top: 10px;">
                                <input type="button" name="Submit" id="IBtn_Print" runat="server" value="打印合同" class="current" onclick="print()" />
                                
                                <input type="button" name="Submit" value="添加型号" onclick="AddSignRow()" class="current" />
                                <input name='txtTRLastIndex' type='hidden' id='txtTRLastIndex' runat="server" value="0" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <script type="text/javascript">

                function print() {
                    var customNum = $('#txtcustomNum').val();
                    var orderNUM = $('#txtorderNum').val();
                    window.open(Config.AppStartupDir + 'Contract.aspx?customerNo=' + customNum + '&orderNum=' + orderNUM, '打印合同', '80%', '90%', false, false);
                }
            </script>
        </div>
    </form>
</body>
</html>
