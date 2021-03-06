//
// Author: Zhenxing Zhou 
// Blog: http://www.xianfen.net
// Date: 2008-7-11
//

/// <reference path="../JQuery/jquery-1.9.1.js" />

//树列表
function init(userid, deptid, deptname, username, unitid, type) {
    var nd = new ZxjayTreeNode(userid, deptid, unitid);
    nd.container = $$("tree");
    if (type == 1) {
        nd.text = deptname + "-" + username;
    }
    else if (type == 2) {
        nd.text = deptname + "-" + username;
    }
    else if (type == 2) {
        nd.text = "全单位";
    }
    nd.Show();
    currentNode = nd;
    currentNode.Refersh();
}

//５１ａsｐｘ
window.onbeforeunload = function () {
    //return "该页面无法保存当前状态，是否确认退出？";
};

//menuitem 鼠标移上变色        
var menuItems = $$("menu").getElementsByTagName("div");

for (var i = 0; i < menuItems.length; i++) {
    menuItems[i].onmouseover = function () {
        this.style.color = "red";
        this.style.backgroundColor = "#eef";
    }

    menuItems[i].onmouseout = function () {
        this.style.color = "";
        this.style.backgroundColor = "transparent";
    }
}

//加载对话框
var dialog = new ZxjayDialog();
dialog.ImgZIndex = 107;
dialog.DialogZIndex = 108;

//向上
function gotoParentDirectory() {
    if (currentNode != null) {
        currentNode.GotoParentNode();
    }
}

//根目录
function goRoot() {
    currentNode = nd;
    currentNode.Refersh();
}

//刷新
function refersh() {
    if (currentNode != null) {
        currentNode.Refersh();
    }
}

//全选
function selectAll() {
    var checkBoxes = $$("fileList").getElementsByTagName("input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].type == "checkbox") {
            checkBoxes[i].checked = $$("checkAll").checked;
        }
    }
}

//新建目录
function newDirectory() {
    dialog.Content = "<div><span>请输入新目录名称：</span><input id='dirName' type='textbox' style='width:100px;' /></div>";
    dialog.Text = "新建目录";
    dialog.Show();

    var dir = $$("dirName");
    dir.focus();

    dialog.OK = function () {
        if (!(/^[\w\u4e00-\u9fa5-\.]+$/.test(dir.value))) {
            dialog.Content = "<span style='color:red;'>目录名称不正确！</span>";

            dialog.OK = function () {
                newDirectory();
            }

            dialog.Show(1);
            return;
        }
       
        var url = defaultURL + "?action=NEWDIR&value1=" + encodeURIComponent(currentNode.path + dir.value);
        var result = executeHttpRequest("GET", url, null);

        if (result == "OK") {
            currentNode.Refersh();
            dialog.Content = "目录创建成功！";
            dialog.Show(1);
            dialog.OK = dialog.Close;
            SetSize();
        }
        else if (result == "dir") {
            dialog.Content = "该目录下已存在相同名字的文件夹！";
            dialog.Show();

            dialog.OK = dialog.Close;
        }
        else {
            dialog.Content = "<span style='color:red;'>目录创建失败，请重试！</span>";
            dialog.Show();

            dialog.OK = dialog.Close;
        }
    }
}

var fileEditor = new ZxjayDialog();
fileEditor.Content = "<div id='editorDiv'><input id='switchEditor' type='button' value='切换编辑器' /><br /><textarea id='FileContentTextArea' name='FileContentTextArea' cols='80' rows='20' style='width:600px; height:400px;'></textarea></div>";
fileEditor.Width = 624;

var oFCKeditor;             //富文本编辑器对象
var oEditor;                //富文本编辑器实例
var isRichEditor = false;   //当前编辑器状态
var currentContent = "";    //当前输入的内容
var textareaEditor = null;  //文本编辑器实例
var switchButton = null;    //切换编辑器按钮
var list = null;            //选中的文件
var cutCopyOperate = null;
var cutCopyFiles = null;

