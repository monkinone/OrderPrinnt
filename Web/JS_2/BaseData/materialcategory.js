///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>
$(function () {
    //******物料类别表*********
    $("#dg_materialcategory").treegrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialcategory',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        idField: "ID",
        treeField: 'CategoryName',
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    });
    //设置分页控件       
    var p = $('#dg_materialcategory').treegrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });
});
//查询物料类别
function searchMaterialCategory() {
    var tbx_search_category = $("#tbx_search_category").val();
    $('#dg_materialcategory').treegrid('load', {
        CategoryName: tbx_search_category
    });
}
//添加物料类别
function addMaterialCategory() {
    var CategoryName = $("#txt_CategoryName").val();
    if ($.trim(CategoryName) == "") {
        alert("类别名称不能为空！");
        $("#txt_CategoryName").focus();
        return;
    }
    var ParentName = $("#txt_ParentName").val();

    $.post(
    "/Service/BaseDataService_2/AddService.ashx",
    { opr: "MaterialCategory", CategoryName: CategoryName, ParentName: ParentName },
    function (data) {
        if (data.d == 1) {
            $('#dg_materialcategory').treegrid('reload');
            $('#dlg_MaterialCategory_add').dialog('close');
            $("#txt_CategoryName").val("");
            $("#txt_ParentName").val("");
            alert("添加成功!");
        } else {
            alert(data.msg);
        }
    }
);
}
//打开编辑物料窗体
function openEditMaterialCategory() {
    var row = $('#dg_materialcategory').treegrid('getSelected');
    $("#txt_CategoryName_edit").val(row.CategoryName);
    $("#txt_ParentName_edit").val(row.ParentName);
    //打开窗体
    $("#dlg_MaterialCategory_edit").dialog("open");
}
//编辑物料类别
function editMaterialCategory() {
    var CategoryName = $("#txt_CategoryName_edit").val();
    if ($.trim(CategoryName) == "") {
        alert("类别名称不能为空！");
        $("#txt_CategoryName").focus();
        return;
    }
    var ParentName = $("#txt_ParentName_edit").val();
    var id = $('#dg_materialcategory').treegrid('getSelected').ID;
    $.post(
    "/Service/BaseDataService_2/EditService.ashx",
    { opr: "MaterialCategory", ID: id, CategoryName: CategoryName, ParentName: ParentName },
    function (data) {
        if (data.d == 1) {
            $('#dg_materialcategory').treegrid('reload');
            $('#dlg_MaterialCategory_edit').dialog('close');
            alert("编辑成功!");
        } else {
            alert(data.msg);
        }
    }
   );
}
//删除仓库
function deleteMaterialCategory() {
    var row = $('#dg_materialcategory').treegrid('getSelected');
    if (confirm("确定删除【" + row.CategoryName + "】吗？")) {
        $.post(
            "/Service/BaseDataService_2/DeleteService.ashx",
            { opr: "materialcategory", ID: row.ID },
            function (data) {
                if (data.d == 1) {        
                    $('#dg_materialcategory').treegrid('reload');
                    alert("删除成功!");
                }
            }
      );
    }
}
//物料类别 编辑、删除
function formatMaterialCategory(val, row, index) {
    return '<a href="javascript:openEditMaterialCategory()">编辑</a> <a href="javascript:deleteMaterialCategory()">删除</a>';
}