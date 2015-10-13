/// <reference path="../JQuery/jquery-1.9.1.js" />
/// <reference path="Config.js" />
/// <reference path="DataControl.js" />

// 附件上传组件控制脚本
//使用举例：
// <input runat="server" clientidmode="Static" type="file" id="File3" class="uploadify" data-idprefix="a5" data-tablename="CallBoard" data-kindof="5" data-multi="true" data-queuesizelimit="5" data-attachidcontrol="HF_5" data-uploadedcontrol="HF_5_HasUploaded" />
//  <asp:HiddenField ClientIDMode="Static" ID="HF_5" runat="server" />
//  <input type="hidden" runat="server" id="HF_5_HasUploaded" value="true" datatype="*" nullmsg="附件上传未完成！" />
//说明：
//在页面中创建3个控件
//其中第一个是type为“file”的input，要使用异步上传组件，应将class设置为“uploadify”，
//  data-idprefix:控件前缀，用于区别页面上的其他上传控件
//  data-tablename 对应附件表中的TableName字段
//  data-kindof 对应附件表中的kindof字段
//  data-multi是否可以上传多个附件
//  data-queuesizelimit允许上传的最大文件数
//  data-attachidcontrol用于存放已上传文件的id值的控件ID。
//  data-uploadedcontrol用于标识是否还有未上传的附件，该控件的value在附件开始上传之前会设置为空，上传完成时会设置为true
//第二个是data-attachidcontrol对应的服务器端控件，若不需要从后台取值，可使用html控件。此处多半需要从后台取得该值，所以建议使用asp:HiddenField并将其设置为ClientIDMode="Static"。若上传单个附件，该控件的值为上传文件在数据库中的ID，且多次上传后仅保留最后一个文件，之前的文件将会从数据库中物理删除；若上传多个附件，该控件以逗号分割存放文件ID，且最后会多一个逗号，请注意，上传文件总数达到设置值的时候，上传按钮会被禁用，并且取消队列中正在上传的附件，在删除已上传的文件后才可以添加其他文件
//第三个是ata-uploadedcontrol对应的控件

$(
    function () {
        $(".uploadify").each(UploadControl.Init);
    }
);


var UploadControl = {};

UploadControl.Init = function () {
    var Prefix = $(this).attr("data-idprefix");
    var TableName = $(this).attr("data-tablename");
    var KindOf = $(this).attr("data-kindof");
    var Multi = eval($(this).attr("data-multi"));
    var QueueSizeLimit = eval($(this).attr("data-queueSizeLimit"));
    var AttachIDControl = $(this).attr("data-attachidcontrol");
    var UploadedControl = $(this).attr("data-uploadedcontrol");
    var ID = $(this).attr("id");
    var uploadifyer = this;

    var UploadedAttach;
    if (QueueSizeLimit > 1) {
        UploadedAttach = "<div id=\"" + Prefix + "_UploadedAttach\" class=\"uploadedattach-s\"></div>";
    } else {
        UploadedAttach = "<div id=\"" + Prefix + "_UploadedAttach\" class=\"uploadedattach\"></div>";
    }
    $(uploadifyer).after(UploadedAttach);

    var FileQueue = "<div id=\"" + Prefix + "_FileQueue\" class=\"fileQueue\"></div>";
    $(uploadifyer).after(FileQueue);


    $(uploadifyer).uploadify({
        swf: Config.UploadifySwf,
        uploader: Config.UploadifyServerPage,
        queueID: Prefix + '_FileQueue',
        auto: true,
        formData: { 'TableName': TableName, 'KindOf': KindOf },
        multi: Multi,  //允许上传多个文件
        buttonText: "浏&nbsp;&nbsp;&nbsp;&nbsp;览...",
        removeCompleted: true,
        removeTimeout: 1,
        fileSizeLimit: '50MB',
        queueSizeLimit: QueueSizeLimit,
        successTimeout: 300,
        onUploadStart: function (file) {
            if ($("#" + Prefix + "_UploadedAttach").find("table").length >= QueueSizeLimit) {
                $(uploadifyer).uploadify('stop');
                $(uploadifyer).uploadify('cancel', '*');
                alert("总文件数超过限制，仅能上传最多" + QueueSizeLimit + "个文件，其余文件上传已自动取消，请删除部分文件再试。");
            }

            $("#" + UploadedControl).val("");
        },
        onUploadSuccess: function (file, data, response) {
            var AttachID = $.parseJSON(data).attachid;
            UploadControl.ShowUploadedAttach(Prefix + "_UploadedAttach", AttachID, file, Multi, AttachIDControl, ID);
        },
        onUploadError: function (file, errorCode, errorMsg, errorString) {
        },
        onQueueComplete: function (queueData) {
            $("#" + UploadedControl).val(true);
            if ($("#" + Prefix + "_UploadedAttach").find("table").length >= 5) {
                $(uploadifyer).uploadify('disable', true);
            }
        }
    });
}

