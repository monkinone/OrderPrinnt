/// <reference path="../JQuery/jquery-1.9.1.js" />

$(function () {
    TabControl.AddClickEvent();
});

/// <summary>首页Tab页控制类</summary>
TabControl = {};

TabControl.AddClickEvent = function () {
    /// <summary>为Tab添加点击事件</summary>
    $("#TabBar > ul > li").on("click", function () {
        TabControl.ActiveTab($(this).attr("name"));
    });
}

TabControl.HasTab = function (FunID) {
    /// <summary>检查是否已经打开Tab</summary>
    /// <param name="FunID" type="String">功能点ID</param>
    return $("#TabBar > ul").find(">li[name=" + FunID + "]").attr("name") != undefined;
}

TabControl.ActiveTab = function (FunID) {
    /// <summary>激活指定的Tab</summary>
    /// <param name="FunID" type="String">功能点ID</param>

    $("#TabBar > ul > li").removeClass("current");
    $("#MainArea > iframe").removeClass("current");

    $("#TabBar > ul").find(">li[name=" + FunID + "]").addClass("current");
    $("#MainArea").find("> iframe[name=iframe_" + FunID + "]").addClass("current");
}


TabControl.AddTab = function (FunID, FunUrl, FunName) {
    /// <summary>打开一个Tab页，若已存在则跳转至该Tab页</summary>
    /// <param name="FunID" type="String">功能点ID</param>
    /// <param name="FunUrl" type="String">功能点地址</param>
    /// <param name="FunName" type="String">功能点名称</param>

    var TabCloseBtnTemplate = '<img alt="关闭" class="close" src="' + Comm.DefaultImageFolder + '/btn/btn_close_tab_n.png" />';
    var TabTemplate = '<li name="' + FunID + '" class="item"><table cellpadding="0" cellspacing="0"><tr><td>' + FunName + '</td><td>' + TabCloseBtnTemplate + '</td></tr></li>';
    var IFrameTemplate = '<iframe name="iframe_' + FunID + '" scrolling="no" width="100%" src="' + FunUrl + '"></iframe>';

    $("#TabBar > ul").append(TabTemplate);
    $("#TabBar > ul > li[name=" + FunID + "] .close").on("click", function () {
        if ($(this).parents("li").hasClass("current")) {
            TabControl.ActiveTab($(this).parents("li").prev("li").attr("name"));
        }
        TabControl.CloseTab(FunID);
    });
    TabControl.AddClickEvent();

    $("#MainArea").append(IFrameTemplate);

    $("#MainArea > iframe").height($("#MainArea").height());

    TabControl.ActiveTab(FunID);
}

TabControl.OpenTab = function (FunID, FunUrl, FunName) {
    /// <summary>打开一个Tab页，若已存在则跳转至该Tab页</summary>
    /// <param name="FunID" type="String">功能点ID</param>
    /// <param name="FunUrl" type="String">功能点地址</param>
    /// <param name="FunName" type="String">功能点名称</param>
    if (TabControl.HasTab("tab_" + FunID)) {
        TabControl.ActiveTab("tab_" + FunID);
    } else {
        TabControl.AddTab("tab_" + FunID, FunUrl, FunName);
    }
}

TabControl.CloseTab = function (FunID) {
    /// <summary>关闭Tab</summary>
    /// <param name="FunID" type="String">功能点ID</param>
    $("#TabBar > ul").find(">li[name=" + FunID + "]").remove();
    $("#MainArea").find("> iframe[name=iframe_" + FunID + "]").remove();
}

TabControl.ReflushCurrentList = function () {
    var Iframe = frames[$("#MainArea").find("> iframe.current").attr("name")];
    if (Iframe.ListPageControl != undefined) {
        if ($.isFunction(Iframe.ListPageControl.ReflushList)) {
            Iframe.ListPageControl.ReflushList();
        }
    }
}

TabControl.RemoveItem = function (Id, TypeCode) {
    /// <summary>移除已处理的待办事项</summary>
    /// <param name="Id" type="String">事件ID</param>
    /// <param name="TypeCode" type="String">事件类型代码</param>
    var Iframe = frames["iframe_tab_00"];

    if (Iframe.MyDeskControl != undefined) {
        if ($.isFunction(Iframe.MyDeskControl.RemoveItem)) {
            Iframe.MyDeskControl.RemoveItem(Id, TypeCode);
        }
    }
}