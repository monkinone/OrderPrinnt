<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/scripts/Validform/css/style.css" />
    <link href="scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <link href="themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
     <script src="scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
   
    <script src="scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="scripts/Custom/Comm.js"></script>
    <script src="scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <script src="scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#form1").Validform({
                beforeSubmit: function () {
                    // return confirm('注意！信息是否审核无误，提交后将不能撤销。');
                },
                datatype: {

                    "phone": function () {
                        var reg1 = $("#txt_officePhone").val();
                        if (reg1.length > 0) {
                            var re = /^[0-9\-]{8,20}$/;
                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },

                    "Mphone": function () {
                        var reg1 = $("#txt_mobilephone").val();
                        if (reg1.length > 0) {
                            var re = /^[0-9]{11}$/;
                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else
                        { return true; }
                    },
                    "fax": function () {
                        var reg1 = $("#txt_fax").val();
                        if (reg1.length > 0) {
                            var re = /^[0-9\-]{8,20}$/;
                            if (reg1 == "" || TestRgexp(re, reg1)) { return true; }
                            else { return false; }
                        } else { return true; }
                    },
                    "zhiji": function () {
                        var reg1 = $("#ddlrank").val();
                        if (reg1 == 0) { return false; } else { return true; }
                    }
                }
            });
        })
        //正则验证
        function TestRgexp(re, s) {
            return re.test(s)
        }
    </script>
    <style type="text/css">
        .selecter
        {
            width: 195px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
    <div id="OptBar" class="optbar">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="info">
                    修改用户密码
                </td>
                <td class="optbtn">
                    <asp:ImageButton ID="IBtn_Save" runat="server"  OnClick="Save_Click" ImageUrl="~/themes/default/images/btn/btn_save_w_h.png"
                        ToolTip="提交" CssClass="btn" />
                   <%-- <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="themes/default/images/btn/btn_close_w_h.png"
                        title="返回" />--%>
                </td>
            </tr>
        </table>
    </div>
    <div class="details">
        <div class="rightinfo" id="RightInfoArea" style="   float:left;">
            <table class="form" cellpadding="4" cellspacing="0" align="center" width="100%">
            <tr>
            <td colspan="2"><span class="loginTishi" id="spanTishi" runat="server">您是首次登录，请修改密码</span></td>
            </tr>
                <tr>
                    <td class="title1">
                        请输入原密码：
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtOldPass" runat="server" CssClass="tbox" Rows="5" datatype="*"
                            nullmsg="请输入原密码！" errormsg="请输入原密码！"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   
                     <td class="title1">
                        请输入新密码：
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtNewPass" runat="server" CssClass="tbox" Rows="5" datatype="*"
                            nullmsg="请输入新密码！" errormsg="请输入新密码！"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="title1">
                        请再次输入新密码：
                    </td>
                    <td class="info">
                        <asp:TextBox ID="txtRePass" runat="server" CssClass="tbox" Rows="5" datatype="*" nullmsg="请再次输入新密码！"
                            errormsg="请再次输入新密码！"></asp:TextBox>
                    </td>
                </tr>

            </table>
        </div>
    </div>
    </form>
</body>
</html>
