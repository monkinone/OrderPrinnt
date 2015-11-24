
    $(function () {
        //合同信息
        $("#htinfo").datagrid({
            url: '/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=LoginUserPurchaseContractList',
            loadMsg: "正在加载，请稍等...",
            pageSize: 20,
            singleSelect: true,
            rownumbers: true,
            pagination: true,//分页控件 
            onLoadSuccess: function (data) {
                if (data.rows && data.rows.length > 0) {
                    //弹出提示框
                    $("#dlg_htinfo").dialog("open");
                }

                //订单号 下拉框
                $("#OrderID").combobox({
                    url: '/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=getOrderlist',
                    method: 'post',
                    valueField: 'OrderID',
                    textField: 'OrderID',
                    onSelect: function (record) {
                        if (!$("#deID").val()) {
                            $("#ModelNumber").val(record.ModelNumber);
                            $("#MaterialName").val(record.MaterialName);
                        }
                    }
                });
                //发货情况列表
                $("#dgorderinfo").datagrid({
                    url: '/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=getDeliverGoodsList',
                    loadMsg: "正在加载，请稍等...",
                    pageSize: 20,
                    rownumbers: true,//行号    
                    singleSelect: true,//是否单选
                    pagination: true//分页控件 
                })

                //合同详情数据表格
                $("#htdetailinfo").datagrid({
                    loadMsg: "正在加载，请稍等...",
                    singleSelect: true,
                    rownumbers: true
                })

            }
        })
    })

//})
//弹出添加明细窗口
function toCreate() {
    var row = $('#dgorderinfo').datagrid('getSelected');
    $("#deID").val(row.ID);
    $("#OrderID").combobox("select", row.OrderID);
    $("#ModelNumber").val(row.ModelNumber);
    $("#MaterialName").val(row.MaterialName);
    $("#TheDeliveryAmout").val(row.TheDeliveryAmout),
    $("#Number").val(row.Number),
    $("#DeliveryNum").val(row.DeliveryNum),
    $("#LogisticsCompany").val(row.LogisticsCompany);
    $("#dlg_add").dialog("open");
}

function formatop(val, row, index) {
    return '<a class="red" href="javascript:toCreate()">录入发货明细</a> ';
}
//获取合同详情
function formatophtinfo(val, row, index) {
    return '<a class="red" href="javascript:accessht(2)">接受</a>  ' +
        '<a class="red" href="javascript:accessht(1)">拒绝</a>  ' +
        '<a class="red" href="javascript:htdetail()">详情</a>';
}

//接受还是拒绝合同
function accessht(states) {
    var row = $('#htinfo').datagrid('getSelected');
    var info = states == 1 ? "拒绝" : "接受";
    $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=updatePurchaseContraceStatus",
        { ID: row.ID, Status: states }
        , function (data) {
            if (data.d > 0) {
                $('#htinfo').datagrid('reload');//重新载入当前页
                alert("合同已" + info + "！");
            } else {
                alert("合同" + info + "失败！");
            }
        })
}

//合同详情
function htdetail() {
    var row = $('#htinfo').datagrid('getSelected');
    //合同详情对话框
    $("#dlg_htdetailinfo").dialog("open");

    $.post("/Service/BaseDataService_2/PurchaseContractManage.ashx?opr=getHtDetail",
        { ContractID: row.ContractID }, function (data) {
            $("#htdetailinfo").datagrid("loadData", data);
        })

}


//查找按钮
function searchData() {
    var tbx_search_OrderID = $("#tbx_search_OrderID").val();
    var tbx_search_ModelNumber = $("#tbx_search_ModelNumber").val();
    var sel_search_isDelivered = $("#sel_search_isDelivered").combobox("getValue");
    $('#dgorderinfo').datagrid('load', {
        OrderID: tbx_search_OrderID,
        ModelNumber: tbx_search_ModelNumber,
        isDelivered: sel_search_isDelivered
    });
}

//弹出添加明细框
function addinfo() {
    $("#dlg_add input").val("");
    $("#dlg_add").dialog("open");
}

//明细
function edit() {
    var OrderID = $("#OrderID").combobox("getText"),
      ModelNumber = $("#ModelNumber").val(),
      MaterialName = $("#MaterialName").val(),
      TheDeliveryAmout = $("#TheDeliveryAmout").val(),
      Number = $("#Number").val(),
      DeliveryNum = $("#DeliveryNum").val(),
      LogisticsCompany = $("#LogisticsCompany").val();
    $.post("/Service/BaseDataService_2/DeliverGoodsManager.ashx?opr=addDeliverGoods", {
        ID: $("#deID").val(),
        OrderID: OrderID,
        ModelNumber: ModelNumber,
        MaterialName: MaterialName,
        TheDeliveryAmout: TheDeliveryAmout,
        Number: Number,
        DeliveryNum: DeliveryNum,
        LogisticsCompany: LogisticsCompany
    }, function (data) {
        if (data.d > 0) {
            alert("明细添加成功！");
            $('#dgorderinfo').datagrid('reload');
        } else {
            alert("明细添加失败！");
        }
        adddialoginit();
    })
}
//对话框取消按钮
function adddialoginit() {
    $("#dlg_add input").val("");
    $("#dlg_add").dialog("close");
}

