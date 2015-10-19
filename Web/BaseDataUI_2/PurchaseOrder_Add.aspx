<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrder_Add.aspx.cs" Inherits="Web.BaseDataUI_2.PurchaseOrder_Add" %>

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
    <script src="../JS_2/BaseData/PurchaseOrder_Add.js">    
    </script>

    <title>增加采购订单</title>
</head>
<body>

    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">增加采购订单</div>
    <span style="font-size: 14px; margin: 10px; font-family: 'Microsoft YaHei';">采购订单号:</span>
    <label style="font-size: 14px; margin: 10px; font-family: 'Microsoft YaHei';" id="cgorderid" class="red">系统自动生成</label>
    <br />
    <span style="font-size: 14px; margin: 10px; font-family: 'Microsoft YaHei';">产品信息:</span>
    <table border="0" cellpadding="3" cellspacing="1" style="margin-left: 10px; background-color: #b9d8f3; width: 1000px; font-size: 14px; font-family: 'Microsoft YaHei';">
        <thead>
            <tr>
                <td>物料型号</td>
                <td>数量</td>
                <td>特殊要求</td>
                <td>操作</td>
            </tr>
        </thead>
        <tr>
            <td>
                <input id="btnselect" type="button" onclick="checkMaterial()" value="选择物料" />
                <input id="selectmaterial" type="text" style="display:none;" readonly="readonly" /></td>
            <td>
                <input type="number" value="0" id="Amout" />
            </td>
            <td>
                <textarea id="Requirement" ></textarea></td>
            <td>
                <input type="button" onclick="addtoorder()" id="addtoorder" value="添加到下面订单中" />
            </td>
        </tr>
    </table>

    <br />
    <br />
    <br />
    <br />

    <%--订单信息显示--%>
    <table id="dgcginfo" class="easyui-datagrid" title="订单信息" style="width: 1000px; height: auto"
        data-options="                
				iconCls: 'icon-edit',
				singleSelect: true,
				toolbar: '#tborder',					
                rownumbers: true  
			">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:100">采购订单编号</th>
                <th data-options="field:'MaterialName',width:100">物料名称</th>
                <th data-options="field:'ModelNumber',width:100">物料型号</th>
                <th data-options="field:'CategoryName',width:100">物料类别</th>
                <th data-options="field:'UnitName',width:100">单位</th>
                <th data-options="field:'Amout',width:100">数量</th>
                <th data-options="field:'TechnicalParameters',width:100">技术参数</th>
                <th data-options="field:'Requirement',width:100">特殊要求</th>
            </tr>
        </thead>

    </table>
    <div id="tborder" style="height: auto">
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="createOrder()">生成订单</a>
    </div>


    <%--添加物料对话框--%>
    <div id="dlgselectMaterial" class="easyui-dialog" title="选择物料" style="width: 800px; height: 400px;"
        data-options="
        iconCls:'icon-save',
        closed: true,
        resizable:true, 
        buttons:'#dlgselect',
        modal:true
        ">
        <table id="dgmaterial" style="width: 600px; height: auto">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'MaterialName',width:100">物料名称</th>
                    <th data-options="field:'ModelNumber',width:100">物料型号</th>
                    <th data-options="field:'CategoryName',width:100">物料类别</th>
                    <th data-options="field:'UnitName',width:100">单位</th>
                    <th data-options="field:'AllCount',width:100">库存量</th>
                </tr>
            </thead>
        </table>

    </div>


    <div id="dlgselect" style="height: auto">
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true" onclick="dlgselectcancel()">取消</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true" onclick="dlgselectok()">确定</a>
    </div>

</body>
</html>
