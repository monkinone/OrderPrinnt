<%@ Page Language="C#" AutoEventWireup="true" Inherits="Login" CodeBehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录</title>
    <meta name="renderer" content="webkit">
    <link href="themes/default/styles/all.css" rel="stylesheet" type="text/css" />
    <link href="themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="themes/default/styles/login.css" rel="stylesheet" type="text/css" />
    <script src="scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="scripts/JQuery/colorbox-master/jquery.colorbox.js" type="text/javascript"></script>
    <script src="scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="scripts/JQuery/Uploadify/swfobject.js" type="text/javascript"></script>
    <script type="text/javascript">
        //        function ShowAgreement() {
        //            BoxControl.Show(Config.AppStartupDir + '/Agreement.aspx', '使用协议', '600px', '425px', false, false);
        //        }
        //        function ShowOfficeSuppliesApplyNotice() {
        //            BoxControl.Show(Config.AppStartupDir + '/OfficeSuppliesApplyNotice.aspx', '办公用品申请通知', '600px', '425px', false, false);
        //        }
        $(function () {
            $.fn.extend({
                layerCenter: function () {
                    var obj = $(this);
                    obj.css({
                        position: "absolute",
                        top: "50%",
                        left: "50%",
                        marginLeft: -obj.width() / 2,
                        marginTop: -obj.height() / 2
                    });
                }
            });
            if (navigator.userAgent.toLocaleLowerCase().indexOf("webkit") == -1) {
                $("#popWindow").show();
                $("#masklayer").layerCenter();
            }

        })
    </script>
    <style type="text/css">
        .popWindow {
            background-color: #9D9D9D;
            width: 100%;
            height: 100%;
            left: 0;
            top: 0;
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 1;
            position: absolute;
        }

        .maskLayer {
            background-color: #000;
            width: 480px;
            height: 30px;
            line-height: 30px;
            left: 50%;
            top: 50%;
            color: #fff;
            z-index: 0;
            position: absolute;
            text-align: center;
        }
    </style>
</head>
<body>
    <div id="popWindow" class="popWindow" style="display: none;">
        <h1 id="masklayer" class="maskLayer" style="color: white;">请使用360安全浏览器！</h1>
    </div>

    <form id="form1" runat="server">
        <div class="loginarea">
            <table class="t">
                <tr>
                    <td>
                        <h1>霍远订单打印系统</h1>
                    </td>
                </tr>
            </table>
            <table class="login" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title1" rowspan="3">登录</td>
                    <td class="title2 username">用户名</td>
                    <td class="title2 password">口令</td>
                    <td></td>
                </tr>
                <tr>
                    <td class="tbox">
                        <asp:TextBox ID="tbx_name" runat="server"></asp:TextBox></td>
                    <td class="tbox">
                        <asp:TextBox ID="tbx_pwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="btn">
                        <asp:ImageButton ID="IBtn_Login" runat="server" ToolTip="登录" OnClick="IBtn_Login_Click"
                            ImageUrl="themes/default/images/btn/btn_execute_w_n.png" onmouseover="this.src='themes/default/images/btn/btn_execute_w_h.png'"
                            onmouseout="this.src='themes/default/images/btn/btn_execute_w_n.png'" />
                    </td>
                </tr>
                <tr>
                    <td class="msg" colspan="2">
                        <asp:Label ID="Message" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                    </td>
                </tr>

            </table>
        </div>
        <a class='BoxHandler' style="display: none;"></a>
    </form>
</body>
</html>
