<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrder_List.aspx.cs" Inherits="Web.BaseDataUI_2.PurchaseOrder_List" %>

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


    <!--功能JS-->
    <script type="text/javascript">
        $(function () {
            $("#dgorderinfo").datagrid({
                url: '/Service/BaseDataService_2/PurchaseOrdersManager.ashx?opr=getOrderList',
                loadMsg: "正在加载，请稍等...",
                pageSize: 20,
                rownumbers: true,//行号    
                singleSelect: true,//是否单选
                pagination: true//分页控件 
            })
        })
        //生成合同
        function toCreate() {
            var row = $('#dgorderinfo').datagrid('getSelected');
            window.location.href = "PurchaseContract_Add.aspx?orderid=" + row.OrderID;
        }

        function formatop(val, row, index) {
            return '<a class="red" href="javascript:toCreate()">生成合同</a> ';
        }
    </script>
    <title>采购订单列表</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">采购订单列表</div>

    <table id="dgorderinfo" title="订单列表" style="width: 1000px; height: auto">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:200">采购订单编号</th>
                <th data-options="field:'AddBy',width:200">创建人</th>
                <th data-options="field:'AddTime',width:200">创建时间</th>

                <th data-options="field:'op',width:200,formatter:formatop">操作</th>
            </tr>
        </thead>

    </table>
    <%-- <div id="tborder" style="height: auto">
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="createOrder()">生成订单</a>
    </div>--%>
</body>
</html>
