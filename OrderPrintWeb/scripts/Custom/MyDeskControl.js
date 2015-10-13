/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="Config.js" />
/// <reference path="DataControl.js" />

var MyDeskControl = {};
MyDeskControl.DefaultImageFolder = "/themes/default/images";

$(function () {
    $("#MainNav").hide();
    $("#TodayInfo").hide();

    MyDeskControl.SetEveryAreaSize();
    MyDeskControl.SetEvent();
    // MyDeskControl.SetStyle();
    MyDeskControl.SetStyleForBtn();

    //MyDeskControl.GetCurrentPrivileges();
});

MyDeskControl.GetCurrentPrivileges = function () {
    /// <summary>获取当前用户的所有功能点</summary>
    //DataControl.GetDataAndExecuteFun("{ 'userid': '3' }", "getUserAllPrivilege", "test(data)");
}

function test(data) {
    var dataObj = eval("(" + data.d + ")");
    $.each(dataObj, function (idx, item) {
        // alert(item.MENU_URL);
    });
}

MyDeskControl.SetStyle = function () {
    /// <summary>设置各种样式</summary>
    //    $("#MainNav").scroller({
    //        horizontal: true
    //    });

    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();
    var IconAreasWidth = HolePageWidth - $("#TodayInfo").width();

    $(".icontable").each(function (index) {
        $(this).css("marginRight", 0);
        if (IconAreasWidth > $(this).outerWidth(true)) {
            $(this).css("marginRight", IconAreasWidth - $(this).outerWidth(true));
        } else {
            $(this).css("marginRight", 20);
        }
    });

    $("#IconAreas").width($(".icontable").length * IconAreasWidth);
}

MyDeskControl.SetStyleForBtn = function () {
    /// <summary>设置Class包含btn的input样式</summary>
    $(".btn").each(function () {
        var BtnName = $(this).attr("src");
        if (BtnName != undefined && BtnName.indexOf("/") < 0) {
            var NormalImg = MyDeskControl.DefaultImageFolder + "/btn/" + BtnName + "_n.png";
            var HoverImg = MyDeskControl.DefaultImageFolder + "/btn/" + BtnName + "_h.png";

            $(this).attr("src", NormalImg);
            $(this).hover(
                function () { $(this).attr("src", HoverImg); },
                function () { $(this).attr("src", NormalImg); }
            );
        }
    });
}


MyDeskControl.SetEveryAreaSize = function () {
    /// <summary>设置本页面各个区域尺寸</summary>
    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();

    var TodayInfoWidth = HolePageWidth * .4;
    var MainNavWidth = HolePageWidth - TodayInfoWidth;
    $("#TodayInfo").width(TodayInfoWidth);
    $("#MainNav").width(MainNavWidth);
    $("#MainNav").height(HolePageHeight);
    $("#MainNav .pagearea").css("left", MainNavWidth / 2 - $("#MainNav .pagearea").outerWidth() + "px");

    $("#ShortcutMenu").width(MainNavWidth);

    var MainNavHeight = $("#MainNav").height();

    $("#MainNav").show();
    $("#TodayInfo").show();

}


MyDeskControl.SetEvent = function () {
    /// <summary>设置各种事件</summary>

    $(".iconareas  .btn").on("click", function () {
        var FunID = $(this).find("input[name=funid]").val();
        var FunUrl = $(this).find("input[name=funurl]").val();
        var FunName = $(this).find("input[name=funname]").val();

        parent.TabControl.OpenTab(FunID, FunUrl, FunName);
    });
}

MyDeskControl.ResizeWindow = function () {
    /// <summary>本页面窗口大小改变事件</summary>
    MyDeskControl.SetEveryAreaSize();
    MyDeskControl.SetStyle();
}

MyDeskControl.RemoveItem = function (Id, TypeCode) {
    /// <summary>移除已处理的待办事项</summary>
    /// <param name="Id" type="String">事件ID</param>
    /// <param name="TypeCode" type="String">事件类型代码</param>

    var Iframe = frames[$("#TodayFrame").attr("name")];

    if ($.isFunction(Iframe.WorkItemPageControl.RemoveItem)) {
        Iframe.WorkItemPageControl.RemoveItem(Id, TypeCode);
    }
}

MyDeskControl.AppMenuSwitchClick = function (Obj) {
    var HolePageWidth = $(window).width();
    var IconAreasWidth = HolePageWidth - $("#TodayInfo").width();
    $("#ShortcutMenu").fadeOut();
    if ($(Obj).attr("name") == "all") {
        $("#IconAreas").animate({
            left: 0 - IconAreasWidth
        });
        $(Obj).html("快捷菜单");
        $(Obj).attr("title","快捷菜单");
        $("#PageDiv").hide();
        $(Obj).attr("name", "my");
        if (parseInt($("#AllApplyPageCount").val()) == 1) {
            $("#AllApplyPage").hide();
        } else {
            $("#AllApplyPage").show();
         }

    } else {
        $("#IconAreas").animate({
            left: 0
        });
        $(Obj).html("全部应用");
        $(Obj).attr("title", "全部应用");
        if (parseInt($("#PageIndexCount").val()) == 1) {
            $("#PageDiv").hide();
        } else {
            $("#PageDiv").show();
        }

        $(Obj).attr("name", "all");
        $("#AllApplyPage").hide();
    }
}

