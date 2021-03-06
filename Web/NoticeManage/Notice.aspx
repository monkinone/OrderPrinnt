﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="NoticeManage_Notice" CodeBehind="Notice.aspx.cs" %>

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

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar" style="text-align: center; padding-top: 20px; display:none;">
            
        </div>
        <div class="details">
            <div class="rightinfo" id="RightInfoArea">
                <table class="" cellpadding="4" cellspacing="0"  width="60%" >
                  
                    <tr>
                        <td style="text-align:center;"><asp:Label ID="lblTitle" runat="server" Style="font-size: 14px; font-weight: bold; text-align: center;"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="info">
                            <asp:Label ID="lblContents" runat="server" Style="text-align: left; line-height: 25px;"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
