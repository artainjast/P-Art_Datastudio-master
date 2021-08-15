<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_AllData.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_AllData" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div id="Competitors_AllDataCount" class="content_container_preload_min"></div>
</figure>
<asp:HiddenField ID="hddParmin1" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_AllDataCount() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin1.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_AllDataCount.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
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
                            type: 'pie',
                            options3d: {
                                enabled: true,
                                alpha: 45
                            }
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">تعداد کل محتوا در تمام رسانه ها</span> '
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
                            name: '',
                            data: DataSeries,
                            showInLegend: true

                        }]
                    };
                    $('#Competitors_AllDataCount').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
</script>


