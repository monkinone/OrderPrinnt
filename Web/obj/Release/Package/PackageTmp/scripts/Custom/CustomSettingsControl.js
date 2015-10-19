/// <reference path="../JQuery/jquery-1.9.1.js" />


var CustomSettingsControl = {};
CustomSettingsControl.HolePageHeight = 0;
CustomSettingsControl.TabBarHeight = 0;
CustomSettingsControl.DefaultImageFolder = "/themes/default/images";

$(function () {
    CustomSettingsControl.ResizeWindow();
    CustomSettingsControl.SetStyle();
    CustomSettingsControl.SetTabEvent();
});

CustomSettingsControl.ResizeWindow = function () {
    /// <summary>窗口大小改变时事件</summary>
    CustomSettingsControl.HolePageHeight = $(window).height();
    CustomSettingsControl.TabBarHeight = $("#TabBar").is(":visible") ? $("#TabBar").height() : 0;

    $("#MainArea").height(CustomSettingsControl.HolePageHeight - CustomSettingsControl.TabBarHeight);
    $("#MainArea > iframe").height($("#MainArea").height());

}

CustomSettingsControl.SetStyle = function () {
    /// <summary>设置样式</summary>   
    CustomSettingsControl.SetStyleForBtn();
}

CustomSettingsControl.SetStyleForBtn = function () {
    /// <summary>为按钮设置样式</summary>
    $(".btn").each(function () {
        var BtnName = $(this).attr("src");
        var NormalImg = CustomSettingsControl.DefaultImageFolder + "/btn/" + BtnName + "_n.png";
        var HoverImg = CustomSettingsControl.DefaultImageFolder + "/btn/" + BtnName + "_h.png";

        $(this).attr("src", NormalImg);
        $(this).hover(
            function () { $(this).attr("src", HoverImg); },
            function () { $(this).attr("src", NormalImg); }
        );
    });
}

CustomSettingsControl.SetTabEvent = function () {
    /// <summary>为Tab绑定事件</summary>
    $("#TabBar li").on("click", function () {
        var DataID = $(this).attr("data-id");
        CustomSettingsControl.ActiveTab(DataID);
    });

    CustomSettingsControl.ActiveTab($("#TabBar li:first").attr("data-id"));
}

CustomSettingsControl.ActiveTab = function (DataID) {
    /// <summary>激活Tab</summary>
    /// <param name="DataID" type="String">TabID</param>
    $("#TabBar li").removeClass("current");
    $("#TabBar li[data-id=" + DataID + "]").addClass("current");
    var CurrentIFrameSrc = $("#TabBar li.current a").attr("name");

    var CurrentIFrame = $("#MainArea").find("> #iframe_" + DataID);
    $("#MainArea > iframe").removeClass("current");
    if (CurrentIFrame.length <= 0) {
        $("#MainArea").append("<iframe class='iframe' id='iframe_" + DataID + "' width='100%' scrolling='no' frameborder='0'></iframe>");
    }

    CurrentIFrame = $("#MainArea").find("> #iframe_" + DataID);
    CustomSettingsControl.ResizeWindow();
    CurrentIFrame.attr("src", CurrentIFrameSrc);
    CurrentIFrame.addClass("current");
}

CustomSettingsControl.CloseBox = function () {
    /// <summary>关闭弹出的窗口</summary>
    parent.BoxControl.Close();
}
