<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrders.aspx.cs" Inherits="Web.DomainUI_2.PurchaseOrders" %>

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
    <title>采购订单管理</title>
</head>
<body>
     <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">采购订单</div>
         <div style="margin:10px;">
            <span>采购订单编号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_OrderID" />
            <span>状态：</span>
            <select id="sel_search_status" style="width:120px;">
              <option value ="-1">==选择状态==</option>
              <option value ="0">未生存合同</option>
              <option value="1">部分生产合同</option>
              <option value="2">全部生产合同</option>
            </select>
            <span>时间：</span>
            <input class="easyui-datebox" id="tbx_search_addTime_begin" />
             <label>-</label>
            <input class="easyui-datebox" id="tbx_search_addTime_end" />
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
        </div>
        <table class="easyui-datagrid">
            <thead>
                <tr>  
                    <th data-options="field:'code',align:'center',width:200">采购订单号</th>  
                    <th data-options="field:'name',align:'center',width:200">时间</th>  
                    <th data-options="field:'price',align:'center',width:200">编辑人</th>
                    <th data-options="field:'code',align:'center',width:200">状态</th>
                    <th data-options="field:'price4',align:'center',width:200">操作</th>   
                </tr>  
            </thead>
        </table>
</body>
</html>
