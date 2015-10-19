$(function () {
    $.post('/Service/BaseDataService_2/PurchaseOrdersManager.ashx?opr=getOrderId', function (data) {
        if (data) {
            $("#cgorderid").text(data.id);
        }
    })

    $("#dgmaterial").datagrid({
        iconCls: 'icon-edit',
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        url: '/Service/BaseDataService_2/PurchaseOrdersManager.ashx?opr=MaterialList'
    })

})

//选择物料
function checkMaterial() {
    $("#dlgselectMaterial").dialog("open");
}
//对话框 确认
function dlgselectok() {
    var row = $('#dgmaterial').datagrid('getSelected');
    if (row) {
        Materialinfo = {};
        Materialinfo["MaterialName"] = row["MaterialName"];
        Materialinfo["ModelNumber"] = row["ModelNumber"];
        Materialinfo["CategoryName"] = row["CategoryName"];
        Materialinfo["UnitName"] = row["UnitName"];
        Materialinfo["TechnicalParameter"] = row["TechnicalParameter"];
        //$("#btnselect").hide();
        $("#selectmaterial").show().val(row.ModelNumber);// + row.MaterialName
        $("#dlgselectMaterial").dialog("close");
    }
}
//对话框取消
function dlgselectcancel() {
    $("#dlgselectMaterial").dialog("close");
}

//物料信息
var Materialinfo;

//将物料添加到订单中
function addtoorder() {   
    var Amout = $("#Amout").val();
    var Requirement = $("#Requirement").val();
    if (Materialinfo && Amout > 0) {
        Materialinfo["OrderID"] = $("#cgorderid").text();
        Materialinfo["Requirement"] = Requirement;
        Materialinfo["Amout"] = Amout;
        var rowdata = $("#dgcginfo").datagrid("getRows");
        var flag;
        if (rowdata.length > 0) {
            //for (var i = 0, max = rowdata.length; i < max; i++) {
            //    var comparerow = rowdata[i];
            //    if (Materialinfo["ModelNumber"] + Materialinfo["MaterialName"] == comparerow["ModelNumber"] + comparerow["MaterialName"]) {
            //        flag = true;
            //        break;
            //    }
            //}
            //if (flag) {
            //    $.messager.alert('提示', '订单中已有此物料');
            //} else {
            //$("#Amout").val(0);
            //$("#dgcginfo").datagrid("appendRow", Materialinfo);
            //}
        }
        //else {
        $("#Amout").val(0);
        $("#dgcginfo").datagrid("appendRow", Materialinfo);
        //}
        $("#Requirement").val("");
        $("#selectmaterial").hide();
        //$("#btnselect").show();
        Materialinfo = null;
    } else {
        $.messager.alert('提示', '请选择物料或填写数量');
    }
}

//产生订单
function createOrder() {
    var rowdata = $("#dgcginfo").datagrid("getRows");
    if (rowdata && rowdata.length > 0) {
        var orderid = $("#cgorderid").text();
        var item = JSON.stringify(rowdata);
        $.post('/Service/BaseDataService_2/PurchaseOrdersManager.ashx?opr=addOrder', {
            OrderId: orderid, Items: item
        }, function (data) {
            if (data && data.d > 0) {
                $.messager.alert('提示', '订单添加成功！');
                window.location.href = window.location.href;
            } else {
                $.messager.alert('提示', '订单添加失败！');
            }
        })
    }

}