function switchEditor() {
    getEditorContent();

    if (isRichEditor) {
        isRichEditor = false;
        newFile();
    }
    else {
        isRichEditor = true;
        createEditor();
    }
}

function getEditorContent() {
    if (isRichEditor) {
        currentContent = oEditor.GetXHTML(true);
    }
    else {
        currentContent = textareaEditor.value;
    }
}

function closeConfirm() {
    dialog.Text = "提示";
    dialog.Content = "<span style='color:red;'>文本已经改变，确定不保存直接退出？</span>";
    dialog.Show();

    dialog.OK = function () {
        dialog.Close();
        fileEditor.Hide();
    }
}

function checkFileName() {
    return (/^[\w\u4e00-\u9fa5-\.]+\.[a-zA-Z0-9]{1,8}$/.test($$("inputFile").value));
}

function saveNewFile() {
    if (checkFileName()) {
        var result = saveFile("NEWFILE", $$("inputFile").value);

        dialog.Text = "提示";

        if (result == "OK") {
            dialog.Content = "文件创建成功！";
            currentNode.Refersh();
            fileEditor.Hide();

        }
        else if (result == "EXISTS") {
            dialog.Content = "<span style='color:red;'>同名文件已存在！</span>";
        }
        else {
            dialog.Content = "<span style='color:red;'>文件创建失败！</span>";
        }

        dialog.OK = dialog.Close;
        dialog.Show(1);
    }
    else {
        dialog.Content = "输入的文件名不正确！";
        dialog.Text = "提示";
        dialog.Show(1);

        dialog.OK = function () {
            dialog.Close();
            fileEditor.OK();
        }
    }
}

function newFile() {
    isRichEditor = false;

    fileEditor.Text = "新建文件";
    fileEditor.Show(2);

    //取得编辑器元素
    textareaEditor = $$("FileContentTextArea");
    switchButton = $$("switchEditor");

    textareaEditor.value = currentContent;
    switchButton.onclick = switchEditor;
    fileEditor.Close = closeConfirm;

    fileEditor.OK = function () {
        dialog.Content = "<span>请输入文件名：</span><input id='inputFile' type='textbox' style='width:100px;' />";
        dialog.Text = "输入文件名";
        dialog.Show(2);
        dialog.OK = saveNewFile;

        $$("inputFile").focus();
    }
}

function saveFile(action, fileName) {
    getEditorContent();
    var url = defaultURL + "?action=" + action + "&value1=" + encodeURIComponent(currentNode.path + fileName);
    return executeHttpRequest("POST", url, "content=" + encodeURIComponent(currentContent));
}

function createEditor() {
    if (oFCKeditor == null) {
        oFCKeditor = new FCKeditor('FileContentTextArea');
        oFCKeditor.BasePath = "../../fckeditor/"
        oFCKeditor.Height = '400';
        oFCKeditor.Width = '600';
        oFCKeditor.ToolbarSet = 'Dialog';
        oFCKeditor.Config['FullPage'] = true;
    }

    oFCKeditor.ReplaceTextarea();
}

function getSelectedFile() {
    list = [];
    var checkBoxes = $$("fileList").getElementsByTagName("input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].type == "checkbox") {
            if (checkBoxes[i].checked) {
                list.push(currentNode.path + checkBoxes[i].title);
            }
        }
    }
}

function del() {
    getSelectedFile();
    dialog.Text = "删除文件";

    if (list.length <= 0) {
        dialog.Content = "请选择要删除的文件！";

        dialog.OK = dialog.Close;

        dialog.Show(1);
        return;
    }

    //dialog.Content = "这些文件删除后将不可恢复，是否确定？";
    dialog.Content = "选择的目录及文件删除后将不可恢复，所选目录内的文件将一并删除，是否确定？";
    dialog.Show();

    dialog.OK = function () {
        var url = defaultURL + "?action=DELETE&value1=" + encodeURIComponent(list.join("|"));
        var result = executeHttpRequest("GET", url, null);

        if (result == "OK") {
            currentNode.Refersh();

            dialog.Content = "目录删除成功！";
            dialog.OK = dialog.Close;
            dialog.Show(1);
        }
        else {
            dialog.Content = "<span style='color:red;'>目录删除失败，请重试！</span>";
            dialog.Show(1);
            currentNode.Refersh();
            dialog.OK = dialog.Close;
        }
    }
}

