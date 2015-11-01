<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliverGoodsList.aspx.cs" Inherits="Web.BaseDataUI_2.DeliverGoodsList" %>

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
            $("#dgorderinfo").datagrid({
                url: '/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=getAllDeliverGoodsList',
                loadMsg: "正在加载，请稍等...",
                pageSize: 20,
                rownumbers: true,//行号    
                singleSelect: true,//是否单选
                pagination: true//分页控件 
            })
        })

        //查找按钮
        function searchData() {
            var tbx_search_OrderID = $("#tbx_search_OrderID").val();
            var tbx_search_ModelNumber = $("#tbx_search_ModelNumber").val();
            var tbx_search_CompanyName = $("#tbx_search_CompanyName").val();
            $('#dgorderinfo').datagrid('load', {
                OrderID: tbx_search_OrderID,
                ModelNumber: tbx_search_ModelNumber,
                CompanyName: tbx_search_CompanyName
            });
        }



    </script>
    <title>发货明细列表</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">供应商发货情况</div>
    <div style="margin: 10px;">
        <span>供应商名称：</span>
        <input type="text" class="inpu_bg" id="tbx_search_CompanyName" />
        <span>采购订单编号：</span>
        <input type="text" class="inpu_bg" id="tbx_search_OrderID" />
        <span>物料型号：</span>
        <input type="text" class="inpu_bg" id="tbx_search_ModelNumber" />

        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="searchData()" data-options="iconCls:'icon-search',plain:true">查询</a>
    </div>
    <table id="dgorderinfo" title="发货情况列表" style="width: 1400px; height: auto">
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
                <th data-options="field:'Requirement',width:100">特殊要求</th>
                <th data-options="field:'DeliverGoodsTime',width:100">发货时间</th>
                <th data-options="field:'DeliveryNum',width:100">发货单号</th>
                <th data-options="field:'LogisticsCompany',width:100">货运公司名称</th>

            </tr>
        </thead>

    </table>

</body>
</html>
