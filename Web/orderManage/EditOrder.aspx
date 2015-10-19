<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_EditOrder" CodeBehind="EditOrder.aspx.cs" %>

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
                }
            });
            //默认添加一行
            //  AddSignRow();
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
            proType.innerHTML = "<input type='text' onblur='GetPrice(" + rowID + "," + newTR.rowIndex + ")' id='txtproType" + rowID + "' name='proType' size='20' datatype='*' nullmsg='请输入型号！'/>";

            //数量
            var shuliang = newTR.insertCell(3);
            shuliang.innerHTML = "数量";
            var proNum = newTR.insertCell(4);
            proNum.innerHTML = "<input type='text' id='txtproNum" + rowID + "' name='proNum' size='20' datatype='*' nullmsg='请输入数量！'/>";

            //单价
            var danjia = newTR.insertCell(5);
            danjia.innerHTML = "单价";
            var ProPrice = newTR.insertCell(6);
            ProPrice.innerHTML = "<input type='text' id='txtproType" + rowID + "' readonly='readonly' value='0' name='ProPrice' size='20' datatype='*' nullmsg='请输入单价！'/>";
            //var wuliao = newTR.insertCell(7);
            //wuliao.innerHTML = "客户物料编：";
            //var wuliaoBian = newTR.insertCell(8);
            //wuliaoBian.innerHTML = "<input type='text'  id='txtwuliaobian' name='wuliaobian' size='10' >";
            //添加列:删除按钮
            var newDeleteTD = newTR.insertCell(7);
            //添加列内容
            newDeleteTD.innerHTML = "<div style='text-align:center'><a href='javascript:;' onclick=\"printYPQRD('" + rowID + "')\">&nbsp;&nbsp;打印样品确认单</a><a href='javascript:;' onclick=\"DeleteSignRow('SignItem" + rowID + "')\">&nbsp;&nbsp;删除</a>&nbsp;&nbsp;<a href='#' style='color:red;' id='addTishi" + rowID + "'></a></div>";
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
            //删除输入线长提示
            //if (rowIndex == $("#hiddRowid").val()) {
            //    $("#spanYaoqiu").html("");
            //    $("#hiddRowid").val();
            //}
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
        //根据型号和客户编号获取价格
        function GetPrice(rowid, rowindex) {
            if ($('#txtcustomNum').val() != '') {
                if ($('#txtproType' + rowid).val() != "") {
                    $.ajax({
                        type: "GET",
                        async: false,
                        url: "/Service/Order.ashx",
                        data: { opr: "isExistProType", proType: $('#txtproType' + rowid).val() },
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d == 0) {
                                alert('该产品型号不存在！');
                                $('#txtproType' + rowid).val('');
                                return false;
                            } else {
                                //输入线长提示
                                $.ajax({
                                    type: "GET",
                                    async: false,
                                    url: "/Service/Order.ashx",
                                    data: { opr: "isAddXianchang", customerNum: $('#txtcustomNum').val(), proType: $('#txtproType' + rowid).val() },
                                    contentType: "application/json;charset=utf-8",
                                    dataType: "json",
                                    success: function (datas) {
                                        if (datas.d != "") {
                                            var arr = datas.d.toString().split(",");
                                            if (arr[0] == 1 && arr[1] == 1) {
                                                $("#addTishi" + rowid).html("该型号需要客户提供输入线长和输出线长");
                                            } else if (arr[0] == 1 && arr[1] == 0) {
                                                $("#addTishi" + rowid).html("该型号需要客户提供输入线长");
                                            } else if (arr[0] == 0 && arr[1] == 1) {
                                                $("#addTishi" + rowid).html("该型号需要客户提供输出线长");
                                            }
                                        }
                                    }
                                });
                                //查询单价
                                $.ajax({
                                    type: "GET",
                                    async: false,
                                    url: "/Service/Order.ashx",
                                    data: { opr: "GetPrice", customerNum: $('#txtcustomNum').val(), proType: $('#txtproType' + rowid).val() },
                                    contentType: "application/json;charset=utf-8",
                                    dataType: "json",
                                    success: function (data) {
                                        if (data.d == '')
                                        { $('#txtproPrice' + rowid).val(0); } else {
                                            $('#txtproPrice' + rowid).val(data.d);
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
                                return true;
                            }
                        }
                    });



                }
            } else { alert('请先填写客户编号！'); $('#txtproType' + rowid).val(''); }
        }
        function printYPQRD(rowid) {
            var customNum = $('#txtcustomNum').val();
            var orderNum = $('#txtorderNum').val();
            var proNum = $('#txtproNum' + rowid).val();
            var proType = $('#txtproType' + rowid).val();
            var address = '';

            window.open(Config.AppStartupDir + 'PrintYPQRD.aspx?proType=' + proType + '&customNum=' + customNum + '&proNum=' + proNum + '&address=' + address + '&orderNum=' + orderNum, '打印样品确认单', '80%', '90%', false, false);
        }
        function printYPQRDrpt(proType, proNum) {

            var customNum = $('#txtcustomNum').val();
            var orderNum = $('#txtorderNum').val();
            //  var proNum = $('#txtProNum').val();
            var address = '';

            window.open(Config.AppStartupDir + 'PrintYPQRD.aspx?proType=' + proType + '&customNum=' + customNum + '&proNum=' + proNum + '&address=' + address + '&orderNum=' + orderNum, '打印样品确认单', '80%', '90%', false, false);
        }
        function check() {
            if ($('#txtcustomNum').val() != "") {
                var result = true;
                $.ajax({
                    type: "GET",
                    async: false,
                    url: "/Service/Order.ashx",
                    data: { opr: "isAdd", customNum: $('#txtcustomNum').val() },
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 1) {
                            if ($('#txtcustomWLBH').val() == "" || $('#txtheTongNum').val() == "" || $('#txtcustomOrderNum').val() == "") {
                                alert('合同编号、客户订单号均不能为空！');
                                result = false;
                            } else {

                            }
                        } else {

                        }
                    }
                });
                return result;
            }
        }


    </script>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">编辑订单信息
                    </td>
                    <td class="optbtn">
                        <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" OnClientClick="return check();" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                            ToolTip="提交" CssClass="btn" />
                        <%--  <asp:ImageButton ID="IBtn_Print" runat="server" OnClick="Print_Click" ImageUrl="../themes/default/images/btn/btn_print_nbyj_b_h.png"
                            ToolTip="打印合同" CssClass="btn" />--%>
                      <%--  <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
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
                                nullmsg="请输入订单号！" errormsg="请输入订单号！"></asp:TextBox>
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
                            <asp:TextBox ID="txtheTongNum" runat="server" CssClass="tbox" d></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">客户订单号：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomOrderNum" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                       <%-- <td class="title1">客户物料编：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomWLBH" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>--%>
                        <td class="title1">客户维护人：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtcustomManager" runat="server" CssClass="tbox" datatype="*" nullmsg="请输入客户维护人！"
                                errormsg="请输入客户维护人！"></asp:TextBox>
                        </td>
                        
                        <td class="title1">
                        </td>
                        <td class="info">
                            <div class="info">
                                <asp:RadioButtonList ID="rbl发货状态" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="直接发" Value="直接发" />
                                    <asp:ListItem Text="等款" Value="等款" />
                                    <asp:ListItem Text="先生产，待通知" Value="先生产，待通知" />
                                </asp:RadioButtonList>
                            </div>
                        </td>

                        
                    </tr>

                    <tr>
                        <td class="title1">特殊要求：
                        </td>
                        <td class="info" colspan="5">
                            <asp:TextBox ID="txtremark" runat="server" CssClass="tarea" Rows="5" TextMode="MultiLine" style="width:100%"></asp:TextBox><br />
                            <span id="spanYaoqiu" runat="server" style="color: red;"></span>
                            <input type="hidden" id="hiddRowid" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <%-- <tr>
                        <td class="title1">输入线长：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtshuRuXianchang" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                        <td class="title1">输出线长：
                        </td>
                        <td class="info">
                            <asp:TextBox ID="txtshuChuXianchang" runat="server" CssClass="tbox"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="title1">产品信息
                        </td>
                        <td colspan="8" style="text-align: center; font-size: 12px; color: red;"><span id="tishi" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td colspan="6" style=" padding:0px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="SignFrame" class="tb" align="center" style="margin-top: 5px; border-top: 1px solid #004EA2">
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
                                            <td class="bbit-form-cell-value" align="left">
                                                <asp:TextBox ID="txtProNum" runat="server" Width="60" Text='<%# Eval("ProNum")%>'> </asp:TextBox>
                                            </td>
                                            <td>单价</td>
                                            <td>
                                                <asp:Label ID="lblProPrice" runat="server" Text='<%# Eval("ProPrice")%>'>
                                                </asp:Label>
                                            </td>
                                            <%--<td>客户物料编</td>
                                            <td>
                                                <asp:Label ID="lblWuliaobian" runat="server" Text='<%# Eval("wuliaobian")%>'>
                                                </asp:Label>
                                            </td>--%>
                                            <td  style="text-align:left; padding-left:40px;"><a href='javascript:;' onclick=" printYPQRDrpt('<%# Eval("ProType")%>', '<%# Eval("ProNum")%>')">&nbsp;&nbsp;打印样品确认单</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                            <div style="text-align: center; margin-top: 10px;">
                                <%--<input type="button" name="Submit" id="IBtn_Print" value="打印合同" class="current" onclick="BoxControl.Show(Config.AppStartupDir + 'Contract.aspx', '打印合同', '80%', '90%', false, false);"  />--%>
                                <input type="button" name="Submit" id="IBtn_Print" runat="server" value="打印合同" class="current" onclick="print()" />
                                <input type="button" name="Submit" value="添加型号" onclick="AddSignRow()" class="current" />
                                <input name='txtTRLastIndex' type='hidden' id='txtTRLastIndex' runat="server" />
                            </div>
                            <script type="text/javascript">

                                function print() {
                                    var customNum = $('#txtcustomNum').val();
                                    var orderNUM = $('#txtorderNum').val();
                                    window.open(Config.AppStartupDir + 'Contract.aspx?customerNo=' + customNum + '&orderNum=' + orderNUM, '打印合同', '80%', '90%', false, false);
                                }
                            </script>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
