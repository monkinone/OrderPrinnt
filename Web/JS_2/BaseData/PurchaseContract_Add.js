
$(function () {
    var orderid = getQueryString("orderid");
    //orderid = 'CG2015-10-12-1';
    $("#dgcginfo").datagrid({
        url: '/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getOrderlist&orderid=' + orderid,
        singleSelect: true,
        rownumbers: true
    })
    $("#htinfo").datagrid({
        singleSelect: true,
        rownumbers: true
    })
    //获取供应商数据
    $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getSuppliersList",
        function (data) {
            if (data)
                getSuppliersdata(data);
        })
})
//获取供应商id
function getSuppliersdata(data) {
    $('#se_SuppliersID').combobox({
        data: data,
        editable: true,
        valueField: 'ID',
        textField: 'ID',
        onChange: selectChangeid
    });
    $('#se_SuppliersName').combobox({
        data: data,
        editable: true,
        textField: 'CompanyName',
        valueField: 'ID',
        onChange: selectChangename
    });
}

//下拉选中事件
function selectChangeid(newValue, oldValue) {
    if (newValue) {
        $('#se_SuppliersName').combobox("select", newValue);
        getHTid(newValue);
    }
}
function selectChangename(newValue, oldValue) {
    if (newValue) {
        $('#se_SuppliersID').combobox("select", newValue);
        getHTid(newValue);
    }
}
//获取合同id
function getHTid(Suppliersid) {
    $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getID", {
        Suppliersid: Suppliersid
    }, function (data) {
        if (data)
            $("#htid").html((data).id);
    })
}

//


//添加到合同
function Addhetong() {
    var supplier = $("#se_SuppliersID").combobox("getValue");
    var HTid = $("#htid").text();
    if (supplier && HTid) {
        var rowdata = $("#dgcginfo").datagrid("getSelected");
        if (rowdata.ModelNumber) {
            $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=searchPrice", {
                SuppliersID: supplier, ModelNumber: rowdata.ModelNumber
            }, function (data) {
                if (data && data.length > 0) {
                    rowdata.UnitPrice = data[0];
                    rowdata.ContractID = HTid;
                    $('#se_SuppliersName').combobox("disable");
                    $('#se_SuppliersID').combobox("disable");
                    $("#htinfo").datagrid("appendRow", rowdata);
                    $("#dgcginfo").datagrid("deleteRow", $("#dgcginfo").datagrid("getRowIndex", rowdata));
                } else {
                    $.messager.alert("提示", "该供应商没有此物料单价！");
                }
            })
        }
    } else {
        $.messager.alert("提示", "请选择供应商！");
    }
}

//添加合同信息
function AddHT() {
    var GoodsMethods = $("input[name='GoodsMethods']:checked").val();
    var SuppliersID = $("#se_SuppliersID").combobox("getValue");
    var CompanyName = $("#se_SuppliersName").combobox("getText");
    var HTid = $("#htid").text();
    var Items = $("#htinfo").datagrid("getRows");
    if (GoodsMethods && SuppliersID && CompanyName && HTid && Items && Items.length > 0) {
        $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=addPurchaseContract", {
            GoodsMethods: GoodsMethods,
            SuppliersID: SuppliersID,
            CompanyName: CompanyName,
            Items: JSON.stringify(Items)
        }, function (data) {
            if (data && data.d > 0) {
                $.messager.alert("提示", "合同添加成功！");
                location.reload();
            } else {
                $.messager.alert("提示", "添加失败！");
            }
        })
    }

}

function formatop(val, row, index) {
    return '<a class="red" href="javascript:Addhetong()">添加到合同信息</a> ';
}

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