function cut() {
    getSelectedFile();
    dialog.Text = "剪切";

    if (list.length < 1) {
        dialog.Content = "请选择要剪切的文件或文件夹。";
    }
    else {
        //dialog.Content = "已剪切以下文件及文件夹：<br /><div style='text-align:left;'>" + list.join("<br />") + "</div>";
        dialog.Content = "已剪切您所选的文件或文件夹！";
        cutCopyOperate = "CUT";
        cutCopyFiles = list;
    }

    dialog.Show(1);
    dialog.OK = dialog.Close;
}

function copy() {
    getSelectedFile();
    dialog.Text = "复制";

    if (list.length < 1) {
        dialog.Content = "请选择要复制的文件或文件夹。";
    }
    else {
        //dialog.Content = "已复制以下文件及文件夹：<br /><div style='text-align:left;'>" + list.join("<br />") + "</div>";
        dialog.Content = "已复制您所选的文件或文件夹！";
        cutCopyOperate = "COPY";
        cutCopyFiles = list;
    }

    dialog.Show(1);
    dialog.OK = dialog.Close;
}

function paste() {
    dialog.Text = "粘贴";

    if (cutCopyOperate != 'CUT' && cutCopyOperate != 'COPY' || cutCopyFiles.length < 1) {
        dialog.Content = "剪贴板没有任何文件及文件夹。";
        dialog.OK = dialog.Close;
        dialog.Show(1);
        return;
    }

    dialog.Content = "确认将您所选的文件粘贴到当前目录吗?";
    dialog.Show();

    dialog.OK = function () {
        var url = defaultURL + "?action=" + cutCopyOperate + "&value1=" + encodeURIComponent(currentNode.path) + "&value2=" + encodeURIComponent(cutCopyFiles.join("|"));
        var result = executeHttpRequest("GET", url, null);

        if (result == "OK") {
            dialog.Content = "粘贴操作成功！";
            currentNode.Refersh();
        }
        else if (result == "file") {
            dialog.Content = "该目录下已存在相同名字的文件！";
        }
        else if (result == "dir") {
            dialog.Content = "该目录下已存在相同名字的文件夹！";
        }
        else {
            dialog.Content = "<span style='color:red;'>粘贴操作失败！</span>";
        }

        dialog.Show(1);
        dialog.OK = dialog.Close;
    }
}

var iframeOnload = function () { }

function uploadFile() {
    iframeOnload = function () { }
    dialog.Content = "<iframe id='uploadFrm' frameborder='no' border='0' scrolling='no' allowtransparency='yes' onload='iframeOnload()' name='uploadFrm' style='width:0px; height:0px; display:none;'></iframe><form name='actionForm' id='actionForm' action='" + defaultURL + "?action=UPLOAD&value1=" + currentNode.path + "' method='POST' target='uploadFrm' enctype='multipart/form-data'>上传的附件大小不能大于50M！<br><input name='selectFile' width='150' type='file' /></form><div id='uploadStatus' style='display:none;'><img src='../../images/WebFile/unzip.gif' /><div style='color:#ccc;'>正在上传，如果长时间不响应，可能是上传文件太大导致出错！</div></div>";
    dialog.Text = "上传文件";
    dialog.Show();

    dialog.OK = function () {
        iframeOnload = function () {
            var result = frames["uploadFrm"].document.body.innerText;
            if (result == "OK") {
                dialog.Text = "提示";
                dialog.Content = "文件上传成功！";
                dialog.OK = dialog.Close;
                dialog.Show(1);
                currentNode.Refersh();
            } else{
                dialog.Text = "提示";
                dialog.Content = result;
                dialog.OK = dialog.Close;
                dialog.Show(1);
            }
        }

        $$("actionForm").submit();
        $$("actionForm").style.display = "none";
        $$("uploadStatus").style.display = "";
    }
}

