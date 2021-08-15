<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_SocialMedia_Hashtag.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_SocialMedia_Hashtag" %>
<figure class="highcharts-figure chartRow container-fluid rtl heightAbs">
    <div id="Competitors_SocialMedia_Hashtag" class="content_container_preload_min"></div>
</figure>
<asp:HiddenField ID="hddParmin21" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_SocialMedia_Hashtag() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin21.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_SocialMedia_TopHashtag.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    DataCategory = [];
                    DataSeries = [];

                    for (var i = 0; i < data.length; i++) {

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
                            text: '<span style="font-size: 14px;font-weight: 500;">هشتگ های برتر</span> '
                        }, tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        subtitle: {
                            text: ''
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
                            name: 'هشتگ های برتر',
                            data: DataSeries,
                            showInLegend: true

                        }]
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_SocialMedia_Hashtag').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
</script>


