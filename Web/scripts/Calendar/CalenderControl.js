var CalenderControl = {};

CalenderControl.initDay = function () {

    $("#CalenderDay").click();
}

CalenderControl.OpenBox = function (Url, Title, Width, Height, OverlayClose, EscKey) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Height">弹出框高度</param>
    parent.parent.BoxControl.Show(Url, Title, Width, Height, OverlayClose, EscKey);
}

function initCalendar(flag, byType, dayStr, endDayStr) {

    var events = GetCalendarByUser(flag, byType, dayStr, endDayStr);

    return events;

}
function GetCalendarByUser(flag, byType, dayStr, endDayStr) {

    var colors = ['#dddddd', '#7E0000', '#00630F', '#00630F'];
    var events;
    $.ajax({
        url: "../../../Calendar/GetCalender.aspx?flag=" + flag + "&byType=" + byType + "&dayStr=" + dayStr + "&endDayStr=" + endDayStr,
        dataType: "json",
        async: false,
        success: function (data) {
            if ("month" == byType) {
                for (var i = 0; i < data.length; i++) {
                    data[i].uid = data[i].uid + "@";


                    if (data[i].color == null)

                        data[i].color = randomFrom(colors);


                }
                events = data;
            }
            if ("day" == byType) {

                //$("#daytext").arrt("value")

                events = new Array();
                for (var i = 0; i < data.length; i++) {

                    data[i].uid = data[i].uid + "@";
                    data[i].begins = data[i].begins.replace("T", " ");
                    data[i].ends = data[i].ends.replace("T", " ");
                    if (data[i].color == null)
                        data[i].color = randomFrom(colors);

                }
                events = data;

            }
            if ("week" == byType) {

                //$("#daytext").arrt("value")
                events = new Array();
                for (var i = 0; i < data.length; i++) {
                    data[i].uid = data[i].uid + "@";
                    data[i].begins = data[i].begins.replace("T", " ");
                    data[i].ends = data[i].ends.replace("T", " ");
                    if (data[i].color == null)
                        data[i].color = randomFrom(colors);

                }
                events = data;
            }


        },
        error: function () {
            alert("未获取到数据！");
        },
        cache: false
    });
    return events;
}
function randomBetween(from, to) {
    return Math.floor(Math.random() * (to - from + 1) + from);
}

/**
* Random array item function. Used in randomEvents()
*
* @param array arr			: returns a random array element in a numerically keyed array.
*
* @return string : array item.
*/
function randomFrom(arr) {

    return arr[randomBetween(0, arr.length - 1)];
}

function DeleteCalendarByUser() {
    var id = $("#selectedEvent").attr("value");

    if (id == "") { alert("请选择删除日程"); return } else if (confirm("是否删除选中日程？")) {
        $.ajax({
            url: "../../../Calendar/GetCalender.aspx?flag=-1&id=  " + id,
            dataType: "text",
            async: false,
            success: function (data) {


                CalenderInit();
            },
            error: function () {
                alert("操作失败");
            },
            cache: false
        });
    }
}
function DeleteCalendarByUserWeek(dayStr) {
    var id = $("#selectedEvent").attr("value");

    if (id == "") { alert("请选择删除日程"); return } else if (confirm("是否删除选中日程？")) {
        $.ajax({
            url: "../../../Calendar/GetCalender.aspx?flag=-1&id=  " + id,
            dataType: "text",
            async: false,
            success: function (data) {


                getWeekCalender(dayStr);
            },
            error: function () {
                alert("操作失败");
            },
            cache: false
        });
    }
}
function DeleteCalendarByUserDay(dayStr) {
    var id = $("#selectedEvent").attr("value");

    if (id == "") { alert("请选择删除日程"); return } else if (confirm("是否删除选中日程？")) {
        $.ajax({
            url: "../../../Calendar/GetCalender.aspx?flag=-1&id=  " + id,
            dataType: "text",
            async: false,
            success: function (data) {


                getDayCalender(dayStr);
            },
            error: function () {
                alert("操作失败");
            },
            cache: false
        });
    }
}



