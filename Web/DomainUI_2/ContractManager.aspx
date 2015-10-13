<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractManager.aspx.cs" Inherits="Web.DomainUI_2.ContractManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>
    <title>合同管理</title>
</head>
<body>
     <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">合同管理</div>
         <div style="margin:10px;">
            <span>合同编号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_ContractID" />
            <span>采购订单编号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_OrderID" />
            <span>供应商编号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_supplier_id" />
            <span>公司名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_company_name" />
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>          
        </div>
        <table class="easyui-datagrid">
            <thead>
                <tr>  
                    <th data-options="field:'code',align:'center',width:200">采购订单号</th>  
                    <th data-options="field:'name',align:'center',width:200">合同编号</th>  
                    <th data-options="field:'price',align:'center',width:200">供应商编号</th>
                    <th data-options="field:'code',align:'center',width:300">公司名称</th>  
                    <th data-options="field:'price',align:'center',width:200">订单总金额</th>
                    <th data-options="field:'price4',align:'center',width:200">操作</th>   
                </tr>  
            </thead>
        </table>
</body>
</html>