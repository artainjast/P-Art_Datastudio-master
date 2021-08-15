<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppMediaAnalyze.aspx.cs" Inherits="P_Art.AppMediaAnalyze" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>چاپ تحلیل رسانه ها</title>
    <link rel="icon" type="image/png" href="../Images/PayeshFaveIcon.png" />
    <!-- JQuery library version 3.3.1 import from our server -->
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src='/Pages/P-Art/Scripts/jquery-ui.min.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.easing.1.3.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/AppScripts.js?ver=13.0' type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery-ui.css" />
    <script src='/Pages/P-Art/Scripts/jquery.min.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery-ui.min.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.easing.1.3.js' type="text/javascript"></script>
    <script src="/Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/AppScripts.js?ver=13.0' type="text/javascript"></script>
    <!-- Convert Engilish Number to Persian Number -->
    <script src="/Scripts/persianNum.jquery-2.min.js"> 
        jQuery.noConflict();
    </script>

    <link href="/Pages/P-Art/Styles/AnalyzeStylePrint.css" rel="stylesheet" type="text/css" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/highcharts.js") %>'></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/wordcloud.js") %>'></script>
    <script src="/Pages/P-Art/Scripts/Calender/calendar.min.js"></script>
    <script src="/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js"></script>
    <script src="/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js"></script>
    <script>
        $(window).load(function () {
            var f = $("#hddFrom").val();
            var t = $("#hddTo").val();
            var ft = $("#hddFromTime").val();
            var tt = $("#hddToTime").val();
            var k = $("#hddKeyword").val();
            getImportantMedia_page3($("#hddParmin").val(), f, t, ft, tt, k);
            getHighNumberMedia_page1_2($("#hddParmin").val(), f, t, ft, tt, k);
            getSugiri_page4($("#hddParmin").val(), f, t, ft, tt, k);
            getSugiri_page5($("#hddParmin").val(), f, t, ft, tt, k);
            getNewTableState_page6($("#hddParmin").val(), f, t, ft, tt, k);
        });
    </script>
    <script>
        function getHighNumberMedia_page1_2(p, f, t, ft, tt, k) {
            $("#divCountingStatistic").css("display", "none");
            $("#imgLoadPage1").css("display", "block");

            $("#divAllMediaHighSource").css("display", "none");
            $("#divNewsHighSource").css("display", "none");
            $("#divNewspaperHighSource").css("display", "none");
            $("#divTelegramHighSource").css("display", "none");
            $("#divTwitterHighSource").css("display", "none");
            $("#imgLoadPage2").css("display", "block");
            var newData = [];
            var newsData = [];
            var newspaperData = [];
            var telegramData = [];
            var twitterData = [];
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetHighNumberMedia.ashx?p=" + p + "&f=" + f + "&t=" + t + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var sourceNewsHtml = "<div class='source-title'><span>کدام خبرگزاری ها بیشترین خبر را در مورد سازمان من داشته اند؟</span></div>";
                    var sourceNewspaperHtml = "<div class='source-title'><span>کدام روزنامه ها بیشترین خبر را در مورد سازمان من داشته اند؟</span></div>";
                    var sourceTelegramHtml = "<div class='source-title'><span>کدام کانال ها بیشترین پست را در مورد سازمان من داشته اند؟</span></div>";
                    var sourceTwitterHtml = "<div class='source-title'><span>کدام اکانت ها بیشترین توییت را در مورد سازمان من داشته اند؟</span></div>";
                    // Define statics html 
                    var page3FullHtml = "<div class='mediaCount' ><div class='newscount'><span>تعداد اخبار خبرگزاری ها</span>";
                    page3FullHtml += "<span class='number'> <i class='fas fa-rss fa-2x'></i> " + toPersianNum(data.AllMediaCount.NewsCount) + "</span></div><div class='othermediacount' ><div class='first-left-row'>";
                    page3FullHtml += "<div class='first-left-newspaper'><span>تعداد اخبار روزنامه ها</span><span class='number'><i class='far fa-newspaper fa-1x'></i>" + toPersianNum(data.AllMediaCount.NewspaperCount) + "</span></div>";
                    page3FullHtml += "<div class='first-left-telegram'><span>تعداد پست های تلگرام</span><span class='number'><i class='fab fa-telegram-plane fa-1x'></i>" + toPersianNum(data.AllMediaCount.TelegramCount) + "</span></div></div>";
                    page3FullHtml += "<div class='second-left-row'><div class='first-left-twitter'><span>تعداد توییت ها</span> <span class='number'><i class='fab fa-twitter fa-1x'></i>" + toPersianNum(data.AllMediaCount.TwitterCount) + "</span></div><div class='third-video'><span>تعداد اخبار صدا و سیما </span> <span class='number'><i class='fa fa-film fa-1x'></i>" + toPersianNum(data.AllMediaCount.VideoCount) + "</span></div></div></div></div>";
                    // Define chart html 
                    page3FullHtml += "<div class='mediaCharts'><div class='first-row-charts' ><div class='news-chart' id='chartNews' style='height: 7cm; width: calc(100% - 3cm);'></div><div class='other-chart'>";
                    page3FullHtml += "<div class='newspaper-chart' id='chartNewspaper' style='height: 6.2cm; width: 10cm;' ></div><div class='twitter-chart' style='height: 6.2cm; width: 7.3cm;' id='chartTwitter' ></div></div></div>";
                    page3FullHtml += "<div class='second-row-charts' ><div class='telegram-chart' id='chartTelegram' style='height: 5cm; width: 18cm;' ></div></div></div>";
                    for (var i = 0; i < data.MediaChartList.length; i++) {
                        newData.push({ 'name': [data.MediaChartList[i].Name], 'y': parseFloat(data.MediaChartList[i].Value) });
                    }
                    for (var j = 0; j < data.NewsCountList.length; j++) {
                        if (j < 10) {
                            sourceNewsHtml += "<div class='source-tile news'> <div class='SourceTitle'> <span>" +
                               data.NewsCountList[j].SourceMedia +
                               "</span> <div class='SourceCount'><span>" + toPersianNum(data.NewsCountList[j].CountMedia) +
                               "</span></div></div></div>";
                        }
                        newsData.push({ 'name': [data.NewsCountList[j].SourceMedia], 'weight': parseFloat(data.NewsCountList[j].CountMedia) });
                    }
                    for (var k = 0; k < data.NewsPaperCountList.length; k++) {
                        if (k < 10) {
                            sourceNewspaperHtml += "<div class='source-tile newspaper'> <div class='SourceTitle'> <span>" +
                               data.NewsPaperCountList[k].SourceMedia +
                               "</span> <div class='SourceCount'><span>" + toPersianNum(data.NewsPaperCountList[k].CountMedia) +
                               "</span></div></div></div>";
                        }
                        newspaperData.push({ 'name': [data.NewsPaperCountList[k].SourceMedia], 'weight': parseFloat(data.NewsPaperCountList[k].CountMedia) });
                    }
                    for (var l = 0; l < data.TelegramCountList.length; l++) {
                        sourceTelegramHtml += "<div class='source-tile telegram'> <div class='SourceTitle'> <span>" +
                           data.TelegramCountList[l].SourceMedia +
                           "</span> <div class='SourceCount'><span>" + toPersianNum(data.TelegramCountList[l].CountMedia) +
                           "</span></div></div></div>";
                        telegramData.push({ 'name': [data.TelegramCountList[l].SourceMedia], 'y': parseFloat(data.TelegramCountList[l].CountMedia) });
                    }
                    for (var t = 0; t < data.TwitterCountList.length; t++) {
                        sourceTwitterHtml += "<div class='source-tile twitter'> <div class='SourceTitle'> <span>" +
                           data.TwitterCountList[t].SourceMedia +
                           "</span> <div class='SourceCount'><span>" + toPersianNum(data.TwitterCountList[t].CountMedia) +
                           "</span></div></div></div>";
                        twitterData.push({ 'name': [data.TwitterCountList[t].SourceMedia], 'y': parseFloat(data.TwitterCountList[t].CountMedia) });
                    }

                    // Build the chart
                    Highcharts.chart('highSourceChart', {
                        chart: {

                            backgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie',

                            style: {
                                fontFamily: 'Conv_BTrafficBold',


                            },
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: %{point.percentage:.1f}',
                            style: {
                                textShadow: false,
                                textOutline: false,
                                fontWeight: 'normal',
                                fontSize: '12px',
                                width: '100px',

                            },
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                colors: ['#ff823f', '#14a0c1', '#0099ff', '#00ccff', '#f15e78'],
                                dataLabels: {
                                    enabled: true,
                                    color: '#000000',
                                    style: {
                                        textShadow: false,
                                        textOutline: false,
                                        fontWeight: 'normal',
                                        fontSize: '12px',

                                    },
                                    format: '{point.name}:   %{point.percentage:.1f}',
                                    distance: 10,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 1
                                    }
                                }
                            }
                        },
                        series: [{
                            name: '',
                            data: newData
                        }]
                    });


                    $("#divhighSourceTotal").html('<span>' + toPersianNum(data.AllMediaCount.AllMediaCount) + '</span>');
                    $("#divNewsHighSource").html(sourceNewsHtml);
                    $("#divNewspaperHighSource").html(sourceNewspaperHtml);
                    $("#divTelegramHighSource").html(sourceTelegramHtml);
                    $("#divTwitterHighSource").html(sourceTwitterHtml);

                    $("#divCountingStatistic").html(page3FullHtml);

                    Highcharts.chart('chartNews', {

                        series: [{
                            type: 'wordcloud',
                            data: newsData,
                            name: 'Occurrences',

                        }],
                        rotation: {
                            from: -60,
                            to: 60,
                            orientations: 5
                        },

                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',


                            }

                        },
                        title: {
                            text: 'نمایش ابری توزیع اخبار در پایگاه های خبری و سایت های خبری',
                            style: {
                                fontSize: '15px',
                                fontWeight: 'bold',
                                fontFamily: 'Conv_BTrafficBold',
                            }
                        }
                    });

                    $('#chartTwitter').highcharts({
                        align: 'left',

                        left: 0,
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a',
                            },
                            type: 'bar',
                            backgroundColor: 'transparent'
                        },
                        xAxis: {
                            type: 'category',
                            labels: {
                                style: {
                                    fontSize: '9px',
                                    fontFamily: 'Conv_BTrafficBold',
                                }
                            }
                        },
                        yAxis: {
                            title: {
                                text: ''
                            },
                            labels: {
                                style: {
                                    fontSize: '9px',
                                    fontFamily: 'Conv_BTrafficBold',
                                }
                            }
                        },
                        title: {
                            text: 'فعال ترین اکانت های توییتر',

                            style: {
                                fontSize: '15px',
                                fontWeight: 'bold',
                                fontFamily: 'Conv_BTrafficBold',
                            }
                        },
                        legend: {
                            enabled: false
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            series: {
                                colorByPoint: true
                            }
                        },
                        series: [{
                            type: 'bar',
                            dataLabels: {
                                enabled: true,
                                color: '#000000',
                                format: '{point.y:.0f}', // one decimal
                                x: 7,
                                y: 2,
                                style: {
                                    fontSize: '11px',
                                }
                            },

                            data: twitterData

                        }]
                    });


                    Highcharts.chart('chartTelegram', {
                        chart: {
                            type: 'column',

                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                            },
                        },
                        title: {
                            text: 'نمودار فعال ترین کانال های تلگرامی',
                            style: {
                                fontSize: '15px',
                                fontWeight: 'bold',
                                fontFamily: 'Conv_BTrafficBold',
                            }
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            type: 'category',
                            labels: {
                                rotation: -20,
                                style: {
                                    fontSize: '9px',
                                    fontFamily: 'Conv_BTrafficBold',
                                }
                            }
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: ''
                            },
                            style: {
                                fontSize: '9px',
                                fontFamily: 'Conv_BTrafficBold',
                            }
                        },
                        legend: {
                            enabled: false
                        },
                        tooltip: {
                            pointFormat: '{point.y:.0f}</b>'
                        },
                        plotOptions: {
                            series: {
                                colorByPoint: true
                            }
                        },
                        series: [{
                            name: 'Population',
                            data: telegramData,
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '13px',
                                }
                            }
                        }]
                    });



                    Highcharts.chart('chartNewspaper', {
                        series: [{
                            type: 'wordcloud',
                            data: newspaperData,
                            name: 'Occurrences'
                        }],
                        rotation: {
                            from: -60,
                            to: 60,
                            orientations: 5
                        },

                        chart: {
                            backgroundColor: '#f2f2f2',
                            style: {
                                fontFamily: 'Conv_BTrafficBold',


                            }

                        },
                        title: {
                            text: 'نمایش ابری توزیع اخبار در روزنامه ها',
                            style: {
                                fontSize: '15px',
                                fontWeight: 'bold',
                                fontFamily: 'Conv_BTrafficBold',
                            }
                        }
                    });

                    $("#divCountingStatistic").css("display", "block");
                    $("#imgLoadPage1").css("display", "none");

                    $("#divAllMediaHighSource").css("display", "block");
                    $("#divNewsHighSource").css("display", "block");
                    $("#divNewspaperHighSource").css("display", "block");
                    $("#divTelegramHighSource").css("display", "block");
                    $("#divTwitterHighSource").css("display", "block");
                    $("#imgLoadPage2").css("display", "none");

                }
            });
        }
    </script>
    <script>
        function getImportantMedia_page3(p, f, t, ft, tt, k) {
            $("#divImportantNewspaper").css("display", "none");
            $("#divImportantNews").css("display", "none");
            $("#divImportantTelegram").css("display", "none");
            $("#divImportantTwitter").css("display", "none");
            $("#imgLoadPage3").css("display", "block");
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetImportantMedia.ashx?p=" + p + "&f=" + f + "&t=" + t + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var newspaperImage = "<div class='media-pic newspaper'><img  src='/Pages/P-Art/Images/analyze/newspaper.png' /><h3 class='root'>مهمترین عناوین</h3><h3 class='sub'>روزنامه ها</h3></div>";
                    var newsImage = "<div class='media-pic news'><img  src='/Pages/P-Art/Images/analyze/rss.png' /><h3 class='root'>مهمترین عناوین</h3><h3 class='sub'>خبرگزاری ها</h3></div>";
                    var telegramImage = "<div class='media-pic telegram'><img  src='/Pages/P-Art/Images/analyze/telegram.png' /><h3 class='root'>مهمترین عناوین</h3><h3 class='sub'>تلگرام</h3></div>";
                    var twitterImage = "<div class='media-pic twitter'><img  src='/Pages/P-Art/Images/analyze/twitter.png' /><h3 class='root'>مهمترین عناوین</h3><h3 class='sub'>توییتر</h3></div>";
                    var newsItems = "<div id='divImportantNewsTitle' class='media-titles'><ul>";
                    var newsCountItems = "<div id='divImportantNewsCount' class='media-analyze'>";
                    var newspaperItems = "<div id='divImportantNewspaperTitle' class='media-titles'><ul>";
                    var newspaperCountItems = "<div id='divImportantNewspaperCount' class='media-analyze'>";

                    var telegramItems = "<div id='divImportantTelegramTitle' class='media-titles'><ul>";
                    var telegramCountItems = "<div id='divImportantTelegramCount' class='media-analyze'>";
                    var twitterItems = "<div id='divImportantTwitterTitle' class='media-titles'><ul>";
                    var twitterCountItems = "<div id='divImportantTwitterCount' class='media-analyze'>";

                    for (var i = 0; i < data.NewspaperList.length; i++) {
                        newspaperItems += "<li><span>" + data.NewspaperList[i].NewsTitleShort + "</span></li>";
                        newspaperCountItems += "<span class='calculate'> <span>تعداد باز نشر</span><span class='calRelease'>" + toPersianNum(data.NewspaperList[i].RelatedCount) + "</span></span>";
                    }
                    for (var i = 0; i < data.NewsList.length; i++) {
                        newsItems += "<li><span>" + data.NewsList[i].NewsTitleShort + "</span></li>";
                        newsCountItems += "<span class='calculate'> <span>تعداد باز نشر</span><span class='calRelease'>" + toPersianNum(data.NewsList[i].RelatedCount) + "</span></span>";
                    }
                    for (var i = 0; i < data.TelegramList.length; i++) {
                        telegramItems += "<li><span>" + data.TelegramList[i].MessageTextShort + "</span></li>";
                        telegramCountItems += "<span class='calculate'> <span>تعداد باز دید</span><span class='calRelease'>" + toPersianNum(data.TelegramList[i].ViewCount) + "</span></span>";
                    }
                    for (var i = 0; i < data.TwitterList.length; i++) {
                        twitterItems += "<li><span>" + data.TwitterList[i].TextShort + "</span></li>";
                        twitterCountItems += "<span class='calculate'> <span>تعداد باز نشر</span><span class='calRelease'>" + toPersianNum(data.TwitterList[i].RetweetCount) + "</span></span>";
                    }
                    newspaperItems += "</ul></div>";
                    newsItems += "</ul></div>";
                    telegramItems += "</ul></div>";
                    twitterItems += "</ul></div>";
                    newspaperCountItems += "</div><div style='clear: both;'></div>";
                    newsCountItems += "</div><div style='clear: both;'></div>";
                    telegramCountItems += "</div><div style='clear: both;'></div>";
                    twitterCountItems += "</div><div style='clear: both;'></div>";
                    $("#divImportantNewspaper").html(newspaperImage + newspaperItems + newspaperCountItems);
                    $("#divImportantNews").html(newsImage + newsItems + newsCountItems);
                    $("#divImportantTelegram").html(telegramImage + telegramItems + telegramCountItems);
                    $("#divImportantTwitter").html(twitterImage + twitterItems + twitterCountItems);

                    $("#divImportantNewspaper").css("display", "block");
                    $("#divImportantNews").css("display", "block");
                    $("#divImportantTelegram").css("display", "block");
                    $("#divImportantTwitter").css("display", "block");
                    $("#imgLoadPage3").css("display", "none");
                }
            });
        }
    </script>
    <script>
        function getSugiri_page4(p, f, t, ft, tt, k) {
            $("#divNewsOrientationSource").css("display", "none");
            $("#imgLoadPage4").css("display", "block");

            $("#divMostNegativeSource").css("display", "none");
            $("#divMostPosetiveSource").css("display", "none");

            var sugiriNewsData = [];
            var posetiveNewsData = [];
            var negativeNewsData = [];
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetSugiriNews.ashx?p=" + p + "&f=" + f + "&t=" + t + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var sourceNegativeNewsHtml = "<div class='source-title'><span>منفی ترین رسانه ها</span></div>";
                    var sourcePosetiveNewsHtml = "<div class='source-title'><span>مثبت ترین رسانه ها</span></div>";

                    // Define statics html 
                    var page4FullHtml = "";

                    for (var i = 0; i < data.NewsChartList.length; i++) {
                        sugiriNewsData.push({ 'name': [data.NewsChartList[i].Name], 'y': parseFloat(data.NewsChartList[i].Value) });
                    }
                    for (var j = 0; j < data.PosetiveNewsCountList.length; j++) {
                        if (j < 10) {
                            sourcePosetiveNewsHtml += "<div class='source-tile posetive'> <div class='SourceTitle'> <span>" +
                               data.PosetiveNewsCountList[j].SourceNews +
                               "</span> <div class='SourceCount'><span>" + toPersianNum(data.PosetiveNewsCountList[j].CountNews) +
                               "</span></div></div></div>";
                        }
                    }
                    for (var k = 0; k < data.NegativeNewsCountList.length; k++) {
                        if (k < 10) {
                            sourceNegativeNewsHtml += "<div class='source-tile negative'> <div class='SourceTitle'> <span>" +
                               data.NegativeNewsCountList[k].SourceNews +
                               "</span> <div class='SourceCount'><span>" + toPersianNum(data.NegativeNewsCountList[k].CountNews) +
                               "</span></div></div></div>";
                        }
                    }

                    $("#divMostNegativeSource").html(sourceNegativeNewsHtml);
                    $("#divMostPosetiveSource").html(sourcePosetiveNewsHtml);
                    // Build the chart
                    Highcharts.chart('NewsOrientationChart', {
                        chart: {

                            backgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie',

                            style: {
                                fontFamily: 'Conv_BTrafficBold',


                            },
                        },
                        title: {
                            text: ''
                        },
                        tooltip: {
                            pointFormat: '{series.name}: %{point.percentage:.1f}',
                            style: {
                                textShadow: false,
                                textOutline: false,
                                fontWeight: 'normal',
                                fontSize: '12px',
                                width: '100px',

                            },
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',

                                colors: ['#ffffc2', '#00b8ba', '#ff0000'],
                                dataLabels: {
                                    enabled: true,
                                    color: '#000000',
                                    style: {
                                        textShadow: false,
                                        textOutline: false,
                                        fontWeight: 'normal',
                                        fontSize: '12px',

                                    },
                                    format: '{point.name}:   %{point.percentage:.1f}',
                                    distance: 10,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 1
                                    }
                                }
                            }
                        },
                        series: [{
                            name: '',
                            data: sugiriNewsData
                        }]
                    });

                    $("#divNewsOrientationSource").css("display", "block");
                    $("#imgLoadPage4").css("display", "none");
                    $("#divMostNegativeSource").css("display", "block");
                    $("#divMostPosetiveSource").css("display", "block");

                }
            });
        }
    </script>
    <script>
        function getSugiri_page5(p, f, t, ft, tt, k) {
            $("#divImportantNegative").css("display", "none");
            $("#divImportantPosetive").css("display", "none");
            $("#imgLoadPage5").css("display", "block");
            var newsSugiriDataPosetive = [];
            var newsSugiriDataNegative = [];
            var newsSugiriDataCommon = [];

            var newsSugiriDataPosetive2 = [];
            var newsSugiriDataNegative2 = [];
            var newsSugiriDataCommon2 = [];
            $.ajax({
                type: "POST",
                url: "/Services/Part_Media_Analyze_GetImportant_SugiriNews.ashx?p=" + p + "&f=" + f + "&t=" + t + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var page5FullHtml = "<div class='sugiri-chart' id='chartPosetiveSugiri' style='height: 5.8cm; width: 18cm;' ></div><div class='Negative-chart' style='height: 5.8cm; width: 18cm;' id='chartNegativeSugiri' ></div>";
                    var posetiveImage = "<div class='media-pic posetive-news'><img  src='/Pages/P-Art/Images/analyze/plus.png' /><h3 class='root'>عناوین اخبار</h3><h3 class='sub'>مثبت</h3></div>";
                    var negativeImage = "<div class='media-pic negative-news'><img  src='/Pages/P-Art/Images/analyze/negative.png' /><h3 class='root'>عناوین اخبار</h3><h3 class='sub'>منفی</h3></div>";

                    var posetiveItems = "<div id='divImportantPosetiveNewsTitle' class='media-titles'><ul>";
                    var posetiveCountItems = "<div id='divImportantPosetiveNewsCount' class='media-analyze'>";
                    var negativeItems = "<div id='divImportantNegativeNewsTitle' class='media-titles'><ul>";
                    var negativeCountItems = "<div id='divImportantNegativeNewsCount' class='media-analyze'>";

                    for (var i = 0; i < data.PosetiveNewsChartList.length; i++) {
                        newsSugiriDataPosetive.push({ 'name': [data.PosetiveNewsChartList[i].Name], 'y': parseFloat(data.PosetiveNewsChartList[i].ThirdValue) });
                        newsSugiriDataNegative.push({ 'name': [data.PosetiveNewsChartList[i].Name], 'y': parseFloat(data.PosetiveNewsChartList[i].SecondValue) });
                        newsSugiriDataCommon.push({ 'name': [data.PosetiveNewsChartList[i].Name], 'y': parseFloat(data.PosetiveNewsChartList[i].Value) });
                    }
                    for (var i = 0; i < data.NegativeNewsChartList.length; i++) {
                        newsSugiriDataPosetive2.push({ 'name': [data.NegativeNewsChartList[i].Name], 'y': parseFloat(data.NegativeNewsChartList[i].ThirdValue) });
                        newsSugiriDataNegative2.push({ 'name': [data.NegativeNewsChartList[i].Name], 'y': parseFloat(data.NegativeNewsChartList[i].SecondValue) });
                        newsSugiriDataCommon2.push({ 'name': [data.NegativeNewsChartList[i].Name], 'y': parseFloat(data.NegativeNewsChartList[i].Value) });
                    }
                    for (var i = 0; i < data.PosetiveNewsCountList.length; i++) {
                        posetiveItems += "<li><span>" + data.PosetiveNewsCountList[i].NewsTitleShort + "</span></li>";
                        posetiveCountItems += "<span class='calculate'> <span>تعداد باز نشر</span><span class='calRelease'>" + toPersianNum(data.PosetiveNewsCountList[i].RelatedCount) + "</span></span>";
                    }
                    for (var i = 0; i < data.NegativeNewsCountList.length; i++) {
                        negativeItems += "<li><span>" + data.NegativeNewsCountList[i].NewsTitleShort + "</span></li>";
                        negativeCountItems += "<span class='calculate'> <span>تعداد باز نشر</span><span class='calRelease'>" + toPersianNum(data.NegativeNewsCountList[i].RelatedCount) + "</span></span>";
                    }

                    posetiveItems += "</ul></div>";
                    negativeItems += "</ul></div>";

                    negativeCountItems += "</div><div style='clear: both;'></div>";
                    posetiveCountItems += "</div><div style='clear: both;'></div>";


                    $("#divImportantNegative").html(negativeImage + negativeItems + negativeCountItems);
                    $("#divImportantPosetive").html(posetiveImage + posetiveItems + posetiveCountItems);
                    $("#divSugiriHighSource").html(page5FullHtml);

                    Highcharts.chart('chartPosetiveSugiri', {
                        colors: ['#00b8ba', '#ff0000', '#ffffc2'],
                        chart: {
                            type: 'column',
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                            },
                        },
                        title: {
                            text: 'سوگیری رسانه ها به ترتیب مثبت ترین'
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            type: 'category',
                            crosshair: true
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: ''
                            }
                        },
                        tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        plotOptions: {
                            column: {
                                pointPadding: 0.2,
                                borderWidth: 0
                            }
                        },
                        series: [{
                            type: 'column',
                            name: 'اخبار مثبت',
                            data: newsSugiriDataPosetive2,
                            stake: 'اخبار مثبت',
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '9px',
                                }
                            }

                        }, {
                            type: 'column',
                            name: 'اخبار منفی',
                            data: newsSugiriDataNegative2,
                            stake: 'اخبار منفی',
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '9px',
                                }
                            }

                        }, {
                            type: 'column',
                            name: 'خنثی',
                            data: newsSugiriDataCommon2,
                            stake: 'خنثی',
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '9px',
                                }
                            }

                        }]
                    });

                    Highcharts.chart('chartNegativeSugiri', {
                        colors: ['#00b8ba', '#ffffc2', '#ff0000'],
                        chart: {
                            type: 'column',
                            backgroundColor: null,
                            style: {
                                fontFamily: 'Conv_BTrafficBold',

                            },

                        },
                        title: {
                            text: 'سوگیری رسانه ها به ترتیب منفی ترین'
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            type: 'category',
                            crosshair: true
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: ''
                            }
                        },
                        tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        plotOptions: {
                            column: {
                                pointPadding: 0.2,
                                borderWidth: 0
                            }
                        },
                        series: [{
                            type: 'column',
                            name: 'اخبار مثبت',
                            data: newsSugiriDataPosetive,
                            stake: 'اخبار مثبت',
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '9px',
                                }
                            }

                        }, {
                            type: 'column',
                            name: 'خنثی',
                            data: newsSugiriDataCommon,
                            stake: 'خنثی',
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '9px',
                                }
                            }

                        }, {
                            type: 'column',
                            name: 'اخبار منفی',
                            data: newsSugiriDataNegative,
                            stake: 'اخبار منفی',
                            dataLabels: {
                                enabled: true,
                                rotation: 0,
                                color: '#000000',
                                align: 'center',
                                format: '{point.y:.0f}', // one decimal
                                y: 10, // 10 pixels down from the top
                                style: {
                                    fontSize: '9px',
                                }
                            }

                        }]
                    });

                    $("#divImportantNegative").css("display", "block");
                    $("#divImportantPosetive").css("display", "block");
                    $("#divImportantPosetive").css("display", "block");
                    $("#imgLoadPage5").css("display", "none");
                }
            });
        }
    </script>
    <script>
        function getNewTableState_page6(p, f, t, ft, tt, k) {
            $("#divTableNews").css("display", "none");
            $("#imgLoadPage6").css("display", "block");
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetTableNews.ashx?p=" + p + "&f=" + f + "&t=" + t + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var newstableHtml = "<ul><li><div class='name'><span>نام</span></div><div class='count'><span>تعداد</span></div><div class='percent'><span>درصد</span></div></li>";
                    var newspapertableHtml = "<ul><li><div class='name'><span>نام</span></div><div class='count'><span>تعداد</span></div><div class='percent'><span>درصد</span></div></li>";
                    for (var i = 0; i < data.NewsCountList.length; i++) {
                        newstableHtml += "<li><div class='name'><span>" + data.NewsCountList[i].SourceMedia +
                            "</span></div><div class='count'>" + toPersianNum(data.NewsCountList[i].CountMedia) +
                            "</div><div class='percent'>" + toPersianNum(data.NewsCountList[i].PercentMedia) + " % </div></li>";
                    }
                    for (var j = 0; j < data.NewspaperCountList.length; j++) {
                        newspapertableHtml += "<li><div class='name'><span>" + data.NewspaperCountList[j].SourceMedia +
                            "</span></div><div class='count'>" + toPersianNum(data.NewspaperCountList[j].CountMedia) +
                            "</div><div class='percent'>" + toPersianNum(data.NewspaperCountList[j].PercentMedia) + " % </div></li>";
                    }
                    newstableHtml += "</ul>";
                    newspapertableHtml += "</ul>";
                    $("#divTableNewsCount").html(newstableHtml);
                    $("#divTableNewspaperCount").html(newspapertableHtml);
                }
            });

            $("#divTableNews").css("display", "block");
            $("#imgLoadPage6").css("display", "none");
        }
    </script>
    <script>
        function toPersianNum(num, dontTrim) {

            var i = 0,

                dontTrim = dontTrim || false,

                num = dontTrim ? num.toString() : num.toString().trim(),
                len = num.length,

                res = '',
                pos,

                persianNumbers = typeof persianNumber == 'undefined' ?
                    ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'] :
                    persianNumbers;

            for (; i < len; i++)
                if ((pos = persianNumbers[num.charAt(i)]))
                    res += pos;
                else
                    res += num.charAt(i);

            return res;
        }
        function print() {
            w = window.open();
            w.document.write($('#printableArea').html());
            w.print();
            w.close();
        }
    </script>
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
            background-image: url("/Pages/P-Art/Images/Jch-07.jpg");
            background-size: 100%;
            background-repeat: no-repeat;
        }

        .pageCover {
            background-image: url("/Pages/P-Art/Images/Jch-08.jpg");
            background-size: 21cm 29.7cm;
            background-repeat: no-repeat;
            overflow: hidden;
        }

        .headerBlock {
            display: block;
            width: 100%;
            height: 3cm !important;
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
                padding-right: 4px;
                font-family: "Font Awesome 5 Free" !important;
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

            .mediaCount {
            }

            .media-titles li {
                float: right;
                width: 100%;
                text-align: right;
                direction: rtl;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div style="display: none;">
            <asp:HiddenField ID="hddParmin" runat="server" />
            <asp:HiddenField ID="hddFrom" runat="server" />
            <asp:HiddenField ID="hddTo" runat="server" />
            <asp:HiddenField ID="hddFromTime" runat="server" />
            <asp:HiddenField ID="hddToTime" runat="server" />
            <asp:HiddenField ID="hddKeyword" runat="server" />
            <asp:HiddenField ID="hddParminTitle" runat="server" />
        </div>

        <%--<a class="printButton" onclick="print()"><i class="fas fa-print"></i><span>چاپ تحلیل</span></a>--%>
        <%-- <a class="printButton" href="#"><i class="fas fa-print"></i>چاپ تحلیل</a>--%>
        <div id="printableArea">
            <div class="page A4 cover">
                <div class="BulltinTitle">
                    <span>
                        <label id="CurrentParminLabel" runat="server"></label>
                    </span>
                    <br />
                    <span>
                        <asp:Label ID="FromDateLabel" runat="server" CssClass="persian persianNum"></asp:Label>
                        -
                        <asp:Label ID="ToDateLabel" runat="server" CssClass="persian persianNum"></asp:Label></span>
                </div>
            </div>

            <div class="page A4 pageCover page-layout" id="page1">
                <div class='headerBlock'></div>
                <img id="imgLoadPage1" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />
                <div id="divCountingStatistic" class="CountingStatistic"></div>
                <div style="clear: both;"></div>
            </div>
            <div class="page A4 pageCover page-layout" id="page2">
                <div class='headerBlock'></div>
                <img id="imgLoadPage2" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />
                <div id="divAllMediaHighSource" class="divAllMediaHighSource">
                    <div id="divMediaHighSourceChart">
                        <div class="highSource-title">
                            <h4>توزیع رسانه ای</h4>
                        </div>
                        <div id="highSourceChart" style="height: 6cm; width: 10cm" class="highSource-chart"></div>
                        <div id="divhighSourceTotal" class="highSourceTotal"></div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
                <div id="divNewsHighSource" class="divNewsHighSource"></div>
                <div style="clear: both;"></div>
                <div id="divNewspaperHighSource" class="divNewspaperHighSource"></div>
                <div id="divTelegramHighSource" class="divTelegramHighSource"></div>
                <div id="divTwitterHighSource" class="divTwitterHighSource"></div>
            </div>
            <div class="page A4 pageCover page-layout" id="page3">
                <div class='headerBlock'></div>
                <img id="imgLoadPage3" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />
                 <div class="page3-title"><span>تمرکز رسانه ها</span></div>
                <div id="divImportantNewspaper" class="important-media newspaper-media"></div>
                <div id="divImportantNews" class="important-media news-media"></div>
                <div id="divImportantTelegram" class="important-media telegram-media"></div>
                <div id="divImportantTwitter" class="important-media twitter-media"></div>
            </div>
            <div class="page A4 pageCover page-layout" id="page4">
                <div class='headerBlock'></div>
                <img id="imgLoadPage4" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />
                <div id="divNewsOrientationSource" class="divNewsOrientationSource">
                    <div id="divNewsOrientationChart">
                        <div class="highSource-title">
                            <h4>سوگیری اخبار</h4>
                        </div>
                        <div id="NewsOrientationChart" style="height: 9cm; width: 18cm; padding-bottom: .5cm; margin-bottom: 2cm;" class="NewsOrientation-chart"></div>
                        <div style="clear: both;"></div>
                    </div>
                </div>
                <div style="clear: both;"></div>
                <div id="divMostNegativeSource" class="divMostNegativeSource"></div>
                <div id="divMostPosetiveSource" class="divMostPosetiveSource"></div>
            </div>
            <div class="page A4 pageCover page-layout" id="page5">
                <div class='headerBlock'></div>
                <img id="imgLoadPage5" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />
                <div id="divImportantNegative" class="important-media negative-media"></div>
                <div id="divImportantPosetive" class="important-media posetive-media"></div>
                <div style="clear: both;"></div>
                <div id="divSugiriHighSource" class="divSugiriHighSource"></div>
            </div>
            <div class="page A4 pageCover page-layout" id="page6">
                <div class='headerBlock'></div>
                <img id="imgLoadPage6" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />
                <div id="divTableNews" class="TableNews">
                    <div class="table-news-header">
                        <span>جدول توزیع اخبار</span>
                    </div>
                    <div id="divTableNewsCount"></div>
                </div>
            </div>

            <div class="page A4 pageCover page-layout" id="page7">
                <div class='headerBlock'></div>
                <div id="divTableNewsPaper" class="TableNews">
                    <div class="table-news-header">
                        <span>جدول توزیع اخبار مطبوعات</span>
                    </div>
                    <div id="divTableNewspaperCount"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