function CalendarByUserDay() {
    var id = $("#selectedEvent").attr("value");
    if (id == "") {
        alert("请选择要查看的日程");
    }
    ListPageControl.ReflushListBtnID = "FlushCalender";
    ListPageControl.OpenBox('../Calendar/CalenderAdd.aspx?id=' + id, '日程信息')
}
function CalendarByUserDayOfDetail() {
    var id = $("#selectedEvent").attr("value");
    if (id == "") {
        alert("请选择要查看的日程");
    }
    ListPageControl.ReflushListBtnID = "FlushCalender";
    ListPageControl.OpenBox('../Calendar/CalenderAdd.aspx?id=' + id, '日程信息')
}
function CalendarByUserWeekOfDetail() {
    var id = $("#selectedEvent").attr("value");
    if (id == "") {
        alert("请选择要查看的日程");
    }
    ListPageControl.ReflushListBtnID = "FlushCalender";
    ListPageControl.OpenBox('../Calendar/CalenderAdd.aspx?id=' + id, '日程信息')
}
function CalendarByUid(obj) {
    var id = $(obj).attr("data-id");
    id = id.replace("@", "");
    ListPageControl.ReflushListBtnID = "FlushCalender";
    ListPageControl.OpenBox('../Calendar/CalenderDetail.aspx?id=' + id, '日程信息')


}
function CalendarByUserDetailMyBox() {
    var id = $("#selectedEvent").attr("value");
    if (id == "") { alert("请选择要查看的日程"); return }


    ListPageControl.OpenBox('../Calendar/CalenderDetail.aspx?id=' + id, '日程信息');
}

