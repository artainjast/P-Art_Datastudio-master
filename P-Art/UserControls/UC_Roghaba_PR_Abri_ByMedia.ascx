<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_Abri_ByMedia.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_Abri_ByMedia" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div id="Competitors_Abri_ByMedia" class="content_container_preload"></div>
</figure>
<asp:HiddenField ID="hddParmin22" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_Abri_BySource() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin22.ClientID %>").val();
        var newsData = [];
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Abri_BySource.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    for (var j = 0; j < data[0].data.length; j++) {
                        newsData.push({ 'name': [data[0].data[j].Name], 'weight': parseFloat(data[0].data[j].Value) });
                    }

                    var options = {

                        series: [{
                            type: 'wordcloud',
                            data: newsData,
                            name: 'فراوانی',

                        }],

                        rotation: {
                            from: -60,
                            to: 60,
                            orientations: 5
                        },

                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                            }

                        },
                        title: {
                            text: '<span style="font-size: 14px;font-weight: 500;">نمایش ابری توزیع اخبار در پایگاه های خبری و سایت های خبری</span>',
                            fontFamily: 'Conv_BTrafficBold',
                        }
                    };
                    Highcharts.setOptions({
                        colors: ['#fda238', '#9489ff', '#52dfc4', '#FF8989', '#FF89F3', '#89DBFF', '#89FF9D', '#FFF789', '#FFD489', '#89C4FF']
                    });
                    $('#Competitors_Abri_ByMedia').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
</script>


