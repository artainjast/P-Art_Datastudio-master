<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Ads_Mohiti_Ekran.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Ads_Mohiti_Ekran" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <a class="showing_detail campain_detail" href="#Competitors_Ads_Advertise_Campain" id="campain_detail"><i class="fa fa-lightbulb-o"></i></a> 
    <div id="Competitors_Ads_Mohiti_Ekran" class="content_container_preload_min"></div>
</figure>
<asp:HiddenField ID="hddParmin38" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_Ads_Mohiti_Ekran() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin38.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Ads_Mohiti_Ekran.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var series = data;
                    DataSeries = series;
                    console.log(DataSeries);
                    i = 0;
                    var options = {
                        chart: {
                            type: 'bar'
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">وضعیت اکران تبلیغات محیطی به تفکیک</span> '
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            categories: ['بودجه', 'تعداد اکران', 'متراژ'],
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
                        },
                        tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr>' +
                                '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        plotOptions: {
                            series: {
                                stacking: 'normal'
                            }
                        },
                        legend: {
                            reversed: true
                        },
                        credits: {
                            enabled: false
                        },
                        series: DataSeries
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_Ads_Mohiti_Ekran').highcharts(options);
                }
            });
        }
        catch (ex) {
        }
    }
    $("#campain_detail").click(function () {
        $('#campain-close').css("display", "block");
        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Ads_Advertise_Campain").offset().top
        //}, 2000);
        $("#Competitors_Ads_Advertise_Campain").slideDown();
    });
</script>


