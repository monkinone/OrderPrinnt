/**日期选择控件
创建时间：2013-04-28
基于jquery：bootstrap-datetimepicker 组件进行创建的类 注意如果动态加载的js没有完成，就关闭了窗口则可能出现脚本错误
**/
document.write('<script src="/scripts/bootstrap-datetimepicker-master/bootstrap/bootstrap.js"  type="text/javascript" charset="UTF-8"></script>');
document.write('<script src="/scripts/bootstrap-datetimepicker-master/bootstrap-datetimepicker.js" type="text/javascript" charset="UTF-8"></script>');
document.write('<script src="/scripts/bootstrap-datetimepicker-master/locales/bootstrap-datetimepicker.zh-CN.js" type="text/javascript" charset="UTF-8"></script>');
var TimeContral = {};
/** 动态加载js 及css 样式
$.extend({
    includePath: '',
    include: function (file) {
        var files = typeof file == "string" ? [file] : file;
        for (var i = 0; i < files.length; i++) {
            var name = files[i].replace(/^\s|\s$/g, "");
            var att = name.split('.');
            var ext = att[att.length - 1].toLowerCase();
            var isCSS = ext == "css";
            var tag = isCSS ? "link" : "script";
            var attr = isCSS ? " type='text/css' rel='stylesheet' " : " language='javascript' type='text/javascript' ";
            var link = (isCSS ? "href" : "src") + "='" + $.includePath + name + "'";
            if ($(tag + "[" + link + "]").length == 0) document.write("<" + tag + attr + link + "></" + tag + ">");
        }
    }
});
$.include(['http://image.esunny.com/script/jquery.divbox.js', '/css/pop_win.css']);
**/
TimeContral._SourceList = new Array(); //注意顺序不能错
TimeContral._SourceList[0] = '/themes/default/styles/bootstrap-datetimepicker-master/datetimepicker.css';
TimeContral._SourceList[1] = '/themes/default/styles/bootstrap-datetimepicker-master/bootstrap.min.css';
//TimeContral._SourceList[2] = '/scripts/bootstrap-datetimepicker-master/bootstrap/bootstrap.min.js';
//TimeContral._SourceList[3] = '/scripts/bootstrap-datetimepicker-master/bootstrap-datetimepicker.js';
//TimeContral._SourceList[4] = '/scripts/bootstrap-datetimepicker-master/locales/bootstrap-datetimepicker.zh-CN.js';

TimeContral.PageTimeMark = "_timecontral"; //页面上input 是否为 时间控件类型的标记 <input class='_timecontral' type=text value=>
TimeContral.PageTimeItemCss = " Wdate tbox  controls input-append date ";
TimeContral.PageTimeItemCssKey = "form_datetime"
TimeContral.init = function (tMark) {//入口方法

    TimeContral.loadResource(TimeContral._SourceList);
    

    TimeContral.pageInit(tMark);
}

TimeContral.pageInit = function (tMark) {//进行页面事件控件的初始化
    if (typeof tMark == "undefiend") {

        TimeContral.pageChangeTimeItems(TimeContral.PageTimeMark);
    } else {
        TimeContral.pageChangeTimeItems(tMark);

    }
}
TimeContral.pageChangeTimeItems = function (mark) {

    var _tMark = typeof mark == "string" ? [mark] : mark;
    for (var j = 0; j < _tMark.length; j++) {

        var _items = $("." + _tMark[j]);

        for (var i = 0; i < _items.length; i++) {

            var _class = $(_items[i]).attr("class");
            _class = TimeContral.PageTimeItemCss + TimeContral.PageTimeItemCssKey + "-" + i + " ";
            $(_items[i]).attr("class", _class);

            $(_items[i]).attr("data-date", " ");
            $(_items[i]).attr("onfocus", " ");
            var value = $(_items[i]).attr("value");
            if (typeof(value) != "undefined") {
                value = value.replace(/\//g, '-');
            }
            $(_items[i]).attr("value", value);

            //$("." + TimeContral.PageTimeItemCssKey + "-" + i).datetimepicker({
            $(_items[i]).datetimepicker({
                language: 'zh-CN',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                forceParse: 0,
                showMeridian: 1,
                format: 'yyyy-mm-dd hh:ii'
            });


        }
    }
}


/**
TimeContral.needResource = function () {

    var _SourceList = new Array(); //注意顺序不能错
    _SourceList[0] = './themes/default/styles/bootstrap-datetimepicker-master/datetimepicker.css';
    _SourceList[1] = './themes/default/styles/bootstrap-datetimepicker-master/bootstrap.min.css';
    _SourceList[2] = './scripts/bootstrap-datetimepicker-master/bootstrap/bootstrap.min.js';
    _SourceList[3] = './scripts/bootstrap-datetimepicker-master/bootstrap-datetimepicker.js';
    _SourceList[4] = '../scripts/bootstrap-datetimepicker-master/locales/bootstrap-datetimepicker.zh-CN.js';
    TimeContral.loadResource(_SourceList);
    /**需要的样式单**/
    /**
    document.write('<link href="../themes/default/styles/bootstrap-datetimepicker-master/datetimepicker.css" rel="stylesheet" type="text/css" />');
    document.write('<link href="../themes/default/styles/bootstrap-datetimepicker-master/bootstrap.min.css"  rel="stylesheet" type="text/css" />');
    /**需要的js库**/
    /**
    document.write('<script src="../scripts/bootstrap-datetimepicker-master/bootstrap/bootstrap.min.js"  type="text/javascript" charset="UTF-8"></script>');
    document.write('<script src="../scripts/bootstrap-datetimepicker-master/bootstrap-datetimepicker.js" type="text/javascript" charset="UTF-8"></script>');
    document.write('<script src="../scripts/bootstrap-datetimepicker-master/locales/bootstrap-datetimepicker.zh-CN.js" type="text/javascript" charset="UTF-8"></script>');
    **/


/**}**/
TimeContral.loadResource = function (file) {
    var files = typeof file == "string" ? [file] : file;

    for (var i = 0; i < files.length; i++) {

        var name = files[i].replace(/^\s|\s$/g, "");
        var att = name.split('.');
        var ext = att[att.length - 1].toLowerCase();
        var isCSS = ext == "css";
        var tag = isCSS ? "link" : "script";
        var attr = isCSS ? " type='text/css' rel='stylesheet' " : "  type='text/javascript' charset='UTF-8' ";
        //var link = (isCSS ? "href" : "src") + "='" + $.includePath + name + "'";
        var link = (isCSS ? "href" : "src") + "='" + name + "'";
        if ($(tag + "[" + link + "]").length == 0) {
            document.write("<" + tag + attr + link + "></" + tag + ">");

           // alert("<" + tag + attr + link + "></" + tag + ">");
        }


    }
}