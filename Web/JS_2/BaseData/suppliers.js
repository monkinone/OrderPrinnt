$(function () {
    $("#dg_suppliers").datagrid({
        url: '/Service/BaseDataService_2/SuppliersManage.ashx?opr=list',
        loadMsg: "正在加载，请稍等...",
        pageSize: 20,
        rownumbers: true,//行号    
        singleSelect: true,//是否单选
        pagination: true//分页控件 
    })
    $('#tbx_supplier_user').combobox({
        //url: '/Service/BaseDataService_2/SuppliersManage.ashx?opr=list',
        method: 'post',
        valueField: 'userId',
        textField: 'trueName',
    })

});
//设置分页控件       
var p = $('#dg_suppliers').datagrid('getPager');
$(p).pagination({
    pageSize: 20,//每页显示的记录条数，默认为10           
    pageList: [20, 30, 50],//可以设置每页记录条数的列表           
    beforePageText: '第',//页数文本框前显示的汉字           
    afterPageText: '页    共 {pages} 页',
    displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
});

//查找供应商
function searchSuppliers() {
    var tbx_search_companyName = $("#tbx_search_companyName").val();

    $('#dg_suppliers').datagrid('load', {
        SuppliersName: tbx_search_companyName
    });

}
//打开添加窗口
function openadddialog() {
    $("#dlg_supplier_add").dialog({
        title: '添加供应商'
    });
    $("#gyxaddid").show();
    $("#gyxeditid").hide();
    $.post('/Service/BaseDataService_2/SuppliersManage.ashx?opr=getuserlist', function (data) {
        if (data) {
            $('#tbx_supplier_user').combobox('loadData', data);
            $('#dlg_supplier_add').prop('opertype', 'add');//标识对话框为添加
            $('#dlg_supplier_add').dialog('open');
        }
    })
}

//添加供应商
function addSuppliers() {

    var tbx_supplier_user = $("#tbx_supplier_user").combobox('getValue');//供应商用户
    var tbx_companyName = $("#tbx_companyName").val();//供应商名称       

    if (!tbx_companyName) {
        alert("*号内容为必填或必选项！");
        $("#tbx_supplier_user").focus();
        return;
    }
    var tbx_ContactMan = $("#tbx_ContactMan").val();
    var tbx_Position = $("#tbx_Position").val();
    var tbx_Telephone = $("#tbx_Telephone").val();
    var tbx_MobilePhone = $("#tbx_MobilePhone").val();
    var tbx_Fax = $("#tbx_Fax").val();
    var tbx_InvoiceFa = $("#tbx_InvoiceFa").val();
    var tbx_Payment = $("#tbx_Payment").val();
    var radio_IsContractModel = $("#dlg_supplier_add input[name=radio_IsContractModel]:checked").val();
    var tbx_BankAccount = $("#tbx_BankAccount").val();
    var tbx_BankName = $("#tbx_BankName").val();
    var tbx_TaxpayerNumber = $("#tbx_TaxpayerNumber").val();
    var tbx_CompanyAdress = $("#tbx_CompanyAdress").val();
    var tbx_ContactManDetailInfo = $("#tbx_ContactManDetailInfo").val();
    var tbx_OtherContactMan = $("#tbx_OtherContactMan").val();
    var ID = $("#gyxeditid").html();

    var opr = $('#dlg_supplier_add').prop('opertype')
    $.post(
        "/Service/BaseDataService_2/SuppliersManage.ashx",
        {
            opr: opr,
            ID: ID,
            LoginUserID: tbx_supplier_user, MobilePhone: tbx_MobilePhone,
            CompanyName: tbx_companyName, Position: tbx_Position, ContactMan: tbx_ContactMan,
            Telephone: tbx_Telephone, Fax: tbx_Fax, InvoiceFa: tbx_InvoiceFa,
            Payment: tbx_Payment, IsContractModel: radio_IsContractModel,
            BankAccount: tbx_BankAccount, BankName: tbx_BankName,
            TaxpayerNumber: tbx_TaxpayerNumber, CompanyAdress: tbx_CompanyAdress,
            OtherContactMan: tbx_OtherContactMan, ContactManDetailInfo: tbx_ContactManDetailInfo
        },
        function (data) {
            if (data.d == 1) {
                adddialoginit();
                $('#dg_suppliers').datagrid('reload');
                alert("操作成功!");
            } else if (data.d == 111) {
                alert("此名称已存在!");
            }
            else {
                alert("操作失败!");
            }
        }
  );
}
//初始化add对话框
function adddialoginit() {
    $('#dlg_supplier_add').dialog('close');
    $('#dlg_supplier_add input[type=text]').val('');
    $('#dlg_supplier_add textarea').text('');      
}


