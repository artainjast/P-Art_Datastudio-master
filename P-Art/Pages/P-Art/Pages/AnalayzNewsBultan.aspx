<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalayzNewsBultan.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.AnalayzNewsBultan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Panel style sheet class-->
    <link href="../Styles/PanelStyle.css" rel="stylesheet" />
    <!-- JQuery UI Style Sheet-->
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <!-- FontAwesome css for used icon from fontawesome.com  import from our server-->
    <link href="../Styles/FontAwesome/web-fonts-with-css/css/fontawesome-all.min.css" rel="stylesheet" />
    <!-- Panel FaveIcon -->
    <link rel="icon" type="image/png" href="../Images/PayeshFaveIcon.png" />
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
            background-image: url("../Images/Bulltin-Cover.jpg");
            background-size: 100%;
            background-repeat: no-repeat;
        }

        .pageCover {
            background-image: url("../Images/Bulltin-Page.jpg");
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
            top: 14cm;
            text-align: center;
        }

        .persianNum {
            font-family: Conv_BTrafficBold;
            font-size: .9em;
        }

        .pageNumber {
            font-family: Conv_BTrafficBold;
            font-size: .9em;
            position: relative;
            display: block;
            bottom: 2cm;
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
    <form id="form1" runat="server">
        <section id="list-news">

            <asp:HiddenField ID="FromDateHiddenField" runat="server" Value="" />
            <asp:HiddenField ID="ToDateHiddenField" runat="server" Value="" />
            <a class="printButton" href="#"><i class="fas fa-print"></i>چاپ بولتن</a>

            <div id="report-result persian">
                <div id="keys-result">
                    <div class="page A4 cover">
                        <div class="BulltinTitle">
                            <span>
                                <label id="CurrentUserLabel" runat="server"></label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="FromDateLabel" runat="server" CssClass="persian persianNum"></asp:Label>
                                -
                                <asp:Label ID="ToDateLabel" runat="server" CssClass="persian persianNum"></asp:Label></span>

                        </div>
                    </div>
                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">جدول توزیع فراوانی تعداد تکرار کلید واژه ها</span>
                            <a id="resultTitleButton_" class="btn btn-info cur-p" style="float: left;" onclick="resultTitleButton_Click()">نمایش گزارش در بازه زمانی</a>
                            <div id="progress1" class="progressbar">
                            </div>

                            <div class="bar keyword1">
                                <input type="text" name="tag[]" value="" class="tag1" />
                            </div>
                            <table class="table-report1 AnalizetableStyle persian">
                                <thead>
                                    <tr>
                                        <th>کلید واژه</th>
                                        <th>عناوین اخبار</th>
                                        <th>خلاصه اخبار</th>
                                        <th>متن اخبار</th>
                                        <th>مجموع</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>

                        </div>
                        <span class="pageNumber">1</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">جدول توزيع فراوانی تعداد اخبار مرتبط با کليد واژه ها</span>
                            <a id="resultKeyCountNewsButton_" class="btn btn-info cur-p" style="float: left;" onclick="resultKeyCountNewsButton_Click()">نمایش گزارش در بازه زمانی</a>
                            <div id="progress11" class="progressbar"></div>
                            <table class="table-report2 AnalizetableStyle">
                                <thead>
                                    <tr>
                                        <th>کلید واژه</th>
                                        <th>مجموع</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>

                        </div>
                        <span class="pageNumber">2</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <div class="pieChartBorder">
                                <span class="title">درصد فراوانی مطالب منتشر شده به تفکيک نوع رسانه</span>
                                <div id="progress2" class="progressbar"></div>
                                <div id="chart1">
                                </div>
                            </div>

                            <br />
                            <br />
                            <div class="pieChartBorder">
                                <span class="title">درصد فراوانی مطالب منتشر شده به تفکيک سو گيری در رسانه</span>
                                <div id="progress6" class="progressbar"></div>
                                <div id="chart6"></div>
                            </div>

                        </div>
                        <span class="pageNumber">3</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">نمودار توزيع فراوانی مطالب منتشره در پايگاه های خبری</span>
                            <div id="progress3" class="progressbar"></div>
                            <div id="chart2"></div>

                        </div>
                        <span class="pageNumber">4</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">نمودار توزيع فراوانی مطالب منتشره در روزنامه ها</span>
                            <div id="progress4" class="progressbar"></div>
                            <div id="chart4"></div>

                        </div>
                        <span class="pageNumber">5</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">نمودار فراوانی مطالب منتشر شده به تفکيک سو گيری در پايکاه های خبری</span>
                            <div id="progress7" class="progressbar"></div>
                            <div id="chart7"></div>

                        </div>
                        <span class="pageNumber">6</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">نمودار فراوانی مطالب منتشر شده به تفکيک سو گيری در جراید و مطبوعات</span>
                            <div id="progress8" class="progressbar"></div>
                            <div id="chart8"></div>
                        </div>
                        <span class="pageNumber">7</span>
                    </div>

                    <div class="page A4 pageCover">
                        <div class="result-title ">
                            <span class="title">درصد مطالب منتشر شده ازاشخاص خبر ساز سازمان</span>
                            <a id="PercentPeopleNewsButton_" class="btn btn-info cur-p" style="float: left;" onclick="PercentPeopleNewsButton_Click()">نمایش گزارش در بازه زمانی</a>
                            <div id="progress9" class="progressbar"></div>
                            <div class="bar keyword2">
                                <span>اشخاص خبر ساز:</span><input type="text" name="tag[]" value="" class="tag2" />
                            </div>
                            <div id="chart9"></div>
                        </div>
                        <span class="pageNumber">8</span>

                    </div>
                </div>
            </div>
        </section>
    </form>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".tag1").tagedit();
            $(".tag2").tagedit();

            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();


            //btn_ReportChart_Click()

            analyz_LoadChart1(fromDate, toDate);

            analyz_LoadChart2(fromDate, toDate);

            analyz_LoadChart3(fromDate, toDate);

            analyz_LoadChart4(fromDate, toDate);

            analyz_LoadChart5(fromDate, toDate);

            analyz_LoadChart6(fromDate, toDate);

            analyz_LoadChart9(fromDate, toDate);

            analyz_LoadKeywords(fromDate, toDate);

            analyz_LoadKeywords2(fromDate, toDate);

        });



        $('.printButton').on('click', function () {
            window.print();
            return false; // why false?
        });



        //$("#resultTitleButtonB").click(function () {
        //    var fromDate = $("#FromDateHiddenField").val();
        //    var toDate = $("#ToDateHiddenField").val();
        //    analyz_LoadKeywords(fromDate, toDate);
           
        //});

        //$("#resultKeyCountNewsButtonB").click(function () {
        //    var fromDate = $("#FromDateHiddenField").val();
        //    var toDate = $("#ToDateHiddenField").val();

        //    analyz_LoadKeywords2(fromDate, toDate);
        //});

        //$("#PercentPeopleNewsButtonB").click(function () {
        //    var fromDate = $("#FromDateHiddenField").val();
        //    var toDate = $("#ToDateHiddenField").val();

        //    analyz_LoadChart9(fromDate, toDate);
        //});



        //function btn_ReportChart_Click() {
        //    //$("#box-waiting").slideDown(700);
        //    var fromDate = $("#FromDateHiddenField").val();
        //    var toDate = $("#ToDateHiddenField").val();

        //    analyz_LoadKeywords(fromDate, toDate, function () {
        //        analyz_LoadKeywords2(fromDate, toDate, function () {
        //            analyz_LoadChart1(fromDate, toDate, function () {
        //                analyz_LoadChart2(fromDate, toDate, function () {
        //                    analyz_LoadChart3(fromDate, toDate, function () {
        //                        analyz_LoadChart4(fromDate, toDate, function () {
        //                            analyz_LoadChart5(fromDate, toDate, function () {
        //                                analyz_LoadChart6(fromDate, toDate, function () {
        //                                    analyz_LoadChart9(fromDate, toDate, function () {
        //                                                    finishAnalyz();
        //                                                });
        //                                            });
        //                                        });
        //                                    });
        //                                });
        //                            });
        //                        });
        //                    })
        //            }

        //        );
        //    //e.preventDefault();
        //}



        function resultTitleButton_Click() {

            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();
            setTimeout(analyz_LoadKeywords(fromDate, toDate), 2000);
        }


        function resultKeyCountNewsButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadKeywords2(fromDate, toDate);
        }

        function resultKeypPercentNewsButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart1(fromDate, toDate);
        }

        function FrequencyDistributionNewsButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart2(fromDate, toDate);
        }

        function FrqDistributionNewsPaperButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart3(fromDate, toDate);
        }

        function FrqDistributionNewsKeysButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadKeywordsChart(fromDate, toDatete);
        }

        function FrqDistributNewsOrientButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart4(fromDate, toDate);
        }

        function FrqDistributNewsStationOrientButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart5(toDate, fromDate);
        }

        function FrqDistributNewsPaperStationOrientButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart6(fromDate, toDate);
        }

        function PercentPeopleNewsButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();

            analyz_LoadChart9(fromDate, toDate);

        }
        function FrqDistributNewsProvinceButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();
            analyz_LoadChart10(fromDate, toDatee);
        }
        function FrqDistributNewsProvincePrButton_Click() {
            var fromDate = $("#FromDateHiddenField").val();
            var toDate = $("#ToDateHiddenField").val();
            analyz_LoadChart12(fromDate, toDate);
        }


        function analyz_LoadKeywords(fromdate, todate, callback) {


            var keyCount = $(".keyword1 .tagedit-list li").size();


            var keywords = "";
            if (keyCount > 0) keyCount--;
            if (keyCount > 0) {
                var percentLoaded = 0;
                var percentMax = 0;
                percentMax = 100 / keyCount;


                var liCounter = 0;
                $('#keys-result .table-report1').css("display", "block");
                $('#keys-result .table-report1').attr('style', '');
                $('#keys-result .table-report1 tr').attr('style', '');
                $('#keys-result .table-report1 th').attr('style', '');
                $('#keys-result .table-report1 td').attr('style', '');

                $('#keys-result .table-report1 tr:not(:has(th))').remove();

                $("#progress1").animate({ width: 0 }, 400);
                var listIndex = 1;
                $(".keyword1 .tagedit-list li").each(function () {
                    var keyWord = $(this).find("span").html();
                    if (keyWord != null) {
                        keywords += keyWord + "|";

                        $.ajax({
                            type: "POST",
                            url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                            data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'" + listIndex + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {

                                liCounter++;
                                percentLoaded += percentMax;
                                //$('#keys-result .table-report1 > tbody:last').append();
                                $("#keys-result .table-report1 tbody").append("<tr><td>" + keyWord + "</td><td>" + msg.d[0] + "</td><td>" + msg.d[1] + "</td><td>" + msg.d[2] + "</td><td>" + (parseInt(msg.d[0]) + parseInt(msg.d[1]) + parseInt(msg.d[2])) + "</td></tr>");

                                $("#progress1").animate({ width: percentLoaded + '%' }, 400);
                                if (liCounter == keyCount) {
                                    $('#keys-result .table-report1').tableSort({
                                        animation: 'fade',
                                        speed: 250,
                                        delay: 25
                                    });
                                }
                            }
                        });

                    }

                    listIndex = listIndex + 1;
                });
                analyz_SaveKeywords();


            }
            if (callback) {
                callback();
            }
            //callback.call();
        }

        function analyz_LoadKeywords2(fromdate, todate, callback) {


            var keyCount = $(".keyword1 .tagedit-list li").size();


            var keywords = "";
            if (keyCount > 0) keyCount--;
            if (keyCount > 0) {
                var percentLoaded = 0;
                var percentMax = 0;
                percentMax = 100 / keyCount;

                var liCounter = 0;

                //$('#keys-result .table-report2').css("display", "block");
                //$('#keys-result .table-report2').attr('style', '');
                //$('#keys-result .table-report2 tr').attr('style', '');
                //$('#keys-result .table-report2 th').attr('style', '');
                //$('#keys-result .table-report2 td').attr('style', '');

                //$('#keys-result .table-report2 tr:not(:has(th))').remove();
                $("#progress11").animate({ width: 0 }, 400);
                var listIndex = 1;

                $(".keyword1 .tagedit-list li").each(function () {
                    var keyWord = $(this).find("span").html();

                    if (keyWord != null) {
                        keywords += keyWord + "|";
                        $.ajax({
                            type: "POST",
                            url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                            data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'1','index':'" + listIndex + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {

                                liCounter++;
                                percentLoaded += percentMax;
                                //$('#keys-result .table-report1 > tbody:last').append();

                                $("#keys-result .table-report2 tbody").append("<tr><td>" + keyWord + "</td><td>" + parseInt(msg.d[0]) + "</td></tr>");
                                $("#progress11").animate({ width: percentLoaded + '%' }, 400);
                                if (liCounter == keyCount) {

                                    $('#keys-result .table-report2').tableSort({
                                        animation: 'fade',
                                        speed: 250,
                                        delay: 25
                                    });
                                }
                            }
                        });

                    }

                    listIndex = listIndex + 1;
                });
                analyz_SaveKeywords();
                if (callback) {
                    callback();
                }

            }
            //callback.call();
        }


        function analyz_LoadChart1(fromdate, todate, callback) {

            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/AnalyzKhabargozari",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    newData = [];
                    //var dictionary = {};

                    //var data = new google.visualization.DataTable();
                    //data.addColumn('string', 'آرا');
                    //data.addColumn('number', 'تعداد رای');
                    for (var i = 0; i < data.d.length; i++) {

                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    }

                    $("#progress2").animate({ width: '100%' }, 400);
                    //start chart
                    $('#chart1').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a'
                            },
                            height: 400,
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            marginRight: 0,
                            marginTop: 0,
                            marginBottom: 0,
                            marginLeft: 0
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {

                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',

                                dataLabels: {
                                    enabled: true,
                                    color: '#000000',
                                    connectorColor: '#000000',
                                    format: "{point.name}: {point.percentage:.1f} %"
                                }
                            }
                        },
                        series: [{
                            type: 'pie',
                            name: 'Browser share',

                            data: newData

                        }]
                    });

                    if (callback) callback();
                }
            });
        }
        function analyz_LoadChart2(fromdate, todate, callback) {


            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/AnalyzChartKhabargozari",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'1'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data2) {
                    newData2 = [];

                    for (var i = 0; i < data2.d.length; i++) {

                        newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                    }
                    $("#progress3").animate({ width: '100%' }, 400);
                    $('#chart2').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a',
                            },
                            height: 900,
                            type: 'bar',
                            backgroundColor: 'transparent'
                        },
                        xAxis: {
                            type: 'category'
                        },
                        yAxis: {
                            title: {
                                text: ''
                            }
                        },
                        title: {
                            text: ''
                        },
                        legend: {
                            enabled: false
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    color: '#000000',
                                    connectorColor: '#000000',
                                    format: "{point.name}: {point.percentage:.1f} %",
                                    backgroundColor: 'transparent'
                                }
                            }
                        },
                        series: [{
                            type: 'bar',
                            name: '',

                            data: newData2

                        }]
                    });

                    if (callback) callback();
                }
            });
        }
        function analyz_LoadChart3(fromdate, todate, callback) {
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/AnalyzChartKhabargozari",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'2'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data2) {
                    newData2 = [];

                    for (var i = 0; i < data2.d.length; i++) {

                        newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);
                    }
                    $("#progress4").animate({ width: '100%' }, 400);
                    $('#chart4').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a'
                            },
                            height: 900,
                            type: 'bar',
                            backgroundColor: 'transparent'

                        },
                        xAxis: {
                            type: 'category'
                        },
                        yAxis: {
                            title: {
                                text: ''
                            }
                        },
                        title: {
                            text: ''
                        },
                        legend: {
                            enabled: false
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    color: '#000000',
                                    connectorColor: '#000000',
                                    format: "{point.name}: {point.percentage:.1f} %"
                                }
                            }
                        },
                        series: [{
                            type: 'column',
                            name: 'Browser share',

                            data: newData2

                        }]
                    });

                    if (callback) callback();
                }
            });
        }
        function analyz_LoadChart4(fromdate, todate, callback) {

            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/AnalyzNewsValue",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    newData = [];
                    //var dictionary = {};

                    //var data = new google.visualization.DataTable();
                    //data.addColumn('string', 'آرا');
                    //data.addColumn('number', 'تعداد رای');
                    for (var i = 0; i < data.d.length; i++) {

                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    }

                    $("#progress6").animate({ width: '100%' }, 400);
                    //start chart
                    $('#chart6').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a'
                            },
                            backgroundColor: 'transparent',
                            height: 400,
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            marginRight: 0,
                            marginTop: 0,
                            marginBottom: 0,
                            marginLeft: 0
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {

                                allowPointSelect: true,
                                cursor: 'pointer',

                                dataLabels: {

                                    enabled: true,
                                    color: '#000000',
                                    connectorColor: '#000000',
                                    format: "{point.name}: {point.percentage:.1f} %"
                                }
                            }
                        },
                        series: [{

                            type: 'pie',
                            name: 'Browser share',

                            data: newData

                        }]
                    });

                    if (callback) callback();
                }
            });
        }
        function analyz_LoadChart5(fromdate, todate, callback) {
            newData = [];
            newData2 = [];

            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'1','newsValue':' = 1'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {


                    for (var i = 0; i < data.d.length; i++) {

                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    }


                    $.ajax({
                        type: "POST",
                        url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
                        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'1','newsValue':' = 2'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data2) {


                            for (var i = 0; i < data2.d.length; i++) {

                                newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                            }
                            $("#progress7").animate({ width: '100%' }, 400);
                            $('#chart7').highcharts({
                                chart: {
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        color: '#72777a'
                                    },
                                    backgroundColor: 'transparent',
                                    height: 900,
                                    type: 'bar'
                                },
                                xAxis: {
                                    type: 'category',
                                    rotation: -45
                                },
                                yAxis: {
                                    title: {
                                        text: ''
                                    }
                                },
                                stackLabels: {
                                    enabled: true,
                                    style: {
                                        fontWeight: 'bold',
                                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                    }
                                },
                                title: {
                                    text: ''
                                },
                                legend: {
                                    enabled: true

                                },
                                tooltip: {
                                    pointFormat: '<div style="direction:rtl;text-align:right"><span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/></div>',
                                    shared: true
                                },
                                plotOptions: {
                                    column: {
                                        stacking: 'normal',
                                        dataLabels: {
                                            enabled: true,
                                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                                            style: {
                                                textShadow: '0 0 3px black, 0 0 3px black'
                                            }
                                        }
                                    }
                                },
                                series: [{
                                    type: 'column',
                                    name: 'اخبار مثبت',
                                    data: newData,
                                    stake: 'اخبار مثبت'

                                }, {
                                    type: 'column',
                                    name: 'اخبار منفی',
                                    data: newData2,
                                    stake: 'اخبار منفی'

                                }]
                            });


                        }
                    });
                    //$("#progress7").animate({ width: '100%' }, 400);
                    //start chart


                    if (callback) callback();
                }
            });
        }
        function analyz_LoadChart6(fromdate, todate, callback) {
            newData = [];
            newData2 = [];

            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'2','newsValue':' = 1'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {


                    for (var i = 0; i < data.d.length; i++) {

                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    }


                    $.ajax({
                        type: "POST",
                        url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
                        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'2','newsValue':' = 2'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data2) {


                            for (var i = 0; i < data2.d.length; i++) {

                                newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                            }
                            $("#progress8").animate({ width: '100%' }, 400);
                            $('#chart8').highcharts({
                                chart: {
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        color: '#72777a'
                                    },
                                    height: 900,
                                    type: 'bar',
                                    backgroundColor: 'transparent'
                                },
                                xAxis: {
                                    type: 'category',
                                    rotation: -45
                                },
                                yAxis: {
                                    title: {
                                        text: ''
                                    }
                                },
                                title: {
                                    text: ''
                                },
                                legend: {
                                    enabled: false
                                },
                                tooltip: {
                                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                                },
                                plotOptions: {
                                    pie: {
                                        allowPointSelect: true,
                                        cursor: 'pointer',
                                        dataLabels: {
                                            enabled: true,
                                            rotation: -90,
                                            color: '#FFFFFF',
                                            align: 'right',
                                            x: 4,
                                            y: 10,
                                            style: {
                                                fontSize: '13px',
                                                fontFamily: 'Verdana, sans-serif',
                                                textShadow: '0 0 3px black'
                                            }
                                        }
                                    }
                                },
                                series: [{
                                    type: 'column',
                                    name: 'اخبار مثبت',

                                    data: newData

                                }, {
                                    type: 'column',
                                    name: 'اخبار منفی',

                                    data: newData2

                                }]
                            });


                        }
                    });
                    //$("#progress7").animate({ width: '100%' }, 400);
                    //start chart


                    if (callback) callback();
                }
            });
        }
        function analyz_LoadChart9(fromdate, todate, callback) {


            var keyCount = $(".keyword2 .tagedit-list li").size();
            newData2 = [];

            var keywords = "";
            if (keyCount > 0) keyCount--;
            if (keyCount > 0) {
                var percentLoaded = 0;
                var percentMax = 0;
                percentMax = 100 / keyCount;

                var liCounter = 0;

                $("#progress9").animate({ width: 0 }, 400);
                $(".keyword2 .tagedit-list li").each(function (index) {
                    var keyWord = $(this).find("span").html();
                    if (keyWord != null) {
                        keywords += keyWord + "|";
                        $.ajax({
                            type: "POST",
                            url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                            data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'0'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {

                                liCounter++;
                                percentLoaded += percentMax;

                                $("#progress9").animate({ width: percentLoaded + '%' }, 400);

                                newData2.push([keyWord, parseInt(msg.d[2])]);

                                if (liCounter == keyCount) {
                                    analyz_SaveKeywords();
                                    $('#chart9').highcharts({
                                        chart: {
                                            style: {
                                                fontFamily: 'Conv_BTrafficBold',
                                                color: '#72777a'
                                            },
                                            backgroundColor: 'transparent',
                                            plotBackgroundColor: null,
                                            plotBorderWidth: null,
                                            plotShadow: false,
                                            marginRight: 0,
                                            marginTop: 0,
                                            marginBottom: 0,
                                            marginLeft: 0,
                                            height: 600
                                        },
                                        title: {
                                            text: ''
                                        },
                                        tooltip: {
                                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                                        },
                                        plotOptions: {
                                            pie: {
                                                allowPointSelect: true,
                                                cursor: 'pointer',
                                                dataLabels: {
                                                    enabled: true,
                                                    color: '#000000',
                                                    connectorColor: '#000000',
                                                    format: "{point.name}: {point.percentage:.1f} %"
                                                }
                                            }
                                        },
                                        series: [{
                                            type: 'pie',
                                            name: 'Browser share',

                                            data: newData2

                                        }]
                                    });


                                }

                            }
                        });

                    }


                });



                if (callback) {
                    callback();
                }

            }
            //callback.call();
        }

    </script>
</body>
</html>