function showBox(Url, Title, Width, Height, OverlayClose, EscKey) {
    /// <summary>显示一个弹出框</summary>
    /// <param name="Url" type="String">弹出框中IFrame的地址</param>
    /// <param name="Title" type="String">对话框标题</param>
    /// <param name="Width" type="Int">弹出框宽度</param>
    /// <param name="Height" type="Int">弹出框高度</param>
    /// <param name="OverlayClose" type="String">点击灰色背景是否关闭对话框</param>
    /// <param name="EscKey" type="String">是否显示关闭按钮</param>
    Width = Width != undefined ? Width : "100%";
    Height = Height != undefined ? Height : "95%";
    OverlayClose = OverlayClose != "undefined" ? OverlayClose : true;
    EscKey = EscKey != "undefined" ? EscKey : true;

    $(".CalenderHander").attr("href", Url);

    $(".CalenderHander").colorbox({
        title: Title,
        fastIframe: false,
        iframe: true,
        width: Width,
        height: Height,
        scrolling: false,
        overlayClose: OverlayClose,
        escKey: EscKey
    });

    $(".CalenderHander").click();
}
function pageindexMainCss(uid) {

    $(".ui-cal-event").each(function () {


        if ($(this).attr("data-id") == uid) {


            var _s = $(this).find(".title").attr("style");

            if (typeof (_s) != "undefined") {
                _s = _s.replace("background", "backgroundinit") + "background:#FF0000;";

                $(this).find(".title").attr("style", _s);
            } else {

                $(this).find(".title").attr("style", "background:#FF0000;");
            }

        } else {

            $(this).find(".title").each(function () {


                var _s = $(this).attr("style");
                if (typeof (_s) != "undefined") {
                    var _ns = "";
                    if (_s.indexOf("backgroundinit") != -1) {
                        var _sl = _s.split(";");
                        for (var i = 0; i < _sl.length; i++) {
                            if (_sl[i].indexOf("background") != -1 && _sl[i].indexOf("backgroundinit") == -1) continue;

                            _ns += _sl[i] + ";";
                        }
                        _ns = _ns.replace("backgroundinit", "background");
                        $(this).attr("style", _ns);

                    } else {

                        $(this).removeAttr("style");

                    }

                } else {


                }
            });


        }

    })

}
function pageindexMainDisplay(uid) {

    $(".ui-cal-event.begin").each(function () {


        if ($(this).attr("data-id") == uid) {


            var _s = $(this).attr("style");
            if (typeof (_s) != "undefined") {
                _s = /**_s.replace("z-index", "z-indexinit") **/_s + "z-index:200;";

                $(this).attr("style", _s);
            }


        } else {



            var _s = $(this).attr("style");
            if (typeof (_s) != "undefined") {
                var _ns = "";
                if (_s.indexOf("z-index") != -1) {
                    var _sl = _s.split(";");
                    for (var i = 0; i < _sl.length; i++) {
                        if (_sl[i].indexOf("z-index") != -1) continue;

                        _ns += _sl[i] + ";";
                    }
                    //_ns = _ns.replace("z-indexinit", "z-index");
                    $(this).attr("style", _ns);
                }
            }



        }

    })

}
function pageindexTabCss(uid) {

    $(".ui-cal-event").each(function () {
        //  alert($(this).attr("class"))
        //   if ($(this).attr("class") == "ui-cal-event mid " || $(this).attr("class") == "ui-cal-event end ") return;
        $(this).find(".pageindex").each(function () {

            if ($(this).find(".tab").attr("pagedata-id") == uid) {

                var _s = $(this).find(".tab").attr("style");
                if (typeof (_s) != "undefined") {
                    _s = _s.replace("background", "backgroundinit") + ";background:#0000A0;";

                    $(this).find(".tab").attr("style", _s);
                }


            } else {

                $(this).find(".tab").each(function () {

                    var _s = $(this).attr("style");

                    if (typeof (_s) != "undefined") {

                        var _ns = "";
                        if (_s.indexOf("backgroundinit") != -1) {
                            //   alert("==" + _s)
                            var _sl = _s.split(";");
                            for (var i = 0; i < _sl.length; i++) {
                                if (_sl[i].indexOf("background") != -1 && _sl[i].indexOf("backgroundinit") == -1) continue;

                                _ns += _sl[i] + ";";
                            }
                            _ns = _ns.replace("backgroundinit", "background");
                            $(this).attr("style", _ns);
                            //   alert("!" + _ns)
                        }
                    }
                });


            }
        })


    })
}
function pageindex(uid) {

   //pageindexMainCss(uid);
    
    // pageindexTabCss(uid);
    //  pageindexMainDisplay(uid);
    uid = uid.substring(0, uid.indexOf("@"));

  $("#selectedEvent").attr("value", uid);
}
function setSelectDay(_day) {

    $("#selectedDay").attr("value", _day);
}
function addCalender() {
    var currentDay = $("input[name=currentDay]").val();
    if (currentDay == "" || currentDay == null) currentDay = $.cal.date().format('Y-m-d');
    CalenderControl.OpenBox("../Calendar/CalenderAdd.aspx?selectedDay='" + currentDay + "'", "添加日程");
}
function addCalenderBySelectDay(selectedDay) {

    CalenderControl.OpenBox("../Calendar/CalenderAdd.aspx?selectedDay='" + selectedDay + "'", "添加日程");
}
function setInitTime(init) {
    if (typeof (init) != "undefined") {

        // init = init.replace(/\-/g, '/');
        $("#txt_begin").attr("value", init + " 08:00");
        $("#txt_end").attr("value", init + " 18:00");

    }
}

function initMonthDay() {/**清除月历中默认的时间值，用于初始化日期**/

    $("input[name=currentDay]").val($.cal.date().format('Y-m-d'));

}


