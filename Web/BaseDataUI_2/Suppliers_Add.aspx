<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers_Add.aspx.cs" Inherits="Web.BaseDataUI_2.Provision_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>
    <title>添加供应商信息</title>
</head>
<body>
    <div class="sear_list">
     <ul>
        <li class="b3">&nbsp;</li>
        <li><strong class="blue">--添加供应商信息--</strong></li>
    </ul>
    <ul>
        <li class="b3">&nbsp;</li>
        <li class="b10_right">供应商编号：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_supplier_id" maxlength="50" />
        </li>
        <li class="b10_right">供应商用户选择：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_supplier_user" maxlength="50" />
        </li>
        <li class="b10_right">公司名称：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_companyName" maxlength="50" />
            <label class="red">*</label>
        </li>
    </ul>
    <ul>
        <li class="b3">&nbsp;</li>
        <li class="b10_right">联系人：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_ContactMan" maxlength="50" />
        </li>
        <li class="b10_right">职务：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_Position" maxlength="50" />
        </li>
        <li class="b10_right">联系电话：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_Telephone" maxlength="50" />
        </li>
    </ul>
    <ul>
        <li class="b3">&nbsp;</li>
        <li class="b10_right">传真：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_Fax" maxlength="50" />
        </li>
        <li class="b10_right">开票方式：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_InvoiceFa" maxlength="50" />
        </li>
        <li class="b10_right">付款方式：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_Payment" maxlength="50" />
        </li>
    </ul>
    <ul>
        <li class="b3">&nbsp;</li>
        <li class="b10_right">是否供应商提供合同范本：</li>
        <li class="b20_left">
            <input type="radio" class="inpu_bg" name="radio_IsContractModel" /><label>是</label>
            <input type="radio" class="inpu_bg" name="radio_IsContractModel" /><label>否</label>
        </li>
        <li class="b10_right">账号：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_BankAccount" maxlength="50" />
        </li>
        <li class="b10_right">开户行：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" id="tbx_BankName" maxlength="50" />
        </li>
    </ul>
    <ul>
        <li class="b3">&nbsp;</li>
        <li class="b10_right">纳税人税号：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" style="width:100%;" id="tbx_TaxpayerNumber" maxlength="50" />
        </li>
        <li class="b10_right">公司地址：</li>
        <li class="b20_left">
            <input type="text" class="inpu_bg" style="width:100%;" id="tbx_CompanyAdress" maxlength="50" />
        </li>
    </ul>
     <ul>
        <li class="b3">&nbsp;</li>
        <li class="b10_right">联系人性格与性别描述：</li>
        <li class="b20_left">
            <textarea  style="width:100%;height:80px" id="tbx_ContactManDetailInfo"></textarea>
        </li>
        <li class="b10_right">其他联系人档案：</li>
        <li class="b20_left">
            <textarea  style="width:100%;height:80px" id="tbx_OtherContactMan"></textarea>
        </li>
    </ul>
    <ul>
        <li class="b3">&nbsp;</li>
        <li class="b35_right"></li>
        <li class="b15_left">
            <input type="button" class="button_blue" id="btn_save" value="保存"/>
        </li>
        <li class="b15_left">
           <input type="button" class="button_blue" id="btn_back" value="返回"/>
        </li>
    </ul>
    </div>
</body>
</html>
