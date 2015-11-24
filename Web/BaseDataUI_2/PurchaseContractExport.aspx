<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseContractExport.aspx.cs" Inherits="Web.BaseDataUI_2.PurchaseContractExport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js">       
    </script>
    <script type="text/javascript">
        $(function () {
            //发货情况列表
            $("#dgorderinfo").datagrid({
                url: '/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=PurchaseContractExport',
                loadMsg: "正在加载，请稍等...",
                pageSize: 20,
                rownumbers: true,//行号    
                singleSelect: true,//是否单选
                pagination: true//分页控件 
            })

            //合同详情数据表格
            $("#htdetailinfo").datagrid({
                loadMsg: "正在加载，请稍等...",
                singleSelect: true,
                rownumbers: true
            })
        })

        //操作
        function formatop(val, row, index) {
            return '<a class="red" href="javascript:htdetail()">详情</a> ';
        }
        //时间格式化
        function formattime(val, row, index) {
            if (val) {
                val = val.split("T")[0];
            }
            return val;
        }
        //合同详情
        function htdetail() {
            var row = $('#dgorderinfo').datagrid('getSelected');
            //合同详情对话框
            $("#dlg_htdetailinfo").dialog("open");

            $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getHtDetail",
                { ContractID: row.ContractID }, function (data) {
                    $("#htdetailinfo").datagrid("loadData", data);
                })
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

    </script>
    <title>合同导出</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">合同导出</div>
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

    <table id="dgorderinfo" title="合同信息" style="width: 1000px; height: auto">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:300">采购订单编号</th>
                <th data-options="field:'AddTime',width:300,formatter:formattime">日期</th>
                <th data-options="field:'op',width:300,formatter:formatop">操作</th>
            </tr>
        </thead>

    </table>


    <div id="dlg_htdetailinfo" class="easyui-dialog" title="合同详情" style="width: 800px; height: 400px;"
        data-options="modal:true,closed:true,iconCls: 'icon-ok'">
        <table id="htdetailinfo" title="合同信息" style="width: 780px; height: auto">
            <thead>
                <tr>
                    <th data-options="field:'OrderID',width:120">采购订单编号</th>
                    <th data-options="field:'ContractID',width:120">合同编号</th>
                    <th data-options="field:'ModelNumber',width:50">物料型号</th>
                    <th data-options="field:'CategoryName',width:50">物料类别</th>
                    <th data-options="field:'Amout',width:50">数量</th>
                    <th data-options="field:'TechnicalParameters',width:100">技术参数</th>
                    <th data-options="field:'Requirement',width:100">特殊要求</th>
                </tr>
            </thead>

        </table>
    </div>
</body>
</html>
