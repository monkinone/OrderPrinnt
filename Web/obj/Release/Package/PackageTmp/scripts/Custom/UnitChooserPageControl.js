﻿/// <reference path="../JQuery/jquery-1.7.2.js" />
/// <reference path="BoxControl.js" />
/// <reference path="Config.js" />

$(function () {
    UnitChooserPageControl.SetEveryView("All");
});

UnitChooserPageControl = {}
UnitChooserPageControl.DefaultImageFolder = Config.DefaultImageFolder;
UnitChooserPageControl.QueryAreaWidthMinWidth = 470;

UnitChooserPageControl.SetEveryView = function (AreaID) {
    /// <summary>设置页面中所有元素样式，</summary>
    UnitChooserPageControl.SetEveryAreaSize();
    UnitChooserPageControl.SetStyle(AreaID);
}

UnitChooserPageControl.SetEveryAreaSize = function () {
    /// <summary>设置本页面各个区域尺寸</summary>

    var HolePageHeight = $(window).height();
    var HolePageWidth = $(window).width();
    var OptBarHeight = $("#OptBar").outerHeight();
    var SelectedUserAreaWidth = HolePageWidth - $(".treef").outerWidth() - $(".userlistf").outerWidth() - 18;

    $(".treef").height(HolePageHeight - OptBarHeight);
    $(".userlistf").height(HolePageHeight - OptBarHeight);
    $(".selecteduserf").height(HolePageHeight - OptBarHeight);
    $(".selecteduserf").width(SelectedUserAreaWidth);

}

UnitChooserPageControl.SetStyle = function (AreaID) {
    /// <summary>
    /// 1.为所有class中包含btn的按钮设置划过样式
    /// 2.设置所有的Select样式</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>

    UnitChooserPageControl.SetStyleForBtn(AreaID);   //为所有class中包含btn的按钮设置划过样式

    $("table").find("tr:even").addClass("even");
    $("table").find("tr:odd").addClass("odd");
}

UnitChooserPageControl.SetStyleForBtn = function (AreaID) {
    /// <summary>设置Class包含btn的input样式</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>
    $(AreaID == "All" ? ".btn" : "#" + AreaID + " .btn").each(function () {
        var BtnName = $(this).attr("src");
        if (BtnName != undefined && BtnName.indexOf("/") < 0) {
            var NormalImg = UnitChooserPageControl.DefaultImageFolder + "/btn/" + BtnName + "_n.png";
            var HoverImg = UnitChooserPageControl.DefaultImageFolder + "/btn/" + BtnName + "_h.png";

            $(this).attr("src", NormalImg);
            $(this).hover(
                function () { $(this).attr("src", HoverImg); },
                function () { $(this).attr("src", NormalImg); }
            );
        }
    });
}

UnitChooserPageControl.ReturnValues = function () {
    /// <summary>回传值</summary>

    var IDs = $("#HF_IDs").val();
    var Names = $("#HF_Names").val();

    parent.$("#" + $("#HF_UnitIDsControlID").val()).val(IDs);
    parent.$("#" + $("#HF_UnitNamesControlID").val()).val(Names);

    UnitChooserPageControl.CloseBox();
}

UnitChooserPageControl.CloseBox = function () {
    /// <summary>关闭弹出的窗口</summary>
    parent.BoxControl.Close();
}

UnitChooserPageControl.LoadAdded = function () {
    /// <summary>加载父页面已经选中的数据</summary>
    var IDs = parent.$("#" + $("#HF_UnitIDsControlID").val()).val();
    var Names = parent.$("#" + $("#HF_UnitNamesControlID").val()).val();
    $("#HF_IDs").val(IDs);
    $("#HF_Names").val(Names);
    $("#Btn_LoadAdded").click();
}
