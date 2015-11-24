<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliverGoods.aspx.cs" Inherits="Web.BaseDataUI_2.DeliverGoods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />

    <style type="text/css">
     
    </style>
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js">       
    </script>
    <script src="../JS_2/BaseData/DeliverGoods.js"></script>

    <title>供应商发货明细录入</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">供应商发货明细录入</div>
    <div style="margin: 10px;">
        <span>采购订单编号：</span>
        <input type="text" class="inpu_bg" id="tbx_search_OrderID" />
        <span>物料型号：</span>
        <input type="text" class="inpu_bg" id="tbx_search_ModelNumber" />
        <span>状态：</span>
        <select id="sel_search_isDelivered" class="easyui-combobox" style="width: 120px;">
            <option value="">全部</option>
            <option value="0">未发货</option>
            <option value="1">已发货</option>
        </select>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="searchData()" data-options="iconCls:'icon-search',plain:true">查询</a>
    </div>


    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="addinfo()" data-options="iconCls:'icon-add',plain:true">添加发货明细</a>

    <table id="dgorderinfo" title="发货情况列表" style="width: 1300px; height: auto">
        <thead>
            <tr>
                <th data-options="field:'OrderID',width:100">采购订单编号</th>
                <th data-options="field:'CompanyName',width:100">供应商名称</th>
                <th data-options="field:'MaterialName',width:100">物料名称</th>
                <th data-options="field:'Amout',width:100">订单总量</th>
                <th data-options="field:'TechnicalParameters',width:100">参数</th>
                <th data-options="field:'AllDeliverCount',width:100">已发货数量累计</th>
                <th data-options="field:'TheDeliveryAmout',width:100">本次发货数量</th>
                <th data-options="field:'Number',width:100">件数</th>
                <th data-options="field:'DeliverGoodsTime',width:100">发货时间</th>
                <th data-options="field:'DeliveryNum',width:100">发货单号</th>
                <th data-options="field:'LogisticsCompany',width:100">货运公司名称</th>

                <th data-options="field:'op',width:100,formatter:formatop">操作</th>
            </tr>
        </thead>

    </table>
    <%-- <div id="tborder" style="height: auto">
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="createOrder()">生成订单</a>
    </div>--%>

    <div id="dlg_add" class="easyui-dialog" title="添加发货明细" style="width: 500px; height: 400px; padding: 10px"
        data-options="modal:true,closed:true,iconCls: 'icon-add',buttons: '#dlg-buttons_add1'">
        <div class="sear_list">
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">订单号：</li>
                <li class="b20_left">
                    <select style="width: 165px" id="OrderID">
                    </select>
                    <input type="hidden" class="inpu_bg" id="deID" />
                    <%--<input type="text" class="inpu_bg" readonly="true" id="OrderID" />--%>
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">物料名称：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" readonly="true" id="MaterialName" />
                    <input type="hidden" class="inpu_bg" readonly="true" id="ModelNumber" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">本次发货数量：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="TheDeliveryAmout" />
                </li>
            </ul>

            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">件数：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="Number" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">发货单号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="DeliveryNum" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b20_right">货运公司：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="LogisticsCompany" />
                </li>
            </ul>
        </div>
    </div>
    <div id="dlg-buttons_add1">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:edit()">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:adddialoginit()">取消</a>
    </div>


    <div id="dlg_htinfo" class="easyui-dialog" title="有订单合同" style="width: 700px; height: 300px;"
        data-options="modal:true,closed:true,iconCls: 'icon-ok'">
        <table id="htinfo" title="合同信息" style="width: 680px; height: auto">
            <thead>
                <tr>
                    <th data-options="field:'OrderID',width:150">采购订单编号</th>
                    <th data-options="field:'ContractID',width:150">合同编号</th>
                    <th data-options="field:'AddTime',width:150">订单时间</th>
                    <th data-options="field:'op',width:100,formatter:formatophtinfo">操作</th>
                </tr>
            </thead>

        </table>
    </div>

    <div id="dlg_htdetailinfo" class="easyui-dialog" title="合同详情" style="width: 800px; height: 400px;"
        data-options="modal:true,closed:true,iconCls: 'icon-ok'">
        <table id="htdetailinfo" title="合同信息" style="width: 780px; height: auto">
            <thead>
                <tr>
                    <th data-options="field:'OrderID',width:120">采购订单编号</th>
                    <th data-options="field:'ContractID',width:120">合同编号</th>
                    <th data-options="field:'ModelNumber',width:50">物料型号</th>
                    <th data-options="field:'CategoryName',width:50">物料类别</th>
                    <th data-options="field:'Amout',width:50">数量</th>
                    <th data-options="field:'TechnicalParameters',width:100">技术参数</th>
                    <th data-options="field:'Requirement',width:100">特殊要求</th>
                </tr>
            </thead>

        </table>
    </div>
</body>
</html>