function CalenderInit(action) {


    //  $calendar.cal('option', 'startdate', newstart);
    var currentDay = $("input[name=currentDay]").val();

    if (currentDay == "" || currentDay == "null") { currentDay = $.cal.date().format('Y-m-d'); }
    var _d = new Date(currentDay);
    var _startdate = currentDay;
    var _startmonth = _d.getMonth() + 1;
    var _startyear = _d.getFullYear();
    switch (action) {
        case "Next":
            var currentDayObj = new Date(currentDay);
            var _startmonth = currentDayObj.getMonth();
            var _startyear = currentDayObj.getFullYear();
            if (_startmonth == 0) { _startmonth = 12; _startyear -= 1; }
            _startmonth += "";
            if (_startmonth.length == 1) _startmonth = "0" + _startmonth;
            _startdate = _startyear + "-" + _startmonth + "-01";

            $("input[name=currentDay]").val(_startdate);
            break;
        case "Prev":

            var currentDayObj = new Date(currentDay);
            var _startmonth = (currentDayObj.getMonth() + 2);

            var _startyear = currentDayObj.getFullYear();
            if (_startmonth == 13) { _startmonth = 1; _startyear += 1; }
            _startmonth += "";
            if (_startmonth.length == 1) _startmonth = "0" + _startmonth;
            _startdate = _startyear + "-" + _startmonth + "-01";
            $("input[name=currentDay]").val(_startdate);
            break;
    }

    ListPageControl.ReflushListBtnID = "CalenderAdd";

    $('#calendar').cal('destroy');

    $calendar = $('#calendar').cal({
        startdate: _startdate,
        startmonth: _startmonth,
        startyear: _startyear,
        monthstodisplay: 1,
        allowmove: false,
        allowselect: true,
        allowremove: false,
        //allownotesedit: true,

        eventselect: function (uid) {
            //  alert("eventselect");
            //  console.log('Selected event: ' + uid);

            pageindex(uid);



        },

        eventremove: function (uid) {
            //  alert("eventremove");
            //console.log('Removed event: ' + uid);
            $("#selectedEvent").attr("value", "");
        },

        eventnotesedit: function (uid) {
            // alert("eventnotesedit");
            // console.log('Edited Notes for event: ' + uid);
        },

        //events: randomEvents(50, 100, '@cal1', -90, 90)
        events: initCalendar('1', 'month')

    });
    $('#date_head').text($.cal.date(_startdate).format('Y年F'));

    /**
    * Set the initial header value.
    */



}

function deleteCurrentDayCalender() {

    var dayStr = $('input[name=currentDay]').val();
    if (dayStr == null || typeof (dayStr) == "undefined" || dayStr == "") dayStr = $.cal.date().format('Y-m-d');
    DeleteCalendarByUserDay(dayStr);
}
function deleteCurrentWeekCalender() {

    var dayStr = $('input[name=currentDay]').val();
    if (dayStr == null || typeof (dayStr) == "undefined" || dayStr == "") dayStr = $.cal.date().format('Y-m-d');
    DeleteCalendarByUserWeek(dayStr);
}

function getCurrentDayCalender() {

    var dayStr = $('input[name=currentDay]').val();
    if (dayStr == null || typeof (dayStr) == "undefined" || dayStr == "") dayStr = $.cal.date().format('Y-m-d');
    getDayCalender(dayStr);
}
function getCurrentWeekCalender() {

    var dayStr = $('input[name=currentDay]').val();
    if (dayStr == null || typeof (dayStr) == "undefined" || dayStr == "") dayStr = $.cal.date().format('Y-m-d');
    getWeekCalender(dayStr);
}

function getDayCalender(dayStr, action) {

    if (dayStr == null || typeof (dayStr) == "undefined" || dayStr == "") dayStr = $.cal.date().format('Y-m-d');

    $('#calendarday').cal('destroy');
    var currentDay = dayStr; //当前日期

    switch (action) {//处理翻页逻辑
        case "Next":
            dayStr = $("input[name=currentDay]").val();
            var currentDayObj = new Date(dayStr);
            var _d = new Date();
            var _m = currentDayObj.getTime() - (1 * (1000 * 60 * 60 * 24));
            _d.setTime(_m);
            currentDay = $.cal.format(_d, 'Y-m-d');
            $("input[name=currentDay]").val(currentDay);
            break;
        case "Prev":
            dayStr = $("input[name=currentDay]").val();
            var currentDayObj = new Date(dayStr);
            var _d = new Date();
            var _m = currentDayObj.getTime() + (1 * (1000 * 60 * 60 * 24));
            _d.setTime(_m);
            currentDay = $.cal.format(_d, 'Y-m-d');

            $("input[name=currentDay]").val(currentDay);
            break;

    }

    $calendar = $('#calendarday').cal({

        daystodisplay: 1,
        startdate: currentDay,
        //defaultcolor:'#FFFFFF',
        //allowresize: true,
        //allowmove: true,
        allowselect: true,
        //allowremove: true,
        //allownotesedit: true,
        daytimestart: '00:00:00',
        daytimeend: '24:00:00',
        eventselect: function (uid) {
            //console.log('Selected event: ' + uid);
            uid = uid.substring(0, uid.indexOf("@"));
            $("#selectedEvent").attr("value", uid);
        },

        eventremove: function (uid) {
            // console.log('Removed event: ' + uid);
        },


        eventnotesedit: function (uid) {
            //console.log('Edited Notes for event: ' + uid);
        },



        events: initCalendar('1', 'day', currentDay)
    });

    /**
    * Set the initial header value.
    */
    $('#date_head').text(currentDay);




}
function CalendarByUserWeekDetail(dayStr) {
    var id = $("#selectedEvent").attr("value");

    if (dayStr == null || typeof (dayStr) == "undefined") dayStr = $.cal.date().format('Y-m-d');

    location.href = '../Calendar/Week.aspx?courrentday=' + dayStr;

}
function CalendarByUserDayDetail(dayStr) {
    var id = $("#selectedEvent").attr("value");

    if (dayStr == null || typeof (dayStr) == "undefined") dayStr = $.cal.date().format('Y-m-d');

    location.href = '../Calendar/day.aspx?courrentday=' + dayStr;

}

