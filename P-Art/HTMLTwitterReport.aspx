<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLTwitterReport.aspx.cs" Inherits="P_Art.HTMLTwitterReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Panel style sheet class-->
    <link href="Pages/P-Art/Styles/PanelStyle.css" rel="stylesheet" />
    <!-- JQuery UI Style Sheet-->
    <link href="Pages/P-Art/Styles/jquery-ui.css" rel="stylesheet" />
    <!-- FontAwesome css for used icon from fontawesome.com  import from our server-->
    <link href="Pages/P-Art/Styles/FontAwesome/web-fonts-with-css/css/fontawesome-all.min.css" rel="stylesheet" />
    <!-- Panel FaveIcon -->
    <link rel="icon" type="image/png" href="Pages/P-Art/Images/PayeshFaveIcon.png" />
    <!-- JQuery library version 3.3.1 import from our server -->
    <script src="/Scripts/jquery-3.3.1.min.js"></script>

    <script src='/Pages/P-Art/Scripts/jquery-ui.min.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.easing.1.3.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/AppScripts.js?ver=13.0' type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery-ui.css" />
    <script src='/Pages/P-Art/Scripts/jquery.min.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.easing.1.3.js' type="text/javascript"></script>
    <%--<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>--%>
    <script src="/Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/AppScripts.js?ver=13.0' type="text/javascript"></script>
    <!-- Convert Engilish Number to Persian Number -->
    <script src="/Scripts/persianNum.jquery-2.min.js"> 
        jQuery.noConflict();
    </script>
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/ui-lightness/jquery-ui-1.8.6.custom.css" />
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery.tagedit.css" />

    <%--    <script src='/Pages/P-Art/Scripts/jquery-ui-1.8.6.custom.min.js' type="text/javascript"></script>--%>

    <script src='/Pages/P-Art/Scripts/jquery.autoGrowInput.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.tagedit.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/highcharts.js' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/tsort.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/exporting.js") %>'></script>

    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js"></script>

    <style>
        body {
            background: rgb(204,204,204);
            
        }

        .page {
            background: white;
            display: block;
            margin: 0 auto;
            margin-bottom: 0.5cm;
            box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);
            overflow: hidden;
        }

        .cover {
            background-image: url("/Pages/P-Art/Images/TelegramReportCover.jpg");
            background-size: 100%;
            background-repeat: no-repeat;
        }

        .pageCover {
            background-image: url(/Pages/P-Art/Images/TelegramReport.jpg);
            background-size: 21cm 29.7cm;
            background-repeat: no-repeat;

        }


        .A4 {
            display: block;
            width: 21cm;
            height: 29.7cm;
        }

            .A4 .portrait {
                width: 29.7cm;
                height: 21cm;
            }

        .A3 {
            width: 29.7cm;
            height: 42cm;
        }

        div .page .A3 .portrait {
            width: 42cm;
            height: 29.7cm;
        }

        .A5 {
            width: 14.8cm;
            height: 21cm;
        }

            .A5.portrait {
                width: 21cm;
                height: 14.8cm;
            }

        .pageContent {
            padding-top: 4cm;
            padding-bottom: 3cm;
            display:block;
            width:100%;
            height:100%;

            
        }
        .MessageHeadder{
            position:relative;
            margin:.5cm 2cm 0 2cm;
            display:block;
            width:100%;


        }

            .MessageHeadder .MessageDateTime {
                background: #75ffe6;
                border-radius: 3px 3px 3px 3px;
                -moz-border-radius: 3px 3px 3px 3px;
                -webkit-border-radius: 3px 3px 3px 3px;
                border: 0px solid #000000;
                height: 1cm;
                line-height: 1cm;
                display: inline-block;
                float: left;
                margin-left: 4cm;
                position: relative;
                padding: 0 .5cm 0 .5cm;
            }
            .MessageHeadder .rowIndex {
                background: #75ffe6;
                border-radius: 3px 3px 3px 3px;
                -moz-border-radius: 3px 3px 3px 3px;
                -webkit-border-radius: 3px 3px 3px 3px;
                border: 0px solid #000000;
                height: 1cm;
                line-height: 1cm;
                display: inline-block;
                position: relative;
                right:0;
            }
            
        .MessageFooter {
            position:relative;
            margin:.5cm 2cm 0 2cm;
            display:block;
            width:100%;
        }
            .MessageFooter .MessageChannel {
                background: #e0e0e0;
                border-radius: 3px 3px 3px 3px;
                -moz-border-radius: 3px 3px 3px 3px;
                -webkit-border-radius: 3px 3px 3px 3px;
                border: 0px solid #000000;
                height: 1cm;
                line-height: 1cm;
                display: inline-block;
                float: left;
                padding: 0 .5cm 0 .5cm;
                position: relative;
                margin-left: 2cm;
                bottom:.1cm;
            }
        .MessageStyle {
           
            position: relative;
            margin:0 2cm 3cm 2cm;
            text-align:justify;
            border-top: 2px solid #ff6a00;
            padding-top:.5cm;
            padding-bottom:1cm;
            border-bottom: 5px dotted #808080;
            

        }

        .printButton {
            padding: 7px 20px;
            position: fixed;
            right: 20px;
            top: 20px;
            background: #ffffff;
            border-radius: 5px 5px 5px 5px;
            -moz-border-radius: 5px 5px 5px 5px;
            -webkit-border-radius: 5px 5px 5px 5px;
            border: 1px solid rgba(0,0,0,0.0625);
            color: #333333;
            font-size: .8em;
            font-weight: bold;
        }

            .printButton i {
                padding-left: 4px;
            }

        .result-title {
            padding-right: 2.6cm;
            padding-top: 3.5cm;
            padding-bottom: 2cm;
            height: 24cm;
        }

        .title {
            font-weight: bold;
        }

        rect .highcharts-background {
            fill: transparent !important;
        }

        .BulltinTitle {
            position: relative;
            font-weight: bold;
            font-size: 1.5em;
            right: .5cm;
            top: 9cm;
            text-align: center;
        }

            .BulltinTitle #CurrentUserLabel {
                font-size:1.6em;
                
            }

        .persianNum {
            font-family: Conv_BTrafficBold;
            font-size: .9em;
        }

        .pageNumber {
            font-family: Conv_BTrafficBold;
            font-size: 1.2em;
            position: relative;
            display: block;
            bottom: 8.2cm;
            margin-right: 19cm;
        }

        .pieChartBorder {
            border: 1px solid rgba(0,0,0,0.0625);
            padding: 10px;
            left: 1.1cm;
            position: relative;
        }

        .highcharts-legend-item rect {
            x : 26px!important;
            position:relative;
        }

        @media print {
            * {
                -webkit-print-color-adjust: exact;
            }

            body {
                margin: 0 0 0 0 !important;
                box-shadow: 0 0 0 0 !important;
            }

            .page {
                right: 0;
                text-align: center;
                margin: 0 0 0 0 !important;
                box-shadow: 0 0 0 0 !important;
            }


            .printButton {
                display: none;
            }

            @page {
                margin: 0;
            }


            .btn {
                display: none;
            }

            .tagedit-list {
                display: none;
            }


        }
    </style>


</head>
<body>
    <form id="ReportContent" runat="server">
        <asp:HiddenField ID="BultanArchiveIdHiddenField" Value='' runat="server" />
    <section id="list-news">
        
            <asp:HiddenField ID="FromDateHiddenField" runat="server" Value="" />
            <asp:HiddenField ID="ToDateHiddenField" runat="server" Value="" />
            <a class="printButton" href="#"><i class="fas fa-print"></i>چاپ بولتن</a>

            <div id="report-result persian">
                <div id="keys-result">
                    <div class="page A4 cover">
                        <div class="BulltinTitle">
                            <span>
                                <label id="BultanTitlePhrase" runat="server"></label>
                                <br />
                                <label id="CurrentUserLabel" runat="server"></label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="FromDateLabel" runat="server" CssClass="persian persianNum"></asp:Label>
                                -
                                <asp:Label ID="ToDateLabel" runat="server" CssClass="persian persianNum"></asp:Label></span>
                        </div>
                    </div>
                    <asp:Literal ID="BultanContent"  runat="server" >

                     </asp:Literal>
                </div>
            </div>
    </section>
    </form>
    <script>
        $('.printButton').on('click', function () {
            window.print();
            return false; // why false?
        });
    </script>
</body>
</html>

