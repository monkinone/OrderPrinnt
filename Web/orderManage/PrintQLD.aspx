<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_PrintQLD" CodeBehind="PrintQLD.aspx.cs" %>

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
    <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>
    <script src="../scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script src="../scripts/JQuery/colorbox-master/jquery.colorbox-min.js" type="text/javascript"></script>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Custom/TableControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            DetailsPageControl.SetEveryAreaSize();
        })
        //修改打印次数
        function update() {
            $.ajax({
                type: "GET",
                async: false,
                url: "/Service/PrintQLD.ashx",
                data: { opr: "UpdatePrint", orderNum:'<%=orderNum %>',proType:'<%=proType %>' },
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //  alert('成功');
                    } else {
                        //alert('失败');
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
    <script type="text/javascript">

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
    <style type="text/css">
        .tb td {
        height:25px;
        padding:0 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印取料单
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                        <%--   <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
           
            <div class="rightinfo" id="RightInfoArea" style="text-align: left;">
                 <!--startprint-->
                <table align="center">
                    <tr>
                        <td>
                            <table class="form" cellpadding="0" cellspacing="0" style="width: 800px;" align="center">
                                <tr>
                                    <td colspan="7" style="font-size:24px; text-align:center; font-weight:bold; padding:10px;">
                                        取料单
                                    </td>
                                </tr>
                                <tr >
                                    <td style="padding-left:5px;">型&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
                                    <td>
                                        <asp:Label ID="lblproType" runat="server"></asp:Label></td>
                                    <td>客户编号:</td>
                                    <td>
                                        <asp:Label ID="lblCustomerNo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="padding-left:5px;">订单号：</td>
                                    <td>
                                        <asp:Label ID="lblOrderNUM" runat="server"></asp:Label></td>
                                    <td>随工单号:</td>
                                    <td>
                                        <asp:Label ID="lblwithWorkNo" runat="server"></asp:Label></td>
                                    <td>备货<input type="checkbox" id="beihuo" />
                                        &nbsp;&nbsp;订单<input type="checkbox" id="dingdan" />
                                    </td>
                                </tr>
                            </table>
                            <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #000;border-left: 1px solid #000; width: 800px; text-align: left; " align="center" id="tabJingTai" runat="server">

                                <tr>
                                    <td style="width:90px;">物料名称</td>
                                    <td style="width:200px;">型号规格</td>
                                    <td style="width:400px;">性能参数要求</td>
                                    <td style="width:50px;">数量</td>
                                    <td style="width:100px;">处理方式</td>
                                    <td style="width:100px;">特殊要求</td>
                                    <td style="width:80px;">领料签字</td>
                                </tr>
                                <tr>
                                    <td>铁芯</td>
                                    <td>
                                        <asp:Label ID="txtguiGe" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtxingNeng" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txttieXiCount" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtchuLiMethod" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>线圈</td>
                                    <td>
                                        <asp:Label ID="lblXianquan" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblXianQuanCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>外壳</td>
                                    <td>
                                        <asp:Label ID="txtwaiKeNo" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblWaikeCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>骨架</td>
                                    <td>
                                        <asp:Label ID="lblgujia" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtgujiaCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtgujiaCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>铜线</td>
                                    <td>
                                        <asp:Label ID="lbltongxian" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbltongxianCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>管脚针输入</td>
                                    <td>
                                        <asp:Label ID="txtguanJiaoZhenLX" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="txtguanJIaoZhenLXCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>管脚针输出</td>
                                    <td>
                                        <asp:Label ID="txtguanJiaoZhenLXTOW" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="txtguanJiaoZhenLXTOWCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>铜排</td>
                                    <td>
                                        <asp:Label ID="lbltongpai" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="txttongpaiCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>输入引线</td>
                                    <td>
                                        <asp:Label ID="txtpeiXianSR" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txttongpaiCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtpeiXianSRCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>输出引线</td>
                                    <td>
                                        <asp:Label ID="txtpeiXianSC" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="txtpeiXianSCCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>接插件</td>
                                    <td>
                                        <asp:Label ID="txtchajianNo" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="txtchajianCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>磁环</td>
                                    <td>
                                        <asp:Label ID="lblcihuan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtcihuanCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtcihuanCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>端子</td>
                                    <td>
                                        <asp:Label ID="lblduanzi" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtduanziCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtduanziCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>线路板</td>
                                    <td>
                                        <asp:Label ID="lblxianluban" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtxianlubanCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtxianlubanCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>胶片</td>
                                    <td>
                                        <asp:Label ID="lbljiaopian" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtjiaopianCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtjiaopianCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>屏蔽</td>
                                    <td>
                                        <asp:Label ID="lblpingbi" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtpingbiCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtpingbiCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>稳压管</td>
                                    <td>
                                        <asp:Label ID="lblwenyaguan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtwenyaguanCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtwenyaguanCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>电阻</td>
                                    <td>
                                        <asp:Label ID="lbldianzu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtdianzuCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtdianzuCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>螺丝</td>
                                    <td>
                                        <asp:Label ID="lblluosi" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtluosiCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtluosiCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>热缩套管</td>
                                    <td>
                                        <asp:Label ID="lblresuotaoguan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtresuotaoguanCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtresuotaoguanCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>安装配件</td>
                                    <td>
                                        <asp:Label ID="lblanzhuangpeijian" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtanzhuangPJCanshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtanzhuangPJCount" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>元器件1</td>
                                    <td>
                                        <asp:Label ID="lblyuanqijian1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian1Canshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian1Count" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>元器件2</td>
                                    <td>
                                        <asp:Label ID="lblyuanqijian2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian2Canshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian2Count" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>元器件3</td>
                                    <td>
                                        <asp:Label ID="lblyuanqijian3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian3Canshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian3Count" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>元器件4</td>
                                    <td>
                                        <asp:Label ID="lblyuanqijian4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian4Canshu" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtyuanQiJian4Count" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
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