function downLoad() {
    getSelectedFile();
    dialog.Text = "下载";

    if (list.length < 1) {
        dialog.Content = "请选择要下载的文件及文件夹。";
        dialog.Show(1);
        dialog.OK = dialog.Close;
        return;
    }

    window.onbeforeunload = function () { }
    window.location.href = defaultURL + "?action=DOWNLOADTOZIP&value1=" + list.join("|");
    //    alert(window.location.href);
    window.onbeforeunload = function () {
        //return "该页面无法保存当前状态，是否确认退出？";
    };
}

renameFile = function (fName) {
    dialog.Text = "重命名：" + fName;
    dialog.Content = "请输入新名称：<input id='newName' type='textbox' style='width:120px;' value='" + fName + "' />";
    dialog.Show();

    var txtNewName = $$("newName");
    txtNewName.value = fName;
    txtNewName.focus();

    dialog.OK = function () {
        if (!(/^[\w\u4e00-\u9fa5-\.]+[a-zA-Z0-9.]*$/.test(txtNewName.value))) {
            dialog.Content = "<span style='color:red;'>输入的新名称不正确！</span>";

            dialog.OK = function () {
                renameFile(fName);
            }

            dialog.Show(1);
            return;
        }

        var url = defaultURL + "?action=RENAME&value1=" + encodeURIComponent(currentNode.path + fName) + "&value2=" + encodeURIComponent(currentNode.path + txtNewName.value);
        var result = executeHttpRequest("GET", url, null);

        if (result == "OK") {
            currentNode.Refersh();

            dialog.Content = "重命名成功！";

            dialog.OK = dialog.Close;

            dialog.Show(1);
        }
        else {
            dialog.Content = "<span style='color:red;'>重命名失败，请重试！</span>";

            dialog.OK = function () {
                renameFile(fName);
            }

            dialog.Show();
        }
    }
}

clickFile = function (fName) {
    window.onbeforeunload = function () { }
    window.location = defaultURL + "?action=DOWNLOAD&value1=" + encodeURIComponent(currentNode.path + fName);

    window.onbeforeunload = function () {
        //     return "该页面无法保存当前状态，是否确认退出？";
    };
}

var currentEditFile = null;

editFile = function (fName) {
    isRichEditor = false;
    currentEditFile = fName;

    fileEditor.Text = "修改文件：" + fName;
    fileEditor.ButtonRetry.value = "重 置";
    fileEditor.Show(3);

    //取得编辑器元素
    textareaEditor = $$("FileContentTextArea");
    switchButton = $$("switchEditor");

    textareaEditor.value = loadFileContent(fName);
    switchButton.onclick = switchEditor;
    fileEditor.Close = closeConfirm;

    fileEditor.OK = function () {
        var result = saveFile("SAVEEDITFILE", fName);

        dialog.Text = "提示";

        if (result == "OK") {
            dialog.Content = "文件保存成功！";
            currentNode.Refersh();
            fileEditor.Hide();
        }
        else {
            dialog.Content = "<span style='color:red;'>文件保存失败！</span>";
        }

        dialog.OK = dialog.Close;
        dialog.Show(1);
    }

    fileEditor.Retry = function () {
        if (isRichEditor) {
            oEditor.SetData(loadFileContent(fName));
        }
        else {
            textareaEditor.value = loadFileContent(fName);
        }
    }
}

