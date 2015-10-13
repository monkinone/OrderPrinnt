///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>
$(function () {
    //*****计量单位******
    $("#dg_Unit").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=Unit',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    });
    //设置分页控件       
    var p = $('#dg_Unit').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });

});
//查询计量单位
function searchUnit() {
    var tbx_search_attribute = $("#tbx_search_unit").val();
    $('#dg_Unit').datagrid('load', {
        UnitName: tbx_search_attribute
    });
}
//添加计量单位
function addUnit() {
    var name = $("#tbx_Unit").val();
    if ($.trim(name) == "") {
        alert("计量单位不能为空！");
        $("#tbx_Unit").focus();
        return;
    }
    $.post(
        "/Service/BaseDataService_2/AddService.ashx",
        { opr: "Unit", UnitName: name },
        function (data) {
            if (data.d == 1) {
                $('#dg_Unit').datagrid('reload');
                $('#dlg_Unit_add').dialog('close');
                $("#tbx_Unit").val("");
                alert("添加成功!");
            }
        }
  );
}
//编辑计量单位
function editUnit() {
    var name = $("#tbx_Unit_edit").val();
    if ($.trim(name) == "") {
        alert("计量单位不能为空！");
        $("#tbx_Unit_edit").focus();
        return;
    }
    var id = $('#dg_Unit').datagrid('getSelected').ID;
    $.post(
        "/Service/BaseDataService_2/EditService.ashx",
        { opr: "Unit", ID: id, UnitName: name },
        function (data) {
            if (data.d == 1) {
                $('#dg_Unit').datagrid('reload');
            }
            $('#dlg_Unit_edit').dialog('close');
            alert("编辑成功!");
        }
  );
}
//删除计量单位
function deleteUnit() {
    var row = $('#dg_Unit').datagrid('getSelected');
    if (confirm("确定删除【" + row.UnitName + "】计量单位吗？")) {
        $.post(
            "/Service/BaseDataService_2/DeleteService.ashx",
            { opr: "Unit", ID: row.ID },
            function (data) {
                if (data.d == 1) {
                    $('#dg_Unit').datagrid('reload');
                    alert("删除成功!");
                }
            }
      );
    }
}
//打开编辑计量单位窗
function openEditUnit() {
    var row = $('#dg_Unit').datagrid('getSelected');
    //计量单位名称
    $("#tbx_Unit_edit").val(row.UnitName);
    //打开修改窗体
    $("#dlg_Unit_edit").dialog('open');
}

//计量单位 编辑、删除
function formatOperUnit(val, row, index) {
    return '<a href="javascript:openEditUnit()">编辑</a> <a href="javascript:deleteUnit()">删除</a>';
}