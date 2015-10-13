/// <reference path="../JQuery/jquery-1.7.2.js" />
/// <reference path="Config.js" />
/// <reference path="DataControl.js" />

$(function () {

    NoteControl.InitHandler(true);
    NoteControl.SetStyle();
    NoteControl.getNoteByUserID();
    setInterval("NoteControl.Shake()", 1200);
});

$(window).resize(function () {
    NoteControl.ShakeTimes = 0;
    NoteControl.InitHandler(true);
    NoteControl.SetStyle();
    NoteControl.ShowNoteBar(false);
});


var NoteControl = {};
NoteControl.ShakeTimes = 0;
NoteControl.ShowBtnImgUrl = Config.DefaultImageFolder + "/arrow_up.png";
NoteControl.HideBtnImgUrl = Config.DefaultImageFolder + "/arrow_down.png";
NoteControl.NoteBarHeight = 130;
NoteControl.NoteBarHandlerHeight = 30;

NoteControl.getNoteByUserID = function () {
    /// <summary>获取日程提醒列表</summary>
    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + userid + "' }", "getRemindNoteByUserID", "NoteControl.BindNoteList(data)");
}

NoteControl.BindNoteList = function (data) {
    var HtmlTemplate = $("#ListArea  .data-template");
    var DataObj = $.parseJSON(data.d);
    $("#NoteNum").html("您有" + $(DataObj).length + "条日程待处理");

    var HolePageHeight = $(window).height();
    var NoteBarTop = HolePageHeight - NoteControl.NoteBarHeight;
    if ($(DataObj).length > 0 && $("#NoteBar").position().top > NoteBarTop) {
        NoteControl.ShakeTimes = 1;
    }
    else {
        NoteControl.ShakeTimes = 0;
    }

    $("#ListArea > .item").remove();
    $(DataObj).each(function () {
        var Date = this["CalenderBegin"].replace(/T/g, "&nbsp;");
        Date = Date.substring(0, Date.length - 3);
        var ItemHtml = HtmlTemplate.html();
        ItemHtml = ItemHtml.replace(/@id/g, this["id"]);
        ItemHtml = ItemHtml.replace(/@typecode/g, "RCCK");
        ItemHtml = ItemHtml.replace(/@infor_time/g, Date);
        ItemHtml = ItemHtml.replace(/@title/g, this["CalenderTitle"]);
        $("#ListArea").prepend(ItemHtml);
        var CurrentObj = $("#NoteBar .itemTemp:first");
        CurrentObj.addClass("item");
    });

    //NoteControl.Flicker();

    NoteControl.BindNoteItemsStyleAndEvent();
    setTimeout("NoteControl.getNoteByUserID();", 60000);

}
NoteControl.Shake = function () {
    if (NoteControl.ShakeTimes > 0) {
        $("#NoteBar .handler").fadeTo(1200, .1).fadeTo(200, 1);
    }
}

NoteControl.BindNoteItemsStyleAndEvent = function () {
    /// <summary>绑定待办事项的样式和点击事件</summary>


    NoteControl.BindNoteItemsEvent();
}
NoteControl.BindNoteItemsEvent = function () {
    $("#ListArea > .item").each(function () {
        var TypeCode = $(this).find("input[name=TypeCode]").val();
        var CurrentID = $(this).find("input[name=Id]").val();
        var CurrentConfig = eval("Config.EventTypeAndStyleAndPopPage." + TypeCode);

        $(this).on("click", function () {
            NoteControl.OpenBox(CurrentConfig.PopPage.replace(/@id/g, CurrentID), CurrentConfig.Name);
        });
    });
}
NoteControl.OpenBox = function (Url, Title, Width, Height, OverlayClose, EscKey) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Height">弹出框高度</param>
    parent.parent.BoxControl.Show(Url, Title, Width, Height, OverlayClose, EscKey);
}

NoteControl.SetStyle = function () {
    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();
    var NoteBarHandlerWidth = $("#NoteBar .handler").width();
    var NoteBarOptBtnWidth = $("#NoteBar .optbtn").width();

    var NoteBarTop = HolePageHeight - NoteControl.NoteBarHandlerHeight;
    $("#NoteBar").css("top", NoteBarTop);
    $("#NoteBar .list").width(HolePageWidth - NoteBarOptBtnWidth);
}

NoteControl.InitHandler = function (IsShow) {
    /// <summary>为提示框的头部按钮添加事件</summary>
    /// <param name="IsShow" type="Boolean">点击后是显示(true)还是隐藏(false)</param>

    $("#NoteBar .handler").one("click", function () {
        if (IsShow) {
            NoteControl.ShowNoteBar(true);
        } else {
            NoteControl.ShowNoteBar(false);
        }
    });
}

NoteControl.ShowNoteBar = function (IsShow) {
    /// <summary>显示或隐藏提示框</summary>
    /// <param name="IsShow" type="Boolean">显示(true)还是隐藏(false)</param>

    var HolePageHeight = $(window).height();
    var NoteBarMinTop = HolePageHeight - NoteControl.NoteBarHeight;
    var NoteBarMaxTop = HolePageHeight - NoteControl.NoteBarHandlerHeight;

    if (IsShow) {
        NoteControl.ShakeTimes = 0;
        if ($("#NoteBar").position().top >= NoteBarMaxTop) {
            $("#NoteBar").animate({
                top: NoteBarMinTop
            }, 1000, function () {
                NoteControl.InitHandler(false);
                $("#NoteBar .handler").attr("title", "收起");
                NoteControl.ShakeTimes = 0;
            });
        }
    } else {
        //NoteControl.ShakeTimes = 1;
        if ($("#NoteBar").position().top <= NoteBarMinTop) {
            $("#NoteBar").animate({
                top: NoteBarMaxTop
            }, 1000, function () {
                NoteControl.InitHandler(true);
                $("#NoteBar .handler").attr("title", "展开");
                NoteControl.ShakeTimes = 1;
            });
        }
    }
}

NoteControl.GetDataAndSave = function () {
    /// <summary>获取数据并保存</summary>
    var CalenderIDList = "";

    $("#ListArea > .item").each(function () {
        CalenderIDList += ($(this).find("input[name=Id]").val() + ",");
    });
    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + userid + "','CalenderIDs':'" + CalenderIDList + "' }", "editCalenderRemindByUserID", "NoteControl.Save(data)");

}
NoteControl.Save = function (data) {
    if (data.d > 0) {
        NoteControl.getNoteByUserID();
        alert("取消提醒成功");
        NoteControl.ShowNoteBar(false);
    }

}