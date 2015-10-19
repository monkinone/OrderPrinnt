/// <reference path="../JQuery/jquery-1.9.1.js" />

var Config = {};

Config.AppStartupDir = "";   //应用虚拟目录名称，如访问地址为 http://localhost:8001/DCQWBOA/， 则此处应修改为“/DCQWBOA”
Config.DefaultImageFolder = Config.AppStartupDir + "/themes/default/images";  //默认图片路径
Config.WebServiceUrl = Config.AppStartupDir + "/ServiceJson.asmx";  //默认WebService地址
