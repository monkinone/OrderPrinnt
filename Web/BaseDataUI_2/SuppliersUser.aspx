<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliersUser.aspx.cs" Inherits="Web.BaseDataUI.ProvisionUserManager" %>

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
    <script src="../JS_2/BaseData/suppliersUser.js"></script>
    <title>供应商用户管理</title>
</head>
<body>
    <div style="font-size:20px; margin:10px;font-family:'Microsoft YaHei';">供应商用户</div>
         <div style="width:100%;">
           <a href="javascript:$('#dlg_cangku_add').dialog('open')" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true">添加</a>
         </div>
         <table id="dg_SuppliersUser" class="easyui-datagrid">  
            <thead>  
                <tr>  
                    <th data-options="field:'userName',align:'center',width:100">登陆账号</th>  
                    <th data-options="field:'trueName',align:'center',width:100">用户姓名</th>  
                    <th data-options="field:'phone',align:'center',width:100">电话</th>
                    <%--<th data-options="field:'price0',align:'center',width:100">最后登陆时间</th>--%>      
                    <th data-options="field:'loginNum',align:'center',width:100">登陆次数</th>
                    <%--<th data-options="field:'price1',align:'center',width:100">创建时间</th>--%>
                    <%--<th data-options="field:'price2',align:'center',width:100">修改时间</th>--%> 
                    <th data-options="field:'CompanyName',align:'center',width:300">绑定的供应商</th>
                    <%--<th data-options="field:'price5',align:'center',width:100">状态</th>--%>
                    <th data-options="field:'a',align:'center',width:100,formatter:formatOperSuppliersUser">操作</th>  
                </tr>  
            </thead>
        </table>
        <!----供应商用户s--->
    <div id="dlg_cangku_add" class="easyui-dialog" title="供应商用户" style="width:800px;height:200px;padding:10px"
			data-options="modal:true,closed:true,iconCls: 'icon-edit',buttons: '#dlg-buttons_add1'">
         <div class="sear_list">
                <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">登陆账号：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="txt_name" maxlength="50" />
                    <font class="red">*</font>
                </li>
                 <li class="b10_right">密码：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="Text1" />
                     <font class="red">*</font>
                    <input type="checkbox" />默认密码123456
                </li>
              </ul>
             <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">用户姓名：</li>
                <li class="b30_left">
                    <input type="text" class="inpu_bg" id="tbx_position" />
                </li>
                <li class="b10_right">手机号码：</li>
                <li class="b30_left">
                   <input type="text" class="inpu_bg" id="Text2" />
                </li>
            </ul>
         </div>
	</div>
    <div id="dlg-buttons_add1">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:alert('save')">保存并继续添加</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:alert('save')">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg').dialog('close')">取消</a>
	</div>
   <!----供应商用户e--->
</body>
</html>
