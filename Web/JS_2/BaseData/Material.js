///<reference path="/themes/jquery-easyui-1.4.1/jquery.min.js"/>
$(function () {
    //*****物料信息******
    $("#dg_Material").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=Material',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
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

    //物料类别
    $("#tbx_edit_category").combotree({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialcategory_combotree'
    });
});
//查询物料信息
function searchMaterial() {
    var tbx_search_materialName = $("#tbx_search_materialName").val();
    var tbx_search_modelNumber = $("#tbx_search_modelNumber").val();
    var tbx_categoryName = $("#tbx_categoryName").val();
    $('#dg_Material').datagrid('load', {
        MaterialName: tbx_search_materialName,
        ModelNumber: tbx_search_modelNumber,
        CategoryName: tbx_categoryName,
    });
}
//打开添加物料信息窗体
function openDialogAdd() {
    $('#dlg_material_add').dialog('open');
    //清空数据
    $("#tbx_modelNumber").val("");
    $("#tbx_marterialName").val("");
    $("#tbx_status").attr("checked",false);
    $("#tbx_upperLimit").val("");
    $("#tbx_lowerLimit").val("");
    $("#tbx_technicalParameter").val("");
    //清理库存表
    try {
        var rows = $("#dg_KuCun").datagrid("getRows");
        if (rows.length > 0) {
            var len = rows.length;
            for (var i = 0; i < len; i++) {
                $("#dg_KuCun").datagrid("deleteRow", i);
            }
        }
    }
    catch (e) {
    }
    //物料类别
    $("#tbx_category").combotree({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialcategory_combotree',
        onSelect: function (node) {
            var lastIndex;
            $("#dg_KuCun").datagrid({
                url: '/Service/BaseDataService_2/SearchService.ashx?opr=Warehouse_Grid&CategoryName=' + node.text,
                loadMsg: "正在加载...",
                onClickRow: function (rowIndex) {
                    if (lastIndex != rowIndex) {
                        $('#dg_KuCun').datagrid('endEdit', lastIndex);
                        $('#dg_KuCun').datagrid('beginEdit', rowIndex);
                       
                    }
                    lastIndex = rowIndex;
               }
            });
        }
    });
    //物料属性
    $("#tbx_attributeName").combobox({   
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialattribute_combobox',
         valueField:'ID',   
         textField: 'AttributeName',
         editable:false
     });  
    //计量单位
    $("#tbx_unit").combobox({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=unit_combobox',
        valueField: 'ID',
        textField: 'UnitName',
        editable: false
    });
}
//添加物料信息
function addMaterial() {
    var tbx_modelNumber = $("#tbx_modelNumber").val();
    if ($.trim(tbx_modelNumber) == "") {
        alert("物料型号不能为空！");
        $("#tbx_modelNumber").focus();
        return;
    }
    var tbx_marterialName = $("#tbx_marterialName").val();
    if ($.trim(tbx_marterialName) == "") {
        alert("物料名称不能为空！");
        $("#tbx_marterialName").focus();
        return;
    }
    var tbx_category = $("#tbx_category").combotree('getText');
    if ($.trim(tbx_category) == "") {
        alert("物料类别不能为空！");
        return;
    }
    var tbx_attributeName = $("#tbx_attributeName").combobox('getText');
    if ($.trim(tbx_attributeName) == "") {
        alert("物料属性不能为空！");
        return;
    }
    var tbx_unit = $("#tbx_unit").combobox('getText');
    if ($.trim(tbx_unit) == "") {
        alert("计量单位不能为空！");
        return;
    }
    var tbx_upperLimit = $("#tbx_upperLimit").val();
    if ($.trim(tbx_modelNumber) == "") {
        alert("库存上限不能为空！");
        $("#tbx_upperLimit").focus();
        return;
    } else {
        var reg = /^[1-9]\d*$/;
        if (!reg.test(tbx_upperLimit)) {
            alert("库存上限只能为正整数！");
            $("#tbx_upperLimit").focus();
            return;
        }
    }
    var tbx_lowerLimit = $("#tbx_lowerLimit").val();
    if ($.trim(tbx_lowerLimit) == "") {
        alert("库存下限不能为空！");
        $("#tbx_lowerLimit").focus();
        return;
    } else {
        var reg = /^[1-9]\d*$/;
        if (!reg.test(tbx_lowerLimit)) {
            alert("库存下限只能为正整数！");
            $("#tbx_lowerLimit").focus();
            return;
        }
    }

    //结束编辑表格
    endEditGrid("#dg_KuCun");

    $.post(
     "/Service/BaseDataService_2/AddService.ashx",
     {
         opr: "Material",
         MaterialName: tbx_marterialName,
         ModelNumber: tbx_modelNumber,
         CategoryID: $("#tbx_category").combotree('getValue'),
         CategoryName: tbx_category,
         AttributeID: $("#tbx_attributeName").combotree('getValue'),
         AttributeName: tbx_attributeName,
         UnitID: $("#tbx_unit").combobox('getValue'),
         UnitName: tbx_unit,
         UpperLimit: tbx_upperLimit,
         LowerLimit: tbx_lowerLimit,
         TechnicalParameter: $("#tbx_technicalParameter").val(),
         Status: $("#tbx_status").attr("checked") == true ? 0 : 1,
         Material_WareHouse: JSON.stringify($('#dg_KuCun').datagrid('getRows'))
     },
     function (data) {
         if (data.d == 1) {
             $('#dg_Material').datagrid('reload');
             $('#dlg_material_add').dialog('close');
             alert("保存成功!");
         } else {
             alert(data.msg);
         }
     }
   );
}

