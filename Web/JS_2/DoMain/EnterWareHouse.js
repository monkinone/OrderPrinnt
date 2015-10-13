///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>

$(function () {
    //*****入仓日志表******
    $("#dg_enterWareHouseLog").datagrid({
        url: '/Service/DomainService_2/EnterWareHouse.ashx?opr=warehouse',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    });
    //设置分页控件       
    var p = $('#dg_enterWareHouseLog').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });
});
//显示增加物料入仓的窗体
function showAddDialog() {
    $("#dlg_rucang_add").dialog("open");
    
    var txt_orderID = $("#txt_orderID");
    var txt_modelNumber = $("#txt_modelNumber");
    var txt_materialName = $("#txt_materialName");
    var txt_unit = $("#txt_unit");
    var txt_categoryName = $("#txt_categoryName");
    var txt_suppliersName = $("#txt_suppliersName");
    var txt_wareHouseName = $("#txt_wareHouseName");
    var txt_amout = $("#txt_amout");
    var txt_remark = $("#txt_remark");
    var tbx_department = $("#tbx_department");
    var tbx_doby = $("#tbx_doby");
    var tbx_dealWithBy = $("#tbx_dealWithBy");
    //清理数据
    txt_orderID.val("");
    txt_modelNumber.val("");
    txt_materialName.val("");
    txt_unit.val("");
    txt_categoryName.val("");
    txt_suppliersName.val("");
    txt_wareHouseName.val("");
    txt_amout.val("");
    txt_remark.val("");
    tbx_doby.val("");
    tbx_dealWithBy.val("");
    tbx_department.val("");
}
//显示选择物料弹窗
function showSelectMaterial() {
    $("#dlg_material").dialog("open");
    //*****物料信息******
    $("#dg_Material").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=Material',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true,//分页控件 
        onClickRow: function (rowIndex, rowData) {
            $("#txt_modelNumber").val(rowData.ModelNumber);
            $("#txt_materialName").val(rowData.MaterialName);
            $("#txt_unit").val(rowData.UnitName);
            $("#txt_categoryName").val(rowData.CategoryName);
            //关闭物料选择窗
            $("#dlg_material").dialog("close");
        }
    });
    //设置分页控件       
    var p = $('#dg_Material').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为20        
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });
}
//显示选择仓库弹窗
function showSelectWareHouse() {
    $("#dlg_wareHouse").dialog("open");
    //*****仓库名称表******
    $("#dg_warehouse").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=warehouse',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
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
}

//查询物料信息
function searchMaterial() {
    var tbx_search_materialName = $("#tbx_search_materialName_dlg").val();
    var tbx_search_modelNumber = $("#tbx_search_modelNumber_dlg").val();
    $('#dg_Material').datagrid('load', {
        MaterialName: tbx_search_materialName,
        ModelNumber: tbx_search_modelNumber
    });
}
