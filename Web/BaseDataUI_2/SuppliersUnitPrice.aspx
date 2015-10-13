<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliersUnitPrice.aspx.cs" Inherits="Web.BaseDataUI_2.SuppliersUnitPrice" %>

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
    <title>供应商单价</title>
</head>
<body>
     <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">供应商单价</div>
         <div style="margin:10px;">
            <span>物料型号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_model_number" />
            <span>供应商编号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_supplier_id" />
            <span>公司名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_company_name" />
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>          
            <a href="javascript:$('#dlg_level_add').dialog('open')" style="right:10px;" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
        </div>
        <table class="easyui-datagrid">
            <thead>  
                <tr>  
                    <th data-options="field:'code',align:'center',width:200">供应商编号</th>  
                    <th data-options="field:'name',align:'center',width:300">公司名称</th>  
                    <th data-options="field:'price',align:'center',width:200">物料型号</th>
                    <th data-options="field:'price',align:'center',width:200">单价</th>
                    <th data-options="field:'price4',align:'center',width:200">操作</th>   
                </tr>  
            </thead>
        </table>
       <!-------------弹出窗体-------------->
     <!----添加评定等级s--->
    <div id="dlg_level_add" class="easyui-dialog" title="添加" style="width:400px;height:240px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
         <div class="sear_list">
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">供应商编号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="txt_supplier_id" maxlength="50" />
                    <label class="red">*</label>
                </li>
            </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">物料型号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tb_model_number" maxlength="50" />
                    <label class="red">*</label>
                </li>
            </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">单价：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_Level" />
                    <label class="red">*</label>
                </li>
            </ul>
         </div>
	</div>
    <div id="dlg-buttons_add1">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addWareHouse()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg').dialog('close')">取消</a>
	</div>
   <!----添加评定等级s--->
</body>
</html>
