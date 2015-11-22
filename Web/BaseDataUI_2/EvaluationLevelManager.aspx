<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluationLevelManager.aspx.cs" Inherits="Web.BaseDataUI_2.EvaluationLevelManager" %>

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
    <script src="../JS_2/BaseData/EvaluationLevel.js">    


    </script>
    <title>供应商等级管理</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">供应商等级管理</div>
    <div style="width: 100%; margin: 10px;">
        <span>供应商：</span>
        <select id="tbx_search_SuppliersID" style="width: 160px" class="inpu_bg"></select>
        <a href="javascript:searchEvaluationLevel()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>
        <a href="javascript:openEvaluationLeveldialog()" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
    </div>
    <table class="easyui-datagrid" id="dg_EvaluationLevel">
        <thead>
            <tr>
                <th data-options="field:'SuppliersID',align:'center',width:100">供应商编号</th>
                <th data-options="field:'CompanyName',align:'center',width:200">公司名称</th>
                <th data-options="field:'Level',align:'center',width:100">当前等级</th>
                <th data-options="field:'opr',align:'center',width:100,formatter:formatOperEvaluationLevel">操作</th>
            </tr>
        </thead>
    </table>


    <%-- 弹出窗口--%>

    <!----添加--->
    <div id="dlg_EvaluationLevel" class="easyui-dialog" opertype="add" title="添加" style="width: 560px; height: 200px; padding: 6px"
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
                <li class="b10_right">等级：</li>
                <li class="b20_left">
                    <input style="width: 165px" id="tbx_Level" />
                    <label class="red">*</label>
                </li>
            </ul>
          
        </div>
    </div>
    <div id="dlg-buttons_add1">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addMaterialPrice()">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:adddialoginit()">取消</a>
    </div>


    <div id="dlginfo" class="easyui-dialog" title="详情" style="width: 560px; height: 300px; padding: 6px"
        data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add2'">
        <div class="sear_list">
            <%--     <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">供应商编号：</li>
                <li class="b20_left">
                    <input style="width: 165px" id="tbx_SuppliersID_info" disabled="disabled" />
                    <label class="red">*</label>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">等级：</li>
                <li class="b20_left">
                    <input style="width: 165px" id="tbx_Level_info" disabled="disabled"  />
                    <label class="red">*</label>
                </li>
            </ul>--%>
            <%--   <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">评审记录：</li>
                <li class="b20_left">
                    <textarea style="width: 200px; height: 80px" id="tbx_Remark_info" disabled="disabled" ></textarea>
                </li>
            </ul>--%>
        </div>
    </div>
    <div id="dlg-buttons_add2">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript: $('#dlginfo .sear_list').html(''); $('#dlginfo').dialog('close');">取消</a>
    </div>
</body>
</html>
