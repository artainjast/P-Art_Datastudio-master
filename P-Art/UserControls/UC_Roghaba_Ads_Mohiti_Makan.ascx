<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Ads_Mohiti_Makan.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Ads_Mohiti_Makan" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div id="Competitors_Ads_Mohiti_Makan" class="content_container_preload_min"></div>
</figure>
<script type="text/javascript">
    function Load_Competitors_Ads_Mohiti_Makan() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //try {
        //    $.ajax({
        //        type: "POST",
        //        url: "/Services/Service_Competitor.aspx/Competitors_Ads_Mohiti_Makan",
        //        data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (data) {
        //            DataCategory = [];
        //            DataSeries = [];

        //            for (var i = 0; i < data.d.length; i++) {

        //                DataCategory.push([data.d[i].Name]);
        //                DataSeries.push([data.d[i].Name, parseInt(data.d[i].Value), false]);
        //            }

        //            var json = data.d;
        //            var len = json.length
        //            i = 0;
        var options = {
            chart: {
                type: 'area'
            },
            title: {
                text: '<span style="font-size: 14px;font-weight: 500;">درصد براساس موقعیت مکانی </span> '
            },
            subtitle: {
                text: ''
            },
            xAxis: {
                categories: ['اتوبان ها', 'خیابان ها', 'میادین', 'اماکن تفریحی', 'اماکن تجاری', 'مترو', 'اتوبوس'],
                title: {
                    text: null
                }
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Payeshmedia.com',
                    align: 'high'
                },
                labels: {
                    overflow: 'justify'
                }
            }
            , tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                area: {
                    pointStart: 0,
                    marker: {
                        enabled: false,
                        symbol: 'circle',
                        radius: 2,
                        states: {
                            hover: {
                                enabled: true
                            }
                        }
                    }
                }
            },
            credits: {
                enabled: false
            },
            series: [{
                name: 'بیمه کوثر',
                data: [5, 3, 4, 8, 2, 54, 3]
            }, {
                name: 'بیمه پارسیان',
                data: [8, 9, 2, 1, 5, 5, 5]
            }, {
                name: 'بیمه پاسارگاد',
                data: [1, 1, 2, 3, 8, 8, 3]
            }]
        };
        Highcharts.setOptions({
            colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
        });
        $('#Competitors_Ads_Mohiti_Makan').highcharts(options);
        //   }
        //    });
        //}
        //catch (ex) {


    }
</script>


