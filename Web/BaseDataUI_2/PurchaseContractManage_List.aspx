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
        })
        function del()
        {
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

    </script>


    <title>合同管理</title>
</head>
<body>
    <table id="htinfo" title="合同信息" style="width: 1000px; height: auto">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:100">采购订单编号</th>
                <th data-options="field:'ContractID',width:100">合同编号</th>
                <th data-options="field:'CompanyName',width:100">供应商名称</th>
                <th data-options="field:'AddTime',width:100">订单时间</th>
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
