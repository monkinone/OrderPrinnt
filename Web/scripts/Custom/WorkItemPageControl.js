/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="BoxControl.js" />

$(function () {
    //WorkItemPageControl.BindWorkItemsStyleAndEvent();
    WorkItemPageControl.getWorkItemByUserIDFirst();
});

var WorkItemPageControl = {};
WorkItemPageControl.MaxDateTime = "";
WorkItemPageControl.OpenBox = function (Url, Title, Width, Height, OverlayClose, EscKey) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Height">弹出框高度</param>
    parent.parent.BoxControl.Show(Url, Title, Width, Height, OverlayClose, EscKey);
}

WorkItemPageControl.BindWorkItemsStyleAndEvent = function () {
    /// <summary>绑定待办事项的样式和点击事件</summary>

    WorkItemPageControl.BindWorkItemsStyle();
    WorkItemPageControl.BindWorkItemsEvent();
}

WorkItemPageControl.BindWorkItemsStyle = function () {
    /// <summary>绑定所有Item元素的样式</summary>
    $("#ListArea .item").each(function () {
        var TypeCode = $(this).find("input[name=TypeCode]").val();
        var CurrentID = $(this).find("input[name=Id]").val();
        var TypeCodes = TypeCode.substring(0, 4);
        //判断如果等于信息共享就给他们赋值
        if (TypeCodes == "XXGX") {
            TypeCode = TypeCodes;
        }
        var CurrentConfig = eval("Config.EventTypeAndStyleAndPopPage." + TypeCode);

        $(this).find("td.icon img").attr("src", Config.AppStartupDir + Config.DefaultImageFolder + "/icon/icon_" + CurrentConfig.IconName + "_m.png");
        $(this).find("td.icon span").html(CurrentConfig.Name);
        $(this).addClass(CurrentConfig.ClassName);
        var IconWidth = 84; //$(this).find("td.icon").outerWidth();
        var TitleWidth = $("#ListArea").width() - IconWidth;

        $(this).find("td.title").width(TitleWidth);
        $(this).find("td.title span").width(TitleWidth);
    });
}

WorkItemPageControl.BindWorkItemStyleAndEvent = function (CurrentObj) {
    /// <summary>绑定单个Item元素的样式和事件</summary>
    var TypeCode = CurrentObj.find("input[name=TypeCode]").val();
    var CurrentID = CurrentObj.find("input[name=Id]").val();
    var TypeCodes = TypeCode.substring(0, 4);
    //判断如果等于信息共享就给他们赋值
    if (TypeCodes == "XXGX") {
        TypeCode = TypeCodes;
    }
    var CurrentConfig = eval("Config.EventTypeAndStyleAndPopPage." + TypeCode);

    CurrentObj.find("td.icon img").attr("src", Config.AppStartupDir + Config.DefaultImageFolder + "/icon/icon_" + CurrentConfig.IconName + "_m.png");
    CurrentObj.find("td.icon span").html(CurrentConfig.Name);
    CurrentObj.addClass(CurrentConfig.ClassName);
    var IconWidth = 84; //$(this).find("td.icon").outerWidth();
    var TitleWidth = $("#ListArea").width() - IconWidth;

    CurrentObj.find("td.title").width(TitleWidth);
    CurrentObj.find("td.title span").width(TitleWidth);

    CurrentObj.on("click", function () {
        WorkItemPageControl.OpenBox(CurrentConfig.PopPage.replace(/@id/g, CurrentID), CurrentConfig.Name);
    });

}

WorkItemPageControl.BindWorkItemsEvent = function () {
    $("#ListArea .item").each(function () {
        var TypeCode = $(this).find("input[name=TypeCode]").val();
        var CurrentID = $(this).find("input[name=Id]").val();
        var TypeCodes = TypeCode.substring(0, 4);
        //判断如果等于信息共享就给他们赋值
        if (TypeCodes == "XXGX") {
            TypeCode = TypeCodes;
        }
        var CurrentConfig = eval("Config.EventTypeAndStyleAndPopPage." + TypeCode);

        $(this).on("click", function () {
            WorkItemPageControl.OpenBox(CurrentConfig.PopPage.replace(/@id/g, CurrentID), CurrentConfig.Name);
        });
    });
}

