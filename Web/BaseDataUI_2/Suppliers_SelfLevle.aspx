<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers_SelfLevle.aspx.cs" Inherits="Web.BaseDataUI_2.Suppliers_Self" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../themes/jquery-easyui-1.4.1/easyui.css" rel="stylesheet" />
    <link href="../themes/jquery-easyui-1.4.1/icon.css" rel="stylesheet" />
    <link href="../themes/global.css" rel="stylesheet" />
    <style type="text/css">
        .b10_right {
            width: 60px;
        }
    </style>
    <script src="../themes/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="../themes/jquery-easyui-1.4.1/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript">
        $(function () {
            //获取供应商等级
            $.post('/Service/BaseDataService_2/EvaluationLevelManager.ashx?opr=getSelfLevle', function (data) {
                if (data) {
                    console.log(data);

                    $("#tbx_SuppliersID").val(data.LevelData.SuppliersID);//供应商id
                    $("#tbx_Level").val(data.LevelData.Level);//供应商级别
                    if (data.logData && data.logData.length > 0) {
                        var remarkdata = data.logData;
                        var strRemark = '';
                        for (var i = 0; i < remarkdata.length; i++) {
                            strRemark += remarkdata[i].DoContent + " " + remarkdata[i].DoTime + "\n\r";
                        }
                        if (strRemark) {
                            $("#tbx_Remark").val(strRemark);//评审记录
                        }
                    }
                }
            })

        })

    </script>

    <title>供应商等级查看</title>
</head>
<body>
    <div id="dlg_EvaluationLevel" class="easyui-dialog" opertype="add" title="供应商等级详情" style="width: 560px; height: 400px; padding: 6px"
        data-options="modal:false,closed:false,iconCls: 'icon-edit'">
        <div class="sear_list" style=" height:350px;">
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">供应商编号：</li>
                <li class="b20_left">
                    <input style="width: 165px" id="tbx_SuppliersID" readonly="true" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">等级：</li>
                <li class="b20_left">
                    <input style="width: 165px" id="tbx_Level" readonly="true" />
                </li>
            </ul>
            <ul>
                <li class="b3">&nbsp;</li>
                <li class="b10_right">评审记录：</li>
                <li class="b20_left">
                    <textarea style="width: 350px; height: 200px" id="tbx_Remark" readonly="true"></textarea>
                </li>
            </ul>
        </div>
    </div>

</body>
</html>
