///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>

$(function () {
    //*****出仓日志表******
    $("#dg_outWareHouseLog").datagrid({
        url: '/Service/DomainService_2/OutWareHouse.ashx?opr=searchoutwarehouselog',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    });
    //设置分页控件       
    var p = $('#dg_outWareHouseLog').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });
});
//查询出仓日志
function searchOutWareHouseLog() {
    var tbx_search_materialName = $("#tbx_search_materialName").val();
    var tbx_search_modelNumber = $("#tbx_search_modelNumber").val();
    var tbx_search_wareHouse = $("#tbx_search_wareHouse").val();
    $('#dg_outWareHouseLog').datagrid('load', {
        MaterialName: tbx_search_materialName,
        ModelNumber: tbx_search_modelNumber,
        WareHouseName: tbx_search_wareHouse
    });
}
//显示增加物料出仓的窗体
function showAddDialog() {
    $("#dlg_outWareHouse_add").dialog("open");

    var txt_modelNumber = $("#txt_modelNumber");
    var txt_materialName = $("#txt_materialName");
    var txt_unit = $("#txt_unit");
    var txt_categoryName = $("#txt_categoryName");
    var txt_wareHouseName = $("#txt_wareHouseName");
    var txt_amout = $("#txt_amout");
    var txt_remark = $("#txt_remark");
    var tbx_department = $("#tbx_department");
    var tbx_doby = $("#tbx_doby");
    var tbx_dealWithBy = $("#tbx_dealWithBy");
    //清理数据
    txt_modelNumber.val("");
    txt_materialName.val("");
    txt_unit.val("");
    txt_categoryName.val("");
    txt_wareHouseName.val("");
    txt_amout.val("");
    txt_remark.val("");
    tbx_doby.val("");
    tbx_dealWithBy.val("");
    tbx_department.val("");
}
//添加
function addEnterWareHouse() {
    var ModelNumber = $("#txt_modelNumber").val();
    if (ModelNumber.trim() == "") {
        alert("请选择物料型号");
        return;
    }
    var MaterialName = $("#txt_materialName").val();
    if (MaterialName.trim() == "") {
        alert("请填写物料名称");
        return;
    }
    var Unit = $("#txt_unit").val();
    var CategoryName = $("#txt_categoryName").val();
    var CategoryID = $("#hid_categoryID").val();
    var WareHouseName = $("#txt_wareHouseName").val();
    if (WareHouseName.trim() == "") {
        alert("请选择仓库");
        return;
    }
    var WareHouseID = $("#hid_wareHouseID").val();
    var Amout = $("#txt_amout").val();
    if (Amout.trim() == "") {
        alert("请输入出仓数量");
        return;
    }
    var Remark = $("#txt_remark").val();
    var Department = $("#tbx_department").val();
    var Doby = $("#tbx_doby").val();
    var DealWithBy = $("#tbx_dealWithBy").val();

    $.post(
     "/Service/DomainService_2/OutWareHouse.ashx",
     {
         opr: "addoutwarehouse",
         WareHouseID: WareHouseID,
         WareHouseName: WareHouseName,
         MaterialName: MaterialName,
         ModelNumber: ModelNumber,
         Amout: Amout,
         CategoryName: CategoryName,
         UnitName: Unit,
         Remark: Remark,
         DealWithBy: DealWithBy,
         Department: Department,
         DoBy: Doby
     },
     function (data) {
         if (data.d == 1) {
             $('#dg_outWareHouseLog').datagrid('reload');
             $('#dlg_outWareHouse_add').dialog('close');
             alert("保存成功!");
         } else {
             alert(data.msg);
         }
     }
    );
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
            $("#hid_categoryID").val(rowData.CategoryID);
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
    var CategoryID = $("#hid_categoryID").val();
    if (CategoryID == "") {
        alert("请先选择物料！");
        return;
    }
    $("#dlg_wareHouse").dialog("open");
    //*****仓库名称表******
    $("#dg_warehouse").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=warehouse&CategoryID=' + CategoryID,
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号
        singleSelect: true,//是否单选
        pagination: true,//分页控件 
        onClickRow: function (rowIndex, rowData) {
            $("#txt_wareHouseName").val(rowData.WareHouseName);
            $("#hid_wareHouseID").val(rowData.ID);
            //关闭选择仓库的弹窗
            $("#dlg_wareHouse").dialog("close");
        }
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
