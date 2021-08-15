<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimelineReport.aspx.cs" Inherits="P_Art.TimelineReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش جریان خبری</title>
    <link href="/Styles/htmlTimeLineReport.css?ver=1.0" rel="stylesheet" />
    <style type="text/css" media="print">
        .page {
            margin: 0;
            box-shadow: 0;
            border: 0;
        }

        .PageContainer {
            margin-top: 10mm;
            margin-bottom: 10mm;
            page-break-after: unset;
            page-break-before: unset;
            page-break-inside: unset;
        }
    </style>
    <meta charset="utf-8" />
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width" />
    <meta http-equiv="Content-Security-Policy" />
    <link href="http://fontawesome.io/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="True" />
        <div>
            <div class="newsContainer">
                <asp:Literal runat="server" ID="ltHtml"></asp:Literal>


               <%-- <div id="chart7" style="max-height: 800px;">
                </div>--%>
            </div>
        </div>
    </form>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jQuery1.11.3/jquery.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/highcharts.js") %>'></script>
    <script src="/Scripts/jquery.lazy.min.js"></script>
    <script src="/Scripts/localScroll.js"></script>

    <script>

        $(document).ready(function () {
            analyz_LoadChart1();
            analyz_LoadChart2();
        });
        function analyz_LoadChart1() {
            newData = [];
            newData2 = [];

            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/ChartNewsSubjectValue",
                data: "{'type':'1'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {

                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    }

                    $.ajax({
                        type: "POST",
                        url: "/pages/p-art/pages/ajax.aspx/ChartNewsSubjectValue",
                        data: "{'type':'2'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data2) {
                            for (var i = 0; i < data2.d.length; i++) {

                                newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                            }
                            // $("#progress7").animate({ width: '100%' }, 400);
                            $('#chart1').highcharts({
                                chart: {
                                    type: 'column'
                                },
                                xAxis: {
                                    type: 'category',
                                    rotation: 0
                                },
                                yAxis: {
                                    title: {
                                        text: 'نرم افزار اتوماسیون متمرکز روابط عمومی'
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
                                    name: 'خبرگزاری ها',
                                    data: newData,
                                    stake: 'خبرگزاری ها'

                                }, {
                                    type: 'column',
                                    name: 'روزنامه ها',
                                    data: newData2,
                                    stake: 'روزنامه ها'

                                }]
                            });


                        }
                    });
                }
            });
        }
        function analyz_LoadChart2() {
            newcData = [];
            newcData2 = [];
            newcData3 = [];

            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/ChartNewsSubjectNewsValue",
                data: "{'type':'1'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {

                        newcData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    }

                    $.ajax({
                        type: "POST",
                        url: "/pages/p-art/pages/ajax.aspx/ChartNewsSubjectNewsValue",
                        data: "{'type':'2'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data2) {
                            for (var i = 0; i < data2.d.length; i++) {

                                newcData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                            }
                            // $("#progress7").animate({ width: '100%' }, 400);
                          
                            $.ajax({
                                type: "POST",
                                url: "/pages/p-art/pages/ajax.aspx/ChartNewsSubjectNewsValue",
                                data: "{'type':'3'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data3) {
                                    for (var i = 0; i < data3.d.length; i++) {

                                        newcData3.push([data3.d[i].Name, parseInt(data3.d[i].Value)]);

                                    }
                                    // $("#progress7").animate({ width: '100%' }, 400);

                                    $('#chart2').highcharts({
                                        chart: {
                                            type: 'line'
                                        },
                                        xAxis: {
                                            type: 'category',
                                            rotation: 0,
                                            style: {
                                                width: '100%',
                                                display:'inline-block'
                                            }
                                        },
                                        yAxis: {
                                            title: {
                                                text: 'نرم افزار اتوماسیون متمرکز روابط عمومی'
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
                                            type: 'line',
                                            name: 'مثبت',
                                            data: newcData,
                                            stake: 'مثبت'

                                        }, {
                                            type: 'line',
                                            name: 'منفی',
                                            data: newcData2,
                                            stake: 'منفی'

                                        }
                                        , {
                                            type: 'line',
                                            name: 'خنثی',
                                            data: newcData3,
                                            stake: 'خنثی'

                                        }]
                                    });

                                }
                            });

                        }
                    });


                }
            });
        }
    </script>


</body>
</html>
