<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_Jensiat.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_Jensiat" %>
<figure class="highcharts-figure chartRow container-fluid rtl heightAbs">
    <div id="Competitors_Jensiat" class="content_container_preload_min"></div>
</figure>
<style>
    tspan.highcharts-text-outline {
        font-weight: 100 !important;
    }
</style>
<script type="text/javascript">
    function Load_By_Jensiat() {
        Highcharts.setOptions({
            colors: ['#fda238', '#9489ff', '#52dfc4']
        });
        Highcharts.chart('Competitors_Jensiat', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: 0,
                plotShadow: false
            },
            title: {
                text: '<span style="font-size: 10px;font-weight: 500;margin-top:20px">به تفکیک جنسیت</span>',
                align: 'center',
                verticalAlign: 'middle',
                y: 60
            }, tooltip: {
                headerFormat: '<span style="font-size:8px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            accessibility: {
                point: {
                    valueSuffix: '%'
                }
            },
            plotOptions: {
                pie: {
                    useHTML: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        useHtml: true,
                        distance: -50,
                        //color:'#fff',
                        style: {
                            fontWeight: 400,
                        }
                    },
                    useHtml: true,
                    startAngle: -90,
                    endAngle: 90,
                    center: ['50%', '75%'],
                    size: '110%'
                }
            },
            series: [{
                type: 'pie',
                showInLegend: true,
                useHtml: true,
                name: '',
                innerSize: '30%',
                data: [
                    ['مرد', 60.9],
                    ['زن', 39.1],


                ]
            }]
        });
    }
</script>


