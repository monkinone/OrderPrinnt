<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WareHouse.aspx.cs" Inherits="Web.BaseDataUI_2.WareHouse" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>
    <!--功能JS-->
    <script src="../JS_2/BaseData/warehouse.js"></script>
    <script src="../JS_2/BaseData/materialcategory.js"></script>
    <script src="../JS_2/BaseData/Unit.js"></script>
    <script src="../JS_2/BaseData/MaterialAttribute.js"></script>
    <title>仓库管理</title>
</head>
<body>
    <div style="font-size:20px;margin:10px;font-family:'Microsoft YaHei';">仓库管理</div>
	<div class="easyui-tabs" data-options="fit:true">
		<div title="仓库名称">
         <div style="width:100%; margin:10px;">
           <span>仓库名称：</span>
           <input type="text" class="inpu_bg" id="tbx_search_material" />
           <a href="javascript:searchWareHouse()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>   
           <a href="javascript:$('#dlg_cangku_add').dialog('open');bindComboTree_add()" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
        </div>
         <table id="dg_warehouse">  
            <thead>  
                <tr>  
                    <th data-options="field:'WareHouseName',align:'center',width:200">仓库名称</th>  
                    <th data-options="field:'Position',align:'center',width:200">位置</th>  
                    <th data-options="field:'CategoryNames',align:'center',width:400">可存放的物料类别</th>  
                    <th data-options="field:'Remark',align:'center',width:400">备注</th>
                    <th data-options="field:'opr',align:'center',width:100,formatter:formatOperWareHouse">操作</th>
                </tr>  
            </thead>
        </table> 
		</div>
		<div title="物料类别">	
         <div style="width:100%;margin:10px;">
            <span>类别名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_category" />
             <a href="javascript:searchMaterialCategory()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>   
            <a href="javascript:$('#dlg_MaterialCategory_add').dialog('open')" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
         </div>
         <table id="dg_materialcategory">  
            <thead>  
                <tr>  
                    <th data-options="field:'CategoryName',align:'left',width:200">物料类别</th>
                    <th data-options="field:'opr',align:'center',width:100,formatter:formatMaterialCategory">操作</th>  
                </tr>  
            </thead>
        </table>
		</div>
		<div title="计量单位">
            <div style="width:100%;margin:10px;">
               <span>计量单位名称：</span>
               <input type="text" class="inpu_bg" id="tbx_search_unit" />
               <a href="javascript:searchUnit()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>   
               <a href="javascript:$('#dlg_Unit_add').dialog('open')" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
            </div>
             <table id="dg_Unit">  
                <thead>  
                    <tr>  
                        <th data-options="field:'UnitName',align:'center',width:200">计量单位</th>  
                        <th data-options="field:'opr',align:'center',width:100,formatter:formatOperUnit">操作</th>  
                    </tr>  
                </thead>
            </table>     
		</div>
        <div title="原料属性">
            <div style="width:100%;margin:10px;">
               <span>原料属性名称：</span>
               <input type="text" class="inpu_bg" id="tbx_search_attribute" />
               <a href="javascript:searchMaterialAttribute()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>
               <a href="javascript:$('#dlg_Unit_add').dialog('open')" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
            </div>
             <table id="dg_MaterialAttribute">  
                <thead>  
                    <tr>  
                        <th data-options="field:'AttributeName',align:'center',width:200">原料属性</th>
                        <th data-options="field:'opr',align:'center',width:100,formatter:formatOperMaterialAttribute">操作</th>  
                    </tr>  
                </thead>
            </table>   
		</div>
	</div>

    <!------------弹窗--------------->
    <!----添加仓库名称s--->
    <div id="dlg_cangku_add" class="easyui-dialog" title="添加库房名称" style="width:500px;height:320px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">仓库名称：</li>
                <li class="b60_left">
                    <input type="text" class="inpu_bg" id="txt_name" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">位置：</li>
                <li class="b60_left">
                    <input type="text" class="inpu_bg" id="tbx_position" />
                </li>
            </ul>
           <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">可存放的物料类别：</li>
                <li class="b60_left">
                    <input type="text" class="inpu_bg" id="com_category" />
                </li>
            </ul>
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">备注：</li>
                <li class="b60_left">
                    <textarea class="inpu_bg" id="tbx_remark" cols="3" style="width:250px; height:50px;"></textarea>
                </li>
            </ul>
         </div>
	</div>
    <div id="dlg-buttons_add1">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addWareHouse()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_cangku_add').dialog('close')">取消</a>
	</div>
   <!----仓库名称e--->
   <!----编辑仓库名称s--->
    <div id="dlg_cangku_edit" class="easyui-dialog" title="编辑库房名称" style="width:500px;height:320px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_edit1'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">仓库名称：</li>
                <li>
                    <input type="text" class="inpu_bg" id="txt_edit_name" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">位置：</li>
                <li>
                    <input type="text" class="inpu_bg" id="txt_edit_position" />
                </li>
            </ul>
           <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">可存放的物料类别：</li>
                <li class="b60_left">
                    <input type="text" class="inpu_bg" id="com_category_edit" />
                </li>
            </ul>
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b25_right">备注：</li>
                <li>
                    <textarea class="inpu_bg" id="txt_edit_remark" cols="3" style="width:250px; height:50px;"></textarea>
                </li>
            </ul>
         </div>
	</div>
    <div id="dlg-buttons_edit1">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:editWareHouse()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_cangku_edit').dialog('close')">取消</a>
	</div>
   <!----仓库名称e--->
   <!----添加物料类别s---->
        <div id="dlg_MaterialCategory_add" class="easyui-dialog" title="物料类别" style="width:400px;height:190px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add2'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">类别名称：</li>
                <li>
                    <input type="text" class="inpu_bg" id="txt_CategoryName" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">上一级：</li>
                <li>
                    <input type="text" class="inpu_bg" id="txt_ParentName" />
                </li>
            </ul>
         </div>
	</div>
       <div id="dlg-buttons_add2">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addMaterialCategory()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_MaterialCategory_add').dialog('close')">取消</a>
	</div>
   <!----添加物料类别e---->
   <!----编辑物料类别s---->
    <div id="dlg_MaterialCategory_edit" class="easyui-dialog" title="物料类别" style="width:400px;height:190px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_edit2'">
     <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">类别名称：</li>
                <li>
                    <input type="text" class="inpu_bg" id="txt_CategoryName_edit" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">上一级：</li>
                <li>
                    <input type="text" class="inpu_bg" id="txt_ParentName_edit" />
                </li>
            </ul>
    </div>
	</div>
       <div id="dlg-buttons_edit2">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:editMaterialCategory()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_MaterialCategory_edit').dialog('close')">取消</a>
	</div>
   <!----编辑物料类别e---->
   <!----添加计量单位s---->
        <div id="dlg_Unit_add" class="easyui-dialog" title="计量单位" style="width:400px;height:160px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg_buttons_add3'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">计量单位：</li>
                <li>
                    <input type="text" class="inpu_bg" id="tbx_Unit" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
         </div>
	</div>
       <div id="dlg_buttons_add3">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addUnit()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_Unit_add').dialog('close')">取消</a>
	  </div>
   <!----添加计量单位e---->
   <!----编辑计量单位s---->
        <div id="dlg_Unit_edit" class="easyui-dialog" title="计量单位" style="width:400px;height:160px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg_buttons_edit3'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">计量单位：</li>
                <li>
                    <input type="text" class="inpu_bg" id="tbx_Unit_edit" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
         </div>
	</div>
       <div id="dlg_buttons_edit3">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:editUnit()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_Unit_edit').dialog('close')">取消</a>
	  </div>
   <!----编辑计量单位e---->
   <!----添加原料属性s---->
        <div id="dlg_shuxing_add" class="easyui-dialog" title="原料属性" style="width:400px;height:160px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg_buttons_add4'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">原料属性：</li>
                <li>
                    <input type="text" class="inpu_bg" id="tbx_AttributeName" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
         </div>
	</div>
    <div id="dlg_buttons_add4">
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addMaterialAttribute()">保存</a>
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_shuxing_add').dialog('close')">取消</a>
	</div>
   <!----添加原料属性e---->
   <!----编辑原料属性s---->
        <div id="dlg_shuxing_edit" class="easyui-dialog" title="原料属性" style="width:400px;height:160px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg_buttons_edit4'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">原料属性：</li>
                <li>
                    <input type="text" class="inpu_bg" id="tbx_AttributeName_edit" maxlength="50" />
                    <font class="red">*</font>
                </li>
            </ul>
         </div>
	</div>
    <div id="dlg_buttons_edit4">
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:editMaterialAttribute()">保存</a>
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_shuxing_edit').dialog('close')">取消</a>
	</div>
   <!----编辑原料属性e---->
</body>
</html>