UploadControl.ShowUploadedAttach = function (UploadedQueueID, AttachID, FileObj, Multi, AttachIDControl, ID) {
    var AttachItemHtml = '<table border="0" cellpadding="0" cellspacing="0" id="Uploaded_' + AttachID + '"><tr><td class="img" rowspan="2"><img src="' + Config.ShowAttachPage.replace(/@ID/g, AttachID) + '" /></td><td class="filename" colspan="2"><span>' + FileObj.name + '</span></td></tr><tr><td class="filesize">' + UploadControl.GetSize(FileObj.size) + '</td><td class="delete"><img src="' + Config.DeleteAttachImg + '" onclick="UploadControl.DelUploadedAttach(' + AttachID + ',\'' + ID + '\')" /></td></tr></table>';

    if (Multi) {
        $("#" + UploadedQueueID).append(AttachItemHtml);
    } else {
        $("#" + UploadedQueueID).html(AttachItemHtml);
        if ($("#" + AttachIDControl).val() != undefined && $("#" + AttachIDControl).val() != "") {
            UploadControl.DelUploadedAttach($("#" + AttachIDControl).val());
        }
    }

    var AttachIDControlValue = $("#" + AttachIDControl).val();
    if (Multi) {
        AttachIDControlValue += (AttachID + ",");
    } else {
        AttachIDControlValue = AttachID;
    }
    $("#" + AttachIDControl).val(AttachIDControlValue);
}

UploadControl.DelUploadedAttach = function (AttachID, ID) {
    DataControl.GetJsonDataAndExecuteFun("{ 'AttachID': '" + AttachID + "' }", "DelAttach");
    $("#Uploaded_" + AttachID).remove();
    if (ID!=undefined) {
        $("#" + ID).uploadify('disable', false);
    }
    
}

UploadControl.GetSize = function (size) {
    /// <summary>获取附件大小字符串</summary>
    /// <param name="size" type="Number">以字节为单位的文件大小</param>
    /// <returns type="String" />
//    var fileSize = Math.round(size / 1024);
//    var suffix = 'Kb';
//    if (fileSize > 1000) {
//        fileSize = Math.round(fileSize / 1000);
//        suffix = 'M';
    //    }
    var fileSize = 0;
    var suffix = 'byte';

    if (size < 1024) {
        suffix = 'byte';
        fileSize = size;
    } else if (size / 1024 < 1024) {
        suffix = 'Kb';
        fileSize = Math.round(size / 1024);
    } else if (size / 1024 / 1024 < 1024) {
        suffix = 'M';
        fileSize = size / 1024 / 1024;
    }
    var fileSizeParts = fileSize.toString().split('.');
    fileSize = fileSizeParts[0];
    if (fileSizeParts.length > 1) {
        fileSize += '.' + fileSizeParts[1].substr(0, 2);
    }
    fileSize += suffix;

    return fileSize;
}

UploadControl.Remove = function () {
    $(".uploadify").remove();
}