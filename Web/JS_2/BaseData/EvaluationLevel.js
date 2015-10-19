$(function () {
    $("#dg_EvaluationLevel").datagrid({
        url: '/Service/BaseDataService_2/EvaluationLevelManager.ashx?opr=Levellist',
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
    getComboboxdata(function (SuppliersList) {
        $('#tbx_search_SuppliersID').combobox('loadData', SuppliersList);
    })
    $('#tbx_SuppliersID').combobox({
        method: 'post',
        valueField: 'ID',
        textField: 'CompanyName',
    });
});

//设置分页控件       
var p = $('#dg_EvaluationLevel').datagrid('getPager');
$(p).pagination({
    pageSize: 20,//每页显示的记录条数，默认为10           
    pageList: [20, 30, 50],//可以设置每页记录条数的列表           
    beforePageText: '第',//页数文本框前显示的汉字           
    afterPageText: '页    共 {pages} 页',
    displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
});
//查找单价列表
function searchEvaluationLevel() {
    var tbx_search_SuppliersID = $("#tbx_search_SuppliersID").combobox('getValue');
    $('#dg_EvaluationLevel').datagrid('load', {
        SuppliersID: tbx_search_SuppliersID
    });

}
//打开添加窗口
function openEvaluationLeveldialog() {
    $("#dlg_EvaluationLevel").dialog({
        title: '添加'
    });
    $('#tbx_SuppliersID').combobox("enable");

    getComboboxdata(function (SuppliersList) {
        $('#tbx_SuppliersID').combobox('loadData', SuppliersList);
        $('#dlg_EvaluationLevel').prop('opertype', 'add');//标识对话框为添加
        $('#dlg_EvaluationLevel').dialog('open');
    })
}

//获取供应商列表和物料列表
function getComboboxdata(callback) {
    $.post('/Service/BaseDataService_2/MaterialPriceManage.ashx?opr=getSuppliersList', function (SuppliersList) {
        if (SuppliersList) {
            callback(SuppliersList);
        }
    })
}


//添加供应商单价
function addMaterialPrice() {
    var tbx_SuppliersID = $("#tbx_SuppliersID").combobox('getValue');//供应商编号
    var tbx_SuppliersID_text = $("#tbx_SuppliersID").combobox('getText');//供应商名称
    var tbx_Level = $("#tbx_Level").val();
    if (!(tbx_SuppliersID && tbx_SuppliersID_text && tbx_Level)) {
        alert("*号内容为必填或必选项！");
        $("#tbx_SuppliersID").focus();
        return;
    }
    var tbx_Remark = $("#tbx_Remark").val();
    var ID = $("#dlgID").val();
    var oprtype = $('#dlg_EvaluationLevel').prop('opertype');
    var opr = oprtype == 'add' ? "addLevel" : "editLevel";
    $.post(
        "/Service/BaseDataService_2/EvaluationLevelManager.ashx",
        {
            opr: opr,
            ID: ID,
            SuppliersID: tbx_SuppliersID,
            CompanyName: tbx_SuppliersID_text,
            Level: tbx_Level,
            Remark: tbx_Remark
        },
        function (data) {
            if (data.d == 1) {
                adddialoginit();
                $('#dg_EvaluationLevel').datagrid('reload');
                alert("操作成功!");
            } else if (data.d === 111) {
                alert("此供应商评级信息已存在！");
            } else {
                alert("操作失败!");
            }
        }
  );
}
//初始化add对话框
function adddialoginit() {
    $("#dlg_EvaluationLevel").dialog('close')
    $("#tbx_Remark").val('');
    $("#tbx_Level").val('');
    $("#tbx_SuppliersID").combobox('select', '');//供应商用户 
}


//编辑
function openEditEvaluationLevel() {

    getComboboxdata(function (SuppliersList) {
        $('#tbx_SuppliersID').combobox('loadData', SuppliersList);
        $('#tbx_SuppliersID').combobox("disable");
        $("#dlg_EvaluationLevel").dialog({
            title: '编辑'
        });

        $('#dlg_EvaluationLevel').prop('opertype', 'edit');//标识对话框为编辑
        var row = $('#dg_EvaluationLevel').datagrid('getSelected');
        $("#dlgID").val(row.ID);
        //将信息补充到窗体中
        $("#tbx_SuppliersID").combobox('select', row.SuppliersID);//供应商用户
        $("#tbx_Level").val(row.Level);
        $("#tbx_Remark").val(row.Remark);
        $('#dlg_EvaluationLevel').dialog('open');
    })
}
//删除
function deleteEvaluationLevel() {
    var row = $('#dg_EvaluationLevel').datagrid('getSelected');
    if (confirm("确定删除【" + row.CompanyName + "】等级信息吗？")) {
        $.post(
            "/Service/BaseDataService_2/EvaluationLevelManager.ashx",
            { opr: "delLevel", ID: row.ID },
            function (data) {
                if (data.d == 1) {
                    $('#dg_EvaluationLevel').datagrid('reload');
                    alert("删除成功!");
                } else {
                    alert("删除失败!");
                }
            }
      );
    }
}
//查看详情
function openInfoEvaluationLevel() {

    var row = $('#dg_EvaluationLevel').datagrid('getSelected');
    $("#dlgID").val(row.ID);
    //将信息补充到窗体中
    //$("#tbx_SuppliersID_info").val(row.SuppliersID);//供应商用户
    //$("#tbx_Level_info").val(row.Level);
    //$("#tbx_Remark_info").val(row.Remark);
    var content = "";
    $.post("/Service/BaseDataService_2/EvaluationLevelManager.ashx", {
        opr: "getLevelRecord", SuppliersID: row.SuppliersID
    }, function (data) {
        if (data.length > 0) {
            for (var i in data) {
                var obj = data[i];
                content += "记录：" + obj.DoContent + "    操作时间：" + obj.DoTime + "<br/>";
            }
            $("#dlginfo .sear_list").html(content);
        } else {
            $("#dlginfo .sear_list").html("最近没有记录");
        }
        $('#dlginfo').dialog('open');
    })

}


//编辑删除按钮
function formatOperEvaluationLevel(val, row, index) {
    return '<a href="javascript:openInfoEvaluationLevel()">详情</a>  ' +
        '<a href="javascript:openEditEvaluationLevel()">编辑</a>   <a href="javascript:deleteEvaluationLevel()">删除</a>';
}


