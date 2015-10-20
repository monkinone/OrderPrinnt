<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseContract_Add.aspx.cs" Inherits="Web.BaseDataUI_2.PurchaseContract_Add" %>

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


    <!--功能JS-->
    <script src="../JS_2/BaseData/PurchaseContract_Add.js"></script>
    <title>添加合同</title>
</head>
<body>
    <div style="margin: 10px; font-size: 14px; font-family: 'Microsoft YaHei';">
        <span style="font-size: 20px;">增加合同</span><br />

        合同编号:
        <label style="font-size: 14px;" id="htid" class="red">系统自动生成</label>
        <br />
        供应商编号：
    <select style="width: 165px" id="se_SuppliersID">
    </select>
        供应商名称:
    <select style="width: 165px" id="se_SuppliersName">
    </select>
        <br />
        发货方式:   
    <input name="GoodsMethods" value="1" checked="checked" type="radio" />直接发
    <input name="GoodsMethods" value="2" type="radio" />等款
    <input name="GoodsMethods" value="3" type="radio" />先生产
    <input name="GoodsMethods" value="4" type="radio" />待通知
        <br />
        合同信息:  <a href="#" class="easyui-linkbutton" onclick="AddHT()" iconcls="icon-add">添加合同</a>
        <table id="htinfo" title="合同信息" style="width: 1000px; height: auto">
            <thead>
                <tr>
                    <th data-options="field:'ContractID',width:120">合同编号</th>
                    <th data-options="field:'OrderID',width:120">采购订单编号</th>
                    <th data-options="field:'MaterialName',width:100">物料名称</th>
                    <th data-options="field:'ModelNumber',width:100">物料型号</th>
                    <th data-options="field:'CategoryName',width:100">物料类别</th>
                    <th data-options="field:'UnitName',width:60">单位</th>
                    <th data-options="field:'Amout',width:60">数量</th>
                    <th data-options="field:'UnitPrice',width:60">单价</th>
                    <th data-options="field:'TechnicalParameters',width:100">技术参数</th>
                    <th data-options="field:'Requirement',width:100">要求</th>
                </tr>
            </thead>

        </table>

        <br />
        <br />
        <br />
        <br />

        <%--订单信息显示--%>
        <table id="dgcginfo" title="订单信息" style="width: 1000px; height: auto">
            <thead>
                <tr>
                    <th data-options="field:'OrderID',width:100">采购订单编号</th>
                    <th data-options="field:'MaterialName',width:100">物料名称</th>
                    <th data-options="field:'ModelNumber',width:100">物料型号</th>
                    <th data-options="field:'CategoryName',width:100">物料类别</th>
                    <th data-options="field:'UnitName',width:100">单位</th>
                    <th data-options="field:'Amout',width:100">数量</th>
                    <th data-options="field:'TechnicalParameters',width:100">技术参数</th>
                    <th data-options="field:'Requirement',width:100">特殊要求</th>
                    <th data-options="field:'op',width:100,formatter:formatop">操作</th>

                </tr>
            </thead>

        </table>

    </div>
</body>
</html>
