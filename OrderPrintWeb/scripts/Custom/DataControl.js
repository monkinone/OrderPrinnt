/// <summary>本JS为数据操作提供通用方法</summary>
/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="Config.js" />

var DataControl = {};

DataControl.UserInfo = {};

DataControl.GetJsonDataAndExecuteFun = function (Params, WSName, Fun) {
    $.ajax({
        type: "POST",   //访问WebService使用Post方式请求
        contentType: "application/json",
        url: Config.WebServiceUrl + "/" + WSName,
        data: Params,         //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到         
        dataType: 'json',
        success: function (data) {
            if (Fun != undefined && Fun != "") {
                eval(Fun);
            }
        },
        error: function (xml, status) {
            if (status == 'error') {
                try {
                    var json = eval('(' + xml.responseText + ')');
                    //alert(json.Message + '\n' + json.StackTrace);
                } catch (e) { }
            } else {
                //alert(status);
            }
        },
        cache: false
    });
}

DataControl.GetXMLDataAndExecuteFun = function (Params, WSName, Fun) {
    $.ajax({
        type: "POST",   //访问WebService使用Post方式请求
        url: Config.WebServiceUrl + "/" + WSName,
        data: Params,         //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到         
        dataType: 'xml',
        success: function (data) {
            if (Fun != undefined && Fun != "") {
                eval(Fun);
            }
        },
        error: function (xml, status) {
            if (status == 'error') {
                try {
                    var json = eval('(' + xml.responseText + ')');
                    alert(json.Message + '\n' + json.StackTrace);
                } catch (e) { }
            } else {
                //alert(status);
            }
        },
        cache: false
    });
}