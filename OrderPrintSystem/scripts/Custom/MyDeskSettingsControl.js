/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="DataControl.js" />
/// <reference path="Config.js" />


var MyDeskSettingsControl = {};
MyDeskSettingsControl.HolePageWidth = 0;
MyDeskSettingsControl.CurrentFunID = "";
MyDeskSettingsControl.CurrentFunName = "";
MyDeskSettingsControl.TypeCode;
MyDeskSettingsControl.CurrentUserId;
MyDeskSettingsControl.CurrentOrgId;
MyDeskSettingsControl.UnitID;
MyDeskSettingsControl.CurrentOrgName;

$(function () {
    MyDeskSettingsControl.TypeCode = "GZDT"
    MyDeskSettingsControl.ResizeWindow();
    MyDeskSettingsControl.GetOrgList();
    MyDeskSettingsControl.SetStyle();
    MyDeskSettingsControl.SetNavClickEvent();
    MyDeskSettingsControl.SetByDateClickEvent();
});

MyDeskSettingsControl.ResizeWindow = function () {
    MyDeskSettingsControl.HolePageWidth = $(window).width();
    var SelectAreaWidth = $("#SelectArea").outerWidth();

    $("#SettingArea").width(MyDeskSettingsControl.HolePageWidth - SelectAreaWidth);
}

MyDeskSettingsControl.SetStyle = function () {
    MyDeskSettingsControl.SetStyleForBtn();
}

