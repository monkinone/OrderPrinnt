$(function () {
    $("#dg_SuppliersUser").datagrid({
        url: '/Service/BaseDataService_2/SuppliersUserManager.ashx?opr=getlist',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    })
  
});
  //设置分页控件       
    var p = $('#dg_SuppliersUser').datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为10           
        pageList: [20, 30, 50],//可以设置每页记录条数的列表           
        beforePageText: '第',//页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });

//查找
//function searchMaterialPrice() {
//    var tbx_search_SuppliersID = $("#tbx_search_SuppliersID").combobox('getValue');
//    var tbx_search_ModelNumber = $("#tbx_search_ModelNumber").combobox('getValue');
//    $('#dlg_SuppliersUser').datagrid('load', {
//        SuppliersID: tbx_search_SuppliersID,
//        ModelNumber: tbx_search_ModelNumber
//    });

//}
//打开添加窗口
function openSuppliersUserdialog() {
    $("#dlg_SuppliersUser").dialog({
        title: '添加用户'
    });
    adddialoginit();
    $('#dlg_SuppliersUser').prop('opertype', 'add');//标识对话框为添加
    $('#dlg_SuppliersUser').dialog('open');

}

//添加供应商单价
function addSuppliersUser() {
    var txt_userName = $("#txt_userName").val();//
    var txt_userPass = $("#txt_userPass").val() || $("#txt_check_userPass").val();//
    var tbx_trueName = $("#tbx_trueName").val();// 
    var txt_phone = $("#txt_phone").val();//

    if (!(txt_userName && txt_userPass)) {
        alert("*号内容为必填项！");
        $("#txt_userName").focus();
        return;
    }
    var tbx_Remark = $("#tbx_Remark").val();
    var ID = $("#dlgID").val();
    var oprtype = $('#dlg_SuppliersUser').prop('opertype');
    var opr = oprtype == 'add' ? "addUser" : "editUser";
    $.post(
        "/Service/BaseDataService_2/SuppliersUserManager.ashx",
        {
            opr: opr,
            userId: ID,
            userName: txt_userName,
            userPass: txt_userPass,
            trueName: tbx_trueName,
            phone: txt_phone
        },
        function (data) {
            if (data.d == 1 || data.d == 0) {
                adddialoginit();
                $('#dg_SuppliersUser').datagrid('reload');
                alert("操作成功!");
            } else if (data.d == 111) {
                alert("此登录帐号已存在!");
            } else {
                alert("操作失败!");
            }
        }
  );
}


//初始化add对话框
function adddialoginit() {
    $("#dlg_SuppliersUser").dialog('close')
    $("#dlg_SuppliersUser input[type=text]").val("");
    $("#dlgID").val('');
}


//编辑
function openEditSuppliersUser() {

    $("#dlg_SuppliersUser").dialog({
        title: '编辑用户'
    });
    $('#dlg_SuppliersUser').prop('opertype', 'edit');//标识对话框为编辑
    var row = $('#dg_SuppliersUser').datagrid('getSelected');
    $("#dlgID").val(row.userId);
    //将信息补充到窗体中
    $("#txt_userName").val(row.userName);//
    $("#txt_userPass").val(row.userPass);
    $("#tbx_trueName").val(row.trueName);// 
    $("#txt_phone").val(row.phone);//
    $('#dlg_SuppliersUser').dialog('open');

}
//删除
function deleteSuppliersUser() {
    var row = $('#dg_SuppliersUser').datagrid('getSelected');
    if (confirm("确定删除【用户 " + row.userName + "】吗？，本次操作会影响相关联的供应商数据")) {
        $.post(
            "/Service/BaseDataService_2/SuppliersUserManager.ashx",
            { opr: "delUser", userId: row.userId },
            function (data) {
                if (data.d == 1) {
                    $('#dg_SuppliersUser').datagrid('reload');
                    alert("删除成功!");
                } else {
                    alert("删除失败!");
                }
            }
      );
    }
}

//详情对话框
function openInfoSuppliersUser() {
    $('#dlg_SuppliersUser_info input').val('');
    var row = $('#dg_SuppliersUser').datagrid('getSelected');
    $("#txt_userName_info").val(row.userName);//
    $("#txt_userPass_info").val(row.userPass);
    $("#tbx_trueName_info").val(row.trueName);// 
    $("#txt_phone_info").val(row.phone);//
    $('#dlg_SuppliersUser_info').dialog('open');
}



//编辑删除按钮
function formatOperSuppliersUser(val, row, index) {
    return '<a href="javascript:openInfoSuppliersUser()">详情</a> <a href="javascript:openEditSuppliersUser()">编辑</a> <a href="javascript:deleteSuppliersUser()">删除</a>';
}


