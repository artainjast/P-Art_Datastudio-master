<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Ads_OnlineBanner_Safeyi.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Ads_OnlineBanner_Safeyi" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div id="Competitors_OnlineBanner_Safeyi" class="content_container_preload_min"></div>
</figure>
<script type="text/javascript">
    function Load_Competitors_OnlineBanner_Safeyi() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        try {
            //$.ajax({
            //    type: "POST",
            //    url: "/Services/Service_Competitor.aspx/Competitors_OnlineBanner_AllData",
            //    data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (data) {
            //        DataCategory = [];
            //        DataSeries = [];

                    //for (var i = 0; i < data.d.length; i++) {

                    //    DataCategory.push([data.d[i].Name]);
                    //    DataSeries.push([data.d[i].Name, parseInt(data.d[i].Value), false]);
                    //}

                    //var json = data.d;
                    //var len = json.length
                    //i = 0;
                    var options = {
                        chart: {
                            type: 'pie',
                            options3d: {
                                enabled: true,
                                alpha: 45
                            }
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">آمار جانمایی صفحه ای تبلیغات بنری آنلاین</span> '
                        },
                        subtitle: {
                            text: ''
                        }, tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        plotOptions: {
                            pie: {
                                innerSize: 100,
                                depth: 45,
                                allowPointSelect: true,
                                useHTML: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,

                                    useHTML: true,
                                    formatter: function () {
                                        var val = this.y,
                                            allData = $.extend(true, [], this.series.processedYData).sort(),
                                            length = allData.length;
                                        if (length - 4 >= 0 && val > allData[length - 4])
                                            return val;
                                    },
                                    format: '{point.percentage:.1f} %',
                                    distance: 0,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        legend: {
                            align: 'center',
                            verticalAlign: 'bottom',
                        },
                        series: [{
                            type: 'pie',
                            showInLegend: true,
                            useHtml: true,
                            name: ' ',
                            innerSize: '50%',
                            data: [
                                ['صفحات اصلی', 41.9],
                                ['صفحات داخلی', 38.1],
                            ]

                        }]
                    };

                    $('#Competitors_OnlineBanner_Safeyi').highcharts(options);
                //}
            //});
        }
        catch (ex) {


        }
    }
</script>


