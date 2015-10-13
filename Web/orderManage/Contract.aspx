<%@ Page Language="C#" AutoEventWireup="true" Inherits="orderManage_Contract" CodeBehind="Contract.aspx.cs" %>

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
    <link href="../themes/default/styles/maincontent.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
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
            height: 23px;
            text-align: center;
        }

        .con h5 {
            margin-top: -15px;
        }

        .printBox {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印合同
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
            <div class="rightinfo" id="RightInfoArea">

                <table align="center">
                    <tr>
                        <td style="font-size: 26px; font-weight: bold; text-align: center;">合同</td>
                    </tr>
                    <tr>
                        <td>
                            <table class="form" cellpadding="0" cellspacing="0" style="width: 768px;" align="center">
                                <tr>
                                    <td>&nbsp;订单号：<asp:Label ID="lblOrderNUM" runat="server"></asp:Label>
                                        &nbsp;&nbsp; TO:<asp:TextBox ID="lblToName" runat="server" Style="border: 0; width: 280px; font-size: 15px;"></asp:TextBox>
                                        &nbsp;&nbsp;  收到合同日期：<asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>

                                </tr>
                            </table>
                            <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #000; border-left: 1px solid #000; text-align: center; width: 768px;" align="center">
                                <tr>
                                    <td colspan="4">供方
                                    </td>
                                    <td></td>
                                    <td colspan="3">需方
                                    </td>
                                </tr>
                                <tr>
                                    <td>单位
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" CssClass="printBox">北京霍远科技有限公司</asp:TextBox></td>
                                    <td>单位
                                    </td>
                                    <td colspan="3" style="text-align: center;" id="tdlblCompanyName">
                                        <asp:TextBox ID="lblCompanyName" runat="server" CssClass="printBox"></asp:TextBox>


                                    </td>
                                </tr>
                                <tr>
                                    <td>地址
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" CssClass="printBox">北京市丰台区角门18号名流未来大厦206室</asp:TextBox></td>
                                    <td>地址
                                    </td>
                                    <td colspan="3" style="height:60px;">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="printBox" TextMode="MultiLine"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td>电话</td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="printBox">010-87581089</asp:TextBox></td>

                                    <td>传真</td>
                                    <td>
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="printBox">52283998</asp:TextBox></td>

                                    <td>电话</td>
                                    <td>
                                        <asp:TextBox ID="txtphone" runat="server" CssClass="printBox"></asp:TextBox></td>
                                    <td>传真</td>
                                    <td>
                                        <asp:TextBox ID="txttax" runat="server" CssClass="printBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>联系人</td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="printBox"></asp:TextBox></td>
                                    <td>手机</td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="printBox"></asp:TextBox></td>
                                    <td>联系人</td>
                                    <td>
                                        <asp:TextBox ID="txtcontacts" runat="server" CssClass="printBox"></asp:TextBox></td>
                                    <td>手机</td>
                                    <td>
                                        <asp:TextBox ID="txttelPhone" runat="server" CssClass="printBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>账号</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TextBox5" runat="server" CssClass="printBox">11001028600056020512</asp:TextBox></td>

                                    <td>账号</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblZhangHao" runat="server"></asp:Label></td>

                                </tr>
                                <tr>
                                    <td>开户</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TextBox6" runat="server" CssClass="printBox">中国建设银行北京白石桥支行</asp:TextBox></td>

                                    <td>税号</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblShuihao" runat="server"></asp:Label></td>

                                </tr>
                                <tr>
                                    <td colspan="8" style="border-bottom: 0px; text-align: left; font-size: 12px; font-weight: bold;">一、合同明细（如果超出表格可另附清单）
                                    </td>
                                </tr>
                            </table>
                            <%--  <table class="form " cellpadding="0" cellspacing="0" style="width: 768px; height:30px;" align="center">
                    <tr>
                        <td>
                            <h5></h5>
                        </td>
                    </tr>
                </table>--%>
                            <div id="tabDongTai" runat="server">
                                <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #000; border-left: 1px solid #000; text-align: center; width: 768px;" align="center" id="Table1">
                                    <tr>
                                        <td>序号</td>
                                        <td>产品名称</td>
                                        <td>型号</td>
                                        <td>数量（只）</td>
                                        <td>单价</td>
                                        <td>金额（元）</td>
                                        <td>备注</td>
                                    </tr>
                                    <asp:Repeater ID="rptPro" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Container.ItemIndex + 1 %></td>
                                                <td>互感器</td>
                                                <td><%# Eval("proType") %></td>
                                                <td><%# Eval("proNum") %></td>
                                                <td><%# Eval("proPrice") %></td>
                                                <td><%# Eval("totalPrice") %></td>
                                                <td>
                                                    <textarea class="printBox" style="width:250px;height:40px;"></textarea></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td colspan="2">合计（人民币大写）</td>
                                        <td colspan="2">
                                            <asp:Label ID="lblDaxiePrice" runat="server"></asp:Label></td>
                                        <td>￥：</td>
                                        <td>
                                            <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></td>
                                        <td>
                                            <input type="text" class="printBox" /></td>
                                    </tr>
                                </table>
                            </div>
                            <table class="form tb" cellpadding="0" cellspacing="0" style="border-top: 1px solid #000; border-left: 1px solid #000; width: 768px;" align="center" id="tabJingTai" runat="server">

                                <tr>
                                    <td>序号</td>
                                    <td>产品名称</td>
                                    <td>型号</td>
                                    <td>数量（只）</td>
                                    <td>单价</td>
                                    <td>金额（元）</td>
                                    <td>备注</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td>5</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td>6</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td>7</td>
                                    <td>传感器</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <input type="text" class="printBox" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">合计（人民币大写）</td>
                                    <td colspan="2">
                                        <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                    <td>￥：</td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server"></asp:Label></td>
                                    <td></td>
                                </tr>
                            </table>
                            <table class="form con" cellpadding="0" cellspacing="0" style="width: 768px; text-align: left;" align="center">

                                <tr>
                                    <td>
                                        <h5 style="margin-top: 0px;">二、
                                <input type="text" value="供方对质量负责的条件：所供产品为需方要求品牌并全新未经使用。" class="printBox" style="border-bottom: 1px solid #bbb; width: 730px;" /></h5>
                                        <h5>三、 交货地点：<input type="text" class="printBox" style="width: 470px; border-bottom: 1px solid #bbb;" /><br />
                                            &nbsp&nbsp&nbsp&nbsp 交货时间(即出厂时间):<input type="text" class="printBox" style="width: 470px; border-bottom: 1px solid #bbb;" /></h5>
                                        <h5>四、 交货方式：□自提      □邮运需方所在地     □送货上门	</h5>
                                        <h5>五、 运输方式：□铁路快件  □包裹     运费承担：□供方   □需方（特殊要求）							
                    <br />
                                            包装标准：原厂装并符合货运部门标准包装。如外包装有损坏，请您通知供方拒绝接收货物。</h5>
                                        <h5>六、 验收标准、方法及异议期限：按供方产品说明书或供方提供给需方的规格书共同验收，如有质量问题请在收到货物						
                    <br />
                                            15个工作日内验收完毕，20内提出退、换货,超过20个工作日我司有权拒绝退货并且由此造成的损失由需方自己承担。</h5>
                                        <h5>七、 结算方式：□ 款到发货          □ 一次付清货款    □月结       □季度付清货款	    □货到付款								
                    <br />
                                            汇款方式：□汇票      □电汇转帐     □现金结算     □支票 </h5>
                                        <h5>八、 发票要求：□增值税(累积2000开票)    □普通发票     □不含税</h5>
                                        <h5>九、 需方严格按照合同约定的方式付款,如货到需方没有按照合同约定的期限付款,每逾期一天,额外支付延期货款的1%									
                    <br />
                                            作为违约金。</h5>
                                        <h5>十、在供方得到需方盖章或签字的传真件合同,供方视为双方正式签定并执行合同,在合同执行期间,需方提出任何方面						
                    <br />
                                            的变更,供方可以配合完成,但由此产生的费用或造成的经济损失由需方承担.</h5>
                                        <h5>十一、纠纷方式：双方协商解决。如协商不成可诉诸法院，双方可选择合同签订地、合同履行地、原告所在地、被告所
                    <br />
                                            在地，地方法院解决纠纷。</h5>
                                        <h5>十二、保修：所售产品保修期二年，保修期内产品损坏一律包换（需方人为或技术使用不当及开封氧化等除外）。</h5>
                                        <h5>十三、附则：本合同自双方签字盖章之日起生效，合同条款执行完毕自行终止。</h5>
                                        <h5>十四、其它补充：<input type="text" class="printBox" style="width: 650px; border-bottom: 1px solid #bbb;" /></h5>
                                    </td>
                                </tr>
                            </table>

                            <table class="form " cellpadding="0" cellspacing="0" style="width: 768px;" align="center">
                                <tr>
                                    <td>供方：北京霍远科技有限公司</td>
                                    <td>需方：</td>
                                </tr>
                                <tr>
                                    <td>单位名称（盖章）：</td>
                                    <td>单位名称（盖章）：</td>
                                </tr>
                                <tr>
                                    <td>法定代理人：</td>
                                    <td>法定代理人：</td>
                                </tr>
                                <tr>
                                    <td>委托代理人：</td>
                                    <td>委托代理人：</td>
                                </tr>
                                <tr>
                                    <td>日期：<asp:Label ID="lblDate" runat="server"></asp:Label></td>
                                    <td>日期：&nbsp;&nbsp;&nbsp;&nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</td>
                                </tr>
                            </table>
                            <table class="form " cellpadding="0" cellspacing="0" style="width: 768px;" align="center">
                                <tr>
                                    <td>
                                        <h5>请及时盖章回传，以方便我公司及时安排生产贵公司的订单!如有问题请及时与我们联系！</h5>
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
