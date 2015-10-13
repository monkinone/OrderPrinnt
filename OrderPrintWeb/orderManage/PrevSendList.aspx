<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrevSendList.aspx.cs" Inherits="OrderPrintWeb.orderManage.PrevSendList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../scripts/Validform/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../scripts/Validform/Validform_v5.3.2.js" type="text/javascript"></script>
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/Selecter-master/jquery.fs.selecter.min.js" type="text/javascript"></script>
  <%--  <script src="../scripts/Custom/DetailsPageControl.js" type="text/javascript"></script>--%>
    <script src="../scripts/My97DatePicker/WdatePicker.js"></script>
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

        function doPrint() {
            // pagesetup_null();
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
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">预览送货单
                    </td>
                    <td class="optbtn">
                        <%--  <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />--%>
                        <%--   <input type="image" onclick="DetailsPageControl.CloseBox();" class="btn" src="../themes/default/images/btn/btn_close_w_h.png"
                            title="返回" />--%>
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../themes/default/images/btn/btn_print_nbyj_b_h.png" ToolTip="打印" OnClick="btnPrint_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="details">
            <!--startprint-->
            <div class="rightinfo" id="RightInfoArea" style="margin-top: 15px; text-align: left; min-height: 400px;">
                <table align="center">
                    <tr>
                        <td>
                            <div style="text-align: center;">
                                <h1 style="font-size: 28px; font-weight: bold;">送 货 单</h1>
                            </div>
                            <table class="form" cellpadding="0" cellspacing="0" style="width: 800px; margin-top: 10px;" align="center">
                                <tr>
                                    <td style="width:500px;font-size:14px;">收货单位Receiving unit：<asp:Label ID="lblCompanyName" runat="server" ></asp:Label></td>

                                    <td style="font-size:14px;">发货日期Shipped Date：<input class=" tbox" readonly="readonly" id="lblPrintTime" type="text" name="txtTime" onclick="WdatePicker()"
                                        runat="server" style="border: 0; border-bottom: 1px solid #ccc;" /></td>
                                </tr>
                            </table>
                            <div id="div1" runat="server">
                                <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #000; width: 800px; text-align: center;" align="center" id="Table1">

                                    <tr>
                                        <td style="width:50px;">序号<br />
                                            number</td>
                                        <td style="width:100px;">名称<br />
                                            Name</td>
                                        <td style="width:150px;">规格型号<br />
                                            Model number</td>
                                        <td style="width:100px;">变比<br />
                                            turns ratio</td>
                                        <td style="width:50px;">单位<br />
                                            unit</td>
                                        <td style="width:50px;">数量<br />
                                            Quantity</td>
                                        <td style="width:80px;">单价<br />
                                            Unit Price</td>
                                        <td style="width:100px;">金额<br />
                                            amount</td>
                                        <td style="width:170px;">备注<br />
                                            Note</td>
                                    </tr>
                                    <asp:Repeater ID="rptPro" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Container.ItemIndex + 1 %></td>
                                                <td>互感器<br />
                                                    Transformers</td>
                                                <td>
                                                    <asp:Label ID="lblProType" runat="server" Text=' <%# Eval("proType") %>'></asp:Label></td>
                                                <td><%# Eval("bianbi").ToString() %></td>
                                                <td>PCS</td>
                                                <td>
                                                    <asp:Label ID="txtProNum" runat="server" Text='<%# Eval("proNum") %>'></asp:Label>
                                                </td>
                                                <td>0.00
                                        <asp:Label ID="lblPrice" runat="server" Text=' <%# Eval("danjia") %>' Style="display: none;"></asp:Label>
                                                </td>
                                                <td>0.00
                                        <asp:Label ID="lblTotalPrice" runat="server" Text=' <%# Eval("jine") %>' Style="display: none;"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtRemark" runat="server" Text=' <%# Eval("beizhu") %>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <div id="div2" runat="server">
                                <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #000; width: 800px; text-align: center;" align="center" id="Table2">

                                    <tr>
                                        <td style="width:50px;">序号<br />
                                            number</td>
                                        <td style="width:100px;">名称<br />
                                            Name</td>
                                        <td style="width:150px;">规格型号<br />
                                            Model number</td>
                                        <td style="width:100px;">变比<br />
                                            turns ratio</td>
                                        <td style="width:50px;">单位<br />
                                            unit</td>
                                        <td style="width:50px;">数量<br />
                                            Quantity</td>
                                        <td style="width:80px;">单价<br />
                                            Unit Price</td>
                                        <td style="width:100px;">金额<br />
                                            amount</td>
                                        <td style="width:170px;">备注<br />
                                            Note</td>

                                    </tr>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Container.ItemIndex + 1 %></td>
                                                <td>互感器<br />
                                                    Transformers</td>
                                                <td>
                                                    <asp:Label ID="lblProType" runat="server" Text=' <%# Eval("proType") %>'></asp:Label></td>
                                                <td><%# Eval("bianbi").ToString() %></td>
                                                <td>PCS</td>
                                                <td>
                                                    <asp:Label ID="txtProNum" runat="server" Text='<%# Eval("proNum") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPrice" runat="server" Text=' <%# Eval("danjia") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotalPrice" runat="server" Text=' <%# Eval("jine") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtRemark" runat="server" Text=' <%# Eval("beizhu") %>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>


                            <table class="form " cellpadding="0" cellspacing="0" style="width: 800px; margin-top: 10px; font-size: 14px; text-align: right;" align="center">
                                <tr>
                                    <td>发货单位及经办人：师小如</td>
                                    <td></td>
                                    <td>订单号：<asp:Label ID="lblOrderNum" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>收货单位及经手人：</td>
                                    <td width="100"></td>
                                </tr>
                                <tr>
                                    <td colspan="6">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6">请在收货后三天内核对以下项目：1、出厂检验报告1份。2、送货单2份，超过以上期限，视为默认接收。</td>

                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">白联（存根)</td>
                                    <td colspan="3">红联、黄联（交客户）</td>
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
