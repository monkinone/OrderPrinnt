<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialManager.aspx.cs" Inherits="Web.BaseDataUI.MaterialManager" %>

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
    <script src="../JS_2/BaseData/Material.js"></script>
    <title>物料管理</title>
</head>
<body>
    <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">物料信息</div>
        <div style="margin:10px;">
            <span>物料名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_materialName" />
            <span>物料型号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_modelNumber" />
            <span>物料类别：</span>
            <input type="text" class="inpu_bg" id="tbx_categoryName" />
            <a href="javascript:searchMaterial()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>          
            <a href="javascript:openDialogAdd()" style="right:10px;" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
        </div>
        <table id="dg_Material">
            <thead>  
                <tr>  
                    <th data-options="field:'MaterialName',align:'center',width:200">物料名称</th>  
                    <th data-options="field:'ModelNumber',align:'center',width:200">物料型号</th>  
                    <th data-options="field:'CategoryName',align:'center',width:200">物料类别</th>
                    <th data-options="field:'UnitName',align:'center',width:100">单位</th>
                    <th data-options="field:'price2',align:'center',width:200">总库存量</th> 
                    <th data-options="field:'AttributeName',align:'center',width:200">原料属性</th> 
                    <th data-options="field:'price4',align:'center',width:200,formatter:formatOperMaterial">操作</th>   
                </tr>  
            </thead>
        </table>

    <!------------弹窗--------------->
     <!----物料信息编辑s--->
    <div id="dlg_material_add" class="easyui-dialog" title="物料信息" style="width:700px;height:400px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
         <div class="sear_list">
              <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">物料型号：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="tbx_modelNumber" maxlength="50" />
                    <label class="red">*</label>
                </li>
                <li class="b15_right">物料名称：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="tbx_marterialName" maxlength="50" />
                    <label class="red">*</label>
                </li>
             </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">物料类别：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_category"  onfocus="searchMaterialCategory()" maxlength="50" />
                   <label class="red">*</label>
                </li>
                <li class="b15_right">物料属性：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_attributeName" maxlength="50" />
                   <label class="red">*</label>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">计量单位：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_unit" maxlength="50" />
                   <label class="red">*</label>
                </li>
                <li class="b15_right"></li>
                <li class="b30_left">
                   <input type="checkbox" id="tbx_status"/>
                   <label>非使用中</label>
                </li>
            </ul>
           <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">库存上限：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_upperLimit" maxlength="50" />
                   <label class="red">*</label>
                </li>
                <li class="b15_right">库存下限：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_lowerLimit" maxlength="50" />
                   <label class="red">*</label>
                </li>
           </ul>
           <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">存货信息：</li>
                <li class="b30_left">
                <table id="dg_KuCun">
                    <thead>  
                        <tr>  
                            <th data-options="field:'WareHouseName',width:100">仓库</th>  
                            <th data-options="field:'KuCun',width:90" editor="{type:'text'}">期初库存</th> 
                        </tr>  
                    </thead>
                </table>
                </li>
                <li class="b15_right">技术参数：</li>
                <li class="b30_left">
                 <textarea style="width:100%;height:80px;" id="tbx_technicalParameter"></textarea>
                </li>
           </ul>
         </div>
	</div>
    <div id="dlg-buttons_add1">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addMaterial()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_material_add').dialog('close')">取消</a>
	</div>
   <!----物料信息编辑e--->   
    <!----物料信息编辑s--->
    <div id="dlg_material_edit" class="easyui-dialog" title="物料信息" style="width:700px;height:400px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_edit1'">
         <div class="sear_list">
              <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">物料型号：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="tbx_edit_modelNumber" maxlength="50" />
                    <label class="red">*</label>
                </li>
                <li class="b15_right">物料名称：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="tbx_edit_marterialName" maxlength="50" />
                    <label class="red">*</label>
                </li>
             </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">物料类别：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_edit_category"  onfocus="searchMaterialCategory()" maxlength="50" />
                   <label class="red">*</label>
                </li>
                <li class="b15_right">物料属性：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_edit_attributeName" maxlength="50" />
                   <label class="red">*</label>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">计量单位：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_edit_unit" maxlength="50" />
                   <label class="red">*</label>
                </li>
                <li class="b15_right"></li>
                <li class="b30_left">
                   <input type="checkbox" id="tbx_edit_status" />
                   <label>非使用中</label>
                </li>
            </ul>
           <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">库存上限：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_edit_upperLimit" maxlength="50" />
                   <label class="red">*</label>
                </li>
                <li class="b15_right">库存下限：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="tbx_edit_lowerLimit" maxlength="50" />
                   <label class="red">*</label>
                </li>
           </ul>
           <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">存货信息：</li>
                <li class="b30_left">
                <table id="dg_edit_KuCun">
                    <thead>  
                        <tr>  
                            <th data-options="field:'WareHouseName',width:100">仓库</th>  
                            <th data-options="field:'KuCun',width:90" editor="{type:'text'}">期初库存</th> 
                        </tr>  
                    </thead>
                </table>
                </li>
                <li class="b15_right">技术参数：</li>
                <li class="b30_left">
                 <textarea style="width:100%;height:80px;" id="tbx_edit_technicalParameter"></textarea>
                </li>
           </ul>
         </div>
	</div>
    <div id="dlg-buttons_edit1">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:editMaterial()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_material_edit').dialog('close')">取消</a>
	</div>
   <!----物料信息编辑e--->   
</body>
</html>
