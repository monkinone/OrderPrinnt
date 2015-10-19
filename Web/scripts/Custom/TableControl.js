/// <reference path="../JQuery/jquery-1.9.1.js" />

$(function () {
    TableControl.SetStyle();
});

var TableControl = {};
TableControl.SetStyle = function () {
    $(".tb").each(function () {
        var Table = $(this);

        Table.find("tr:even").addClass("even");
        Table.find("tr:odd").addClass("odd");

        Table.find("td").each(function () {
            if ($(this).html() == "") {
                $(this).html("&nbsp;") 
            }
        });
    });
}