WorkItemPageControl.getWorkItemByUserIDFirst = function () {
    /// <summary>首次获取待办列表，不添加动画效果</summary>
    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + userid + "','MaxDateTime':'" + WorkItemPageControl.MaxDateTime + "','pageSize':'" + pageSize + "' }", "getWorkItemByUserID", "WorkItemPageControl.BindWorkItemListFirst(data)");
}

WorkItemPageControl.BindWorkItemListFirst = function (data) {
    var HtmlTemplate = $("#ListArea  .data-template");
    var DataObj = $.parseJSON(data.d);

    $(DataObj).each(function () {
        var ItemHtml = HtmlTemplate.html();

        WorkItemPageControl.SetMaxDateTime(this["infor_time"]);
        ItemHtml = ItemHtml.replace(/@ORG_NAME/g, this["ORG_NAME"]);
        ItemHtml = ItemHtml.replace(/@id/g, this["id"]);
        ItemHtml = ItemHtml.replace(/@typecode/g, this["typecode"]);
        ItemHtml = ItemHtml.replace(/@infor_other/g, this["infor_other"]);
        ItemHtml = ItemHtml.replace(/@infor_time/g, this["infor_time"].replace(/T/g, "&nbsp;"));
        ItemHtml = ItemHtml.replace(/@title/g, this["title"]);

        $("#ListArea").prepend(ItemHtml);
        var CurrentObj = $("#ListArea .itemTemp:first");
        CurrentObj.addClass("item");
    });

    WorkItemPageControl.BindWorkItemsStyleAndEvent();
    setTimeout("WorkItemPageControl.getWorkItemByUserID();", 60000);

}

WorkItemPageControl.getWorkItemByUserID = function () {
    /// <summary>获取待办列表</summary>
    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + userid + "','MaxDateTime':'" + WorkItemPageControl.MaxDateTime + "','pageSize':'"+pageSize+"' }", "getWorkItemByUserID", "WorkItemPageControl.BindWorkItemList(data)");
}

WorkItemPageControl.BindWorkItemList = function (data) {
    var HtmlTemplate = $("#ListArea  .data-template");
    var DataObj = $.parseJSON(data.d);

    $(DataObj).each(function () {
        var ItemHtml = HtmlTemplate.html();

        WorkItemPageControl.SetMaxDateTime(this["infor_time"]);
        ItemHtml = ItemHtml.replace(/@ORG_NAME/g, this["ORG_NAME"]);
        ItemHtml = ItemHtml.replace(/@id/g, this["id"]);
        ItemHtml = ItemHtml.replace(/@typecode/g, this["typecode"]);
        ItemHtml = ItemHtml.replace(/@infor_other/g, this["infor_other"]);
        ItemHtml = ItemHtml.replace(/@infor_time/g, this["infor_time"].replace(/T/g, "&nbsp;"));
        ItemHtml = ItemHtml.replace(/@title/g, this["title"]);

        $("#ListArea").prepend(ItemHtml);
        var CurrentObj = $("#ListArea .itemTemp:first");
        CurrentObj.addClass("item");
        WorkItemPageControl.BindWorkItemStyleAndEvent(CurrentObj);
        CurrentObj.hide();
    });

    WorkItemPageControl.ShowItem($(DataObj).length + 1);

    setTimeout("WorkItemPageControl.getWorkItemByUserID();", 60000);
}

WorkItemPageControl.ShowItem = function (Number) {
    /// <summary>动画显示每一个Item</summary>
    var CurrentObj = $("#ListArea .item:hidden:last");

    CurrentObj.show(600, "linear", function () {
        if (Number > 0) {
            WorkItemPageControl.ShowItem(Number - 1);
        }
    });
}

WorkItemPageControl.ResizeWindow = function () {
    WorkItemPageControl.BindWorkItemsStyle();
}

WorkItemPageControl.SetMaxDateTime = function (CurrentDateTime) {
    /// <summary>设置当前最大时间</summary>
    /// <param name="CurrentDateTime" type="String">当前待办事件的时间</param>
    if (CurrentDateTime > WorkItemPageControl.MaxDateTime) {
        WorkItemPageControl.MaxDateTime = CurrentDateTime;
    }
}

WorkItemPageControl.RemoveItem = function (Id, TypeCode) {
    /// <summary>移除已处理的待办事项</summary>
    /// <param name="Id" type="String">事件ID</param>
    /// <param name="TypeCode" type="String">事件类型代码</param>
    $("#ListArea .item[data-flag=" + Id + "-" + TypeCode + "]").hide(600).remove();
}
