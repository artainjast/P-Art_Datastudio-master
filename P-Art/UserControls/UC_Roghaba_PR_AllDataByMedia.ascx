<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_AllDataByMedia.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_AllDataByMedia" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div id="Competitors_AllDataCountWithMediaType" class="content_container_preload"></div>
</figure>
<asp:HiddenField ID="hddParmin2" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_AllDataCountWithMediaType() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin2.ClientID %>").val();
        console.log(fromDate);
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_AllDataCountWithMediaType.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var series = data;
                    DataSeries = series;
                    var options = {

                        chart: {
                            type: 'column'
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">میزان تمام داده ها به تفکیک رسانه</span> '
                        },
                        subtitle: {
                            text: ''
                        },
                        plotOptions: {
                            column: {
                                pointPadding: 0.2,
                                borderWidth: 0
                            }
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: 'تعداد'
                            },
                            stackLabels: {
                                style: {
                                    color: '#000',
                                    fontWeight: 'bold'
                                },
                                enabled: true,
                                verticalAlign: 'top'
                            }
                        }, tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        xAxis: {
                            categories: [
                                'سایت های خبری',
                                'مطبوعات',
                                'تلگرام',
                                'توییتر',
                                'اینستاگرام'
                            ],
                            crosshair: true
                        },
                        legend: {
                            enabled: true
                        },
                        series: DataSeries
                    };
                    Highcharts.setOptions({
                         colors: ['#fda238', '#9489ff', '#52dfc4','#FF8989','#FF89F3','#89DBFF','#89FF9D','#FFF789','#FFD489','#89C4FF']
                    });
                    $('#Competitors_AllDataCountWithMediaType').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
</script>


