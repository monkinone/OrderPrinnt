/// <reference path="../JQuery/jquery-1.9.1.js" />

$(function () {
  //  PageControl.SetEveryView("All");
});

var PageControl = {};
PageControl.DefaultImageFolder = "/themes/default/images";
PageControl.QueryAreaWidthMinWidth = 470;
PageControl.ReflushListBtnID = "";

PageControl.SetEveryView = function (AreaID) {
    /// <summary>设置页面中所有元素样式，</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>
//    PageControl.SetEveryAreaSize();
  //  PageControl.SetStyle(AreaID);

}

PageControl.SetEveryAreaSize = function () {
    /// <summary>设置本页面各个区域尺寸</summary>

    var HolePageWidth = $(window).width();
    var QueryAreaWidth = HolePageWidth * .3;

    if ($("#QueryArea").length > 0) {
        QueryAreaWidth = QueryAreaWidth < PageControl.QueryAreaWidthMinWidth ? PageControl.QueryAreaWidthMinWidth : QueryAreaWidth;
        $("#QueryArea").width(QueryAreaWidth);
    } else {
        QueryAreaWidth = 0;
    }
    var ListAreaWidth = $(window).width() - QueryAreaWidth;
    $("#ListArea").width(ListAreaWidth);
}

PageControl.ResizeWindow = function () {
    /// <summary>本页面窗口大小改变事件</summary>
  //  PageControl.SetEveryAreaSize();
}

PageControl.SetStyle = function (AreaID) {
    /// <summary>
    /// 1.为所有class中包含btn的按钮设置划过样式
    /// 2.设置所有的Select样式</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>

    PageControl.SetStyleForBtn(AreaID);   //为所有class中包含btn的按钮设置划过样式
    $((AreaID == "All" ? "select" : "#" + AreaID + " select") + "[addselecter!=true]").selecter().attr("addselecter", "true");     //设置所有的Select样式

    if (typeof (TableControl) != "undefined" && $.isFunction(TableControl.SetStyle)) {
        TableControl.SetStyle();
    }
}

PageControl.SetStyleForBtn = function (AreaID) {
    /// <summary>设置Class包含btn的input样式</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>
    $(AreaID == "All" ? ".btn" : "#" + AreaID + " .btn").each(function () {
        var BtnName = $(this).attr("src");
        if (BtnName != undefined && BtnName.indexOf("/") < 0) {
            var NormalImg = PageControl.DefaultImageFolder + "/btn/" + BtnName + "_n.png";
            var HoverImg = PageControl.DefaultImageFolder + "/btn/" + BtnName + "_h.png";

            $(this).attr("src", NormalImg);
            $(this).hover(
                function () { $(this).attr("src", HoverImg); },
                function () { $(this).attr("src", NormalImg); }
            );
        }
    });

    try {
        DateControl.init("Wdate");
    }
    catch (e) { }
}

PageControl.OpenBox = function (Url, Title, Width, Height) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Height">弹出框高度</param>
    parent.BoxControl.Show(Url, Title, Width, Height);
}

PageControl.CloseBox = function () {
    /// <summary>关闭弹出的窗口</summary>
    parent.BoxControl.Close();
}

PageControl.ReflushList = function () {
    /// <summary>刷新列表</summary>
    //alert(PageControl.ReflushListBtnID);
    $("#" + PageControl.ReflushListBtnID).click();
    
}