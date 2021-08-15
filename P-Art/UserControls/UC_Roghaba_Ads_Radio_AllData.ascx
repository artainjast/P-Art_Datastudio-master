<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Ads_Radio_AllData.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Ads_Radio_AllData" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <a class="showing_detail radio-detail" href="#Competitors_Show_Ads_Radio_AllDataCount" id="radio-detail" ><i class="fa fa-lightbulb-o"></i></a> 
    <div id="Competitors_Ads_Radio_AllDataCount" class="content_container_preload_min"></div>
</figure>
<asp:HiddenField ID="hddParmin3" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_Ads_Radio_AllDataCount() {
        $('#radio-close').css("display", "none");
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin3.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Ads_Radio_AllData.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
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
                            text: '<span style="font-size: 14px;font-weight: 500;">تعداد محتوا تبلیغات رادیو</span> '
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
                            name: 'تعداد کل محتوای تبلیغات در رادیو',
                            data: DataSeries,
                            showInLegend: true

                        }]
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_Ads_Radio_AllDataCount').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }

    $("#radio-detail").click(function () {

        $('#radio-close').css("display", "block");
        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Show_Ads_Radio_AllDataCount").offset().top
        //}, 2000);
        $("#Competitors_Show_Ads_Radio_AllDataCount").slideDown();
    });
</script>


