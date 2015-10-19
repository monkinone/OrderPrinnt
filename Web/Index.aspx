<%@ Page Language="C#" AutoEventWireup="true" Inherits="Index" CodeBehind="Index.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="themes/default/styles/all.css" rel="stylesheet" type="text/css" />
    <link href="themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="scripts/JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="scripts/Custom/Config.js"></script>
    <script src="scripts/Custom/Comm.js" type="text/javascript"></script>
    <script src="scripts/JQuery/colorbox-master/jquery.colorbox.js" type="text/javascript"></script>
    <script src="scripts/Custom/BoxControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).resize(function () {
            Comm.ResizeWindow();
        });
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
        .aHead { font-size:20px;color: #004ea2; margin-left:5px}
        .userinfo  a:link {color: #004ea2}     /* 未访问的链接 */       
        .userinfo  a:visited {color: #004ea2}  /* 已访问的链接 */
        .userinfo  a:hover {color:Red}    /* 当有鼠标悬停在链接上 */
        .userinfo  a:active {color: #004ea2}   /* 被选择的链接 */
    </style>
</head>
<body>
    <div id="popWindow" class="popWindow" style="display: none;">
        <h1 id="masklayer" class="maskLayer" style="color: white;">请使用360浏览器或谷歌浏览器！</h1>
    </div>
    <form id="form1" runat="server">
        <div id="TopArea" class="t">
            <div class="appname">
                <div class="MainTitle">
                    霍远订单打印系统
                </div>
                <div class="userinfo" id="UserInfo">
                    <span>当前用户:</span><asp:Label ID="L_UserName" runat="server" CssClass="username"></asp:Label>
                    <a href="LoginOut.aspx"  class="aHead" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</a>
                 <br />
                </div>
            </div>
        </div>
        <div id="TabBar" class="tab">
            <ul>
                <!--管理-->
                <li name="tab_00" class="item" id="guanli" runat="server" visible="false">
                    <a href="orderManage/OrderManage.aspx" target="iframe_tab_00" id="a2">订单管理</a>
                    <a href="orderManage/SendList.aspx" target="iframe_tab_00" id="a3">发货情况</a>
                    <a href="CustomerManage/CustomerManage.aspx" id="a4" target="iframe_tab_00">客户管理</a>
                    <a href="orderManage/OrderKaiPiaoManage.aspx" target="iframe_tab_00" id="a8">回款与开票管理</a>
                    <a href="CustomerManage/PriceManage.aspx" target="iframe_tab_00" id="a6">单价管理</a>
                    <a href="NoticeManage/AddNotice.aspx" target="iframe_tab_00" id="a7">通知管理</a>
                    <a href="orderManage/PrintGuigeshu.aspx" target="iframe_tab_00">打印规格书</a>
                    <%-- <a href="LoginOut.aspx" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</a>--%>
                    <%-- <a href="Main.aspx" target="iframe_tab_00" id="a1" >修改密码</a>--%>
                </li>
                <!--生产-->
                <li name="tab_00" class="item " id="shengchan" runat="server" visible="false">
                    <a href="orderManage/OrderProManage.aspx?UserType=" target="iframe_tab_00">待打印单据</a>
                    <a href="/orderManage/SearchSGD.aspx" target="iframe_tab_00">随工单号查询</a>
                    <a href="orderManage/SendListOrAddSend.aspx" target="iframe_tab_00">发货情况及录入发货明细</a>
                    <a href="orderManage/NoSendList.aspx" target="iframe_tab_00">未完成订单</a>
                    <a href="ProductManage/TongjiProduct.aspx" target="iframe_tab_00">产品统计</a>
                    <a href="ProductManage/ProductManage.aspx" target="iframe_tab_00">产品管理</a>
                    <a href="ProductManage/YulanImg.aspx" target="iframe_tab_00">标示位置&外壳&管脚针图预览</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                    <a href="orderManage/PrintGuigeshu.aspx" target="iframe_tab_00">打印规格书</a>
                    <%-- %>a href="LoginOut.aspx" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</%>
                    <%--<a href="Main.aspx" target="iframe_tab_00">修改密码</a>--%>
                </li>
                <!--辅助生产-->
                <li name="tab_00" class="item " id="fzsc" runat="server" visible="false">
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                    <a href="orderManage/OrderProManage.aspx?UserType=<%=UserType %>" target="iframe_tab_00">待打印单据</a>
                    <a href="orderManage/SendListOrAddSend.aspx?UserType=6" target="iframe_tab_00">发货情况及录入发货明细</a>
                    <a href="ProductManage/YulanImg.aspx" target="iframe_tab_00">标示位置&外壳&管脚针图预览</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                    <a href="orderManage/PrintGuigeshu.aspx" target="iframe_tab_00">打印规格书</a>
                    <%-- %>a href="LoginOut.aspx" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</%>
                    <%--<a href="Main.aspx" target="iframe_tab_00">修改密码</a>--%>
                </li>
                <!--技术-->
                <li name="tab_00" class="item " id="jishu" runat="server" visible="false">
                    <a href="ProductManage/ProductManage.aspx"
                        target="iframe_tab_00">产品管理</a>
                    <a href="ProductManage/WaiKeImgManage.aspx" target="iframe_tab_00">外壳图片管理</a>
                    <a href="ProductManage/GuanJiaoZhenImgManage.aspx" target="iframe_tab_00">管脚针图片管理</a>
                    <a href="ProductManage/BiaoShiImageManage.aspx" target="iframe_tab_00">标示位置管理</a>
                    <a href="CustomerManage/ProductParamManage.aspx" target="iframe_tab_00">客户产品参数</a>
                    <a href="CustomerManage/ZYSXManage.aspx" target="iframe_tab_00">发货前注意事项</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                    <a href="orderManage/GuiGeShu.aspx" target="iframe_tab_00">打印规格书</a>
                    <%-- %>a href="LoginOut.aspx" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</%>
                    <%--<a href="Main.aspx" target="iframe_tab_00">修改密码</a>--%>
                </li>
                <!--业务-->
                <li name="tab_00" class="item " id="yewu" runat="server" visible="false">
                    <a href="orderManage/YeWuOrderList.aspx" target="iframe_tab_00">订单情况</a>
                    <a href="orderManage/YeWuSendList.aspx" target="iframe_tab_00">发货情况</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                    <a href="orderManage/PrintGuigeshu.aspx" target="iframe_tab_00">打印规格书</a>
                    <%-- %>a href="LoginOut.aspx" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</%>
                    <%--<a href="Main.aspx" target="iframe_tab_00">修改密码</a>--%>
                </li>
                <!--用户-->
                <li name="tab_00" class="item " id="yonghu" runat="server" visible="false">
                    <a href="UserManage/UserManage.aspx" target="iframe_tab_00" id="a5">用户管理</a>
                    <a href="orderManage/DeleteOrder.aspx" target="iframe_tab_00" id="a1">订单管理</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                    <%-->a href="LoginOut.aspx" target="iframe_tab_00" onclick="return confirm('您确定要退出系统吗？')">退出系统</--%>
                </li>
                <!--库房-->
               <li name="tab_00" class="item " id="kufang" runat="server" visible="false">
                    <a href="" target="iframe_tab_00">原料进仓</a>
                    <a href="" target="iframe_tab_00">原料出仓</a>
                    <a href="" target="iframe_tab_00">退料</a>
                    <a href="" target="iframe_tab_00">查看供应商发货明细</a>
                    <a href="" target="iframe_tab_00">导出库存清单</a>
                    <a href="" target="iframe_tab_00">采购订单管理</a>
                    <a href="BaseDataUI_2/WareHouse.aspx" target="iframe_tab_00">仓库管理</a>
                    <a href="BaseDataUI_2/MaterialManager.aspx" target="iframe_tab_00">物料信息</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                </li>
               <!--采购-->
               <li name="tab_00" class="item " id="caigou" runat="server" visible="false">
                    <a href="BaseDataUI_2/Suppliers.aspx" target="iframe_tab_00">供应商管理</a>
                    <a href="BaseDataUI_2/SuppliersUser.aspx" target="iframe_tab_00">供应商帐号管理</a>
                    <a href="BaseDataUI_2/SuppliersUnitPrice.aspx" target="iframe_tab_00">单价管理</a>
                    <a href="BaseDataUI_2/SuppliersLevel.aspx" target="iframe_tab_00">供应商评定</a>
                    <a href="" target="iframe_tab_00">供应商发货明细</a>
                    <a href="" target="iframe_tab_00">导出库存清单</a>
                    <a href="" target="iframe_tab_00">采购订单查看</a>
                    <a href="" target="iframe_tab_00">合同管理</a>
                   <a href="BaseDataUI_2/WareHouse.aspx" target="iframe_tab_00">仓库管理</a>
                   <a href="BaseDataUI_2/MaterialManager.aspx" target="iframe_tab_00">物料信息</a>
                   <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                </li>
                <!--供应商-->
               <li name="tab_00" class="item " id="gongyingshang" runat="server" visible="false">
                    <a href="" target="iframe_tab_00">发货</a>
                    <a href="" target="iframe_tab_00">等级查看</a>
                    <a href="" target="iframe_tab_00">订单合同</a>
                    <a href="NoticeManage/Notice.aspx" target="iframe_tab_00">通知公告</a>
                </li>
            </ul>
        </div>
        <div id="MainArea" class="m">
            <iframe name="iframe_tab_00" id="desk" runat="server" scrolling="no" width="100%" height="100%"
                src="" class="current" style="overflow: auto;"></iframe>
        </div>
        <div id="FootArea" class="f">
            <div class="currentfun" id="CurrentFunName">
                霍远订单打印系统&copy;版权所有
            </div>
        </div>

        <script type="text/javascript">
            function change(id) {
                //   $('.current').removeClass('current');
                $('#' + id).addClass('current');

            }
        </script>
    </form>
</body>
</html>
