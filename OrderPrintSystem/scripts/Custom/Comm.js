/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="Config.js" />
/// <reference path="BoxControl.js" />
/// <reference path="DataControl.js" />


var Comm = {};
Comm.HolePageHeight = 0;
Comm.TopAreaHeight = 0;
Comm.TabBarHeight = 0;
Comm.FootAreaHeight = 0;
Comm.DefaultImageFolder = Config.DefaultImageFolder;

$(function () {
    Comm.ResizeWindow();
});

Comm.ResizeWindow = function () {
    Comm.HolePageHeight = $(window).height();
    Comm.TopAreaHeight = $("#TopArea").is(":visible") ? $("#TopArea").height() : 0;
    Comm.TabBarHeight = $("#TabBar").is(":visible") ? $("#TabBar").height() : 0;
    Comm.FootAreaHeight = $("#FootArea").is(":visible") ? $("#FootArea").height() : 0;

   // $("#MainArea").height(Comm.HolePageHeight - Comm.TopAreaHeight - Comm.TabBarHeight - Comm.FootAreaHeight);
    //$("#MainArea > iframe").height($("#MainArea").height());

}
