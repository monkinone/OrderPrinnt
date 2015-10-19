<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrders_Add.aspx.cs" Inherits="Web.DomainUI_2.PurchaseOrders_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>
    <title>采购订单管理</title>
</head>
<body>
     <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">添加采购订单</div>
      <div class="sear_list">
      <ul>
        <li class="b10_right">采购订单编号：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" style="color:gray" disabled="disabled" id="tbx_supplier_id" value="系统生成" maxlength="50" />
        </li>
      </ul>
      <ul>
        <li class="b10_right">订单明细：</li>
      </ul>
    </div>
</body>
</html>
