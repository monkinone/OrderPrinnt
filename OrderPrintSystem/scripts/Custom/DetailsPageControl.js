/// <reference path="../JQuery/jquery-1.7.2.js" />
/// <reference path="BoxControl.js" />
/// <reference path="Config.js" />

$(function () {
    DetailsPageControl.SetEveryView("All");
    DetailsPageControl.AddAttachmentClick();
});

DetailsPageControl = {}
DetailsPageControl.DefaultImageFolder = "/themes/default/images";
DetailsPageControl.QueryAreaWidthMinWidth = 470;

DetailsPageControl.SetEveryView = function (AreaID) {
    /// <summary>设置页面中所有元素样式，</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>
    DetailsPageControl.SetEveryAreaSize();
    DetailsPageControl.SetStyle(AreaID);

}

DetailsPageControl.SetEveryAreaSize = function () {
    /// <summary>设置本页面各个区域尺寸</summary>

    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();
    var LeftInfoAreaWidth = HolePageWidth * .3;
    var OptBarHeight = $("#OptBar").outerHeight();

    var RightInfoAreaWidth = HolePageWidth - LeftInfoAreaWidth - 1;

    //$("#LeftInfoArea").width(LeftInfoAreaWidth)
    //    .height(HolePageHeight - OptBarHeight);
    //$("#RightInfoArea").width(RightInfoAreaWidth)
    //    .height(HolePageHeight - OptBarHeight);

    var InfoWidth = HolePageWidth - $(".optbar .title").width() - $(".optbar .optbtn").outerWidth() - 40;

    $(".optbar .info").width(InfoWidth);
    $(".optbar .info span").width(InfoWidth);

}

DetailsPageControl.ResizeWindow = function () {
    /// <summary>本页面窗口大小改变事件</summary>
    DetailsPageControl.SetEveryAreaSize();
}

DetailsPageControl.SetStyle = function (AreaID) {
    /// <summary>
    /// 1.为所有class中包含btn的按钮设置划过样式
    /// 2.设置所有的Select样式</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>

    DetailsPageControl.SetStyleForBtn(AreaID);   //为所有class中包含btn的按钮设置划过样式
    $(AreaID == "All" ? "select" : "#" + AreaID + " select").selecter();     //设置所有的Select样式

    $("tr:even").addClass("even");
    $("tr:odd").addClass("odd");

    $(".forwordrecorditem:last").addClass("forwordrecorditem-last");
}

DetailsPageControl.SetStyleForBtn = function (AreaID) {
    /// <summary>设置Class包含btn的input样式</summary>
    /// <param name="AreaID" type="String">要设置的区域ID，可选值：查询区域QueryArea，列表区域ListArea，全部All</param>
    $(AreaID == "All" ? ".btn" : "#" + AreaID + " .btn").each(function () {
        var BtnName = $(this).attr("src");
        if (BtnName != undefined && BtnName.indexOf("/") < 0) {
            var NormalImg = DetailsPageControl.DefaultImageFolder + "/btn/" + BtnName + "_n.png";
            var HoverImg = DetailsPageControl.DefaultImageFolder + "/btn/" + BtnName + "_h.png";

            $(this).attr("src", NormalImg);
            $(this).hover(
                function () { $(this).attr("src", HoverImg); },
                function () { $(this).attr("src", NormalImg); }
            );
        }
    });
}

DetailsPageControl.OpenBox = function (Url) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Height">弹出框高度</param>
    parent.BoxControl.Show(Url, Title, Width, Height);
}

DetailsPageControl.CloseBox = function () {
    /// <summary>关闭弹出的窗口</summary>

    $(".uploadify").remove();
    $("body").remove();
    parent.BoxControl.Close();
}

DetailsPageControl.ReflushList = function (iframSrc) {
    /// <summary>刷新列表</summary>
    //parent.TabControl.ReflushCurrentList();
    // window.opener.refresh();
    //window.opener.location.href = window.opener.location.href;
    
    parent.$("#desk").attr("src", iframSrc);
}

DetailsPageControl.RemoveItem = function (Id, TypeCode) {
    /// <summary>移除已处理的待办事项</summary>
    /// <param name="Id" type="String">事件ID</param>
    /// <param name="TypeCode" type="String">事件类型代码</param>
    parent.TabControl.RemoveItem(Id, TypeCode);
}


DetailsPageControl.OpenUserChooser = function (UserNamesControlID, UserIDsControlID) {
    /// <summary>开启选人控件</summary>

    var UserChooserPage = Config.UserChooserPage + "?";
    UserChooserPage += "type=user&UserNamesControlID=" + UserNamesControlID + "&UserIDsControlID=" + UserIDsControlID;

    BoxControl.Show(UserChooserPage, "选择人员", "650px", "480px", false, false);
}



DetailsPageControl.ViewOrDownloadAttachment = function (AttachID) {
    var ViewOrDownloadAttachmentPage = Config.ViewOrDownloadAttachmentPage + "?";
    ViewOrDownloadAttachmentPage += "AttachID=" + AttachID;

    window.open(ViewOrDownloadAttachmentPage, '', 'height=600,width=800,top=20,location=no,menubar=no,status=no,titlebar=no,resizable=yes,toolbar=no,scrollbars=yes,channelmode=no');

    //  BoxControl.Show(ViewOrDownloadAttachmentPage, "查看附件", "650px", "480px", false, false);

}

DetailsPageControl.AddAttachmentClick = function () {
    $(".uploadedattach").find("> .showattach").each(function () {
        var AttachID = $(this).find("input").val();

        $(this).on("click", function () {
            DetailsPageControl.ViewOrDownloadAttachment(AttachID);
        });
    })
}