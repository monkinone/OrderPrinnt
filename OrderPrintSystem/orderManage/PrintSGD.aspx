<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSGD.aspx.cs" Inherits="orderManage_PrintSGD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="ProgId" content="Excel.Sheet" />
    <meta name="Generator" content="WPS Office ET" />
    <base target="_self" />
    <link href="../themes/default/styles/details.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/select.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../themes/default/styles/orderTable.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>

    <style>
        <!-- @page {
            margin: 0.00in 0.00in 0.00in 0.00in;
            mso-header-margin: 0.00in;
            mso-footer-margin: 0.00in;
            mso-horizontal-page-align: center;
        }

        tr {
            mso-height-source: auto;
            mso-ruby-visibility: none;
        }

        col {
            mso-width-source: auto;
            mso-ruby-visibility: none;
        }

        br {
            mso-data-placement: same-cell;
        }

        .font0 {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font1 {
            color: #003366;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font2 {
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font3 {
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font4 {
            color: #333399;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font5 {
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font6 {
            color: #003366;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font7 {
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font8 {
            color: #FF9900;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font9 {
            color: #FF9900;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font10 {
            color: #003366;
            font-size: 13.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font11 {
            color: #006411;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font12 {
            color: #333333;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font13 {
            color: #000000;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font14 {
            color: #DD0806;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font15 {
            color: #808080;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: italic;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font16 {
            color: #F20884;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font17 {
            color: #993300;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font18 {
            color: #003366;
            font-size: 15.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "微软雅黑";
            mso-font-charset: 134;
        }

        .font19 {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font20 {
            color: #000000;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font21 {
            color: #000000;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font22 {
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font23 {
            color: #000000;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font24 {
            color: #000000;
            font-size: 16.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font25 {
            color: #DD0806;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font26 {
            color: #DD0806;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font27 {
            color: #000000;
            font-size: 10.5pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font28 {
            color: windowtext;
            font-size: 10.5pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font29 {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font30 {
            color: #000000;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font31 {
            color: #000000;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font32 {
            color: windowtext;
            font-size: 10.5pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font33 {
            color: #DD0806;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .font34 {
            color: #DD0806;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "宋体";
            mso-font-charset: 134;
        }

        .style0 {
            mso-number-format: "General";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            mso-rotate: 0;
            mso-pattern: auto;
            mso-background-source: auto;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            mso-font-charset: 134;
            border: none;
            mso-protection: locked visible;
            mso-style-name: "Normal";
            mso-style-id: 0;
        }

        .style16 {
            mso-number-format: "General";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            mso-rotate: 0;
            mso-pattern: auto;
            mso-background-source: auto;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            mso-font-charset: 134;
            border: none;
            mso-protection: locked visible;
            mso-style-name: "常规_Sheet1_5";
        }

        .style17 {
            mso-number-format: "_ * \#\,\#\#0\.00_ \;_ * \\-\#\,\#\#0\.00_ \;_ * \0022-\0022??_ \;_ \@_ ";
            mso-style-name: "Comma";
            mso-style-id: 3;
        }

        .style18 {
            mso-number-format: "_ \0022\00A5\0022* \#\,\#\#0\.00_ \;_ \0022\00A5\0022* \\-\#\,\#\#0\.00_ \;_ \0022\00A5\0022* \\-??_ \;_ \@_ ";
            mso-style-name: "Currency";
            mso-style-id: 4;
        }

        .style19 {
            mso-number-format: "_ * \#\,\#\#0_ \;_ * \\-\#\,\#\#0_ \;_ * \0022-\0022_ \;_ \@_ ";
            mso-style-name: "Comma[0]";
            mso-style-id: 6;
        }

        .style20 {
            mso-pattern: auto none;
            background: #800080;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "强调文字颜色 4";
        }

        .style21 {
            mso-number-format: "0%";
            mso-style-name: "Percent";
            mso-style-id: 5;
        }

        .style22 {
            mso-pattern: auto none;
            background: #FFCC99;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "20% - 强调文字颜色 2";
        }

        .style23 {
            color: #003366;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            mso-font-charset: 134;
            mso-style-name: "标题";
        }

        .style24 {
            mso-number-format: "_ \0022\00A5\0022* \#\,\#\#0_ \;_ \0022\00A5\0022* \\-\#\,\#\#0_ \;_ \0022\00A5\0022* \\-_ \;_ \@_ ";
            mso-style-name: "Currency[0]";
            mso-style-id: 7;
        }

        .style25 {
            mso-pattern: auto none;
            background: #FFFFFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "20% - 强调文字颜色 1";
        }

        .style26 {
            mso-pattern: auto none;
            background: #CCCCFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "20% - 强调文字颜色 3";
        }

        .style27 {
            mso-pattern: auto none;
            background: #FFCC99;
            color: #333399;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border: .5pt solid #808080;
            mso-style-name: "输入";
        }

        .style28 {
            mso-pattern: auto none;
            background: #FFFFFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "20% - 强调文字颜色 4";
        }

        .style29 {
            mso-pattern: auto none;
            background: #CCFFFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "20% - 强调文字颜色 5";
        }

        .style30 {
            mso-pattern: auto none;
            background: #333399;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "强调文字颜色 1";
        }

        .style31 {
            mso-pattern: auto none;
            background: #FFCC99;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "20% - 强调文字颜色 6";
        }

        .style32 {
            color: #FF9900;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border-left: none;
            border-top: none;
            border-right: none;
            border-bottom: 2.0pt double #FF9900;
            mso-style-name: "链接单元格";
        }

        .style33 {
            mso-pattern: auto none;
            background: #90713A;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "强调文字颜色 2";
        }

        .style34 {
            mso-pattern: auto none;
            background: #99CCFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "40% - 强调文字颜色 1";
        }

        .style35 {
            mso-pattern: auto none;
            background: #FFCC99;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "40% - 强调文字颜色 2";
        }

        .style36 {
            mso-pattern: auto none;
            background: #CCCCFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "40% - 强调文字颜色 3";
        }

        .style37 {
            mso-pattern: auto none;
            background: #FF99CC;
            color: #F20884;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "差";
        }

        .style38 {
            mso-pattern: auto none;
            background: #CC99FF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "40% - 强调文字颜色 4";
        }

        .style39 {
            mso-pattern: auto none;
            background: #99CCFF;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "40% - 强调文字颜色 5";
        }

        .style40 {
            mso-pattern: auto none;
            background: #FFCC00;
            color: #000000;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "40% - 强调文字颜色 6";
        }

        .style41 {
            mso-pattern: auto none;
            background: #0066CC;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "60% - 强调文字颜色 1";
        }

        .style42 {
            color: #003366;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border-left: none;
            border-top: none;
            border-right: none;
            border-bottom: 1.0pt solid #0066CC;
            mso-style-name: "标题 3";
        }

        .style43 {
            mso-pattern: auto none;
            background: #FF8080;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "60% - 强调文字颜色 2";
        }

        .style44 {
            color: #003366;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "标题 4";
        }

        .style45 {
            color: #DD0806;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "警告文本";
        }

        .style46 {
            mso-pattern: auto none;
            background: #CCCCFF;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "60% - 强调文字颜色 3";
        }

        .style47 {
            mso-pattern: auto none;
            background: #C0C0C0;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "60% - 强调文字颜色 4";
        }

        .style48 {
            mso-pattern: auto none;
            background: #C0C0C0;
            color: #333333;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border: .5pt solid #333333;
            mso-style-name: "输出";
        }

        .style49 {
            mso-pattern: auto none;
            background: #33CCCC;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "60% - 强调文字颜色 5";
        }

        .style50 {
            mso-pattern: auto none;
            background: #FFCC99;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "60% - 强调文字颜色 6";
        }

        .style51 {
            color: #003366;
            font-size: 15.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border-left: none;
            border-top: none;
            border-right: none;
            border-bottom: 1.5pt solid #333399;
            mso-style-name: "标题 1";
        }

        .style52 {
            color: #003366;
            font-size: 13.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border-left: none;
            border-top: none;
            border-right: none;
            border-bottom: 1.5pt solid #C0C0C0;
            mso-style-name: "标题 2";
        }

        .style53 {
            mso-number-format: "General";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            mso-rotate: 0;
            mso-pattern: auto;
            mso-background-source: auto;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            mso-font-charset: 134;
            border: none;
            mso-protection: locked visible;
            mso-style-name: "常规_Sheet1";
        }

        .style54 {
            mso-number-format: "General";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            mso-rotate: 0;
            mso-pattern: auto;
            mso-background-source: auto;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            mso-font-charset: 134;
            border: none;
            mso-protection: locked visible;
            mso-style-name: "常规_Sheet1_4";
        }

        .style55 {
            mso-pattern: auto none;
            background: #CCFFCC;
            color: #006411;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "好";
        }

        .style56 {
            color: #000000;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border-left: none;
            border-top: .5pt solid #333399;
            border-right: none;
            border-bottom: 2.0pt double #333399;
            mso-style-name: "汇总";
        }

        .style57 {
            mso-pattern: auto none;
            background: #C0C0C0;
            color: #FF9900;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border: .5pt solid #808080;
            mso-style-name: "计算";
        }

        .style58 {
            mso-pattern: auto none;
            background: #969696;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            border: 2.0pt double #333333;
            mso-style-name: "检查单元格";
        }

        .style59 {
            mso-pattern: auto none;
            background: #CCCCFF;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "强调文字颜色 3";
        }

        .style60 {
            mso-pattern: auto none;
            background: #33CCCC;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "强调文字颜色 5";
        }

        .style61 {
            mso-pattern: auto none;
            background: #FF8080;
            color: #FFFFFF;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "强调文字颜色 6";
        }

        .style62 {
            color: #808080;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: italic;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "说明文本";
        }

        .style63 {
            mso-pattern: auto none;
            background: #FFFFCC;
            color: #993300;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 微软雅黑, sans-serif;
            mso-font-charset: 134;
            mso-style-name: "无色";
        }

        .style64 {
            mso-pattern: auto none;
            background: #FFFF99;
            border: .5pt solid #C0C0C0;
            mso-style-name: "注释";
        }

        td {
            mso-style-parent: style0;
            padding-top: 1px;
            padding-right: 1px;
            padding-left: 1px;
            mso-ignore: padding;
            mso-number-format: "General";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            mso-rotate: 0;
            mso-pattern: auto;
            mso-background-source: auto;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            mso-font-charset: 134;
            border: none;
            mso-protection: locked visible;
        }

        .xl66 {
            mso-style-parent: style0;
            font-size: 11.0pt;
        }

        .xl67 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 18.0pt;
            font-weight: 700;
        }

        .xl68 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
        }

        .xl69 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
        }

        .xl70 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
        }

        .xl71 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl72 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl73 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl74 {
            mso-style-parent: style54;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-top: 1.0pt solid #000000;
            border-right: .5pt solid #000000;
        }

        .xl75 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl76 {
            mso-style-parent: style53;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl77 {
            mso-style-parent: style53;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-right: .5pt solid windowtext;
        }

        .xl78 {
            mso-style-parent: style53;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl79 {
            mso-style-parent: style53;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl80 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl81 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl82 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl83 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl84 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl85 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl86 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl87 {
            mso-style-parent: style0;
            mso-number-format: "0\.00%";
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl88 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl89 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl90 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl91 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl92 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl93 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl94 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl95 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl96 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl97 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl98 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl99 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl100 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl101 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl102 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl103 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
        }

        .xl104 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl105 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl106 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl107 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl108 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl109 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl110 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl111 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl112 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl113 {
            mso-style-parent: style0;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl114 {
            mso-style-parent: style0;
            text-align: center;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl115 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl116 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl117 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl118 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl119 {
            mso-style-parent: style0;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl120 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl121 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl122 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl123 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 10.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl124 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 10.0pt;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl125 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl126 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl127 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl128 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl129 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl130 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl131 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-bottom: .5pt solid windowtext;
        }

        .xl132 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl133 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl134 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl135 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl136 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl137 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
        }

        .xl138 {
            mso-style-parent: style0;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl139 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl140 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 16.0pt;
            font-weight: 700;
            border: 1.0pt solid windowtext;
        }

        .xl141 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border: 1.0pt solid windowtext;
        }

        .xl142 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl143 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border: 1.0pt solid windowtext;
        }

        .xl144 {
            mso-style-parent: style0;
            font-size: 11.0pt;
            border: 1.0pt solid windowtext;
        }

        .xl145 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
        }

        .xl146 {
            mso-style-parent: style0;
            white-space: normal;
            font-size: 11.0pt;
        }

        .xl147 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl148 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl149 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
        }

        .xl150 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
        }

        .xl151 {
            mso-style-parent: style53;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
        }

        .xl152 {
            mso-style-parent: style53;
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
        }

        .xl153 {
            mso-style-parent: style0;
            white-space: normal;
        }

        .xl154 {
            mso-style-parent: style0;
            mso-number-format: "0\.00%";
            text-align: center;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl155 {
            mso-style-parent: style0;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl156 {
            mso-style-parent: style0;
            text-align: center;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
        }

        .xl157 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl158 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl159 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl160 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl161 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl162 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
        }

        .xl163 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
        }

        .xl164 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl165 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl166 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl167 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-left: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl168 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            color: #000000;
            font-size: 11.0pt;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl169 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
        }

        .xl170 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
        }

        .xl171 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
        }

        .xl172 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            font-weight: 700;
            border-left: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl173 {
            mso-style-parent: style0;
            text-align: left;
            color: #000000;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl174 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl175 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #DD0806;
            font-size: 9.0pt;
            border: .5pt solid windowtext;
        }

        .xl176 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #DD0806;
            font-size: 11.0pt;
            border: .5pt solid windowtext;
        }

        .xl177 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #DD0806;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl178 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #DD0806;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl179 {
            mso-style-parent: style16;
            text-align: justify;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 10.5pt;
            font-weight: 700;
        }

        .xl180 {
            mso-style-parent: style0;
            text-align: justify;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 10.5pt;
            font-weight: 700;
        }

        .xl181 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            color: #DD0806;
            font-size: 9.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl182 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl183 {
            mso-style-parent: style16;
            text-align: justify;
            vertical-align: top;
            font-size: 10.5pt;
            font-weight: 700;
        }

        .xl184 {
            mso-style-parent: style0;
            text-align: justify;
            vertical-align: top;
            font-size: 10.5pt;
            font-weight: 700;
        }

        .xl185 {
            mso-style-parent: style16;
            text-align: center;
            vertical-align: top;
            font-weight: 700;
        }

        .xl186 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            font-weight: 700;
        }

        .xl187 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl188 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .xl189 {
            mso-style-parent: style16;
            text-align: center;
            vertical-align: top;
            color: #000000;
            font-weight: 700;
        }

        .xl190 {
            mso-style-parent: style0;
            text-align: center;
            vertical-align: top;
            color: #000000;
            font-weight: 700;
        }

        .xl191 {
            mso-style-parent: style16;
            text-align: left;
            white-space: normal;
            color: #000000;
            font-size: 9.0pt;
        }

        .xl192 {
            mso-style-parent: style0;
            text-align: left;
            white-space: normal;
            color: #000000;
            font-size: 9.0pt;
        }

        .xl193 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl194 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl195 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            color: #000000;
            font-size: 11.0pt;
            border-left: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
        }

        .xl196 {
            mso-style-parent: style16;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            font-size: 10.5pt;
        }

        .xl197 {
            mso-style-parent: style0;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            font-size: 10.5pt;
        }

        .xl198 {
            mso-style-parent: style0;
            font-size: 11.0pt;
        }

        .xl199 {
            mso-style-parent: style0;
        }
        -->
    </style>

    <script type="text/javascript">

        //修改打印次数
        function update() {

            $.ajax({
                type: "Post",
                async: false,
                url: "PrintSGD.aspx/UpdatePrint",
                data: "",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d > 0) {
                        //   alert('成功');
                    } else {
                        // alert('失败');
                    }
                },
                error: function (xml, status) {
                    if (status == 'error') {
                        try {
                            var json = eval('(' + xml.responseText + ')');
                            //                        alert(json.Message + '\n' + json.StackTrace);
                        } catch (e) { }
                    } else {
                        //                    alert(status);
                    }
                }
            });

        }

        function doPrint() {
            // pagesetup_null();
            //修改打印信息
            update();
            //打印
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            // window.location.reload();//重新加载
            //DetailsPageControl.CloseBox();//关闭窗口
            //  pagesetup_default()
        }


        function pagesetup_null() {
            //设置网页打印的页眉页脚为空  要降低浏览器安全级别
            var RegWsh = new CreateObject("WScript.Shell");
            RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\header", " ");
            RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\footer", " ");


            //设置页边距   
            //   RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_bottom", "");
            // RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_left", "100");
            //   RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_right", "");
            //RegWsh.RegWrite("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\margin_top", "10");
        }
        //设置网页打印的页眉页脚为默认值
        function pagesetup_default() {
            var RegWsh = new ActiveXObject("WScript.Shell")
            hkey_key = "header"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&w&b页码，&p/&P")
            hkey_key = "footer"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&u&b&d")
        }


    </script>
