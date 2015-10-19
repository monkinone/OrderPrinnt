<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialPriceManage.aspx.cs" Inherits="Web.BaseDataUI_2.MaterialPriceManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />

    <style type="text/css">
        .b10_right {
            width: 100px;
        }
    </style>
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>


    <!--功能JS-->

    <script src="../JS_2/BaseData/MaterialPrice.js"></script>
    <script type="text/javascript">
       
    </script>
    <title>供应商单价管理</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">供应商单价列表</div>
    <div style="width: 100%; margin: 10px;">
        <span>供应商：</span>
        <select id="tbx_search_SuppliersID" style="width: 160px" class="inpu_bg"></select>
        <span>物料：</span>
        <select id="tbx_search_ModelNumber" style="width: 160px" class="inpu_bg"></select>
        <a href="javascript:searchMaterialPrice()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>
        <a href="javascript:openMaterialPricedialog()" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
    </div>
    <table class="easyui-datagrid" id="dg_MaterialPrice">
        <thead>
            <tr>
                <th data-options="field:'SuppliersID',align:'center',width:100">供应商编号</th>
                <th data-options="field:'CompanyName',align:'center',width:200">公司名称</th>
                <th data-options="field:'ModelNumber',align:'center',width:100">物料型号</th>
                <th data-options="field:'MaterialName',align:'center',width:100">物料名称</th>
                <th data-options="field:'UnitPrice',align:'center',width:100">单价</th>
                <th data-options="field:'opr',align:'center',width:100,formatter:formatOperMaterialPrice">操作</th>
            </tr>
        </thead>
    </table>


    <%-- 弹出窗口--%>

    <!----添加--->
    <div id="dlg_MaterialPrice" class="easyui-dialog" opertype="add" title="供应商单价" style="width: 600px; height: 300px; padding: 6px"
        data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
        <div class="sear_list">
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">供应商编号：</li>
                <li class="b20_left">
                    <input type="hidden" id="dlgID" />
                    <select class="easyui-combobox" style="width: 165px" id="tbx_SuppliersID">
                    </select><label class="red">*</label>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">物料型号：</li>
                <li class="b20_left">
                    <select class="easyui-combobox" style="width: 165px" id="tbx_ModelNumber">
                    </select><label class="red">*</label>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">单价：</li>
                <li class="b20_left">
                    <input style="width: 165px" id="tbx_UnitPrice" />
                    <label class="red">*</label>
                </li>
            </ul>
            <%--  <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">调价记录：</li>
                <li class="b20_left">
                    <textarea style="width: 100%; height: 80px" id="tbx_Remark"></textarea>
                </li>
            </ul>--%>
        </div>
    </div>
    <div id="dlg-buttons_add1">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addMaterialPrice()">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:adddialoginit()">取消</a>
    </div>

    <div id="dlg_info" class="easyui-dialog" title="供应商调价记录" style="width: 600px; height: 300px; padding: 6px"
        data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_info'">
        <div class="sear_list">
        </div>
    </div>
    <div id="dlg-buttons_info">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg_info .sear_list').html('');$('#dlg_info').dialog('close');">取消</a>
    </div>
</body>
</html>