//编辑
function openEditSuppliers() {
    $("#dlg_supplier_add").dialog({
        title: '编辑供应商'
    });
    $('#dlg_supplier_add').prop('opertype', 'edit');//标识对话框为编辑
    $("#gyxaddid").hide();
    $("#gyxeditid").show();
    $.post('/Service/BaseDataService_2/SuppliersManage.ashx?opr=getuserlist', function (data) {
        if (data) {
            $('#tbx_supplier_user').combobox('loadData', data);

            var row = $('#dg_suppliers').datagrid('getSelected');
            $("#gyxeditid").html(row.ID);
            //将信息补充到窗体中
            $("#tbx_supplier_user").combobox('select', row.LoginUserID);//供应商用户
            $("#tbx_companyName").val(row.CompanyName);//供应商名称  
            $("#tbx_ContactMan").val(row.ContactMan);
            $("#tbx_Position").val(row.Position);
            $("#tbx_Telephone").val(row.Telephone);
            $("#tbx_MobilePhone").val(row.MobilePhone);
            $("#tbx_Fax").val(row.Fax);
            $("#tbx_InvoiceFa").val(row.InvoiceFa);
            $("#tbx_Payment").val(row.Payment);
            //$(".inpu_bg[name=radio_IsContractModel]").attr('checked', false);

            $("#radio_default" + row.IsContractModel).attr('checked', 'checked').siblings("input:radio").attr('checked', false);


            //$([value=" +  + "]").prop('checked', true);
            $("#tbx_BankAccount").val(row.BankAccount);
            $("#tbx_BankName").val(row.BankName);
            $("#tbx_TaxpayerNumber").val(row.TaxpayerNumber);
            $("#tbx_CompanyAdress").val(row.CompanyAdress);
            $("#tbx_ContactManDetailInfo").val(row.ContactManDetailInfo);
            $("#tbx_OtherContactMan").val(row.OtherContactMan);


            $('#dlg_supplier_add').dialog('open');
        }
    })
}
//删除
function deleteSuppliers() {
    var row = $('#dg_suppliers').datagrid('getSelected');
    if (confirm("确定删除【" + row.CompanyName + "】供应商吗？")) {
        $.post(
            "/Service/BaseDataService_2/SuppliersManage.ashx",
            { opr: "del", ID: row.ID },
            function (data) {
                if (data.d == 1) {
                    $('#dg_suppliers').datagrid('reload');
                    alert("删除成功!");
                } else {
                    alert("删除失败!");
                }
            }
      );
    }
}
//详情页面
function openInfoSuppliers() {
    var row = $('#dg_suppliers').datagrid('getSelected');
    $("#gyxid").html(row.ID);
    //将信息补充到窗体中
    $("#tbx_supplier_user_info").val(row.trueName);//供应商用户
    $("#tbx_companyName_info").val(row.CompanyName);//供应商名称  
    $("#tbx_ContactMan_info").val(row.ContactMan);
    $("#tbx_Position_info").val(row.Position);
    $("#tbx_Telephone_info").val(row.Telephone);
    $("#tbx_MobilePhone_info").val(row.MobilePhone);
    $("#tbx_Fax_info").val(row.Fax);
    $("#tbx_InvoiceFa_info").val(row.InvoiceFa);
    $("#tbx_Payment_info").val(row.Payment);
    $("#radio_default_info" + row.IsContractModel).attr('checked', 'checked').siblings("input:radio").attr('checked', false);
    $("#tbx_BankAccount_info").val(row.BankAccount);
    $("#tbx_BankName_info").val(row.BankName);
    $("#tbx_TaxpayerNumber_info").val(row.TaxpayerNumber);
    $("#tbx_CompanyAdress_info").val(row.CompanyAdress);
    $("#tbx_ContactManDetailInfo_info").val(row.ContactManDetailInfo);
    $("#tbx_OtherContactMan_info").val(row.OtherContactMan);


    $('#dlg_supplier_info').dialog('open');
}



//编辑删除按钮
function formatOperSuppliers(val, row, index) {
    return '<a href="javascript:openInfoSuppliers()">详情</a> <a href="javascript:openEditSuppliers()">编辑</a> <a href="javascript:deleteSuppliers()">删除</a>';
}