//删除物料信息
function deleteMaterial() {
    var row = $('#dg_Material').datagrid('getSelected');
    if (confirm("确定删除物料【" + row.MaterialName + "】吗？")) {
        $.post(
            "/Service/BaseDataService_2/DeleteService.ashx",
            { opr: "Material", ID: row.ID,ModelNumber:row.ModelNumber,MaterialName:row.MaterialName },
            function (data) {
                if (data.d == 1) {
                    $('#dg_Material').datagrid('reload');
                    alert("删除成功!");
                }
            }
      );
    }
}
//结束编辑表
function endEditGrid(id) {
    var rows = $(id).datagrid('getRows');
    for (var i = 0; i < rows.length; i++) {
        $(id).datagrid('endEdit', i);
    }
}
//打开编辑物料信息窗
function openEditMaterial() {
    //打开修改窗体
    $("#dlg_material_edit").dialog('open');
    //物料类别
    $("#tbx_edit_category").combotree({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialcategory_combotree',
        onSelect: function (node) {
            var lastIndex;
            $("#dg_edit_KuCun").datagrid({
                url: '/Service/BaseDataService_2/SearchService.ashx?opr=Warehouse_Grid&CategoryName=' + node.text,
                loadMsg: "正在加载...",
                onClickRow: function (rowIndex) {
                    if (lastIndex != rowIndex) {
                        $('#dg_edit_KuCun').datagrid('endEdit', lastIndex);
                        $('#dg_edit_KuCun').datagrid('beginEdit', rowIndex);
                       
                    }
                    lastIndex = rowIndex;
                }
            });
        }
    });
    //物料属性
    $("#tbx_edit_attributeName").combobox({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=materialattribute_combobox',
        valueField: 'ID',
        textField: 'AttributeName',
        editable: false
    });
    //计量单位
    $("#tbx_edit_unit").combobox({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=unit_combobox',
        valueField: 'ID',
        textField: 'UnitName',
        editable: false
    });

    var row = $('#dg_Material').datagrid('getSelected');
    debugger;
    $("#tbx_edit_modelNumber").val(row.ModelNumber);
    $("#tbx_edit_marterialName").val(row.MaterialName);
    $("#tbx_edit_category").combotree('setValue', row.CategoryID);
    $("#tbx_edit_category").combotree('setText', row.CategoryName);
    $("#tbx_edit_attributeName").combobox('setValue', row.AttributeID);
    $("#tbx_edit_attributeName").combobox('setText', row.AttributeName);
    $("#tbx_edit_unit").combobox('setValue', row.UnitID);
    $("#tbx_edit_unit").combobox('setText', row.UnitName);
    $("#tbx_edit_status").attr("checked", row.Status == 1 ? false : true);
    $("#tbx_edit_upperLimit").val(row.UpperLimit);
    $("#tbx_edit_lowerLimit").val(row.LowerLimit);
    $("#tbx_edit_technicalParameter").val(row.TechnicalParameter);
    var lastIndex1;
    $("#dg_edit_KuCun").datagrid({
        url: '/Service/BaseDataService_2/SearchService.ashx?opr=material_warehouse&ModelNumber=' + row.ModelNumber + "&MaterialName=" + row.MaterialName,
        loadMsg: "正在加载...",
        onClickRow: function (rowIndex) {
            if (lastIndex1 != rowIndex) {
                $('#dg_edit_KuCun').datagrid('endEdit', lastIndex1);
                $('#dg_edit_KuCun').datagrid('beginEdit', rowIndex);
            }
            lastIndex1 = rowIndex;
        }
    });
}
//编辑物料信息
function editMaterial() {
    var tbx_modelNumber = $("#tbx_edit_modelNumber").val();
    if ($.trim(tbx_modelNumber) == "") {
        alert("物料型号不能为空！");
        $("#tbx_edit_modelNumber").focus();
        return;
    }
    var tbx_marterialName = $("#tbx_edit_marterialName").val();
    if ($.trim(tbx_marterialName) == "") {
        alert("物料名称不能为空！");
        $("#tbx_edit_marterialName").focus();
        return;
    }
    var tbx_category = $("#tbx_edit_category").combotree('getText');
    if ($.trim(tbx_category) == "") {
        alert("物料类别不能为空！");
        return;
    }
    var tbx_attributeName = $("#tbx_edit_attributeName").combobox('getText');
    if ($.trim(tbx_attributeName) == "") {
        alert("物料属性不能为空！");
        return;
    }
    var tbx_unit = $("#tbx_edit_unit").combobox('getText');
    if ($.trim(tbx_unit) == "") {
        alert("计量单位不能为空！");
        return;
    }
    var tbx_upperLimit = $("#tbx_edit_upperLimit").val();
    if ($.trim(tbx_modelNumber) == "") {
        alert("库存上限不能为空！");
        $("#tbx_edit_upperLimit").focus();
        return;
    } else {
        var reg = /^[1-9]\d*$/;
        if (!reg.test(tbx_upperLimit)) {
            alert("库存上限只能为正整数！");
            $("#tbx_edit_upperLimit").focus();
            return;
        }
    }
    var tbx_lowerLimit = $("#tbx_edit_lowerLimit").val();
    if ($.trim(tbx_lowerLimit) == "") {
        alert("库存下限不能为空！");
        $("#tbx_edit_lowerLimit").focus();
        return;
    } else {
        var reg = /^[1-9]\d*$/;
        if (!reg.test(tbx_lowerLimit)) {
            alert("库存下限只能为正整数！");
            $("#tbx_edit_lowerLimit").focus();
            return;
        }
    }

    //结束编辑表格
    endEditGrid("#dg_edit_KuCun");
    var row = $('#dg_Material').datagrid('getSelected');
    $.post(
     "/Service/BaseDataService_2/EditService.ashx",
     {
         opr: "Material",
         ID:row.ID,
         MaterialName: tbx_marterialName,
         MaterialName_old:row.MaterialName,
         ModelNumber: tbx_modelNumber,
         ModelNumber_old:row.ModelNumber,
         CategoryID: $("#tbx_edit_category").combotree('getValue'),
         CategoryName: tbx_category,
         AttributeID: $("#tbx_edit_attributeName").combotree('getValue'),
         AttributeName: tbx_attributeName,
         UnitID: $("#tbx_edit_unit").combobox('getValue'),
         UnitName: tbx_unit,
         UpperLimit: tbx_upperLimit,
         LowerLimit: tbx_lowerLimit,
         TechnicalParameter: $("#tbx_edit_technicalParameter").val(),
         Status: $("#tbx_edit_status").attr("checked") == true ? 0 : 1,
         Material_WareHouse: JSON.stringify($('#dg_edit_KuCun').datagrid('getRows'))
     },
     function (data) {
         if (data.d == 1) {
             $('#dg_Material').datagrid('reload');
             $('#dlg_material_edit').dialog('close');
             alert("保存成功!");
         } else {
             alert(data.msg);
         }
     }
   );

}
//物料信息 编辑、删除
function formatOperMaterial(val, row, index) {
    return '<a href="javascript:openEditMaterial();openEditMaterial();">编辑</a> <a href="javascript:deleteMaterial()">删除</a>';
}