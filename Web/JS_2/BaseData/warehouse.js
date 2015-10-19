///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>
$(function () {
    //*****仓库名称表******
    $("#dg_warehouse").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=warehouse',
        loadMsg: "正在加载，请稍等...",
        pageSize:20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    });
    //设置分页控件       
    var p = $('#dg_warehouse').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });
});

//查询仓库
function searchWareHouse() {
    var tbx_search_material = $("#tbx_search_material").val();
    $('#dg_warehouse').datagrid('load', {
        WareHouseName: tbx_search_material
    });
}
//添加仓库
function addWareHouse() {
    var name = $("#txt_name").val();
    if ($.trim(name) == "") {
        alert("仓库名称不能为空！");
        $("#txt_name").focus();
        return;
    }
    var position = $("#tbx_position").val();
    var categoryIDs = $("#com_category").combotree("getValues")+"";
    var categoryNames = $("#com_category").combotree("getText");
    var remark = $("#tbx_remark").val();
    $.post(
        "/Service/BaseDataService_2/AddService.ashx",
        { opr: "warehouse", WareHouseName: name, Position: position,CategoryIDs:categoryIDs,categoryNames:categoryNames,Remark: remark },
        function (data) {
            if (data.d == 1) {
                $('#dg_warehouse').datagrid('reload');
                $('#dlg_cangku_add').dialog('close');
                $("#txt_name").val("");
                $("#tbx_position").val("");
                $("#tbx_remark").val("");
                alert("添加成功!");
            }       
        }
  );
}
//编辑仓库
function editWareHouse(){
    var name = $("#txt_edit_name").val();
    if ($.trim(name) == "") {
        alert("仓库名称不能为空！");
        $("#txt_edit_name").focus();
        return;
    }
    var position = $("#txt_edit_position").val();
    var categoryIDs = $("#com_category_edit").combotree("getValues") + "";
    var categoryNames = $("#com_category_edit").combotree("getText");
    var remark = $("#txt_edit_remark").val();
    var id = $('#dg_warehouse').datagrid('getSelected').ID;
    $.post(
        "/Service/BaseDataService_2/EditService.ashx",
        { opr: "warehouse", ID: id, WareHouseName: name, Position: position, CategoryIDs: categoryIDs, categoryNames: categoryNames, Remark: remark },
        function (data) {
            if (data.d == 1) {
                $('#dg_warehouse').datagrid('reload');
            }
            $('#dlg_cangku_edit').dialog('close');
            alert("编辑成功!");
        }
  );
}
//删除仓库
function deleteWareHouse() {
    var row = $('#dg_warehouse').datagrid('getSelected');
    if (confirm("确定删除【" + row.WareHouseName + "】仓库吗？")) {
        $.post(
            "/Service/BaseDataService_2/DeleteService.ashx",
            { opr: "warehouse", ID: row.ID },
            function (data) {
                if (data.d == 1) {
                    $('#dg_warehouse').datagrid('reload');
                    alert("删除成功!");
                }
            }
      );
    }
}
//打开编辑仓库窗
function openEditWareHouse() {
    var row = $('#dg_warehouse').datagrid('getSelected');
    //仓库名称
    $("#txt_edit_name").val(row.WareHouseName);
    //仓库位置
    $("#txt_edit_position").val(row.Position);
    //位置
    $("#txt_edit_remark").val(row.Remark);
    //打开修改窗体
    $("#dlg_cangku_edit").dialog('open');

    //可存放的物料类别
    $("#com_category_edit").combotree({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialcategory_combotree&CategoryIDs=' + row.CategoryIDs,
        multiple: true,
        checkbox: true,
        onlyLeafCheck: true
    });
}
//绑定下拉树--添加
function bindComboTree_add() {
    $("#com_category").combotree({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialcategory_combotree',
        multiple:true,
        checkbox: true,
        onlyLeafCheck:true
    });
}

//仓库 编辑、删除
function formatOperWareHouse(val, row, index) {
    return '<a href="javascript:openEditWareHouse()">编辑</a> <a href="javascript:deleteWareHouse()">删除</a>';
}