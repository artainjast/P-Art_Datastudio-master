<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Ads_RadioVideo_AllData.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Ads_RadioVideo_AllData" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div id="Competitors_Ads_RadioVideo_AllDataCount" class="content_container_preload_min"></div>
</figure>
<asp:HiddenField ID="hddParmin5" runat="server"  />

<script type="text/javascript">
    function Load_Competitors_Ads_RadioVideo_AllDataCount() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin5.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Ads_RadioVideo_AllData.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    DataCategory = [];
                    DataSeries = [];

                    for (var i = 0; i < data.length; i++) {

                        DataCategory.push([data[i].Name]);
                        DataSeries.push([data[i].Name, parseInt(data[i].Value), false]);
                    }

                    var json = data;
                    var len = json.length
                    i = 0;
                    var options = {
                        chart: {
                            type: 'bar'
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">فراوانی تعداد تبلیغات رصد شده صداوسیما</span> '
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            categories: ['بیمه کوثر', 'بیمه پاسارگاد', 'بیمه آسیا'],
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
                        }, tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        plotOptions: {
                            bar: {
                                dataLabels: {
                                    enabled: true
                                }
                            }
                        },
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            verticalAlign: 'top',
                            x: -40,
                            y: 80,
                            floating: true,
                            borderWidth: 1,
                            backgroundColor:
                                Highcharts.defaultOptions.legend.backgroundColor || '#FFFFFF',
                            shadow: true
                        },
                        credits: {
                            enabled: false
                        },
                        series: [{
                            name: 'تعداد کل تبلیعات در صدا و سیما',
                            data: DataSeries,
                            showInLegend: false

                        }]
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_Ads_RadioVideo_AllDataCount').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
</script>