</head>
<body link="blue" vlink="purple">
    <form id="form1" runat="server">
        <div id="OptBar" class="optbar">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="info">打印随工单			

                    </td>
                    <td class="optbtn">
                        <input type="image" onclick="doPrint()" class="btn" src="../themes/default/images/btn/btn_print_nbyj_b_h.png" title="打印" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="details" style="text-align: left; height: 685px; width: auto; overflow: scroll; overflow-x: hidden;" align="center">
            <!--startprint-->
           



            <table border="0" cellpadding="0" cellspacing="0" style='border-collapse: collapse; table-layout: fixed; margin-left:10px; margin-top:30px;' align="center">
                <col width="73.33" style='mso-width-source: userset; mso-width-alt: 2346;' />
                <col width="80" style='mso-width-source: userset; mso-width-alt: 2560;' />
                <col width="24" style='mso-width-source: userset; mso-width-alt: 768;' />
                <col width="85.33" style='mso-width-source: userset; mso-width-alt: 2730;' />
                <col width="37.33" style='mso-width-source: userset; mso-width-alt: 1194;' />
                <col width="53.33" style='mso-width-source: userset; mso-width-alt: 1706;' />
                <col width="72" style='mso-width-source: userset; mso-width-alt: 2304;' />
                <col width="42.67" style='mso-width-source: userset; mso-width-alt: 1365;' />
                <col width="62.67" style='mso-width-source: userset; mso-width-alt: 2005;' />
                <col width="37.33" style='mso-width-source: userset; mso-width-alt: 1194;' />
                <col width="64" style='mso-width-source: userset; mso-width-alt: 2048;' />
                <col width="65.33" style='mso-width-source: userset; mso-width-alt: 2090;' />
                <col width="62.67" style='mso-width-source: userset; mso-width-alt: 2005;' />
                <col width="29.33" style='mso-width-source: userset; mso-width-alt: 938;' />
                <col width="69.33" span="230" style='mso-width-source: userset; mso-width-alt: 2218;' />
                <tr height="24" style='height: 18.00pt; mso-height-source: userset; mso-height-alt: 360;'>
                    <td class="xl67" height="24" width="789.33" colspan="14" style='height: 18.00pt; width: 592.00pt; border-right: none; border-bottom: none;' x:str><span style='mso-spacerun: yes;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>随工单参数<span style='mso-spacerun: yes;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><font class="font23">计划发货日期：</font><asp:Label ID="lblPlanTime" runat="server"></asp:Label>
                    </td>
                    <tr height="24" class="xl66" style='height: 18.00pt; mso-height-source: userset; mso-height-alt: 360;'>
                    <td class="xl68" height="24" style='height: 18.00pt;' x:str>订单<input type="checkbox" /></td>
                    <td class="xl69" />
                    <td class="xl69" colspan="2" style='mso-ignore: colspan;' x:str>备货<input type="checkbox" /></td>
                    <td class="xl68" />
                    <td class="xl68" />
                    <td class="xl68" />
                    <td class="xl68" />
                    <td class="xl68" />
                    <td class="xl145" colspan="3" style='border-right: none; border-bottom: none;' x:str>编号：</td>
                    <td class="xl145" />
                    <td class="xl69" />
                    <tr height="24" class="xl66" style='height: 18.00pt; mso-height-source: userset; mso-height-alt: 360;'>
                    <td class="xl70" height="24" style='height: 18.00pt;' x:str>订单号</td>
                    <td class="xl71" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>
                        <asp:Label ID="lblOrderNUM" runat="server"></asp:Label>
                        </td>
                    <td class="xl74" x:str>型号</td>
                    <td class="xl75" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: none;' x:str>
                        <asp:Label ID="lblproType" runat="server"></asp:Label>
                        </td>
                    <td class="xl75" x:str>数量</td>
                    <td class="xl147" x:num>
                        <asp:Label ID="lblProNUM" runat="server"></asp:Label>
                        </td>
                    <td class="xl148" x:str>批号</td>
                    <td class="xl148" x:str>
                        <asp:Label ID="lblPihao" runat="server"></asp:Label>
                        </td>
                    <td class="xl148" />
                    <td class="xl149" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: none;' />
                    <tr height="21.33" style='height: 16.00pt; mso-height-source: userset; mso-height-alt: 320;'>
                    <td class="xl76" height="21.33" colspan="14" style='height: 16.00pt; border-right: 1.0pt solid windowtext; border-bottom: none;' x:str>参数指导</td>
                    <tr height="20" style='height: 15.00pt; mso-height-source: userset; mso-height-alt: 300;'>
                    <td class="xl80" height="20" colspan="14" style='height: 15.00pt; border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>成品参数</td>
                    <tr height="25.33" style='height: 19.00pt; mso-height-source: userset; mso-height-alt: 380;'>
                    <td class="xl83" height="25.33" style='height: 19.00pt;' x:str>变<span style='mso-spacerun: yes;'>&nbsp;&nbsp; </span>比</td>
                    <td class="xl84" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: none;'>
                        <asp:Label ID="txtbianbi" runat="server"></asp:Label>
                       </td>
                    <td class="xl86" x:str>精  度</td>
                    <td class="xl85" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: none;'>
                        <asp:Label ID="txtjingDu" runat="server"></asp:Label>
                       </td>
                    <td class="xl86" x:str>线性度</td>
                    <td class="xl85" colspan="4" style='border-right: none; border-bottom: none;'>
                        <asp:Label ID="txtxianXingdu" runat="server"></asp:Label>
                        </td>
                    <td class="xl155" x:str>额定角差</td>
                    <td class="xl104" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: none;'>
                        <asp:Label ID="txteDingJC" runat="server"></asp:Label>
                        </td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl88" height="26.67" colspan="2" style='height: 20.00pt; border-right: none; border-bottom: .5pt solid windowtext;' x:str>1.铁芯参数</td>
                    <td class="xl90" x:str>
                        <asp:Label ID="txttieXiCount" runat="server"></asp:Label>
                        
                       </td>
                    <td class="xl91" x:str>2.线圈参数</td>
                    <td class="xl92" ><asp:Label ID="txtxianQuanCount" runat="server"></asp:Label></td>
                        &nbsp;<td class="xl93" colspan="4" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>
                        
                        </td>
                    <td class="xl108" colspan="5" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>3.线圈检测要求</td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>规格</td>
                    <td class="xl96" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtguiGe" runat="server"></asp:Label></td>
                    <td class="xl95" x:str>初级匝数</td>
                    <td class="xl98" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtchujZaShu" runat="server"></asp:Label></td>
                    <td class="xl100" x:str>次级匝数</td>
                    <td class="xl97" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcijZaShu" runat="server"></asp:Label></td>
                    <td class="xl157" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;' x:str>设备名称</td>
                    <td class="xl159" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtxqjcyqEquip" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>材料</td>
                    <td class="xl96" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcaiLiao" runat="server"></asp:Label></td>
                    <td class="xl95" x:str>线径</td>
                    <td class="xl98" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtchujXianJing" runat="server"></asp:Label></td>
                    <td class="xl100" x:str>线径</td>
                    <td class="xl97" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcijXianJing" runat="server"></asp:Label></td>
                    <td class="xl157" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;' x:str>输入状态</td>
                    <td class="xl159" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtxqjcyqShuRuState" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>性能</td>
                    <td class="xl96" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtxingNeng" runat="server"></asp:Label></td>
                    <td class="xl95" x:str>绕线指导</td>
                    <td class="xl98" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtchujRaoXianZD" runat="server"></asp:Label></td>
                    <td class="xl100" x:str>绕线指导</td>
                    <td class="xl97" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcijRaoXianZD" runat="server"></asp:Label></td>
                    <td class="xl157" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;' x:str>输出状态</td>
                    <td class="xl159" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtxqjcyqShuChuState" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>处理方式</td>
                    <td class="xl96" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtchuLiMethod" runat="server"></asp:Label></td>
                    <td class="xl95" x:str>线头长度</td>
                    <td class="xl98" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtchujXianTouCD" runat="server"></asp:Label></td>
                    <td class="xl100" x:str>线头长度</td>
                    <td class="xl97" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcijXianTouCD" runat="server"></asp:Label></td>
                    <td class="xl112" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;' x:str>角差</td>
                    <td class="xl161" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: none;'>
                        <asp:Label ID="txtxqjcyqJiaoCha" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl101" height="26.67" style='height: 20.00pt;' x:str>饱和点</td>
                    <td class="xl96" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtbaoHeDian" runat="server"></asp:Label></td>
                    <td class="xl95" x:str>线头处理</td>
                    <td class="xl98" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtchujXiantouCL" runat="server"></asp:Label></td>
                    <td class="xl100" x:str>线头处理</td>
                    <td class="xl97" colspan="2" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcijXianTouCL" runat="server"></asp:Label></td>
                    <td class="xl164" colspan="2" rowspan="2" style='border-right: .5pt solid windowtext; border-bottom: none;' x:str>负载</td>
                    <td class="xl117" colspan="3" rowspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: none;'>
                        <asp:Label ID="txtxqjcyqFuZai" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl102" height="26.67" style='height: 20.00pt;' />
                    <td class="xl103" colspan="2" style='border-right: none; border-bottom: none;' />
                    <td class="xl83" x:str>同名端</td>
                    <td class="xl84" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: none;'>
                        <asp:Label ID="txtchujTongMD" runat="server"></asp:Label></td>
                    <td class="xl86" x:str>同名端</td>
                    <td class="xl104" colspan="2" style='border-right: none; border-bottom: none;'>
                        <asp:Label ID="txtcijTongMD" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl105" height="26.67" colspan="3" style='height: 20.00pt; border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>4.外形参数</td>
                    <td class="xl108" colspan="4" style='border-right: none; border-bottom: .5pt solid windowtext;' x:str>5.成品检测参数</td>
                    <td class="xl88" colspan="7" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>6.辅料信息</td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>标示编号</td>
                    <td class="xl99" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtbiaoShiNo" runat="server"></asp:Label></td>
                    <td class="xl111" x:str>设备名称</td>
                    <td class="xl96" colspan="3" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcpjccsEquip" runat="server"></asp:Label></td>
                    <td class="xl112" colspan="2" rowspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>管脚针型号</td>
                    <td class="xl99" colspan="4" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtguanJiaoZhenLX" runat="server"></asp:Label></td>
                    <td class="xl110" x:str>
                        <asp:Label ID="txtguanJIaoZhenLXCount" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl113" height="26.67" style='height: 20.00pt;' x:str>标识位置</td>
                    <td class="xl114" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtbiaoShiAddress" runat="server"></asp:Label></td>
                    <td class="xl111" x:str>输入状态</td>
                    <td class="xl98" colspan="3" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcpjccsShuRuState" runat="server"></asp:Label></td>
                    <td class="xl110" colspan="4" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtguanJiaoZhenLXTOW" runat="server"></asp:Label></td>
                    <td class="xl110" x:str>
                        <asp:Label ID="txtguanJiaoZhenLXTOWCount" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>外壳编号</td>
                    <td class="xl100">
                        <asp:Label ID="txtwaiKeNo" runat="server"></asp:Label></td>
                    <td class="xl110" x:str>
                        <asp:Label ID="txtwaiKeCount" runat="server"></asp:Label></td>
                    <td class="xl111" x:str>输出状态</td>
                    <td class="xl98" colspan="3" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcpjccsShuChuState" runat="server"></asp:Label></td>
                    <td class="xl115" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>输入线长<font class="font23">(外留)</font></td>
                    <td class="xl175" colspan="5" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>
                        <asp:Label ID="txtshuRuXC" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>用胶参数</td>
                    <td class="xl96" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtyongJiaoCS" runat="server"></asp:Label></td>
                    <td class="xl111" x:str>角差</td>
                    <td class="xl98" colspan="3" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtCpjccsJiaoChaBH" runat="server"></asp:Label></td>
                    <td class="xl115" colspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>输出线长<font class="font23">(外留)</font></td>
                    <td class="xl175" colspan="5" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>
                        <asp:Label ID="txtshuChuXC" runat="server"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl95" height="26.67" style='height: 20.00pt;' x:str>输入方式</td>
                    <td class="xl96" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtshuRu" runat="server"></asp:Label></td>
                    <td class="xl111" x:str>负载</td>
                    <td class="xl98" colspan="3" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcpjccsFuZai" runat="server"></asp:Label></td>
                    <td class="xl119" rowspan="2" style='border-right: .5pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>配线要求</td>
                    <td class="xl119" x:str>输入</td>
                    <td class="xl175" colspan="4" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>
                        <asp:Label ID="txtpeiXianSR" runat="server"></asp:Label></td>
                    <td class="xl182" x:str>
                        <asp:Label ID="txtpeiXianSRCount" runat="server" CssClass="tbox"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl120" height="26.67" style='height: 20.00pt;' x:str>输出方式</td>
                    <td class="xl121" colspan="2" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtshuChu" runat="server"></asp:Label></td>
                    <td class="xl111" x:str>耐压</td>
                    <td class="xl98" colspan="3" style='border-right: none; border-bottom: .5pt solid windowtext;'>
                        <asp:Label ID="txtcpjccsNaiYa" runat="server"></asp:Label></td>
                    <td class="xl119" x:str>输出</td>
                    <td class="xl175" colspan="4" style='border-right: 1.0pt solid windowtext; border-bottom: .5pt solid windowtext;' x:str>
                        <asp:Label ID="txtpeiXianSC" runat="server"></asp:Label></td>
                    <td class="xl182" x:str>
                        <asp:Label ID="txtpeiXianSCCount" runat="server" CssClass="tbox"></asp:Label></td>
                    <tr height="26.67" style='height: 20.00pt; mso-height-source: userset; mso-height-alt: 400;'>
                    <td class="xl123" height="26.67" style='height: 20.00pt;' x:str>接插件型号</td>
                    <td class="xl124">
                        <asp:Label ID="txtchajianNo" runat="server"></asp:Label></td>
                    <td class="xl125" x:str>
                        <asp:Label ID="txtchajianCount" runat="server"></asp:Label></td>
                    <td class="xl126" x:str>同名端</td>
                    <td class="xl127" colspan="3" style='border-right: none; border-bottom: 1.0pt solid windowtext;'>
                        <asp:Label ID="txtcpjccsTongMD" runat="server"></asp:Label>
                        <td class="xl115" colspan="7" rowspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>其他制作要求<font class="font26"><asp:Label ID="txtremark" runat="server" ></asp:Label></font></td>
                        <tr height="40" style='height: 30.00pt; mso-height-source: userset; mso-height-alt: 600;'>
                    <td class="xl130" height="196" colspan="7" rowspan="2" style='height: 147.00pt; border-right: none; border-bottom: none;' x:str>外形图纸：
                        <asp:Image ID="imgWaiXingTZ" runat="server" Width="320" Height="175" /></td>
                    <tr height="36" style='height: 27.00pt; mso-height-source: userset; mso-height-alt: 540;'>
                    <td style='mso-ignore: colspan;' />
                </tr>
                <tr height="80" style='height: 60.00pt; mso-height-source: userset; mso-height-alt: 1200;'>
                    <td class="xl140" height="80" colspan="14" style='height: 60.00pt; border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>参数要求<font class="font33"><br/></font><asp:Label ID="lblCanshuYaoqiu" runat="server"></asp:Label></td>
                    <td style='mso-ignore: colspan;' />
                </tr>
                <tr height="72" style='height: 54.00pt; mso-height-source: userset; mso-height-alt: 1080;'>
                    <td class="xl140" height="72" colspan="14" style='height: 54.00pt; border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>客户特殊要求<br />
                        <asp:Label ID="lblTeshuYaoqiu" runat="server"></asp:Label></td>
                    <td style='mso-ignore: colspan;' />
                </tr>
                <tr height="89.33" style='height: 67.00pt; mso-height-source: userset; mso-height-alt: 1340;'>
                    <td class="xl140" height="89.33" colspan="14" style='height: 67.00pt; border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>工艺注意事项<font class="font21"><br/></font><asp:Label ID="lblZhuyiShixiang" runat="server"></asp:Label></td>
                    <td style='mso-ignore: colspan;' />
                </tr>
                <tr height="89.33" style='height: 67.00pt; mso-height-source: userset; mso-height-alt: 1340;' >
                    <td class="xl144" height="89.33" colspan="3" style='height: 67.00pt; border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>组装负责人：</td>
                    <td class="xl144" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>同名端确认人：</td>
                    <td class="xl144" colspan="3" style='border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>下单编辑人：</td>
                    <td class="xl144" colspan="5" style='border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext;' x:str>下单审核人：</td>
                    <td style='mso-ignore: colspan;' />
                </tr>
            </table>
            <!--endprint-->
        </div>



        <%-- <table class="form " cellpadding="0" cellspacing="0" style="width: 685px;" align="center">
                <tr>
                    <td colspan="6" style="text-align:right; font-size:24px; font-weight:bold;">随工单参数</td>
                    <td  style="text-align:right;">计划发货日期：</td>
                    <td  style="width:50px;"></td>
                </tr>
                <tr>
                    <td>订单<input type="checkbox" /></td>
                    <td>备货<input type="checkbox" /></td>
                    <td colspan="4">编号：</td>
                    <td colspan="2"></td>
                </tr>
            </table>
            <table class="form tb" cellpadding="0" cellspacing="0" style="width: 685px; border-top:1px solid #000000" align="center">
               
                <tr>
                    <td>订单号</td>
                    <td>
                        
                    </td>
                    <td>型号</td>
                    <td width="100"></td>
                    <td>数量</td>
                    <td></td>
                    <td>批号</td>
                    <td width="150">
                        
                    </td>
                  
                </tr>
                <tr>
                    <td colspan="8" style="text-align:center;">参数指导</td>
                </tr>
                 <tr>
                    <td colspan="8" style="text-align:left;">成品参数</td>
                </tr>
                <tr>
                    <td>变   比</td>
                    <td>
                       
                    </td>
                    <td>精  度</td>
                    <td>
                        
                    </td>
                    <td>线性度</td>
                    <td colspan="2">
                        
                    </td>
                    <td>额定角差</td>
                    <td width="80">
                        
                    </td>
                </tr>
                <tr>
                    <td>1.铁芯参数</td>
                    <td>
                        
                    </td>
                    <td>2.线圈参数</td>
                    <td colspan="3">
           
                    </td>
                    <td colspan="4">3.线圈检测要求</td>
                    
                </tr>
                <tr>
                    <td>规格</td>
                    <td></td>
                    <td>初级匝数</td>
                    <td></td>
                    <td>次级匝数</td>
                    <td></td>
                    <td>设备名称</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>材料</td>
                    <td></td>
                    <td>线径</td>
                    <td></td>
                    <td>线径</td>
                    <td></td>
                    <td>输入状态</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>性能</td>
                    <td></td>
                    <td>绕线指导</td>
                    <td></td>
                    <td>绕线指导</td>
                    <td></td>
                    <td>输出状态</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>处理方式</td>
                    <td></td>
                    <td>线头长度</td>
                    <td></td>
                    <td>线头长度</td>
                    <td></td>
                    <td>角差</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>饱和点</td>
                    <td></td>
                    <td>线头处理</td>
                    <td></td>
                    <td>线头处理</td>
                    <td></td>
                    <td rowspan="2">负载</td>
                    <td rowspan="2"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>同名端</td>
                    <td></td>
                    <td>同名端</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">4.外形参数</td>
                    <td colspan="3">5.成品检测参数</td>
                    <td colspan="3">6.辅料信息</td>
                </tr>
                 <tr>
                    <td>标示编号</td>
                    <td></td>
                    <td>设备名称</td>
                    <td colspan="2"></td>
                    <td rowspan="2">管脚针型号</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>标识位置</td>
                    <td></td>
                    <td>输入状态</td>
                    <td colspan="2"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>外壳编号</td>
                    <td></td>
                    <td>输出状态</td>
                    <td colspan="2"></td>
                    <td>输入线长(外留)</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>用胶参数</td>
                    <td></td>
                    <td>角差</td>
                    <td colspan="2"></td>
                    <td>输出线长(外留)</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>输入方式</td>
                    <td></td>
                    <td>负载</td>
                    <td colspan="2"></td>
                    <td rowspan="2">配线要求</td>
                    <td >输入</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>输出方式</td>
                    <td></td>
                    <td>耐压</td>
                    <td colspan="2"></td>
                    <td>输出</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>接插件型号</td>
                    <td></td>
                    <td>同名端</td>
                    <td colspan="2"></td>
                    <td rowspan="5" colspan="3">其他制作要求</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td colspan="4" rowspan="3">外形图纸：</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td colspan="8">参数要求</td>
                </tr>
                 <tr>
                    <td colspan="8">客户特殊要求</td>
                </tr>
                 <tr>
                    <td colspan="8">工艺注意事项</td>
                </tr>
                <tr>
                    <td  colspan="2">组装负责人：</td>
                    <td colspan="2">同名端确认人：</td>
                    <td colspan="2">下单编辑人：</td>
                    <td colspan="2">下单审核人：</td>
                </tr>
            </table>--%>
    </form>
</body>

</html>
