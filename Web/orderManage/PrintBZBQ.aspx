<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_PrintBZBQ" CodeBehind="PrintBZBQ.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/Custom/Config.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <%--<script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>--%>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <%--<link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        $(function () {
            //  DetailsPageControl.SetEveryAreaSize();
            var HolePageWidth = $(window).width();
            var HolePageHeight = $(window).height();
            var LeftInfoAreaWidth = HolePageWidth * .3;
            var OptBarHeight = $("#OptBar").outerHeight();

            var RightInfoAreaWidth = HolePageWidth;
            $("#RightInfoArea").height(HolePageHeight - OptBarHeight);
            var InfoWidth = HolePageWidth - $(".optbar .title").width() - $(".optbar .optbtn").outerWidth() - 40;
        })
        //修改打印次数
        function update() {

            $.ajax({
                type: "GET",
                async: false,
                url: "/Service/PrintBZBQ.ashx",
                data: { opr: "UpdatePrint",orderNum:'<%=orderNum%>' },
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //  alert('成功');
                    } else {
                        // alert('失败');
                    }
                },
                error: function (xml, status) {
                    if (status == 'error') {
                        try {
                            var json = eval('(' + xml.responseText + ')');
                            //                        alert(json.Message + '\n' + json.StackTrace);
                        } catch (e) { }
                    } else {
                        //                    alert(status);
                    }
                }
            });
        }
        function doPrint() {
            // pagesetup_null();
            update();

            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            // window.location.reload();//重新加载
            //DetailsPageControl.CloseBox();//关闭窗口
            //  pagesetup_default()
        }


        function pagesetup_null() {
            //设置网页打印的页眉页脚为空  要降低浏览器安全级别
            var RegWsh = new CreateObject("WScript.Shell");
            RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\header", " ");
            RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\footer", " ");


            //设置页边距   
            //   RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_bottom", "");
            // RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_left", "100");
            //   RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_right", "");
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_top", "10");
        }
        //设置网页打印的页眉页脚为默认值
        function pagesetup_default() {
            var RegWsh = new ActiveXObject("WScript.Shell")
            hkey_key = "header"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&w&b页码，&p/&P")
            hkey_key = "footer"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&u&b&d")
        }


    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印外包装标签
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                        <%--   <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="details" style="text-align: left;">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea" style="width: 100%">
                 
                <%=htmlStr %>
            </div>
            <!--endprint-->
        </div>
    </form>
</body>
</html>
