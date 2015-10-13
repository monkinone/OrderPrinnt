<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNotice.aspx.cs" Inherits="NoticeManage_AddNotice" ValidateRequest="false" %>

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

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
    <div id="OptBar" class="optbar">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="info">
                    通知管理
                </td>
                <td class="optbtn">
                    <asp:ImageButton ID="IBtn_Save" runat="server" OnClick="Save_Click" ImageUrl="../themes/default/images/btn/btn_save_w_h.png"
                        ToolTip="提交" CssClass="btn" />
                  
                </td>
            </tr>
        </table>
    </div>
    <div class="details">
        <div class="rightinfo" id="RightInfoArea" style="width: auto">
            <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
                <tr>
                    <td class="title1">
                        标题：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="tbox" datatype="*" Width="800"
                            nullmsg="请输入标题！" errormsg="请输入标题！"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        内容：
                    </td>
                </tr>
                <tr>
                    <td class="info">
                         <textarea class="ckeditor" cols="80" id="txtContents" name="editor1" rows="10" runat="server"></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
