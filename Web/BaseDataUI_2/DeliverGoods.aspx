<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliverGoods.aspx.cs" Inherits="Web.BaseDataUI_2.DeliverGoods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />

    <style type="text/css">
     
    </style>
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js">       
    </script>
    <script type="text/javascript">

        $(function () {
            $("#OrderID").combobox({
                url: '/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=getOrderlist',
                method: 'post',
                valueField: 'OrderID',
                textField: 'OrderID',
                onSelect: function (record) {
                    if (!$("#deID").val()) {
                        $("#ModelNumber").val(record.ModelNumber);
                        $("#MaterialName").val(record.MaterialName);
                    }
                }
            });

            $("#dgorderinfo").datagrid({
                url: '/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=getDeliverGoodsList',
                loadMsg: "正在加载，请稍等...",
                pageSize: 20,
                rownumbers: true,//行号    
                singleSelect: true,//是否单选
                pagination: true//分页控件 
            })
        })
        //弹出添加明细窗口
        function toCreate() {
            var row = $('#dgorderinfo').datagrid('getSelected');
            $("#deID").val(row.ID);
            $("#OrderID").combobox("select", row.OrderID);
            $("#ModelNumber").val(row.ModelNumber);
            $("#MaterialName").val(row.MaterialName);
            $("#TheDeliveryAmout").val(row.TheDeliveryAmout),
            $("#Number").val(row.Number),
            $("#DeliveryNum").val(row.DeliveryNum),
            $("#LogisticsCompany").val(row.LogisticsCompany);
            $("#dlg_add").dialog("open");
        }

        function formatop(val, row, index) {
            return '<a class="red" href="javascript:toCreate()">录入发货明细</a> ';
        }
        //查找按钮
        function searchData() {
            var tbx_search_OrderID = $("#tbx_search_OrderID").val();
            var tbx_search_ModelNumber = $("#tbx_search_ModelNumber").val();
            var sel_search_isDelivered = $("#sel_search_isDelivered").combobox("getValue");
            $('#dgorderinfo').datagrid('load', {
                OrderID: tbx_search_OrderID,
                ModelNumber: tbx_search_ModelNumber,
                isDelivered: sel_search_isDelivered
            });
        }

        //弹出添加明细框
        function addinfo() {
            $("#dlg_add input").val("");
            $("#dlg_add").dialog("open");
        }

        //明细
        function edit() {
            var OrderID = $("#OrderID").combobox("getText"),
              ModelNumber = $("#ModelNumber").val(),
              MaterialName = $("#MaterialName").val(),
              TheDeliveryAmout = $("#TheDeliveryAmout").val(),
              Number = $("#Number").val(),
              DeliveryNum = $("#DeliveryNum").val(),
              LogisticsCompany = $("#LogisticsCompany").val();
            $.post("/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=addDeliverGoods", {
                ID: $("#deID").val(),
                OrderID: OrderID,
                ModelNumber: ModelNumber,
                MaterialName: MaterialName,
                TheDeliveryAmout: TheDeliveryAmout,
                Number: Number,
                DeliveryNum: DeliveryNum,
                LogisticsCompany: LogisticsCompany
            }, function (data) {
                if (data.d > 0) {
                    alert("明细添加成功！");
                    $('#dgorderinfo').datagrid('reload');
                } else {
                    alert("明细添加失败！");
                }
                adddialoginit();
            })
        }
        //对话框取消按钮
        function adddialoginit() {
            $("#dlg_add input").val("");
            $("#dlg_add").dialog("close");
        }

    </script>

    <title>供应商发货明细录入</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">供应商发货明细录入</div>
    <div style="margin: 10px;">
        <span>采购订单编号：</span>
        <input type="text" class="inpu_bg" id="tbx_search_OrderID" />
        <span>物料型号：</span>
        <input type="text" class="inpu_bg" id="tbx_search_ModelNumber" />
        <span>状态：</span>
        <select id="sel_search_isDelivered" class="easyui-combobox" style="width: 120px;">
            <option value="">全部</option>
            <option value="0">未发货</option>
            <option value="1">已发货</option>
        </select>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="searchData()" data-options="iconCls:'icon-search',plain:true">查询</a>
    </div>


    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="addinfo()" data-options="iconCls:'icon-add',plain:true">添加发货明细</a>

    <table id="dgorderinfo" title="发货情况列表" style="width: 1300px; height: auto">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:100">采购订单编号</th>
                <th data-options="field:'CompanyName',width:100">供应商名称</th>
                <th data-options="field:'MaterialName',width:100">物料名称</th>
                <th data-options="field:'Amout',width:100">订单总量</th>
                <th data-options="field:'TechnicalParameters',width:100">参数</th>
                <th data-options="field:'AllDeliverCount',width:100">已发货数量累计</th>
                <th data-options="field:'TheDeliveryAmout',width:100">本次发货数量</th>
                <th data-options="field:'Number',width:100">件数</th>
                <th data-options="field:'DeliverGoodsTime',width:100">发货时间</th>
                <th data-options="field:'DeliveryNum',width:100">发货单号</th>
                <th data-options="field:'LogisticsCompany',width:100">货运公司名称</th>

                <th data-options="field:'op',width:100,formatter:formatop">操作</th>
            </tr>
        </thead>

    </table>
    <%-- <div id="tborder" style="height: auto">
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="createOrder()">生成订单</a>
    </div>--%>

    <div id="dlg_add" class="easyui-dialog" title="添加发货明细" style="width: 500px; height: 400px; padding: 10px"
        data-options="modal:true,closed:true,iconCls: 'icon-add',buttons: '#dlg-buttons_add1'">
        <div class="sear_list">
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">订单号：</li>
                <li class="b20_left">
                    <select style="width: 165px" id="OrderID">
                    </select>
                    <input type="hidden" class="inpu_bg" id="deID" />
                    <%--<input type="text" class="inpu_bg" readonly="true" id="OrderID" />--%>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">物料名称：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" readonly="true" id="MaterialName" />
                    <input type="hidden" class="inpu_bg" readonly="true" id="ModelNumber" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">本次发货数量：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="TheDeliveryAmout" />
                </li>
            </ul>

            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">件数：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="Number" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">发货单号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="DeliveryNum" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">货运公司：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="LogisticsCompany" />
                </li>
            </ul>
        </div>
    </div>
    <div id="dlg-buttons_add1">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:edit()">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:adddialoginit()">取消</a>
    </div>

</body>
</html>
