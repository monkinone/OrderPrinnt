/// <reference path="../JQuery/jquery-1.7.2.js" />

$(function () {
    var BoxHandlerHtml = '<a class="BoxHandler" style="display: none;"></a>';

    if ($(".BoxHandler").length <= 0) {
        $("body").append(BoxHandlerHtml);
    }
});

var BoxControl = {};

BoxControl.Show = function (Url, Title, Width, Height, OverlayClose, EscKey) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Title" type="String">对话框标题</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Int">弹出框高度</param>
    /// <param name="OverlayClose" type="String">点击灰色背景是否关闭对话框</param>
    /// <param name="EscKey" type="String">是否显示关闭按钮</param>



    Width = Width != undefined ? Width : "80%";
    Height = Height != undefined ? Height : "80%";
    OverlayClose = OverlayClose != undefined ? OverlayClose : false;
    EscKey = EscKey != undefined ? EscKey : true;

    $(".BoxHandler").attr("href", Url);

    $(".BoxHandler").colorbox({
        title: Title,
        fastIframe: false,
        iframe: true,
        width: Width,
        height: Height,
        scrolling: false,
        overlayClose: OverlayClose,
        escKey: EscKey
    });

    $(".BoxHandler").click();
}

BoxControl.Close = function () {
    $.colorbox.close();
}