var loadFileContent = function (fName) {
    var url = defaultURL + "?action=GETEDITFILE&value1=" + encodeURIComponent(currentNode.path + fName);
    var content = executeHttpRequest("GET", url, null);

    if (content == "ERROR") {
        dialog.Text = "错误";
        dialog.Content = "<span style='color:red;'>读取文件出错！</span>";
        dialog.Show(1);
        content = "";
        dialog.OK = dialog.Close;
    }

    return content;
}

function FCKeditor_OnComplete(editorInstance) {
    oEditor = editorInstance;

    if (currentContent != null) {
        oEditor.SetData(currentContent);
    }
}

function zipFile() {
    getSelectedFile();

    if (list.length < 1) {
        dialog.Text = "提示";
        dialog.Content = "请选择要压缩的文件和文件夹！";
        dialog.Show(1);
        dialog.OK = dialog.Close;
        return;
    }

    dialog.Text = "压缩";
    dialog.Content = "<span>请输入压缩文件名：</span><input id='inputFile' type='textbox' style='width:100px;' />";
    dialog.Show();

    dialog.OK = function () {
        if (checkFileName()) {
            var url = defaultURL + "?action=ZIP&value1=" + encodeURIComponent(currentNode.path + $$("inputFile").value) + "&value2=" + encodeURIComponent(list.join("|"));
            var result = executeHttpRequest("GET", url, null);

            dialog.Text = "提示";

            if (result == "OK") {
                dialog.Content = "压缩成功！";
                currentNode.Refersh();
            }
            else {
                dialog.Content = "压缩失败！";
            }

            dialog.OK = dialog.Close;
            dialog.Show(1);
        }
        else {
            dialog.Content = "输入的文件名不正确！";
            dialog.Text = "提示";
            dialog.Show(1);

            dialog.OK = function () {
                dialog.Close();
                zipFile();
            }
        }
    }
}

function unZipFile() {
    getSelectedFile();

    if (list.length < 1) {
        dialog.Text = "提示";
        dialog.Content = "请选择要解压的文件！";
        dialog.Show(1);

        dialog.OK = dialog.Close;

        return;
    }

    var url = defaultURL + "?action=UNZIP&value1=" + encodeURIComponent(currentNode.path) + "&value2=" + encodeURIComponent(list.join("|"));
    var result = executeHttpRequest("GET", url, null);

    dialog.Text = "提示";

    if (result == "OK") {
        dialog.Content = "解压成功！";
        currentNode.Refersh();
    }
    else {
        dialog.Content = "解压失败！";
    }

    dialog.OK = dialog.Close;
    dialog.Show(1);
}

$$("tree").style.height = document.documentElement.clientHeight + "px";

if (document.compatMode != 'CSS1Compat') {
    $$("tree").style.height = document.body.clientHeight + "px";
}


$(function () {

    SetSize();
});

function SetSize() {
    var HolePageWidth = $(window).width();
    var HolePageHeight = $(window).height();

    var TreeWidth = HolePageWidth * .3;
    var optbarHeight = $("#optbar").height();
    var fileListHeadHeight = $("#fileListHead").height();

    var chkColumn = $("#fileListHead > .chkColumn").width();
    var fileType = $("#fileListHead > .fileType").width();
    var fileSize = $("#fileListHead > .fileSize").width();
    var lastUpdate = $("#fileListHead > .lastUpdate").width();
    var rename = $("#fileListHead > .rename").width();
    var fileName = HolePageWidth - chkColumn - fileType - fileSize - lastUpdate - $("#QueryArea").width() - 21;
    $("#fileExplorer").width(HolePageWidth - $("#QueryArea").width());

    $("#fileListHead > .fileName").width(fileName);
    $("#fileList").find(".fileName").each(function () { $(this).width(fileName) });
    //  $("#fileList").find(".rename").each(function () { $(this).width(rename - 20) });

    $("#fileList .fileItem:odd").addClass("odd");
    $("#fileList").height(HolePageHeight - optbarHeight - fileListHeadHeight);

}