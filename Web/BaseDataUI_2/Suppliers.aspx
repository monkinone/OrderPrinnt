<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="Web.BaseDataUI_2.Provision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <style type="text/css">
        .b10_right {
            width: 12%;
        }

        .b3 {
            width: 2%;
        }
    </style>
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>


    <!--功能JS-->
    <script src="../JS_2/BaseData/suppliers.js"></script>
    <script type="text/javascript">
      
    </script>
    <title>供应商管理</title>
</head>
<body>
    <div style="font-size: 20px; margin: 10px; font-family: 'Microsoft YaHei';">供应商信息</div>
    <div style="width: 100%; margin: 10px;">
        <span>公司名称：</span>
        <input type="text" class="inpu_bg" id="tbx_search_companyName" />
        <a href="javascript:searchSuppliers()" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">查询</a>
        <a href="javascript:openadddialog()" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
    </div>
    <table class="easyui-datagrid" id="dg_suppliers">
        <thead>
            <tr>
                <th data-options="field:'ID',align:'center',width:100">供应商编号</th>
                <th data-options="field:'CompanyName',align:'center',width:200">公司名称</th>
                <th data-options="field:'AssessmentLevel',align:'center',width:100">评定等级</th>
                <th data-options="field:'ContactMan',align:'center',width:100">联系人</th>
                <th data-options="field:'trueName',align:'center',width:100">供应商用户</th>
                <th data-options="field:'opr',align:'center',width:100,formatter:formatOperSuppliers">操作</th>
            </tr>
        </thead>
    </table>


    <%-- 弹出窗口--%>

    <!----添加--->
    <div id="dlg_supplier_add" class="easyui-dialog" opertype="add" title="添加供应商" style="width: 1100px; height: 450px; padding: 6px"
        data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
        <div class="sear_list">
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b15_right">供应商编号：</li>
                <li class="b20_left">
                    <label id="gyxaddid" class="red">本编号由系统自动生成</label>
                    <label id="gyxeditid"></label>
                    <%--<input type="text" class="inpu_bg" id="tbx_supplier_id" maxlength="50" />--%>
                </li>
                <li class="b15_right">供应商用户选择：</li>
                <li class="b20_left">
                    <select class="easyui-combobox" style="width: 165px" id="tbx_supplier_user">
                    </select>
                    <%--   <label class="red">*</label>--%>
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
                <li class="b10_right">是否提供合同范本：</li>
                <li class="b20_left">
                    <input type="radio" id="radio_default0" class="inpu_bg" name="radio_IsContractModel" checked="checked" value="0" /><label>是</label>
                    <input type="radio" id="radio_default1" class="inpu_bg" name="radio_IsContractModel" value="1" /><label>否</label>
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
                    <input type="text" class="inpu_bg" style="width: 100%;" id="tbx_TaxpayerNumber" maxlength="50" />
                </li>
                <li class="b10_right">公司地址：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" style="width: 100%;" id="tbx_CompanyAdress" maxlength="50" />
                </li>

                <li class="b10_right">联系人手机号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" style="width: 100%;" id="tbx_MobilePhone" maxlength="50" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">联系人性格与性别描述：</li>
                <li class="b20_left">
                    <textarea style="width: 100%; height: 80px" id="tbx_ContactManDetailInfo"></textarea>
                </li>
                <li class="b10_right">其他联系人档案：</li>
                <li class="b20_left">
                    <textarea style="width: 100%; height: 80px" id="tbx_OtherContactMan"></textarea>
                </li>
            </ul>
        </div>
    </div>
    <div id="dlg-buttons_add1">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:addSuppliers()">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:adddialoginit();$('#dlg_supplier_add').dialog('close')">取消</a>
    </div>

    <div id="dlg_supplier_info" class="easyui-dialog" title="供应商信息" style="width: 1100px; height: 450px; padding: 6px"
        data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_info'">
        <div class="sear_list">
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">供应商编号：</li>
                <li class="b20_left">
                    <label id="gyxid"></label>
                </li>
                <li class="b10_right">供应商用户：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_supplier_user_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">公司名称：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_companyName_info" disabled="disabled" maxlength="50" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">联系人：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_ContactMan_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">职务：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_Position_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">联系电话：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_Telephone_info" disabled="disabled" maxlength="50" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">传真：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_Fax_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">开票方式：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_InvoiceFa_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">付款方式：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_Payment_info" disabled="disabled" maxlength="50" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">是否提供合同范本：</li>
                <li class="b20_left">
                    <input type="radio" id="radio_default_info0" class="inpu_bg" name="radio_IsContractModel_info" disabled="disabled" checked="checked" value="0" /><label>是</label>
                    <input type="radio"id="radio_default_info1"  class="inpu_bg" name="radio_IsContractModel_info" disabled="disabled" value="1" /><label>否</label>
                </li>
                <li class="b10_right">账号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_BankAccount_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">开户行：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" id="tbx_BankName_info" disabled="disabled" maxlength="50" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">纳税人税号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" style="width: 100%;" id="tbx_TaxpayerNumber_info" disabled="disabled" maxlength="50" />
                </li>
                <li class="b10_right">公司地址：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" style="width: 100%;" id="tbx_CompanyAdress_info" disabled="disabled" maxlength="50" />
                </li>

                <li class="b10_right">联系人手机号：</li>
                <li class="b20_left">
                    <input type="text" class="inpu_bg" style="width: 100%;" id="tbx_MobilePhone_info" disabled="disabled" maxlength="50" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">联系人性格与性别描述：</li>
                <li class="b20_left">
                    <textarea style="width: 100%; height: 80px" id="tbx_ContactManDetailInfo_info" disabled="disabled"></textarea>
                </li>
                <li class="b10_right">其他联系人档案：</li>
                <li class="b20_left">
                    <textarea style="width: 100%; height: 80px" id="tbx_OtherContactMan_info" disabled="disabled"></textarea>
                </li>
            </ul>
        </div>
    </div>
    <div id="dlg-buttons_info">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript: $('#dlg_supplier_info input[type=text]').val('');$('#dlg_supplier_info textarea').text('');$('#dlg_supplier_info').dialog('close')">取消</a>
    </div>


</body>
</html>
