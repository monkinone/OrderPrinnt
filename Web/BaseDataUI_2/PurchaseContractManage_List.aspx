<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseContractManage_List.aspx.cs" Inherits="Web.BaseDataUI_2.PurchaseContractManage_List" %>

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
            $("#htinfo").datagrid({
                url: '/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getPurchaseContractList',
                loadMsg: "正在加载，请稍等...",
                pageSize: 20,
                singleSelect: true,
                rownumbers: true,
                pagination: true//分页控件 
            })
            //获取供应商数据
            $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getSuppliersList",
                function (data) {
                    if (data)
                        getSuppliersdata(data);
                })
        })

        //获取供应商id
        function getSuppliersdata(data) {
            data.unshift({ ID: "", CompanyName: "==请选择供应商==" });
            $('#tbx_search_supplier_id').combobox({
                data: data,
                editable: true,
                valueField: 'ID',
                textField: 'ID',
                onChange: selectChange
            });
            
            $('#tbx_search_company_name').combobox({
                data: data,
                editable: true,
                textField: 'CompanyName',
                valueField: 'ID',
                onChange: selectChange
            });
        }

        function selectChange(newValue, oldValue) {
            $('#tbx_search_supplier_id').combobox("select", newValue);
            $('#tbx_search_company_name').combobox("select", newValue);
        }

        //删除合同
        function del() {
            var row = $('#htinfo').datagrid('getSelected');
            if (confirm("确定删除合同吗？")) {
                $.post(
                    "/Service/BaseDataService_2/PurchaseContractManage.ashx",
                    { opr: "delPurchaseContract", ID: row.ID },
                    function (data) {
                        if (data.d > 0) {
                            $('#htinfo').datagrid('reload');
                            alert("删除成功!");
                        } else {
                            alert("删除失败!");
                        }
                    }
              );
            }
        }

        function formatop(val, row, index) {
            return '<a class="red" href="javascript:del()">删除</a> ';
        }
        //查询数据
        function searchData() {
            var tbx_search_ContractID = $("#tbx_search_ContractID").val();
            var tbx_search_OrderID = $("#tbx_search_OrderID").val();
            var SupplierId = $("#tbx_search_company_name").combobox("getValue");

            $('#htinfo').datagrid('load', {
                ContractID: tbx_search_ContractID,
                OrderID: tbx_search_OrderID,
                SupplierId: SupplierId
            });
        }

    </script>


    <title>合同管理</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">合同管理</div>
    <div style="margin: 10px;">
        <span>合同编号：</span>
        <input type="text" style="width: 150px" class="inpu_bg" id="tbx_search_ContractID" />
        <span>采购订单编号：</span>
        <input type="text" style="width: 150px" class="inpu_bg" id="tbx_search_OrderID" />
        <span>公司名称：</span>
        <input type="text" style="width: 150px" class="inpu_bg" id="tbx_search_company_name" />
        <span>供应商编号：</span>
        <input type="text" style="width: 100px" class="inpu_bg" id="tbx_search_supplier_id" />

        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="searchData()" data-options="iconCls:'icon-search',plain:true">查询</a>
    </div>
    <table id="htinfo" title="合同信息" style="width: 1000px; height: auto">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:150">采购订单编号</th>
                <th data-options="field:'ContractID',width:150">合同编号</th>
                <th data-options="field:'CompanyName',width:150">供应商名称</th>
                <th data-options="field:'AddTime',width:150">订单时间</th>
                <%-- <th data-options="field:'ModelNumber',width:100">物料型号</th>
                <th data-options="field:'CategoryName',width:100">物料类别</th>

                <th data-options="field:'Amout',width:100">数量</th>--%>
                <%-- <th data-options="field:'TechnicalParameters',width:100">技术参数</th>
                <th data-options="field:'Requirement',width:100">特殊要求</th>--%>
                <th data-options="field:'op',width:100,formatter:formatop">操作</th>
            </tr>
        </thead>

    </table>
</body>
</html>