MyDeskSettingsControl.SetStyleForBtn = function () {
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


MyDeskSettingsControl.SetNavClickEvent = function () {
    /// <summary>设置导航区域按钮点击事件</summary>

    $("#SelectArea > .btn").on("click", MyDeskSettingsControl.SetCurrentFun);
}

MyDeskSettingsControl.SetCurrentFun = function () {
    /// <summary>转到当前要设置的功能点</summary>

    if ($(this).attr("data-id") == undefined) {
        var CurrentFun = $("#SelectArea > .btn:first");
        MyDeskSettingsControl.CurrentFunID = CurrentFun.attr("data-id");
        MyDeskSettingsControl.CurrentFunName = CurrentFun.attr("data-name");
    } else {
        MyDeskSettingsControl.CurrentFunID = $(this).attr("data-id");
        MyDeskSettingsControl.CurrentFunName = $(this).attr("data-name");
    }
    $("#SettingArea > .title").html(MyDeskSettingsControl.CurrentFunName + "&nbsp;功能设置");

}

MyDeskSettingsControl.SetByOrgClickEvent = function () {
    /// <summary>设置按单位筛选的选项点击事件</summary>
    $("#SettingArea .byorg .list").find(".item").each(function () {
        $(this).on("click", function () {
            if ($(this).hasClass("current")) {
                $(this).removeClass("current");
            } else {
                $(this).addClass("current");
            }
        });
    });
}

MyDeskSettingsControl.SetByDateClickEvent = function () {
    /// <summary>设置按日期筛选的选项点击事件</summary>

    $("#SettingArea .bydate .list").find(".item").each(function () {
        $(this).on("click", function () {
            $("#SettingArea .bydate .list .item").removeClass("current");
            $(this).addClass("current");
        });
    });

}

MyDeskSettingsControl.GetOrgList = function () {
    $("#SettingArea .byorg .list").html(" <div class=\"data-template\"><div class=\"item\" id=\"Org_@ORG_ID\" data-orgid=\"@ORG_ID\">@ORG_NAME</div></div>");
    /// <summary>获取机构列表</summary>
    //判断信息共享，并给信息共享加默认样式
    if (MyDeskSettingsControl.TypeCode == "XXGX") {
        MyDeskSettingsControl.TypeCode = "XXGX_ZBB";
        //去除其他样式
        $("#XXGXLM .XXGXList").find(".XXGXItem").each(function () {
                $("#XXGXLM .XXGXList .XXGXItem").removeClass("XXGXCurrent");
        });
        $("#ZBB").addClass("XXGXCurrent");
    }
    //给公文流转加默认样式
    if (MyDeskSettingsControl.TypeCode == "GWLZ") {
        //去除其他样式
        $("#GWLZNBWB .XXGXList").find(".XXGXItem").each(function () {
                $("#GWLZNBWB .XXGXList .XXGXItem").removeClass("XXGXCurrent");
        });
        $("#WBGW").addClass("XXGXCurrent");
    } else if (MyDeskSettingsControl.TypeCode == "NBGWLZ") {
        //去除其他样式
        $("#GWLZNBWB .XXGXList").find(".XXGXItem").each(function () {
            $("#GWLZNBWB .XXGXList .XXGXItem").removeClass("XXGXCurrent");
        });
        $("#NBGW").addClass("XXGXCurrent");
    }

    //判断信息共享的内部外部显示隐藏
    if (MyDeskSettingsControl.TypeCode == "XXGX_ZBB" || MyDeskSettingsControl.TypeCode == "XXGX_HYJY" || MyDeskSettingsControl.TypeCode == "XXGX_GZZD" || MyDeskSettingsControl.TypeCode == "XXGX_GZYB" || MyDeskSettingsControl.TypeCode == "XXGX_KW" || MyDeskSettingsControl.TypeCode == "XXGX_GX" || MyDeskSettingsControl.TypeCode == "XXGX_QT") {
        $("#XXGXLM").show();
        $("#TS").show();
    } else {
        $("#XXGXLM").hide();
    }
    if (!(MyDeskSettingsControl.TypeCode == "XXGX_ZBB" || MyDeskSettingsControl.TypeCode == "XXGX_HYJY" || MyDeskSettingsControl.TypeCode == "XXGX_GZZD" || MyDeskSettingsControl.TypeCode == "XXGX_GZYB" || MyDeskSettingsControl.TypeCode == "XXGX_KW" || MyDeskSettingsControl.TypeCode == "XXGX_GX" || MyDeskSettingsControl.TypeCode == "XXGX_QT") && !(MyDeskSettingsControl.TypeCode == "GWLZ" || MyDeskSettingsControl.TypeCode == "NBGWLZ")) {
        $("#TS").hide();
    }
    if (MyDeskSettingsControl.TypeCode == "GZDT") {
        DataControl.GetJsonDataAndExecuteFun("{'UserId':'" + MyDeskSettingsControl.CurrentUserId + "','TypeCode':'" + MyDeskSettingsControl.TypeCode + "'}", "GetOrgByUserIdAndTypeCode", "MyDeskSettingsControl.BindOrgList(data)");
    }
    else {
        DataControl.GetJsonDataAndExecuteFun("{'Unit_ID':'" + parseInt(MyDeskSettingsControl.UnitID.toString()) + "'}", "GetOrgByUserIdAndTypeCodeNotKS", "MyDeskSettingsControl.BindOrgList(data)");
    }
}

MyDeskSettingsControl.BindOrgList = function (data) {
    /// <summary>绑定机构列表</summary>
    /// <param name="data" type="String">获取到的数据</param>

    var HtmlTemplate = $("#SettingArea .byorg .list .data-template");
    var DataObj = $.parseJSON(data.d);

    if (DataObj.length > 0) {
        $(DataObj).each(function () {
            var ItemHtml = HtmlTemplate.html();
            if (MyDeskSettingsControl.TypeCode == "GZDT") {
                ItemHtml = ItemHtml.replace(/@ORG_NAME/g, this["PRIVILEGE_NAME"]);
                ItemHtml = ItemHtml.replace(/@ORG_ID/g, this["PRIVILEGE_CODE"]);
            } else {
                ItemHtml = ItemHtml.replace(/@ORG_NAME/g, this["ORG_NAME"]);
                ItemHtml = ItemHtml.replace(/@ORG_ID/g, this["ORG_ID"]);
            }
            $("#SettingArea .byorg .list").append(ItemHtml);
            $("#SettingArea .byorg .list .item:last").removeClass("data-template");
        });
    } else {
        var ItemHtml = HtmlTemplate.html();

        ItemHtml = ItemHtml.replace(/@ORG_NAME/g, MyDeskSettingsControl.CurrentOrgName);
        ItemHtml = ItemHtml.replace(/@ORG_ID/g, MyDeskSettingsControl.CurrentOrgId);

        $("#SettingArea .byorg .list").append(ItemHtml);
        $("#SettingArea .byorg .list .item:last").removeClass("data-template");
    }
    MyDeskSettingsControl.SetByOrgClickEvent();
    MyDeskSettingsControl.GetSelectedOrgAndDate();
}

MyDeskSettingsControl.GetSelectedOrgAndDate = function () {
    /// <summary>绑定已选中的机构列表和日期</summary>

    //    var TypeCode = $("#SelectArea > .btn.current").attr("data-typecode");

    if (MyDeskSettingsControl.TypeCode == "GWLZ" || MyDeskSettingsControl.TypeCode == "NBGWLZ") {
        $("#GWLZNBWB").show();
        $("#TS").show();
    } else {
        $("#GWLZNBWB").hide();
    }

    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + MyDeskSettingsControl.CurrentUserId + "','TypeCode':'" + MyDeskSettingsControl.TypeCode + "'}", "GetFuncCustomByUserIdAndTypeCode", "MyDeskSettingsControl.BindSelectedOrgAndDate(data)");
}

