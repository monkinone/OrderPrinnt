<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnWareHouse.aspx.cs" Inherits="Web.DomainUI_2.ReturnWareHouse" %>

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
    <!--功能JS-->
    <script src="../JS_2/DoMain/ReturnWareHouse.js"></script>
    <title>退料</title>
</head>
<body>
      <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">退料日志</div>
       <div style="margin:10px;">
            <span>物料名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_materialName" />
            <span>物料型号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_modelNumber" />
            <span>仓库名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_wareHouse" />
            <a href="javascript:searchOutWareHouseLog()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>          
            <a href="javascript:showAddDialog()" style="right:10px;" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">退料</a>
       </div>
    <table id="dg_outWareHouseLog">
        <thead>  
            <tr>
                <th data-options="field:'MaterialName',align:'center',width:200">物料名称</th>  
                <th data-options="field:'ModelNumber',align:'center',width:200">物料型号</th>  
                <th data-options="field:'CategoryName',align:'center',width:200">物料类别</th>
                <th data-options="field:'UnitName',align:'center',width:200">单位名称</th> 
                <th data-options="field:'WareHouseName',align:'center',width:200">仓库名称</th>
                <th data-options="field:'Amout',align:'center',width:200">退料数量</th> 
                <th data-options="field:'Remark',align:'center',width:200">特殊说明</th> 
            </tr>  
        </thead>
    </table>

    <!------------弹窗--------------->
    <!----添加退料s--->
    <div id="dlg_outWareHouse_add" class="easyui-dialog" title="退料" style="width:800px;height:400px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
         <div class="sear_list">
               <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">物料型号：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="txt_modelNumber" disabled="disabled" />
                    <font style="color:red">*</font>
                     <a href="javascript:showSelectMaterial()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">选择物料</a>       
                </li>
              </ul>
              <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">物料名称：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="txt_materialName" maxlength="50" />
                    <font style="color:red">*</font>
                </li>
                <li class="b10_right">单位：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="txt_unit" />      
                </li>
              </ul>
              <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">物料类别：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="txt_categoryName"/>
                    <input type="hidden" id="hid_categoryID" />
                </li>
              </ul>
              <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">仓库名称：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="txt_wareHouseName" maxlength="50" disabled="disabled" />
                    <input type="hidden" id="hid_wareHouseID"/>
                    <font style="color:red">*</font>     
                    <a href="javascript:showSelectWareHouse()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">选择仓库</a>  
                </li>
                <li class="b10_right">退料数量：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="txt_amout" />      
                    <font style="color:red">*</font>     
                </li>
              </ul>
              <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">特殊说明：</li>
                <li class="b50_left">
                    <input type="text" class="inpu_bg" id="txt_remark" />
                </li>
              </ul>
               <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">部门：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="tbx_department" maxlength="50" />
                </li>
                <li class="b10_right">操作管理员：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="tbx_doby" />      
                </li>
              </ul>
               <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">入库经手人：</li>
                <li class="b35_left">
                    <input type="text" class="inpu_bg" id="tbx_dealWithBy" maxlength="50" />
                </li>
              </ul>
         </div>
	</div>
    <div id="dlg-buttons_add1">
		<a href="javascript:addEnterWareHouse()" class="easyui-linkbutton">保存</a>
		<a href="javascript:$('#dlg_outWareHouse_add').dialog('close');" class="easyui-linkbutton">取消</a>
	</div>
   <!----仓库名称e--->
   <!--物料选择窗体s-->
   <div id="dlg_material" class="easyui-dialog" title="物料选择（单击一行选择物料）" style="width:800px;height:500px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-search'">
           <div style="margin:10px;">
            <span>物料名称：</span>
            <input type="text" class="inpu_bg" id="tbx_search_materialName_dlg" />
            <span>物料型号：</span>
            <input type="text" class="inpu_bg" id="tbx_search_modelNumber_dlg" />
            <a href="javascript:searchMaterial()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>
          </div>
        <table id="dg_Material">
            <thead>  
                <tr>  
                    <th data-options="field:'MaterialName',align:'center',width:200">物料名称</th>  
                    <th data-options="field:'ModelNumber',align:'center',width:200">物料型号</th>  
                    <th data-options="field:'CategoryName',align:'center',width:200">物料类别</th>
                    <th data-options="field:'UnitName',align:'center',width:100">单位</th>
                </tr>  
            </thead>
        </table>
    </div>
   <!--物料选择窗体e-->
   <!--仓库选择窗体s-->
    <div id="dlg_wareHouse" class="easyui-dialog" title="仓库选择（单击一行选择仓库）" style="width:800px;height:500px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-search'">
         <span style="margin:10px; font-size:15px ;color:red;">提示：如果表格空的，就表明没有可以存放该物料的仓库。</span>
         <table id="dg_warehouse">  
            <thead>  
                <tr>  
                    <th data-options="field:'WareHouseName',align:'center',width:200">仓库名称</th>  
                    <th data-options="field:'Position',align:'center',width:200">位置</th>  
                    <th data-options="field:'CategoryNames',align:'center',width:400">可存放的物料类别</th>  
                    <th data-options="field:'Remark',align:'center',width:400">备注</th>
                </tr>  
            </thead>
        </table> 
    </div>
   <!--仓库选择窗体e-->
</body>
</html>