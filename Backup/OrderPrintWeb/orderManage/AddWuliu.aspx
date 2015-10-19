<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_AddWuliu" CodeBehind="AddWuliu.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../scripts/Validform/css/style.css" />
    <link href="../scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            DetailsPageControl.SetEveryAreaSize();
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }
    </script>
    <style type="text/css">
        .selecter {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">编辑发货明细
                    </td>
                    <td class="optbtn">
                        <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                            ToolTip="提交" CssClass="btn" />
                        <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
            <div class="rightinfo" id="RightInfoArea" >
                <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="title1">订单号：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="lblOrderNum" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">发货单号：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtsendNum" runat="server" CssClass="tarea" TextMode="MultiLine" datatype="*" 
                            nullmsg="请输入发货单号！" errormsg="请输入发货单号！"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="title1">货运公司：
                        </td>
                    </tr>
                    <tr>
                        <td class="info">&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtpackingCompanyName" runat="server" CssClass="tarea" datatype="*"   TextMode="MultiLine"
                                nullmsg="请输入货运公司名称！" errormsg="请输入货运公司名称！"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
