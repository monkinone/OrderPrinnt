/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="BoxControl.js" />

$(function () {
    ShortcutMenuPageControl.getShortcutMenuFirst();
    ShortcutMenuPageControl.GetAllApply();
        ShortcutMenuPageControl.SetEvent();
    $("#PageIndex").val("1"); //当前页码
    $("#PageIndexCount").val("1"); //显示总页数
    $("#AllApplyPageCount").val("1"); //全部应用的页
    $("#LeiShu").val("1");
});
var ShortcutMenuPageControl = {};
var pageindex = 1;
ShortcutMenuPageControl.strDate;
ShortcutMenuPageControl.strWeek;
ShortcutMenuPageControl.getShortcutMenuFirst = function () {
    /// <summary</summary>               
    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + userid + "'}", "getShortcutMenuByUserId", "ShortcutMenuPageControl.BindShortcutMenuListFirst(data)");
}
ShortcutMenuPageControl.BindShortcutMenuListFirst = function (data) {
    var HtmlTemplate = "<table oncontextmenu=\"EnitShortcutMenu('@Authority_Code',@Size); return false;\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\" id=\"@Authority_Code\" lang=\"@TableID\" title=\"@Funname\"><tr>@ImgSrc</tr><tr><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
    var DataObj = $.parseJSON(data.d);
    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();
    //计算空白区域的宽
    var MainNavWidth = HolePageWidth - $("#TodayInfo").width() - 120;
    //计算空白区域的高
    var MainNavHeight = $("#TodayInfo").height() - 60;
    //给要操作区域宽和高
    $("#MyApp").width(MainNavWidth).height(MainNavHeight);

    //计算宽度能放几个图标
    var NumberWidth = Math.floor(MainNavWidth / 150);
    //计算高度能放几个图标
    var NumberHeight = Math.floor(MainNavHeight / 135);
    //计算那块区域能放多少个图标
    var Sum = NumberWidth * NumberHeight;
    $("#PageCount").val(Sum.toString());
    //页码
    pageindex = 1;

    var myDate = new Date();
    $(DataObj).each(function (index) {
        if (Sum <= 0) {
            $("#MyApp .iconarea:last").after("<td class=\"iconarea\"></td>");

            pageindex++;
            $("#PageIndexCount").val(pageindex.toString());
            Sum = NumberWidth * NumberHeight; //一页能放多少个图标
            $("#MyApp .iconarea").hide();
            $("#MyApp .iconarea:nth-child(" + parseInt($("#PageIndex").val()) + ")").show();
        }
        var ItemHtml = HtmlTemplate;
        if (this["Authority_Code"].toString() == "RCGLCK") {
            //判断两行时是否换行，或换列
            var PresentPage = Math.ceil(Sum / NumberWidth);
            if (NumberWidth * (PresentPage - 1) + 1 == Sum) {
                Sum--;
                if (Sum <= 0) {
                    $("#MyApp .iconarea:last").after("<td class=\"iconarea\"></td>");
                    pageindex++;
                    $("#PageIndexCount").val(pageindex.toString());
                    Sum = NumberWidth * NumberHeight;
                    $("#MyApp .iconarea").hide();
                    $("#MyApp .iconarea:nth-child(" + parseInt($("#PageIndex").val()) + ")").show();
                }
            }
            Sum = Sum - 2;
            ItemHtml = ItemHtml.replace(/@TableID/g, this["TableID"]);
            ItemHtml = ItemHtml.replace(/@ClassName/g, "btn h " + this["ClassName"]);
            ItemHtml = ItemHtml.replace(/@Authority_Code/g, this["Authority_Code"]);
            ItemHtml = ItemHtml.replace(/@Size/g, this["Size"]);
            ItemHtml = ItemHtml.replace(/@ImgSrc/g, "<td class='info'></td><td class='icon date' rowspan='2'><div class='date'>" + ShortcutMenuPageControl.strDate + "</div><div class='week'>" + ShortcutMenuPageControl.strWeek + "</div><span id='sp_" + this["TableID"] + "'></span></td>");
            ItemHtml = ItemHtml.replace(/@Funid/g, this["Funid"]);
            ItemHtml = ItemHtml.replace(/@Funurl/g, this["Funurl"]);
            ItemHtml = ItemHtml.replace(/@Funname/g, this["Funname"]);
            $("#MyApp .iconarea:last").append(ItemHtml);
        }
        else {
            if (parseInt(this["Size"].toString()) == 1) {//1:大图标；0：小图标
                //当前行数
                var PresentPage = Math.ceil(Sum / NumberWidth);
                //判断两行时是否换行，或换列
                if (NumberWidth * (PresentPage - 1) + 1 == Sum) {
                    Sum--;
                    if (Sum <= 0) {
                        $("#MyApp .iconarea:last").after("<td class=\"iconarea\"></td>");
                        pageindex++;
                        $("#PageIndexCount").val(pageindex.toString());
                        Sum = NumberWidth * NumberHeight;
                        $("#MyApp .iconarea").hide();
                        $("#MyApp .iconarea:nth-child(" + parseInt($("#PageIndex").val()) + ")").show();
                    }
                }
                //} else {
                Sum = Sum - 2;
                ItemHtml = ItemHtml.replace(/@TableID/g, this["TableID"]);
                ItemHtml = ItemHtml.replace(/@ClassName/g, "btn h " + this["ClassName"]);
                ItemHtml = ItemHtml.replace(/@Authority_Code/g, this["Authority_Code"]);
                ItemHtml = ItemHtml.replace(/@Size/g, this["Size"]);
                ItemHtml = ItemHtml.replace(/@ImgSrc/g, "<td class='info'></td><td class='icon date' rowspan='2' style=\"background-image:url(" + this["ImgSrc"] + ")\"><span id='sp_" + this["TableID"] + "'></span></td>");
                ItemHtml = ItemHtml.replace(/@Funid/g, this["Funid"]);
                ItemHtml = ItemHtml.replace(/@Funurl/g, this["Funurl"]);
                ItemHtml = ItemHtml.replace(/@Funname/g, this["Funname"]);
                $("#MyApp .iconarea:last").append(ItemHtml);
            }
            else {
                Sum--;
                ItemHtml = ItemHtml.replace(/@TableID/g, this["TableID"]);
                ItemHtml = ItemHtml.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                ItemHtml = ItemHtml.replace(/@Authority_Code/g, this["Authority_Code"]);
                ItemHtml = ItemHtml.replace(/@Size/g, this["Size"]);
                ItemHtml = ItemHtml.replace(/@ImgSrc/g, "<td class='icon' style=\"background-image:url(" + this["ImgSrc"] + ")\"><span id='sp_" + this["TableID"] + "'></span></td>");
                ItemHtml = ItemHtml.replace(/@Funid/g, this["Funid"]);
                ItemHtml = ItemHtml.replace(/@Funurl/g, this["Funurl"]);
                ItemHtml = ItemHtml.replace(/@Funname/g, this["Funname"]);
                $("#MyApp .iconarea:last").append(ItemHtml);

            }
        }
    });

    //分页加载
    //将所有的分页码都隐藏
    $("#PageDiv .pageritem").hide();
    //根据页码，控制分页table是否显示隐藏
    if (pageindex > 1 && $("#AppMenuSwitch > a").attr("name") == "all") {
        $("#PageDiv").show();
    } else {
        $("#PageDiv").hide();
    }
    //根据页码,判断显示几个分页码
    for (var i = 1; i <= pageindex; i++) {
        $("#Page" + i).show();
    }
    $("#PageDiv .pageritem").removeClass("current");
    $("#Page1").addClass("current");
    //加载拖动事件
    tuodong();
    //加载点击事件
    ShortcutMenuPageControl.SetEvent();
    ShortcutMenuPageControl.SelTypeCodeCount();
    //给要IconAreas区域宽和高
    $("#IconAreas").width($("#MyApp").outerWidth() + $("#AllApp").outerWidth() + 250);

}
//绑定代办数量
ShortcutMenuPageControl.BindShortcutCount = function (data) {
    var DataObj = $.parseJSON(data.d);
    var TaskCountHtml = "<span class=\"left\">&nbsp;</span><span class=\"right\">@Count</span>";
    var div1 = document.getElementById("kuajie").getElementsByTagName("table");
    var TableID = "";
    for (var i = 0; i < div1.length; i++) {
        var nums = 0;
        TableID = div1[i].lang.toString();
        if (TableID == "GWLZ") {  //公文流转   
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'GWLZ' || this["typecode"] == 'NBGWLZ') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#sp_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }

        }
        else if (TableID == "LDQP") {  //公文领导签批  
            nums =0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'GWLZ' || this["typecode"] == 'NBGWLZ') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#sp_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }

        } else if (TableID == "BGYPTJCK") {    //办公用品统计                
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'SPTJ' || this["typecode"] == 'SQTJ' || this["typecode"] == 'JDTJ') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#sp_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        } else if (TableID == "DAMLGL") {    //档案管理借阅待审批                
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'DASP') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#sp_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        } else if (TableID == "DAML") {    //档案查阅                
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'DAJY') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#sp_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        }
        else if (TableID == "TZGG") {    //通知公告           
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'TZGG' || this["typecode"] == 'WBTZGG') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#sp_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        }
        else {
            $(DataObj).each(function () {
                if (this["typecode"] == TableID) {
                    $("#sp_" + this["typecode"] + "").html(TaskCountHtml.replace(/@Count/g, this["nums"]));
                }
            });
        }
    }
    setTimeout("ShortcutMenuPageControl.SelTypeCodeCount()", 60000);

}
//快捷菜单待办处理
ShortcutMenuPageControl.SelTypeCodeCount = function () {
    DataControl.GetJsonDataAndExecuteFun("{}", "GetTSTypeCodeCount", "ShortcutMenuPageControl.BindShortcutCount(data)");  
}
//绑定全部应用数量
ShortcutMenuPageControl.BindAllShortcutCount = function (data) {
    var TaskCountHtml = "<span style=\"font-size:12px;color:red;\">待办@Count条</span>";
    var DataObj = $.parseJSON(data.d);
    var div1 = document.getElementById("AllApp").getElementsByTagName("span");
    var TableID = "";
    for (var i = 0; i < div1.length; i++) {
        var nums = 0;
        TableID = div1[i].id.toString().substring(3, div1[i].id.toString().length);
        if (TableID == "GWLZ") {  //公文流转   
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'GWLZ' || this["typecode"] == 'NBGWLZ') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#qb_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }

        }
        else if (TableID == "LDQP") {  //公文领导签批  
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'GWLZ' || this["typecode"] == 'NBGWLZ') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#qb_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }

        } else if (TableID == "BGYPTJCK") {    //办公用品统计                
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'SPTJ' || this["typecode"] == 'SQTJ' || this["typecode"] == 'JDTJ') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#qb_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        } else if (TableID == "DAMLGL") {    //档案管理借阅待审批                
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'DASP') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#qb_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        } else if (TableID == "DAML") {    //档案查阅                
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'DAJY') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#qb_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            }
        } 
        else if (TableID == "TZGG") {    //通知公告           
            nums = 0;
            $(DataObj).each(function () {
                if (this["typecode"] == 'TZGG'|| this["typecode"] == 'WBTZGG') {
                    nums += this["nums"];
                }
            });
            if (nums != 0) {
                $("#qb_" + TableID + "").html(TaskCountHtml.replace(/@Count/g, nums));
            } 
        } 
        else {
            $(DataObj).each(function () {
                if (this["typecode"] == TableID) {
                    $("#qb_" + this["typecode"] + "").html(TaskCountHtml.replace(/@Count/g, this["nums"]));
                }
            });
        }
    }
    setTimeout("ShortcutMenuPageControl.SelWorkItemCount()", 60000);

}
//全部菜单待办处理
ShortcutMenuPageControl.SelWorkItemCount = function () {
    DataControl.GetJsonDataAndExecuteFun("{}", "GetTSTypeCodeCount", "ShortcutMenuPageControl.BindAllShortcutCount(data)");
}

