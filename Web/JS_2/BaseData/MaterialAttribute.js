///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>
$(function () {
    //*****原料属性******
    $("#dg_MaterialAttribute").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=MaterialAttribute',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    });
    //设置分页控件       
    var p = $('#dg_MaterialAttribute').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });

});
//查询原料属性
function searchMaterialAttribute() {
    var tbx_search_attribute = $("#tbx_search_attribute").val();
    $('#dg_MaterialAttribute').datagrid('load', {
        AttributeName: tbx_search_attribute
    });
}
//添加原料属性
function addMaterialAttribute() {
    var name = $("#tbx_AttributeName").val();
    if ($.trim(name) == "") {
        alert("原料属性不能为空！");
        $("#tbx_AttributeName").focus();
        return;
    }
    $.post(
        "/Service/BaseDataService_2/AddService.ashx",
        { opr: "MaterialAttribute", AttributeName: name },
        function (data) {
            if (data.d == 1) {        
                $('#dg_MaterialAttribute').datagrid('reload');
                $('#dlg_shuxing_add').dialog('close');
                $("#tbx_AttributeName").val("");
                alert("添加成功!");
            }
        }
  );
}
//编辑原料属性
function editMaterialAttribute() {
    var name = $("#tbx_AttributeName_edit").val();
    if ($.trim(name) == "") {
        alert("原料属性不能为空！");
        $("#tbx_AttributeName_edit").focus();
        return;
    }
    var id = $('#dg_MaterialAttribute').datagrid('getSelected').ID;
    $.post(
        "/Service/BaseDataService_2/EditService.ashx",
        { opr: "MaterialAttribute", ID: id, AttributeName: name },
        function (data) {
            if (data.d == 1) {
                $('#dg_MaterialAttribute').datagrid('reload');
            }
            $('#dlg_shuxing_edit').dialog('close');
            alert("编辑成功!");
        }
  );
}
//删除原料属性
function deleteMaterialAttribute() {
    var row = $('#dg_MaterialAttribute').datagrid('getSelected');
    if (confirm("确定删除【" + row.AttributeName + "】原料属性吗？")) {
        $.post(
            "/Service/BaseDataService_2/DeleteService.ashx",
            { opr: "MaterialAttribute", ID: row.ID },
            function (data) {
                if (data.d == 1) {               
                    $('#dg_MaterialAttribute').datagrid('reload');
                    alert("删除成功!");
                }
            }
      );
    }
}
//打开编辑原料属性窗
function openEditMaterialAttribute() {
    var row = $('#dg_MaterialAttribute').datagrid('getSelected');
    //原料属性名称
    $("#tbx_AttributeName_edit").val(row.AttributeName);
    //打开修改窗体
    $("#dlg_shuxing_edit").dialog('open');
}

//原料属性 编辑、删除
function formatOperMaterialAttribute(val, row, index) {
    return '<a href="javascript:openEditMaterialAttribute()">编辑</a> <a href="javascript:deleteMaterialAttribute()">删除</a>';
}