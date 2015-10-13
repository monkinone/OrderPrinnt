<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSGDJL.aspx.cs" Inherits="orderManage_PrintSGDJL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //修改打印次数
        function update() {

            $.ajax({
                type: "Post",
                async: false,
                url: "PrintSGDJL.aspx/UpdatePrint",
                data: "",
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
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印随工单记录
                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />

                    </td>
                </tr>
            </table>
        </div>
        <div class="details" style="text-align: left; height: 700px; width: auto; overflow: scroll; overflow-x: hidden;">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea">
                <div style="text-align: center;">
                    <h1>随工单记录</h1>
                </div>
                <table class="form" cellpadding="0" cellspacing="0" style="width: 685px;" align="center">
                    <tr>
                        <td>型号：<asp:Label ID="lblProtype" runat="server"></asp:Label>&nbsp;&nbsp;数量：<asp:Label ID="lblProNum" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #004EA2; width: 685px;" align="center">
                    <tr>
                        <td>序号</td>
                        <td>工序</td>
                        <td>接单日期</td>
                        <td>接单量</td>
                        <td>返修量</td>
                        <td>废品</td>
                        <td>合格量</td>
                        <td>完成人</td>
                        <td>完成日期</td>
                        <td width="200">备注</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>铁芯处理</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>生产商：</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>线圈绕制</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>生产商/批号：</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>配料</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td>标识打印</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>5</td>
                        <td>线圈测量</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>6</td>
                        <td>线圈制作</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>7</td>
                        <td>成品组装▲</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>8</td>
                        <td>初级绕线</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>9</td>
                        <td>半成品测量</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>100% 抽检</td>
                    </tr>
                    <tr>
                        <td>10</td>
                        <td>封前整理</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>11</td>
                        <td>封胶</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>12</td>
                        <td>老化</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>13</td>
                        <td>检验耐压</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>14</td>
                        <td>成品测量</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>15</td>
                        <td>整理外观</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>抽检结果：</td>
                    </tr>
                    <tr>
                        <td>16</td>
                        <td>检测电阻/保护</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>抽检结果：</td>
                    </tr>
                    <tr>
                        <td>17</td>
                        <td>包装</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>

                </table>
                <table class="form tb" cellpadding="0" cellspacing="0" style="width: 685px;" align="center">
                    <tr>
                        <td colspan="8" style="text-align:center; font-size:24px; font-weight:bold;">产 品 流 向 表</td>
                    </tr>
                    <tr>
                        <td>序号</td>
                        <td>工序</td>
                        <td>类型</td>
                        <td>数量</td>
                        <td>操作员</td>
                        <td>日期</td>
                        <td>接收人</td>
                        <td width="200">备注</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>5</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>6</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>7</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>8</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>9</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="5">▲组装负责人：</td>
                        <td colspan="3">▲组装确认人：</td>
                    </tr>
                </table>
                <table class="form " cellpadding="0" cellspacing="0" style="width: 685px;" align="center">
                    <tr>
                        <td>使用说明：1、返修量按实际情况填写；2、三处“▲”要填写完整；3、下单审核人审核参数要求及注意事项；4、产品流向表中的“类型”，分“返修品”、“合格品”、“废品”三种，按实际情况填写。5、每批产品中出现不良品须填写在每批跟随的随工单上，不得与下一批混和在同张随工单上。6、特殊订做上打“√”代表本型号无富余量，有废品及时补上；普通常规上打“√”代表有富余量，无需补。7、下单编辑与审核必须是两个人员完成。</td>
                    </tr>
                </table>
            </div>
            <!--endprint-->
        </div>
    </form>
</body>
</html>
