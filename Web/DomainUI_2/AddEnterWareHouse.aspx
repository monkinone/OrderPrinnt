<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEnterWareHouse.aspx.cs" Inherits="Web.DomainUI_2.AddEnterWareHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>
    <!--功能JS-->
    <script src="../JS_2/DoMain/EnterWareHouse.js"></script>
    <title>物料进仓</title>
</head>
<body>
   <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">新增物料入仓</div>
    <div style="margin:10px;">
        <a href="" class="easyui-linkbutton">添加</a>   
        <a href="" class="easyui-linkbutton">删除</a>
    </div>
     <table id="dg_enterWareHouseLog">
        <thead>  
            <tr>
                <th data-options="field:'OrderID',align:'center',width:200">采购订单编号</th>
                <th data-options="field:'ModelNumber',align:'center',width:200">物料型号</th> 
                <th data-options="field:'MaterialName',align:'center',width:200">物料名称</th>
                <th data-options="field:'MaterialName',align:'center',width:200">物料名称</th>   
                <th data-options="field:'WareHouseName',align:'center',width:200">入仓名称</th>
                <th data-options="field:'Amout',align:'center',width:200">入仓数量</th> 
                <th data-options="field:'DoBy',align:'center',width:200">操作管理员</th> 
                <th data-options="field:'DoTime',align:'center',width:200">日期</th>   
            </tr>  
        </thead>
    </table>
     <div style="margin:10px;">
        <span>操作管理员：</span><input  type="text" id="tbx_doby"/>
        <span>部门：</span><input  type="text" id="tbx_department"/>
        <span>入库经手人：</span><input  type="text" id="tbx_dealWithBy"/>
    </div>
</body>
</html>
