/// <reference path="../JQuery/jquery-1.7.2.js" />
/// <reference path="Config.js" />
/// <reference path="DataControl.js" />

var UserChooserControl = {};

UserChooserControl.GetDeptUserData = function (usernames,userids ) {
    /// <summary>获取日程提醒列表</summary>
    DataControl.GetJsonDataAndExecuteFun("{ 'UserUnitid': '" + userunitid + "' }", "getDeptUserIDByUnit", "UserChooserControl.BindUserInfo(data,'"+userids+"','"+usernames+"')");
}

UserChooserControl.BindUserInfo = function (data, userids, usernames) {
    var DataObj = $.parseJSON(data.d);
    var USERNAMEs = "";
    var USERIDs="";
    $(DataObj).each(function () {
        USERNAMEs +=   this["USER_NAME"]+";";
        USERIDs +=   this["USER_ID"]+";";
    });
    $("#" + userids).val(USERIDs.toString().substring(0, USERIDs.length-1));
    $("#" + usernames).val(USERNAMEs.toString().substring(0, USERNAMEs.length-1));
}
