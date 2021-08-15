<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_Instagram_Mohtava.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_Instagram_Mohtava" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <a id="instagram-detail" href="#Competitors_Show_PR_Instagram_Mohtava" class="showing_detail instagram-detail" ><i class="fa fa-lightbulb-o"></i></a>
    <div id="Competitors_Instagram_Mohtava" class="content_container_preload"></div>
</figure>
<asp:HiddenField ID="hddParmin10" runat="server" />
<script type="text/javascript">
    function Load_Competitors_Instagram_Mohtava() {
        $('#instagram-close').css("display", "none");
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin10.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Instagram_Mohtava.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var series = data;
                    DataSeries = series;
                    var options = {

                        chart: {
                            type: 'area'
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">رفتار رقبا در شبکه اجتماعی اینستاگرام</span> '
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
                                'لایک',
                                'کامنت',
                                'ویدیوها',
                                'عکس ها',
                                'کل محتوا'
                            ],
                            crosshair: true
                        },
                        legend: {
                            enabled: true
                        },
                        series: DataSeries
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_Instagram_Mohtava').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }

    $("#instagram-detail").click(function () {
        $('#instagram-close').css("display", "block");
        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Show_PR_Instagram_Mohtava").offset().top
        //}, 2000);
        $("#Competitors_Show_PR_Instagram_Mohtava").slideDown();
    });
</script>


