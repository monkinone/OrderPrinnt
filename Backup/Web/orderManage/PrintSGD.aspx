<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_PrintSGD" CodeBehind="PrintSGD.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="ProgId" content="Excel.Sheet" />
    <meta name="Generator" content="WPS Office ET" />
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
    <%--<script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .tb td {
            height: 20px;
        }

        #txtremark table td {
            border: 1px solid #000;
            border: 0px;
        }

        #lblGongyi table td {
            border: 1px solid #000;
            border: 0px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            // DetailsPageControl.SetEveryAreaSize();
            var HolePageWidth = $(window).width();
            var HolePageHeight = $(window).height();
            var LeftInfoAreaWidth = HolePageWidth * .3;
            var OptBarHeight = $("#OptBar").outerHeight();

            var RightInfoAreaWidth = HolePageWidth;
            $("#RightInfoArea").height(HolePageHeight - OptBarHeight);
            var InfoWidth = HolePageWidth - $(".optbar .title").width() - $(".optbar .optbtn").outerWidth() - 40;


        })
        function jiSuanHeight() {
            var gaodu1 = parseInt($("#tdshuru").height());
            var gaodu2 = $("#tdshuchu").height();
            var gaodu = gaodu1 + gaodu2;
            $("#tbPeixianYaoqiu").height(gaodu);
        }
        function update() {
            //修改已打印数量
            $.ajax({
                type: "Post",
                async: false,
                url: "PrintSGD.aspx/UpdatePrint",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //   alert('成功');
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
            //修改随工单打印数量
            $.ajax({
                type: "Post",
                async: false,
                url: "PrintSGD.aspx/UpdatePrintCount",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //   alert('成功');
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
            //添加随工单号(随工单记录)
            $.ajax({
                type: "Post",
                async: false,
                url: "PrintSGD.aspx/AddSuigongdan",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //   alert('成功');
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
            //修改打印信息
            update();
            //打印
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
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

        $(function () {
            var allBox = $(":checkbox");
            allBox.click(function () {
                allBox.removeAttr("checked");
                $(this).attr("checked", "checked");
            });
            $(":button").click(function () {
                // alert($(":checkbox:checked").val());
            });
        });
    </script>
</head>
<body link="blue" vlink="purple" onload="jiSuanHeight()">
    <form id="form1" runat="server">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印随工单			

                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint(); return false;" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="details" align="center">
            <div class="rightinfo" id="RightInfoArea" style="text-align: left; font-size:10px">
                <!--startprint-->
                <table align="center">
                    <tr>
                        <td>
                            <table class="form " cellpadding="0" cellspacing="0" style="width: 768px;" align="center">
                                <tr>
                                    <td colspan="6" style="text-align: center; font-size: 24px; font-weight: bold;">随工单</td>

                                </tr>
                                <tr>
                                    <td>订单<input type="checkbox" /></td>
                                    <td>备货<input type="checkbox" /></td>
                                    <td colspan="4" style="font-size: 12px;">订单号:<asp:Label ID="lblOrderNUM" runat="server" Style="padding-right: 30px;"></asp:Label>计划发货日期：<asp:Label ID="lblPlanTime" runat="server" Style="padding-right: 30px;"></asp:Label>编号：<asp:Label ID="lblSuigongdan" runat="server"></asp:Label></td>
                                    <td colspan="2"></td>
                                </tr>
                            </table>
                            <table class="form tb" cellpadding="0" cellspacing="0" style="width: 768px; border-top: 1px solid #000000; border-left: 1px solid #000;" align="center">
                                <tr>
                                    <td width="80">型号</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblproType" runat="server"></asp:Label>
                                    </td>

                                    <td width="80">数量</td>
                                    <td>
                                        <asp:Label ID="lblProNUM" runat="server"></asp:Label></td>
                                    <td width="80">批号</td>
                                    <td colspan="2">
                                        <asp:Label ID="lblPihao" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="9" style="text-align: center;">参数指导</td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="text-align: left;">成品参数</td>
                                    <td>包装盒规格
                                    </td>
                                    <td>
                                        <asp:Label ID="txtbaoZhuangHeGG" runat="server"></asp:Label>
                                    </td>
                                    <td>包装箱规格
                                    </td>
                                    <td>
                                        <asp:Label ID="txtbaoZhuangXiangGG" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80">变   比</td>
                                    <td width="80">
                                        <asp:Label ID="txtbianbi" runat="server"></asp:Label></td>
                                    <td width="80">精  度</td>
                                    <td width="80">
                                        <asp:Label ID="txtjingDu" runat="server"></asp:Label></td>
                                    <td width="80">线性度</td>
                                    <td colspan="2" width="80">
                                        <asp:Label ID="txtxianXingdu" runat="server"></asp:Label></td>
                                    <td width="80">额定角差</td>
                                    <td width="80">
                                        <asp:Label ID="txteDingJC" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-weight: bold;">1.铁芯参数</td>
                                    <td colspan="4" style="font-weight: bold;">2.线圈参数</td>
                                    <td colspan="3" style="font-weight: bold;">3.线圈检测要求</td>
                                </tr>
                                <tr>
                                    <td>规格</td>
                                    <td width="80">
                                        <asp:Label ID="txtguiGe" runat="server"></asp:Label></td>
                                    <td>初级匝数</td>
                                    <td width="80">
                                        <asp:Label ID="txtchujZaShu" runat="server"></asp:Label></td>
                                    <td>次级匝数</td>
                                    <td width="80">
                                        <asp:Label ID="txtcijZaShu" runat="server"></asp:Label></td>
                                    <td>设备名称</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtxqjcyqEquip" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>材料</td>
                                    <td width="80">
                                        <asp:Label ID="txtcaiLiao" runat="server"></asp:Label></td>
                                    <td>线径</td>
                                    <td width="80">
                                        <asp:Label ID="txtchujXianJing" runat="server"></asp:Label></td>
                                    <td>线径</td>
                                    <td width="80">
                                        <asp:Label ID="txtcijXianJing" runat="server"></asp:Label></td>
                                    <td>输入状态</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtxqjcyqShuRuState" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>性能</td>
                                    <td width="80">
                                        <div style="width: 80px;">
                                            <asp:Label ID="txtxingNeng" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                    <td>绕线指导</td>
                                    <td width="80">
                                        <asp:Label ID="txtchujRaoXianZD" runat="server"></asp:Label></td>
                                    <td>绕线指导</td>
                                    <td width="80">
                                        <asp:Label ID="txtcijRaoXianZD" runat="server"></asp:Label></td>
                                    <td>输出状态</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtxqjcyqShuChuState" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>处理方式</td>
                                    <td width="80">
                                        <asp:Label ID="txtchuLiMethod" runat="server"></asp:Label></td>
                                    <td>线头长度</td>
                                    <td width="80">
                                        <asp:Label ID="txtchujXianTouCD" runat="server"></asp:Label></td>
                                    <td>线头长度</td>
                                    <td width="80">
                                        <asp:Label ID="txtcijXianTouCD" runat="server"></asp:Label></td>
                                    <td>角差</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtxqjcyqJiaoCha" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>饱和点</td>
                                    <td width="80">
                                        <asp:Label ID="txtbaoHeDian" runat="server"></asp:Label></td>
                                    <td>线头处理</td>
                                    <td width="80">
                                        <asp:Label ID="txtchujXiantouCL" runat="server"></asp:Label></td>
                                    <td>线头处理</td>
                                    <td width="80">
                                        <asp:Label ID="txtcijXianTouCL" runat="server"></asp:Label></td>
                                    <td rowspan="2">负载</td>
                                    <td colspan="2" rowspan="2">
                                        <asp:Label ID="txtxqjcyqFuZai" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="80">饱和点测试条件</td>
                                    <td width="80">
                                        <asp:Label ID="txtbaoHeDianTestTJ" runat="server"></asp:Label></td>
                                    <td>同名端</td>
                                    <td width="80">
                                        <asp:Label ID="txtchujTongMD" runat="server"></asp:Label></td>
                                    <td>同名端</td>
                                    <td width="80">
                                        <asp:Label ID="txtcijTongMD" runat="server"></asp:Label></td>

                                </tr>
                                <tr>
                                    <td colspan="2" style="font-weight: bold;">4.外形参数</td>
                                    <td colspan="3" style="font-weight: bold;">5.成品检测参数</td>
                                    <td colspan="4" style="font-weight: bold;">6.辅料信息</td>
                                </tr>
                                <tr>
                                    <td>标示编号</td>
                                    <td>
                                        <asp:Label ID="txtbiaoShiNo" runat="server"></asp:Label></td>
                                    <td>设备名称</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtcpjccsEquip" runat="server"></asp:Label></td>
                                    <td rowspan="2" colspan="4">
                                        <%--                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-right: 0px; padding-right: 0px;">
                                            <tr>
                                                <td rowspan="2" style="border-bottom: 0px;">管脚针型号</td>
                                                <td style="border: 0px; border-bottom: 1px solid #000;">输入</td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px;">输出</td>
                                            </tr>
                                        </table>--%>
                                        <table id="Table1" style="height: 100%; width: 100%;" cellpadding="0" cellspacing="0" border="0" style="border: 0; margin-right: 0px; padding-right: 0px;">
                                            <tr>
                                                <td rowspan="2" style="border-bottom: 0px; width: 50px;">管脚针型号</td>
                                                <td style="border: 0px; border-bottom: 1px solid #000; border-right: 1px solid #000; width: 40px;">输入</td>
                                                <td style="border: 0px; border-bottom: 1px solid #000;">

                                                    <div style="width: 100%; border: 0;">
                                                        <asp:Label ID="txtguanJiaoZhenLX" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px; border-right: 1px solid #000; width: 40px;">输出</td>
                                                <td style="border: 0px;">
                                                    <div style="width: 100%; border: 0;">
                                                        <asp:Label ID="txtguanJiaoZhenLXTOW" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>标识位置</td>
                                    <td>
                                        <asp:Label ID="txtbiaoShiAddress" runat="server"></asp:Label></td>
                                    <td>输入状态</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtcpjccsShuRuState" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>外壳编号</td>
                                    <td>
                                        <asp:Label ID="txtwaiKeNo" runat="server"></asp:Label></td>
                                    <td>输出状态</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtcpjccsShuChuState" runat="server"></asp:Label></td>
                                    <td style="width: 100px;">输入线长(外留)</td>
                                    <td colspan="3">
                                        <div style="width: 280px;">
                                            <asp:Label ID="txtshuRuXC" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>用胶参数</td>
                                    <td>
                                        <asp:Label ID="txtyongJiaoCS" runat="server"></asp:Label></td>
                                    <td>角差</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtCpjccsJiaoChaBH" runat="server"></asp:Label></td>
                                    <td>输出线长(外留)</td>
                                    <td colspan="3">
                                        <div style="width: 280px;">
                                            <asp:Label ID="txtshuChuXC" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>输入方式</td>
                                    <td>
                                        <asp:Label ID="txtshuRu" runat="server"></asp:Label></td>
                                    <td>负载</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtcpjccsFuZai" runat="server"></asp:Label></td>
                                    <td rowspan="2" colspan="4">
                                        <table id="tbPeixianYaoqiu" style="height: 100%; width: 100%;" cellpadding="0" cellspacing="0" border="0" style="border: 0; margin-right: 0px; padding-right: 0px;">
                                            <tr>
                                                <td rowspan="2" style="border-bottom: 0px; width: 50px;">配线要求</td>
                                                <td style="border: 0px; border-bottom: 1px solid #000; border-right: 1px solid #000; width: 40px;">输入</td>
                                                <td style="border: 0px; border-bottom: 1px solid #000;">
                                                    <div style="width: 100%; border: 0;">
                                                        <asp:Label ID="txtpeiXianSR" runat="server">
                                                        </asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px; border-right: 1px solid #000; width: 40px;">输出</td>
                                                <td style="border: 0px;">
                                                    <div style="width: 100%; border: 0;">
                                                        <asp:Label ID="txtpeiXianSC" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>输出方式</td>
                                    <td>
                                        <asp:Label ID="txtshuChu" runat="server"></asp:Label></td>
                                    <td>耐压</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtcpjccsNaiYa" runat="server"></asp:Label></td>

                                </tr>




                                <tr>
                                    <td>接插件型号</td>
                                    <td>
                                        <asp:Label ID="txtchajianNo" runat="server"></asp:Label></td>
                                    <td>同名端</td>
                                    <td colspan="2">
                                        <asp:Label ID="txtcpjccsTongMD" runat="server"></asp:Label></td>

                                    <td colspan="4" rowspan="2">其他制作要求<div id="txtremark" runat="server" style="width: 380px;" />
                                    </td>
                                </tr>


                                <%--                                <tr>
                                    <td>接插件型号</td>
                                    <td>
                                        <asp:Label ID="txtchajianNo" runat="server"></asp:Label></td>
                                    <td>同名端</td>
                                    <td>
                                        <asp:Label ID="txtcpjccsTongMD" runat="server"></asp:Label></td>
                                    <td colspan="3">
                                        
                                        其他制作要求<div id="txtremark" runat="server" style="width: 98%;"></div>
                                    </td>

                                </tr>--%>
                                <tr>
                                    <td colspan="5" style="padding: 2px; padding-left: 20px;">
                                        <asp:Image ID="imgWaiXingTZ" runat="server" Height="150" Style="max-width: 300px;" />&nbsp;&nbsp;<%--<asp:Image ID="imgBisoShiImg" runat="server" Width="160" Height="160" />--%></td>
                                </tr>
                                <tr>
                                    <td colspan="9" style="font-weight: bold;">参数要求:<asp:Label ID="lblCanshuYaoqiu" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="9" style="font-weight: bold;">工艺注意事项:<div id="lblGongyi" runat="server"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">组装负责人：</td>
                                    <td colspan="2">同名端确认人：</td>
                                    <td colspan="2">下单编辑人：</td>
                                    <td colspan="3">下单审核人：</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>


                <!--endprint-->
            </div>
        </div>

    </form>
</body>

</html>
