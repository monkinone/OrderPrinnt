/// <reference path="../JQuery/jquery-1.7.2.js" />
/// <reference path="Config.js" />


var PersonInfoSettingsControl = {};
PersonInfoSettingsControl.HolePageWidth = 0;
PersonInfoSettingsControl.CurrentFunID = "";
PersonInfoSettingsControl.CurrentFunName = "";

$(function () {
    PersonInfoSettingsControl.ResizeWindow();
    PersonInfoSettingsControl.SetStyle();
    PersonInfoSettingsControl.InitAnchor();
});

PersonInfoSettingsControl.InitAnchor = function () {
    $("#SettingArea").find(".title[data-id]").each(
        function () {
            var LinkName = $(this).attr("data-name");
            var LinkID = $(this).attr("data-id");
            var AnchorHtml = "<a name='" + LinkID + "'></a>";
            var ButtonHtml = "<a class='link' title='" + LinkName + "'>" + LinkName + "</a>";
            $("#SelectArea").append(ButtonHtml);
            $(this).append(AnchorHtml);
        }
    );

    $("#SelectArea").find("a.link").each(function () {
        $(this).on("click", function () {
            $("#SelectArea").find("a.link").removeClass("current");
            $(this).addClass("current");
        });
    });
}

PersonInfoSettingsControl.ResizeWindow = function () {
    /// <summary>改变窗口大小</summary>
    PersonInfoSettingsControl.HolePageWidth = $(window).width();
    var SelectAreaWidth = $("#SelectArea").outerWidth();

    $("#SettingArea").width(PersonInfoSettingsControl.HolePageWidth - SelectAreaWidth);
}

PersonInfoSettingsControl.SetStyle = function () {
    /// <summary>设置样式</summary>
    PersonInfoSettingsControl.SetStyleForBtn();
}

PersonInfoSettingsControl.SetStyleForBtn = function () {
    /// <summary>设置按钮样式</summary>
    $(".btn").each(function () {
        var BtnName = $(this).attr("src");
        var NormalImg = Config.DefaultImageFolder + "/btn/" + BtnName + "_n.png";
        var HoverImg = Config.DefaultImageFolder + "/btn/" + BtnName + "_h.png";

        $(this).attr("src", NormalImg);
        $(this).hover(
            function () { $(this).attr("src", HoverImg); },
            function () { $(this).attr("src", NormalImg); }
        );
    });
}