function CalendarByUserMonthDetail() {/**周历返回月历调用的方法**/
    var id = $("#selectedEvent").attr("value");
    location.href = '../Calendar/Main.aspx';

}
function getWeekCalender(dayStr, action) {


    //alert($.cal.date().addDays(1 - $.cal.date().format('N')).format('y-m-d'));
    if (dayStr == null || typeof (dayStr) == "undefined" || dayStr == "") dayStr = $.cal.date().format('Y-m-d');

    $('#calendarweek').cal('destroy');
    var currentDay = dayStr; //当前日期


    var beginDay; //周的开始时间
    var endDay; //周的结束时间


    switch (action) {//处理翻页逻辑
        case "Next":
            dayStr = $("input[name=currentDay]").val();
            var currentDayObj = new Date(dayStr);
            var _d = new Date();
            var _m = currentDayObj.getTime() - (7 * (1000 * 60 * 60 * 24));
            _d.setTime(_m);
            currentDay = $.cal.format(_d, 'Y-m-d');
            $("input[name=currentDay]").val(currentDay);
            break;
        case "Prev":
            dayStr = $("input[name=currentDay]").val();
            var currentDayObj = new Date(dayStr);
            var _d = new Date();
            var _m = currentDayObj.getTime() + (7 * (1000 * 60 * 60 * 24));
            _d.setTime(_m);
            currentDay = $.cal.format(_d, 'Y-m-d');

            $("input[name=currentDay]").val(currentDay);
            break;

    }

    /**根据当前日期处理这周的起始日期**/
    var currentDayObj = new Date(currentDay);
    var _d = new Date();
    var _m = currentDayObj.getTime() + ((1 - $.cal.format(currentDayObj, 'N')) * (1000 * 60 * 60 * 24));
    _d.setTime(_m);
    beginDay = $.cal.format(_d, 'Y-m-d');
    var _nd = new Date(beginDay);
    var _nm = _nd.getTime() + (6 * (1000 * 60 * 60 * 24));
    _nd.setTime(_nm);
    endDay = $.cal.format(_nd, 'Y-m-d');


    /**处理结束**/
    $calendar = $('#calendarweek').cal({

        startdate: beginDay, // Week beginning sunday.

        //allowresize: true,
        //allowmove: true,
        allowselect: true,
        // allowremove: true,
        //allownotesedit: true,
        daytimestart: '00:00:00',
        daytimeend: '24:00:00',
        eventselect: function (uid) {
            //console.log('Selected event: ' + uid);
            uid = uid.substring(0, uid.indexOf("@"));
            $("#selectedEvent").attr("value", uid);
            //   CalenderControl.OpenBox('../Calendar/CalenderAdd.aspx?id=' + uid, '日程信息')
        },

        eventremove: function (uid) {
            // console.log('Removed event: ' + uid);
        },


        eventnotesedit: function (uid) {
            //console.log('Edited Notes for event: ' + uid);
        },



        events: initCalendar('1', 'week', beginDay, endDay)
    });

    /**
    * Set the initial header value.
    */
    $('#date_head').dateRange($calendar.cal('option', 'startdate'), $calendar.cal('option', 'startdate').addDays($calendar.cal('option', 'daystodisplay') - 1));

}

