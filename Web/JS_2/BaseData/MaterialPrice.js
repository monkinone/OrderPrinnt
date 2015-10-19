$(function () {
    $("#dg_MaterialPrice").datagrid({
        url: '/Service/BaseDataService_2/MaterialPriceManage.ashx?opr=getMaterialPriceList',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    })
    $('#tbx_search_SuppliersID').combobox({
        method: 'post',
        valueField: 'ID',
        textField: 'CompanyName',
    });

    $('#tbx_search_ModelNumber').combobox({
        method: 'post',
        valueField: 'ModelNumber',
        textField: 'MaterialName',
    });
    getComboboxdata(function (SuppliersList, MaterialList) {
        $('#tbx_search_SuppliersID').combobox('loadData', SuppliersList);
        $('#tbx_search_ModelNumber').combobox('loadData', MaterialList);
    })
    $('#tbx_SuppliersID').combobox({
        method: 'post',
        valueField: 'ID',
        textField: 'CompanyName',
    });

    $('#tbx_ModelNumber').combobox({
        method: 'post',
        valueField: 'ModelNumber',
        textField: 'MaterialName',
    });



});

//设置分页控件       
var p = $('#dg_MaterialPrice').datagrid('getPager');
$(p).pagination({
    pageSize: 20,//每页显示的记录条数，默认为10           
    pageList: [20, 30, 50],//可以设置每页记录条数的列表           
    beforePageText: '第',//页数文本框前显示的汉字           
    afterPageText: '页    共 {pages} 页',
    displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
});
//查找单价列表
function searchMaterialPrice() {
    var tbx_search_SuppliersID = $("#tbx_search_SuppliersID").combobox('getValue');
    var tbx_search_ModelNumber = $("#tbx_search_ModelNumber").combobox('getValue');
    $('#dg_MaterialPrice').datagrid('load', {
        SuppliersID: tbx_search_SuppliersID,
        ModelNumber: tbx_search_ModelNumber
    });

}
//打开添加窗口
function openMaterialPricedialog() {
    $("#dlg_MaterialPrice").dialog({
        title: '添加单价'
    });
    $('#tbx_SuppliersID').combobox('enable');
    $('#tbx_ModelNumber').combobox('enable');
    getComboboxdata(function (SuppliersList, MaterialList) {
        $('#tbx_SuppliersID').combobox('loadData', SuppliersList);
        $('#tbx_ModelNumber').combobox('loadData', MaterialList);
        $('#dlg_MaterialPrice').prop('opertype', 'add');//标识对话框为添加
        $('#dlg_MaterialPrice').dialog('open');
    })
}

//获取供应商列表和物料列表
function getComboboxdata(callback) {
    $.post('/Service/BaseDataService_2/MaterialPriceManage.ashx?opr=getSuppliersList', function (SuppliersList) {
        if (SuppliersList) {
            $.post('/Service/BaseDataService_2/MaterialPriceManage.ashx?opr=getMaterialList', function (MaterialList) {
                if (MaterialList) {
                    callback(SuppliersList, MaterialList);
                }
            })
        }
    })
}


