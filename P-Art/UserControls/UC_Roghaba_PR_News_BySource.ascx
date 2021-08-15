<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_News_BySource.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_News_BySource" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
     <a id="newsbysource-detail" href="#Competitors_Show_PR_News_BySource" class="showing_detail newsbysource-detail" ><i class="fa fa-lightbulb-o"></i></a>
    <div id="Competitors_News_BySource" class="content_container_preload"></div>
</figure>
<asp:HiddenField ID="hddParmin23" runat="server" />
<script type="text/javascript">
    function Load_Competitors_News_BySource() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin23.ClientID %>").val();
        var DataSeries = [];
        var DataCatgories = [];
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_News_BySource.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var jsonCategories = "[";
                    var selectedCat = data[0].data;
                    console.log("f1");
                    console.log(selectedCat);
                    for (var ctg = 1; ctg < data.length; ctg++) {
                        if (selectedCat.length < data[ctg].data.length)
                            selectedCat = data[ctg].data;
                    }
                    console.log("f2");
                    console.log(selectedCat);
                    for (var b = 0; b < selectedCat.length; b++) {
                        if (b < selectedCat.length - 1) {
                            try { jsonCategories += "\"" + selectedCat[b].Name + "\"," } catch (err) {
                                jsonCategories += "\"" + "0" + "\","
                            }
                        }
                        else {
                            try {
                                jsonCategories += "\"" + selectedCat[b].Name  + "\"";
                            }
                            catch (err) {
                                jsonCategories += "\"" + "0"  + "\"";
                            }
                        }
                    }
                    jsonCategories += "]";

                    console.log(jsonCategories);

                    var jsonSeries = "["
                    for (var i = 0; i < data.length; i++) {
                        if (i < data.length - 1) {
                            jsonSeries += "{\"name\":\"" + data[i].Name + "\",\"data\":[";
                            for (var j = 0; j < data[i].data.length; j++) {
                                if (j < data[i].data.length - 1)
                                    jsonSeries += data[i].data[j].Value + ",";
                                else jsonSeries += data[i].data[j].Value;
                            }
                            jsonSeries += "]},"
                        }
                        else {
                            jsonSeries += "{\"name\":\"" + data[i].Name + "\",\"data\":[";
                            for (var j = 0; j < data[i].data.length; j++) {
                                if (j < data[i].data.length - 1)
                                    jsonSeries += data[i].data[j].Value + ",";
                                else jsonSeries += data[i].data[j].Value;
                            }
                            jsonSeries += "]}"
                        }
                    }
                    jsonSeries += "]";
                    var options = {

                        chart: {
                            type: 'column'
                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">برترین رسانه انتشار دهنده محتوا در پایگاه های خبری</span> '
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
                            categories: JSON.parse(jsonCategories),
                            crosshair: true
                        },
                        legend: {
                            enabled: true
                        },
                        series: JSON.parse(jsonSeries)
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_News_BySource').highcharts(options);


                    $('.pageloading').removeClass('showing');

                }
            });
        }
        catch (ex) {


        }
    }

    $("#newsbysource-detail").click(function () {
        $('#newsbySource-close').css("display", "block");
        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Show_PR_News_BySource").offset().top
        //}, 2000);
        $("#Competitors_Show_PR_News_BySource").slideDown();
    });
</script>


