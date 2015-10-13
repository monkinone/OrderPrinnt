<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_InspectionReport" CodeBehind="InspectionReport.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />

    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />

    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
   <%-- <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>--%>
    <title>出厂检验报告</title>
    <script type="text/javascript">
        $(function () {
            //   DetailsPageControl.SetEveryAreaSize();
            var HolePageWidth = $(window).width();
            var HolePageHeight = $(window).height();
            var LeftInfoAreaWidth = HolePageWidth * .3;
            var OptBarHeight = $("#OptBar").outerHeight();

            var RightInfoAreaWidth = HolePageWidth;
            // $("#RightInfoArea").width(RightInfoAreaWidth);
            // $("#LeftInfoArea").height(HolePageHeight - OptBarHeight);
            $("#RightInfoArea").height(HolePageHeight - OptBarHeight);
        })
      
        //修改打印次数
        function update() {

            $.ajax({
                type: "Post",
                async: false,
                url: "InspectionReport.aspx/UpdatePrint",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //  alert('成功');
                    } else {
                        //  alert('失败');
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
    <style type="text/css">
        .tb td {
        font-size:14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">出 厂 检 验 报 告				

                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="details" style="text-align: left;">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea">
                <table align="center">
                    <tr>
                        <td>
                            <table class="form tb" cellpadding="4" cellspacing="0" align="center" style="width: 768px; text-align: left; border-top: 1px solid #000; border-left-color: #000;">
                                <tr>
                                    <td colspan="4" style="text-align: center; font-size: 24px; font-weight: bold;">出 厂 检 验 报 告</td>
                                </tr>
                                <tr>
                                    <td>供应商</td>
                                    <td colspan="2" style="text-align: left;">北京霍远科技有限公司
                                    </td>
                                    <td >产品批号:<asp:Label ID="lblPiHAO" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>客户名称</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>产品名称</td>
                                    <td>传感器</td>
                                    <td colspan="2">主要技术参数:<%--<asp:Label ID="lblBianbi" runat="server"></asp:Label>--%></td>
                                </tr>
                                <tr>
                                    <td>产品型号</td>
                                    <td>
                                        <asp:Label ID="lblProtype" runat="server"></asp:Label></td>
                                    <td style="width:150px;">额定输入<input type="checkbox" disabled="disabled" />电流<input type="checkbox" disabled="disabled" />电压</td>
                                    <td style="width:150px;">
                                        <asp:Label ID="lblBianbiQian" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>数量</td>
                                    <td>
                                        <asp:Label ID="lblProNum" runat="server"></asp:Label></td>
                                    <td style="width:150px;">额定输出<input type="checkbox" disabled="disabled" />电流<input type="checkbox" disabled="disabled" />电压</td>
                                    <td style="width:150px;">
                                        <asp:Label ID="lblBianbiHou" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4">一&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 外观检验&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 检验员：				
                                    </td>

                                </tr>
                                <tr>
                                    <td>外壳</td>
                                    <td colspan="2">无裂痕，无划伤</td>
                                    <td rowspan="5" >结论：</td>
                                </tr>
                                <tr>
                                    <td>胶面</td>
                                    <td colspan="2">无花纹、无气泡、无异物、胶面硬化</td>
                                </tr>
                                <tr>
                                    <td>输入方式</td>
                        <td colspan="2">
                            <asp:Label ID="txtshuRu" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>输出方式
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="txtshuChu" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>标签
                                    </td>
                                    <td colspan="2">
                                        <div class="fl">
                                        激光<input type="checkbox" disabled="disabled" />油印<input type="checkbox" disabled="disabled" disabled="disabled" /><br />
                                        标签<input type="checkbox" disabled="disabled" />&nbsp;&nbsp;&nbsp;无&nbsp;<input type="checkbox" disabled="disabled" disabled="disabled" /></div>
                                        <div  class="fl" style="padding-top:10px; padding-left:10px;"> 字迹清晰、字体规整、位置居中</div></td>
                                </tr>
                                <tr>
                                    <td colspan="4">二&nbsp;&nbsp;&nbsp; 工频电压检验&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                                    检验员：	</td>

                                </tr>
                                <tr style="height: 50px;">
                                    <td style="text-align: center;">工频
                                    </td>
                                    <td>
                                        <asp:Label ID="txtcpjccsNaiYa" runat="server"></asp:Label></td>
                                    <td>无击穿,无闪格<input type="checkbox" disabled="disabled" /></td>
                                    <td colspan="2" style="vertical-align: top;">结论:</td>
                                </tr>
                                <%--<tr>
                        <td></td>
                        <td></td>
                    </tr>--%>
                                <tr>
                                    <td colspan="4">三&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 比差值检验&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 检验员：				
                                    </td>
                                </tr>
                                <tr>

                                    <td>内容
                                    </td>
                                    <td>参数
                                    </td>
                                    <td>检验方式
                                    </td>
                                    <td rowspan="4" style="vertical-align: top;">结论：</td>
                                </tr>
                                <tr>

                                    <td>精度
                                    </td>
                                    <td>
                                        <asp:Label ID="txtjingDu" runat="server"></asp:Label></td>
                                    <td>全检<input type="checkbox" disabled="disabled" /></td>
                                </tr>
                                <tr>

                                    <td>线性度%
                                    </td>
                                    <td>
                                        <asp:Label ID="txtxianXingdu" runat="server"></asp:Label></td>
                                    <td>抽检<input type="checkbox" disabled="disabled" /></td>
                                </tr>
                                <tr>
                                    <td>额定角差</td>
                                    <td>
                                        <asp:Label ID="txteDingJC" runat="server"></asp:Label></td>
                                    <td>全检<input type="checkbox" disabled="disabled" /></td>
                                </tr>
                                <tr>
                                    <td rowspan="2">备注
                                    </td>
                                    <td colspan="3">仪器:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 互感器效验仪<input type="checkbox"  disabled="disabled"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 单相测试源:<input type="checkbox" disabled="disabled" /><br />

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">精度测试条件： 1.输入<input type="text" style="border: 0; border-bottom: 1px solid #ccc; width: 50px;" />
                                        A时测试 2.输入<input type="text" style="border: 0; border-bottom: 1px solid #ccc; width: 50px;" />V 时测试   3.负载电阻<asp:Label ID="txtxqjcyqFuZai" runat="server"></asp:Label>
                                        时测试		</td>
                                </tr>
                                <tr>
                                    <td>检验工号：
                                    </td>
                                    <td>检验日期：
                                    </td>
                                    <td>审核人：
                                    </td>
                                    <td>日期：	
                                    </td>
                                </tr>

                            </table>
                            <table class="form " cellpadding="4" cellspacing="0" align="center" style="width: 768px; text-align: left;">

                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>检验标准：</td>
                                    <td>GB1207-2006<br />
                                        GB1208-2006</td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td colspan="3" style="text-align: right">霍远科技有限公司</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td colspan="3" style="text-align: right">质检部		
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </div>
            <!--endprint-->
        </div>
    </form>
</body>
</html>