//添加供应商单价
function addMaterialPrice() {
    var tbx_SuppliersID = $("#tbx_SuppliersID").combobox('getValue');//供应商编号
    var tbx_SuppliersID_text = $("#tbx_SuppliersID").combobox('getText');//供应商名称
    var tbx_ModelNumber = $("#tbx_ModelNumber").combobox('getValue');//物料类型     
    var tbx_ModelNumber_text = $("#tbx_ModelNumber").combobox('getText');//物料名称
    var tbx_UnitPrice = $("#tbx_UnitPrice").val();
    if (!(tbx_SuppliersID && tbx_SuppliersID_text && tbx_ModelNumber && tbx_ModelNumber_text && tbx_UnitPrice)) {
        alert("*号内容为必填或必选项！");
        $("#tbx_SuppliersID").focus();
        return;
    }
    var tbx_Remark = $("#tbx_Remark").val();
    var ID = $("#dlgID").val();
    var oprtype = $('#dlg_MaterialPrice').prop('opertype');
    var opr = oprtype == 'add' ? "addMaterialPrice" : "editMaterialPrice";
    $.post(
        "/Service/BaseDataService_2/MaterialPriceManage.ashx",
        {
            opr: opr,
            ID: ID,
            SuppliersID: tbx_SuppliersID,
            CompanyName: tbx_SuppliersID_text,
            ModelNumber: tbx_ModelNumber,
            MaterialName: tbx_ModelNumber_text,
            UnitPrice: tbx_UnitPrice,
            Remark: tbx_Remark
        },
        function (data) {
            if (data.d == 1) {
                adddialoginit();
                $('#dg_MaterialPrice').datagrid('reload');
                alert("操作成功!");
            } else if (data.d == 111) {
                alert("此单价记录已存在！");
            } else {
                alert("操作失败!");
            }
        }
  );
}
//初始化add对话框
function adddialoginit() {
    $("#dlg_MaterialPrice").dialog('close')
    $("#tbx_Remark").val('');
    $("#tbx_UnitPrice").val('');
    $("#tbx_SuppliersID").combobox('select', '');//供应商用户
    $("#tbx_ModelNumber").combobox('select', '');//物料
}


//编辑
function openEditMaterialPrice() {
    getComboboxdata(function (SuppliersList, MaterialList) {
        $('#tbx_SuppliersID').combobox('loadData', SuppliersList);
        $('#tbx_ModelNumber').combobox('loadData', MaterialList);
        $('#tbx_SuppliersID').combobox('disable');
        $('#tbx_ModelNumber').combobox('disable');
        $("#dlg_MaterialPrice").dialog({
            title: '编辑单价'
        });
        $('#dlg_MaterialPrice').prop('opertype', 'edit');//标识对话框为编辑
        var row = $('#dg_MaterialPrice').datagrid('getSelected');
        $("#dlgID").val(row.ID);
        //将信息补充到窗体中
        $("#tbx_SuppliersID").combobox('select', row.SuppliersID);//供应商用户
        $("#tbx_ModelNumber").combobox('select', row.ModelNumber);//物料
        $("#tbx_UnitPrice").val(row.UnitPrice);
        $("#tbx_Remark").val(row.Remark);
        $('#dlg_MaterialPrice').dialog('open');
    })
}
//删除
function deleteMaterialPrice() {
    var row = $('#dg_MaterialPrice').datagrid('getSelected');
    if (confirm("确定删除【" + row.CompanyName + "的物料" + row.MaterialName + "】单价记录吗？")) {
        $.post(
            "/Service/BaseDataService_2/MaterialPriceManage.ashx",
            { opr: "delMaterialPrice", ID: row.ID },
            function (data) {
                if (data.d == 1) {
                    $('#dg_MaterialPrice').datagrid('reload');
                    alert("删除成功!");
                } else {
                    alert("删除失败!");
                }
            }
      );
    }
}
function openInfoMaterialPrice()
{
    var row = $('#dg_MaterialPrice').datagrid('getSelected');
    var content = "";
    $.post("/Service/BaseDataService_2/MaterialPriceManage.ashx", {
        opr: "getPriceRecord", ModelNumber: row.ModelNumber
    }, function (data) {
        if (data.length > 0) {
            for (var i in data) {
                var obj = data[i];
                content += "记录：" + obj.DoContent + "    操作时间：" + obj.DoTime + "<br/>";
            }
            $("#dlg_info .sear_list").html(content);
        } else {
            $("#dlg_info .sear_list").html("最近没有记录");
        }
        $('#dlg_info').dialog('open');
    })
}


//编辑删除按钮
function formatOperMaterialPrice(val, row, index) {
    return '<a href="javascript:openInfoMaterialPrice()">详情</a> <a href="javascript:openEditMaterialPrice()">编辑</a> <a href="javascript:deleteMaterialPrice()">删除</a>';
}