MyDeskSettingsControl.BindSelectedOrgAndDate = function (data) {
    /// <summary>绑定已选中的机构和日期</summary>
    var DataObj = $.parseJSON(data.d);
    var OrgList = "";
    var Days;

    if (DataObj.length > 0) {
        OrgList = DataObj[0]["org_ids"];
        Days = DataObj[0]["days"];
    }
    if (OrgList=="") {
        $("#SettingArea .byorg .list >.item").addClass("current");
    }
    if (OrgList == ",") {
        //        $("#SettingArea .byorg .list >.item").addClass("current");
    } else {
        $("#SettingArea .byorg .list >.item").each(function () {
            if (OrgList.indexOf("," + $(this).attr("data-orgid") + ",") >= 0) {
                $(this).addClass("current");
            }
        });
    }

    if (Days == null) {
        Days = "";
    }

    $("#SettingArea .bydate .list >.item").each(function () {
        if (Days == $(this).attr("data-days")) {
            $("#SettingArea .bydate .list >.item").removeClass("current");
            $(this).addClass("current");
        }
    });
}

MyDeskSettingsControl.GetDataAndSave = function () {
    /// <summary>获取数据并保存</summary>
    //    var TypeCode = $("#SelectArea > .btn.current").attr("data-typecode");
    var UserID = MyDeskSettingsControl.CurrentUserId;
    var OrgList = ",";
    var Days = "";

    $("#SettingArea .byorg .list >.current").each(function () {
        OrgList += ($(this).attr("data-orgid") + ",");
    });

    Days = $("#SettingArea .bydate .list >.current").attr("data-days");
    if (Days == undefined || Days == "undefined") {
        Days = "";
    }
    DataControl.GetJsonDataAndExecuteFun("{ 'UserId': '" + MyDeskSettingsControl.CurrentUserId + "','TypeCode':'" + MyDeskSettingsControl.TypeCode + "','OrgList':'" + OrgList + "','Days':'" + Days + "'}", "SaveFuncCustom", "MyDeskSettingsControl.Save(data)");
}

MyDeskSettingsControl.Save = function (data) {
    if (data.d == true) {
        alert("保存成功");
    }
}
MyDeskSettingsControl.Saves = function (data) {
}