//点击事件 跳转到相应页面
ShortcutMenuPageControl.SetEvent = function () {
    /// <summary>设置各种事件</summary>
    $(".iconareas .btn").on("click", function () {
        var FunID = $(this).find("input[name=funid]").val();
        var FunUrl = $(this).find("input[name=funurl]").val();
        var FunName = $(this).find("input[name=funname]").val();
        parent.TabControl.OpenTab(FunID, FunUrl, FunName);
    });
}
var AllApplyPageIndex = 1;
var AllApplySum;
//动态获取全部应用
ShortcutMenuPageControl.GetAllApply = function () {
    /// <summary</summary>               
    DataControl.GetJsonDataAndExecuteFun("{ 'Authority_Code': '" + ShortcutMenuPageControl.SCode + "'}", "GetAllApplyByAuthority_Code", "ShortcutMenuPageControl.BindAllApplyList(data)");
}
ShortcutMenuPageControl.BindAllApplyList = function (data) {
    //记录分类模块是否被添加过（全部应用的大分组 标题）
    var GwCount = 0; //公文
    var DaCount = 0; //档案
    var GzCount = 0; //工资
    var JyCount = 0; //机要文件
    var HysCount = 0; //会议室
    var BgypCount = 0; //办公用品
    var ClCount = 0; //车辆
    var FzgjCount = 0; //辅助工具

    var DataObj = $.parseJSON(data.d);
    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();

    //计算空白区域的宽
    var MainNavWidth = HolePageWidth - $("#TodayInfo").width() - 120;
    //计算空白区域的高
    var MainNavHeight = $("#TodayInfo").height() - 60;
    //给要操作区域宽和高
    $("#AllApp").width(MainNavWidth).height(MainNavHeight);
    //计算宽度能放几个图标
    var NumberWidth = Math.floor(MainNavWidth / 150);
    $("#LeiShu").val(NumberWidth);
    //计算高度能放几个图标
    AllApplySum = Math.floor(MainNavHeight / 30);
    var myDate = new Date();
    $(DataObj).each(function (index) {
        if (AllApplySum <= 0) {
            AllApplyNextLie();
        }
        var HtmlTemplates = "<table id=\"@ApplyType\"><tr><td class=\"iconarea_title\" colspan=\"2\">@ApplyTypeName</td></tr><tr><td><table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table></td></tr></table>";

        var ItemHtmls = HtmlTemplates;
        ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
        ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
        ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
        ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
        ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
        ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
        ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
        ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
        ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);  //一级模块名称

        //判断类型根据类型，往适合的位置填入数据
        switch (this["ApplyType"].toString()) {
            case "1":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "2":
                if (GwCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    GwCount++;


                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;
            case "3":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "4":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }
                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "5":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "6":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "7":
                if (ClCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    ClCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }

                break;
            case "8":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "9":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "10":
                AllApplySum = AllApplySum - 3;
                if (AllApplySum < 0) {
                    AllApplyNextLie();
                    AllApplySum = AllApplySum - 3;
                }

                $("#AllApp .iconarea_all:last").append(ItemHtmls);
                break;
            case "11":
                if (DaCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }
                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    DaCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;
            case "12":
                if (GzCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    GzCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;
            case "13":
                if (BgypCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    BgypCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;
            case "14":
                if (JyCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    JyCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;
            case "15":
                if (HysCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    HysCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;

            case "16":
                if (FzgjCount == 0) {
                    //题头为1，下面的每个图标为2
                    AllApplySum = AllApplySum - 3;
                    if (AllApplySum < 0) {
                        AllApplyNextLie();
                        AllApplySum = AllApplySum - 3;
                    }

                    $("#AllApp .iconarea_all:last").append(ItemHtmls);
                    FzgjCount++;
                } else {
                    //如果这个table已经到了下一个td就不减数量
                    if (!(Math.floor(MainNavHeight / 30) == AllApplySum)) {
                        AllApplySum = AllApplySum - 2;
                    }
                    HtmlTemplatess = "<table oncontextmenu=\"RightClick('@Authority_Code'); return false;\" runat=\"server\" cellpadding=\"0\" cellspacing=\"0\" class=\"@ClassName\"  id=\"@TableID\"><tr><td class=\"icon\"><img src=\"@ImgSrc\" /></td><td class=\"funcname\">@Funname<input name=\"funid\" type=\"hidden\" value=\"@Funid\" /><input name=\"funurl\" type=\"hidden\" value=\"@Funurl\" /><input name=\"funname\" type=\"hidden\" value=\"@Funname\" /></td></tr></table>";
                    ItemHtmls = HtmlTemplatess;
                    ItemHtmls = ItemHtmls.replace(/@TableID/g, this["TableID"]);
                    ItemHtmls = ItemHtmls.replace(/@ClassName/g, "btn s " + this["ClassName"]);
                    ItemHtmls = ItemHtmls.replace(/@Authority_Code/g, this["Authority_Code"]);
                    ItemHtmls = ItemHtmls.replace(/@ImgSrc/g, this["ImgSrc"]);
                    ItemHtmls = ItemHtmls.replace(/@Funid/g, this["Funid"]);
                    ItemHtmls = ItemHtmls.replace(/@Funurl/g, this["Funurl"]);
                    ItemHtmls = ItemHtmls.replace(/@Funname/g, this["Funname"] + "<br/><span id='qb_" + this["TableID"] + "'></span>");
                    ItemHtmls = ItemHtmls.replace(/@ApplyType/g, this["ApplyType"]);
                    ItemHtmls = ItemHtmls.replace(/@ApplyTypeName/g, this["ApplyTypeName"]);
                    $("#" + this["ApplyType"] + ">tbody >tr:last >td:last").append(ItemHtmls);
                }
                break;
        }
    });

    $("#AllApplyPage .pageritem").hide();
    $("#AllApp .iconarea_all").hide();

    //判断全部应用进行分页
    var AllPageIndex = Math.ceil(AllApplyPageIndex / NumberWidth);
    for (var i = 1; i <= AllPageIndex; i++) {
        $("#AllApply" + i).show();

    }
    //获取全部应用的页码
    $("#AllApplyPageCount").val(AllPageIndex.toString());
    //判断是否大于一页和
    if (AllPageIndex > 1 && $("#AppMenuSwitch > a").attr("name") != "all") {
        $("#AllApplyPage").show();
    } else {
        $("#AllApplyPage").hide();
    }
    for (var i = 1; i <= NumberWidth; i++) {
        $("#AllApp .iconarea_all:nth-child(" + i + ")").show();
    }

    $("#AllApplyPage .pageritem").removeClass("current");
    $("#AllApply1").addClass("current");

    ShortcutMenuPageControl.SetEvent();
    ShortcutMenuPageControl.SelWorkItemCount();
    //给要IconAreas区域宽和高
    $("#IconAreas").width($("#MyApp").outerWidth() + $("#AllApp").outerWidth() + 250);
};
function AllApplyNextLie() {
    //计算空白区域的高
    var MainNavHeight = $("#TodayInfo").height() - 60;
    var HolePageWidth = $(window).width();
    //计算空白区域的宽
    var MainNavWidth = HolePageWidth - $("#TodayInfo").width() - 120;
    var NumberWidth = Math.floor(MainNavWidth / 180);
    $("#AllApp .iconarea_all:last").after("<td class=\"iconarea_all\" style=\"float:left\"></td>");
    AllApplySum = Math.floor(MainNavHeight / 30);
    //    AllApplySum = AllApplySum - 2;
    AllApplyPageIndex++;
    //记录当前页码
    $("#AllApplyPageIndex").val(AllApplyPageIndex.toString());
}
//分页控制显示隐藏的快捷菜单
function PageShortcutMenu(Obj) {
    var curPageIndex = $(Obj).attr("data-page");

    $("#MyApp .iconarea").hide();
    $("#MyApp .iconarea:nth-child(" + $(Obj).attr("data-page") + ")").show();
    $("#PageIndex").val(curPageIndex)

    $("#PageDiv .pageritem").removeClass("current");
    $("#Page" + curPageIndex).addClass("current");
}
//全部应用分页
function PageAllApply(Obj) {
    $("#AllApp .iconarea_all").hide();
    var curPageIndex = parseInt($(Obj).attr("data-page"));
    var LieShu = curPageIndex * parseInt($("#LeiShu").val());
    for (var i = LieShu; i > (curPageIndex - 1) * parseInt($("#LeiShu").val()); i--) {
        $("#AllApp .iconarea_all:nth-child(" + i + ")").show();
    }
    $("#AllApplyPage .pageritem").removeClass("current");
    $("#AllApply" + curPageIndex).addClass("current");

}
//在全部应用中右键弹出操作快捷菜单DIV
function RightClick(PowerCode) {
    $.ajax({
        type: "GET",
        url: "MyDesk.aspx/IfExistence",
        data: "{'PowerCode':'" + PowerCode + "'}",
        contentType: "application/json;charset=utf-8", // 这句可不要忘了。
        dataType: "json",
        success: function (res) {
            if (res.d) {
                $("#ShortcutMenu").fadeIn();
                $("#tishi").text("它已经在您的快捷菜单了");
                $("#tishi").show();
                $("#AddMenu").hide();
            } else {
                $("#ShortcutMenu").fadeIn();
                $("#tishi").hide();
                $("#AddMenu").show();
            }
        },
        error: function (xmlReq, err, c) {
            //                        alert("error:" + err)
        }
    });
    $("#DelMenu").hide();
    $("#EnidMenu").hide();
    $("#TopIndex").hide();
    $("#ButtomIndex").hide();

    $("#PowerCode").val(PowerCode);
}

//在快捷菜单中右键操作快捷菜单中的项
function EnitShortcutMenu(PowerCode, Size) {
    if (Size == "1") {
        $("#EnidMenu").text("图标变小");
    } else {
        $("#EnidMenu").text("图标变大");
    }
    if (PowerCode.toString() == "RCGLCK" || PowerCode.toString() == "LDQP") {
        $("#EnidMenu").hide();
    }
    $("#ShortcutMenu").fadeIn();
    $("#tishi").hide();
    $("#AddMenu").hide();
    $("#DelMenu").show();
    $("#EnidMenu").show();
    $("#TopIndex").show();
    $("#ButtomIndex").show();
    $("#PowerCode").val(PowerCode);
    $("#Size").val(Size);
}
//添加到快捷菜单
function AddShortcutMenu() {
    var PowerCode = $("#PowerCode").val();
    $.ajax({
        type: "Post",
        url: "MyDesk.aspx/RightClick",
        data: "{'PowerCode':'" + PowerCode + "'}",
        contentType: "application/json;charset=utf-8", // 这句可不要忘了。
        dataType: "json",
        success: function (res) {
            //                    alert(res.d);
            $("#kuajie").html(" <td class=\"iconarea\"></td>");
            ShortcutMenuPageControl.getShortcutMenuFirst();
            $("#ShortcutMenu").fadeOut();
        },
        error: function (xmlReq, err, c) {
            //                        alert("error:" + err)
        }
    });
}
//删除快捷菜单
function DelShortcutMenu() {
    var PowerCode = $("#PowerCode").val();
    $.ajax({
        type: "Post",
        url: "MyDesk.aspx/DelShortcutMenu",
        data: "{'PowerCode':'" + PowerCode + "'}",
        contentType: "application/json;charset=utf-8", // 这句可不要忘了。
        dataType: "json",
        success: function (res) {
            //                    alert(res.d);
            $("#kuajie").html(" <td class=\"iconarea\"></td>");
            ShortcutMenuPageControl.getShortcutMenuFirst();
            $("#ShortcutMenu").fadeOut();
        },
        error: function (xmlReq, err, c) {
            //                        alert("error:" + err)
        }
    });
}
//改变大小图标
function ChangeSize() {
    var size = $("#Size").val().toString();

    var PowerCode = $("#PowerCode").val();
    if (size == "1") {
        $("#Size").val("0");
        size = 0;
    } else {
        $("#Size").val("1");
        size = 1;
    }
    if (PowerCode == "RCGLCK"||PowerCode=="LDQP") {
        alert('该模块图标禁止变小');
    } else {
        $.ajax({
            type: "Post",
            url: "MyDesk.aspx/ChangeSizeImg",
            data: "{'PowerCode':'" + PowerCode + "','Size':'" + size + "'}",
            contentType: "application/json;charset=utf-8", // 这句可不要忘了。
            dataType: "json",
            success: function (res) {
                //                    alert(res.d);
                $("#kuajie").html(" <td class=\"iconarea\"></td>");
                ShortcutMenuPageControl.getShortcutMenuFirst();
                $("#ShortcutMenu").fadeOut();
                //                    tuodong();
            },
            error: function (xmlReq, err, c) {
                //                    alert("error:" + err)
            }
        });
    }
}
//关闭右键菜单选项
function guanbi() {
    $("#ShortcutMenu").fadeOut();
}
//添加拖动效果
function tuodong() {
    $("#kuajie .iconarea").sortable({
        update: function (event, ui) {
            var div1 = document.getElementById("kuajie").getElementsByTagName("table");
            var SortCode = "";
            for (var i = 0; i < div1.length; i++) {
                SortCode += div1[i].id.toString() + ",";
            }
            $.ajax({
                type: "Post",
                url: "MyDesk.aspx/SortUpdate",
                data: "{'SortCode':'" + SortCode + "'}",
                contentType: "application/json;charset=utf-8", // 这句可不要忘了。
                dataType: "json",
                success: function (res) {
                    $("#kuajie .iconarea").sortable("disable");
                    $("#kuajie").html(" <td class=\"iconarea\"></td>");
                    ShortcutMenuPageControl.getShortcutMenuFirst();
                    $("#ShortcutMenu").fadeOut();
                },
                error: function (xmlReq, err, c) {
                    //                            alert("error:" + err)
                }
            });
        }
    });
    $("#kuajie .iconarea").disableSelection();
}
//上一页
function TopPageIndex() {
    //权限编码
    var PowerCode = $("#PowerCode").val();

    //一共有几页
    var pageindexcount = parseInt($("#PageIndexCount").val());
    //一页有能放多少小图标
    var pagecount = parseInt($("#PageCount").val());
    //当前页码
    var pageindex = parseInt($("#PageIndex").val());
    if (pageindex == 1) {
        alert("已经是首页了");
    } else {
        var SortCode = pagecount * (pageindex - 1) - 1;
        if (pageindexcount.toString() != "" && pageindex.toString() != "") {
            $.ajax({
                type: "Post",
                url: "MyDesk.aspx/TopButtomPageUpdate",
                data: "{'SortCode':" + SortCode + ",'PowerCode':'" + PowerCode + "'}",
                contentType: "application/json;charset=utf-8", // 这句可不要忘了。
                dataType: "json",
                success: function (res) {
                    //alert(res.d);
                    $("#kuajie .iconarea").sortable("disable");
                    $("#kuajie").html(" <td class=\"iconarea\"></td>");
                    ShortcutMenuPageControl.getShortcutMenuFirst();
                    $("#ShortcutMenu").fadeOut();
                },
                error: function (xmlReq, err, c) {
                    //                            alert("error:" + err)
                }
            });
        }
    }

}
//下一页
function ButtomPageIndex() {
    //权限编码
    var PowerCode = $("#PowerCode").val();
    //一共有几页
    var pageindexcount = parseInt($("#PageIndexCount").val());
    //一页有能放多少小图标
    var pagecount = parseInt($("#PageCount").val());
    //当前页码
    var pageindex = parseInt($("#PageIndex").val());
    if (pageindex == pageindexcount) {
        alert("已经是尾页了");
    } else {
        var SortCode = pagecount * (pageindex + 1) - 1;
        if (pageindexcount.toString() != "" && pageindex.toString() != "") {
            $.ajax({
                type: "Post",
                url: "MyDesk.aspx/TopButtomPageUpdate",
                data: "{'SortCode':" + SortCode + ",'PowerCode':'" + PowerCode + "'}",
                contentType: "application/json;charset=utf-8", // 这句可不要忘了。
                dataType: "json",
                success: function (res) {
                    //alert(res.d);
                    $("#kuajie .iconarea").sortable("disable");
                    $("#kuajie").html(" <td class=\"iconarea\"></td>");
                    ShortcutMenuPageControl.getShortcutMenuFirst();
                    $("#ShortcutMenu").fadeOut();

                },
                error: function (xmlReq, err, c) {
                    //                            alert("error:" + err)
                }
            });
        }
    }
}
